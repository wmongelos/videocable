
using CapaDatos;
using System;
using System.Data;
using System.Linq;

namespace CapaNegocios
{
    public class Equipos
    {
        public Int32 Id { get; set; }
        public Int32 Id_Equipos_Estados { get; set; }
        public Int32 Id_Usuarios { get; set; }
        public Int32 Id_Equipos_Tipos { get; set; }
        public Int32 Id_Equipos_Marcas { get; set; }
        public Int32 Id_Equipos_Modelos { get; set; }
        public String Serie { get; set; }
        public String Mac { get; set; }
        public String Equipo_Usuario { get; set; }
        public String Equipo_Clave { get; set; }
        public String Equipo_IP { get; set; }
        public String Descripcion { get; set; }
        public Int32 Borrado { get; set; }
        public Int32 Id_Usuarios_servicios { get; set; }

        public enum Equipos_Estados
        {
            DISPONIBLE_EN_STOCK = 1,
            EN_REPARACION = 2,
            ASIGNADO_A_USUARIO = 3,
            ASIGNADO_A_DEPARTAMENTO = 4,
            EN_PROCESO_DE_ASIGNACION = 5,
            BAJA_DE_STOCK = 6
        }

        public enum VERIFICACION_SERIE_MAC
        {
            SERIE_MAC_REPETIDOS = 0,
            SERIE_REPETIDO = 1,
            MAC_REPETIDA = 2,
            SIN_REPETICION = 3
        }

        private Conexion oCon = new Conexion();

        public VERIFICACION_SERIE_MAC VerificarEquipo(string serie, string mac, int id, int VerificarSerie, int VerificarMac)
        {
            DataTable dt = new DataTable();
            VERIFICACION_SERIE_MAC Verificacion = VERIFICACION_SERIE_MAC.SIN_REPETICION;
            try
            {
                oCon.Conectar();
                if (VerificarSerie == 1 && VerificarMac == 1)
                {
                    if (id == 0)
                    {
                        oCon.CrearComando("select Id from equipos where (Serie=@serie or Mac=@mac) and borrado=0");
                        oCon.AsignarParametroCadena("@serie", serie);
                        oCon.AsignarParametroCadena("@mac", mac);
                    }
                    else
                    {
                        oCon.CrearComando("select Id from equipos where (Serie=@serie or Mac=@mac) and Id!=@id and borrado=0");
                        oCon.AsignarParametroCadena("@serie", serie);
                        oCon.AsignarParametroCadena("@mac", mac);
                        oCon.AsignarParametroEntero("@id", id);
                    }
                    Verificacion = VERIFICACION_SERIE_MAC.SERIE_MAC_REPETIDOS;

                }
                else if (VerificarSerie == 1 && VerificarMac == 0)
                {
                    if (id == 0)
                    {
                        oCon.CrearComando("select Id from equipos where Serie=@serie and borrado=0");
                        oCon.AsignarParametroCadena("@serie", serie);
                    }
                    else
                    {
                        oCon.CrearComando("select Id from equipos where Serie=@serie and Id!=@id and borrado=0");
                        oCon.AsignarParametroCadena("@serie", serie);
                        oCon.AsignarParametroEntero("@id", id);
                    }
                    Verificacion = VERIFICACION_SERIE_MAC.SERIE_REPETIDO;
                }
                else
                {
                    if (id == 0)
                    {
                        oCon.CrearComando("select Id from equipos where Mac=@mac and borrado=0");
                        oCon.AsignarParametroCadena("@mac", mac);
                    }
                    else
                    {
                        oCon.CrearComando("select Id from equipos where Mac=@mac and Id!=@id and borrado=0");
                        oCon.AsignarParametroCadena("@mac", mac);
                        oCon.AsignarParametroEntero("@id", id);
                    }
                    Verificacion = VERIFICACION_SERIE_MAC.MAC_REPETIDA;
                }
                dt = oCon.Tabla();
                oCon.DesConectar();
                if (dt.Rows.Count == 0)
                    Verificacion = VERIFICACION_SERIE_MAC.SIN_REPETICION;

            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }

            return Verificacion;
        }

        public bool ConsultarDisponibilidad(int idTipoEquipo, int stockRequerido)
        {

            DataTable dt = new DataTable();
            int resultado = 0;
            bool respuesta = false;
            try
            {
                oCon.Conectar();
                oCon.CrearComando(String.Format("select count(Id) as Cantidad from equipos where id_equipos_estados={0} and id_equipos_tipos={1} and Borrado=0", Convert.ToInt32(Equipos.Equipos_Estados.DISPONIBLE_EN_STOCK), idTipoEquipo));
                dt = oCon.Tabla();
                oCon.DesConectar();
                resultado = Convert.ToInt32(dt.Rows[0]["Cantidad"]);
                if (resultado >= stockRequerido)
                    respuesta = true;
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }

            return respuesta;
        }

