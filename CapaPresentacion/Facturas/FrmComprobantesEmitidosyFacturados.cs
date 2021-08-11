using CapaNegocios;
using CapaPresentacion.Herramientas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Facturas
{
    public partial class FrmComprobantesEmitidosyFacturados : Form
    {

        #region Declaraciones
        private Thread hilo;
        private delegate void myDel();
        private DataTable dt, dt2;
        Usuarios_CtaCte_Det oUsuDet = new Usuarios_CtaCte_Det();
        DateTime desde, hasta;
        Decimal ImporteTotal;
        Int32 FilasTotales;
        DataColumn col;
        private List<int> origenesSeleccionados = new List<int>();
        #endregion

        public FrmComprobantesEmitidosyFacturados()
        {
            InitializeComponent();
            dtpDesde.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpHasta.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
            origenesSeleccionados.AddRange(new Usuarios_CtaCte().ListarCuentaCorrienteOrigenes().AsEnumerable().Select(dr => dr.Field<int>("id")));
        }

        #region METODOS
        private void comenzarCarga()
        {
            pgCircular.Start();

            dgv.DataSource = null;

            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
        }

        private void cargarDatos()
        {
            try
            {
                dt = oUsuDet.ListarComprobantesEmitidosYFacturas(desde, hasta, origenesSeleccionados);

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
            this.Cursor = Cursors.WaitCursor;
            LlenarDtFinal();
            dgv.DataSource = dt;

            CalcularImporteYFilasTotales();

            foreach (DataGridViewColumn col in dgv.Columns)
            {
                col.Visible = false;
            }

            dgv.Columns["Servicio"].Visible = true;
            dgv.Columns["Importe_Final"].DefaultCellStyle.Format = "c2";
            dgv.Columns["Importe_Final"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["Importe_Final"].Visible = true;
            dgv.Columns["Importe_Final"].HeaderText = "Subtotal";
            dgv.Columns["CantidadServicios"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["CantidadServicios"].Visible = true;
            dgv.Columns["CantidadServicios"].HeaderText = "Cantidad de servicios";
            dgv.Columns["CantUsu"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["CantUsu"].Visible = true;
            dgv.Columns["CantUsu"].HeaderText = "Cantidad de usuarios";

            decimal total = dt.AsEnumerable().Sum<DataRow>((dr) => dr.Field<decimal>("Importe_Final"));

            lblTotal.Text = $"Total de Registros: {FilasTotales}";
            lblImporteTotal.Text = $"Total: {total.ToString("c2")}";
            this.Cursor = Cursors.Default;
        }
        private void LlenarDtFinal()
        {
            col = new DataColumn();
            col.DataType = Type.GetType("System.Int32");
            col.ColumnName = "cantUsu";
            dt.Columns.Add(col);
            foreach (DataRow dr in dt.Rows)
            {
                int id_servicio = Convert.ToInt32(dr["id_serv"].ToString());
                dt2 = oUsuDet.ListarCantidadUsuariosComprobantesEmitidosFacturados(id_servicio, desde, hasta);
                dr["cantUsu"] = Convert.ToInt32(dt2.Rows[0]["CantUsu"].ToString());
                dt2.Clear();
            }
        }
        private void CalcularImporteYFilasTotales()
        {
            ImporteTotal = 0;
            FilasTotales = 0;
            if (dgv.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.Visible)
                    {
                        //ImporteTotal += Convert.ToDecimal(row.Cells["Importe_Total"].Value);
                        FilasTotales++;
                    }
                }
            }
        }

        private void seleccionarOrigen()
        {
            using (frmPopUp popUp = new frmPopUp())
            {
                frmSeleccionValores frmSelec = new frmSeleccionValores("Origenes", new Usuarios_CtaCte().ListarCuentaCorrienteOrigenes(), "Id", "Descripcion");
                frmSelec.valoresSeleccionados = origenesSeleccionados;
                frmSelec.SeleccionarAlMenosUno = true;
                popUp.Formulario = frmSelec;
                popUp.Maximizar = false;
                if (popUp.ShowDialog() == DialogResult.OK)
                {
                    origenesSeleccionados = frmSelec.valoresSeleccionados;
                }
            }
        }

        private void btnSelecOrigen_Click(object sender, EventArgs e)
        {
            seleccionarOrigen();
        }
        #endregion


        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 0)
            {
                Tools tools = new Tools();
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    tools.ExportDataTableToExcel(dt, "Servicios generados", this);
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al exportar a excel");
                }
                finally { this.Cursor = Cursors.Default; }
            }
            else
                MessageBox.Show("Grilla vacia");
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            desde = dtpDesde.Value;
            hasta = dtpHasta.Value;
            comenzarCarga();
        }
    }
}
