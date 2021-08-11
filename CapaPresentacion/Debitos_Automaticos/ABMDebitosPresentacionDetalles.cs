//modificación 130919-12:54
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CapaNegocios;
using System.Threading;
using System.Collections.Generic;

namespace CapaPresentacion.Abms
{
    public partial class ABMDebitosPresentacionDetalles : Form
    {
        public enum TAREA
        {
            CREACION_PRESENTACION = 1,
            CONSULTA_PRESENTACION = 2
        }
        public DataTable dtPlasticosPresentacion, dtUsuariosServiciosSubPlasticos, dtDeudasAnexadas, dtPlasticoDetalles;
        Thread hilo;
        delegate void myDel();
        Presentacion_Debitos oPresentacionDebitos = new Presentacion_Debitos();
        DateTime fechaPresentacion = new DateTime();
        DialogResult dialogResult = new DialogResult();
        int funcionARealizar = 0;
        int idFormaPago = 0;
        decimal montoTotalServicio = 0;
        decimal montoTotalDeudaAtrasada = 0;
        decimal montoTotalDeudaAdelantada = 0;
        decimal montoTotalDebito = 0;
        decimal montoTotalPresentacion = 0;
        decimal totalPagado = 0;
        bool calculaCorrectamente = false;
        DataView dtvUsuariosServiciosSub;
        DataTable dtDatosUsuario = new DataTable();
        DataTable dtUsuariosServiciosSub = new DataTable();
        DataTable dtUsuariosServiciosSubABonificar = new DataTable();
        Usuarios oUsuarios = new Usuarios();
        Facturacion oFacturacion = new Facturacion();
        Servicios_Tarifas oServiciosTarifas = new Servicios_Tarifas();
        int idTarifaActual = 0;
        Bonificaciones oBonificaciones = new Bonificaciones();
        Presentacion_Usuarios_Servicios oPresentacionUsuariosServicios = new Presentacion_Usuarios_Servicios();
        private DataTable dtUsuariosServiciosPlasticos = new DataTable();
        List<int> listaUsuariosCalculoBonificacion = new List<int>();
        List<int> listaUsuariosServiciosDeudaAdelantada = new List<int>();
        List<int> listaIndicesDebitosEliminar = new List<int>();
        Tools oTools = new Tools();
        Presentacion_Plasticos oPresentacionPlasticos = new Presentacion_Plasticos();
        int idPresentacionExistente = 0;
        int contadorParcial, total;
        private DataTable dtErroresProducidos = new DataTable();
        private Usuarios_CtaCte_Det oUsuariosCtaCteDet = new Usuarios_CtaCte_Det();

        private void ComenzarCarga()
        {
            pgCircular.Location = new Point(
                           this.ClientSize.Width / 2 - pgCircular.Size.Width / 2,
                           this.ClientSize.Height / 2 - pgCircular.Size.Height / 2);
            pgCircular.Visible = true;
            pgCircular.Start();
            hilo = new Thread(new ThreadStart(CargarDatos));
            hilo.IsBackground = true;
            hilo.Start();
        }

