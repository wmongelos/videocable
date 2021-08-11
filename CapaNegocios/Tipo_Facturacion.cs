using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Tipo_Facturacion
    {
        private Conexion oCon = new Conexion();

        public enum Id_Tipo_Facturacion
        {
            POR_ZONAS = 1,
            POR_CATEGORIAS = 2
        }

        public void Guardar(int idtipofac, int idservicio, DataTable dt)
        {
            try
            {
                this.EliminarServicios(idtipofac, idservicio);

                oCon.Conectar();

                foreach (DataRow dr in dt.Rows)
                {
                    if (Convert.ToBoolean(dr["Seleccionar"]))
                    {
                        oCon.CrearComando("INSERT INTO tipo_facturacion_servicios(Id_Tipo_Facturacion, Id_Servicios, Id_Servicios_Sub,id_personal) VALUES(@idtipo, @idser, @idsub,@personal)");
                        oCon.AsignarParametroEntero("@idtipo", idtipofac);
                        oCon.AsignarParametroEntero("@idser", idservicio);
                        oCon.AsignarParametroEntero("@idsub", Convert.ToInt32(dr["Id"]));
                        oCon.AsignarParametroEntero("@personal", Personal.Id_Login);
                        oCon.EjecutarComando();

                    }
                }
                oCon.DesConectar();

            }
            catch (Exception)
            {
                oCon.DesConectar();

                throw;
            }
        }

        public void EliminarServicios(int idtipo, int idservicios)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("DELETE FROM tipo_facturacion_servicios WHERE Id_Servicios = @idser AND Id_Tipo_Facturacion = @idtipo");
                oCon.AsignarParametroEntero("@idser", idservicios);
                oCon.AsignarParametroEntero("@idtipo", idtipo);
                oCon.EjecutarComando();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();

                throw;
            }
        }

        public DataTable Listar()
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT tipo_facturacion_servicios.* , servicios.Descripcion AS Servicio " +
                    "FROM tipo_facturacion_servicios " +
                    "LEFT JOIN servicios ON tipo_facturacion_servicios.Id_Servicios = servicios.id " +
                    "ORDER BY id_tipo_facturacion; ");

                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch
            {
                oCon.DesConectar();
            }

            return dt;
        }    

        public DataTable Listar(int IdTipoFacturacion,bool soloServicios=false)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                if(soloServicios)
                    oCon.CrearComando(String.Format("SELECT Tipo_Facturacion_Servicios.*, servicios.descripcion as  servicio FROM Tipo_Facturacion_Servicios  left join servicios on servicios.id = Tipo_Facturacion_Servicios.id_servicios WHERE Id_Tipo_Facturacion = {0} and servicios.borrado=0 group by Tipo_Facturacion_Servicios.id_servicios", IdTipoFacturacion));
                else
                    oCon.CrearComando(String.Format("SELECT Tipo_Facturacion_Servicios.*, servicios.descripcion as  servicio FROM Tipo_Facturacion_Servicios  left join servicios on servicios.id = Tipo_Facturacion_Servicios.id_servicios WHERE Id_Tipo_Facturacion = {0} and servicios.borrado=0", IdTipoFacturacion));

                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch
            {
                oCon.DesConectar();
            }

            return dt;
        }

        public DataTable GetServicios()
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT Id_Tipo_Facturacion, Id_Servicios, Descripcion, Requiere_Equipo, Requiere_Velocidad, Requiere_Tarjeta, Forzar_Inicio_Mes, Fecha_Inicio_Servicio," +
                    "(SELECT Nombre FROM Servicios_Modalidad WHERE Id = Id_Servicios_Modalidad) AS Modalidad, Id_Servicios_Modalidad, Dias_Bonificacion," +
                    "(SELECT Id from Servicios_Grupos WHERE Id = (Select Id_Servicios_Grupos FROM Servicios_Tipos WHERE Id = Id_Servicios_Tipos)) AS Id_Servicios_Grupos, " +
                    "(SELECT Nombre from Servicios_Grupos WHERE Id = (Select Id_Servicios_Grupos FROM Servicios_Tipos WHERE Id = Id_Servicios_Tipos)) AS Grupo, " +
                    "Id_Servicios_Tipos, Tipo_Facturacion_Servicios.Id,servicios.id_aplicaciones_externas FROM Tipo_Facturacion_Servicios " +
                    "LEFT JOIN Servicios on Servicios.Id = Tipo_Facturacion_Servicios.Id_Servicios WHERE Servicios.Borrado = 0 " +
                    "GROUP BY Id_Servicios, Id_Tipo_Facturacion order by Descripcion");

                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch
            {
                oCon.DesConectar();
            }

            return dt;
        }

        public DataTable GetServiciosPorTipo(int idtipo)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                if (idtipo > 0)
                    oCon.CrearComando(String.Format("SELECT id_servicios, servicios.descripcion as servicios, servicios_tipos.id as id_tipo, servicios_grupos.id as id_grupo, servicios.requiere_velocidad,servicios.origenmeses from tipo_facturacion_servicios " +
                                                    "left join servicios on tipo_facturacion_servicios.id_servicios = servicios.id left join servicios_tipos on servicios.id_servicios_tipos = servicios_tipos.id " +
                                                    "left join servicios_grupos on servicios_tipos.id_servicios_grupos = servicios_grupos.id where id_tipo_facturacion = {0} group by id_servicios order by servicios", idtipo));
                else
                    oCon.CrearComando(String.Format("SELECT id_servicios, servicios.descripcion as servicios, servicios_tipos.id as id_tipo, servicios_grupos.id as id_grupo, servicios.requiere_velocidad,servicios.origenmeses from tipo_facturacion_servicios " +
                                                "left join servicios on tipo_facturacion_servicios.id_servicios = servicios.id left join servicios_tipos on servicios.id_servicios_tipos = servicios_tipos.id " +
                                                "left join servicios_grupos on servicios_tipos.id_servicios_grupos = servicios_grupos.id where id_tipo_facturacion > {0} group by id_servicios order by servicios", idtipo));
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch
            {
                oCon.DesConectar();
            }

            return dt;
        }

        public DataTable GetServiciosSu(int idservicios)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando(String.Format("SELECT Id_Servicios_Sub, (select descripcion from servicios_sub where id = id_servicios_sub) as servicios_sub, Id_Servicios, Id_Tipo_Facturacion, " +
                    "servicios_sub_tipos.id as idtipodesub, (select requiere_ip from servicios_sub where id = id_servicios_sub) as requiere_ip, (select valor_defecto from servicios_sub where id = id_servicios_sub) as valor_defecto from tipo_facturacion_servicios LEFT JOIN servicios_sub_tipos on servicios_sub_tipos.id = (select id_servicios_sub_tipos from servicios_sub where id = " +
                    "Id_Servicios_Sub) where id_servicios = {0}", idservicios));
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch
            {
                oCon.DesConectar();
            }

            return dt;
        }

        public DataTable GetServiciosSubPorTipo(int idtipo, int idservicios)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando(String.Format("SELECT Id_Servicios_Sub, (select descripcion from servicios_sub where id = id_servicios_sub) as servicios_sub, Id_Servicios, Id_Tipo_Facturacion, " +
                    "servicios_sub_tipos.id as idtipodesub, (select requiere_ip from servicios_sub where id = id_servicios_sub) as requiere_ip, (select valor_defecto from servicios_sub where id = id_servicios_sub) as valor_defecto from tipo_facturacion_servicios LEFT JOIN servicios_sub_tipos on servicios_sub_tipos.id = (select id_servicios_sub_tipos from servicios_sub where id = " +
                    "Id_Servicios_Sub) where Id_Tipo_Facturacion = {0} and id_servicios = {1}", idtipo, idservicios));
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch
            {
                oCon.DesConectar();
            }

            return dt;
        }

        public DataTable getZonaLocacion(int idLoc)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT localidades.id AS IdLocalidad,usuarios_locaciones.id AS idLocacion, " +
                    "zonas_localidades.Id_Zona AS idTipoFac, zonas.Nombre AS Zona, localidades.Nombre AS Localidad " +
                    "FROM usuarios_locaciones " +
                    "LEFT JOIN localidades ON usuarios_locaciones.Id_Localidades = localidades.id " +
                    "LEFT JOIN zonas_localidades ON zonas_localidades.Id_Localidad = localidades.id " +
                    "LEFT JOIN zonas ON zonas_localidades.Id_Zona = zonas.id " +
                    "WHERE usuarios_locaciones.id = @idLoc; ");
                oCon.AsignarParametroEntero("@idLoc", idLoc);
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch
            {
                oCon.DesConectar();
            }

            return dt;
        }

        public DataTable getCategoryLocacion(int idLoc)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT tipo_facturacion_servicios.Id_Tipo_Facturacion AS idTipoFac, usuarios_servicios.id AS idusuServ, " +
                    "usuarios_locaciones.id AS idLocacion, servicios.id AS idServicio   " +
                    "FROM usuarios_servicios " +
                    "LEFT JOIN usuarios_locaciones ON usuarios_servicios.Id_Usuarios_Locaciones = usuarios_locaciones.id " +
                    "LEFT JOIN servicios ON usuarios_servicios.Id_Servicios = servicios.id " +
                    "LEFT JOIN tipo_facturacion_servicios ON tipo_facturacion_servicios.Id_Servicios = servicios.id " +
                    "WHERE usuarios_locaciones.Id = @idLoc " +
                    "GROUP BY usuarios_locaciones.id, servicios.id; ");
                oCon.AsignarParametroEntero("@idLoc", idLoc);
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch
            {
                oCon.DesConectar();
            }

            return dt;
        }

        public DataTable ListarConOrigenMeses(int IdTipoFacturacion)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando(("SELECT Tipo_Facturacion_Servicios.*, servicios.descripcion as  servicio, "+
                                  " servicios.OrigenMeses" +
                                  " FROM Tipo_Facturacion_Servicios" +
                                  " left join servicios on servicios.id = Tipo_Facturacion_Servicios.id_servicios" +
                                  " WHERE servicios.borrado = 0 AND Id_Tipo_Facturacion = "+IdTipoFacturacion+" and servicios.OrigenMeses = 1"+
                                  " GROUP BY id_Servicios"));

                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch
            {
                oCon.DesConectar();
            }

            return dt;
        }

    }


}
