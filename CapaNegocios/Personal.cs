using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Personal
    {
        public Int32 Id { get; set; }
        public String Nombre { get; set; }
        public String Clave { get; set; }
        public Int32 Usuario_Sistema { get; set; }
        public Int32 Id_Personal_Areas { get; set; }
        public Int32 Id_Puntos_Cobros { get; set; }
        public String Hr_matutino_inicio { get; set; }
        public String Hr_matutino_fin { get; set; }
        public String Hr_vespertino_inicio { get; set; }
        public String Hr_vespertino_fin { get; set; }
        public Int32 Rango { get; set; }
        public Int32 Doble_turno { get; set; }
        public Int32 Id_Rol { get; set; }

        public static Int32 Id_Login;
        public static String Name_Login;
        public static Int32 Id_Punto_Cobro_Predeterminado;
        public static Int32 Id_Punto_Venta;
        public static String Area_Login;
        public static Int32 Id_Area;
        public static Int32 Req_Horario;
        public static Int32 IdRol { get; set; }

        private Conexion oCon = new Conexion();

        public void Guardar(Personal oPersonal, int id_personal)
        {
            try
            {
                oCon.Conectar();

                if (oPersonal.Id > 0)
                {
                    oCon.CrearComando("UPDATE personal set Nombre = @nombre, Clave = @clave, Id_Personal_Areas = @area, Id_Puntos_Cobros = @cobro, usuario_sistema = @usu, hora_inicio_1=@hora_i_1, hora_fin_1=@hora_f_1, hora_inicio_2=@hora_i_2, hora_fin_2=@hora_f_2, rango=@rango, con_doble_turno=@doble_turno, Id_Roles=@idrol, Id_Personal = @personal WHERE Id = @id");

                    oCon.AsignarParametroCadena("@nombre", oPersonal.Nombre);
                    oCon.AsignarParametroCadena("@clave", oPersonal.Clave);
                    oCon.AsignarParametroEntero("@area", oPersonal.Id_Personal_Areas);
                    oCon.AsignarParametroEntero("@cobro", oPersonal.Id_Puntos_Cobros);
                    oCon.AsignarParametroEntero("@usu", oPersonal.Usuario_Sistema);
                    oCon.AsignarParametroCadena("@hora_i_1", oPersonal.Hr_matutino_inicio);
                    oCon.AsignarParametroCadena("@hora_f_1", oPersonal.Hr_matutino_fin);
                    oCon.AsignarParametroCadena("@hora_i_2", oPersonal.Hr_vespertino_inicio);
                    oCon.AsignarParametroCadena("@hora_f_2", oPersonal.Hr_vespertino_fin);
                    oCon.AsignarParametroEntero("@rango", oPersonal.Rango);
                    oCon.AsignarParametroEntero("@doble_turno", oPersonal.Doble_turno);
                    oCon.AsignarParametroEntero("@idrol", Id_Rol);
                    oCon.AsignarParametroEntero("@id", oPersonal.Id);
                    oCon.AsignarParametroEntero("@personal", id_personal);
                }
                else
                {
                    oCon.CrearComando("INSERT INTO personal(Nombre, Clave, Id_Personal_Areas, Id_Puntos_Cobros, Usuario_Sistema, hora_inicio_1, hora_fin_1, hora_inicio_2, hora_fin_2, rango, con_doble_turno,Id_Roles, Id_Personal) VALUES(@nombre, @clave, @area, @cobro, @usu, @hora_i_1, @hora_f_1, @hora_i_2, @hora_f_2, @rango, @con_doble_turno,@idrol,@personal)");
                    oCon.AsignarParametroCadena("@nombre", oPersonal.Nombre);
                    oCon.AsignarParametroCadena("@clave", oPersonal.Clave);
                    oCon.AsignarParametroEntero("@area", oPersonal.Id_Personal_Areas);
                    oCon.AsignarParametroEntero("@cobro", oPersonal.Id_Puntos_Cobros);
                    oCon.AsignarParametroEntero("@usu", oPersonal.Usuario_Sistema);
                    oCon.AsignarParametroCadena("@hora_i_1", oPersonal.Hr_matutino_inicio);
                    oCon.AsignarParametroCadena("@hora_f_1", oPersonal.Hr_matutino_fin);
                    oCon.AsignarParametroCadena("@hora_i_2", oPersonal.Hr_vespertino_inicio);
                    oCon.AsignarParametroCadena("@hora_f_2", oPersonal.Hr_vespertino_fin);
                    oCon.AsignarParametroEntero("@rango", oPersonal.Rango);
                    oCon.AsignarParametroEntero("@con_doble_turno", oPersonal.Doble_turno);
                    oCon.AsignarParametroEntero("@idrol", Id_Rol);
                    oCon.AsignarParametroEntero("@personal", id_personal);
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

        public DataTable Listar(bool paraCombo = false)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                if (paraCombo)
                    oCon.CrearComando("SELECT 0 as id, 'TODOS' as Nombre, 0 as ordenamiento UNION ALL SELECT personal.id, personal.nombre, 1 FROM personal where personal.borrado = 0 ORDER BY ordenamiento,nombre");
                else
                    oCon.CrearComando("SELECT P.Id, P.Nombre, Clave, IFNULL(Personal_Areas.Nombre, 'NINGUNA') AS Area,(select personal_areas.Req_horario) as req_horario, IFNULL(Puntos_Cobros.Descripcion,'NINGUNA') AS PuntoCobro, P.Borrado, P.Id_Personal_Areas, P.Id_Puntos_Cobros, IF(P.Usuario_Sistema = 1, 'SI', 'NO') As Usuario, P.Usuario_Sistema, P.hora_inicio_1, P.hora_fin_1, P.hora_inicio_2, P.hora_fin_2, P.rango, P.con_doble_turno,P.Id_Roles,(select nombre FROM personal_roles WHERE id=Id_Roles) AS rol FROM Personal AS P LEFT JOIN Personal_Areas ON P.Id_Personal_Areas = Personal_Areas.Id LEFT JOIN Puntos_Cobros ON P.Id_Puntos_Cobros = Puntos_Cobros.Id WHERE P.Borrado = 0 ORDER BY P.Nombre");
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

        public DataTable ConsultarTecnicos()
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("select personal.Id, personal.Id_Personal_Areas, personal.Nombre, personal.hora_inicio_1, personal.hora_fin_1, personal.hora_inicio_2, personal.hora_fin_2, rango, con_doble_turno from (select Id as Id_area from personal_areas where Req_horario=1)areas_con_horario inner join personal on areas_con_horario.Id_area=personal.Id_Personal_Areas and rango is not null and personal.Borrado=0");
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

        public void Eliminar(int id)
        {
            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();
                oCon.CrearComando("UPDATE personal SET Borrado = 1 WHERE Id = @id");
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

        public Boolean ValidarAcceso(string clave)
        {
            DataTable dt = new DataTable();


            Boolean bReturn = false;

            try
            {

                oCon.Conectar();

                oCon.CrearComando("SELECT personal.Id, personal.Nombre, personal.Id_Puntos_Cobros,personal.id_personal_areas,personal_areas.nombre as area,"
                        + " personal.id_roles, puntos_cobros.punto as punto_venta, personal_areas.req_horario"
                        + " FROM personal"
                        + " left join puntos_cobros on puntos_cobros.id = personal.id_puntos_cobros"
                        + " left join personal_areas on personal_areas.id = personal.id_personal_areas"
                        + " WHERE personal.Clave = @clave and personal.borrado = 0");

                oCon.AsignarParametroCadena("@clave", clave);
                dt = oCon.Tabla();
                oCon.DesConectar();

                if (dt.Rows.Count == 0)
                    bReturn = false;
                else
                {
                    Personal.Id_Login = Convert.ToInt32(dt.Rows[0]["Id"]);
                    Personal.Name_Login = dt.Rows[0]["Nombre"].ToString().ToString();
                    Personal.Id_Punto_Cobro_Predeterminado = Convert.ToInt32(dt.Rows[0]["Id_Puntos_Cobros"]);
                    Personal.Area_Login = dt.Rows[0]["Area"].ToString();
                    Personal.Id_Area = Convert.ToInt32(dt.Rows[0]["id_personal_areas"]);
                    Personal.IdRol = Convert.ToInt32(dt.Rows[0]["id_roles"]);
                    Personal.Req_Horario = Convert.ToInt32(dt.Rows[0]["req_horario"]);
                    bReturn = true;
                }

            }
            catch (Exception ex)
            {
                oCon.DesConectar();

                throw;
            }

            return bReturn;
        }

        public Boolean ValidarAccesoNuevo(string clave, string user)
        {
            DataTable dt = new DataTable();


            Boolean bReturn = false;

            try
            {

                oCon.Conectar();

                oCon.CrearComando("SELECT personal.Id, personal.Nombre, personal.Id_Puntos_Cobros,personal.id_personal_areas,personal_areas.nombre as area,"
                        + " personal.id_roles, puntos_cobros.punto as punto_venta, personal_areas.req_horario"
                        + " FROM personal"
                        + " left join puntos_cobros on puntos_cobros.id = personal.id_puntos_cobros"
                        + " left join personal_areas on personal_areas.id = personal.id_personal_areas"
                        + " WHERE personal.Clave = @clave and personal.nombre=@user and personal.borrado = 0");

                oCon.AsignarParametroCadena("@clave", clave);
                oCon.AsignarParametroCadena("@user", user);
                dt = oCon.Tabla();
                oCon.DesConectar();

                if (dt.Rows.Count == 0)
                    bReturn = false;
                else
                {
                    Personal.Id_Login = Convert.ToInt32(dt.Rows[0]["Id"]);
                    Personal.Name_Login = dt.Rows[0]["Nombre"].ToString().ToString();
                    Personal.Id_Punto_Cobro_Predeterminado = Convert.ToInt32(dt.Rows[0]["Id_Puntos_Cobros"]);
                    Personal.Area_Login = dt.Rows[0]["Area"].ToString();
                    Personal.Id_Area = Convert.ToInt32(dt.Rows[0]["id_personal_areas"]);
                    Personal.IdRol = Convert.ToInt32(dt.Rows[0]["id_roles"]);
                    Personal.Req_Horario = Convert.ToInt32(dt.Rows[0]["req_horario"]);
                    bReturn = true;
                }

            }
            catch (Exception ex)
            {
                oCon.DesConectar();

                throw;
            }

            return bReturn;
        }

        public DataTable ListarPersonalYArea()
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando(" select personal.id,concat(personal_areas.nombre,' - ',personal.nombre) as nombre"
                                + " from personal"
                                + " left join personal_areas on personal.id_personal_areas = personal_areas.id"
                                + " order by personal_areas.nombre, personal.nombre");
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

        public DataTable ListarPorPuntoDeCobro(Int32 idPuntoCobro)
        {
            DataTable dt;
            try
            {
                oCon.Conectar();
                oCon.CrearComando("Select personal.id, personal.Nombre from Personal WHERE borrado=0 and id_puntos_cobros=@idpc ORDER BY Nombre");
                oCon.AsignarParametroEntero("@idpc", idPuntoCobro);
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

        public void ActualizarRol(int id_rolActual, int id_rolNuevo)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("UPDATE personal SET id_roles = @nuevo where id_roles = @actual");
                oCon.AsignarParametroEntero("@nuevo", id_rolNuevo);
                oCon.AsignarParametroEntero("@actual", id_rolActual);
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

        public DataTable ListarPersonalHabilitado(Objetos.Acciones accion)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT personal.id as id_personal, personal.Nombre as nombre_personal, personal.Clave as personal_clave"
                        + " FROM objetos"
                        + " LEFT JOIN roles_permisos ON roles_permisos.id_objeto = objetos.id"
                        + " LEFT JOIN personal ON personal.id_roles = roles_permisos.id_rol"
                        + " WHERE objetos.Name = @accionName and personal.borrado = 0" 
                        + " UNION "
                        + " SELECT personal.id as id_personal, personal.Nombre as nombre_personal, personal.Clave as personal_clave"
                        + " FROM personal"
                        + " WHERE personal.id_roles = 1 ");
                oCon.AsignarParametroCadena("@accionName", accion.ToString());
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
