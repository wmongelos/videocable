using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;

namespace CapaNegocios
{
    public class Comprobantes
    {
        public Int32 Id { get; set; }
        public Int32 Id_Usuarios { get; set; }
        public DateTime Fecha { get; set; }
        public Int32 Punto_Venta { get; set; }
        public Int32 Numero { get; set; }
        public Int32 Id_Comprobantes_Tipo { get; set; }
        public Decimal Importe { get; set; }
        public Int32 Id_Usuarios_Locaciones { get; set; }
        public Int32 Id_Personal { get; set; }
        public Int32 Id_Punto_Venta { get; set; }
        public Int32 Id_Punto_Cobro { get; set; }
        public String Descripcion { get; set; }
        public enum NUEVO
        {
            GENERADO = 2,
            NUEVO = 1
        }
        public Usuarios_CtaCte UsuCtacta { get; set; }

        public enum Estado_Factura
        {
            TODAS = 0,
            NO_ENVIADA = 1,
            ENVIADA = 2
        }

        private Conexion oCon = new Conexion();


        public DataTable ListarTipoIVA()
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT * FROM comprobantes_iva ORDER BY Id");
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

        public DataTable ListarTipoIVAUsuario(int id_usuario)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT * FROM usuarios LEFT JOIN comprobantes_iva ON usuarios.Id_Comprobantes_Iva = comprobantes_iva.id where usuarios.id = @id_usu");
                oCon.AsignarParametroEntero("@id_usu", id_usuario);
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

        public Int32 Guardar(Comprobantes oComp)
        {
            string numeroMuestra = oComp.Punto_Venta.ToString().PadLeft(4, '0') + "-" + oComp.Numero.ToString().PadLeft(8, '0');
            string descripcion = String.Empty;
            if (oComp.Id_Comprobantes_Tipo == Convert.ToInt32(Comprobantes_Tipo.Tipo.COMPROBANTE_DEUDA))
                descripcion = "COMPROBANTE DE DEUDA";
            else if (oComp.Id_Comprobantes_Tipo == Convert.ToInt32(Comprobantes_Tipo.Tipo.FACTURA_A))
                descripcion = "FACTURA A";
            else if (oComp.Id_Comprobantes_Tipo == Convert.ToInt32(Comprobantes_Tipo.Tipo.FACTURA_B))
                descripcion = "FACTURA B";
            else if (oComp.Id_Comprobantes_Tipo == Convert.ToInt32(Comprobantes_Tipo.Tipo.NOTA_CREDITO_A))
                descripcion = "NOTA DE CREDITO A";
            else if (oComp.Id_Comprobantes_Tipo == Convert.ToInt32(Comprobantes_Tipo.Tipo.NOTA_CREDITO_B))
                descripcion = "NOTA DE CREDITO B";
            else if (oComp.Id_Comprobantes_Tipo == Convert.ToInt32(Comprobantes_Tipo.Tipo.PLAN_DE_PAGO))
                descripcion = "PLAN DE PAGO";
            else if (oComp.Id_Comprobantes_Tipo == Convert.ToInt32(Comprobantes_Tipo.Tipo.RECIBO))
                descripcion = "RECIBO";
            else if (oComp.Id_Comprobantes_Tipo == Convert.ToInt32(Comprobantes_Tipo.Tipo.NOTA_DEBITO_A))
                descripcion = "NOTA DE DEBITO A";
            else if (oComp.Id_Comprobantes_Tipo == Convert.ToInt32(Comprobantes_Tipo.Tipo.NOTA_DEBITO_B))
                descripcion = "NOTA DE DEBITO B";
            else if (oComp.Id_Comprobantes_Tipo == Convert.ToInt32(Comprobantes_Tipo.Tipo.RECIBO_AJUSTE))
                descripcion = "RECIBO AJUSTE";
            try
            {

                oCon.Conectar();
                oCon.CrearComando("INSERT INTO comprobantes(Id_Usuarios, Fecha, Punto_Venta, Numero, Id_Comprobantes_Tipo, Importe, Id_Usuarios_Locaciones, Id_Personal, Id_Punto_Venta,Id_Puntos_De_Cobro, Descripcion) " +
                    "VALUES(@usuario, @fecha, @pdv, @numero, @id_tipo, @importe, @loc, @personal, @punto,@puntocobro, @descripcion); SELECT @@IDENTITY");

                oCon.AsignarParametroEntero("@usuario", oComp.Id_Usuarios);
                oCon.AsignarParametroFecha("@fecha", oComp.Fecha);
                oCon.AsignarParametroEntero("@pdv", oComp.Punto_Venta);
                oCon.AsignarParametroEntero("@numero", oComp.Numero);
                oCon.AsignarParametroEntero("@id_tipo", oComp.Id_Comprobantes_Tipo);
                oCon.AsignarParametroDecimal("@importe", oComp.Importe);
                oCon.AsignarParametroEntero("@loc", oComp.Id_Usuarios_Locaciones);
                oCon.AsignarParametroEntero("@personal", oComp.Id_Personal);
                oCon.AsignarParametroEntero("@punto", oComp.Id_Punto_Venta);
                oCon.AsignarParametroEntero("@puntocobro", Puntos_Cobros.Id_Punto);
                oCon.AsignarParametroCadena("@descripcion", String.Format("{0} {1}", descripcion, numeroMuestra));

                oCon.ComenzarTransaccion();
                oComp.Id = oCon.EjecutarScalar();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                oComp.Id = -1;
            }

            return oComp.Id;
        }



        public DataTable ListarLoteFacturacionElec(int mes, int año)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT usuarios.id, CONCAT_WS(', ', usuarios.apellido, usuarios.nombre) as usuario, " +
                    "usuarios_ctacte.descripcion, importe_original, usuarios_ctacte.id as idctacte, usuarios_ctacte.id_usuarios_locacion " +
                    "FROM usuarios_servicios " +
                    "LEFT JOIN usuarios on usuarios.id = usuarios_servicios.id_usuarios " +
                    "LEFT JOIN usuarios_ctacte on usuarios_ctacte.id_usuarios = usuarios_servicios.id_usuarios " +
                    "WHERE usuarios_servicios.id_servicios_categorias = 1 " +
                    "and year(usuarios_ctacte.fecha_movimiento) = @año and month(usuarios_ctacte.fecha_movimiento) = @mes group by idctacte");

                oCon.AsignarParametroEntero("@año", año);
                oCon.AsignarParametroEntero("@mes", mes);
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

        public DataTable GetComprobante(int idComprobante)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();

                string consulta = " select vw_comprobantes.id, vw_comprobantes.id_usuarios, vw_comprobantes.id_comprobantes_tipo, id_puntos_de_cobro, vw_comprobantes.id_personal, "
                         + " id_comprobantes_iva, vw_comprobantes.id_usuarios_locaciones, id_punto_venta, fecha, vw_comprobantes.numero, importe, vw_comprobantes.descripcion, enviado, "
                         + " usuarios_apellido, usuarios_nombre, usuario, usuarios_cuit, comprobantes_tipo_nombre, comprobantes_tipo_letra, "
                         + " comprobantes_tipo_presenta_ventas, puntos_cobros_descripcion, puntos_cobros_puntos, personal_nombre, comprobantes_iva_descripcion, "
                         + " comprobantes_iva_letra, usuarios_locaciones_calle, usuarios_locaciones_altura, usuarios_locaciones_piso,"
                         + " usuarios_locaciones_depto, usuarios_locaciones_localidad, puntos_venta_descripcion, puntos_venta_numero, "
                         + " vw_comprobantes.borrado,comprobantes_tipo.codigo_afip,usuarios_ctacte_det.id_debito_asociado"
                         + " from vw_comprobantes"
                         + " left join comprobantes_tipo on comprobantes_tipo.id = vw_comprobantes.id_comprobantes_tipo"
                         + " left join usuarios_ctacte on usuarios_ctacte.id_comprobantes = vw_comprobantes.id "
                         + " left join usuarios_ctacte_det on usuarios_ctacte_det.id_usuarios_ctacte = usuarios_ctacte.id"
                         + " where vw_comprobantes.id = @idx";

