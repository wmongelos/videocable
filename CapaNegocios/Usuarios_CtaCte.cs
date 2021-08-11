using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;

namespace CapaNegocios
{
    public class Usuarios_CtaCte
    {
        #region [PROPIEDADES]
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
        public Decimal Importe_Final { get; set; }
        public Decimal Importe_Saldo { get; set; }
        public Decimal Importe_Provincial { get; set; }
        public String Numero { get; set; }
        public Int32 Id_Comprobantes_Ref { get; set; }
        public Int32 Id_Facturacion { get; set; }
        public Int32 Generado_facturacion_mensual { get; set; }
        public Int32 Id_Iva_Ventas { get; set; }
        public Int32 Id_Personal { get; set; }
        public Int32 Id_Origen { get; set; }
        public Int32 Percepcion { get; set; } = 1;//0 si no se calcula la percepcion - 1 se calcula percepcion
        public Int32 Id_Ctacte_Recibo_Plan { get; set; } = 0;//relaciona una cuota con recibo plan de pago
        public Decimal Porcentaje_Percepcion { get; set; }

        public List<Usuarios_CtaCte_Det> UsuCtaCteDet = new List<Usuarios_CtaCte_Det>();

        private DataTable dtCtaCteDetfinal;
        private DataTable dtCtaCte;
        private DataTable dtCtaCteDet;

        private Usuarios_CtaCte_Det oUsuCtaCteDet = new Usuarios_CtaCte_Det();

        public enum PERCEPCIONES
        {
            NO_CALCULA = 0,
            CALCULA = 1
        }
        public enum TIPO_MOVIMIENTO
        {
            VENTAS = 0,
            COBROS = 1,
            TODOS = 2
        }
        public enum GENERADO_FACTURACION_MENSUAL
        {
            NO = 0,
            SI = 1
        }

        public enum TIPO_REGISTRO_CTACTE
        {
            COMPROBANTE = 0,
            SERVICIO = 1,
            SUBSERVICIO = 2
        }

        public enum TIPO_VALOR_AJUSTE
        {
            PORCENTAJE = 0,
            MONTO = 1
        }

        public enum TIPO_AJUSTE
        {
            INCREMENTO = 0,
            DESCUENTO = 1
        }

        public enum FECHA_CONSULTA_MOVIMIENTOS_CTACTE
        {
            FECHA_DESDE = 0,
            FECHA_MOVIMIENTO = 1
        }

        public enum ORIGEN
        {
            COMPROBANTE_MANUAL = 1, 
            FACTURACION_MENSUAL = 2, 
            PARTE_CONEXION = 3, 
            COMPLEMENTARIAS = 4,
            ASIGNACION_EQUIPOS = 5,
            CTACTE = 6,
            OTROS = 7,
            FACTURACION_MENSUAL_DEBITOS = 8, 
            COMPROBANTE_DETALLADO = 9,
            PAGOS_EXTERNOS = 10
        }

        public enum TIPO_PUNITORIO
        {
            CAMBIA_MES = 1,
            VENCE = 2
        }
        #endregion

        private Conexion oCon = new Conexion();

        public Int32 Guardar(Usuarios_CtaCte oCtaCte)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("INSERT INTO usuarios_ctacte(Id_Usuarios, Id_Usuarios_Locacion, Id_Comprobantes, Id_Comprobantes_Tipo, Fecha_Movimiento, Fecha_Desde, " +
                    "Fecha_Hasta, Descripcion, Importe_Original, Importe_Punitorio, Importe_Bonificacion, Importe_Final,importe_provincial, Importe_Saldo, Numero, Id_Comprobantes_Ref, id_facturacion, generado_facturacion_mensual, id_iva_ventas,id_personal,id_origen,percepcion,id_plan_recibo, porcentaje_percepcion) " +
                    "VALUES(@usuario, @locacion, @comprobante, @comprobante_tipo, @fecha, @desde, @hasta, @descrip, @original, @punitorio, @bonificacion, @final,@provincial, @saldo, @numero, @idref, @id_facturacion, @generado_facturacion_mensual, @id_iva_ventas,@idpersonal,@id_origen,@percepcion,@idplan, @porcentajePer); SELECT @@IDENTITY");

                oCon.AsignarParametroEntero("@usuario", oCtaCte.Id_Usuarios);
                oCon.AsignarParametroEntero("@locacion", oCtaCte.Id_Usuarios_Locacion);
                oCon.AsignarParametroEntero("@comprobante", oCtaCte.Id_Comprobantes);
                oCon.AsignarParametroEntero("@comprobante_tipo", oCtaCte.Id_Comprobantes_Tipo);
                oCon.AsignarParametroFecha("@fecha", oCtaCte.Fecha_Movimiento);
                oCon.AsignarParametroFecha("@desde", oCtaCte.Fecha_Desde);
                oCon.AsignarParametroFecha("@hasta", oCtaCte.Fecha_Hasta);
                oCon.AsignarParametroCadena("@descrip", oCtaCte.Descripcion);
                oCon.AsignarParametroDecimal("@original", oCtaCte.Importe_Original);
                oCon.AsignarParametroDecimal("@punitorio", oCtaCte.Importe_Punitorio);
                oCon.AsignarParametroDecimal("@bonificacion", oCtaCte.Importe_Bonificacion);
                oCon.AsignarParametroDecimal("@final", oCtaCte.Importe_Final);
                oCon.AsignarParametroDecimal("@provincial", oCtaCte.Importe_Provincial);
                oCon.AsignarParametroDecimal("@saldo", oCtaCte.Importe_Saldo);
                oCon.AsignarParametroCadena("@numero", oCtaCte.Numero);
                oCon.AsignarParametroEntero("@idref", oCtaCte.Id_Comprobantes);
                oCon.AsignarParametroEntero("@id_facturacion", oCtaCte.Id_Facturacion);
                oCon.AsignarParametroEntero("@generado_facturacion_mensual", oCtaCte.Generado_facturacion_mensual);
                oCon.AsignarParametroEntero("@id_iva_ventas", oCtaCte.Id_Iva_Ventas);
                oCon.AsignarParametroEntero("@idpersonal", oCtaCte.Id_Personal);
                oCon.AsignarParametroEntero("@id_origen", oCtaCte.Id_Origen);
                oCon.AsignarParametroEntero("@percepcion", oCtaCte.Percepcion);
                oCon.AsignarParametroEntero("@idplan", oCtaCte.Id_Ctacte_Recibo_Plan);
                oCon.AsignarParametroDecimal("@porcentajePer", oCtaCte.Porcentaje_Percepcion);

