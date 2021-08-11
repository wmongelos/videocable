using CapaNegocios;
using CapaPresentacion.Impresiones;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Partes_Trabajo
{
    public partial class frmPartesImpresion : Form
    {
        DataTable dtPartes = new DataTable();
        private DataTable dtEstados = new DataTable();
        DateTime fechaDesde, fechaHasta;
        Partes.Tipo_Fecha oTipoFecha;
        Thread hilo;
        Partes oPartes = new Partes();
        private delegate void myDel();
        private bool Seleccionados = false;
        Impresion oImpresiones = new Impresion();
        private int idServiciosTipos = 0;
        Tools oTools = new Tools();
        DataView dtvPartes;
        private String Impresora;

        private Thread hiloPrint;
        private delegate void myDelPrint();

        private void ComenzarCarga()
        {
            idServiciosTipos = Convert.ToInt16(cboTipoServicio.SelectedValue);
            pgCircular.Start();
            hilo = new Thread(new ThreadStart(CargarDatos));
            hilo.IsBackground = true;
            hilo.Start();
        }

        private void CargarDatos()
        {
            try
            {
                dtPartes = oPartes.ListarPorRangoDeFechas(fechaDesde, fechaHasta, oTipoFecha, idServiciosTipos);
                myDel MD = new myDel(AsignarDatos);
                this.Invoke(MD, new object[] { });
            }
            catch
            {
                //throw;
                MessageBox.Show("Error al cargar información.");
            }
            pgCircular.Stop();
        }

        private void AsignarDatos()
        {


            dtvPartes = new DataView(dtPartes);

            if (dtPartes.Rows.Count > 0)
            {
                if (Convert.ToInt32(cboEstado.SelectedValue) == 0)
                    dtvPartes.RowFilter = String.Format("impreso = 0 and id_partes_operaciones='{0}' and id_partes_estados>0", Convert.ToInt16(cboTipoOperacion.SelectedValue));
                else
                    dtvPartes.RowFilter = String.Format("impreso = 0 and id_partes_operaciones='{0}'  and id_partes_estados='{1}'", Convert.ToInt16(cboTipoOperacion.SelectedValue), Convert.ToInt32(cboEstado.SelectedValue));

            }


            DataColumn colSeleccion = new DataColumn("colSeleccion", typeof(bool));
            colSeleccion.DefaultValue = false;

            dtPartes.Columns.Add(colSeleccion);

            dgvPartes.DataSource = dtvPartes;
            for (int x = 0; x < dgvPartes.Columns.Count; x++)
                dgvPartes.Columns[x].Visible = false;

            dgvPartes.Columns["id"].Visible = true;
            dgvPartes.Columns["id"].DisplayIndex = 0;

            dgvPartes.Columns["solicitud"].Visible = true;
            dgvPartes.Columns["solicitud"].DisplayIndex = 8;

            dgvPartes.Columns["codigo_usuario"].Visible = true;
            dgvPartes.Columns["codigo_usuario"].DisplayIndex = 1;

            dgvPartes.Columns["usuario"].Visible = true;
            dgvPartes.Columns["usuario"].DisplayIndex = 2;

            dgvPartes.Columns["servicio"].Visible = false;
            dgvPartes.Columns["servicio"].DisplayIndex = 6;

            dgvPartes.Columns["calle"].Visible = true;
            dgvPartes.Columns["calle"].DisplayIndex = 4;

            dgvPartes.Columns["altura"].Visible = true;
            dgvPartes.Columns["altura"].DisplayIndex = 5;

            dgvPartes.Columns["localidad"].Visible = true;
            dgvPartes.Columns["localidad"].DisplayIndex = 3;

            dgvPartes.Columns["operador"].Visible = true;
            dgvPartes.Columns["operador"].DisplayIndex = 7;

            dgvPartes.Columns["fecha_reclamo"].Visible = true;
            dgvPartes.Columns["fecha_reclamo"].DisplayIndex = 8;

            dgvPartes.Columns["fecha_programado"].Visible = true;
            dgvPartes.Columns["fecha_programado"].DisplayIndex = 8;

            dgvPartes.Columns["estado"].Visible = true;
            dgvPartes.Columns["estado"].DisplayIndex = 9;

            dgvPartes.Columns["colSeleccion"].Visible = true;

            dgvPartes.Columns["codigo_usuario"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPartes.Columns["id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPartes.Columns["altura"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPartes.Columns["solicitud"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPartes.Columns["localidad"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPartes.Columns["servicio"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPartes.Columns["operador"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPartes.Columns["fecha_reclamo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPartes.Columns["fecha_programado"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dgvPartes.Columns["id"].HeaderText = "Parte";
            dgvPartes.Columns["solicitud"].HeaderText = "Solicitud";
            dgvPartes.Columns["codigo_usuario"].HeaderText = "Cód. Usuario";
            dgvPartes.Columns["usuario"].HeaderText = "Usuario";
            dgvPartes.Columns["servicio"].HeaderText = "Servicio";
            dgvPartes.Columns["calle"].HeaderText = "Calle";
            dgvPartes.Columns["altura"].HeaderText = "Altura";
            dgvPartes.Columns["localidad"].HeaderText = "Localidad";
            dgvPartes.Columns["operador"].HeaderText = "Personal";
            dgvPartes.Columns["colSeleccion"].HeaderText = "Imprimir";
            dgvPartes.Columns["fecha_reclamo"].HeaderText = "Reclamo";
            dgvPartes.Columns["fecha_programado"].HeaderText = "Programado para";


            dgvPartes.Columns["id"].ReadOnly = true;
            dgvPartes.Columns["solicitud"].ReadOnly = true;
            dgvPartes.Columns["codigo_usuario"].ReadOnly = true;
            dgvPartes.Columns["usuario"].ReadOnly = true;
            dgvPartes.Columns["servicio"].ReadOnly = true;
            dgvPartes.Columns["calle"].ReadOnly = true;
            dgvPartes.Columns["altura"].ReadOnly = true;
            dgvPartes.Columns["localidad"].ReadOnly = true;
            dgvPartes.Columns["operador"].ReadOnly = true;
            dgvPartes.Columns["fecha_reclamo"].ReadOnly = true;
            dgvPartes.Columns["fecha_programado"].ReadOnly = true;

            dgvPartes.Columns["colSeleccion"].ReadOnly = false;





            lblTotal.Text = String.Format("Total de Registros: {0}", dgvPartes.Rows.Count);


            try
            {
                dgvPartes.Rows[dgvPartes.Rows.Count - 1].Selected = true;
            }
            catch { }

        }

        private void BuscarPartes()
        {
            fechaDesde = dtpFechaDesde.Value;
            fechaHasta = dtpFechaHasta.Value;
            if (rbFechaReclamo.Checked == true)
                oTipoFecha = Partes.Tipo_Fecha.FECHA_RECLAMO;
            else if (rbFechaProgramado.Checked == true)
                oTipoFecha = Partes.Tipo_Fecha.FECHA_PROGRAMADO;
            else
                oTipoFecha = Partes.Tipo_Fecha.FECHA_REALIZADO;
            ComenzarCarga();
        }

        private void ImprimirPartes(String PrintName)
        {
            Impresora = PrintName;
            hilo = new Thread(new ThreadStart(ImpresionLote));
            hilo.IsBackground = true;
            hilo.Start();

            //int cantErrores = 0;
            //if (dgvPartes.Rows.Count > 0)
            //{
            //    string excepcion = "";
            //    foreach (DataGridViewRow fila in dgvPartes.Rows)
            //    {
            //        if (fila.Cells["colseleccion"].Value != DBNull.Value && (Convert.ToInt32(fila.Cells["colseleccion"].Value) == 1))
            //        {
            //            try
            //            {
            //                if (oImpresiones.ImprimirPartes(Convert.ToInt32(fila.Cells["id"].Value), Impresora) == false)
            //                    break;
            //            }
            //            catch (Exception c)
            //            {
            //                cantErrores++;
            //                excepcion = c.ToString();
            //            }
            //        }
            //    }
            //    if (cantErrores > 0)
            //        MessageBox.Show("Algunos partes no se imprimieron.: \n " + excepcion);
            //}

            
        }

        private void ImpresionLote()
        {
            int cantErrores = 0;
            if (dtvPartes.Table.Rows.Count > 0)
            {
                string excepcion = "";
                foreach (DataRow fila in dtvPartes.Table.Rows)
                {
                    if (fila["colseleccion"] != DBNull.Value && (Convert.ToInt32(fila["colseleccion"]) == 1))
                    {
                        try
                        {
                            if (oImpresiones.ImprimirPartes(Convert.ToInt32(fila["id"]), Impresora) == false)
                                break;
                        }
                        catch (Exception c)
                        {
                            cantErrores++;
                            excepcion = c.ToString();
                        }
                    }
                }
                if (cantErrores > 0)
                    MessageBox.Show("Algunos partes no se imprimieron.: \n " + excepcion);
                else
                {
                    myDel MD = new myDel(ComenzarCarga);
                    this.Invoke(MD, new object[] { });
                }
            }
        }

        private void ExportarAExcel()
        {
            if (dgvPartes.Rows.Count > 0)
            {
                dgvPartes.Columns["colSeleccion"].Visible = false;
                oTools.ExportToExcel(dgvPartes, "Partes consultados");
                dgvPartes.Columns["colSeleccion"].Visible = true;
            }
            else
                MessageBox.Show("No hay datos en la grilla.");
        }

        public frmPartesImpresion()
        {
            InitializeComponent();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPartesImpresion_Load(object sender, EventArgs e)
        {
            DataTable dtPartesOperaciones = new DataTable();
            dtPartesOperaciones = oPartes.ListarOperaciones();
            DataTable dtTiposServicios = Tablas.DataServicios_Tipos.Copy();
            dtTiposServicios.Rows.Add(0, "TODOS");
            cboTipoServicio.DataSource = dtTiposServicios;
            cboTipoServicio.DisplayMember = "nombre";
            cboTipoServicio.ValueMember = "id";
            cboTipoOperacion.DataSource = dtPartesOperaciones;
            cboTipoOperacion.DisplayMember = "nombre";
            cboTipoOperacion.ValueMember = "id";
            rbFechaReclamo.Checked = true;
            dgvPartes.ReadOnly = false;
            dtEstados.Columns.Clear();
            DataColumn dcId = new DataColumn("id", typeof(int));
            DataColumn dcNombreEst = new DataColumn("Estado", typeof(string));
            dtEstados.Columns.Add(dcId);
            dtEstados.Columns.Add(dcNombreEst);
            dtEstados.Rows.Add(5, "REALIZADO");
            dtEstados.Rows.Add(3, "ASIGNADO");
            dtEstados.Rows.Add(0, "TODOS");
            dtEstados.AcceptChanges();
            cboEstado.DataSource = dtEstados;
            cboEstado.ValueMember = "id";
            cboEstado.DisplayMember = "Estado";
            dtpFechaDesde.Value = DateTime.Now.Date;

        }

        private void rbFechaReclamo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFechaReclamo.Checked)
                rbFechaProgramado.Checked = false;
            else
                rbFechaProgramado.Checked = true;
        }

        private void rbFechaProgramado_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFechaProgramado.Checked)
                rbFechaReclamo.Checked = false;
            else
                rbFechaReclamo.Checked = true;
        }

        private void btnSeleccionarTodos_Click(object sender, EventArgs e)
        {
            if (dgvPartes.Rows.Count > 0)
            {
                if (Seleccionados)
                {
                    foreach (DataGridViewRow fila in dgvPartes.Rows)
                        fila.Cells["colseleccion"].Value = false;
                    btnSeleccionarTodos.Text = "Seleccionar todos";
                    Seleccionados = false;
                }
                else
                {
                    foreach (DataGridViewRow fila in dgvPartes.Rows)
                        fila.Cells["colseleccion"].Value = true;
                    btnSeleccionarTodos.Text = "Quitar selección";
                    Seleccionados = true;
                }
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (pdSelectPrinter.ShowDialog() == DialogResult.OK)
                ImprimirPartes(pdSelectPrinter.PrinterSettings.PrinterName.ToString());

        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                ExportarAExcel();
            }
            catch { MessageBox.Show("Controle que la librería Excel se encuentre instalada."); }
        }

        private void dtpFechaDesde_ValueChanged(object sender, EventArgs e)
        {
            dtpFechaHasta.MinDate = dtpFechaDesde.Value;
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtBuscar.Text != "")
                {
                    if (Convert.ToInt32(cboEstado.SelectedValue) == 0)
                        dtvPartes.RowFilter = String.Format("Localidad LIKE '%{0}%' and impreso = 0 and id_partes_operaciones='{1}' and id_partes_estados>0", txtBuscar.Text, Convert.ToInt16(cboTipoOperacion.SelectedValue));
                    else
                        dtvPartes.RowFilter = String.Format("Localidad LIKE '%{0}%' and impreso = 0 and id_partes_operaciones='{1}'  and id_partes_estados='{2}'", txtBuscar.Text, Convert.ToInt16(cboTipoOperacion.SelectedValue), Convert.ToInt32(cboEstado.SelectedValue));
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            BuscarPartes();
        }
    }
}//041119fede