                oCon.CrearComando(consulta);
                oCon.AsignarParametroEntero("@idx", idComprobante);
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
            }

            return dt;
        }

        public DataTable ListarComprobantesPorFecha(DateTime FechaDesde, DateTime FechaHasta)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT usuarios.id, concat_ws(',', usuarios.apellido, usuarios.nombre) as usuario, concat_ws(',', calle) as locacion, " +
                    "fecha, comprobantes_tipo.nombre, comprobantes_tipo.letra, 0 AS punto_venta, " +
                    "numero, importe From comprobantes " +
                    "LEFT JOIN usuarios on usuarios.id = id_usuarios " +
                    "LEFT JOIN comprobantes_tipo on comprobantes_tipo.id = id_comprobantes_tipo " +
                    "LEFT JOIN usuarios_locaciones on usuarios_locaciones.id = comprobantes.id_usuarios_locaciones where comprobantes.fecha between @fecha_desde and @fecha_hasta");

                oCon.AsignarParametroFecha("@fecha_desde", FechaDesde);
                oCon.AsignarParametroFecha("@fecha_hasta", FechaHasta);

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

        public int EliminarComprobante(int idComprobante, int idUsuariosLocaciones, int idUsuario)
        {
            int eliminarComprobante = 0, idTipoComprobante, numeroComprobanteTipoAfip;

            decimal totalFactura = 0, totalNeto = 0, totalIva = 0, neto = 0, iva = 0;
            string CAE = "", NumeroMuestra = "";
            DateTime vencimientoCAE = DateTime.Now;
            Double nroFacturaCAE = 0;

            Boolean trabajaElectronica = false;
            List<int> arrayUsuariosServicios = new List<int>();
            DataRow drDatosComprobante;
            DataTable dtDatosComprobante = new DataTable();
            DataTable dtDatosUltimoComprobante = new DataTable();
            DataTable dtDatosCtaCte = new DataTable();
            DataTable dtUsuariosServiciosSubActualizar = new DataTable();
            DataTable dtDatosUsuario = new DataTable();
            DataTable dtIvas = new DataTable();
            DataTable dtItemsFactura = new DataTable();
            DataTable dtRegistrosCtaCteDet = new DataTable();
            DataTable dtRegistrosCtaCteDetAux = new DataTable();
            DataTable dtDatosPuntoVenta = new DataTable();
            DataTable dtDatosCAE = new DataTable();
            Usuarios_Servicios oUsuariosServicios = new Usuarios_Servicios();
            Facturacion oFacturacion = new Facturacion();
            Comprobantes oComprobantes = new Comprobantes();
            Comprobantes_Tipo oComprobantesTipo = new Comprobantes_Tipo();
            Usuarios_CtaCte oUsuariosCtaCte = new Usuarios_CtaCte();
            Iva_Alicuotas oIvaAlicuotas = new Iva_Alicuotas();
            Comprobantes_Detalle oComprobantesDetalle = new Comprobantes_Detalle();
            Usuarios oUsuario = new Usuarios();
            Comprobantes_Iva oComprobanteIVA = new Comprobantes_Iva();
            Comprobantes_Habilitados oComprobantesHabilitados = new Comprobantes_Habilitados();

            DataTable dtaux = oComprobantes.GetFechasAnterioresElimina(idComprobante);
            try
            {
                oCon.Conectar();
                oCon.CrearComando(String.Format("select * from vw_comprobantes where id={0}", idComprobante));//trae datos del comprobante
                dtDatosComprobante = oCon.Tabla();
                oCon.CrearComando(String.Format("select * from vw_usuarios_ctacte where id_comprobantes={0}", idComprobante));//trae registros ctacte relacionados al comprobante
                dtDatosCtaCte = oCon.Tabla();
                foreach (DataRow ctacte in dtDatosCtaCte.Rows)
                {//controla que los registros de ctacte del comprobantes no esten pagos 
                    if (Convert.ToDecimal(ctacte["importe_pago"]) > 0)
                    {
                        eliminarComprobante = -1;
                        break;
                    }
                }
                if (eliminarComprobante != -1)
                {
                    if (Convert.ToInt32(dtDatosComprobante.Rows[0]["comprobantes_tipo_presenta_ventas"]) == Convert.ToInt32(Comprobantes_Tipo.Presenta_Ventas.NO))
                    {//si es un comprobante a pagar que no presenta ventas
                        oCon.CrearComando(String.Format("select * from vw_comprobantes where id=(select max(id) from vw_comprobantes where id_usuarios_locaciones={0} and id_usuarios={1} and id_comprobantes_tipo={2} and borrado=0)", idUsuariosLocaciones, idUsuario, Convert.ToInt32(Comprobantes_Tipo.Tipo.COMPROBANTE_DEUDA)));
                        dtDatosUltimoComprobante = oCon.Tabla();
                        if (dtDatosUltimoComprobante.Rows.Count > 0)
                        {
                            //if (idComprobante == Convert.ToInt32(dtDatosUltimoComprobante.Rows[0]["id"]))
                            //{
                            if (dtDatosCtaCte.Rows.Count > 0)
                            {
                                foreach (DataRow ctacte in dtDatosCtaCte.Rows)
                                {
                                    oCon.CrearComando("Update usuarios_ctacte_det set borrado=1,id_personal=@personal where id_usuarios_ctacte=@id");
                                    oCon.AsignarParametroEntero("@personal", Personal.Id_Login);
                                    oCon.AsignarParametroEntero("@id", Convert.ToInt32(ctacte["id"]));
                                    oCon.ComenzarTransaccion();
                                    oCon.EjecutarComando();
                                    oCon.ConfirmarTransaccion();

                                    oCon.CrearComando("Update usuarios_ctacte set borrado=1,id_personal=@personal where id=@id");
                                    oCon.AsignarParametroEntero("@personal", Personal.Id_Login);
                                    oCon.AsignarParametroEntero("@id", Convert.ToInt32(ctacte["id"]));
                                    oCon.ComenzarTransaccion();
                                    oCon.EjecutarComando();
                                    oCon.ConfirmarTransaccion();
                                }
                                oCon.CrearComando("Update comprobantes set borrado=1,id_personal = @personal where id=@id");
                                oCon.AsignarParametroEntero("@personal", Personal.Id_Login);
                                oCon.AsignarParametroEntero("@id", idComprobante);
                                oCon.ComenzarTransaccion();
                                oCon.EjecutarComando();
                                oCon.ConfirmarTransaccion();

                                //nueva modificacion elimina comprobante vuelve la fecha factura a la ultima fecha_hasta del det que corresponda al servicio
                                DataTable dtDet = new DataTable();
                                oCon.CrearComando("SELECT usuarios_ctacte_det.* FROM usuarios_ctacte_det where id_usuarios_ctacte=@id_ctacte group by usuarios_ctacte_det.id_usuarios_servicios ");
                                oCon.AsignarParametroEntero("@id_ctacte", Convert.ToInt32(dtDatosCtaCte.Rows[0]["id"]));
                                dtDet = oCon.Tabla();
                                DataTable dtDatosDetUsuarioServicio = new DataTable();
                                DateTime fechaDesdeAnterior = new DateTime(1999,01,01);
                                DateTime fechaHastaAnterior = new DateTime(1999,01,01);
                                Dictionary<int, DateTime> usuSerFechas = new Dictionary<int, DateTime>();


                                foreach (DataRow itemCtaCte in dtDet.Rows)
                                {
                                    int idUsuarioServicio = Convert.ToInt32(itemCtaCte["id_usuarios_servicios"]);
                                    oCon.CrearComando("select usuarios_ctacte_det.*, usuarios_ctacte.fecha_hasta as fecha_hasta_ctacte from usuarios_ctacte_det left join usuarios_ctacte on usuarios_ctacte.id=usuarios_ctacte_det.id_usuarios_ctacte where id_usuarios_servicios = @id_usu_ser and usuarios_ctacte_det.borrado=0 order by usuarios_ctacte_det.fecha_hasta desc limit 1");
                                    oCon.AsignarParametroEntero("@id_usu_ser", idUsuarioServicio);
                                    dtDatosDetUsuarioServicio = oCon.Tabla();
                                    if (dtDatosDetUsuarioServicio.Rows.Count > 0)
                                    {
                                        fechaDesdeAnterior = Convert.ToDateTime(dtDatosDetUsuarioServicio.Rows[0]["fecha_desde"]);
                                        fechaHastaAnterior = Convert.ToDateTime(dtDatosDetUsuarioServicio.Rows[0]["fecha_hasta_ctacte"]);
                                    }
                                    else
                                    {
                                        DataTable dt = oUsuariosServicios.RetornarFechasDelServicio(idUsuarioServicio);
                                        if (dt.Rows.Count > 0)
                                        {
                                            fechaDesdeAnterior = Convert.ToDateTime(dt.Rows[0]["fecha_inicio"]);
                                            fechaHastaAnterior = Convert.ToDateTime(dt.Rows[0]["fecha_inicio"]);
                                        }
                                    }
                                    usuSerFechas.Add(idUsuarioServicio, fechaHastaAnterior);
                                }

                                foreach (DataRow ctacte in dtDatosCtaCte.Rows)
                                {
                                    arrayUsuariosServicios.Clear();
                                    dtUsuariosServiciosSubActualizar.Clear();
                                    oCon.CrearComando(String.Format("select id_usuarios_servicios_sub, min(usuarios_ctacte_det.fecha_desde) as fecha_desde, usuarios_ctacte_det.id_usuarios_servicios, vw_usuarios_servicios_sub.fecha_inicio from usuarios_ctacte_det left join vw_usuarios_servicios_sub on usuarios_ctacte_det.id_usuarios_servicios_sub = vw_usuarios_servicios_sub.id  where id_usuarios_ctacte = {0} group by id_usuarios_servicios_sub", Convert.ToInt32(ctacte["id"])));
                                    dtUsuariosServiciosSubActualizar = oCon.Tabla();
                                    foreach (DataRow fila in dtUsuariosServiciosSubActualizar.Rows)
                                    {
                                        if (arrayUsuariosServicios.Contains(Convert.ToInt32(fila["id_usuarios_servicios"])) == false)
                                            arrayUsuariosServicios.Add(Convert.ToInt32(fila["id_usuarios_servicios"]));
                                        try
                                        {
                                            if (idComprobante == Convert.ToInt32(dtDatosUltimoComprobante.Rows[0]["id"]))
                                            {
                                                DateTime fechasub = new DateTime();
                                                usuSerFechas.TryGetValue(Convert.ToInt32(fila["id_usuarios_servicios"]), out fechasub);
                                                if (DateTime.Compare(Convert.ToDateTime(fila["fecha_desde"]).AddDays(-1), Convert.ToDateTime(fila["fecha_inicio"])) < 0)
                                                    oFacturacion.ActualizarFechaFacturaSubServicio(Convert.ToInt32(fila["id_usuarios_servicios_sub"]), fechasub);
                                                else
                                                    oFacturacion.ActualizarFechaFacturaSubServicio(Convert.ToInt32(fila["id_usuarios_servicios_sub"]), fechasub);
                                            }
                                        }
                                        catch
                                        {
                                            oFacturacion.ActualizarFechaFacturaSubServicio(Convert.ToInt32(fila["id_usuarios_servicios_sub"]), Convert.ToDateTime(fila["fecha_desde"]).AddDays(-1));
                                        }
                                    }
                                    foreach (int idUsuarioServicio in arrayUsuariosServicios)
                                    {
                                        DateTime fecha = new DateTime();
                                        usuSerFechas.TryGetValue(idUsuarioServicio, out fecha);
                                        if (fechaHastaAnterior.Year != 1999)
                                            oUsuariosServicios.Fecha_Factura = fecha;
                                        else
                                            oUsuariosServicios.Fecha_Factura = Convert.ToDateTime(ctacte["fecha_desde"]).AddDays(-1);

                                        oUsuariosServicios.Actualizar_fecha_facturado(idUsuarioServicio);
                                    }
                                    // fin nueva modificacion maxi
                                }
                            }
                            //}
                            //else
                            //    eliminarComprobante = -1;
                        }
                        else
                        {

                            oCon.CrearComando("Update usuarios_ctacte left join usuarios_ctacte_Det on usuarios_ctacte_Det.id_usuarios_ctacte= usuarios_ctacte.id  set usuarios_ctacte.borrado=1,usuarios_ctacte_det.borrado=1, usuarios_ctacte.id_personal = @personal where usuarios_ctacte.id_Comprobantes=@id");
                            oCon.AsignarParametroEntero("@personal", Personal.Id_Login);
                            oCon.AsignarParametroEntero("@id",idComprobante);
                            oCon.ComenzarTransaccion();
                            oCon.EjecutarComando();
                            oCon.ConfirmarTransaccion();
                        }
                    }
                    else
                    {//si es un comprobante a pagar que sí presenta ventas
                        oCon.CrearComando(String.Format("select * from vw_usuarios where id={0}", idUsuario));
                        dtDatosUsuario = oCon.Tabla();//trae los datos del usuario ya que requiere algunos de éstos como id_comprobantes_iva y otros.

                        if (Convert.ToInt32(dtDatosUsuario.Rows[0]["id_comprobantes_iva"]) == Convert.ToInt32(Comprobantes_Iva.Tipo.RESPONSABLE_INSCRIPTO))//datos de numeración para comprobante nota de crédito que se va a generar
                            drDatosComprobante = oComprobantesTipo.GetNumeracion(Convert.ToInt32(Comprobantes_Tipo.Tipo.NOTA_CREDITO_A), Puntos_Cobros.Id_Punto);
                        else
                            drDatosComprobante = oComprobantesTipo.GetNumeracion(Convert.ToInt32(Comprobantes_Tipo.Tipo.NOTA_CREDITO_B), Puntos_Cobros.Id_Punto);

                        if (Convert.ToInt32(dtDatosUsuario.Rows[0]["id_comprobantes_iva"]) == Convert.ToInt32(Comprobantes_Iva.Tipo.RESPONSABLE_INSCRIPTO))
                        {//setea numeración comprobantes
                            oComprobantesTipo.SetNumeracion(Convert.ToInt32(drDatosComprobante["idPuntoVenta"]), Convert.ToInt32(Comprobantes_Tipo.Tipo.NOTA_CREDITO_A), Convert.ToInt32(drDatosComprobante["numComprobante"]));
                            oComprobantes.Id_Comprobantes_Tipo = (int)Comprobantes_Tipo.Tipo.NOTA_CREDITO_A;
                            oUsuariosCtaCte.Id_Comprobantes_Tipo = (int)Comprobantes_Tipo.Tipo.NOTA_CREDITO_A;
                        }
                        else
                        {
                            oComprobantesTipo.SetNumeracion(Convert.ToInt32(drDatosComprobante["idPuntoVenta"]), Convert.ToInt32(Comprobantes_Tipo.Tipo.NOTA_CREDITO_B), Convert.ToInt32(drDatosComprobante["numComprobante"]));
                            oComprobantes.Id_Comprobantes_Tipo = (int)Comprobantes_Tipo.Tipo.NOTA_CREDITO_B;
                            oUsuariosCtaCte.Id_Comprobantes_Tipo = (int)Comprobantes_Tipo.Tipo.NOTA_CREDITO_B;
                        }

                        oComprobantes.Id_Usuarios = idUsuario;
                        oComprobantes.Fecha = DateTime.Now;
                        oComprobantes.Numero = Convert.ToInt32(drDatosComprobante["numComprobante"]);
                        oComprobantes.Punto_Venta = Convert.ToInt32(drDatosComprobante["numPuntoVenta"]);
                        oComprobantes.Id_Punto_Venta = Convert.ToInt32(drDatosComprobante["idPuntoVenta"]);
                        oComprobantes.Id_Personal = Personal.Id_Login;
                        oComprobantes.Id_Punto_Cobro = Puntos_Cobros.Id_Punto;
                        oComprobantes.Id_Usuarios_Locaciones = idUsuariosLocaciones;
                        oComprobantes.Importe = 0;
                        oComprobantes.Id = oComprobantes.Guardar(oComprobantes);//guardar el comprobante de nota de crédito

                        dtRegistrosCtaCteDet.Clear();
                        foreach (DataRow registroCtaCte in dtDatosCtaCte.Rows)
                        {
                            dtRegistrosCtaCteDetAux.Clear();
                            dtRegistrosCtaCteDetAux = oUsuariosCtaCte.ListarMovimiento(Convert.ToInt32(registroCtaCte["id"]), 0, 0);
                            if (dtRegistrosCtaCteDet.Rows.Count == 0)
                                dtRegistrosCtaCteDet = dtRegistrosCtaCteDetAux;
                            else
                            {
                                foreach (DataRow registroCtaCteDet in dtRegistrosCtaCteDetAux.Rows)
                                    dtRegistrosCtaCteDet.ImportRow(registroCtaCteDet);
                            }
                        }

                        //formatear tabla con registros de usuarios ctacte detalle para que se pueda usar en el método Arma_Detalle_Tipo
                        dtRegistrosCtaCteDet.Columns.Add("encabezado", typeof(string));
                        dtRegistrosCtaCteDet.Columns.Add("elige", typeof(bool));
                        dtRegistrosCtaCteDet.Columns.Add("importe_total", typeof(string));
                        dtRegistrosCtaCteDet.Columns["servicio"].ColumnName = "servicio_nombre";
                        dtRegistrosCtaCteDet.Columns["subservicio"].ColumnName = "sub_servicio";
                        dtRegistrosCtaCteDet.Columns["id_servicios_sub"].ColumnName = "id_tipo";
                        dtRegistrosCtaCteDet.Columns["tipo_concepto"].ColumnName = "tipo";
                        dtRegistrosCtaCteDet.Columns["servicio_tipo"].ColumnName = "tipo_nombre";

                        foreach (DataRow registro in dtRegistrosCtaCteDet.Rows)
                        {
                            registro["encabezado"] = 0;
                            registro["elige"] = true;
                            registro["importe_total"] = Decimal.Round(Convert.ToDecimal(registro["importe_saldo"]) - Convert.ToDecimal(registro["importe_bonificacion"]), 2);
                        }

                        dtItemsFactura = oFacturacion.Arma_Detalle_Tipo(dtDatosComprobante, dtRegistrosCtaCteDet, oFacturacion);

                        dtIvas = oIvaAlicuotas.Listar();
                        oComprobantesDetalle.Id_Comprobantes = oComprobantes.Id;

                        foreach (DataRow DrItem in dtItemsFactura.Rows)
                        {
                            if (!Convert.ToBoolean(DrItem["suma"].ToString()))
                            {
                                foreach (DataRow drIva in dtIvas.Rows)
                                {
                                    if (Convert.ToInt32(drIva["Id"].ToString()) == Convert.ToInt32(DrItem["Id_Iva_Alicuotas"].ToString()))
                                    {
                                        neto = decimal.Round(Convert.ToDecimal(DrItem["total"].ToString()) / Convert.ToDecimal(drIva["porcentaje_divide"].ToString()), 2);
                                        iva = decimal.Round(Convert.ToDecimal(DrItem["total"].ToString()) - neto, 2);
                                        //ACUMULA LOS IVAS
                                        drIva["importe_neto"] = Convert.ToDecimal(drIva["importe_neto"].ToString()) + neto;
                                        drIva["importe_iva"] = Convert.ToDecimal(drIva["importe_iva"].ToString()) + iva;
                                        totalNeto = totalNeto + neto;
                                        totalIva = totalIva + iva;
                                        totalFactura = totalFactura + decimal.Round(Convert.ToDecimal(DrItem["total"].ToString()), 2);
                                    }
                                }
                                //if (Comprobantes_Iva.CurrentComprobantes_Iva.Letra == "A"){
                                //}
                                //else{
                                //}
                            }
                            DataTable dtDatosUsuarios = new DataTable();
                            int idTipoComprobanteUsuario = 0;
                            double docCuit = 0;
                            dtDatosUsuarios = oUsuario.Buscar_datos_usuario(idUsuario);
                            if (dtDatosUsuario.Rows.Count > 0)
                            {
                                //compruebo la condicion de iva. si es 1 es consumidor final, en ese caso tomo el dni sino el cuit
                                if (Convert.ToInt32(dtDatosUsuario.Rows[0]["Id_Comprobantes_Iva"]) == 1)
                                    docCuit = Convert.ToDouble(dtDatosUsuario.Rows[0]["numero_documento"]);
                                else
                                    docCuit = Convert.ToDouble(dtDatosUsuario.Rows[0]["Cuit"]);
                                idTipoComprobanteUsuario = Convert.ToInt32(dtDatosUsuario.Rows[0]["id_comprobantes_iva"]);
                            }
                            int tipoDocumentoAfip = oComprobanteIVA.GetTipoDocumentoAfip(idTipoComprobanteUsuario);
                            int idtipoComprobante = 0;
                            int tipoComprobanteAfip = 0;

                            if (tipoDocumentoAfip != 0)
                            {
                                if (Convert.ToInt32(dtDatosComprobante.Rows[0]["id_comprobantes_tipo"]) == (int)Comprobantes_Tipo.Tipo.FACTURA_A)
                                {
                                    dtDatosPuntoVenta = oComprobantesHabilitados.GetDatosPuntoVenta(Convert.ToInt32(Comprobantes_Tipo.Tipo.FACTURA_A), Convert.ToInt32(Puntos_Cobros.Id_Punto));
                                    idtipoComprobante = (int)Comprobantes_Tipo.Tipo.NOTA_CREDITO_A;
                                }
                                else
                                {
                                    dtDatosPuntoVenta = oComprobantesHabilitados.GetDatosPuntoVenta(Convert.ToInt32(Comprobantes_Tipo.Tipo.FACTURA_B), Convert.ToInt32(Puntos_Cobros.Id_Punto));
                                    idtipoComprobante = (int)Comprobantes_Tipo.Tipo.NOTA_CREDITO_B;

                                }
                                tipoComprobanteAfip = oComprobantesTipo.getNumeroAfip(idtipoComprobante);
                                idTipoComprobante = Convert.ToInt32(dtDatosPuntoVenta.Rows[0]["id_comprobantes_tipo"]);
                                numeroComprobanteTipoAfip = oComprobantesTipo.getNumeroAfip(idTipoComprobante);
                                if (dtDatosPuntoVenta.Rows.Count > 0)
                                {
                                    if (Convert.ToInt32(dtDatosPuntoVenta.Rows[0]["punto_venta_id_modalidad_facturacion"]) == 3)
                                    {
                                        trabajaElectronica = true;
                                        // dtDatosCAE =oFacturacion.Nuevo_Cae(dtIvas, tipoDocumentoAfip, docCuit, numeroComprobanteTipoAfip,10,Convert.ToDateTime(dtDatosCtaCte.Rows[0]["fecha_desde"]), Convert.ToDateTime(dtDatosCtaCte.Rows[0]["fecha_hasta"]), Convert.ToDateTime(dtDatosCtaCte.Rows[0]["fecha_hasta"]));
                                        if (Convert.ToInt32(dtDatosCAE.Rows[0]["salida"]) != 0)
                                            return Convert.ToInt32(dtDatosCAE.Rows[0]["salida"]);
                                    }
                                }
                                else
                                    trabajaElectronica = false;
                            }

                            oComprobantesDetalle.Descripcion = DrItem["descripcion"].ToString();
                            oComprobantesDetalle.Unidad = DrItem["unidad"].ToString();
                            oComprobantesDetalle.Cantidad = Convert.ToInt32(DrItem["cantidad"].ToString());
                            oComprobantesDetalle.Unitario = decimal.Round(Convert.ToDecimal(DrItem["unitario"].ToString()), 2);
                            oComprobantesDetalle.Total = Convert.ToDecimal(DrItem["total"].ToString());
                            oComprobantesDetalle.Punitorios = decimal.Round(Convert.ToDecimal(DrItem["punitorios"].ToString()), 2);
                            oComprobantesDetalle.Bonificaciones = decimal.Round(decimal.Multiply(Convert.ToDecimal(DrItem["bonificaciones"].ToString()), -1), 2);
                            oComprobantesDetalle.Desde = Convert.ToDateTime(DrItem["desde"].ToString());
                            oComprobantesDetalle.Hasta = Convert.ToDateTime(DrItem["hasta"].ToString());
                            oComprobantesDetalle.Descripcion_Adicional = DrItem["descripcion_adicional"].ToString();
                            oComprobantesDetalle.Codigo = "";
                            oComprobantesDetalle.Unidad = "";
                            oComprobantesDetalle.Guardar(oComprobantesDetalle);
                        }

                        if (trabajaElectronica)
                        {
                            if (Convert.ToInt32(dtDatosCAE.Rows[0]["salida"]) == 0)
                            {
                                CAE = dtDatosCAE.Rows[0]["cae"].ToString();
                                vencimientoCAE = Convert.ToDateTime(dtDatosCAE.Rows[0]["vencimiento"]);
                                nroFacturaCAE = Convert.ToDouble(dtDatosCAE.Rows[0]["numero"]);
                            }
                            else
                            {
                                CAE = "";
                                vencimientoCAE = DateTime.Now;
                                nroFacturaCAE = 0;
                            }
                        }


                        oFacturacion.Cae = CAE;
                        oFacturacion.Cae_vencimiento = vencimientoCAE;
                        if (trabajaElectronica)
                        {
                            NumeroMuestra = oComprobantes.Punto_Venta.ToString().PadLeft(4, '0') + "-" + nroFacturaCAE.ToString().PadLeft(8, '0');
                            Descripcion = Descripcion + " " + NumeroMuestra;
                            oFacturacion.Descripcion = Descripcion;
                        }
                        else
                        {
                            oFacturacion.Descripcion = "NOTA DE CRÉDITO " + dtDatosUsuario.Rows[0]["letra"].ToString();
                            oFacturacion.Numero = oComprobantes.Numero;
                            oFacturacion.NumeroMuestra = oComprobantes.Punto_Venta.ToString().PadLeft(4, '0') + "-" + oComprobantes.Numero.ToString().PadLeft(8, '0');
                        }


                        oFacturacion.Punto_Venta = oComprobantes.Punto_Venta;
                        oFacturacion.Id_Comprobantes_tipo = oComprobantes.Id_Comprobantes_Tipo;
                        oFacturacion.Id_Comprobantes = oComprobantes.Id;
                        oFacturacion.Letra = dtDatosUsuario.Rows[0]["letra"].ToString();
                        oFacturacion.Fecha = DateTime.Now;
                        oFacturacion.Descripcion = String.Format("{0} {1}", oFacturacion.Descripcion, oFacturacion.NumeroMuestra);
                        oFacturacion.Importe_Neto = totalNeto;
                        oFacturacion.Importe_Iva = totalIva;
                        oFacturacion.Importe_Impuesto_Provincial = 0;
                        oFacturacion.Importe_Impuesto_Nacional = 0;
                        oFacturacion.Importe_Impuesto_Municipal = 0;
                        oFacturacion.Importe_Impuesto_Interno = 0;
                        oFacturacion.Importe_Impuesto_Otros = 0;
                        oFacturacion.Importe_Final = totalFactura;
                        oFacturacion.Razon_Social = String.Format("{0} {1}", Usuarios.CurrentUsuario.Apellido, Usuarios.CurrentUsuario.Nombre);
                        oFacturacion.Fantasia = "";
                        oFacturacion.Calle = Usuarios.CurrentUsuario.Calle;
                        oFacturacion.Altura = Usuarios.CurrentUsuario.Altura;
                        oFacturacion.Localidad = Usuarios.CurrentUsuario.localidad;
                        oFacturacion.Cod_postal = Usuarios.CurrentUsuario.Cod_postal;


                        if (Usuarios.CurrentUsuario.Id_Comprobantes_Iva == (Int32)Comprobantes_Iva.Tipo.CONSUMIDOR_FINAL)
                            oFacturacion.Numero_Doc = Usuarios.CurrentUsuario.Numero_Documento;
                        else
                            oFacturacion.Numero_Doc = Usuarios.CurrentUsuario.CUIT;




                        oFacturacion.Provincia = "";
                        oFacturacion.Id_Usuarios = idUsuario;
                        oFacturacion.Id_Usuarios_locacion = idUsuariosLocaciones;
                        oFacturacion.Id_Iva_Ventas = oFacturacion.GuardarIvaVentas(oFacturacion);

                        oComprobantes.ActualizarImporteComprobante(oComprobantes.Id, totalFactura);

                        foreach (DataRow drIva in dtIvas.Rows)
                        {
                            if (Convert.ToDecimal(drIva["importe_neto"].ToString()) > 0)
                                oFacturacion.GuardarIvalicuotas(oFacturacion, drIva);
                        }

                        dtDatosComprobante.Clear();
                        foreach (DataRow registroCtaCte in dtDatosCtaCte.Rows)
                        {
                            oCon.CrearComando(String.Format("select * from vw_comprobantes where id={0}", Convert.ToInt32(registroCtaCte["id_comprobantes_ref"])));//trae datos del comprobante
                            dtDatosComprobante = oCon.Tabla();
                            oUsuariosCtaCte.ConvertirComprobante(Convert.ToInt32(dtDatosComprobante.Rows[0]["id_comprobantes_tipo"]), dtDatosComprobante.Rows[0]["descripcion"].ToString(), Convert.ToInt32(registroCtaCte["id"]));
                            oUsuariosCtaCte.GuardarCtaCteComprobante(Convert.ToInt32(registroCtaCte["id"]), oComprobantes.Id);
                            eliminarComprobante = oComprobantes.Id;
                        }
                    }
                }
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
                eliminarComprobante = -1;
                throw;
            }
            return eliminarComprobante;
        }

        public int ActualizarImporteComprobante(int idComprobante, decimal importe)
        {
            int codigoError = 0;
            try
            {
                oCon.Conectar();
                oCon.CrearComando("Update comprobantes set importe=@importeNuevo where id=@id");
                oCon.AsignarParametroDecimal("@importeNuevo", importe);
                oCon.AsignarParametroEntero("@id", idComprobante);
                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                codigoError = -1;
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                throw;
            }
            return codigoError;
        }

        public DataTable ListarFacturasElectronicasSinEnviar(DateTime desde, DateTime hasta, Estado_Factura estado)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                string condicion = "";
                if (estado == Estado_Factura.NO_ENVIADA)
                    condicion = " and vw_comprobantes.enviado = 0 ";
                else if (estado == Estado_Factura.ENVIADA)
                    condicion = " and vw_comprobantes.enviado = 1 ";

                oCon.CrearComando("select vw_usuarios_ctacte.descripcion,vw_usuarios_ctacte.usuario,vw_usuarios_ctacte.numero_documento,vw_usuarios_ctacte.usuario_nombre,vw_usuarios_ctacte.usuario_apellido,vw_usuarios_ctacte.localidad,vw_usuarios_ctacte.calle,vw_usuarios_ctacte.altura,vw_usuarios_ctacte.piso,vw_usuarios_ctacte.depto,vw_usuarios_ctacte.codigo_postal,vw_usuarios_ctacte.codigo_usuario,vw_usuarios_ctacte.entre_Calle_1,vw_usuarios_ctacte.entre_calle_2,vw_usuarios_ctacte.usuario_condicion_iva,vw_usuarios_ctacte.importe_original,vw_usuarios_ctacte.importe_bonificacion,vw_usuarios_ctacte.importe_provincial,vw_usuarios_ctacte.importe_final,vw_usuarios_ctacte.fecha_movimiento,vw_usuarios_ctacte.id_usuarios,vw_usuarios_ctacte.id_comprobantes as IdComprobante,vw_comprobantes.enviado,vw_usuarios.adhesion_facdigital,vw_usuarios.correo_electronico,vw_comprobantes.id_usuarios_locaciones, vw_comprobantes.enviado" +
                    " from vw_usuarios_ctacte" +
                    " inner join vw_comprobantes on vw_comprobantes.id=vw_usuarios_ctacte.id_comprobantes inner join vw_usuarios on vw_usuarios.id=vw_usuarios_ctacte.id_usuarios " +
                    " where vw_comprobantes.comprobantes_tipo_presenta_ventas=1 and vw_comprobantes.borrado=0 and vw_usuarios.adhesion_facdigital=1 and (vw_usuarios.correo_electronico !='' and vw_usuarios.correo_electronico is not null) " +
                    $" and Fecha_movimiento between @desde and @hasta {condicion} GROUP BY Descripcion");

                oCon.AsignarParametroFecha("@desde", desde);
                oCon.AsignarParametroFecha("@hasta", hasta);
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception e)
            {
                oCon.DesConectar();

            }

            return dt;
        }

        public DataTable ListarMovimientosCtaCte(int idComprobante)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("select * from vw_usuarios_ctacte where id_comprobantes=@idComprobante");

                oCon.AsignarParametroEntero("@idComprobante", idComprobante);

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

        public DataTable ListarComprobantes(int idUsuariosCtaCte)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("select id_comprobantes,fecha_emision, descripcion, comprobantes_tipo_nombre, comprobantes_tipo_letra, punto_gestion, importe from vw_usuarios_ctacte_comprobantes_historial where id_usuarios_ctacte=@idusuariosctacte");
                oCon.AsignarParametroEntero("@idusuariosctacte", idUsuariosCtaCte);

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

        public int Eliminar(int id, string detalle)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("update comprobantes set borrado=1, descripcion=@des where id=@idcom");
                oCon.AsignarParametroCadena("@des", detalle);
                oCon.AsignarParametroEntero("@idcom", id);
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

        public bool ActualizarEnviado(int idComp)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("update comprobantes set enviado=1 where id=@idcom");
                oCon.AsignarParametroEntero("@idcom", idComp);
                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();
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
        public bool DesHacerRemito(int idComprobante, out string salida)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("update usuarios_ctacte left join comprobantes on comprobantes.id=usuarios_ctacte.Id_comprobantes_ref set usuarios_ctacte.descripcion = comprobantes.descripcion, id_personal=@personal WHERE id_comprobantes=@comprobante");
                oCon.AsignarParametroEntero("@personal", Personal.Id_Login);
                oCon.AsignarParametroEntero("@comprobante", idComprobante);
                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();

                oCon.CrearComando("update usuarios_ctacte set id_comprobantes=Id_comprobantes_ref,usuarios_ctacte.id_comprobantes_Tipo=7, id_personal=@personal WHERE id_comprobantes=@comprobante");
                oCon.AsignarParametroEntero("@personal", Personal.Id_Login);
                oCon.AsignarParametroEntero("@comprobante", idComprobante);
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
                throw;
            }
        }

        public bool ContieneSubServicios(int idComprobante)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("select usuarios_ctacte_det.id from usuarios_ctacte_det " +
                    " left join usuarios_ctacte on usuarios_ctacte.id=usuarios_ctacte_det.id_usuarios_ctacte " +
                    " left join comprobantes on comprobantes.id = usuarios_ctacte.id_comprobantes_ref " +
                    " where comprobantes.id = @comprobante and usuarios_ctacte_det.tipo='S' group by usuarios_ctacte.id");
                oCon.AsignarParametroEntero("@comprobante", idComprobante);
                dt = oCon.Tabla();
                oCon.DesConectar();
                if (dt.Rows.Count > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception c)
            {
                return false;
            }

        }
        
        public DataTable ListarAdheridosFacElectronica(int idFac, DateTime fechaDesde, DateTime fechaHasta) //27/06/19 maxi
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT * FROM (select vw_usuarios_ctacte.descripcion,vw_usuarios_ctacte.codigo_usuario, vw_usuarios_ctacte.usuario,vw_usuarios_ctacte.importe_original,vw_usuarios_ctacte.importe_bonificacion,vw_usuarios_ctacte.importe_provincial,ifnull(vw_usuarios_ctacte.importe_final,0) as importe_final,vw_usuarios_ctacte.id as idctacte,vw_usuarios_ctacte.id_facturacion,comprobantes.id as idcomprobantes,comprobantes.id_usuarios,comprobantes.fecha,comprobantes.punto_venta,comprobantes.numero,comprobantes.importe,comprobantes.id_usuarios_locaciones,vw_usuarios_ctacte.localidad,vw_usuarios_ctacte.calle,vw_usuarios_ctacte.altura,vw_usuarios_ctacte.codigo_postal,vw_usuarios_ctacte.piso,vw_usuarios_ctacte.depto,vw_usuarios_ctacte.id_origen "
                    + ", usuarios_ctacte_recibos.id, usuarios_ctacte_recibos.Id_Comprobantes, IFNULL((SELECT comprobantes.Id_Comprobantes_Tipo FROM comprobantes WHERE comprobantes.Id = usuarios_ctacte_recibos.Id_Comprobantes), 5) AS tipo, usuarios.presentacion, usuarios.Adhesion_FacDigital, usuarios_Ctacte_det.id_debito_asociado, vw_usuarios_ctacte.Fecha_Desde, vw_usuarios_ctacte.Fecha_Hasta, comprobantes.id_comprobantes_tipo from vw_usuarios_ctacte "
                    + " left join comprobantes on comprobantes.id = vw_usuarios_ctacte.id_comprobantes join usuarios on usuarios.id = vw_usuarios_ctacte.id_usuarios "
                    + " left join usuarios_ctacte_relacion on usuarios_ctacte_relacion.id_usuarios_ctacte = vw_usuarios_ctacte.id "
                    + " left join usuarios_ctacte_recibos on usuarios_ctacte_recibos.id = usuarios_ctacte_relacion.id_usuarios_ctacte_recibos "
                    + " left join usuarios_ctacte_det on usuarios_ctacte_det.id_usuarios_ctacte =vw_usuarios_ctacte.id "
                    + " left join servicios on servicios.id = usuarios_ctacte_det.Id_Servicios "
                    + " where comprobantes.importe > 0 "
                    + " and comprobantes.borrado = 0 "
                    + " and (comprobantes.id_comprobantes_tipo = 6 OR comprobantes.id_comprobantes_tipo = 7) "
                    + " and ((vw_usuarios_ctacte.Fecha_Desde >= @desde AND vw_usuarios_ctacte.Fecha_Hasta <= @hasta) "
                    + " OR vw_usuarios_ctacte.id_facturacion = @idFacturacion) "
                    + " GROUP BY vw_usuarios_ctacte.id order by usuarios.id ASC ) AS comprobantes WHERE tipo< 9");
                oCon.AsignarParametroEntero("@idFacturacion", idFac);
                oCon.AsignarParametroFecha("@desde", fechaDesde);
                oCon.AsignarParametroFecha("@hasta", fechaHasta);
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

        public DataTable GetComprobante(int idComprobante, int idUsuario = 0)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();

                string condicion = "";
                string tipoJoin = "";
                if (idUsuario != 0)
                {
                    condicion = " where usuarios.id = @usuario and comprobantes.borrado = 0 ";
                    tipoJoin = "INNER";
                }
                else
                {
                    condicion = " where comprobantes.id = @idx";
                    tipoJoin = "LEFT";
                }

                string consulta = " SELECT comprobantes.id, comprobantes.id_usuarios, comprobantes.id_comprobantes_tipo, comprobantes.id_puntos_de_cobro,"
                                + " comprobantes.id_personal, comprobantes.Id_Comprobantes_Iva, comprobantes.Id_Usuarios_Locaciones, comprobantes.id_punto_venta, comprobantes.fecha,"
                                + " comprobantes.numero,  if(comprobantes_tipo.presenta_Ventas = 1, iva_ventas.importe_final, usuarios_ctacte.importe_final ) as importe, comprobantes.descripcion, comprobantes.enviado, usuarios.apellido as usuarios_apellido,"
                                + " usuarios.nombre as usuarios_nombre,  CONCAT(usuarios.Apellido, ' ', usuarios.Nombre) AS usuario, usuarios.cuit as usuarios_cuit,"
                                + " comprobantes_tipo.nombre as comprobantes_tipo_nombre , comprobantes_tipo.letra as comprobantes_tipo_letra, "
                                + " comprobantes_tipo.presenta_ventas as comprobantes_tipo_presenta_ventas, puntos_cobros.Descripcion AS puntos_cobros_descripcion,"
                                + " puntos_cobros.Punto AS puntos_cobros_puntos, personal.Nombre AS personal_nombre, comprobantes_iva.Descripcion AS comprobantes_iva_descripcion,"
                                + " comprobantes_tipo.Letra AS comprobantes_tipo_letra, IF(ISNULL(localidades_calles.Nombre), 'NO ASIGNADO', localidades_calles.Nombre) as usuarios_locaciones_calle,"
                                + " usuarios_locaciones.Altura as usuarios_locaciones_altura, usuarios_locaciones.Piso as usuarios_locaciones_piso,"
                                + " usuarios_locaciones.Depto as usuarios_locaciones_depto, IF(ISNULL(localidades.Nombre), 'NO ASIGNADO', localidades.Nombre) AS usuarios_locaciones_localidad,"
                                + " puntos_venta.Descripcion AS puntos_venta_descripcion, puntos_venta.Numero AS puntos_venta_numero, comprobantes.Borrado AS borrado,"
                                + " comprobantes_tipo.codigo_afip,usuarios_ctacte_det.id_debito_asociado"
                                + " FROM comprobantes"
                                + " LEFT JOIN usuarios ON comprobantes.Id_Usuarios = usuarios.id"
                                + " LEFT JOIN comprobantes_tipo ON comprobantes.Id_Comprobantes_Tipo = comprobantes_tipo.Id"
                                + " LEFT JOIN puntos_cobros ON comprobantes.Id_Puntos_De_Cobro = puntos_cobros.Id"
                                + " LEFT JOIN personal ON comprobantes.Id_Personal = personal.Id"
                                + " LEFT JOIN comprobantes_iva ON comprobantes.Id_Comprobantes_Iva = comprobantes_iva.Id"
                                + " LEFT JOIN usuarios_locaciones ON comprobantes.Id_Usuarios_Locaciones = usuarios_locaciones.id"
                                + " LEFT JOIN localidades ON usuarios_locaciones.Id_Localidades = localidades.Id"
                                + " LEFT JOIN localidades_calles ON localidades_calles.id = usuarios_locaciones.id_localidades"
                                + " LEFT JOIN puntos_venta ON comprobantes.id_punto_venta = puntos_venta.Id"
                                + $" {tipoJoin} JOIN usuarios_ctacte on usuarios_ctacte.id_comprobantes = comprobantes.id"
                                + $" {tipoJoin} JOIN usuarios_ctacte_det on usuarios_ctacte_det.id_usuarios_ctacte = usuarios_ctacte.id"
                                + " LEFT JOIN iva_ventas on iva_ventas.id_comprobantes = comprobantes.id"
                                + $" {condicion}"
                                + " group by comprobantes.id"
                                + " order by comprobantes.fecha";

                oCon.CrearComando(consulta);
                if (idUsuario != 0)
                    oCon.AsignarParametroEntero("@usuario", idUsuario);
                else
                    oCon.AsignarParametroEntero("@idx", idComprobante);

                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
            }

            return dt;
        }


        public DataTable GetComprobanteHistorial(int idUsuario, int id_Locacion)
        {
            DataTable dt = new DataTable();

            oCon.Conectar();
            string condicion = "";

            /*string consulta = "select *, (select sum(importe_imputa)  from usuarios_ctacte_relacion where id_usuarios_ctacte=ctacte_id) as pago  " +
                "from(select comprobantes.descripcion as descripcion, iva_ventas.fecha as fecha_iva, iva_ventas.importe_final as importe_iva, " +
                "usuarios_ctacte.importe_final as ctacte_importe, " +
                "date(usuarios_ctacte.fecha_movimiento) as ctacte_fecha, date(usuarios_ctacte.fecha_hasta) as ctacte_hasta, " +
                "comprobantes.id as comprobantes_id, iva_ventas.id as ivaventas_id, " +
                "usuarios_ctacte.id as ctacte_id, usuarios_ctacte_recibos.id as recibos_id, " +
                "usuarios_ctacte.Id_comprobantes_tipo AS id_comprobantes_tipo_ctacte, " +
                "usuarios_ctacte_recibos.importe_recibo as recibos_importe, date(usuarios_ctacte_recibos.fecha_movimiento) as recibos_fecha, " +
                "usuarios_ctacte.borrado as ctacte_borrado, iva_ventas.cae, " +
                "iva_ventas.id_comprobantes_tipo, iva_ventas.numero as ivaventas_numero, iva_ventas.letra, " +
                "iva_ventas.borrado as ivaventas_borrado, usuarios_ctacte_recibos.borrado as recibos_borrado,usuarios_ctacte.Importe_Saldo as ctacte_Saldo, usuarios_ctacte.Fecha_desde as ctacte_desde " +
                "from comprobantes " +
                "left join iva_ventas on iva_ventas.id_comprobantes = comprobantes.id " +
                "left join usuarios_ctacte on usuarios_ctacte.id_comprobantes = comprobantes.id " +
                "left join usuarios_ctacte_recibos on usuarios_ctacte_recibos.id_comprobantes = comprobantes.id " +
                "where comprobantes.id_usuarios = @usuario AND usuarios_ctacte.Id_Usuarios_Locacion = @idLoc OR usuarios_ctacte_recibos.Id_Usuarios_Locaciones = @idLoc2 " +
                "and comprobantes.borrado = 0 order by comprobantes.id) as resultado";*/
            string consulta = "select *, (select sum(importe_imputa)  from usuarios_ctacte_relacion where id_usuarios_ctacte=ctacte_id) as pago  " +
                "from(select comprobantes.descripcion as descripcion, iva_ventas.fecha as fecha_iva, iva_ventas.importe_final as importe_iva, " +
                "usuarios_ctacte.importe_final as ctacte_importe, " +
                "date(usuarios_ctacte.fecha_movimiento) as ctacte_fecha, date(usuarios_ctacte.fecha_hasta) as ctacte_hasta, " +
                "comprobantes.id as comprobantes_id, iva_ventas.id as ivaventas_id, " +
                "usuarios_ctacte.id as ctacte_id, usuarios_ctacte_recibos.id as recibos_id, " +
                "usuarios_ctacte.Id_comprobantes_tipo AS id_comprobantes_tipo_ctacte, " +
                "usuarios_ctacte_recibos.importe_recibo as recibos_importe, date(usuarios_ctacte_recibos.fecha_movimiento) as recibos_fecha, " +
                "usuarios_ctacte.borrado as ctacte_borrado, iva_ventas.cae,	ifnull(usuarios_ctacte.Id_Usuarios_Locacion,0) AS id_locacion,comprobantes.Id_Usuarios_Locaciones AS id_locacion_comp, " +
                "iva_ventas.id_comprobantes_tipo, iva_ventas.numero as ivaventas_numero, iva_ventas.letra, " +
                "iva_ventas.borrado as ivaventas_borrado, usuarios_ctacte_recibos.borrado as recibos_borrado,usuarios_ctacte.Importe_Saldo as ctacte_Saldo, usuarios_ctacte.Fecha_desde as ctacte_desde " +
                "from comprobantes " +
                "left join iva_ventas on iva_ventas.id_comprobantes = comprobantes.id " +
                "left join usuarios_ctacte on usuarios_ctacte.id_comprobantes = comprobantes.id " +
                "left join usuarios_ctacte_recibos on usuarios_ctacte_recibos.id_comprobantes = comprobantes.id " +
                "where comprobantes.id_usuarios = @usuario " +
                "and comprobantes.borrado = 0 order by comprobantes.id) as resultado";

            oCon.CrearComando(consulta);

            oCon.AsignarParametroEntero("@usuario", idUsuario);
            //oCon.AsignarParametroEntero("@idLoc", id_Locacion);
            //oCon.AsignarParametroEntero("@idLoc2", id_Locacion);

            dt = oCon.Tabla();
            oCon.DesConectar();

            return dt;
        }
    
        public DataTable GetFechasAnterioresElimina(int idComprobante)
        {
            DataTable dt = new DataTable();
            DataTable dtFinal = new DataTable();
            DataTable dtDet = new DataTable();
            DataTable dtDetAnterior = new DataTable();
            int idCtacte = 0;
            int idDet = 0;
            int idUsuSer = 0;
            string fechaAnterior = "";
            string fechaInicio = "";
            string servicio;

            DataColumn dcServicio = new DataColumn
            {
                DataType = typeof(string),
                ColumnName = "servicio",
                DefaultValue = ""
            };
            DataColumn dcFechaAnterior = new DataColumn
            {
                DataType = typeof(string),
                ColumnName = "fecha_anterior",
                DefaultValue = new DateTime()
            };
            DataColumn dcFechaConexion = new DataColumn
            {
                DataType = typeof(string),
                ColumnName = "fecha_conexion",
                DefaultValue = new DateTime()
            };
            dtFinal.Columns.Add(dcServicio);
            dtFinal.Columns.Add(dcFechaAnterior);
            dtFinal.Columns.Add(dcFechaConexion);
            try
            {
                oCon.Conectar();
                oCon.CrearComando("select id from usuarios_ctacte where id_comprobantes = @comp");
                oCon.AsignarParametroEntero("@comp", idComprobante);
                dt = oCon.Tabla();
                if(dt.Rows.Count>0)
                {
                    idCtacte = Convert.ToInt32(dt.Rows[0]["id"]);
                    oCon.CrearComando("select usuarios_ctacte_det.id, usuarios_ctacte_det.id_usuarios_servicios,servicios.descripcion as servicio,usuarios_servicios.fecha_inicio from usuarios_ctacte_det " +
                        "left join usuarios_servicios on usuarios_servicios.id =usuarios_ctacte_det.id_usuarios_servicios  " +
                        "left join servicios on servicios.id =usuarios_servicios.id_servicios  " +
                        "where id_usuarios_ctacte=@ctacte group by id_usuarios_servicios");
                    oCon.AsignarParametroEntero("@ctacte", idCtacte);
                    dtDet = oCon.Tabla();
                    if(dtDet.Rows.Count>0)
                    {

                        foreach (DataRow item in dtDet.Rows)
                        {
                            fechaAnterior = "";
                            fechaInicio ="";
                            servicio = item["servicio"].ToString();
                            idUsuSer = Convert.ToInt32(item["id_usuarios_servicios"]);
                            oCon.CrearComando("select id,fecha_hasta from usuarios_ctacte_det where id_usuarios_servicios=@usu_ser and id_usuarios_ctacte!=@ctacte and usuarios_ctacte_det.borrado=0 order by fecha_hasta desc limit 1  ");
                            oCon.AsignarParametroEntero("@usu_ser", idUsuSer);
                            oCon.AsignarParametroEntero("@ctacte", idCtacte);
                            dtDetAnterior = oCon.Tabla();
                            if (dtDetAnterior.Rows.Count > 0)
                            {
                                fechaAnterior = Convert.ToDateTime(dtDetAnterior.Rows[0]["fecha_hasta"]).ToShortDateString();
                                fechaInicio = "";
                            }
                            else
                            {
                                fechaInicio = Convert.ToDateTime(item["fecha_inicio"]).ToShortDateString();
                                fechaAnterior = "";
                            }

                            dtFinal.Rows.Add(servicio, fechaAnterior,fechaInicio);
                        }
                    }

                }
                oCon.DesConectar();
            }
            catch (Exception c)
            {
                oCon.DesConectar();
            }
            
            return dtFinal;
        }

        public DataTable ListarOrigenComprobantes()
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT id,nombre FROM comprobantes_origen");
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception C)
            {
                oCon.DesConectar();
            }
          
            return dt;
        }

        public DataTable ListarComprobantesGenerados(int idOrigen,int facPres,DateTime desde,DateTime hasta,int idTipoCom,int codUsuario)
        {

            DataTable dt = new DataTable();
            string consulta = "";
            string agrupa = "";
            try
            {
                oCon.Conectar();
                consulta= "select date(usuarios_ctacte.fecha_movimiento) as fecha,personal.Nombre as personal, usuarios_ctacte.Descripcion, usuarios_ctacte.Importe_final, usuarios.codigo, CONCAT(usuarios.Apellido,',',usuarios.Nombre) as abonado,usuarios_ctacte.rechazado, usuarios_ctacte_det.id_estado_debito"
                + " from usuarios_ctacte "
                 + "left join usuarios on usuarios.Id = usuarios_ctacte.Id_Usuarios"
                + " left join usuarios_ctacte_det on usuarios_ctacte_det.Id_Usuarios_CtaCte = usuarios_ctacte.Id"
                + " left join personal on personal.id = usuarios_ctacte.Id_Personal"
                + " where usuarios_ctacte.borrado=0";

                //armo los filtros de la consulta
                if (idOrigen == 0)
                    consulta = consulta + " and usuarios_ctacte.id_origen>0 ";
                else
                    consulta = consulta + string.Format(" and usuarios_ctacte.id_origen ={0}",idOrigen);

                if (idOrigen == (int)Usuarios_CtaCte.ORIGEN.FACTURACION_MENSUAL)
                    consulta = consulta + string.Format(" and usuarios_ctacte.id_facturacion={0}", facPres);
                
                if (idOrigen == (int)Usuarios_CtaCte.ORIGEN.FACTURACION_MENSUAL_DEBITOS)
                    consulta = consulta + string.Format(" and usuarios_ctacte_det.id_presentacion={0} ", facPres);
               
                if (idTipoCom > 0)
                    consulta = consulta + string.Format(" and usuarios_ctacte.id_comprobantes_tipo={0} ", idTipoCom);
                else
                    consulta = consulta + " and (usuarios_ctacte.id_comprobantes_tipo=1 or usuarios_ctacte.id_comprobantes_tipo=2 or usuarios_ctacte.id_comprobantes_tipo=7)  ";

                if (codUsuario > 0)
                    consulta = consulta + string.Format(" and usuarios.codigo = {0} ", codUsuario);
                else
                    consulta = consulta + " and usuarios.codigo > 0 ";
                //asigno los parametros fecha

                if (idOrigen != (int)Usuarios_CtaCte.ORIGEN.FACTURACION_MENSUAL && idOrigen != (int)Usuarios_CtaCte.ORIGEN.FACTURACION_MENSUAL_DEBITOS)
                    consulta = consulta +string.Format(" and date(usuarios_ctacte.fecha_movimiento)>date('{0}') AND date(usuarios_ctacte.fecha_movimiento)<date('{1}') ", desde.ToString("yyyy-MM-dd"), hasta.ToString("yyyy-MM-dd"));
               agrupa = " group by usuarios_ctacte.id order by usuarios.codigo asc";
               consulta = consulta + agrupa;
               oCon.CrearComando(consulta);
               dt = oCon.Tabla();
               oCon.DesConectar();
            }
            catch (Exception C)
            {
                oCon.DesConectar();
            }

            return dt;
        }

    }
}
