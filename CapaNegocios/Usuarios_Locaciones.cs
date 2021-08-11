using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Usuarios_Locaciones
    {
        #region [PROPIEDADES]
        public Int32 Id { get; set; }
        public Int32 Id_Usuarios { get; set; }
        public Int32 Id_Localidades { get; set; }
        public Int32 Id_Provincias { get; set; }
        public Int32 Id_Calle { get; set; }
        public String Calle { get; set; }
        public Int32 Altura { get; set; }
        public String Piso { get; set; }
        public String Depto { get; set; }
        public String Codigo_Postal { get; set; }
        public String Manzana { get; set; }
        public int id_manzana { get; set; }
        public String Parcela { get; set; }
        public Int32 Id_Calle_Entre_1 { get; set; }
        public String Entre_Calle_1 { get; set; }
        public Int32 Id_Calle_Entre_2 { get; set; }
        public String Entre_Calle_2 { get; set; }
        public String Observacion { get; set; }
        public Int32 Activo { get; set; }
        public String Tipo { get; set; }
        public Int32 Prefijo_1 { get; set; }
        public Int32 Telefono_1 { get; set; }
        public Int32 Prefijo_2 { get; set; }
        public Int32 Telefono_2 { get; set; }
        public string Usuario { get; set; }
        public string Localidad { get; set; }
        public Int32 Altura_desde { get; set; }
        public Int32 Altura_hasta { get; set; }
        public Int32 Borrado { get; set; }
        public Int32 Id_Locacion_Fiscal_Asociada { get; set; }
        private Usuarios_Servicios oUsuario_servicio = new Usuarios_Servicios();
        private Conexion oCon = new Conexion();
        private static Conexion oConStatic = new Conexion();

        public enum Locacion_Estados
        {
            ACTIVA = 0,
            DESACTIVADA = 1,
            PENDIENTE_DE_ACTIVACION = 2
        }

        public enum CONTEMPLAR_NOMBRE_LIMITES_CALLES
        {
            NO = 0,
            SI = 1
        }


        #endregion

        public Int32 Guardar(Int32 idUsuario, Usuarios_Locaciones oUsuario_Locacion)
        {

            oCon.Conectar();
            if (oUsuario_Locacion.Id == 0)
            {
                oCon.CrearComando("INSERT INTO usuarios_locaciones(Id_Usuarios, Id_Localidades, Id_Calle, Calle, Altura, Piso, Depto, " +
                     "Codigo_Postal, id_manzana, Manzana, Parcela, Id_Calle_Entre_1, Entre_Calle_1, Id_Calle_Entre_2, Entre_Calle_2, Observacion, Activo, Tipo, Prefijo_1, Telefono_1, Prefijo_2, Telefono_2) " +
                     "VALUES(@usuario, @loc, @calleid, @calle, @altura, @piso, @depto, @cp,@id_manzana, @manzana, @parcela, @calleidentre1, @entre1, @calleidentre2, @entre2, @obs, @activo, @tipo, @pre1, @tel1, @pre2, @tel2); SELECT @@IDENTITY");

                oCon.AsignarParametroEntero("@usuario", idUsuario);
                oCon.AsignarParametroEntero("@loc", oUsuario_Locacion.Id_Localidades);
                oCon.AsignarParametroEntero("@calleid", oUsuario_Locacion.Id_Calle);
                oCon.AsignarParametroCadena("@calle", oUsuario_Locacion.Calle);
                oCon.AsignarParametroEntero("@altura", oUsuario_Locacion.Altura);
                oCon.AsignarParametroCadena("@piso", oUsuario_Locacion.Piso);
                oCon.AsignarParametroCadena("@depto", oUsuario_Locacion.Depto);
                oCon.AsignarParametroCadena("@cp", oUsuario_Locacion.Codigo_Postal);
                oCon.AsignarParametroEntero("@id_manzana", oUsuario_Locacion.id_manzana);

                oCon.AsignarParametroCadena("@manzana", oUsuario_Locacion.Manzana);
                oCon.AsignarParametroCadena("@parcela", oUsuario_Locacion.Parcela);
                oCon.AsignarParametroEntero("@calleidentre1", oUsuario_Locacion.Id_Calle_Entre_1);
                oCon.AsignarParametroCadena("@entre1", oUsuario_Locacion.Entre_Calle_1);
                oCon.AsignarParametroEntero("@calleidentre2", oUsuario_Locacion.Id_Calle_Entre_1);
                oCon.AsignarParametroCadena("@entre2", oUsuario_Locacion.Entre_Calle_2);
                oCon.AsignarParametroCadena("@obs", oUsuario_Locacion.Observacion);
                oCon.AsignarParametroEntero("@activo", oUsuario_Locacion.Activo);
                oCon.AsignarParametroCadena("@tipo", oUsuario_Locacion.Tipo);
                oCon.AsignarParametroEntero("@pre1", oUsuario_Locacion.Prefijo_1);
                oCon.AsignarParametroEntero("@tel1", oUsuario_Locacion.Telefono_1);
                oCon.AsignarParametroEntero("@pre2", oUsuario_Locacion.Prefijo_2);
                oCon.AsignarParametroEntero("@tel2", oUsuario_Locacion.Telefono_2);
            }
            else
            {
                oCon.CrearComando("update usuarios_locaciones set Codigo_Postal=@cp, Id_Calle_Entre_1=@calleidentre1, Entre_Calle_1=@entre1, Id_Calle_Entre_2=@calleidentre2, Entre_Calle_2=@entre2, Observacion=@obs, Tipo=@tipo, Prefijo_1=@pre1, Telefono_1=@tel1, Prefijo_2=@pre2, Telefono_2=@tel2, id_localidades=@idLocalidades, altura=@altura, piso=@piso, depto=@depto, observacion=@obs where Id=@locacion;");
                oCon.AsignarParametroCadena("@cp", oUsuario_Locacion.Codigo_Postal);

                oCon.AsignarParametroEntero("@calleidentre1", oUsuario_Locacion.Id_Calle_Entre_1);
                oCon.AsignarParametroCadena("@entre1", oUsuario_Locacion.Entre_Calle_1);
                oCon.AsignarParametroEntero("@calleidentre2", oUsuario_Locacion.Id_Calle_Entre_1);
                oCon.AsignarParametroCadena("@entre2", oUsuario_Locacion.Entre_Calle_2);
                oCon.AsignarParametroCadena("@obs", oUsuario_Locacion.Observacion);
                oCon.AsignarParametroCadena("@tipo", oUsuario_Locacion.Tipo);
                oCon.AsignarParametroEntero("@pre1", oUsuario_Locacion.Prefijo_1);
                oCon.AsignarParametroEntero("@tel1", oUsuario_Locacion.Telefono_1);
                oCon.AsignarParametroEntero("@pre2", oUsuario_Locacion.Prefijo_2);
                oCon.AsignarParametroEntero("@tel2", oUsuario_Locacion.Telefono_2);
                oCon.AsignarParametroEntero("@idLocalidades", oUsuario_Locacion.Id_Localidades);
                oCon.AsignarParametroEntero("@altura", oUsuario_Locacion.Altura);
                oCon.AsignarParametroCadena("@piso", oUsuario_Locacion.Piso);
                oCon.AsignarParametroCadena("@depto", oUsuario_Locacion.Depto);
                oCon.AsignarParametroCadena("@obs", oUsuario_Locacion.Observacion);
                oCon.AsignarParametroEntero("@locacion", oUsuario_Locacion.Id);
            }

            if (oUsuario_Locacion.Id == 0)
                oUsuario_Locacion.Id = oCon.EjecutarScalar();
            else
                oCon.EjecutarComando();

            oCon.ConfirmarTransaccion();
            oCon.DesConectar();


            return oUsuario_Locacion.Id;

        }

        public static void ActualizarSaldo(Int32 IdLocacion)
        {
            try
            {
                oConStatic.Conectar();
                oConStatic.CrearComando("call SaldoCC(@idu)");
                oConStatic.AsignarParametroEntero("@idu", IdLocacion);
                oConStatic.EjecutarComando();
                oConStatic.DesConectar();
            }
            catch { };
        }

        public DataTable ListarLocacionesServicio(Int32 idUsuario, int idLocacion = 0, bool calcularSaldo = false)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                if (idLocacion == 0)
                {

                    oCon.CrearComando("SELECT usuarios_locaciones.*, localidades.Nombre as localidad,"
                    + " CONCAT_WS(' ',trim(usuarios_locaciones.calle), ' NRO: ', cast(usuarios_locaciones.altura as char(50)), ' PISO: ',  ifnull(usuarios_locaciones.Piso,0), 'DEPTO: ', ifnull(usuarios_locaciones.Depto,0)) AS Locacion, usuarios_locaciones.id, 0 as Genera_Factura,"
                    + " localidades_calles.altura_desde, localidades_calles.altura_hasta,usuarios_locaciones.activo"
                    + " FROM usuarios_locaciones"
                    + " LEFT JOIN localidades_calles ON localidades_calles.Id = usuarios_locaciones.Id_Calle"
                    + " LEFT JOIN localidades ON localidades.Id = usuarios_locaciones.Id_Localidades"
                    + " WHERE usuarios_locaciones.Id_Usuarios = @id order by usuarios_locaciones.activo asc ");
                    oCon.AsignarParametroEntero("@id", idUsuario);


                }
                else
                {

                    oCon.CrearComando("SELECT usuarios_locaciones.*, localidades.Nombre as localidad,"
                    + " CONCAT_WS(' ',trim(usuarios_locaciones.calle), ' NRO: ', cast(usuarios_locaciones.altura as char(50)), ' PISO: ', usuarios_locaciones.Piso, 'DEPTO: ', usuarios_locaciones.Depto) AS Locacion, usuarios_locaciones.id, 0 as Genera_Factura,"
                    + " localidades_calles.altura_desde, localidades_calles.altura_hasta,usuarios_locaciones.activo"
                    + " FROM usuarios_locaciones"
                    + " LEFT JOIN localidades_calles ON localidades_calles.Id = usuarios_locaciones.Id_Calle"
                    + " LEFT JOIN localidades ON localidades.Id = usuarios_locaciones.Id_Localidades"
                    + " WHERE usuarios_locaciones.Id = @id order by usuarios_locaciones.activo asc");
                    oCon.AsignarParametroEntero("@id", idLocacion);
                }

                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch
            {
                oCon.DesConectar();
            }
            if (calcularSaldo)
            {
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)
                        ActualizarSaldo(Convert.ToInt32(item["id"]));
                    dt = ListarLocacionesServicio(idUsuario, idLocacion, false);
                }
            }
            return dt;
        }

        public Usuarios_Locaciones GetLocacion(Int32 Id)
        {
            DataTable dt = new DataTable();
            Usuarios_Locaciones oUsuLoc = new Usuarios_Locaciones();
            try
            {
                oCon.Conectar();
                oCon.CrearComando(String.Format("select usuarios_locaciones.*,(select concat(usuarios.Apellido,' ',usuarios.Nombre) from usuarios where usuarios.id=usuarios_locaciones.Id_Usuarios) as usuario, (select localidades_calles.Altura_Desde from localidades_calles where localidades_calles.Id=usuarios_locaciones.Id_Calle) as Altura_Desde, (select localidades_calles.Altura_Hasta from localidades_calles where localidades_calles.Id=usuarios_locaciones.Id_Calle) as Altura_Hasta, (select nombre from localidades where id=id_localidades) as localidad from usuarios_locaciones where usuarios_locaciones.Id=@id", Id));
                oCon.AsignarParametroEntero("@id", Id);
                dt = oCon.Tabla();
                oCon.DesConectar();

                if (dt.Rows.Count > 0)
                {
                    oUsuLoc.Id = Convert.ToInt32(dt.Rows[0]["Id"]);
                    oUsuLoc.Id_Usuarios = Convert.ToInt32(dt.Rows[0]["Id_Usuarios"]);
                    oUsuLoc.Usuario = dt.Rows[0]["usuario"].ToString();
                    oUsuLoc.Localidad = dt.Rows[0]["localidad"].ToString();
                    oUsuLoc.Id_Localidades = Convert.ToInt32(dt.Rows[0]["Id_Localidades"]);
                    oUsuLoc.Id_Provincias = Convert.ToInt32(dt.Rows[0]["Id_Provincias"]);
                    oUsuLoc.Id_Calle = Convert.ToInt32(dt.Rows[0]["Id_Calle"]);
                    oUsuLoc.Calle = dt.Rows[0]["Calle"].ToString();
                    oUsuLoc.Altura = Convert.ToInt32(dt.Rows[0]["Altura"].ToString());
                    oUsuLoc.Piso = dt.Rows[0]["Piso"].ToString();
                    oUsuLoc.Depto = dt.Rows[0]["Depto"].ToString();
                    oUsuLoc.Codigo_Postal = dt.Rows[0]["Codigo_Postal"].ToString();
                    if (String.IsNullOrEmpty(dt.Rows[0]["id_manzana"].ToString()))
                        oUsuLoc.id_manzana = 0;
                    else
                        oUsuLoc.id_manzana = Convert.ToInt32(dt.Rows[0]["id_manzana"]);

                    oUsuLoc.Manzana = dt.Rows[0]["Manzana"].ToString();
                    oUsuLoc.Parcela = dt.Rows[0]["Parcela"].ToString();
                    oUsuLoc.Id_Calle_Entre_1 = Convert.ToInt32(dt.Rows[0]["Id_Calle_Entre_1"]);
                    oUsuLoc.Entre_Calle_1 = dt.Rows[0]["Entre_Calle_1"].ToString();
                    oUsuLoc.Id_Calle_Entre_2 = Convert.ToInt32(dt.Rows[0]["Id_Calle_Entre_2"]);
                    oUsuLoc.Entre_Calle_2 = dt.Rows[0]["Entre_Calle_2"].ToString();
                    oUsuLoc.Observacion = dt.Rows[0]["Observacion"].ToString();
                    oUsuLoc.Activo = Convert.ToInt32(dt.Rows[0]["Activo"]);
                    oUsuLoc.Tipo = dt.Rows[0]["Tipo"].ToString();
                    oUsuLoc.Prefijo_1 = Convert.ToInt32(dt.Rows[0]["Prefijo_1"]);
                    oUsuLoc.Telefono_1 = Convert.ToInt32(dt.Rows[0]["Telefono_1"].ToString());
                    oUsuLoc.Prefijo_2 = Convert.ToInt32(dt.Rows[0]["Prefijo_2"]);
                    oUsuLoc.Telefono_2 = Convert.ToInt32(dt.Rows[0]["Telefono_2"].ToString());
                    if (String.IsNullOrEmpty(dt.Rows[0]["Altura_Desde"].ToString()))
                        oUsuLoc.Altura_desde = 0;
                    else
                        oUsuLoc.Altura_desde = Convert.ToInt32(dt.Rows[0]["Altura_Desde"].ToString());

                    if (String.IsNullOrEmpty(dt.Rows[0]["Altura_Hasta"].ToString()))
                        oUsuLoc.Altura_hasta = 0;
                    else
                        oUsuLoc.Altura_hasta = Convert.ToInt32(dt.Rows[0]["Altura_Hasta"].ToString());
                    oUsuLoc.Id_Locacion_Fiscal_Asociada = Convert.ToInt32(dt.Rows[0]["id_locacion_fiscal_asociada"].ToString());
                }
                else
                {
                    oUsuLoc.Id = 0;
                    oUsuLoc.Activo = Convert.ToInt32(Locacion_Estados.DESACTIVADA);
                }
            }
            catch
            {
                oCon.DesConectar();
                throw;
            }

            return oUsuLoc;
        }

        public void modifica(Usuarios_Locaciones oUsuLoc)
        {
            try
            {
                oCon.Conectar();


                oCon.CrearComando("UPDATE usuarios_locaciones SET Prefijo_1 = @pre_1, Prefijo_2 = @pre_2,Telefono_1 = @tel_1, Telefono_2 = @tel_2 WHERE Id = @id");

                oCon.AsignarParametroEntero("@id", oUsuLoc.Id);
                oCon.AsignarParametroEntero("@pre_1", oUsuLoc.Prefijo_1);
                oCon.AsignarParametroEntero("@tel_1", oUsuLoc.Telefono_1);
                oCon.AsignarParametroEntero("@pre_2", oUsuLoc.Prefijo_2);
                oCon.AsignarParametroEntero("@tel_2", oUsuLoc.Telefono_2);

                oCon.EjecutarComando();

                oCon.ConfirmarTransaccion();

                oCon.DesConectar();
            }

            catch
            {
                oCon.DesConectar();
                throw;
            }
        }

        public int Verificar_Locacion(Usuarios_Locaciones oUsuLoc)
        {
            int control = 0;
            try
            {
                DataTable dt = new DataTable();

                oCon.Conectar();
                oCon.CrearComando("select * from usuarios_locaciones where Id_Localidades=@id_localidad and Id_Calle=@id_calle and Altura=@altura and Piso=@piso and Depto=@depto and id_manzana=@manzana and Activo!=1 and borrado=0");
                oCon.AsignarParametroEntero("@id_localidad", oUsuLoc.Id_Localidades);
                oCon.AsignarParametroEntero("@id_calle", oUsuLoc.Id_Calle);
                oCon.AsignarParametroEntero("@altura", oUsuLoc.Altura);
                oCon.AsignarParametroCadena("@piso", oUsuLoc.Piso);
                oCon.AsignarParametroCadena("@depto", oUsuLoc.Depto);
                oCon.AsignarParametroEntero("@manzana", oUsuLoc.id_manzana);


                dt = oCon.Tabla();

                if (dt.Rows.Count > 0)
                {
                    control = 1;
                }
                else
                {
                    control = 0;
                }

                oCon.DesConectar();
            }
            catch (Exception)
            {
                control = 3;
                throw;
            }
            return control;
        }

        public bool Realizar_Cambio_Domicilio(int id_parte, DataTable dtUsuariosServicios, int id_locacion_nueva, int id_locacion_anterior, int id_usuarios, int traspasa)
        {
            bool resultado = false;
            Usuarios_Servicios oUsuario_Servicio = new Usuarios_Servicios();

            try
            {
                DataTable dtUsuarioLocacionAnterior = ListarLocacionesServicio(0, id_locacion_anterior);
                string Prefijo1 = dtUsuarioLocacionAnterior.Rows[0]["Prefijo_1"].ToString();
                string Prefijo2 = dtUsuarioLocacionAnterior.Rows[0]["Prefijo_2"].ToString();
                string Telefono1 = dtUsuarioLocacionAnterior.Rows[0]["Telefono_1"].ToString();
                string Telefono2 = dtUsuarioLocacionAnterior.Rows[0]["Telefono_2"].ToString();

                DataTable dt = new DataTable();
                oCon.Conectar();

                oCon.CrearComando("select Activo from usuarios_locaciones where id=@id");//trae estado locacion nueva
                oCon.AsignarParametroEntero("@id", id_locacion_nueva);
                dt = oCon.Tabla();

                if (Convert.ToInt32(dt.Rows[0]["Activo"]) == Convert.ToInt32(Usuarios_Locaciones.Locacion_Estados.PENDIENTE_DE_ACTIVACION) || Convert.ToInt32(dt.Rows[0]["Activo"]) == Convert.ToInt32(Usuarios_Locaciones.Locacion_Estados.DESACTIVADA))
                {
                    oCon.CrearComando(string.Format("UPDATE usuarios_locaciones SET Activo=@activo, Prefijo_1={0}, Telefono_1={1}, Prefijo_2={2}, Telefono_2={3} WHERE Id = @id", Prefijo1, Telefono1, Prefijo2, Telefono2));
                    oCon.AsignarParametroEntero("@activo", Convert.ToInt32(Usuarios_Locaciones.Locacion_Estados.ACTIVA));
                    oCon.AsignarParametroEntero("@id", id_locacion_nueva);//activa locacion nueva
                    oCon.EjecutarComando();
                    oCon.ConfirmarTransaccion();
                }

                if (dtUsuariosServicios.Rows.Count > 0)
                {
                    foreach (DataRow fila in dtUsuariosServicios.Rows)
                    {
                        oUsuario_Servicio.ActualizarLocacion(id_locacion_anterior, id_locacion_nueva, Convert.ToInt32(fila["id_usuarios_servicios"]));
                    }
                }

                if (traspasa == (int)Partes.Traspaso.CUENTA_CORRIENTE || traspasa == (int)Partes.Traspaso.TODO)
                {
                    Configuracion oConfig = new Configuracion();
                    if(oConfig.GetValor_N("TrasladaImpago")==1)
                        oCon.CrearComando("UPDATE usuarios_ctacte_det set id_usuarios_locaciones=@idLocacionNueva where id_usuarios_locaciones=@idLocacionAntigua and importe_saldo<>0");
                    else
                        oCon.CrearComando("UPDATE usuarios_ctacte_det set id_usuarios_locaciones=@idLocacionNueva where id_usuarios_locaciones=@idLocacionAntigua");

                    oCon.AsignarParametroEntero("@idLocacionNueva", id_locacion_nueva);
                    oCon.AsignarParametroEntero("@idLocacionAntigua", id_locacion_anterior);
                    oCon.EjecutarComando();
                    oCon.ConfirmarTransaccion();

                    if (oConfig.GetValor_N("TrasladaImpago") == 1)
                        oCon.CrearComando("UPDATE usuarios_ctacte set id_usuarios_locacion=@idLocacionNueva where id_usuarios_locacion=@idLocacionAntigua and importe_saldo<>0");
                    else
                        oCon.CrearComando("UPDATE usuarios_ctacte set id_usuarios_locacion=@idLocacionNueva where id_usuarios_locacion=@idLocacionAntigua");

                    oCon.AsignarParametroEntero("@idLocacionNueva", id_locacion_nueva);
                    oCon.AsignarParametroEntero("@idLocacionAntigua", id_locacion_anterior);
                    oCon.EjecutarComando();
                    oCon.ConfirmarTransaccion();

                }

                if (traspasa == (int)Partes.Traspaso.PARTES || traspasa == (int)Partes.Traspaso.TODO)
                {

                    oCon.CrearComando("update partes set partes.id_usuarios_locaciones =@idLocacionNueva where partes.id_usuarios_locaciones=@idLocacionAntigua");
                    oCon.AsignarParametroEntero("@idLocacionNueva", id_locacion_nueva);
                    oCon.AsignarParametroEntero("@idLocacionAntigua", id_locacion_anterior);
                    oCon.EjecutarComando();
                    oCon.ConfirmarTransaccion();

                }

                DataTable dtServiciosViejaLoc = new DataTable();
                dtServiciosViejaLoc = oUsuario_servicio.ListarServiciosYSubServiciosActivos(id_usuarios);
                DataView dv = dtServiciosViejaLoc.DefaultView;
                dv.RowFilter = string.Format("id_locacion={0}", id_locacion_anterior);
                dtServiciosViejaLoc = dv.ToTable();
                if (dtServiciosViejaLoc.Rows.Count == 0)
                {
                    oCon.CrearComando("UPDATE usuarios_locaciones SET Activo=@activo, borrado=1 WHERE Id = @id");//desactiva locacion anterior si ya no le quedan servicios
                    oCon.AsignarParametroEntero("@activo", Convert.ToInt32(Usuarios_Locaciones.Locacion_Estados.DESACTIVADA));
                    oCon.AsignarParametroEntero("@id", id_locacion_anterior);
                    oCon.EjecutarComando();
                    oCon.ConfirmarTransaccion();
                }

                oCon.CrearComando("call SaldoCC(@idu)");
                oCon.AsignarParametroEntero("@idu", id_locacion_nueva);
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();

                oCon.CrearComando("call SaldoCC(@idu)");
                oCon.AsignarParametroEntero("@idu", id_locacion_anterior);
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();

                oCon.DesConectar();

                ActualizarSaldo(id_locacion_nueva);
                ActualizarSaldo(id_locacion_anterior);
                resultado = true;
            }
            catch
            {
                oCon.DesConectar();
                throw;
            }


            return resultado;
        }

        public DataTable VerificarExistenciaLocacion(int idLocalidad, int idCalle, int altura, string piso, string depto, string limiteCalle1, string limiteCalle2, CONTEMPLAR_NOMBRE_LIMITES_CALLES contemplarNombreCallesLimites)
        {
            int idLimiteCalle1, idLimiteCalle2;
            string consulta = String.Empty;
            DataTable dtLocacionesEncontradas = new DataTable();

            consulta = String.Format("select * from vw_usuarios_locaciones where id_localidades={0} and id_calle={1} and altura={2} and (activo={3} or activo={4})", idLocalidad, idCalle, altura, Convert.ToInt32(Locacion_Estados.ACTIVA), Convert.ToInt32(Locacion_Estados.PENDIENTE_DE_ACTIVACION));

            if (piso != String.Empty)
                consulta = String.Format("{0} and piso={1}", consulta, piso);

            if (depto != String.Empty)
                consulta = String.Format("{0} and depto={1}", consulta, depto);

            if (limiteCalle1 != String.Empty || String.IsNullOrEmpty(limiteCalle1) == false)
            {
                if (contemplarNombreCallesLimites == CONTEMPLAR_NOMBRE_LIMITES_CALLES.NO && int.TryParse(limiteCalle1, out idLimiteCalle1))
                    consulta = String.Format("{0} and id_calle_entre_1={1}", consulta, idLimiteCalle1);
                else
                    consulta = String.Format("{0} and entre_calle_1='{1}'", consulta, limiteCalle1);
            }

            if (limiteCalle2 != String.Empty || String.IsNullOrEmpty(limiteCalle2) == false)
            {
                if (contemplarNombreCallesLimites == CONTEMPLAR_NOMBRE_LIMITES_CALLES.NO && int.TryParse(limiteCalle2, out idLimiteCalle2))
                    consulta = String.Format("{0} and id_calle_entre_2={1}", consulta, idLimiteCalle2);
                else
                    consulta = String.Format("{0} and entre_calle_2='{1}'", consulta, limiteCalle2);
            }

            try
            {
                oCon.Conectar();
                oCon.CrearComando(consulta);
                dtLocacionesEncontradas = oCon.Tabla();
                oCon.DesConectar();
            }
            catch
            {
                oCon.DesConectar();
            }
            return dtLocacionesEncontradas;
        }

        public void ActualizarLocacionFiscal(int idLocacionServicio, int idLocacionFiscal)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("update usuarios_locaciones set id_locacion_fiscal_asociada=@idLocacionFiscal where id=@id");
                oCon.AsignarParametroEntero("@idLocacionFiscal", idLocacionFiscal);
                oCon.AsignarParametroEntero("@id", idLocacionServicio);
                oCon.EjecutarComando();

                oCon.DesConectar();
            }
            catch
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                throw;
            };
        }

        public DataTable ListarLocacionesDeServicio(Int32 idUsuario)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando(String.Format("select * FROM vw_usuarios_locaciones WHERE vw_usuarios_locaciones.Id_Usuarios = {0} AND Activo = 0", idUsuario));
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch
            {
                oCon.DesConectar();
            }

            return dt;
        }

        public int RetornarEstadoLocacion(int idLocacion)
        {
            int estado = -1;
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando(String.Format("select * FROM vw_usuarios_locaciones WHERE vw_usuarios_locaciones.id = {0}", idLocacion));
                dt = oCon.Tabla();
                if (dt.Rows.Count > 0)
                    estado = Convert.ToInt32(dt.Rows[0]["activo"]);
                oCon.DesConectar();
            }
            catch
            {
                oCon.DesConectar();
            }

            return estado;
        }

        public DataTable ListarDatosLocacion(Int32 idLocacion)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT usuarios_locaciones.id_usuarios,usuarios_locaciones.id_localidades,usuarios_locaciones.id_provincias,usuarios_locaciones.id_Calle,localidades.nombre as localidad,usuarios_locaciones.altura,usuarios_locaciones.piso,usuarios_locaciones.depto,usuarios_locaciones.codigo_postal,usuarios_locaciones.id_manzana,usuarios_locaciones.manzana,usuarios_locaciones.parcela,usuarios_locaciones.id_calle_entre_1,usuarios_locaciones.id_Calle_entre_2,usuarios_locaciones.entre_calle_1,usuarios_locaciones.entre_Calle_2,usuarios_locaciones.observacion,usuarios_locaciones.activo,usuarios_locaciones.tipo,usuarios_locaciones.prefijo_1,telefono_1,usuarios_locaciones.prefijo_2,telefono_2,usuarios_locaciones.saldo,usuarios_locaciones.borrado,usuarios_locaciones.id_locacion_fiscal_asociada,usuarios_locaciones.id_usuarios_locaciones_original,localidades_calles.nombre as calle FROM usuarios_locaciones INNER JOIN localidades_calles on localidades_calles.id=usuarios_locaciones.id_Calle inner join localidades on localidades.id=usuarios_locaciones.id_localidades WHERE usuarios_locaciones.id=@idLoc");
                oCon.AsignarParametroEntero("@idLoc", idLocacion);
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
            }
            return dt;
        }

        public void ActualizarDatosLocacion(int idLocacion, int prefijo1, double tel1, int prefijo2, double tel2, string observacion, int altura, string piso, string depto)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("update usuarios_locaciones set prefijo_1=@prefijo1, telefono_1=@telefono1, prefijo_2=@prefijo2, telefono_2=@telefono2, observacion=@observacion,altura=@altura,piso=@piso,depto=@depto where id=@id");
                oCon.AsignarParametroEntero("@prefijo1", prefijo1);
                oCon.AsignarParametroDouble("@telefono1", tel1);
                oCon.AsignarParametroEntero("@prefijo2", prefijo2);
                oCon.AsignarParametroDouble("@telefono2", tel2);
                oCon.AsignarParametroCadena("@observacion", observacion);
                oCon.AsignarParametroEntero("@altura", altura);
                oCon.AsignarParametroCadena("@piso", piso);
                oCon.AsignarParametroCadena("@depto", depto);
                oCon.AsignarParametroEntero("@id", idLocacion);
                oCon.EjecutarComando();

                oCon.DesConectar();
            }
            catch
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                throw;
            };
        }

        public Int32 ActualizarDatosLocacion(Usuarios_Locaciones oUsuarioLocacion)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("UPDATE usuarios_locaciones SET id_localidades=@id_localidad,calle=@calle,id_calle=@id_calle,altura=@altura,piso=@piso,depto=@depto where id=@id");
                oCon.AsignarParametroEntero("@id_localidad", oUsuarioLocacion.Id_Localidades);
                oCon.AsignarParametroCadena("@calle", oUsuarioLocacion.Calle);
                oCon.AsignarParametroEntero("@id_calle", oUsuarioLocacion.Id_Calle);
                oCon.AsignarParametroEntero("@altura", oUsuarioLocacion.Altura);
                oCon.AsignarParametroCadena("@piso", oUsuarioLocacion.Piso);
                oCon.AsignarParametroCadena("@depto", oUsuarioLocacion.Depto);
                oCon.AsignarParametroEntero("@id", oUsuarioLocacion.Id);
                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                //return -1;
                throw;
            }
            return 0;
        }

        public void ActualizarTelefonosObservacion(int idLocacion, int prefijo1, double tel1, int prefijo2, double tel2, string observacion)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("update usuarios_locaciones set prefijo_1=@prefijo1, telefono_1=@telefono1, prefijo_2=@prefijo2, telefono_2=@telefono2, observacion=@observacion where id=@id");
                oCon.AsignarParametroEntero("@prefijo1", prefijo1);
                oCon.AsignarParametroDouble("@telefono1", tel1);
                oCon.AsignarParametroEntero("@prefijo2", prefijo2);
                oCon.AsignarParametroDouble("@telefono2", tel2);
                oCon.AsignarParametroCadena("@observacion", observacion);
                oCon.AsignarParametroEntero("@id", idLocacion);
                oCon.EjecutarComando();

                oCon.DesConectar();
            }
            catch
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                throw;
            };
        }

        public void ActualizarUltimoAviso(int idLocacion)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("update usuarios_locaciones set fecha_ultimo_aviso=@fecha where id=@idLocacion");
                oCon.AsignarParametroFecha("@fecha", DateTime.Now.Date);
                oCon.AsignarParametroEntero("@idLocacion", idLocacion);
                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
            }
        }

        public void ActualizarSaldoCtacte(decimal SaldoCtacte, int id_Locacion) 
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("update usuarios_locaciones set saldoctacte=@saldo where id=@id_loc");
                oCon.AsignarParametroDecimal("@saldo", SaldoCtacte);
                oCon.AsignarParametroEntero("@id_loc", id_Locacion);
                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
            }

        }
        public Boolean UnificarLocacion(DataTable dt_Servicio, DataTable dt_CtaCte, DataTable dtPartes, int id_LocacionNueva)
        {
            try
            {
                oCon.Conectar();

                if (dt_Servicio.Rows.Count > 0)
                {
                    foreach (DataRow drServ in dt_Servicio.Rows)
                    {
                        int id_UsuServ = 0;
                        id_UsuServ = Convert.ToInt32(drServ["id_usuario_servicio"]);
                        if (Convert.ToBoolean(drServ["OK"]) == true)
                        {
                            oCon.CrearComando(" UPDATE usuarios_servicios SET usuarios_servicios.id_usuarios_locaciones=@idLocUsuServ where usuarios_servicios.id=@id_UsuServ");
                            oCon.AsignarParametroEntero("@idLocUsuServ", id_LocacionNueva);
                            oCon.AsignarParametroEntero("@id_UsuServ", id_UsuServ);
                            oCon.ComenzarTransaccion();
                            oCon.EjecutarComando();
                            oCon.ConfirmarTransaccion();

                            oCon.CrearComando(" UPDATE usuarios_servicios_Equipos SET usuarios_servicios_Equipos.id_usuario_locacion=@idLocUsuServEq where id_usuario_servicio=@id_UsuServEq");
                            oCon.AsignarParametroEntero("@idLocUsuServEq", id_LocacionNueva);
                            oCon.AsignarParametroEntero("@id_UsuServEq", id_UsuServ);
                            oCon.ComenzarTransaccion();
                            oCon.EjecutarComando();
                            oCon.ConfirmarTransaccion();


                        }
                    }
                }

                if (dt_CtaCte.Rows.Count > 0)
                {
                    int id_Ctacte = 0;
                    foreach (DataRow dtCtaCte in dt_CtaCte.Rows)
                    {
                        if (Convert.ToBoolean(dtCtaCte["OK"]) == true)
                        {
                            DataTable dtRelacion = new DataTable();
                            id_Ctacte = Convert.ToInt32(dtCtaCte["id"]);

                            oCon.CrearComando("UPDATE usuarios_ctacte SET id_usuarios_locacion = @idLocCtaCte WHERE usuarios_ctacte.id = @idUsuCtaCte");
                            oCon.AsignarParametroEntero("@idLocCtaCte", id_LocacionNueva);
                            oCon.AsignarParametroEntero("@idUsuCtaCte", id_Ctacte);
                            oCon.ComenzarTransaccion();
                            oCon.EjecutarComando();
                            oCon.ConfirmarTransaccion();

                            oCon.CrearComando("UPDATE usuarios_ctacte_Det SET id_usuarios_locaciones = @idLocCtaCteDet WHERE usuarios_ctacte_det.id_usuarios_ctacte = @idUsuCtaCteDet");
                            oCon.AsignarParametroEntero("@idLocCtaCteDet", id_LocacionNueva);
                            oCon.AsignarParametroEntero("@idUsuCtaCteDet", id_Ctacte);
                            oCon.ComenzarTransaccion();
                            oCon.EjecutarComando();
                            oCon.ConfirmarTransaccion();

                            dtRelacion = EncontrarRelacion(id_Ctacte);
                            if (dtRelacion.Rows.Count > 0)
                            {
                                int id_Recibo = 0;
                                foreach (DataRow drRelacion in dtRelacion.Rows)
                                {
                                    id_Recibo = Convert.ToInt32(drRelacion["id_recibo"]);
                                    oCon.CrearComando("UPDATE usuarios_ctacte_recibos SET id_usuarios_locaciones = @idLocCtaCteRecibo WHERE usuarios_ctacte_recibos.id = @id_Recibo");
                                    oCon.AsignarParametroEntero("@idLocCtaCteRecibo", id_LocacionNueva);
                                    oCon.AsignarParametroEntero("@id_Recibo", id_Recibo);
                                    oCon.ComenzarTransaccion();
                                    oCon.EjecutarComando();
                                    oCon.ConfirmarTransaccion();
                                }
                            }
                        }
                    }
                }

                if (dtPartes.Rows.Count > 0)
                {
                    int id_parte = 0;
                    foreach (DataRow drParte in dtPartes.Rows)
                    {
                        if (Convert.ToBoolean(drParte["OK"]) == true)
                        {
                            id_parte = Convert.ToInt32(drParte["id"]);
                            oCon.CrearComando("update partes set id_usuarios_locaciones=@idLoc where id=@idParte");
                            oCon.AsignarParametroEntero("@idLoc", id_LocacionNueva);
                            oCon.AsignarParametroEntero("@idParte", id_parte);
                            oCon.ComenzarTransaccion();
                            oCon.EjecutarComando();
                            oCon.ConfirmarTransaccion();
                        }
                    }
                }
                oCon.DesConectar();
                return true;
            }
            catch (Exception e)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                string Salida = e.ToString();
                return false;
                
            }
        }

        public DataTable EncontrarRelacion(Int32 id_Ctacte)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.CrearComando("SELECT usuarios_ctacte_relacion.ID AS id_relacioon, usuarios_ctacte_relacion.Id_Usuarios_ctacte AS id_Ctacte, usuarios_ctacte_recibos.id AS id_recibo " +
                    "FROM usuarios_ctacte_relacion " +
                    "LEFT JOIN usuarios_ctacte_recibos ON usuarios_ctacte_relacion.Id_Usuarios_ctacte_recibos = usuarios_ctacte_recibos.id " +
                    "WHERE usuarios_ctacte_recibos.borrado = 0 AND usuarios_ctacte_relacion.Id_Usuarios_ctacte = @idCtaCte; ");
                oCon.AsignarParametroEntero("@idCtaCte", id_Ctacte); 
                dt = oCon.Tabla();
            }
            catch (Exception)
            {
                oCon.DesConectar();
            }
            return dt;
        }

        public decimal listardeudaLocacion(int id_locacion)
        {
            DataTable dt = new DataTable();
            decimal SaldoTotal = 0;
            try 
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT ifnull(SUM(importe_saldo),0) AS Saldo " +
                     "FROM usuarios_ctacte " +
                     "WHERE usuarios_ctacte.Id_Usuarios_Locacion = @idLoc AND usuarios_ctacte.Importe_Saldo > 0; ");
                 oCon.AsignarParametroEntero("@idLoc", id_locacion);
                dt = oCon.Tabla();
                oCon.DesConectar();
                if (dt.Rows.Count > 0)
                    SaldoTotal = Convert.ToDecimal(dt.Rows[0]["Saldo"]);
                else
                    SaldoTotal = 0;
                return SaldoTotal;
            }
            catch (Exception)
            {
                oCon.DesConectar();
                return 0;
            }
        }

    }

}
//200919-13:39 fede
