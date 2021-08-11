using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class Lotes
    {
        public int Id { get; set; }
        public int Id_Lote { get; set; }
        public int Id_Entidad { get; set; }
        public int Id_Registro { get; set; }

        private Conexion oCon = new Conexion();

        public void ProgramarPartesPara(List<int> registros, Entidades.Tabla tabla, DateTime fechaEjecucion)
        {
            //verificar si existe un lote de partes para esa fecha
             // -- si existe agregar los registros
             // -- si no existe crear lote y agregar


        }

        public void ProgramarPartesPara(int registro, Entidades.Tabla tabla, DateTime fechaEjecucion)
        {
            ProgramarPartesPara(new List<int> { registro }, tabla, fechaEjecucion);
        }
    }
}
