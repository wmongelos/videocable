using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocios
{
    public class Aplicaciones_Externas_Excepciones
    {
        public int Id_Aplicacion_Externa { get; set; }
        public string Clase { get; set; } = "";
        public string Titulo_Formulario { get; set; } = "";
        public string Operacion { get; set; } = "";
        public DateTime Fecha { get; private set; } 
        public int Id_Personal { get; set; } = 0;
        public string Mensaje_Error { get; set; } = "";
        public int Id_Usuario { get; set; } = 0;
        public int Id_Usuario_Locacion { get; set; } = 0;
        public int Id_Usuario_Servicio { get; set; } = 0;
        public int Id_Parte { get; set; } = 0;
        public int Id_Usuario_Externo { get; set; } = 0;
        public int Id_Locacion_Externa { get; set; } = 0;
        public int Id_Cuenta_Externa { get; set; } = 0;
        public int Id_Producto_Externo { get; set; } = 0;
        public string Serial_Equipo { get; set; } = "";
        public string Mac_Equipo { get; set; } = "";

        private Conexion oCon = new Conexion();

        public int Guardar(Aplicaciones_Externas_Excepciones oAppExternaExcp)
        {
            int id = 0;
            try
            {
                oCon.Conectar();
                oCon.CrearComando("INSERT INTO aplicaciones_externas_excepciones "
                    + " (Id_Aplicacion_Externa, Clase, Titulo_Formulario, Operacion, Fecha, Id_Personal, Mensaje_Error, Id_Usuario, Id_Usuario_Locacion, Id_Usuario_Servicio, Id_Parte, Id_Usuario_Externo, Id_Locacion_Externa, Id_Cuenta_Externa, Id_Producto_Externo, Serial_Equipo, Mac_Equipo) "
                    + " VALUES (@idAppExt, @clase, @tituloForm, @operacion, @fecha, @idpersonal, @mensajeError, @idusuario, @idusuLoc, @idusuServ, @idparte, @idusuExt, @idlocExt, @idcuentaExt, @idprodExt, @serialEquipo, @macEquipo); SELECT @@IDENTITY");

                oCon.AsignarParametroEntero("@idAppExt", oAppExternaExcp.Id_Aplicacion_Externa);
                oCon.AsignarParametroCadena("@clase", oAppExternaExcp.Clase);
                oCon.AsignarParametroCadena("@tituloForm", oAppExternaExcp.Titulo_Formulario);
                oCon.AsignarParametroCadena("@operacion", oAppExternaExcp.Operacion);
                oCon.AsignarParametroFecha("@fecha", DateTime.Now);
                oCon.AsignarParametroEntero("@idpersonal", oAppExternaExcp.Id_Personal);
                oCon.AsignarParametroCadena("@mensajeError", oAppExternaExcp.Mensaje_Error);
                oCon.AsignarParametroEntero("@idusuario", oAppExternaExcp.Id_Usuario);
                oCon.AsignarParametroEntero("@idusuLoc", oAppExternaExcp.Id_Usuario_Locacion);
                oCon.AsignarParametroEntero("@idusuServ", oAppExternaExcp.Id_Usuario_Servicio);
                oCon.AsignarParametroEntero("@idparte", oAppExternaExcp.Id_Parte);
                oCon.AsignarParametroEntero("@idusuExt", oAppExternaExcp.Id_Usuario_Externo);
                oCon.AsignarParametroEntero("@idlocExt", oAppExternaExcp.Id_Locacion_Externa);
                oCon.AsignarParametroEntero("@idcuentaExt", oAppExternaExcp.Id_Cuenta_Externa);
                oCon.AsignarParametroEntero("@idprodExt", oAppExternaExcp.Id_Producto_Externo);
                oCon.AsignarParametroCadena("@serialEquipo", oAppExternaExcp.Operacion);
                oCon.AsignarParametroCadena("@macEquipo", oAppExternaExcp.Operacion);

                id = oCon.EjecutarScalar();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
            }
            return id;
        }
    }
}
