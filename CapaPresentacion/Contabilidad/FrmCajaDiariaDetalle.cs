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
    public partial class FrmCajaDiariaDetalle : Form
    {
        public FrmCajaDiariaDetalle()
        {
            InitializeComponent();
        }

        #region Declaraciones
        private Thread hilo;
        private delegate void myDel();
        public DataTable dtDetalle;
        public int Filtro;
        Decimal ImporteTotalDiaria;
        Int32 FilasTotalesDiaria;
        #endregion


        #region Metodos
        private void comenzarCarga()
        {
            dgv.DataSource = null;
            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
        }

        private void cargarDatos()
        {
            try
            {
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
            dgv.DataSource = dtDetalle;

            for (int i = 0; i < dgv.ColumnCount; i++)
                dgv.Columns[i].Visible = false;

            if (Filtro == 1)
            {
                dgv.Columns["Servicio"].Visible = true;
                dgv.Columns["Importe"].Visible = true;

                dgv.Columns["Servicio"].HeaderText = "Servicio";
                dgv.Columns["importe"].HeaderText = "Importe";

                dgv.Columns["Importe"].DefaultCellStyle.Format = "C2";
                dgv.Columns["Importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv.Columns["Importe"].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("en-US");
                lblTituloHeader.Text = "Detalle de caja diaria Facturado por Servicio";
            }
            else if(Filtro == 2)
            {
                dgv.Columns["formapago"].Visible = true;
                dgv.Columns["Importe"].Visible = true;

                dgv.Columns["formapago"].HeaderText = "Forma de Pago";
                dgv.Columns["importe"].HeaderText = "Importe";

                dgv.Columns["Importe"].DefaultCellStyle.Format = "C2";
                dgv.Columns["Importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv.Columns["Importe"].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("en-US");
                lblTituloHeader.Text = "Detalle de caja diaria Facturado por Forma de Pago";
            }
            else 
            {
                dgv.Columns["FechaRecibo"].Visible = true;
                dgv.Columns["Importe"].Visible = true;
                dgv.Columns["ImportePago"].Visible = true;
                dgv.Columns["Usuario"].Visible = true;
                dgv.Columns["Recibo"].Visible = true;

                dgv.Columns["importe"].HeaderText = "Importe";
                dgv.Columns["FechaRecibo"].HeaderText = "Fecha";
                dgv.Columns["ImportePago"].HeaderText = "Importe Pago";
                dgv.Columns["Usuario"].HeaderText = "Usuario";
                dgv.Columns["Recibo"].HeaderText = "Recibo";

                dgv.Columns["Importe"].DefaultCellStyle.Format = "C2";
                dgv.Columns["Importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv.Columns["Importe"].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("en-US");
                dgv.Columns["ImportePago"].DefaultCellStyle.Format = "C2";
                dgv.Columns["ImportePago"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv.Columns["ImportePago"].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("en-US");

                lblTituloHeader.Text = "Recibos detallados de la Caja Diaria.";
            }
            if (dgv.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.Visible)
                    {
                        ImporteTotalDiaria += Convert.ToDecimal(row.Cells["Importe"].Value);
                        FilasTotalesDiaria++;
                    }
                }
            }
            lblRegistroDiaria.Text = String.Format("Total de Registros: {0}", FilasTotalesDiaria);
            lblImporteDiaria.Text = String.Format("Total: $ {0}", ImporteTotalDiaria);
        }
        #endregion

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmCajaDiariaDetalle_Load(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 0)
            {
                Tools tools = new Tools();
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    tools.ExportDataTableToExcel(dtDetalle, "Detalle Caja Diaria");
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
    }
}