        private void CargarDatos(){
            try
            {
                if (funcionARealizar == Convert.ToInt16(TAREA.CREACION_PRESENTACION)){
                    int idUsuario = 0;
                    bool agregarServicioAPresentacion = false;
                    DataTable dtAux = new DataTable();
                    DataTable dtRegistrosCtaCteDetDeudas = new DataTable();
                    dtDeudasAnexadas = oPresentacionDebitos.GetEstructuraPresentacionDeudasAnexadas();
                    oServiciosTarifas.Fecha_Actual = fechaPresentacion;
                    idTarifaActual = oServiciosTarifas.getTarifa();
                    dtUsuariosServiciosSubPlasticos = oPresentacionUsuariosServicios.GetEstructuraPresentacionUsuariosServiciosSub();
                    listaUsuariosCalculoBonificacion.Clear();

                    listaIndicesDebitosEliminar.Clear();
                    
                    //listando debitos y servicios
                    for (int x = 0; x < dtPlasticosPresentacion.Rows.Count; x++){//lista los servicios que cada débito tiene asociado y los coloca todos en un datatable
                        dtAux.Clear();
                        dtAux = oPresentacionDebitos.ListarUsuariosServiciosDelDebito(Convert.ToInt32(dtPlasticosPresentacion.Rows[x]["id_plastico"]), fechaPresentacion);
                        if (dtUsuariosServiciosPlasticos.Rows.Count == 0)
                            dtUsuariosServiciosPlasticos = dtAux.Clone();

                        if (dtAux.Rows.Count > 0){
                            foreach (DataRow usuarioServicio in dtAux.Rows){
                                agregarServicioAPresentacion = false;
                                dtRegistrosCtaCteDetDeudas.Clear();
                                idUsuario = Convert.ToInt32(usuarioServicio["id_usuarios"]);
                                if (Convert.ToDateTime(usuarioServicio["fecha_factura_usuario_servicio"]) < fechaPresentacion){//se calcula monto estimado, la deuda se genera en prefacturación
                                    if (listaUsuariosCalculoBonificacion.Contains(idUsuario) == false)
                                        listaUsuariosCalculoBonificacion.Add(idUsuario);
                                    agregarServicioAPresentacion = true;
                                }else{//se busca deuda adelantada
                                    dtRegistrosCtaCteDetDeudas = oPresentacionDebitos.RetornarDeudasPosterioresDelServicio(fechaPresentacion, Convert.ToInt32(usuarioServicio["id_usuarios_servicios"]));
                                    if (dtRegistrosCtaCteDetDeudas.Rows.Count > 0){
                                        foreach (DataRow deuda in dtRegistrosCtaCteDetDeudas.Rows){
                                            if (dtDeudasAnexadas.Select(String.Format("id_usuarios_ctacte_det={0}", deuda["id"].ToString())).Count() == 0)
                                            {
                                                dtDeudasAnexadas.Rows.Add(0, Convert.ToInt32(dtPlasticosPresentacion.Rows[x]["id_plastico"]), 0, Convert.ToInt32(deuda["id_usuarios_locaciones"]), Convert.ToInt32(usuarioServicio["id_usuarios_servicios"]), Convert.ToInt32(deuda["id_usuarios_servicios_sub"]), Convert.ToInt32(deuda["id_comprobantes"]), Convert.ToInt32(deuda["id_usuarios_ctacte"]), Convert.ToInt32(deuda["id"]), Convert.ToInt16(Presentacion_Usuarios_Servicios.TIPO_DEUDA.DEUDA_ADELANTANDA), deuda["detalles"], deuda["comprobantes_descripcion"], deuda["fecha_desde"], deuda["fecha_hasta"], deuda["importe_saldo"], deuda["id_usuarios"], 0, "");
                                                oUsuariosCtaCteDet.ActualizarDebitoPresentacion(0, 0, Convert.ToInt32(deuda["id"]), Convert.ToInt32(dtPlasticosPresentacion.Rows[x]["id_plastico"]), fechaPresentacion.Month, fechaPresentacion.Year);
                                            }
                                        }
                                        agregarServicioAPresentacion = true;
                                    if (listaUsuariosServiciosDeudaAdelantada.Contains(idUsuario) == false)
                                        listaUsuariosServiciosDeudaAdelantada.Add(idUsuario);
                                }
                                }
                                dtRegistrosCtaCteDetDeudas.Clear();
                                //---se busca deudas atrasadas
                                dtRegistrosCtaCteDetDeudas = oPresentacionDebitos.RetornarDeudasAdicionales(fechaPresentacion, Convert.ToInt32(usuarioServicio["id_usuarios_servicios"]), Convert.ToInt32(dtPlasticosPresentacion.Rows[x]["id_plastico"]));
                                if (dtRegistrosCtaCteDetDeudas.Rows.Count > 0){
                                    foreach (DataRow deuda in dtRegistrosCtaCteDetDeudas.Rows){
                                        if (dtDeudasAnexadas.Select(String.Format("id_usuarios_ctacte_det={0}", deuda["id"].ToString())).Count() == 0)
                                            dtDeudasAnexadas.Rows.Add(0, Convert.ToInt32(dtPlasticosPresentacion.Rows[x]["id_plastico"]), 0, Convert.ToInt32(deuda["id_usuarios_locaciones"]), Convert.ToInt32(usuarioServicio["id_usuarios_servicios"]), Convert.ToInt32(usuarioServicio["id_usuarios_servicios_sub"]), Convert.ToInt32(deuda["id_comprobantes"]), Convert.ToInt32(deuda["id_usuarios_ctacte"]), Convert.ToInt32(deuda["id"]), Convert.ToInt16(Presentacion_Usuarios_Servicios.TIPO_DEUDA.DEUDA_ATRASADA), deuda["detalles"], deuda["comprobantes_descripcion"], deuda["fecha_desde"], deuda["fecha_hasta"], deuda["importe_saldo"], deuda["id_usuarios"], 0, "");
                                    }
                                    agregarServicioAPresentacion = true;
                                    if(agregarServicioAPresentacion && listaUsuariosCalculoBonificacion.Contains(idUsuario) == false && listaUsuariosServiciosDeudaAdelantada.Contains(idUsuario))
                                        listaUsuariosServiciosDeudaAdelantada.Add(idUsuario);
                                }
                                if (agregarServicioAPresentacion)
                                    dtUsuariosServiciosPlasticos.ImportRow(usuarioServicio);
                            }
                            dtRegistrosCtaCteDetDeudas.Clear();
                            //---se busca deudas adicionales
                            dtRegistrosCtaCteDetDeudas = oPresentacionDebitos.RetornarDeudasAdicionales(fechaPresentacion, 0, Convert.ToInt32(dtPlasticosPresentacion.Rows[x]["id_plastico"]));
                            if (dtRegistrosCtaCteDetDeudas.Rows.Count > 0){
                                foreach (DataRow deuda in dtRegistrosCtaCteDetDeudas.Rows){
                                    if (dtDeudasAnexadas.Select(String.Format("id_usuarios_ctacte_det={0}", deuda["id"].ToString())).Count() == 0)
                                        dtDeudasAnexadas.Rows.Add(0, Convert.ToInt32(dtPlasticosPresentacion.Rows[x]["id_plastico"]), 0, Convert.ToInt32(deuda["id_usuarios_locaciones"]), Convert.ToInt32(deuda["id_usuarios_servicios"]), Convert.ToInt32(deuda["id_usuarios_servicios_sub"]), Convert.ToInt32(deuda["id_comprobantes"]), Convert.ToInt32(deuda["id_usuarios_ctacte"]), Convert.ToInt32(deuda["id"]), Convert.ToInt16(Presentacion_Usuarios_Servicios.TIPO_DEUDA.DEUDA_ADICIONAL), deuda["detalles"], deuda["comprobantes_descripcion"], deuda["fecha_desde"], deuda["fecha_hasta"], deuda["importe_saldo"], deuda["id_usuarios"], 0, "");
                                }
                            }
                        }
                        else
                            listaIndicesDebitosEliminar.Add(x);
                    }

                    //quitando débitos sin servicios adheridos
                    foreach (int indicePlastico in listaIndicesDebitosEliminar)//elimina de la tabla de plásticos aquellos que no tienen servicios asociados
                        dtPlasticosPresentacion.Rows.RemoveAt(indicePlastico);

                    //consultandosubservicios
                    dtUsuariosServiciosSub.Clear();
                    foreach (int idUsuarioConBonificacion in listaUsuariosCalculoBonificacion){
                        dtAux.Clear();
                        dtAux =oPresentacionDebitos.RetornarSubServicios(idTarifaActual, idUsuarioConBonificacion, 0, 0, oPresentacionDebitos.Fecha_Presentacion, false, true);
                        if (dtUsuariosServiciosSub.Rows.Count == 0)
                            dtUsuariosServiciosSub = dtAux.Clone();
                        if (dtAux.Rows.Count > 0){
                            foreach (DataRow subservicio in dtAux.Rows)
                                dtUsuariosServiciosSub.ImportRow(subservicio);
                        }
                        oFacturacion.AgregarSubServiciosHeredados(dtUsuariosServiciosSub, idUsuarioConBonificacion);
                    }

                    //listandodeudas adelantandas
                    foreach(int idUsuarioServicioDeudaAdelantada in listaUsuariosServiciosDeudaAdelantada){
                        dtAux.Clear();
                        dtAux = oPresentacionDebitos.RetornarSubServicios(idTarifaActual, idUsuarioServicioDeudaAdelantada, 0, 0, oPresentacionDebitos.Fecha_Presentacion, false, true);
                        if (dtUsuariosServiciosSub.Rows.Count == 0)
                            dtUsuariosServiciosSub = dtAux.Clone();
                        if (dtAux.Rows.Count > 0){
                            foreach (DataRow subservicio in dtAux.Rows)
                                dtUsuariosServiciosSub.ImportRow(subservicio);
                        }
                    }


                    if (dtUsuariosServiciosPlasticos.Rows.Count > 0){
                        foreach (DataRow usuarioServicio in dtUsuariosServiciosPlasticos.Rows){
                            montoTotalServicio = 0;
                            montoTotalDeudaAtrasada = 0;
                            montoTotalDeudaAdelantada = 0;
                            calculaCorrectamente = false;
                            dtDatosUsuario.Clear();
                            dtUsuariosServiciosSubABonificar.Clear();
                            dtDatosUsuario = oUsuarios.Listar(Convert.ToInt32(usuarioServicio["id_usuarios"]));
                            dtvUsuariosServiciosSub = new DataView(dtUsuariosServiciosSub);

                            dtvUsuariosServiciosSub.RowFilter = String.Format("id_usuarios={0}", usuarioServicio["id_usuarios"].ToString());

                            if (Convert.ToDecimal(usuarioServicio["monto_deuda_adelantada"]) == 0){
                                if (Convert.ToInt32(dtDatosUsuario.Rows[0]["calculo_bonificacion"]) != Convert.ToInt32(Usuarios._Calculo_Bonificacion.POR_USUARIO)){
                                    if (Convert.ToInt32(dtDatosUsuario.Rows[0]["calculo_bonificacion"]) == Convert.ToInt32(Usuarios._Calculo_Bonificacion.POR_LOCACION))
                                        dtvUsuariosServiciosSub.RowFilter = String.Format("id_locacion={0} and id_usuarios={1}", usuarioServicio["id_locacion"].ToString(), usuarioServicio["id_usuarios"].ToString());
                                    else
                                        dtvUsuariosServiciosSub.RowFilter = String.Format("id_usuarios_servicios={0} and heredado=0", usuarioServicio["id_usuarios_servicios"].ToString());
                                }
                                dtUsuariosServiciosSubABonificar = dtvUsuariosServiciosSub.ToTable();
                                if (Convert.ToInt32(dtDatosUsuario.Rows[0]["calculo_bonificacion"]) != Convert.ToInt32(Usuarios._Calculo_Bonificacion.NO_SE_APLICA))
                                    calculaCorrectamente = oBonificaciones.CalcularBonificaciones(dtUsuariosServiciosSubABonificar, idTarifaActual, false,0,false);
                            }else
                                dtUsuariosServiciosSubABonificar = dtvUsuariosServiciosSub.ToTable();

                            if ((Convert.ToInt32(dtDatosUsuario.Rows[0]["calculo_bonificacion"]) != Convert.ToInt32(Usuarios._Calculo_Bonificacion.NO_SE_APLICA) && calculaCorrectamente) || dtUsuariosServiciosSubABonificar.Rows.Count > 0){
                                foreach (DataRow subServicio in dtUsuariosServiciosSubABonificar.Select(String.Format("id_usuario_servicio={0} and heredado=0", usuarioServicio["id_usuarios_servicios"].ToString()))){
                                    
                                    decimal montoAdelantado, montoAtrasado, montoEstimado, montoTotal;
                                    montoAdelantado = 0;
                                    montoAtrasado = 0;
                                    montoEstimado = 0;
                                    montoTotal = 0;
                                
                                    
                                    DataRow[] drDeudasSubServicio = dtDeudasAnexadas.Select(String.Format("id_usuarios_servicios_sub={0}", subServicio["id_usuario_servicio_sub"].ToString()));
                                    if (drDeudasSubServicio.Count() > 0){
                                        foreach(DataRow deudaSubServicio in drDeudasSubServicio){
                                            if (Convert.ToInt16(deudaSubServicio["tipo_deuda"]) == Convert.ToInt16(Presentacion_Usuarios_Servicios.TIPO_DEUDA.DEUDA_ADELANTANDA))
                                                montoAdelantado += Convert.ToDecimal(deudaSubServicio["total"]);
                                            else if(Convert.ToInt16(deudaSubServicio["tipo_deuda"]) == Convert.ToInt16(Presentacion_Usuarios_Servicios.TIPO_DEUDA.DEUDA_ATRASADA))
                                                montoAtrasado += Convert.ToDecimal(deudaSubServicio["total"]);
                                        }
                                    }

                                    if(montoAdelantado==0)
                                        montoEstimado= Convert.ToDecimal(subServicio["importe_con_descuento"]);

                                montoTotal = montoAdelantado + montoAtrasado + montoEstimado;
                                    dtUsuariosServiciosSubPlasticos.Rows.Add("0", "0", usuarioServicio["id_plastico"], usuarioServicio["id_usuarios_servicios"], subServicio["id_usuario_servicio_sub"], subServicio["subservicio"], montoAtrasado, montoEstimado, 0, montoAdelantado, montoTotal);
                                    if(montoAdelantado==0)
                                        montoTotalServicio += Convert.ToDecimal(montoEstimado);
                                    montoTotalDeudaAtrasada += montoAtrasado;
                                    montoTotalDeudaAdelantada += montoAdelantado;
                                }
                            }

                            usuarioServicio["monto_estimado"] = Decimal.Round(montoTotalServicio, 2).ToString();
                            usuarioServicio["monto_deuda_atrasada"] = Decimal.Round(montoTotalDeudaAtrasada, 2).ToString();
                            usuarioServicio["monto_deuda_adelantada"] = Decimal.Round(montoTotalDeudaAdelantada, 2).ToString();
                            usuarioServicio["total"] = Decimal.Round((montoTotalServicio + montoTotalDeudaAtrasada + montoTotalDeudaAdelantada), 2).ToString();

                            dtPlasticoDetalles.Rows.Add(usuarioServicio["id_plastico"], String.Format("{0} - {1}", usuarioServicio["codigo_usuario"], usuarioServicio["usuario"]), usuarioServicio["servicio"], usuarioServicio["monto_deuda_atrasada"], usuarioServicio["monto_estimado"] , usuarioServicio["monto_prefacturacion"], usuarioServicio["monto_deuda_adelantada"], "1");

                            foreach (DataRow subservicio in dtUsuariosServiciosSubPlasticos.Select(String.Format("id_usuarios_servicios={0}", usuarioServicio["id_usuarios_servicios"].ToString())))
                                dtPlasticoDetalles.Rows.Add(usuarioServicio["id_plastico"], "", "   " + subservicio["servicio_sub"].ToString(), subservicio["monto_deuda_atrasada"], subservicio["monto_estimado"], subservicio["monto_prefacturacion"], subservicio["monto_deuda_adelantada"], "2");
                        }

                        foreach (DataRow debito in dtPlasticosPresentacion.Rows){
                            decimal monto_estimado = 0;
                            decimal monto_atrasado = 0;
                            decimal monto_adelantado = 0;
                            foreach (DataRow usuarioServicio in dtUsuariosServiciosPlasticos.Select(String.Format("id_plastico={0}", debito["id_plastico"]))){
                                monto_atrasado += Decimal.Round(Convert.ToDecimal(usuarioServicio["monto_deuda_atrasada"]));
                                monto_estimado += Decimal.Round(Convert.ToDecimal(usuarioServicio["monto_estimado"]));
                                monto_adelantado+= Decimal.Round(Convert.ToDecimal(usuarioServicio["monto_deuda_adelantada"]));
                            }
                            foreach(DataRow deudaAnexada in dtDeudasAnexadas.Select(String.Format("tipo_deuda={0} and id_plastico={1}", Convert.ToInt16(Presentacion_Usuarios_Servicios.TIPO_DEUDA.DEUDA_ADICIONAL),debito["id_plastico"].ToString())))
                                monto_atrasado += Decimal.Round(Convert.ToDecimal(deudaAnexada["total"]));
                            
                            debito["monto_deuda_atrasada"] = monto_atrasado;
                            debito["monto_estimado"] = monto_estimado;
                            debito["monto_deuda_adelantada"] = monto_adelantado;
                            debito["total"] = monto_atrasado + monto_estimado + monto_adelantado;
                        }
                    }
                    else
                        MessageBox.Show("No hay servicios asociados a los débitos o los débitos presentes no poseen servicios asociados.");
                }
            else{
                    DataColumn DcQuitar = new DataColumn("quitar", typeof(Boolean));
                    DcQuitar.DefaultValue = false;
                    dtPlasticosPresentacion.Columns.Add(DcQuitar);



                    dtUsuariosServiciosPlasticos = oPresentacionUsuariosServicios.Listar(oPresentacionDebitos.Id,0);
                dtUsuariosServiciosSubPlasticos = oPresentacionUsuariosServicios.ListarPlasticosSubServicios(oPresentacionDebitos.Id,0);
                
                dtDeudasAnexadas = oPresentacionUsuariosServicios.ListarDeudasAnexadas(oPresentacionDebitos.Id);

                foreach (DataRow usuarioServicio in dtUsuariosServiciosPlasticos.Rows)
                {
                    dtPlasticoDetalles.Rows.Add(usuarioServicio["id_plastico"], String.Format("{0} - {1}", usuarioServicio["codigo_usuario"], usuarioServicio["usuario"]), usuarioServicio["servicio"], usuarioServicio["monto_deuda_atrasada"], usuarioServicio["monto_estimado"], usuarioServicio["monto_prefacturacion"], usuarioServicio["monto_deuda_adelantada"], "1");

                    foreach (DataRow subservicio in dtUsuariosServiciosSubPlasticos.Select(String.Format("id_usuarios_servicios={0}", usuarioServicio["id_usuarios_servicios"])))
                        dtPlasticoDetalles.Rows.Add(usuarioServicio["id_plastico"], "", "   " + subservicio["servicio_sub"].ToString(), subservicio["monto_deuda_atrasada"], subservicio["monto_estimado"], subservicio["monto_prefacturacion"], subservicio["monto_deuda_adelantada"], "2");
                }
            }

                myDel MD = new myDel(AsignarDatos);
                this.Invoke(MD, new object[] { });
                pgCircular.Stop();

            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
            }
        }
        
