using CapaNegocios;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Informes
{
    public partial class FrmInformeCompleto : Form
    {
        private Thread hilo;
        private delegate void myDel();
        private DataTable dtDatos = new DataTable();
        private Usuarios_CtaCte_Det.TIPO_LISTAR tipoBusqueda;
        private DateTime fechaBusqueda = default(DateTime);
        private int peridoFacturacionBusqueda = 0;

        public FrmInformeCompleto()
        {
            InitializeComponent();
        }

        private void FrmInformeCompleto_Load(object sender, EventArgs e)
        {
            CargarDatos();
            dtpFechaInicioServ.Enabled = false;
            dtpFechaMov.Enabled = false;
        }

        private void CargarDatos()
        {
            cboHistorialFacturacion.DataSource = new Facturacion_Mensual_Historial().ListarHistorial();
            cboHistorialFacturacion.ValueMember = "id";
            cboHistorialFacturacion.DisplayMember = "periodo";
            cboHistorialFacturacion.SelectedIndex = cboHistorialFacturacion.Items.Count - 1;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            pgCircular.Start();

            dgv.DataSource = null;

            if (rbPeriodo.Checked)
            {
                tipoBusqueda = Usuarios_CtaCte_Det.TIPO_LISTAR.PERIODO;
                peridoFacturacionBusqueda = (int)cboHistorialFacturacion.SelectedValue;
            }
            else if (rbFechaMov.Checked)
            {
                tipoBusqueda = Usuarios_CtaCte_Det.TIPO_LISTAR.FECHA_MOVIMIENTO;
                fechaBusqueda = dtpFechaMov.Value.Date;
            }
            else
            {
                tipoBusqueda = Usuarios_CtaCte_Det.TIPO_LISTAR.FECHA_INICIO_SERVICIO;
                fechaBusqueda = dtpFechaInicioServ.Value.Date;
            }

            hilo = new Thread(new ThreadStart(TraerDatos));
            hilo.Start();
        }

        private void TraerDatos()
        {
            try
            {
                dtDatos = new Usuarios_CtaCte_Det().ListaCompletaDeServicios(tipoBusqueda, peridoFacturacionBusqueda, fechaBusqueda);

                myDel MD = new myDel(AsignarDatos);

                this.Invoke(MD, new object[] { });

                pgCircular.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Informacion" + ex.Message);
            }
        }

        private void AsignarDatos()
        {
            dgv.DataSource = dtDatos;

            foreach (DataGridViewColumn col in dgv.Columns)
            {
                col.Visible = false;
            }

            dgv.Columns["codigo_usuarios"].Visible = true;
            dgv.Columns["codigo_usuarios"].HeaderText = "Codigo";

            dgv.Columns["nombre_usuario"].Visible = true;
            dgv.Columns["nombre_usuario"].HeaderText = "Nombre";

            dgv.Columns["descripcion"].Visible = true;
            dgv.Columns["descripcion"].HeaderText = "Comprobante";

            dgv.Columns["importe_original"].Visible = true;
            dgv.Columns["importe_original"].HeaderText = "Importe original";
            dgv.Columns["importe_original"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgv.Columns["importe_punitorio"].Visible = true;
            dgv.Columns["importe_punitorio"].HeaderText = "Importe punitorio";
            dgv.Columns["importe_punitorio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgv.Columns["importe_saldo"].Visible = true;
            dgv.Columns["importe_saldo"].HeaderText = "Importe saldo";
            dgv.Columns["importe_saldo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgv.Columns["importe_bonificacion"].Visible = true;
            dgv.Columns["importe_bonificacion"].HeaderText = "Importe bonificacion";
            dgv.Columns["importe_bonificacion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgv.Columns["importe_pago"].Visible = true;
            dgv.Columns["importe_pago"].HeaderText = "Importe pago";
            dgv.Columns["importe_pago"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgv.Columns["importe_provincial"].Visible = true;
            dgv.Columns["importe_provincial"].HeaderText = "Importe provincial";
            dgv.Columns["importe_provincial"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            lblTotal.Text = $"Total de registros: {dtDatos.Rows.Count}";

            if (dtDatos.Rows.Count > 0)
            {
                EstadoControles(true);
            }
        }

        private void EstadoControles(bool estado)
        {
            lblFiltros.Enabled = estado;
            gbUniverso.Enabled = estado;
            btnFiltrar.Enabled = estado;
            btnExportar.Enabled = estado;
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            string filtro = "";

            //Presentacion
            if (rbUniverso.Checked)
                filtro += "presentacion = 1";
            else if (rbEspeciales.Checked)
                filtro += "presentacion = 0";

            dtDatos.DefaultView.RowFilter = filtro;
            lblTotal.Text = $"Total de registros: {dtDatos.DefaultView.ToTable().Rows.Count}";
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            Tools tools = new Tools();
            try
            {
                tools.ExportDataTableToExcel(dtDatos.DefaultView.ToTable(), "informe", this);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error el exportar a excel: {ex.Message}");
            }
        }

        private void rbConsulta_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb.Checked)
            {
                if (rb.Name == rbPeriodo.Name)
                {
                    dtpFechaMov.Enabled = false;
                    dtpFechaInicioServ.Enabled = false;
                    cboHistorialFacturacion.Enabled = true;
                }
                else if (rb.Name == rbFechaInicioServ.Name)
                {
                    dtpFechaMov.Enabled = false;
                    dtpFechaInicioServ.Enabled = true;
                    cboHistorialFacturacion.Enabled = false;
                }
                else if (rb.Name == rbFechaMov.Name)
                {
                    dtpFechaMov.Enabled = true;
                    dtpFechaInicioServ.Enabled = false;
                    cboHistorialFacturacion.Enabled = false;
                }
            }
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmInformeCompleto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

    }
}
