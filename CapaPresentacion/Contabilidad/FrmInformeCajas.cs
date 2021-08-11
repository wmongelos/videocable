using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CapaNegocios;
using System.Globalization;
using System.Threading;

namespace CapaPresentacion.Contabilidad
{
    public partial class FrmInformeCajas : Form
    {
        public FrmInformeCajas()
        {
            InitializeComponent();
        }
        #region PROPIEDADES
        private Thread hilo;
        private delegate void myDel();
        private DataTable dt_Caja_general, dt_Caja_diaria;
        private DataTable dt_Detalle_General;
        private DataTable dt_Detalle_Diaria;
        private Caja_general oGeneral = new Caja_general();
        private Caja_Diaria oDiaria = new Caja_Diaria();
        Decimal ImporteTotalGeneral, ImporteTotalDiaria;
        Int32 FilasTotalesGeneral, FilasTotalesDiaria;
        private Usuarios_CtaCte_Recibos oRecibos = new Usuarios_CtaCte_Recibos();
        DateTime desde, hasta;
        int cont_Diaria = 0;
        #endregion

        #region METODOS

        private void comenzarCarga()
        {

            dgvCajaGeneral.DataSource = null;
            dgvCajaDiaria.DataSource = null;

            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
        }

        private void cargarDatos()
        {
            try
            {
                dt_Caja_general = oGeneral.ListarCajaGeneral(desde,hasta);

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
            FormatearDgvCajaGeneral();
            FormatearDgvCajaDiaria();
        }

        private void FormatearDgvCajaGeneral()
        {
            dgvCajaGeneral.DataSource = dt_Caja_general;

            for (int i = 0; i < dgvCajaGeneral.ColumnCount; i++)
                dgvCajaGeneral.Columns[i].Visible = false;

            dgvCajaGeneral.Columns["CajaGeneral"].Visible = true;
            dgvCajaGeneral.Columns["fecha"].Visible = true;
            dgvCajaGeneral.Columns["importe_cuenta1"].Visible = true;
            dgvCajaGeneral.Columns["importe_cuenta2"].Visible = true;
            dgvCajaGeneral.Columns["importe_total"].Visible = true;
            dgvCajaGeneral.Columns["CajaGeneral"].HeaderText = "TIPOCAJA";
            dgvCajaGeneral.Columns["fecha"].HeaderText = "Fecha";
            dgvCajaGeneral.Columns["importe_cuenta1"].HeaderText = "Cuenta 1";
            dgvCajaGeneral.Columns["importe_cuenta2"].HeaderText = "Cuenta 2";
            dgvCajaGeneral.Columns["importe_total"].HeaderText = "Total";

            dgvCajaGeneral.Columns["importe_cuenta1"].DefaultCellStyle.Format = "C2";
            dgvCajaGeneral.Columns["importe_cuenta1"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCajaGeneral.Columns["importe_cuenta1"].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("en-US");

            dgvCajaGeneral.Columns["importe_cuenta2"].DefaultCellStyle.Format = "C2";
            dgvCajaGeneral.Columns["importe_cuenta2"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCajaGeneral.Columns["importe_cuenta2"].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("en-US");

            dgvCajaGeneral.Columns["importe_total"].DefaultCellStyle.Format = "C2";
            dgvCajaGeneral.Columns["importe_total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCajaGeneral.Columns["importe_total"].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("en-US");

            ImporteTotalGeneral = 0;
            FilasTotalesGeneral = 0;
            if (dgvCajaGeneral.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvCajaGeneral.Rows)
                {
                    if (row.Visible)
                    {
                        ImporteTotalGeneral += Convert.ToDecimal(row.Cells["Importe_Total"].Value);
                        FilasTotalesGeneral++;
                    }
                }
            }
            lblRegistrosGeneral.Text = String.Format("Total de Registros: {0}", FilasTotalesGeneral);
            lblImporteGeneral.Text = String.Format("Total: $ {0}", ImporteTotalGeneral);
            AgregarColumnaDgvCajaGeneral();
        }

        private void FormatearDgvCajaDiaria()
        {
            try
            {
                dgvCajaDiaria.DataSource = dt_Caja_diaria;

                for (int i = 0; i < dgvCajaDiaria.ColumnCount; i++)
                    dgvCajaDiaria.Columns[i].Visible = true;
                ImporteTotalDiaria = 0;
                FilasTotalesDiaria = 0;
                if (dgvCajaDiaria.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in dgvCajaDiaria.Rows)
                    {
                        if (row.Visible)
                        {
                            ImporteTotalDiaria += Convert.ToDecimal(row.Cells["Total"].Value);
                            FilasTotalesDiaria++;
                        }
                    }
                }
                lblRegistroDiaria.Text = String.Format("Total de Registros: {0}", FilasTotalesDiaria);
                lblImporteDiaria.Text = String.Format("Total: $ {0}", ImporteTotalDiaria);

                dgvCajaDiaria.Columns["id_diaria"].Visible = false;
                dgvCajaDiaria.Columns["Punto_cobro"].HeaderText = "Pto Cobro";
                dgvCajaDiaria.Columns["Fecha_caja"].HeaderText = "Fecha";
                dgvCajaDiaria.Columns["impcuenta1"].HeaderText = "Cuenta1";
                dgvCajaDiaria.Columns["impcuenta2"].HeaderText = "Cuenta2";
                dgvCajaDiaria.Columns["personales"].HeaderText = "Personal";
                dgvCajaDiaria.Columns["total"].HeaderText = "Total";

                dgvCajaDiaria.Columns["impcuenta1"].DefaultCellStyle.Format = "C2";
                dgvCajaDiaria.Columns["impcuenta1"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvCajaDiaria.Columns["impcuenta1"].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("en-US");
                dgvCajaDiaria.Columns["impcuenta2"].DefaultCellStyle.Format = "C2";
                dgvCajaDiaria.Columns["impcuenta2"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvCajaDiaria.Columns["impcuenta2"].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("en-US");
                dgvCajaDiaria.Columns["total"].DefaultCellStyle.Format = "C2";
                dgvCajaDiaria.Columns["total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvCajaDiaria.Columns["total"].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("en-US");
                if (cont_Diaria < 1)
                    AgregarColumnadgvCajaDiaria();
                cont_Diaria = cont_Diaria + 1;

            }
            catch { }
        }


        private void AgregarColumnaDgvCajaGeneral()
        {
                DataGridViewLinkColumn detalleCajaGral = new DataGridViewLinkColumn();
                detalleCajaGral.Text = "Detalle";
                detalleCajaGral.DataPropertyName = "DetalleGral";
                detalleCajaGral.Name = "DetalleGral";
                detalleCajaGral.LinkColor = Color.DarkOrchid;
                detalleCajaGral.VisitedLinkColor = Color.Violet;
                detalleCajaGral.UseColumnTextForLinkValue = true;
                detalleCajaGral.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                detalleCajaGral.Width = 100;
                detalleCajaGral.HeaderText = "Detalle";
                dgvCajaGeneral.Columns.Add(detalleCajaGral);

                DataGridViewLinkColumn formaPagoGeneral = new DataGridViewLinkColumn();
                formaPagoGeneral.Text = "Formas de Pago";
                formaPagoGeneral.DataPropertyName = "FormasPago";
                formaPagoGeneral.Name = "FormasPagoGral";
                formaPagoGeneral.LinkColor = Color.DarkOrchid;
                formaPagoGeneral.VisitedLinkColor = Color.Violet;
                formaPagoGeneral.UseColumnTextForLinkValue = true;
                formaPagoGeneral.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                formaPagoGeneral.Width = 100;
                formaPagoGeneral.HeaderText = "Formas de Pago";
                dgvCajaGeneral.Columns.Add(formaPagoGeneral);
        }

        private void FrmInformeCajas_Load(object sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Now.AddMonths(-1);
            dtpHasta.Value = DateTime.Now;
        }

        private void dgvCajaGeneral_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int FiltroColumna = 0; //1.PARA VER DETALLADO LOS SERVICIOS , 2.PARA VER LAS FORMAS DE PAGO
            int id_CajaGeneral = 0;
            id_CajaGeneral = Convert.ToInt32(dgvCajaGeneral.SelectedRows[0].Cells["id"].Value.ToString());
            if (dgvCajaGeneral.Columns[e.ColumnIndex].Name == "DetalleGral")
            {
                FiltroColumna = 1;    
                dt_Detalle_General = oGeneral.ListarDetalleCajaGeneral(id_CajaGeneral, FiltroColumna);
                using (frmPopUp frm = new frmPopUp())
                {
                    FrmCajaGeneralDetalle form = new FrmCajaGeneralDetalle();
                    form.Filtro = FiltroColumna;
                    form.dtDetalle = dt_Detalle_General;
                    frm.Formulario = form;
                    frm.Maximizar = false;

                    if (frm.ShowDialog() == DialogResult.OK)
                        cargarDatos();
                }
            }
            else if(dgvCajaGeneral.Columns[e.ColumnIndex].Name == "FormasPagoGral") 
            {
                FiltroColumna = 2;
                dt_Detalle_General = oGeneral.ListarDetalleCajaGeneral(id_CajaGeneral, FiltroColumna);
                using (frmPopUp frm = new frmPopUp())
                {
                    FrmCajaGeneralDetalle form = new FrmCajaGeneralDetalle();
                    form.Filtro = FiltroColumna;
                    form.dtDetalle = dt_Detalle_General;
                    frm.Formulario = form;
                    frm.Maximizar = false;

                    if (frm.ShowDialog() == DialogResult.OK)
                        cargarDatos();
                }
            }
        }

        private void AgregarColumnadgvCajaDiaria()
        {

                DataGridViewLinkColumn DetalleDiaria = new DataGridViewLinkColumn();
                DetalleDiaria.Text = "Detalles";
                DetalleDiaria.DataPropertyName = "DetalleDiaria";
                DetalleDiaria.Name = "DetalleDiaria";
                DetalleDiaria.LinkColor = Color.DarkOrchid;
                DetalleDiaria.VisitedLinkColor = Color.Violet;
                DetalleDiaria.UseColumnTextForLinkValue = true;
                DetalleDiaria.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                DetalleDiaria.Width = 10;
                DetalleDiaria.HeaderText = "Detalle";
                dgvCajaDiaria.Columns.Add(DetalleDiaria);

                DataGridViewLinkColumn FormaPagoDiaria = new DataGridViewLinkColumn();
                FormaPagoDiaria.Text = "Formas de Pago";
                FormaPagoDiaria.DataPropertyName = "FormasPagoDiaria";
                FormaPagoDiaria.Name = "FormasPagoDiaria";
                FormaPagoDiaria.LinkColor = Color.DarkOrchid;
                FormaPagoDiaria.VisitedLinkColor = Color.Violet;
                FormaPagoDiaria.UseColumnTextForLinkValue = true;
                FormaPagoDiaria.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                FormaPagoDiaria.Width = 10;
                FormaPagoDiaria.HeaderText = "Formas de Pago";
                dgvCajaDiaria.Columns.Add(FormaPagoDiaria);

                DataGridViewLinkColumn Recibos = new DataGridViewLinkColumn();
                Recibos.Text = "Recibos";
                Recibos.DataPropertyName = "Recibos";
                Recibos.Name = "Recibos";
                Recibos.LinkColor = Color.DarkOrchid;
                Recibos.VisitedLinkColor = Color.Violet;
                Recibos.UseColumnTextForLinkValue = true;
                Recibos.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Recibos.Width = 10;
                Recibos.HeaderText = "Recibos";
                dgvCajaDiaria.Columns.Add(Recibos);
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            if (dgvCajaGeneral.Rows.Count > 0)
            {
                Tools tools = new Tools();
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    tools.ExportDataTableToExcel(dt_Caja_general, "CajaGeneral");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally { this.Cursor = Cursors.Default; }
            }
            else
            {
                MessageBox.Show("Tabla vacia", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (dgvCajaDiaria.Rows.Count > 0)
            {
                Tools tools = new Tools();
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    tools.ExportDataTableToExcel(dt_Caja_diaria, "CajaDiaria");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally { this.Cursor = Cursors.Default; }
            }
            else
            {
                MessageBox.Show("Tabla vacia", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        #endregion

        #region EVENTOS

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            desde = dtpDesde.Value;
            hasta = dtpHasta.Value;
            comenzarCarga();
        }

        private void dgvCajaDiaria_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int FiltroColumna = 0; //1.PARA VER DETALLADO LOS SERVICIOS , 2.PARA VER LAS FORMAS DE PAGO
            int id_CajaDiaria = 0;
            id_CajaDiaria = Convert.ToInt32(dgvCajaDiaria.SelectedRows[0].Cells["id_Diaria"].Value.ToString());
            if (dgvCajaDiaria.Columns[e.ColumnIndex].Name == "DetalleDiaria")
            {
                FiltroColumna = 1;
                dt_Detalle_Diaria = oDiaria.ListarDetallesCajaDiaria(id_CajaDiaria, FiltroColumna);
                using (frmPopUp frm = new frmPopUp())
                {
                    FrmCajaDiariaDetalle form = new FrmCajaDiariaDetalle();
                    form.Filtro = FiltroColumna;
                    form.dtDetalle = dt_Detalle_Diaria;
                    frm.Formulario = form;
                    frm.Maximizar = false;

                    if (frm.ShowDialog() == DialogResult.OK)
                        cargarDatos();
                }
            }
            else if (dgvCajaDiaria.Columns[e.ColumnIndex].Name == "FormasPagoDiaria")
            {
                FiltroColumna = 2;
                dt_Detalle_Diaria = oDiaria.ListarDetallesCajaDiaria(id_CajaDiaria, FiltroColumna);
                using (frmPopUp frm = new frmPopUp())
                {
                    FrmCajaDiariaDetalle form = new FrmCajaDiariaDetalle();
                    form.Filtro = FiltroColumna;
                    form.dtDetalle = dt_Detalle_Diaria;
                    frm.Formulario = form;
                    frm.Maximizar = false;

                    if (frm.ShowDialog() == DialogResult.OK)
                        cargarDatos();
                }
            }
            else if (dgvCajaDiaria.Columns[e.ColumnIndex].Name == "Recibos")
            {
                FiltroColumna = 3;
                dt_Detalle_Diaria = oDiaria.ListarDetallesCajaDiaria(id_CajaDiaria, FiltroColumna);
                using (frmPopUp frm = new frmPopUp())
                {
                    FrmCajaDiariaDetalle form = new FrmCajaDiariaDetalle();
                    form.Filtro = FiltroColumna;
                    form.dtDetalle = dt_Detalle_Diaria;
                    frm.Formulario = form;
                    frm.Maximizar = false;

                    if (frm.ShowDialog() == DialogResult.OK)
                        cargarDatos();
                }
            }
        }

        private void dgvCajaGeneral_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try 
            { 
                int id_CajaGeneral = 0;
                id_CajaGeneral = Convert.ToInt32(dgvCajaGeneral.SelectedRows[0].Cells["id"].Value.ToString());
                dt_Caja_diaria = oDiaria.ListarCajasIdCajaGeneral(id_CajaGeneral);
                FormatearDgvCajaDiaria();             
            }
            catch { }
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
