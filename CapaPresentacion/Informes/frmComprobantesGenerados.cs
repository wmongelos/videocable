using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using CapaNegocios;

namespace CapaPresentacion.Informes
{
    public partial class frmComprobantesGenerados : Form
    {
        #region PROPIEDADES

        private Thread hilo;
        private delegate void myDel();
        private int idOrigenSeleccionado, idFacPresSeleccionado,idTipoCompSeleccionado;
        private DateTime fechaDesde, fechaHasta;
        private DataTable dtComprobantes = new DataTable();
        private DataTable dtOrigenComprobantes;
        private DataTable dtTipoComprobantes;
        private Comprobantes oComprobantes = new Comprobantes();
        private bool yaCargo = false,filtroRechazados=false;
        private int usuarioCodigo = 0;
        #endregion
        #region METODOS
        private void comenzarCarga()
        {
            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.IsBackground = true;
            hilo.Start();
        }
        private void cargarDatos()
        {
            try
            {

                dtComprobantes = oComprobantes.ListarComprobantesGenerados(idOrigenSeleccionado,idFacPresSeleccionado,fechaDesde,fechaHasta,idTipoCompSeleccionado,usuarioCodigo);
                myDel MD = new myDel(asignarDatos);
                this.Invoke(MD, new object[] { });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Informacion" + ex.Message);
            }
        }

