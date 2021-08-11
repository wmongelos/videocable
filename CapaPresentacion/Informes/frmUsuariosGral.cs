using CapaNegocios;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmUsuariosGral : Form
    {
        #region PROPIEDADES
        private DataTable Data = new DataTable();
        private DataTable DataServiciosGrupos = new DataTable();
        private DataTable DataServiciosTipos = new DataTable();
        private DataTable DataServiciosEstados = new DataTable();
        private DataTable DataZonas = new DataTable();

        private Boolean Detallado = false;

        private Usuarios_Servicios usuarios_Servicios = new Usuarios_Servicios();

        private Int32 IdServiciosGrupos, IdServiciosTipos, IdServiciosEstados, IdZonas;

        private Thread hilo;
        private delegate void myDel();
        #endregion

        #region MÉTODOS
        private void comenzarCarga()
        {
            pgCircular.Start();

            dgvDatos.DataSource = null;

            IdServiciosGrupos = Convert.ToInt32(cboServicios_Grupos.SelectedValue);
            IdServiciosTipos = Convert.ToInt32(cboServicios_Tipos.SelectedValue);
            IdServiciosEstados = Convert.ToInt32(cboServicios_Estados.SelectedValue);
            IdZonas = Convert.ToInt32(cboZonas.SelectedValue);

            Detallado = chkDetalle.CheckState == CheckState.Checked ? true : false;

            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.IsBackground = true;
            hilo.Start();
            btnConsultar.Enabled = false;
            btnExportar.Enabled = false;
        }

        private void inicioCarga()
        {
            pgCircular.Start();

            hilo = new Thread(new ThreadStart(cargarCombos));
            hilo.IsBackground = true;
            hilo.Start();
        }

        private void cargarCombos()
        {
            Servicios oServicios = new Servicios();
            Servicios_Tipos oServicios_Tipos = new Servicios_Tipos();
            Zonas oZonas = new Zonas();

            DataServiciosGrupos = oServicios.ListarGrupos();
            DataServiciosGrupos.Rows.Add(0, "TODOS");
            DataServiciosGrupos.DefaultView.Sort = "Id asc";
            DataServiciosGrupos = DataServiciosGrupos.DefaultView.ToTable(true);

            DataServiciosTipos = oServicios_Tipos.Listar();
            DataServiciosTipos.Rows.Add(0, "TODOS", "TODOS", 0, 0);
            DataServiciosTipos.DefaultView.Sort = "Id asc";
            DataServiciosTipos = DataServiciosTipos.DefaultView.ToTable(true);

            DataServiciosEstados = oServicios.ListarEstados();
            DataServiciosEstados.Rows.Add(0, "TODOS", 0, 0, 0);
            DataServiciosEstados.DefaultView.Sort = "Id asc";
            DataServiciosEstados = DataServiciosEstados.DefaultView.ToTable(true);

            DataZonas = oZonas.Listar();
            DataZonas.Rows.Add(0, "TODAS", 0);
            DataZonas.DefaultView.Sort = "Id asc";
            DataZonas = DataZonas.DefaultView.ToTable(true);

            myDel MD = new myDel(asignarCombos);
            this.Invoke(MD, new object[] { });
            pgCircular.Stop();
        }

        private void cargarDatos()
        {
            Data = usuarios_Servicios.ListarUsuariosGral(IdServiciosGrupos, IdServiciosTipos, IdServiciosEstados, IdZonas, Detallado);

            myDel MD = new myDel(asignarDatos);
            this.Invoke(MD, new object[] { });
            pgCircular.Stop();
        }

        private void asignarDatos()
        {
            dgvDatos.DataSource = Data;

            foreach (DataGridViewColumn col in dgvDatos.Columns)
            {
                col.Visible = false;
            }

            if (!chkDetalle.Checked)
            {
                dgvDatos.Columns["codigo"].Visible = true;
                dgvDatos.Columns["abonado"].Visible = true;

                dgvDatos.Columns["codigo"].HeaderText = "Codigo";
                dgvDatos.Columns["abonado"].HeaderText = "Abonado";
            }
            else
            {
                dgvDatos.Columns["codigo"].Visible = true;
                dgvDatos.Columns["abonado"].Visible = true;
                dgvDatos.Columns["calle"].Visible = true;
                dgvDatos.Columns["altura"].Visible = true;
                dgvDatos.Columns["piso"].Visible = true;
                dgvDatos.Columns["zona"].Visible = true;
                dgvDatos.Columns["localidad"].Visible = true;
                dgvDatos.Columns["servicio"].Visible = true;
                dgvDatos.Columns["categoria"].Visible = true;
                dgvDatos.Columns["estado"].Visible = true;
                dgvDatos.Columns["fecha_factura"].Visible = true;

                dgvDatos.Columns["codigo"].HeaderText = "Codigo";
                dgvDatos.Columns["abonado"].HeaderText = "Abonado";
                dgvDatos.Columns["calle"].HeaderText = "Calle";
                dgvDatos.Columns["altura"].HeaderText = "Altura";
                dgvDatos.Columns["piso"].HeaderText = "Piso";
                dgvDatos.Columns["zona"].HeaderText = "Zona";
                dgvDatos.Columns["localidad"].HeaderText = "Localidad";
                dgvDatos.Columns["servicio"].HeaderText = "Sevicio";
                dgvDatos.Columns["categoria"].HeaderText = "Categoria";
                dgvDatos.Columns["estado"].HeaderText = "Estado";
                dgvDatos.Columns["fecha_factura"].HeaderText = "Fecha factura";
            }

            lblTotal.Text = String.Format("Total de Registros: {0}", Data.Rows.Count);
            btnConsultar.Enabled = true;
            btnExportar.Enabled = true;
        }

        private void asignarCombos()
        {
            cboServicios_Grupos.DataSource = DataServiciosGrupos;
            cboServicios_Grupos.DisplayMember = "Nombre";
            cboServicios_Grupos.ValueMember = "Id";

            cboServicios_Tipos.DataSource = DataServiciosTipos;
            cboServicios_Tipos.DisplayMember = "Nombre";
            cboServicios_Tipos.ValueMember = "Id";

            cboServicios_Estados.DataSource = DataServiciosEstados;
            cboServicios_Estados.DisplayMember = "Estado";
            cboServicios_Estados.ValueMember = "Id";

            cboZonas.DataSource = DataZonas;
            cboZonas.DisplayMember = "Nombre";
            cboZonas.ValueMember = "Id";

        }
        #endregion

        public frmUsuariosGral()
        {
            InitializeComponent();
        }

        private void frmUsuariosGral_Load(object sender, EventArgs e)
        {
            this.cargarCombos();
        }

        private void frmUsuariosGral_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.Rows.Count > 0)
            {
                Tools tools = new Tools();
                tools.ExportDataTableToExcel(Data, "Usuarios", this);
                MessageBox.Show("Exportado correctamente", "Mensaje del sistema");
            }
            else
                MessageBox.Show("Grilla vacia.");

        }

        private void chkDetalle_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            this.comenzarCarga();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (chkDetalle.CheckState == CheckState.Checked)
                Data.DefaultView.RowFilter = String.Format("Convert(codigo, 'System.String') LIKE '%{0}%' or abonado LIKE '%{0}%' or calle LIKE '%{0}%' or zona LIKE '%{0}%' or localidad LIKE '%{0}%' or servicio LIKE '%{0}%' or categoria LIKE '%{0}%' or estado LIKE '%{0}%'", txtBuscar.Text);
            else
                Data.DefaultView.RowFilter = String.Format("Convert(codigo, 'System.String') LIKE '%{0}%' or abonado LIKE '%{0}%'", txtBuscar.Text);

            lblTotal.Text = String.Format("Total de Registros: {0}", dgvDatos.Rows.Count);
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
