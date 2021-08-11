using CapaNegocios;
using CapaPresentacion.Cuenta_Corriente;
using CapaPresentacion.Impresiones;
using CapaPresentacion.Seguridad;
using PlataformasPagos.CaptarPagos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;


namespace CapaPresentacion
{
    public partial class frmUsuariosCtaCteConsultaNuevo : Form
    {
        #region [DECLARACIONES]
        private Thread hilo;
        private delegate void myDel();

        public bool SoloVer = false, emailPago=false;
        public Boolean huboCambios = false;

        private Configuracion oConf = new Configuracion();
        private frmPopUp oPop;
        private Usuarios_Servicios oUsuServ = new Usuarios_Servicios();
        private Usuarios_Locaciones oUsuLoc = new Usuarios_Locaciones();
        private Usuarios_CtaCte oUsuCtaCte = new Usuarios_CtaCte();
        private Comprobantes oComprobante = new Comprobantes();
        private Usuarios_CtaCte oUsuarios_CtaCte = new Usuarios_CtaCte();
        private Usuarios_CtaCte_Det Ousuarios_CtaCte_Det = new Usuarios_CtaCte_Det();
        private Usuarios_CtaCte_Recibos Ousuarios_CtaCte_Recibos = new Usuarios_CtaCte_Recibos();
        private Impresion Oimpresion = new Impresion();
        private Facturacion ofacturacion = new Facturacion();
        private Usuarios_Dom_Fiscal oUsuariosDomFiscal = new Usuarios_Dom_Fiscal();

        private DataTable dtLocaciones;
        private DataTable dtCtaCte;
        private DataTable dtComprobantesHistorial = new DataTable();
        private DataTable dt = new DataTable();
        private DataTable dt__Locaciones = new DataTable();
        private DataTable dtComprobantes = new DataTable();
        private DataTable dtEstado = new DataTable();
        private DataTable dtCtacteAfip;

        private Int32 Usuario_Id = 0;
        private Int32 Locacion_Id = 0;
        private int id_Comp = 0;
        private int formatoConsultaCtaCte = 0;
        private int tipoelimina = 0; 
        private int codigoError = 0;
        private int idLocacionSeleccionada = 0;
        private int idComprobanteSeleccionado = 0;
        private decimal saldo2 = 0;
        private decimal saldoEstado = 0;
        private string Fecha_Desde;
        private string Fecha_Hasta;
        private string nombreAarchivo;
        private string email = "";
        private string rutaSalidaPdf = "";
        private bool historialComprobantesCargado = false;
        private decimal saldo = 0;
        #endregion

