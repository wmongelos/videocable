using CapaNegocios;
using System;
using System.Diagnostics;
using System.IO;
using System.Web;

namespace CapaPresentacion
{
    public class Log
    {
        public enum ACCION
        {
            INICIO_SESION = 1,
            NUEVO_PARTE_CONEXION = 2,
            CIERRE_CAJA = 3,
            NUEVO_USUARIO = 4,
            NUEVA_UNIDAD_FUNCIONAL = 5,
            NUEVA_NOVEDAD = 6,
            NUEVA_LOCACION = 7,
            NUEVO_USUARIO_SERVICIO = 8,
            NUEVO_COMPROBANTE = 9,
            NUEVO_CTACTE = 10,
            NUEVO_CTACTE_DET = 11,
            NUEVO_COMPROBANTE_MANUAL = 12,
            BORRAR_COMPROBANTE = 13,
            AFIP = 14,
            BAJA_DEBITO_AUTOMATICO = 15
        }

        public static void guardarLog(object obj, Exception ex)
        {
            string fecha = System.DateTime.Now.ToString("yyyyMMdd");
            string hora = System.DateTime.Now.ToString("HH:mm:ss");
            string path = HttpContext.Current.Request.MapPath("~/log/" + fecha + ".txt");

            StreamWriter sw = new StreamWriter(path, true);

            StackTrace stacktrace = new StackTrace();
            sw.WriteLine(obj.GetType().FullName + " " + hora);
            sw.WriteLine(stacktrace.GetFrame(1).GetMethod().Name + " - " + ex.Message);
            sw.WriteLine("");

            sw.Flush();
            sw.Close();
        }
        public static void guardarEvento(Log.ACCION oAccion, int idUsuario = 0, int idLocacion = 0, int idUsuarioServicio = 0, String mensaje = "")
        {
            string nombrePersonal = Personal.Name_Login;
            int idPuntoLogin = Personal.Id_Login;
            string fecha = DateTime.Now.ToString("yyyyMMdd");
            string hora = DateTime.Now.ToString("HH:mm:ss");
            string ruta = Directory.GetCurrentDirectory();
            //string path = ruta +  "\\log\\log.txt";

            string path = ruta + "\\log.txt";

            //StreamWriter sw = new StreamWriter(path, true);
            StreamWriter sw = File.AppendText(path);

            //StreamWriter sw = File.CreateText(path);

            StackTrace stacktrace = new StackTrace();
            string texto = "";
            if (idUsuario != 0)
            {
                texto = oAccion.ToString() + " " + nombrePersonal + "( " + idPuntoLogin + ") " + "usuario:" + idUsuario;
                if (idLocacion != 0)
                    texto = texto + " idLocacion=" + idLocacion;
                if (idUsuarioServicio != 0)
                    texto = texto + " idUsuarioServicio=" + idUsuarioServicio;

                texto = texto + " mensaje" + mensaje;
            }
            else
                texto = oAccion.ToString() + " " + nombrePersonal + "( " + idPuntoLogin + ")";

            string textoFinal = fecha + " " + hora + " " + texto;
            sw.WriteLine(textoFinal);
            sw.Flush();
            sw.Close();


        }
    }
}