                oCon.ComenzarTransaccion();
                oCtaCte.Id = oCon.EjecutarScalar();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                oCtaCte.Id = -1;
            }
            if (oCtaCte.Id > 0)
                GuardarCtaCteComprobante(Id, oCtaCte.Id_Comprobantes);
            return oCtaCte.Id;
        }

        public void GuardarAjustesManuales(DataTable dtAjustes)
        {
            DataTable dt = new DataTable();

            DataTable dtComprobanteCtacte = new DataTable();

            Usuarios_CtaCte_Det oUsuariosCtaCteDet = new Usuarios_CtaCte_Det();

            try
            {
                Int32 Idusuarioctacte = 0;
                Int32 Idcomprobante = 0;

                oCon.Conectar();
                foreach (DataRow fila in dtAjustes.Rows)
                {

                    if (Convert.ToDecimal(fila["bonificacionimporte"]) != 0)
                    {
                        Idusuarioctacte = Convert.ToInt32(fila["Id_usuarios_ctacte"]);
                        Idcomprobante = Convert.ToInt32(fila["Id_comprobantes"]);
                        oUsuariosCtaCteDet.Id_Usuarios_CtaCte = Convert.ToInt32(fila["Id_usuarios_ctacte"]);
                        oUsuariosCtaCteDet.Id_Usuarios_Locaciones = Convert.ToInt32(fila["Id_usuarios_locaciones"]);
                        oUsuariosCtaCteDet.Id_Zonas = 1;
                        oUsuariosCtaCteDet.Id_Servicios = Convert.ToInt32(fila["Id_servicios"]);
                        oUsuariosCtaCteDet.Id_Tipo = Convert.ToInt32(fila["id_tipo"]);
                        oUsuariosCtaCteDet.Tipo = fila["tipo"].ToString();
                        if (Convert.ToInt32(fila["Operacion"].ToString()) == 0) //descuento
                        {
                            oUsuariosCtaCteDet.Importe_Original = Convert.ToDecimal(fila["bonificacionimporte"]) * -1;
                            oUsuariosCtaCteDet.Importe_Saldo = Convert.ToDecimal(fila["bonificacionimporte"]) * -1;
                        }

                        if (Convert.ToInt32(fila["Operacion"].ToString()) == 1) //descuento
                        {
                            oUsuariosCtaCteDet.Importe_Original = Convert.ToDecimal(fila["bonificacionimporte"]);
                            oUsuariosCtaCteDet.Importe_Saldo = Convert.ToDecimal(fila["bonificacionimporte"]);
                        }

                        oUsuariosCtaCteDet.Importe_Punitorio = 0;
                        oUsuariosCtaCteDet.Importe_Bonificacion = 0;
                        oUsuariosCtaCteDet.Id_Usuarios_Servicios = Convert.ToInt32(fila["id_usuarios_servicios"]);
                        oUsuariosCtaCteDet.Id_Velocidades_Tip = 0;
                        oUsuariosCtaCteDet.Id_Velocidades = 0;
                        oUsuariosCtaCteDet.Requiere_IP = 0;
                        oUsuariosCtaCteDet.Cantidad_Periodos = 0;
                        oUsuariosCtaCteDet.Id_Usuarios_Servicios_sub = 0;
                        oUsuariosCtaCteDet.Fecha_Desde = Convert.ToDateTime(fila["fecha_desde"]);
                        oUsuariosCtaCteDet.Fecha_Hasta = Convert.ToDateTime(fila["fecha_hasta"]);
                        oUsuariosCtaCteDet.Id_bonificacion_Aplicada = 0;
                        oUsuariosCtaCteDet.Nombre_Bonificacion = "";
                        oUsuariosCtaCteDet.Porcentaje_Bonificacion = 0;
                        oUsuariosCtaCteDet.Periodo_Mes = 0;
                        oUsuariosCtaCteDet.Periodo_Ano = 0;
                        oUsuariosCtaCteDet.Detalles = fila["Detalle"].ToString();
                        oUsuariosCtaCteDet.Id_Tipo_Registro_Cta_Cte_Det = Convert.ToInt32(Usuarios_CtaCte_Det.TIPO_REGISTRO_CTACTEDET.BONIFICACION_MANUAL);
                        oUsuariosCtaCteDet.Guardar(oUsuariosCtaCteDet);
                    }

                    //if (Convert.ToInt32(fila["idTipoAjuste"]) == Convert.ToInt32(Usuarios_CtaCte.TIPO_AJUSTE.DESCUENTO))
                    //    oUsuariosCtaCteDet.ActualizarImporteAjusteManual(Convert.ToInt32(registro["id"]), Convert.ToDecimal(registro["importe_ajuste_manual"]) - ajuste);
                    //else
                    //    oUsuariosCtaCteDet.ActualizarImporteAjusteManual(Convert.ToInt32(registro["id"]), Convert.ToDecimal(registro["importe_ajuste_manual"]) + ajuste);

                }

                if (Idcomprobante > 0)
                {
                    oCon.CrearComando("call ActualizarImportesCtaCte(@idComprobante, @idUsuariosCtaCte)");
                    oCon.AsignarParametroCadena("@idComprobante", Idcomprobante.ToString());
                    oCon.AsignarParametroCadena("@idUsuariosCtaCte", Idusuarioctacte.ToString());
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

        public void SetDetallePlanPago(Int32 IdUsuariosCtaCte, String Detalle)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("UPDATE Usuarios_CtaCte SET Descripcion = @detalle,id_personal=@personal WHERE Id = @id");
                oCon.AsignarParametroCadena("@detalle", Detalle);
                oCon.AsignarParametroEntero("@personal", Personal.Id_Login);
                oCon.AsignarParametroEntero("@id", IdUsuariosCtaCte);
                oCon.EjecutarComando();
                oCon.DesConectar();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void GuardarCtaCteComprobante(int idCtaCte, int idComprobante)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("INSERT INTO usuarios_ctacte_comprobantes (id_usuarios_ctacte,id_comprobantes,id_personal) VALUES (@idCta,@idComprobante,@idPersonal)");
                oCon.AsignarParametroEntero("@idCta", idCtaCte);
                oCon.AsignarParametroEntero("@idComprobante", idComprobante);
                oCon.AsignarParametroEntero("@idPersonal", Personal.Id_Login);

                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
            }
            catch (Exception ex)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                throw;
            }
        }

        public DataTable GetDtModelo()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("elige", typeof(Boolean));
            dt.Columns.Add("expande", typeof(String));
            dt.Columns.Add("Servicio", typeof(String));
            dt.Columns.Add("Fecha_Desde", typeof(DateTime));
            dt.Columns.Add("Fecha_hasta", typeof(DateTime));
            dt.Columns.Add("Sub_Servicio", typeof(String));
            dt.Columns.Add("Importe_original", typeof(Decimal));
            dt.Columns.Add("Importe_saldo", typeof(Decimal));
            dt.Columns.Add("Id", typeof(Int32));
            dt.Columns.Add("Id_usuarios_ctacte", typeof(Int32));
            dt.Columns.Add("Id_servicios", typeof(Int32));
            dt.Columns.Add("Importe_punitorio", typeof(Decimal));
            dt.Columns.Add("Importe_bonificacion", typeof(Decimal));
            dt.Columns.Add("Importe_provincial", typeof(Decimal));
            dt.Columns.Add("Importe_Total", typeof(Decimal));
            dt.Columns.Add("Importe_Pago", typeof(Decimal));
            dt.Columns.Add("Id_tipo", typeof(Decimal)); // es el subservicio
            dt.Columns.Add("Id_usuarios_locaciones", typeof(Int32));
            dt.Columns.Add("Encabezado", typeof(Int32)); //0= FACTURA 1= SERVICIO 2=SUBSERVICIO
            dt.Columns.Add("Muestra", typeof(Int32)); //0 NO 1= SI
            dt.Columns.Add("id_usuarios", typeof(Int32));
            dt.Columns.Add("id_usuarios_servicios", typeof(Int32));
            dt.Columns.Add("domicilio", typeof(String));
            dt.Columns.Add("Id_Comprobantes", typeof(Int32));
            dt.Columns.Add("Id_Comprobantes_Tipo", typeof(Int32));
            dt.Columns.Add("Id_Comprobantes_nuevo", typeof(Int32)); // si paso a facutras
            dt.Columns.Add("dias", typeof(Int32)); // si paso a facutras
            dt.Columns.Add("Tipo_Nombre", typeof(String)); // TIPO SE SERVICIOS
            dt.Columns.Add("Punto", typeof(Int32)); // pto de venta
            dt.Columns.Add("Numero", typeof(Int32)); // numero de comprobante
            dt.Columns.Add("Id_Servicios_Tipo", typeof(Int32)); // numero de comprobante
            dt.Columns.Add("Servicio_Nombre", typeof(String));
            dt.Columns.Add("Presenta_ventas", typeof(Int32));  /// 1 ya es factura --- 0  es comprobante y lo debe convertir
            dt.Columns.Add("Id_Iva_Ventas", typeof(Int32));
            dt.Columns.Add("Detalles", typeof(String));
            dt.Columns.Add("Tipo", typeof(String)); // S=Servicio      P=PARTES    F=Falla
            dt.Columns.Add("Id_Bonificacion_Aplicada", typeof(Int32)); // 
            dt.Columns.Add("Bonificacion_Nombre", typeof(String)); //
            dt.Columns.Add("Id_Iva_Alicuotas", typeof(Int32)); // 
            dt.Columns.Add("Idtiporegistroctactedet", typeof(Int32)); //
            dt.Columns.Add("FechaEstado", typeof(DateTime)); // Fecha estado del servicio
            dt.Columns.Add("Estado", typeof(Int32)); // estado del servicio
            dt.Columns.Add("Iva_Alicuota", typeof(Decimal)); // iva_alicuota
            dt.Columns.Add("Cuenta", typeof(Int32)); // Cuenta por defecto  marcelo 08/11
            dt.Columns.Add("Id_Debito_Asociado", typeof(Int32)); // 
            DataColumn dc = new DataColumn()
            {
                ColumnName = "CalcularPercepcion",
                DataType = typeof(Int32),
                DefaultValue = 0
            };
            dt.Columns.Add(dc);

            DataColumn drech = new DataColumn()
            {
                ColumnName = "rechazado",
                DataType = typeof(Int32),
                DefaultValue = 0
            };
            dt.Columns.Add(drech);

            DataColumn dcDiasPunitorios = new DataColumn()
            {
                ColumnName = "diaspunitorio",
                DataType = typeof(Int32),
                DefaultValue = 0
            };
            dt.Columns.Add(dcDiasPunitorios);


            DataColumn idColumn = new DataColumn("autonumerico", typeof(int));
            idColumn.Unique = true;//<==indicamos que será unico
            idColumn.AutoIncrement = true; //<==Aqui indicamos que se autoincrementa
            idColumn.AutoIncrementSeed = 1;//<==Aqui indicamos que inicia en 1
            idColumn.AutoIncrementStep = 1;//<==
            dt.Columns.Add(idColumn);

            DataColumn dcPercepcion = new DataColumn()
            {
                ColumnName = "percepcion",
                DataType = typeof(Int32),
                DefaultValue = 0
            };
            dt.Columns.Add(dcPercepcion);

            DataColumn dcCantidad = new DataColumn()
            {
                ColumnName = "cantidad",
                DataType = typeof(decimal),
                DefaultValue = 1
            };
            dt.Columns.Add(dcCantidad);

            return dt;
        }

        public DataTable LlenarDtModelo(DataTable dtLocaciones, String tipo, int Id, int idUsuario = 0)
        {
            if (idUsuario > 0)
            {
                dtCtaCte = ListarCtaCte_deuda(tipo, idUsuario, Id);//lista todos los registros de la tabla usuarios_ctacte que compartan el mismo id_comprobante en caso de que la variable 'tipo' tenga valor 'C'.
                dtCtaCteDet = oUsuCtaCteDet.Listar(idUsuario, 0, (int)Usuarios_CtaCte_Det.TIPO_CONSULTA_CTACTE_DET.CON_DEUDA);//lista los registros de la tabla usuarios_ctacte_det que pertenecen a un id_usuario en particular.
            }
            else
            {
                dtCtaCte = ListarCtaCte_deuda(tipo, Usuarios.CurrentUsuario.Id, Id);//lista todos los registros de la tabla usuarios_ctacte que compartan el mismo id_comprobante en caso de que la variable 'tipo' tenga valor 'C'.
                dtCtaCteDet = oUsuCtaCteDet.Listar(Id, 0, (int)Usuarios_CtaCte_Det.TIPO_CONSULTA_CTACTE_DET.ID_CTACTE);
            }
            dtCtaCteDetfinal = GetDtModelo();

            foreach (DataRow dr_loc in dtLocaciones.Rows) // Recorre las locaciones
            {
                DataTable dtFiltradaPorLocacion;//datatable que contiene los registros de ctacte que pertenecen a una locación específica.

                DataView ViewCta = dtCtaCte.DefaultView;
                ViewCta.RowFilter = string.Format("id_usuarios_locacion = {0} ", Convert.ToInt32(dr_loc["id"].ToString()));//filtra registros de usuarios_ctacte según id_usuarios_locaciones
                string locacion;
                locacion = dr_loc["calle"].ToString().Trim() + " Nro (" + dr_loc["Altura"].ToString() + ") - " + dr_loc["piso"].ToString() + "  " + dr_loc["depto"].ToString();
                dtFiltradaPorLocacion = ViewCta.ToTable();//contiene los registros de ctacte que pertenecen a la locación que se está recorriendo en el bucle.

                foreach (DataRow dr_cta in dtFiltradaPorLocacion.Rows) // recorre ctacte de esa locacion. Arma el datatable dtCtaCteDetFinal para que luego sirva de fuente de datos para la grilla del formulario
                {
                    Int32 idcta = Convert.ToInt32(dr_cta["id"].ToString());
                    /// Crea la LInea de Comprobantes 
                    int d = Convert.ToInt32(dr_cta["rechazado"]);
                    DataRow drDet = dtCtaCteDetfinal.NewRow();
                    drDet["elige"] = false;
                    drDet["expande"] = "+";
                    drDet["servicio"] = dr_cta["Descripcion"].ToString();
                    drDet["fecha_desde"] = dr_cta["fecha_desde"];
                    drDet["fecha_hasta"] = dr_cta["fecha_hasta"];
                    drDet["sub_servicio"] = "";
                    drDet["importe_original"] = Convert.ToDecimal(dr_cta["Importe_original"]);
                    drDet["importe_saldo"] = Convert.ToDecimal(dr_cta["Importe_saldo"]) - Convert.ToDecimal(dr_cta["Importe_provincial"]);
                    drDet["id"] = Convert.ToInt32(dr_cta["id"]);
                    drDet["id_usuarios_ctacte"] = idcta;
                    drDet["id_servicios"] = 0;
                    drDet["importe_punitorio"] = Convert.ToDecimal(dr_cta["Importe_punitorio"]);
                    drDet["importe_bonificacion"] = Convert.ToDecimal(dr_cta["Importe_bonificacion"]);
                    drDet["importe_provincial"] = Convert.ToDecimal(dr_cta["Importe_provincial"]);
                    drDet["importe_total"] = Convert.ToDecimal(dr_cta["Importe_saldo"]);
                    if (tipo == "C")
                    {
                        drDet["importe_pago"] = 1;

                    }
                    drDet["id_tipo"] = 0;
                    drDet["id_usuarios_locaciones"] = Convert.ToInt32(dr_loc["id"]);
                    drDet["encabezado"] = 2;
                    drDet["muestra"] = 1;
                    drDet["id_usuarios"] = Usuarios.CurrentUsuario.Id;
                    drDet["id_usuarios_servicios"] = 0;
                    drDet["domicilio"] = locacion;
                    drDet["id_comprobantes"] = Convert.ToInt32(dr_cta["id_comprobantes"]);
                    drDet["id_comprobantes_tipo"] = Convert.ToInt32(dr_cta["id_comprobantes_tipo"]);
                    drDet["id_comprobantes_nuevo"] = 0;
                    drDet["dias"] = 0;
                    drDet["tipo_nombre"] = "SERVICIO";
                    drDet["punto"] = Convert.ToInt32(dr_cta["punto_venta"]);
                    drDet["numero"] = Convert.ToInt32(dr_cta["numero"]);
                    drDet["id_servicios_tipo"] = 0;
                    drDet["servicio_nombre"] = "";
                    drDet["presenta_ventas"] = Convert.ToInt32(dr_cta["presenta_ventas"]);
                    drDet["id_iva_ventas"] = Convert.ToInt32(dr_cta["id_iva_ventas"]);
                    drDet["detalles"] = "";
                    drDet["tipo"] = "";
                    drDet["id_bonificacion_aplicada"] = 0;
                    drDet["bonificacion_nombre"] = "";
                    drDet["id_iva_alicuotas"] = 0;
                    drDet["idtiporegistroctactedet"] = 0;
                    drDet["fechaestado"] = DateTime.Now;
                    drDet["estado"] = 0;
                    drDet["iva_alicuota"] = 0;
                    drDet["cuenta"] = 1;
                    drDet["id_debito_asociado"] = 0;
                    drDet["calcularpercepcion"] = Convert.ToInt32(dr_cta["percepcion"]);
                    drDet["percepcion"] = Convert.ToInt32(dr_cta["percepcion"]);
                    drDet["rechazado"] = 0;
                    drDet["diaspunitorio"] = Convert.ToInt32(dr_cta["dias_punitorio"]);
                    dtCtaCteDetfinal.Rows.Add(drDet);
                    //dtCtaCteDetfinal.Rows.Add(false, "+", dr_cta["Descripcion"].ToString(), dr_cta["fecha_desde"], dr_cta["fecha_hasta"], "", Convert.ToDecimal(dr_cta["Importe_original"]), Convert.ToDecimal(dr_cta["Importe_saldo"]) - Convert.ToDecimal(dr_cta["Importe_provincial"]), Convert.ToInt32(dr_cta["id"]), idcta, 0, Convert.ToDecimal(dr_cta["Importe_punitorio"]), 
                    //  Convert.ToDecimal(dr_cta["Importe_bonificacion"]), Convert.ToDecimal(dr_cta["Importe_provincial"]), 0, 0, 0, Convert.ToInt32(dr_loc["id"].ToString()), 2, 1, Usuarios.CurrentUsuario.Id, 0, locacion,
                    // Convert.ToInt32(dr_cta["id_comprobantes"]), Convert.ToInt32(dr_cta["id_comprobantes_tipo"]), Convert.ToInt32(dr_cta["id_comprobantes_tipo"]), 0, "SERVICIO", 
                    //Convert.ToInt32(dr_cta["punto_venta"]), Convert.ToInt32(dr_cta["numero"]), 0, "", Convert.ToInt32(dr_cta["presenta_ventas"]), Convert.ToInt32(dr_cta["id_iva_ventas"]),
                    //"", "", 0, "", 0, 0, DateTime.Now,0,0,1, 0);
                    /// Genera servicios y subservicios
                    Generar_Grilla_det(idcta, Convert.ToInt32(dr_loc["id"].ToString()), Convert.ToDateTime(dr_cta["fecha_desde"].ToString()), Convert.ToDateTime(dr_cta["fecha_hasta"].ToString()), Convert.ToInt32(dr_cta["presenta_ventas"]), Convert.ToInt32(dr_cta["rechazado"]), Convert.ToInt32(dr_cta["dias_punitorio"]));
                }
            }
            return dtCtaCteDetfinal;
        }

        public void Generar_Grilla_det(int idcta, int idloc, DateTime fecha_desde, DateTime fecha_hasta, Int32 PresentaVentas, Int32 Rechazado, Int32 DiasPuni)
        {
            DateTime Fechaestado;
            int Estado = 0;
            Int32 Fila_Comprobante = dtCtaCteDetfinal.Rows.Count - 1;

            /// Agrupa servicios recorriendo usuariosctactedet
            /// 
            DataTable titulo = new DataTable();
            titulo.Columns.Add("servicio", typeof(String));
            titulo.Columns.Add("importe_original", typeof(Decimal));
            titulo.Columns.Add("id_servicios", typeof(Int32));
            titulo.Columns.Add("id", typeof(Int32));  // id detalle ctacte
            titulo.Columns.Add("id_usuarios_ctacte", typeof(Int32));  // id detalle ctacte
            titulo.Columns.Add("Importe_saldo", typeof(Decimal));  // id detalle ctacte
            titulo.Columns.Add("Importe_bonificacion", typeof(Decimal));  // id detalle ctacte
            titulo.Columns.Add("Importe_provincial", typeof(Decimal));  // id detalle ctacte
            titulo.Columns.Add("Importe_punitorio", typeof(Decimal));  // id detalle ctacte
            titulo.Columns.Add("id_usuarios_servicios", typeof(Int32));  // id detalle ctacte
            titulo.Columns.Add("id_comprobantes", typeof(Int32));  // id detalle ctacte
            titulo.Columns.Add("id_comprobantes_tipo", typeof(Int32));  // id detalle ctacte
            titulo.Columns.Add("id_servicios_tipo", typeof(Int32));  // id detalle ctacte
            titulo.Columns.Add(new DataColumn("Cantidad", typeof(decimal)) { DefaultValue = 1 });  // id detalle ctacte

            foreach (DataRow dr in dtCtaCteDet.Rows) // busca los servicios dentro del comprobante 
            {
                if (Convert.ToInt32(dr["id_usuarios_ctacte"]) == idcta)
                {

                    int esta = 0;

                    foreach (DataRow dr_fi in titulo.Rows)
                    {

                        if (Convert.ToInt32(dr["id_usuarios_servicios"].ToString()) == Convert.ToInt32(dr_fi["id_usuarios_servicios"].ToString()))
                            esta = 1;
                    }

                    if (esta == 0)
                    {
                        string vel;
                        string velt;
                        string serv;

                        if (string.IsNullOrEmpty(dr["velocidad"].ToString()))
                            vel = "";
                        else
                            vel = dr["velocidad"].ToString() + " Mb ";

                        if (string.IsNullOrEmpty(dr["velocidad_tipo"].ToString()))
                            velt = "";
                        else
                            velt = dr["velocidad_tipo"].ToString();

                        if (string.IsNullOrEmpty(dr["servicio"].ToString().ToString()))
                            serv = "";
                        else
                            serv = dr["servicio"].ToString();

                        DataRow drTitulo = titulo.NewRow();
                        drTitulo["servicio"] = serv + " " + vel + " " + velt;
                        drTitulo["importe_original"] = 0;
                        drTitulo["id_servicios"] = Convert.ToInt32(dr["id_servicios"]);
                        drTitulo["id"] = Convert.ToInt32(dr["Id"]);
                        drTitulo["id_usuarios_ctacte"] = Convert.ToInt32(dr["Id_usuarios_ctacte"]);
                        drTitulo["Importe_saldo"] = 0;
                        drTitulo["Importe_bonificacion"] = 0;
                        drTitulo["Importe_provincial"] = 0;
                        drTitulo["Importe_punitorio"] = 0;
                        drTitulo["id_usuarios_servicios"] = Convert.ToInt32(dr["Id_usuarios_servicios"]);
                        drTitulo["id_comprobantes"] = Convert.ToInt32(dr["Id_comprobantes"]);
                        drTitulo["id_comprobantes_tipo"] = Convert.ToInt32(dr["Id_comprobantes_tipo"]);
                        drTitulo["id_servicios_tipo"] = Convert.ToInt32(dr["serviciostipoid"]);
                        drTitulo["Cantidad"] = Convert.ToDecimal(dr["Cantidad"]);
                        titulo.Rows.Add(drTitulo);
                        //titulo.Rows.Add(serv + " " + vel + " " + velt, 0, Convert.ToInt32(dr["id_servicios"].ToString()), Convert.ToInt32(dr["Id"]), Convert.ToInt32(dr["Id_usuarios_ctacte"]), 0, 0, 0, 0, 
                        //Convert.ToInt32(dr["Id_usuarios_servicios"]), Convert.ToInt32(dr["Id_comprobantes"]), Convert.ToInt32(dr["Id_comprobantes_tipo"]), Convert.ToInt32(dr["serviciostipoid"].ToString()));

                    }
                }

            }


            foreach (DataRow dr_ti in titulo.Rows)
            {
                DataRow drIns;
                drIns = dtCtaCteDetfinal.NewRow();
                drIns["elige"] = false;
                drIns["expande"] = "+";
                drIns["Servicio"] = "   " + dr_ti["servicio"].ToString();
                drIns["Fecha_Desde"] = fecha_desde;
                drIns["Fecha_hasta"] = fecha_hasta;
                drIns["Sub_Servicio"] = dr_ti["servicio"].ToString();
                drIns["Importe_original"] = 0;
                drIns["Importe_saldo"] = 0;
                drIns["Id"] = Convert.ToInt32(dr_ti["id"]);
                drIns["Id_usuarios_ctacte"] = idcta;
                drIns["Id_servicios"] = Convert.ToInt32(dr_ti["id_servicios"].ToString());
                drIns["Importe_punitorio"] = 0;
                drIns["Importe_bonificacion"] = 0;
                drIns["Importe_provincial"] = 0;
                drIns["Importe_Total"] = 0;
                drIns["Importe_Pago"] = 0;
                drIns["Id_tipo"] = Convert.ToInt32(dr_ti["id_servicios"].ToString());
                drIns["Id_usuarios_locaciones"] = idloc;
                drIns["Encabezado"] = 1; //0= FACTURA 1= SERVICIO 2=SUBSERVICIO
                drIns["Muestra"] = 0; //0 NO 1= SI
                drIns["id_usuarios"] = Usuarios.CurrentUsuario.Id;
                drIns["id_usuarios_servicios"] = Convert.ToInt32(dr_ti["id_usuarios_servicios"].ToString());
                drIns["domicilio"] = "";
                drIns["Id_Comprobantes"] = Convert.ToInt32(dr_ti["Id_comprobantes"]);
                drIns["Id_Comprobantes_Tipo"] = Convert.ToInt32(dr_ti["id_comprobantes_tipo"]);
                drIns["Id_Comprobantes_nuevo"] = 0; // si paso a facutras
                drIns["dias"] = 0; // si paso a facutras
                drIns["Tipo_Nombre"] = "SERVICIO";// TIPO SE SERVICIOS
                drIns["Punto"] = 0;// pto de venta
                drIns["Numero"] = 0; // numero de comprobante
                drIns["Id_Servicios_Tipo"] = Convert.ToInt32(dr_ti["id_servicios_tipo"]); // numero de comprobante
                drIns["Servicio_Nombre"] = dr_ti["servicio"].ToString();
                drIns["Presenta_Ventas"] = PresentaVentas;
                drIns["Detalles"] = "";
                drIns["Tipo"] = "";
                drIns["Id_Bonificacion_Aplicada"] = 0;
                drIns["Bonificacion_Nombre"] = "";
                drIns["Id_Iva_Alicuotas"] = 0;
                drIns["Idtiporegistroctactedet"] = 0;
                drIns["FechaEstado"] = DateTime.Now;
                drIns["Estado"] = 0;
                drIns["cuenta"] = 0;
                drIns["id_debito_asociado"] = 0;
                drIns["rechazado"] = Rechazado;
                drIns["diaspunitorio"] = DiasPuni;

                ///                Convert.ToDateTime(dr_cta["fecha_estado"].ToString()), Convert.ToInt32(dr_cta["id_servicios_estados"].ToString())
                /// Inserta la linea de servicios
                dtCtaCteDetfinal.Rows.Add(drIns);
                Int32 Fila_Servicio = dtCtaCteDetfinal.Rows.Count - 1;



                Int32 idse = Convert.ToInt32(dr_ti["id_usuarios_servicios"].ToString());

                foreach (DataRow dr in dtCtaCteDet.Rows)
                {
                    decimal monto_boni;

                    Int32 idse1 = Convert.ToInt32(dr["id_usuarios_servicios"].ToString());
                    Int32 idca1 = Convert.ToInt32(dr["id_usuarios_ctacte"].ToString());
                    Int32 Debib = Convert.ToInt32(dr["Id_debito_asociado"].ToString());

                    if (Rechazado == 1)
                        Debib = 0;



                    monto_boni = decimal.Round(Convert.ToDecimal(dr["importe_bonificacion"].ToString()), 2);

                    if (idse == idse1 && idcta == idca1)
                    {
                        if (Convert.ToDateTime(dr["fecha_desde"].ToString()) < Fecha_Desde)
                            Fecha_Desde = Convert.ToDateTime(dr["fecha_desde"].ToString());

                        if (Convert.ToDateTime(dr["fecha_hasta"].ToString()) > Fecha_Hasta)
                            Fecha_Desde = Convert.ToDateTime(dr["fecha_desde"].ToString());


                        if (string.IsNullOrEmpty(dr["fecha_estado"].ToString()))
                            Fechaestado = DateTime.Now;
                        else
                            Fechaestado = Convert.ToDateTime(dr["fecha_estado"].ToString());

                        if (string.IsNullOrEmpty(dr["id_servicios_estados"].ToString()))
                            Estado = 2;
                        else
                            Estado = Convert.ToInt32(dr["id_servicios_estados"].ToString());


                        ////*****************************************************************



                        dtCtaCteDetfinal.Rows.Add(false, "", "       " + dr["Sub_Servicio"].ToString().Trim() + " " + dr["Detalles"].ToString().Trim(), Convert.ToDateTime(dr["fecha_desde"].ToString()), Convert.ToDateTime(dr["fecha_hasta"].ToString()), dr["Sub_Servicio"].ToString(), Convert.ToDecimal(dr["Importe_original"]), Convert.ToDecimal(dr["Importe_saldo"]) - Convert.ToDecimal(dr["Importe_provincial"]), Convert.ToInt32(dr["id"]), idcta, Convert.ToInt32(dr["id_servicios"]), Convert.ToDecimal(dr["Importe_punitorio"]), monto_boni, Convert.ToDecimal(dr["Importe_provincial"]), Convert.ToDecimal(dr["Importe_saldo"]), 0, Convert.ToInt32(dr["id_tipo"]), idloc, 0, 0, Usuarios.CurrentUsuario.Id, Convert.ToInt32(dr["Id_usuarios_servicios"]), "", Convert.ToInt32(dr_ti["Id_comprobantes"]), Convert.ToInt32(dr_ti["id_comprobantes_tipo"]), 0, 0, dr["servicio_tipo"].ToString(), 0, 0, Convert.ToInt32(dr_ti["id_servicios_tipo"]), dr_ti["servicio"].ToString(), PresentaVentas, 0, dr["Detalles"].ToString(), dr["Tipo"].ToString(), Convert.ToInt32(dr["Id_Bonificacion_Aplicada"].ToString()), dr["Nombre_Bonificacion"].ToString(), Convert.ToInt32(dr["Id_iva_alicuotas"].ToString()), Convert.ToInt32(dr["Idtiporegistroctactedet"].ToString()), Fechaestado, Estado, Convert.ToDecimal(dr["porcentaje_divide"]), Convert.ToDecimal(dr["cuenta"]), Debib, 0, Rechazado, DiasPuni);
                        dtCtaCteDetfinal.Rows[dtCtaCteDetfinal.Rows.Count - 1]["Cantidad"] = Convert.ToDecimal(dr["Cantidad"]);

                        dtCtaCteDetfinal.Rows[Fila_Servicio]["importe_original"] = Convert.ToDecimal(dtCtaCteDetfinal.Rows[Fila_Servicio]["importe_original"].ToString()) + decimal.Round(Convert.ToDecimal(dr["importe_original"].ToString()), 2);
                        dtCtaCteDetfinal.Rows[Fila_Servicio]["importe_saldo"] = Convert.ToDecimal(dtCtaCteDetfinal.Rows[Fila_Servicio]["importe_saldo"].ToString()) + decimal.Round(Convert.ToDecimal(dr["importe_saldo"].ToString()), 2);
                        dtCtaCteDetfinal.Rows[Fila_Servicio]["importe_bonificacion"] = Convert.ToDecimal(dtCtaCteDetfinal.Rows[Fila_Servicio]["importe_bonificacion"].ToString()) + decimal.Round(Convert.ToDecimal(dr["importe_bonificacion"].ToString()), 2);
                        dtCtaCteDetfinal.Rows[Fila_Servicio]["importe_provincial"] = Convert.ToDecimal(dtCtaCteDetfinal.Rows[Fila_Servicio]["importe_provincial"].ToString()) + decimal.Round(Convert.ToDecimal(dr["importe_provincial"].ToString()), 2);
                        dtCtaCteDetfinal.Rows[Fila_Servicio]["importe_total"] = Convert.ToDecimal(dtCtaCteDetfinal.Rows[Fila_Servicio]["importe_saldo"].ToString()) + decimal.Round(Convert.ToDecimal(dr["importe_saldo"].ToString()), 2);


                    }

                }

            }


        }

        public DataTable ListarCtaCte_deuda(String tipo, Int32 idUsuario, Int32 idLocacion)
        {
            DataTable dt = new DataTable();

            try
            {
                string Condicion = "select usuarios_ctacte.id,usuarios_ctacte.id_usuarios,usuarios_ctacte.id_comprobantes,usuarios_ctacte.fecha_movimiento,usuarios_ctacte.fecha_desde,usuarios_ctacte.fecha_hasta,usuarios_ctacte.descripcion,"
                + " usuarios_ctacte.importe_original,usuarios_ctacte.importe_punitorio,usuarios_ctacte.importe_bonificacion,usuarios_ctacte.importe_provincial,usuarios_ctacte.importe_final,usuarios_ctacte.importe_saldo,"
                + " usuarios_ctacte.estado,usuarios_ctacte.id_usuarios_locacion,usuarios_ctacte.id_comprobantes_tipo,usuarios_ctacte.id_comprobantes_ref,usuarios_ctacte.importe_pago,comprobantes.punto_venta,comprobantes.numero,"
                + " comprobantes_tipo.presenta_ventas, usuarios_ctacte.id_iva_ventas,usuarios_ctacte.rechazado,usuarios_ctacte.percepcion,usuarios_ctacte.dias_punitorio"
                + " from usuarios_ctacte"
                + " left join comprobantes on comprobantes.id = usuarios_ctacte.id_comprobantes"
                + " left join comprobantes_tipo on comprobantes_tipo.id = comprobantes.id_comprobantes_tipo ";
                oCon.Conectar();

                switch (tipo)
                {
                    case "U":
                        oCon.CrearComando(Condicion +
                        " WHERE usuarios_ctacte.id_usuarios = @id and usuarios_ctacte.importe_saldo <> @saldo and usuarios_ctacte.borrado=0 ");
                        oCon.AsignarParametroEntero("@id", idUsuario);
                        oCon.AsignarParametroDecimal("@saldo", 0);
                        break;
                    case "L":
                        oCon.CrearComando(Condicion + " WHERE usuarios_ctacte.id_usuarios = @id AND id_usuarios_locacion = @locacion  and usuarios_ctacte.borrado=0");
                        oCon.AsignarParametroEntero("@id", idUsuario);
                        oCon.AsignarParametroEntero("@locacion", idLocacion);
                        break;
                    case "C":
                        oCon.CrearComando(Condicion +
                        " WHERE usuarios_ctacte.id_comprobantes = @id  and usuarios_ctacte.borrado=0 ");
                        oCon.AsignarParametroEntero("@id", idLocacion);
                        break;
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

        public DataTable ListarCtaCteCompletaNuevo(Int32 idUsuario, Int32 idLocacion, DateTime? fechaMov = null, decimal importeFinal = 0)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();

                if (fechaMov.HasValue)
                {
                    oCon.CrearComando("select personal.nombre as personal, usuarios_ctacte.descripcion, usuarios_ctacte.numero, usuarios_ctacte.fecha_movimiento, usuarios_ctacte.fecha_Desde, usuarios_ctacte.fecha_hasta," +
                        " usuarios_ctacte.importe_original, usuarios_ctacte.importe_punitorio, usuarios_ctacte.importe_bonificacion, usuarios_ctacte.importe_final, usuarios_ctacte.importe_pago, usuarios_ctacte.importe_saldo," +
                        " usuarios_ctacte.importe_saldo as importe_saldo_comprobante, usuarios_ctacte.id, usuarios_ctacte.id_usuarios_locacion," +
                        " usuarios_ctacte.id_comprobantes, 'F' as tipo, usuarios_ctacte.descripcion as relacion, usuarios_ctacte.id_comprobantes_tipo, usuarios_ctacte.id_usuarios_ctacte_recibos as id_recibos," +
                        " usuarios_ctacte.id_iva_ventas, sum(usuarios_ctacte.importe_provincial) as importe_provincial, usuarios_ctacte.percepcion, usuarios_ctacte.id_comp_notadebito_asociada," +
                        " usuarios_ctacte.dias_punitorio,sum(usuarios_ctacte_det.id_debito_asociado) as id_debito,usuarios_ctacte.rechazado,usuarios_ctacte.id_plan_recibo " +
                        " from usuarios_ctacte" +
                        " LEFT JOIN personal ON personal.id = usuarios_ctacte.id_personal" +
                        " LEFT JOIN usuarios_ctacte_det ON usuarios_ctacte_det.id_usuarios_ctacte = usuarios_ctacte.id" +
                        " where date(usuarios_ctacte.fecha_movimiento) = @fecha and abs(usuarios_ctacte.importe_final - @impFinal) < 1" +
                        " ORDER BY usuarios_ctacte.Fecha_desde ");
                    oCon.AsignarParametroFecha("@fecha", fechaMov.Value.Date);
                    oCon.AsignarParametroDecimal("@impFinal", importeFinal);
                }
                else if(idLocacion > 0 && idUsuario > 0)
                {
                    oCon.CrearComando("select  usuarios_ctacte_recibos.id as Id_Usu_rec, usuarios_ctacte_recibos.borrado as recibo_borrado,usuarios_ctacte.fecha_movimiento,usuarios_ctacte.descripcion,usuarios_ctacte.fecha_desde, usuarios_ctacte.fecha_hasta, " +
                        "usuarios_ctacte.numero, usuarios_ctacte.importe_original as importe_original, usuarios_ctacte.importe_punitorio as importe_punitorio, " +
                        "usuarios_ctacte.importe_bonificacion, usuarios_ctacte.importe_provincial as importe_provincial, usuarios_ctacte.importe_final as importe_final, usuarios_ctacte.importe_pago as importe_pago, " +
                        "usuarios_ctacte.importe_saldo as importe_saldo, usuarios_ctacte.importe_saldo as importe_saldo_comprobante, usuarios_ctacte.id, " +
                        "usuarios_ctacte.id_usuarios_locacion, usuarios_ctacte.id_comprobantes, 'f' as tipo, usuarios_ctacte.descripcion as relacion, " +
                        "usuarios_ctacte.id_comprobantes_tipo, usuarios_ctacte.id_usuarios_ctacte_recibos as id_recibos, usuarios_ctacte.id_iva_ventas, " +
                        "usuarios_ctacte.percepcion, usuarios_ctacte.id_comp_notadebito_asociada, " +
                        "usuarios_ctacte.dias_punitorio, sum(usuarios_ctacte_det.id_debito_asociado) as id_debito, usuarios_ctacte.rechazado, " +
                        "usuarios_ctacte.id_plan_recibo,usuarios_ctacte_recibos.numero_muestra as recibo, personalctacte.nombre as personalctacte, personalrecibo.nombre as personalrecibo " +
                        "from usuarios_ctacte " +
                        "left join usuarios_ctacte_det on usuarios_ctacte_det.id_usuarios_ctacte = usuarios_ctacte.id " +
                        "left join usuarios_ctacte_relacion on usuarios_ctacte_relacion.id_usuarios_ctacte = usuarios_ctacte.id " +
                        "left join usuarios_ctacte_recibos on usuarios_ctacte_relacion.id_usuarios_ctacte_recibos = usuarios_ctacte_recibos.id " +
                        "left join personal personalctacte on usuarios_ctacte.id_personal = personalctacte.id " +
                        "left join personal personalrecibo on usuarios_ctacte_recibos.id_personal = personalrecibo.id " +
                        "where usuarios_ctacte.id_usuarios = @id and usuarios_ctacte.id_usuarios_locacion = @idLoc and usuarios_ctacte.borrado = 0 " +
                        "group by usuarios_ctacte.id " +
                        "order by usuarios_ctacte.fecha_desde");
                    oCon.AsignarParametroEntero("@id", idUsuario);
                    oCon.AsignarParametroEntero("@idLoc", idLocacion);
                }
                else if (idLocacion == 0)
                {
                    oCon.CrearComando("select  usuarios_ctacte_recibos.id as Id_Usu_rec, usuarios_ctacte_recibos.borrado as recibo_borrado,usuarios_ctacte.fecha_movimiento,usuarios_ctacte.descripcion,usuarios_ctacte.fecha_desde, usuarios_ctacte.fecha_hasta, " +
                        "usuarios_ctacte.numero, usuarios_ctacte.importe_original as importe_original, usuarios_ctacte.importe_punitorio as importe_punitorio, " +
                        "usuarios_ctacte.importe_bonificacion, usuarios_ctacte.importe_provincial as importe_provincial, usuarios_ctacte.importe_final as importe_final, usuarios_ctacte.importe_pago as importe_pago, " +
                        "usuarios_ctacte.importe_saldo as importe_saldo, usuarios_ctacte.importe_saldo as importe_saldo_comprobante, usuarios_ctacte.id, " +
                        "usuarios_ctacte.id_usuarios_locacion, usuarios_ctacte.id_comprobantes, 'f' as tipo, usuarios_ctacte.descripcion as relacion, " +
                        "usuarios_ctacte.id_comprobantes_tipo, usuarios_ctacte.id_usuarios_ctacte_recibos as id_recibos, usuarios_ctacte.id_iva_ventas, " +
                        "usuarios_ctacte.percepcion, usuarios_ctacte.id_comp_notadebito_asociada, " +
                        "usuarios_ctacte.dias_punitorio, sum(usuarios_ctacte_det.id_debito_asociado) as id_debito, usuarios_ctacte.rechazado, " +
                        "usuarios_ctacte.id_plan_recibo,usuarios_ctacte_recibos.numero_muestra as recibo, personalctacte.nombre as personalctacte, personalrecibo.nombre as personalrecibo " +
                        "from usuarios_ctacte " +
                        "left join usuarios_ctacte_det on usuarios_ctacte_det.id_usuarios_ctacte = usuarios_ctacte.id " +
                        "left join usuarios_ctacte_relacion on usuarios_ctacte_relacion.id_usuarios_ctacte = usuarios_ctacte.id " +
                        "left join usuarios_ctacte_recibos on usuarios_ctacte_relacion.id_usuarios_ctacte_recibos = usuarios_ctacte_recibos.id " +
                        "left join personal personalctacte on usuarios_ctacte.id_personal = personalctacte.id " +
                        "left join personal personalrecibo on usuarios_ctacte_recibos.id_personal = personalrecibo.id " +
                        "where usuarios_ctacte.id_usuarios = @id and usuarios_ctacte.borrado = 0 " +
                        "group by usuarios_ctacte.id " +
                        "order by usuarios_ctacte.fecha_desde");
                    oCon.AsignarParametroEntero("@id", idUsuario);
                }
                else
                {
                    oCon.CrearComando("SELECT personal.nombre as personal, usuarios_ctacte.descripcion,usuarios_ctacte.numero,usuarios_ctacte.fecha_movimiento,usuarios_ctacte.fecha_desde,usuarios_ctacte.fecha_hasta,sum(usuarios_ctacte_det.importe_original) as importe_original," +
                        " sum(usuarios_ctacte_det.importe_punitorio) as importe_punitorio," +
                        " sum(usuarios_ctacte_det.importe_bonificacion) as importe_bonificacion,sum(usuarios_ctacte_det.Importe_final) as Importe_final,sum(usuarios_ctacte_det.importe_pago) as importe_pago,sum(usuarios_ctacte_det.Importe_saldo) as importe_saldo," +
                        " sum(usuarios_ctacte_det.importe_saldo) as importe_saldo_comprobante ,usuarios_ctacte.id,usuarios_ctacte.id_usuarios_locacion," +
                        " usuarios_ctacte.id_comprobantes,'F' as tipo,usuarios_ctacte.descripcion as relacion,usuarios_ctacte.id_comprobantes_tipo,usuarios_ctacte.id_usuarios_ctacte_recibos as id_recibos, usuarios_ctacte.id_iva_ventas,sum(usuarios_ctacte_det.importe_provincial) as importe_provincial,usuarios_ctacte.percepcion,usuarios_ctacte.id_comp_notadebito_asociada, usuarios_ctacte.dias_punitorio,sum(usuarios_ctacte_det.id_debito_asociado) as id_debito,usuarios_ctacte.rechazado,usuarios_ctacte.id_plan_recibo  " +
                        " from usuarios_ctacte " +
                        " LEFT JOIN personal ON usuarios_ctacte.id_personal = personal.id" +
                        " LEFT JOIN usuarios_ctacte_det ON usuarios_ctacte_det.id_usuarios_ctacte = usuarios_ctacte.id" +
                        " where id_usuarios_locacion = @idLoc and usuarios_ctacte.borrado=0 group by id_comprobantes ORDER BY usuarios_ctacte.Fecha_Desde");
                    oCon.AsignarParametroEntero("@idLoc", idLocacion);
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

        public DataTable ListarCtaCteCompletaNuevo2(Int32 idUsuario)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("select usuarios_ctacte_relacion.id_usuarios_ctacte,usuarios_ctacte_relacion.id as id_Ctacte_relacion,Id_Usuarios_ctacte_recibos,"
                    + " sum(importe_imputa)as importeImputa,personal.nombre as personal, usuarios_ctacte_recibos.Numero_muestra,usuarios_ctacte_recibos.fecha_movimiento,usuarios_ctacte_recibos.id_comprobantes,"
                    + " usuarios_ctacte_recibos.importe_recibo, usuarios_ctacte_recibos.cuenta,usuarios_ctacte_recibos.Numero"
                    + " from usuarios_ctacte_relacion"
                    + " left join usuarios_ctacte_recibos on usuarios_ctacte_recibos.id = usuarios_ctacte_relacion.Id_Usuarios_ctacte_recibos"
                    + " left join personal on usuarios_ctacte_recibos.id_personal = personal.id"
                    + " where usuarios_ctacte_relacion.id_usuarios_ctacte = @idusuario and usuarios_ctacte_recibos.borrado=0"
                    + " group by Id_Usuarios_ctacte_recibos");
                oCon.AsignarParametroEntero("@idusuario", idUsuario);

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

        public DataTable GetCtaCteCompleta(Int32 idUsuario)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT *  " +
                    "FROM usuarios_ctacte " +
                    "LEFT JOIN usuarios ON usuarios_ctacte.Id_Usuarios = usuarios.id " +
                    "WHERE usuarios_ctacte.borrado = 0 AND usuarios.borrado = 0 AND usuarios_ctacte.id_usuarios = @idusuario; ");
                oCon.AsignarParametroEntero("@idusuario", idUsuario);

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


        public void SetFacturaElectronica(int idComprobantes, int idComprobantestipo, string descripcion, int idCtaCte, int idIvaVentas)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("UPDATE usuarios_ctacte SET Id_Comprobantes = @id, Fecha_Movimiento = NOW(),id_comprobantes_tipo=@idtipo, Descripcion = @descrip, id_iva_ventas=@id_iva_ventas,id_personal=@personal WHERE id = @ctacte");
                oCon.AsignarParametroEntero("@id", idComprobantes);
                oCon.AsignarParametroCadena("@descrip", descripcion);
                oCon.AsignarParametroEntero("@ctacte", idCtaCte);
                oCon.AsignarParametroEntero("@idtipo", idComprobantestipo);
                oCon.AsignarParametroEntero("@id_iva_ventas", idIvaVentas);
                oCon.AsignarParametroEntero("@personal", Personal.Id_Login);
                oCon.EjecutarComando();


                oCon.DesConectar();
            }
            catch { }
        }

        public void SetFacturaElectronica(int idComprobantes, int idComprobantestipo, string descripcion, int idCtaCte, int idIvaVentas, decimal porcentajePercepcion = -1)
        {
            try
            {
                oCon.Conectar();
                string updatePorcentaje = "";
                if (porcentajePercepcion > -1)
                {
                    updatePorcentaje = ",porcentaje_percepcion = @porcentaje_percepcion";
                }

                oCon.CrearComando($"UPDATE usuarios_ctacte SET Id_Comprobantes = @id, Fecha_Movimiento = NOW(),id_comprobantes_tipo=@idtipo, Descripcion = @descrip, id_iva_ventas=@id_iva_ventas {updatePorcentaje}, id_personal=@personal WHERE id = @ctacte");
                oCon.AsignarParametroEntero("@id", idComprobantes);
                oCon.AsignarParametroCadena("@descrip", descripcion);
                oCon.AsignarParametroEntero("@ctacte", idCtaCte);
                oCon.AsignarParametroEntero("@idtipo", idComprobantestipo);
                oCon.AsignarParametroEntero("@id_iva_ventas", idIvaVentas);
                if (porcentajePercepcion > -1)
                    oCon.AsignarParametroDecimal("@porcentaje_percepcion", porcentajePercepcion);
                oCon.AsignarParametroEntero("@personal", Personal.Id_Login);

                oCon.EjecutarComando();


                oCon.DesConectar();
            }
            catch (Exception ex) { throw ex; }
        }

        public DataTable ListarMovimiento(int idUsuariosCtaCte, int idUsuariosServicios, int idUsuariosCtaCteDet, int idMovimiento, DateTime fechaDesde, DateTime fechaHasta, FECHA_CONSULTA_MOVIMIENTOS_CTACTE fechaConsulta)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                if (idUsuariosCtaCte > 0 && idUsuariosServicios == 0)
                    oCon.CrearComando(String.Format("SELECT usuarios_ctacte_det.Id,usuarios_ctacte_det.Id_Usuarios_CtaCte,usuarios_ctacte_det.Id_Usuarios_Locaciones,"
                    + " usuarios_ctacte_det.Id_Zonas, usuarios_ctacte_det.id_servicios, usuarios_ctacte_det.Id_Tipo, usuarios_ctacte_det.Tipo,"
                    + " usuarios_ctacte_det.Importe_Original, usuarios_ctacte_det.Importe_Punitorio, usuarios_ctacte_det.Importe_Saldo,"
                    + " usuarios_ctacte_det.Importe_Bonificacion, usuarios_ctacte_det.Id_Usuarios_Servicios, usuarios_ctacte_det.Importe_Pago,"
                    + " usuarios_ctacte_det.Id_Velocidades, usuarios_ctacte_det.Id_Velocidades_Tip, usuarios_ctacte_det.Requiere_IP,"
                    + " usuarios_ctacte_det.Borrado, usuarios_ctacte_det.Cantidad_periodos, usuarios_ctacte_det.id_usuarios_servicios_sub,"
                    + " usuarios_ctacte_det.Importe_Provincial, usuarios_ctacte_det.Fecha_Desde, usuarios_ctacte_det.Fecha_Hasta, usuarios_ctacte_det.Periodo_Mes,"
                    + " usuarios_ctacte_det.Periodo_Ano, usuarios_ctacte_det.id_bonificacion_aplicada, usuarios_ctacte_det.nombre_bonificacion,"
                    + " usuarios_ctacte_det.porcentaje_bonificacion, usuarios_ctacte_det.id_bonificacion, usuarios_ctacte_det.Detalles,"
                    + " usuarios_ctacte_det.idTipoRegistroCtaCteDet, usuarios_ctacte_det.Importe_ajuste_manual, usuarios_ctacte_det.Id_Iva_Alicuotas,"
                    + " usuarios_ctacte_det.id_debito_asociado, usuarios_ctacte_det.mes_presentacion, usuarios_ctacte_det.ano_presentacion,"
                    + " usuarios_servicios.Id_Tipo_Facturacion"
                    + " from usuarios_ctacte_det"
                    + " left JOIN usuarios_servicios ON usuarios_servicios.id=usuarios_ctacte_det.id_usuarios_servicios"
                    + " where usuarios_ctacte_det.Id_Usuarios_CtaCte={0} AND usuarios_ctacte_det.borrado = 0", idUsuariosCtaCte));
                else if (idUsuariosCtaCte > 0 && idUsuariosServicios > 0 && idUsuariosCtaCteDet == 0)
                    oCon.CrearComando(String.Format("SELECT sum(importe_original) as importe_original, sum(importe_saldo) as importe_saldo, servicio as nombre, numero_descripcion, min(fecha_desde) as fecha_desde, max(fecha_hasta) as fecha_hasta, id_usuarios_ctacte, id_comprobantes, id_usuarios_servicios  from vw_ventas_cobros where id_usuarios_ctacte={0} and id_usuarios_servicios={1} and tipo_movimiento='v'", idUsuariosCtaCte, idUsuariosServicios));
                else if (idUsuariosCtaCteDet > 0)
                    oCon.CrearComando(String.Format("SELECT /*MAX_EXECUTION_TIME(1000)*/ * from vw_ventas_cobros where id={0} and tipo_movimiento='v'", idUsuariosCtaCteDet));
                else
                {
                    if (fechaConsulta == FECHA_CONSULTA_MOVIMIENTOS_CTACTE.FECHA_DESDE)
                    {
                        if (idMovimiento == Convert.ToInt32(TIPO_MOVIMIENTO.VENTAS))
                            oCon.CrearComando(String.Format("SELECT * from vw_ventas_cobros where tipo_movimiento='v' and date(fecha_desde)>='{0}' and date(fecha_desde)<='{1}'", fechaDesde.Date.ToString("yyyy-MM-dd"), fechaHasta.Date.ToString("yyyy-MM-dd")));
                        else if (idMovimiento == Convert.ToInt32(TIPO_MOVIMIENTO.COBROS))
                            oCon.CrearComando(String.Format("SELECT * from vw_ventas_cobros where tipo_movimiento='c' and date(fecha_movimiento)>='{0}' and date(fecha_movimiento)<='{1}'", fechaDesde.Date.ToString("yyyy-MM-dd"), fechaHasta.Date.ToString("yyyy-MM-dd")));
                        else if (idMovimiento == Convert.ToInt32(TIPO_MOVIMIENTO.TODOS))
                            oCon.CrearComando(String.Format("SELECT * from vw_ventas_cobros where date(fecha_desde)>='{0}' and date(fecha_desde)<='{1}'", fechaDesde.Date.ToString("yyyy-MM-dd"), fechaHasta.Date.ToString("yyyy-MM-dd")));
                    }
                    else
                    {
                        if (idMovimiento == Convert.ToInt32(TIPO_MOVIMIENTO.VENTAS))
                            oCon.CrearComando(String.Format("SELECT * from vw_ventas_cobros where tipo_movimiento='v' and date(fecha_movimiento)>='{0}' and date(fecha_movimiento)<='{1}'", fechaDesde.Date.ToString("yyyy-MM-dd"), fechaHasta.Date.ToString("yyyy-MM-dd")));
                        else if (idMovimiento == Convert.ToInt32(TIPO_MOVIMIENTO.COBROS))
                            oCon.CrearComando(String.Format("SELECT * from vw_ventas_cobros where tipo_movimiento='c' and date(fecha_movimiento)>='{0}' and date(fecha_movimiento)<='{1}'", fechaDesde.Date.ToString("yyyy-MM-dd"), fechaHasta.Date.ToString("yyyy-MM-dd")));
                        else if (idMovimiento == Convert.ToInt32(TIPO_MOVIMIENTO.TODOS))
                            oCon.CrearComando(String.Format("SELECT * from vw_ventas_cobros where date(fecha_movimiento)>='{0}' and date(fecha_movimiento)<='{1}'", fechaDesde.Date.ToString("yyyy-MM-dd"), fechaHasta.Date.ToString("yyyy-MM-dd")));
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

        public DataTable ListarMovimiento(int idUsuariosCtaCte, int idUsuariosServicios, int idUsuariosCtaCteDet)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                if (idUsuariosCtaCte > 0 && idUsuariosServicios == 0)
                    oCon.CrearComando(String.Format("SELECT * from vw_ventas_cobros where id_usuarios_ctacte={0} and tipo_movimiento='v'", idUsuariosCtaCte));
                else if (idUsuariosCtaCte > 0 && idUsuariosServicios > 0 && idUsuariosCtaCteDet == 0)
                    oCon.CrearComando(String.Format("SELECT sum(importe_original) as importe_original, sum(importe_saldo) as importe_saldo, servicio as nombre, numero_descripcion, min(fecha_desde) as fecha_desde, max(fecha_hasta) as fecha_hasta, id_usuarios_ctacte, id_comprobantes, id_usuarios_servicios  from vw_ventas_cobros where id_usuarios_ctacte={0} and id_usuarios_servicios={1} and tipo_movimiento='v'", idUsuariosCtaCte, idUsuariosServicios));
                else if (idUsuariosCtaCteDet > 0)
                    oCon.CrearComando(String.Format("SELECT * from vw_ventas_cobros where id={0} and tipo_movimiento='v'", idUsuariosCtaCteDet));

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

        public DataTable GenerarDtDatosCtaCteAjustes()
        {
            DataTable DtDatosCtaCte = new DataTable();

            DataColumn DcIdTipoRegistro = new DataColumn("idTipoRegistro", typeof(decimal));
            DcIdTipoRegistro.DefaultValue = 0;
            DtDatosCtaCte.Columns.Add(DcIdTipoRegistro);

            DataColumn DcIdUsuariosCtaCte = new DataColumn("idUsuariosCtaCte", typeof(decimal));
            DcIdUsuariosCtaCte.DefaultValue = 0;
            DtDatosCtaCte.Columns.Add(DcIdUsuariosCtaCte);

            DataColumn DcIdUsuariosServicios = new DataColumn("idUsuariosServicios", typeof(decimal));
            DcIdUsuariosServicios.DefaultValue = 0;
            DtDatosCtaCte.Columns.Add(DcIdUsuariosServicios);

            DataColumn DcIdUsuariosCtaCteDet = new DataColumn("idUsuariosCtaCteDet", typeof(decimal));
            DcIdUsuariosCtaCteDet.DefaultValue = 0;
            DtDatosCtaCte.Columns.Add(DcIdUsuariosCtaCteDet);

            DataColumn DcIdUsuarios = new DataColumn("idUsuarios", typeof(decimal));
            DcIdUsuarios.DefaultValue = 0;
            DtDatosCtaCte.Columns.Add(DcIdUsuarios);

            DataColumn DcPresentaVentas = new DataColumn("presenta_ventas", typeof(int));
            DcPresentaVentas.DefaultValue = 0;
            DtDatosCtaCte.Columns.Add(DcPresentaVentas);

            return DtDatosCtaCte;
        }

        public void ConvertirComprobante(int idComprobantestipo, string descripcion, int idCtaCte, bool modificaPercepcion = true)
        {
            try
            {
                oCon.Conectar();

                if (modificaPercepcion)
                {
                    oCon.CrearComando("UPDATE usuarios_ctacte SET Id_Comprobantes = id_comprobantes_ref, Fecha_Movimiento = NOW(),id_comprobantes_tipo=@idtipo, Descripcion = @descrip, id_iva_ventas=@id_iva_ventas,importe_provincial=@Impuesto_Provincial,importe_final=importe_original+importe_punitorio-importe_bonificacion,importe_saldo=importe_final, percepcion=@Percepcion,id_personal=@personal WHERE id = @ctacte");
                    oCon.AsignarParametroEntero("@Impuesto_Provincial", 0);
                    oCon.AsignarParametroEntero("@Percepcion", Convert.ToInt32(Usuarios_CtaCte.PERCEPCIONES.CALCULA));
                }
                else
                {
                    oCon.CrearComando("UPDATE usuarios_ctacte SET Id_Comprobantes = id_comprobantes_ref, Fecha_Movimiento = NOW(),id_comprobantes_tipo=@idtipo, Descripcion = @descrip, id_iva_ventas=@id_iva_ventas,importe_final=importe_original+importe_punitorio-importe_bonificacion,importe_saldo=importe_final, percepcion=@Percepcion,id_personal=@personal WHERE id = @ctacte");
                    oCon.AsignarParametroEntero("@Percepcion", Convert.ToInt32(Usuarios_CtaCte.PERCEPCIONES.NO_CALCULA));
                }
                oCon.AsignarParametroEntero("@idtipo", idComprobantestipo);
                oCon.AsignarParametroCadena("@descrip", descripcion);
                oCon.AsignarParametroEntero("@id_iva_ventas", 0);
                oCon.AsignarParametroEntero("@ctacte", idCtaCte);
                oCon.AsignarParametroEntero("@personal", Personal.Id_Login);
                oCon.EjecutarComando();

                if (modificaPercepcion)
                {
                    oCon.CrearComando("UPDATE usuarios_ctacte_det SET importe_provincial = @Impuesto_Provincial, importe_saldo = importe_original + importe_punitorio - importe_bonificacion,id_personal=@personal WHERE id_usuarios_ctacte = @ctacte");
                    oCon.AsignarParametroEntero("@Impuesto_Provincial", 0);
                }
                else
                    oCon.CrearComando("UPDATE usuarios_ctacte_det SET importe_saldo=importe_original+importe_punitorio-importe_bonificacion,id_personal=@personal WHERE id_usuarios_ctacte = @ctacte");
                oCon.AsignarParametroEntero("@personal", Personal.Id_Login);
                oCon.AsignarParametroEntero("@ctacte", idCtaCte);
                oCon.EjecutarComando();

                oCon.DesConectar();
            }
            catch(Exception c)
            {
                string error = c.ToString();
                oCon.DesConectar();
            
            }
        }

        public Int32 ActualizarRechazoDebito(int id, int rechazado,int idPresentacion)
        {
            //rechazao=1;
            //noRechazado=0;
            try
            {
                oCon.Conectar();
                oCon.CrearComando("update usuarios_ctacte set rechazado=@rechazo,id_personal=@personal where id=@id");
                oCon.AsignarParametroEntero("@rechazo", rechazado);
                oCon.AsignarParametroEntero("@personal", Personal.Id_Login);
                oCon.AsignarParametroEntero("@id", id);
                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();
                if (rechazado == 1)
                    oCon.CrearComando("update presentacion_debitos set cant_plasticos_rechazados=cant_plasticos_rechazados+1 where id =@presentacion");
                else
                    oCon.CrearComando("update presentacion_debitos set cant_plasticos_rechazados=cant_plasticos_rechazados-1 where id =@presentacion");

                oCon.AsignarParametroEntero("@presentacion", idPresentacion);
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

        public DataTable ListarDebeHaber(int idUsuario, int idLocacion)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("select usuarios_ctacte.Fecha_Movimiento,usuarios_ctacte.Descripcion,sum(usuarios_ctacte.Importe_Final) AS debe,0 AS haber,usuarios_ctacte.Importe_Saldo AS saldo"
                    + " from usuarios_ctacte"
                    + " where usuarios_ctacte.id_usuarios = @idusuario AND usuarios_ctacte.Id_Usuarios_Locacion = @idlocacion AND usuarios_ctacte.Borrado = 0 GROUP BY usuarios_ctacte.Id_Comprobantes"
                    + " UNION"
                    + " SELECT usuarios_ctacte_recibos.Fecha_movimiento, usuarios_ctacte_recibos.Numero_Muestra, 0 as debe, sum(usuarios_ctacte_recibos.Importe_Recibo),0 AS saldo  FROM  usuarios_ctacte_recibos "
                    + " WHERE usuarios_ctacte_recibos.Id_Usuarios = @idusuario2 AND usuarios_ctacte_recibos.Id_Usuarios_Locaciones = @idlocacion2 GROUP BY usuarios_ctacte_recibos.Id_Comprobantes"
                    + " ORDER BY Fecha_Movimiento asc");
                oCon.AsignarParametroEntero("@idusuario", idUsuario);
                oCon.AsignarParametroEntero("@idlocacion", idLocacion);
                oCon.AsignarParametroEntero("@idusuario2", idUsuario);
                oCon.AsignarParametroEntero("@idlocacion2", idLocacion);
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
            }
            return dt;
        }

        public DataTable ListarArrastreDeudas(int mes, int anio)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("call spAnalisisDeuda(@Mes,@Anio)");
                oCon.AsignarParametroEntero("@Mes", mes);
                oCon.AsignarParametroEntero("@Anio", anio);
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
            }
            return dt;
        }

        public int Eliminar(int id, string detalle)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("update usuarios_ctacte set borrado=1,descripcion=@des,id_personal=@personal where id=@idctacte");
                oCon.AsignarParametroEntero("@idctacte", id);
                oCon.AsignarParametroEntero("@personal", Personal.Id_Login);
                oCon.AsignarParametroCadena("@des", detalle);
                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
                return 0;
            }
            catch (Exception c)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                return -1;
            }
        }

        public DataTable getCtaCte(int id_usuario)
        {
            DataTable dt = new DataTable();
            oCon.Conectar();
            oCon.CrearComando("SELECT IFNULL(usuarios_ctacte_relacion.Id,0) AS idRelacion,IFNULL(usuarios_ctacte_relacion.Id_Usuarios_ctacte_recibos,0) AS idRecibo, IFNULL(usuarios_ctacte_relacion.Id_Usuarios_ctacte,0) AS idCtacte,  " +
                "usuarios_ctacte.Fecha_Movimiento AS Fecha , usuarios_ctacte.Descripcion AS Factura, usuarios_ctacte.Borrado AS BorradoCtacte, IFNULL(usuarios_ctacte_relacion.Borrado, 0) AS BorradoRelacion, " +
                "IFNULL(usuarios_ctacte_relacion.Id_Usuarios_ctacte_recibos, 0) AS id_Usu_ctacte_recibos, " +
                "usuarios_ctacte.Importe_Original + usuarios_ctacte.Importe_Punitorio + usuarios_ctacte.Importe_Provincial - usuarios_ctacte.Importe_Bonificacion AS Importe, IFNULL(usuarios_ctacte_relacion.nuevo, 0) AS CACNuevo, CONCAT(usuarios_ctacte.Fecha_Desde, ' - ',usuarios_ctacte.Fecha_Hasta) AS Periodo ," +
                "usuarios_ctacte.Id_comprobantes_tipo AS comptipo, " +
                "usuarios_ctacte.Importe_Original + usuarios_ctacte.Importe_Punitorio + usuarios_ctacte.Importe_Provincial - usuarios_ctacte.Importe_Bonificacion AS Total, usuarios_ctacte.Importe_Pago AS PagoCtaCte " +
                "FROM usuarios_ctacte " +
                "LEFT JOIN usuarios_ctacte_relacion ON usuarios_ctacte_relacion.Id_Usuarios_ctacte = usuarios_ctacte.id " +
                "WHERE usuarios_ctacte.borrado = 0  AND usuarios_ctacte.Id_Usuarios = @idUSu " +
                "group by idRecibo, idCtaCte ORDER BY usuarios_ctacte.Id_comprobantes_tipo ");
            oCon.AsignarParametroEntero("@idUsu", id_usuario);
            dt = oCon.Tabla();
            oCon.DesConectar();

            return dt;

        }

        public DataTable getCtaCte_Recibos(int id_usuario)
        {
            DataTable dt = new DataTable();
            oCon.Conectar();
            oCon.CrearComando("SELECT usuarios_ctacte_relacion.Id AS idRelacion,usuarios_ctacte_relacion.Id_Usuarios_ctacte_recibos AS idRecibo, usuarios_ctacte_relacion.Id_Usuarios_ctacte AS idCtacte,  " +
                "usuarios_ctacte_recibos.Fecha_movimiento AS Fecha , usuarios_ctacte_recibos.Numero_Muestra AS Recibo, " +
                "usuarios_ctacte_recibos.Borrado AS BorradoCtacteRecibos, usuarios_ctacte_relacion.Borrado AS BorradoRelacion, " +
                "usuarios_ctacte_recibos.Id_Usuarios_Locaciones AS Id_Locacion, " +
                "usuarios_ctacte_recibos.Importe_Recibo AS Pago, 1 As EsRecibo " +
                "FROM usuarios_ctacte_recibos " +
                "LEFT JOIN usuarios_ctacte_relacion ON usuarios_ctacte_relacion.Id_Usuarios_ctacte_recibos = usuarios_ctacte_recibos.id " +
                "WHERE usuarios_ctacte_recibos.Id_Usuarios = @idUsu AND usuarios_ctacte_recibos.borrado = 0 " +
                "GROUP BY idRecibo ");
            oCon.AsignarParametroEntero("@idUsu", id_usuario);
            dt = oCon.Tabla();
            oCon.DesConectar();

            return dt;

        }

        public DataTable getCtaCte_SinRecibos(int id_usuario)
        {
            DataTable dt = new DataTable();
            oCon.Conectar();
            oCon.CrearComando("SELECT IFNULL(usuarios_ctacte_relacion.Id,0) AS idRelacion,IFNULL(usuarios_ctacte_relacion.Id_Usuarios_ctacte_recibos,0) AS idRecibo, IFNULL(usuarios_ctacte_relacion.Id_Usuarios_ctacte,0) AS idCtacte,  " +
                "usuarios_ctacte.Fecha_Movimiento AS Fecha,usuarios_ctacte.Descripcion AS Factura, usuarios_ctacte.Borrado AS BorradoCtacte, IFNULL(usuarios_ctacte_relacion.Borrado, 0) AS BorradoRelacion, " +
                "IFNULL(usuarios_ctacte_relacion.Id_Usuarios_ctacte_recibos, 0) AS id_Usu_ctacte_recibos, " +
                "usuarios_ctacte.Importe_Original + usuarios_ctacte.Importe_Punitorio + usuarios_ctacte.Importe_Provincial - usuarios_ctacte.Importe_Bonificacion AS Importe, IFNULL(usuarios_ctacte_relacion.nuevo, 0) AS CACNuevo, CAST(CONCAT(usuarios_ctacte.Fecha_Desde, ' - ',usuarios_ctacte.Fecha_Hasta) AS char(100)) AS Periodo " +
                "FROM usuarios_ctacte " +
                "LEFT JOIN usuarios_ctacte_relacion ON usuarios_ctacte_relacion.Id_Usuarios_ctacte = usuarios_ctacte.id " +
                "WHERE usuarios_ctacte.borrado = 0 AND  usuarios_ctacte.Importe_Saldo>0 AND usuarios_ctacte.Id_Usuarios = @idUsu  ORDER BY usuarios_ctacte.Id_comprobantes_tipo  ");
            oCon.AsignarParametroEntero("@idUsu", id_usuario);
            dt = oCon.Tabla();
            oCon.DesConectar();

            return dt;

        }

        public bool esDebitoAutomatico(int id_ctacte)
        { 
            try
            {
                DataTable dt;
                oCon.Conectar();
                oCon.CrearComando("select id_origen from usuarios_ctacte where id = @idctacte");
                oCon.AsignarParametroEntero("@idctacte", id_ctacte);
                dt = oCon.Tabla();
                if(dt.Rows.Count == 0)
                {
                    oCon.DesConectar();
                    throw new Exception($"No existe el cuenta corriente {id_ctacte}");
                }

                Id_Origen = Convert.ToInt32(dt.Rows[0]);

                if(Id_Origen == Convert.ToInt32(ORIGEN.FACTURACION_MENSUAL_DEBITOS))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }
        }

        public DataTable get_Extras(DateTime Desde, DateTime Hasta)
        {
            DataTable dt = new DataTable();
            oCon.Conectar();
            oCon.CrearComando("SELECT SUM(usuarios_ctacte_det.Importe_Original) AS Extras " +
                "FROM usuarios_ctacte_det " +
                "LEFT JOIN usuarios_ctacte on usuarios_ctacte_det.Id_Usuarios_CtaCte = usuarios_ctacte.id " +
                "WHERE(usuarios_ctacte.fecha_movimiento >= @desde and usuarios_ctacte.fecha_movimiento <= @hasta) " +
                "and usuarios_ctacte.id_origen = 4 AND usuarios_ctacte.borrado = 0 AND usuarios_ctacte_det.Tipo = 's' " +
                "GROUP BY id_origen; ");
            oCon.AsignarParametroFecha("@desde", Desde);
            oCon.AsignarParametroFecha("@hasta", Hasta);
            dt = oCon.Tabla();
            oCon.DesConectar();

            return dt;

        }

        public DataTable Listar_Deudores_Enacom(DateTime Desde, int id_Grupo, DateTime Hasta)
        {
            DataTable dt = new DataTable();
            oCon.Conectar();

            /*oCon.CrearComando("select servicios_grupos.id AS id_grupo, servicios.id as id_serv, servicios_tipos.id as id_tipo, usuarios.id as id_usu , usuarios_ctacte.id as id_ctacte,  " +
                "usuarios.codigo as codusu, servicios.descripcion as servicio, concat(usuarios.apellido, ' , ', usuarios.nombre) as usuario, " +
                "usuarios_ctacte_det.fecha_desde as fecha_deuda, servicios_grupos.nombre as grupo, sum(usuarios_ctacte_det.importe_saldo) AS saldo " +
                "from usuarios_ctacte_det " +
                "inner JOIN usuarios_ctacte ON usuarios_ctacte_det.Id_Usuarios_CtaCte = usuarios_ctacte.id " +
                "inner join usuarios on usuarios_ctacte.id_usuarios = usuarios.id " +
                "INNER JOIN usuarios_servicios_sub ON usuarios_servicios_sub.id = usuarios_ctacte_det.id_usuarios_servicios_sub " +
                "inner join usuarios_servicios on usuarios_servicios.id = usuarios_servicios_sub.id_usuarios_servicios " +
                "inner join servicios on usuarios_servicios.id_servicios = servicios.id " +
                "inner join servicios_tipos ON usuarios_servicios.Id_Servicios_Tipo = servicios_tipos.id " +
                "inner join servicios_grupos ON servicios_tipos.id_servicios_grupos = servicios_grupos.id " +
                "where usuarios.borrado = 0 and usuarios_ctacte.borrado = 0 AND usuarios_ctacte_det.borrado = 0 and usuarios_ctacte.importe_saldo > 0 " +
                "AND(usuarios_ctacte_det.fecha_desde >= @fecha and usuarios_ctacte_det.Fecha_desde <= @fechaHasta) " +
                "and usuarios_servicios.id_servicios_estados = @Estado_Servicio " +
                "GROUP BY usuarios_ctacte.id, servicios_grupos.id " +
                "order by usuarios.codigo, servicios_grupos.id");*/

            oCon.CrearComando("select servicios_grupos.id as id_grupo, servicios.id as id_serv, servicios_tipos.id as id_tipo, usuarios.id as id_usu ,  " +
                "usuarios_ctacte.id as id_ctacte, usuarios.codigo as codusu, servicios.descripcion as servicio, usuarios.Numero_Documento AS Documento, " +
                "'DNI' as TipoDoc, concat(usuarios.apellido, ' , ', usuarios.nombre) as usuario, usuarios_ctacte_det.fecha_desde as fecha_deuda, servicios_grupos.nombre as grupo, " +
                "'ATCCO S.R.L' AS Empresa, 'FACTURA' AS Comp, sum(usuarios_ctacte_det.importe_saldo) as saldo, provincias.Nombre AS provincia, " +
                "usuarios_locaciones.Calle AS Calle, usuarios_locaciones.altura AS Altura, " +
                "localidades.Nombre AS Localidad, localidades.Codigo_Postal AS Cod_Postal " +
                "from usuarios_ctacte_det " +
                "inner join usuarios_ctacte on usuarios_ctacte_det.id_usuarios_ctacte = usuarios_ctacte.id " +
                "inner join usuarios on usuarios_ctacte.id_usuarios = usuarios.id " +
                "inner join usuarios_servicios_sub on usuarios_servicios_sub.id = usuarios_ctacte_det.id_usuarios_servicios_sub " +
                "inner join usuarios_servicios on usuarios_servicios.id = usuarios_servicios_sub.id_usuarios_servicios " +
                "inner join servicios on usuarios_servicios.id_servicios = servicios.id " +
                "inner join servicios_tipos on usuarios_servicios.id_servicios_tipo = servicios_tipos.id " +
                "inner join servicios_grupos on servicios_tipos.id_servicios_grupos = servicios_grupos.id " +
                "LEFT JOIN usuarios_locaciones ON usuarios_ctacte.Id_Usuarios_Locacion = usuarios_locaciones.id " +
                "LEFT JOIN localidades ON usuarios_locaciones.Id_Localidades = localidades.id " +
                "LEFT JOIN provincias ON usuarios_locaciones.Id_Provincias = provincias.id " +
                "where usuarios.borrado = 0 and usuarios_ctacte.borrado = 0 and usuarios_ctacte_det.borrado = 0 and usuarios_ctacte.importe_saldo > 0 " +
                "and(usuarios_ctacte_det.fecha_desde >= @fecha and usuarios_ctacte_det.fecha_desde <= @fechaHasta) " +
                "and usuarios_servicios.id_servicios_estados = @Estado_Servicio and usuarios_ctacte.id_comprobantes_tipo = 7 and usuarios_servicios.borrado=0 " +
                "group by usuarios_ctacte.id, servicios_grupos.id " +
                "order by usuarios.codigo, servicios_grupos.id, usuarios_ctacte_det.Fecha_Desde ");


            oCon.AsignarParametroFecha("@fecha", Desde);
            oCon.AsignarParametroFecha("@fechaHasta", Hasta);
            oCon.AsignarParametroEntero("@Estado_Servicio", (int)Servicios.Servicios_Estados.CONECTADO);
            dt = oCon.Tabla();
            oCon.DesConectar();
            return dt;
        }

        public DataTable Listar_Factura_Iva_Ventas(int id_comprobante)
        {
            DataTable dt = new DataTable();
            oCon.Conectar();
            oCon.CrearComando("SELECT iva_Ventas.id AS id_iva_venta, id_comprobantes AS id_comprobante, punto_venta AS Punto_Venta, " +
                "Numero AS Numero_Comprobante, iva_ventas.Letra, id_comprobantes_iva, id_comprobantes_Tipo, " +
                "Concat(comprobantes_tipo.Nombre, ' - ', comprobantes_tipo.Letra) AS Factura, codigo_afip " +
                "FROM iva_ventas " +
                "LEFT JOIN comprobantes_tipo ON iva_ventas.Id_comprobantes_tipo = comprobantes_tipo.id " +
                "WHERE iva_ventas.Borrado = 0 AND id_comprobantes = @id_comp; ");
            oCon.AsignarParametroEntero("@id_comp", id_comprobante);
            dt = oCon.Tabla();
            oCon.DesConectar();

            return dt;

        }

        public bool ActualizarIdNotaDebitoEnCtacte(DataTable dtNotaDeDebito)
        {
            if (dtNotaDeDebito.Rows.Count == 0)
                return false;
            try
            {
                oCon.Conectar();
                string consulta = "UPDATE usuarios_ctacte SET id_comp_notadebito_asociada = @idNotaDebitoComprobante, id_personal=@personal WHERE id = @idCtacte";
                foreach (DataRow row in dtNotaDeDebito.Rows)
                {
                    oCon.ComenzarTransaccion();
                    oCon.CrearComando(consulta);
                    oCon.AsignarParametroEntero("@idCtacte", Convert.ToInt32(row["idCtacte"]));
                    oCon.AsignarParametroEntero("@idNotaDebitoComprobante", Convert.ToInt32(row["idNotaDebitoComprobante"]));
                    oCon.AsignarParametroEntero("@personal", Personal.Id_Login);
                    oCon.EjecutarComando();
                    oCon.ConfirmarTransaccion();
                }
                oCon.DesConectar();
                return true;
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                return false;
            }
        }

        public DataTable ListarDatosCtaCte(int idCtaCte)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("select * from usuarios_ctacte where id=@id");
                oCon.AsignarParametroEntero("@id", idCtaCte);
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
            }
            return dt;
        }
    
        public DataTable ListarDatosNotaDebito(int idCtaCte)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("select usuarios_ctacte.id_comprobantes, usuarios_ctacte.id_comp_notadebito_asociada,comprobantes.punto_venta,comprobantes.numero,comprobantes.id_comprobantes_tipo as tipo " +
                    "from usuarios_ctacte " +
                    "left join comprobantes on comprobantes.id=usuarios_ctacte.id_comp_notadebito_asociada WHERE usuarios_ctacte.id=@idctacte and id_comp_notadebito_asociada != 0");
                oCon.AsignarParametroEntero("@idctacte", idCtaCte);
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

        public int CambiarComprobanteEIvaVentasDeCtacte(int idUsuarioCtacte, int idComprobante, string descripcion, int idCompTipo, int idIvaVentas)
        {
            int result = 0;
            try
            {
                oCon.Conectar();
                string comando = "UPDATE usuarios_ctacte SET Id_Comprobantes = @idComp, Descripcion = @desc, id_comprobantes_tipo = @idCompTipo, id_iva_ventas = @idIvaVentas,id_personal=@personal WHERE id = @idUsCtacte";
                oCon.CrearComando(comando);
                oCon.AsignarParametroEntero("@idComp", idComprobante);
                oCon.AsignarParametroCadena("@desc", descripcion);
                oCon.AsignarParametroEntero("@idCompTipo", idCompTipo);
                oCon.AsignarParametroEntero("@idIvaVentas", idIvaVentas);
                oCon.AsignarParametroEntero("@idUsCtacte", idUsuarioCtacte);
                oCon.AsignarParametroEntero("@personal", Personal.Id_Login);
                oCon.EjecutarComando();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                result = 1;
                oCon.DesConectar();
                throw;
            }
            return result;
        }

        public DataTable ListarFacturasSinRecibos(int id_TipoComprobante)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                if (id_TipoComprobante == (int)Comprobantes_Tipo.Tipo.FACTURA_A)
                {
                    oCon.CrearComando("SELECT usuarios_ctacte.id_Comprobantes as id_comprobante,usuarios_ctacte.id_usuarios_locacion as id_locacion,usuarios_ctacte.id_usuarios as Id_Usu,usuarios_ctacte.id AS Id_Ctacte, ifnull(usuarios_ctacte_recibos.id,0) AS id_Recibo, " +
                                          "usuarios_ctacte_relacion.id AS Id_relacion, usuarios_ctacte_relacion.Id_Usuarios_ctacte_recibos AS Id_Relacion_recibos, " +
                                          "usuarios_ctacte_relacion.Id_Usuarios_ctacte AS Id_Relacion_ctacte, usuarios_ctacte.Fecha_Desde as Desde, usuarios_ctacte.Fecha_hasta as Hasta, " +
                                          "usuarios_ctacte.Descripcion AS Comprobante,usuarios_ctacte.Importe_Original AS Original, usuarios_ctacte.Importe_Final AS Final, " +
                                          "ifnull(usuarios_ctacte_recibos.Numero_Muestra, 0) AS Recibo, usuarios_ctacte_recibos.Importe_Recibo AS Importe_Recibo, usuarios_ctacte.borrado as Borrado_Ctacte " +
                                          "FROM usuarios_ctacte " +
                                          "LEFT JOIN usuarios_ctacte_relacion ON usuarios_ctacte_relacion.Id_Usuarios_ctacte = usuarios_ctacte.id " +
                                          "LEFT JOIN usuarios_ctacte_recibos ON usuarios_ctacte_relacion.Id_Usuarios_ctacte_recibos = usuarios_ctacte_recibos.id " +
                                          "WHERE usuarios_Ctacte.Importe_Saldo = 0 AND(usuarios_Ctacte.id_comprobantes_tipo = @idCompTipo) " +
                                          "GROUP BY usuarios_ctacte.id " +
                                          "ORDER BY usuarios_ctacte.id_usuarios;");
                    oCon.AsignarParametroEntero("@idCompTipo", id_TipoComprobante);
                    dt = oCon.Tabla();
                }
                else
                {
                    oCon.CrearComando("SELECT usuarios_ctacte.id_Comprobantes as id_comprobante, usuarios_ctacte.id_usuarios_locacion as id_locacion, usuarios_ctacte.id_usuarios as Id_Usu,usuarios_ctacte.id AS Id_Ctacte, ifnull(usuarios_ctacte_recibos.id,0) AS id_Recibo, " +
                       "usuarios_ctacte_relacion.id AS Id_relacion, usuarios_ctacte_relacion.Id_Usuarios_ctacte_recibos AS Id_Relacion_recibos, " +
                       "usuarios_ctacte_relacion.Id_Usuarios_ctacte AS Id_Relacion_ctacte,usuarios_ctacte.Fecha_Desde as Desde, usuarios_ctacte.Fecha_hasta as Hasta, " +
                       "usuarios_ctacte.Descripcion AS Comprobante,usuarios_ctacte.Importe_Original AS Original, usuarios_ctacte.Importe_Final AS Final, " +
                       "ifnull(usuarios_ctacte_recibos.Numero_Muestra, 0) AS Recibo, usuarios_ctacte_recibos.Importe_Recibo AS Importe_Recibo, usuarios_ctacte.borrado as Borrado_Ctacte " +
                       "FROM usuarios_ctacte " +
                       "LEFT JOIN usuarios_ctacte_relacion ON usuarios_ctacte_relacion.Id_Usuarios_ctacte = usuarios_ctacte.id " +
                       "LEFT JOIN usuarios_ctacte_recibos ON usuarios_ctacte_relacion.Id_Usuarios_ctacte_recibos = usuarios_ctacte_recibos.id " +
                       "WHERE usuarios_Ctacte.Importe_Saldo = 0 AND(usuarios_Ctacte.id_comprobantes_tipo = @idCompTipo) " +
                       "GROUP BY usuarios_ctacte.id " +
                       "ORDER BY usuarios_ctacte.id_usuarios;");
                    oCon.AsignarParametroEntero("@idCompTipo", id_TipoComprobante);
                    dt = oCon.Tabla();
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

        public void ActualizarCtaCte_FacturaSinRecibo(int id_Ctacte)
        {
            try
            {
                oCon.Conectar();
                string comando = "UPDATE usuarios_ctacte SET importe_saldo = 0 , importe_pago = importe_final,id_personal=@personal WHERE id = @id";
                oCon.CrearComando(comando);
                oCon.AsignarParametroEntero("@id", id_Ctacte);
                oCon.AsignarParametroEntero("@personal", Personal.Id_Login);
                oCon.EjecutarComando();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }
        }

        public DataRow getDatosCtaCte(Int32 idComprobante, int idCtacte = 0)
        {
            DataTable dt = new DataTable();
            DataRow dr;

            try
            {
                oCon.Conectar();
                if(idCtacte == 0)
                    oCon.CrearComando(String.Format("SELECT * FROM usuarios_ctacte where id_comprobantes = {0} ", idComprobante));
                else
                    oCon.CrearComando(String.Format("SELECT * FROM usuarios_ctacte where id = {0} ", idCtacte));

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
                dr = dt.NewRow();
                dr["id"] = 0;
                dr["id_comprobantes_tipo"] = 0;
                dt.Rows.Add(dr);
                return dr;
            }
            else
            {
                return dt.Rows[0];
            }


        }

        public DataTable ListarDeudaDeUsuarioServicio(int idUsuarioServicio)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                string comando = "select * from usuarios_ctacte_det"
                                + " where id_usuarios_servicios = @idUsuarioServicio"
                                + " and borrado = 0 and importe_saldo > 0";
                oCon.CrearComando(comando);
                oCon.AsignarParametroEntero("@idUsuarioServicio", idUsuarioServicio);
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
            }
            return dt;
        }

        public DataTable ListarCuentaCorrienteOrigenes()
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                string comando = "SELECT * FROM usuarios_ctacte_origen";
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

        public Usuarios_CtaCte Get(int idCtacte)
        {
            Usuarios_CtaCte oCta = new Usuarios_CtaCte();
            Usuarios_CtaCte_Det oDet = new Usuarios_CtaCte_Det();
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT * FROM usuarios_ctacte WHERE id = @ctacte and borrado = 0");
                oCon.AsignarParametroEntero("@ctacte", idCtacte);
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception x)
            {
                oCon.DesConectar();

                throw;
            }
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    oCta = new Usuarios_CtaCte();
                    oCta.Id = Convert.ToInt32(item["id"]);
                    oCta.Id_Usuarios = Convert.ToInt32(item["Id_Usuarios"]);
                    oCta.Id_Comprobantes = Convert.ToInt32(item["Id_Comprobantes"]);
                    oCta.Fecha_Movimiento = Convert.ToDateTime(item["Fecha_Movimiento"]);
                    oCta.Fecha_Desde = Convert.ToDateTime(item["Fecha_Desde"]);
                    oCta.Fecha_Hasta = Convert.ToDateTime(item["Fecha_Hasta"]);
                    oCta.Descripcion = item["Descripcion"].ToString();
                    oCta.Importe_Original = Convert.ToDecimal(item["Importe_Original"]);
                    oCta.Importe_Punitorio = Convert.ToDecimal(item["Importe_Punitorio"]);
                    oCta.Importe_Bonificacion = Convert.ToDecimal(item["Importe_Bonificacion"]);
                    oCta.Importe_Final = Convert.ToDecimal(item["Importe_Final"]);
                    oCta.Importe_Saldo = Convert.ToDecimal(item["Importe_Saldo"]);
                    oCta.Id_Usuarios_Locacion = Convert.ToInt32(item["Id_Usuarios_Locacion"]);
                    oCta.Numero = item["Numero"].ToString();
                    oCta.Id_Comprobantes_Tipo = Convert.ToInt32(item["Id_comprobantes_tipo"]);
                    oCta.Id_Comprobantes_Ref = Convert.ToInt32(item["Id_comprobantes_ref"]);
                    oCta.Importe_Provincial = Convert.ToDecimal(item["Importe_Provincial"]);
                    oCta.Id_Facturacion = Convert.ToInt32(item["id_facturacion"]);
                    oCta.Generado_facturacion_mensual = Convert.ToInt32(item["generado_facturacion_mensual"]);
                    oCta.Id_Iva_Ventas = Convert.ToInt32(item["Id_Iva_Ventas"]);
                    oCta.Id_Personal = Convert.ToInt32(item["Id_Personal"]);
                    oCta.Id_Origen = Convert.ToInt32(item["id_origen"]);
                    oCta.Percepcion = Convert.ToInt32(item["percepcion"]);
                    oCta.Id_Ctacte_Recibo_Plan = Convert.ToInt32(item["id_plan_recibo"]);
                    oCta.Porcentaje_Percepcion = Convert.ToDecimal(item["porcentaje_percepcion"]);
                    oCta.UsuCtaCteDet = oDet.Get(oCta.Id);
                }
                return oCta;

            }
            else
                return null;
        }


        public List<Usuarios_CtaCte> Get(int idComprobante, int idUsuario, int idLocacion)
        {
            Usuarios_CtaCte oCta = new Usuarios_CtaCte();
            List<Usuarios_CtaCte> oCtaLista = new List<Usuarios_CtaCte>();
            Usuarios_CtaCte_Det oDet = new Usuarios_CtaCte_Det();
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                if (idUsuario == 0)
                {
                    oCon.CrearComando("SELECT * FROM usuarios_ctacte WHERE id_comprobantes = @compro and borrado = 0");
                    oCon.AsignarParametroEntero("@compro", idComprobante);
                }
                else if(idLocacion==0)
                {
                    oCon.CrearComando("SELECT * FROM usuarios_ctacte WHERE id_usuarios = @usuario and id_usuarios_locacion = @locacion and borrado = 0");
                    oCon.AsignarParametroEntero("@usuario", idUsuario);
                    oCon.AsignarParametroEntero("@locacion", idLocacion);
                }
                else
                {
                    oCon.CrearComando("SELECT * FROM usuarios_ctacte WHERE id_usuarios = @usuario and borrado = 0");
                    oCon.AsignarParametroEntero("@usuario", idUsuario);
                }

                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception x)
            {
                oCon.DesConectar();

                throw;
            }
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    oCta = new Usuarios_CtaCte();
                    oCta.Id = Convert.ToInt32(item["id"]);
                    oCta.Id_Usuarios = Convert.ToInt32(item["Id_Usuarios"]);
                    oCta.Id_Comprobantes = Convert.ToInt32(item["Id_Comprobantes"]);
                    oCta.Fecha_Movimiento = Convert.ToDateTime(item["Fecha_Movimiento"]);
                    oCta.Fecha_Desde = Convert.ToDateTime(item["Fecha_Desde"]);
                    oCta.Fecha_Hasta = Convert.ToDateTime(item["Fecha_Hasta"]);
                    oCta.Descripcion = item["Descripcion"].ToString();
                    oCta.Importe_Original = Convert.ToDecimal(item["Importe_Original"]);
                    oCta.Importe_Punitorio = Convert.ToDecimal(item["Importe_Punitorio"]);
                    oCta.Importe_Bonificacion = Convert.ToDecimal(item["Importe_Bonificacion"]);
                    oCta.Importe_Final = Convert.ToDecimal(item["Importe_Final"]);
                    oCta.Importe_Saldo = Convert.ToDecimal(item["Importe_Saldo"]);
                    oCta.Id_Usuarios_Locacion = Convert.ToInt32(item["Id_Usuarios_Locacion"]);
                    oCta.Numero = item["Numero"].ToString();
                    oCta.Id_Comprobantes_Tipo = Convert.ToInt32(item["Id_comprobantes_tipo"]);
                    oCta.Id_Comprobantes_Ref = Convert.ToInt32(item["Id_comprobantes_ref"]);
                    oCta.Importe_Provincial = Convert.ToDecimal(item["Importe_Provincial"]);
                    oCta.Id_Facturacion = Convert.ToInt32(item["id_facturacion"]);
                    oCta.Generado_facturacion_mensual = Convert.ToInt32(item["generado_facturacion_mensual"]);
                    oCta.Id_Iva_Ventas = Convert.ToInt32(item["Id_Iva_Ventas"]);
                    oCta.Id_Personal = Convert.ToInt32(item["Id_Personal"]);
                    oCta.Id_Origen = Convert.ToInt32(item["id_origen"]);
                    oCta.Percepcion = Convert.ToInt32(item["percepcion"]);
                    oCta.Id_Ctacte_Recibo_Plan = Convert.ToInt32(item["id_plan_recibo"]);
                    oCta.Porcentaje_Percepcion = Convert.ToDecimal(item["porcentaje_percepcion"]);
                    //oCta.UsuCtaCteDet = oDet.Get(oCta.Id);
                    oCtaLista.Add(oCta);
                }
                return oCtaLista;
                
            }
            return oCtaLista;

        }

        public DataRow getDatosCtaCteId(Int32 id_ctacte)
        {
            DataTable dt;

            try
            {
                oCon.Conectar();
                oCon.CrearComando(String.Format("SELECT * FROM usuarios_ctacte where id = {0} ", id_ctacte));
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
                dr["id_comprobantes_tipo"] = 0;
                dt.Rows.Add(dr);
            }

            return dt.Rows[0];

        }

        public Int32 gestionarAppExternaPrepagos(int id_usuario_servicio, out string resultadoFinal, out string resultadoFinalAccion, bool activarPrepagos = false)
        {
            //DECLARACIONES DE VARIABLES INTERNAS DEL METODO
            Partes_Usuarios_Servicios oParteUsuarioServicio = new Partes_Usuarios_Servicios();
            DataTable dtDatosUsuServ = new DataTable();
            DataTable DtServiciosAsociados = new DataTable();
            bool generoAccionCorrectamente = false;
            Usuarios_Servicios oUsuarioServicio = new Usuarios_Servicios();
            Aplicaciones_Externas oAppExterna = new Aplicaciones_Externas();


            //DECLARACIONES PARA EL CASS
            DataTable dtAplicacionesFiltradas = Tablas.DataCass;
            Cass oCass;
            oCass = new Cass(Convert.ToInt32(dtAplicacionesFiltradas.Rows[0]["Id"]));
            DataTable dtOperacionesCass = new DataTable();
            string ResultadoOpCass = "";
            string resultadoBajasCass = "";
            string ResultadoTotal = "";

            //DECLARACIONES PARA EL ISP
            Isp oIsp = new Isp();
            string ResultadoOpIsp = "";
            int estadoOpIsp = 0;

            try
            {
                dtDatosUsuServ = oUsuarioServicio.getUsuServData(id_usuario_servicio);
                if (dtDatosUsuServ.Rows.Count > 0)
                {
                    foreach (DataRow drUsuServ in dtDatosUsuServ.Rows)
                    {
                        ResultadoOpCass = "";
                        resultadoBajasCass = "";
                        if (Convert.ToInt32(drUsuServ["id_app_ext"]) == (int)Aplicaciones_Externas.Aplicacion_Externa.CASS)
                        {
                            dtOperacionesCass.Clear();
                            dtOperacionesCass = oCass.GenerarDtTarjetas(dtDatosUsuServ);
                            if (dtOperacionesCass.Rows.Count == 0)
                            {
                                dtOperacionesCass.Clear();
                                dtOperacionesCass = oCass.GenerarDtPreAsignacion(dtDatosUsuServ);
                            }
                            if (dtOperacionesCass.Rows.Count > 0)
                            {
                                if (oCass.GenerarActivacion(dtOperacionesCass, Convert.ToInt32(drUsuServ["idUsuario"]), out ResultadoOpCass, activarPrepagos))
                                {
                                    generoAccionCorrectamente = true;
                                    resultadoBajasCass = "Cass activado correctamente.";
                                }
                                else
                                    resultadoBajasCass = "Falla al activar en el cass.";
                            }
                            //LIMPIO la tabla de paquete de cass
                            oCass.LimpiarDtPaquetesCass();
                            //LIMPIO LA TABLA DE INFORMACION ESTATICA
                            dtOperacionesCass.Clear();
                        }
                        else if (Convert.ToInt32(drUsuServ["id_app_ext"]) == (int)Aplicaciones_Externas.Aplicacion_Externa.ISP)
                        {
                            if (DtServiciosAsociados.Rows.Count > 0)
                            {
                                if (oIsp.GenerarActivacion(dtDatosUsuServ, out ResultadoOpIsp, out estadoOpIsp))
                                {
                                    generoAccionCorrectamente = true;
                                    ResultadoOpIsp = "ISP Activado correctamente";

                                }
                                else
                                {
                                    generoAccionCorrectamente = false;
                                    ResultadoOpIsp = "Hubo una falla al activar en el ISP";
                                }
                            }
                            else
                            {
                                generoAccionCorrectamente = false;
                                ResultadoOpIsp = "No hay servicios asocaidos al ISP para este parte.";
                                resultadoFinal = ResultadoOpIsp;
                            }
                        }
                        ResultadoTotal += $"\n{ResultadoOpIsp}";

                    }
                }

            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }
            resultadoFinal = ResultadoTotal;
            resultadoFinalAccion = resultadoBajasCass;
            if (generoAccionCorrectamente == true)
                return 1;
            else
                return 0;

        }

    }
}