        #region [METODOS]
        private void ComenzarCarga()
        {          
            pgCircular.Start();
            imgReturn.Enabled = false;

            dgvComprobantes.DataSource = null;
            dgvLineal.DataSource = null;

            hilo = new Thread(new ThreadStart(CargarDatos));
            hilo.Start();
        }
        private void CargarDatos()
        {
            dtCtaCte = oUsuarios_CtaCte.ListarCtaCteCompletaNuevo(this.Usuario_Id, this.Locacion_Id);

            //Para la consulta Desglosada
            foreach (DataRow dr in dtCtaCte.Rows)
            {
                if (!string.IsNullOrEmpty(dr["recibo_borrado"].ToString()))
                {
                    if (Convert.ToInt32(dr["recibo_borrado"]) == 1)
                    {
                        dr["personalrecibo"] = "";
                        dr["recibo"] = "";
                    }
                }
            }

            dtComprobantesHistorial.Rows.Clear();

            myDel MD = new myDel(AsignarDatos);
            
            this.Invoke(MD, new object[] { });
            
            pgCircular.Stop();
        }
        private void CalcularSaldoUsuario()
        {
            DataTable DataSaldos = oUsuLoc.ListarLocacionesServicio(Usuarios.CurrentUsuario.Id, 0, true);

            var total = DataSaldos.Compute("SUM(saldo)", "");

            lblSaldoTotalLoc.Text = "Saldo Usuario: $" + total.ToString();
        }
        private void CalcularSaldoLocacion()
        {
            saldo2 = 0;
            foreach (DataGridViewRow item in dgvComprobantes.Rows)
                saldo2 += Convert.ToDecimal(item.Cells["importe_saldo"].Value);
            
            LbSaldoCta.Text = "Saldo Locacion: $ " + saldo2.ToString();
        }
        private void AsignarDatos()
        {
            imgReturn.Enabled = true;

            foreach (Control item in this.Controls)
                item.Enabled = true;

            if (ckPorFechas.Checked == true)
                dtCtaCte.DefaultView.RowFilter = string.Format("fecha_desde >= '{0}' and fecha_hasta <= '{1}' ", Fecha_Desde, Fecha_Hasta);
            else
                dtCtaCte.DefaultView.RowFilter = string.Format("id_usuarios_locacion = {0} ", Convert.ToInt32(cboLocacion.SelectedValue));

            dgvComprobantes.DataSource = dtCtaCte;
            dgvLineal.DataSource = dtCtaCte;

            FormatearGrilla();
            FormatearGrillaLineal();

            CalcularSaldoLocacion();
            CalcularSaldoUsuario();

            btnExportar.Enabled = !SoloVer;
            btnRecibos.Enabled = !SoloVer;

            DataRow drLocacionSeleccionada = dtLocaciones.Select(String.Format("id={0}", cboLocacion.SelectedValue))[0];
            Usuarios.CurrentUsuario.localidad = drLocacionSeleccionada["localidad"].ToString();
            Usuarios.CurrentUsuario.Cod_postal = drLocacionSeleccionada["codigo_postal"].ToString();
            Usuarios.CurrentUsuario.Calle = drLocacionSeleccionada["calle"].ToString();
            Usuarios.CurrentUsuario.Altura = Convert.ToInt32(drLocacionSeleccionada["Altura"].ToString());
            Usuarios.CurrentUsuario.piso = drLocacionSeleccionada["piso"].ToString();
            Usuarios.CurrentUsuario.Depto = drLocacionSeleccionada["depto"].ToString();
            Usuarios.CurrentUsuario.Entre1 = drLocacionSeleccionada["entre_calle_1"].ToString();
            Usuarios.CurrentUsuario.Entre2 = drLocacionSeleccionada["entre_calle_2"].ToString();

            Usuarios.CurrentUsuarioDomFiscal = oUsuariosDomFiscal.LlenarDatosLocFiscal(Usuarios.Current_IdUsuarioLocacion);

            lbdomfiscal.Text = Usuarios.CurrentUsuarioDomFiscal.R_Social.ToString().Trim() + " - " + Comprobantes_Iva.CurrentComprobantes_Iva.Descripcion.ToString().Trim() + '"' + Comprobantes_Iva.CurrentComprobantes_Iva.Letra + '"';
            lblocalidad.Text = cboLocacion.Text.ToString();

            SeleccionarUltimaFilaDelDataGrid();
        }
        private void FormatearGrilla()
        {
            try
            {
                Decimal saldo = 0;
                foreach (DataGridViewRow dr in dgvComprobantes.Rows)
                {
                    if (dr.Cells["tipo"].Value.ToString() == "F")
                    {
                        if (Convert.ToInt32(dr.Cells["id_comprobantes_tipo"].Value.ToString()) == (int)Comprobantes_Tipo.Tipo.CREDITO_A_CUENTA)
                        {
                            dr.Cells["importe_pago"].Value = 0;

                        }

                        else
                        {
                            dr.Cells["importe_pago"].Value = 0;
                            dr.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                            dr.DefaultCellStyle.ForeColor = Color.Black;
                        }
                    }
                    else
                    {
                        dr.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                        dr.Cells["importe_saldo_comprobante"].Value = 0;
                        dr.Cells["importe_saldo_comprobante"].Style.ForeColor = Color.Transparent;
                        dr.Cells["descripcion"].Value = dr.Cells["descripcion"].Value.ToString();
                    }
                    dr.Cells["importe_saldo"].Style.ForeColor = Color.Black;
                    dr.Cells["importe_saldo"].Style.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                    saldo = (decimal.Parse(dr.Cells["importe_final"].Value.ToString()) - decimal.Parse(dr.Cells["importe_pago"].Value.ToString()));
                }

                foreach (DataGridViewColumn item in dgvComprobantes.Columns)
                {
                    item.Visible = false;
                    item.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
               
                dgvComprobantes.Columns["id"].Visible = false;

                dgvComprobantes.Columns["fecha_movimiento"].Visible = true;
                dgvComprobantes.Columns["fecha_movimiento"].HeaderText = "FECHA";
                dgvComprobantes.Columns["fecha_movimiento"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvComprobantes.Columns["fecha_movimiento"].DisplayIndex = 0;

                dgvComprobantes.Columns["personalCtacte"].Visible = true;
                dgvComprobantes.Columns["personalCtacte"].HeaderText = "PERSONAL FACTURA";
                dgvComprobantes.Columns["personalCtacte"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvComprobantes.Columns["personalCtacte"].DisplayIndex = 1;
                dgvComprobantes.Columns["personalCtacte"].Width = 100;

                dgvComprobantes.Columns["descripcion"].Visible = true;
                dgvComprobantes.Columns["descripcion"].HeaderText = "DETALLE";
                dgvComprobantes.Columns["descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dgvComprobantes.Columns["fecha_desde"].Visible = true;
                dgvComprobantes.Columns["fecha_desde"].HeaderText = "DESDE";
                dgvComprobantes.Columns["fecha_desde"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                dgvComprobantes.Columns["fecha_hasta"].Visible = true;
                dgvComprobantes.Columns["fecha_hasta"].HeaderText = "HASTA";
                dgvComprobantes.Columns["fecha_hasta"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                dgvComprobantes.Columns["importe_original"].Visible = true;
                dgvComprobantes.Columns["importe_original"].DefaultCellStyle.Format = "c2";
                dgvComprobantes.Columns["importe_original"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvComprobantes.Columns["importe_original"].HeaderText = "IMPORTE ORIGINAL";
                dgvComprobantes.Columns["importe_original"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                dgvComprobantes.Columns["importe_punitorio"].Visible = true;
                dgvComprobantes.Columns["importe_punitorio"].DefaultCellStyle.Format = "c2";
                dgvComprobantes.Columns["importe_punitorio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvComprobantes.Columns["importe_punitorio"].HeaderText = "IMPORTE PUNITORIO";
                dgvComprobantes.Columns["importe_punitorio"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                dgvComprobantes.Columns["importe_bonificacion"].Visible = true;
                dgvComprobantes.Columns["importe_bonificacion"].DefaultCellStyle.Format = "c2";
                dgvComprobantes.Columns["importe_bonificacion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvComprobantes.Columns["importe_bonificacion"].HeaderText = "IMPORTE BONIF.";
                dgvComprobantes.Columns["importe_bonificacion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                dgvComprobantes.Columns["importe_provincial"].Visible = true;
                dgvComprobantes.Columns["importe_provincial"].DefaultCellStyle.Format = "c2";
                dgvComprobantes.Columns["importe_provincial"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvComprobantes.Columns["importe_provincial"].HeaderText = "IMPORTE PROVINCIAL";
                dgvComprobantes.Columns["importe_provincial"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                dgvComprobantes.Columns["Importe_saldo"].Visible = true;
                dgvComprobantes.Columns["Importe_saldo"].DefaultCellStyle.Format = "c2";
                dgvComprobantes.Columns["Importe_saldo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvComprobantes.Columns["Importe_saldo"].HeaderText = "SALDO";
                dgvComprobantes.Columns["Importe_saldo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dgvComprobantes.Columns["Importe_final"].Visible = true;
                dgvComprobantes.Columns["Importe_final"].DefaultCellStyle.Format = "c2";
                dgvComprobantes.Columns["Importe_final"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvComprobantes.Columns["Importe_final"].HeaderText = "IMPORTE FINAL";
                dgvComprobantes.Columns["Importe_final"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvComprobantes.Columns["Importe_final"].DisplayIndex = dgvComprobantes.Columns["Importe_saldo"].DisplayIndex - 1;


                if (dgvComprobantes.Columns["DetelleComp"] == null)
                {
                    DataGridViewLinkColumn link = new DataGridViewLinkColumn();

                    link.Text = "Detalle";
                    link.DataPropertyName = "Detalle";
                    link.Name = "cDetalle";
                    link.LinkColor = Color.White;
                    link.VisitedLinkColor = Color.White;
                    link.UseColumnTextForLinkValue = true;
                    link.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    link.HeaderText = "Detalle de Comp.";
                    link.DefaultCellStyle.BackColor = Color.White;
                    link.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    dgvComprobantes.Columns.Add(link);
                }

                dgvComprobantes.Columns["Recibo"].Visible = true;
                dgvComprobantes.Columns["Recibo"].HeaderText = "RECIBO";
                dgvComprobantes.Columns["Recibo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvComprobantes.Columns["Recibo"].DisplayIndex = dgvComprobantes.Columns["Importe_saldo"].DisplayIndex +2;
               
                dgvComprobantes.Columns["personalRecibo"].Visible = true;
                dgvComprobantes.Columns["personalRecibo"].HeaderText = "PERSONAL RECIBO";
                dgvComprobantes.Columns["personalRecibo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvComprobantes.Columns["personalRecibo"].DisplayIndex = dgvComprobantes.Columns["Importe_saldo"].DisplayIndex + 3;

                //coloreo la grilla segun el tipo de comprobante
                if (dgvComprobantes.Rows.Count > 0)
                {
                    foreach (DataGridViewRow item in dgvComprobantes.Rows)
                    {
                        int idTipoComprobante = Convert.ToInt32(item.Cells["id_comprobantes_Tipo"].Value);
                        switch (idTipoComprobante)
                        {
                            case 10:
                                //Tipo Plan de pago
                                item.DefaultCellStyle.BackColor = Color.LightGreen;

                                break;
                            case 7:
                                //comprobante de deuda
                                item.DefaultCellStyle.BackColor = Color.LightBlue;
                                break;
                            case 5:
                                //recibo
                                item.DefaultCellStyle.BackColor = Color.Thistle;
                                break;
                            case 9:
                                //recibo
                                item.DefaultCellStyle.BackColor = Color.Thistle;
                                break;
                            default:
                                item.DefaultCellStyle.BackColor = Color.White;
                                break;
                        }
                        item.Height = 30;
                        if (Convert.ToDecimal(item.Cells["Importe_saldo"].Value) > 0)
                        {
                            item.DefaultCellStyle.BackColor = Color.Tomato;
                        }
                    }

                }

            }
            catch { }

        }
        private void FormatearGrillaLineal()
        {
            try
            {
                Decimal saldo = 0;
                foreach (DataGridViewRow dr in dgvLineal.Rows)
                {
                    if (dr.Cells["tipo"].Value.ToString() == "F")
                    {
                        if (Convert.ToInt32(dr.Cells["id_comprobantes_tipo"].Value.ToString()) == (int)Comprobantes_Tipo.Tipo.CREDITO_A_CUENTA)
                        {
                            dr.Cells["importe_pago"].Value = 0;

                        }

                        else
                        {
                            dr.Cells["importe_pago"].Value = 0;
                            dr.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                            dr.DefaultCellStyle.ForeColor = Color.Black;
                        }
                    }
                    else
                    {
                        dr.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                        dr.Cells["importe_saldo_comprobante"].Value = 0;
                        dr.Cells["importe_saldo_comprobante"].Style.ForeColor = Color.Transparent;
                        dr.Cells["descripcion"].Value = dr.Cells["descripcion"].Value.ToString();
                    }
                    dr.Cells["importe_saldo"].Style.ForeColor = Color.Black;
                    dr.Cells["importe_saldo"].Style.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                    saldo = (decimal.Parse(dr.Cells["importe_final"].Value.ToString()) - decimal.Parse(dr.Cells["importe_pago"].Value.ToString()));
                }

                foreach (DataGridViewColumn item in dgvLineal.Columns)
                    item.Visible = false;

                dgvLineal.Columns["id_comprobantes_tipo"].Visible = true;
                dgvLineal.Columns["id_comprobantes_tipo"].HeaderText = "TIPOCOMP";
                dgvLineal.Columns["id_comprobantes_tipo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                dgvLineal.Columns["fecha_movimiento"].Visible = true;
                dgvLineal.Columns["fecha_movimiento"].HeaderText = "FECHA";
                dgvLineal.Columns["fecha_movimiento"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                dgvLineal.Columns["personalCtacte"].Visible = true;
                dgvLineal.Columns["personalCtacte"].HeaderText = "PERSONAL FACTURA";
                dgvLineal.Columns["personalCtacte"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvLineal.Columns["personalCtacte"].Width = 100;

                dgvLineal.Columns["descripcion"].Visible = true;
                dgvLineal.Columns["descripcion"].HeaderText = "DETALLE";
                dgvLineal.Columns["descripcion"].Width = 100;
                dgvLineal.Columns["descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;


                dgvLineal.Columns["fecha_desde"].Visible = true;
                dgvLineal.Columns["fecha_desde"].HeaderText = "DESDE";
                dgvLineal.Columns["fecha_desde"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                dgvLineal.Columns["fecha_hasta"].Visible = true;
                dgvLineal.Columns["fecha_hasta"].HeaderText = "HASTA";
                dgvLineal.Columns["fecha_hasta"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                dgvLineal.Columns["importe_original"].Visible = true;
                dgvLineal.Columns["importe_original"].DefaultCellStyle.Format = "c2";
                dgvLineal.Columns["importe_original"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvLineal.Columns["importe_original"].HeaderText = "IMPORTE ORIGINAL";
                dgvLineal.Columns["importe_original"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvLineal.Columns["importe_original"].Width = 150;

                dgvLineal.Columns["importe_bonificacion"].Visible = true;
                dgvLineal.Columns["importe_bonificacion"].DefaultCellStyle.Format = "c2";
                dgvLineal.Columns["importe_bonificacion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvLineal.Columns["importe_bonificacion"].HeaderText = "IMPORTE BONIF.";
                dgvLineal.Columns["importe_bonificacion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvLineal.Columns["importe_bonificacion"].Width = 150;

                dgvLineal.Columns["importe_punitorio"].Visible = true;
                dgvLineal.Columns["importe_punitorio"].DefaultCellStyle.Format = "c2";
                dgvLineal.Columns["importe_punitorio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvLineal.Columns["importe_punitorio"].HeaderText = "IMPORTE PUNITORIO";
                dgvLineal.Columns["importe_punitorio"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvLineal.Columns["importe_punitorio"].Width = 200;

                dgvLineal.Columns["importe_provincial"].Visible = true;
                dgvLineal.Columns["importe_provincial"].DefaultCellStyle.Format = "c2";
                dgvLineal.Columns["importe_provincial"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvLineal.Columns["importe_provincial"].HeaderText = "IMPORTE PROVINCIAL";
                dgvLineal.Columns["importe_provincial"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvLineal.Columns["importe_provincial"].Width = 200;

                dgvLineal.Columns["Importe_final"].Visible = true;
                dgvLineal.Columns["Importe_final"].DefaultCellStyle.Format = "c2";
                dgvLineal.Columns["Importe_final"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvLineal.Columns["Importe_final"].Width = 150;
                dgvLineal.Columns["Importe_final"].HeaderText = "IMPORTE FINAL";
                dgvLineal.Columns["Importe_final"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                dgvLineal.Columns["Importe_saldo"].Visible = true;
                dgvLineal.Columns["Importe_saldo"].DefaultCellStyle.Format = "c2";
                dgvLineal.Columns["Importe_saldo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvLineal.Columns["importe_saldo"].Width = 150;
                dgvLineal.Columns["Importe_saldo"].HeaderText = "SALDO";
                dgvLineal.Columns["Importe_saldo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dgvLineal.Columns["Recibo"].Visible = true;
                dgvLineal.Columns["Recibo"].HeaderText = "RECIBO";
                dgvLineal.Columns["Recibo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                dgvLineal.Columns["personalRecibo"].Visible = true;
                dgvLineal.Columns["personalRecibo"].HeaderText = "PERSONAL RECIBO";
                dgvLineal.Columns["personalRecibo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;


                if (dgvLineal.Columns["DetelleComp"] == null)
                {
                    DataGridViewLinkColumn link = new DataGridViewLinkColumn();


                    link.Text = "Detalle";
                    link.DataPropertyName = "Detalle";
                    link.Name = "cDetalle";
                    link.LinkColor = Color.White;
                    link.VisitedLinkColor = Color.White;
                    link.UseColumnTextForLinkValue = true;
                    link.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    link.HeaderText = "Detalle de Comp.";
                    link.DefaultCellStyle.BackColor = Color.White;
                    link.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvLineal.Columns.Add(link);
                }


            }
            catch 
            { 

            
            }

        }
        private void Eliminar_Recibo()
        {
            DataTable dtSalida = new DataTable();
            int NoBorraRecibo = 0;
            string salida = "";
            int codSalida = 0;
            NoBorraRecibo = Ousuarios_CtaCte_Recibos.borrar_recibo(Convert.ToInt32(dgvRecibos.SelectedRows[0].Cells["id_usuarios_ctacte_recibos"].Value.ToString()), out dtSalida,out codSalida,out salida);
            if (NoBorraRecibo == 1)
            {
                if (codSalida != 0)
                    MessageBox.Show(salida, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            ComenzarCarga();
        }
        private void Detalles()
        {
            oPop = new frmPopUp();
            if (dgvComprobantes.SelectedRows[0].Cells["tipo"].Value.ToString() == "R")
            {
                try
                {
                    FrmUsuariosCtaCteDetalles Frm = new Cuenta_Corriente.FrmUsuariosCtaCteDetalles();
                    Frm.idViene = Convert.ToInt32(dgvComprobantes.SelectedRows[0].Cells["id"].Value);
                    Frm.tipoViene = "R";
                    Frm.lb1 = dgvComprobantes.SelectedRows[0].Cells["descripcion"].Value.ToString();
                    Frm.datosUsuarios = lblUsuario.Text;
                    Frm.datosLocacion = lblocalidad.Text;
                    oPop.Formulario = Frm;
                    oPop.Maximizar = false;
                    oPop.ShowDialog();
                }
                catch { }
            }
            else
            {
                try
                {
                    FrmUsuariosCtaCteDetalles Frm = new Cuenta_Corriente.FrmUsuariosCtaCteDetalles();
                    Frm.idViene = Convert.ToInt32(dgvComprobantes.SelectedRows[0].Cells["id_comprobantes"].Value.ToString());
                    Frm.tipoViene = "F";
                    Frm.lb1 = dgvComprobantes.SelectedRows[0].Cells["descripcion"].Value.ToString();
                    Frm.fechaDesde = Convert.ToDateTime(dgvComprobantes.SelectedRows[0].Cells["fecha_desde"].Value);
                    Frm.fechaHasta = Convert.ToDateTime(dgvComprobantes.SelectedRows[0].Cells["fecha_hasta"].Value);
                    Frm.datosUsuarios = lblUsuario.Text;
                    Frm.datosLocacion = lblocalidad.Text;
                    oPop.Formulario = Frm;
                    oPop.Maximizar = false;
                    oPop.ShowDialog();
                }
                catch { }
            }

        }
        private void EliminarComprobante()
        {
            idComprobanteSeleccionado = Convert.ToInt32(dgvComprobantes.SelectedRows[0].Cells["id_comprobantes"].Value);

            if (!new Personal_Roles().VerificarSiTienePermiso(Objetos.Acciones.Eliminar_Comprobante))
            {
                frmPersonalResponsable frmPersonalResp = new frmPersonalResponsable(Objetos.Acciones.Eliminar_Comprobante, Entidades.Tabla.Comprobantes, idComprobanteSeleccionado);
                using (frmPopUp popUp = new frmPopUp())
                {
                    popUp.Formulario = frmPersonalResp;
                    popUp.Maximizar = false;
                    if (popUp.ShowDialog() != DialogResult.OK)
                        return;
                }
            }

            idLocacionSeleccionada = Convert.ToInt32(cboLocacion.SelectedValue);
            
            pgCircular.Start();

            foreach (Control item in this.Controls)
                item.Enabled = false;

            hilo = new Thread(new ThreadStart(EliminarSegundoPlano));
            hilo.Start();
        }
        private void EliminarSegundoPlano()
        {
            if (oComprobante.ContieneSubServicios(idComprobanteSeleccionado))
            {
                DataTable dtFEchasAnteriores = oComprobante.GetFechasAnterioresElimina(idComprobanteSeleccionado);
                if (dtFEchasAnteriores.Rows.Count > 0)
                {
                    int contadorSinFechas = 0;
                    foreach (DataRow item in dtFEchasAnteriores.Rows)
                    {
                        if (item["fecha_anterior"].ToString() == "")
                            contadorSinFechas++;
                    }
                    if (contadorSinFechas > 0)
                    {
                        MessageBox.Show("Para algunos servicios involucrados en el comprobante que desea borrar, no existe una fecha de fin de servicio anterior. Se le asignara como fecha de fin de servicio la fecha de conexion del mismo.\n Se mostrara una ventana con los servicios y las fechas correspondientes.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmComprobantesFechasAnteriores oFrm = new frmComprobantesFechasAnteriores();
                        oFrm.dtServicios = dtFEchasAnteriores;
                        if(oFrm.ShowDialog()==DialogResult.OK)
                        {
                            codigoError = oComprobante.EliminarComprobante(idComprobanteSeleccionado, idLocacionSeleccionada, Usuario_Id);
                        }

                    }
                    else
                        codigoError = oComprobante.EliminarComprobante(idComprobanteSeleccionado, idLocacionSeleccionada, Usuario_Id);
                }
            }
            else
                codigoError = oComprobante.EliminarComprobante(idComprobanteSeleccionado, idLocacionSeleccionada, Usuario_Id);

            myDel MD = new myDel(ActualizarDatos);
            this.Invoke(MD, new object[] { });
            pgCircular.Stop();
        }
        private void ActualizarDatos()
        {
            switch (codigoError)
            {
                case 0:
                    if (Convert.ToInt32(dgvComprobantes.SelectedRows[0].Cells["id_comprobantes_tipo"].Value) == Convert.ToInt32(Comprobantes_Tipo.Tipo.FACTURA_A) ||
                        Convert.ToInt32(dgvComprobantes.SelectedRows[0].Cells["id_comprobantes_tipo"].Value) == Convert.ToInt32(Comprobantes_Tipo.Tipo.FACTURA_B))
                        MessageBox.Show("La nota de credito fue realizada correctamente", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("El comprobante ha sido eliminado correctamente", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    for (int i = 0; i < dtLocaciones.Rows.Count; i++)
                    {
                        Usuarios_Locaciones.ActualizarSaldo(Convert.ToInt32(dtLocaciones.Rows[i]["id"]));
                    }
                    ComenzarCarga();
                    break;
                case -1:
                    MessageBox.Show("Error al eliminar comprobante. Controle que el comprobante seleccionado no se encuentre pago o, en caso de ser un comprobante de deuda, sea el último generado.");
                    codigoError = 0;
                    idComprobanteSeleccionado = 0;
                    idLocacionSeleccionada = 0;
                    ComenzarCarga();

                    break;
                case -2:
                    ComenzarCarga();
                    break;
                default:
                    dtComprobantes = oComprobante.GetComprobante(codigoError);
                    if (dtComprobantes.Rows.Count > 0)
                    {
                        string detalle = dtComprobantes.Rows[0]["descripcion"].ToString();
                        MessageBox.Show("Se genero correctamente la nota de credito (" + detalle + ").", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        for (int i = 0; i < dtLocaciones.Rows.Count; i++)
                        {
                            Usuarios_Locaciones.ActualizarSaldo(Convert.ToInt32(dtLocaciones.Rows[i]["id"]));
                        }
                    }
                    idComprobanteSeleccionado = 0;
                    idLocacionSeleccionada = 0;
                    codigoError = 0;
                    ComenzarCarga();
                    break;
            }

        }
        private void MostrarRecibos()
        {
            dgvRecibos.DataSource = null;

            DataTable dt = oUsuCtaCte.ListarCtaCteCompletaNuevo2(Convert.ToInt32(dgvComprobantes.SelectedRows[0].Cells["id"].Value));

            dgvRecibos.DataSource = dt;

            FormatearGrillaRecibos();
        }
        private void FormatearGrillaRecibos()
        {
            try
            {
                dgvRecibos.Columns["Numero_muestra"].DisplayIndex = 1;
                dgvRecibos.Columns["Numero_muestra"].HeaderText = "DESCRIPCION";
                dgvRecibos.Columns["personal"].HeaderText = "PERSONAL";
                dgvRecibos.Columns["personal"].DisplayIndex = 1;
                dgvRecibos.Columns["Id_Comprobantes"].Visible = false;
                dgvRecibos.Columns["Id_Usuarios_ctacte_recibos"].Visible = false;
                dgvRecibos.Columns["id_usuarios_ctacte"].Visible = false;
                dgvRecibos.Columns["numero"].Visible = false;
                dgvRecibos.Columns["id_Ctacte_relacion"].Visible = false;
                dgvRecibos.Columns["importeImputa"].HeaderText = "IMPORTE IMPUTA";
                dgvRecibos.Columns["importeImputa"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvRecibos.Columns["importeImputa"].DefaultCellStyle.Format = "c";
                dgvRecibos.Columns["cuenta"].HeaderText = "Nro. de Cuenta";
                dgvRecibos.Columns["cuenta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvRecibos.Columns["fecha_movimiento"].HeaderText = "FECHA MOVIMIENTO";
                dgvRecibos.Columns["fecha_movimiento"].DisplayIndex = 0;
                dgvRecibos.Columns["importe_recibo"].HeaderText = "IMPORTE RECIBO";
                dgvRecibos.Columns["importe_recibo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvRecibos.Columns["importe_recibo"].DefaultCellStyle.Format = "c";
                if (dgvRecibos.Columns["EliminarPago"] == null)
                {
                    DataGridViewLinkColumn link = new DataGridViewLinkColumn();

                    link.Text = "Eliminar pago";
                    link.DataPropertyName = "EliminarPago";
                    link.Name = "EliminarPago";
                    link.LinkColor = Color.White;
                    link.VisitedLinkColor = Color.White;
                    link.UseColumnTextForLinkValue = true;
                    link.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    link.HeaderText = "Eliminar pago";
                    link.DefaultCellStyle.BackColor = Color.White;

                    dgvRecibos.Columns.Add(link);
                }
                dgvRecibos.Columns["EliminarPago"].DisplayIndex = dgvRecibos.Columns.Count - 1;

                if (dgvRecibos.Columns["Imprimir"] == null)
                {
                    DataGridViewLinkColumn link = new DataGridViewLinkColumn();

                    link.Text = "Imprimir";
                    link.DataPropertyName = "Imprimir";
                    link.Name = "Imprimir";
                    link.LinkColor = Color.White;
                    link.VisitedLinkColor = Color.White;
                    link.UseColumnTextForLinkValue = true;
                    link.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    link.HeaderText = "Imprimir";
                    link.DefaultCellStyle.BackColor = Color.White;

                    dgvRecibos.Columns.Add(link);
                }
                dgvRecibos.Columns["Imprimir"].DisplayIndex = dgvRecibos.Columns.Count - 1;

                if (dgvRecibos.Columns["FormaPago"] == null)
                {
                    DataGridViewLinkColumn link = new DataGridViewLinkColumn();

                    link.Text = "Forma de Pago";
                    link.DataPropertyName = "FormaPago";
                    link.Name = "FormaPago";
                    link.LinkColor = Color.White;
                    link.VisitedLinkColor = Color.White;
                    link.UseColumnTextForLinkValue = true;
                    link.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    link.HeaderText = "Forma de Pago";
                    link.DefaultCellStyle.BackColor = Color.White;

                    dgvRecibos.Columns.Add(link);
                }
                dgvRecibos.Columns["FormaPago"].DisplayIndex = dgvRecibos.Columns.Count - 1;

                foreach (DataGridViewRow item in dgvRecibos.Rows)
                    item.Height = 30;
            }
            catch { }

        }
        private void SeleccionarUltimaFilaDelDataGrid()
        {
           if(formatoConsultaCtaCte == 1)
            { 
                if(dgvComprobantes.Rows.Count > 0)
                {
                    dgvComprobantes.FirstDisplayedScrollingRowIndex = dgvComprobantes.Rows.Count - 1;
                    dgvComprobantes.Rows[dgvComprobantes.Rows.Count - 1].Selected = true;
                }
            }
            else 
            {
                if (dgvLineal.Rows.Count > 0)
                {
                    dgvLineal.FirstDisplayedScrollingRowIndex = dgvLineal.Rows.Count - 1;
                    dgvLineal.Rows[dgvLineal.Rows.Count - 1].Selected = true;
                }
            }
        }
        #endregion
        public frmUsuariosCtaCteConsultaNuevo(Int32 idusuario, Int32 idlocacion)
        {
            InitializeComponent();

            if (idusuario > 0)
            {
                this.Usuario_Id = idusuario;
                this.Locacion_Id = idlocacion;

                lblUsuario.Text = String.Format("[{0}] - {1}, {2}", Usuarios.CurrentUsuario.Codigo, Usuarios.CurrentUsuario.Apellido, Usuarios.CurrentUsuario.Nombre);
            }

            ckPreviewImpresion.CheckState = new Configuracion().GetValor_N("PreviewConsulta") == 1 ? CheckState.Checked : CheckState.Unchecked;

            dtComprobantesHistorial.Columns.Add("Descripcion", typeof(String));
            dtComprobantesHistorial.Columns.Add("Fecha", typeof(String));
            dtComprobantesHistorial.Columns.Add("Periodo", typeof(String));
            dtComprobantesHistorial.Columns.Add("letra", typeof(String));
            dtComprobantesHistorial.Columns.Add("Debe", typeof(Decimal));
            dtComprobantesHistorial.Columns.Add("Haber", typeof(Decimal));
            dtComprobantesHistorial.Columns.Add("Saldo", typeof(Decimal));
            dtComprobantesHistorial.Columns.Add("PagoImputacion", typeof(Decimal));
            dtComprobantesHistorial.Columns.Add("Cae", typeof(String));
            dtComprobantesHistorial.Columns.Add("Id", typeof(Int32));
            dtComprobantesHistorial.Columns.Add("orden", typeof(Int32));
            dtComprobantesHistorial.Columns.Add("IdCtacte", typeof(Int32));
            dtComprobantesHistorial.Columns.Add("id_Comprobantes_tipo", typeof(Int32));
            dtComprobantesHistorial.Columns.Add("id_comprobantes_tipo_ctacte", typeof(Int32));
            dtComprobantesHistorial.Columns.Add("ctacte_desde", typeof(DateTime));
            dtComprobantesHistorial.Columns.Add("ctacte_hasta", typeof(DateTime));
            dtComprobantesHistorial.Columns.Add("ctacte_importe", typeof(Decimal));
            dtComprobantesHistorial.Columns.Add("ctacte_saldo", typeof(Decimal));
            dtComprobantesHistorial.Columns.Add("id_Recibo", typeof(Int32));
            dtComprobantesHistorial.Columns.Add("EstadoComprobante", typeof(Int32));
            dtComprobantesHistorial.Columns.Add("Id_Locacion", typeof(Int32));
        }
        private void frmUsuariosCtaCteConsulta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
        private void frmUsuariosCtaCteConsulta_Load(object sender, EventArgs e)
        {
            dtLocaciones = oUsuLoc.ListarLocacionesServicio(this.Usuario_Id);
            dtLocaciones.Columns.Add("Dato", typeof(String));

            cboLocacion.DataSource = dtLocaciones;
            cboLocacion.DisplayMember = "locacion";
            cboLocacion.ValueMember = "id";
            cboLocacion.Focus();

            this.Locacion_Id = Usuarios.Current_IdUsuarioLocacion;

            formatoConsultaCtaCte = oConf.GetValor_N("TipoConsultaCuentaCorriente");
            if (Personal.Id_Login == 1)
                generarLinkDePagoToolStripMenuItem.Visible = true;
            else
                generarLinkDePagoToolStripMenuItem.Visible = false;

            ComenzarCarga();

        }
        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void pnReturnPDF_Click(object sender, EventArgs e)
        {
            pnlRuta.Visible = false;
        }
        private void pnReturnCorreo_Click(object sender, EventArgs e)
        {
            pnlEmail.Visible = false;
        }
        private void lblImpago_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea Reimprimir el Recibo Seleccionado?", "Mensaje del Sistema", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Oimpresion.NumeroMuestra = dgvRecibos.SelectedRows[0].Cells["numero"].Value.ToString();
                Oimpresion.ImprimeReciboInterno(Convert.ToInt32(dgvRecibos.SelectedRows[0].Cells["id_comprobantes"].Value.ToString()), Convert.ToInt32(dgvRecibos.SelectedRows[0].Cells["cuenta"].Value.ToString()));
            }
        }
        private void ckTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (ckTodos.Checked == true)
            {
                ckPorFechas.Checked = false;
                dtpDesde.Enabled = false;
                dtpHasta.Enabled = false;
            }
        }
        private void ckPorFechas_CheckedChanged(object sender, EventArgs e)
        {
            if (ckPorFechas.Checked == true)
            {
                ckTodos.Checked = false;
                dtpDesde.Enabled = true;
                dtpHasta.Enabled = true;
            }
        }       
        private void cboLocacion_SelectedValueChanged(object sender, EventArgs e)
        {

            try
            {
                Usuarios.Current_IdUsuarioLocacion = Convert.ToInt32(cboLocacion.SelectedValue);

                this.Locacion_Id = Convert.ToInt32(cboLocacion.SelectedValue);

                if(dgvComprobantes.DataSource != null)
                    ComenzarCarga();
            }
            catch (Exception c){
                String DF = c.ToString();
            }
        }
        private void dgvComprobantes_SelectionChanged(object sender, EventArgs e)
        {
            if(formatoConsultaCtaCte == 1)
            {
                if (dgvComprobantes.SelectedRows.Count > 0)
                {
                    id_Comp = Convert.ToInt32(dgvComprobantes.SelectedRows[0].Cells["id_comprobantes"].Value.ToString());
                    this.MostrarRecibos();
                    Int32 idTipoComprobante = Convert.ToInt32(dgvComprobantes.SelectedRows[0].Cells["id_comprobantes_Tipo"].Value);

                    if (idTipoComprobante == Convert.ToInt32(Comprobantes_Tipo.Tipo.COMPROBANTE_DEUDA) ||(idTipoComprobante == Convert.ToInt32(Comprobantes_Tipo.Tipo.PLAN_DE_PAGO)))
                    {
                        tsEliminar.Text = "Eliminar";
                        tsEliminar.Enabled = true;
                        tipoelimina = 0;
                    }
                    else
                    {
                        if (idTipoComprobante == (int)Comprobantes_Tipo.Tipo.REMITO)
                        {
                            tsEliminar.Text = "Deshacer remito";
                            tipoelimina = 2;
                            tsEliminar.Enabled = true;

                        }
                        else if (idTipoComprobante == (int)Comprobantes_Tipo.Tipo.CREDITO_A_CUENTA)
                        {
                            tsEliminar.Text = "Eliminar";
                            tsEliminar.Enabled = true;
                        }
                        else
                            tsEliminar.Enabled = false;
                       
                    }
                }
            }
        }
        private void dgvComprobantes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvComprobantes.Columns[e.ColumnIndex].Name == "cDetalle")
                Detalles();
        }
        private void dgvComprobantes_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    var hti = dgvComprobantes.HitTest(e.X, e.Y);
                    // Add this
                    dgvComprobantes.CurrentCell = dgvComprobantes.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    // Can leave these here - doesn't hurt
                    dgvComprobantes.Rows[e.RowIndex].Selected = true;
                    dgvComprobantes.Focus();
                    MenuAcciones.Show(Cursor.Position);

                }
                catch
                {

                }
            }
        }
        private void dgvDebeHaber_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            int EstadoComprobante = 0;
            if (!string.IsNullOrEmpty(dgvDebeHaber.Rows[e.RowIndex].Cells["id_comprobantes_tipo"].Value.ToString()) || !string.IsNullOrEmpty(dgvDebeHaber.Rows[e.RowIndex].Cells["id_comprobantes_tipo_ctacte"].Value.ToString()))
                EstadoComprobante = Convert.ToInt32(dgvDebeHaber.Rows[e.RowIndex].Cells["EstadoComprobante"].Value);

            if (EstadoComprobante == 0) //RECIBO
                e.CellStyle.BackColor = Color.LightBlue;
            else if (EstadoComprobante == 1) //FACTURA PAGA
                e.CellStyle.BackColor = Color.LightCyan;
            else if (EstadoComprobante == 2) //COMPROBANTE DE DEUDA O FACTURA IMPAGA
                e.CellStyle.BackColor = Color.Tomato;
            else // FACTURA PAGA SIN RECIBO
                e.CellStyle.BackColor = Color.FromArgb(255, 255, 153);

        }
        private void dgvRecibos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvRecibos.Columns[e.ColumnIndex].HeaderText == "Eliminar pago")
            {
                if (MessageBox.Show("¿Elimina Recibo?", "Baja de registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    frmPopUp oPop = new frmPopUp();
                    frmResponsable frmre = new frmResponsable();
                    oPop.Formulario = frmre;
                    oPop.Maximizar = false;
                    if (oPop.ShowDialog() == DialogResult.OK)
                        Eliminar_Recibo();
                    huboCambios = true;
                }
            }

            if (dgvRecibos.Columns[e.ColumnIndex].HeaderText == "Imprimir")
            {
                if (MessageBox.Show("¿Desea Reimprimir el Recibo Seleccionado?", "Mensaje del Sistema", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Oimpresion.NumeroMuestra = dgvRecibos.SelectedRows[0].Cells["numero"].Value.ToString();
                    Oimpresion.Imprime_Recibo(Convert.ToInt32(dgvRecibos.SelectedRows[0].Cells["id_comprobantes"].Value.ToString()), Convert.ToInt32(dgvRecibos.SelectedRows[0].Cells["cuenta"].Value.ToString()));
                }
            }

            if (dgvRecibos.Columns[e.ColumnIndex].HeaderText == "Forma de Pago")
            {
                frmUsuariosCtaCteRecibosFP frmPago = new frmUsuariosCtaCteRecibosFP();
                frmPago.Id_Usuarios_ctacte_recibos = Convert.ToInt32(dgvRecibos.SelectedRows[0].Cells["Id_Usuarios_ctacte_recibos"].Value.ToString());

                using (frmPopUp frm = new frmPopUp())
                {
                    frm.Formulario = frmPago;
                    frm.Maximizar = false;

                    frm.ShowDialog();
                }
            }
        }
        private void dgvDebeHaber_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDebeHaber.SelectedRows.Count > 0)
                id_Comp = Convert.ToInt32(dgvDebeHaber.SelectedRows[0].Cells["id"].Value.ToString());
        }
        private void dgvDebeHaber_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    var hti = dgvDebeHaber.HitTest(e.X, e.Y);
                    dgvDebeHaber.CurrentCell = dgvDebeHaber.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    dgvDebeHaber.Rows[e.RowIndex].Selected = true;
                    dgvDebeHaber.Focus();
                    MenuAcciones.Show(Cursor.Position);
                }
                catch { }
            }
        }
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (ckPorFechas.Checked == true)
            {
                Fecha_Desde = string.Format("{0}/{1}/{2}", dtpDesde.Value.Day, dtpDesde.Value.Month, dtpDesde.Value.Year);
                Fecha_Hasta = string.Format("{0}/{1}/{2}", dtpHasta.Value.Day, dtpHasta.Value.Month, dtpHasta.Value.Year);
            }

            ComenzarCarga();
        }
        private void btnRecibos_Click(object sender, EventArgs e)
        {
            frmUsuariosCtaCte frm = new frmUsuariosCtaCte(Usuarios.CurrentUsuario.Id, Usuarios.CurrentUsuario.Id_Usuarios_Locacion);

            frmMain.Instance().openForm(frm);
        }
        private async void btnEnviar_ClickAsync(object sender, EventArgs e)
        {
            Tools oTools = new Tools();
            Configuracion oConfig = new Configuracion();
            if (oTools.ComprobarFormatoEmail(txtCorreo.Text))
            {
                lblInfo.Visible = false;
                if(emailPago)
                {
                    foreach (Control item in this.Controls)
                    {
                        if(item is Button)
                            item.Enabled = false;
                        if (item.Name == "imgReturn" || item.Name == "pnReturnCorreo")
                            item.Enabled = false;
                    }
                    CapaNegocios.PagosExternos.CaptarPagos.CaptarPagosImplement oIm = new CapaNegocios.PagosExternos.CaptarPagos.CaptarPagosImplement();
                    oIm.SetEntidad();
                    oIm.SetHash();
                    Usuarios_CtaCte oUsuCtacteBoton = new Usuarios_CtaCte();
                    oUsuCtacteBoton.Importe_Saldo = Convert.ToDecimal(dgvComprobantes.SelectedRows[0].Cells["importe_saldo"].Value);
                    oUsuCtacteBoton.Descripcion = dgvComprobantes.SelectedRows[0].Cells["descripcion"].Value.ToString();
                    oUsuCtacteBoton.Id_Usuarios = Usuarios.CurrentUsuario.Id;
                    List<BotonResponse> respuesta = await oIm.CrearBotonesAsync(oUsuCtacteBoton,txtCorreo.Text);
                    if (respuesta.Count > 0)
                    {
                        MessageBox.Show("Boton generado correctamente. \n" + respuesta[0].Data[0].Record.Link);
                        CapaNegocios.PagosExternos.PagoExterno oPago = new CapaNegocios.PagosExternos.PagoExterno();
                        oPago.IdUsuario = Usuarios.CurrentUsuario.Id;
                        oPago.IdPago = respuesta[0].Data[0].Record.IdPago;
                        oPago.IdPlataforma = (int)CapaNegocios.PagosExternos.PagoExterno.Plataforma.CAPTARPAGOS;
                        oPago.IdComprobante = 0;
                        oPago.IdUsuarioCtaCte = Convert.ToInt32(dgvComprobantes.SelectedRows[0].Cells["id"].Value);
                        oPago.ImportePago = 0;
                        oPago.ImporteSaldo = Convert.ToDecimal(dgvComprobantes.SelectedRows[0].Cells["importe_saldo"].Value);
                        oPago.Link = respuesta[0].Data[0].Record.Link;
                        oPago.NombrePlataforma = "CAPTARPAGOS";
                        oPago.NombreUsuario = Usuarios.CurrentUsuario.Apellido + ", " + Usuarios.CurrentUsuario.Nombre;
                        oPago.Pagado = false;
                        oPago.FechaEmitido = DateTime.Now;
                        oPago.CodigoUsuario = Usuarios.CurrentUsuario.Codigo;
                        oPago.Guardar(oPago);
                    }
                    else
                    {

                        MessageBox.Show("Hubo un error al generar el boton de pago online");
                        foreach (Control item in this.Controls)
                        {
                            if (item is Button)
                                item.Enabled = true;
                            if (item.Name == "imgReturn" || item.Name == "pnReturnCorreo")
                                item.Enabled = true;
                        }
                    }
                    pnlEmail.Visible = false;

                }
                else
                {
                    if (oTools.EnviarFacturaElectronica(txtCorreo.Text, rutaSalidaPdf + "\\" + nombreAarchivo) == 0)
                    {
                        MessageBox.Show("Enviado correctamente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        pnlEmail.Visible = false;
                    }
                    else
                        MessageBox.Show("Hubo un error al enviar correo", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                lblInfo.Visible = true;
                
                
                txtCorreo.Focus();
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (dgvComprobantes.Rows.Count > 0)
            {
                if (dgvComprobantes.SelectedRows[0].Cells["tipo"].Value.ToString() == "f")
                {
                    try
                    {
                        rutaSalidaPdf = txtRuta.Text;
                        nombreAarchivo = Oimpresion.Imprime_factura_RDLC(false, id_Comp, true, rutaSalidaPdf);
                        if (MessageBox.Show("Desea enviar documento por correo electronico?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            pnlRuta.Visible = false;
                            pnlEmail.Location = new Point((dgvComprobantes.Width / 2) - pnlEmail.Width / 2, pnlEmail.Location.Y);
                            pnlEmail.Visible = true;
                            email = Usuarios.CurrentUsuario.Correo_Electronico;
                            txtCorreo.Text = email;
                        }
                    }
                    catch { }
                }
            }
        }
        private void btnExaminar_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string[] files = Directory.GetFiles(fbd.SelectedPath);
                    rutaSalidaPdf = fbd.SelectedPath.ToString();
                    txtRuta.Text = fbd.SelectedPath.ToString();
                }
            }
        }
        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgvDebeHaber.Rows.Count > 0)
            {
                Tools tools = new Tools();
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    DataTable dtExcel = dtComprobantesHistorial.Copy();
                    dtExcel.Columns.Add(new DataColumn("usuario", typeof(string)));
                    foreach (DataRow row in dtExcel.Rows)
                        row["usuario"] = $"{Usuarios.CurrentUsuario.Apellido}, {Usuarios.CurrentUsuario.Nombre} [{Usuarios.CurrentUsuario.Codigo}]";
                    tools.ExportDataTableToExcel(dtExcel, "Estado cuenta corriente");
                    MessageBox.Show("Excel exportador correctamente");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally { this.Cursor = Cursors.Default; }
            }
            else
                MessageBox.Show("Tabla vacia", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnAjuste_Click(object sender, EventArgs e)
        {
            decimal Saldo_Usuario = 0, ultimo = 0, Total_Ajuste = 0;
            int id_Comprobante = 0;
            int valor = 0;
            string Comprobante = "";
            List<int> id_Comprobantes = new List<int>();

            foreach (DataGridViewRow item in dgvComprobantes.Rows)
                Saldo_Usuario += Convert.ToDecimal(item.Cells["importe_saldo"].Value);

            valor = dgvDebeHaber.Rows.Count;
            ultimo = Convert.ToDecimal(dgvDebeHaber.Rows[valor - 1].Cells["saldo"].Value);
            Comprobante = dgvDebeHaber.Rows[valor - 1].Cells["Descripcion"].Value.ToString();
            Total_Ajuste = Math.Abs(ultimo - Saldo_Usuario);
            if (ultimo < 0)
                Total_Ajuste = Total_Ajuste * -1;

            if (Convert.ToInt32(dgvDebeHaber.SelectedRows[0].Cells["EstadoComprobante"].Value.ToString()) == 0)
                MessageBox.Show("El ajuste se aplica sobre una factura.");
            else if (Convert.ToInt32(dgvDebeHaber.SelectedRows[0].Cells["EstadoComprobante"].Value.ToString()) == 2)
                MessageBox.Show("El ajuste se aplica sobre una factura .");
            else
            {
                foreach (DataGridViewRow item in dgvDebeHaber.Rows)
                {
                    if (Convert.ToInt32(item.Cells["EstadoComprobante"].Value) == 3)
                    {
                        id_Comprobante = Convert.ToInt32(item.Cells["id"].Value.ToString());
                        id_Comprobantes.Add(id_Comprobante);
                    }
                }
                using (frmPopUp frmPop = new frmPopUp())
                {

                    FrmDatosReciboTipoAjuste frm = new FrmDatosReciboTipoAjuste();
                    frmPop.Formulario = frm;
                    frm.movimiento = Convert.ToDateTime(dgvDebeHaber.SelectedRows[0].Cells["Fecha"].Value.ToString());
                    frm.id_Ctacte = Convert.ToInt32(dgvDebeHaber.SelectedRows[0].Cells["idCtacte"].Value.ToString());
                    frm.id_usu = Usuarios.CurrentUsuario.Id;
                    frm.id_locacion = this.Locacion_Id;
                    frm.id_Comprobantes = id_Comprobantes;
                    frm.idComprobante = Convert.ToInt32(dgvDebeHaber.SelectedRows[0].Cells["id"].Value.ToString());
                    if (string.IsNullOrEmpty(dgvDebeHaber.SelectedRows[0].Cells["ctacte_desde"].Value.ToString()))
                        frm.desde = DateTime.Now;
                    else
                        frm.desde = Convert.ToDateTime(dgvDebeHaber.SelectedRows[0].Cells["ctacte_Desde"].Value.ToString());
                    if (string.IsNullOrEmpty(dgvDebeHaber.SelectedRows[0].Cells["ctacte_hasta"].Value.ToString()))
                        frm.hasta = DateTime.Now.AddMonths(-1);
                    else
                        frm.hasta = Convert.ToDateTime(dgvDebeHaber.SelectedRows[0].Cells["ctacte_hasta"].Value.ToString());
                    frm.Importe = Convert.ToDecimal(dgvDebeHaber.SelectedRows[0].Cells["debe"].Value.ToString());
                    frm.Comprobante = Convert.ToString(dgvDebeHaber.SelectedRows[0].Cells["Descripcion"].Value.ToString());
                    frm.Importe_Completo = Total_Ajuste;
                    frm.SaldoCtacte = saldo;
                    frmPop.Maximizar = false;
                    if (frmPop.ShowDialog() == DialogResult.OK)
                    {
                        MessageBox.Show("Datos actualizados correctamente.");
                        this.Close();
                    }
                    else
                        MessageBox.Show("Operacion cancelada manualmente, o ocurrio un fallo en el proceso.");
                }
            }
        }
        private void btnGeneraComprobantes_Click(object sender, EventArgs e)
        {
            DataTable dtServiciosContratados, dtLocaciones;
            dtServiciosContratados = oUsuServ.ListarServiciosYSubServiciosActivos(Usuarios.CurrentUsuario.Id);
            dtLocaciones = oUsuLoc.ListarLocacionesServicio(Usuarios.CurrentUsuario.Id, 0, true);
            int idLocacionSeleccionada = 0;
            idLocacionSeleccionada = Convert.ToInt32(cboLocacion.SelectedValue);

            using (frmPopUp frmPop = new frmPopUp())
            {
                frmGeneraComprobantesManual frm = new frmGeneraComprobantesManual(Usuarios.CurrentUsuario.Id, idLocacionSeleccionada, dtServiciosContratados, dtLocaciones);
                frmPop.Formulario = frm;

                frmPop.ShowDialog();

                ComenzarCarga();
            }
        }
        private void tbEstado_Enter(object sender, EventArgs e)
        {
            lblComImp.Visible = false;
            lblCompDeuda.Visible = false;
            lblCompronteDeuda.Visible = false;
            lblImpago.Visible = false;
            lblPlandePago.Visible = false;
            lblPlanPagos.Visible = false;
            tsEliminar.Enabled = false;
            tsEditar.Enabled = false;
            tsGenerarFactura.Enabled = false;
            if (historialComprobantesCargado == false)
            {

                ZolapaHistorial();

                if (dtComprobantesHistorial.Rows.Count > 0)
                {

                    dgvDebeHaber.Columns["id"].Visible = false;
                    dgvDebeHaber.Columns["orden"].Visible = false;
                    dgvDebeHaber.Columns["idCtacte"].Visible = false;
                    dgvDebeHaber.Columns["id_comprobantes_tipo_ctacte"].Visible = false;
                    dgvDebeHaber.Columns["id_comprobantes_tipo"].Visible = false;
                    dgvDebeHaber.Columns["ctacte_desde"].Visible = false;
                    dgvDebeHaber.Columns["ctacte_hasta"].Visible = false;
                    dgvDebeHaber.Columns["ctacte_importe"].Visible = false;
                    dgvDebeHaber.Columns["ctacte_saldo"].Visible = false;
                    dgvDebeHaber.Columns["id_recibo"].Visible = false;
                    dgvDebeHaber.Columns["pagoimputacion"].Visible = false;
                    dgvDebeHaber.Columns["cae"].Visible = false;
                    dgvDebeHaber.Columns["letra"].Visible = false;
                    dgvDebeHaber.Columns["estadocomprobante"].Visible = false;

                    dgvDebeHaber.Columns["fecha"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvDebeHaber.Columns["fecha"].HeaderText = "Fecha movimiento";

                    dgvDebeHaber.Columns["descripcion"].HeaderText = "Descripcion";
                    dgvDebeHaber.Columns["descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    dgvDebeHaber.Columns["debe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvDebeHaber.Columns["debe"].HeaderText = "Debe";
                    dgvDebeHaber.Columns["debe"].DefaultCellStyle.Format = "c2";

                    dgvDebeHaber.Columns["haber"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvDebeHaber.Columns["haber"].HeaderText = "Haber";
                    dgvDebeHaber.Columns["haber"].DefaultCellStyle.Format = "c2";

                    dgvDebeHaber.Columns["saldo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvDebeHaber.Columns["saldo"].HeaderText = "Saldo";
                    dgvDebeHaber.Columns["saldo"].DefaultCellStyle.Format = "c2";

                    dgvDebeHaber.RowTemplate.Height = 35;
                    btnExportar.Enabled = true;
                    decimal debe = 0, haber = 0;
                    foreach (DataRow item in dtEstado.Rows)
                    {
                        if (Convert.ToDecimal(item["debe"]) > 0)
                            debe = debe + Convert.ToDecimal(item["debe"]);
                        else
                            haber = haber + Convert.ToDecimal(item["haber"]);
                    }
                    saldoEstado = debe - haber;
                }
                else
                    btnExportar.Enabled = false;


            }

        }      
        private void tbCtaCte_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage.Name == "tbHistorial" && !historialComprobantesCargado)
                ZolapaHistorial();
        }
        private void tabPageCtaCteMov_Enter(object sender, EventArgs e)
        {
            lblComImp.Visible = true;
            lblCompDeuda.Visible = true;
            lblCompronteDeuda.Visible = true;
            lblImpago.Visible = true;
            lblPlandePago.Visible = true;
            lblPlanPagos.Visible = true;
            tsEditar.Enabled = true;
            tsEliminar.Enabled = true;
            tsGenerarFactura.Enabled = true;
        }
        private void ZolapaHistorial(int Filtro=0)
        {

            if (Filtro == 0)
                dt = new Comprobantes().GetComprobanteHistorial(Usuarios.CurrentUsuario.Id, this.Locacion_Id);
            else
                dt = dtComprobantesHistorial.Copy();
            DataRow dr_Datos_CtaCte;
            DataRow dr_Datos_CtacteInicial;
            DataTable dt_Iva_Ventas = new DataTable();
            DataRow dr_Datos_Ctacte_Recibo;
            decimal debe = 0;
            decimal haber = 0;
            decimal td = 0;
            decimal th = 0;
            decimal pago = 0;
            saldo = 0;
            string cae = "";
            string letra = "";
            string Periodo = "";
            Int32 Orden = 0;
            Int32 IdCtaCte = 0;
            int borrado = 1;
            DateTime Fecha;
            dtComprobantesHistorial.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                debe = 0;
                haber = 0;
                cae = "";
                letra = "X";
                borrado = 0;
                Orden = 0;
                IdCtaCte = 0;
                char pad = '0';
                pago = 0;
                Periodo = "";
                Fecha = DateTime.Now;

                if (!string.IsNullOrEmpty(dr["ctacte_ID"].ToString()))
                {
                    if (!string.IsNullOrEmpty(dr["pago"].ToString()))
                        pago = Convert.ToDecimal(dr["pago"].ToString());

                    IdCtaCte = Convert.ToInt32(dr["ctacte_ID"].ToString());
                    borrado = Convert.ToInt32(dr["ctacte_borrado"].ToString());
                    if (borrado == 0)
                    {
                        debe = Convert.ToDecimal(dr["ctacte_importe"].ToString());
                        Fecha = Convert.ToDateTime(dr["ctacte_fecha"].ToString());
                        Periodo = Convert.ToDateTime(dr["ctacte_hasta"].ToString()).Month.ToString() + " - " + Convert.ToDateTime(dr["ctacte_hasta"].ToString()).Year.ToString();
                        Orden = Convert.ToInt32(Convert.ToDateTime(dr["ctacte_hasta"].ToString()).Year.ToString() + Convert.ToDateTime(dr["ctacte_hasta"].ToString()).Month.ToString().PadLeft(2, pad));
                    }
                }

                if (borrado == 0)
                {
                    if (!string.IsNullOrEmpty(dr["ivaventas_ID"].ToString()))
                    {

                        if (Convert.ToInt32(dr["id_comprobantes_tipo"].ToString()) != 6)
                        {
                            if (debe == 0)
                                debe = Convert.ToDecimal(dr["importe_iva"].ToString());

                            cae = dr["cae"].ToString();
                            letra = dr["letra"].ToString();
                            Fecha = Convert.ToDateTime(dr["fecha_iva"].ToString());
                            borrado = Convert.ToInt32(dr["ivaventas_borrado"].ToString());

                            if (Convert.ToInt32(dr["id_comprobantes_tipo"].ToString()) == 3) //NC
                            {
                                haber = debe;
                                debe = 0;
                                Orden = Convert.ToInt32(Convert.ToDateTime(dr["fecha_iva"].ToString()).Year.ToString() + Convert.ToDateTime(dr["fecha_iva"].ToString()).Month.ToString().PadLeft(2, pad));
                            }

                            if (Convert.ToInt32(dr["id_comprobantes_tipo"].ToString()) == 4)
                            {
                                haber = debe;
                                debe = 0;
                                Orden = Convert.ToInt32(Convert.ToDateTime(dr["fecha_iva"].ToString()).Year.ToString() + Convert.ToDateTime(dr["fecha_iva"].ToString()).Month.ToString().PadLeft(2, pad));
                            }

                        }
                    }
                }

                if (!string.IsNullOrEmpty(dr["recibos_ID"].ToString()))
                {
                    haber = Convert.ToDecimal(dr["recibos_importe"].ToString());
                    letra = "R";
                    borrado = Convert.ToInt32(dr["recibos_borrado"].ToString());
                    Fecha = Convert.ToDateTime(dr["recibos_fecha"].ToString());
                    Orden = Convert.ToInt32(Convert.ToDateTime(dr["recibos_fecha"].ToString()).Year.ToString() + Convert.ToDateTime(dr["recibos_fecha"].ToString()).Month.ToString().PadLeft(2, pad));
                }

                if (borrado == 0)
                {
                    if (debe != 0 || haber != 0)
                    {
                        dr_Datos_CtacteInicial = oUsuCtaCte.getDatosCtaCte(Convert.ToInt32(dr["comprobantes_id"].ToString()));
                        if(Convert.ToInt32(dr_Datos_CtacteInicial["id_comprobantes_tipo"]) != (int)Comprobantes_Tipo.Tipo.CREDITO_A_CUENTA)
                        { 
                            td = td + debe;
                            th = th + haber;
                           
                            saldo = td - th;
                            DataRow drIns = dtComprobantesHistorial.NewRow();
                            drIns["Descripcion"] = dr["descripcion"].ToString();
                            drIns["letra"] = letra;
                            drIns["haber"] = haber;
                            drIns["debe"] = debe;
                            drIns["saldo"] = saldo;
                            drIns["pagoimputacion"] = pago;
                            drIns["fecha"] = Fecha.ToString("dd-MM-yyyy");
                            drIns["cae"] = cae;
                            drIns["periodo"] = Periodo;
                            drIns["orden"] = Orden;
                            drIns["id"] = Convert.ToInt32(dr["comprobantes_id"].ToString());
                            if (!string.IsNullOrEmpty(dr["id_comprobantes_Tipo"].ToString()))
                                drIns["id_comprobantes_tipo"] = Convert.ToInt32(dr["id_comprobantes_Tipo"]);
                            if (!string.IsNullOrEmpty(dr["id_locacion"].ToString()))
                                drIns["id_locacion"] = Convert.ToInt32(dr["id_locacion"]);
                            else
                                drIns["id_locacion"] = 0;
                            dr_Datos_CtaCte = oUsuCtaCte.getDatosCtaCte(Convert.ToInt32(dr["comprobantes_id"].ToString()));
                            dt_Iva_Ventas = oUsuarios_CtaCte.Listar_Factura_Iva_Ventas(Convert.ToInt32(dr["comprobantes_id"].ToString()));
                            drIns["IdCtaCte"] = Convert.ToInt32(dr_Datos_CtaCte["id"].ToString());
                            if (dt_Iva_Ventas.Rows.Count > 0) 
                            { 
                                dr_Datos_Ctacte_Recibo = Ousuarios_CtaCte_Recibos.getDatosRelacion(Convert.ToInt32(dr_Datos_CtaCte["id"].ToString()));
                                if(Convert.ToInt32(dr_Datos_Ctacte_Recibo["id"]) == 0)
                                    drIns["EstadoComprobante"] = 3; //FACTURA PAGA SIN RECIBO
                                else
                                    drIns["EstadoComprobante"] = 1; //FACTURA PAGA
                            }
                            else
                            {
                                int id_Comp_Tipo = 0;
                                id_Comp_Tipo = Convert.ToInt32(dr_Datos_CtaCte["id_Comprobantes_tipo"]);
                                if (id_Comp_Tipo == (int)Comprobantes_Tipo.Tipo.COMPROBANTE_DEUDA ||
                                    (id_Comp_Tipo == (int)Comprobantes_Tipo.Tipo.FACTURA_A && Convert.ToInt32(dr_Datos_CtaCte["Importe_Saldo"]) > 0) ||
                                    (id_Comp_Tipo == (int)Comprobantes_Tipo.Tipo.FACTURA_B && Convert.ToInt32(dr_Datos_CtaCte["Importe_Saldo"]) > 0))
                                    drIns["EstadoComprobante"] = 2; //FACTURA IMPAGA O COMPROBANTE DE DEUDA
                                else
                                    drIns["EstadoComprobante"] = 0; //RECIBO
                            }
                            if (!string.IsNullOrEmpty(dr["id_comprobantes_Tipo_ctacte"].ToString()))
                                drIns["id_comprobantes_tipo_ctacte"] = Convert.ToInt32(dr["id_comprobantes_tipo_ctacte"]);
                            if (!string.IsNullOrEmpty(dr["ctacte_desde"].ToString()))
                                drIns["ctacte_desde"] = Convert.ToDateTime(dr["ctacte_desde"]);
                            if (!string.IsNullOrEmpty(dr["ctacte_hasta"].ToString()))
                                drIns["ctacte_hasta"] = Convert.ToDateTime(dr["ctacte_hasta"]);
                            if (!string.IsNullOrEmpty(dr["ctacte_importe"].ToString()))
                                drIns["ctacte_importe"] = Convert.ToDecimal(dr["ctacte_importe"]);
                            if (!string.IsNullOrEmpty(dr["ctacte_saldo"].ToString()))
                                drIns["ctacte_saldo"] = Convert.ToDecimal(dr["ctacte_saldo"]);
                            if (!string.IsNullOrEmpty(dr["recibos_ID"].ToString()))
                                drIns["id_Recibo"] = Convert.ToInt32(dr["recibos_id"]);
                            else
                                drIns["id_Recibo"] = 0;

                            dtComprobantesHistorial.Rows.Add(drIns);
                        }
                    }
                }

                if (saldo == saldo2) 
                { 
                    LbSaldoCta.ForeColor = Color.LightSeaGreen;
                    btnAjuste.Enabled = false;
                    LbSaldoCta.Text = "Saldo Locacion: $ " + saldo2.ToString() + " - Sin necesidad de Ajuste";
                }
                else 
                { 
                    LbSaldoCta.ForeColor = Color.OrangeRed;
                    btnAjuste.Enabled = false;
                    LbSaldoCta.Text = "Saldo Locacion: $ " + saldo2.ToString() + " - Con necesidad de Ajuste";
                    if (Personal.Id_Login == 0)
                        btnAjuste.Enabled = true;
                }

            }

            dgvDebeHaber.DataSource = dtComprobantesHistorial;

            if (dtComprobantesHistorial.Rows.Count > 0)
            {
                dgvDebeHaber.Columns["id"].Visible = false;
                dgvDebeHaber.Columns["orden"].Visible = false;
                dgvDebeHaber.Columns["idCtacte"].Visible = false;
                dgvDebeHaber.Columns["id_comprobantes_tipo_ctacte"].Visible = false;
                dgvDebeHaber.Columns["id_comprobantes_tipo"].Visible = false;
                dgvDebeHaber.Columns["ctacte_desde"].Visible = false;
                dgvDebeHaber.Columns["ctacte_hasta"].Visible = false;
                dgvDebeHaber.Columns["ctacte_importe"].Visible = false;
                dgvDebeHaber.Columns["ctacte_saldo"].Visible = false;
                dgvDebeHaber.Columns["id_recibo"].Visible = false;
                dgvDebeHaber.Columns["pagoimputacion"].Visible = false;
                dgvDebeHaber.Columns["cae"].Visible = false;
                dgvDebeHaber.Columns["letra"].Visible = false;
                dgvDebeHaber.Columns["estadocomprobante"].Visible = false;
                dgvDebeHaber.Columns["fecha"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvDebeHaber.Columns["fecha"].HeaderText = "Fecha movimiento";
                dgvDebeHaber.Columns["descripcion"].HeaderText = "Descripcion";
                dgvDebeHaber.Columns["descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvDebeHaber.Columns["debe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvDebeHaber.Columns["debe"].HeaderText = "Debe";
                dgvDebeHaber.Columns["debe"].DefaultCellStyle.Format = "c2";
                dgvDebeHaber.Columns["haber"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvDebeHaber.Columns["haber"].HeaderText = "Haber";
                dgvDebeHaber.Columns["haber"].DefaultCellStyle.Format = "c2";
                dgvDebeHaber.Columns["saldo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvDebeHaber.Columns["saldo"].HeaderText = "Saldo";
                dgvDebeHaber.Columns["saldo"].DefaultCellStyle.Format = "c2";

                dgvDebeHaber.RowTemplate.Height = 35;
                btnExportar.Enabled = true;
                decimal debe2 = 0, haber2 = 0;
                foreach (DataRow item in dtEstado.Rows)
                {
                    if (Convert.ToDecimal(item["debe"]) > 0)
                        debe2 = debe2 + Convert.ToDecimal(item["debe"]);
                    else
                        haber2 = haber2 + Convert.ToDecimal(item["haber"]);
                }
                saldoEstado = debe2 - haber2;
            }
            else
                btnExportar.Enabled = false;

            this.Cursor = Cursors.Default;

            historialComprobantesCargado = true;
        }
        private void tsImprimir_Click(object sender, EventArgs e)
        {
            if (dgvComprobantes.Rows.Count > 0)
            {
                if (dgvComprobantes.SelectedRows[0].Cells["tipo"].Value.ToString() == "f")
                {
                    bool impDirecto = ckPreviewImpresion.CheckState == CheckState.Checked ? false : true;
                    try
                    {
                        Oimpresion.Imprime_factura_RDLC(impDirecto, Convert.ToInt32(id_Comp));
                        if (Convert.ToInt32(dgvComprobantes.SelectedRows[0].Cells["id_comp_notadebito_asociada"].Value) != 0)
                            Oimpresion.Imprime_factura_RDLC(impDirecto, Convert.ToInt32(dgvComprobantes.SelectedRows[0].Cells["id_comp_notadebito_asociada"].Value.ToString()));
                    }
                    catch (Exception c)
                    {
                        string salida = c.ToString();
                    }
                }
            }
        }
        private void tsGenerarPDF_Click(object sender, EventArgs e)
        {
            pnlRuta.Visible = true;
        }
        private void tsEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if(Convert.ToInt32(dgvComprobantes.SelectedRows[0].Cells["id_debito"].Value) == 0 &&
                   Convert.ToInt32(dgvComprobantes.SelectedRows[0].Cells["id_comprobantes_tipo"].Value) != Convert.ToInt32(Comprobantes_Tipo.Tipo.REMITO) &&
                   ( (Convert.ToInt32(dgvComprobantes.SelectedRows[0].Cells["id_comprobantes_tipo"].Value) != Convert.ToInt32(Comprobantes_Tipo.Tipo.FACTURA_A) &&
                   Convert.ToInt32(dgvComprobantes.SelectedRows[0].Cells["id_comprobantes_tipo"].Value) != Convert.ToInt32(Comprobantes_Tipo.Tipo.FACTURA_B)) || 
                   (Convert.ToDecimal(dgvComprobantes.SelectedRows[0].Cells["importe_pago"].Value) == 0)))
                {
                    frmPopUp oPop = new frmPopUp();
                    frmResponsable frmre = new frmResponsable();
                    oPop.Formulario = frmre;
                    oPop.Maximizar = false;
                    if (oPop.ShowDialog() == DialogResult.OK)
                    {
                        frmPopUp frmPop = new frmPopUp();
                        frmUsuariosCtaCteDetEdicion frmEdita = new frmUsuariosCtaCteDetEdicion();
                        frmEdita.Id_CtaCte = Convert.ToInt32(dgvComprobantes.SelectedRows[0].Cells["iD"].Value);
                        frmEdita.Id_Comprobantes = Convert.ToInt32(dgvComprobantes.SelectedRows[0].Cells["id_comprobantes"].Value);
                        frmEdita.Comprobante = dgvComprobantes.SelectedRows[0].Cells["descripcion"].Value.ToString();
                        frmEdita.Comprobante_Tipo = (Comprobantes_Tipo.Tipo)Convert.ToInt32(dgvComprobantes.SelectedRows[0].Cells["id_comprobantes_tipo"].Value);
                        frmPop.Formulario = frmEdita;
                        frmPop.Maximizar = false;

                        if (frmPop.ShowDialog() == DialogResult.OK)
                            ComenzarCarga();

                    }
                }
                else
                {
                    if (Convert.ToInt32(dgvComprobantes.SelectedRows[0].Cells["id_debito"].Value) > 0)
                        MessageBox.Show("No se puede editar un comprobante que esta adherido a débito automático", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    else
                        MessageBox.Show("No se puede editar el tipo de comprobante", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se puede editar el movimiento: " + ex.Message, "Baja de Movimiento", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void tsEliminar_Click(object sender, EventArgs e)
        {
            if (dgvComprobantes.Rows.Count > 0 && dgvComprobantes.SelectedRows.Count > 0)
            {
                Int32 idTipoComprobante = Convert.ToInt32(dgvComprobantes.SelectedRows[0].Cells["id_comprobantes_Tipo"].Value);

                if (idTipoComprobante == (int)Comprobantes_Tipo.Tipo.CREDITO_A_CUENTA)
                    MessageBox.Show("No puede eliminarse el credito a cuenta, debe eliminar el recibo que genero este movimiento.");
                else
                {
                    if (Convert.ToInt32(dgvComprobantes.SelectedRows[0].Cells["id_debito"].Value) > 0 && (Convert.ToInt32(dgvComprobantes.SelectedRows[0].Cells["rechazado"].Value) == 0) && tipoelimina == 0)
                        MessageBox.Show("El comprobante seleccionado esta adherido a debito automatico", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    else
                    {
                        if (tipoelimina == 2)
                        {
                            if (MessageBox.Show("Estas a punto de deshacer un remito, ¿desea continuar con la operacion?", "Mensaje del sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                return;

                            string salida = "";
                            if (oComprobante.DesHacerRemito(Convert.ToInt32(dgvComprobantes.SelectedRows[0].Cells["id_comprobantes"].Value), out salida) == false)
                                MessageBox.Show("Error al deshacer Remito. Error: ", salida);
                            else
                                ComenzarCarga();
                        }
                        else
                        {
                            if ((Convert.ToInt32(dgvComprobantes.SelectedRows[0].Cells["id_plan_recibo"].Value) > 0 && Convert.ToInt32(dgvComprobantes.SelectedRows[0].Cells["id_iva_ventas"].Value) == 0))
                                MessageBox.Show("No se puede elimnar una cuota, elimine el recibo del plan de pago para eliminar el plan de pago completo.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            else
                                EliminarComprobante();
                        }
                    }
                }
            }
        }
        private void tsGenerarFactura_Click(object sender, EventArgs e)
        {
            GenerarFactura(facturaDeCredito: false);
        }
        private void tsVerComponentes_Click(object sender, EventArgs e)
        {
            if (dgvComprobantes.Rows.Count > 0)
            {
                frmUsuariosCtaCteComponentes frmComponentes = new frmUsuariosCtaCteComponentes(id_Comp);
                frmPopUp frmPU = new frmPopUp();
                frmPU.Formulario = frmComponentes;
                frmPU.ShowDialog();
            }
        }
        private void tsContratoTemporario_Click(object sender, EventArgs e)
        {
            Impresion impresion = new Impresion();

            Int32 idComprobante = Convert.ToInt32(dgvComprobantes.SelectedRows[0].Cells["id_comprobantes"].Value.ToString());

            DataTable dtDetalle = Ousuarios_CtaCte_Det.ListarDetalle(id_Comp);

            int cantidadContrato = Convert.ToInt32(dtDetalle.Compute("COUNT(id_contrato)", "id_contrato > 0"));


            if (cantidadContrato > 0)
            {
                impresion.ImprimirContratoTemporario(Usuarios.CurrentUsuario.Id, Convert.ToDecimal(dtDetalle.Rows[0]["Importe_Original"]), Convert.ToDateTime(dtDetalle.Rows[0]["Fecha_Hasta"]));

            }
            else
            {
                MessageBox.Show("No hay Servicios con Contrato");
            }
        }
        private void tsIva_Click(object sender, EventArgs e)
        {
            dtCtacteAfip = oUsuarios_CtaCte.Listar_Factura_Iva_Ventas(id_Comp);
            using (frmPopUp frm = new frmPopUp())
            {
                Afip.frmafipservicios frmAfip = new Afip.frmafipservicios();
                frmAfip.dt_Facturas_iva = dtCtacteAfip;
                frm.Formulario = frmAfip;
                frm.Maximizar = false;
                frm.Show();
            }
        }
        private void tsNotaCredito_Click(object sender, EventArgs e)
        {
            frmPopUp popup = new frmPopUp();
            frmSeleccionComprobantes ofrmSeleccion = new frmSeleccionComprobantes(permitirSeleccionarUnoSolo: false, permitirImportesEnCero: false);
            ofrmSeleccion.NotaDeCredito = true;
            DataTable dt = dtCtaCte.Copy();
            DataView dvSoloFacturas = dt.DefaultView;

            popup.Formulario = ofrmSeleccion;
            popup.Maximizar = false;

            dvSoloFacturas.RowFilter = $"id_comprobantes_tipo={(int)Comprobantes_Tipo.Tipo.FACTURA_A} or id_comprobantes_tipo={(int)Comprobantes_Tipo.Tipo.FACTURA_B} and importe_saldo>0";
            ofrmSeleccion.dtComprobantes = dvSoloFacturas.ToTable();
            if (popup.ShowDialog() == DialogResult.OK)
            {

                foreach (Control item in this.Controls)
                    item.Enabled = false;

                int idComprobante;
                foreach (DataRow item in ofrmSeleccion.dtComprobantes.Rows)
                {
                    idComprobante = Convert.ToInt32(item["id_comprobantes"]);
                    DataTable dtDevolucion = new DataTable();
                    dtDevolucion = ofacturacion.NotaDeCreditoCompleta(idComprobante, ofacturacion);
                    if (dtDevolucion.Rows.Count > 0)
                    {
                        if (Convert.ToInt32(dtDevolucion.Rows[0]["respuesta_codigo"]) == -1)
                            MessageBox.Show("Hubo un error al generar la nota de credito. \n Error: " + dtDevolucion.Rows[0]["respuesta_descripcion"].ToString(), "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (MessageBox.Show("¿Desea imprimir la Nota de Credito?", "Mensaje del sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            bool impDirecto = ckPreviewImpresion.CheckState == CheckState.Checked ? false : true;
                            Oimpresion.Imprime_factura_RDLC(impDirecto, ofacturacion.Id_Comprobantes);
                        }
                    }
                }
                ComenzarCarga();
            }
        }
        
        private void GenerarFactura(bool facturaDeCredito)
        {
            frmPopUp popup = new frmPopUp();
            frmSeleccionComprobantes ofrmSeleccion = new frmSeleccionComprobantes(permitirSeleccionarUnoSolo: false, permitirImportesEnCero: false);
            DataTable dt = dtCtaCte.Copy();
            DataView dvSoloComprobantes = dt.DefaultView;

            popup.Formulario = ofrmSeleccion;
            popup.Maximizar = false;

            dvSoloComprobantes.RowFilter = string.Format("id_comprobantes_tipo<>{0} and id_comprobantes_tipo<>{1} and id_comprobantes_tipo<>{1}", (int)Comprobantes_Tipo.Tipo.FACTURA_A, (int)Comprobantes_Tipo.Tipo.FACTURA_B, (int)Comprobantes_Tipo.Tipo.CREDITO_A_CUENTA);
            ofrmSeleccion.dtComprobantes = dvSoloComprobantes.ToTable();
            if (popup.ShowDialog() == DialogResult.OK)
            {

                foreach (Control item in this.Controls)
                    item.Enabled = false;
                if (dgvComprobantes.SelectedRows[0].Cells["tipo"].Value.ToString() == "f")
                {
                    Int32 codigoRetorno = -1;
                    try
                    {
                        string mensaje = "";
                        int idCtacte = 0;
                        int IdComprobante = 0;
                        DataTable dtCtaCteDetfinal = oUsuCtaCte.LlenarDtModelo(dtLocaciones, "L", Convert.ToInt32(cboLocacion.SelectedValue));
                        foreach (DataRow Dr in dtCtaCteDetfinal.Rows)
                        {
                            IdComprobante = Convert.ToInt32(Dr["id_comprobantes"]);
                            idCtacte = Convert.ToInt32(Dr["id_usuarios_ctacte"]);
                            DataView dv = ofrmSeleccion.dtComprobantes.DefaultView;
                            dv.RowFilter = "id_comprobantes=" + IdComprobante;
                            DataTable dtFiltrado = dv.ToTable();
                            if (dtFiltrado.Rows.Count > 0)
                            {
                                if (ofacturacion.PlanDePagoFactura(idCtacte, out mensaje) == true)
                                {
                                    Dr["elige"] = true;
                                    Dr["importe_pago"] = 1;
                                    Dr["importe_total"] = Convert.ToDecimal(Dr["importe_saldo"].ToString());
                                }
                            }
                        }

                        if (facturaDeCredito)
                        {
                            decimal suma = 0;
                            foreach (DataRow Dr in dtCtaCteDetfinal.Rows)
                            {
                                if (Convert.ToBoolean(Dr["elige"]))
                                {
                                    if(Convert.ToInt32(Dr["encabezado"]) == 2)
                                    {
                                        suma += Convert.ToDecimal(Dr["importe_total"]);
                                    }
                                }
                            }
                            if(suma < Convert.ToInt32(oConf.GetValor_N("MontoMinimoFacturaDeCredito")))
                            {
                                MessageBox.Show("El importe total no es suficiente para realizar una factura de credito", "Mensaje del sistema");
                                foreach (Control item in this.Controls)
                                    item.Enabled = true;
                                return;
                            }
                        }

                        if (mensaje != "")
                            MessageBox.Show("Uno de los comprobantes seleccionados es una cuota de un plan de pago de un comprobante que ya es factura.");
                        else
                        {
                            Percepciones.CalcularPercepcionesEnDtFinal(dtCtaCteDetfinal, modificarImportesPagos: false);
                            dtCtaCteDetfinal.Rows[0]["calcularPercepcion"] = 1;
                            DataView dvElegidos = dtCtaCteDetfinal.DefaultView;
                            dvElegidos.RowFilter = "elige=true";
                            DataTable dtFinalElegidos = dvElegidos.ToTable();
                            DataTable dtResultado = ofacturacion.Comprobante_a_Factura(ofacturacion, dtFinalElegidos, Convert.ToInt32(cboLocacion.SelectedValue), Personal.Id_Punto_Venta, permitirHacerRemito: false, facturaDeCredito);
                            codigoRetorno = Convert.ToInt32(dtResultado.Rows[0]["respuesta_codigo"]);
                            string mensajeResultado = dtResultado.Rows[0]["respuesta_descripcion"].ToString();
                            if (codigoRetorno == 0)
                            {
                                MessageBox.Show("Factura generada correctamente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Configuracion oConfi = new Configuracion();
                                if (oConfi.GetValor_N("Cta_Comprobante_De_Pago") == 2)//si trabaja mismo num de recibo = num de factura cuando un remito se pasa a factura y tiene un pago asociado tmb hay que updatear la descripcin del recibo
                                {
                                    DataView dvRemitos = dtFinalElegidos.DefaultView;
                                    dvRemitos.RowFilter = $"id_comprobantes_tipo={(int)Comprobantes_Tipo.Tipo.REMITO}";
                                    DataTable dtRemitos = dvRemitos.ToTable();
                                    if (dtRemitos.Rows.Count > 0)
                                    {
                                        foreach (DataRow item in dtRemitos.Rows)
                                        {
                                            Usuarios_CtaCte_Recibos oRecibo = new Usuarios_CtaCte_Recibos();
                                            DataTable dtDatosCtacte = new DataTable();
                                            dtDatosCtacte = oUsuCtaCte.ListarDatosCtaCte(Convert.ToInt32(dtFinalElegidos.Rows[0]["id_usuarios_ctacte"]));
                                            DataTable dtRecibosAsociadosRemito = new DataTable();
                                            string salida = "";
                                            if (oRecibo.ActualizarReciboRemito(Convert.ToInt32(dtDatosCtacte.Rows[0]["id_usuarios_ctacte_recibos"]), ofacturacion.Descripcion, ofacturacion.Numero, out salida) == false)
                                                MessageBox.Show("Hubo un error al actualizar el recibo con los datos de la factura.\n Error: " + salida, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                }
                            }
                            else if (Convert.ToInt16(dtResultado.Rows[dtResultado.Rows.Count - 1]["respuesta_codigo"]) == Convert.ToInt32(Facturacion.CODIGOS_RESPUESTA_FACTURACION.NO_SE_REALIZARON_MODIFICACIONES))
                            {
                                MessageBox.Show($"No se pudo realizar la factura, hubo un problema con la afip\nError: {mensajeResultado}", "Mensaje del sistema");
                            }
                            else
                                MessageBox.Show("Hubo un error al generar la factura. Error: " + codigoRetorno + "\n" + mensajeResultado, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            huboCambios = true;
                            CargarDatos();

                        }
                    }
                    catch (Exception c)
                    {
                        MessageBox.Show("Hubo un error al gererar la factura. Controle que el comprobante seleccionado no sea una factura: " + c.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                }
                foreach (Control item in this.Controls)
                    item.Enabled = true;
            }
        }

        private void tsGenerarFacturaCredito_Click(object sender, EventArgs e)
        {
            if(oConf.GetValor_N("TrabajaConFacturaDeCredito") == 1)
            {
                GenerarFactura(facturaDeCredito: true);
            }
            else
            {
                MessageBox.Show("No esta configurado para generar factura de credito");
                return;
            }
        }

        private async void generarLinkDePagoToolStripMenuItem_ClickAsync(object sender, EventArgs e)
        {
            frmPopUp oPopUp = new frmPopUp();
            frmPlataformasPagosSel oFrm = new frmPlataformasPagosSel();
            oPopUp.Formulario = oFrm;
            oPopUp.Maximizar = false;
            if (oPopUp.ShowDialog() == DialogResult.OK)
            {
                if(oFrm.IdPlataformaSeleccionada == (int)CapaNegocios.PagosExternos.PagoExterno.Plataforma.CAPTARPAGOS)
                {
                    if (Convert.ToDecimal(dgvComprobantes.SelectedRows[0].Cells["importe_saldo"].Value) > 0)
                    {
                        pnlEmail.Location = new Point((dgvComprobantes.Width / 2) - pnlEmail.Width / 2, pnlEmail.Location.Y);
                        btnEnviar.Text = "Generar link y enviar";
                        btnEnviar.Width = 160;
                        emailPago = true;
                        if (Personal.Name_Login == "ADMINISTRADOR")
                            txtCorreo.Text = "maxi1792@gmail.com.ar";
                        else
                            txtCorreo.Text = Usuarios.CurrentUsuario.Correo_Electronico;
                        pnlEmail.Visible = true;
                    }
                }

            }
        }
    }
}