        public void PasarEquipoReparacion(int id, int usuario_servicio)
        {
            try
            {

                oCon.Conectar();
                if (id != 0 && usuario_servicio == 0)
                {
                    oCon.CrearComando("update equipos set Id_Equipos_Estados=@estado, id_usuarios=0, id_tarjeta=0, id_usuarios_servicios=0, equipo_usuario='', equipo_clave='', equipo_ip='',id_personal=@personal where Id=@id and Borrado=0");
                    oCon.AsignarParametroEntero("@personal", Personal.Id_Login);
                    oCon.AsignarParametroEntero("@id", id);
                }
                else if (id != 0 && usuario_servicio != 0)
                {
                    oCon.CrearComando("update equipos set Id_Equipos_Estados=@estado, id_usuarios=0, id_tarjeta=0, id_usuarios_servicios=0, equipo_usuario='', equipo_clave='', equipo_ip='',id_personal=@personal where Id=@id and Id_Usuarios_Servicios=@usuarios_servicios and Borrado=0");
                    oCon.AsignarParametroEntero("@personal", Personal.Id_Login);
                    oCon.AsignarParametroEntero("@id", id);
                    oCon.AsignarParametroEntero("@usuarios_servicios", usuario_servicio);
                }
                else if (id == 0 && usuario_servicio != 0)
                {
                    oCon.CrearComando("update equipos set Id_Equipos_Estados=@estado, id_usuarios=0, id_tarjeta=0, id_usuarios_servicios=0, equipo_usuario='', equipo_clave='', equipo_ip='' where Id_Usuarios_Servicios=@usuarios_servicios,id_personal=@personal and Borrado=0");
                    oCon.AsignarParametroEntero("@personal", Personal.Id_Login);
                    oCon.AsignarParametroEntero("@usuarios_servicios", usuario_servicio);
                }


                oCon.AsignarParametroEntero("@estado", Convert.ToInt32(Equipos_Estados.EN_REPARACION));


                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();

                oCon.CrearComando("update usuarios_servicios_equipos set borrado=1,id_personal=@personal where id_equipo=@idequipo and Borrado=0");
                oCon.AsignarParametroEntero("@personal", Personal.Id_Login);
                oCon.AsignarParametroEntero("@idequipo", id);
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

        public void Eliminar(int id)
        {
            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();
                oCon.CrearComando("UPDATE equipos SET Borrado = 1,id_personal=@personal WHERE Id = @id");
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

        public bool CambiarEstado(int id, int idEstado,out string salida)
        {
            DataTable dtEstadoActual = new DataTable();
            int idEstadoActual = 0;
            string mac = "";
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT id_equipos_estados,mac from equipos where id=@id");
                oCon.AsignarParametroEntero("@id", id);
                dtEstadoActual = oCon.Tabla();
                if (dtEstadoActual.Rows.Count > 0)
                {
                    idEstadoActual = Convert.ToInt32(dtEstadoActual.Rows[0]["id_equipos_estados"]);
                    mac = dtEstadoActual.Rows[0]["mac"].ToString();
                    if (!mac.Equals("99:99:99:99:99:99"))
                    {
                        oCon.ComenzarTransaccion();

                        if (idEstado == Convert.ToInt32(Equipos.Equipos_Estados.DISPONIBLE_EN_STOCK) || idEstado == Convert.ToInt32(Equipos.Equipos_Estados.EN_REPARACION) || idEstado == Convert.ToInt32(Equipos.Equipos_Estados.ASIGNADO_A_DEPARTAMENTO) || idEstado == Convert.ToInt32(Equipos.Equipos_Estados.BAJA_DE_STOCK))
                        {
                            oCon.CrearComando("UPDATE equipos SET id_equipos_estados = @estado, id_usuarios=@idUsuario, id_usuarios_servicios=@idUsuariosServicios, equipo_usuario=@equipo_usuario, equipo_clave=@equipo_clave, equipo_ip=@equipo_ip,id_personal=@personal WHERE Id = @id");
                            oCon.AsignarParametroEntero("@estado", idEstado);
                            oCon.AsignarParametroEntero("@idUsuario", 0);
                            oCon.AsignarParametroEntero("@idUsuariosServicios", 0);
                            oCon.AsignarParametroCadena("@equipo_usuario", String.Empty);
                            oCon.AsignarParametroCadena("@equipo_clave", String.Empty);
                            oCon.AsignarParametroCadena("@equipo_ip", String.Empty);
                            oCon.AsignarParametroEntero("@personal", Personal.Id_Login);
                            oCon.AsignarParametroEntero("@id", id);
                        }
                        else
                        {
                            oCon.CrearComando("UPDATE equipos SET id_equipos_estados = @estado, id_personal=@personal WHERE Id = @id");
                            oCon.AsignarParametroEntero("@estado", idEstado);
                            oCon.AsignarParametroEntero("@personal", Personal.Id_Login);
                            oCon.AsignarParametroEntero("@id", id);
                        }

                        oCon.EjecutarComando();
                        oCon.ConfirmarTransaccion();
                        oCon.DesConectar();
                    }
                    else
                    {
                        oCon.DesConectar();
                    }



                }
                else
                {
                    salida = "No se encontraron datos del estado actual del equipo. \n Equipo número: " + id;
                    return false;
                }
                salida = "";
                return true;
            }
            catch (Exception ex)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                salida ="Error al intentar cambiar el estado del equipo " + id +" \n Error:  " + ex.ToString();
                throw new ConexionException(ex.Message);
            }
            if (!mac.Equals("99:99:99:99:99:99"))
            {
                if (idEstadoActual == (int)Equipos_Estados.ASIGNADO_A_USUARIO)
                    EliminarRelacionEquipoServicio(id, idEstado);
            }
        }

        public Int32 AsignarEquipoAUsuario(int IdEquipo, int IdUsuario, int IdUsuarioServicio, int idEstado)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("update equipos set id_equipos_estados=@idEquiposEstados, id_usuarios=@idUsuarios, id_usuarios_servicios=@idUsuariosServicios where Id=@id");
                oCon.AsignarParametroEntero("@idEquiposEstados", idEstado);
                oCon.AsignarParametroEntero("@idUsuarios", IdUsuario);
                oCon.AsignarParametroEntero("@idUsuariosServicios", IdUsuarioServicio);
                oCon.AsignarParametroEntero("@id", IdEquipo);
                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
                GuardarRelacionEquipoServicio(IdEquipo, IdUsuarioServicio);
                return 1;
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                return -1;
            }
        }