        //generar datos
        private void ListarDebitosYServiciosAdheridos(object o, DoWorkEventArgs e){
            try
            {
                DataColumn DcIdUsuario = new DataColumn("id_usuario", typeof(string));
                DcIdUsuario.DefaultValue = "0";
                dtPlasticosPresentacion.Columns.Add(DcIdUsuario);
                DataColumn DcCodUsuario = new DataColumn("codigo_usuario", typeof(string));
                DcCodUsuario.DefaultValue = "0";
                dtPlasticosPresentacion.Columns.Add(DcCodUsuario);

                dtDeudasAnexadas = oPresentacionDebitos.GetEstructuraPresentacionDeudasAnexadas();
            oServiciosTarifas.Fecha_Actual = fechaPresentacion;
            idTarifaActual = oServiciosTarifas.getTarifa();
            dtUsuariosServiciosSubPlasticos = oPresentacionUsuariosServicios.GetEstructuraPresentacionUsuariosServiciosSub();
            listaUsuariosCalculoBonificacion.Clear();

            listaIndicesDebitosEliminar.Clear();

            
                int idUsuario = 0;
                bool agregarServicioAPresentacion = false;
                decimal montoPercepcion = 0, montoPercepcionTotal=0;
                DataTable dtAux = new DataTable();
                DataTable dtRegistrosCtaCteDetDeudas = new DataTable();
                for (int x = 0; x < dtPlasticosPresentacion.Rows.Count; x++)
                {//lista los servicios que cada débito tiene asociado y los coloca todos en un datatable
                    dtAux.Clear();
                    dtAux = oPresentacionDebitos.ListarUsuariosServiciosDelDebito(Convert.ToInt32(dtPlasticosPresentacion.Rows[x]["id_plastico"]), fechaPresentacion);
                    if (dtUsuariosServiciosPlasticos.Rows.Count == 0)
                        dtUsuariosServiciosPlasticos = dtAux.Clone();
                    if (dtAux.Rows.Count > 0)
                    {
                        dtPlasticosPresentacion.Rows[x]["id_usuario"] = dtAux.Rows[0]["id_usuarios"].ToString();
                        dtPlasticosPresentacion.Rows[x]["codigo_usuario"] = dtAux.Rows[0]["codigo_usuario"].ToString();
                        foreach (DataRow usuarioServicio in dtAux.Rows)
                        {

                            agregarServicioAPresentacion = false;
                            dtRegistrosCtaCteDetDeudas.Clear();
                            idUsuario = Convert.ToInt32(usuarioServicio["id_usuarios"]);
                            if (Convert.ToDateTime(usuarioServicio["fecha_factura_usuario_servicio"]) < fechaPresentacion)
                            {//se calcula monto estimado, la deuda se genera en prefacturación
                                if (listaUsuariosCalculoBonificacion.Contains(idUsuario) == false)
                                    listaUsuariosCalculoBonificacion.Add(idUsuario);
                                agregarServicioAPresentacion = true;
                            }
                            else
                            {//se busca deuda adelantada
                                dtRegistrosCtaCteDetDeudas = oPresentacionDebitos.RetornarDeudasPosterioresDelServicio(fechaPresentacion, Convert.ToInt32(usuarioServicio["id_usuarios_servicios"]));
                                if (dtRegistrosCtaCteDetDeudas.Rows.Count > 0)
                                {
                                    foreach (DataRow deuda in dtRegistrosCtaCteDetDeudas.Rows)
                                    {
                                        if (dtDeudasAnexadas.Select(String.Format("id_usuarios_ctacte_det='{0}'", deuda["id"].ToString())).Count() == 0)
                                        {
                                            oUsuariosCtaCteDet.ActualizarDebitoPresentacion(0, 0, Convert.ToInt32(deuda["id"]), Convert.ToInt32(dtPlasticosPresentacion.Rows[x]["id_plastico"]), fechaPresentacion.Month, fechaPresentacion.Year);
                                            montoPercepcion = 0;
                                            montoPercepcion=oPresentacionDebitos.CalcularPercepcionDetalle(Convert.ToInt32(deuda["id"]), Convert.ToInt32(deuda["id_usuarios"]), Convert.ToInt32(deuda["id_comprobantes"]),Convert.ToDecimal(deuda["importe_saldo"]));
                                            
                                            montoPercepcionTotal = Convert.ToDecimal(deuda["importe_saldo"]) + montoPercepcion;
                                            dtDeudasAnexadas.Rows.Add(0, Convert.ToInt32(dtPlasticosPresentacion.Rows[x]["id_plastico"]), 0, Convert.ToInt32(deuda["id_usuarios_locaciones"]), Convert.ToInt32(usuarioServicio["id_usuarios_servicios"]), Convert.ToInt32(deuda["id_usuarios_servicios_sub"]), Convert.ToInt32(deuda["id_comprobantes"]), Convert.ToInt32(deuda["id_usuarios_ctacte"]), Convert.ToInt32(deuda["id"]), Convert.ToInt16(Presentacion_Usuarios_Servicios.TIPO_DEUDA.DEUDA_ADELANTANDA), deuda["detalles"], deuda["comprobantes_descripcion"], deuda["fecha_desde"], deuda["fecha_hasta"], montoPercepcionTotal.ToString(), deuda["id_usuarios"], 0, "");
                                        }
                                    }
                                    agregarServicioAPresentacion = true;
                                    if (listaUsuariosServiciosDeudaAdelantada.Contains(idUsuario) == false)
                                        listaUsuariosServiciosDeudaAdelantada.Add(idUsuario);
                                }
                            }
                            dtRegistrosCtaCteDetDeudas.Clear();
                            //---se busca deudas atrasadas
                            dtRegistrosCtaCteDetDeudas = oPresentacionDebitos.RetornarDeudasAdicionales(fechaPresentacion, Convert.ToInt32(usuarioServicio["id_usuarios_servicios"]), Convert.ToInt32(dtPlasticosPresentacion.Rows[x]["id_plastico"]));
                            if (dtRegistrosCtaCteDetDeudas.Rows.Count > 0)
                            {
                                foreach (DataRow deuda in dtRegistrosCtaCteDetDeudas.Rows)
                                {
                                    if (dtDeudasAnexadas.Select(String.Format("id_usuarios_ctacte_det='{0}'", deuda["id"].ToString())).Count() == 0)
                                    {
                                        montoPercepcion = 0;
                                        montoPercepcion = oPresentacionDebitos.CalcularPercepcionDetalle(Convert.ToInt32(deuda["id"]), Convert.ToInt32(deuda["id_usuarios"]), Convert.ToInt32(deuda["id_comprobantes"]), Convert.ToDecimal(deuda["importe_saldo"]));

                                        montoPercepcionTotal = Convert.ToDecimal(deuda["importe_saldo"]) + montoPercepcion;
                                        dtDeudasAnexadas.Rows.Add(0, Convert.ToInt32(dtPlasticosPresentacion.Rows[x]["id_plastico"]), 0, Convert.ToInt32(deuda["id_usuarios_locaciones"]), Convert.ToInt32(usuarioServicio["id_usuarios_servicios"]), Convert.ToInt32(deuda["id_usuarios_servicios_sub"]), Convert.ToInt32(deuda["id_comprobantes"]), Convert.ToInt32(deuda["id_usuarios_ctacte"]), Convert.ToInt32(deuda["id"]), Convert.ToInt16(Presentacion_Usuarios_Servicios.TIPO_DEUDA.DEUDA_ATRASADA), deuda["detalles"], deuda["comprobantes_descripcion"], deuda["fecha_desde"], deuda["fecha_hasta"], montoPercepcionTotal.ToString(), deuda["id_usuarios"], 0, "");
                                    }
                                }
                                agregarServicioAPresentacion = true;
                                if (agregarServicioAPresentacion && listaUsuariosCalculoBonificacion.Contains(idUsuario) == false && listaUsuariosServiciosDeudaAdelantada.Contains(idUsuario))
                                    listaUsuariosServiciosDeudaAdelantada.Add(idUsuario);
                            }
                            if (agregarServicioAPresentacion)
                                dtUsuariosServiciosPlasticos.ImportRow(usuarioServicio);
                        }
                        dtRegistrosCtaCteDetDeudas.Clear();
                        //---se busca deudas adicionales
                        dtRegistrosCtaCteDetDeudas = oPresentacionDebitos.RetornarDeudasAdicionales(fechaPresentacion, 0, Convert.ToInt32(dtPlasticosPresentacion.Rows[x]["id_plastico"]));
                        if (dtRegistrosCtaCteDetDeudas.Rows.Count > 0)
                        {
                            foreach (DataRow deuda in dtRegistrosCtaCteDetDeudas.Rows)
                            {
                                if (dtDeudasAnexadas.Select(String.Format("id_usuarios_ctacte_det='{0}'", deuda["id"].ToString())).Count() == 0)
                                {
                                    montoPercepcion = 0;
                                    montoPercepcion = oPresentacionDebitos.CalcularPercepcionDetalle(Convert.ToInt32(deuda["id"]), Convert.ToInt32(deuda["id_usuarios"]), Convert.ToInt32(deuda["id_comprobantes"]), Convert.ToDecimal(deuda["importe_saldo"]));

                                    montoPercepcionTotal = Convert.ToDecimal(deuda["importe_saldo"]) + montoPercepcion;
                                    dtDeudasAnexadas.Rows.Add(0, Convert.ToInt32(dtPlasticosPresentacion.Rows[x]["id_plastico"]), 0, Convert.ToInt32(deuda["id_usuarios_locaciones"]), Convert.ToInt32(deuda["id_usuarios_servicios"]), Convert.ToInt32(deuda["id_usuarios_servicios_sub"]), Convert.ToInt32(deuda["id_comprobantes"]), Convert.ToInt32(deuda["id_usuarios_ctacte"]), Convert.ToInt32(deuda["id"]), Convert.ToInt16(Presentacion_Usuarios_Servicios.TIPO_DEUDA.DEUDA_ADICIONAL), deuda["detalles"], deuda["comprobantes_descripcion"], deuda["fecha_desde"], deuda["fecha_hasta"], montoPercepcionTotal.ToString(), deuda["id_usuarios"], 0, "");
                                }
                            }
                        }
                    }
                    else
                        listaIndicesDebitosEliminar.Add(Convert.ToInt32(dtPlasticosPresentacion.Rows[x]["id_plastico"]));
                    contadorParcial = x;
                    total = dtPlasticosPresentacion.Rows.Count;
                    bgwListarDebitosYServiciosAdheridos.ReportProgress(contadorParcial,total);
                }
            foreach (int indicePlastico in listaIndicesDebitosEliminar){
                int indice = 0;
                for (int x = 0; x < dtPlasticosPresentacion.Rows.Count; x++){
                    if (Convert.ToInt32(dtPlasticosPresentacion.Rows[x]["id_plastico"]) == indicePlastico){
                        indice = x;
                        break;
                    }
                }
                dtPlasticosPresentacion.Rows.RemoveAt(indice);
            }
        }
            catch (Exception c)
            {
                throw;
                MessageBox.Show("Error al listar debitos y servicios adheridos.");
            }
}

        private void ListarSubservicios(object o, DoWorkEventArgs e){
            try
            {
                DataTable dtAux = new DataTable();
                dtUsuariosServiciosSub.Clear();
                int x = 0;
                foreach (int idUsuarioConBonificacion in listaUsuariosCalculoBonificacion)
                {
                    dtAux.Clear();
                    dtAux = oPresentacionDebitos.RetornarSubServicios(idTarifaActual, idUsuarioConBonificacion, 0, 0, oPresentacionDebitos.Fecha_Presentacion, false, true);
                    if (dtUsuariosServiciosSub.Rows.Count == 0)
                        dtUsuariosServiciosSub = dtAux.Clone();
                    if (dtAux.Rows.Count > 0)
                    {
                        foreach (DataRow subservicio in dtAux.Rows)
                            dtUsuariosServiciosSub.ImportRow(subservicio);
                    }
                    oFacturacion.AgregarSubServiciosHeredados(dtUsuariosServiciosSub, idUsuarioConBonificacion);
                    contadorParcial = x;
                    total = listaUsuariosCalculoBonificacion.Count;
                    bgwListarSubservicios.ReportProgress(contadorParcial, total);
                    x++;
                }
            }
            catch { MessageBox.Show("Error al listar subservicios."); }
        }

        private void ListarDatosDeudasAdelantadas(object o, DoWorkEventArgs e){
            try
            {
                DataTable dtAux = new DataTable();
                int x = 0;
                foreach (int idUsuarioServicioDeudaAdelantada in listaUsuariosServiciosDeudaAdelantada)
                {
                    dtAux.Clear();
                    dtAux = oPresentacionDebitos.RetornarSubServicios(idTarifaActual, idUsuarioServicioDeudaAdelantada, 0, 0, oPresentacionDebitos.Fecha_Presentacion, false, true);
                    if (dtUsuariosServiciosSub.Rows.Count == 0)
                        dtUsuariosServiciosSub = dtAux.Clone();
                    if (dtAux.Rows.Count > 0)
                    {
                        foreach (DataRow subservicio in dtAux.Rows)
                            dtUsuariosServiciosSub.ImportRow(subservicio);
                    }
                    contadorParcial = x;
                    total = listaUsuariosServiciosDeudaAdelantada.Count;
                    bgwListarDeudasAdelantadas.ReportProgress(contadorParcial, total);
                    x++;
                }
            }
            catch { MessageBox.Show("Error al listar deudas adelantadas."); }
        }

