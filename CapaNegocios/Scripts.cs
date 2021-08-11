using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocios
{
    public class Scripts
    {
        private Conexion oCon = new Conexion();

        public void EjecutarScripts()
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("");
                oCon.EjecutarComando();


                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();

                throw;
            }
        }

        private Boolean ExisteColumna(String tabla, String columna) 
        {
            try
            {
               

                oCon.Conectar();
                oCon.CrearComando("");
            }
            catch (Exception)
            {

                throw;
            }

            return false;
        }
    }
}