        public Int32 AsignarEquipoAUsuarioconTarjeta(int IdEquipo, int IdUsuario, int IdUsuarioServicio, int idEstado, int id_tarjeta)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("update equipos set id_equipos_estados=@idEquiposEstados, id_usuarios=@idUsuarios, id_usuarios_servicios=@idUsuariosServicios, id_tarjeta = @idTarj where Id=@id");
                oCon.AsignarParametroEntero("@idEquiposEstados", idEstado);
                oCon.AsignarParametroEntero("@idUsuarios", IdUsuario);
                oCon.AsignarParametroEntero("@idUsuariosServicios", IdUsuarioServicio);
                oCon.AsignarParametroEntero("@idTarj", id_tarjeta);
                oCon.AsignarParametroEntero("@id", IdEquipo);
                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
                GuardarRelacionEquipoServicio(IdEquipo, IdUsuarioServicio);
                return 1;
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                return -1;
            }
        }

        public Int32 Guardar(Equipos oEquipo)
        {
            int nuevoEquipoId = 0;
            try
            {

                oCon.Conectar();
                if (oEquipo.Id == 0)
                {
                    oCon.CrearComando("INSERT INTO equipos(id_usuarios,id_usuarios_servicios,Id_Equipos_Estados, Id_Equipos_Tipos, Id_Equipos_Marcas, Id_Equipos_Modelos, Serie, Mac) " +
                        "VALUES(@usuarioid,@ususervicioid,@estado, @tipo, @marca, @modelo, @serie, @mac);SELECT @@IDENTITY");
                }
                else
                {
                    oCon.CrearComando("update equipos set Id_Equipos_Tipos=@tipo, Id_Equipos_Marcas=@marca, Id_Equipos_Modelos=@modelo, Serie=@serie, Mac=@mac, id_equipos_estados=@estado, id_usuarios=@usuarioid, id_usuarios_servicios=@ususervicioid where Id=@id");
                    oCon.AsignarParametroEntero("@id", oEquipo.Id);
                }

                oCon.AsignarParametroEntero("@usuarioid", oEquipo.Id_Usuarios);
                oCon.AsignarParametroEntero("@ususervicioid", oEquipo.Id_Usuarios_servicios);
                oCon.AsignarParametroEntero("@estado", oEquipo.Id_Equipos_Estados);
                oCon.AsignarParametroEntero("@tipo", oEquipo.Id_Equipos_Tipos);
                oCon.AsignarParametroEntero("@marca", oEquipo.Id_Equipos_Marcas);
                oCon.AsignarParametroEntero("@modelo", oEquipo.Id_Equipos_Modelos);
                oCon.AsignarParametroCadena("@serie", oEquipo.Serie);
                oCon.AsignarParametroCadena("@mac", oEquipo.Mac);

                oCon.ComenzarTransaccion();
                if (oEquipo.Id > 0)
                    oCon.EjecutarComando();
                else
                    nuevoEquipoId = oCon.EjecutarScalar();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();

                return nuevoEquipoId;
            }
            catch (Exception ex)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                return -1;
                throw ex;
            }
        }

        public void GuardarRelacionEquipoServicio(int idEquipo, int idUsuarioServicio)
        {
            try
            {
                DataTable dtDatosUsuarioServicio = new DataTable();
                Usuarios_Servicios oUsuSer = new Usuarios_Servicios();
                dtDatosUsuarioServicio = oUsuSer.Traer_datos_usuarios_servicios(idUsuarioServicio);
                int idUsuario = Convert.ToInt32(dtDatosUsuarioServicio.Rows[0]["id_usuarios"]);

                int idLocacion = Convert.ToInt32(dtDatosUsuarioServicio.Rows[0]["id_usuarios_locaciones"]);
                oCon.Conectar();
                oCon.CrearComando("INSERT INTO usuarios_servicios_equipos (id_Equipo,id_usuario_servicio,id_usuario,id_usuario_locacion) VALUES (@idequipo,@idusuarioservicio,@idusu,@idloca)");
                oCon.AsignarParametroEntero("@idequipo", idEquipo);
                oCon.AsignarParametroEntero("@idusuarioservicio", idUsuarioServicio);
                oCon.AsignarParametroEntero("@idusu", idUsuario);
                oCon.AsignarParametroEntero("@idloca", idLocacion);

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

        public Int32 PasarAConfigurado(int idUsuarioServicio, int idEquipo, int idEquiment, int idAccesAcount, int idProducto)
        {
            int salida = 0;
            try
            {
                oCon.Conectar();
                oCon.CrearComando("UPDATE usuarios_servicios_equipos SET configurado=1,id_equipment=@id_equipment,id_account_acces=@id_acces,id_producto=@idproducto WHERE id_equipo=@idquipo and id_usuario_servicio=@idusuarioservicio");
                oCon.AsignarParametroEntero("@id_equipment", idEquiment);
                oCon.AsignarParametroEntero("@id_acces", idAccesAcount);
                oCon.AsignarParametroEntero("@idquipo", idEquipo);
                oCon.AsignarParametroEntero("@idproducto", idProducto);
                oCon.AsignarParametroEntero("@idusuarioservicio", idUsuarioServicio);
                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
            }
            catch
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                salida = -1;
                throw;
            }
            return salida;
        }

        public int EliminarRelacionEquipoServicio(int idEquipo, int idEstado = 0)
        {
            try
            {

                oCon.Conectar();
                oCon.CrearComando("update equipos set id_usuarios=0,id_usuarios_servicios=0,equipo_usuario='',equipo_clave='',id_equipos_estados=@estado,id_personal=@personal where id=@idEquipo");
                if (idEstado == 0)
                    oCon.AsignarParametroEntero("@estado", Convert.ToInt32(Equipos_Estados.EN_REPARACION));
                else
                    oCon.AsignarParametroEntero("@estado", idEstado);
                oCon.AsignarParametroEntero("@personal", Personal.Id_Login);
                oCon.AsignarParametroEntero("@idEquipo", idEquipo);

                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();

                oCon.CrearComando("update usuarios_servicios_equipos set borrado=1,id_personal=@personal where id_equipo=@idEquipo");
                oCon.AsignarParametroEntero("@personal", Personal.Id_Login);
                oCon.AsignarParametroEntero("@idEquipo", idEquipo);
                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                return -1;
            }
            return 0;
        }

        public DataTable BuscarEquipoPorUsuarioServicio(int id_usuario_servicio)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();

                oCon.CrearComando(String.Format("select equipos.id, serie, mac, id_equipos_tipos, equipos_marcas.nombre as marca, equipos_modelos.nombre as modelo, id_tarjeta, if (equipos_tipos.requiere_tarjeta > 0, upper('si'),upper('no')) as requiere_tarjeta, equipos_tarjetas.numero as numtarjeta, equipos.equipo_usuario, equipos.equipo_clave, equipos.equipo_ip, equipos.id_equipos_estados, equipos_estados.nombre as estado, servicios.id_aplicaciones_externas as idAppExterna, usuarios_servicios.id_servicios_estados as idEstadoServicio "
                    + " from usuarios_servicios_equipos"
                    + " left join equipos on usuarios_servicios_equipos.id_equipo = equipos.id"
                    + " left join usuarios_servicios on usuarios_servicios_equipos.id_usuario_servicio = usuarios_servicios.id"
                    + " left join equipos_tipos on equipos.id_equipos_tipos = equipos_tipos.id"
                    + " left join equipos_marcas on equipos.id_equipos_marcas = equipos_marcas.id"
                    + " left join equipos_modelos on equipos.id_equipos_modelos = equipos_modelos.id"
                    + " left join equipos_tarjetas on equipos.id_tarjeta = equipos_tarjetas.id"
                    + " left join servicios on usuarios_servicios.id_servicios = servicios.id"
                    + " left join equipos_estados on equipos.id_equipos_estados = equipos_estados.id"
                    + " where equipos.borrado = 0 AND id_usuario_servicio = {0} and usuarios_Servicios_Equipos.borrado=0", id_usuario_servicio));

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

        public DataTable BuscarEquipoPorUsuario(int idUsuario)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();

                oCon.CrearComando(String.Format("select equipos.id, equipos.serie, equipos.mac, equipos.id_equipos_tipos, equipos_marcas.nombre as marca, equipos_modelos.nombre as modelo, equipos.id_tarjeta, if (equipos_tipos.requiere_tarjeta > 0, upper('SI'),upper('NO')) as requiere_tarjeta, equipos_tarjetas.numero as numtarjeta, equipos.Equipo_Usuario, equipos.Equipo_Clave, equipos.Equipo_IP, equipos.id_equipos_estados, equipos_estados.nombre as estado, usuarios_servicios_equipos.id_usuario_servicio" +
                                " from equipos" +
                                " left join usuarios_servicios_equipos on usuarios_servicios_equipos.id_equipo = equipos.id" +
                                " left join equipos_tipos on equipos.id_equipos_tipos = equipos_tipos.id" +
                                " left join equipos_marcas on equipos.id_equipos_marcas = equipos_marcas.id" +
                                " left join equipos_modelos on equipos.id_equipos_modelos = equipos_modelos.id" +
                                " left join equipos_tarjetas on equipos.id_tarjeta = equipos_tarjetas.id" +
                                " left join equipos_estados on equipos.id_equipos_estados = equipos_estados.id" +
                                " where equipos.Borrado = 0 and usuarios_servicios_equipos.id_usuario={0} and usuarios_Servicios_equipos.borrado=0", idUsuario));

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

        public DataTable ListarTarjetasAux()
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("select * from minetti order by minetti.cod_usu asc");
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

        public Int32 EditarTarjetas(int id, int resu)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("update minetti set resultado=@resu where id=@id");
                oCon.AsignarParametroEntero("@resu", resu);
                oCon.AsignarParametroEntero("@id", id);
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
                throw;

            }
        }

        public DataTable TraerEquiposPorTipoServicio(int IdTipoServicio, int aux = 0, bool Estructura = false)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                if (Estructura == true)
                {
                    oCon.CrearComando(String.Format("select id,equipos_filtrados.id_equipos_tipos,id_equipos_marcas,id_equipos_modelos,serie,mac, equipo_ip,equipo_usuario,equipo_clave,(select nombre from equipos_tipos where id=equipos_filtrados.id_equipos_tipos) as tipo_equipo,(select nombre from equipos_marcas where id=id_equipos_marcas) as marca, (select nombre from equipos_modelos where id=id_equipos_modelos) as modelo, (select numero from equipos_tarjetas where id=equipos_filtrados.id_tarjeta) as numero_tarjeta from (select * from equipos where borrado=0 and Id_equipos_estados={0})equipos_filtrados inner join (select Id_Equipos_Tipos from equipos_tipos_servicios where Id_Servicios_Tipos={1})tipos_equipos_filtrados on equipos_filtrados.id_equipos_tipos=tipos_equipos_filtrados.id_equipos_tipos where borrado=50", Convert.ToInt32(Equipos.Equipos_Estados.DISPONIBLE_EN_STOCK), IdTipoServicio));
                }
                else
                {
                    if (aux == 0)
                        oCon.CrearComando(String.Format("select id,equipos_filtrados.id_equipos_tipos,id_equipos_marcas,id_equipos_modelos,serie,mac, equipo_ip,equipo_usuario,equipo_clave,(select nombre from equipos_tipos where id=equipos_filtrados.id_equipos_tipos) as tipo_equipo,(select nombre from equipos_marcas where id=id_equipos_marcas) as marca, (select nombre from equipos_modelos where id=id_equipos_modelos) as modelo, (select numero from equipos_tarjetas where id=equipos_filtrados.id_tarjeta) as numero_tarjeta from (select * from equipos where borrado=0 and Id_equipos_estados={0})equipos_filtrados inner join (select Id_Equipos_Tipos from equipos_tipos_servicios where Id_Servicios_Tipos={1})tipos_equipos_filtrados on equipos_filtrados.id_equipos_tipos=tipos_equipos_filtrados.id_equipos_tipos", Convert.ToInt32(Equipos.Equipos_Estados.DISPONIBLE_EN_STOCK), IdTipoServicio));
                    else
                    {
                        oCon.CrearComando(String.Format("select id,equipos_filtrados.id_equipos_tipos,id_equipos_marcas,id_equipos_modelos,serie,mac, equipo_ip,equipo_usuario,equipo_clave,(select nombre from equipos_tipos where id=equipos_filtrados.id_equipos_tipos) as tipo_equipo,(select nombre from equipos_marcas where id=id_equipos_marcas) as marca, (select nombre from equipos_modelos where id=id_equipos_modelos) as modelo, (select numero from equipos_tarjetas where id=equipos_filtrados.id_tarjeta) as numero_tarjeta from (select * from equipos where borrado=0 and Id_equipos_estados={0})equipos_filtrados inner join (select Id_Equipos_Tipos from equipos_tipos_servicios where Id_Servicios_Tipos={1})tipos_equipos_filtrados on equipos_filtrados.id_equipos_tipos=tipos_equipos_filtrados.id_equipos_tipos", Convert.ToInt32(Equipos.Equipos_Estados.DISPONIBLE_EN_STOCK), IdTipoServicio));
                    }
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

        public DataTable BuscarDatosEquipo(int idEquipo)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT equipos.Id, equipos_tipos.nombre as tipo,equipos_modelos.nombre as modelo,equipos_marcas.nombre as marca, equipos.Serie, equipos.Mac, equipos_estados.Nombre as estado, CONCAT(usuarios.nombre, ' ', usuarios.apellido) as usuario, CONCAT(usuarios_locaciones.calle, ' ', cast(usuarios_locaciones.altura as char)) as locacion, equipos.Id_Equipos_Tipos,equipos.Id_Equipos_Modelos,equipos.Id_Equipos_Marcas,equipos.Id_Usuarios_Servicios," +
                                  "equipos.Id_Usuarios, equipos.Id_Equipos_Estados, servicios.Descripcion as servicio, equipos.equipo_usuario, equipos.equipo_clave, equipos.equipo_ip FROM equipos LEFT JOIN equipos_estados ON equipos.id_Equipos_Estados = equipos_estados.Id LEFT JOIN equipos_tipos ON equipos.id_Equipos_tipos = equipos_tipos.Id LEFT JOIN equipos_marcas ON equipos.id_Equipos_marcas = equipos_marcas.Id LEFT JOIN equipos_modelos ON equipos.id_Equipos_modelos = equipos_modelos.Id LEFT JOIN usuarios ON equipos.id_usuarios = usuarios.Id LEFT JOIN usuarios_servicios ON equipos.id_usuarios_servicios = usuarios_servicios.Id LEFT JOIN servicios on usuarios_servicios.Id_Servicios = servicios.Id left JOIN " +
                                    "usuarios_locaciones ON usuarios_servicios.id_usuarios_locaciones = usuarios_locaciones.Id where equipos.borrado = 0 and equipos.id = @id");
                oCon.AsignarParametroEntero("@id", idEquipo);
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

        public DataTable BuscarEquipos(int idTipoServicio, string mac, string serie = "", string Marca = "", string Modelo = "")
        {
            DataTable dt = new DataTable();
            string consulta = string.Format("select equipos.id,equipos.id_equipos_tipos,equipos.id_equipos_marcas,equipos.id_equipos_modelos,equipos.serie,equipos.mac, equipos.equipo_ip,equipos.equipo_usuario,equipos.equipo_clave,equipos_tipos.nombre as tipo_equipo,equipos_marcas.nombre as marca,equipos_modelos.nombre as modelo,equipos_tarjetas.numero as numero_tarjeta, equipos.Id_Equipos_Estados, equipos_estados.nombre as estado,equipos_tipos_servicios.id_servicios_Tipos "
                    + " from equipos"
                    + " left join equipos_marcas on equipos_marcas.id = equipos.id_equipos_marcas"
                    + " left join equipos_modelos on equipos_modelos.id = equipos.id_equipos_modelos"
                    + " left join equipos_tarjetas on equipos_tarjetas.id = equipos.id_tarjeta"
                    + " left join equipos_tipos on equipos_tipos.id = equipos.id_equipos_tipos"
                    + " left join equipos_tipos_servicios on equipos_tipos_servicios.id_equipos_Tipos = equipos.id_equipos_tipos"
                    + " left join equipos_estados on equipos_estados.Id = equipos.Id_Equipos_Estados"
                    + " where equipos.borrado=0  and equipos.id_equipos_estados ={0} ", Convert.ToInt32(Equipos.Equipos_Estados.DISPONIBLE_EN_STOCK));

            if (idTipoServicio > 0)
                consulta = consulta + " and equipos_tipos_servicios.id_servicios_tipos=" + idTipoServicio;
            if (mac != "")
                consulta = consulta + " and equipos.mac='" + mac + "'";
            if (serie != "")
                consulta = consulta + " and equipos.serie='" + serie + "'";
            if (Marca != "")
                consulta = consulta + " and equipos_marcas.nombre LIKE '%" + Marca + "%'";
            if (Modelo != "")
                consulta = consulta + " and equipos_modelos.nombrE LIKE '%" + Modelo + "%'";

            try
            {

                oCon.Conectar();
                oCon.CrearComando(consulta);
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
            }

            return dt;
        }

        public DataTable ListarCantidad()
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT equipos_estados.Nombre as estado, count(equipos.Id_Equipos_Estados) as Cantidad FROM equipos_estados Left JOIN equipos ON  equipos_estados.Id=equipos.id_Equipos_Estados group by estado order by Cantidad DESC");
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

        public DataTable ListarPorUsuario(int Codigo)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando(String.Format("SELECT equipos.Id,equipos_estados.Nombre as estado,equipos.Id_Usuarios_Servicios,CONCAT(usuarios_locaciones.calle,' ',usuarios_locaciones.altura) as locacion,"
                                 + "equipos.Id_Usuarios, CONCAT(usuarios.nombre, ' ', usuarios.apellido) as usuario, equipos.Id_Equipos_Tipos, equipos_tipos.nombre as tipo,"
                                 + "equipos.Id_Equipos_Marcas, equipos_marcas.nombre as marca, equipos.Id_Equipos_Modelos, equipos_modelos.nombre as modelo,"
                                 + "equipos.Descripcion, equipos.Serie, equipos.Mac, equipos.Id_Equipos_Estados,usuarios_locaciones.id as id_locacion,usuarios.nombre,usuarios.apellido,"
                                 + "equipos.id_usuarios_Servicios, servicios_tipos.id_servicios_grupos, servicios_tipos.id as id_servicios_tipos, usuarios_servicios.id_servicios, usuarios_locaciones.id_localidades FROM equipos"
                                 + " LEFT JOIN equipos_estados ON equipos.id_Equipos_Estados = equipos_estados.Id"
                                 + " LEFT JOIN equipos_tipos ON equipos.id_Equipos_tipos = equipos_tipos.Id"
                                 + " LEFT JOIN equipos_marcas ON equipos.id_Equipos_marcas = equipos_marcas.Id"
                                 + " LEFT JOIN equipos_modelos ON equipos.id_Equipos_modelos = equipos_modelos.Id"
                                 + " LEFT JOIN usuarios ON equipos.id_usuarios = usuarios.Id"
                                 + " LEFT JOIN usuarios_servicios ON equipos.id_usuarios_servicios = usuarios_servicios.Id"
                                 + " LEFT JOIN servicios ON servicios.id = usuarios_servicios.id_servicios"
                                 + " LEFT JOIN servicios_tipos ON servicios_tipos.id = servicios.id_servicios_tipos"
                                 + " LEFT JOIN servicios_grupos ON servicios_grupos.id = servicios_tipos.id_servicios_grupos"
                                 + " LEFT JOIN usuarios_locaciones ON usuarios_servicios.id_usuarios_locaciones = usuarios_locaciones.Id where equipos.id_usuarios={0}", Codigo));
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

        public DataTable Listar()
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT equipos.Id, if(equipos_tipos.requiere_tarjeta=0,'NO','SI') as requiere_tarjeta,equipos_tipos.nombre as tipo, equipos_modelos.nombre as modelo, equipos_marcas.nombre as marca, equipos.Serie, equipos.Mac," +
                                   "equipos_estados.Nombre as estado,usuarios.codigo, CONCAT(usuarios.apellido, ' ', usuarios.nombre) as usuario, usuarios_locaciones.calle,usuarios_locaciones.altura ,if(equipos.Id_Tarjeta>0,'SI','NO') as Posee_Tarjeta, equipos.Id_Equipos_Tipos, equipos.Id_Equipos_Modelos, equipos.Id_Equipos_Marcas, equipos.Id_Usuarios_Servicios, equipos.Id_Usuarios," +
                                   "equipos.Id_Equipos_Estados, equipos.id_tarjeta, equipos_tarjetas.numero, equipos.equipo_usuario, equipos.equipo_clave, equipos.equipo_ip FROM equipos " +
                                   "LEFT JOIN equipos_estados ON equipos.id_Equipos_Estados = equipos_estados.Id " +
                                   "LEFT JOIN equipos_tipos ON equipos.id_Equipos_tipos = equipos_tipos.Id " +
                                   "LEFT JOIN equipos_marcas ON equipos.id_Equipos_marcas = equipos_marcas.Id " +
                                   "LEFT JOIN equipos_modelos ON equipos.id_Equipos_modelos = equipos_modelos.Id " +
                                   "LEFT JOIN usuarios ON equipos.id_usuarios = usuarios.Id " +
                                   "LEFT JOIN usuarios_servicios ON equipos.id_usuarios_servicios = usuarios_servicios.Id " +
                                   "LEFT JOIN usuarios_locaciones ON usuarios_servicios.id_usuarios_locaciones = usuarios_locaciones.Id " +
                                   "left join servicios on usuarios_servicios.Id_Servicios = servicios.Id " +
                                   "left join equipos_tarjetas on equipos.id_tarjeta=equipos_tarjetas.id where equipos.borrado = 0");
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

        public DataTable ListarUsuariosServiciosEquipos()
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("select usuarios.codigo,usuarios_Servicios_equipos.id,usuarios_Servicios_equipos.id_equipo,usuarios_Servicios_equipos.id_usuario,usuarios_Servicios_equipos.id_usuario_servicio,usuarios_Servicios_equipos.id_usuario_locacion,usuarios_Servicios_equipos.id_equipment,usuarios_Servicios_equipos.id_account_acces,usuarios_Servicios_equipos.id_producto,usuarios_Servicios_equipos.id_producto_aux,usuarios_servicios.id_Servicios,equipos.mac,usuarios_Servicios_equipos.id_location,usuarios_Servicios_equipos.id_customer from usuarios_Servicios_equipos left join usuarios_Servicios on usuarios_Servicios.id=usuarios_Servicios_equipos.id_usuario_servicio left join equipos on equipos.id=usuarios_Servicios_equipos.id_equipo  left join usuarios on usuarios.id=usuarios_servicios_equipos.id_usuario where equipos.mac<>'' and usuarios_serivicios_equipos.borrado=0 order by usuarios_Servicios_equipos.id ");
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

        public DataTable ListarDatosUsuariosServiciosEquipos(int idUsuarioServicio, int idEquipo)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT  * FROM usuarios_servicios_equipos WHERE id_usuario_servicio=@id_use and id_equipo=@equipo_id and usuarios_servicios_equipos.borrado=0");
                oCon.AsignarParametroEntero("@id_use", idUsuarioServicio);
                oCon.AsignarParametroEntero("@equipo_id", idEquipo);

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

        public DataTable ListarEquipoPorUsuariosServicio(int idUsuSer)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT * FROM usuarios_servicios_equipos where id_usuario_servicio=@id and borrado=0");
                oCon.AsignarParametroEntero("@id", idUsuSer);
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

        public DataTable ListarEquipoPorUsuarioYLocacion(int idUsuario,int idLoc)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT usuarios_servicios_equipos.*,equipos.serie,equipos.mac,equipos_tipos.nombre as tipoequipo ,servicios.descripcion as servicio " +
                    "FROM usuarios_servicios_equipos " +
                    "LEFT JOIN equipos on equipos.id=usuarios_servicios_equipos.id_equipo " +
                    "LEFT JOIN equipos_tipos on equipos_tipos.id=equipos.id_equipos_tipos " +
                    "LEFT JOIN usuarios_servicios on usuarios_servicios.id=usuarios_servicios_equipos.id_usuario_servicio " +
                    "LEFT JOIN servicios on servicios.id=usuarios_servicios.id_servicios " +
                    " where id_usuario=@id and id_usuario_locacion=@idloc and usuarios_servicios_equipos.borrado=0");
                oCon.AsignarParametroEntero("@id", idUsuario);
                oCon.AsignarParametroEntero("@idloc", idLoc);
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
        
        public DataTable ListarInformeAsignados(string filtro,bool asignados)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                if (asignados)
                {
                    oCon.CrearComando("SELECT equipos_tipos.nombre as tipo,equipos_marcas.nombre as marca,equipos_modelos.nombre as modelo,equipos.mac,equipos.serie,equipos_tarjetas.numero as tarjeta,usuarios.codigo,concat(usuarios.apellido,', ',usuarios.nombre) as abonado,equipo_clave,equipo_ip, "
                        + " localidades.nombre as localidad, localidades_calles.nombre as calle, usuarios_locaciones.altura,usuarios_locaciones.piso,usuarios_locaciones.depto,"
                        + "(CASE (SELECT configuracion.Valor_N FROM configuracion WHERE (configuracion.Variable = 'Id_Tipo_Facturacion')) WHEN 1 THEN (SELECT zonas.Nombre FROM zonas WHERE (zonas.Id = usuarios_servicios.Id_Tipo_Facturacion)) WHEN 2 THEN (SELECT servicios_categorias.Nombre FROM servicios_categorias WHERE (servicios_categorias.Id = usuarios_servicios.Id_Tipo_Facturacion)) END) AS 'tipofac', "
                        + " servicios_tipos.nombre as tipo_servicio, servicios_modalidad.nombre as modalidad,servicios.descripcion as servicio,usuarios_servicios_equipos.fecha "
                        + " from usuarios_servicios_equipos"
                        + " left join equipos on equipos.id=usuarios_servicios_equipos.id_equipo "
                        + " left join equipos_tipos on equipos_tipos.id=equipos.id_equipos_tipos "
                        + " left join equipos_marcas on equipos_marcas.id=equipos.id_equipos_marcas "
                        + " left join equipos_modelos on equipos_modelos.id=equipos.id_equipos_modelos "
                        + " left join equipos_tarjetas on equipos_tarjetas.id=equipos.id_tarjeta "
                        + " left join usuarios_servicios on usuarios_servicios.id=usuarios_servicios_equipos.id_usuario_servicio "
                        + " left join usuarios_locaciones on usuarios_locaciones.id=usuarios_servicios.id_usuarios_locaciones "
                        + " left join localidades on localidades.id=usuarios_locaciones.id_localidades "
                        + " left join localidades_calles on localidades_calles.id=usuarios_locaciones.id_calle "
                        + " left join servicios on servicios.id=usuarios_servicios.id_servicios "
                        + " left join servicios_tipos on servicios_tipos.id=servicios.id_servicios_tipos "
                        + " left join servicios_modalidad on servicios_modalidad.id=servicios.id_servicios_modalidad "
                        + " left join usuarios on usuarios.id=usuarios_servicios.id_usuarios "
                        + " where usuarios_servicios_equipos.borrado=0 and  " + filtro);

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
        
        public int ActualizarDatosConfig(int idEquipo, string usuario, string contraseña, string direccionIP)
        {
            int respuesta = 1;
            try
            {
                oCon.Conectar();
                oCon.CrearComando("update equipos set equipo_usuario=@equipo_usuario, equipo_clave=@equipo_clave, equipo_ip=@equipo_ip,id_personal=@personal where Id=@id");
                oCon.AsignarParametroCadena("@equipo_usuario", usuario);
                oCon.AsignarParametroCadena("@equipo_clave", contraseña);
                oCon.AsignarParametroCadena("@equipo_ip", direccionIP);
                oCon.AsignarParametroEntero("@personal", Personal.Id_Login);
                oCon.AsignarParametroEntero("@id", idEquipo);
                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                respuesta = -1;
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                throw;
            }
            return respuesta;
        }

        public int ActualizarDatos(int idUse, int idProduct, int idAccount, int idCustomer, int idLocation, int idEquipment)
        {
            int salida = -1;
            try
            {
                oCon.Conectar();
                oCon.CrearComando("UPDATE usuarios_servicios_equipos SET id_equipment=@id_equipo,id_account_acces=@id_account,id_producto=@id_product, id_location=@id_locacion, id_Customer=@id_customer,id_personal=@personal where id=@iduse");
                oCon.AsignarParametroEntero("@iduse", idUse);
                oCon.AsignarParametroEntero("@id_account", idAccount);
                oCon.AsignarParametroEntero("@id_product", idProduct);
                oCon.AsignarParametroEntero("@id_locacion", idLocation);
                oCon.AsignarParametroEntero("@id_customer", idLocation);
                oCon.AsignarParametroEntero("@id_equipo", idEquipment); 
                oCon.AsignarParametroEntero("@personal", Personal.Id_Login);

                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
                salida = 0;
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                throw;
            }
            return salida;

        }

        public void BajaUsuarioServicioEquipo(int use)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("update usuarios_servicios_equipos set borrado=1,id_personal=@personal where id=@id_use");
                oCon.AsignarParametroEntero("@personal", Personal.Id_Login);
                oCon.AsignarParametroEntero("@id_use", Id);
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

        public Int32 GuardarUsuarioServicioEquipo(int idUsuarioServicio, int idEquipo, int idUsuario, int idLocacion, DateTime fecha, int configurado)
        {
            int id = 0;
            try
            {
                oCon.Conectar();
                oCon.CrearComando("INSERT INTO usuarios_servicios_equipos (id_equipo,id_usuario,id_usuario_servicio,id_usuario_locacion,fecha,configurado, id_personal)  VALUES (@idequipo,@idusuario,@idususer,@idlocacion,@fecha,@configurado, @idPersonal);SELECT @@IDENTITY");
                oCon.AsignarParametroEntero("@idequipo", idEquipo);
                oCon.AsignarParametroEntero("@idusuario", idUsuario);
                oCon.AsignarParametroEntero("@idususer", idUsuarioServicio);
                oCon.AsignarParametroEntero("@idlocacion", idLocacion);
                oCon.AsignarParametroFecha("@fecha", fecha);
                oCon.AsignarParametroEntero("@configurado", configurado);
                oCon.AsignarParametroEntero("@idPersonal", Personal.Id_Login);
                id = oCon.EjecutarScalar();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                id = 0;
                oCon.DesConectar();
                throw;
            }
            return id;
        }

        public void ActualizarProductoAux(int idUSE, int idProductpAux)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("update usuarios_servicios_equipos SET id_producto_aux=@id_producto,id_personal=@personal where id=@id_use");
                oCon.AsignarParametroEntero("@id_use", idUSE);
                oCon.AsignarParametroEntero("@id_producto", idProductpAux);
                oCon.AsignarParametroEntero("@personal", Personal.Id_Login);

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

        public DataTable ListarHistorialEquipos(int idEqui)
        {
            DataTable dt;
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT concat(usuarios.Nombre,' , ', usuarios.Apellido) AS Usuario, equipos_tipos.Nombre AS Equipo, personal.Nombre AS personal " +
                    "FROM usuarios_servicios_equipos " +
                    "LEFT JOIN usuarios ON usuarios_servicios_equipos.id_usuario = usuarios.Id " +
                    "LEFT JOIN equipos ON usuarios_servicios_equipos.id_equipo = equipos.Id " +
                    "LEFT JOIN equipos_tipos ON equipos.Id_Equipos_Tipos = equipos_tipos.Id " +
                    "LEFT JOIN personal ON usuarios_servicios_equipos.id_personal = personal.Id " +
                    "WHERE usuarios_servicios_equipos.borrado = 0 and usuarios_servicios_equipos.id_equipo= @idEquipo");
                oCon.AsignarParametroEntero("@idEquipo", idEqui);
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

        public DataTable ListarEquiposDisponibles()
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando(String.Format("SELECT equipos_tipos.id AS id_Equipo_Tipo, equipos_estados.id AS id_Equipo_estado, equipos.id,equipos_tipos.Nombre AS Nombre, equipos_marcas.Nombre AS Marca, equipos.Serie,equipos.Mac " +
                    "FROM equipos " +
                    "LEFT JOIN equipos_estados ON equipos.Id_Equipos_Estados = equipos_estados.Id " +
                    "LEFT JOIN equipos_tipos ON equipos.Id_Equipos_Tipos = equipos_tipos.Id " +
                    "LEFT JOIN equipos_marcas ON equipos.Id_Equipos_Marcas = equipos_marcas.Id " +
                    "WHERE equipos.borrado = 0 AND equipos_estados.Id = {0} ", Convert.ToInt32(Equipos.Equipos_Estados.DISPONIBLE_EN_STOCK)));
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

        public DataTable ListarStockEquiposTipos()
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando(String.Format("SELECT equipos.Id,equipos_tipos.id AS id_tipo,equipos_tipos.Nombre, equipos.Serie,equipos.Mac, equipos_estados.Nombre AS Estado " +
                    "FROM equipos " +
                    "LEFT JOIN equipos_tipos ON equipos.Id_Equipos_Tipos = equipos_tipos.id " +
                    "LEFT JOIN equipos_estados ON equipos.Id_Equipos_Estados = equipos_estados.id " +
                    "WHERE equipos.borrado = 0 AND equipos_estados.id ={0} " +
                    "ORDER BY Nombre; ", Convert.ToInt32(Equipos.Equipos_Estados.DISPONIBLE_EN_STOCK)));
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

        public DataTable ListarEnStock()
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT equipos.Id,equipos_estados.Nombre as estado,"
                                 + "equipos.Id_Equipos_Tipos, equipos_tipos.nombre as tipo,"
                                 + "equipos.Id_Equipos_Marcas, equipos_marcas.nombre as marca, equipos.Id_Equipos_Modelos, equipos_modelos.nombre as modelo,"
                                 + "equipos.Descripcion, equipos.Serie, equipos.Mac FROM equipos"
                                 + " INNER JOIN equipos_estados ON equipos.id_Equipos_Estados = equipos_estados.Id"
                                 + " INNER JOIN equipos_tipos ON equipos.id_Equipos_tipos = equipos_tipos.Id"
                                 + " INNER JOIN equipos_marcas ON equipos.id_Equipos_marcas = equipos_marcas.Id"
                                 + " INNER JOIN equipos_modelos ON equipos.id_Equipos_modelos = equipos_modelos.Id"
                                 + " WHERE equipos.id_Equipos_Estados = 1");
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

        public DataTable ListarEnStockMinetti()
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT equipos.Id,equipos_estados.Nombre as estado,"
                                 + "equipos.Id_Equipos_Tipos, equipos_tipos.nombre as tipo,"
                                 + "equipos.Id_Equipos_Marcas, equipos_marcas.nombre as marca, equipos.Id_Equipos_Modelos, equipos_modelos.nombre as modelo,"
                                 + "equipos.Descripcion, equipos.Serie, equipos.Mac FROM equipos"
                                 + " INNER JOIN equipos_estados ON equipos.id_Equipos_Estados = equipos_estados.Id"
                                 + " INNER JOIN equipos_tipos ON equipos.id_Equipos_tipos = equipos_tipos.Id"
                                 + " INNER JOIN equipos_marcas ON equipos.id_Equipos_marcas = equipos_marcas.Id"
                                 + " INNER JOIN equipos_modelos ON equipos.id_Equipos_modelos = equipos_modelos.Id"
                                 + " WHERE equipos.id_Equipos_Estados = 1 AND equipos_tipos.id = 2 and equipos.borrado =0");
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

        public Int32 MudarEquiposUsuarioServicio(int idUsuarioServicioViejo,int idUsuarioServicioNuevo,out string salida)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("update usuarios_servicios_equipos set id_usuario_servicio=@idnuevo,id_personal=@personal where id_usuario_servicio=@idviejo");
                oCon.AsignarParametroEntero("@idviejo", idUsuarioServicioViejo);
                oCon.AsignarParametroEntero("@idnuevo", idUsuarioServicioNuevo);
                oCon.AsignarParametroEntero("@personal", Personal.Id_Login);

                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
                salida = "";
                return 0;
            }
            catch (Exception c)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                salida = c.ToString();
                return -1;
            }
        }

        public bool AsignarEquipo(int idParte,Partes.Partes_Operaciones estado,out string salida)
        {
            try
            {
                Partes_Equipos oParteEquipo = new Partes_Equipos();
                Equipos_Tarjetas oEquipoTarjeta = new Equipos_Tarjetas();
                DataTable dtEquiposPorActivar = oParteEquipo.ListarPorParte(idParte);
                DataTable dtDatosUsuSerEquipos = new DataTable();
                foreach (DataRow EquipoActivar in dtEquiposPorActivar.Rows)
                {
                    if (estado  == Partes.Partes_Operaciones.CAMBIO_DE_EQUIPO)
                    {
                        PasarEquipoReparacion(Convert.ToInt32(EquipoActivar["id_equipo_anterior"]), Convert.ToInt32(EquipoActivar["id_usuarios_servicios"]));
                        dtDatosUsuSerEquipos = ListarDatosUsuariosServiciosEquipos(Convert.ToInt32(EquipoActivar["id_usuarios_servicios"]), Convert.ToInt32(EquipoActivar["id_equipo_anterior"]));
                        if (dtDatosUsuSerEquipos.Rows.Count > 0)
                            BajaUsuarioServicioEquipo(Convert.ToInt32(dtDatosUsuSerEquipos.Rows[0]["id"]));
                        if (Convert.ToInt32(EquipoActivar["id_tarjeta_anterior"]) > 0)
                        {
                            oEquipoTarjeta.QuitarTarjetaEquipo(Convert.ToInt32(EquipoActivar["id_equipo_anterior"]));
                            if (Convert.ToInt32(EquipoActivar["id_tarjeta"]) != Convert.ToInt32(EquipoActivar["id_tarjeta_anterior"]))
                                oEquipoTarjeta.CambiarEstadoTarjeta(Convert.ToInt32(EquipoActivar["id_tarjeta_anterior"]), Convert.ToInt32(Equipos_Tarjetas.Tarjetas_Estados.CON_FALLA));
                            else
                                oEquipoTarjeta.AsignarTarjetaEquipo(Convert.ToInt32(EquipoActivar["id_equipos"]), Convert.ToInt32(EquipoActivar["id_tarjeta"]));
                        }

                        if (Convert.ToInt32(EquipoActivar["id_parte_equipo_anterior"]) > 0)
                            oParteEquipo.Eliminar(Convert.ToInt32(EquipoActivar["id_parte_equipo_anterior"]));

                        //si ya esta asignado a usuario no lo vuelvo a cambiarle el estado 
                        DataTable dtDatosEquipo = new DataTable();
                        dtDatosEquipo = BuscarDatosEquipo(Convert.ToInt32(EquipoActivar["id_equipos"]));
                        if (dtDatosEquipo.Rows.Count > 0)
                        {
                            if (Convert.ToInt32(dtDatosEquipo.Rows[0]["id_equipos_Estados"]) != (int)Equipos.Equipos_Estados.ASIGNADO_A_USUARIO)
                                CambiarEstado(Convert.ToInt32(EquipoActivar["id_equipos"]), Convert.ToInt32(Equipos.Equipos_Estados.ASIGNADO_A_USUARIO), out salida);

                        }
                    }

                        
                   
                }
                salida = "";
                return true;
            }
            catch (Exception c)
            {
                salida = c.ToString();
                return false;
                throw;
            }
        }

        public Int32 verificarUsuario_Equipo_Tarjeta(int idUsuarioServicio)
        {
            DataTable dt = new DataTable();
            dt.Clear();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT equipos_tarjetas.numero as Tarjeta FROM partes_equipos  " +
                    "LEFT JOIN equipos_tarjetas ON partes_equipos.Id_Tarjeta = equipos_tarjetas.id " +
                    $"WHERE partes_equipos.Id_Usuarios_Servicios = {idUsuarioServicio} AND partes_equipos.borrado = 0 AND equipos_tarjetas.borrado = 0; ");
                dt = oCon.Tabla();
                if(dt.Rows.Count == 0)
                {
                    dt.Clear();
                    oCon.CrearComando("SELECT equipos_tarjetas.numero AS tarjeta " +
                        " FROM equipos " +
                        " LEFT JOIN equipos_tarjetas ON equipos.Id_Tarjeta = equipos_tarjetas.id " +
                        $" WHERE equipos.Id_Usuarios_Servicios = {idUsuarioServicio} and equipos.borrado=0 and equipos_tarjetas.borrado=0; ");
                    dt = oCon.Tabla();
                }
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }
            if (dt.Rows.Count > 0)
                return 1;
            else
                return 0;
        }

    }
}