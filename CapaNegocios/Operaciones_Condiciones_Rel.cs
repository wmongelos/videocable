using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CapaNegocios
{
    public class Operaciones_Condiciones_Rel
    {
        public enum Estados
        {
            Habilitado = 0,
            Advertencia = 1,
            Restringido = 2
        }

        public int Id { get; set; }
        public int Id_Parte_Operaciones { get; set; }
        public int Id_Condicion { get; set; }
        public int Estado { get; set; }

        private Conexion oCon = new Conexion();

        public void Guardar(List<Operaciones_Condiciones_Rel> oOperacionCondRel)
        {
            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();
                foreach (Operaciones_Condiciones_Rel item in oOperacionCondRel)
                {
                    if(item.Id > 0)
                    {
                        oCon.CrearComando("UPDATE operaciones_condiciones_rel SET Id_Parte_Operacion = @ParteOperaciones, " +
                            " Id_Condicion = @Condicion, Estado = @estado WHERE id = @id");
                        oCon.AsignarParametroEntero("@id", item.Id);
                    }
                    else
                    {
                        oCon.CrearComando("INSERT INTO operaciones_condiciones_rel (Id_Parte_Operacion, Id_Condicion, Estado) " +
                            " VALUES (@ParteOperaciones, @Condicion, @estado)");
                    }
                    oCon.AsignarParametroEntero("@ParteOperaciones", item.Id_Parte_Operaciones);
                    oCon.AsignarParametroEntero("@Condicion", item.Id_Condicion);
                    oCon.AsignarParametroEntero("@estado", item.Estado);
                    oCon.EjecutarComando();
                }
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
            }
            catch (Exception ex)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                throw ex;
            }
        }

        public DataTable Listar(int idParteOperacion)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT Id, Id_Parte_Operacion, Id_Condicion, Estado FROM Operaciones_Condiciones_Rel" +
                    " WHERE Id_Parte_Operacion = @idParteOperacion");
                oCon.AsignarParametroEntero("@idParteOperacion", idParteOperacion);
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
            }
            return dt;
        }
    }
}
