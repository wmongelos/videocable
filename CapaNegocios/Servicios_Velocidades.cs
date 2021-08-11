using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Servicios_Velocidades
    {
        public Int32 Id { get; set; }
        public Int32 Velocidad { get; set; }

        public Int32 Borrado { get; set; }
        public Int32 Id_Velocidad_Tipo { get; set; }

        private Conexion oCon = new Conexion();

        public int Guardar(Servicios_Velocidades oServiciosVelocidades)
        {
            try
            {
                oCon.Conectar();
                if (oServiciosVelocidades.Id > 0)
                {
                    oCon.CrearComando("UPDATE servicios_velocidades set Velocidad=@velocidad, id_velocidad_tipo=@id_velocidad_tipo,id_personal=@personal WHERE id=@id; SELECT @@IDENTITY");
                    oCon.AsignarParametroEntero("@velocidad", oServiciosVelocidades.Velocidad);
                    oCon.AsignarParametroEntero("@id_velocidad_tipo", oServiciosVelocidades.Id_Velocidad_Tipo);
                    oCon.AsignarParametroEntero("@personal", Personal.Id_Login);

                    oCon.AsignarParametroEntero("@id", oServiciosVelocidades.Id);
                }
                else
                {
                    oCon.CrearComando("INSERT INTO servicios_velocidades (velocidad, id_velocidad_tipo, Borrado,id_personal) " +
                        "VALUES (@velocidad, @id_velocidad_tipo, @borrado,@personal);SELECT @@IDENTITY");
                    oCon.AsignarParametroEntero("@velocidad", oServiciosVelocidades.Velocidad);
                    oCon.AsignarParametroEntero("@id_velocidad_tipo", oServiciosVelocidades.Id_Velocidad_Tipo);
                    oCon.AsignarParametroEntero("@borrado", 0);
                    oCon.AsignarParametroEntero("@personal", Personal.Id_Login);

                }

                oCon.ComenzarTransaccion();
                oServiciosVelocidades.Id = oCon.EjecutarScalar();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                throw;
            }

            return oServiciosVelocidades.Id;
        }

        public void Eliminar(int id)
        {
            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();
                oCon.CrearComando("UPDATE servicios_velocidades SET Borrado = 1,id_personal=@personal WHERE Id = @id");
                oCon.AsignarParametroEntero("@personal", Personal.Id_Login);
                oCon.AsignarParametroEntero("@id", id);
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

        public void ActualizarVelocidad(int Id_Usuarios_Servicios, int Id_Velocidad, int Id_Sub)
        {
            try
            {
                oCon.Conectar();
                if ((Id_Usuarios_Servicios > 0) && (Id_Velocidad > 0))
                    oCon.CrearComando("update usuarios_servicios_sub set id_servicios_velocidades=@id_servicios_velocidades where id_usuarios_servicios=@id_usuarios_servicios and id_servicios_sub=@id_servicios_sub and borrado=0");

                oCon.AsignarParametroEntero("@id_servicios_velocidades", Id_Velocidad);
                oCon.AsignarParametroEntero("@id_usuarios_servicios", Id_Usuarios_Servicios);
                oCon.AsignarParametroEntero("@id_servicios_sub", Id_Sub);
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

        public DataTable ListarVelocidades()
        {
            oCon.Conectar();
            oCon.CrearComando("SELECT servicios_velocidades.id,servicios_velocidades.velocidad,servicios_velocidades.id_velocidad_tipo,servicios_velocidades_tip.nombre as tipo FROM servicios_velocidades left join servicios_velocidades_tip on servicios_velocidades_tip.id=servicios_velocidades.id_velocidad_tipo where servicios_velocidades.borrado=0 ORDER BY Velocidad");

            DataTable dt = oCon.Tabla();

            oCon.DesConectar();

            return dt;
        }

        public DataTable ListarVelocidadesTipos()
        {
            oCon.Conectar();
            oCon.CrearComando("SELECT * FROM servicios_velocidades_tip");

            DataTable dt = oCon.Tabla();

            oCon.DesConectar();

            return dt;
        }

        public DataTable ListarPrecios(int idTarifa, int idTipoFacturacion, int idServicios)
        {
            DataTable dt;
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT *,(SELECT Nombre FROM servicios_velocidades_tip WHERE Id = Id_Servicios_Velocidad_Tip) AS Tipo," +
                    "(SELECT Velocidad FROM servicios_velocidades WHERE Id = Id_Servicios_Velocidad) AS Velocidad " +
                    "FROM servicios_tarifas_sub_esp where id_servicios_tarifas = @tarifa and id_tipo_facturacion = @idtipofac " +
                    "and id_servicios = @ser");
                oCon.AsignarParametroEntero("@tarifa", idTarifa);
                oCon.AsignarParametroEntero("@idtipofac", idTipoFacturacion);
                oCon.AsignarParametroEntero("@ser", idServicios);
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

        public DataTable ListarVelocidadesUsuarios(int id_usuarios_servicios)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("select usuarios_servicios.id,usuarios_servicios.id_zonas,usuarios_servicios.id_tipo_facturacion,usuarios_servicios.id_servicios_categorias,usuarios_servicios_sub.id_servicios_sub,usuarios_servicios_sub.id_servicios_velocidades,usuarios_servicios_sub.id_servicios_velocidades_tip,servicios_velocidades.velocidad,servicios_sub.id_servicios_sub_tipos,servicios_velocidades_tip.nombre as tipoVelocidad" +
                " from usuarios_servicios" +
                " inner join usuarios_servicios_sub on usuarios_servicios_sub.id_usuarios_servicios = usuarios_servicios.id" +
                " inner join servicios_sub on servicios_sub.id = usuarios_servicios_sub.id_servicios_sub" +
                " inner join servicios_velocidades on servicios_velocidades.id = usuarios_servicios_sub.id_servicios_velocidades" +
                " inner join servicios_velocidades_tip on servicios_velocidades_tip.id = usuarios_servicios_sub.id_servicios_velocidades_tip" +

                " where usuarios_servicios.id = @id_usuarios_servicios and id_servicios_sub_tipos=1; ");
                oCon.AsignarParametroEntero("@id_usuarios_servicios", id_usuarios_servicios);
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

        public DataTable ListarDatosVelocidades(int idVel, int idTipoVel)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT servicios_velocidades.velocidad,servicios_velocidades_tip.nombre, servicios_velocidades.id as id_velocidad, servicios_velocidades_tip.id as id_velocidad_tipo FROM servicios_velocidades inner join servicios_velocidades_tip on servicios_velocidades_tip.id=@idtipo WHERE servicios_velocidades.id=@idvel");
                oCon.AsignarParametroEntero("@idvel", idVel);
                oCon.AsignarParametroEntero("@idtipo", idTipoVel);
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {

                throw;
            }

            return dt;
        }

        public DataTable ListarVelocidadesRelacion()
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT id_velocidad_relacion,id_velocidad,id_velocidad_tipo,velocidad,velocidad_tipo FROM vw_servicios_velocidades_relacion");
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch
            {
                oCon.DesConectar();
            }
            return dt;
        }

        public DataTable ListarVelocidadesServicioSub(int idSub)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT servicios_sub_especiales.id,servicios_sub_especiales.id_servicio,servicios_sub_especiales.id_servicio_sub,servicios_sub_especiales.id_velocidad_relacion,"
                    + " vw_servicios_velocidades_relacion.id_velocidad, vw_servicios_velocidades_relacion.id_velocidad_tipo, vw_servicios_velocidades_relacion.velocidad, vw_servicios_velocidades_relacion.velocidad_tipo"
                    + " FROM servicios_sub_especiales"
                    + " left join vw_servicios_velocidades_relacion on vw_servicios_velocidades_relacion.id_velocidad_relacion = servicios_sub_especiales.id_velocidad_relacion"
                    + " WHERE servicios_sub_especiales.id_servicio_sub = @idsub and servicios_sub_especiales.borrado=0 ");
                oCon.AsignarParametroEntero("@idsub", idSub);
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch
            {
                oCon.DesConectar();
                throw;
            }
            return dt;
        }

        public Int32 EliminarRelacion(int id)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("update servicios_sub_especiales set borrado=1 where id=@idEspecial");
                oCon.AsignarParametroEntero("@idEspecial", id);
                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
                return 0;
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                return -1;
            }
        }

        public Int32 GuardarRelacion(int idServicio, int idServicioSub, int idVelocidad_relacion)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("INSERT INTO servicios_sub_especiales (id_servicio,id_servicio_sub,id_velocidad_relacion) values (@idSer,@idSub,@idVel)");
                oCon.AsignarParametroEntero("@idSer", idServicio);
                oCon.AsignarParametroEntero("@idSub", idServicioSub);
                oCon.AsignarParametroEntero("@idVel", idVelocidad_relacion);
                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
                return 0;
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                return -1;
            }
        }

        public Int32 GuardarRelacionExterna(int idVelocidad, int idVelocidadTipo, int paqueteExterno)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("INSERT INTO  servicios_velocidad_relacion (id_velocidad,id_velocidad_tipo,id_paquete_externo) VALUES (@velocidad,@velocidad_tipo,@paquete_externo)");
                oCon.AsignarParametroEntero("@velocidad", idVelocidad);
                oCon.AsignarParametroEntero("@velocidad_tipo", idVelocidadTipo);
                oCon.AsignarParametroEntero("@paquete_externo", paqueteExterno);
                oCon.EjecutarComando();
                oCon.DesConectar();
                return 0;
            }
            catch (Exception c)
            {
                oCon.DesConectar();
                return -1;
            }
        }

        public Int32 EliminarRelacionExterna(int idRelacion)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("delete from servicio where id=@id_relacion");
                oCon.AsignarParametroEntero("@id_relacion", idRelacion);
                oCon.EjecutarComando();
                oCon.DesConectar();
                return 0;
            }
            catch (Exception)
            {
                oCon.DesConectar();
                return -1;
            }
        }

        public DataTable ListarRelacionesExternas()
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT servicios_velocidad_relacion.id, servicios_velocidad_relacion.id_velocidad, servicios_velocidad_relacion.id_velocidad_tipo,servicios_velocidades.velocidad, servicios_velocidades_tip.nombre as tipo_velocidad,servicios_velocidad_relacion.id_paquete_externo,' ' as paquete FROM servicios_velocidad_relacion " +
                    " inner JOIN servicios_velocidades on servicios_velocidades.id = servicios_velocidad_relacion.id_velocidad" +
                    " inner JOIN servicios_velocidades_tip on servicios_velocidades_tip.id = servicios_velocidad_relacion.id_velocidad_tipo" +
                    " WHERE servicios_velocidades.borrado=0 order by  servicios_velocidad_relacion.id_velocidad asc");
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception c)
            {
                oCon.DesConectar();
            }
            return dt;
        }

        public DataTable ListarRelacionesExternasPorVelocidades(int id_Velocidad , int id_Velocidad_tipo)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT * " +
                    "FROM servicios_velocidad_relacion " +
                    "LEFT JOIN servicios_velocidades ON servicios_velocidad_relacion.id_velocidad = servicios_velocidades.id " +
                    "LEFT JOIN servicios_velocidades_tip ON servicios_velocidad_relacion.id_velocidad_Tipo = servicios_velocidades_tip.id " +
                    $"WHERE  servicios_velocidad_relacion.id_velocidad = {id_Velocidad} and servicios_velocidad_relacion.id_velocidad_tipo = {id_Velocidad_tipo}; ");
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception c)
            {
                oCon.DesConectar();
            }
            return dt;
        }

        public DataTable ListarServicioVelocidades(int IdVelocidad)
        {
            DataTable dt = new DataTable();

            oCon.Conectar();
            oCon.CrearComando("SELECT usuarios_servicios_sub.id, concat(usuarios.Nombre,' , ', usuarios.Apellido) AS Nombre, id_servicios_velocidades " +
                "FROM usuarios_servicios_sub " +
                "LEFT JOIN usuarios_servicios ON usuarios_servicios_sub.Id_Usuarios_Servicios = usuarios_servicios.Id " +
                "LEFT JOIN usuarios ON usuarios_servicios.Id_Usuarios = usuarios.Id " +
                "WHERE usuarios_servicios_sub.borrado = 0 AND Id_servicios_velocidades > 0 AND id_servicios_Velocidades=@idVel");
            oCon.AsignarParametroEntero("@idVel", IdVelocidad);
            dt = oCon.Tabla();
            oCon.DesConectar();

            return dt;

        }
    }
}
