using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Usuarios_Servicios
    {
        public Int32 Id { get; set; } = 0;
        public Int32 Id_Usuarios { get; set; }
        public Int32 Id_Usuarios_Locaciones { get; set; }
        public Int32 Id_Zonas { get; set; }
        public Int32 Id_Servicios { get; set; }
        public Int32 Id_Servicios_Categorias { get; set; }
        public Int32 Id_Servicios_Tipo { get; set; }
        public Int32 Id_Servicios_Estados { get; set; }
        public Int32 Id_Bonificacion_Esp { get; set; }
        public Int32 Id_Tipo_Facturacion { get; set; }
        public DateTime Fecha_Estado { get; set; }
        public DateTime Fecha_Inicio { get; set; }
        public DateTime Fecha_Fin { get; set; }
        public DateTime Fecha_Saldado { get; set; }
        public DateTime Fecha_Factura { get; set; }
        public DateTime Fecha_Factura_Desde { get; set; }
        public String Tipo { get; set; }
        public Int32 Cant_Bocas { get; set; }
        public Int32 Cant_Bocas_Pac { get; set; }
        public Int32 Borrado { get; set; }
        public Int32 Meses_Servicio { get; set; }
        public Int32 Meses_Cobro { get; set; }

        public static Int32 Current_IdUsuarioServicio;

        private Conexion oCon = new Conexion();

        public enum _TipoItemServicio { SERVICIO_PROPIO = 1, SUBSERVICIO_PROPIO = 2, SERVICIO_HEREDADO = 3, SUBSERVICIO_HEREDADO = 4 };

        public Usuarios_Servicios GetUsuarioServicio(int id)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT * FROM usuarios_servicios WHERE id = @id AND borrado = 0");
                oCon.AsignarParametroEntero("@id", id);
                DataTable dt = oCon.Tabla();
                oCon.DesConectar();

                Usuarios_Servicios oUsServ = new Usuarios_Servicios();
                oUsServ.Id = Convert.ToInt32(dt.Rows[0]["Id"]);
                oUsServ.Id_Usuarios = Convert.ToInt32(dt.Rows[0]["Id_Usuarios"]);
                oUsServ.Id_Usuarios_Locaciones = Convert.ToInt32(dt.Rows[0]["Id_Usuarios_Locaciones"]);
                oUsServ.Id_Zonas = Convert.ToInt32(dt.Rows[0]["Id_Zonas"]);
                oUsServ.Id_Servicios = Convert.ToInt32(dt.Rows[0]["Id_Servicios"]);
                oUsServ.Id_Servicios_Categorias = Convert.ToInt32(dt.Rows[0]["Id_Servicios_Categorias"]);
                oUsServ.Id_Servicios_Tipo = Convert.ToInt32(dt.Rows[0]["Id_Servicios_Tipo"]);
                oUsServ.Id_Servicios_Estados = Convert.ToInt32(dt.Rows[0]["Id_Servicios_Estados"]);
                oUsServ.Id_Bonificacion_Esp = Convert.ToInt32(dt.Rows[0]["Id_Bonificacion_Esp"]);
                oUsServ.Id_Tipo_Facturacion = Convert.ToInt32(dt.Rows[0]["Id_Tipo_Facturacion"]);
                oUsServ.Fecha_Estado = Convert.ToDateTime(dt.Rows[0]["Fecha_Estado"]);
                oUsServ.Fecha_Factura = Convert.ToDateTime(dt.Rows[0]["Fecha_Factura"]);
                oUsServ.Fecha_Factura_Desde = Convert.ToDateTime(dt.Rows[0]["Fecha_Factura_Desde"]);
                oUsServ.Fecha_Fin = Convert.ToDateTime(dt.Rows[0]["Fecha_Fin"]);
                oUsServ.Fecha_Inicio = Convert.ToDateTime(dt.Rows[0]["Fecha_Inicio"]);
                oUsServ.Fecha_Saldado = Convert.ToDateTime(dt.Rows[0]["Fecha_Saldado"]);
                oUsServ.Tipo = dt.Rows[0]["Tipo"].ToString();
                oUsServ.Cant_Bocas = Convert.ToInt32(dt.Rows[0]["cant_bocas"]);
                oUsServ.Cant_Bocas_Pac = Convert.ToInt32(dt.Rows[0]["Cant_Bocas_Pac"]);
                oUsServ.Borrado = Convert.ToInt32(dt.Rows[0]["Borrado"]);
                oUsServ.Meses_Servicio = Convert.ToInt32(dt.Rows[0]["Meses_Servicio"]);
                oUsServ.Meses_Cobro = Convert.ToInt32(dt.Rows[0]["Meses_Cobro"]);

                return oUsServ;
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }
        }

        public Int32 Guardar(Usuarios_Servicios oUsuario_Ser)
        {
            int id = 0;
            try
            {
                oCon.Conectar();
                if (oUsuario_Ser.Id > 0)
                {
                    oCon.CrearComando("UPDATE Usuarios_Servicios SET Id_Usuarios = @usuario, Id_Usuarios_Locaciones = @locacion, Id_Zonas = @zona, Id_Servicios = @servicio, Id_Servicios_Categorias = @servicio_categ, " +
                        "Id_Servicios_Tipo = @servicio_tipo, Id_Servicios_Estados = @estado, Id_Bonificacion_Esp = @bonif, Id_Tipo_Facturacion = @tipofac, Fecha_Estado = @fecest, Fecha_Inicio = @inicio, Fecha_Fin = @fin, Fecha_Factura = @factura, " +
                        "Tipo = @tipo, Cant_Bocas = @bocas, Cant_Bocas_Pac = @bocas_pac, Meses_Servicio = @meses_servicio, Meses_Cobro = @meses_cobro, Fecha_Factura_Desde = @fecha_factura_desde " +
                        "WHERE id = @id");
                    oCon.AsignarParametroEntero("@id", oUsuario_Ser.Id);
                }
                else
                {
                    oCon.CrearComando("INSERT INTO Usuarios_Servicios(Id_Usuarios, Id_Usuarios_Locaciones, Id_Zonas, Id_Servicios, Id_Servicios_Categorias, Id_Servicios_Tipo, Id_Servicios_Estados, Id_Bonificacion_Esp, Id_Tipo_Facturacion, Fecha_Estado, Fecha_Inicio, Fecha_Fin, Fecha_Factura, Tipo, Cant_Bocas, Cant_Bocas_Pac,Meses_Servicio,Meses_Cobro, Fecha_Factura_Desde) " +
                        "VALUES(@usuario, @locacion, @zona, @servicio, @servicio_categ, @servicio_tipo, @estado, @bonif, @tipofac, @fecest, @inicio, @fin, @factura, @tipo, @bocas, @bocas_pac,@meses_servicio,@meses_cobro, @fecha_factura_desde); SELECT @@IDENTITY");
                }

                oCon.AsignarParametroEntero("@usuario", oUsuario_Ser.Id_Usuarios);
                oCon.AsignarParametroEntero("@locacion", oUsuario_Ser.Id_Usuarios_Locaciones);
                oCon.AsignarParametroEntero("@zona", oUsuario_Ser.Id_Zonas);
                oCon.AsignarParametroEntero("@servicio", oUsuario_Ser.Id_Servicios);
                oCon.AsignarParametroEntero("@servicio_categ", oUsuario_Ser.Id_Servicios_Categorias);
                oCon.AsignarParametroEntero("@servicio_tipo", oUsuario_Ser.Id_Servicios_Tipo);
                oCon.AsignarParametroEntero("@estado", oUsuario_Ser.Id_Servicios_Estados);
                oCon.AsignarParametroEntero("@bonif", oUsuario_Ser.Id_Bonificacion_Esp);
                oCon.AsignarParametroEntero("@tipofac", oUsuario_Ser.Id_Tipo_Facturacion);
                oCon.AsignarParametroFecha("@fecest", oUsuario_Ser.Fecha_Estado);
                oCon.AsignarParametroFecha("@inicio", oUsuario_Ser.Fecha_Inicio);
                oCon.AsignarParametroFecha("@fin", oUsuario_Ser.Fecha_Fin);
                oCon.AsignarParametroFecha("@factura", oUsuario_Ser.Fecha_Factura);
                oCon.AsignarParametroCadena("@tipo", oUsuario_Ser.Tipo);
                oCon.AsignarParametroEntero("@bocas", oUsuario_Ser.Cant_Bocas);
                oCon.AsignarParametroEntero("@bocas_pac", oUsuario_Ser.Cant_Bocas_Pac);
                oCon.AsignarParametroEntero("@meses_servicio", oUsuario_Ser.Meses_Servicio);
                oCon.AsignarParametroEntero("@meses_cobro", oUsuario_Ser.Meses_Cobro);
                oCon.AsignarParametroFecha("@fecha_factura_desde", oUsuario_Ser.Fecha_Factura_Desde);
                oCon.ComenzarTransaccion();
                if (oUsuario_Ser.Id == 0)
                    id = oCon.EjecutarScalar();
                else
                {
                    oCon.EjecutarComando();
                    id = oUsuario_Ser.Id;
                }
               
                oCon.ConfirmarTransaccion();

                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                throw;
            }

            return id;
        }

        public Int32 Get_Id_Usuarios_Servicios_Sub(Int32 idusuariosserv, Int32 idserviciossub)
        {
            int id = 0;

            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando(string.Format("SELECT id from usuarios_servicios_sub WHERE id_usuarios_servicios = {0} and id_servicios_sub = {1}", idusuariosserv, idserviciossub));
                dt = oCon.Tabla();

                if (dt.Rows.Count > 0)
                    id = Convert.ToInt32(dt.Rows[0]["id"]);

                oCon.DesConectar();
            }
            catch (Exception)
            {
                throw;
            }

            return id;
        }

        public Int32 Guardar_Subservicios(int idUsuarios_Servicios_Sub, int idUsuarios_Servicios, int idServicios_Sub, int idVelocidad, int idVelocidadTipo, int requiereIP, int idBonificacion_Esp, int idBonificacion_Aplicada, decimal porcentaje, string bonificacion, DateTime fechaInicio, DateTime fechaFin, int borrado)
        {
            int id = 0;
            try
            {
                oCon.Conectar();
                
                if(idUsuarios_Servicios_Sub > 0)
                {
                    oCon.CrearComando("UPDATE usuarios_servicios_sub SET Id_Usuarios_Servicios = @idUsServicios, Id_Servicios_Sub = @subservicio, Id_Servicios_Velocidades_Tip = @idvelotip, Id_Servicios_Velocidades = @idvelo," +
                        "Requiere_IP = @reqip, Id_Bonificacion_Esp = @boniesp, Id_Bonificacion_Aplicada = @idboniaplicada, Porcentaje_Bonificacion_Aplicada = @porcentaje, Nombre_Bonificacion_Aplicacion = @bonificacion, fecha_inicio = @fecha_inicio, fecha_fin = @fecha_fin, id_ip_fija = @id_ip_fija,borrado=@borrado " +
                        "WHERE id = @idus_serv_sub");
                    oCon.AsignarParametroEntero("@idus_serv_sub", idUsuarios_Servicios_Sub);
                }
                else
                {
                    oCon.CrearComando("INSERT INTO usuarios_servicios_sub(Id_Usuarios_Servicios, Id_Servicios_Sub, Id_Servicios_Velocidades_Tip, Id_Servicios_Velocidades, Requiere_IP, Id_Bonificacion_Esp, Id_Bonificacion_Aplicada, Porcentaje_Bonificacion_Aplicada, Nombre_Bonificacion_Aplicacion, fecha_inicio,fecha_fin,id_ip_fija,borrado) " +
                        "VALUES(@idUsServicios, @subservicio, @idvelotip, @idvelo, @reqip, @boniesp, @idboniaplicada, @porcentaje, @bonificacion, @fecha_inicio,@fecha_fin,@id_ip_fija,@borrado); SELECT @@IDENTITY");
                }
                oCon.AsignarParametroEntero("@idUsServicios", idUsuarios_Servicios);
                oCon.AsignarParametroEntero("@subservicio", idServicios_Sub);
                oCon.AsignarParametroEntero("@idvelotip", idVelocidadTipo);
                oCon.AsignarParametroEntero("@idvelo", idVelocidad);
                oCon.AsignarParametroEntero("@reqip", requiereIP);
                oCon.AsignarParametroEntero("@boniesp", idBonificacion_Esp);
                oCon.AsignarParametroEntero("@idboniaplicada", idBonificacion_Aplicada);
                oCon.AsignarParametroDecimal("@porcentaje", porcentaje);
                oCon.AsignarParametroCadena("@bonificacion", bonificacion);
                oCon.AsignarParametroFecha("@fecha_inicio", fechaInicio);
                oCon.AsignarParametroFecha("@fecha_fin", fechaFin);
                if (requiereIP == 1)
                    oCon.AsignarParametroEntero("@id_ip_fija", -1);
                else
                    oCon.AsignarParametroEntero("@id_ip_fija", 0);
                oCon.AsignarParametroEntero("@borrado", borrado);
                oCon.ComenzarTransaccion();
                if(idUsuarios_Servicios_Sub == 0)
                    id = oCon.EjecutarScalar();
                else
                {
                    oCon.EjecutarComando();
                    id = idUsuarios_Servicios_Sub;
                }
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                throw;
            }
            return id;
            //111119fede
        }

        public Int32 ActualizarEstadoUsuarioServicioSub(int id_usuario_servicio_sub,int borrado)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando($"UPDATE usuarios_Servicios_sub set borrado = {borrado} where id = {id_usuario_servicio_sub}");
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
                return 1;
            }
            catch (Exception)
            {
                oCon.DesConectar();
                return 0;
                throw;
            }


        }

        public void ActualizarIpFija(int id_usuarios_servicios, int id_servicios_sub, int id_ip)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("UPDATE Usuarios_Servicios_Sub set requiere_ip = @requiere_ip, Id_Ip_Fija=@id_ip_fija where id_usuarios_servicios=@id_usuarios_servicios and id_servicios_sub=@id_servicios_sub");
                oCon.AsignarParametroEntero("@requiere_ip", id_ip > 0 ? 1 : 0);
                oCon.AsignarParametroEntero("@id_ip_fija", id_ip);
                oCon.AsignarParametroEntero("@id_usuarios_servicios", id_usuarios_servicios);
                oCon.AsignarParametroEntero("@id_servicios_sub", id_servicios_sub);
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

        public bool ActivarServicio(int id, DateTime fecha,out string salida)
        {
            try
            {
                oCon.Conectar();

                oCon.CrearComando("UPDATE usuarios_servicios set id_servicios_estados=2, fecha_estado=@estado,fecha_inicio=@inicio where id=@id ");
                oCon.AsignarParametroEntero("@id", id);
                oCon.AsignarParametroFecha("@estado", fecha);
                oCon.AsignarParametroFecha("@inicio", fecha);
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
                salida = "";
                return true;
            }
            catch (Exception c)
            {
                salida = c.ToString();
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                return false;
                throw;
            }
        }

        public void Actualizar_fecha_facturado(int id)
        {
            DataTable dtDatosUsuarioServicio = new DataTable();
            DateTime fechaInicio = new DateTime();
            try
            {
                oCon.Conectar();
                oCon.CrearComando(String.Format("select * from usuarios_servicios where id={0}", id));
                dtDatosUsuarioServicio = oCon.Tabla();
                fechaInicio = Convert.ToDateTime(dtDatosUsuarioServicio.Rows[0]["fecha_inicio"]);

                oCon.ComenzarTransaccion();
                oCon.CrearComando("UPDATE Usuarios_servicios SET fecha_factura =@fecha, fecha_fin=@fechaFin, fecha_factura_desde=@fechaFacturaDesde  WHERE Id = @id");
                oCon.AsignarParametroEntero("@id", id);
                oCon.AsignarParametroFecha("@fecha", Fecha_Factura);
                oCon.AsignarParametroFecha("@fechaFin", Fecha_Factura);
                oCon.AsignarParametroFecha("@fechaFacturaDesde", Fecha_Factura_Desde);
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

        public void Actualizar_avisos(int campo, int estado, Int32 id)
        {
            oCon.Conectar();
            oCon.ComenzarTransaccion();

            if (campo == 1)
            {
                oCon.CrearComando("UPDATE Usuarios_servicios set con_aviso = @Estado WHERE Id = @Id");
                oCon.AsignarParametroEntero("@Id", id);
                oCon.AsignarParametroEntero("@Estado", estado);
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
            }


            if (campo == 2)
            {
                oCon.CrearComando("UPDATE Usuarios_servicios set con_corte = @Estado WHERE Id = @Id");
                oCon.AsignarParametroEntero("@Id", id);
                oCon.AsignarParametroEntero("@Estado", estado);
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
            }


            if (campo == 3)
            {
                oCon.CrearComando("UPDATE Usuarios_servicios set con_corte = @corte, con_aviso=@aviso WHERE Id = @Id");
                oCon.AsignarParametroEntero("@Id", id);
                oCon.AsignarParametroEntero("@corte", estado);
                oCon.AsignarParametroEntero("@aviso", estado);
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
            }

        }

        public void ActualizarEstadoCorte(int id, int id_corte)
        {
            try
            {
                oCon.Conectar();
                //oCon.ComenzarTransaccion();
                oCon.CrearComando("UPDATE Usuarios_servicios set id_servicios_estados = @id_estado WHERE Id = @Id");
                oCon.AsignarParametroEntero("@id_estado", id_corte);
                oCon.AsignarParametroEntero("@Id", id);

                oCon.EjecutarComando();
                //oCon.ConfirmarTransaccion();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                throw;
            }
        }

        public void ActualizarEstado(int id, int id_estado)
        {
            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();
                if (id_estado == 0)
                {
                    oCon.CrearComando("UPDATE Usuarios_servicios set id_servicios_estados = @Estado,fecha_estado = @Fecha WHERE Id = @Id");

                    oCon.AsignarParametroEntero("@Estado", Id_Servicios_Estados);
                    oCon.AsignarParametroFecha("@Fecha", Fecha_Estado);
                }
                else
                {
                    oCon.CrearComando("UPDATE Usuarios_servicios set id_servicios_estados = @Estado WHERE Id = @Id");

                    oCon.AsignarParametroEntero("@Estado", id_estado);
                }
                oCon.AsignarParametroEntero("@Id", id);
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

        public void ActualizarEstado(int id, int id_estado, int conCorte = 0)
        {
            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();
                if (id_estado == 0)
                {
                    oCon.CrearComando("UPDATE Usuarios_servicios set id_servicios_estados = @Estado,fecha_estado = @Fecha, con_corte=@corte WHERE Id = @Id");

                    oCon.AsignarParametroEntero("@Estado", Id_Servicios_Estados);
                    oCon.AsignarParametroFecha("@Fecha", Fecha_Estado);
                    oCon.AsignarParametroEntero("@corte", conCorte);
                }
                else
                {
                    oCon.CrearComando("UPDATE Usuarios_servicios set id_servicios_estados = @Estado, con_corte=@corte WHERE Id = @Id");
                    oCon.AsignarParametroEntero("@Estado", id_estado);
                    oCon.AsignarParametroEntero("@corte", conCorte);

                }
                oCon.AsignarParametroEntero("@Id", id);
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

        public void ActualizarLocacion(int id_locacion_antigua, int id_locacion_nueva, int id_usuarios_servicios)
        {
            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();
                oCon.CrearComando("UPDATE Usuarios_servicios set Id_Usuarios_Locaciones = @id_locacion_nueva WHERE Id=@id_usuarios_servicios and Id_Usuarios_Locaciones = @id_locacion_antigua");
                oCon.AsignarParametroEntero("@id_locacion_nueva", id_locacion_nueva);
                oCon.AsignarParametroEntero("@id_usuarios_servicios", id_usuarios_servicios);
                oCon.AsignarParametroEntero("@id_locacion_antigua", id_locacion_antigua);

                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
                //MessageBox.Show("No se pudieron actualizar los servicios.");
            }
        }

        public void QuitarSubservicio(int IdUsuarioServiciosub)
        {
            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();
                oCon.CrearComando("UPDATE usuarios_servicios_sub SET borrado=1  WHERE Id = @id");
                oCon.AsignarParametroEntero("@id", IdUsuarioServiciosub);
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

        public void DesactivarSubservicio(int IdUsuarioServiciosub, int borrado = -1)
        {
            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();
                oCon.CrearComando("UPDATE usuarios_servicios_sub SET borrado=@borrado  WHERE Id = @id");
                oCon.AsignarParametroEntero("@borrado", borrado);
                oCon.AsignarParametroEntero("@id", IdUsuarioServiciosub);
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

        public void ActivarSubservicio(int IdUsuarioServiciosub)
        {
            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();
                oCon.CrearComando("UPDATE usuarios_servicios_sub SET borrado=0  WHERE Id = @id");
                oCon.AsignarParametroEntero("@id", IdUsuarioServiciosub);
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

        public void ActualizarFechaEstado(int IdUsuariosServicios, DateTime Fecha)
        {
            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();
                oCon.CrearComando("UPDATE usuarios_servicios set fecha_estado = @fecha WHERE Id = @Id");
                oCon.AsignarParametroFecha("@fecha", Fecha);
                oCon.AsignarParametroEntero("@Id", IdUsuariosServicios);

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

        public void ActualizarBocas(int id_usuarios_servicios, int cantBocas, char tipo, char operacion)
        {
            //a= agregar, q=quitar, p=pactada, c=comun
            try
            {
                oCon.Conectar();
                if (operacion == 'a')
                {
                    if (tipo == 'p')
                        oCon.CrearComando("Update Usuarios_Servicios set cant_bocas_pac=@cant_bocas where id=@id");
                    else
                        oCon.CrearComando("Update Usuarios_Servicios set cant_bocas=@cant_bocas where id=@id");
                }
                else
                {
                    if (tipo == 'p')
                        oCon.CrearComando("Update Usuarios_Servicios set cant_bocas_pac=cant_bocas_pac-@cant_bocas where id=@id");
                    else
                        oCon.CrearComando("Update Usuarios_Servicios set cant_bocas=cant_bocas-@cant_bocas where id=@id");
                }

                oCon.AsignarParametroEntero("@cant_bocas", cantBocas);
                oCon.AsignarParametroEntero("@id", id_usuarios_servicios);
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

        public Int32 ActualizarBonificacionEsp(int idBonificacion, DataTable dtSub)
        {
            try
            {
                oCon.Conectar();
                foreach (DataRow item in dtSub.Rows)
                {

                    oCon.CrearComando("UPDATE usuarios_servicios_sub SET id_bonificacion_Esp=@idboni where id=@idsub");
                    oCon.AsignarParametroEntero("@idboni", idBonificacion);
                    oCon.AsignarParametroEntero("@idsub", Convert.ToInt32(item["idUsuarioServicioSub"]));
                    oCon.ComenzarTransaccion();
                    oCon.EjecutarComando();
                    oCon.ConfirmarTransaccion();
                }
                oCon.DesConectar();
                return 0;
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                return -1;
                //throw;
            }
        }

        public Int32 ActualizarMesesCobroServicios(int idUsuariosServicios, int mesesCobro, int mesesServicios)//metodo nuevo maxi complementarias 30/09
        {
            int retorno = 0;
            try
            {
                oCon.Conectar();
                oCon.CrearComando("update usuarios_servicios set meses_cobro=@cobro_meses,meses_servicio=@servicio_meses where id=@id_usuario_servicio");
                oCon.AsignarParametroEntero("@cobro_meses", mesesCobro);
                oCon.AsignarParametroEntero("@servicio_meses", mesesServicios);
                oCon.AsignarParametroEntero("@id_usuario_servicio", idUsuariosServicios);
                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
                retorno = 0;
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                retorno = -1;
                throw;
            }
            return retorno;
        }

        public Int32 ActualizarConCorte(int id, int valor)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("update usuarios_servicios set con_corte=@valor where id=@idUsuSer");
                oCon.AsignarParametroEntero("@valor", valor);
                oCon.AsignarParametroEntero("@idUsuSer", id);
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
                return 1;
            }
        }

        public DataTable Listar_Servicios_Activos(int id_locacion, int verTodos = 0)
        {

            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                if (verTodos == 0)
                {
                    oCon.CrearComando(string.Format("select usuarios_servicios.id,usuarios_servicios.fecha_inicio, usuarios_servicios.fecha_factura, usuarios_servicios.id_usuarios, usuarios_servicios.id_servicios, servicios_tipos.id as id_servicios_tipo, servicios_grupos.id as id_servicios_grupo," +
                                                    " usuarios_locaciones.id as id_usuarios_locaciones, usuarios_servicios.id_zonas, usuarios_servicios.id_servicios_categorias, servicios.corteautomatico, servicios.id_Aplicaciones_externas as idAppExterna, " +
                                                    //" if (servicios.requiere_velocidad = 'SI',concat(servicios.descripcion, ' ', cast(servicios_velocidades.velocidad as char(4)), ' MB ', servicios_velocidades_tip.nombre),servicios.descripcion) as servicio," +
                                                    "servicios.descripcion as servicio, " +
                                                    " servicios.requiere_equipo, servicios.requiere_tarjeta, '' as requiere_velocidad, servicios_tipos.nombre as tipo_servicio, (select estado from servicios_estados where id = usuarios_servicios.id_servicios_estados) as estado," +
                                                    " usuarios_locaciones.calle,usuarios_locaciones.altura, localidades.nombre as localidad,  usuarios_servicios.id_tipo_facturacion, usuarios_servicios.id as id_usuario_servicio, servicios_tipos.id as id_servicio_tipo, usuarios_servicios.id_servicios_estados,ifnull(equipos.Mac, ' ') AS MAC, ifnull(equipos.Serie,' ') AS Serie,ifnull(equipos_tarjetas.Numero,' ') AS Tarjeta  from usuarios_servicios " +
                                                    " left join servicios on usuarios_servicios.id_servicios = servicios.id " +
                                                    " left join servicios_tipos on servicios.id_servicios_tipos = servicios_tipos.id " +
                                                    " left join servicios_grupos on servicios_tipos.id_servicios_grupos = servicios_grupos.id " +
                                                    " left join usuarios_locaciones on usuarios_servicios.id_usuarios_locaciones = usuarios_locaciones.id " +
                                                    " left join localidades on usuarios_locaciones.id_localidades = localidades.id " +
                                                    " left join usuarios_servicios_sub on usuarios_servicios.id = usuarios_servicios_sub.id_usuarios_servicios " +
                                                    " left join servicios_sub on usuarios_servicios_sub.id_servicios_sub = servicios_sub.id " +
                                                    " left join servicios_velocidades on usuarios_servicios_sub.id_servicios_velocidades = servicios_velocidades.id " +
                                                    " left join servicios_velocidades_tip on usuarios_servicios_sub.id_servicios_velocidades_tip = servicios_velocidades_tip.id " +
                                                    " LEFT JOIN equipos ON equipos.Id_Usuarios_Servicios = usuarios_servicios.Id " +
                                                    " LEFT JOIN equipos_tarjetas ON equipos.Id_Tarjeta = equipos_tarjetas.id " +
                                                    " where usuarios_locaciones.id = {0}  and usuarios_servicios.id_servicios_estados!={2} and usuarios_servicios.borrado=0 group by usuarios_servicios.id", id_locacion, Convert.ToInt32(Servicios_Sub.SERVICIO_SUB_TIPOS.SUBSERVICIO), Convert.ToInt32(Servicios.Servicios_Estados.RETIRADO)));
                }
                else
                {
                    oCon.CrearComando(string.Format("select usuarios_servicios.id,usuarios_servicios.fecha_inicio, usuarios_servicios.fecha_factura, usuarios_servicios.id_usuarios, usuarios_servicios.id_servicios, servicios_tipos.id as id_servicios_tipo, servicios_grupos.id as id_servicios_grupo," +
                                                   " usuarios_locaciones.id as id_usuarios_locaciones, usuarios_servicios.id_zonas, usuarios_servicios.id_servicios_categorias, servicios.corteautomatico, servicios.id_Aplicaciones_externas as idAppExterna, " +
                                                   //" if (servicios.requiere_velocidad = 'SI',concat(servicios.descripcion, ' ', cast(servicios_velocidades.velocidad as char(4)), ' MB ', servicios_velocidades_tip.nombre),servicios.descripcion) as servicio," +
                                                   "servicios.descripcion as servicio, " +
                                                   " servicios.requiere_equipo, servicios.requiere_tarjeta, '' as requiere_velocidad, servicios_tipos.nombre as tipo_servicio, (select estado from servicios_estados where id = usuarios_servicios.id_servicios_estados) as estado," +
                                                   " usuarios_locaciones.calle,usuarios_locaciones.altura, localidades.nombre as localidad,  usuarios_servicios.id_tipo_facturacion, usuarios_servicios.id as id_usuario_servicio, servicios_tipos.id as id_servicio_tipo,usuarios_servicios.id_servicios_estados from usuarios_servicios " +
                                                   " left join servicios on usuarios_servicios.id_servicios = servicios.id " +
                                                   " left join servicios_tipos on servicios.id_servicios_tipos = servicios_tipos.id " +
                                                   " left join servicios_grupos on servicios_tipos.id_servicios_grupos = servicios_grupos.id " +
                                                   " left join usuarios_locaciones on usuarios_servicios.id_usuarios_locaciones = usuarios_locaciones.id " +
                                                   " left join localidades on usuarios_locaciones.id_localidades = localidades.id " +
                                                   " left join usuarios_servicios_sub on usuarios_servicios.id = usuarios_servicios_sub.id_usuarios_servicios " +
                                                   " left join servicios_sub on usuarios_servicios_sub.id_servicios_sub = servicios_sub.id " +
                                                   " left join servicios_velocidades on usuarios_servicios_sub.id_servicios_velocidades = servicios_velocidades.id " +
                                                   " left join servicios_velocidades_tip on usuarios_servicios_sub.id_servicios_velocidades_tip = servicios_velocidades_tip.id " +
                                                   " where usuarios_locaciones.id = {0}  and usuarios_servicios.borrado=0 group by usuarios_servicios.id", id_locacion, Convert.ToInt32(Servicios_Sub.SERVICIO_SUB_TIPOS.SUBSERVICIO), Convert.ToInt32(Servicios.Servicios_Estados.RETIRADO)));
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
            //111119fede
        }

        public DataTable Traer_datos_usuarios_servicios(int Id_usuarios_servicios)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando(string.Format("SELECT usuarios_servicios.id, usuarios_servicios.id_usuarios, usuarios_servicios.id_zonas, usuarios_servicios.id_usuarios_locaciones, usuarios_servicios.id_servicios," +
                                    " usuarios_servicios.id_servicios_categorias, servicios_grupos.id as id_servicios_grupo, usuarios_servicios.id_servicios_tipo, " +
                                    "(select descripcion from servicios where id = id_servicios) as servicio," +
                                    " servicios_tipos.nombre as tiposervicio,usuarios_servicios.cant_bocas,usuarios_servicios.cant_bocas_pac," +
                                    " usuarios_servicios.Fecha_Factura,usuarios_servicios.Fecha_inicio,usuarios_servicios.Id_Tipo_Facturacion, usuarios_servicios.id_servicios_estados," +
                                    " (select corteautomatico from servicios where id = id_servicios) as corteautomatico,meses_cobro,meses_servicio " +
                                    " from usuarios_servicios " +
                                    " left join servicios_tipos on servicios_tipos.id = usuarios_servicios.id_servicios_tipo " +
                                    " left join servicios_grupos on servicios_grupos.id = servicios_tipos.id_servicios_grupos " +
                                    " where usuarios_servicios.id = @id_usuario_servicio"));
                oCon.AsignarParametroEntero("@id_usuario_servicio", Id_usuarios_servicios);
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

        public DataTable ListarSubserviciosDisponibles(int IdTarifaVigente, int IdServicio, int IdTipoFacturacion)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando(string.Format("select vw_tarifas.*, (select requiere_ip from servicios_sub where id=vw_tarifas.id_servicios_sub) as requiere_ip from vw_tarifas where id_servicios_tarifas={0} and id_servicios={1} and tiposub='S' and id_tipo_facturacion={2}", IdTarifaVigente, IdServicio, IdTipoFacturacion));
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

        public DataTable ListarServicios(int idUsuarios, int idLocacion)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando(String.Format("SELECT Descripcion as Servicio, Estado, Id_Servicios_Tipos,id_servicios, servicios_tipos.nombre as ServicioTipo, usuarios_servicios.id,id_zonas,id_servicios_tipo,id_usuarios_locaciones,id_servicios_estados, id_servicios_categorias,zonas_localidades.id_zona,usuarios_servicios.fecha_factura, servicios.corteautomatico, servicios.id_servicios_modalidad  FROM usuarios_servicios LEFT JOIN servicios on servicios.Id = Id_Servicios LEFT JOIN servicios_estados on servicios_estados.Id = Id_Servicios_Estados  left join servicios_tipos on servicios.id_servicios_tipos=servicios_tipos.id left join usuarios_locaciones on usuarios_servicios.id_usuarios_locaciones=usuarios_locaciones.id left join zonas_localidades on usuarios_locaciones.id_localidades=zonas_localidades.id_localidad WHERE usuarios_servicios.Id_Usuarios ={0} and usuarios_servicios.Id_Usuarios_Locaciones ={1} and usuarios_servicios.borrado=0", idUsuarios, idLocacion));
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

        public DataTable Listar_activos(int id)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando(string.Format("select usuarios_servicios.id, usuarios_servicios.id_servicios_tipo as Id_servicio_tipo ,(select descripcion from servicios where servicios.id=usuarios_servicios.id_servicios) as servicio, (select nombre from servicios_tipos where id=usuarios_servicios.id_servicios_tipo) as tiposervicio, (select estado from servicios_estados where servicios_estados.id=usuarios_servicios.id_servicios_estados) as estado, localidades.nombre as localidad, (select calle from usuarios_locaciones where id=id_usuarios_locaciones) as calle, (select altura from usuarios_locaciones where id=id_usuarios_locaciones) as altura, id_servicios,usuarios_servicios.id_usuarios, id_usuarios_locaciones from usuarios_servicios left join usuarios_locaciones on usuarios_servicios.id_usuarios_locaciones=usuarios_locaciones.id left join localidades on usuarios_locaciones.id_localidades=localidades.id where usuarios_servicios.id_usuarios={0} and (id_servicios_estados={1} or id_servicios_estados={2} or id_servicios_estados={3} or id_servicios_estados={4} or id_servicios_estados={5}) and usuarios_servicios.borrado=0", id, Convert.ToInt32(Servicios.Servicios_Estados.SIN_CONECTAR), Convert.ToInt32(Servicios.Servicios_Estados.CONECTADO), Convert.ToInt32(Servicios.Servicios_Estados.RETIRADO), Convert.ToInt32(Servicios.Servicios_Estados.CORTADO), Convert.ToInt32(Servicios.Servicios_Estados.EN_ESPERA)));
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

      
        public DataTable ListarServiciosSub(int idUsuariosServicios, bool traerInactivos = false)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                string condicionInactivos = ")";
                if (traerInactivos)
                    condicionInactivos = $" or usuarios_servicios_sub.borrado=2 )";

                string comando = "SELECT usuarios_servicios_sub.id, id_servicios_sub, " +
                    " (SELECT servicios_sub.descripcion FROM servicios_sub WHERE servicios_sub.id = id_servicios_sub) AS descripcion," +
                    " 0 AS nuevo, Id_Servicios_Velocidades_Tip, Id_Servicios_Velocidades,servicios_sub.Requiere_IP, " +
                    " servicios_sub_tipos.nombre as tiposubservicio,servicios_sub.id_servicios_sub_tipos,Id_Ip_fija, " +
                    " fecha_inicio,fecha_fin, usuarios_servicios_sub.borrado " +
                    " FROM usuarios_servicios_sub " +
                    " left join servicios_sub on usuarios_servicios_sub.id_servicios_sub=servicios_sub.id " +
                    " left join servicios_sub_tipos on servicios_sub.id_servicios_sub_tipos=servicios_sub_tipos.id" +
                    $" WHERE id_usuarios_servicios = {idUsuariosServicios} and (usuarios_servicios_sub.borrado=0 {condicionInactivos}";

                oCon.CrearComando(comando);
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

        public DataTable ListarServiciosUsuario(int idUsuarios, int idLocacion)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                //oCon.CrearComando(String.Format("SELECT Descripcion as Servicio, Estado, Id_Servicios_Tipos,id_servicios, servicios_tipos.nombre as ServicioTipo, usuarios_servicios.id,id_zonas,id_servicios_tipo,id_usuarios_locaciones,id_servicios_estados, id_servicios_categorias,zonas_localidades.id_zona FROM usuarios_servicios LEFT JOIN servicios on servicios.Id = Id_Servicios LEFT JOIN servicios_estados on servicios_estados.Id = Id_Servicios_Estados  left join servicios_tipos on servicios.id_servicios_tipos=servicios_tipos.id left join usuarios_locaciones on usuarios_servicios.id_usuarios_locaciones=usuarios_locaciones.id left join zonas_localidades on usuarios_locaciones.id_localidades=zonas_localidades.id_localidad WHERE usuarios_servicios.Id_Usuarios ={0} and usuarios_servicios.Id_Usuarios_Locaciones ={1}", idUsuarios, idLocacion));
                oCon.CrearComando(String.Format("SELECT * FROM usuarios_servicios_sub " +
                    "LEFT JOIN usuarios_servicios ON usuarios_servicios.id = usuarios_servicios_sub.id_usuarios_servicios " +
                    "LEFT JOIN servicios ON servicios.id = usuarios_servicios.id_servicios " +
                    "LEFT JOIN servicios_estados ON servicios_estados.id = usuarios_servicios.id_servicios_estados " +
                    "LEFT JOIN servicios_tipos ON servicios_tipos.id = servicios.id_servicios_tipos " +
                    "LEFT JOIN servicios_sub ON servicios_sub.id = usuarios_servicios_sub.id_servicios_sub " +
                    "LEFT JOIN servicios_sub_tipos ON servicios_sub_tipos.id = servicios_sub.id_servicios_sub_tipos " +
                    "LEFT JOIN servicios_velocidades ON servicios_velocidades.id = usuarios_servicios_sub.id_servicios_velocidades " +
                    "WHERE usuarios_servicios.Id_Usuarios = {0} and usuarios_servicios.Id_Usuarios_Locaciones = {1} and usuarios_servicios.borrado=0", idUsuarios, idLocacion));
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

        public DataTable ListarUsuariosServicios(int idUsuarios)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                //oCon.CrearComando(String.Format("SELECT Descripcion as Servicio, Estado, Id_Servicios_Tipos,id_servicios, servicios_tipos.nombre as ServicioTipo, usuarios_servicios.id,id_zonas,id_servicios_tipo,id_usuarios_locaciones,id_servicios_estados, id_servicios_categorias,zonas_localidades.id_zona FROM usuarios_servicios LEFT JOIN servicios on servicios.Id = Id_Servicios LEFT JOIN servicios_estados on servicios_estados.Id = Id_Servicios_Estados  left join servicios_tipos on servicios.id_servicios_tipos=servicios_tipos.id left join usuarios_locaciones on usuarios_servicios.id_usuarios_locaciones=usuarios_locaciones.id left join zonas_localidades on usuarios_locaciones.id_localidades=zonas_localidades.id_localidad WHERE usuarios_servicios.Id_Usuarios ={0} and usuarios_servicios.Id_Usuarios_Locaciones ={1}", idUsuarios, idLocacion));
                oCon.CrearComando(String.Format("SELECT * FROM usuarios_servicios_sub " +
                    "LEFT JOIN usuarios_servicios ON usuarios_servicios.id = usuarios_servicios_sub.id_usuarios_servicios " +
                    "LEFT JOIN servicios ON servicios.id = usuarios_servicios.id_servicios " +
                    "LEFT JOIN servicios_estados ON servicios_estados.id = usuarios_servicios.id_servicios_estados " +
                    "LEFT JOIN servicios_tipos ON servicios_tipos.id = servicios.id_servicios_tipos " +
                    "LEFT JOIN servicios_sub ON servicios_sub.id = usuarios_servicios_sub.id_servicios_sub " +
                    "LEFT JOIN servicios_sub_tipos ON servicios_sub_tipos.id = servicios_sub.id_servicios_sub_tipos " +
                    "LEFT JOIN servicios_velocidades ON servicios_velocidades.id = usuarios_servicios_sub.id_servicios_velocidades " +
                    "WHERE usuarios_servicios.Id_Usuarios = {0} and usuarios_servicios.borrado=0 and usuarios_servicios_sub.borrado=0", idUsuarios));
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
        public DataTable ListarServiciosBaja(DateTime fechaDesde)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("select usuarios_servicios.id, usuarios_servicios.id_tipo_facturacion, usuarios_servicios.id_usuarios,"
                + " usuarios_servicios.id_servicios, servicios_tipos.id as id_servicios_tipo, servicios_grupos.id as id_servicios_grupo, "
                + " usuarios_locaciones.id as id_usuarios_locaciones, usuarios_servicios.id_zonas, usuarios_servicios.id_servicios_categorias,"
                + " servicios.corteautomatico, servicios.descripcion as servicio,servicios.requiere_equipo, servicios.requiere_tarjeta, "
                + " servicios.requiere_velocidad, servicios_tipos.nombre as tipo_servicio,servicios_estados.Estado as estado, "
                + " usuarios_locaciones.calle,usuarios_locaciones.altura, localidades.nombre as localidad, "
                + " concat(usuarios.apellido,', ',usuarios.nombre) as nombre_usuario, usuarios_servicios.fecha_estado as desde,"
                + " configuracion.valor_n, if(configuracion.valor_n=1,zonas.nombre,servicios_categorias.nombre) as tipofac "
                + " from usuarios_servicios "
                + " left join servicios on usuarios_servicios.id_servicios = servicios.id "
                + " left join usuarios on usuarios.id=usuarios_servicios.id_usuarios "
                + " left join servicios_tipos on servicios.id_servicios_tipos = servicios_tipos.id "
                + " left join servicios_grupos on servicios_tipos.id_servicios_grupos = servicios_grupos.id "
                + " left join usuarios_locaciones on usuarios_servicios.id_usuarios_locaciones = usuarios_locaciones.id "
                + " left join localidades on usuarios_locaciones.id_localidades = localidades.id "
                + " left join configuracion on configuracion.variable='id_tipo_facturacion' "
                + " left join zonas on zonas.id=usuarios_servicios.id_tipo_facturacion "
                + " left join servicios_categorias on servicios_categorias.id=usuarios_servicios.id_tipo_facturacion "
                + " left join servicios_estados on servicios_estados.id=usuarios_servicios.Id_Servicios_Estados "
                + " where usuarios_servicios.id_servicios_estados = @estadoServicio and usuarios_servicios.borrado = 0 "
                + " and date (usuarios_servicios.fecha_estado)<=date(@fecha) AND usuarios_servicios.Id NOT IN "
                + " ("
                + " SELECT partes_usuarios_servicios.Id_usuarios_servicios FROM partes_usuarios_servicios"
                + " LEFT JOIN partes ON partes.Id=partes_usuarios_servicios.id_parte"
                + " LEFT JOIN partes_fallas ON partes_fallas.Id=partes_usuarios_servicios.id_parte_falla"
                + " WHERE partes_fallas.Id_Partes_Operaciones=@operacion AND partes.Id_Partes_Estados<>@estadoParte AND partes.borrado=0"
                + " )");
                oCon.AsignarParametroEntero("@estadoServicio", (int)Servicios.Servicios_Estados.CORTADO);
                oCon.AsignarParametroFecha("@fecha", fechaDesde);
                oCon.AsignarParametroEntero("@operacion", (int)Partes.Partes_Operaciones.BAJA);
                oCon.AsignarParametroEntero("@estadoParte", (int)Partes.Partes_Estados.REALIZADO);
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

        public DataTable ListarServiciosYSubServiciosActivos(int idUsuario)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                string comando = String.Format("CALL spServiciosActivos({0})", idUsuario);

                oCon.CrearComando(comando);
                dt = oCon.Tabla();

                Servicios_Velocidades oVel = new Servicios_Velocidades();
                foreach (DataRow item in dt.Rows)
                {
                    int idVelocidad = Convert.ToInt32(item["id_velocidad"]);
                    if (idVelocidad > 0)
                    {
                        DataTable dtvel = oVel.ListarDatosVelocidades(idVelocidad, Convert.ToInt32(item["id_velocidad_tipo"]));
                        item["servicio"] = item["servicio"] + " " + dtvel.Rows[0]["velocidad"].ToString() + " MB " + dtvel.Rows[0]["nombre"].ToString();
                        item["servicio_sub"] = item["servicio_sub"] + " " + dtvel.Rows[0]["velocidad"].ToString() + " MB " + dtvel.Rows[0]["nombre"].ToString();
                    }
                    if (Convert.ToInt32(item["id_ip_fija"]) > 0)
                    {
                        item["servicio"] = item["servicio"] + " CON IP FIJA ";
                        item["servicio_sub"] = item["servicio_sub"] + " CON IP FIJA ";
                    }
                }

                oCon.DesConectar();
            }
            catch { }

            return dt;
        }

        public DataTable ListarServiciosYSubServiciosActivosCASS(int idUsuario)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                string comando = String.Format("SELECT usuarios.ID AS id_usuario, usuarios_servicios.id AS id_usuario_servicio,usuarios_servicios_sub.id AS id_usuario_servicio_sub, " +
                    "usuarios_servicios.Id_Usuarios_Locaciones AS id_locacion, usuarios_servicios.id_servicios AS id_servicio, usuarios_servicios.Id_Servicios_Estados AS id_estado, " +
                    "servicios_grupos.id AS id_servicios_grupos, usuarios_servicios.Id_Servicios_Tipo AS id_servicio_tipo, " +
                    "servicios.Id_Servicios_Modalidad AS id_servicio_modalidad, usuarios_servicios.Id_Tipo_Facturacion AS id_tipo_facturacion, " +
                    "usuarios_servicios_sub.id AS id_usuarios_servicios_Sub, usuarios_servicios_sub.Id_Servicios_Sub AS id_servicio_sub, " +
                    "servicios_sub.Id_Servicios_Sub_Tipos AS id_servicio_Sub_tipo, usuarios_servicios.Id_Zonas AS id_zona, usuarios_servicios.Id_Servicios_Categorias AS id_Servicio_categoria, " +
                    "usuarios_locaciones.Id_Localidades AS id_localidad, servicios_grupos.Nombre AS grupo, servicios_tipos.Nombre AS servicio_tipo, " +
                    "servicios.Descripcion AS servicio, servicios_sub.Descripcion AS servicio_sub, 'S' AS servicio_Sub_tipo, servicios_sub_tipos.Nombre AS tiposubservicio, " +
                    "usuarios_servicios.Fecha_Estado AS Fecha_Estado, usuarios_servicios_sub.fecha_inicio AS fecha_inicio, usuarios_servicios_sub.fecha_fin AS fecha_fin, " +
                    "usuarios_servicios.Fecha_Saldado AS fecha_saldado, usuarios_servicios.Fecha_Factura AS fecha_factura, " +
                    "servicios.Requiere_Equipo, servicios.Requiere_Tarjeta, servicios.Requiere_Velocidad, servicios_estados.Estado AS estado, " +
                    "servicios_modalidad.Nombre AS Modalidad " +
                    "FROM usuarios_servicios_sub " +
                    "INNER JOIN cass ON usuarios_servicios_sub.Id_Servicios_Sub = cass.Id_Servicios_Sub " +
                    "LEFT JOIN servicios_sub ON usuarios_servicios_sub.Id_Servicios_Sub = servicios_sub.id " +
                    "LEFT JOIN servicios_sub_tipos ON servicios_sub.Id_Servicios_Sub_Tipos = servicios_sub_tipos.id " +
                    "LEFT JOIN usuarios_servicios ON usuarios_servicios_sub.Id_Usuarios_Servicios = usuarios_servicios.id " +
                    "LEFT JOIN servicios_estados ON usuarios_servicios.Id_Servicios_Estados = servicios_estados.id " +
                    "LEFT JOIN servicios ON usuarios_servicios.Id_Servicios = servicios.id " +
                    "LEFT JOIN servicios_tipos ON usuarios_servicios.Id_Servicios_Tipo = servicios_tipos.id " +
                    "LEFT JOIN servicios_modalidad on servicios.Id_Servicios_Modalidad = servicios_modalidad.id " +
                    "LEFT JOIN servicios_grupos ON servicios_tipos.Id_Servicios_Grupos = servicios_grupos.id " +
                    "LEFT JOIN usuarios ON usuarios_servicios.Id_Usuarios = usuarios.id " +
                    "LEFT JOIN usuarios_locaciones ON usuarios_locaciones.Id_Usuarios = usuarios.id " +
                    "LEFT JOIN usuarios_servicios_equipos ON usuarios_servicios_equipos.id_usuario_servicio = usuarios_servicios.id " +
                    "LEFT JOIN equipos ON usuarios_servicios_equipos.id_equipo = equipos.id " +
                    "LEFT JOIN equipos_tarjetas ON equipos.id_tarjeta = equipos_tarjetas.id " +
                    "WHERE usuarios_servicios.Id_Usuarios = {0} AND servicios_grupos.id = 1 " +
                    "AND usuarios_servicios.borrado = 0 AND usuarios_servicios_sub.borrado = 0 AND servicios_sub.borrado = 0 AND servicios.borrado = 0 " +
                    "GROUP BY cass.Id_Servicios_Sub; ", idUsuario);

                oCon.CrearComando(comando);
                dt = oCon.Tabla();

            

                oCon.DesConectar();
            }
            catch { }

            return dt;
        }



        public DataTable ListarUsuariosGral(Int32 IdServiciosGrupos, Int32 IdServiciosTipos, Int32 IdServiciosEstados, Int32 IdZonas, Boolean Detallado)
        {
            DataTable Data = new DataTable();
            String Filtro = string.Empty;
            // Cuando se consulta con detalle trae registros diferentes
            try
            {
                if (IdServiciosGrupos > 0)
                    Filtro += String.Format(" AND servicios_tipos.id_servicios_grupos = {0}", IdServiciosGrupos);

                if (IdServiciosTipos > 0)
                    Filtro += String.Format(" AND servicios.id_servicios_tipos = {0}", IdServiciosTipos);

                if (IdServiciosEstados > 0)
                    Filtro += String.Format(" AND usuarios_servicios.id_servicios_estados = {0}", IdServiciosEstados);

                if (IdZonas > 0)
                    Filtro += String.Format(" AND usuarios_servicios.id_zonas = {0}", IdZonas);

                String Query = String.Empty;

                if (Detallado == true)
                {
                    Query = "SELECT usuarios.codigo, CONCAT_WS(',', usuarios.apellido, usuarios.nombre) AS abonado, usuarios_locaciones.calle, usuarios_locaciones.altura, usuarios_locaciones.piso,zonas.nombre as zona, localidades.nombre as localidad, servicios.descripcion as servicio,servicios_categorias.nombre as categoria, servicios_estados.estado as estado, date(usuarios_servicios.fecha_factura) as fecha_factura,servicios_Tipos.id_servicios_grupos " +
                        " FROM usuarios_servicios " +
                        " LEFT JOIN usuarios ON usuarios.id=usuarios_servicios.id_usuarios " +
                        " LEFT JOIN servicios ON servicios.id=usuarios_servicios.id_servicios " +
                        " LEFT JOIN servicios_estados ON servicios_estados.id=usuarios_servicios.id_servicios_Estados " +
                        " LEFT JOIN servicios_tipos ON servicios_tipos.id=servicios.id_servicios_tipos " +
                        " LEFT JOIN servicios_categorias ON servicios_categorias.id=usuarios_servicios.id_servicios_categorias " +
                        " LEFT JOIN usuarios_locaciones ON usuarios_locaciones.id=usuarios_servicios.id_usuarios_locaciones " +
                        " LEFT JOIN localidades ON localidades.id=usuarios_locaciones.id_localidades " +
                        " LEFT JOIN zonas ON zonas.id=usuarios_servicios.id_zonas " +
                        " where usuarios_servicios.id > 0 and usuarios_servicios.borrado = 0 " + Filtro;
                }
                else
                {
                    Query = "SELECT usuarios.codigo, CONCAT_WS(',', usuarios.apellido, usuarios.nombre) AS abonado,usuarios_servicios.id_servicios,servicios.id_Servicios_tipos FROM usuarios_servicios " +
                        " LEFT JOIN usuarios on usuarios.id=usuarios_servicios.id_usuarios " +
                        " LEFT JOIN servicios on servicios.id=usuarios_servicios.id_servicios " +
                        " LEFT JOIN servicios_tipos on servicios_tipos.id=servicios.id_servicios_tipos " +
                        " LEFT JOIN servicios_estados ON servicios_estados.id=usuarios_servicios.id_servicios_Estados " +
                        " LEFT JOIN servicios_categorias ON servicios_categorias.id=usuarios_servicios.id_servicios_categorias " +
                        " LEFT JOIN usuarios_locaciones ON usuarios_locaciones.id=usuarios_servicios.id_usuarios_locaciones " +
                        " LEFT JOIN localidades ON localidades.id=usuarios_locaciones.id_localidades " +
                        " LEFT JOIN localidades_calles ON localidades.id=usuarios_locaciones.id_localidades " +
                        "where usuarios_servicios.id > 0 and usuarios_servicios.borrado = 0 " + Filtro + " GROUP BY usuarios_servicios.id_usuarios";
                }

                oCon.Conectar();
                oCon.CrearComando(Query);
                Data = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                throw;
            }

            return Data;
        }

        public void ActualizarFechaFactura(Int32 Id_Usuarios_Servicios, DateTime Fecha_Factura)
        {
            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();
                oCon.CrearComando("UPDATE usuarios_servicios set fecha_factura = @fecha WHERE Id = @Id");
                oCon.AsignarParametroFecha("@fecha", Fecha_Factura);
                oCon.AsignarParametroEntero("@Id", Id_Usuarios_Servicios);

                oCon.EjecutarComando();


                oCon.CrearComando("UPDATE usuarios_servicios_sub set fecha_fin = @fecha WHERE id_usuarios_servicios = @id");
                oCon.AsignarParametroFecha("@fecha", Fecha_Factura);
                oCon.AsignarParametroEntero("@Id", Id_Usuarios_Servicios);

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

        public Int32 ActualizarZona(Int32 Id_Usuarios_Servicios, int zona)
        {
            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();
                oCon.CrearComando("UPDATE usuarios_servicios set id_tipo_facturacion = @zona WHERE Id = @Id");
                oCon.AsignarParametroEntero("@zona", zona);
                oCon.AsignarParametroEntero("@Id", Id_Usuarios_Servicios);
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                return -1;
                throw;
            }
            return 0;
        }

        public Int32 EliminarUsuarioServicio(int idUsuarioServicio)
        {
            Int32 retorno = 0;
            try
            {
                oCon.Conectar();
                oCon.CrearComando("UPDATE usuarios_servicios set borrado=1 WHERE id=@idususer");
                oCon.AsignarParametroEntero("@idususer", idUsuarioServicio);
                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();

                oCon.CrearComando("UPDATE usuarios_servicios_sub set borrado=1 where id_usuarios_Servicios=@idususervicio");
                oCon.AsignarParametroEntero("@idususervicio", idUsuarioServicio);
                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();

                oCon.DesConectar();
                retorno = 0;
            }
            catch (Exception)
            {
                retorno = -1;
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                throw;
            }
            return retorno;
        }

        public bool QuitarBonificacionesEspeciales(Int32 IdUsuariosServicios)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando(String.Format("UPDATE usuarios_servicios set id_bonificacion_esp = 0 where id = {0}", IdUsuariosServicios));
                oCon.EjecutarComando();
                oCon.CrearComando(String.Format("UPDATE usuarios_servicios_sub set id_bonificacion_esp = 0 where id_usuarios_servicios = {0}", IdUsuariosServicios));
                oCon.EjecutarComando();
                oCon.DesConectar();
            }
            catch (Exception)
            {

            }
            return false;
        }

        public int ActualizarBonificacionNormal(int idUsuariosServiciosSub, int idBonificacion, string nombreBonificacion, decimal porcentaje)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("UPDATE usuarios_servicios_sub SET id_bonificacion_aplicada=@idboni, porcentaje_bonificacion_aplicada=@porcentaje, nombre_bonificacion_aplicada=@nombre where id=@idsub");
                oCon.AsignarParametroEntero("@idboni", idBonificacion);
                oCon.AsignarParametroDecimal("@porcentaje", porcentaje);
                oCon.AsignarParametroCadena("@nombre", nombreBonificacion);
                oCon.AsignarParametroEntero("@idsub", idUsuariosServiciosSub);
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
                //throw;
            }
        }

        public DataTable RetornarFechasDelServicio(int idUsuariosServicios)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando(string.Format("select fecha_estado, fecha_inicio, fecha_fin, fecha_saldado, fecha_factura, fecha_factura_desde from usuarios_servicios where id={0}", idUsuariosServicios));
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

        public DataTable ListarServicioVel(Int32 id_zona, Int32 id_servicios, Int32 id_servicios_vel, Int32 id_servicios_vel_tip)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando(string.Format("select usuarios.codigo, usuarios.apellido, usuarios.nombre from usuarios_servicios_sub " +
                    "left join usuarios_servicios on usuarios_servicios.id = id_usuarios_servicios " +
                    "left join usuarios on usuarios.id = usuarios_servicios.id_usuarios " +
                    "where id_tipo_facturacion = {0} and id_servicios = {1} and id_servicios_velocidades = {2} and id_servicios_velocidades_tip = {3} " +
                    "group by usuarios.codigo, usuarios.apellido, usuarios.nombre", id_zona, id_servicios, id_servicios_vel, id_servicios_vel_tip));
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

        public bool ActualizarVelocidades(Int32 Id_Zona, Int32 Id_Servicios, Int32 Id_Servicios_Vel_Anterior, Int32 Id_Servicios_Vel_Nueva)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando(String.Format("UPDATE usuarios_servicios_sub SET id_servicios_velocidades = {0} WHERE id_servicios_velocidades = {1} and " +
                    "id_usuarios_servicios IN (select id from usuarios_servicios where id_tipo_facturacion = {2} and id_servicios = {3})", Id_Servicios_Vel_Nueva,
                    Id_Servicios_Vel_Anterior, Id_Zona, Id_Servicios));

                oCon.EjecutarComando();
                oCon.DesConectar();

                return true;
            }
            catch { return false; }
        }

        public void ActualizarFechaUltimoAviso(int id_usuario_servicio)
        {
            try
            {
                oCon.Conectar();

                oCon.CrearComando("UPDATE usuarios_servicios set Ultimo_aviso = @fechaActualizada where id = @idUsServicio");
                oCon.AsignarParametroFecha("@fechaActualizada", DateTime.Now.Date);
                oCon.AsignarParametroEntero("@idUsServicio", id_usuario_servicio);
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

        public void Actualizar_UsuariosServicios_Equipos(int id_equipo , int id_usuario, int id_usuario_servicio, int id_cass_usuario, int Estado_Tarjeta, int Condicion, int id_Tarjeta) 
        {
            try
            {
                oCon.Conectar();
                if(Condicion == 1)
                { 
                    if (id_usuario_servicio > 0) 
                    {
                        oCon.CrearComando("UPDATE Usuarios_Servicios_Equipos set id_equipo = @idEquipo, id_usuario = @idUsuario, id_usuario_locacion = @idUsuarioLocacion, Fecha = @Fecha WHERE id_usuario_servicio = @idUsuarioServicio");                   
                    }
                    else 
                    { 
                        oCon.CrearComando("INSERT INTO Usuarios_Servicios_Equipos(id_Equipo, id_usuario, id_usuario_servicio, id_usuario_locacion, Fecha) " +
                        "VALUES(@idEquipo,@idUsuario,@idUsuarioServicio,@idUsuarioLocacion,@Fecha);");
                    }
                    oCon.AsignarParametroEntero("@idEquipo", id_equipo);
                    oCon.AsignarParametroEntero("@idUsuario", id_usuario);
                    oCon.AsignarParametroEntero("@idUsuarioServicio", id_usuario_servicio);
                    oCon.AsignarParametroEntero("@idUsuarioLocacion", 0);
                    oCon.AsignarParametroFecha("@Fecha", DateTime.Now);
                    oCon.EjecutarComando();
                    oCon.ComenzarTransaccion();
                    oCon.ConfirmarTransaccion();
                }

                oCon.CrearComando("UPDATE cass_usuarios set realizado = @Estado WHERE id = @id_cass_usuario");
                oCon.AsignarParametroEntero("@Estado", Estado_Tarjeta);             
                oCon.AsignarParametroEntero("@id_cass_usuario", id_cass_usuario);
                oCon.EjecutarComando();
                oCon.ComenzarTransaccion();
                oCon.ConfirmarTransaccion();

                if(id_equipo> 0 && id_Tarjeta > 0)
                { 
                    oCon.CrearComando("UPDATE equipos set id_tarjeta = @id_tarj, id_usuarios = @id_Usuario, id_usuarios_servicios = @id_usu_serv, id_equipos_estados = @equipo_estado WHERE id = @id_Equipo");
                    oCon.AsignarParametroEntero("@id_Usuario", id_usuario);
                    oCon.AsignarParametroEntero("@id_Equipo", id_equipo);
                    oCon.AsignarParametroEntero("@id_usu_serv", id_usuario_servicio);
                    oCon.AsignarParametroEntero("@id_tarj", id_Tarjeta);
                    oCon.AsignarParametroEntero("@equipo_estado", (int)Equipos.Equipos_Estados.ASIGNADO_A_USUARIO);
                    oCon.EjecutarComando();
                    oCon.ComenzarTransaccion();
                    oCon.ConfirmarTransaccion();
                }

                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                throw;
            }

        }

        public bool ActualizarFechaFacturaPorDet(int id)
        {
            try
            {
                DateTime fechaFactura = new DateTime();
                DataTable dtRsultado;
                oCon.Conectar();
                oCon.CrearComando("select max(fecha_hasta) as fecha from usuarios_ctacte_det where usuarios_ctacte_det.id_usuarios_servicios=@id and usuarios_ctacte_det.borrado=0 group by usuarios_ctacte_det.id_usuarios_servicios");
                oCon.AsignarParametroEntero("@id", id);
                dtRsultado = oCon.Tabla();
                if (dtRsultado.Rows.Count > 0)
                {
                    fechaFactura = Convert.ToDateTime(dtRsultado.Rows[0]["fecha"]);
                     oCon.CrearComando("update usuarios_servicios" +
                        " set usuarios_servicios.fecha_factura =@fecha " +
                        " where usuarios_servicios.id = @usu_ser" );
                    oCon.AsignarParametroFecha("@fecha", fechaFactura);
                    oCon.AsignarParametroEntero("@usu_ser", id);
                    oCon.ComenzarTransaccion();
                    oCon.EjecutarComando();
                    oCon.ConfirmarTransaccion();       
                    
                    DataTable dtSubServicios;
                    DataView dv = Usuarios.Current_dtServicios.DefaultView;
                    dv.RowFilter = $"id_usuario_servicio ={id} and id_usuarios_servicios_sub>0";
                    dtSubServicios = dv.ToTable();
                    foreach (DataRow item in dtSubServicios.Rows)
                    {
                        oCon.CrearComando("update usuarios_servicios_sub " +
                            "set usuarios_servicios_sub.fecha_fin = @fecha " +
                            "where usuarios_servicios_sub.id = @usu_ser_sub");
                        oCon.AsignarParametroFecha("@fecha", fechaFactura);
                        oCon.AsignarParametroEntero("@usu_ser_sub", Convert.ToInt32(item["id_usuario_servicio_sub"]));
                        oCon.ComenzarTransaccion();
                        oCon.EjecutarComando();
                        oCon.ConfirmarTransaccion();

                    }

                }
               

                oCon.DesConectar();
                return true;
            }
            catch (Exception c)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                return false;
                throw;
            }
        }
        public DataTable ListarUsuariosServiciosSubInactivos(int idUsuarioServicio)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando(String.Format("SELECT * " +
                    " FROM usuarios_servicios_sub " +
                    " LEFT JOIN usuarios_servicios ON usuarios_servicios.id = usuarios_servicios_sub.id_usuarios_servicios " +
                    " LEFT JOIN servicios ON servicios.id = usuarios_servicios.id_servicios " +
                    " LEFT JOIN servicios_estados ON servicios_estados.id = usuarios_servicios.id_servicios_estados " +
                    " LEFT JOIN servicios_tipos ON servicios_tipos.id = servicios.id_servicios_tipos " +
                    " LEFT JOIN servicios_sub ON servicios_sub.id = usuarios_servicios_sub.id_servicios_sub " +
                    " LEFT JOIN servicios_sub_tipos ON servicios_sub_tipos.id = servicios_sub.id_servicios_sub_tipos " +
                    " LEFT JOIN servicios_velocidades ON servicios_velocidades.id = usuarios_servicios_sub.id_servicios_velocidades " +
                    " WHERE usuarios_servicios.Id = {0} and usuarios_servicios.borrado=0 and usuarios_servicios_sub.borrado=2", idUsuarioServicio));
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


        public DataTable getUsuServData(int id)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT usuarios_servicios.id AS id_usuarios_servicios, servicios.id AS idServicio, " +
                    "servicios.Id_Aplicaciones_Externas AS id_app_ext, servicios.descripcion AS Servicio, " +
                    "servicios.borrado AS borradoServ, usuarios_servicios.borrado AS borradoUsuServ,usuarios.id as idUsuario,usuarios_servicios.fecha_inicio as fecha_conexion,usuarios_servicios.fecha_fin,usuarios_servicios.fecha_factura_desde as fecha_inicio " +
                    "FROM usuarios_servicios " +
                    "LEFT JOIN servicios ON usuarios_servicios.Id_Servicios = servicios.id " +
                    "LEFT JOIN usuarios ON usuarios_servicios.Id_Usuarios = usuarios.id " +
                    $"WHERE usuarios_servicios.borrado = 0 AND usuarios_servicios.Id = {id} ; ");
                dt = oCon.Tabla();
                oCon.DesConectar();
                return dt;
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }
        }

        public DataTable getFullDataUserServ(int idUsuario)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando(String.Format("SELECT usuarios_servicios.Id_Servicios AS id_serv,usuarios_servicios_sub.Id_Servicios_Sub AS id_servSub, usuarios_servicios.id AS id_usu_serv, " +
                    "usuarios_servicios_sub.Id AS id_usu_servsub, usuarios.id AS id_usuario,  ifnull(equipos.Id,0) AS id_equipo , usuarios_servicios.Id_Usuarios_Locaciones, " +
                    " usuarios.Codigo AS codUsu, usuarios.nombre AS nombreUsu,usuarios.Apellido AS apellidoUsu ,servicios.Descripcion AS Servicio, servicios_sub.Descripcion AS SubServicio, " +
                    "servicios.Id_Aplicaciones_Externas AS idAppExt, ifnull(servicios_velocidades.Id,0) AS id_velocidad, ifnull(servicios_velocidades.Velocidad,0) AS velocidad, " +
                    " ifnull(servicios_velocidades_tip.Id,0) AS idTipoVelocidad, ifnull(servicios_velocidades_tip.Nombre,0) AS TipoVelocidad, ifnull(equipos.Serie,0) AS Serie, ifnull(equipos.Mac,0) AS Mac, " +
                    " ifnull(equipos.Equipo_Usuario,0) as equipo_usuario,ifnull(equipos.Equipo_Clave,0) as equipo_clave,ifnull(equipos.Equipo_IP,0) as equipo_ip, ifnull(equipos_marcas.nombre,0) as Marca, ifnull(equipos_modelos.nombre,0) as Modelo " +
                    "FROM usuarios_servicios_sub " +
                    "LEFT JOIN usuarios_servicios ON usuarios_servicios_sub.Id_Usuarios_Servicios = usuarios_servicios.id " +
                    "LEFT JOIN usuarios_servicios_equipos ON usuarios_servicios_equipos.id_usuario_servicio = usuarios_servicios.id " +
                    "LEFT JOIN equipos ON usuarios_servicios_equipos.id_equipo = equipos.id " +
                    "LEFT JOIN equipos_tipos ON equipos.Id_Equipos_Tipos = equipos_tipos.id " +
                    "LEFT JOIN equipos_marcas ON equipos.Id_Equipos_Marcas = equipos_marcas.id "+
                    "LEFT JOIN equipos_modelos ON equipos.Id_Equipos_Modelos = equipos_modelos.id "+
                    "LEFT JOIN usuarios ON usuarios_servicios.Id_Usuarios = usuarios.id " +
                    "LEFT JOIN servicios ON usuarios_servicios.Id_Servicios = servicios.id " +
                    "LEFT JOIN servicios_sub ON usuarios_servicios_sub.Id_Servicios_Sub = servicios_sub.id " +
                    "LEFT JOIN servicios_velocidades ON usuarios_servicios_sub.Id_Servicios_Velocidades = servicios_velocidades.Id " +
                    "LEFT JOIN servicios_velocidades_tip ON usuarios_servicios_sub.Id_Servicios_Velocidades_Tip = servicios_velocidades_tip.id " +
                    "WHERE usuarios_servicios.Id_Usuarios = {0} " +
                    "GROUP BY usuarios_servicios.Id_Servicios,usuarios_servicios_sub.id; ", idUsuario));
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


        public DataRow getInfoUsuServicio(int id_usuario_servicio)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando($"SELECT id_servicios_estados,fecha_factura_desde as Fecha_desde,fecha_factura as Fecha_hasta from usuarios_Servicios where id = {id_usuario_servicio}");
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }

            return dt.Rows[0];
        }
    }
}
