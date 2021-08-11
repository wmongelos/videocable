using CapaNegocios;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacion.Abms
{
    public partial class ABMServicios_Ficha : Form
    {
        public DataRow DataRow;

        private DataTable dtDatosSerEstados = new DataTable();
        private Servicios_Tipos oSerTipo = new Servicios_Tipos();
        private Servicios oSer = new Servicios();
        private Aplicaciones_Externas oAppExternas = new Aplicaciones_Externas();

        public ABMServicios_Ficha()
        {
            InitializeComponent();
        }

        private void ABMServicio_Load(object sender, EventArgs e)
        {
            dtDatosSerEstados = oSer.ListarEstados();
            cboServicios_Tipos.DataSource = oSerTipo.Listar();
            cboServicios_Tipos.ValueMember = "Id";
            cboServicios_Tipos.DisplayMember = "Nombre";

            cboServicios_Modalidad.DataSource = oSer.ListarModalidades();
            cboServicios_Modalidad.ValueMember = "Id";
            cboServicios_Modalidad.DisplayMember = "Nombre";

            cboContratos.DataSource = oSer.ListarContratos();
            cboContratos.ValueMember = "Id";
            cboContratos.DisplayMember = "Contrato";

            cboCorteDefecto.DataSource = oSer.ListarEstados();
            cboCorteDefecto.ValueMember = "Id";
            cboCorteDefecto.DisplayMember = "Estado";

            DataTable dtAplicacionesExternas = new DataTable();
            dtAplicacionesExternas = oAppExternas.Listar();
            if (dtAplicacionesExternas.Rows.Count > 0)
            {
                cboApliciones_Externas.DataSource = dtAplicacionesExternas;
                cboApliciones_Externas.ValueMember = "Id";
                cboApliciones_Externas.DisplayMember = "Nombre";
            }

            int idEstadoCortado = (int)Servicios.Servicios_Estados.CORTADO;
            int idEstadoRetirado = (int)Servicios.Servicios_Estados.RETIRADO;
            chkCortado.Text = dtDatosSerEstados.Select(string.Format("id={0}", idEstadoCortado))[0]["estado"].ToString();
            chkRetirado.Text = dtDatosSerEstados.Select(string.Format("id={0}", idEstadoRetirado))[0]["estado"].ToString();
            cboTipoCorte.SelectedIndex = 0;
            DataTable dtOrigen = oSer.getOrigenMeses();
            cboOrigen.DataSource = dtOrigen;
            cboOrigen.ValueMember = "Id";
            cboOrigen.DisplayMember = "Origen";
            if (this.DataRow != null)
            {
                oSer.Id = Convert.ToInt32(this.DataRow["Id"]);

                lblServicio.Text = this.DataRow["Descripcion"].ToString();
                txtDescripcion.Text = this.DataRow["Descripcion"].ToString();
                cboServicios_Tipos.SelectedValue = this.DataRow["Id_Servicios_Tipos"];
                cboServicios_Modalidad.SelectedValue = this.DataRow["Id_Servicios_Modalidad"];
                chkServicioFechaIni.CheckState = this.DataRow["Fecha_Inicio_Servicio"].ToString() == "1" ? CheckState.Checked : CheckState.Unchecked;
                spDias_Bonificacion.Value = Convert.ToDecimal(this.DataRow["Dias_Bonificacion"]);
                chkRequiereEquipo.CheckState = this.DataRow["Requiere_Equipo"].ToString() == "SI" ? CheckState.Checked : CheckState.Unchecked;
                chkRequiereTar.CheckState = this.DataRow["Requiere_Tarjeta"].ToString() == "SI" ? CheckState.Checked : CheckState.Unchecked;
                chkRequiereVel.CheckState = this.DataRow["Requiere_Velocidad"].ToString() == "SI" ? CheckState.Checked : CheckState.Unchecked;
                chkCorteAutomatico.CheckState = this.DataRow["CorteAutomatico"].ToString() == "1" ? CheckState.Checked : CheckState.Unchecked;
                cboTipoCorte.SelectedIndex = Convert.ToInt32(this.DataRow["TipoCorte"].ToString());
                chkForzarInicioMes.CheckState = this.DataRow["Forzar_Inicio_Mes"].ToString() == "1" ? CheckState.Checked : CheckState.Unchecked;
                chkRequiere_Servicio_Padre.CheckState = this.DataRow["Requiere_Servicio_Padre"].ToString() == "1" ? CheckState.Checked : CheckState.Unchecked;

                chkAppExterna.CheckState = Convert.ToInt32(this.DataRow["Aplicacion_Externa"]) == 1 ? CheckState.Checked : CheckState.Unchecked;
                cboApliciones_Externas.SelectedValue = Convert.ToInt32(this.DataRow["Id_Aplicaciones_Externas"]);
                cboContratos.SelectedValue = Convert.ToInt32(this.DataRow["Id_Contrato"]);
                cboCta.SelectedIndex = Convert.ToInt32(this.DataRow["Cuenta"]) - 1;

                chkCortado.CheckState = Convert.ToInt32(this.DataRow["genera_deuda_cortado"]) == 1 ? CheckState.Checked : CheckState.Unchecked;
                chkRetirado.CheckState = Convert.ToInt32(this.DataRow["genera_deuda_retirado"]) == 1 ? CheckState.Checked : CheckState.Unchecked;
                chkDebito.CheckState = Convert.ToInt32(this.DataRow["habilita_debito"]) == 1 ? CheckState.Checked : CheckState.Unchecked;
                cboOrigen.SelectedValue = Convert.ToInt32(this.DataRow["OrigenMeses"]);
                cboCorteDefecto.SelectedValue = Convert.ToInt32(this.DataRow["Id_parte_corte"]);
            }
            else
            {
                lblServicio.Text = "ALTA DE SERVICIO";
            }



        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            oSer.Descripcion = txtDescripcion.Text.Trim();
            oSer.Id_Servicios_Tipos = Convert.ToInt32(cboServicios_Tipos.SelectedValue);
            oSer.Id_Servicios_Modalidad = Convert.ToInt32(cboServicios_Modalidad.SelectedValue);
            oSer.Fecha_Inicio_Servicio = chkServicioFechaIni.CheckState == CheckState.Checked ? 1 : 0;
            oSer.Dias_Bonificacion = Convert.ToInt32(spDias_Bonificacion.Value);
            oSer.Requiere_Equipo = chkRequiereEquipo.CheckState == CheckState.Checked ? Servicios._Requiere_equipo.SI : Servicios._Requiere_equipo.NO;
            oSer.Requiere_Tarjeta = chkRequiereTar.CheckState == CheckState.Checked ? Servicios._Requiere_tarjeta.SI : Servicios._Requiere_tarjeta.NO;
            oSer.Requiere_Velocidad = chkRequiereVel.CheckState == CheckState.Checked ? Servicios._Requiere_velocidad.SI : Servicios._Requiere_velocidad.NO;
            oSer.CorteAutomatico = chkCorteAutomatico.CheckState == CheckState.Checked ? 1 : 0;
            oSer.TipodeCorte = cboTipoCorte.SelectedIndex;
            oSer.Forzar_Inicio_Mes = chkForzarInicioMes.CheckState == CheckState.Checked ? 1 : 0;
            oSer.Requiere_Servicio_Padre = chkRequiere_Servicio_Padre.CheckState == CheckState.Checked ? 1 : 0;
            oSer.Factura_Mensualmente = chkFacturarMensualmente.CheckState == CheckState.Checked ? Servicios._Factura_mensualmente.SI : Servicios._Factura_mensualmente.NO;
            oSer.Aplicaciones_Externas = chkAppExterna.CheckState == CheckState.Checked ? 1 : 0;
            oSer.Id_Aplicaciones_Externas = chkAppExterna.CheckState == CheckState.Checked ? Convert.ToInt32(cboApliciones_Externas.SelectedValue) : 0;
            oSer.Id_Contrato = Convert.ToInt32(cboContratos.SelectedValue);
            oSer.Cuenta = cboCta.SelectedIndex + 1;
            oSer.GeneraDeudaCortado = chkCortado.CheckState == CheckState.Checked ? 1 : 0;
            oSer.GeneraDeudaRetirado = chkRetirado.CheckState == CheckState.Checked ? 1 : 0;
            oSer.Origen_meses = Convert.ToInt32(cboOrigen.SelectedValue);
            oSer.Id_parte_corte = Convert.ToInt32(cboCorteDefecto.SelectedValue);
            oSer.Habilita_Debito = chkDebito.CheckState == CheckState.Checked ? 1 : 0;
            oSer.Guardar(oSer, Personal.Id_Login);
            Tablas.LoadData();

            this.DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ABMServicio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void cboServicios_Modalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cboServicios_Modalidad.SelectedValue) == Convert.ToInt32(Servicios._Modalidad.PERIODO))
                {
                    chkRequiere_Servicio_Padre.Enabled = true;
                    chkServicioFechaIni.Enabled = true;
                }
                else
                {
                    chkRequiere_Servicio_Padre.Enabled = false;
                    chkServicioFechaIni.Enabled = false;
                    spDias_Bonificacion.Enabled = false;
                    lblDiasBonificacion.Enabled = false;

                    if (Convert.ToInt32(cboServicios_Modalidad.SelectedValue) == Convert.ToInt32(Servicios._Modalidad.DIA))
                    {
                        spDias_Bonificacion.Enabled = true;
                        lblDiasBonificacion.Enabled = true;
                    }

                    if (Convert.ToInt32(cboServicios_Modalidad.SelectedValue) == Convert.ToInt32(Servicios._Modalidad.PERIODO_CERRADO_POR_DIA))
                    {
                        chkServicioFechaIni.Enabled = true;
                        chkServicioFechaIni.Checked = true;
                    }
                }
                if (DataRow != null && DataRow["factura_mensualmente"].ToString().ToUpper() == "SI")
                    chkFacturarMensualmente.Checked = true;
                else
                    chkFacturarMensualmente.Checked = false;
            }
            catch { }
        }

        private void chkAppExterna_CheckedChanged(object sender, EventArgs e)
        {
            cboApliciones_Externas.Enabled = chkAppExterna.CheckState == CheckState.Checked ? true : false;
        }
    }
}
