using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Plasticos_Usuarios
    {
        public int Id { get; set; }
        public int Id_Plastico { get; set; }
        public int Id_Usuarios_Servicios { get; set; }
        public DateTime Fecha_Inicio { get; set; }
        public DateTime Fecha_Baja { get; set; }
        public DateTime Fecha_Solicitud { get; set; }
        public int Activo { get; set; }
        public int Id_Usuario { get; set; }
        public int Borrado { get; set; }

        private Conexion oCon = new Conexion();

        public enum ESTADO
        {
            ACTIVO = 1,
            NO_ACTIVO = 0
        }


        public void Guardar(Plasticos_Usuarios oPlasticosUsuarios)
        {
            try
            {
                oCon.Conectar();

                if (oPlasticosUsuarios.Id > 0)
                {
                    oCon.CrearComando("UPDATE plasticos_usuarios set fecha_inicio=@fecha_inicio,fecha_baja=@fecha_baja,fecha_solicitud=@fecha_solicitud,activo=@activo,borrado=@borrado,id_usuario=@id_usuario,id_personal=@personal WHERE id = @id");
                    oCon.AsignarParametroFecha("@fecha_inicio", oPlasticosUsuarios.Fecha_Inicio);
                    oCon.AsignarParametroFecha("@fecha_baja", oPlasticosUsuarios.Fecha_Baja);
                    oCon.AsignarParametroFecha("@fecha_solicitud", oPlasticosUsuarios.Fecha_Solicitud);
                    oCon.AsignarParametroEntero("@activo", oPlasticosUsuarios.Activo);
                    oCon.AsignarParametroEntero("@borrado", oPlasticosUsuarios.Borrado);
                    oCon.AsignarParametroEntero("@id_usuario", oPlasticosUsuarios.Id_Usuario);
                    oCon.AsignarParametroEntero("@personal", Personal.Id_Login);
                    oCon.AsignarParametroEntero("@id", oPlasticosUsuarios.Id);
                }
                else
                {
                    oCon.CrearComando("INSERT INTO plasticos_usuarios(id_plastico,id_usuarios_servicios,fecha_inicio,fecha_baja,fecha_solicitud,activo,borrado,id_usuario,id_personal) VALUES" +
                                  "(@plastico,@id_usuarios_servicios,@fecha_inicio,@fecha_baja,@fecha_solicitud,@activo,@borrado,@id_usuario,@personal)");

                    oCon.AsignarParametroEntero("@plastico", oPlasticosUsuarios.Id_Plastico);
                    oCon.AsignarParametroEntero("@id_usuarios_servicios", oPlasticosUsuarios.Id_Usuarios_Servicios);
                    oCon.AsignarParametroFecha("@fecha_inicio", oPlasticosUsuarios.Fecha_Inicio);
                    oCon.AsignarParametroFecha("@fecha_baja", oPlasticosUsuarios.Fecha_Baja);
                    oCon.AsignarParametroFecha("@fecha_solicitud", oPlasticosUsuarios.Fecha_Solicitud);
                    oCon.AsignarParametroEntero("@activo", oPlasticosUsuarios.Activo);
                    oCon.AsignarParametroEntero("@borrado", oPlasticosUsuarios.Borrado);
                    oCon.AsignarParametroEntero("@id_usuario", oPlasticosUsuarios.Id_Usuario);
                    oCon.AsignarParametroEntero("@personal", Personal.Id_Login);


                }


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

        public DataTable Listar(int idPlastico, int idUsuario)
        {
            DataTable dt = new DataTable();
            string Consulta = " select usuarios.codigo,concat(usuarios.apellido, ' ', usuarios.nombre) as usuario,localidades.nombre as localidad,Concat(localidades.nombre, ',Calle: ', usuarios_locaciones.calle, ',Altura: ', cast(usuarios_locaciones.altura as char(50)), ',Piso: ', cast(usuarios_locaciones.piso as char(50)), ',Depto: ', usuarios_locaciones.depto) as locacion, servicios.descripcion as servicio,plasticos_usuarios.fecha_solicitud, plasticos_usuarios.id, plasticos.numero, plasticos.titular, plasticos.id_forma_de_pago, plasticos.activo, plasticos_usuarios.id_plastico,"
                + " plasticos_usuarios.id_usuarios_servicios, plasticos_usuarios.activo, plasticos_usuarios.fecha_inicio, plasticos_usuarios.fecha_baja,"
                + "  servicios_tipos.nombre as tiposervicio, usuarios_locaciones.calle, usuarios_locaciones.altura,usuarios_locaciones.piso, usuarios_locaciones.depto, usuarios_servicios.id_servicios, "
                + " usuarios_servicios.id_servicios_tipo, usuarios_servicios.id_usuarios,usuarios_servicios.id_usuarios_locaciones,usuarios_servicios.borrado"
                + " from plasticos_usuarios"
                + " left join usuarios_servicios on plasticos_usuarios.id_usuarios_servicios = usuarios_servicios.id"
                + " left join usuarios_locaciones on usuarios_locaciones.id = usuarios_servicios.id_usuarios_locaciones"
                + " left join servicios on servicios.id = usuarios_servicios.id_servicios"
                + " left join servicios_tipos on servicios_tipos.id = usuarios_servicios.id_servicios_tipo"
                + " left join localidades on localidades.id = usuarios_locaciones.id_localidades"
                + " left join usuarios on usuarios.id = usuarios_servicios.id_usuarios"
                + " left join plasticos on plasticos_usuarios.id_plastico = plasticos.id ";

            try
            {
                oCon.Conectar();
                if (idPlastico > 0 && idUsuario > 0)
                {
                    oCon.CrearComando(Consulta + "where plasticos_usuarios.id_plastico = @id_plastico and usuarios_servicios.id_usuarios=@id_usuario and plasticos_usuarios.borrado = 0");
                    oCon.AsignarParametroEntero("@id_plastico", idPlastico);
                    oCon.AsignarParametroEntero("@id_usuario", idUsuario);
                }
                else if (idPlastico > 0 && idUsuario == 0)
                {
                    oCon.CrearComando(Consulta + "where plasticos_usuarios.id_plastico = @id_plastico and plasticos_usuarios.borrado = 0");
                    oCon.AsignarParametroEntero("@id_plastico", idPlastico);
                }
                else if (idPlastico == 0 && idUsuario > 0)
                {
                    oCon.CrearComando(Consulta + "where usuarios_servicios.id_usuarios=@id_usuario and plasticos_usuarios.borrado = 0");
                    oCon.AsignarParametroEntero("@id_usuario", idUsuario);
                }

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

        public void Eliminar(int id_usu_serv)
        {
            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();
                oCon.CrearComando("UPDATE plasticos_usuarios SET borrado = 1 , activo=0 WHERE id_usuarios_servicios = @id_usu_ser");
                oCon.AsignarParametroEntero("@id_usu_ser", id_usu_serv);
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

        public DataTable Listar_Plasticos()
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT plasticos.id, plasticos.titular, plasticos.numero, plasticos.vencimiento, if (plasticos.activo = 1,'ACTIVA','INACTIVA') as activo_texto, plasticos.activo,  " +
                    "date(plasticos_usuarios.fecha_inicio) as fecha_inicio, date(plasticos_usuarios.fecha_baja) as fecha_baja, plasticos_usuarios.id_usuarios_servicios, " +
                    "usuarios_servicios.id, usuarios_servicios.Id_Usuarios, concat(usuarios.apellido, ' ', usuarios.nombre, ' - Codigo: ', convert(usuarios.codigo, char(10))) AS usuario, servicios.descripcion, " +
                    "servicios.codigo " +
                    "FROM plasticos_usuarios " +
                    "LEFT JOIN plasticos ON plasticos_usuarios.id_plastico = plasticos.id " +
                    "LEFT JOIN usuarios ON plasticos_usuarios.id_usuario = usuarios.id " +
                    "LEFT JOIN usuarios_servicios ON plasticos_usuarios.id_usuarios_servicios = usuarios_servicios.id " +
                    "LEFT JOIN servicios ON usuarios_servicios.Id_Servicios = servicios.id " +
                    "WHERE plasticos.borrado = 0; ");
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

        public DataTable BuscarPlasticosServicio(int idUsuarioServicio)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT plasticos.id, plasticos.titular, plasticos.numero, plasticos.vencimiento, if (plasticos.activo = 1,'ACTIVA','INACTIVA') as activo_texto, plasticos.activo," +
                                  " date(plasticos_usuarios.fecha_inicio) as fecha_inicio, date(plasticos_usuarios.fecha_baja) as fecha_baja, plasticos_usuarios.id_usuarios_servicios," +
                                  " usuarios_servicios.id, usuarios_servicios.Id_Usuarios, concat(usuarios.apellido, ' ', usuarios.nombre,'- Codigo:', convert(usuarios.codigo ,char(10))) AS usuario, servicios.descripcion," +
                                  " servicios.codigo FROM plasticos left join plasticos_usuarios on plasticos.id = plasticos_usuarios.id_plastico left join usuarios_servicios on plasticos_usuarios.id_usuarios_servicios = usuarios_servicios.id" +
                                  " left join usuarios on usuarios_servicios.id_usuarios = usuarios.id left join servicios on usuarios_servicios.id_servicios = servicios.id where plasticos.activo=1 and  plasticos.borrado = 0 and plasticos_usuarios.id_usuarios_servicios=@idusuarioservicio and plasticos_usuarios.activo =1 AND plasticos_usuarios.borrado=0");
                oCon.AsignarParametroEntero("@idusuarioservicio", idUsuarioServicio);
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
    
        public bool ValidarUsuarioServicio(int idUsuarioServicio, out string salida)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("select plasticos_usuarios.*,plasticos.* from plasticos_usuarios left join plasticos on plasticos.id=plasticos_usuarios.id_plastico where plasticos_usuarios.borrado=0 and plasticos.borrado=0 and plasticos.activo=1 and plasticos_usuarios.id_usuarios_servicios=@idususer");
                oCon.AsignarParametroEntero("@idususer", idUsuarioServicio);
                dt = oCon.Tabla();
                oCon.DesConectar();
                if (dt.Rows.Count > 0)
                {
                    string titular = dt.Rows[0]["titular"].ToString().ToUpper();
                    string tarjeta = dt.Rows[0]["numero"].ToString();
                    salida = $"Este servicio ya esta asociado a un débito. \n Tituluar: { titular } \n Numero de tarjeta: {tarjeta}";
                    return false;
                }
                salida = "";
                return true;
            }
            catch (Exception c)
            {
                salida = c.ToString();
                return false;
            }
        }

        public DataTable ListarServiciosAsociadosAUnPlastico(int idPlastico)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                string comando = "select plasticos_usuarios.id as id_plastico_usuario, plasticos_usuarios.id_plastico, plasticos_usuarios.fecha_inicio, plasticos_usuarios.fecha_baja,"
                               + "  plasticos_usuarios.fecha_solicitud, usuarios_servicios.id as id_usuario_servicio, usuarios_servicios.id_usuarios"
                               + "  from plasticos_usuarios"
                               + "  inner join usuarios_Servicios on usuarios_servicios.id = plasticos_usuarios.id_usuarios_servicios"
                               + "  where plasticos_usuarios.activo = 1 and plasticos_usuarios.borrado = 0 and usuarios_Servicios.borrado = 0"
                               + "  and plasticos_usuarios.id_plastico = @idPlastico";
                oCon.CrearComando(comando);
                oCon.AsignarParametroEntero("@idPlastico", idPlastico);
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
            }
            return dt;
        }
    
        public bool ReactivarServicio(int idPlasticoUsuario, int idPlastico, out string salida)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("UPDATE plasticos set plasticos.activo = 1 where id = @plastico ");
                oCon.AsignarParametroEntero("@plastico", idPlastico);
                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();

                oCon.CrearComando("UPDATE plasticos_usuarios set plasticos_usuarios.activo = 1 where id = @plasticoservicio ");
                oCon.AsignarParametroEntero("@plasticoservicio", idPlasticoUsuario);
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
    }
}
