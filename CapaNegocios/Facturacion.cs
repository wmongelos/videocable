using CapaDatos;
using FEAFIPLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CapaNegocios
{
    public class Facturacion
    {
        #region Declaraciones
        public Int32 Id { get; set; }
        public Int32 Id_Iva_Ventas { get; set; }
        public Int32 Id_Usuarios { get; set; }
        public Int32 Id_Usuarios_locacion { get; set; }
        public Int32 Id_Usuarios_locacion_fiscal { get; set; }
        public Int32 Id_Comprobantes { get; set; }
        public Int32 Id_Comprobantes_iva { get; set; } // CONDICION DE IVA
        public Int32 Id_Comprobantes_tipo { get; set; }
        public String Razon_Social { get; set; }
        public String Fantasia { get; set; }
        public String Calle { get; set; }
        public Int32 Altura { get; set; } //cuit cuil o documento
        public String Localidad { get; set; }
        public String Provincia { get; set; }
        public String Cod_postal { get; set; }
        public Double Numero_Doc { get; set; } //cuit cuil o documento
        public Int32 Numero { get; set; }
        public Int32 Punto_Venta { get; set; }
        public String Letra { get; set; }
        public String Descripcion { get; set; }
        public String NumeroMuestra { get; set; }

        public String Cae { get; set; }
        public DateTime Cae_vencimiento { get; set; }
        public DateTime Fecha { get; set; }
        public Boolean ElectronicaOk { get; set; }
        public Decimal Importe_Neto { get; set; }
        public Decimal Importe_Iva { get; set; }
        public Decimal Importe_Impuesto_Provincial { get; set; }
        public Decimal Importe_Impuesto_Nacional { get; set; }
        public Decimal Importe_Impuesto_Municipal { get; set; }
        public Decimal Importe_Impuesto_Interno { get; set; }
        public Decimal Importe_Impuesto_Otros { get; set; }
        public Decimal Importe_Final { get; set; }
        public DataTable dtIvas { get; set; }
        public DataTable dtNovedadesAplicadasMesSubServicio = new DataTable();

        private Conexion oCon = new Conexion();
        private Comprobantes oComprobante = new Comprobantes();
        private Comprobantes_Iva Ocomprobantes_Iva = new Comprobantes_Iva();
        private Comprobantes_Tipo oComprobante_Tipo = new Comprobantes_Tipo();
        private Usuarios_CtaCte oUsuCtaCte = new Usuarios_CtaCte();
        private Usuarios_Ctacte_Det_Extra oUsuCtaCteDetExt = new Usuarios_Ctacte_Det_Extra();
        private Comprobantes_Detalle oComprobantes_Detalle = new Comprobantes_Detalle();
        private Comprobantes_Tipo Ocomprobantes_iva = new Comprobantes_Tipo();
        private Servicios_Tarifas_Sub_Esp oServiciosTarifasSubEsp = new Servicios_Tarifas_Sub_Esp();
        private Iva_Alicuotas oIva_Alicuotas = new Iva_Alicuotas();
        private Usuarios_Locaciones oUsuLoc = new Usuarios_Locaciones();
        private Comprobantes_Habilitados oComprobantesHabilitados = new Comprobantes_Habilitados();
        private Usuarios oUsuarios = new Usuarios();
        private DataTable dtDatosCAE = new DataTable();
        private Boolean trabajaElectronica = false;
        private Configuracion oConfi = new Configuracion();
        public static Int32 facturacionElectronicaMensual = 0;
        public DataTable dtSubServiciosNovedadesAplicacadas = new DataTable();
        public DataTable dtSubServiciosMesesNovedadesAplicadas = new DataTable();
        private int hacerRemito;
        public DataTable dtExtras = new DataTable();

        #region camposGeneraPercepciones
        private decimal Total_Neto;
        private decimal Total_Provincial;
        private decimal Total_Iva;
        private decimal Total_Factura;
        private DataTable dtCompDeuda;
        private DataTable ItemFactura;
        #endregion

        public enum CODIGOS_RESPUESTA_FACTURACION
        {
            OPERACION_ERROR = -1,
            OPERACION_CORRECTA = 0,
            //ERRORES PROVENIENTES DE INTERACCIÓN CON API AFIP
            ERROR_RECUPERAR_ULTIMO_COMPROBANTE = 1,
            DESAPROBADO = 2,
            NO_AUTORIZADO = 3,
            ERROR_LOGIN_API = 4,
            NO_SE_ENCUENTRA_DOCUMENTO_AFIP = 5,
            FACTURA_IMPORTE_CERO = 6,
            FACTURA_SIN_ITEMS = 7,
            NO_SE_REALIZARON_MODIFICACIONES = 8
        }

        public enum TIPO_PRESENTACION
        {
            IVA_VENTAS = 1,
            IMPUESTOS_PROVINCIALES = 2,
        }

        public enum EMITIR_REMITO
        {
            NO = 0,
            SI = 1
        }


        #endregion
        public enum ESTADO_IVA_VENTAS
        {
            OK = 0,
            VERIFICAR_CTACTE = 1,
            VERIFICAR_USUARIO = 2,
            DOCUMENTO_INVALIDO = 3,
            CERRADO = 4
        }

        public DataTable Listar_Comprobantes_Emitidos(int Id_usuario)
        {
            oCon.Conectar();
            oCon.CrearComando("SELECT comprobantes.id AS Id_Comprobantes,iva_ventas.id AS Id_Iva_ventas, usuarios.id AS Id_Usuario,usuarios.codigo AS Codigo_Usuario, " +
                "comprobantes.Id_Comprobantes_Tipo AS Id_Comprobantes_tipo, iva_ventas.fecha AS Fecha, " +
                "CONCAT(usuarios.Apellido, ' , ', usuarios.Nombre) AS Usuario, " +
                "comprobantes.Descripcion AS Comprobante, iva_ventas.Importe_Final AS Importe " +
                "FROM iva_ventas " +
                "LEFT JOIN usuarios ON iva_ventas.Id_usuario = usuarios.Id " +
                "LEFT JOIN comprobantes ON iva_Ventas.id_comprobantes = comprobantes.id " +
                "WHERE usuarios.borrado = 0 and comprobantes.borrado = 0 and iva_ventas.borrado = 0 AND usuarios.id=@id_usu " +
                "ORDER BY comprobantes.Id_Comprobantes_Tipo desc; ");
            oCon.AsignarParametroEntero("@id_usu", Id_usuario);
            DataTable dt = oCon.Tabla();

            oCon.DesConectar();

            return dt;


        }

        public Int32 GuardarIvaVentas(Facturacion Ofac, ESTADO_IVA_VENTAS estadoIvaVentas = ESTADO_IVA_VENTAS.OK)
        {
            try
            {

                decimal Final = Math.Abs(Importe_Neto) + Math.Abs(Importe_Iva) + Importe_Impuesto_Provincial;


                oCon.Conectar();
                oCon.CrearComando("insert into iva_ventas (Id_Comprobantes,Id_Usuario, Fecha, Punto_Venta, Numero,Letra,Razon_social,Fantasia,Calle,Altura,Localidad,Codigo_postal,Provincia,Numero_Documento,Cae,Cesp,Vencimiento,id_Comprobantes_iva,Id_Comprobantes_Tipo, Importe_Neto,Importe_iva,Importe_impuesto_interno,Importe_impuesto_nacional,Importe_impuesto_provincial,Importe_impuesto_municipal,Importe_final, estado) " +
                    "VALUES(@id_comprobantes1,@id_usuarios1,@fecha1,@punto_venta1,@numero1,@letra1,@Razon_social1,@Fantasia1,@Calle1,@Altura1,@Localidad1,@Cod_postal1,@Provincia1,@NumeroCuit,@cae1,@cesp1,@vencimiento1,@id_comprobantes_iva1,@id_comprobantes_tipo1,@importe_neto1,@importe_iva1,@importe_impuestos_internos1,@importe_impuesto_nacional1,@importe_impuesto_provincial1,@importe_impuesto_municipal1,@importe_final1, @estado); SELECT @@IDENTITY");

                oCon.AsignarParametroEntero("@id_comprobantes1", Id_Comprobantes);
                oCon.AsignarParametroEntero("@id_usuarios1", Id_Usuarios);
                oCon.AsignarParametroFecha("@fecha1", Fecha);
                oCon.AsignarParametroEntero("@punto_venta1", Punto_Venta);
                oCon.AsignarParametroEntero("@numero1", Numero);
                oCon.AsignarParametroCadena("@letra1", Letra);
                oCon.AsignarParametroCadena("@Razon_social1", Razon_Social);
                oCon.AsignarParametroCadena("@Fantasia1", Fantasia);
                oCon.AsignarParametroCadena("@Calle1", Calle);
                oCon.AsignarParametroEntero("@Altura1", Altura);
                oCon.AsignarParametroCadena("@Localidad1", Localidad);
                oCon.AsignarParametroCadena("@Cod_postal1", Cod_postal);
                oCon.AsignarParametroCadena("@Provincia1", Provincia);
                oCon.AsignarParametroDouble("@NumeroCuit", Numero_Doc);
                oCon.AsignarParametroCadena("@cae1", Cae);
                oCon.AsignarParametroCadena("@cesp1", Cae);
                oCon.AsignarParametroFecha("@vencimiento1", Cae_vencimiento);
                oCon.AsignarParametroEntero("@id_comprobantes_iva1", Id_Comprobantes_iva);
                oCon.AsignarParametroEntero("@id_comprobantes_tipo1", Id_Comprobantes_tipo);
                oCon.AsignarParametroDecimal("@importe_neto1", Math.Abs(Importe_Neto));
                oCon.AsignarParametroDecimal("@importe_iva1", Math.Abs(Importe_Iva));
                oCon.AsignarParametroDecimal("@importe_impuestos_internos1", Importe_Impuesto_Interno);
                oCon.AsignarParametroDecimal("@importe_impuesto_nacional1", Importe_Impuesto_Nacional);
                oCon.AsignarParametroDecimal("@importe_impuesto_provincial1", Importe_Impuesto_Provincial);
                oCon.AsignarParametroDecimal("@importe_impuesto_municipal1", Importe_Impuesto_Municipal);
                oCon.AsignarParametroDecimal("@importe_final1", Final);
                oCon.AsignarParametroEntero("@estado", Convert.ToInt32(estadoIvaVentas));

                oCon.ComenzarTransaccion();
                Id = oCon.EjecutarScalar();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                Id = 0;
                throw;
            }
            return Id;
        }

        public bool AgregarSubServiciosHeredados(DataTable dtUsuariosServiciosSubLocacionHijo, int idUsuario = 0)
        {
            bool respuesta = false;
            List<int> listaLocaciones = new List<int>();
            DataRow fila;
            DataTable dtAux = new DataTable();
            DataTable dtsubServiciosHeredados = new DataTable();

            try
            {
                if (idUsuario == 0)
                {
                    foreach (DataRow usuarioServicioSub in dtUsuariosServiciosSubLocacionHijo.Rows)
                    {
                        if (listaLocaciones.Contains(Convert.ToInt32(usuarioServicioSub["id_usuarios_locaciones"])) == false)
                            listaLocaciones.Add(Convert.ToInt32(usuarioServicioSub["id_usuarios_locaciones"]));
                    }
                }
                else
                {
                    foreach (DataRow usuarioServicioSub in dtUsuariosServiciosSubLocacionHijo.Select(String.Format("id_usuarios={0}", idUsuario)))
                    {
                        if (listaLocaciones.Contains(Convert.ToInt32(usuarioServicioSub["id_usuarios_locaciones"])) == false)
                            listaLocaciones.Add(Convert.ToInt32(usuarioServicioSub["id_usuarios_locaciones"]));
                    }
                }

                oCon.Conectar();

                if (listaLocaciones.Count > 0)
                {
                    foreach (int idLocacion in listaLocaciones)
                    {
                        dtAux.Clear();
                        dtsubServiciosHeredados.Clear();
                        oCon.CrearComando(String.Format("select id_usuarios_locaciones_padre from usuarios_locaciones_uf_relacion where id_usuarios_locaciones={0}", idLocacion));
                        dtAux = oCon.Tabla();
                        if (dtAux.Rows.Count > 0 && Convert.ToInt32(dtAux.Rows[0]["id_usuarios_locaciones_padre"]) > 0)
                        {
                            oCon.CrearComando(String.Format("select * from vw_usuarios_servicios_sub where (vw_usuarios_servicios_sub.id_servicios_estados = {1} or vw_usuarios_servicios_sub.id_servicios_estados = {2} or vw_usuarios_servicios_sub.id_servicios_estados = {3}) and id_usuarios_locaciones={0}", dtAux.Rows[0]["id_usuarios_locaciones_padre"].ToString(), Convert.ToInt32(Servicios.Servicios_Estados.SIN_CONECTAR), Convert.ToInt32(Servicios.Servicios_Estados.CONECTADO), Convert.ToInt32(Servicios.Servicios_Estados.EN_ESPERA)));
                            dtsubServiciosHeredados = oCon.Tabla();
                            if (dtsubServiciosHeredados.Rows.Count > 0)
                            {
                                foreach (DataRow filaDb in dtsubServiciosHeredados.Rows)
                                {
                                    fila = dtUsuariosServiciosSubLocacionHijo.NewRow();
                                    fila["id_usuario_servicio"] = filaDb["id_usuarios_servicios"];
                                    fila["id_usuario_servicio_sub"] = filaDb["id"];
                                    fila["id_tipo_facturacion"] = filaDb["id_tipo_facturacion"];
                                    fila["id_grupo"] = filaDb["id_servicios_grupos"];
                                    fila["id_servicio_tipo"] = filaDb["id_servicios_tipos"];
                                    fila["id_servicio"] = filaDb["id_servicios"];
                                    fila["id_servicio_sub"] = filaDb["id_servicios_sub"];
                                    fila["id_velocidad"] = filaDb["id_servicios_velocidades"];
                                    fila["id_velocidad_tipo"] = filaDb["id_servicios_velocidades_tip"];
                                    fila["tipo_servicio_sub"] = filaDb["tipo_servicio_sub"];
                                    fila["cant_bocas_pac"] = filaDb["cant_bocas_pac"];
                                    fila["servicio"] = filaDb["servicio"];
                                    fila["subservicio"] = filaDb["servicio_sub"];
                                    fila["velocidad"] = filaDb["velocidad"];
                                    fila["velocidad_tipo"] = filaDb["velocidad_tipo"];
                                    fila["nombre_bonificacion"] = filaDb["nombre_bonificacion_aplicacion"];
                                    fila["id_ip_fija"] = filaDb["id_ip_fija"];
                                    fila["id_tipo_de_sub"] = filaDb["id_servicios_sub_tipos"];
                                    fila["importe_original"] = filaDb["importe_original"];
                                    fila["importe_con_descuento"] = filaDb["importe_con_descuento"];
                                    fila["id_usuarios"] = filaDb["id_usuarios"];
                                    fila["id_usuarios_locaciones"] = idLocacion;//si bien los subservicios pertenecen a la locación padre, se les asigna el id de la locacion para que trabaje en las bonificaciones
                                    fila["fecha_factura"] = Convert.ToDateTime(filaDb["fecha_fin"]).ToString("yyyy-MM-dd");
                                    fila["id_servicios_tarifas"] = filaDb["id_servicios_tarifas"];
                                    fila["requiere_ip"] = Convert.ToInt32(filaDb["requiere_ip"]);
                                    fila["cobro_unico"] = filaDb["cobro_unico"];
                                    fila["meses_cobro"] = filaDb["meses_cobro"];
                                    fila["meses_servicio"] = filaDb["meses_servicio"];
                                    fila["id_servicio_modalidad"] = filaDb["id_servicios_modalidad"];
                                    fila["calle"] = filaDb["calle"];
                                    fila["altura"] = filaDb["altura"];
                                    fila["piso"] = filaDb["piso"];
                                    fila["depto"] = filaDb["depto"];
                                    fila["localidad"] = filaDb["localidad"];
                                    fila["usuario"] = filaDb["usuario"];
                                    fila["codigo_usuario"] = filaDb["usuario_codigo"];
                                    try
                                    {
                                        fila["fecha_factura"] = Convert.ToDateTime(filaDb["fecha_fin"]).ToString("yyyy-MM-dd");
                                    }
                                    catch
                                    {
                                        fila["fecha_factura"] = filaDb["fecha_fin"];
                                    }
                                    fila["fecha_factura_servicio"] = filaDb["fecha_factura"];
                                    fila["id_servicios_estados"] = filaDb["id_servicios_estados"];
                                    fila["id_localidad"] = filaDb["id_localidades"];
                                    fila["id_bonificacion_especial"] = filaDb["id_bonificacion_esp"];
                                    fila["heredado"] = 1;
                                    dtUsuariosServiciosSubLocacionHijo.Rows.Add(fila);
                                }
                            }
                        }
                    }
                }
                oCon.DesConectar();
                respuesta = true;
            }
            catch
            {
                respuesta = false;

                oCon.DesConectar();
            }
            return respuesta;
        }

        public DataTable GetEstructuraItem()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Descripcion", typeof(String));
            dt.Columns.Add("Unidad", typeof(String));
            dt.Columns.Add("Cantidad", typeof(Int32));
            dt.Columns.Add("Descripcion_Adicional", typeof(String));
            dt.Columns.Add("Unitario", typeof(Decimal));
            dt.Columns.Add("Total", typeof(Decimal));
            dt.Columns.Add("Punitorios", typeof(Decimal));
            dt.Columns.Add("Bonificaciones", typeof(Decimal));
            dt.Columns.Add("Impuesto", typeof(Decimal));
            dt.Columns.Add("Desde", typeof(DateTime));
            dt.Columns.Add("Hasta", typeof(DateTime));
            dt.Columns.Add("Id_servicios_tipo", typeof(Int32));
            dt.Columns.Add("Id_usuarios_servicios", typeof(Int32));
            dt.Columns.Add("Id_tipo", typeof(Int32));
            dt.Columns.Add("Id_iva_alicuotas", typeof(Int32));
            dt.Columns.Add("Id_bonificacion_aplicada", typeof(Int32));
            dt.Columns.Add("suma", typeof(Boolean));
            dt.Columns.Add("Tipo", typeof(String)); //B BONOFICACIONES AUTOMATICAS
            dt.Columns.Add("idtiporegistro", typeof(Int32)); //=0 subservicio 1 ajuste 2 bonificacion   3 novedad
            return dt;
        }

        public DataTable Arma_Detalle_Tipo(DataTable dtCdeuda, DataTable dtDetalle, Facturacion Ofac)
        {
            //// filtra los subservicios
            DataTable dtExtraFinal = new DataTable();  ///// acumula la bonificaciones
            dtExtraFinal.Columns.Add("Descripcion", typeof(String));
            dtExtraFinal.Columns.Add("Importe", typeof(Decimal));
            dtExtraFinal.Columns.Add("Id_Tipo_Extra", typeof(Int32));
            dtExtraFinal.Columns.Add("Id_extra", typeof(Int32));
            DataTable dtItemFactura = new DataTable(); // tabla para agrupar los subservicios de un tipo
            dtItemFactura = GetEstructuraItem();
            //Int32 Id_Iva_Alicuotas = 1; /// deberia venir de los servicios
            DataTable dtSubServicios = new DataTable();
            DataView v1 = dtDetalle.DefaultView;
            v1.RowFilter = String.Format("encabezado={0} and elige={1}", 0, true); // Los Subservicios elegidos
            v1.Sort = "Id_Servicios_Tipo ASC";
            dtSubServicios = v1.ToTable();
            var qTipo = from c in dtSubServicios.AsEnumerable() // agrupa por tipo de servicio
                        group c by c.Field<int>("Id_Servicios_Tipo") into grupo
                        select new
                        {
                            idtipo = grupo.FirstOrDefault().Field<int>("Id_Servicios_Tipo"),
                            nomtipo = grupo.FirstOrDefault().Field<String>("tipo_nombre"),
                        };
            Decimal Sub_Bonificacion = 0;
            Decimal Sub_Punitorio = 0;
            Decimal Sub_Impuesto = 0;
            Decimal Sub_Unitario = 0;
            Decimal Sub_Total = 0;
            Decimal Sub_Bonificacion_Extras = 0; // acumula de usuarios_ctacte_det_extras
            string tipo_linea = "S";
            Boolean esta = false;
            Int32 idtiporeg = 0;
            foreach (var item in qTipo) /// Agrupado por tipo de servicios
            {
                //--------------------------------------------------
                //Acumula los subservicios solo el monto original
                //--------------------------------------------------
                dtExtraFinal.Clear();
                foreach (DataRow Dr in dtSubServicios.Rows) /// subservicios elegidos
                {
                    if (Convert.ToInt32(Dr["Id_Servicios_Tipo"].ToString()) == Convert.ToInt32(item.idtipo))
                    {
                        esta = false;
                        tipo_linea = Dr["tipo"].ToString(); // SERVICIO LO TRAE DE TIPO DE LA CTACTE
                        idtiporeg = Convert.ToInt32(Dr["Idtiporegistroctactedet"].ToString()); //0 servicio - 1 ajuste 3 novedad (2 bonificacion se crea) 9 total
                        if (Convert.ToInt32(Dr["Idtiporegistroctactedet"].ToString()) == 3) //NOVEDAD
                            tipo_linea = "N";
                        if (Convert.ToInt32(Dr["Idtiporegistroctactedet"].ToString()) == 1) //AJUSTE MANUAL
                            tipo_linea = "A";
                        Sub_Bonificacion = Sub_Bonificacion + Convert.ToDecimal(Dr["importe_bonificacion"].ToString());
                        Sub_Punitorio = Sub_Punitorio + Convert.ToDecimal(Dr["importe_punitorio"].ToString());
                        Sub_Impuesto = Sub_Impuesto + Convert.ToDecimal(Dr["importe_provincial"].ToString());
                        Sub_Unitario = Sub_Unitario + Convert.ToDecimal(Dr["importe_original"].ToString());
                        Sub_Total = Sub_Total + Convert.ToDecimal(Dr["importe_total"].ToString());

                        if (tipo_linea != "A")// AL SER UN AJUSTE NO SUMA
                        {
                            foreach (DataRow Dritem in dtItemFactura.Rows) /// tiene que elegir todos los subservicios se pague o no
                            {
                                if (Convert.ToInt32(Dr["Id_usuarios_servicios"].ToString()) != 0 && Convert.ToInt32(Dr["Id_usuarios_servicios"].ToString()) == Convert.ToInt32(Dritem["Id_usuarios_servicios"].ToString()) && Convert.ToInt32(Dr["Id_tipo"].ToString()) == Convert.ToInt32(Dritem["Id_tipo"].ToString()) && Dr["Tipo"].ToString() == Dritem["Tipo"].ToString() && Convert.ToInt32(Dritem["idtiporegistro"].ToString()) == idtiporeg)
                                {
                                    esta = true;
                                    //    Dritem["Cantidad"] = Convert.ToInt32(Dritem["Cantidad"].ToString()) + 1;
                                    Dritem["Total"] = Convert.ToDecimal(Dritem["total"].ToString()) + Convert.ToDecimal(Dr["importe_original"].ToString());
                                    Dritem["Unitario"] = Convert.ToDecimal(Dritem["Unitario"].ToString()) + Convert.ToDecimal(Dr["importe_original"].ToString());
                                    Dritem["Punitorios"] = Convert.ToDecimal(Dritem["Punitorios"].ToString()) + Convert.ToDecimal(Dr["importe_punitorio"].ToString());
                                    Dritem["Bonificaciones"] = Convert.ToDecimal(Dritem["Bonificaciones"].ToString()) + Convert.ToDecimal(Dr["importe_bonificacion"].ToString());
                                    Dritem["Hasta"] = Convert.ToDateTime(Dr["fecha_hasta"].ToString());
                                    Dritem["Impuesto"] = Convert.ToDecimal(Dritem["Impuesto"].ToString()) + Convert.ToDecimal(Dr["importe_provincial"].ToString());
                                }
                            }
                        }
                        //                            if (Convert.ToDecimal(Dr["importe_original"].ToString()) < 0 || Convert.ToDecimal(Dr["Idtiporegistroctactedet"].ToString()) == 3) /// ajustes tiene que salir individuales O NOVEDADES
                        if (esta == false) /// No esta no suma importes e inserta una fila
                        {
                            String DetalleLinea = "";
                            if (tipo_linea == "A")
                               DetalleLinea = Dr["Detalles"].ToString().Trim() + " ";
                            else
                                DetalleLinea = Dr["servicio_nombre"].ToString().ToUpper() + "-" + Dr["sub_servicio"].ToString() + "\n" + Dr["Detalles"].ToString().Trim() + " ";

                            DataRow DrInserta;
                            DrInserta = dtItemFactura.NewRow();
                              DrInserta["Descripcion"] = DetalleLinea;
                              DrInserta["Unidad"] = "";
                              DrInserta["Cantidad"] = 1;
                              DrInserta["Descripcion_Adicional"] = Dr["Detalles"].ToString();
                              DrInserta["Total"] = Convert.ToDecimal(Dr["importe_original"].ToString()); //+ Convert.ToDecimal(Dr["importe_punitorio"].ToString());
                              DrInserta["Unitario"] = Convert.ToDecimal(Dr["importe_original"].ToString());
                              DrInserta["Punitorios"] = Convert.ToDecimal(Dr["importe_punitorio"].ToString());
                              DrInserta["Bonificaciones"] = Convert.ToDecimal(Dr["importe_bonificacion"].ToString());
                              DrInserta["Impuesto"] = Convert.ToDecimal(Dr["importe_provincial"].ToString());
                              DrInserta["Desde"] = Convert.ToDateTime(Dr["fecha_desde"].ToString());
                              DrInserta["Hasta"] = Convert.ToDateTime(Dr["fecha_hasta"].ToString());
                              DrInserta["Id_servicios_tipo"] = Convert.ToInt32(Dr["Id_servicios_tipo"].ToString());
                              DrInserta["Id_usuarios_servicios"] = Convert.ToInt32(Dr["Id_usuarios_servicios"].ToString());
                              DrInserta["Id_tipo"] = Convert.ToInt32(Dr["Id_tipo"].ToString());
                             //busco el id iva alicuotas
                              DrInserta["Id_iva_alicuotas"] = oIva_Alicuotas.idIvaAliCuotas(Convert.ToInt32(Dr["Id_tipo"]), Dr["Tipo"].ToString());
                              DrInserta["Id_bonificacion_aplicada"] = 0;
                              DrInserta["suma"] = false;
                              DrInserta["Tipo"] = Dr["Tipo"].ToString();
                              DrInserta["idtiporegistro"] = idtiporeg;
                            dtItemFactura.Rows.Add(DrInserta);
                        }

                    }
                }
                //------------------------------------------------------
                //Acumula los subservicios solo el monto bonificaciones
                //------------------------------------------------------

                DataTable dtExtras = new DataTable();
                DataTable dtSubServiciosBonificacionAplicada = new DataTable();
                DataView v2 = dtSubServicios.DefaultView;
                v2.RowFilter = String.Format("importe_bonificacion<>{0} and Id_Servicios_Tipo={1} and encabezado ={2} ", 0, Convert.ToInt32(item.idtipo), 0); // Los Subservicios elegidos
                v2.Sort = "Id_Servicios_Tipo ASC";
                dtSubServiciosBonificacionAplicada = v1.ToTable();
                foreach (DataRow Dr in dtSubServiciosBonificacionAplicada.Rows) /// subservicios elegidos
                {
                    if (Convert.ToDecimal(Dr["importe_bonificacion"].ToString()) != 0 && Convert.ToInt32(Dr["Id_Servicios_Tipo"].ToString()) == Convert.ToInt32(item.idtipo))
                    {
                        dtExtras = oUsuCtaCteDetExt.ListarExtrasDet(Convert.ToInt32(Dr["Id"].ToString()));
                        foreach (DataRow DrExtras in dtExtras.Rows)
                        {
                            esta = false;
                            foreach (DataRow DrExtrasFinal in dtExtraFinal.Rows) /// si ya existe la bonifi la suma , sino inserta
                            {
                                if (Convert.ToInt32(DrExtras["Id_Extra"].ToString()) == Convert.ToInt32(DrExtrasFinal["Id_Extra"].ToString()))
                                {
                                    DrExtrasFinal["Importe"] = Convert.ToDecimal(DrExtrasFinal["Importe"].ToString()) + Convert.ToDecimal(DrExtras["descuento"].ToString());
                                    esta = true;
                                }
                            }
                            if (esta == false)
                                dtExtraFinal.Rows.Add(DrExtras["detalle"].ToString(), Convert.ToDecimal(DrExtras["descuento"].ToString()), Convert.ToInt32(DrExtras["Id_Extra"].ToString()), Convert.ToInt32(DrExtras["Id_Extra"].ToString()));
                        }
                    }
                }
                foreach (DataRow DrExtrasFinal in dtExtraFinal.Rows) /// si ya existe la bonifi la suma , sino inserta
                {
                    Sub_Bonificacion_Extras = Sub_Bonificacion_Extras + Convert.ToDecimal(DrExtrasFinal["importe"].ToString());
                    DataRow DrInserta;
                    DrInserta = dtItemFactura.NewRow();
                    DrInserta["Descripcion"] = " ** Bonificacion  " + DrExtrasFinal["Descripcion"].ToString();
                    DrInserta["Unidad"] = "";
                    DrInserta["Cantidad"] = 1;
                    DrInserta["Descripcion_Adicional"] = "";
                    DrInserta["Total"] = Convert.ToDecimal(DrExtrasFinal["importe"].ToString()) * -1;
                    DrInserta["Unitario"] = Convert.ToDecimal(DrExtrasFinal["importe"].ToString()) * -1;
                    DrInserta["Punitorios"] = 0;
                    DrInserta["Bonificaciones"] = 0;
                    DrInserta["Impuesto"] = 0;
                    DrInserta["Id_tipo"] = Convert.ToInt32(item.idtipo);
                    DrInserta["Id_usuarios_servicios"] = 0;
                    DrInserta["Desde"] = DateTime.Now;
                    DrInserta["Hasta"] = DateTime.Now;
                    DrInserta["Tipo"] = "B";
                    DrInserta["suma"] = false;
                    DrInserta["Id_iva_alicuotas"] = Iva_Alicuotas.IVA_ALICUOTAS.IVA21;
                    DrInserta["idtiporegistro"] = 2;
                    dtItemFactura.Rows.Add(DrInserta);
                }


                if (Sub_Punitorio>0)
                {
                    DataRow DrPunitorios;
                    DrPunitorios = dtItemFactura.NewRow();
                    DrPunitorios["Descripcion"] = "Punitorios";
                    DrPunitorios["Unidad"] = "";
                    DrPunitorios["Cantidad"] = 1;
                    DrPunitorios["Descripcion_Adicional"] = "";
                    DrPunitorios["Unitario"] = Sub_Punitorio;
                    DrPunitorios["Total"] = Sub_Punitorio;
                    DrPunitorios["Punitorios"] = 0;
                    DrPunitorios["Bonificaciones"] = 0;
                    DrPunitorios["Impuesto"] = 0;
                    DrPunitorios["Id_tipo"] = Convert.ToInt32(item.idtipo);
                    DrPunitorios["Id_usuarios_servicios"] = 0;
                    DrPunitorios["Desde"] = DateTime.Now;
                    DrPunitorios["Hasta"] = DateTime.Now;
                    DrPunitorios["Id_iva_alicuotas"] = Iva_Alicuotas.IVA_ALICUOTAS.IVA21;
                    DrPunitorios["idtiporegistro"] = 9;
                    DrPunitorios["suma"] = false;
                    dtItemFactura.Rows.Add(DrPunitorios);
                }

                DataRow DrInsertas;
                DrInsertas = dtItemFactura.NewRow();
                DrInsertas["Descripcion"] = item.nomtipo;
                DrInsertas["Unidad"] = "";
                DrInsertas["Cantidad"] = 1;
                DrInsertas["Descripcion_Adicional"] = "S";
                DrInsertas["Unitario"] = Sub_Unitario - Sub_Bonificacion_Extras;
                DrInsertas["Total"] = Sub_Unitario - Sub_Bonificacion_Extras + Sub_Punitorio;
                DrInsertas["Punitorios"] = Sub_Punitorio;
                DrInsertas["Bonificaciones"] = Sub_Bonificacion;
                DrInsertas["Impuesto"] = Sub_Impuesto;
                DrInsertas["Id_tipo"] = Convert.ToInt32(item.idtipo);
                DrInsertas["Id_usuarios_servicios"] = 0;
                DrInsertas["Desde"] = DateTime.Now;
                DrInsertas["Hasta"] = DateTime.Now;
                DrInsertas["Id_iva_alicuotas"] = Iva_Alicuotas.IVA_ALICUOTAS.IVA21;
                DrInsertas["idtiporegistro"] = 9;
                DrInsertas["suma"] = true;
                dtItemFactura.Rows.Add(DrInsertas);
                Sub_Bonificacion = 0;
                Sub_Punitorio = 0;
                Sub_Impuesto = 0;
                Sub_Unitario = 0;
                Sub_Total = 0;
                Sub_Bonificacion_Extras = 0;
            }
            return dtItemFactura;
        }

        public DataTable ListarDetalle()
        {
            oCon.Conectar();
            oCon.CrearComando("SELECT * FROM comprobantes_detalle where id_comprobantes=@idc ");
            oCon.AsignarParametroEntero("@idc", Id_Comprobantes);
            DataTable dt = oCon.Tabla();

            oCon.DesConectar();

            return dt;
        }

        public void GuardarIvalicuotas(Facturacion Ofac, DataRow drIvas)
        {
            try
            {

                oCon.Conectar();
                oCon.CrearComando("insert into iva_alicuotas_detalles (Id_iva_ventas,Id_Comprobantes,id_iva_Alicuotas,porcentaje,Importe_Neto,Importe_iva) " +
                    "VALUES(@idIvaVentas,@id_comprobantes1,@id_iva_alicuotas1,@porcen,@importe_neto1,@importe_iva1)");

                oCon.AsignarParametroEntero("@idIvaVentas", Ofac.Id_Iva_Ventas);
                oCon.AsignarParametroEntero("@id_comprobantes1", Ofac.Id_Comprobantes);
                oCon.AsignarParametroEntero("@id_iva_alicuotas1", Convert.ToInt32(drIvas["id"].ToString()));
                oCon.AsignarParametroDecimal("@porcen", Convert.ToDecimal(drIvas["porcentaje"].ToString()));
                oCon.AsignarParametroDecimal("@importe_neto1", Convert.ToDecimal(drIvas["importe_neto"].ToString()));
                oCon.AsignarParametroDecimal("@importe_iva1", Convert.ToDecimal(drIvas["importe_iva"].ToString()));

                oCon.EjecutarComando();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                throw;
            }


        }

        public DataTable ListarIvalicuotas()
        {
            oCon.Conectar();
            oCon.CrearComando("SELECT * FROM iva_alicuotas_detalles where id_comprobantes=@idc ");
            oCon.AsignarParametroEntero("@idc", Id_Comprobantes);
            DataTable dt = oCon.Tabla();

            oCon.DesConectar();

            return dt;
        }

        public Int32 GuardarIvaVentas(Facturacion Ofac)
        {
            try
            {

                decimal Final = Math.Abs(Importe_Neto) + Math.Abs(Importe_Iva) + Importe_Impuesto_Provincial;


                oCon.Conectar();
                oCon.CrearComando("insert into iva_ventas (Id_Comprobantes,Id_Usuario, Fecha, Punto_Venta, Numero,Letra,Razon_social,Fantasia,Calle,Altura,Localidad,Codigo_postal,Provincia,Numero_Documento,Cae,Cesp,Vencimiento,id_Comprobantes_iva,Id_Comprobantes_Tipo, Importe_Neto,Importe_iva,Importe_impuesto_interno,Importe_impuesto_nacional,Importe_impuesto_provincial,Importe_impuesto_municipal,Importe_final) " +
                    "VALUES(@id_comprobantes1,@id_usuarios1,@fecha1,@punto_venta1,@numero1,@letra1,@Razon_social1,@Fantasia1,@Calle1,@Altura1,@Localidad1,@Cod_postal1,@Provincia1,@NumeroCuit,@cae1,@cesp1,@vencimiento1,@id_comprobantes_iva1,@id_comprobantes_tipo1,@importe_neto1,@importe_iva1,@importe_impuestos_internos1,@importe_impuesto_nacional1,@importe_impuesto_provincial1,@importe_impuesto_municipal1,@importe_final1); SELECT @@IDENTITY");

                oCon.AsignarParametroEntero("@id_comprobantes1", Id_Comprobantes);
                oCon.AsignarParametroEntero("@id_usuarios1", Id_Usuarios);
                oCon.AsignarParametroFecha("@fecha1", Fecha);
                oCon.AsignarParametroEntero("@punto_venta1", Punto_Venta);
                oCon.AsignarParametroEntero("@numero1", Numero);
                oCon.AsignarParametroCadena("@letra1", Letra);
                oCon.AsignarParametroCadena("@Razon_social1", Razon_Social);
                oCon.AsignarParametroCadena("@Fantasia1", Fantasia);
                oCon.AsignarParametroCadena("@Calle1", Calle);
                oCon.AsignarParametroEntero("@Altura1", Altura);
                oCon.AsignarParametroCadena("@Localidad1", Localidad);
                oCon.AsignarParametroCadena("@Cod_postal1", Cod_postal);
                oCon.AsignarParametroCadena("@Provincia1", Provincia);
                oCon.AsignarParametroDouble("@NumeroCuit", Numero_Doc);
                oCon.AsignarParametroCadena("@cae1", Cae);
                oCon.AsignarParametroCadena("@cesp1", Cae);
                oCon.AsignarParametroFecha("@vencimiento1", Cae_vencimiento);
                oCon.AsignarParametroEntero("@id_comprobantes_iva1", Id_Comprobantes_iva);
                oCon.AsignarParametroEntero("@id_comprobantes_tipo1", Id_Comprobantes_tipo);
                oCon.AsignarParametroDecimal("@importe_neto1", Math.Abs(Importe_Neto));
                oCon.AsignarParametroDecimal("@importe_iva1", Math.Abs(Importe_Iva));
                oCon.AsignarParametroDecimal("@importe_impuestos_internos1", Importe_Impuesto_Interno);
                oCon.AsignarParametroDecimal("@importe_impuesto_nacional1", Importe_Impuesto_Nacional);
                oCon.AsignarParametroDecimal("@importe_impuesto_provincial1", Importe_Impuesto_Provincial);
                oCon.AsignarParametroDecimal("@importe_impuesto_municipal1", Importe_Impuesto_Municipal);
                oCon.AsignarParametroDecimal("@importe_final1", Final);

                oCon.ComenzarTransaccion();
                Id = oCon.EjecutarScalar();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                Id = 0;
                throw;
            }
            return Id;
        }

        public DataTable ListarIvaVentas()
        {
            oCon.Conectar();
            oCon.CrearComando("SELECT iva_ventas.*,puntos_venta.* FROM iva_ventas left join puntos_venta on puntos_venta.numero = iva_ventas.punto_venta where id_comprobantes=@idc and iva_ventas.borrado=0");
            oCon.AsignarParametroEntero("@idc", Id_Comprobantes);
            DataTable dt = oCon.Tabla();

            oCon.DesConectar();

            return dt;
        }

        public DataTable ListarIvaAlicuotasDetalles()
        {
            oCon.Conectar();
            oCon.CrearComando(string.Format("SELECT id_iva_Alicuotas, iva_alicuotas_detalles.porcentaje,iva_alicuotas_detalles.importe_neto, " +
                " iva_alicuotas_detalles.importe_iva,iva_alicuotas.numero_afip,iva_alicuotas.id as id " +
                " FROM iva_alicuotas_detalles " +
                " left join iva_alicuotas on iva_alicuotas.id = iva_alicuotas_detalles.id_iva_alicuotas " +
                " where id_comprobantes={0}", Id_Comprobantes));
            DataTable dt = oCon.Tabla();

            oCon.DesConectar();

            return dt;
        }

        public DataTable[] ListarIvaVentasPorFechayPunto(string fecha_desde, string fecha_hasta, int punto)
        {
            DataTable[] dts = new DataTable[2];
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();
            try
            {
                oCon.Conectar();
                if (punto == 0)
                    oCon.CrearComando("SELECT iva_ventas.Id_comprobantes, iva_ventas.Id_comprobantes_iva, iva_ventas.Razon_social,iva_ventas.localidad,iva_Ventas.calle,iva_Ventas.altura,iva_ventas.fecha,iva_ventas.Punto_Venta,comprobantes_iva.documento_afip, comprobantes_iva.descripcion as condicion_iva, comprobantes_tipo.nombre,comprobantes_tipo.Letra,comprobantes_tipo.Codigo_Afip,iva_ventas.cae,iva_ventas.Numero_Documento,iva_ventas.Importe_Neto,iva_ventas.Importe_Iva,iva_ventas.Importe_Impuesto_Interno,iva_ventas.Importe_Final,iva_ventas.Importe_Impuesto_Provincial,iva_ventas.Importe_Impuesto_nacional,iva_ventas.Importe_Impuesto_municipal,iva_ventas.Id_comprobantes_tipo,comprobantes.numero,iva_ventas.vencimiento FROM iva_ventas INNER JOIN comprobantes_tipo on comprobantes_tipo.id=iva_ventas.id_comprobantes_tipo LEFT JOIN comprobantes on comprobantes.id=iva_ventas.Id_comprobantes left join comprobantes_iva on comprobantes_iva.id=iva_ventas.id_comprobantes_iva where iva_ventas.numero>0 and iva_ventas.fecha>=@fecha_desde AND iva_ventas.fecha<=@fecha_hasta order by iva_ventas.numero asc");
                else
                    oCon.CrearComando("SELECT iva_ventas.Id_comprobantes, iva_ventas.Id_comprobantes_iva, iva_ventas.Razon_social,iva_ventas.localidad,iva_Ventas.calle,iva_Ventas.altura,iva_ventas.fecha,iva_ventas.Punto_Venta,comprobantes_iva.documento_afip, comprobantes_iva.descripcion as condicion_iva, comprobantes_tipo.nombre,comprobantes_tipo.Letra,comprobantes_tipo.Codigo_Afip,iva_ventas.cae,iva_ventas.Numero_Documento,iva_ventas.Importe_Neto,iva_ventas.Importe_Iva,iva_ventas.Importe_Impuesto_Interno,iva_ventas.Importe_Final,iva_ventas.Importe_Impuesto_Provincial,iva_ventas.Importe_Impuesto_nacional,iva_ventas.Importe_Impuesto_municipal,iva_ventas.Id_comprobantes_tipo,comprobantes.numero,iva_ventas.vencimiento FROM iva_ventas INNER JOIN comprobantes_tipo on comprobantes_tipo.id=iva_ventas.id_comprobantes_tipo LEFT JOIN comprobantes on comprobantes.id=iva_ventas.Id_comprobantes left join comprobantes_iva on comprobantes_iva.id=iva_ventas.id_comprobantes_iva where iva_ventas.numero>0 and iva_ventas.fecha>=@fecha_desde AND iva_ventas.fecha<=@fecha_hasta AND iva_ventas.Punto_Venta=@punto order by iva_ventas.numero asc");
                oCon.AsignarParametroCadena("@fecha_desde", fecha_desde);
                oCon.AsignarParametroCadena("@fecha_hasta", fecha_hasta);
                if (punto != 0)
                    oCon.AsignarParametroEntero("@punto", punto);

                dts[0] = oCon.Tabla();
                if (punto == 0)
                    oCon.CrearComando("select sum(iva_ventas.importe_final) AS total_final,sum(iva_ventas.Importe_Neto) AS total_neto,sum(iva_ventas.Importe_Iva) AS total_iva,sum(iva_ventas.Importe_Impuesto_Interno) AS total_interno,"
                  + " sum(iva_ventas.Importe_Impuesto_Provincial) AS total_provincial, sum(iva_ventas.Importe_Impuesto_Nacional) AS total_nacional,"
                  + " sum(iva_ventas.Importe_Impuesto_Municipal) AS total_municipal, iva_ventas.id_comprobantes, iva_ventas.id_comprobantes_iva,"
                  + " iva_ventas.punto_venta, comprobantes_tipo.nombre, comprobantes_tipo.letra,"
                  + " comprobantes_tipo.codigo_afip, iva_ventas.id_comprobantes_tipo"
                  + " from iva_ventas"
                  + " LEFT join comprobantes_tipo on comprobantes_tipo.id = iva_ventas.id_comprobantes_tipo"
                  + " where iva_ventas.numero>0 and DATE(iva_ventas.fecha) >=DATE(@fecha_desde) and DATE(iva_ventas.fecha) <= DATE(@fecha_hasta)"
                  + " group by iva_ventas.id_comprobantes_tipo,iva_ventas.punto_venta");
                else
                    oCon.CrearComando("select sum(iva_ventas.importe_final) AS total_final,sum(iva_ventas.Importe_Neto) AS total_neto,sum(iva_ventas.Importe_Iva) AS total_iva,sum(iva_ventas.Importe_Impuesto_Interno) AS total_interno,"
                    + " sum(iva_ventas.Importe_Impuesto_Provincial) AS total_provincial, sum(iva_ventas.Importe_Impuesto_Nacional) AS total_nacional,"
                    + " sum(iva_ventas.Importe_Impuesto_Municipal) AS total_municipal, iva_ventas.id_comprobantes, iva_ventas.id_comprobantes_iva,"
                    + " iva_ventas.punto_venta, comprobantes_tipo.nombre, comprobantes_tipo.letra,"
                    + " comprobantes_tipo.codigo_afip, iva_ventas.id_comprobantes_tipo"
                    + " from iva_ventas"
                    + " LEFT join comprobantes_tipo on comprobantes_tipo.id = iva_ventas.id_comprobantes_tipo"
                    + " where iva_ventas.numero>0 and DATE(iva_ventas.fecha) >=DATE(@fecha_desde) and DATE(iva_ventas.fecha) <= DATE(@fecha_hasta) and iva_ventas.punto_venta = @punto"
                    + " group by iva_ventas.id_comprobantes_tipo,iva_ventas.punto_venta");
                oCon.AsignarParametroCadena("@fecha_desde", fecha_desde);
                oCon.AsignarParametroCadena("@fecha_hasta", fecha_hasta);
                if (punto != 0)
                    oCon.AsignarParametroEntero("@punto", punto);
                dts[1] = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }


            return dts;
        }

        /// <summary>
        /// Metodo Homero
        /// </summary>
        /// <param name="idTarifa"></param>
        /// <param name="idUsuario"></param>
        /// <param name="fechaInicioServicio"></param>
        /// <param name="contemplarServiciosCortados"></param>
        /// <param name="contemplarServiciosNoFacturablesMensual"></param>
        /// <param name="debitos"></param>
        /// <returns></returns>
        public DataTable RetornarSubServicios(int idTarifa, int idUsuario, DateTime fechaInicioServicio, bool contemplarServiciosCortados, bool contemplarServiciosNoFacturablesMensual, bool debitos = false)
        {
            string consulta = String.Empty;
            DataTable dtEstructuraBonificaciones = new DataTable();
            Bonificaciones oBonificaciones = new Bonificaciones();
            dtEstructuraBonificaciones = oBonificaciones.GenerarDtSubServicios();
            DataRow fila;
            DataTable dt = new DataTable();
            DataView dtv;
            try
            {
                oCon.Conectar();

                if (contemplarServiciosCortados)
                {
                    if (contemplarServiciosNoFacturablesMensual)
                    {
                        consulta = string.Format("select usuarios_servicios_sub.id , usuarios_servicios_sub.id_usuarios_servicios ,usuarios_servicios_sub.id_servicios_sub, usuarios_servicios.id_tipo_facturacion,"
                                        + " servicios_tipos.id_servicios_grupos , servicios.id_servicios_tipos, servicios_sub.id_servicios, usuarios_servicios_sub.id_servicios_velocidades,"
                                        + " usuarios_servicios_sub.id_servicios_velocidades_tip,'S' AS 'tipo_servicio_sub', usuarios_servicios.cant_bocas_pac, servicios.descripcion as servicio,"
                                        + " servicios_sub.descripcion as servicio_sub, IF((ISNULL(`servicios_velocidades`.`Velocidad`) = 1), '-', CONCAT(CAST(`servicios_velocidades`.`Velocidad` AS char(50) CHARSET utf8), ' MB')) AS 'velocidad',"
                                        + " IF((ISNULL(`servicios_velocidades_tip`.`Nombre`) = 1), '-', `servicios_velocidades_tip`.`Nombre`) AS 'velocidad_tipo',"
                                        + " usuarios_servicios_sub.nombre_bonificacion_aplicacion, usuarios_servicios_sub.id_ip_fija, servicios_sub.id_servicios_sub_tipos,"
                                        + " T.importe as importe_original , T.importe as importe_con_descuento, usuarios_servicios.id_usuarios,"
                                        + " usuarios_servicios.id_usuarios_locaciones, usuarios_servicios_sub.fecha_fin, T.id_servicios_tarifas,"
                                        + " usuarios_servicios_sub.requiere_ip, servicios_sub_tipos.cobro_unico, usuarios_servicios.meses_cobro, usuarios_servicios.meses_servicio,"
                                        + " servicios.id_servicios_modalidad, usuarios_locaciones.calle, usuarios_locaciones.altura, CONCAT('Piso:', `usuarios_locaciones`.`Piso`) AS 'piso',"
                                        + " CONCAT('Depto.:', `usuarios_locaciones`.`Depto`) AS 'depto', localidades.nombre as localidad, "
                                        + " CONCAT(`usuarios`.`Apellido`, ' ', `usuarios`.`Nombre`) AS 'usuario', usuarios.Codigo AS 'usuario_codigo', usuarios_servicios.fecha_factura,"
                                        + " usuarios_servicios.id_servicios_estados, usuarios_locaciones.id_localidades, usuarios_servicios_sub.id_bonificacion_esp, servicios.factura_mensualmente"
                                        + " from usuarios_servicios_sub"
                                        + " left join usuarios_servicios on usuarios_servicios.id = usuarios_servicios_sub.id_usuarios_servicios"
                                        + " left join usuarios on usuarios.id = usuarios_servicios.id_usuarios"
                                        + " left join servicios_sub on servicios_sub.id = usuarios_servicios_sub.id_servicios_sub"
                                        + " left join servicios_tipos on servicios_tipos.id = usuarios_servicios.id_servicios_tipo"
                                        + " left join servicios on servicios.id = usuarios_servicios.id_servicios"
                                        + " left join servicios_sub_tipos on servicios_sub.Id_Servicios_Sub_Tipos = servicios_sub_tipos.Id"
                                        + " left join servicios_velocidades on servicios_velocidades.id = usuarios_servicios_sub.id_servicios_velocidades"
                                        + " left join servicios_velocidades_tip on servicios_velocidades_tip.id = usuarios_servicios_sub.id_servicios_velocidades_tip"
                                        + " left join usuarios_locaciones on usuarios_locaciones.id = usuarios_servicios.id_usuarios_locaciones"
                                        + " left join localidades on localidades.id = usuarios_locaciones.id_localidades"
                                        + " inner join (select servicios_tarifas_sub.id_servicios_tarifas ,servicios_tarifas_sub.importe, servicios_tarifas_sub.id_tabla_tipo as id_servicios_sub,"
                                        + " servicios_tarifas_sub.tipo as tiposub, servicios_tarifas_sub.id_tipo_facturacion, 0 as id_servicios_velocidad, 0 as id_servicio_velocidad_tip"
                                        + " from servicios_tarifas_sub"
                                        + " UNION ALL"
                                        + " select servicios_tarifas_sub_esp.id_servicios_tarifas,"
                                        + " (CASE `servicios_tarifas_sub_esp`.`Id_Servicios_Base` WHEN 0 THEN `servicios_tarifas_sub_esp`.`Importe` ELSE(SELECT(SUM(`servicios_tarifas_sub`.`Importe`) * `servicios_tarifas_sub_esp`.`Meses_Cobro`) FROM `servicios_tarifas_sub` WHERE((`servicios_tarifas_sub`.`Id_Servicios` = `servicios_tarifas_sub_esp`.`Id_Servicios_Base`)"
                                        + " AND(`servicios_tarifas_sub`.`Tipo` = 'S')"
                                        + " AND(`servicios_tarifas_sub`.`Id_Tipo_Facturacion` = `servicios_tarifas_sub_esp`.`Id_Tipo_Facturacion`)"
                                        + " AND(`servicios_tarifas_sub`.`Id_Servicios_Tarifas` = `servicios_tarifas_sub_esp`.`Id_Servicios_Tarifas`))) END) AS 'importe',"
                                        + " servicios_sub.id as id_servicios_sub, 'S' as tiposub, servicios_tarifas_sub_esp.id_tipo_facturacion ,"
                                        + " servicios_tarifas_sub_esp.id_servicios_velocidad, servicios_tarifas_sub_esp.id_servicios_velocidad_tip as id_servicio_velocidad_tip"
                                        + " from servicios_tarifas_sub_esp"
                                        + " LEFT JOIN servicios_sub ON servicios_sub.Id = servicios_tarifas_sub_esp.Id_Servicios_Sub) as T  "
                                        + " on T.id_servicios_sub = usuarios_servicios_sub.id_servicios_sub"
                                        + " and T.tiposub = 'S' and usuarios_servicios.id_tipo_facturacion = T.id_tipo_facturacion and usuarios_servicios_sub.id_servicios_velocidades = T.id_servicios_velocidad"
                                        + " and usuarios_servicios_sub.id_servicios_velocidades_tip = T.id_servicio_velocidad_tip and T.id_servicios_tarifas = {0}"
                                        + " where usuarios.id = {1} and usuarios_servicios_sub.borrado = 0"
                                        + " and(usuarios_servicios.id_servicios_estados = {2} or usuarios_servicios.id_servicios_estados = {3} or usuarios_servicios.id_servicios_estados = {4} or usuarios_servicios.id_servicios_estados = {5} or usuarios_servicios.id_servicios_estados = {6})"
                                        + " and servicios_sub.id_servicios_sub_tipos != {5}"
                                        + " group by usuarios_servicios_sub.id order by usuarios.codigo asc",
                                        idTarifa, idUsuario, Convert.ToInt32(Servicios.Servicios_Estados.CONECTADO), Convert.ToInt32(Servicios.Servicios_Estados.EN_ESPERA),
                                        Convert.ToInt32(Servicios.Servicios_Estados.SIN_CONECTAR), Convert.ToInt32(Servicios.Servicios_Estados.RETIRADO), Convert.ToInt32(Servicios.Servicios_Estados.CORTADO), Convert.ToInt32(Servicios_Sub.SERVICIO_SUB_TIPOS.DERECHO_DE_CONEXION));
                    }
                    else
                    {
                        consulta = String.Format("select vw_usuarios_servicios_sub.*, vw_tarifas.importe as importe_original, vw_tarifas.importe as importe_con_descuento, vw_tarifas.id_servicios_tarifas " +
                                                          " from  vw_usuarios_servicios_sub inner join vw_tarifas on vw_usuarios_servicios_sub.id_servicios_sub = vw_tarifas.id_servicios_sub" +
                                                          " and vw_tarifas.tiposub = 'S' and vw_usuarios_servicios_sub.id_tipo_facturacion = vw_tarifas.id_tipo_facturacion and vw_usuarios_servicios_sub.id_servicios_velocidades = vw_tarifas.id_servicios_velocidad" +
                                                          " and vw_usuarios_servicios_sub.id_servicios_velocidades_tip = vw_tarifas.id_servicio_velocidad_tip and vw_tarifas.id_servicios_tarifas = {0}" +
                                                          " where(vw_usuarios_servicios_sub.id_servicios_estados = {1} or vw_usuarios_servicios_sub.id_servicios_estados = {2}) and vw_usuarios_servicios_sub.factura_mensualmente = 'SI' and vw_usuarios_servicios_sub.id_servicios_sub_tipos!={3} and vw_usuarios_servicios_sub.borrado=0" +
                                                          " group by vw_usuarios_servicios_sub.id ORDER BY usuario_codigo asc ",
                                                          idTarifa, Convert.ToInt32(Servicios.Servicios_Estados.CONECTADO), Convert.ToInt32(Servicios.Servicios_Estados.EN_ESPERA), Convert.ToInt32(Servicios_Sub.SERVICIO_SUB_TIPOS.DERECHO_DE_CONEXION));
                    }
                }
                else
                {
                    if (contemplarServiciosNoFacturablesMensual)
                    {
                        if (debitos)
                        {
                            consulta = String.Format("select vw_usuarios_servicios_sub.*, vw_tarifas.importe as importe_original, vw_tarifas.importe as importe_con_descuento, vw_tarifas.id_servicios_tarifas "
                                + " from  vw_usuarios_servicios_sub inner join vw_tarifas on vw_usuarios_servicios_sub.id_servicios_sub = vw_tarifas.id_servicios_sub"
                                + " and vw_tarifas.tiposub = 'S' and vw_usuarios_servicios_sub.id_tipo_facturacion = vw_tarifas.id_tipo_facturacion and vw_usuarios_servicios_sub.id_servicios_velocidades = vw_tarifas.id_servicios_velocidad"
                                + " and vw_usuarios_servicios_sub.id_servicios_velocidades_tip = vw_tarifas.id_servicio_velocidad_tip and vw_tarifas.id_servicios_tarifas = {0}"
                                + " where(vw_usuarios_servicios_sub.id_servicios_estados = {1} or vw_usuarios_servicios_sub.id_servicios_estados = {2}) and vw_usuarios_servicios_sub.id_servicios_sub_tipos!={3} and vw_usuarios_servicios_sub.borrado=0"
                                + " AND vw_usuarios_servicios_sub.id_usuarios_servicios IN("
                                + "     SELECT plasticos_usuarios.id_usuarios_servicios"
                                + "     FROM plasticos_usuarios"
                                + "     where plasticos_usuarios.activo=1 and date(plasticos_usuarios.fecha_inicio)<=date('{4}') and plasticos_usuarios.borrado=0"
                                + " )"
                                + " group by vw_usuarios_servicios_sub.id ORDER BY usuario_codigo asc ",
                               idTarifa, Convert.ToInt32(Servicios.Servicios_Estados.CONECTADO), Convert.ToInt32(Servicios.Servicios_Estados.EN_ESPERA), Convert.ToInt32(Servicios_Sub.SERVICIO_SUB_TIPOS.DERECHO_DE_CONEXION), "" + fechaInicioServicio.Year + "-" + fechaInicioServicio.Month + "-" + fechaInicioServicio.Day);
                        }
                        else
                        {
                            consulta = string.Format("select usuarios_servicios_sub.id , usuarios_servicios_sub.id_usuarios_servicios ,usuarios_servicios_sub.id_servicios_sub, usuarios_servicios.id_tipo_facturacion,"
                                        + " servicios_tipos.id_servicios_grupos , servicios.id_servicios_tipos, servicios_sub.id_servicios, usuarios_servicios_sub.id_servicios_velocidades,"
                                        + " usuarios_servicios_sub.id_servicios_velocidades_tip,'S' AS 'tipo_servicio_sub', usuarios_servicios.cant_bocas_pac, servicios.descripcion as servicio,"
                                        + " servicios_sub.descripcion as servicio_sub, IF((ISNULL(`servicios_velocidades`.`Velocidad`) = 1), '-', CONCAT(CAST(`servicios_velocidades`.`Velocidad` AS char(50) CHARSET utf8), ' MB')) AS 'velocidad',"
                                        + " IF((ISNULL(`servicios_velocidades_tip`.`Nombre`) = 1), '-', `servicios_velocidades_tip`.`Nombre`) AS 'velocidad_tipo',"
                                        + " usuarios_servicios_sub.nombre_bonificacion_aplicacion, usuarios_servicios_sub.id_ip_fija, servicios_sub.id_servicios_sub_tipos,"
                                        + " T.importe as importe_original , T.importe as importe_con_descuento, usuarios_servicios.id_usuarios,"
                                        + " usuarios_servicios.id_usuarios_locaciones, usuarios_servicios_sub.fecha_fin, T.id_servicios_tarifas,"
                                        + " usuarios_servicios_sub.requiere_ip, servicios_sub_tipos.cobro_unico, usuarios_servicios.meses_cobro, usuarios_servicios.meses_servicio,"
                                        + " servicios.id_servicios_modalidad, usuarios_locaciones.calle, usuarios_locaciones.altura, CONCAT('Piso:', `usuarios_locaciones`.`Piso`) AS 'piso',"
                                        + " CONCAT('Depto.:', `usuarios_locaciones`.`Depto`) AS 'depto', localidades.nombre as localidad, "
                                        + " CONCAT(`usuarios`.`Apellido`, ' ', `usuarios`.`Nombre`) AS 'usuario', usuarios.Codigo AS 'usuario_codigo', usuarios_servicios.fecha_factura,"
                                        + " usuarios_servicios.id_servicios_estados, usuarios_locaciones.id_localidades, usuarios_servicios_sub.id_bonificacion_esp, servicios.factura_mensualmente"
                                        + " from usuarios_servicios_sub"
                                        + " left join usuarios_servicios on usuarios_servicios.id = usuarios_servicios_sub.id_usuarios_servicios"
                                        + " left join usuarios on usuarios.id = usuarios_servicios.id_usuarios"
                                        + " left join servicios_sub on servicios_sub.id = usuarios_servicios_sub.id_servicios_sub"
                                        + " left join servicios_tipos on servicios_tipos.id = usuarios_servicios.id_servicios_tipo"
                                        + " left join servicios on servicios.id = usuarios_servicios.id_servicios"
                                        + " left join servicios_sub_tipos on servicios_sub.Id_Servicios_Sub_Tipos = servicios_sub_tipos.Id"
                                        + " left join servicios_velocidades on servicios_velocidades.id = usuarios_servicios_sub.id_servicios_velocidades"
                                        + " left join servicios_velocidades_tip on servicios_velocidades_tip.id = usuarios_servicios_sub.id_servicios_velocidades_tip"
                                        + " left join usuarios_locaciones on usuarios_locaciones.id = usuarios_servicios.id_usuarios_locaciones"
                                        + " left join localidades on localidades.id = usuarios_locaciones.id_localidades"
                                        + " inner join (select servicios_tarifas_sub.id_servicios_tarifas ,servicios_tarifas_sub.importe, servicios_tarifas_sub.id_tabla_tipo as id_servicios_sub,"
                                        + " servicios_tarifas_sub.tipo as tiposub, servicios_tarifas_sub.id_tipo_facturacion, 0 as id_servicios_velocidad, 0 as id_servicio_velocidad_tip"
                                        + " from servicios_tarifas_sub"
                                        + " UNION ALL"
                                        + " select servicios_tarifas_sub_esp.id_servicios_tarifas,"
                                        + " (CASE `servicios_tarifas_sub_esp`.`Id_Servicios_Base` WHEN 0 THEN `servicios_tarifas_sub_esp`.`Importe` ELSE(SELECT(SUM(`servicios_tarifas_sub`.`Importe`) * `servicios_tarifas_sub_esp`.`Meses_Cobro`) FROM `servicios_tarifas_sub` WHERE((`servicios_tarifas_sub`.`Id_Servicios` = `servicios_tarifas_sub_esp`.`Id_Servicios_Base`)"
                                        + " AND(`servicios_tarifas_sub`.`Tipo` = 'S')"
                                        + " AND(`servicios_tarifas_sub`.`Id_Tipo_Facturacion` = `servicios_tarifas_sub_esp`.`Id_Tipo_Facturacion`)"
                                        + " AND(`servicios_tarifas_sub`.`Id_Servicios_Tarifas` = `servicios_tarifas_sub_esp`.`Id_Servicios_Tarifas`))) END) AS 'importe',"
                                        + " servicios_sub.id as id_servicios_sub, 'S' as tiposub, servicios_tarifas_sub_esp.id_tipo_facturacion ,"
                                        + " servicios_tarifas_sub_esp.id_servicios_velocidad, servicios_tarifas_sub_esp.id_servicios_velocidad_tip as id_servicio_velocidad_tip"
                                        + " from servicios_tarifas_sub_esp"
                                        + " LEFT JOIN servicios_sub ON servicios_sub.Id = servicios_tarifas_sub_esp.Id_Servicios_Sub) as T  "
                                        + " on T.id_servicios_sub = usuarios_servicios_sub.id_servicios_sub"
                                        + " and T.tiposub = 'S' and usuarios_servicios.id_tipo_facturacion = T.id_tipo_facturacion and usuarios_servicios_sub.id_servicios_velocidades = T.id_servicios_velocidad"
                                        + " and usuarios_servicios_sub.id_servicios_velocidades_tip = T.id_servicio_velocidad_tip and T.id_servicios_tarifas = {0}"
                                        + " where usuarios.id = {1} and usuarios_servicios_sub.borrado = 0"
                                        + " and(usuarios_servicios.id_servicios_estados = {2} or usuarios_servicios.id_servicios_estados = {3} or usuarios_servicios.id_servicios_estados = {4})"
                                        + " and servicios_sub.id_servicios_sub_tipos != {5}"
                                        + " group by usuarios_servicios_sub.id order by usuarios.codigo asc",
                                        idTarifa, idUsuario, Convert.ToInt32(Servicios.Servicios_Estados.CONECTADO), Convert.ToInt32(Servicios.Servicios_Estados.EN_ESPERA),
                                        Convert.ToInt32(Servicios.Servicios_Estados.SIN_CONECTAR), Convert.ToInt32(Servicios_Sub.SERVICIO_SUB_TIPOS.DERECHO_DE_CONEXION));
                        }

                    }
                    else
                    {
                        if (debitos)
                        {
                            consulta = String.Format("select vw_usuarios_servicios_sub.*, vw_tarifas.importe as importe_original, vw_tarifas.importe as importe_con_descuento, vw_tarifas.id_servicios_tarifas"
                                 + " from vw_usuarios_servicios_sub"
                                 + " inner join vw_tarifas on vw_usuarios_servicios_sub.id_servicios_sub = vw_tarifas.id_servicios_sub"
                                 + " and vw_tarifas.tiposub = 'S'"
                                 + " and vw_usuarios_servicios_sub.id_tipo_facturacion = vw_tarifas.id_tipo_facturacion"
                                 + " and vw_usuarios_servicios_sub.id_servicios_velocidades = vw_tarifas.id_servicios_velocidad"
                                 + " and vw_usuarios_servicios_sub.id_servicios_velocidades_tip = vw_tarifas.id_servicio_velocidad_tip"
                                 + " and vw_tarifas.id_servicios_tarifas = {0}"
                                 + " where(vw_usuarios_servicios_sub.id_servicios_estados = {1} or vw_usuarios_servicios_sub.id_servicios_estados = {2}) and vw_usuarios_servicios_sub.factura_mensualmente = 'SI' and vw_usuarios_servicios_sub.id_servicios_sub_tipos !={3}"
                                 + " and vw_usuarios_servicios_sub.borrado = 0 AND vw_usuarios_servicios_sub.id_usuarios_servicios"
                                 + " IN("
                                 + "     SELECT plasticos_usuarios.id_usuarios_servicios"
                                 + "     FROM plasticos_usuarios"
                                 + "     WHERE plasticos_usuarios.activo=1 and date(plasticos_usuarios.fecha_inicio)<=date('{4}') and plasticos_usuarios.borrado=0)"
                                 + " )"
                                 + " group by vw_usuarios_servicios_sub.id ORDER BY usuario_codigo asc",
                                 idTarifa, Convert.ToInt32(Servicios.Servicios_Estados.CONECTADO), Convert.ToInt32(Servicios.Servicios_Estados.EN_ESPERA), Convert.ToInt32(Servicios_Sub.SERVICIO_SUB_TIPOS.DERECHO_DE_CONEXION), "" + fechaInicioServicio.Year + "-" + fechaInicioServicio.Month + "-" + fechaInicioServicio.Day);
                        }
                        else
                        {
                            consulta = String.Format("select vw_usuarios_servicios_sub.*, vw_tarifas.importe as importe_original, vw_tarifas.importe as importe_con_descuento, vw_tarifas.id_servicios_tarifas "
                                + " from  vw_usuarios_servicios_sub inner join vw_tarifas on vw_usuarios_servicios_sub.id_servicios_sub = vw_tarifas.id_servicios_sub"
                                + " and vw_tarifas.tiposub = 'S' and vw_usuarios_servicios_sub.id_tipo_facturacion = vw_tarifas.id_tipo_facturacion and vw_usuarios_servicios_sub.id_servicios_velocidades = vw_tarifas.id_servicios_velocidad"
                                + " and vw_usuarios_servicios_sub.id_servicios_velocidades_tip = vw_tarifas.id_servicio_velocidad_tip and vw_tarifas.id_servicios_tarifas = {0}"
                                + " where(vw_usuarios_servicios_sub.id_servicios_estados = {1} or vw_usuarios_servicios_sub.id_servicios_estados = {2}) and vw_usuarios_servicios_sub.factura_mensualmente = 'SI' and vw_usuarios_servicios_sub.id_servicios_sub_tipos!={3} and vw_usuarios_servicios_sub.borrado=0"
                                + " group by vw_usuarios_servicios_sub.id ORDER BY usuario_codigo asc ",
                                idTarifa, Convert.ToInt32(Servicios.Servicios_Estados.CONECTADO), Convert.ToInt32(Servicios.Servicios_Estados.EN_ESPERA), Convert.ToInt32(Servicios_Sub.SERVICIO_SUB_TIPOS.DERECHO_DE_CONEXION));
                        }
                    }
                }

                //       if (idUsuario > 0)
                //          consulta = String.Format("select * from({0})subservicios where id_usuarios ={1}", consulta, idUsuario);


                oCon.CrearComando(consulta);


                dt = oCon.Tabla();

                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }


            if (dt.Rows.Count > 0)
            {
                dtv = new DataView(dt);
                if (idUsuario > 0)
                    dtv.RowFilter = String.Format("id_usuarios={0}", idUsuario);
                dt = dtv.ToTable();
                foreach (DataRow filaDb in dt.Rows)
                {
                    fila = dtEstructuraBonificaciones.NewRow();
                    fila["id_usuario_servicio"] = filaDb["id_usuarios_servicios"];
                    fila["id_usuario_servicio_sub"] = filaDb["id"];
                    fila["id_tipo_facturacion"] = filaDb["id_tipo_facturacion"];
                    fila["id_grupo"] = filaDb["id_servicios_grupos"];
                    fila["id_servicio_tipo"] = filaDb["id_servicios_tipos"];
                    fila["id_servicio"] = filaDb["id_servicios"];
                    fila["id_servicio_sub"] = filaDb["id_servicios_sub"];
                    fila["id_velocidad"] = filaDb["id_servicios_velocidades"];
                    fila["id_velocidad_tipo"] = filaDb["id_servicios_velocidades_tip"];
                    fila["tipo_servicio_sub"] = filaDb["tipo_servicio_sub"].ToString().ToUpper();
                    fila["cant_bocas_pac"] = filaDb["cant_bocas_pac"];
                    fila["servicio"] = filaDb["servicio"];
                    fila["subservicio"] = filaDb["servicio_sub"];
                    fila["velocidad"] = filaDb["velocidad"];
                    fila["velocidad_tipo"] = filaDb["velocidad_tipo"];
                    fila["nombre_bonificacion"] = filaDb["nombre_bonificacion_aplicacion"];
                    fila["id_ip_fija"] = filaDb["id_ip_fija"];
                    fila["id_tipo_de_sub"] = filaDb["id_servicios_sub_tipos"];
                    fila["importe_original"] = filaDb["importe_original"];
                    fila["importe_con_descuento"] = filaDb["importe_con_descuento"];
                    fila["id_usuarios"] = filaDb["id_usuarios"];
                    fila["id_usuarios_locaciones"] = filaDb["id_usuarios_locaciones"];
                    fila["fecha_factura"] = Convert.ToDateTime(filaDb["fecha_fin"]).ToString("yyyy-MM-dd");
                    fila["id_servicios_tarifas"] = filaDb["id_servicios_tarifas"];
                    fila["requiere_ip"] = Convert.ToInt32(filaDb["requiere_ip"]);
                    fila["cobro_unico"] = filaDb["cobro_unico"];
                    fila["meses_cobro"] = filaDb["meses_cobro"];
                    fila["meses_servicio"] = filaDb["meses_servicio"];
                    fila["id_servicio_modalidad"] = filaDb["id_servicios_modalidad"];
                    fila["calle"] = filaDb["calle"];
                    fila["altura"] = filaDb["altura"];
                    fila["piso"] = filaDb["piso"];
                    fila["depto"] = filaDb["depto"];
                    fila["localidad"] = filaDb["localidad"];
                    fila["usuario"] = filaDb["usuario"];
                    fila["codigo_usuario"] = filaDb["usuario_codigo"];
                    fila["fecha_inicio_servicio"] = fechaInicioServicio.ToString("yyyy-MM-dd");
                    try
                    {
                        fila["fecha_factura"] = Convert.ToDateTime(filaDb["fecha_fin"]).ToString("yyyy-MM-dd");
                    }
                    catch
                    {
                        fila["fecha_factura"] = filaDb["fecha_fin"];
                    }
                    fila["fecha_factura_servicio"] = filaDb["fecha_factura"];
                    fila["id_servicios_estados"] = filaDb["id_servicios_estados"];
                    fila["id_localidad"] = filaDb["id_localidades"];
                    fila["id_bonificacion_especial"] = filaDb["id_bonificacion_esp"];
                    if (Convert.ToInt32(fila["id_servicio_modalidad"]) == Convert.ToInt32(Servicios._Modalidad.MENSUAL) || Convert.ToInt32(fila["id_servicio_modalidad"]) == Convert.ToInt32(Servicios._Modalidad.PERIODO))
                        fila["fecha_hasta_servicio"] = fechaInicioServicio.AddMonths(Convert.ToInt32(fila["meses_servicio"])).AddDays(-1);
                    else
                        fila["fecha_hasta_servicio"] = fechaInicioServicio;
                    fila["factura_mensualmente"] = filaDb["factura_mensualmente"];
                    dtEstructuraBonificaciones.Rows.Add(fila);
                }
            }

            return dtEstructuraBonificaciones;
        }

        public DataTable RetornarSubServiciosFacturacionMensual(int idTarifa, int idUsuario, DateTime fechaInicioServicio, bool contemplarServiciosCortados, bool contemplarServiciosNoFacturablesMensual, bool debitos = false, int cantidad = 0)
        {
            string consulta = String.Empty;
            string consulta2 = String.Empty;
            string filtro = String.Empty;
            string condiciones = String.Empty;
            string condicionesDebito = String.Empty;
            string agrupar = String.Empty;
            DataTable dtEstructuraBonificaciones = new DataTable();
            Bonificaciones oBonificaciones = new Bonificaciones();
            dtEstructuraBonificaciones = oBonificaciones.GenerarDtSubServicios();
            DataRow fila;
            DataTable dt = new DataTable();
            DataView dtv;
            try
            {
                oCon.Conectar();
                consulta2 = string.Format("SELECT usuarios_servicios_sub.Id AS id, usuarios_servicios_sub.Id_Usuarios_Servicios AS id_usuarios_servicios, usuarios_servicios_sub.Id_Servicios_Sub AS id_servicios_sub,servicios_sub.Id_Servicios_Sub_Tipos AS id_servicios_sub_tipos,servicios_sub.Id_Servicios AS id_servicios,"
                    + " servicios.Id_Servicios_Tipos AS id_servicios_tipos,servicios.Id_Servicios_Modalidad AS id_servicios_modalidad,servicios.Id_Servicios_Ejecutable AS id_servicios_ejecutable,servicios_tipos.Id_Servicios_Grupos AS id_servicios_grupos, usuarios_servicios_sub.Id_Servicios_Velocidades AS id_servicios_velocidades,"
                    + " usuarios_servicios_sub.Id_Servicios_Velocidades_Tip AS id_servicios_velocidades_tip,usuarios_servicios_sub.Requiere_IP AS requiere_ip,usuarios_servicios_sub.Id_Ip_fija AS id_ip_fija,usuarios_servicios_sub.Id_Bonificacion_Esp AS id_bonificacion_esp,usuarios_servicios_sub.Id_Bonificacion_Aplicada AS id_bonificacion_aplicada,usuarios_servicios_sub.Porcentaje_Bonificacion_Aplicada AS porcentaje_bonificacion_aplicada,usuarios_servicios_sub.Nombre_Bonificacion_Aplicacion AS nombre_bonificacion_aplicacion,"
                    + " usuarios_servicios_sub.fecha_desde,usuarios_servicios_sub.fecha_hasta, usuarios_servicios_sub.fecha_inicio,usuarios_servicios_sub.fecha_fin,usuarios_servicios.Id_Usuarios AS id_usuarios,usuarios_servicios.Id_Usuarios_Locaciones AS id_usuarios_locaciones,"
                    + " usuarios_servicios.Id_Tipo_Facturacion AS id_tipo_facturacion,usuarios_servicios.Fecha_Factura AS fecha_factura,usuarios_servicios.cant_bocas,usuarios_servicios.Cant_Bocas_Pac AS cant_bocas_pac,usuarios_servicios.Id_Servicios_Estados AS id_servicios_estados,usuarios_servicios.Meses_Servicio AS meses_servicio,"
                    + " usuarios_servicios.Meses_Cobro AS meses_cobro,usuarios_locaciones.Id_Localidades AS id_localidades,servicios_sub.Descripcion AS servicio_sub,servicios_sub.Valor_Defecto AS valor_defecto,servicios_sub.id_iva_alicuotas,servicios_sub_tipos.Nombre AS servicio_sub_tipo,servicios_sub_tipos.Cobro_Unico AS cobro_unico,"
                    + " IF((ISNULL(`servicios_velocidades`.`Velocidad`) = 1), '-', CONCAT(CAST(`servicios_velocidades`.`Velocidad` AS char(50) CHARSET utf8), ' MB')) AS 'velocidad', IF((ISNULL(servicios_velocidades_tip.Nombre) = 1), '-', servicios_velocidades_tip.Nombre) AS velocidad_tipo,servicios.Codigo AS servicio_codigo,servicios.Descripcion AS servicio,"
                    + " servicios.Requiere_Equipo AS requiere_equipo,servicios.Requiere_Tarjeta AS requiere_tarjeta,servicios.Requiere_Velocidad AS requiere_velocidad,servicios.TipoCorte AS tipocorte,servicios.CorteAutomatico AS corteautomatico,servicios.Factura_Mensualmente AS factura_mensualmente,servicios_modalidad.Nombre AS servicio_modalidad,"
                    + " IF(((SELECT `configuracion`.`Valor_N` FROM `configuracion` WHERE(`configuracion`.`Id` = 10)) = 1), (SELECT `zonas`.`Nombre` FROM `zonas` WHERE(`zonas`.`Id` = `usuarios_servicios`.`Id_Tipo_Facturacion`)), (SELECT `servicios_categorias`.`Nombre` FROM `servicios_categorias` WHERE(`servicios_categorias`.`Id` = `usuarios_servicios`.`Id_Tipo_Facturacion`))) AS 'tipo_facturacion',"
                    + " servicios_tipos.Nombre AS servicio_tipo,servicios_grupos.Nombre AS servicio_grupo,usuarios.Codigo AS usuario_codigo,CONCAT(usuarios.Apellido,', ', usuarios.Nombre) AS usuario,usuarios.Apellido AS usuarios_apellido,usuarios.Nombre AS usuarios_nombre,usuarios_locaciones.Calle AS calle,usuarios_locaciones.Altura AS altura,"
                    + " CONCAT('Piso: ', usuarios_locaciones.Piso) AS piso,CONCAT('Depto.: ', usuarios_locaciones.Depto) AS depto,localidades.Nombre AS localidad,'S' AS tipo_servicio_sub,usuarios.Calculo_Bonificacion AS calculo_bonificacion,usuarios_servicios_sub.Borrado AS borrado,usuarios.Impuesto_Provincial AS impuesto_provincial,usuarios.Id_Comprobantes_Iva AS id_comprobantes_iva,"
                    + " vw_tarifas.importe as importe_original, vw_tarifas.importe as importe_con_descuento, vw_tarifas.id_servicios_tarifas FROM usuarios_servicios_sub"
                    + " LEFT JOIN servicios_sub ON usuarios_servicios_sub.Id_Servicios_Sub = servicios_sub.Id"
                    + " LEFT JOIN usuarios_servicios ON usuarios_servicios_sub.Id_Usuarios_Servicios = usuarios_servicios.Id"
                    + " LEFT JOIN usuarios ON usuarios_servicios.Id_Usuarios = usuarios.Id"
                    + " LEFT JOIN servicios ON usuarios_servicios.Id_Servicios = servicios.Id"
                    + " LEFT JOIN servicios_modalidad ON servicios.Id_Servicios_Modalidad = servicios_modalidad.Id"
                    + " LEFT JOIN servicios_sub_tipos ON servicios_sub.Id_Servicios_Sub_Tipos = servicios_sub_tipos.Id"
                    + " LEFT JOIN servicios_velocidades ON usuarios_servicios_sub.Id_Servicios_Velocidades = servicios_velocidades.Id"
                    + " LEFT JOIN servicios_velocidades_tip ON usuarios_servicios_sub.Id_Servicios_Velocidades_Tip = servicios_velocidades_tip.Id"
                    + " LEFT JOIN usuarios_locaciones ON usuarios_servicios.Id_Usuarios_Locaciones = usuarios_locaciones.Id"
                    + " LEFT JOIN localidades ON usuarios_locaciones.Id_Localidades = localidades.Id"
                    + " LEFT JOIN servicios_tipos ON servicios.Id_Servicios_Tipos = servicios_tipos.Id"
                    + " LEFT JOIN servicios_grupos ON servicios_tipos.Id_Servicios_Grupos = servicios_grupos.Id"
                    + " INNER JOIN vw_tarifas on usuarios_servicios_sub.id_servicios_sub = vw_tarifas.id_servicios_sub"
                    + " and vw_tarifas.tiposub = 'S' and usuarios_servicios.id_tipo_facturacion = vw_tarifas.id_tipo_facturacion "
                    + " and usuarios_servicios_sub.id_servicios_velocidades = vw_tarifas.id_servicios_velocidad"
                    + " and usuarios_servicios_sub.id_servicios_velocidades_tip = vw_tarifas.id_servicio_velocidad_tip and vw_tarifas.id_servicios_tarifas = {0}", idTarifa);

                condiciones = string.Format(" where(usuarios_servicios.id_servicios_estados ={0} or usuarios_servicios.id_servicios_estados = {1}) and servicios_sub.id_servicios_sub_tipos !={2} and usuarios_servicios_sub.borrado = 0", Convert.ToInt32(Servicios.Servicios_Estados.CONECTADO), Convert.ToInt32(Servicios.Servicios_Estados.EN_ESPERA), Convert.ToInt32(Servicios_Sub.SERVICIO_SUB_TIPOS.DERECHO_DE_CONEXION));

                consulta2 = consulta2 + condiciones;

                condicionesDebito = string.Format(" AND usuarios_servicios_sub.id_usuarios_servicios IN("
                    + "     SELECT plasticos_usuarios.id_usuarios_servicios"
                    + "     FROM plasticos_usuarios"
                    + "     LEFT JOIN plasticos ON plasticos.Id = plasticos_usuarios.id_plastico"
                    + "     LEFT JOIN usuarios_servicios ON usuarios_servicios.Id = plasticos_usuarios.id_usuarios_servicios"
                    + "     where plasticos_usuarios.activo = 1 and date(plasticos_usuarios.fecha_inicio) <= date('{0}') and plasticos_usuarios.borrado = 0 AND plasticos.borrado = 0 AND plasticos.activo = 1 AND usuarios_servicios.Borrado = 0"
                    + " )", "" + fechaInicioServicio.Year + "-" + fechaInicioServicio.Month + "-" + fechaInicioServicio.Day);

                if (debitos)
                    consulta2 = consulta2 + condicionesDebito;

                if (!contemplarServiciosNoFacturablesMensual)
                    condiciones = condiciones + "AND servicios.Factura_Mensualmente = 'SI' ";


                if (idUsuario > 0)
                    consulta2 = consulta2 + String.Format(" AND usuarios_servicios.id_usuarios ={0}", idUsuario);

                if (idUsuario == 0 && cantidad > 0)
                    consulta2 = consulta2 + String.Format(" order by usuarios.codigo asc LIMIT {0}", cantidad);

                oCon.CrearComando(consulta2);


                dt = oCon.Tabla();

                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }


            if (dt.Rows.Count > 0)
            {

                foreach (DataRow filaDb in dt.Rows)
                {
                    fila = dtEstructuraBonificaciones.NewRow();
                    fila["id_usuario_servicio"] = filaDb["id_usuarios_servicios"];
                    fila["id_usuario_servicio_sub"] = filaDb["id"];
                    fila["id_tipo_facturacion"] = filaDb["id_tipo_facturacion"];
                    fila["id_grupo"] = filaDb["id_servicios_grupos"];
                    fila["id_servicio_tipo"] = filaDb["id_servicios_tipos"];
                    fila["id_servicio"] = filaDb["id_servicios"];
                    fila["id_servicio_sub"] = filaDb["id_servicios_sub"];
                    fila["id_velocidad"] = filaDb["id_servicios_velocidades"];
                    fila["id_velocidad_tipo"] = filaDb["id_servicios_velocidades_tip"];
                    fila["tipo_servicio_sub"] = filaDb["tipo_servicio_sub"].ToString().ToUpper();
                    fila["cant_bocas_pac"] = filaDb["cant_bocas_pac"];
                    fila["servicio"] = filaDb["servicio"];
                    fila["subservicio"] = filaDb["servicio_sub"];
                    fila["velocidad"] = filaDb["velocidad"];
                    fila["velocidad_tipo"] = filaDb["velocidad_tipo"];
                    fila["nombre_bonificacion"] = filaDb["nombre_bonificacion_aplicacion"];
                    fila["id_ip_fija"] = filaDb["id_ip_fija"];
                    fila["id_tipo_de_sub"] = filaDb["id_servicios_sub_tipos"];
                    fila["importe_original"] = filaDb["importe_original"];
                    fila["importe_con_descuento"] = filaDb["importe_con_descuento"];
                    fila["id_usuarios"] = filaDb["id_usuarios"];
                    fila["id_usuarios_locaciones"] = filaDb["id_usuarios_locaciones"];
                    fila["fecha_factura"] = Convert.ToDateTime(filaDb["fecha_fin"]).ToString("yyyy-MM-dd");
                    fila["id_servicios_tarifas"] = filaDb["id_servicios_tarifas"];
                    fila["requiere_ip"] = Convert.ToInt32(filaDb["requiere_ip"]);
                    fila["cobro_unico"] = filaDb["cobro_unico"];
                    fila["meses_cobro"] = filaDb["meses_cobro"];
                    fila["meses_servicio"] = filaDb["meses_servicio"];
                    fila["id_servicio_modalidad"] = filaDb["id_servicios_modalidad"];
                    fila["calle"] = filaDb["calle"];
                    fila["altura"] = filaDb["altura"];
                    fila["piso"] = filaDb["piso"];
                    fila["depto"] = filaDb["depto"];
                    fila["localidad"] = filaDb["localidad"];
                    fila["usuario"] = filaDb["usuario"];
                    fila["codigo_usuario"] = filaDb["usuario_codigo"];
                    fila["fecha_inicio_servicio"] = fechaInicioServicio.ToString("yyyy-MM-dd");
                    try
                    {
                        fila["fecha_factura"] = Convert.ToDateTime(filaDb["fecha_fin"]).ToString("yyyy-MM-dd");
                    }
                    catch
                    {
                        fila["fecha_factura"] = filaDb["fecha_fin"];
                    }
                    fila["fecha_factura_servicio"] = filaDb["fecha_factura"];
                    fila["id_servicios_estados"] = filaDb["id_servicios_estados"];
                    fila["id_localidad"] = filaDb["id_localidades"];
                    fila["id_bonificacion_especial"] = filaDb["id_bonificacion_esp"];
                    if (Convert.ToInt32(fila["id_servicio_modalidad"]) == Convert.ToInt32(Servicios._Modalidad.MENSUAL) || Convert.ToInt32(fila["id_servicio_modalidad"]) == Convert.ToInt32(Servicios._Modalidad.PERIODO))
                        fila["fecha_hasta_servicio"] = fechaInicioServicio.AddMonths(Convert.ToInt32(fila["meses_servicio"])).AddDays(-1);
                    else
                        fila["fecha_hasta_servicio"] = fechaInicioServicio;
                    fila["factura_mensualmente"] = filaDb["factura_mensualmente"];
                    fila["tipo_fac"] = filaDb["tipo_facturacion"];
                    dtEstructuraBonificaciones.Rows.Add(fila);
                }

            }

            return dtEstructuraBonificaciones;
        }

        public DataTable AplicarNovedades(DataTable dtSubServicios, DataTable dtRegistrosSubServCtaCteDetalle, int idLocacion, DateTime fechaDesde, bool facMensual)
        {
            DateTime fechaDesdeSubServ = new DateTime();
            DateTime fechaHastaSubServ = new DateTime();
            decimal importeDescuento;
            decimal importeDescuentoTotal;
            DataRow[] drNovedadesSubServicio;
            DataTable dtNovedades = new DataTable();
            Usuarios_Servicios_Novedades oUsuariosServiciosNovedades = new Usuarios_Servicios_Novedades();
            Bonificaciones oBonificaciones = new Bonificaciones();
            DataTable dtDatosCalculoRetornados = new DataTable();
            decimal ImporteOriginalTotalSubServicios = 0;
            decimal ImporteDescuentoTotalSubServicios = 0;
            int mesesCobro = 0;
            int idTarifa = 0;
            int idServicio = 0;
            int idTipoFacturacion = 0;
            int idNovedadAplicar = 0;
            decimal porcentajeNovedad = 0;
            string Detalle = String.Empty;
            dtExtras = GetEstructuraExtra();
            dtDatosCalculoRetornados.Columns.Add("fecha_factura_ultima", typeof(string));
            dtDatosCalculoRetornados.Columns.Add("importe_original_total", typeof(string));
            dtDatosCalculoRetornados.Columns.Add("importe_con_descuento_total", typeof(string));

            if (idLocacion > 0)//lista novedades de la locación específica
            {
                oUsuariosServiciosNovedades.Id_Usuarios_Locaciones = idLocacion;
                oUsuariosServiciosNovedades.Tipo_Busqueda = "L";
                dtNovedades = oUsuariosServiciosNovedades.Listar();
            }

            //---Novedades aplicadas a servicios 281119 ----------------------------------------------------------------------------
            int idServicios = 0;
            List<int> listadoServiciosBusquedaNovedades = new List<int>();
            DataTable dtServiciosBusquedaNovedades = new DataTable();
            dtServiciosBusquedaNovedades.Columns.Add("idServicio", typeof(string));
            dtServiciosBusquedaNovedades.Columns.Add("idTipoFacturacion", typeof(string));

            foreach (DataRow fila in dtSubServicios.Rows)
            {
                idServicio = Convert.ToInt32(fila["id_servicio"]);
                if (listadoServiciosBusquedaNovedades.Contains(idServicio) == false)
                {
                    listadoServiciosBusquedaNovedades.Add(idServicio);
                    DataRow drServicio = dtServiciosBusquedaNovedades.NewRow();
                    drServicio["idServicio"] = fila["id_servicio"].ToString();
                    drServicio["idTipoFacturacion"] = fila["id_tipo_facturacion"].ToString();
                    dtServiciosBusquedaNovedades.Rows.Add(drServicio);
                }
            }

            if (dtServiciosBusquedaNovedades.Rows.Count > 0)
            {
                DataTable dtAux = new DataTable();
                foreach (DataRow servicio in dtServiciosBusquedaNovedades.Rows)//añade novedades generales que esten asignadas a los servicios presentes
                {
                    oUsuariosServiciosNovedades.Id_Servicios = Convert.ToInt32(servicio["idServicio"]);
                    oUsuariosServiciosNovedades.id_tipo_facturacion = Convert.ToInt32(servicio["idTipoFacturacion"]);
                    oUsuariosServiciosNovedades.Tipo_Busqueda = "S";
                    dtAux = oUsuariosServiciosNovedades.Listar();
                    if (dtNovedades.Rows.Count == 0)
                        dtNovedades = dtAux.Copy();
                    else
                    {

                        foreach (DataRow fila in dtAux.Rows)
                            dtNovedades.ImportRow(fila);
                    }
                }
            }
            //--------------------------------------------------------------------------------------

            foreach (DataRow SubServ in dtSubServicios.Rows)
            {
                idTarifa = Convert.ToInt32(SubServ["id_servicios_tarifas"]);
                idServicio = Convert.ToInt32(SubServ["id_servicio"]);
                idTipoFacturacion = Convert.ToInt32(SubServ["id_tipo_facturacion"]);
                mesesCobro = 0;

                drNovedadesSubServicio = dtNovedades.Select(String.Format("id_servicios={0}", SubServ["id_servicio"]));

                importeDescuento = 0;

                foreach (DataRow mes in dtRegistrosSubServCtaCteDetalle.Select(String.Format("id_usuarios_servicios_sub='{0}' and tipo_servicio_sub='S' and id_usuarios_servicios_sub_tipos='{1}'", SubServ["id_usuario_servicio_sub"].ToString(), Convert.ToInt16(Servicios_Sub.SERVICIO_SUB_TIPOS.SUBSERVICIO).ToString())))
                {
                    fechaDesdeSubServ = Convert.ToDateTime(mes["fecha_desde"]);
                    importeDescuento = Convert.ToDecimal(mes["importe_con_descuento_parcial"]);
                    if (drNovedadesSubServicio.Count() > 0)
                    {
                        foreach (DataRow novedad in drNovedadesSubServicio)
                        {
                            Detalle = String.Empty;
                            if (
                               (Convert.ToInt32(novedad["id_usuarios_servicios_sub"]) != 0 && Convert.ToInt32(mes["id_usuarios_servicios_sub"]) == Convert.ToInt32(novedad["id_usuarios_servicios_sub"]))
                               ||
                               (Convert.ToInt32(novedad["id_usuarios_servicios_sub"]) == 0 && Convert.ToInt32(novedad["id_usuarios_servicios"]) != 0 && Convert.ToInt32(novedad["id_usuarios_servicios"]) == Convert.ToInt32(mes["id_usuarios_servicios"]))
                               ||
                               (Convert.ToInt32(novedad["id_usuarios_servicios_sub"]) == 0 && Convert.ToInt32(novedad["id_usuarios_servicios"]) == 0 && Convert.ToInt32(novedad["id_servicios_sub"]) != 0 && Convert.ToInt32(novedad["id_servicios_sub"]) == Convert.ToInt32(SubServ["id_servicio_sub"]))
                               ||
                               (Convert.ToInt32(novedad["id_usuarios_servicios_sub"]) == 0 && Convert.ToInt32(novedad["id_usuarios_servicios"]) == 0 && Convert.ToInt32(novedad["id_servicios_sub"]) == 0 && Convert.ToInt32(novedad["id_servicios"]) != 0 && Convert.ToInt32(novedad["id_servicios"]) == Convert.ToInt32(mes["id_servicios"]))

                               )
                            {
                                if ((Convert.ToInt32(novedad["finaliza"]) == 1 && fechaDesdeSubServ >= Convert.ToDateTime(novedad["fecha_desde"]) && fechaDesdeSubServ <= Convert.ToDateTime(novedad["fecha_hasta"])) || (Convert.ToInt32(novedad["finaliza"]) == 0 && fechaDesdeSubServ >= Convert.ToDateTime(novedad["fecha_desde"])))
                                {
                                    DataRow dr = dtRegistrosSubServCtaCteDetalle.NewRow();
                                    dr["id_usuarios_servicios"] = mes["id_usuarios_servicios"];
                                    dr["id_usuarios_servicios_sub"] = mes["id_usuarios_servicios_sub"];
                                    dr["id_usuarios_locaciones"] = mes["id_usuarios_locaciones"];
                                    dr["nro_mes"] = mes["nro_mes"];
                                    dr["meses_cobro"] = mes["meses_cobro"];
                                    dr["meses_servicio"] = mes["meses_servicio"];
                                    dr["fecha_desde"] = Convert.ToDateTime(mes["fecha_desde"]);
                                    dr["fecha_hasta"] = Convert.ToDateTime(mes["fecha_hasta"]);
                                    dr["id_servicios"] = mes["id_servicios"];
                                    dr["id_usuarios_servicios_sub_tipos"] = mes["id_usuarios_servicios_sub_tipos"];
                                    dr["tipo_servicio_sub"] = mes["tipo_servicio_sub"];
                                    dr["requiere_ip"] = 0;
                                    dr["id_servicios_velocidades"] = 0;
                                    dr["id_servicios_velocidades_tipos"] = 0;
                                    dr["borrado"] = mes["borrado"];
                                    dr["id_servicios_modalidad"] = 0;
                                    dr["por_contratacion"] = 0;
                                    dr["nivel_bonificacion_contratacion"] = mes["nivel_bonificacion_contratacion"];
                                    dr["id_servicios_velocidades_contratacion"] = 0;
                                    dr["id_servicios_velocidades_tip_contratacion"] = 0;
                                    dr["id_bonificacion_contratacion"] = mes["id_bonificacion_contratacion"];
                                    dr["fecha_desde_contratacion"] = mes["fecha_desde_contratacion"];
                                    dr["fecha_hasta_contratacion"] = mes["fecha_hasta_contratacion"];
                                    dr["monto_contratacion"] = mes["monto_contratacion"];
                                    dr["tipo_contratacion"] = mes["tipo_contratacion"];
                                    dr["detalle_contratacion"] = novedad["detalle"];
                                    dr["id_usuarios_servicios_contratacion"] = mes["id_usuarios_servicios_contratacion"];
                                    dr["id_usuarios_servicios_sub_contratacion"] = mes["id_usuarios_servicios_sub_contratacion"];
                                    dr["finaliza_contratacion"] = mes["finaliza_contratacion"];
                                    dr["facturable_contratacion"] = mes["facturable_contratacion"];
                                    dr["id_tipo_contratacion"] = mes["id_tipo_contratacion"];
                                    dr["imprime_contratacion"] = mes["imprime_contratacion"];
                                    dr["cantidad_periodos_contratacion"] = mes["cantidad_periodos_contratacion"];
                                    dr["id_usuarios_contratacion"] = mes["id_usuarios_contratacion"];
                                    dr["id_usuarios_locaciones_contratacion"] = mes["id_usuarios_locaciones_contratacion"];
                                    dr["id_servicios_contratacion"] = mes["id_servicios_contratacion"];
                                    dr["id_servicios_sub_contratacion"] = mes["id_servicios_sub_contratacion"];
                                    dr["id_bonificacion"] = mes["id_bonificacion"];
                                    dr["nombre_bonificacion"] = "Novedades";
                                    dr["importe_original"] = 0;
                                    dr["porcentaje"] = mes["porcentaje"];
                                    dr["importe_con_descuento_parcial"] = 0;
                                    dr["porcentaje_parcial"] = mes["porcentaje_parcial"];
                                    dr["porcentaje_contratacion"] = mes["porcentaje_contratacion"];
                                    dr["indice"] = mes["indice"];
                                    dr["subservicio"] = novedad["detalle"];

                                    if (Convert.ToDecimal(novedad["monto"]) != 0)
                                    {
                                        dr["importe_con_descuento"] = Convert.ToDecimal(novedad["monto"]);
                                    }
                                    else
                                    {
                                        dr["importe_con_descuento"] = (importeDescuento + Decimal.Round(((importeDescuento * Convert.ToDecimal(novedad["porcentaje"])) / 100), 0)) - importeDescuento;
                                    }

                                    dr["importe_original"] = Convert.ToDecimal(dr["importe_con_descuento"].ToString());
                                    dtRegistrosSubServCtaCteDetalle.Rows.Add(dr);
                                }
                            }
                        }
                    }
                }
            }

            oBonificaciones.RecalcularImportes(dtSubServicios, dtRegistrosSubServCtaCteDetalle, facMensual);

            foreach (DataRow subServicio in dtSubServicios.Rows)
            {
                ImporteOriginalTotalSubServicios += Convert.ToDecimal(subServicio["importe_original"]);
                ImporteDescuentoTotalSubServicios += Convert.ToDecimal(subServicio["importe_con_descuento"]);
            }
            try
            {
                dtDatosCalculoRetornados.Rows.Add(fechaDesdeSubServ.AddDays(-1), ImporteOriginalTotalSubServicios, ImporteDescuentoTotalSubServicios);
            }
            catch { }
            return dtDatosCalculoRetornados;
        }

        public void ActualizarFechaFacturaSubServicio(int idUsuarioServicioSub, DateTime nuevaFechaFin)
        {
            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();
                oCon.CrearComando("UPDATE usuarios_servicios_sub SET fecha_fin=@fecha_fin  WHERE Id = @id");
                oCon.AsignarParametroFecha("@fecha_fin", nuevaFechaFin);
                oCon.AsignarParametroEntero("@id", idUsuarioServicioSub);
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

        public void ActualizarFechaFacturaSubServicioPrepago(int idUsuarioServicioSub, DateTime nuevaFechaFin,DateTime nuevaFechaInicio)
        {
            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();
                oCon.CrearComando("UPDATE usuarios_servicios_sub SET fecha_inicio = @fecha_inicio , fecha_fin=@fecha_fin  WHERE Id = @id");
                oCon.AsignarParametroFecha("@fecha_inicio", nuevaFechaInicio);
                oCon.AsignarParametroFecha("@fecha_fin", nuevaFechaFin);
                oCon.AsignarParametroEntero("@id", idUsuarioServicioSub);
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

        public DataTable GetEstructuraRetornoComprobanteFactura()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("punto_venta_id", typeof(string));
            dt.Columns.Add("punto_venta_numero", typeof(string));
            dt.Columns.Add("punto_venta_descripcion", typeof(string));
            dt.Columns.Add("respuesta_codigo", typeof(string));
            dt.Columns.Add("respuesta_descripcion", typeof(string));
            dt.Columns.Add("factura_tipo", typeof(string));
            dt.Columns.Add("factura_descripcion", typeof(string));
            return dt;
        }

        public DataTable GetEstructuraExtra()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id_extra", typeof(string));
            dt.Columns.Add("id_tipo_extra", typeof(string));
            dt.Columns.Add("id_usuarios_ctacte_det", typeof(string));
            dt.Columns.Add("id_usuario_servicio_sub", typeof(string));
            dt.Columns.Add("porcentaje", typeof(string));
            dt.Columns.Add("importe_original", typeof(string));
            dt.Columns.Add("importe_nuevo", typeof(string));
            dt.Columns.Add("descripcion_extra", typeof(string));
            dt.Columns.Add("nro_mes", typeof(string));
            dt.Columns.Add("detalle", typeof(string));
            return dt;
        }

        public DataTable[] ListarFacturacionServicio(int tipoDeFiltro, int presentacion, int mostrar, int id_facturacion, string fechaDesde = default(string), string fechaHasta = default(string))
        {
            DataTable[] dt = new DataTable[3];
            try
            {
                oCon.Conectar();

                ////////////////////////////
                // DATATABLE[0] SERVICIOS //
                ////////////////////////////

                string count = string.Empty;
                string groupby = string.Empty;
                string condicion = string.Empty;
            
                if (tipoDeFiltro == 0)
                    condicion = string.Format(" WHERE usuarios_ctacte.id_facturacion = {0}", id_facturacion);
                else if (tipoDeFiltro == 1)
                {
                    condicion = $" WHERE usuarios_ctacte.Id_Comprobantes IN(SELECT id_comprobantes FROM iva_ventas WHERE(iva_ventas.fecha between '{fechaDesde}' AND '{fechaHasta}') AND borrado = 0)";
                    //condicion = string.Format(" WHERE DATE(usuarios_ctacte.fecha_movimiento) BETWEEN '{0}' AND '{1}' AND usuarios_ctacte_det.tipo = 's' ", fechaDesde, fechaHasta);
                }
                else
                    throw new Exception("Tipo de filtro invalido");

                if (presentacion == 0 || presentacion == 1)
                    condicion = string.Format("{0} AND usuarios.presentacion = {1}", condicion, presentacion);

                if (mostrar == 1)
                {
                    count = "id_servicios";
                    groupby = "usuarios_ctacte_det.id_servicios";
                }
                else if (mostrar == 2) ///
                {
                    count = "tipo";
                    groupby = "usuarios_ctacte_det.id_servicios, servicios_sub.id, usuarios_ctacte_det.id_tipo";
                }
                else
                    throw new Exception("Agrupacion invalida");

                condicion = string.Format("{0}  AND usuarios_ctacte_det.id_servicios > 0 AND " +
                    " usuarios_ctacte_det.borrado = 0 AND usuarios_ctacte.borrado = 0", condicion);

                string consulta = string.Format("SELECT servicios.Descripcion as servicios, servicios_sub.Descripcion as subservicio," +
                    "SUM(usuarios_ctacte_det.Importe_Original) as Importe_original, " +
                    "SUM(usuarios_ctacte_det.importe_original + usuarios_ctacte_det.importe_punitorio + usuarios_ctacte_det.importe_provincial - usuarios_ctacte_det.importe_bonificacion) AS 'Importe', " +
                    "SUM(usuarios_ctacte_det.Importe_Bonificacion) as Bonificacion, SUM(usuarios_ctacte_det.Importe_Original + usuarios_ctacte_det.importe_punitorio - usuarios_ctacte_det.Importe_Bonificacion)/1.21 AS Neto, " +
                    " COUNT(usuarios_ctacte_det.{0}) as Cantidad, servicios_velocidades.velocidad as Velocidad_Megas," +
                    "servicios_velocidades_tip.nombre as Tipo_Internet FROM usuarios_ctacte_det " +
                    "LEFT JOIN usuarios_ctacte ON usuarios_ctacte.Id = usuarios_ctacte_det.id_usuarios_ctacte " +
                    "LEFT JOIN servicios ON servicios.Id = usuarios_ctacte_det.id_servicios " +
                    "LEFT JOIN servicios_sub ON servicios_sub.id = usuarios_ctacte_det.id_tipo " +
                    "LEFT JOIN usuarios ON usuarios_ctacte.Id_usuarios = usuarios.Id " +
                    "LEFT JOIN servicios_velocidades ON servicios_velocidades.id = usuarios_ctacte_det.id_velocidades " +
                    "LEFT JOIN servicios_velocidades_tip ON servicios_velocidades_tip.Id = usuarios_ctacte_det.id_velocidades_tip " +
                    "LEFT JOIN comprobantes ON comprobantes.id = usuarios_ctacte.id_comprobantes " +
                    "LEFT JOIN comprobantes_tipo ON comprobantes_tipo.id = comprobantes.id_comprobantes_tipo " +
                    "{1} GROUP BY {2}" +
                    ", servicios_velocidades.velocidad, servicios_velocidades_tip.nombre ORDER BY servicios.Descripcion", count, condicion, groupby);

                oCon.CrearComando(consulta);
                dt[0] = oCon.Tabla();

                //////////////////////////
                // DATATABLE[1] EQUIPOS //
                //////////////////////////

                if (tipoDeFiltro == 1)
                {
                    condicion = string.Empty;
                    condicion = string.Format(" WHERE DATE(usuarios_ctacte.fecha_movimiento) BETWEEN '{0}' AND '{1}' AND usuarios_ctacte_det.tipo = 'E' " +
                        " AND usuarios_ctacte_det.borrado = 0 AND usuarios_ctacte_det.importe_original != 0 ", fechaDesde, fechaHasta);

                    if (presentacion == 0 || presentacion == 1)
                        condicion = string.Format(" {0} AND usuarios.presentacion = {1} ", condicion, presentacion);

                    consulta = string.Empty;
                    consulta = string.Format("SELECT  equipos_tipos.nombre as nombre_equipo, COUNT(usuarios_ctacte_det.id_tipo) as Cantidad ," +
                        "SUM(usuarios_ctacte_det.Importe_Original) as Importe," +
                        "SUM(usuarios_ctacte_det.Importe_Bonificacion) as Bonificacion " +
                        "FROM usuarios_ctacte_det " +
                        "LEFT JOIN equipos_tipos ON equipos_tipos.id = usuarios_ctacte_det.id_tipo " +
                        "LEFT JOIN usuarios_ctacte ON usuarios_ctacte.id = usuarios_ctacte_det.id_usuarios_ctacte " +
                        "LEFT JOIN usuarios ON usuarios.id = usuarios_ctacte.id_usuarios {0} GROUP BY usuarios_ctacte_det.id_tipo " +
                        "ORDER BY equipos_tipos.nombre", condicion);

                    oCon.CrearComando(consulta);
                    dt[1] = oCon.Tabla();

                    /////////////////////////
                    // DATATABLE[2] PARTES //
                    /////////////////////////

                    condicion = string.Empty;
                    condicion = string.Format("WHERE DATE(usuarios_ctacte.fecha_movimiento) BETWEEN '{0}' AND '{1}' " +
                        "AND usuarios_ctacte_det.tipo = 'P' " +
                        "AND usuarios_ctacte_det.borrado = 0 " +
                        "AND partes_fallas.borrado = 0 " +
                        "AND servicios_tipos.borrado = 0 " +
                        "AND usuarios_ctacte_det.importe_original != 0", fechaDesde, fechaHasta);

                    if (presentacion == 0 || presentacion == 1)
                        condicion = string.Format(" {0} AND usuarios.presentacion = {1} ", condicion, presentacion);

                    consulta = string.Empty;
                    consulta = string.Format("SELECT servicios_tipos.Nombre as Servicio ,partes_fallas.nombre as Nombre_Parte," +
                        "SUM(usuarios_ctacte_det.Importe_Original) as Importe," +
                        "SUM(usuarios_ctacte_det.Importe_Bonificacion) as Bonificacion," +
                        "COUNT(usuarios_ctacte_det.id_tipo) as Cantidad " +
                        "FROM usuarios_ctacte_det " +
                        "LEFT JOIN partes_fallas ON partes_fallas.id = usuarios_ctacte_det.id_tipo " +
                        "LEFT JOIN servicios_tipos ON servicios_tipos.id = partes_fallas.id_servicios_tipos " +
                        "LEFT JOIN usuarios_ctacte ON usuarios_ctacte.id = usuarios_ctacte_det.id_usuarios_ctacte " +
                        "LEFT JOIN usuarios ON usuarios.id = usuarios_ctacte.id_usuarios {0} GROUP BY usuarios_ctacte_det.id_tipo ORDER BY servicios_tipos.nombre ", condicion);

                    oCon.CrearComando(consulta);
                    dt[2] = oCon.Tabla();
                }

                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }
            return dt;
        }

        public DataTable BuscarFacturaEmail (string detalleFac)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT usuarios_ctacte.id_usuarios,usuarios.correo_electronico,usuarios_ctacte.id_comprobantes from usuarios_ctacte left join usuarios on usuarios.id=usuarios_ctacte.id_usuarios where usuarios_ctacte.descripcion=@des");
                oCon.AsignarParametroCadena("@des", detalleFac);
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

        public void CargaDtIva(DataTable dtfinal, Facturacion oFacturacion, int Idlocacion, DataTable dtDatosRetorno, ref int codigoRetorno)
        {
            Total_Factura = 0;
            Total_Neto = 0;
            Total_Iva = 0;
            Total_Provincial = 0;

            DataView v1 = dtfinal.DefaultView;

            if (Convert.ToInt32(dtfinal.Rows[0]["id_comprobantes_tipo"]) == (Int32)Comprobantes_Tipo.Tipo.REMITO)
                v1.RowFilter = String.Format("encabezado={0} and importe_pago>{1} and Id_usuarios_locaciones ={2}", 2, 0, Idlocacion);
            else
                v1.RowFilter = String.Format("presenta_ventas = {0} and encabezado={1} and importe_pago>{2} and Id_usuarios_locaciones ={3}", 0, 2, 0, Idlocacion);//de la tabla recibida filtra los registros de ctacte que no presenten ventas y que pertenezcan a una locación específica.

            dtCompDeuda = v1.ToTable();
            dtIvas = oIva_Alicuotas.Listar();

            if (dtCompDeuda.Rows.Count > 0)
            {
                foreach (DataRow Dr in dtfinal.Rows)/// tiene que elegir todos los subservicios se pague o no
                    Dr["elige"] = false;

                foreach (DataRow DrEncabezado in dtCompDeuda.Rows)
                { ///// recorre todos los comprobantes de deuda. Selecciona todas las filas de la tabla dtfinal que compartan el mismo id_usuarios_ctacte
                    foreach (DataRow Dr in dtfinal.Rows)
                    { /// tiene que elegir todos los subservicios se pague o no
                        if (Convert.ToInt32(DrEncabezado["id_usuarios_ctacte"].ToString()) == Convert.ToInt32(Dr["id_usuarios_ctacte"].ToString()))
                            Dr["elige"] = true;
                    }
                }

                ItemFactura = Arma_Detalle_Tipo(dtCompDeuda, dtfinal, oFacturacion);//formatea los datos para luego guardarlos y presentarlos en la factura impresa


                //calcula los iva
                Decimal ÏtemUnitario = 0, ItemPuntorio = 0, ItemBonificacion = 0, ItemTotal = 0, ItemSinImpuestos = 0;
                //   Decimal Total_Factura = 0, Total_Neto = 0, Total_Iva = 0;
                Decimal neto = 0, iva = 0;//, Total_Provincial = 0;
                if (ItemFactura.Rows.Count > 0)
                {
                    foreach (DataRow DrItem in ItemFactura.Rows) ///// recorre todos los comprobantes de deuda. Genera los comprobantes_detalle 
                    {
                        if (Convert.ToInt32(DrItem["Id_Iva_Alicuotas"].ToString()) == 0) ///parche sacar es por si no trae iva
                            DrItem["Id_Iva_Alicuotas"] = Convert.ToInt32(dtIvas.Rows[0]["Id"]);

                        foreach (DataRow drIva in dtIvas.Rows) ///acumula los ivas
                        {
                            if (Convert.ToInt32(drIva["Id"].ToString()) == Convert.ToInt32(DrItem["Id_Iva_Alicuotas"].ToString()))  // busca que iva aplica
                            {
                                ItemSinImpuestos = Convert.ToDecimal(DrItem["total"].ToString());

                                neto = decimal.Round(ItemSinImpuestos / Convert.ToDecimal(drIva["porcentaje_divide"].ToString()), 2);
                                iva = decimal.Round(ItemSinImpuestos - neto, 2);

                                if (Comprobantes_Iva.CurrentComprobantes_Iva.Letra == "A")  // tira el iva para atras = genera neto
                                {
                                    ÏtemUnitario = decimal.Round(ItemSinImpuestos / Convert.ToDecimal(drIva["porcentaje_divide"].ToString()), 2);
                                    ItemPuntorio = decimal.Round(Convert.ToDecimal(DrItem["punitorios"].ToString()) / Convert.ToDecimal(drIva["porcentaje_divide"].ToString()), 2);
                                    ItemBonificacion = decimal.Round(Convert.ToDecimal(DrItem["bonificaciones"].ToString()) / Convert.ToDecimal(drIva["porcentaje_divide"].ToString()), 2);
                                    ItemTotal = decimal.Round(ItemSinImpuestos / Convert.ToDecimal(drIva["porcentaje_divide"].ToString()), 2);
                                }
                                else
                                {
                                    ÏtemUnitario = decimal.Round(ItemSinImpuestos, 2);
                                    ItemPuntorio = decimal.Round(Convert.ToDecimal(DrItem["punitorios"].ToString()), 2);
                                    ItemBonificacion = decimal.Round(Convert.ToDecimal(DrItem["bonificaciones"].ToString()), 2);
                                    ItemTotal = decimal.Round(ItemSinImpuestos, 2);
                                }

                                DrItem["total"] = ÏtemUnitario;
                                DrItem["unitario"] = ÏtemUnitario;
                                DrItem["punitorios"] = ItemPuntorio;
                                DrItem["bonificaciones"] = ItemBonificacion;

                                if (!Convert.ToBoolean(DrItem["suma"].ToString())) //suma los item para el total del pie
                                {

                                    //ACUMULA LOS IVAS
                                    drIva["importe_neto"] = Convert.ToDecimal(drIva["importe_neto"].ToString()) + neto;
                                    drIva["importe_iva"] = Convert.ToDecimal(drIva["importe_iva"].ToString()) + iva;

                                    Total_Provincial = Total_Provincial + decimal.Round(Convert.ToDecimal(DrItem["impuesto"].ToString()), 2);
                                    Total_Neto = Total_Neto + neto;
                                    Total_Iva = Total_Iva + iva;
                                    decimal impuesto = decimal.Round(Convert.ToDecimal(DrItem["impuesto"].ToString()), 2);
                                    Total_Factura = Total_Factura + ItemSinImpuestos + impuesto;

                                }
                            }
                        }
                    }
                    ItemFactura.AcceptChanges();
                }
                else
                {
                    dtDatosRetorno.Rows.Add("Error: Factura sin items ", "", "", Convert.ToInt16(CODIGOS_RESPUESTA_FACTURACION.FACTURA_SIN_ITEMS).ToString(), CODIGOS_RESPUESTA_FACTURACION.FACTURA_SIN_ITEMS.ToString(), "", "");
                    codigoRetorno = Convert.ToInt16(CODIGOS_RESPUESTA_FACTURACION.FACTURA_SIN_ITEMS);
                }
            }
        }

        public DataTable Comprobante_a_Factura(Facturacion oFacturacion, DataTable dtfinal, int Idlocacion, int ptoVenta, bool permitirHacerRemito, bool facturaDeCredito)
        {
            Int32 codigoRetorno = 0;
            int idTipoComprobanteUsuario = 0, numeroComprobanteTipoAfip = 0;
            double docCuit = 0;
            double nroFacturaCAE = 0;
            string CAE = "";
            DataTable dtDatosPuntoVenta = new DataTable();
            DateTime vencimientoCAE = new DateTime();
            DataTable dtDatosUsuario = new DataTable();
            DataTable dtDatosNuevoCAE = new DataTable();
            //INFORMACION DE RETORNO
            DataTable dtDatosRetorno = new DataTable();
            dtDatosRetorno = GetEstructuraRetornoComprobanteFactura();
            hacerRemito = 0;
            trabajaElectronica = false;
            //------------------------------

            idTipoComprobanteUsuario = Comprobantes_Iva.CurrentComprobantes_Iva.Id;

            if (Comprobantes_Iva.CurrentComprobantes_Iva.Id == 1) // consumidor final
                docCuit = Convert.ToDouble(Usuarios.CurrentUsuarioDomFiscal.Numero_Documento.ToString());
            else
                docCuit = Convert.ToDouble(Usuarios.CurrentUsuarioDomFiscal.Cuit.ToString());


            CargaDtIva(dtfinal, oFacturacion, Idlocacion, dtDatosRetorno, ref codigoRetorno);


            if (Total_Neto > 0)
            {
                oComprobante.Id_Usuarios = Usuarios.CurrentUsuario.Id;
                oComprobante.Fecha = DateTime.Today;
                int idTipoComprobante = 0;
                int tipoDocumentoAfip = Ocomprobantes_Iva.GetTipoDocumentoAfip(idTipoComprobanteUsuario);
                if (tipoDocumentoAfip != 0)
                {
                    if (Comprobantes_Iva.CurrentComprobantes_Iva.Letra == "A")
                        dtDatosPuntoVenta = oComprobantesHabilitados.GetDatosPuntoVenta(Convert.ToInt32(Comprobantes_Tipo.Tipo.FACTURA_A), Puntos_Cobros.Id_Punto);
                    else
                        dtDatosPuntoVenta = oComprobantesHabilitados.GetDatosPuntoVenta(Convert.ToInt32(Comprobantes_Tipo.Tipo.FACTURA_B), Puntos_Cobros.Id_Punto);

                    idTipoComprobante = Convert.ToInt32(dtDatosPuntoVenta.Rows[0]["id_comprobantes_tipo"]);
                    numeroComprobanteTipoAfip = oComprobante_Tipo.getNumeroAfip(idTipoComprobante);
                    if (dtDatosPuntoVenta.Rows.Count > 0)
                    {
                        if (Convert.ToInt32(dtDatosPuntoVenta.Rows[0]["punto_venta_id_modalidad_facturacion"]) == 3)
                        {
                            int punto = Convert.ToInt32(dtDatosPuntoVenta.Rows[0]["num_afip"]);
                            trabajaElectronica = true;
                            DataView dv = dtfinal.DefaultView;
                            dv.RowFilter = "elige=true";
                            DataTable dtFinalFiltrada = dv.ToTable();
                            if (facturacionElectronicaMensual == 1)
                                dtDatosCAE.Clear();
                            dtDatosNuevoCAE = Nuevo_Cae(dtIvas, tipoDocumentoAfip, docCuit, numeroComprobanteTipoAfip, punto, facturaDeCredito, Convert.ToDateTime(dtFinalFiltrada.Rows[0]["fecha_desde"]), Convert.ToDateTime(dtFinalFiltrada.Rows[0]["fecha_hasta"]), Convert.ToDateTime(dtFinalFiltrada.Rows[0]["fecha_hasta"]), Total_Provincial);
                            if (Convert.ToInt32(dtDatosNuevoCAE.Rows[dtDatosNuevoCAE.Rows.Count - 1]["salida"]) != 0)
                            {
                                dtDatosRetorno.Rows.Add(oComprobante.Id_Punto_Venta.ToString(), oComprobante.Punto_Venta.ToString(), dtDatosPuntoVenta.Rows[0]["punto_venta_descripcion"].ToString(), dtDatosNuevoCAE.Rows[dtDatosNuevoCAE.Rows.Count - 1]["salida"].ToString(), dtDatosNuevoCAE.Rows[dtDatosNuevoCAE.Rows.Count - 1]["mensaje"].ToString(), dtDatosPuntoVenta.Rows[0]["modalidad_facturacion_descripcion"].ToString(), Descripcion);
                                if (facturacionElectronicaMensual == 1)
                                    return dtDatosRetorno;

                                hacerRemito = 1;
                            }
                        }
                    }
                    else
                    {
                        trabajaElectronica = false;
                        hacerRemito = 1;
                    }
                }
                else
                {
                    dtDatosRetorno.Rows.Add(oComprobante.Id_Punto_Venta.ToString(), oComprobante.Punto_Venta.ToString(), dtDatosPuntoVenta.Rows[0]["punto_venta_descripcion"].ToString(), Convert.ToInt16(CODIGOS_RESPUESTA_FACTURACION.NO_SE_ENCUENTRA_DOCUMENTO_AFIP).ToString(), CODIGOS_RESPUESTA_FACTURACION.NO_SE_ENCUENTRA_DOCUMENTO_AFIP.ToString(), dtDatosPuntoVenta.Rows[0]["modalidad_facturacion_descripcion"].ToString(), Descripcion);
                    hacerRemito = 1;
                }

                if (trabajaElectronica == true && hacerRemito == 0)
                {
                    if (Convert.ToInt32(dtDatosNuevoCAE.Rows[0]["salida"]) == 0)
                    {
                        CAE = dtDatosNuevoCAE.Rows[0]["cae"].ToString();
                        vencimientoCAE = Convert.ToDateTime(dtDatosNuevoCAE.Rows[0]["vencimiento"]);
                        nroFacturaCAE = Convert.ToDouble(dtDatosNuevoCAE.Rows[0]["numero"]);

                        //Ocomprobantes_Iva.Id = Usuarios.CurrentUsuario.Id_Comprobantes_Iva;
                        //Ocomprobantes_Iva.Listarportipo();
                        Descripcion = "FACTURA " + Comprobantes_Iva.CurrentComprobantes_Iva.Letra;

                        DataRow drDatosComprobante;
                        if (Comprobantes_Iva.CurrentComprobantes_Iva.Letra == "A")
                        {
                            //oComprobante_Tipo.SetNumeracion(Convert.ToInt32(drDatosComprobante["idPuntoVenta"]), Convert.ToInt32(Comprobantes_Tipo.Tipo.FACTURA_A), Convert.ToInt32(drDatosComprobante["numComprobante"]));
                            if (facturaDeCredito)
                            {
                                Descripcion = "FACTURA DE CREDITO A";
                                drDatosComprobante = oComprobante_Tipo.GetNumeracion(Convert.ToInt32(Comprobantes_Tipo.Tipo.FACTURA_CREDITO_ELECTRONICA_A), Puntos_Cobros.Id_Punto);
                                drDatosComprobante["numPuntoVenta"] = 17;
                                drDatosComprobante["idPuntoVenta"] = 17;
                                oComprobante.Id_Comprobantes_Tipo = (int)Comprobantes_Tipo.Tipo.FACTURA_CREDITO_ELECTRONICA_A;
                                oUsuCtaCte.Id_Comprobantes_Tipo = (int)Comprobantes_Tipo.Tipo.FACTURA_CREDITO_ELECTRONICA_A;
                            }
                            else
                            {
                                drDatosComprobante = oComprobante_Tipo.GetNumeracion(Convert.ToInt32(Comprobantes_Tipo.Tipo.FACTURA_A), Puntos_Cobros.Id_Punto);
                                oComprobante.Id_Comprobantes_Tipo = (int)Comprobantes_Tipo.Tipo.FACTURA_A;
                                oUsuCtaCte.Id_Comprobantes_Tipo = (int)Comprobantes_Tipo.Tipo.FACTURA_A;
                            }
                            oComprobante.Numero = Convert.ToInt32(nroFacturaCAE);
                            oComprobante.Punto_Venta = Convert.ToInt32(drDatosComprobante["numPuntoVenta"]);
                            oComprobante.Id_Punto_Venta = Convert.ToInt32(drDatosComprobante["idPuntoVenta"]);
                        }
                        if (Comprobantes_Iva.CurrentComprobantes_Iva.Letra == "B")
                        {
                            drDatosComprobante = oComprobante_Tipo.GetNumeracion(Convert.ToInt32(Comprobantes_Tipo.Tipo.FACTURA_B), Puntos_Cobros.Id_Punto);
                            oComprobante.Numero = Convert.ToInt32(nroFacturaCAE);
                            //oComprobante_Tipo.SetNumeracion(Convert.ToInt32(drDatosComprobante["idPuntoVenta"]), Convert.ToInt32(Comprobantes_Tipo.Tipo.FACTURA_B), Convert.ToInt32(drDatosComprobante["numComprobante"]));
                            oComprobante.Id_Comprobantes_Tipo = (int)Comprobantes_Tipo.Tipo.FACTURA_B;
                            oComprobante.Punto_Venta = Convert.ToInt32(drDatosComprobante["numPuntoVenta"]);
                            oComprobante.Id_Punto_Venta = Convert.ToInt32(drDatosComprobante["idPuntoVenta"]);
                            oUsuCtaCte.Id_Comprobantes_Tipo = (int)Comprobantes_Tipo.Tipo.FACTURA_B;
                        }

                        oComprobante.Importe = 0;
                        foreach (DataRow fila in dtCompDeuda.Rows)
                        {//se asigna el importe a la factura. Esto es provisorio ya que en realidad tendría que tomar en cuenta el IVA.
                            try
                            {
                                oComprobante.Importe += Convert.ToDecimal(fila["importe_total"]);
                            }

                            catch
                            {
                                oComprobante.Importe += 0;
                            }
                        }

                        oComprobante.Id_Personal = Personal.Id_Login;
                        oComprobante.Id_Punto_Cobro = Puntos_Cobros.Id_Punto;
                        oComprobante.Id_Usuarios_Locaciones = Idlocacion;

                        oComprobante.Id = oComprobante.Guardar(oComprobante);

                        oFacturacion.Punto_Venta = oComprobante.Punto_Venta;
                        oFacturacion.Numero = Convert.ToInt32(nroFacturaCAE);
                        oFacturacion.Id_Comprobantes_tipo = oComprobante.Id_Comprobantes_Tipo;
                        oFacturacion.Id_Comprobantes = oComprobante.Id;
                        oFacturacion.Letra = Comprobantes_Iva.CurrentComprobantes_Iva.Letra;
                        oFacturacion.Fecha = DateTime.Now;

                        NumeroMuestra = oComprobante.Punto_Venta.ToString().PadLeft(4, '0') + "-" + nroFacturaCAE.ToString().PadLeft(8, '0');
                        Descripcion = Descripcion + " " + NumeroMuestra;

                        oComprobantes_Detalle.Id_Comprobantes = oComprobante.Id;
                        foreach (DataRow DrItem in ItemFactura.Rows) ///// recorre todos los comprobantes de deuda. Genera los comprobantes_detalle 
                        {
                            oComprobantes_Detalle.Descripcion = DrItem["descripcion"].ToString();
                            oComprobantes_Detalle.Unidad = DrItem["unidad"].ToString();
                            oComprobantes_Detalle.Cantidad = Convert.ToInt32(DrItem["cantidad"].ToString());
                            //oComprobantes_Detalle.Unitario = ÏtemUnitario;
                            //oComprobantes_Detalle.Total = ItemTotal;
                            //oComprobantes_Detalle.Punitorios = ItemPuntorio;
                            //oComprobantes_Detalle.Bonificaciones = decimal.Round(decimal.Multiply(ItemBonificacion, -1), 2);
                            oComprobantes_Detalle.Unitario = Convert.ToDecimal(DrItem["total"].ToString());
                            oComprobantes_Detalle.Total = Convert.ToDecimal(DrItem["total"].ToString()) / Convert.ToDecimal(DrItem["cantidad"].ToString());
                            oComprobantes_Detalle.Punitorios = Convert.ToDecimal(DrItem["punitorios"].ToString());
                            oComprobantes_Detalle.Bonificaciones = decimal.Round(decimal.Multiply(Convert.ToDecimal(DrItem["bonificaciones"].ToString()), -1), 2);
                            oComprobantes_Detalle.Desde = Convert.ToDateTime(DrItem["desde"].ToString());
                            oComprobantes_Detalle.Hasta = Convert.ToDateTime(DrItem["hasta"].ToString());
                            oComprobantes_Detalle.Descripcion_Adicional = DrItem["descripcion_adicional"].ToString();
                            oComprobantes_Detalle.Codigo = "";
                            oComprobantes_Detalle.Unidad = "";
                            oComprobantes_Detalle.Guardar(oComprobantes_Detalle);
                        }

                        Importe_Neto = Total_Neto;
                        Importe_Iva = Total_Iva;
                        Importe_Impuesto_Provincial = Total_Provincial;
                        Importe_Impuesto_Nacional = 0;
                        Importe_Impuesto_Municipal = 0;
                        Importe_Impuesto_Interno = 0;
                        Importe_Impuesto_Otros = 0;
                        Importe_Final = Total_Factura;

                        Razon_Social = String.Format("{0} {1}", Usuarios.CurrentUsuario.Apellido, Usuarios.CurrentUsuario.Nombre);
                        Fantasia = "";
                        Calle = Usuarios.CurrentUsuario.Calle;
                        Altura = Usuarios.CurrentUsuario.Altura;
                        Localidad = Usuarios.CurrentUsuario.localidad;
                        Cod_postal = Usuarios.CurrentUsuario.Cod_postal;
                        Numero_Doc = Usuarios.CurrentUsuario.Numero_Documento;
                        Letra = Comprobantes_Iva.CurrentComprobantes_Iva.Letra;
                        Provincia = "";
                        Id_Usuarios = Usuarios.CurrentUsuario.Id;

                        Id_Usuarios_locacion = Usuarios.CurrentUsuario.Id_Usuarios_Locacion;


                        oFacturacion.Letra = Letra;
                        oFacturacion.Numero = Convert.ToInt32(nroFacturaCAE);
                        oFacturacion.Razon_Social = Usuarios.CurrentUsuarioDomFiscal.R_Social;
                        oFacturacion.Calle = Usuarios.CurrentUsuarioDomFiscal.Calle;
                        oFacturacion.Altura = Usuarios.CurrentUsuarioDomFiscal.Altura;
                        oFacturacion.Localidad = Usuarios.CurrentUsuarioDomFiscal.Localidad;
                        oFacturacion.Cod_postal = Usuarios.CurrentUsuarioDomFiscal.Codigo_Postal;
                        if (Usuarios.CurrentUsuarioDomFiscal.Ocomprobantes_Iva.Id == (int)Comprobantes_Iva.Tipo.CONSUMIDOR_FINAL)
                            oFacturacion.Numero_Doc = Usuarios.CurrentUsuarioDomFiscal.Numero_Documento;
                        else
                            oFacturacion.Numero_Doc = Usuarios.CurrentUsuarioDomFiscal.Cuit;

                        oFacturacion.Id_Comprobantes_tipo = oComprobante.Id_Comprobantes_Tipo;
                        oFacturacion.Id_Comprobantes_iva = Comprobantes_Iva.CurrentComprobantes_Iva.Id;
                        oFacturacion.Cae = CAE;
                        oFacturacion.Cae_vencimiento = vencimientoCAE;
                        oUsuCtaCte.Descripcion = Descripcion;

                        Id_Iva_Ventas = GuardarIvaVentas(oFacturacion);
                        oFacturacion.Id_Iva_Ventas = Id_Iva_Ventas;

                        foreach (DataRow drIva in dtIvas.Rows)
                        {
                            if (Convert.ToDecimal(drIva["importe_neto"].ToString()) > 0)
                                GuardarIvalicuotas(oFacturacion, drIva);
                        }

                        bool aplicaDetalles = false;
                        bool convirtioAFactura = false;
                        foreach (DataRow Dr in dtfinal.Rows) /// aplica percepcion a los item
                        {
                            if (Convert.ToBoolean(Dr["elige"]) && Convert.ToDecimal(Dr["encabezado"].ToString()) == 2 && Convert.ToInt32(Dr["presenta_ventas"]) == 0)
                            {
                                decimal porcentajePercepcion = 0;
                                if (Convert.ToInt32(Dr["percepcion"]) == 1)
                                {
                                    porcentajePercepcion = Convert.ToDecimal(new Usuarios().GetCampo("Impuesto_Provincial", Convert.ToInt32(Dr["id_usuarios"])));
                                    Aplicar_Impuesto_CtaCte(Convert.ToInt32(Dr["id_usuarios_ctacte"].ToString()), Convert.ToDecimal(Dr["importe_provincial"].ToString()));
                                }
                                oUsuCtaCte.SetFacturaElectronica(oComprobante.Id, oComprobante.Id_Comprobantes_Tipo, Descripcion, Convert.ToInt32(Dr["id_usuarios_ctacte"].ToString()), Id_Iva_Ventas, porcentajePercepcion);
                                oUsuCtaCte.GuardarCtaCteComprobante(Convert.ToInt32(Dr["id_usuarios_ctacte"].ToString()), oComprobante.Id);
                                aplicaDetalles = true;
                                convirtioAFactura = true;
                            }
                            else if (Convert.ToDecimal(Dr["encabezado"].ToString()) == 2)
                            {
                                aplicaDetalles = false;
                            }

                            if (Convert.ToDecimal(Dr["encabezado"].ToString()) == 0 && aplicaDetalles)
                            {
                                if (Convert.ToDecimal(Dr["importe_provincial"].ToString()) != 0)
                                    Aplicar_Impuesto_CtaCte_det(Convert.ToDecimal(Dr["importe_provincial"].ToString()), Convert.ToInt32(Dr["id"].ToString()));
                            }
                        }
                        //aca no estaba el siguiente foreach y no actualizaba de comprobante a factura en los ctacte que eran generados por debitos que fueron marcados como rechazado
                        if (!convirtioAFactura)
                        {
                            foreach (DataRow DrEncabezado in dtCompDeuda.Rows)
                            { ///// recorre todos los comprobantes de deuda y los actualiza a factura
                                decimal porcentajePercepcion = Convert.ToDecimal(new Usuarios().GetCampo("Impuesto_Provincial", Convert.ToInt32(DrEncabezado["id_usuarios"])));
                                oUsuCtaCte.SetFacturaElectronica(oComprobante.Id, oComprobante.Id_Comprobantes_Tipo, Descripcion, Convert.ToInt32(DrEncabezado["id_usuarios_ctacte"].ToString()), Id_Iva_Ventas, porcentajePercepcion);
                                oUsuCtaCte.GuardarCtaCteComprobante(Convert.ToInt32(DrEncabezado["id_usuarios_ctacte"].ToString()), oComprobante.Id);
                            }
                        }

                    }
                    else
                        codigoRetorno = Convert.ToInt32(dtDatosCAE.Rows[0]["salida"]);

                }
                else
                {
                    if (trabajaElectronica == false && hacerRemito == 0)
                    {
                        //Ocomprobantes_Iva.Id = Usuarios.CurrentUsuario.Id_Comprobantes_Iva;
                        //Ocomprobantes_Iva.Listarportipo();
                        Descripcion = "FACTURA " + Comprobantes_Iva.CurrentComprobantes_Iva.Letra;

                        DataRow drDatosComprobante;
                        if (Comprobantes_Iva.CurrentComprobantes_Iva.Letra == "A")
                        {
                            drDatosComprobante = oComprobante_Tipo.GetNumeracion(Convert.ToInt32(Comprobantes_Tipo.Tipo.FACTURA_A), Puntos_Cobros.Id_Punto);
                            oComprobante.Numero = Convert.ToInt32(drDatosComprobante["numComprobante"]);
                            oComprobante_Tipo.SetNumeracion(Convert.ToInt32(drDatosComprobante["idPuntoVenta"]), Convert.ToInt32(Comprobantes_Tipo.Tipo.FACTURA_A), Convert.ToInt32(drDatosComprobante["numComprobante"]));
                            oComprobante.Id_Comprobantes_Tipo = (int)Comprobantes_Tipo.Tipo.FACTURA_A;
                            oComprobante.Punto_Venta = Convert.ToInt32(drDatosComprobante["numPuntoVenta"]);
                            oComprobante.Id_Punto_Venta = Convert.ToInt32(drDatosComprobante["idPuntoVenta"]);
                            oUsuCtaCte.Id_Comprobantes_Tipo = (int)Comprobantes_Tipo.Tipo.FACTURA_A;
                        }
                        if (Comprobantes_Iva.CurrentComprobantes_Iva.Letra == "B")
                        {
                            drDatosComprobante = oComprobante_Tipo.GetNumeracion(Convert.ToInt32(Comprobantes_Tipo.Tipo.FACTURA_B), Puntos_Cobros.Id_Punto);
                            oComprobante.Numero = Convert.ToInt32(drDatosComprobante["numComprobante"]);
                            oComprobante_Tipo.SetNumeracion(Convert.ToInt32(drDatosComprobante["idPuntoVenta"]), Convert.ToInt32(Comprobantes_Tipo.Tipo.FACTURA_B), Convert.ToInt32(drDatosComprobante["numComprobante"]));
                            oComprobante.Id_Comprobantes_Tipo = (int)Comprobantes_Tipo.Tipo.FACTURA_B;
                            oComprobante.Punto_Venta = Convert.ToInt32(drDatosComprobante["numPuntoVenta"]);
                            oComprobante.Id_Punto_Venta = Convert.ToInt32(drDatosComprobante["idPuntoVenta"]);
                            oUsuCtaCte.Id_Comprobantes_Tipo = (int)Comprobantes_Tipo.Tipo.FACTURA_B;
                        }

                        oComprobante.Importe = 0;
                        foreach (DataRow fila in dtCompDeuda.Rows)
                        {//se asigna el importe a la factura. Esto es provisorio ya que en realidad tendría que tomar en cuenta el IVA.
                            try
                            {
                                oComprobante.Importe += Convert.ToDecimal(fila["importe_total"]);
                            }
                            catch
                            {
                                oComprobante.Importe += 0;
                            }
                        }

                        oComprobante.Id_Personal = Personal.Id_Login;
                        oComprobante.Id_Punto_Cobro = Puntos_Cobros.Id_Punto;
                        oComprobante.Id_Usuarios_Locaciones = Idlocacion;

                        oComprobante.Id = oComprobante.Guardar(oComprobante);

                        oFacturacion.Punto_Venta = oComprobante.Punto_Venta;
                        oFacturacion.Numero = oComprobante.Numero;
                        oFacturacion.Id_Comprobantes_tipo = oComprobante.Id_Comprobantes_Tipo;
                        oFacturacion.Id_Comprobantes = oComprobante.Id;
                        oFacturacion.Letra = Comprobantes_Iva.CurrentComprobantes_Iva.Letra;
                        oFacturacion.Fecha = DateTime.Now;
                        oFacturacion.Cae = "";
                        oFacturacion.Cae_vencimiento = DateTime.Today;
                        NumeroMuestra = oComprobante.Punto_Venta.ToString().PadLeft(4, '0') + "-" + oComprobante.Numero.ToString().PadLeft(8, '0');
                        Descripcion = Descripcion + " " + NumeroMuestra;

                        oComprobantes_Detalle.Id_Comprobantes = oComprobante.Id;
                        foreach (DataRow DrItem in ItemFactura.Rows) ///// recorre todos los comprobantes de deuda. Genera los comprobantes_detalle 
                        {
                            oComprobantes_Detalle.Descripcion = DrItem["descripcion"].ToString();
                            oComprobantes_Detalle.Unidad = DrItem["unidad"].ToString();
                            oComprobantes_Detalle.Cantidad = Convert.ToInt32(DrItem["cantidad"].ToString());
                            oComprobantes_Detalle.Unitario = Convert.ToDecimal(DrItem["total"].ToString());
                            oComprobantes_Detalle.Total = Convert.ToDecimal(DrItem["total"].ToString());
                            oComprobantes_Detalle.Punitorios = Convert.ToDecimal(DrItem["punitorios"].ToString());
                            oComprobantes_Detalle.Bonificaciones = decimal.Round(decimal.Multiply(Convert.ToDecimal(DrItem["bonificaciones"].ToString()), -1), 2);

                            //oComprobantes_Detalle.Unitario = ÏtemUnitario;
                            //oComprobantes_Detalle.Total = ItemTotal;
                            //oComprobantes_Detalle.Punitorios = ItemPuntorio;
                            //oComprobantes_Detalle.Bonificaciones = decimal.Round(decimal.Multiply(ItemBonificacion, -1), 2);
                            oComprobantes_Detalle.Desde = Convert.ToDateTime(DrItem["desde"].ToString());
                            oComprobantes_Detalle.Hasta = Convert.ToDateTime(DrItem["hasta"].ToString());
                            oComprobantes_Detalle.Descripcion_Adicional = DrItem["descripcion_adicional"].ToString();
                            oComprobantes_Detalle.Codigo = "";
                            oComprobantes_Detalle.Unidad = "";
                            oComprobantes_Detalle.Guardar(oComprobantes_Detalle);
                        }


                        foreach (DataRow DrEncabezado in dtCompDeuda.Rows)
                        { ///// recorre todos los comprobantes de deuda y los actualiza a factura

                            decimal porcentajePercepcion = Convert.ToDecimal(new Usuarios().GetCampo("Impuesto_Provincial", Convert.ToInt32(DrEncabezado["id_usuarios"])));
                            oUsuCtaCte.SetFacturaElectronica(oComprobante.Id, oComprobante.Id_Comprobantes_Tipo, Descripcion, Convert.ToInt32(DrEncabezado["id_usuarios_ctacte"].ToString()), Id_Iva_Ventas, porcentajePercepcion);
                            oUsuCtaCte.GuardarCtaCteComprobante(Convert.ToInt32(DrEncabezado["id_usuarios_ctacte"].ToString()), oComprobante.Id);


                        }

                        bool aplicaDetalles = false;
                        foreach (DataRow Dr in dtfinal.Rows) /// aplica percepcion a los item
                        {
                            if (Convert.ToBoolean(Dr["elige"]) && Convert.ToDecimal(Dr["encabezado"].ToString()) == 2 && Convert.ToInt32(Dr["percepcion"]) == 1 && Convert.ToInt32(Dr["presenta_ventas"]) == 0)
                            {
                                Aplicar_Impuesto_CtaCte(Convert.ToInt32(Dr["id_usuarios_ctacte"].ToString()), Convert.ToDecimal(Dr["importe_provincial"].ToString()));
                                aplicaDetalles = true;
                            }
                            else if (Convert.ToDecimal(Dr["encabezado"].ToString()) == 2)
                            {
                                aplicaDetalles = false;
                            }

                            if (Convert.ToDecimal(Dr["encabezado"].ToString()) == 0 && aplicaDetalles)
                            {
                                if (Convert.ToDecimal(Dr["importe_provincial"].ToString()) != 0)
                                    Aplicar_Impuesto_CtaCte_det(Convert.ToDecimal(Dr["importe_provincial"].ToString()), Convert.ToInt32(Dr["id"].ToString()));
                            }
                        }


                    }
                    else
                    {
                        if (oConfi.GetValor_N("EmitirRemito") == Convert.ToInt32(EMITIR_REMITO.NO) || permitirHacerRemito == false)
                        {
                            dtDatosRetorno.Rows.Add(dtDatosNuevoCAE.Rows[0]["salida"].ToString(), "", "", Convert.ToInt16(CODIGOS_RESPUESTA_FACTURACION.NO_SE_REALIZARON_MODIFICACIONES).ToString(), CODIGOS_RESPUESTA_FACTURACION.NO_SE_REALIZARON_MODIFICACIONES.ToString(), "", "");
                            return dtDatosRetorno;
                        }
                        else
                        {
                            //hago remito
                            Ocomprobantes_Iva.Id = Usuarios.CurrentUsuario.Id_Comprobantes_Iva;
                            Ocomprobantes_Iva.Listarportipo();
                            Descripcion = "REMITO ";

                            DataRow drDatosComprobante;
                            drDatosComprobante = oComprobante_Tipo.GetNumeracion(Convert.ToInt32(Comprobantes_Tipo.Tipo.REMITO), Puntos_Cobros.Id_Punto);
                            oComprobante.Numero = Convert.ToInt32(drDatosComprobante["numComprobante"]);
                            oComprobante_Tipo.SetNumeracion(Convert.ToInt32(drDatosComprobante["idPuntoVenta"]), Convert.ToInt32(Comprobantes_Tipo.Tipo.REMITO), Convert.ToInt32(drDatosComprobante["numComprobante"]));
                            oComprobante.Id_Comprobantes_Tipo = (int)Comprobantes_Tipo.Tipo.REMITO;
                            oComprobante.Punto_Venta = Convert.ToInt32(drDatosComprobante["numPuntoVenta"]);
                            oComprobante.Id_Punto_Venta = Convert.ToInt32(drDatosComprobante["idPuntoVenta"]);
                            oUsuCtaCte.Id_Comprobantes_Tipo = (int)Comprobantes_Tipo.Tipo.REMITO;


                            oComprobante.Importe = 0;
                            foreach (DataRow fila in dtCompDeuda.Rows)
                            {//se asigna el importe a la factura. Esto es provisorio ya que en realidad tendría que tomar en cuenta el IVA.
                                try
                                {
                                    oComprobante.Importe += Convert.ToDecimal(fila["importe_total"]);
                                }
                                catch
                                {
                                    oComprobante.Importe += 0;
                                }
                            }
                            NumeroMuestra = oComprobante.Punto_Venta.ToString().PadLeft(4, '0') + "-" + oComprobante.Numero.ToString().PadLeft(8, '0');
                            Descripcion = Descripcion + " " + NumeroMuestra;

                            oComprobante.Id_Personal = Personal.Id_Login;
                            oComprobante.Id_Punto_Cobro = Puntos_Cobros.Id_Punto;
                            oComprobante.Id_Usuarios_Locaciones = Idlocacion;
                            oComprobante.Descripcion = Descripcion;
                            oComprobante.Id = oComprobante.Guardar(oComprobante);

                            oFacturacion.Punto_Venta = oComprobante.Punto_Venta;
                            oFacturacion.Numero = oComprobante.Numero;
                            oFacturacion.Id_Comprobantes_tipo = oComprobante.Id_Comprobantes_Tipo;
                            oFacturacion.Id_Comprobantes = oComprobante.Id;
                            oFacturacion.Letra = "x";
                            oFacturacion.Fecha = DateTime.Now;
                            oFacturacion.Cae = "";
                            oFacturacion.Cae_vencimiento = DateTime.Today;

                            oComprobantes_Detalle.Id_Comprobantes = oComprobante.Id;
                            foreach (DataRow DrItem in ItemFactura.Rows) ///// recorre todos los comprobantes de deuda. Genera los comprobantes_detalle 
                            {
                                oComprobantes_Detalle.Descripcion = DrItem["descripcion"].ToString();
                                oComprobantes_Detalle.Unidad = DrItem["unidad"].ToString();
                                oComprobantes_Detalle.Cantidad = Convert.ToInt32(DrItem["cantidad"].ToString());
                                oComprobantes_Detalle.Unitario = Convert.ToDecimal(DrItem["total"].ToString());
                                oComprobantes_Detalle.Total = Convert.ToDecimal(DrItem["total"].ToString());
                                oComprobantes_Detalle.Punitorios = Convert.ToDecimal(DrItem["punitorios"].ToString());
                                oComprobantes_Detalle.Bonificaciones = decimal.Round(decimal.Multiply(Convert.ToDecimal(DrItem["bonificaciones"].ToString()), -1), 2);

                                //oComprobantes_Detalle.Unitario = ÏtemUnitario;
                                //oComprobantes_Detalle.Total = ItemTotal;
                                //oComprobantes_Detalle.Punitorios = ItemPuntorio;
                                //oComprobantes_Detalle.Bonificaciones = decimal.Round(decimal.Multiply(ItemBonificacion, -1), 2);
                                oComprobantes_Detalle.Desde = Convert.ToDateTime(DrItem["desde"].ToString());
                                oComprobantes_Detalle.Hasta = Convert.ToDateTime(DrItem["hasta"].ToString());
                                oComprobantes_Detalle.Descripcion_Adicional = DrItem["descripcion_adicional"].ToString();
                                oComprobantes_Detalle.Codigo = "";
                                oComprobantes_Detalle.Unidad = "";
                                oComprobantes_Detalle.Guardar(oComprobantes_Detalle);
                            }
                        }
                    }

                    Importe_Neto = Total_Neto;
                    Importe_Iva = Total_Iva;
                    Importe_Impuesto_Provincial = Total_Provincial;
                    Importe_Impuesto_Nacional = 0;
                    Importe_Impuesto_Municipal = 0;
                    Importe_Impuesto_Interno = 0;
                    Importe_Impuesto_Otros = 0;
                    Importe_Final = Total_Factura;

                    Id_Usuarios = Usuarios.CurrentUsuario.Id;
                    Id_Usuarios_locacion = Usuarios.CurrentUsuario.Id_Usuarios_Locacion;
                    Provincia = "";
                    Fantasia = Usuarios.CurrentUsuario.Nombre;
                    oFacturacion.Letra = Comprobantes_Iva.CurrentComprobantes_Iva.Letra;
                    oFacturacion.Numero = oComprobante.Numero;
                    oFacturacion.Razon_Social = String.Format("{0} {1}", Usuarios.CurrentUsuario.Apellido, Usuarios.CurrentUsuario.Nombre);
                    oFacturacion.Calle = Usuarios.CurrentUsuarioDomFiscal.Calle;
                    oFacturacion.Altura = Usuarios.CurrentUsuarioDomFiscal.Altura;
                    oFacturacion.Localidad = Usuarios.CurrentUsuarioDomFiscal.Localidad;
                    oFacturacion.Cod_postal = Usuarios.CurrentUsuarioDomFiscal.Codigo_Postal;
                    oFacturacion.Numero_Doc = Usuarios.CurrentUsuarioDomFiscal.Numero_Documento;
                    oFacturacion.Id_Comprobantes_tipo = oComprobante.Id_Comprobantes_Tipo;
                    oFacturacion.Id_Comprobantes_iva = Comprobantes_Iva.CurrentComprobantes_Iva.Id;
                    oUsuCtaCte.Descripcion = Descripcion;
                    Id_Iva_Ventas = GuardarIvaVentas(oFacturacion);
                    oFacturacion.Id_Iva_Ventas = Id_Iva_Ventas;

                    foreach (DataRow drIva in dtIvas.Rows)
                    {
                        if (Convert.ToDecimal(drIva["importe_neto"].ToString()) > 0)
                            GuardarIvalicuotas(oFacturacion, drIva);
                    }

                    foreach (DataRow DrEncabezado in dtCompDeuda.Rows)
                    { ///// recorre todos los comprobantes de deuda y los actualiza a factura
                        decimal porcentajePercepcion = Convert.ToDecimal(new Usuarios().GetCampo("Impuesto_Provincial", Convert.ToInt32(DrEncabezado["id_usuarios"])));
                        oUsuCtaCte.SetFacturaElectronica(oComprobante.Id, oComprobante.Id_Comprobantes_Tipo, Descripcion, Convert.ToInt32(DrEncabezado["id_usuarios_ctacte"].ToString()), Id_Iva_Ventas, porcentajePercepcion);
                        oUsuCtaCte.GuardarCtaCteComprobante(Convert.ToInt32(DrEncabezado["id_usuarios_ctacte"].ToString()), oComprobante.Id);
                    }
                }
            }
            else
            {
                dtDatosRetorno.Rows.Add("Error: La factura no puede tener importe menor o igual a 0 ", "", "", Convert.ToInt16(CODIGOS_RESPUESTA_FACTURACION.FACTURA_IMPORTE_CERO).ToString(), CODIGOS_RESPUESTA_FACTURACION.FACTURA_IMPORTE_CERO.ToString(), "", "");
                codigoRetorno = Convert.ToInt16(CODIGOS_RESPUESTA_FACTURACION.FACTURA_IMPORTE_CERO);
            }

            int codigoRespuesta = 0;
            string respuesta = String.Empty;
            if (trabajaElectronica)
            {
                if (codigoRetorno != Convert.ToInt16(CODIGOS_RESPUESTA_FACTURACION.FACTURA_IMPORTE_CERO) && codigoRetorno != Convert.ToInt16(CODIGOS_RESPUESTA_FACTURACION.FACTURA_SIN_ITEMS))
                    codigoRespuesta = Convert.ToInt16(dtDatosNuevoCAE.Rows[0]["salida"]);
            }
            else
                codigoRespuesta = codigoRetorno;

            if (trabajaElectronica)
            {
                if (hacerRemito == 0)
                {
                    if (codigoRetorno != Convert.ToInt16(CODIGOS_RESPUESTA_FACTURACION.FACTURA_IMPORTE_CERO) && codigoRetorno != Convert.ToInt16(CODIGOS_RESPUESTA_FACTURACION.FACTURA_SIN_ITEMS))
                        respuesta = dtDatosNuevoCAE.Rows[0]["mensaje"].ToString();
                }
                else
                {
                    if (facturacionElectronicaMensual == 0)
                        respuesta = "REMITO";
                    else
                    {
                        if (codigoRetorno != Convert.ToInt16(CODIGOS_RESPUESTA_FACTURACION.FACTURA_IMPORTE_CERO) && codigoRetorno != Convert.ToInt16(CODIGOS_RESPUESTA_FACTURACION.FACTURA_SIN_ITEMS))
                            respuesta = dtDatosNuevoCAE.Rows[0]["mensaje"].ToString();
                    }
                }
            }
            else
            {

                if (codigoRespuesta == Convert.ToInt16(CODIGOS_RESPUESTA_FACTURACION.NO_SE_ENCUENTRA_DOCUMENTO_AFIP))
                    respuesta = CODIGOS_RESPUESTA_FACTURACION.NO_SE_ENCUENTRA_DOCUMENTO_AFIP.ToString();
                else if (codigoRespuesta == Convert.ToInt16(CODIGOS_RESPUESTA_FACTURACION.OPERACION_CORRECTA))
                    respuesta = CODIGOS_RESPUESTA_FACTURACION.OPERACION_CORRECTA.ToString();
                else if (codigoRespuesta == Convert.ToInt16(CODIGOS_RESPUESTA_FACTURACION.OPERACION_ERROR))
                    respuesta = CODIGOS_RESPUESTA_FACTURACION.OPERACION_ERROR.ToString();
                else if (codigoRespuesta == Convert.ToInt16(CODIGOS_RESPUESTA_FACTURACION.FACTURA_SIN_ITEMS))
                    respuesta = CODIGOS_RESPUESTA_FACTURACION.FACTURA_SIN_ITEMS.ToString();
                else if (codigoRespuesta == Convert.ToInt16(CODIGOS_RESPUESTA_FACTURACION.FACTURA_IMPORTE_CERO))
                    respuesta = CODIGOS_RESPUESTA_FACTURACION.FACTURA_IMPORTE_CERO.ToString();
            }
            if (dtDatosPuntoVenta.Rows.Count > 0)
                dtDatosRetorno.Rows.Add(oComprobante.Id_Punto_Venta.ToString(), oComprobante.Punto_Venta.ToString(), dtDatosPuntoVenta.Rows[0]["punto_venta_descripcion"].ToString(), codigoRespuesta.ToString(), respuesta, dtDatosPuntoVenta.Rows[0]["modalidad_facturacion_descripcion"].ToString(), Descripcion);

            return dtDatosRetorno;
        }

        public DataTable Nuevo_Cae(DataTable dtIvas, int tipoDoc, double docCuit, int tipoComprobante, int idPunto, bool facturaDeCredito, DateTime fechaDesde = new DateTime(), DateTime fechaHasta = new DateTime(), DateTime vencimientoPago = new DateTime(), Decimal importeProvincial = 0, DataTable dtCompAsociados = null)
        {
            // verifico si es por homologacion o produccion 1:homo 2: produ
            double porcentajeprovincial = Convert.ToDouble(Usuarios.CurrentUsuarioDomFiscal.ImpuestoProvincial.ToString());
            int trabajaHomologacion = Convert.ToInt32(oConfi.GetValor_N("Factura_Electronica"));
            dtDatosCAE.Clear();
            if (dtDatosCAE.Columns.Count == 0)
            {
                dtDatosCAE.Columns.Add("cae", typeof(String));
                dtDatosCAE.Columns.Add("vencimiento", typeof(DateTime));
                dtDatosCAE.Columns.Add("numero", typeof(Double));
                dtDatosCAE.Columns.Add("salida", typeof(Int32));
                dtDatosCAE.Columns.Add("mensaje", typeof(string));
            }
            /* Los nombres de los parametros de las funciones se obtienen descomprimiendo FEAFIP DOC
           y luego abriendo el archivo index.html de la carpeta "Doc Interfaces".
           la interfaz correspondiente a este ejemplo es Iwsfev1 para facturas A y B.*/
            //URLs de autenticacion y negocio. Cambiarlas por las de producción al implementarlas en el cliente(abajo)
            string URLWSAA = "";
            //Producción: https://wsaa.afip.gov.ar/ws/services/LoginCms
            string URLWSW = "";
            //Producción: https://servicios1.afip.gov.ar/wsfev1/service.asmx
            string CAE = "";
            string Vencimiento = "";
            string Resultado = "";
            string Reproceso = "";
            string CBU = "";
            double nro = 0;
            int PtoVta = 14;
            int TipoComp = tipoComprobante; // Factura A(ir a http://www.bitingenieria.com.ar/codigos.html)
            string FechaComp = DateTime.Today.ToString("yyyyMMdd");

            wsfev1 lwsfev1 = new wsfev1();

            if (facturaDeCredito)
            {
                if (trabajaHomologacion == 1)
                {
                    URLWSAA = "https://wsaahomo.afip.gov.ar/ws/services/LoginCms";
                    URLWSW = "https://wswhomo.afip.gov.ar/wsfev1/service.asmx";
                    lwsfev1.CUIT = 20939802593; // Cuit del vendedor
                }
                else
                {
                    URLWSAA = "https://wsaa.afip.gov.ar/ws/services/LoginCms";
                    URLWSW = "https://servicios1.afip.gov.ar/wsfev1/service.asmx";
                    lwsfev1.CUIT = Convert.ToDouble(oConfi.GetValor_C("Cuit"));
                }
                CBU = oConfi.GetValor_C("CBUFacturaDeCredito");
                PtoVta = 17;
                TipoComp = 201;
            }
            else if (trabajaHomologacion == 1)
            {
                URLWSAA = "https://wsaahomo.afip.gov.ar/ws/services/LoginCms";
                URLWSW = "https://wswhomo.afip.gov.ar/wsfev1/service.asmx";

                lwsfev1.CUIT = 20939802593; // Cuit del vendedor
                PtoVta = 198;
            }
            else
            {
                URLWSAA = "https://wsaa.afip.gov.ar/ws/services/LoginCms";
                URLWSW = "https://servicios1.afip.gov.ar/wsfev1/service.asmx";

                lwsfev1.CUIT = Convert.ToDouble(oConfi.GetValor_C("Cuit"));
                PtoVta = idPunto;
            }

            lwsfev1.URL = URLWSW;
            //switch (tipoDoc)
            //{
            //    case 80:
            //        TipoComp = 1;
            //        break;
            //    case 96:
            //        TipoComp = 6;
            //        break;
            //    default:
            //        break;
            //}
            //recupero rutas de archivos certificado.crt y clave.key
            Configuracion oConfig = new Configuracion();
            string rutaCertificado = @"C:\GIES\certificado.crt";
            String rutaClave = @"C:\GIES\clave.key";
            double totalNeto = 0;
            double totalTotal = 0;
            double totalIva = 0;

            try
            {

                if (lwsfev1.login(rutaCertificado, rutaClave, URLWSAA))
                {
                    if (lwsfev1.RecuperaLastCMP(PtoVta, TipoComp, out nro) == false)
                        dtDatosCAE.Rows.Add("0", new DateTime(), 0, 1, lwsfev1.ErrorDesc);
                    else
                    {
                        nro = nro + 1;
                        lwsfev1.Reset();
                        double cuit = docCuit;

                        foreach (DataRow item in dtIvas.Rows)
                        {
                            totalNeto = totalNeto + Convert.ToDouble(item["importe_neto"]);
                            totalIva = totalIva + Convert.ToDouble(item["importe_iva"]);
                        }
                        totalTotal = totalNeto + totalIva + Convert.ToDouble(importeProvincial.ToString());
                        if (fechaDesde == new DateTime())
                            lwsfev1.AgregaFactura(1, tipoDoc, cuit, nro, nro, FechaComp, totalTotal, 0, totalNeto, 0, "", "", "", "PES", 1);
                        else
                            lwsfev1.AgregaFactura(3, tipoDoc, docCuit, nro, nro, FechaComp, totalTotal, 0, totalNeto, 0, fechaDesde.ToString("yyyyMMdd"), fechaHasta.ToString("yyyyMMdd"), DateTime.Now.AddDays(10).ToString("yyyyMMdd"), "PES", 1);

                        foreach (DataRow item in dtIvas.Rows)
                        {
                            double importeNeto = Convert.ToDouble(item["importe_neto"]);
                            double importeIva = Convert.ToDouble(item["importe_iva"]);
                            int numeroAfip = Convert.ToInt32(item["numero_afip"]);
                            if (importeNeto > 0)
                                lwsfev1.AgregaIVA(numeroAfip, importeNeto, importeIva);
                        }

                        if (TipoComp == 8 || TipoComp == 3 || TipoComp==2 || TipoComp==7)//si es nota de credito a o b
                        {
                            foreach (DataRow drComprobante in dtCompAsociados.Rows)
                            {

                                if (docCuit.ToString().Length == 11)
                                    lwsfev1.AgregaCompAsoc(Convert.ToInt32(drComprobante["id_tipo_comp_afip"]), Convert.ToInt32(drComprobante["id_punto_venta"]), Convert.ToDouble(drComprobante["numero"]), Convert.ToDouble(drComprobante["cuit"]), drComprobante["fecha"].ToString());
                                else
                                    lwsfev1.AgregaCompAsoc(Convert.ToInt32(drComprobante["id_tipo_comp_afip"]), Convert.ToInt32(drComprobante["id_punto_venta"]), Convert.ToDouble(drComprobante["numero"]));
                            }
                        }

                        if (importeProvincial > 0)
                            lwsfev1.AgregaTributo(2, "PER IBB", totalNeto, porcentajeprovincial, (double)importeProvincial);

                        if (facturaDeCredito)
                        {
                            lwsfev1.AgregaOpcional("27", "SCA");
                            lwsfev1.AgregaOpcional("2101", CBU);
                        }

                        if (lwsfev1.Autorizar(PtoVta, TipoComp))
                        {
                            lwsfev1.AutorizarRespuesta(0, out CAE, out Vencimiento, out Resultado, out Reproceso);
                            if (Resultado == "A")
                            {
                                DateTime fechaVencimiento;
                                string anio, mes, dia;
                                anio = Vencimiento.Substring(0, 4);
                                mes = Vencimiento.Substring(4, 2);
                                dia = Vencimiento.Substring(6, 2);
                                fechaVencimiento = new DateTime(Convert.ToInt32(anio), Convert.ToInt32(mes), Convert.ToInt32(dia));
                                dtDatosCAE.Rows.Add(CAE, fechaVencimiento, nro, 0, "");
                            }
                            else
                            {
                                dtDatosCAE.Rows.Add("0", new DateTime(), 0, 2, lwsfev1.AutorizarRespuestaObs(0));
                            }
                        }
                        else
                            dtDatosCAE.Rows.Add("0", new DateTime(), 0, 3, lwsfev1.ErrorDesc.ToString());
                    }
                }
                else
                    dtDatosCAE.Rows.Add("0", new DateTime(), 0, 4, lwsfev1.ErrorDesc.ToString());

            }
            catch (Exception c)
            {
                dtDatosCAE.Rows.Add("0", new DateTime(), 0, 4, c.Message);
            }
            return dtDatosCAE;
        }

        public Boolean VerificarAFIP()
        {
            string URLWSAA = "https://wsaa.afip.gov.ar/ws/services/LoginCms";
            string URLWSW = "https://servicios1.afip.gov.ar/wsfev1/service.asmx";

            wsfev1 lwsfev1 = new wsfev1();
            lwsfev1.CUIT = Convert.ToDouble(oConfi.GetValor_C("Cuit"));
           
            string rutaCertificado = @"C:\GIES\certificado.crt";
            String rutaClave = @"C:\GIES\clave.key";

            if (Convert.ToInt32(oConfi.GetValor_N("Factura_Electronica")) == 1)
            {
                URLWSAA = "https://wsaahomo.afip.gov.ar/ws/services/LoginCms";
                URLWSW = "https://wswhomo.afip.gov.ar/wsfev1/service.asmx";

                lwsfev1.CUIT = 20939802593; 
            }

            lwsfev1.URL = URLWSW;

            if (lwsfev1.login(rutaCertificado, rutaClave, URLWSAA))
            {
                string server = "";
                string serverauth = "";
                string serverdb = "";

                if (lwsfev1.Dummy(out server, out serverauth, out serverdb))
                {
                    if (server == "OK" && serverauth == "OK" && serverdb == "OK")
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
            else
                return false;
        }

        private void Aplicar_Impuesto_CtaCte(Int32 Id, Decimal Impuesto)
        {
            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();

                oCon.CrearComando("UPDATE usuarios_ctacte SET importe_provincial=@impuesto,importe_final=importe_original+importe_provincial+importe_punitorio-importe_bonificacion,importe_saldo = if(importe_saldo>0,importe_final,0), id_personal=@personal WHERE Id = @idcta");
                oCon.AsignarParametroDecimal("@impuesto", Impuesto);
                oCon.AsignarParametroEntero("@personal", Personal.Id_Login);
                oCon.AsignarParametroEntero("@idcta", Id);

                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();

            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }

        }


        private void Aplicar_Impuesto_CtaCte_det(Decimal Impuesto, Int32 IdctaDet)
        {

            oCon.Conectar();
            oCon.ComenzarTransaccion();

            oCon.CrearComando("UPDATE usuarios_ctacte_det SET importe_provincial=@impuesto,importe_saldo=importe_original+importe_provincial+importe_punitorio-importe_bonificacion  WHERE Id = @idcta");
            oCon.AsignarParametroDecimal("@impuesto", Impuesto);
            oCon.AsignarParametroEntero("@idcta", IdctaDet);


            oCon.EjecutarComando();
            oCon.ConfirmarTransaccion();
            oCon.DesConectar();

        }

        public bool PlanDePagoFactura(int idCtacte, out string salida)
        {
            //verifico si la cuota que se quiere pasar a factura, no peretenece a un cctacte que ya no es factura, si es factura la cuota ya no puede pasarse a factura
            DataTable dtDatosCuota = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT id_plan_recibo from usuarios_ctacte where id = @idctacte");
                oCon.AsignarParametroEntero("@idctacte", idCtacte);
                dtDatosCuota = oCon.Tabla();

                if (dtDatosCuota.Rows.Count > 0)
                {
                    DataTable dtDatosRecibo = new DataTable();

                    int idReciboDelPlan = Convert.ToInt32(dtDatosCuota.Rows[0]["id_plan_recibo"]);
                    if (idReciboDelPlan > 0)
                    {

                        oCon.CrearComando("SELECT * FROM usuarios_ctacte_relacion WHERE id_usuarios_ctacte_recibos = @idrecibo");
                        oCon.AsignarParametroEntero("@idrecibo", idReciboDelPlan);
                        dtDatosRecibo = oCon.Tabla();
                        if (dtDatosRecibo.Rows.Count > 0)
                        {
                            int idCtaCteDeudaOriginal = Convert.ToInt32(dtDatosRecibo.Rows[0]["id_usuarios_ctacte"]);
                            DataTable dtDatosDeudaOriginal = new DataTable();
                            oCon.CrearComando("SELECT id_comprobantes_tipo FROM usuarios_ctacte where id=@id");
                            oCon.AsignarParametroEntero("@id", idCtaCteDeudaOriginal);
                            dtDatosDeudaOriginal = oCon.Tabla();
                            if (dtDatosDeudaOriginal.Rows.Count > 0)
                            {
                                if (Convert.ToInt32(dtDatosDeudaOriginal.Rows[0]["id_comprobantes_tipo"]) == (int)Comprobantes_Tipo.Tipo.COMPROBANTE_DEUDA)
                                {
                                    salida = "";
                                    oCon.DesConectar();
                                    return true;
                                }
                                else
                                {
                                    oCon.DesConectar();
                                    salida = "La deuda original ya es factura.";
                                    return false;
                                }
                            }
                            else
                            {
                                oCon.DesConectar();
                                salida = "No se encontraron datos del deuda original.";
                                return false;
                            }
                        }
                        else
                        {
                            oCon.DesConectar();
                            salida = "No se encontraron datos del recibo del plan de pagos que canceló la deuda.";
                            return false;
                        }

                    }
                    else
                    {
                        oCon.DesConectar();
                        salida = "";
                        return true;
                    }

                }
                else
                {
                    oCon.DesConectar();
                    salida = "No se encontraron datos de la deuda seleccionada.";
                    return false;

                }
            }
            catch (Exception c)
            {
                oCon.DesConectar();
                salida = c.ToString();
                return false;
                throw;
            }
        }

        public Boolean Guarda_Iva_Alicuotas_Afip(Facturacion oFac)
        {
            try
            {

                oCon.Conectar();
                oCon.CrearComando("insert into iva_alicuotas_detalles (Id_iva_ventas,Id_Comprobantes,id_iva_Alicuotas,porcentaje,Importe_Neto,Importe_iva) " +
                    "VALUES(@idIvaVentas,@id_comprobantes1,@id_iva_alicuotas1,@porcen,@importe_neto1,@importe_iva1)");

                oCon.AsignarParametroEntero("@idIvaVentas", oFac.Id_Iva_Ventas);
                oCon.AsignarParametroEntero("@id_comprobantes1", oFac.Id_Comprobantes);
                oCon.AsignarParametroEntero("@id_iva_alicuotas1", 1); //Hay que sacar este numero 1 por ahora dejarlo
                oCon.AsignarParametroDecimal("@porcen", 21);
                oCon.AsignarParametroDecimal("@importe_neto1", Convert.ToDecimal(oFac.Importe_Neto));
                oCon.AsignarParametroDecimal("@importe_iva1", Convert.ToDecimal(oFac.Importe_Iva));

                oCon.EjecutarComando();
                oCon.DesConectar();
                return true;
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                return false;
                throw;
            }

        }

        public void GenerarNotasDebito(DataTable dtCtaCtes, int idPuntoVenta, out string salida)
        {
            decimal importeOriginal, importeNeto, importeIva;
            int idCtacte, idComprobanteTipo, codigoAfipComprobante, numeroAfip = 0, idTipoComprobanteUsuario, tipoCompAfipAsociado, idPuntoVentaAsociado, numeroCompAsociado, idLocacion, idUsuario;
            double docCuit = 0;
            string cae = "", vencimiento = "", descripcionFactura = "";
            Comprobantes oComprobanteDebito = new Comprobantes();
            Usuarios_Locaciones oLocacion = new Usuarios_Locaciones();
            Usuarios oUsuarios = new Usuarios();
            Comprobantes_Detalle oComprobanteDetalle = new Comprobantes_Detalle();

            salida = "";
            DataTable dtDatosCtacte = new DataTable();
            DataTable dtCae = new DataTable();
            DataTable dtIvas = new DataTable();
            DataTable dtCompAsociados = new DataTable();
            DataTable dtDatosLocacion = new DataTable();
            DataTable dtDatosUsuario = new DataTable();
            DataColumn dcIdPuntoVenta = new DataColumn();
            dcIdPuntoVenta.DataType = typeof(int);
            dcIdPuntoVenta.DefaultValue = 0;
            dcIdPuntoVenta.ColumnName = "id_punto_venta";

            DataColumn dcNumero = new DataColumn();
            dcNumero.DataType = typeof(double);
            dcNumero.DefaultValue = 0;
            dcNumero.ColumnName = "numero";

            DataColumn dcFecha = new DataColumn();
            dcFecha.DataType = typeof(string);
            dcFecha.DefaultValue = 0;
            dcFecha.ColumnName = "fecha";

            DataColumn dcTipoComp = new DataColumn();
            dcTipoComp.DataType = typeof(int);
            dcTipoComp.DefaultValue = 0;
            dcTipoComp.ColumnName = "id_tipo_comp_afip";

            DataColumn dcCuit = new DataColumn();
            dcCuit.DataType = typeof(double);
            dcCuit.DefaultValue = 0;
            dcCuit.ColumnName = "cuit";

            dtCompAsociados.Columns.Add(dcIdPuntoVenta);
            dtCompAsociados.Columns.Add(dcNumero);
            dtCompAsociados.Columns.Add(dcFecha);
            dtCompAsociados.Columns.Add(dcTipoComp);
            dtCompAsociados.Columns.Add(dcCuit);



            DataColumn dcImporteNeto = new DataColumn();
            dcImporteNeto.DataType = typeof(decimal);
            dcImporteNeto.ColumnName = "importe_neto";
            dcImporteNeto.DefaultValue = 0;
            dtIvas.Columns.Add(dcImporteNeto);

            DataColumn dcImportIva = new DataColumn();
            dcImportIva.DataType = typeof(decimal);
            dcImportIva.ColumnName = "importe_iva";
            dcImportIva.DefaultValue = 0;
            dtIvas.Columns.Add(dcImportIva);

            DataColumn dcNumeroAfip = new DataColumn();
            dcNumeroAfip.DataType = typeof(int);
            dcNumeroAfip.ColumnName = "numero_afip";
            dcNumeroAfip.DefaultValue = 0;
            dtIvas.Columns.Add(dcNumeroAfip);

            if (dtCtaCtes.Rows.Count > 0)
            {
                foreach (DataRow ctacte in dtCtaCtes.Rows)
                {

                    idCtacte = Convert.ToInt32(ctacte["idCtacte"]);
                    importeOriginal = Convert.ToDecimal(ctacte["importePunitorio"]);
                    importeNeto = decimal.Round(importeOriginal / 1.21m, 2);
                    idComprobanteTipo = Convert.ToInt32(ctacte["idComprobanteTipo"]);
                    importeIva = importeOriginal - importeNeto;
                    docCuit = Convert.ToDouble(ctacte["docOCuit"]);
                    idPuntoVentaAsociado = Convert.ToInt32(ctacte["idPuntoVenta"]);
                    numeroCompAsociado = Convert.ToInt32(ctacte["numeroAsociado"]);
                    idLocacion = Convert.ToInt32(ctacte["idLocacion"]);
                    idUsuario = Convert.ToInt32(ctacte["idUsuario"]);
                    if (idComprobanteTipo == (int)Comprobantes_Tipo.Tipo.FACTURA_A)
                    {
                        codigoAfipComprobante = 2;//nota de debito A
                        idTipoComprobanteUsuario = 80; //num de cuit
                        tipoCompAfipAsociado = 1;//factura A

                    }
                    else
                    {
                        codigoAfipComprobante = 7;//nota de debito B
                        idTipoComprobanteUsuario = 96;//numero de documento
                        tipoCompAfipAsociado = 6;//factura B
                    }
                    dtCompAsociados.Clear();
                    DataRow drCompAsociado = dtCompAsociados.NewRow();

                    drCompAsociado["cuit"] = docCuit;
                    drCompAsociado["fecha"] = DateTime.Now.ToString("yyyyMMdd");
                    drCompAsociado["id_tipo_comp_afip"] = tipoCompAfipAsociado;
                    drCompAsociado["id_punto_venta"] = idPuntoVentaAsociado;
                    drCompAsociado["numero"] = numeroCompAsociado;
                    dtCompAsociados.Rows.Add(drCompAsociado);



                    dtIvas.Clear();
                    DataRow drIvas = dtIvas.NewRow();
                    drIvas["importe_neto"] = importeNeto;
                    drIvas["importe_iva"] = importeIva;
                    drIvas["numero_afip"] = numeroAfip;
                    dtIvas.Rows.Add(drIvas);
                    //------------- PREPARO IVAS 

                    //no se si hay que asociarle la factura original...
                    dtCae = Nuevo_Cae(dtIvas, idTipoComprobanteUsuario, docCuit, codigoAfipComprobante, idPuntoVentaAsociado, facturaDeCredito: false, dtCompAsociados: dtCompAsociados);
                    if (dtCae.Rows.Count > 0)
                    {
                        cae = dtCae.Rows[0]["cae"].ToString();
                        vencimiento = dtCae.Rows[0]["vencimiento"].ToString();
                        if (Convert.ToInt32(dtCae.Rows[0]["salida"]) == 0)
                        {
                            dtDatosUsuario = oUsuarios.Listar(idUsuario);
                            oComprobanteDebito = new Comprobantes();
                            if (idComprobanteTipo == (int)Comprobantes_Tipo.Tipo.FACTURA_A)
                                oComprobanteDebito.Id_Comprobantes_Tipo = (int)Comprobantes_Tipo.Tipo.NOTA_DEBITO_A;
                            else
                                oComprobanteDebito.Id_Comprobantes_Tipo = (int)Comprobantes_Tipo.Tipo.NOTA_DEBITO_B;

                            oComprobanteDebito.Id_Personal = Personal.Id_Login;
                            oComprobanteDebito.Id_Punto_Cobro = Personal.Id_Punto_Cobro_Predeterminado;
                            oComprobanteDebito.Id_Punto_Venta = Personal.Id_Punto_Venta;
                            oComprobanteDebito.Id_Usuarios = idUsuario;
                            oComprobanteDebito.Id_Usuarios_Locaciones = idLocacion;
                            oComprobanteDebito.Importe = importeOriginal;
                            oComprobanteDebito.Numero = Convert.ToInt32(dtCae.Rows[0]["numero"]);
                            oComprobanteDebito.Punto_Venta = idPuntoVentaAsociado;
                            oComprobanteDebito.Id = oComprobanteDebito.Guardar(oComprobanteDebito);
                            ctacte["idNotaDebitoComprobante"] = oComprobanteDebito.Id;
                            ctacte.AcceptChanges();
                            Facturacion oFactudarionDebito = new Facturacion();
                            dtDatosLocacion = oLocacion.ListarDatosLocacion(idLocacion);
                            //*******************************************************
                            // IVA VENTAS
                            //*******************************************************
                            if (idComprobanteTipo == (int)Comprobantes_Tipo.Tipo.FACTURA_A)
                                oFactudarionDebito.Letra = "A";
                            else
                                oFactudarionDebito.Letra = "B";

                            oFactudarionDebito.Id_Comprobantes = oComprobanteDebito.Id;
                            oFactudarionDebito.Id_Usuarios = oComprobanteDebito.Id_Usuarios;
                            oFactudarionDebito.Fecha = DateTime.Now;
                            oFactudarionDebito.Punto_Venta = oComprobanteDebito.Punto_Venta;
                            oFactudarionDebito.Numero = oComprobanteDebito.Numero;
                            oFactudarionDebito.Razon_Social = dtDatosUsuario.Rows[0]["apellido"].ToString() + dtDatosUsuario.Rows[0]["nombre"].ToString();
                            oFactudarionDebito.Fantasia = dtDatosUsuario.Rows[0]["apellido"].ToString() + dtDatosUsuario.Rows[0]["nombre"].ToString();
                            oFactudarionDebito.Calle = dtDatosLocacion.Rows[0]["calle"].ToString();
                            oFactudarionDebito.Altura = Convert.ToInt32(dtDatosLocacion.Rows[0]["Altura"]);
                            oFactudarionDebito.Localidad = dtDatosLocacion.Rows[0]["localidad"].ToString();
                            oFactudarionDebito.Cod_postal = dtDatosLocacion.Rows[0]["codigo_postal"].ToString();
                            oFactudarionDebito.Provincia = "BUENOS AIRES";
                            oFactudarionDebito.Numero_Doc = docCuit;
                            oFactudarionDebito.Cae = cae;
                            oFactudarionDebito.Cae_vencimiento = Convert.ToDateTime(vencimiento);
                            oFactudarionDebito.Id_Comprobantes_tipo = oComprobanteDebito.Id_Comprobantes_Tipo;

                            if (idTipoComprobanteUsuario == 96)//CONSUMIDOR FINAL
                                oFactudarionDebito.Id_Comprobantes_iva = (int)Comprobantes_Iva.Tipo.CONSUMIDOR_FINAL;
                            else
                                oFactudarionDebito.Id_Comprobantes_iva = (int)Comprobantes_Iva.Tipo.RESPONSABLE_INSCRIPTO;

                            oFactudarionDebito.Importe_Neto = importeNeto;
                            oFactudarionDebito.Importe_Iva = importeIva;
                            oFactudarionDebito.Importe_Impuesto_Interno = 0;
                            oFactudarionDebito.Importe_Impuesto_Nacional = 0;
                            oFactudarionDebito.Importe_Impuesto_Provincial = 0;
                            oFactudarionDebito.Importe_Impuesto_Municipal = 0;
                            oFactudarionDebito.Importe_Final = importeOriginal;
                            if (oFactudarionDebito.GuardarIvaVentas(oFactudarionDebito) > 0)
                            {
                                if (oFactudarionDebito.Guarda_Iva_Alicuotas_Afip(oFactudarionDebito))
                                {
                                    //*******************************************************
                                    // DETALLE COMPROBANTES DE DEUDA
                                    //*******************************************************
                                    dtDatosCtacte = oUsuCtaCte.ListarDatosCtaCte(idCtacte);
                                    descripcionFactura = dtDatosCtacte.Rows[0]["descripcion"].ToString();
                                    oComprobantes_Detalle.Id_Comprobantes = oComprobanteDebito.Id;
                                    oComprobantes_Detalle.Descripcion = "NOTA DE DEBITO PUNITORIOS " + descripcionFactura;
                                    oComprobantes_Detalle.Unidad = "";
                                    oComprobantes_Detalle.Cantidad = 1;
                                    oComprobantes_Detalle.Unitario = importeOriginal;
                                    oComprobantes_Detalle.Total = importeOriginal;
                                    oComprobantes_Detalle.Punitorios = 0;
                                    oComprobantes_Detalle.Bonificaciones = 0;
                                    oComprobantes_Detalle.Desde = DateTime.Now;
                                    oComprobantes_Detalle.Hasta = DateTime.Now;
                                    oComprobantes_Detalle.Descripcion_Adicional = "";
                                    oComprobantes_Detalle.Codigo = "";
                                    oComprobantes_Detalle.Id_Iva_Alicuotas = 1;
                                    oComprobantes_Detalle.Guardar(oComprobantes_Detalle);


                                    salida = "";
                                }
                                else
                                {
                                    salida = dtCae.Rows[0]["mensaje"].ToString() + " No se pudo guardar iva alicuota detalle Gies";
                                    ctacte["salida"] = salida;
                                    ctacte.AcceptChanges();
                                }
                            }
                            else
                            {
                                salida = dtCae.Rows[0]["mensaje"].ToString() + " No se pudo guardar en libro de iva ventas Gies";
                                ctacte["salida"] = salida;
                                ctacte.AcceptChanges();
                            }

                            

                        }
                        else
                        {
                            salida = dtCae.Rows[0]["mensaje"].ToString();
                            ctacte["salida"] = salida;
                            ctacte.AcceptChanges();
                        }
                    }
                    else
                    {
                        salida = "AFIP NO DEVOLVIO RESUTADOS";
                        ctacte["salida"] = salida;
                        ctacte.AcceptChanges();
                    }

                }
            }
            else
                return;
        }

        public DataTable getTotalIVAFacturado(DateTime desde, DateTime hasta)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT usuarios_ctacte.Id_Comprobantes,usuarios_ctacte_det.Id AS Id_ctacte_det,usuarios_ctacte.Id AS id_ctacte, servicios.id AS Id_Servicio, " +
                    "usuarios_ctacte.Id_comprobantes_tipo AS id_comp_tipo,  " +
                    "servicios.Descripcion AS Servicio,CONCAT(comprobantes_tipo.Nombre, ' - ', comprobantes_tipo.Letra) AS Factura, " +
                    "SUM(usuarios_ctacte_det.Importe_Original + usuarios_ctacte_det.Importe_Punitorio + usuarios_ctacte_det.importe_provincial - usuarios_ctacte_det.importe_bonificacion) AS Importe " +
                    "FROM usuarios_ctacte_det " +
                    "LEFT JOIN usuarios_ctacte ON usuarios_ctacte_det.Id_Usuarios_CtaCte = usuarios_ctacte.id " +
                    "LEFT JOIN servicios ON usuarios_ctacte_det.Id_Servicios = servicios.id " +
                    "LEFT JOIN comprobantes_tipo ON usuarios_ctacte.Id_comprobantes_tipo = comprobantes_tipo.id " +
                    "WHERE usuarios_ctacte_det.borrado = 0 AND usuarios_ctacte.borrado = 0 AND servicios.borrado = 0 " +
                    "and usuarios_ctacte.Id_Comprobantes IN(SELECT id_comprobantes FROM iva_ventas WHERE(iva_ventas.fecha between @desde AND @hasta)AND borrado = 0) " +
                    "GROUP BY servicios.id, id_comp_tipo ORDER BY servicios.id,comprobantes_tipo.Id ");
                oCon.AsignarParametroFecha("@desde", desde);
                oCon.AsignarParametroFecha("@hasta", hasta);
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

        public DataTable getTotalIVAFacturado_Detalle(DateTime desde, DateTime hasta, int id_Servicio, int id_Comprobante_Tipo)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT usuarios_ctacte.id AS Id_Ctacte , usuarios_ctacte_det.id AS Id_Ctacte_det, usuarios.id AS Id_Usu, " +
                    "usuarios_ctacte.Fecha_Movimiento AS Fecha, " +
                    "CONCAT(usuarios.Apellido, ' , ', usuarios.Nombre) AS Usuario, usuarios_ctacte.Descripcion AS Factura, " +
                    "SUM(usuarios_ctacte_det.Importe_Original + usuarios_ctacte_det.Importe_Punitorio + usuarios_ctacte_det.importe_provincial - usuarios_ctacte_det.importe_bonificacion) AS Importe, comprobantes_iva.Descripcion AS Condicion_Iva " +
                    "FROM usuarios_ctacte_det " +
                    "LEFT JOIN usuarios_ctacte ON usuarios_ctacte_det.id_usuarios_ctacte = usuarios_ctacte.id " +
                    "LEFT JOIN usuarios ON usuarios_ctacte.id_usuarios = usuarios.id " +
                    "LEFT JOIN comprobantes_iva ON usuarios.Id_Comprobantes_Iva = comprobantes_iva.id " +
                    "WHERE usuarios_ctacte_det.borrado = 0 AND usuarios.borrado = 0 AND usuarios_ctacte.borrado = 0 " +
                    "AND(DATE(usuarios_ctacte.Fecha_Movimiento) IN(SELECT fecha FROM iva_ventas WHERE(iva_ventas.fecha BETWEEN @desde AND @hasta) AND borrado = 0)) " +
                    "AND usuarios_ctacte_det.Id_Servicios = @id_Servicio AND usuarios_ctacte.Id_comprobantes_tipo = @id_Comprobante_Tipo " +
                    "GROUP BY usuarios.id, usuarios_ctacte.id ");
                oCon.AsignarParametroFecha("@desde", desde);
                oCon.AsignarParametroFecha("@hasta", hasta);
                oCon.AsignarParametroEntero("@id_Servicio", id_Servicio);
                oCon.AsignarParametroEntero("@id_Comprobante_Tipo", id_Comprobante_Tipo);
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

        public DataTable NotaDeCreditoCompleta(int IdComprobantesel, Facturacion oFacturacion)
        {

            int Codigo = 0;
            Id_Comprobantes = IdComprobantesel;
            int idTipoComprobanteUsuario = 0, numeroComprobanteTipoAfip = 0;
            double docCuit = 0;
            double nroFacturaCAE = 0;
            string CAE = "";

            Int32 PtoVenta = 0;
            Int32 IdPtoVenta = 0;
            Double NumeroNota = 0;


            Decimal Total_Provincial = 0;
            DateTime vencimientoCAE = new DateTime();
            DateTime FechaDesde = DateTime.Now;
            DateTime FechaHasta = DateTime.Now;

            DataTable dtDatosPuntoVenta = new DataTable();
            DataTable dtDatosUsuario = new DataTable();
            DataTable dtDatosNuevoCAE = new DataTable();

            DataTable dtDatosComprobante = new DataTable();

            DataTable dtDatosCtaCte = new DataTable();

            //INFORMACION DE RETORNO
            DataTable dtDatosRetorno = new DataTable();
            dtDatosRetorno = GetEstructuraRetornoComprobanteFactura();
            if (Comprobantes_Iva.CurrentComprobantes_Iva.Id == (Int32)Comprobantes_Iva.Tipo.CONSUMIDOR_FINAL)
                docCuit = Convert.ToDouble(Usuarios.CurrentUsuarioDomFiscal.Numero_Documento);
            else
                docCuit = Convert.ToDouble(Usuarios.CurrentUsuarioDomFiscal.Cuit);

            idTipoComprobanteUsuario = Comprobantes_Iva.CurrentComprobantes_Iva.Id;



            DataTable dtComprobantes = oComprobante.GetComprobante(IdComprobantesel);
            DataTable dtIvaVentas = ListarIvaVentas();
            DataTable dtIvas = ListarIvaAlicuotasDetalles();
            DataTable dtComprobantesDetalles = ListarDetalle();
            DataTable dtCompAsociados = new DataTable();

            DataColumn dcIdPuntoVenta = new DataColumn();
            dcIdPuntoVenta.DataType = typeof(int);
            dcIdPuntoVenta.DefaultValue = 0;
            dcIdPuntoVenta.ColumnName = "id_punto_venta";

            DataColumn dcNumero = new DataColumn();
            dcNumero.DataType = typeof(double);
            dcNumero.DefaultValue = 0;
            dcNumero.ColumnName = "numero";

            DataColumn dcFecha = new DataColumn();
            dcFecha.DataType = typeof(string);
            dcFecha.DefaultValue = 0;
            dcFecha.ColumnName = "fecha";

            DataColumn dcTipoComp = new DataColumn();
            dcTipoComp.DataType = typeof(int);
            dcTipoComp.DefaultValue = 0;
            dcTipoComp.ColumnName = "id_tipo_comp_afip";

            DataColumn dcCuit = new DataColumn();
            dcCuit.DataType = typeof(double);
            dcCuit.DefaultValue = 0;
            dcCuit.ColumnName = "cuit";



            dtCompAsociados.Columns.Add(dcIdPuntoVenta);
            dtCompAsociados.Columns.Add(dcNumero);
            dtCompAsociados.Columns.Add(dcFecha);
            dtCompAsociados.Columns.Add(dcTipoComp);
            dtCompAsociados.Columns.Add(dcCuit);

            DataRow drCompAsociado = dtCompAsociados.NewRow();
            drCompAsociado["cuit"] = docCuit;
            drCompAsociado["fecha"] = Convert.ToDateTime(dtComprobantes.Rows[0]["fecha"]).ToString("yyyyMMdd");
            drCompAsociado["id_tipo_comp_afip"] = Convert.ToInt32(dtComprobantes.Rows[0]["codigo_Afip"]);
            drCompAsociado["id_punto_venta"] = Convert.ToInt32(dtComprobantes.Rows[0]["id_punto_venta"]);
            drCompAsociado["numero"] = Convert.ToDouble(dtComprobantes.Rows[0]["numero"]);
            dtCompAsociados.Rows.Add(drCompAsociado);

            oComprobante.Id_Usuarios = Usuarios.CurrentUsuario.Id;
            oComprobante.Fecha = DateTime.Today;
            int idTipoComprobante = 0;
            int tipoDocumentoAfip = Ocomprobantes_Iva.GetTipoDocumentoAfip(idTipoComprobanteUsuario);

            if (tipoDocumentoAfip != 0)
            {
                if (Comprobantes_Iva.CurrentComprobantes_Iva.Letra == "A")
                    dtDatosPuntoVenta = oComprobantesHabilitados.GetDatosPuntoVenta(Convert.ToInt32(Comprobantes_Tipo.Tipo.NOTA_CREDITO_A), Puntos_Cobros.Id_Punto);
                else
                    dtDatosPuntoVenta = oComprobantesHabilitados.GetDatosPuntoVenta(Convert.ToInt32(Comprobantes_Tipo.Tipo.NOTA_CREDITO_B), Puntos_Cobros.Id_Punto);



                idTipoComprobante = Convert.ToInt32(dtDatosPuntoVenta.Rows[0]["id_comprobantes_tipo"]);
                numeroComprobanteTipoAfip = oComprobante_Tipo.getNumeroAfip(idTipoComprobante);
                if (dtDatosPuntoVenta.Rows.Count > 0)
                {
                    if (Convert.ToInt32(dtDatosPuntoVenta.Rows[0]["punto_venta_id_modalidad_facturacion"]) == 3)
                    {
                        int punto = Convert.ToInt32(dtDatosPuntoVenta.Rows[0]["num_afip"]);
                        trabajaElectronica = true;
                        if (facturacionElectronicaMensual == 1)
                            dtDatosCAE.Clear();

                        Total_Provincial = Convert.ToDecimal(dtIvaVentas.Rows[0]["importe_impuesto_provincial"]);
                        dtDatosNuevoCAE = Nuevo_Cae(dtIvas, tipoDocumentoAfip, docCuit, numeroComprobanteTipoAfip, punto, facturaDeCredito: false, FechaDesde, FechaHasta, FechaHasta, Total_Provincial, dtCompAsociados);

                        CAE = dtDatosNuevoCAE.Rows[0]["cae"].ToString();
                        vencimientoCAE = Convert.ToDateTime(dtDatosNuevoCAE.Rows[0]["vencimiento"]);
                        NumeroNota = Convert.ToDouble(dtDatosNuevoCAE.Rows[0]["numero"]);
                        Descripcion = "NOTA DE CREDITO " + Comprobantes_Iva.CurrentComprobantes_Iva.Letra + oComprobante.Punto_Venta.ToString().PadLeft(4, '0') + "-" + oComprobante.Numero.ToString().PadLeft(8, '0');

                        DataRow drDatosComprobante;
                        if (Comprobantes_Iva.CurrentComprobantes_Iva.Letra == "A")
                        {
                            drDatosComprobante = oComprobante_Tipo.GetNumeracion(Convert.ToInt32(Comprobantes_Tipo.Tipo.NOTA_CREDITO_A), Puntos_Cobros.Id_Punto);
                            oComprobante.Id_Comprobantes_Tipo = (int)Comprobantes_Tipo.Tipo.NOTA_CREDITO_A;
                            PtoVenta = Convert.ToInt32(drDatosComprobante["numPuntoVenta"]);
                            IdPtoVenta = Convert.ToInt32(drDatosComprobante["idPuntoVenta"]);
                        }


                        if (Comprobantes_Iva.CurrentComprobantes_Iva.Letra == "B")
                        {
                            drDatosComprobante = oComprobante_Tipo.GetNumeracion(Convert.ToInt32(Comprobantes_Tipo.Tipo.NOTA_CREDITO_B), Puntos_Cobros.Id_Punto);
                            oComprobante.Id_Comprobantes_Tipo = (int)Comprobantes_Tipo.Tipo.NOTA_CREDITO_B;
                            PtoVenta = Convert.ToInt32(drDatosComprobante["numPuntoVenta"]);
                            IdPtoVenta = Convert.ToInt32(drDatosComprobante["idPuntoVenta"]);
                        }

                        oComprobante.Punto_Venta = PtoVenta;

                        //*********


                        if (Convert.ToInt32(dtDatosNuevoCAE.Rows[dtDatosNuevoCAE.Rows.Count - 1]["salida"]) != 0)
                            dtDatosRetorno.Rows.Add(oComprobante.Id_Punto_Venta.ToString(), oComprobante.Punto_Venta.ToString(), dtDatosPuntoVenta.Rows[0]["punto_venta_descripcion"].ToString(), dtDatosNuevoCAE.Rows[dtDatosNuevoCAE.Rows.Count - 1]["salida"].ToString(), dtDatosNuevoCAE.Rows[dtDatosNuevoCAE.Rows.Count - 1]["mensaje"].ToString(), dtDatosPuntoVenta.Rows[0]["modalidad_facturacion_descripcion"].ToString(), Descripcion);
                    }
                    else
                    {
                        DataRow drDatosComprobante;
                        if (Comprobantes_Iva.CurrentComprobantes_Iva.Letra == "A")
                        {
                            drDatosComprobante = oComprobante_Tipo.GetNumeracion(Convert.ToInt32(Comprobantes_Tipo.Tipo.NOTA_CREDITO_A), Puntos_Cobros.Id_Punto);
                            oComprobante.Id_Comprobantes_Tipo = (int)Comprobantes_Tipo.Tipo.NOTA_CREDITO_A;
                            PtoVenta = Convert.ToInt32(drDatosComprobante["numPuntoVenta"]);
                            IdPtoVenta = Convert.ToInt32(drDatosComprobante["idPuntoVenta"]);
                            NumeroNota = Convert.ToInt32(drDatosComprobante["numcomprobante"]);
                        }


                        if (Comprobantes_Iva.CurrentComprobantes_Iva.Letra == "B")
                        {
                            drDatosComprobante = oComprobante_Tipo.GetNumeracion(Convert.ToInt32(Comprobantes_Tipo.Tipo.NOTA_CREDITO_B), Puntos_Cobros.Id_Punto);
                            oComprobante.Id_Comprobantes_Tipo = (int)Comprobantes_Tipo.Tipo.NOTA_CREDITO_B;
                            PtoVenta = Convert.ToInt32(drDatosComprobante["numPuntoVenta"]);
                            IdPtoVenta = Convert.ToInt32(drDatosComprobante["idPuntoVenta"]);
                            NumeroNota = Convert.ToInt32(drDatosComprobante["numcomprobante"]);
                        }
                    }
                }
            }
            else
            {
                dtDatosRetorno.Rows.Add(oComprobante.Id_Punto_Venta.ToString(), oComprobante.Punto_Venta.ToString(), dtDatosPuntoVenta.Rows[0]["punto_venta_descripcion"].ToString(), Convert.ToInt16(CODIGOS_RESPUESTA_FACTURACION.NO_SE_ENCUENTRA_DOCUMENTO_AFIP).ToString(), CODIGOS_RESPUESTA_FACTURACION.NO_SE_ENCUENTRA_DOCUMENTO_AFIP.ToString(), dtDatosPuntoVenta.Rows[0]["modalidad_facturacion_descripcion"].ToString(), Descripcion);
            }

            //***************************************************
            //    COMPROBANTE DE DEUDA
            //***************************************************

            oComprobante.Id_Usuarios = Usuarios.CurrentUsuario.Id;
            oComprobante.Fecha = DateTime.Now;
            oComprobante.Numero = (Int32)NumeroNota;
            oComprobante.Id_Punto_Venta = IdPtoVenta;
            oComprobante.Punto_Venta = PtoVenta;
            oComprobante.Id_Personal = Personal.Id_Login;
            oComprobante.Id_Punto_Cobro = Puntos_Cobros.Id_Punto;
            oComprobante.Id_Usuarios_Locaciones = Usuarios.Current_IdUsuarioLocacion;
            oComprobante.Importe = Convert.ToDecimal(dtComprobantes.Rows[0]["importe"].ToString());
            oComprobante.Descripcion = Descripcion;
            oComprobante.Id = oComprobante.Guardar(oComprobante); //guardar el comprobante de nota de crédito
            if (Convert.ToInt32(dtDatosPuntoVenta.Rows[0]["punto_venta_id_modalidad_facturacion"]) != 3 &&
                oComprobante.Id > 0)
            {
                oComprobante_Tipo.SetNumeracion(oComprobante.Id_Punto_Venta, oComprobante.Id_Comprobantes_Tipo, oComprobante.Numero);
            }

            //*******************************************************
            // IVA VENTAS
            //*******************************************************
            oFacturacion.Letra = Comprobantes_Iva.CurrentComprobantes_Iva.Letra;
            oFacturacion.Id_Comprobantes = oComprobante.Id;
            oFacturacion.Id_Usuarios = Usuarios.CurrentUsuario.Id;
            oFacturacion.Fecha = DateTime.Now;
            oFacturacion.Punto_Venta = PtoVenta;
            oFacturacion.Numero = (Int32)NumeroNota;
            oFacturacion.Razon_Social = dtIvaVentas.Rows[0]["Razon_Social"].ToString();
            oFacturacion.Fantasia = dtIvaVentas.Rows[0]["Fantasia"].ToString();
            oFacturacion.Calle = dtIvaVentas.Rows[0]["Calle"].ToString();
            oFacturacion.Altura = Convert.ToInt32(dtIvaVentas.Rows[0]["Altura"].ToString());
            oFacturacion.Localidad = dtIvaVentas.Rows[0]["Localidad"].ToString();
            oFacturacion.Cod_postal = dtIvaVentas.Rows[0]["Codigo_postal"].ToString();
            oFacturacion.Provincia = dtIvaVentas.Rows[0]["Provincia"].ToString();
            oFacturacion.Numero_Doc = docCuit;
            oFacturacion.Cae = CAE;
            oFacturacion.Cae_vencimiento = vencimientoCAE;
            oFacturacion.Id_Comprobantes_tipo = oComprobante.Id_Comprobantes_Tipo;
            oFacturacion.Id_Comprobantes_iva = Comprobantes_Iva.CurrentComprobantes_Iva.Id;
            oFacturacion.Importe_Neto = Convert.ToDecimal(dtIvaVentas.Rows[0]["Importe_Neto"].ToString());
            oFacturacion.Importe_Iva = Convert.ToDecimal(dtIvaVentas.Rows[0]["Importe_Iva"].ToString());
            oFacturacion.Importe_Impuesto_Interno = Convert.ToDecimal(dtIvaVentas.Rows[0]["Importe_Impuesto_Interno"].ToString());
            oFacturacion.Importe_Impuesto_Nacional = Convert.ToDecimal(dtIvaVentas.Rows[0]["Importe_Impuesto_Nacional"].ToString());
            oFacturacion.Importe_Impuesto_Provincial = Convert.ToDecimal(dtIvaVentas.Rows[0]["Importe_Impuesto_Provincial"].ToString());
            oFacturacion.Importe_Impuesto_Municipal = Convert.ToDecimal(dtIvaVentas.Rows[0]["Importe_Impuesto_Municipal"].ToString());

            oFacturacion.Importe_Final = Convert.ToDecimal(dtIvaVentas.Rows[0]["Importe_Final"].ToString());

            oFacturacion.GuardarIvaVentas(oFacturacion);


            //*******************************************************
            // ALICUOTAS
            //*******************************************************
            foreach (DataRow drIva in dtIvas.Rows)
            {
                if (Convert.ToDecimal(drIva["importe_neto"].ToString()) > 0)
                    GuardarIvalicuotas(oFacturacion, drIva);
            }

            //*******************************************************
            // DETALLE COMPROBANTES DE DEUDA
            //*******************************************************

            foreach (DataRow DrItem in dtComprobantesDetalles.Rows)
            {
                oComprobantes_Detalle.Id_Comprobantes = oComprobante.Id;
                oComprobantes_Detalle.Descripcion = DrItem["descripcion"].ToString();
                oComprobantes_Detalle.Unidad = DrItem["unidad"].ToString();
                oComprobantes_Detalle.Cantidad = 1;
                oComprobantes_Detalle.Unitario = Convert.ToDecimal(DrItem["unitario"].ToString());
                oComprobantes_Detalle.Total = Convert.ToDecimal(DrItem["total"].ToString());
                oComprobantes_Detalle.Punitorios = Convert.ToDecimal(DrItem["punitorios"].ToString());
                oComprobantes_Detalle.Bonificaciones = Convert.ToDecimal(DrItem["bonificaciones"].ToString());
                oComprobantes_Detalle.Desde = Convert.ToDateTime(DrItem["desde"].ToString());
                oComprobantes_Detalle.Hasta = Convert.ToDateTime(DrItem["hasta"].ToString());
                oComprobantes_Detalle.Descripcion_Adicional = DrItem["descripcion_adicional"].ToString();

                oComprobantes_Detalle.Codigo = "";
                oComprobantes_Detalle.Unidad = "";
                oComprobantes_Detalle.Id_Iva_Alicuotas = 1;
                oComprobantes_Detalle.Guardar(oComprobantes_Detalle);
            }

            oCon.CrearComando(String.Format("select * from vw_usuarios_ctacte where id_comprobantes={0}", IdComprobantesel));//trae registros ctacte relacionados al comprobante
            dtDatosCtaCte = oCon.Tabla();
            oCon.DesConectar();

            foreach (DataRow dr in dtDatosCtaCte.Rows)
            {
                DataTable dtComprobanteOriginal = oComprobante.GetComprobante(Convert.ToInt32(dr["id_comprobantes_ref"]));
                Descripcion = dtComprobanteOriginal.Rows[0]["descripcion"].ToString();
                if (Convert.ToInt32(dtComprobantes.Rows[0]["id_debito_asociado"]) > 0)
                    oUsuCtaCte.ConvertirComprobante((int)Comprobantes_Tipo.Tipo.COMPROBANTE_DEUDA, Descripcion, Convert.ToInt32(dr["id"]), modificaPercepcion: false);
                else
                    oUsuCtaCte.ConvertirComprobante((int)Comprobantes_Tipo.Tipo.COMPROBANTE_DEUDA, Descripcion, Convert.ToInt32(dr["id"]));
                oUsuCtaCte.GuardarCtaCteComprobante(Convert.ToInt32(dr["id"]), oComprobante.Id);
            }

            return dtDatosRetorno;


        }

        public int AsignarDatosUsuarioAComprobanteEIvaVentas(int idUsuarioLocacion, int idComprobante, int idIvaVentas)
        {
            int resultado = 0;
            Usuarios_Locaciones oUsuLoc = new Usuarios_Locaciones();
            oUsuLoc = oUsuLoc.GetLocacion(idUsuarioLocacion);
            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();
                string comandoComprobante = "UPDATE comprobantes SET id_usuarios = @idUsuario, id_usuarios_locaciones =  @idLocacion WHERE id = @idComp";
                oCon.CrearComando(comandoComprobante);
                oCon.AsignarParametroEntero("@idUsuario", oUsuLoc.Id_Usuarios);
                oCon.AsignarParametroEntero("@idLocacion", oUsuLoc.Id);
                oCon.AsignarParametroEntero("@idComp", idComprobante);
                oCon.EjecutarComando();

                string comandoIvaVentas = "UPDATE iva_Ventas SET id_usuario = @idUs, id_usuarios_locacion = @idLoc, Razon_Social = @razonSocial, Fantasia = @fantasia, " +
                    "Localidad = @loc, Calle = @calle, Altura = @altura, estado = @estado where id = @idIvaVentas";
                oCon.CrearComando(comandoIvaVentas);
                oCon.AsignarParametroEntero("@idUs", oUsuLoc.Id_Usuarios);
                oCon.AsignarParametroEntero("@idLoc", oUsuLoc.Id);
                oCon.AsignarParametroCadena("@razonSocial", oUsuLoc.Usuario);
                oCon.AsignarParametroCadena("@fantasia", oUsuLoc.Usuario);
                oCon.AsignarParametroCadena("@loc", oUsuLoc.Localidad);
                oCon.AsignarParametroCadena("@calle", oUsuLoc.Calle);
                oCon.AsignarParametroEntero("@altura", oUsuLoc.Altura);
                oCon.AsignarParametroEntero("@idIvaVentas", idIvaVentas);
                oCon.AsignarParametroEntero("@estado", Convert.ToInt32(ESTADO_IVA_VENTAS.VERIFICAR_CTACTE));
                oCon.EjecutarComando();

                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                resultado = 1;
                oCon.CancelarTransaccion();
                oCon.DesConectar();
            }
            return resultado;
        }

        public void ActualizarEstadoIvaVentas(int idIvaVentas, ESTADO_IVA_VENTAS estado)
        {
            try
            {
                oCon.Conectar();
                string comando = "UPDATE iva_ventas SET estado = @estado WHERE id = @idIvaVentas";
                oCon.CrearComando(comando);
                oCon.AsignarParametroEntero("@estado", Convert.ToInt32(estado));
                oCon.AsignarParametroEntero("@idIvaVentas", idIvaVentas);
                oCon.EjecutarComando();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }
        }

        public DataTable getDeudasBAPRO()
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("select codigo, CONCAT(Apellido, ' , ', Nombre) AS Usuario,IFNULL(usuarios.numero_documento,0) AS dni, " +
                    "IFNULL((select sum(importe_saldo) from usuarios_ctacte where id_usuarios = usuarios.id and borrado = 0 AND usuarios_ctacte.importe_Saldo > 0), 0) as saldo_total, " +
                    "IFNULL((SELECT importe_saldo from usuarios_ctacte where borrado = 0 AND usuarios_ctacte.importe_saldo > 0 and id_usuarios = usuarios.id order by fecha_desde desc LIMIT 1),0) as saldo_mensual, " +
                    "IFNULL((select MAX(DATE(fecha_desde)) from usuarios_ctacte where id_usuarios = usuarios.id and borrado = 0 AND usuarios_ctacte.importe_saldo > 0),  '2021-01-01') as FechaActual, " +
                    "IFNULL((SELECT usuarios_ctacte.Numero from usuarios_ctacte where borrado = 0 AND usuarios_ctacte.importe_saldo>0 and id_usuarios = usuarios.id order by fecha_desde desc LIMIT 1 ),0) as numComp " +
                    "from usuarios " +
                    "LIMIT 100 ");
 
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