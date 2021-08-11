using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Globalization;
using CapaDatos;
using CapaNegocios;

namespace CapaNegocios
{
    public class Servicios_Grupos
    {
        private Conexion oCon = new Conexion();
        public enum GRUPO
        {
            CABLE =1 ,
            INTERNET=2
        }
    }
}
