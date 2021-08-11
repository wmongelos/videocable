using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class GPS
    {
        private ConexionesExternas oConExterna = new ConexionesExternas();

        public GPS()
        {
            oConExterna.conexionString = "server=192.168.20.250;uid=gestionavc;pwd=gest10n_avc;database=avcdigital;";
        }

        public void EnviarParte(Int32 IdParte)
        {
            if (System.Diagnostics.Debugger.IsAttached)
                return;

            Partes oPartes = new Partes();

            DataRow drParte = oPartes.TraerParteRow(IdParte);

            if (Convert.ToInt32(drParte["id_partes_operaciones"]) == Convert.ToInt32(Partes.Partes_Operaciones.PARTE_INTERNO))
                return;

            //String codigo = String.Format("{0}{1}", drParte["codigo"].ToString(), drParte["id_usuarios_locaciones"]);
            Int32 codigoUsu = Convert.ToInt32(drParte["codigo"].ToString());
            String nombreUsu = String.Format("{0}, {1}", drParte["apellido"].ToString(), drParte["nombre"].ToString());
            String locUsu = drParte["localidad"].ToString();
            String calleSer = drParte["calle"].ToString();
            Int32 altSer = Convert.ToInt32(drParte["altura"].ToString());
            String pisoSer = drParte["piso"].ToString();
            String dptoSer = drParte["depto"].ToString();
            Int32 tipoSer = 0;

            try
            {
                tipoSer = Convert.ToInt32(drParte["id_servicios_grupos"].ToString());

            }
            catch (Exception)
            {
                tipoSer = 1;
            }



            String telSer = drParte["telefono_1"].ToString();

            String queryUsuario = String.Format("REPLACE INTO usuario(codusu, nomusu, locser, domser, altser, pisoser, deptoser, detall, tipser, telser) " +
                "VALUES({0}, UPPER('{1}'), UPPER('{2}'), UPPER('{3}'), {4}, '{5}', '{6}','', {7}, '{8}')", codigoUsu, nombreUsu, locUsu, calleSer, altSer, pisoSer, dptoSer, tipoSer, telSer);

            String fecha = Convert.ToDateTime(drParte["fecha_reclamo"]).ToString("yyyy-MM-dd HH:mm");
            String tipord = drParte["solicitud"].ToString();
            String ubicacion = String.Format("{0} {1} {2} {3}", calleSer, altSer, pisoSer, dptoSer);
            Int32 idoper = Convert.ToInt32(drParte["id_operadores"].ToString());
            String obser = String.Format("{0} : {1}", drParte["servicio"].ToString(), drParte["detalle_falla"].ToString());
            Int32 prioridad = 3;


            String queryParte = String.Format("INSERT INTO reclamos(codusu, numord, fecrec, tipord, ubicacion, codadm, observaciones, prioridad, tipser) " +
                "VALUES({0}, {1}, '{2}', UPPER('{3}'), UPPER('{4}'), {5}, UPPER('{6}'), {7}, {8})", codigoUsu, IdParte, fecha, tipord, ubicacion, idoper, obser, prioridad, tipoSer);

            try
            {
                oConExterna.Conectar();
                oConExterna.CrearComando(queryUsuario);
                oConExterna.EjecutarComando();

                oConExterna.CrearComando(queryParte);
                oConExterna.EjecutarComando();
                oConExterna.Desconectar();
            }
            catch { }
        }

        public Int32 GuardarObservacion(Int32 idParte, Parte_Observacion oObs)
        {
            try
            {
                oConExterna.Conectar();

                oConExterna.CrearComando("INSERT INTO reclamos_log (numord,area,quien,cuando,observaciones) VALUES (@idparte,@idarea,@idpersonal,@fecha,@obs)");
                oConExterna.AsignarParametroEntero("@idparte", oObs.IdParte);
                oConExterna.AsignarParametroEntero("@idarea", oObs.IdArea);
                oConExterna.AsignarParametroEntero("@idpersonal", oObs.IdPersonal);
                oConExterna.AsignarParametroFecha("@fecha", oObs.Fecha);
                oConExterna.AsignarParametroCadena("@obs", oObs.Texto);
                oConExterna.ComenzarTransaccion();
                oConExterna.EjecutarComando();
                oConExterna.ConfirmarTransaccion();
                oConExterna.Desconectar();
            }
            catch (Exception)
            {
                oConExterna.CancelarTransaccion();
                oConExterna.Desconectar();
                return -1;
            }
            return 0;
        }


        public Int32 AnularParte(Int32 idParte)
        {
            try
            {
                oConExterna.Conectar();
                oConExterna.CrearComando("UPDATE Reclamos SET fecanu = now() where numord = @id;");
                oConExterna.AsignarParametroEntero("@id", idParte);
                oConExterna.ComenzarTransaccion();
                oConExterna.EjecutarComando();
                oConExterna.ConfirmarTransaccion();
                oConExterna.Desconectar();
            }
            catch (Exception)
            {
                oConExterna.CancelarTransaccion();
                oConExterna.Desconectar();
                return -1;
            }
            return 0;
        }

        public DataTable ListarObservaciones(int idParte)
        {
            DataTable dt = new DataTable();
            try
            {
                oConExterna.Conectar();

                string consulta = "SELECT numord , cuando , IFNULL(nombre,'') AS nombre , IFNULL(administrativos_new.area,'') AS AREA,"
                          + " observaciones FROM reclamos_log"
                          + " LEFT JOIN administrativos_new ON administrativos_new.codigo = reclamos_log.quien WHERE numord = @idParte";

                oConExterna.CrearComando(consulta);
                oConExterna.AsignarParametroEntero("@idParte", idParte);
                dt = oConExterna.Tabla();
                oConExterna.Desconectar();
            }
            catch (Exception)
            {
                oConExterna.Desconectar();
                throw;
            }
            return dt;
        }

    }
}
