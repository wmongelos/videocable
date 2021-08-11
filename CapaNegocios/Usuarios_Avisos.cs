using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Usuarios_Avisos
    {
        public int id { get; set; }
        public int id_usuarios { get; set; }
        public int id_usuarios_locaciones { get; set; }
        public int id_usuarios_servicios { get; set; }
        public int id_avisos_tipo { get; set; }
        public int id_personal { get; set; }
        public DateTime fecha { get; set; }
        public String descripcion { get; set; }
        public String receptor { get; set; }
        public String tipo_de_comunicacion { get; set; }
        public Decimal importe { get; set; }
        public string Mensaje { get; set; }
        public string Telefono { get; set; }

        private Conexion oCon = new Conexion();

        public void Guardar(Usuarios_Avisos oAvi)
        {
            try
            {
                oCon.Conectar();

                oCon.CrearComando("Insert into usuarios_avisos(id_usuarios,id_usuarios_locaciones,id_usuarios_servicios,id_avisos_tipo,id_personal,fecha,descripcion,receptor,tipo_de_comunicacion,importe,detalle,telefono) VALUES(@Id_usuarios,@Id_usuarios_locaciones,@Id_usuarios_servicios,@Id_avisos_tipo,@Id_personal,@Fecha,@Descripcion,@Receptor,@Tipo_de_comunicacion,@importe,@detalle,@telefono)");

                oCon.AsignarParametroEntero("@Id_usuarios", oAvi.id_usuarios);
                oCon.AsignarParametroEntero("@Id_usuarios_locaciones", oAvi.id_usuarios_locaciones);
                oCon.AsignarParametroEntero("@Id_usuarios_servicios", oAvi.id_usuarios_servicios);
                oCon.AsignarParametroEntero("@Id_avisos_tipo", oAvi.id_avisos_tipo);
                oCon.AsignarParametroEntero("@Id_personal", oAvi.id_personal);
                oCon.AsignarParametroFecha("@Fecha", oAvi.fecha);
                oCon.AsignarParametroCadena("@Descripcion", oAvi.descripcion);
                oCon.AsignarParametroCadena("@Receptor", oAvi.receptor);
                oCon.AsignarParametroCadena("@Tipo_de_comunicacion", oAvi.tipo_de_comunicacion);
                oCon.AsignarParametroDecimal("@importe", importe);
                oCon.AsignarParametroCadena("@detalle", Mensaje);
                oCon.AsignarParametroCadena("@telefono", oAvi.Telefono);

                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
            }
            catch (Exception c)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();

                throw;
            }
        }

        public bool Eliminar(int id, out string salida)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("UPDATE usuarios_avisos left join usuarios_locaciones on usuarios_locaciones.id = usuarios_avisos.id_usuarios_locaciones set usuarios_avisos.borrado=1,usuarios_locaciones.fecha_ultimo_aviso='2000-01-01 01:01:01' WHERE usuarios_avisos.id=@id");
                oCon.AsignarParametroEntero("@id", id);
                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
                salida = "";
                return true;
            }
            catch (Exception c)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                salida = c.ToString();
                return false;
            }
        }
        
        public bool EliminarAvisosAnteriores(int idLocacion)
        {
            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();
                oCon.CrearComando("update usuarios_avisos set borrado=1 where id_usuarios_locaciones=@idlocacion");
                oCon.AsignarParametroEntero("@idlocacion", idLocacion);
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
                return true;

            }
            catch (Exception c)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                return false;
            }
        }

        public DataTable Listar()
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT usuarios.codigo, usuarios_avisos.fecha,servicios.descripcion as servicio,concat(usuarios.apellido,', ',usuarios.nombre) as usuario,localidades.nombre as localidad, localidades_calles.nombre as calle,usuarios_locaciones.altura,usuarios_locaciones.piso,usuarios_locaciones.depto,usuarios.correo_electronico,usuarios_Avisos.id,usuarios_Avisos.importe,usuarios_Avisos.detalle,usuarios_avisos.id_usuarios_locaciones,usuarios_avisos.id_usuarios,usuarios_Avisos.id_usuarios_servicios, usuarios_servicios.id_servicios,usuarios_locaciones.id_localidades,usuarios_locaciones.id_calle,usuarios_locaciones.entre_calle_1,usuarios_locaciones.entre_calle_2,usuarios_locaciones.manzana,usuarios_locaciones.observacion,usuarios_avisos.telefono " +
                    "FROM usuarios_avisos " +
                    "left join usuarios on usuarios_avisos.id_usuarios=usuarios.id " +
                    "left join usuarios_servicios on usuarios_servicios.id=usuarios_avisos.id_usuarios_Servicios " +
                    "left join servicios on servicios.id=usuarios_Servicios.id_Servicios " +
                    "left join usuarios_locaciones on usuarios_locaciones.id=usuarios_avisos.id_usuarios_locaciones " +
                    "left join localidades on localidades.id=usuarios_locaciones.id_localidades " +
                    "left join localidades_Calles on localidades_calles.id=usuarios_locaciones.id_calle " +
                    " where usuarios_avisos.borrado=0" +
                    " order by localidades_calles.nombre, usuarios_locaciones.altura");
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }
            return dt;
        }
    
        public DataTable ListarMensajesServicios(int idServicio = 0)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                if (idServicio == 0)
                    oCon.CrearComando("SELECT * FROM servicios_avisos_detalle where borrado=0");
                else
                {
                    oCon.CrearComando("SELECT * FROM servicios_avisos_detalle where id_servicio=@id");
                    oCon.AsignarParametroEntero("@id", idServicio);
                }
                dt = oCon.Tabla();
                oCon.DesConectar();

            }
            catch (Exception)
            {

                throw;
            }
            return dt;

        }

        public DateTime getFechaUltimoAviso(int idLocacion)
        {
            DateTime fechaUltimoAviso = new DateTime(2000,1,1);
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("select fecha from usuarios_avisos where id_usuarios_locaciones=@idLocacion and borrado=0 order by fecha desc limit 1");
                oCon.AsignarParametroEntero("@idLocacion", idLocacion);
                dt = oCon.Tabla();
                oCon.DesConectar();

            }
            catch (Exception)
            {
                oCon.DesConectar();
            }
            finally
            {
                if(dt!=null && dt.Rows.Count>0)
                    fechaUltimoAviso = Convert.ToDateTime(dt.Rows[0]["fecha"]);
            }
            return fechaUltimoAviso;
        }
    }
}
