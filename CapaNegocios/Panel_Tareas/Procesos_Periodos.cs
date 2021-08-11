using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CapaNegocios.Panel_Tareas
{
    public class Procesos_Periodos
    {
        public enum Periodos
        {
            Todos_Los_Dias = 1,
            Una_Vez_Por_Semana = 2,
            Una_Vez_Por_Mes = 3
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }

        private readonly Conexion oCon = new Conexion();

        public DataTable Listar()
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT id, descripcion FROM procesos_periodos");
                DataTable dt = oCon.Tabla();
                oCon.DesConectar();

                return dt;
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }
        }
    }
}