        private void CalcularBonificaciones(object o, DoWorkEventArgs e){
            try
            {
                int x = 0;
                foreach (DataRow usuarioServicio in dtUsuariosServiciosPlasticos.Rows)
                {
                    montoTotalServicio = 0;
                    montoTotalDeudaAtrasada = 0;
                    montoTotalDeudaAdelantada = 0;
                    calculaCorrectamente = false;
                    dtDatosUsuario.Clear();
                    dtUsuariosServiciosSubABonificar.Clear();
                    dtDatosUsuario = oUsuarios.Listar(Convert.ToInt32(usuarioServicio["id_usuarios"]));
                    dtvUsuariosServiciosSub = new DataView(dtUsuariosServiciosSub);

                    dtvUsuariosServiciosSub.RowFilter = String.Format("id_usuarios='{0}'", usuarioServicio["id_usuarios"].ToString());

                    if (Convert.ToDecimal(usuarioServicio["monto_deuda_adelantada"]) == 0)
                    {
                        if (Convert.ToInt32(dtDatosUsuario.Rows[0]["calculo_bonificacion"]) != Convert.ToInt32(Usuarios._Calculo_Bonificacion.POR_USUARIO))
                        {
                            if (Convert.ToInt32(dtDatosUsuario.Rows[0]["calculo_bonificacion"]) == Convert.ToInt32(Usuarios._Calculo_Bonificacion.POR_LOCACION))
                                dtvUsuariosServiciosSub.RowFilter = String.Format("id_locacion='{0}' and id_usuarios='{1}'", usuarioServicio["id_locacion"].ToString(), usuarioServicio["id_usuarios"].ToString());
                            else
                                dtvUsuariosServiciosSub.RowFilter = String.Format("id_usuario_servicio='{0}' and heredado=0", usuarioServicio["id_usuarios_servicios"].ToString());
                        }
                        dtUsuariosServiciosSubABonificar = dtvUsuariosServiciosSub.ToTable();
                        foreach (DataRow fila in dtUsuariosServiciosSubABonificar.Rows)
                            fila["tipo_servicio_sub"] = fila["tipo_servicio_sub"].ToString().ToUpper();


                        if (Convert.ToInt32(dtDatosUsuario.Rows[0]["calculo_bonificacion"]) != Convert.ToInt32(Usuarios._Calculo_Bonificacion.NO_SE_APLICA))
                            calculaCorrectamente = oBonificaciones.CalcularBonificaciones(dtUsuariosServiciosSubABonificar, idTarifaActual, false,0,false);
                    }
                    else
                        dtUsuariosServiciosSubABonificar = dtvUsuariosServiciosSub.ToTable();

                    if ((Convert.ToInt32(dtDatosUsuario.Rows[0]["calculo_bonificacion"]) != Convert.ToInt32(Usuarios._Calculo_Bonificacion.NO_SE_APLICA) && calculaCorrectamente) || dtUsuariosServiciosSubABonificar.Rows.Count > 0)
                    {
                        foreach (DataRow subServicio in dtUsuariosServiciosSubABonificar.Select(String.Format("id_usuario_servicio='{0}' and heredado=0", usuarioServicio["id_usuarios_servicios"].ToString())))
                        {

                            decimal montoAdelantado, montoAtrasado, montoEstimado, montoTotal;
                            montoAdelantado = 0;
                            montoAtrasado = 0;
                            montoEstimado = 0;
                            montoTotal = 0;


                            DataRow[] drDeudasSubServicio = dtDeudasAnexadas.Select(String.Format("id_usuarios_servicios_sub='{0}'", subServicio["id_usuario_servicio_sub"].ToString()));
                            if (drDeudasSubServicio.Count() > 0)
                            {
                                foreach (DataRow deudaSubServicio in drDeudasSubServicio)
                                {
                                    if (Convert.ToInt16(deudaSubServicio["tipo_deuda"]) == Convert.ToInt16(Presentacion_Usuarios_Servicios.TIPO_DEUDA.DEUDA_ADELANTANDA))
                                        montoAdelantado += Convert.ToDecimal(deudaSubServicio["total"]);
                                    else if (Convert.ToInt16(deudaSubServicio["tipo_deuda"]) == Convert.ToInt16(Presentacion_Usuarios_Servicios.TIPO_DEUDA.DEUDA_ATRASADA))
                                        montoAtrasado += Convert.ToDecimal(deudaSubServicio["total"]);
                                }
                            }

                            if (montoAdelantado == 0)
                            {
                                montoEstimado = 0;

                                montoEstimado = Convert.ToDecimal(subServicio["importe_con_descuento"])+oPresentacionDebitos.CalcularPercepcionEstimado(Convert.ToInt32(Convert.ToDecimal(subServicio["id_usuarios"])),Convert.ToDecimal(subServicio["importe_con_descuento"]));
                                montoEstimado = decimal.Round(montoEstimado, 2);
                            }
                            montoAdelantado = decimal.Round(montoAdelantado, 2);
                            montoAtrasado = decimal.Round(montoAtrasado, 2);

                            montoTotal = montoAdelantado + montoAtrasado + montoEstimado;
                            dtUsuariosServiciosSubPlasticos.Rows.Add("0", "0", usuarioServicio["id_plastico"], usuarioServicio["id_usuarios_servicios"], subServicio["id_usuario_servicio_sub"], subServicio["subservicio"], montoAtrasado, montoEstimado, 0, montoAdelantado, montoTotal);
                            if (montoAdelantado == 0)
                                montoTotalServicio += Convert.ToDecimal(montoEstimado);
                            montoTotalDeudaAtrasada += montoAtrasado;
                            montoTotalDeudaAdelantada += montoAdelantado;
                        }
                    }

                    usuarioServicio["monto_estimado"] = Decimal.Round(montoTotalServicio, 2).ToString();
                    usuarioServicio["monto_deuda_atrasada"] = Decimal.Round(montoTotalDeudaAtrasada, 2).ToString();
                    usuarioServicio["monto_deuda_adelantada"] = Decimal.Round(montoTotalDeudaAdelantada, 2).ToString();
                    usuarioServicio["total"] = Decimal.Round((montoTotalServicio + montoTotalDeudaAtrasada + montoTotalDeudaAdelantada), 2).ToString();

                    dtPlasticoDetalles.Rows.Add(usuarioServicio["id_plastico"], String.Format("{0} - {1}", usuarioServicio["codigo_usuario"], usuarioServicio["usuario"]), usuarioServicio["servicio"], usuarioServicio["monto_deuda_atrasada"], usuarioServicio["monto_estimado"], usuarioServicio["monto_prefacturacion"], usuarioServicio["monto_deuda_adelantada"], "1");

                    foreach (DataRow subservicio in dtUsuariosServiciosSubPlasticos.Select(String.Format("id_usuarios_servicios='{0}'", usuarioServicio["id_usuarios_servicios"].ToString())))
                        dtPlasticoDetalles.Rows.Add(usuarioServicio["id_plastico"], "", "   " + subservicio["servicio_sub"].ToString(), subservicio["monto_deuda_atrasada"], subservicio["monto_estimado"], subservicio["monto_prefacturacion"], subservicio["monto_deuda_adelantada"], "2");
                    contadorParcial = x;
                    total = dtUsuariosServiciosPlasticos.Rows.Count;
                    bgwCalcularBonificaciones.ReportProgress(contadorParcial, total);
                    x++;
                }
            }
            catch
            {
                MessageBox.Show("Error al calcular bonificaciones.");
            }
        }

        private void CalcularMontosFinales(object o, DoWorkEventArgs e){
            try
            {
                int x = 0;
                foreach (DataRow debito in dtPlasticosPresentacion.Rows)
                {
                    decimal monto_estimado = 0;
                    decimal monto_atrasado = 0;
                    decimal monto_adelantado = 0;
                    foreach (DataRow usuarioServicio in dtUsuariosServiciosPlasticos.Select(String.Format("id_plastico={0}", debito["id_plastico"])))
                    {
                        monto_atrasado += Decimal.Round(Convert.ToDecimal(usuarioServicio["monto_deuda_atrasada"]),2);
                        monto_estimado += Decimal.Round(Convert.ToDecimal(usuarioServicio["monto_estimado"]),2);
                        monto_adelantado += Decimal.Round(Convert.ToDecimal(usuarioServicio["monto_deuda_adelantada"]),2);
                    }
                    foreach (DataRow deudaAnexada in dtDeudasAnexadas.Select(String.Format("tipo_deuda='{0}' and id_plastico='{1}'", Convert.ToInt16(Presentacion_Usuarios_Servicios.TIPO_DEUDA.DEUDA_ADICIONAL), debito["id_plastico"].ToString())))
                        monto_atrasado += Decimal.Round(Convert.ToDecimal(deudaAnexada["total"]),2);

                    debito["monto_deuda_atrasada"] = monto_atrasado;
                    debito["monto_estimado"] = monto_estimado;
                    debito["monto_deuda_adelantada"] = monto_adelantado;
                    debito["total"] = monto_atrasado + monto_estimado + monto_adelantado;
                    contadorParcial = x;
                    total = dtPlasticosPresentacion.Rows.Count;
                    bgwCalcularMontosFinales.ReportProgress(contadorParcial, total);
                    x++;
                }
            }
            catch
            {
                MessageBox.Show("Error al calcular montos finales.");
            }
        }

        private void CargarPresentacionExistente(object o, DoWorkEventArgs e){
            DataColumn DcQuitar = new DataColumn("quitar", typeof(Boolean));
            DcQuitar.DefaultValue = false;
            dtPlasticosPresentacion.Columns.Add(DcQuitar);

            dtUsuariosServiciosPlasticos = oPresentacionUsuariosServicios.Listar(oPresentacionDebitos.Id, 0);
            dtUsuariosServiciosSubPlasticos = oPresentacionUsuariosServicios.ListarPlasticosSubServicios(oPresentacionDebitos.Id, 0);

            dtDeudasAnexadas = oPresentacionUsuariosServicios.ListarDeudasAnexadas(oPresentacionDebitos.Id);
            int x = 0;
            foreach (DataRow usuarioServicio in dtUsuariosServiciosPlasticos.Rows)
            {
                dtPlasticoDetalles.Rows.Add(usuarioServicio["id_plastico"], String.Format("{0} - {1}", usuarioServicio["codigo_usuario"], usuarioServicio["usuario"]), usuarioServicio["servicio"], usuarioServicio["monto_deuda_atrasada"], usuarioServicio["monto_estimado"], usuarioServicio["monto_prefacturacion"], usuarioServicio["monto_deuda_adelantada"], "1");

                foreach (DataRow subservicio in dtUsuariosServiciosSubPlasticos.Select(String.Format("id_usuarios_servicios='{0}'", usuarioServicio["id_usuarios_servicios"])))
                    dtPlasticoDetalles.Rows.Add(usuarioServicio["id_plastico"], "", "   " + subservicio["servicio_sub"].ToString(), subservicio["monto_deuda_atrasada"], subservicio["monto_estimado"], subservicio["monto_prefacturacion"], subservicio["monto_deuda_adelantada"], "2");
                contadorParcial = x;
                total = dtUsuariosServiciosPlasticos.Rows.Count;
                bgwCargarPresentacionExistente.ReportProgress(contadorParcial, total);
                x++;
            }
        }

        private void ListarSubServiciosP2(object o, RunWorkerCompletedEventArgs e)
        {
            pbProgreso.Maximum = listaUsuariosCalculoBonificacion.Count;
            imgReturn.Enabled = false;
            this.KeyPreview = false;
            Cursor = Cursors.WaitCursor;
            bgwListarSubservicios.DoWork += ListarSubservicios;
            bgwListarSubservicios.RunWorkerCompleted += ListarDatosDeudasAdelantadasP3;
            bgwListarSubservicios.RunWorkerAsync();
        }

