using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using CapaNegocios;
using System.Globalization;

namespace CapaPresentacion.Contabilidad
{
    public partial class FrmCajaGeneralDetalle : Form
    {
        public FrmCajaGeneralDetalle()
        {
            InitializeComponent();
        }
        #region Declaraciones
        private Thread hilo;
        private delegate void myDel();
        public DataTable dtDetalle;
        public int Filtro;
        Decimal ImporteTotalGeneral;
        Int32 FilasTotalesGeneral;
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

            if(Filtro == 1) 
            { 
                dgv.Columns["Servicio"].Visible = true;
                dgv.Columns["Importe"].Visible = true;

                dgv.Columns["Servicio"].HeaderText = "Servicio";
                dgv.Columns["importe"].HeaderText = "Importe";

                dgv.Columns["Importe"].DefaultCellStyle.Format = "C2";
                dgv.Columns["Importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv.Columns["Importe"].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("en-US");
                lblTituloHeader.Text = "Detalle de caja general Facturado por Servicio";
            }
            else 
            {
                dgv.Columns["formapago"].Visible = true;
                dgv.Columns["Importe"].Visible = true;

                dgv.Columns["formapago"].HeaderText = "Forma de Pago";
                dgv.Columns["importe"].HeaderText = "Importe";

                dgv.Columns["Importe"].DefaultCellStyle.Format = "C2";
                dgv.Columns["Importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv.Columns["Importe"].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("en-US");
                lblTituloHeader.Text = "Detalle de caja general Facturado por Forma de Pago";
            }
            if (dgv.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.Visible)
                    {
                        ImporteTotalGeneral += Convert.ToDecimal(row.Cells["Importe"].Value);
                        FilasTotalesGeneral++;
                    }
                }
            }
            lblRegistrosGeneral.Text = String.Format("Total de Registros: {0}", FilasTotalesGeneral);
            lblImporteGeneral.Text = String.Format("Total: $ {0}", ImporteTotalGeneral);
        }
        #endregion


        #region Eventos
        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void FrmCajaGeneralDetalle_Load(object sender, EventArgs e)
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
                    tools.ExportDataTableToExcel(dtDetalle, "Detalle Caja General");
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
