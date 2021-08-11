using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Servicios_Estados_Historial
    {
        public int id { get; set; }
        public int id_usuarios { get; set; }
        public int id_servicios { get; set; }
        public int id_servicios_estados { get; set; }
        public int id_usuarios_servicios { get; set; }
        public DateTime fecha { get; set; }

        private Conexion oCon = new Conexion();

        public void Guardar(Servicios_Estados_Historial oServicios_Estados_Historial)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("INSERT INTO servicios_estados_historial (id_usuarios,id_servicios,fecha,id_servicios_estados,id_usuarios_servicios ) " +
                                 " VALUES (@usuarios,@servicios, @fecha,@estado,@uServicio)");
                oCon.AsignarParametroEntero("@usuarios", oServicios_Estados_Historial.id_usuarios);
                oCon.AsignarParametroEntero("@servicios", oServicios_Estados_Historial.id_servicios);
                oCon.AsignarParametroFecha("@fecha", oServicios_Estados_Historial.fecha);
                oCon.AsignarParametroEntero("@estado", oServicios_Estados_Historial.id_servicios_estados);
                oCon.AsignarParametroEntero("@uServicio", oServicios_Estados_Historial.id_usuarios_servicios);
                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                throw;
            }
        }

        public DataTable Listar_Por_estados()
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando(String.Format("SELECT id_usuarios,servicios_estados_historial.id_servicios,fecha,id_servicios_estados,id_usuarios_servicios, " +
                    "Servicios.descripcion,Servicios_estados.estado  FROM servicios_estados_historial " +
                    "LEFT JOIN Servicios ON Servicios.Id = servicios_estados_historial.id_servicios " +
                    "LEFT JOIN Servicios_estados ON Servicios_estados.Id = servicios_estados_historial.id_servicios_estados " +
                    " where id_servicios_estados={0} and id_usuarios={1} ORDER BY Id_USUARIOS", id_servicios_estados, id_usuarios));

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

        public DataTable ListarPorUsuarioSevicio(int idUsuarioServicio)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando(String.Format("select id, Id_Usuarios, Id_Servicios,Id_Usuarios_Servicios, Id_Servicios_Estados, Fecha,(select fecha_estado from usuarios_servicios where id={0})as fecha_estado, (select servicios_estados.Estado from servicios_estados where id=servicios_estados_historial.Id_Servicios_Estados) as estado from servicios_estados_historial where id_usuarios_servicios={0} order by id", idUsuarioServicio));

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

        public DataTable ListarDatosUsuarioServicio(int idUsuarioServicio)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando(String.Format("select usuarios_servicios.id_usuarios, CONCAT(usuarios.nombre, ' ', usuarios.apellido) as Usuario,  CONCAT(TRIM(usuarios_locaciones.calle), ' ', TRIM(CAST(usuarios_locaciones.altura AS char(50)))) as Direccion,localidades.nombre as localidad," +
                                               " usuarios_servicios.id_zonas, zonas.nombre as Zona, usuarios_servicios.id_servicios,usuarios_servicios.id_servicios_categorias, servicios.descripcion as Servicio, servicios_categorias.nombre as Categoria, servicios_tipos.nombre as TIpo, usuarios_servicios.id_servicios_tipo, servicios_Estados.estado as Estado," +
                                               " usuarios_Servicios.id_servicios_estados, usuarios_servicios.Id as id_usuario_servicio " +
                                               " from usuarios_servicios " +
                                               " left join usuarios on usuarios.id=usuarios_servicios.id_usuarios " +
                                               " left join usuarios_locaciones on usuarios_locaciones.id=usuarios_servicios.id_usuarios_locaciones " +
                                               " left join localidades on localidades.id=usuarios_locaciones.id_localidades " +
                                               " left join zonas on zonas.id=usuarios_servicios.id_zonas " +
                                               " left join servicios on servicios.id=usuarios_servicios.id_servicios " +
                                               " left join servicios_categorias on servicios_categorias.id=usuarios_servicios.id_servicios_categorias " +
                                               " left join servicios_tipos on servicios_tipos.id=usuarios_servicios.id_servicios_tipo " +
                                               " left join servicios_estados on servicios_estados.id=usuarios_servicios.id_servicios_estados " +
                                               " WHERE  usuarios_servicios.id= {0}", idUsuarioServicio));

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
    }
}