        private void ListarDatosDeudasAdelantadasP3(object o, RunWorkerCompletedEventArgs e)
        {
            pbProgreso.Maximum = listaUsuariosServiciosDeudaAdelantada.Count;
            imgReturn.Enabled = false;
            this.KeyPreview = false;
            Cursor = Cursors.WaitCursor;
            bgwListarDeudasAdelantadas.DoWork += ListarDatosDeudasAdelantadas;
            bgwListarDeudasAdelantadas.RunWorkerCompleted += CalcularBonificacionesP4;
            bgwListarDeudasAdelantadas.RunWorkerAsync();
        }

        private void CalcularBonificacionesP4(object o, RunWorkerCompletedEventArgs e)
        {
            pbProgreso.Maximum = dtUsuariosServiciosPlasticos.Rows.Count;
            imgReturn.Enabled = false;
            this.KeyPreview = false;
            Cursor = Cursors.WaitCursor;
            bgwCalcularBonificaciones.DoWork += CalcularBonificaciones;
            bgwCalcularBonificaciones.RunWorkerCompleted += CalcularMontosP5;
            bgwCalcularBonificaciones.RunWorkerAsync();
        }

        private void CalcularMontosP5(object o, RunWorkerCompletedEventArgs e)
        {
            pbProgreso.Maximum = dtPlasticosPresentacion.Rows.Count;
            imgReturn.Enabled = false;
            this.KeyPreview = false;
            Cursor = Cursors.WaitCursor;
            bgwCalcularMontosFinales.DoWork += CalcularMontosFinales;
            bgwCalcularMontosFinales.RunWorkerCompleted += Terminado;
            bgwCalcularMontosFinales.RunWorkerAsync();
        }

