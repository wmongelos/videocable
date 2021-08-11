using CapaNegocios;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Informes
{
    public partial class frmHistorialCobros : Form
    {
        private Thread hilo;
        private delegate void myDel();
        private DataTable dtServiciosTipos, dtCobros;
        Usuarios_CtaCte_Recibos oUsuRecibo = new Usuarios_CtaCte_Recibos();
        Servicios_Tipos oServicios_Tipos = new Servicios_Tipos();
        int TotalRegistros;
        decimal cuenta_1, cuenta_2;
        public frmHistorialCobros()
        {
            InitializeComponent();

            dtpDesde.Value = DateTime.Today;
            dtpHasta.Value = DateTime.Today;
        }

        private void comenzarCarga()
        {
            cuenta_1 = 0;
            cuenta_1 = 0;
            SetTotales();

            btnBuscar.Enabled = false;
            pgCircular.Visible = true;
            pgCircular.Start();
            dgv.DataSource = null;
            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
        }

        private void cargarDatos()
        {
            try
            {
                dtServiciosTipos = oServicios_Tipos.Listar();
                DataColumn dc1 = new DataColumn()
                {
                    ColumnName = "Cuenta_1",
                    DataType = typeof(Decimal),
                    DefaultValue = 0
                }; dtServiciosTipos.Columns.Add(dc1);
                DataColumn dc2 = new DataColumn()
                {
                    ColumnName = "Cuenta_2",
                    DataType = typeof(Decimal),
                    DefaultValue = 0
                }; dtServiciosTipos.Columns.Add(dc2);
                DataColumn dct = new DataColumn()
                {
                    ColumnName = "Total",
                    DataType = typeof(Decimal),
                    DefaultValue = 0
                }; dtServiciosTipos.Columns.Add(dct);
                dtCobros = oUsuRecibo.ListarCuentas(Convert.ToDateTime(dtpDesde.Value), Convert.ToDateTime(dtpHasta.Value));

                foreach (DataRow drItem in dtServiciosTipos.Rows)
                {
                    int id_servicio_tipo = Convert.ToInt32(drItem["id"]);


                    DataRow[] drFilter = dtCobros.Select(string.Format("id = {0}", id_servicio_tipo));

                    if (drFilter.Length > 0)
                    {
                        for (int i = 0; i < drFilter.Length; i++)
                        {
                            if (Convert.ToInt32(drFilter[i]["cuenta"]) == 1)
                                drItem["Cuenta_1"] = drFilter[i]["importe"];
                            if (Convert.ToInt32(drFilter[i]["cuenta"]) == 2)
                                drItem["Cuenta_2"] = drFilter[i]["importe"];

                            drItem["Total"] = Convert.ToDecimal(drItem["Cuenta_1"].ToString()) + Convert.ToDecimal(drItem["Cuenta_2"].ToString());
                        }
                    }

                }


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
            pgCircular.Stop();
            pgCircular.Visible = false;

            btnBuscar.Enabled = true;

            dgv.DataSource = dtServiciosTipos;

            for (int i = 0; i < dgv.ColumnCount; i++)
                dgv.Columns[i].Visible = false;

            dgv.Columns["nombre"].Visible = true;
            dgv.Columns["grupo"].Visible = true;
            dgv.Columns["Cuenta_1"].Visible = true;
            dgv.Columns["Cuenta_2"].Visible = true;
            dgv.Columns["Total"].Visible = true;

            dgv.Columns["nombre"].HeaderText = "Servicio";
            dgv.Columns["grupo"].HeaderText = "Grupo";
            dgv.Columns["Cuenta_1"].HeaderText = "Cuenta 1";
            dgv.Columns["Cuenta_2"].HeaderText = "Cuenta 2";
            dgv.Columns["Total"].HeaderText = "Importe";
            dgv.Columns["Cuenta_1"].DefaultCellStyle.Format = "C2";
            dgv.Columns["Cuenta_1"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["Cuenta_2"].DefaultCellStyle.Format = "C2";
            dgv.Columns["Cuenta_2"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["Total"].DefaultCellStyle.Format = "C2";
            dgv.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            calculaRegistros();

            SetTotales();


        }

        private void SetTotales()
        {
            lblCuenta1.Text = string.Format("Cuenta 1: ${0}", cuenta_1.ToString());

            lblCuenta2.Text = string.Format("Cuenta 2: ${0}", cuenta_2.ToString());

            lblTotal.Text = String.Format("Total de Registros: {0}", TotalRegistros);
            decimal cuentaTotal = cuenta_1 + cuenta_2;
            lblTotalImporte.Text = string.Format("TOTAL:${0}", cuentaTotal.ToString());
        }

        private void calculaRegistros()
        {
            TotalRegistros = 0;
            if (dgv.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.Visible)
                    {
                        TotalRegistros += 1;
                        cuenta_1 = cuenta_1 + Convert.ToDecimal(row.Cells["Cuenta_1"].Value);
                        cuenta_2 = cuenta_2 + Convert.ToDecimal(row.Cells["Cuenta_2"].Value);
                    }
                }
            }
        }

        private void exportaExcel()
        {
            if (dgv.Rows.Count > 0)
            {
                Tools tools = new Tools();
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    tools.ExportToExcel(dgv, "Registro Cajas");
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al exportar a excel");
                }
                finally { this.Cursor = Cursors.Default; }
            }
            else
                MessageBox.Show("Grilla vacia", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            exportaExcel();
        }

        private void frmHistorialCobros_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            comenzarCarga();
        }
    }
}
