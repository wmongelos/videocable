using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;

namespace CapaNegocios
{
    public class Usuarios_CtaCte_Recibos
    {
        #region [get del recibo]
        public Int32 Id_Usuarios_CtaCte { get; set; }
        public Int32 Id { get; set; }
        public Int32 Id_Usuarios { get; set; }
        public Int32 Id_Usuarios_Locacion { get; set; }
        public Int32 Id_Comprobantes { get; set; }
        public Int32 Id_Comprobantes_Tipo { get; set; }
        public DateTime Fecha_Movimiento { get; set; }
        public DateTime Fecha_Desde { get; set; }
        public DateTime Fecha_Hasta { get; set; }
        public String Descripcion { get; set; }
        public Decimal Importe_Original { get; set; }
        public Decimal Importe_Punitorio { get; set; }
        public Decimal Importe_Bonificacion { get; set; }
        public Decimal Importe_Provincial { get; set; }
        public Decimal Importe_Final { get; set; }
        public Decimal Importe_Saldo { get; set; }
        public Decimal Importe_Rendido { get; set; }
        public Int32 Numero { get; set; }
        public Int32 Id_Comprobantes_Ref { get; set; }
        public Int32 Id_Puntos_Cobro { get; set; }
        public Int32 Id_Personal { get; set; }
        public Int32 Estado { get; set; }
        public Int32 Id_Caja_Diaria { get; set; }
        public String Numero_Muestra { get; set; }
        public Int32 Numero_Hasta { get; set; }
        public Int16 Recibo_Tipo { get; set; }
        public Int32 Id_Cobrador { get; set; }
        public Int32 Id_Punto_Venta { get; set; }
        public Int32 Id_Presentacion_Deb { get; set; }
        #endregion

        private Conexion oCon = new Conexion();
        private Comprobantes_Detalle oComprobantes_Detalle = new Comprobantes_Detalle();
        private Comprobantes oComprobantes = new Comprobantes();
        public enum CAJAS
        {
            BLANCO = 1,
            NEGRO = 2
        }