        private void Terminado(object o, RunWorkerCompletedEventArgs e)
        {
            pbProgreso.Value = pbProgreso.Maximum;
            this.Cursor = Cursors.Arrow;
            lblProgreso.Visible = false;
            pbProgreso.Visible = false;
            AsignarDatos();
            MessageBox.Show("Proceso completado.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //consultar datos
        private void ConsultarDatosPresentacion(object o, DoWorkEventArgs e){
            DataColumn DcQuitar = new DataColumn("quitar", typeof(Boolean));
            DcQuitar.DefaultValue = false;
            dtPlasticosPresentacion.Columns.Add(DcQuitar);



            dtUsuariosServiciosPlasticos = oPresentacionUsuariosServicios.Listar(oPresentacionDebitos.Id, 0);
            dtUsuariosServiciosSubPlasticos = oPresentacionUsuariosServicios.ListarPlasticosSubServicios(oPresentacionDebitos.Id, 0);

            dtDeudasAnexadas = oPresentacionUsuariosServicios.ListarDeudasAnexadas(oPresentacionDebitos.Id);

            foreach (DataRow usuarioServicio in dtUsuariosServiciosPlasticos.Rows)
            {
                dtPlasticoDetalles.Rows.Add(usuarioServicio["id_plastico"], String.Format("{0} - {1}", usuarioServicio["codigo_usuario"], usuarioServicio["usuario"]), usuarioServicio["servicio"], usuarioServicio["monto_deuda_atrasada"], usuarioServicio["monto_estimado"], usuarioServicio["monto_prefacturacion"], usuarioServicio["monto_deuda_adelantada"], "1");

                foreach (DataRow subservicio in dtUsuariosServiciosSubPlasticos.Select(String.Format("id_usuarios_servicios={0}", usuarioServicio["id_usuarios_servicios"])))
                    dtPlasticoDetalles.Rows.Add(usuarioServicio["id_plastico"], "", "   " + subservicio["servicio_sub"].ToString(), subservicio["monto_deuda_atrasada"], subservicio["monto_estimado"], subservicio["monto_prefacturacion"], subservicio["monto_deuda_adelantada"], "2");
            }
        }

        private void AsignarDatos()
        {
            decimal montoTotal = 0;
            DataView dtvAux;
            pgCircular.Visible = false;
            //grilla plasticos
            dgvPlasticos.DataSource = dtPlasticosPresentacion;
            for (int x = 0; x < dgvPlasticos.ColumnCount; x++)
                dgvPlasticos.Columns[x].Visible = false;

            dgvPlasticos.Columns["titular"].Visible = true;
            dgvPlasticos.Columns["numero"].Visible = true;
            dgvPlasticos.Columns["monto_deuda_atrasada"].Visible = true;
            dgvPlasticos.Columns["monto_estimado"].Visible = true;
            dgvPlasticos.Columns["monto_prefacturacion"].Visible = true;
            dgvPlasticos.Columns["monto_deuda_adelantada"].Visible = true;
            dgvPlasticos.Columns["total"].Visible = true;

            dgvPlasticos.Columns["titular"].HeaderText = "Titular";
            dgvPlasticos.Columns["numero"].HeaderText = "Número";
            dgvPlasticos.Columns["monto_deuda_atrasada"].HeaderText = "Deuda atrasada";
            dgvPlasticos.Columns["monto_estimado"].HeaderText = "Deuda estimada";
            dgvPlasticos.Columns["monto_prefacturacion"].HeaderText = "Prefacturación";
            dgvPlasticos.Columns["monto_deuda_adelantada"].HeaderText = "Deuda adelantada";
            dgvPlasticos.Columns["total"].HeaderText = "Total";

            dgvPlasticos.Columns["numero"].Width = 75;
            dgvPlasticos.Columns["monto_deuda_atrasada"].Width = 80;
            dgvPlasticos.Columns["monto_estimado"].Width = 80;
            dgvPlasticos.Columns["monto_prefacturacion"].Width = 85;
            dgvPlasticos.Columns["monto_deuda_adelantada"].Width = 80;
            dgvPlasticos.Columns["total"].Width = 80;

            dgvPlasticos.Columns["numero"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPlasticos.Columns["monto_deuda_atrasada"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPlasticos.Columns["monto_estimado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPlasticos.Columns["monto_prefacturacion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPlasticos.Columns["monto_deuda_adelantada"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPlasticos.Columns["total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            if (funcionARealizar == Convert.ToInt16(TAREA.CONSULTA_PRESENTACION) && (oPresentacionDebitos.Id_Estado == Convert.ToInt16(Presentacion_Debitos.ESTADO.ARCHIVO_PENDIENTE) || oPresentacionDebitos.Id_Estado == Convert.ToInt16(Presentacion_Debitos.ESTADO.RECIBO_PENDIENTE)))
            {
                dgvPlasticos.Columns["quitar"].Visible = true;
                dgvPlasticos.Columns["quitar"].HeaderText = "Rechazado";
                dgvPlasticos.Columns["quitar"].Width = 80;
                dgvPlasticos.Columns["quitar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvPlasticos.ReadOnly = false;
                foreach (DataGridViewColumn columna in dgvPlasticos.Columns)
                {
                    if (columna.Name != "quitar")
                        columna.ReadOnly = true;
                }

                ColorearGrillaPlasticos();
            }

            //grilla servicios
            dgvServicios.DataSource = dtPlasticoDetalles;
            for (int x = 0; x < dgvServicios.ColumnCount; x++)
                dgvServicios.Columns[x].Visible = false;

            dgvServicios.Columns["usuario"].Visible = true;
            dgvServicios.Columns["nombre"].Visible = true;
            dgvServicios.Columns["deuda_atrasada"].Visible = true;
            dgvServicios.Columns["monto_estimado"].Visible = true;
            dgvServicios.Columns["monto_prefacturacion"].Visible = true;
            dgvServicios.Columns["deuda_adelantada"].Visible = true;

            dgvServicios.Columns["usuario"].HeaderText = "Usuario";
            dgvServicios.Columns["nombre"].HeaderText = "Item";
            dgvServicios.Columns["deuda_atrasada"].HeaderText = "Deuda atrasada";
            dgvServicios.Columns["monto_estimado"].HeaderText = "Deuda estimada";
            dgvServicios.Columns["monto_prefacturacion"].HeaderText = "Prefacturación";
            dgvServicios.Columns["deuda_adelantada"].HeaderText = "Deuda adelantada";

            dgvServicios.Columns["nombre"].Width = 150;
            dgvServicios.Columns["deuda_atrasada"].Width = 80;
            dgvServicios.Columns["monto_estimado"].Width = 80;
            dgvServicios.Columns["monto_prefacturacion"].Width = 90;
            dgvServicios.Columns["deuda_adelantada"].Width = 80;

            dgvServicios.Columns["deuda_atrasada"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvServicios.Columns["monto_estimado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvServicios.Columns["monto_prefacturacion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvServicios.Columns["deuda_adelantada"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //grilla deudas adicionales

            dgvDeudasAnexadas.DataSource = dtDeudasAnexadas;

            for (int x = 0; x < dgvDeudasAnexadas.ColumnCount; x++)
                dgvDeudasAnexadas.Columns[x].Visible = false;

            dgvDeudasAnexadas.Columns["servicio_sub"].Visible = true;
            dgvDeudasAnexadas.Columns["comprobantes_descripcion"].Visible = true;
            dgvDeudasAnexadas.Columns["fecha_desde"].Visible = true;
            dgvDeudasAnexadas.Columns["fecha_hasta"].Visible = true;
            dgvDeudasAnexadas.Columns["total"].Visible = true;

            dgvDeudasAnexadas.Columns["servicio_sub"].HeaderText = "Subservicio";
            dgvDeudasAnexadas.Columns["comprobantes_descripcion"].HeaderText = "Comprobante";
            dgvDeudasAnexadas.Columns["fecha_desde"].HeaderText = "Vigencia desde";
            dgvDeudasAnexadas.Columns["fecha_hasta"].HeaderText = "Hasta";
            dgvDeudasAnexadas.Columns["total"].HeaderText = "Total";

            dgvDeudasAnexadas.Columns["fecha_desde"].Width = 80;
            dgvDeudasAnexadas.Columns["fecha_hasta"].Width = 80;
            dgvDeudasAnexadas.Columns["total"].Width = 80;

            dgvDeudasAnexadas.Columns["total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;



            //----------------------------------------------------------------------------------------------------------

            dtPlasticoDetalles.DefaultView.RowFilter = String.Format("id_plastico={0}", dtPlasticosPresentacion.Rows[0]["id_plastico"].ToString());
            dtDeudasAnexadas.DefaultView.RowFilter = String.Format("id_plastico={0} and tipo_deuda={1}", dtPlasticosPresentacion.Rows[0]["id_plastico"].ToString(), Convert.ToInt16(Presentacion_Usuarios_Servicios.TIPO_DEUDA.DEUDA_ADICIONAL));
            foreach (DataGridViewRow fila in dgvServicios.Rows)
            {
                if (Convert.ToInt16(fila.Cells["tipo_item"].Value) == 1)
                    fila.DefaultCellStyle.BackColor = Color.MediumBlue;
                else
                    fila.DefaultCellStyle.BackColor = Color.LightBlue;
            }


            foreach (DataRow plastico in dtPlasticosPresentacion.Rows)
                montoTotal += Convert.ToDecimal(plastico["total"]);
            montoTotalPresentacion = montoTotal;
            lblNroPlasticos.Text = String.Format("Nro. de plásticos:{0}", dtPlasticosPresentacion.Rows.Count);
            lblTotalPlasticos.Text = String.Format("Total: ${0}", montoTotal.ToString());
            if (oPresentacionDebitos.Id_Estado == Convert.ToInt16(Presentacion_Debitos.ESTADO.PAGO_GENERADO))
                btnConfirmarPresentacion.Visible = false;
            else
                btnConfirmarPresentacion.Visible = true;

        }
        
        private void ExportarAExcel(){
            if (dgvPlasticos.Rows.Count > 0)
                oTools.ExportToExcel(dgvPlasticos, "Plasticos");
            else
                MessageBox.Show("No hay datos en la grilla.");
        }

        private decimal RecalcularMontoTotalPresentacion(DataTable dtListadoPlasticos){
            decimal montoTotal = 0;
            if (dtListadoPlasticos.Rows.Count > 0){
                foreach (DataRow plastico in dtListadoPlasticos.Rows)
                    montoTotal += Convert.ToDecimal(plastico["total"]);
            }
            return Decimal.Round(montoTotal, 2);
        }

        private void ComenzarPresentacion(){
            btnConfirmarPresentacion.Enabled = false;
            pgCircular.Visible = true;
            pgCircular.Start();
            hilo = new Thread(new ThreadStart(GenerarPresentacion));
            hilo.IsBackground = true;
            hilo.Start();
        }

        private void GenerarPresentacion(){
            try
            {
                oPresentacionDebitos.Monto_Total = RecalcularMontoTotalPresentacion(dtPlasticosPresentacion);
                oPresentacionDebitos.Id = oPresentacionDebitos.Guardar(oPresentacionDebitos);
                foreach (DataRow plastico in dtPlasticosPresentacion.Rows){
                    if (Convert.ToDecimal(plastico["total"]) > 0){
                        oPresentacionPlasticos.Id_Presentacion = oPresentacionDebitos.Id;
                        oPresentacionPlasticos.Id_Plastico = Convert.ToInt32(plastico["id_plastico"]);
                        oPresentacionPlasticos.Id_Estado = Convert.ToInt16(Presentacion_Plasticos.ESTADO.PAGO_PENDIENTE);
                        oPresentacionPlasticos.Monto_Estimado = Convert.ToDecimal(plastico["monto_estimado"]);
                        oPresentacionPlasticos.Monto_Prefacturacion = 0;
                        oPresentacionPlasticos.Monto_Deuda_Adelantada = Convert.ToDecimal(plastico["monto_deuda_adelantada"]);
                    oPresentacionPlasticos.Monto_Deuda_Atrasada = Convert.ToDecimal(plastico["monto_deuda_atrasada"]);
                    oPresentacionPlasticos.Id = oPresentacionPlasticos.Guardar(oPresentacionPlasticos);
                        foreach (DataRow usuarioServicio in dtUsuariosServiciosPlasticos.Select(String.Format("id_plastico='{0}'", plastico["id_plastico"].ToString()))){
                            if (Convert.ToDecimal(usuarioServicio["total"]) > 0){
                                oPresentacionUsuariosServicios.Id_Plastico = oPresentacionPlasticos.Id_Plastico;
                                oPresentacionUsuariosServicios.Id_Presentacion = oPresentacionDebitos.Id;
                                oPresentacionUsuariosServicios.Id_Usuarios_Servicios = Convert.ToInt32(usuarioServicio["id_usuarios_servicios"]);
                                oPresentacionUsuariosServicios.Monto_Estimado = Convert.ToDecimal(usuarioServicio["monto_estimado"]);
                                oPresentacionUsuariosServicios.Monto_Prefacturacion = 0;
                                oPresentacionUsuariosServicios.Monto_Deuda_Adelantada = Convert.ToDecimal(usuarioServicio["monto_deuda_adelantada"]);
                                oPresentacionUsuariosServicios.Monto_Deuda_Atrasada = Convert.ToDecimal(usuarioServicio["monto_deuda_atrasada"]);
                                oPresentacionUsuariosServicios.Guardar(oPresentacionUsuariosServicios);
                                foreach (DataRow usuarioServicioSub in dtUsuariosServiciosSubPlasticos.Select(String.Format("id_usuarios_servicios='{0}'", usuarioServicio["id_usuarios_servicios"])))
                                    oPresentacionUsuariosServicios.GuardarPresentacionUsuariosServiciosSub(oPresentacionUsuariosServicios.Id_Presentacion, oPresentacionUsuariosServicios.Id_Plastico, oPresentacionUsuariosServicios.Id_Usuarios_Servicios, Convert.ToInt32(usuarioServicioSub["id_usuarios_servicios_sub"]), Convert.ToDecimal(usuarioServicioSub["monto_estimado"]), 0, Convert.ToDecimal(usuarioServicioSub["monto_deuda_adelantada"]), Convert.ToDecimal(usuarioServicioSub["monto_deuda_atrasada"]));
                            }
                        }
                        foreach (DataRow deudaAnexada in dtDeudasAnexadas.Select(String.Format("id_plastico='{0}'", oPresentacionPlasticos.Id_Plastico)))
                            oPresentacionUsuariosServicios.GuardarPresentacionDeudasAnexadas(oPresentacionDebitos.Id, oPresentacionPlasticos.Id_Plastico, Convert.ToInt32(deudaAnexada["id_usuarios_locaciones"]), Convert.ToInt32(deudaAnexada["id_usuarios_servicios"]), Convert.ToInt32(deudaAnexada["id_usuarios_servicios_sub"]), Convert.ToInt32(deudaAnexada["id_comprobante"]), Convert.ToInt32(deudaAnexada["id_usuarios_ctacte"]), Convert.ToInt32(deudaAnexada["id_usuarios_ctacte_det"]), Convert.ToInt16(deudaAnexada["tipo_deuda"]), Convert.ToDecimal(deudaAnexada["total"]), Convert.ToInt32(deudaAnexada["id_usuarios"]));
                    }
                }

                myDel MD = new myDel(FinalizarPresentacion);
                this.Invoke(MD, new object[] { });
                pgCircular.Stop();

        }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
            }
}

        private void FinalizarPresentacion()
        {
            MessageBox.Show(String.Format("Se ha generado una presentación con un monto de ${0}. Se procederá a generar el archivo para la presentación.", oPresentacionDebitos.Monto_Total));
            if (oPresentacionDebitos.GenerarArchivoPresentacion(dtPlasticosPresentacion, oPresentacionDebitos.Id_Forma_De_Pago, oPresentacionDebitos)){
                oPresentacionDebitos.ActualizarEstado(oPresentacionDebitos.Id, Convert.ToInt16(Presentacion_Debitos.ESTADO.RECIBO_PENDIENTE));
                if (idPresentacionExistente> 0)
                    oPresentacionDebitos.Eliminar(idPresentacionExistente);
                MessageBox.Show("Presentación generada correctamente.");
            }
            else
                MessageBox.Show("Hubo errores al generar la presentación");
            pgCircular.Visible = false;
            btnConfirmarPresentacion.Enabled = true;
        }

        private void GenerarPago(){
            if(dtDeudasAnexadas.Rows.Count>0){
                totalPagado = 0;
                int punitoriosTolerancia, ctaSeleccion, reciboTipo;
                int idComprobantes = 0;
                int idLocacionAux = 0;
                int cuenta = 1;
                int cantRecibosPagados = 0;
                int idPrimerRecibo = 0;
                int idUltimoRecibo = 0;
                int contRecibos = 0;
                decimal totalRecibo = 0;
                decimal punitoriosPorcentaje;
                List<int> listadoComprobantes = new List<int>();
                List<int> listadoPlasticosRechazados = new List<int>();
                List<int> listadoPlasticosPagados = new List<int>();
                DataRow drDatosPlastico;
                DataRow[] drDatosComprobante;
                DataRow[] drDeudasAnexadasDetalles;
                DataTable dtDatosFormaDePagoSeleccionada = oPresentacionDebitos.GenerarEstructuraDtDetallesRecibos();
                DataTable dtFacurasAimprimir = oPresentacionDebitos.GenerarEstructuraDtFacturasImprimir();
                DataTable dtListadoComprobantes = oPresentacionDebitos.GenerarEstructuraDtListadoComprobantes();
                DataTable dtLocaciones = new DataTable();
                DataTable dtDatosCtaCte= new DataTable();
                DataTable dtRegistrosAPagar= new DataTable();
                DataTable dtAux = new DataTable();
                DataView dtvAux;
                Usuarios_Locaciones oUsuariosLocaciones = new Usuarios_Locaciones();
                Usuarios_CtaCte oUsuariosCtaCte = new Usuarios_CtaCte();
                Comprobantes oComprobantes = new Comprobantes();
                Comprobantes_Tipo oComprobantesTipo = new Comprobantes_Tipo();
                Usuarios_CtaCte_Recibos oUsuariosCtaCteRecibos = new Usuarios_CtaCte_Recibos();
                Facturacion oFacturacion = new Facturacion();
                Configuracion oConfiguracion = new Configuracion();

                punitoriosPorcentaje = oConfiguracion.GetValor_Decimal("Punitorios_Porcentaje"); //porcentaje de interes
                punitoriosTolerancia= oConfiguracion.GetValor_N("Punitorios_Tolerancia");//días de tolerancia
                ctaSeleccion = oConfiguracion.GetValor_N("Cta_Seleccion");
                reciboTipo= oConfiguracion.GetValor_N("Cta_Comprobante_De_Pago");

                //---busca las locaciones y comprobantes que se encuentran en las deudas a pagar---//
                foreach (DataRow deuda in dtDeudasAnexadas.Rows) {
                    if (Convert.ToBoolean(dtPlasticosPresentacion.Select(String.Format("id_plastico={0}", deuda["id_plastico"]))[0]["quitar"]) == false){
                        idComprobantes = Convert.ToInt32(deuda["id_comprobante"]);
                        idLocacionAux = Convert.ToInt32(deuda["id_usuarios_locaciones"]);
                        if (dtListadoComprobantes.Select(String.Format("id_comprobante={0}", idComprobantes)).Count() == 0)
                            dtListadoComprobantes.Rows.Add(idComprobantes, deuda["id_usuarios"]);
                        if (dtLocaciones.Rows.Count == 0){
                            dtLocaciones = oUsuariosLocaciones.ListarLocacionesServicio(0, idLocacionAux);
                            dtLocaciones.Columns.Add("idPlasticoAsociado", typeof(int));
                            dtLocaciones.Rows[0]["idPlasticoAsociado"] = Convert.ToInt32(deuda["id_plastico"]);
                        }
                        else{
                            if (dtLocaciones.Select(String.Format("id={0}", idLocacionAux)).Count() == 0){
                                dtLocaciones.ImportRow(oUsuariosLocaciones.ListarLocacionesServicio(0, idLocacionAux).Rows[0]);
                                dtLocaciones.Rows[dtLocaciones.Rows.Count - 1]["idPlasticoAsociado"] = Convert.ToInt32(deuda["id_plastico"]);
                            }
                        }
                    }
                    else{
                        if (listadoPlasticosRechazados.Contains(Convert.ToInt32(deuda["id_plastico"])) == false)
                            listadoPlasticosRechazados.Add(Convert.ToInt32(deuda["id_plastico"]));
                    }
                }
                //---arma la tabla que contiene los datos del comprobante completo para luego determinar de ese comprobante cuales detalles se pagarán
                foreach(DataRow comprobante in dtListadoComprobantes.Rows){
                    if (dtDatosCtaCte.Rows.Count == 0)
                        dtDatosCtaCte = oUsuariosCtaCte.LlenarDtModelo(dtLocaciones, "C", Convert.ToInt32(comprobante["id_comprobante"]), Convert.ToInt32(comprobante["id_usuario"]));
                    else{
                        dtAux.Clear();
                        dtAux = oUsuariosCtaCte.LlenarDtModelo(dtLocaciones, "C", Convert.ToInt32(comprobante["id_comprobante"]), Convert.ToInt32(comprobante["id_usuario"]));
                        foreach(DataRow fila in dtAux.Rows)
                            dtDatosCtaCte.ImportRow(fila);
                    }
                }
                //---se seleccionan los detalles que se van a pagar
                foreach (DataRow comprobante in dtListadoComprobantes.Rows){
                    drDeudasAnexadasDetalles = dtDeudasAnexadas.Select(String.Format("id_comprobante={0}", Convert.ToInt32(comprobante["id_comprobante"])));
                    drDatosComprobante = dtDatosCtaCte.Select(String.Format("id_comprobantes={0}", Convert.ToInt32(comprobante["id_comprobante"])));
                    foreach (DataRow detalle in drDeudasAnexadasDetalles){
                        foreach (DataRow detalleComprobante in drDatosComprobante){
                            if (Convert.ToInt16(detalleComprobante["encabezado"]) == 0 && Convert.ToInt32(detalleComprobante["id"]) == Convert.ToInt32(detalle["id_usuarios_ctacte_det"]))
                                detalleComprobante["elige"] = true;
                        }
                    }
                    dtDatosCtaCte.AcceptChanges();
                }
               
                //---resetear a 0 saldo de cada locación
                foreach (DataRow locacion in dtLocaciones.Rows)
                    locacion["saldo"] = 0;
                //---seleccionar sólo los registros seleccionados para pagar
                dtvAux = new DataView(dtDatosCtaCte);
                dtvAux.RowFilter = string.Format("elige = {0} ", true);
                dtRegistrosAPagar = dtvAux.ToTable();
                //---actualizar saldo de locación de acuerdo con registros para pagar seleccionados y determinar a cuales se les va a generar factura
                foreach (DataRow registro in dtRegistrosAPagar.Rows){
                    foreach (DataRow locacion in dtLocaciones.Rows){
                        if (Convert.ToInt32(registro["Id_usuarios_locaciones"].ToString()) == Convert.ToInt32(locacion["id"])){
                            if (Convert.ToInt32(registro["encabezado"].ToString()) == 0)
                                locacion["saldo"] = Convert.ToDecimal(locacion["saldo"].ToString()) + Convert.ToDecimal(registro["Importe_pago"].ToString());
                            if (Convert.ToInt32(registro["encabezado"].ToString()) == 2){
                                if (Convert.ToInt32(registro["presenta_ventas"].ToString()) == 0)
                                    locacion["Genera_Factura"] = 1;
                                else
                                    dtFacurasAimprimir.Rows.Add(Convert.ToInt32(locacion["id"]), Convert.ToInt32(registro["Id_comprobantes"].ToString()), Convert.ToInt32(registro["Punto"].ToString()), Convert.ToInt32(registro["Numero"].ToString()));
                            }
                        }
                    }
                }

                foreach (DataRow drl in dtLocaciones.Rows)
                    drl["saldo"] = 0;
                foreach (DataRow locacion in dtLocaciones.Rows){
                    locacion["saldo"] = dtRegistrosAPagar.Compute("SUM(importe_saldo)", String.Format("id_usuarios_locaciones={0}", locacion["id"]));
                    drDatosPlastico = dtPlasticosPresentacion.Select(String.Format("id_plastico={0}", locacion["idPlasticoAsociado"].ToString()))[0];
                    dtDatosFormaDePagoSeleccionada.Rows.Add("", Convert.ToDecimal(locacion["saldo"]), "", "", "", "", "", "", "", drDatosPlastico["numero"], idFormaPago.ToString(), Convert.ToInt32(locacion["id"]));

                    int idLocacion = Convert.ToInt32(locacion["id"]);

                    if (Convert.ToDecimal(locacion["saldo"].ToString()) > 0){
                        DataView ViewAbonadosLocacion = dtRegistrosAPagar.DefaultView;
                        ViewAbonadosLocacion.RowFilter = string.Format("Id_usuarios_locaciones = {0} ", Convert.ToInt32(locacion["id"]));
                        DataTable dtAbonadosLocacion = ViewAbonadosLocacion.ToTable();

                        DataView ViewDetallesLocacion = dtDatosCtaCte.DefaultView;
                        ViewAbonadosLocacion.RowFilter = string.Format("Id_usuarios_locaciones = {0} ", Convert.ToInt32(locacion["id"]));
                        DataTable dtDetallesLocacion = ViewDetallesLocacion.ToTable();

                        string NumeroString;
                        Int32 NroRecibo, PtoRecibo;
                        if (cuenta == 1) {
                            foreach (DataRow drFacAnt in dtFacurasAimprimir.Rows){
                                if (Convert.ToInt32(drFacAnt["Id_locacion"].ToString()) == Convert.ToInt32(locacion["id"])){
                                    oFacturacion.Punto_Venta = Convert.ToInt32(drFacAnt["Punto"].ToString());
                                    oFacturacion.Numero = Convert.ToInt32(drFacAnt["Numero"].ToString());
                                    oFacturacion.NumeroMuestra = NumeroString =oFacturacion.Punto_Venta.ToString().PadLeft(4, '0') + "-" + oFacturacion.Numero.ToString().PadLeft(8, '0');
                                }
                            }
                            if (Convert.ToInt32(locacion["Genera_Factura"].ToString()) == 1) {
                                Int32 codigoRetorno =Convert.ToInt16(oFacturacion.Comprobante_a_Factura(oFacturacion, dtDetallesLocacion, idLocacion,Personal.Id_Punto_Venta, permitirHacerRemito: false, facturaDeCredito: false).Rows[0]["respuesta_codigo"]);
                            }
                        }

                        if (reciboTipo == 1){
                            DataRow drComprobante;
                            drComprobante = oComprobantesTipo.GetNumeracion(Convert.ToInt32(Comprobantes_Tipo.Tipo.RECIBO), Puntos_Cobros.Id_Punto);
                            NroRecibo = Convert.ToInt32(drComprobante["numComprobante"]);
                            PtoRecibo = Convert.ToInt32(drComprobante["numPuntoVenta"]);
                            NumeroString = PtoRecibo.ToString().PadLeft(4, '0') + "-" + NroRecibo.ToString().PadLeft(8, '0');
                            oComprobantesTipo.SetNumeracion(Convert.ToInt32(drComprobante["idPuntoVenta"]), Convert.ToInt32(Comprobantes_Tipo.Tipo.RECIBO), NroRecibo);
                        }
                        else{
                            if (cuenta == 1){
                                NroRecibo = oFacturacion.Numero;
                                PtoRecibo = oFacturacion.Punto_Venta;
                                NumeroString = oFacturacion.NumeroMuestra;
                            }
                            else{
                                DataRow drComprobante;
                                drComprobante =oComprobantesTipo.GetNumeracion(Convert.ToInt32(Comprobantes_Tipo.Tipo.RECIBO_INTERNO), Puntos_Cobros.Id_Punto);
                                NroRecibo = Convert.ToInt32(drComprobante["numComprobante"]);
                                PtoRecibo = Convert.ToInt32(drComprobante["numPuntoVenta"]);
                                NumeroString = PtoRecibo.ToString().PadLeft(4, '0') + "-" + NroRecibo.ToString().PadLeft(8, '0');
                                oComprobantesTipo.SetNumeracion(Convert.ToInt32(drComprobante["idPuntoVenta"]), Convert.ToInt32(Comprobantes_Tipo.Tipo.RECIBO_INTERNO), NroRecibo);
                            }
                        }

                        oComprobantes.Id_Usuarios = Convert.ToInt32(locacion["id_usuarios"]);
                        oComprobantes.Fecha = DateTime.Today;
                        oComprobantes.Punto_Venta = PtoRecibo;
                        oComprobantes.Numero = NroRecibo;
                        if (cuenta == 1)
                            oComprobantes.Id_Comprobantes_Tipo = (int)Comprobantes_Tipo.Tipo.RECIBO;
                        else
                            oComprobantes.Id_Comprobantes_Tipo = (int)Comprobantes_Tipo.Tipo.RECIBO_INTERNO;
                        oComprobantes.Importe = Convert.ToDecimal(locacion["saldo"].ToString());
                        oComprobantes.Id = oComprobantes.Guardar(oComprobantes);

                        oUsuariosCtaCteRecibos.Descripcion = oFacturacion.Descripcion;
                        oUsuariosCtaCteRecibos.Id_Usuarios = Convert.ToInt32(locacion["id_usuarios"]);
                        oUsuariosCtaCteRecibos.Id_Usuarios_Locacion = idLocacion;
                        oUsuariosCtaCteRecibos.Fecha_Movimiento = DateTime.Now;
                        oUsuariosCtaCteRecibos.Importe_Final = Convert.ToDecimal(locacion["saldo"].ToString());
                        oUsuariosCtaCteRecibos.Id_Comprobantes = oComprobantes.Id;
                        oUsuariosCtaCteRecibos.Numero_Muestra = "Recibo Nro " + NumeroString;
                        oUsuariosCtaCteRecibos.Numero = NroRecibo;
                        oUsuariosCtaCteRecibos.Id_Usuarios_Locacion = idLocacion;

                        DataView dtvAbonadosLocacion = new DataView(dtAbonadosLocacion);
                        dtvAbonadosLocacion.RowFilter = String.Format("elige=true");

                        DataView dtvLocacionSeleccionada = new DataView(dtDatosFormaDePagoSeleccionada);
                        dtvLocacionSeleccionada.RowFilter = String.Format("id_usuarios_locaciones={0}", locacion["id"]);
                        string salida = "";
                        oUsuariosCtaCteRecibos.guardar(oUsuariosCtaCteRecibos, dtvLocacionSeleccionada.ToTable(), dtvAbonadosLocacion.ToTable(), cuenta,out salida);
                        if (contRecibos == 0)
                            idPrimerRecibo = oUsuariosCtaCteRecibos.Id;
                        else
                            idUltimoRecibo = oUsuariosCtaCteRecibos.Id;
                        contRecibos++;
                        cantRecibosPagados++;
                    }

                    if (listadoPlasticosPagados.Contains(Convert.ToInt32(locacion["idPlasticoAsociado"])) == false)
                        listadoPlasticosPagados.Add(Convert.ToInt32(locacion["idPlasticoAsociado"]));
                    totalPagado += Decimal.Round(oUsuariosCtaCteRecibos.Importe_Final,2);
                    
                }

                foreach(DataRow plastico in dtPlasticosPresentacion.Rows){
                    if (Convert.ToBoolean(plastico["quitar"]) == true)
                    {
                        if (listadoPlasticosRechazados.Contains(Convert.ToInt32(plastico["id_plastico"])) == false)
                            listadoPlasticosRechazados.Add(Convert.ToInt32(plastico["id_plastico"]));
                    }
                }


                if(listadoPlasticosRechazados.Count>0){
                    foreach (int idPlastico in listadoPlasticosRechazados)
                        oPresentacionPlasticos.ActualizarEstado(oPresentacionDebitos.Id, idPlastico, Convert.ToInt16(Presentacion_Plasticos.ESTADO.RECHAZADO));
                }
                if (listadoPlasticosPagados.Count > 0){
                    foreach (int idPlastico in listadoPlasticosPagados)
                        oPresentacionPlasticos.ActualizarEstado(oPresentacionDebitos.Id, idPlastico, Convert.ToInt16(Presentacion_Plasticos.ESTADO.PAGADO));
                }

                oPresentacionDebitos.ActualizarEstado(oPresentacionDebitos.Id, Convert.ToInt16(Presentacion_Debitos.ESTADO.PAGO_GENERADO));
                oPresentacionDebitos.ActualizarMontoPago(oPresentacionDebitos.Id, totalPagado);
                oPresentacionDebitos.Cantidad_Total_Plasticos = listadoPlasticosPagados.Count + listadoPlasticosRechazados.Count;
                oPresentacionDebitos.Cant_Plasticos_Aceptados = listadoPlasticosPagados.Count;
                oPresentacionDebitos.Cant_Plasticos_Rechazados = listadoPlasticosRechazados.Count;
                oPresentacionDebitos.ActualizarDatosDePlasticos(oPresentacionDebitos.Id, oPresentacionDebitos.Cantidad_Total_Plasticos, oPresentacionDebitos.Cant_Plasticos_Aceptados, oPresentacionDebitos.Cant_Plasticos_Rechazados);
                oPresentacionDebitos.Cantidad_Recibos = cantRecibosPagados;

                oPresentacionDebitos.ActualizarDatosDeRecibos(oPresentacionDebitos.Id, cantRecibosPagados, idPrimerRecibo, idUltimoRecibo);
                MessageBox.Show("Pago realizado correctamente.");
            }
        }

        private void ColorearGrillaPlasticos(){
            if (dgvPlasticos.Rows.Count > 0){
                int idEstado = 0;
                foreach (DataGridViewRow fila in dgvPlasticos.Rows) {
                    idEstado = Convert.ToInt16(fila.Cells["id_estado"].Value);
                    if (idEstado == Convert.ToInt16(Presentacion_Plasticos.ESTADO.PAGADO))
                        fila.DefaultCellStyle.BackColor = Color.LightGreen;
                    else if (idEstado == Convert.ToInt16(Presentacion_Plasticos.ESTADO.RECHAZADO))
                        fila.DefaultCellStyle.BackColor = Color.Tomato;
                }
            }
        }
        
        #region MÉTODOS CONTROLES BACKGROUNDWORKERS
        private void bgwListarServicios_ProgressChanged(object sender, ProgressChangedEventArgs e){
            double porcentajeHecho = 0;
            pbProgreso.Value = e.ProgressPercentage;
            porcentajeHecho = (contadorParcial * 100) / total;
            lblProgreso.Text = String.Format("Listando servicios adheridos {0}%", porcentajeHecho);
        }

        private void bgwListarServicios_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pbProgreso.Value = pbProgreso.Maximum;
            this.Cursor = Cursors.Arrow;
            imgReturn.Enabled = true;
        }

        private void bgwListarSubservicios_ProgressChanged(object sender, ProgressChangedEventArgs e){
            double porcentajeHecho = 0;
            pbProgreso.Value = e.ProgressPercentage;
            porcentajeHecho = (contadorParcial * 100) / total;
            lblProgreso.Text = String.Format("Listando subservicios {0}%", porcentajeHecho);
        }

        private void bgwListarSubservicios_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pbProgreso.Value = pbProgreso.Maximum;
            this.Cursor = Cursors.Arrow;
            imgReturn.Enabled = true;
        }

        private void bgwListarDeudasAdelantadas_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            double porcentajeHecho = 0;
            pbProgreso.Value = e.ProgressPercentage;
            porcentajeHecho = (contadorParcial * 100) / total;
            lblProgreso.Text = String.Format("Listando deudas adelantadas {0}%", porcentajeHecho);
        }

        private void bgwListarDeudasAdelantadas_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pbProgreso.Value = pbProgreso.Maximum;
            this.Cursor = Cursors.Arrow;
            imgReturn.Enabled = true;
        }

        private void bgwCalcularBonificaciones_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            double porcentajeHecho = 0;
            pbProgreso.Value = e.ProgressPercentage;
            porcentajeHecho = (contadorParcial * 100) / total;
            lblProgreso.Text = String.Format("Calculando bonificaciones {0}%", porcentajeHecho);
        }

        private void bgwCalcularBonificaciones_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pbProgreso.Value = pbProgreso.Maximum;
            this.Cursor = Cursors.Arrow;
            imgReturn.Enabled = true;
        }

        private void bgwCalcularMontosFinales_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            double porcentajeHecho = 0;
            pbProgreso.Value = e.ProgressPercentage;
            porcentajeHecho = (contadorParcial * 100) / total;
            lblProgreso.Text = String.Format("Calculando montos finales {0}%", porcentajeHecho);
        }

        private void bgwCalcularMontosFinales_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pbProgreso.Value = pbProgreso.Maximum;
            this.Cursor = Cursors.Arrow;
            imgReturn.Enabled = true;
        }

        private void bgwCargarPresentacionExistente_ProgressChanged(object sender, ProgressChangedEventArgs e){
            double porcentajeHecho = 1;
            pbProgreso.Value = e.ProgressPercentage;
            porcentajeHecho = (contadorParcial * 100) / total;
            lblProgreso.Text = String.Format("Cargando presentación {0}%", porcentajeHecho);
        }

        private void bgwCargarPresentacionExistente_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e){
            pbProgreso.Value = pbProgreso.Maximum;
            this.Cursor = Cursors.Arrow;
            imgReturn.Enabled = true;
        }
        #endregion

        public ABMDebitosPresentacionDetalles(int funcion, DataTable dtPlasticosRecibidos, DateTime fechaPresentacion, Presentacion_Debitos oPresentacionDebitos, int idPresentacionExistente, int idFormaPago)
        {
            dtPlasticosPresentacion = new DataTable();
            dtUsuariosServiciosPlasticos = new DataTable();
            dtPlasticosPresentacion = dtPlasticosRecibidos;
            this.fechaPresentacion = fechaPresentacion;
            this.oPresentacionDebitos = oPresentacionDebitos;
            funcionARealizar = funcion;
            this.idPresentacionExistente = idPresentacionExistente;
            this.idFormaPago = idFormaPago;
            InitializeComponent();
        }

        private void ABMDebitosPresentacionDetalles_Load(object sender, EventArgs e){
            dtPlasticoDetalles = new DataTable();
            dtPlasticoDetalles.Columns.Add("id_plastico", typeof(string));
            dtPlasticoDetalles.Columns.Add("usuario", typeof(string));
            dtPlasticoDetalles.Columns.Add("nombre", typeof(string));
            dtPlasticoDetalles.Columns.Add("deuda_atrasada", typeof(string));
            dtPlasticoDetalles.Columns.Add("monto_estimado", typeof(string));
            dtPlasticoDetalles.Columns.Add("monto_prefacturacion", typeof(string));
            dtPlasticoDetalles.Columns.Add("deuda_adelantada", typeof(string));
            dtPlasticoDetalles.Columns.Add("tipo_item", typeof(string));

            dtErroresProducidos.Columns.Add("id_usuario", typeof(string));
            dtErroresProducidos.Columns.Add("codigo_usuario", typeof(string));
            dtErroresProducidos.Columns.Add("usuario", typeof(string));
            dtErroresProducidos.Columns.Add("id_locacion", typeof(string));
            dtErroresProducidos.Columns.Add("error", typeof(string));


            lblPeriodoPresentacion.Text = String.Format("Datos de la presentación correspondiente al periodo: {0}/{1}", fechaPresentacion.Month, fechaPresentacion.Year);
            if (funcionARealizar == Convert.ToInt16(TAREA.CREACION_PRESENTACION)){
                pbProgreso.Visible = true;
                lblProgreso.Visible = true;
                pbProgreso.Maximum = dtPlasticosPresentacion.Rows.Count;
                imgReturn.Enabled = false;
                this.KeyPreview = false;
                Cursor = Cursors.WaitCursor;
                bgwListarDebitosYServiciosAdheridos.DoWork += ListarDebitosYServiciosAdheridos;
                bgwListarDebitosYServiciosAdheridos.RunWorkerCompleted += ListarSubServiciosP2;
                bgwListarDebitosYServiciosAdheridos.RunWorkerAsync();
                btnConfirmarPresentacion.Text = "Generar presentación";
            }
            else{
                btnConfirmarPresentacion.Text = "Realizar pago";
                pbProgreso.Visible = false;
                lblProgreso.Visible = false;
                dtUsuariosServiciosPlasticos = oPresentacionUsuariosServicios.Listar(oPresentacionDebitos.Id, 0);
                pbProgreso.Maximum = dtUsuariosServiciosPlasticos.Rows.Count;
                imgReturn.Enabled = false;
                this.KeyPreview = false;
                Cursor = Cursors.WaitCursor;
                bgwCargarPresentacionExistente.DoWork += CargarPresentacionExistente;
                bgwCargarPresentacionExistente.RunWorkerCompleted += Terminado;
                bgwCargarPresentacionExistente.RunWorkerAsync();
            }
           
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnAnexarDeuda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Permite anexar deudas atrasadas al servicio seleccionado. En desarrollo.");
        }

        private void dgvPlasticos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPlasticos.SelectedRows.Count > 0)
            {
                dtPlasticoDetalles.DefaultView.RowFilter = String.Format("id_plastico={0}", dgvPlasticos.SelectedRows[0].Cells["id_plastico"].Value.ToString());
                dtDeudasAnexadas.DefaultView.RowFilter = String.Format("id_plastico={0} and tipo_deuda={1}", dgvPlasticos.SelectedRows[0].Cells["id_plastico"].Value.ToString(), Convert.ToInt16(Presentacion_Usuarios_Servicios.TIPO_DEUDA.DEUDA_ADICIONAL));
            }
            foreach (DataGridViewRow fila in dgvServicios.Rows)
            {
                if (Convert.ToInt16(fila.Cells["tipo_item"].Value) == 1)
                    fila.DefaultCellStyle.BackColor = Color.CadetBlue;
                else
                    fila.DefaultCellStyle.BackColor = Color.LightBlue;
            }
        }