        private void asignarDatos()
        {
            dgvComprobantes.DataSource = dtComprobantes;
            dgvComprobantes.Columns["rechazado"].Visible = false;
            dgvComprobantes.Columns["id_estado_debito"].Visible = false;
            dgvComprobantes.Columns["personal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvComprobantes.Columns["personal"].HeaderText = "Personal";
            dgvComprobantes.Columns["importe_final"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvComprobantes.Columns["importe_final"].DefaultCellStyle.Format ="c2";
            dgvComprobantes.Columns["importe_final"].HeaderText = "Importe";
            dgvComprobantes.Columns["importe_final"].Width =150;

            dgvComprobantes.Columns["fecha"].Width =100;
            dgvComprobantes.Columns["fecha"].HeaderText = "Fecha";

            dgvComprobantes.Columns["codigo"].Width =70;
            dgvComprobantes.Columns["codigo"].HeaderText = "Codigo";
            dgvComprobantes.Columns["abonado"].HeaderText = "Abonado";
            dgvComprobantes.Columns["descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvComprobantes.Columns["descripcion"].HeaderText = "Comprobante/Factura";

            btnBuscar.Enabled = true;
            btnExportar.Enabled = true;
            imgReturn.Enabled = true;
            lblTotal.Text = $"Total encontrados: {dtComprobantes.Rows.Count} ";
            dtComprobantes.DefaultView.RowFilter="";
            object sumTotal = dtComprobantes.Compute("sum(importe_final)", "");
            if(dtComprobantes.Rows.Count>0)
                lblImporteTotal.Text = $"Importe total: {Convert.ToDecimal(sumTotal).ToString("c2")}";
            int cantidadRechazados = 0;
            if (Convert.ToInt32(cboOrigen.SelectedValue) == (int)Usuarios_CtaCte.ORIGEN.FACTURACION_MENSUAL_DEBITOS)
            {
                foreach (DataGridViewRow item in dgvComprobantes.Rows)
                {
                    if (Convert.ToInt32(item.Cells["rechazado"].Value) != 0)
                    {
                        cantidadRechazados++;
                        item.DefaultCellStyle.BackColor = Color.Tomato;
                    }
                }
                lblCantRechazados.Text = $"Cantidad de rechazados: {cantidadRechazados} ";
                lblReferencias.Visible = true;
                lblRechazado.Visible = true;
                lblCantRechazados.Visible = true;
            }
            else
            {
                lblReferencias.Visible = false;
                lblRechazado.Visible = false;
                lblCantRechazados.Visible = false;

            }
            pgCircular.Stop();

        }
        private void CargarCombos()
        {
            dtTipoComprobantes = Tablas.DataTipoComprobantes.Copy();
            DataView dvTipoCom = new DataView(dtTipoComprobantes);
            dvTipoCom.RowFilter = "id=1 OR id=2 OR id=7 ";//factura a,b y comprobante de deuda
            dtTipoComprobantes = dvTipoCom.ToTable();
            dtTipoComprobantes.Rows.Add(0, "TODOS");
            cboTipo.DataSource = dtTipoComprobantes;
            cboTipo.DisplayMember = "nombre";
            cboTipo.ValueMember = "id";
            cboTipo.SelectedValue = 0;

            dtOrigenComprobantes =  Tablas.DataOrigenComprobantes.Copy();
            dtOrigenComprobantes.Rows.Add(0, "TODOS");
            cboOrigen.DataSource = dtOrigenComprobantes;
            cboOrigen.DisplayMember = "nombre";
            cboOrigen.ValueMember = "id";
            cboOrigen.SelectedValue = 0;
            cboFacPres.Visible = false;
            lblFaturacion.Visible = false;
            yaCargo = true;
        }
        #endregion
        public frmComprobantesGenerados()
        {
            InitializeComponent();
        }

        private void cboOrigen_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (yaCargo)
            {
                idOrigenSeleccionado = Convert.ToInt32(cboOrigen.SelectedValue);

                if (idOrigenSeleccionado == (int)Usuarios_CtaCte.ORIGEN.FACTURACION_MENSUAL)
                {
                    pnlFechas.Visible = false;
                    lblFaturacion.Visible = true;
                    cboFacPres.Visible = true;
                    Facturacion_Mensual_Historial oFacturacion = new Facturacion_Mensual_Historial();
                    DataTable dtFacturaciones = oFacturacion.ListarHistorial();
                    cboFacPres.DataSource = dtFacturaciones;
                    cboFacPres.DisplayMember = "periodo";
                    cboFacPres.ValueMember = "id";

                }
                else if(idOrigenSeleccionado == (int)Usuarios_CtaCte.ORIGEN.FACTURACION_MENSUAL_DEBITOS)
                {
                    pnlFechas.Visible = false;
                    lblFaturacion.Visible = true;
                    cboFacPres.Visible = true;

                    Presentacion_Debitos oPresentacion = new Presentacion_Debitos();
                    DataTable dtPresentaciones = oPresentacion.ListarTodas();
                    cboFacPres.DataSource = dtPresentaciones;
                    cboFacPres.DisplayMember = "periodo";
                    cboFacPres.ValueMember = "id";
                }
                else
                {
                    lblFaturacion.Visible = false;
                    cboFacPres.Visible = false;
                    pnlFechas.Visible = true;
                }
            }
        }

        private void dtpDesde_ValueChanged(object sender, EventArgs e)
        {
            dtpHasta.MinDate = dtpDesde.Value.Date;
        }

        private void frmComprobantesGenerados_Load(object sender, EventArgs e)
        {
            CargarCombos();
        }

        private void txtCod_Leave(object sender, EventArgs e)
        {
            if (txtCod.Text.Trim() == "")
                txtCod.Text = "0";
        }

        private void lblRechazado_Click(object sender, EventArgs e)
        {
            if (filtroRechazados == false)
            {
                filtroRechazados = true;
                dtComprobantes.DefaultView.RowFilter = dtComprobantes.DefaultView.RowFilter + "rechazado>0";
               
            }
            else
            {
                filtroRechazados = false;
                dtComprobantes.DefaultView.RowFilter = "";
            }
            foreach (DataGridViewRow item in dgvComprobantes.Rows)
            {
                if (Convert.ToInt32(item.Cells["rechazado"].Value) != 0)
                    item.DefaultCellStyle.BackColor = Color.Tomato;
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            Tools oTools = new Tools();
            oTools.ExportDataTableToExcel(dtComprobantes, "Comprobantes generados");
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            idFacPresSeleccionado = Convert.ToInt32(cboFacPres.SelectedValue);
            idOrigenSeleccionado = Convert.ToInt32(cboOrigen.SelectedValue);
            idTipoCompSeleccionado = Convert.ToInt32(cboTipo.SelectedValue);
            usuarioCodigo = Convert.ToInt32(txtCod.Text);
            fechaDesde = dtpDesde.Value;
            fechaHasta = dtpHasta.Value;
            btnBuscar.Enabled = false;
            btnExportar.Enabled = false;
            imgReturn.Enabled = false;
            pgCircular.Start();
            comenzarCarga();
        }
    }
}