        private bool PreGuardar(Usuarios_CtaCte_Recibos oUsuarios_CtaCte_Recibos, Int32 cuenta, out string salida, Int32 idPuntoCobrador = 0, Int32 IdNroLiquidacion = 0)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("INSERT INTO usuarios_ctacte_recibos(Id_Usuarios, Id_Usuarios_Locaciones, Id_Comprobantes, Fecha_Movimiento, Id_Puntos_Cobros, Numero, Id_personal, Importe_Recibo, Importe_Saldo, Estado, Id_Caja_Diaria,numero_muestra,cuenta,id_punto_venta,id_referencia,id_presentacion_deb) " +
                                    "VALUES(@idUsuario, @idLocacion, @idComprobante, @fecha, @idPtoCobro, @nroRecibo, @idPersonal, @importe, @saldo, @estado, @idCaja,@numero_muestra,@cuenta,@idPuntoVenta,@idnroliquidacion,@idpresentacion); SELECT @@IDENTITY");
                oCon.AsignarParametroEntero("@idUsuario", Id_Usuarios);
                oCon.AsignarParametroEntero("@idLocacion", Id_Usuarios_Locacion);
                oCon.AsignarParametroEntero("@idComprobante", Id_Comprobantes);
                oCon.AsignarParametroFecha("@fecha", Fecha_Movimiento);
                if (idPuntoCobrador != 0)
                    oCon.AsignarParametroEntero("@idPtoCobro", idPuntoCobrador);
                else
                    oCon.AsignarParametroEntero("@idPtoCobro", oUsuarios_CtaCte_Recibos.Id_Puntos_Cobro);
                oCon.AsignarParametroEntero("@nroRecibo", Numero);
                oCon.AsignarParametroEntero("@idPersonal", Personal.Id_Login);
                oCon.AsignarParametroDecimal("@importe", Importe_Final);
                oCon.AsignarParametroDecimal("@saldo", 0);
                oCon.AsignarParametroEntero("@estado", 0);
                if (IdNroLiquidacion > 0)
                    oCon.AsignarParametroEntero("@idCaja", Id_Caja_Diaria);
                else
                    oCon.AsignarParametroEntero("@idCaja", 0);
                oCon.AsignarParametroCadena("@numero_muestra", Numero_Muestra);
                oCon.AsignarParametroEntero("@cuenta", cuenta);
                oCon.AsignarParametroEntero("@idPuntoVenta", Id_Punto_Venta);
                oCon.AsignarParametroEntero("@idnroliquidacion", IdNroLiquidacion);
                oCon.AsignarParametroEntero("@idpresentacion", oUsuarios_CtaCte_Recibos.Id_Presentacion_Deb);
                oCon.ComenzarTransaccion();
                Id = oCon.EjecutarScalar();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
                oUsuarios_CtaCte_Recibos.Id = Id;
                salida = "";
                return true;
            }
            catch (Exception c)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                salida = c.Message;
                return false;
                //throw;
            }
        }
   
        public bool guardar(Usuarios_CtaCte_Recibos oUsuarios_CtaCte_Recibos, DataTable dtf, DataTable dtt, Int32 cuenta, out string salida, Int32 idPuntoCobrador = 0, Int32 IdNroLiquidacion = 0)
        {
            string salidaAux = "";
            if (dtt.Rows.Count > 0)
            {
                DataColumn DcPorcentajeIva = new DataColumn("porcentaje_iva", typeof(string));
                DcPorcentajeIva.DefaultValue = "0";
                dtt.Columns.Add(DcPorcentajeIva);
                foreach (DataRow fila in dtt.Select("encabezado=0"))
                {
                    fila["porcentaje_iva"] = GetPorcentajeIva(Convert.ToInt32(fila["id"]));
                }
            }

            if (PreGuardar(oUsuarios_CtaCte_Recibos, cuenta, out salidaAux, idPuntoCobrador, IdNroLiquidacion))
            {
                Int32 idr = Id;
                String servi = "", comp = "";
                if (GuardarDetallesPago(oUsuarios_CtaCte_Recibos.Id, Id_Comprobantes, dtf, out salidaAux))
                {
                    foreach (DataRow dr in dtt.Rows) ///detalles de los pagos que realizo
                    {
                        if (Convert.ToInt32(dr["id_usuarios_locaciones"].ToString()) == Id_Usuarios_Locacion)
                        {

                            var importe = Decimal.Parse(dr["importe_pago"].ToString());
                            var importe_punitorio = Decimal.Parse(dr["importe_punitorio"].ToString());
                            var importe_bonicacion = Decimal.Parse(dr["importe_bonificacion"].ToString());
                            var importe_Provincial = Decimal.Parse(dr["importe_Provincial"].ToString());
                            var id_usuario_ctacte = Int32.Parse(dr["Id_usuarios_ctacte"].ToString());
                            var id_usuario_ctacte_det = Int32.Parse(dr["Id"].ToString()); //id ctacte
                            var id_tipo = Int32.Parse(dr["Id_tipo"].ToString()); // id subservicio
                            var id_servicios = Int32.Parse(dr["Id_servicios"].ToString());
                            var porcentaje_iva = Decimal.Parse(dr["porcentaje_iva"].ToString());

                            if (Convert.ToInt32(dr["presenta_ventas"].ToString()) == 1) // ya es una factura y trae por arrastre las percepciones
                                importe_Provincial = 0;

                            String Descripcion_v = "";
                            Decimal Importe = 0;
                            if (Convert.ToInt32(dr["encabezado"]) == 2)
                            {
                                comp = dr["servicio"].ToString().Trim();

                                if (Int32.Parse(dr["id_comprobantes_tipo"].ToString()) == (int)Comprobantes_Tipo.Tipo.COMPROBANTE_DEUDA)
                                    comp = Descripcion;
                            }

                            if (Convert.ToInt32(dr["encabezado"]) == 1)
                                servi = dr["servicio"].ToString().Trim();

                            if (Int32.Parse(dr["encabezado"].ToString()) == 0) /// s la linea de subservicio
                            {
                                //consulto los datos del recibo, y obtengo los datos para actualizarlos y meter los importees nuevos

                                //aca consulto

                                if (dr["tipo"].ToString() != "C") // si es c es un craedito a cuenta
                                {
                                    DataTable dtDatosRecibo = new DataTable();
                                    oCon.CrearComando("SELECT importe_pago,importe_saldo,importe_punitorio,importe_provincial,importe_original,importe_bonificacion FROM usuarios_ctacte where id=@id1");
                                    oCon.AsignarParametroEntero("@id1", id_usuario_ctacte);
                                    dtDatosRecibo = oCon.Tabla();

                                    //aca obtengo los valores de las consulta
                                    decimal importePago = Convert.ToDecimal(dtDatosRecibo.Rows[0]["importe_pago"]);
                                    decimal importeSaldo = Convert.ToDecimal(dtDatosRecibo.Rows[0]["importe_saldo"]);
                                    decimal importeProvincial = Convert.ToDecimal(dtDatosRecibo.Rows[0]["importe_provincial"]);
                                    decimal importePunitorio = Convert.ToDecimal(dtDatosRecibo.Rows[0]["importe_punitorio"]);
                                    decimal importeOriginal = Convert.ToDecimal(dtDatosRecibo.Rows[0]["importe_original"]);
                                    decimal importeBonificacion = Convert.ToDecimal(dtDatosRecibo.Rows[0]["importe_bonificacion"]);

                                    //aca calculo los nuevos valores
                                    decimal nuevoImportePago = importePago + importe;
                                    decimal nuevoImporteProvincial = importeProvincial + Importe_Provincial;
                                    decimal nuevoImporteFinal = importeOriginal + nuevoImporteProvincial + importePunitorio - importeBonificacion;
                                    decimal nuevoImporteSaldo = nuevoImporteFinal - nuevoImportePago;
                                    int nuevoEstado = 0;
                                    if (Math.Abs(nuevoImporteSaldo) >= 1)
                                        nuevoEstado = 0;
                                    else
                                        nuevoEstado = 1;

                                    if (nuevoImporteSaldo < 1)
                                        nuevoImporteSaldo = 0;

                                    //aca se meten los datos procesados al ctacte
                                    oCon.Conectar();
                                    oCon.CrearComando("UPDATE usuarios_ctacte set id_usuarios_ctacte_recibos=@Idr,importe_pago =@importepago,importe_provincial = @importeii,importe_final=@importefinal,importe_saldo=@importesaldo,estado=@estado1 where id = @Idc");
                                    oCon.AsignarParametroEntero("@Idc", id_usuario_ctacte);
                                    oCon.AsignarParametroEntero("@Idr", idr);
                                    oCon.AsignarParametroDecimal("@importepago", nuevoImportePago);
                                    oCon.AsignarParametroDecimal("@importeii", nuevoImporteProvincial);
                                    oCon.AsignarParametroDecimal("@importefinal", nuevoImporteFinal);
                                    oCon.AsignarParametroDecimal("@importesaldo", nuevoImporteSaldo);
                                    oCon.AsignarParametroDecimal("@estado", nuevoEstado);
                                    oCon.EjecutarComando();


                                    //traigo los datos del usuarios_Ctacte_det 

                                    oCon.CrearComando("SELECT importe_pago,importe_saldo,importe_punitorio,importe_provincial,importe_original,importe_bonificacion FROM usuarios_ctacte_det where id=@idctactedet");
                                    oCon.AsignarParametroEntero("@idctactedet", id_usuario_ctacte_det);
                                    DataTable dtDatosCtacteDet = oCon.Tabla();
                                    oCon.DesConectar();
                                    //aca obtengo los valores de las consulta
                                    importePago = Convert.ToDecimal(dtDatosCtacteDet.Rows[0]["importe_pago"]);
                                    importeSaldo = Convert.ToDecimal(dtDatosCtacteDet.Rows[0]["importe_saldo"]);
                                    importeProvincial = Convert.ToDecimal(dtDatosCtacteDet.Rows[0]["importe_provincial"]);
                                    importePunitorio = Convert.ToDecimal(dtDatosCtacteDet.Rows[0]["importe_punitorio"]);
                                    importeOriginal = Convert.ToDecimal(dtDatosCtacteDet.Rows[0]["importe_original"]);
                                    importeBonificacion = Convert.ToDecimal(dtDatosCtacteDet.Rows[0]["importe_bonificacion"]);

                                    //aca calculo los nuevos valores
                                    nuevoImportePago = importePago + importe;
                                    nuevoImporteProvincial = importeProvincial + Importe_Provincial;
                                    nuevoImporteFinal = importeOriginal + nuevoImporteProvincial + importePunitorio - importeBonificacion;
                                    nuevoImporteSaldo = nuevoImporteFinal - nuevoImportePago;

                                    Usuarios_CtaCte_Det oDet = new Usuarios_CtaCte_Det();
                                    if (!oDet.ActualizarDetallesConRecibos(id_usuario_ctacte_det, nuevoImportePago, nuevoImporteProvincial, nuevoImporteSaldo, out salidaAux))
                                    {
                                        salida = salidaAux;
                                        return false;
                                    }

                                }
                                int TipoCreditoCuenta = 0;
                                if (Convert.ToInt32(dr["Id_Comprobantes_Tipo"]) == (int)Comprobantes_Tipo.Tipo.CREDITO_A_CUENTA)
                                {
                                    if (((Convert.ToInt32(dr["Id_Tipo"]) == 0) && ((Convert.ToInt32(dr["Id_Comprobantes"]) == 0))))
                                        TipoCreditoCuenta = (int)Comprobantes.NUEVO.NUEVO;
                                    else
                                        TipoCreditoCuenta = (int)Comprobantes.NUEVO.GENERADO;
                                }
                                int nuevo;
                                if (Convert.ToInt32(dr["Id_Comprobantes_Tipo"]) == (int)Comprobantes_Tipo.Tipo.CREDITO_A_CUENTA)
                                    nuevo = TipoCreditoCuenta;
                                else
                                    nuevo = 0;
                                if (GuardarRelacion(Id, id_usuario_ctacte, id_usuario_ctacte_det, importe, importe_Provincial, importe_punitorio, id_tipo, porcentaje_iva, nuevo, out salidaAux))
                                {
                                    if (GuardarRelacionReciboServicio(Id, id_servicios, id_tipo, Importe, importe_punitorio, Importe_Bonificacion, importe_Provincial, out salidaAux))
                                    {
                                        if (Convert.ToInt32(dr["id"].ToString()) == 0)
                                        {
                                            Descripcion_v = "Credito a favor ";
                                            Importe = decimal.Round(decimal.Multiply(Convert.ToDecimal(dr["importe_pago"].ToString()), -1), 2);
                                        }
                                        else
                                        {
                                            Descripcion_v = comp + " " + servi + " - " + dr["servicio"].ToString().ToLower();
                                            Importe = Convert.ToDecimal(dr["importe_total"].ToString());
                                        }
                                    }
                                    else
                                    {
                                        salida = salidaAux;
                                        return false;
                                    }
                                }
                                else
                                {
                                    salida = salidaAux;
                                    return false;
                                }
                            }
                            if (cuenta == Convert.ToInt32(CAJAS.BLANCO) && Convert.ToInt32(dr["encabezado"]) == 2)
                            {
                                oComprobantes_Detalle.Descripcion = dr["servicio"].ToString();
                                oComprobantes_Detalle.Unidad = "";
                                oComprobantes_Detalle.Cantidad = 1;
                                oComprobantes_Detalle.Unitario = Convert.ToDecimal(dr["importe_total"].ToString());
                                oComprobantes_Detalle.Total = Convert.ToDecimal(dr["importe_total"].ToString());
                                oComprobantes_Detalle.Desde = Convert.ToDateTime(dr["fecha_desde"].ToString());
                                oComprobantes_Detalle.Hasta = Convert.ToDateTime(dr["fecha_hasta"].ToString());
                                oComprobantes_Detalle.Descripcion_Adicional = "";
                                oComprobantes_Detalle.Codigo = "";
                                oComprobantes_Detalle.Unidad = "";
                                oComprobantes_Detalle.Id_Comprobantes = Id_Comprobantes;
                                oComprobantes_Detalle.Guardar(oComprobantes_Detalle);
                            }
                            else if (cuenta == Convert.ToInt32(CAJAS.NEGRO) && Convert.ToInt32(dr["encabezado"]) == 0)
                            {
                                oComprobantes_Detalle.Descripcion = dr["servicio"].ToString();
                                oComprobantes_Detalle.Unidad = "";
                                oComprobantes_Detalle.Cantidad = 1;
                                oComprobantes_Detalle.Unitario = Convert.ToDecimal(dr["importe_total"].ToString());
                                oComprobantes_Detalle.Total = Convert.ToDecimal(dr["importe_total"].ToString());
                                oComprobantes_Detalle.Desde = Convert.ToDateTime(dr["fecha_desde"].ToString());
                                oComprobantes_Detalle.Hasta = Convert.ToDateTime(dr["fecha_hasta"].ToString());
                                oComprobantes_Detalle.Descripcion_Adicional = "";
                                oComprobantes_Detalle.Codigo = "";
                                oComprobantes_Detalle.Unidad = "";
                                oComprobantes_Detalle.Id_Comprobantes = Id_Comprobantes;
                                oComprobantes_Detalle.Guardar(oComprobantes_Detalle);
                            }

                        }
                    }
                    Usuarios_Locaciones.ActualizarSaldo(oUsuarios_CtaCte_Recibos.Id_Usuarios_Locacion);
                }
                else
                {
                    salida = salidaAux;
                    return false;
                }

                if (dtt.Rows.Count > 0)
                {
                    int indexColumn = dtt.Columns.IndexOf("porcentaje_iva");
                    if (indexColumn > -1)
                        dtt.Columns.RemoveAt(indexColumn);
                }
                salida = "";
                return true;
            }
            else
            {
                salida = salidaAux;
                return false;
            }

        }

        public Int32 guardar(Usuarios_CtaCte_Recibos oUsuarios_CtaCte_Recibos, int cuenta, DataTable dtPagos = null)
        {
            Int32 retorno = 0;
            Int32 idRecibo = 0;
            try
            {

                oCon.Conectar();
                oCon.CrearComando("INSERT INTO usuarios_ctacte_recibos(Id_Usuarios, Id_Usuarios_Locaciones, Id_Comprobantes, Fecha_Movimiento, Id_Puntos_Cobros, Numero, Id_personal, Importe_Recibo, Importe_Saldo, Estado, Id_Caja_Diaria,numero_muestra,cuenta,Id_Cobrador,Importe_Rendido,numero_hata,recibo_tipo) " +
                                    "VALUES(@idUsuario, @idLocacion, @idComprobante, @fecha, @idPtoCobro, @nroRecibo, @idPersonal, @importe, @saldo, @estado, @idCaja,@numero_muestra,@cuenta,@idCobrador,@idImporte_Rendido,@numero_hasta,@recibo_tipo); SELECT @@IDENTITY");
                oCon.AsignarParametroEntero("@idUsuario", oUsuarios_CtaCte_Recibos.Id_Usuarios);
                oCon.AsignarParametroEntero("@idLocacion", oUsuarios_CtaCte_Recibos.Id_Usuarios_Locacion);
                oCon.AsignarParametroEntero("@idComprobante", oUsuarios_CtaCte_Recibos.Id_Comprobantes);
                oCon.AsignarParametroFecha("@fecha", oUsuarios_CtaCte_Recibos.Fecha_Movimiento);
                oCon.AsignarParametroEntero("@idPtoCobro", oUsuarios_CtaCte_Recibos.Id_Puntos_Cobro);
                oCon.AsignarParametroEntero("@nroRecibo", oUsuarios_CtaCte_Recibos.Numero);
                oCon.AsignarParametroEntero("@idPersonal", oUsuarios_CtaCte_Recibos.Id_Personal);
                oCon.AsignarParametroDecimal("@importe", oUsuarios_CtaCte_Recibos.Importe_Final);
                oCon.AsignarParametroDecimal("@saldo", oUsuarios_CtaCte_Recibos.Importe_Saldo);
                oCon.AsignarParametroEntero("@estado", oUsuarios_CtaCte_Recibos.Estado);
                oCon.AsignarParametroEntero("@idCaja", oUsuarios_CtaCte_Recibos.Id_Caja_Diaria);
                oCon.AsignarParametroCadena("@numero_muestra", oUsuarios_CtaCte_Recibos.Numero_Muestra);
                oCon.AsignarParametroEntero("@cuenta", cuenta);
                oCon.AsignarParametroEntero("@idCobrador", oUsuarios_CtaCte_Recibos.Id_Cobrador);
                oCon.AsignarParametroDecimal("@idImporte_Rendido", oUsuarios_CtaCte_Recibos.Importe_Rendido);
                oCon.AsignarParametroEntero("@numero_hasta", oUsuarios_CtaCte_Recibos.Numero_Hasta);
                oCon.AsignarParametroEntero("@recibo_tipo", oUsuarios_CtaCte_Recibos.Recibo_Tipo);
                oCon.ComenzarTransaccion();
                idRecibo = oCon.EjecutarScalar();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                retorno = -1;
                oCon.CancelarTransaccion();
                oCon.DesConectar();
            }
            if (dtPagos != null && idRecibo > 0)
            {
                oCon.Conectar();
                foreach (DataRow item in dtPagos.Rows)
                {
                    Int32 codUsu = Convert.ToInt32(item["cod_usu"]);
                    Decimal importe = Convert.ToDecimal(item["monto"]);
                    String cliente = item["titular"].ToString();
                    String cuenta_banco = item["cuenta"].ToString();
                    String cuit = item["cuit"].ToString();
                    String banco = item["banco"].ToString();
                    String sucursal = item["sucursal"].ToString();
                    DateTime fc = DateTime.Now;
                    DateTime fa = DateTime.Now;
                    Int32 id_formas_de_pago = Convert.ToInt32(item["Id_forma_pago"]);
                    var numero_f = Int32.Parse(item["numero"].ToString());

                    oCon.CrearComando("INSERT INTO usuarios_ctacte_recibos_det(Id_Usuarios_ctacte_recibos, Id_formas_de_pago, importe,cuit,nombre,sucursal,fecha_comprobante,fecha_acreditacion,numero,cuenta,banco, Id_Comprobantes,cod_usuario) " +
                                                                      "VALUES(@id_usuarios_ctacte_recibos, @id_formas_de_pago, @importe, @cuit, @nombre, @sucursal, @fecha_comprobante, @fecha_acreditacion, @numero_f, @cuenta_banco,@banco,@idComprobante,@codUsuario); ");

                    oCon.AsignarParametroEntero("@id_usuarios_ctacte_recibos", idRecibo);
                    oCon.AsignarParametroEntero("@id_formas_de_pago", id_formas_de_pago);
                    oCon.AsignarParametroDecimal("@importe", importe);
                    oCon.AsignarParametroCadena("@cuit", cuit);
                    oCon.AsignarParametroCadena("@nombre", cliente);
                    oCon.AsignarParametroCadena("@sucursal", sucursal);
                    oCon.AsignarParametroFecha("@fecha_comprobante", fc);
                    oCon.AsignarParametroFecha("@fecha_acreditacion", fa);
                    oCon.AsignarParametroEntero("@numero_f", numero_f);
                    oCon.AsignarParametroCadena("@cuenta_banco", cuenta_banco);
                    oCon.AsignarParametroCadena("@banco", banco);
                    oCon.AsignarParametroEntero("@idComprobante", Id_Comprobantes);
                    oCon.AsignarParametroEntero("@codUsuario", codUsu);

                    oCon.ComenzarTransaccion();
                    oCon.EjecutarComando();
                    oCon.ConfirmarTransaccion();
                }
                oCon.DesConectar();
            }
            return retorno;
        }

        public Int32 Guarda_Recibos(Usuarios_CtaCte_Recibos oCtacte_Recibo)
        {
            int id_Recibo = 0;
            try
            {
                oCon.Conectar();
                oCon.CrearComando("INSERT INTO usuarios_ctacte_recibos(Id_Usuarios, Id_Usuarios_Locaciones, Id_Comprobantes, Fecha_Movimiento, Id_Puntos_Cobros, Numero, Id_personal, Importe_Recibo, Importe_Saldo, Estado, Id_Caja_Diaria,numero_muestra,cuenta,id_punto_venta,id_referencia,id_presentacion_deb,importe_rendido) " +
                                    "VALUES(@idUsuario, @idLocacion, @idComprobante, @fecha, @idPtoCobro, @nroRecibo, @idPersonal, @importe, @saldo, @estado, @idCaja,@numero_muestra,@cuenta,@idPuntoVenta,@idnroliquidacion,@idpresentacion,@rendido); SELECT @@IDENTITY");
                oCon.AsignarParametroEntero("@idUsuario", oCtacte_Recibo.Id_Usuarios);
                oCon.AsignarParametroEntero("@idLocacion", oCtacte_Recibo.Id_Usuarios_Locacion);
                oCon.AsignarParametroEntero("@idComprobante", oCtacte_Recibo.Id_Comprobantes);
                oCon.AsignarParametroFecha("@fecha", oCtacte_Recibo.Fecha_Movimiento);
                oCon.AsignarParametroEntero("@idPtoCobro", Puntos_Cobros.Id_Punto);
                oCon.AsignarParametroEntero("@nroRecibo", oCtacte_Recibo.Numero);
                oCon.AsignarParametroEntero("@idPersonal", Personal.Id_Login);
                oCon.AsignarParametroDecimal("@importe", oCtacte_Recibo.Importe_Final);
                oCon.AsignarParametroDecimal("@saldo", 0);
                oCon.AsignarParametroEntero("@estado", 0);
                oCon.AsignarParametroEntero("@idCaja", 0);
                oCon.AsignarParametroCadena("@numero_muestra", oCtacte_Recibo.Numero_Muestra);
                oCon.AsignarParametroEntero("@cuenta", 0);
                oCon.AsignarParametroEntero("@idPuntoVenta", 0);
                oCon.AsignarParametroEntero("@idnroliquidacion", 0);
                oCon.AsignarParametroEntero("@idpresentacion", 0);
                oCon.AsignarParametroDecimal("@rendido", oCtacte_Recibo.Importe_Final);
                oCon.ComenzarTransaccion();
                id_Recibo = oCon.EjecutarScalar();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
                oCtacte_Recibo.Id = Id;
                return id_Recibo;
            }
            catch (Exception c)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                return 1;
                //throw;
            }


        }

        private bool GuardarDetallesPago(int idCtaCteRecibo, int idComprobante, DataTable dtf, out string salida)
        {
            if (dtf.Rows.Count > 0)
            {
                try
                {
                    oCon.Conectar();
                    foreach (DataRow dr in dtf.Rows)
                    {
                        var importe = Decimal.Parse(dr["importe"].ToString());
                        var cliente = dr["cliente"].ToString();
                        var cuenta_banco = dr["cuenta"].ToString();
                        var cuit = dr["cuit"].ToString();
                        var banco = dr["banco"].ToString();
                        var sucursal = dr["sucursal"].ToString();
                        DateTime fc = DateTime.Now;
                        DateTime fa = DateTime.Now;
                        var id_formas_de_pago = Int32.Parse(dr["Id_formas_de_pago"].ToString());
                        var numero_f = dr["numero"].ToString();
                        int Conciliado = 0;

                        oCon.CrearComando("INSERT INTO usuarios_ctacte_recibos_det(Id_Usuarios_ctacte_recibos, Id_formas_de_pago, importe,cuit,nombre,sucursal,fecha_comprobante,fecha_acreditacion,numero,cuenta,banco, Id_Comprobantes, Conciliado ) " +
                                                                          "VALUES(@id_usuarios_ctacte_recibos, @id_formas_de_pago, @importe, @cuit, @nombre, @sucursal, @fecha_comprobante, @fecha_acreditacion, @numero_f, @cuenta_banco,@banco,@idComprobante, @Conciliado); ");

                        oCon.AsignarParametroEntero("@id_usuarios_ctacte_recibos", idCtaCteRecibo);
                        oCon.AsignarParametroEntero("@id_formas_de_pago", id_formas_de_pago);
                        oCon.AsignarParametroDecimal("@importe", importe);
                        oCon.AsignarParametroCadena("@cuit", cuit);
                        oCon.AsignarParametroCadena("@nombre", cliente);
                        oCon.AsignarParametroCadena("@sucursal", sucursal);
                        oCon.AsignarParametroFecha("@fecha_comprobante", fc);
                        oCon.AsignarParametroFecha("@fecha_acreditacion", fa);
                        oCon.AsignarParametroCadena("@numero_f", numero_f);
                        oCon.AsignarParametroCadena("@cuenta_banco", cuenta_banco);
                        oCon.AsignarParametroCadena("@banco", banco);
                        oCon.AsignarParametroEntero("@idComprobante", idComprobante);
                        oCon.AsignarParametroEntero("@Conciliado", Conciliado);
                        oCon.ComenzarTransaccion();
                        oCon.EjecutarComando();
                        oCon.ConfirmarTransaccion();
                    }
                    oCon.DesConectar();
                    salida = "";
                    return true;
                }
                catch (Exception c)
                {
                    oCon.CancelarTransaccion();
                    oCon.DesConectar();
                    salida = c.Message;
                    return false;

                }
            }
            else
            {
                salida = "No hay formas de pago";
                return false;
            }

        }
        public int borrar_recibo(Int32 idrecibo, out DataTable Salida,out int codSalida,out string mensaje)
        {
            DataTable dt_relacion = new DataTable();
            DataTable dt_recibo = new DataTable();
            DataTable dt_recibo_det = new DataTable();
            DataTable dt_cuotas = new DataTable();
            DataTable dt_recibos_cuotas = new DataTable();


            oCon.Conectar();

            oCon.CrearComando("SELECT * FROM usuarios_ctacte_relacion WHERE id_usuarios_ctacte_recibos = @id and borrado=0 ");
            oCon.AsignarParametroEntero("@id", idrecibo);
            dt_relacion = oCon.Tabla();

            oCon.CrearComando("SELECT * FROM usuarios_ctacte_recibos WHERE id = @id ");
            oCon.AsignarParametroEntero("@id", idrecibo);
            dt_recibo = oCon.Tabla();

            oCon.CrearComando("SELECT * FROM usuarios_ctacte_recibos_det WHERE id_usuarios_ctacte_recibos = @id ");
            oCon.AsignarParametroEntero("@id", idrecibo);
            dt_recibo_det = oCon.Tabla();

            oCon.CrearComando("SELECT usuarios_ctacte.* FROM usuarios_ctacte WHERE borrado=0 and id_plan_recibo = @id_recibo ");
            oCon.AsignarParametroEntero("@id_recibo", idrecibo);
            dt_cuotas = oCon.Tabla();


            DataTable Aux = new DataTable();
            Aux = dt_relacion.Copy();

            if (dt_relacion.Rows.Count > 0)
            {

                foreach (DataRow dr in dt_relacion.Rows) ///detalles de los pagos que realizo
                {
                    int Ir = 0;
                    DataTable dt_ctacte = new DataTable();
                    DataTable dtRecibosAux = new DataTable();
                    int CreditoCuentaNuevo = Convert.ToInt32(dr["nuevo"]);
                    /////  oCon.Conectar();
                    oCon.CrearComando("SELECT id,id_comprobantes_tipo,importe_saldo,id_plan_recibo FROM usuarios_ctacte WHERE id = @id ");
                    oCon.AsignarParametroEntero("@id", Convert.ToInt32(dr["id_usuarios_ctacte"].ToString()));
                    dt_ctacte = oCon.Tabla();

                    //en caso de que sea un plan de pago, si elimino el recibo las cuotas tambien se tienen que borrar
                    if (dt_ctacte.Rows.Count > 0)
                    {
                        int idCtacteCuota = 0;
                        int idComprobanteTipo = 0;
                        int cantEliminados = 0;
                        int cantYaConFac = 0;
                        foreach (DataRow cuotas in dt_cuotas.Rows)//si ya se pago al menos una cuota no se puede eliminar o si una cuota ya esta convertida a factura tampoco se puede eliminar
                        {
                            idCtacteCuota = (int)cuotas["id"];
                            idComprobanteTipo = Convert.ToInt32(cuotas["id_comprobantes_tipo"]);
                            oCon.CrearComando("SELECT * FROM usuarios_ctacte_relacion WHERE borrado=0 and id_usuarios_ctacte = @id_ctacte ");
                            oCon.AsignarParametroEntero("@id_ctacte", idCtacteCuota);
                            dt_recibos_cuotas = oCon.Tabla();
                        
                            if(dt_recibos_cuotas.Rows.Count>0 || (idComprobanteTipo==(int)Comprobantes_Tipo.Tipo.FACTURA_A || idComprobanteTipo == (int)Comprobantes_Tipo.Tipo.FACTURA_B))
                            {
                                cantYaConFac++;

                            }
                          
                        }
                        if(cantYaConFac>0)
                        {
                            oCon.DesConectar();
                            Salida = new DataTable();
                            codSalida = -1;
                            mensaje = "No se puede eliminar un plan de pagos si una de las cuotas esta paga o es factura. Elimine el pago de las cuotas y vuelva a intentarlo. ";
                            return 1;

                        }
                        else
                        {
                            foreach (DataRow cuotas in dt_cuotas.Rows)//si ya se pago al menos una cuota no se puede eliminar o si una cuota ya esta convertida a factura tampoco se puede eliminar
                            {
                                idCtacteCuota = (int)cuotas["id"];
                                idComprobanteTipo = Convert.ToInt32(cuotas["id_comprobantes_tipo"]);
                                oCon.CrearComando("SELECT * FROM usuarios_ctacte_relacion WHERE borrado=0 and id_usuarios_ctacte = @id_ctacte ");
                                oCon.AsignarParametroEntero("@id_ctacte", idCtacteCuota);
                                dt_recibos_cuotas = oCon.Tabla();

                                if (idComprobanteTipo == (int)Comprobantes_Tipo.Tipo.PLAN_DE_PAGO || idComprobanteTipo == (int)Comprobantes_Tipo.Tipo.COMPROBANTE_DEUDA)
                                {
                                    oCon.CrearComando("UPDATE usuarios_ctacte set borrado=1 where Id = @id");
                                    oCon.AsignarParametroEntero("@id", idCtacteCuota);
                                    oCon.EjecutarComando();


                                    oCon.CrearComando("UPDATE usuarios_ctacte_det set borrado=1 WHERE Id_usuarios_ctacte = @id");
                                    oCon.AsignarParametroEntero("@id", idCtacteCuota);
                                    oCon.EjecutarComando();
                                    cantEliminados++;
                                }
                                else
                                {
                                    oCon.DesConectar();
                                    Salida = new DataTable();
                                    codSalida = -1;
                                    mensaje = "No se puede eliminar un plan de pagos si una de las cuotas es una factura,se debe realizar la nota de credito de la cuota.";
                                    return 1;
                                }
                            }
                        }

                       
                        if (cantEliminados == dt_cuotas.Rows.Count)
                        {
                            oCon.CrearComando("UPDATE usuarios_ctacte left join comprobantes on comprobantes.id = usuarios_ctacte.id_comprobantes set usuarios_ctacte.descripcion = comprobantes.descripcion where usuarios_ctacte.Id = @id");
                            oCon.AsignarParametroEntero("@id", Convert.ToInt32(dr["id_usuarios_ctacte"]));
                            oCon.EjecutarComando();

                        }
                        foreach (DataRow drAux in Aux.Rows)
                        {
                            int importe = Convert.ToInt32(drAux["Importe_imputa"]);
                            int Usu_CtaCte = Convert.ToInt32(drAux["id_usuarios_ctacte"]);
                            if (Convert.ToInt32(drAux["nuevo"]) == 1)
                            {
                                oCon.CrearComando("SELECT * " +
                                "FROM usuarios_ctacte_relacion " +
                                "LEFT JOIN usuarios_ctacte ON usuarios_ctacte_relacion.Id_Usuarios_ctacte = usuarios_ctacte.Id " +
                                "LEFT JOIN usuarios_ctacte_recibos ON usuarios_ctacte_relacion.Id_Usuarios_ctacte_recibos = usuarios_ctacte_recibos.id " +
                                "WHERE id_usuarios_ctacte = @idCtaCte AND usuarios_ctacte_relacion.borrado = 0 AND usuarios_ctacte.Id_comprobantes_tipo = @tipoComp ORDER BY nuevo");
                                oCon.AsignarParametroEntero("@idCtaCte", Usu_CtaCte);
                                oCon.AsignarParametroEntero("@tipoComp", (int)Comprobantes_Tipo.Tipo.CREDITO_A_CUENTA);
                                dtRecibosAux = oCon.Tabla();
                                if (dtRecibosAux.Rows.Count > 1)
                                {
                                    oCon.DesConectar();
                                    Salida = dtRecibosAux;
                                    codSalida = -1;
                                    mensaje = "No se puede eliminar un plan de pagos si una de las cuotas esta paga. Elimine el pago de las cuotas y vuelva a intentarlo. ";
                                    return 1;
                                }
                            }
                        }

                        if (Convert.ToInt32(dt_ctacte.Rows[0]["id_comprobantes_tipo"].ToString()) == (Int32)Comprobantes_Tipo.Tipo.CREDITO_A_CUENTA && CreditoCuentaNuevo == 1)
                        {
                            oCon.CrearComando("UPDATE usuarios_ctacte set borrado=1 where Id = @id");
                            oCon.AsignarParametroEntero("@id", Convert.ToInt32(dr["id_usuarios_ctacte"].ToString()));
                            oCon.EjecutarComando();


                            oCon.CrearComando("UPDATE usuarios_ctacte_det set borrado=1 WHERE Id = @id");
                            oCon.AsignarParametroEntero("@id", Convert.ToInt32(dr["id_usuarios_ctacte_det"].ToString()));
                            oCon.EjecutarComando();

                        }
                        else
                        {
                            oCon.CrearComando("UPDATE usuarios_ctacte set importe_pago =importe_pago- @importe,importe_saldo=importe_final-importe_pago,id_usuarios_ctacte_recibos=@ir where Id = @id");
                            oCon.AsignarParametroEntero("@id", Convert.ToInt32(dr["id_usuarios_ctacte"].ToString()));
                            oCon.AsignarParametroEntero("@ir", Ir);
                            oCon.AsignarParametroDecimal("@importe", Convert.ToDecimal(dr["importe_imputa"].ToString()));
                            oCon.EjecutarComando();


                            oCon.CrearComando("UPDATE usuarios_ctacte_det set importe_pago =importe_pago- @importe ,importe_saldo=importe_original+importe_punitorio-importe_bonificacion-importe_pago+importe_provincial WHERE Id = @id");
                            oCon.AsignarParametroEntero("@id", Convert.ToInt32(dr["id_usuarios_ctacte_det"].ToString()));
                            oCon.AsignarParametroDecimal("@importe", Convert.ToDecimal(dr["importe_imputa"].ToString()));
                            oCon.EjecutarComando();

                        }
                    }

                }

                if (dt_recibo.Rows.Count > 0)
                {
                    Int32 Idreferencia = Convert.ToInt32(dt_recibo.Rows[0]["id_referencia"].ToString());
                    Decimal ImporteDescuenta = Convert.ToDecimal(dt_recibo.Rows[0]["importe_recibo"].ToString());
                    Int32 Idcajadiaria = Convert.ToInt32(dt_recibo.Rows[0]["id_caja_diaria"].ToString());

                    if (Idreferencia > 0)
                    {
                        oCon.CrearComando("update usuarios_ctacte_recibos set importe_rendido=importe_rendido-@importedescuenta where id = @id");
                        oCon.AsignarParametroEntero("@id", Idreferencia);
                        oCon.AsignarParametroDecimal("@importedescuenta", ImporteDescuenta);
                        oCon.EjecutarComando();

                    }

                    //marcelo 08/11
                    if (Idcajadiaria > 0) //el recibo esta en otra caja por lo tanto debe ingresar uno en negativo
                    {
                        Int32 idRecibo = 0;

                        oCon.CrearComando("INSERT INTO usuarios_ctacte_recibos(Id_Usuarios, Id_Usuarios_Locaciones, Id_Comprobantes, Fecha_Movimiento, Id_Puntos_Cobros, Numero, Id_personal, Importe_Recibo, Importe_Saldo, Estado, Id_Caja_Diaria,numero_muestra,cuenta,Id_Cobrador,Importe_Rendido,numero_hata,recibo_tipo) " +
                                            "VALUES(@idUsuario, @idLocacion, @idComprobante, @fecha, @idPtoCobro, @nroRecibo, @idPersonal, @importe, @saldo, @estado, @idCaja,@numero_muestra,@cuenta,@idCobrador,@idImporte_Rendido,@numero_hasta,@recibo_tipo); SELECT @@IDENTITY");
                        oCon.AsignarParametroEntero("@idUsuario", Convert.ToInt32(dt_recibo.Rows[0]["id_usuarios"].ToString()));
                        oCon.AsignarParametroEntero("@idLocacion", Convert.ToInt32(dt_recibo.Rows[0]["Id_Usuarios_Locaciones"].ToString()));
                        oCon.AsignarParametroEntero("@idComprobante", Convert.ToInt32(dt_recibo.Rows[0]["Id_Comprobantes"].ToString()));
                        oCon.AsignarParametroFecha("@fecha", DateTime.Now);
                        oCon.AsignarParametroEntero("@idPtoCobro", Convert.ToInt32(dt_recibo.Rows[0]["Id_Puntos_Cobros"].ToString()));
                        oCon.AsignarParametroEntero("@nroRecibo", Convert.ToInt32(dt_recibo.Rows[0]["Numero"].ToString()));
                        oCon.AsignarParametroEntero("@idPersonal", Convert.ToInt32(dt_recibo.Rows[0]["Id_personal"].ToString()));
                        oCon.AsignarParametroDecimal("@importe", Convert.ToDecimal(dt_recibo.Rows[0]["Importe_Recibo"].ToString()) * -1);
                        oCon.AsignarParametroDecimal("@saldo", 0);
                        oCon.AsignarParametroEntero("@estado", 0);
                        oCon.AsignarParametroEntero("@idCaja", 0);
                        oCon.AsignarParametroCadena("@numero_muestra", dt_recibo.Rows[0]["numero_muestra"].ToString());
                        oCon.AsignarParametroEntero("@cuenta", Convert.ToInt32(dt_recibo.Rows[0]["cuenta"].ToString()));
                        oCon.AsignarParametroEntero("@idCobrador", Convert.ToInt32(dt_recibo.Rows[0]["Id_Cobrador"].ToString()));
                        oCon.AsignarParametroDecimal("@idImporte_Rendido", Convert.ToDecimal(dt_recibo.Rows[0]["Importe_Rendido"].ToString()));
                        oCon.AsignarParametroEntero("@numero_hasta", Convert.ToInt32(dt_recibo.Rows[0]["numero_hata"].ToString()));
                        oCon.AsignarParametroEntero("@recibo_tipo", Convert.ToInt32(dt_recibo.Rows[0]["recibo_tipo"].ToString()));
                        oCon.ComenzarTransaccion();
                        idRecibo = oCon.EjecutarScalar();
                        oCon.ConfirmarTransaccion();

                        foreach (DataRow item in dt_recibo_det.Rows)
                        {

                            oCon.CrearComando("INSERT INTO usuarios_ctacte_recibos_det(Id_Usuarios_ctacte_recibos, Id_formas_de_pago, importe,cuit,nombre,sucursal,fecha_comprobante,fecha_acreditacion,numero,cuenta,banco, Id_Comprobantes,cod_usuario) " +
                                                  "VALUES(@id_usuarios_ctacte_recibos, @id_formas_de_pago, @importe, @cuit, @nombre, @sucursal, @fecha_comprobante, @fecha_acreditacion, @numero_f, @cuenta_banco,@banco,@idComprobante,@codUsuario); ");

                            oCon.AsignarParametroEntero("@id_usuarios_ctacte_recibos", idRecibo);
                            oCon.AsignarParametroEntero("@id_formas_de_pago", Convert.ToInt32(item["Id_formas_de_pago"].ToString()));
                            oCon.AsignarParametroDecimal("@importe", Convert.ToDecimal(item["importe"].ToString()) * -1);
                            oCon.AsignarParametroCadena("@cuit", item["cuit"].ToString());
                            oCon.AsignarParametroCadena("@nombre", item["nombre"].ToString());
                            oCon.AsignarParametroCadena("@sucursal", item["sucursal"].ToString());
                            oCon.AsignarParametroFecha("@fecha_comprobante", Convert.ToDateTime(item["fecha_comprobante"].ToString()));
                            oCon.AsignarParametroFecha("@fecha_acreditacion", Convert.ToDateTime(item["fecha_acreditacion"].ToString()));
                            oCon.AsignarParametroEntero("@numero_f", Convert.ToInt32(item["numero"].ToString()));
                            oCon.AsignarParametroCadena("@cuenta_banco", item["cuenta"].ToString());
                            oCon.AsignarParametroCadena("@banco", item["banco"].ToString());
                            oCon.AsignarParametroEntero("@idComprobante", Convert.ToInt32(item["Id_Comprobantes"].ToString()));
                            oCon.AsignarParametroEntero("@codUsuario", Convert.ToInt32(item["cod_usuario"].ToString()));

                            oCon.ComenzarTransaccion();
                            oCon.EjecutarComando();
                            oCon.ConfirmarTransaccion();

                        }
                    }
                }

                oCon.CrearComando("update usuarios_ctacte_relacion set borrado=1 where id_usuarios_ctacte_recibos = @id");
                oCon.AsignarParametroEntero("@id", idrecibo);
                oCon.EjecutarComando();

                oCon.CrearComando("update usuarios_ctacte_recibos set borrado=1 where id = @id");
                oCon.AsignarParametroEntero("@id", idrecibo);
                oCon.EjecutarComando();

                oCon.CrearComando("update usuarios_ctacte_recibos_det set borrado=1 where id_usuarios_ctacte_recibos = @id");
                oCon.AsignarParametroEntero("@id", idrecibo);
                oCon.EjecutarComando();


                oCon.CrearComando("update usuarios_ctacte_recibos_servicios set borrado=1 where id_usuarios_ctacte_recibos = @id");
                oCon.AsignarParametroEntero("@id", idrecibo);
                oCon.EjecutarComando();
            }


            oCon.CrearComando("call SaldoCC(@idu)");
            oCon.AsignarParametroEntero("@idu", Id_Usuarios_Locacion);
            oCon.EjecutarComando();

            oCon.DesConectar();
            Salida = dt_relacion;
            codSalida = 0;
            mensaje = "";
            return 0;
        }

        public void CambiarFormaPagoRecibo(int idRecibo, int idComprobante, DataTable dtPagos)
        {
            //primero paso a borrado todos los recibos_det 
            try
            {
                oCon.Conectar();
                oCon.CrearComando("UPDATE usuarios_ctacte_recibos_det SET borrado=1 WHERE id_usuarios_ctacte_recibos=@idRecibo");
                oCon.AsignarParametroEntero("@idRecibo", idRecibo);
                oCon.EjecutarComando();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }
            try
            {
                oCon.Conectar();

                foreach (DataRow dr in dtPagos.Rows)
                {
                    var importe = Decimal.Parse(dr["importe"].ToString());
                    var cliente = dr["cliente"].ToString();
                    var cuenta_banco = dr["cuenta"].ToString();
                    var cuit = dr["cuit"].ToString();
                    var banco = dr["banco"].ToString();
                    var sucursal = dr["sucursal"].ToString();
                    DateTime fc = DateTime.Now;
                    DateTime fa = DateTime.Now;
                    var id_formas_de_pago = Int32.Parse(dr["Id_formas_de_pago"].ToString());
                    var numero_f = Int32.Parse(dr["numero"].ToString());

                    oCon.CrearComando("INSERT INTO usuarios_ctacte_recibos_det(Id_Usuarios_ctacte_recibos, Id_formas_de_pago, importe,cuit,nombre,sucursal,fecha_comprobante,fecha_acreditacion,numero,cuenta,banco, Id_Comprobantes) " +
                                                                      "VALUES(@id_usuarios_ctacte_recibos, @id_formas_de_pago, @importe, @cuit, @nombre, @sucursal, @fecha_comprobante, @fecha_acreditacion, @numero_f, @cuenta_banco,@banco,@idComprobante); ");

                    oCon.AsignarParametroEntero("@id_usuarios_ctacte_recibos", idRecibo);
                    oCon.AsignarParametroEntero("@id_formas_de_pago", id_formas_de_pago);
                    oCon.AsignarParametroDecimal("@importe", importe);
                    oCon.AsignarParametroCadena("@cuit", cuit);
                    oCon.AsignarParametroCadena("@nombre", cliente);
                    oCon.AsignarParametroCadena("@sucursal", sucursal);
                    oCon.AsignarParametroFecha("@fecha_comprobante", fc);
                    oCon.AsignarParametroFecha("@fecha_acreditacion", fa);
                    oCon.AsignarParametroEntero("@numero_f", numero_f);
                    oCon.AsignarParametroCadena("@cuenta_banco", cuenta_banco);
                    oCon.AsignarParametroCadena("@banco", banco);
                    oCon.AsignarParametroEntero("@idComprobante", idComprobante);
                    oCon.EjecutarComando();
                }
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }

        }

        public DataTable ListarCtaCteRelacion(Int32 idctacte, Int32 idrecibos, Int32 agrupada)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                if (agrupada == 1)
                {
                    oCon.CrearComando("SELECT id,id_usuarios_ctacte,(select numero_muestra from usuarios_ctacte_recibos where usuarios_ctacte_recibos.id=usuarios_ctacte_relacion.id_usuarios_ctacte_recibos) as recibo,id_usuarios_ctacte_recibos,id_usuarios_ctacte_det,importe_imputa FROM usuarios_ctacte_relacion WHERE id_usuarios_ctacte = @id  and borrado=@bo ");
                    oCon.AsignarParametroEntero("@id", idctacte);
                    oCon.AsignarParametroEntero("@bo", 0);

                }
                else
                {
                    if (idctacte > 0)
                    {
                        oCon.CrearComando("SELECT id,id_usuarios_ctacte,(select numero_muestra from usuarios_ctacte_recibos where usuarios_ctacte_recibos.id=usuarios_ctacte_relacion.id_usuarios_ctacte_recibos) as recibo,(select fecha_movimiento from usuarios_ctacte_recibos where usuarios_ctacte_recibos.id = usuarios_ctacte_relacion.id_usuarios_ctacte_recibos) as fecha,id_usuarios_ctacte_recibos,sum(importe_imputa) as importe,borrado FROM usuarios_ctacte_relacion group by id_usuarios_ctacte_recibos  having id_usuarios_ctacte = @id  and borrado=@bo ");
                        oCon.AsignarParametroEntero("@id", idctacte);
                        oCon.AsignarParametroEntero("@bo", 0);
                    }
                    else
                    {


                        oCon.CrearComando("SELECT id,(select descripcion from usuarios_ctacte where usuarios_ctacte.id=usuarios_ctacte_relacion.id_usuarios_ctacte) as descripcion," +
                            "(select descripcion from servicios_sub where servicios_sub.id = usuarios_ctacte_relacion.id_tipo) as servicio," +
                           "importe_imputa,id_usuarios_ctacte_det FROM usuarios_ctacte_relacion WHERE id_usuarios_ctacte_recibos = @id  and borrado=@bo ");
                        oCon.AsignarParametroEntero("@id", idrecibos);
                        oCon.AsignarParametroEntero("@bo", 0);
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

        public DataTable ListarCtaCteRecibosdet(Int32 id, String tipo)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                if (tipo == "ID")
                    oCon.CrearComando("SELECT id,(select nombre from formas_de_pago where formas_de_pago.id= usuarios_ctacte_recibos_det.id_formas_de_pago) as descripcion,importe,numero,banco,nombre,fecha_comprobante,fecha_acreditacion,usuarios_ctacte_recibos_det.id_formas_de_pago FROM usuarios_ctacte_recibos_det WHERE id_usuarios_ctacte_recibos = @id ");
                else
                    oCon.CrearComando("SELECT id,(select nombre from formas_de_pago where formas_de_pago.id= usuarios_ctacte_recibos_det.id_formas_de_pago) as descripcion,importe,numero,banco,nombre,fecha_comprobante,fecha_acreditacion,cod_usuario,usuarios_ctacte_recibos_det.id_formas_de_pago FROM usuarios_ctacte_recibos_det where id_comprobantes = @id ");

                oCon.AsignarParametroEntero("@id", id);
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

        public void Editar_Importe_Recibo_Cobrador(int Id_Comprobante, decimal Importe, decimal ajuste)
        {
            try
            {
                oCon.Conectar();

                if (Id_Comprobante > 0)
                {
                    oCon.CrearComando("UPDATE usuarios_ctacte_recibos SET Importe_Recibo=@Importe_Recibo, Importe_Ajuste=@Importe_Ajuste WHERE Id_Comprobantes = @id_Comprobante");
                    oCon.AsignarParametroDecimal("@Importe_Recibo", Importe);
                    oCon.AsignarParametroDecimal("@Importe_Ajuste", ajuste);
                    oCon.AsignarParametroEntero("@id_Comprobante", Id_Comprobante);
                    oCon.EjecutarComando();

                }
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();

                throw;
            }
            oCon.DesConectar();
        }

        public DataTable ListaFormaPago(int id_usuarios_ctacte_recibos)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando(String.Format("SELECT formas_de_pago.nombre as formapago, importe, cuit, usuarios_ctacte_recibos_det.nombre, banco, " +
                    "sucursal, fecha_comprobante, fecha_acreditacion, numero, id_formas_de_pago " +
                    "FROM usuarios_ctacte_recibos_det " +
                    "LEFT JOIN formas_de_pago ON formas_de_pago.id = usuarios_ctacte_recibos_det.id_formas_de_pago " +
                    "WHERE id_usuarios_ctacte_recibos = {0}", id_usuarios_ctacte_recibos));

                dt = oCon.Tabla();

                oCon.DesConectar();
            }
            catch { }

            return dt;
        }

        public DataTable ListarCobranzas(int idServiciosTipos, List<int> listaIdModalidades, int idTipoFacturacion, DateTime fechaDesde, DateTime fechaHasta, int idCajaDesde, int idCajaHasta, int idConceptoConsulta, int idPuntoCobroConsulta)
        {
            DataTable dt = new DataTable();
            DataTable dtCobranzas = new DataTable();
            try
            {
                oCon.Conectar();
                foreach (int idModalidad in listaIdModalidades)
                {
                    dt.Clear();
                    oCon.CrearComando(String.Format("call spConsultaCobranzas('{0}','{1}',{2},{3},{4},{5},{6},{7},{8},{9})", fechaDesde.ToString("yyyy-MM-dd"), fechaHasta.ToString("yyyy-MM-dd"), Convert.ToInt16(Comprobantes_Tipo.Tipo.PLAN_DE_PAGO), idModalidad, idServiciosTipos, idTipoFacturacion, idCajaDesde, idCajaHasta, idConceptoConsulta, idPuntoCobroConsulta));
                    dt = oCon.Tabla();
                    if (dtCobranzas.Rows.Count == 0)
                        dtCobranzas = dt.Copy();
                    else
                    {
                        foreach (DataRow fila in dt.Rows)
                            dtCobranzas.ImportRow(fila);
                    }
                }


                oCon.DesConectar();
            }
            catch
            {
                oCon.DesConectar();
            }

            return dtCobranzas;

        }

        public DataTable ListarDetallesCtaCteDet(int idComprobate)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("select usuarios_ctacte_recibos.id_puntos_cobros,usuarios_ctacte_recibos.id_caja_diaria,usuarios_ctacte_relacion.id_usuarios_ctacte_det,usuarios_ctacte_relacion.Id_Usuarios_ctacte_recibos,usuarios_ctacte_det.tipo,usuarios_ctacte_det.id_tipo,usuarios_ctacte_det.id_usuarios_servicios_sub,usuarios_ctacte_relacion.importe_imputa, "
                + " if(usuarios_ctacte_det.id_tipo>0,case usuarios_ctacte_det.tipo"
                + "  WHEN 'S' THEN(SELECT Descripcion FROM servicios_sub WHERE Id = usuarios_ctacte_det.id_tipo)"
                + "  WHEN 'E' THEN(SELECT nombre FROM equipos_tipos WHERE Id = usuarios_ctacte_det.Id_Tipo)"
                + "  WHEN 'P' THEN(SELECT nombre from partes_fallas where id = usuarios_ctacte_det.Id_Tipo)"
                + " END,usuarios_ctacte_Det.detalles) AS sub_servicio,usuarios_ctacte_recibos.id_comprobantes,comprobantes.id_comprobantes_tipo"
                + " from usuarios_ctacte_recibos"
                + " inner join usuarios_ctacte_relacion on usuarios_ctacte_recibos.id = usuarios_ctacte_relacion.id_usuarios_ctacte_recibos"
                + " inner join usuarios_ctacte_det on usuarios_ctacte_det.id = usuarios_ctacte_relacion.id_usuarios_ctacte_det"
                + " inner join comprobantes on comprobantes.id=usuarios_ctacte_recibos.id_comprobantes"
                + " left join usuarios_servicios_sub on usuarios_Servicios_sub.id = usuarios_ctacte_det.id_usuarios_servicios_sub"
                + " left join servicios_sub on servicios_sub.id = usuarios_Servicios_sub.id_servicios_sub"
                + " where usuarios_ctacte_recibos.id_comprobantes=@id_comprobante");
                oCon.AsignarParametroEntero("@id_comprobante", idComprobate);
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

        public decimal GetPorcentajeIva(int idUsuariosCtaCteDet)
        {
            //nuevo método 061119fede
            decimal porcentaje = 0;
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("select iva_alicuotas.porcentaje from (select id_iva_alicuotas from usuarios_ctacte_det where id=@idusuariosctactedet)ivausuariosctactedet left join iva_alicuotas on ivausuariosctactedet.id_iva_alicuotas=iva_alicuotas.id");
                oCon.AsignarParametroEntero("@idusuariosctactedet", idUsuariosCtaCteDet);
                dt = oCon.Tabla();
                if (dt.Rows.Count > 0)
                    porcentaje = Convert.ToDecimal(dt.Rows[0]["porcentaje"]);
                oCon.DesConectar();
            }
            catch (Exception)
            {
                porcentaje = 0;
                oCon.DesConectar();
                throw;
            }
            return porcentaje;

        }

        public DataTable ListarRecibosPresentacionDeb(int idPresentacion)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT *, COUNT(*)AS cont,"
                    + " MIN(numero_muestra) AS 'menor', max(numero_muestra) AS 'mayor',SUM(importe_recibo)AS importe_total,presentacion_debitos.periodo"
                    + " FROM usuarios_ctacte_recibos left join presentacion_debitos on presentacion_debitos.id=id_presentacion_deb"
                    + " where id_presentacion_deb = @id and usuarios_ctacte_recibos.borrado=0 and presentacion_debitos.borrado=0"
                    + " group by id_presentacion_deb");
                oCon.AsignarParametroEntero("@id", idPresentacion);
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

        public DataTable ListarCuentas(DateTime fechadesde, DateTime fechahasta)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT servicios_tipos.id, servicios_tipos.nombre, SUM(usuarios_ctacte_relacion.Importe_imputa) AS Importe, " +
                    "usuarios_ctacte_recibos.cuenta FROM usuarios_ctacte_relacion " +
                    "LEFT JOIN usuarios_ctacte_det ON usuarios_ctacte_det.Id = usuarios_ctacte_relacion.id_usuarios_Ctacte_det " +
                    "LEFT JOIN usuarios_ctacte_recibos ON usuarios_ctacte_recibos.Id = usuarios_ctacte_relacion.id_usuarios_ctacte_recibos " +
                    "LEFT JOIN servicios ON servicios.id = usuarios_ctacte_det.Id_Servicios " +
                    "LEFT JOIN servicios_tipos ON servicios_tipos.id = servicios.id_servicios_tipos " +
                    "LEFT JOIN servicios_grupos ON servicios_grupos.Id = servicios_tipos.id_servicios_grupos " +
                    "WHERE usuarios_ctacte_recibos.borrado = 0 AND usuarios_ctacte_det.borrado = 0 AND usuarios_ctacte_det.tipo = 'S' " +
                    "AND DATE(usuarios_ctacte_recibos.Fecha_movimiento) >=@des AND DATE(usuarios_ctacte_recibos.Fecha_Movimiento)<=@has AND usuarios_ctacte_det.id_servicios > 0 " +
                    "GROUP BY servicios_tipos.id, servicios_tipos.nombre, usuarios_ctacte_recibos.cuenta");
                oCon.AsignarParametroFecha("@des", fechadesde.Date);
                oCon.AsignarParametroFecha("@has", fechahasta.Date);
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

        private bool GuardarRelacion(int idCtacteRecibo, int idCtacte, int idDet, decimal importe, decimal importeProvincial, decimal importePunitorio, int idTipo, decimal porcentajeIva, int nuevo, out string salida)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("INSERT INTO usuarios_ctacte_relacion(Id_Usuarios_ctacte,Id_Usuarios_ctacte_recibos, Id_Usuarios_ctacte_det,importe_imputa,importe_provincial,importe_punitorio,importe_bonificacion,id_tipo, porcentaje_iva, nuevo ) " +
                                  "VALUES(@id_usuarios_ctacte,@id_usuarios_ctacte_recibos, @id_usuarios_ctacte_det, @importe, @importeii, @importep, @importeb,@Id_Tipo, @porcentaje_iva, @nuevo); ");

                oCon.AsignarParametroEntero("@id_usuarios_ctacte_recibos", Id);
                oCon.AsignarParametroEntero("@id_usuarios_ctacte", idCtacte);
                oCon.AsignarParametroEntero("@id_usuarios_ctacte_det", idDet);
                oCon.AsignarParametroDecimal("@importe", importe);
                oCon.AsignarParametroDecimal("@importeii", importeProvincial);
                oCon.AsignarParametroDecimal("@importep", importePunitorio);
                oCon.AsignarParametroDecimal("@importeb", 0);
                oCon.AsignarParametroEntero("@Id_Tipo", idTipo);
                oCon.AsignarParametroEntero("@nuevo", nuevo);
                oCon.AsignarParametroDecimal("@porcentaje_iva", porcentajeIva);
                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
                salida = "";
                return true;

            }
            catch (Exception c)
            {
                oCon.DesConectar();
                salida = c.Message;
                return false;
            }
        }

        private bool GuardarRelacionReciboServicio(int idRecibo, int idServicio, int idTipo, decimal importe, decimal importePunitorio, decimal importeBonificacion, decimal importeProvincial, out string salida)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("INSERT INTO usuarios_ctacte_recibos_servicios(Id_Usuarios_ctacte_recibos , Id_servicios ,Id_servicios_subservicios,importe_original,importe_punitorio ,importe_bonificacion,importe_provincial) " +
                    "VALUES(@id_usuarios_ctacte_recibos, @id_servicios, @id_tipo, @importe_original,@importe_punitorio,@importe_bonificacion,@importe_provincial); ");
                oCon.AsignarParametroEntero("@id_usuarios_ctacte_recibos", idRecibo);
                oCon.AsignarParametroEntero("@id_servicios", idServicio);
                oCon.AsignarParametroEntero("@id_tipo", idTipo);
                oCon.AsignarParametroDecimal("@importe_original", importe);
                oCon.AsignarParametroDecimal("@importe_punitorio", importePunitorio);
                oCon.AsignarParametroDecimal("@importe_bonificacion", importeBonificacion);
                oCon.AsignarParametroDecimal("@importe_provincial", importeProvincial);
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
                salida = c.Message;
                return false;
            }
        }

        public DataTable ListarPagosAdelantados(DateTime fechaDesde, DateTime fechaHasta, int idTipoServicio = 0)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                string condicion = "";
                string comando = "SELECT usuarios_ctacte_recibos.id AS id_ctacte_recibo, usuarios_ctacte_det.Id AS id_ctacte_det, usuarios_ctacte_det.id_usuarios_ctacte, usuarios.id as id_usuario, usuarios_locaciones.id as id_locacion, "
                             + " usuarios_ctacte_det.Id_Usuarios_Servicios, usuarios_servicios.Id_Servicios, usuarios.Codigo, "
                             + " CONCAT_WS(',', usuarios.Apellido, usuarios.Nombre) AS usuario, CONCAT(localidades.Nombre,', ', 'Calle: ' , usuarios_locaciones.Calle, ' Altura: ', usuarios_locaciones.Altura) AS locacion ,usuarios_ctacte_recibos.Fecha_movimiento AS fecha_pago,"
                             + " usuarios_ctacte_recibos.importe_recibo, usuarios_ctacte_det.Fecha_Desde, servicios_grupos.nombre as servicio_grupo, servicios_tipos.nombre as servicio_tipo, servicios.Descripcion AS servicio,"
                             + " usuarios.presentacion, usuarios_ctacte_recibos.cuenta, servicios_tipos.id as id_servicio_tipo"
                             + " FROM usuarios_ctacte_det"
                             + " INNER JOIN usuarios_ctacte_relacion ON usuarios_ctacte_relacion.Id_Usuarios_ctacte_det = usuarios_ctacte_det.id"
                             + " AND usuarios_ctacte_det.fecha_desde > @hasta1 AND usuarios_ctacte_det.Borrado = 0"
                             + " INNER JOIN usuarios_ctacte_recibos ON usuarios_ctacte_recibos.Id = usuarios_ctacte_relacion.Id_Usuarios_ctacte_recibos"
                             + " AND usuarios_ctacte_recibos.Fecha_movimiento BETWEEN @desde AND @hasta2"
                             + " AND usuarios_ctacte_recibos.borrado = 0"
                             + " LEFT JOIN usuarios ON usuarios.Id = usuarios_ctacte_recibos.Id_Usuarios"
                             + " LEFT JOIN usuarios_servicios ON usuarios_servicios.Id = usuarios_ctacte_det.Id_Usuarios_Servicios"
                             + " LEFT JOIN servicios ON servicios.Id = usuarios_servicios.Id_Servicios"
                             + " LEFT JOIN servicios_tipos ON servicios_tipos.Id = servicios.Id_Servicios_Tipos"
                             + " LEFT JOIN servicios_grupos ON servicios_grupos.id = servicios_tipos.Id_Servicios_Grupos"
                             + " LEFT JOIN usuarios_locaciones ON usuarios_locaciones.id = usuarios_ctacte_det.Id_Usuarios_Locaciones"
                             + " LEFT JOIN localidades ON localidades.id = usuarios_locaciones.Id_Localidades ";

                if (idTipoServicio != 0)
                    condicion = $"WHERE servicios_tipos.id = {idTipoServicio}";

                string groupby = " group by date(usuarios_ctacte_det.fecha_desde) ";

                oCon.CrearComando($"{comando} {condicion} {groupby}");
                oCon.AsignarParametroFecha("@desde", fechaDesde);
                oCon.AsignarParametroFecha("@hasta1", fechaHasta);
                oCon.AsignarParametroFecha("@hasta2", fechaHasta);
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                oCon.DesConectar();
            }
            return dt;
        }
    
        public bool ActualizarReciboRemito(int idRecibo, string descripcion, int numero, out string salida)
        {
            try
            {
                oCon.Conectar();

                oCon.CrearComando("UPDATE usuarios_ctacte_recibos set numero_muestra=@descripcion,numero=@num where id=@idrecibo");
                oCon.AsignarParametroCadena("@descripcion", descripcion);
                oCon.AsignarParametroEntero("@num", numero);
                oCon.AsignarParametroEntero("@idrecibo", idRecibo);
                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
                salida = "";
                return true;
            }
            catch (Exception c)
            {
                oCon.DesConectar();
                salida = c.ToString();
                return false;
            }
        }

        public DataTable ListarUsuariosConPeriodosFacturadosDesde(DateTime fechaDesdePago, DateTime fechaHastaPago, DateTime fechaFacturadoHasta, int cantidadMeses = 12)
        {
            DataTable dtUsuarios = new DataTable();
            try
            {
                oCon.Conectar();
                string comando = "select usuarios.codigo, usuarios_locaciones.id as id_usuario_locacion, CONCAT(TRIM(usuarios_locaciones.calle),' , ',Usuarios_locaciones.altura) as locacion"
                               + ", TRecibos.Id_usuarios, usuarios_Ctacte_relacion.id_usuarios_ctacte, TRecibos.id as id_ctacte_recibo, "
                               + " usuarios_ctacte_det.id_usuarios_servicios ,count(DISTINCT usuarios_ctacte_det.Fecha_Desde) AS meses_pagos"
                               + " from usuarios_Ctacte_relacion"
                               + " inner join (select id, id_usuarios from usuarios_ctacte_recibos where fecha_movimiento between @desde and @hasta"
                               + " and borrado = 0 order by id_usuarios, fecha_movimiento) TRecibos ON TRecibos.id = usuarios_ctacte_relacion.id_usuarios_ctacte_recibos"
                               + " inner join usuarios_ctacte on usuarios_ctacte.id = usuarios_ctacte_relacion.id_usuarios_ctacte"
                               + " inner join usuarios_ctacte_det on usuarios_ctacte_Det.id_usuarios_ctacte = usuarios_ctacte.id"
                               + " inner join usuarios_Servicios on usuarios_servicios.id = usuarios_ctacte_det.id_usuarios_servicios"
                               + " inner join usuarios on usuarios.id = TRecibos.id_usuarios "
                               + " inner join usuarios_locaciones on usuarios_locaciones.id = usuarios_servicios.id_usuarios_locaciones "
                               + " where usuarios_ctacte.borrado = 0 and usuarios_ctacte_det.borrado = 0 and usuarios_ctacte_det.Tipo = 'S'"
                               + " and usuarios_servicios.fecha_factura >= @fechaFacturado"
                               + " and usuarios_ctacte_det.Id_Tipo = 4 and usuarios_ctacte_det.idTipoRegistroCtaCteDet != 1"
                               + " group by id_usuarios"
                               + " having meses_pagos >= @cantMeses"
                               + " order by id_usuarios, id_ctacte_recibo";
                oCon.CrearComando(comando);
                oCon.AsignarParametroFecha("@desde", fechaDesdePago.Date);
                oCon.AsignarParametroFecha("@hasta", fechaHastaPago.Date);
                oCon.AsignarParametroFecha("@fechaFacturado", fechaFacturadoHasta.Date);
                oCon.AsignarParametroEntero("@cantMeses", cantidadMeses);
                dtUsuarios = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
            }
            return dtUsuarios;
        }

        public bool GuardarRelacionReciboAjuste(int idCtacteRecibo, int idCtacte, List<Usuarios_CtaCte_Det> ListaDet, decimal porcentajeIva, out string salida)
        {
            try
            {
                oCon.Conectar();

                foreach (Usuarios_CtaCte_Det itemDet in ListaDet)
                {
                    oCon.CrearComando("INSERT INTO usuarios_ctacte_relacion(Id_Usuarios_ctacte,Id_Usuarios_ctacte_recibos, Id_Usuarios_ctacte_det,importe_imputa,importe_provincial,importe_punitorio,importe_bonificacion,id_tipo, porcentaje_iva, nuevo ) " +
                                 "VALUES(@id_usuarios_ctacte,@id_usuarios_ctacte_recibos, @id_usuarios_ctacte_det, @importe, @importeii, @importep, @importeb,@Id_Tipo, @porcentaje_iva, @nuevo); ");
                    oCon.AsignarParametroEntero("@id_usuarios_ctacte_recibos", idCtacteRecibo);
                    oCon.AsignarParametroEntero("@id_usuarios_ctacte", idCtacte);
                    oCon.AsignarParametroEntero("@id_usuarios_ctacte_det", itemDet.Id);
                    oCon.AsignarParametroDecimal("@importe", itemDet.Importe_Original);
                    oCon.AsignarParametroDecimal("@importeii", itemDet.Importe_Provincial);
                    oCon.AsignarParametroDecimal("@importep", itemDet.Importe_Punitorio);
                    oCon.AsignarParametroDecimal("@importeb", 0);
                    oCon.AsignarParametroEntero("@Id_Tipo", 0);
                    oCon.AsignarParametroEntero("@nuevo", 0);
                    oCon.AsignarParametroDecimal("@porcentaje_iva", porcentajeIva);
                    oCon.ComenzarTransaccion();
                    oCon.EjecutarComando();
                    oCon.ConfirmarTransaccion();
                }
                oCon.DesConectar();
                salida = "";
                return true;

            }
            catch (Exception c)
            {
                oCon.DesConectar();
                salida = c.Message;
                return false;
            }
        }

        public bool GuardarRelacionReciboServicioReciboAjuste(int idRecibo, List<Usuarios_CtaCte_Det> ListaDet)
        {
            try
            {
                oCon.Conectar();
                foreach (Usuarios_CtaCte_Det itemDet in ListaDet)
                {
                    oCon.CrearComando("INSERT INTO usuarios_ctacte_recibos_servicios(Id_Usuarios_ctacte_recibos , Id_servicios ,Id_servicios_subservicios,importe_original,importe_punitorio ,importe_bonificacion,importe_provincial) " +
                        "VALUES(@id_usuarios_ctacte_recibos, @id_servicios, @id_tipo, @importe_original,@importe_punitorio,@importe_bonificacion,@importe_provincial); ");
                    oCon.AsignarParametroEntero("@id_usuarios_ctacte_recibos", idRecibo);
                    oCon.AsignarParametroEntero("@id_servicios", itemDet.Id_Servicios);
                    oCon.AsignarParametroDecimal("@importe_original", itemDet.Importe_Original);
                    oCon.AsignarParametroDecimal("@importe_punitorio", itemDet.Importe_Punitorio);
                    oCon.AsignarParametroDecimal("@importe_bonificacion", itemDet.Importe_Bonificacion);
                    oCon.AsignarParametroDecimal("@importe_provincial", itemDet.Importe_Provincial);
                    oCon.AsignarParametroEntero("@id_tipo", 0);
                    oCon.ComenzarTransaccion();
                    oCon.EjecutarComando();
                    oCon.ConfirmarTransaccion();
                }
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

        public DataRow getDatosRelacion(Int32 idCtacte)
        {
            DataTable dt;

            try
            {
                oCon.Conectar();
                oCon.CrearComando(String.Format("SELECT * FROM usuarios_ctacte_relacion where id_usuarios_ctacte = {0} ", idCtacte));
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }
            if (dt.Rows.Count == 0)
            {
                DataRow dr;
                dr = dt.NewRow();
                dr["id"] = 0;
                dt.Rows.Add(dr);
            }

            return dt.Rows[0];

        }


        public DataTable ListarDetalleCajaDiaria(int id_CajaDiaria)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT usuarios_ctacte_recibos.id AS Id_recibo, usuarios_ctacte_recibos.Fecha_movimiento AS FechaRecibo, " +
                    "usuarios_ctacte_recibos.Importe_Recibo AS Importe, usuarios_ctacte_recibos.Importe_Rendido AS ImportePago, " +
                    "usuarios_ctacte_recibos.Numero_Muestra AS Recibo, " +
                    "CONCAT(usuarios.Apellido, ' , ', usuarios.Nombre) AS Usuario " +
                    "FROM usuarios_ctacte_recibos " +
                    "LEFT JOIN usuarios ON usuarios_ctacte_recibos.id_usuarios = usuarios.id " +
                    "WHERE usuarios_ctacte_recibos.Id_Caja_Diaria = @idDiaria AND usuarios_ctacte_recibos.borrado = 0; ");
                oCon.AsignarParametroEntero("@idDiaria", id_CajaDiaria);
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

        public DataTable ListarComprobantesAConciliar(DateTime desde, DateTime hasta, int Conciliacion)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT usuarios_ctacte_recibos.id AS Id_recibo, usuarios_ctacte_recibos_det.id AS id_recibo_det, usuarios.Codigo AS CodUsu, " +
                    "Concat(usuarios.Apellido, ' , ', usuarios.Nombre) AS Usuario, formas_de_pago.Nombre AS formapago, formas_de_pago_tipos.Nombre AS tipoformapago, " +
                    "usuarios_ctacte_recibos.Numero_Muestra AS Recibo, usuarios_ctacte_recibos.Importe_Recibo AS ImporteRecibo, " +
                    "usuarios_ctacte_recibos_det.Importe AS ImporteDetalle, " +
                    "usuarios_ctacte_recibos_det.Conciliado, usuarios_ctacte_recibos_det.Fecha_Comprobante AS FechaComprobante, " +
                    "usuarios_ctacte_recibos_det.Numero AS Transferencia, " +
                    "usuarios_ctacte_recibos_det.Nombre AS Titular " +
                    "FROM usuarios_ctacte_recibos_det " +
                    "LEFT JOIN usuarios_ctacte_recibos ON usuarios_ctacte_recibos_det.Id_Usuarios_Ctacte_recibos = usuarios_ctacte_recibos.id " +
                    "LEFT JOIN usuarios ON usuarios_ctacte_recibos.Id_Usuarios = usuarios.id " +
                    "LEFT JOIN formas_de_pago ON usuarios_ctacte_recibos_det.Id_Formas_de_Pago = formas_de_pago.id " +
                    "LEFT JOIN formas_de_pago_tipos ON formas_de_pago.Id_Tipo_de_Forma = formas_de_pago_tipos.id " +
                    "WHERE usuarios_ctacte_recibos_det.borrado = 0 AND usuarios_ctacte_recibos.borrado = 0 AND formas_de_pago_tipos.Trabaja_Conciliacion = 1 " +
                    "AND usuarios_ctacte_recibos_det.Conciliado = @Conciliado " +
                    "AND(DATE(usuarios_ctacte_recibos_det.Fecha_Comprobante) BETWEEN DATE(@desde) AND DATE(@hasta)); ");
                oCon.AsignarParametroEntero("@Conciliado", Conciliacion);
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

        public bool ActualizarConciliacion(int id_Detalle)
        {
            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();
                oCon.CrearComando("UPDATE usuarios_ctacte_recibos_det SET Conciliado=1  WHERE Id = @id");
                oCon.AsignarParametroEntero("@id", id_Detalle);
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
                return true;
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                throw;
                return false;
            }
        }
    }
}