        private void btnConfirmarPresentacion_Click(object sender, EventArgs e)
        {
            dtErroresProducidos.Clear();
            if (funcionARealizar == Convert.ToInt16(TAREA.CREACION_PRESENTACION))
                ComenzarPresentacion();
            else
                GenerarPago();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtPlasticosPresentacion.Rows.Count > 0)
                    dtPlasticosPresentacion.DefaultView.RowFilter = String.Format("numero Like '%{0}%'", txtBuscar.Text);
                if (dgvPlasticos.SelectedRows.Count > 0)
                {
                    dtPlasticoDetalles.DefaultView.RowFilter = String.Format("id_plastico={0}", dgvPlasticos.SelectedRows[0].Cells["id_plastico"].Value.ToString());
                    dtDeudasAnexadas.DefaultView.RowFilter = String.Format("id_plastico={0} and tipo_deuda={1}", dgvPlasticos.SelectedRows[0].Cells["id_plastico"].Value.ToString(), Convert.ToInt16(Presentacion_Usuarios_Servicios.TIPO_DEUDA.DEUDA_ADICIONAL));
                }
                foreach (DataGridViewRow fila in dgvServicios.Rows)
                {
                    if (Convert.ToInt16(fila.Cells["tipo_item"].Value) == 1)
                        fila.DefaultCellStyle.BackColor = Color.CadetBlue;
                    else
                        fila.DefaultCellStyle.BackColor = Color.LightBlue;
                }
            }
            catch
            {

            }
        }

        private void btnListadoErrores_Click(object sender, EventArgs e)
        {
            //if (dtErroresProducidos.Rows.Count > 0)
            //{
            //    dgvErrores.DataSource = dtErroresProducidos;
            //    dgvErrores.Columns["id_usuario"].Visible = false;
            //    dgvErrores.Columns["codigo_usuario"].HeaderText = "Código usuario";
            //    dgvErrores.Columns["usuario"].HeaderText = "Usuario";
            //    dgvErrores.Columns["id_locacion"].HeaderText = "Código locación";
            //    dgvErrores.Columns["error"].HeaderText = "Error";
            //    pnlErrores.Location = new Point(
            //            this.ClientSize.Width / 2 - pnlErrores.Size.Width / 2,
            //            this.ClientSize.Height / 2 - pnlErrores.Size.Height / 2);
            //    pnlErrores.Anchor = AnchorStyles.None;
            //    pnlErrores.Visible = true;
            //}
            //else
            //    MessageBox.Show("No se han producido errores en el proceso.");
        }

        private void boton1_Click(object sender, EventArgs e)
        {
            //if (dgvErrores.Rows.Count > 0)
            //    oTools.ExportToExcel(dgvErrores, DateTime.Now.ToString("yyyy-MM-dd"));
            //else
            //    MessageBox.Show("No hay datos en la grilla.");
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

            if (txtBuscar.Text.Length == 0)
                dtPlasticosPresentacion.DefaultView.RowFilter = String.Format("id_plastico>0");
            if (dgvPlasticos.SelectedRows.Count > 0)
            {
                dtPlasticoDetalles.DefaultView.RowFilter = String.Format("id_plastico={0}", dgvPlasticos.Rows[0].Cells["id_plastico"].Value.ToString());
                dtDeudasAnexadas.DefaultView.RowFilter = String.Format("id_plastico={0} and tipo_deuda={1}", dgvPlasticos.SelectedRows[0].Cells["id_plastico"].Value.ToString(), Convert.ToInt16(Presentacion_Usuarios_Servicios.TIPO_DEUDA.DEUDA_ADICIONAL));
            }
            foreach (DataGridViewRow fila in dgvServicios.Rows)
            {
                if (Convert.ToInt16(fila.Cells["tipo_item"].Value) == 1)
                    fila.DefaultCellStyle.BackColor = Color.CadetBlue;
                else
                    fila.DefaultCellStyle.BackColor = Color.LightBlue;
            }

        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            dtPlasticosPresentacion.DefaultView.RowFilter = String.Format("id_plastico>0");
            ExportarAExcel();

        }

        private void dgvPlasticos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnExportar_Click_1(object sender, EventArgs e)
        {
            dtPlasticosPresentacion.DefaultView.RowFilter = String.Format("id_plastico>0");
            ExportarAExcel();
        }
    }
}//251119fede
