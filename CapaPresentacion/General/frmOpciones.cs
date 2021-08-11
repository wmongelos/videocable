using CapaNegocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmOpciones : Form
    {
        private Configuracion oConfig = new Configuracion();

        public frmOpciones()
        {
            InitializeComponent();

            LoadData();
        }

        private void LoadData()
        {
            DataTable dtIpFijas = new DataTable();
            dtIpFijas.Columns.Add("id", typeof(int));
            dtIpFijas.Columns.Add("tipo", typeof(string));
            dtIpFijas.Rows.Add(1, "Importe fijo");
            dtIpFijas.Rows.Add(2, "Subservicio");
            dtIpFijas.AcceptChanges();

            DataTable dtOpcionesDeudasAdelantadas = new DataTable();
            dtOpcionesDeudasAdelantadas.Columns.Add("id", typeof(int));
            dtOpcionesDeudasAdelantadas.Columns.Add("nombre", typeof(string));
            dtOpcionesDeudasAdelantadas.Rows.Add(1, "TARIFA FECHA ACTUAL");
            dtOpcionesDeudasAdelantadas.Rows.Add(2, "TARIFA FECHA SERVICIO");
            dtOpcionesDeudasAdelantadas.AcceptChanges();
            cboDeudaAdelantada.DataSource = dtOpcionesDeudasAdelantadas;
            cboDeudaAdelantada.DisplayMember = "nombre";
            cboDeudaAdelantada.ValueMember = "id";
            cboEstadoDesafectarEquipo.DataSource = Tablas.DataEquiposEstados;
            cboEstadoDesafectarEquipo.DisplayMember = "nombre";
            cboEstadoDesafectarEquipo.ValueMember = "id";
            cboCobroIp.DataSource = dtIpFijas;
            cboCobroIp.DisplayMember = "tipo";
            cboCobroIp.ValueMember = "id";

            string Nombre, Descripcion;
            int largolista, largoDB, x;
            DataTable dtVariables = new DataTable();
            dtVariables = oConfig.LeerConfiguraciones();
            List<string> Nombre_Controles = new List<string>();
            List<string> Descripcion_Controles = new List<string>();
            List<string> Nombre_Variables = new List<string>();
            List<string> Descripcion_Variables = new List<string>();

            // Por cada TextBox del form...
            for (x = 0; x < tabConfiguracion.TabPages.Count; x++)
            {
                foreach (Control oControl in this.tabConfiguracion.TabPages[x].Controls)
                {
                    if ((oControl is TextBox) || (oControl is CheckBox) || (oControl is ComboBox) || (oControl is NumericUpDown) || (oControl is DateTimePicker))
                    {
                        //Guardamos su nombre...
                        Nombre = oControl.Name;
                        Descripcion = oControl.AccessibleDescription;
                        Nombre_Controles.Add(Nombre.Substring(3));
                        Descripcion_Controles.Add(Descripcion);

                    }
                }
            }
            x = 0;
            foreach (DataRow row in dtVariables.Rows)
            {
                Nombre_Variables.Add(row["Variable"].ToString());
                Descripcion_Variables.Add(row["descripcion"].ToString());
            }

            largolista = Nombre_Controles.Count;
            largoDB = dtVariables.Rows.Count;
            Nombre_Controles.Sort();
            string nombre_control = "";
            IEnumerable<string> differenceQuery = Nombre_Controles.Except(Nombre_Variables);
            foreach (string s in differenceQuery)
                oConfig.AgregarVariable(s);
            oConfig.LoadConfiguracion();

            for (x = 0; x < tabConfiguracion.TabPages.Count; x++)
            {
                foreach (Control oControl in this.tabConfiguracion.TabPages[x].Controls)
                {
                    if (oControl is TextBox)
                    {
                        nombre_control = oControl.Name.Substring(3).ToString();
                        oControl.Text = oConfig.GetValor_C(nombre_control);
                    }
                    if (oControl is ComboBox)
                    {
                        nombre_control = oControl.Name.Substring(3).ToString();
                        oControl.Text = oConfig.GetValor_C(nombre_control);
                    }

                }
            }


            cboCondicion_Iva.SelectedIndex = oConfig.GetValor_N("Condicion_Iva") - 1;
            cboTipoGestionPartes.SelectedIndex = oConfig.GetValor_N("TipoGestionPartes") - 1;
            splCosto_IP.Value = oConfig.GetValor_N("Costo_IP");
            cboCobroIp.SelectedValue = oConfig.GetValor_N("CobroIp");
            cboId_Tipo_Facturacion.SelectedIndex = oConfig.GetValor_N("Id_Tipo_Facturacion") - 1;
            cboAgenda_Trabajo.SelectedIndex = oConfig.GetValor_N("Agenda_Trabajo") - 1;
            cboTrabaja_Manzanas.SelectedIndex = oConfig.GetValor_N("Trabaja_Manzanas") - 1;
            cboEstadoInicial.SelectedIndex = oConfig.GetValor_N("Estado_Inicial_Parte") - 1;
            cboCta_Seleccion.SelectedIndex = oConfig.GetValor_N("Cta_Seleccion") - 1;
            cboCta_Pagos_Parciales.SelectedIndex = oConfig.GetValor_N("Cta_Pagos_Parciales") - 1;
            cboCta_Comprobante_De_Pago.SelectedIndex = oConfig.GetValor_N("Cta_Comprobante_De_Pago") - 1;
            cboBonificacionUsuLoc.SelectedIndex = oConfig.GetValor_N("BonificacionUsuLoc");
            splPunitorios_Porcentaje.Value = oConfig.GetValor_Decimal("Punitorios_Porcentaje");
            splPunitorios_Tolerancia.Value = oConfig.GetValor_N("Punitorios_Tolerancia");
            chkSolicita_Tarjeta_Parte.Checked = oConfig.GetValor_N("Solicita_Tarjeta_Parte") == 1 ? true : false;
            cboDeuda.SelectedIndex = oConfig.GetValor_N("Deuda") - 1;
            cboFormatoCaja.SelectedIndex = oConfig.GetValor_N("FormatoCaja") - 1;
            cboCambioMeses.SelectedIndex = oConfig.GetValor_N("CambioMeses") - 1;
            txtRutaCertificado.Text = oConfig.GetValor_C("RutaCertificado");
            txtRutaClave.Text = oConfig.GetValor_C("RutaClave");
            splCantidad_Decimales.Value = oConfig.GetValor_N("Cantidad_Decimales");
            chkVistaPreviaFactura.Checked = oConfig.GetValor_N("VistaPreviaFactura") == 1 ? true : false;
            txtCorreoFactura.Text = oConfig.GetValor_C("CorreoFactura");
            txtPassCorreo.Text = oConfig.GetValor_C("PassCorreo");
            cboBonifSoloEspeciales.SelectedIndex = oConfig.GetValor_N("BonifSoloEspeciales") - 1;
            cboDeudaAdelantada.SelectedIndex = oConfig.GetValor_N("DeudaAdelantada") - 1;
            txtServidor.Text = oConfig.GetValor_C("servidor");
            txtPuerto.Text = oConfig.GetValor_N("puerto").ToString();
            chkTraspasoPartes.Checked = oConfig.GetValor_N("TraspasoPartes") == 1 ? true : false;
            chkTraspasoCtacte.Checked = oConfig.GetValor_N("TraspasoCtaCte") == 1 ? true : false;
            chkModPuntoGestion.Checked = oConfig.GetValor_N("ModPuntoGestion") == 1 ? false : true;
            chkBusquedaUsuarioExactitud.Checked = oConfig.GetValor_N("BusquedaUsuarioExactitud") == 1 ? false : true;
            cboEstadoDesafectarEquipo.SelectedValue = oConfig.GetValor_N("EstadoDesafectarEquipo");
            cboTipoPunitorio.SelectedValue = oConfig.GetValor_N("TipoPunitorio");
            chkTrasladaImpago.Checked = oConfig.GetValor_N("TrasladaImpago") == 1 ? true : false;
            chkVerificacionAsignarEquipo.Checked = oConfig.GetValor_N("VerificacionAsignarEquipo") == 1 ? false : true;
            chkRetencion.Checked = oConfig.GetValor_C("Retencion") == "S" ? true : false;
            spnRetencion_IIBB.Value = Convert.ToDecimal(oConfig.GetValor_N("Retencion_IIBB"));
            //DEBITO AUTOMATICO
            dtpFechaFinDebito.Value = Convert.ToDateTime(oConfig.GetValor_C("FechaDebitoFin"));
            chkEmitirRemito.Checked = oConfig.GetValor_N("EmitirRemito") == 1 ? true : false;
            chkPreviewConsulta.Checked = oConfig.GetValor_N("PreviewConsulta") == 1 ? true : false;
            chkPreviewRecibos.Checked = oConfig.GetValor_N("PreviewRecibos") == 1 ? true : false;
            chkCtacteDefecto.Checked = oConfig.GetValor_N("TipoConsultaCuentaCorriente") == 1 ? true : false;
            chkCtacteLineal.Checked = oConfig.GetValor_N("TipoConsultaCuentaCorriente") == 2 ? true : false;
            chkSSL.Checked = oConfig.GetValor_N("SSL") == 2 ? true : false;
            chkParteTrabajaAppExterna.Checked = oConfig.GetValor_N("ParteTrabajaAppExterna") == 1 ? true : false;
            //FACTURA DE CREDITO
            chkTrabajaConFacturaDeCredito.Checked = oConfig.GetValor_N("TrabajaConFacturaDeCredito") == 1 ? true : false;
            splMontoMinimoFacturaDeCredito.Value = oConfig.GetValor_N("MontoMinimoFacturaDeCredito");
            txtCBUFacturaDeCredito.Text = oConfig.GetValor_C("CBUFacturaDeCredito");

            if (String.IsNullOrEmpty(oConfig.GetValor_C("FechaAPartirCalculaPunitorio")))
            {
                dtpFechaAPartirCalculaPunitorio.Value = DateTime.Now.Date;
            }
            else
            {
                string[] fechaAPartirCalcula = oConfig.GetValor_C("FechaAPartirCalculaPunitorio").Split('-');
                if (fechaAPartirCalcula.Length != 3)
                    dtpFechaAPartirCalculaPunitorio.Value = DateTime.Now.Date;
                else
                    dtpFechaAPartirCalculaPunitorio.Value = new DateTime(Convert.ToInt32(fechaAPartirCalcula[0]), Convert.ToInt32(fechaAPartirCalcula[1]), Convert.ToInt32(fechaAPartirCalcula[2]));
            }

            if (Convert.ToInt32(oConfig.GetValor_N("CassServPeriodo")) == 1)
            {
                rbPagar.Checked = false;
                rbGenerar.Checked = true;
            }
            else
            {
                rbGenerar.Checked = false;
                rbPagar.Checked = true;
            }
        }

        private void btnGuardar_Click(object sender, System.EventArgs e)
        {
            oConfig.SetValor_N("Solicita_Tarjeta_Parte", chkSolicita_Tarjeta_Parte.CheckState == CheckState.Checked ? 1 : 0);
            oConfig.SetValor_C("Empresa", txtEmpresa.Text);
            oConfig.SetValor_C("Direccion", txtDireccion.Text);
            oConfig.SetValor_C("Localidad", txtLocalidad.Text);
            oConfig.SetValor_C("Inicio_actividades", txtInicio_actividades.Text);
            oConfig.SetValor_C("Condicion_Iva", cboCondicion_Iva.Text);
            oConfig.SetValor_C("Correo", txtCorreo.Text);
            oConfig.SetValor_C("Cuit", txtCuit.Text);
            oConfig.SetValor_C("Provincia", txtProvincia.Text);
            oConfig.SetValor_C("Ingresos_Brutos", txtIngresos_Brutos.Text);
            oConfig.SetValor_C("Hab_Municipal", txtHab_Municipal.Text);
            oConfig.SetValor_C("Telefono", txtTelefono.Text);
            oConfig.SetValor_N("Condicion_Iva", cboCondicion_Iva.SelectedIndex + 1);
            oConfig.SetValor_C("CorreoFactura", txtCorreoFactura.Text);
            oConfig.SetValor_C("PassCorreo", txtPassCorreo.Text);
            oConfig.SetValor_C("Servidor", txtServidor.Text);

            oConfig.SetValor_N("Costo_IP", (int)splCosto_IP.Value);
            oConfig.SetValor_N("CobroIp", (int)cboCobroIp.SelectedValue);
            oConfig.SetValor_N("Id_Tipo_Facturacion", cboId_Tipo_Facturacion.SelectedIndex + 1);
            oConfig.SetValor_N("Agenda_Trabajo", cboAgenda_Trabajo.SelectedIndex + 1);
            oConfig.SetValor_N("Estado_Inicial_Parte", cboEstadoInicial.SelectedIndex + 1);
            oConfig.SetValor_N("Trabaja_Manzanas", cboTrabaja_Manzanas.SelectedIndex + 1);
            oConfig.SetValor_N("Cta_Pagos_Parciales", cboCta_Pagos_Parciales.SelectedIndex + 1);
            oConfig.SetValor_N("Cta_Comprobante_De_Pago", cboCta_Comprobante_De_Pago.SelectedIndex + 1);
            oConfig.SetValor_N("Cta_Seleccion", cboCta_Seleccion.SelectedIndex + 1);
            oConfig.SetValor_N("Punitorios_Tolerancia", (int)splPunitorios_Tolerancia.Value);
            oConfig.SetValor_N("BonificacionUsuLoc", cboBonificacionUsuLoc.SelectedIndex);
            oConfig.SetValor_Decimal("Punitorios_Porcentaje", (decimal)splPunitorios_Porcentaje.Value);
            oConfig.SetValor_N("TipoGestionPartes", cboTipoGestionPartes.SelectedIndex + 1);
            oConfig.SetValor_N("Deuda", cboDeuda.SelectedIndex + 1);
            oConfig.SetValor_N("FormatoCaja", cboFormatoCaja.SelectedIndex + 1);
            oConfig.SetValor_N("CambioMeses", cboCambioMeses.SelectedIndex + 1);

            oConfig.SetValor_C("RutaCertificado", @txtRutaCertificado.Text);
            oConfig.SetValor_C("RutaClave", @txtRutaClave.Text);
            oConfig.SetValor_N("Cantidad_Decimales", (int)splCantidad_Decimales.Value);
            oConfig.SetValor_N("VistaPreviaFactura", chkVistaPreviaFactura.CheckState == CheckState.Checked ? 1 : 0);
            oConfig.SetValor_N("BonifSoloEspeciales", cboBonifSoloEspeciales.SelectedIndex + 1);
            oConfig.SetValor_N("DeudaAdelantada", cboDeudaAdelantada.SelectedIndex + 1);
            oConfig.SetValor_N("Puerto", Convert.ToInt32(txtPuerto.Text));
            oConfig.SetValor_N("TraspasoPartes", chkTraspasoPartes.CheckState == CheckState.Checked ? 1 : 0);
            oConfig.SetValor_N("TraspasoCtaCte", chkTraspasoCtacte.CheckState == CheckState.Checked ? 1 : 0);
            oConfig.SetValor_N("TrasladaImpago", chkTrasladaImpago.CheckState == CheckState.Checked ? 1 : 0);

            oConfig.SetValor_N("ModPuntoGestion", chkModPuntoGestion.CheckState == CheckState.Checked ? 2 : 1);
            oConfig.SetValor_N("BusquedaUsuarioExactitud", chkBusquedaUsuarioExactitud.CheckState == CheckState.Checked ? 2 : 1);
            oConfig.SetValor_N("EstadoDesafectarEquipo", Convert.ToInt32(cboEstadoDesafectarEquipo.SelectedValue));
            oConfig.SetValor_C("EstadoDesafectarEquipo", cboEstadoDesafectarEquipo.Text);

            decimal Porcentaje = Convert.ToDecimal(spnRetencion_IIBB.Value);
            oConfig.SetValor_N("Retencion_IIBB", Convert.ToInt32(Porcentaje > 0 ? Porcentaje : 0));
            oConfig.SetValor_C("Retencion", chkRetencion.CheckState == CheckState.Checked ? "S" : "N");
            oConfig.SetValor_N("TipoPunitorio", cboTipoPunitorio.SelectedIndex + 1);
            oConfig.SetValor_N("VerificacionAsignarEquipo", chkVerificacionAsignarEquipo.CheckState == CheckState.Checked ? 2 : 1);
            oConfig.SetValor_C("FechaAPartirCalculaPunitorio", $"{dtpFechaAPartirCalculaPunitorio.Value.Year}-{dtpFechaAPartirCalculaPunitorio.Value.Month}-{dtpFechaAPartirCalculaPunitorio.Value.Day}");
            oConfig.SetValor_N("EmitirRemito", chkEmitirRemito.CheckState == CheckState.Checked ? 1 : 0);
            oConfig.SetValor_N("PreviewConsulta", chkPreviewConsulta.CheckState == CheckState.Checked ? 1 : 0);
            oConfig.SetValor_N("PreviewRecibos", chkPreviewRecibos.CheckState == CheckState.Checked ? 1 : 0);
            oConfig.SetValor_N("SSL", chkSSL.CheckState == CheckState.Checked ? 2 : 1);
            //DEBITO AUTOMATICO
            oConfig.SetValor_C("FechaDebitoFin", dtpFechaFinDebito.Value.ToString("dd-MM-yyyy"));
            oConfig.SetValor_N("TipoConsultaCuentaCorriente", chkCtacteDefecto.CheckState == CheckState.Checked ? 1 : 2);
            //   Muestra_Item_factura

            //FACTURA DE CREDITO
            oConfig.SetValor_N("TrabajaConFacturaDeCredito", chkTrabajaConFacturaDeCredito.CheckState == CheckState.Checked ? 1 : 0);
            oConfig.SetValor_N("MontoMinimoFacturaDeCredito", (int)splMontoMinimoFacturaDeCredito.Value);
            oConfig.SetValor_C("CBUFacturaDeCredito", txtCBUFacturaDeCredito.Text);
            oConfig.SetValor_N("ParteTrabajaAppExterna", chkParteTrabajaAppExterna.CheckState == CheckState.Checked ? 1 : 2);
            oConfig.SetValor_N("CassServPeriodo", rbGenerar.Checked == true ? 1 : 2);

            oConfig.LoadConfiguracion();
            this.Close();

        }

        private void label19_Click(object sender, System.EventArgs e)
        {

        }

        private void cboAgenda_Trabajo_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        private void frmOpciones_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "All Files (*.crt)|*.crt";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = true;

            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                string sFileName = choofdlog.FileName;

                txtRutaCertificado.Text = sFileName.Replace("\\", "\\\\");

            }
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "All Files (*.key)|*.key";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = true;

            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                string sFileName = choofdlog.FileName;
                txtRutaClave.Text = sFileName.Replace("\\", "\\\\"); ;
            }
        }

        private void chkRetencion_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRetencion.Checked == true)
            {
                spnRetencion_IIBB.Visible = true;
                label29.Visible = true;
            }
            else
            {
                spnRetencion_IIBB.Visible = false;
                label29.Visible = false;
                spnRetencion_IIBB.Value = 0;
            }
        }

        private void chkTraspasoCtacte_CheckedChanged(object sender, EventArgs e)
        {
            chkTrasladaImpago.Enabled = chkTraspasoCtacte.Checked;
            if (!chkTraspasoCtacte.Checked)
                chkTrasladaImpago.Checked = false;
        }

        private void cboCobroIp_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cboCobroIp.SelectedValue) == 1)
                    splCosto_IP.Enabled = true;
                else
                    splCosto_IP.Enabled = false;

            }
            catch (Exception c)
            {
            }
        }

        private void AbrirFormularioDetallesComprobantes()
        {
            frmPopUp popup = new frmPopUp();
            frmDetallesComprobantes frmDetComp = new frmDetallesComprobantes();

            popup.Formulario = frmDetComp;
            popup.Maximizar = false;
            popup.ShowDialog();
        }

        private void btnDetalleComp_Click(object sender, EventArgs e)
        {
            AbrirFormularioDetallesComprobantes();
        }

        private void chkCtacteDefecto_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCtacteDefecto.Checked == true)
                chkCtacteLineal.Checked = false;
        }

        private void chkCtacteLineal_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCtacteLineal.Checked == true)
                chkCtacteDefecto.Checked = false;
        }
    }
}//111119fede
