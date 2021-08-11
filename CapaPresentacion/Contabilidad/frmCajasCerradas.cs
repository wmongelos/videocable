using CapaNegocios;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;


namespace CapaPresentacion
{
    public partial class frmCajasCerradas : Form
    {
        #region [PROPIEDADES]
        private Caja_general oCajasGenerales = new Caja_general();
        private Thread hilo;
        private delegate void myDel();
        private DataTable dtCajasCerradas = new DataTable();
        private DataView dv;
        private DateTime fechaDesde, fechaHasta;
        #endregion

        #region [METODOS]
        private void comenzarCarga()
        {
            pgCircular.Start();
            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
            btnExportar.Enabled = false;
            btnFiltrar.Enabled = false;

        }

        private void cargarDatos()
        {
            try
            {
                DateTime desde = dtpDesde.Value;
                DateTime hasta = dtpHasta.Value;
                dtCajasCerradas = oCajasGenerales.ListarCajasCerradas(desde, hasta);
                dv = dtCajasCerradas.DefaultView;
                myDel MD = new myDel(asignarDatos);

                this.Invoke(MD, new object[] { });

                pgCircular.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Informacion" + ex.Message);
            }
        }

        private void asignarDatos()
        {
            try
            {
                dgvCajas.DataSource = dv;
                btnFiltrar.Enabled = true;
                dtpDesde.Enabled = true;
                dtpHasta.Enabled = true;
                FormatearGrilla();
            }
            catch (Exception)
            {

                throw;
            }
            btnExportar.Enabled = true;
            btnFiltrar.Enabled = true;


        }

        private void FormatearGrilla()
        {

            foreach (DataGridViewColumn item in dgvCajas.Columns)
                item.Visible = false;

            dgvCajas.Columns["importe_cuenta1"].Visible = true;
            dgvCajas.Columns["importe_cuenta1"].HeaderText = "Importe cuenta 1";
            dgvCajas.Columns["importe_cuenta1"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCajas.Columns["importe_cuenta1"].DefaultCellStyle.Format = "c2";

            dgvCajas.Columns["importe_cuenta2"].Visible = true;
            dgvCajas.Columns["importe_cuenta2"].HeaderText = "importe cuenta 2";
            dgvCajas.Columns["importe_cuenta2"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCajas.Columns["importe_cuenta2"].DefaultCellStyle.Format = "c2";

            dgvCajas.Columns["fecha"].Visible = true;
            dgvCajas.Columns["fecha"].HeaderText = "Fecha";

            dgvCajas.Columns["controlada"].Visible = true;
            dgvCajas.Columns["controlada"].HeaderText = "Controlada";

            dgvCajas.Columns["importe_total"].Visible = true;
            dgvCajas.Columns["importe_total"].HeaderText = "Importe total";
            dgvCajas.Columns["importe_total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCajas.Columns["importe_total"].DefaultCellStyle.Format = "c2";
        }
        #endregion

        public frmCajasCerradas()
        {
            InitializeComponent();
        }

        private void frmCajasCerrdas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            comenzarCarga();

            //if (dtpDesde.Value <= dtpHasta.Value)
            //{
            //    dv = dtCajasCerradas.DefaultView;
            //    fechaDesde = dtpDesde.Value;
            //    fechaHasta = dtpHasta.Value;
            //    string fechaDesdeCorta = fechaDesde.ToShortDateString();
            //    string fechaHastaCorta = fechaHasta.ToShortDateString();
            //    dv.RowFilter = string.Format("fecha>=#{0}# and fecha<=#{1}#", fechaDesde.ToString("yyyy/MM/dd"), fechaHasta.ToString("yyyy/MM/dd"));
            //    asignarDatos();

            //}
            //else
            //{
            //    MessageBox.Show("La fecha desde no puede ser posterior a la fecha hasta", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    dtpDesde.Focus();
            //}
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            Tools tools = new Tools();
            tools.ExportToExcel(dgvCajas, "Informe Cajas Cerradas");

        }

    }
}
