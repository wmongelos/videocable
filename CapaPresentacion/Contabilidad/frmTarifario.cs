using CapaNegocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Contabilidad
{
    public partial class frmTarifario : Form
    {
        private Thread hilo;
        private delegate void myDel();
        private DataTable DataTarifas;
        private DataTable DataSolicitudes;
        private DataTable DataEquipamientos;
        private DataTable DataTipoFacturacion;

        private readonly Tarifas Tarifas = new Tarifas();
        private readonly Partes_Solicitudes Partes_Solicitudes = new Partes_Solicitudes();
        private readonly Equipos_Tipos Equipos_Tipos = new Equipos_Tipos();
        private readonly Configuracion Config = new Configuracion();

        private Int32 IdTipoFacturacion;
        private Int32 IdServiciosModalidad;

        public frmTarifario()
        {
            InitializeComponent();

            WindowState = FormWindowState.Maximized;
        }

        private void comenzarCarga()
        {
            pgCircular.Start();

            dgvServicios.DataSource = null;
            dgvSolicitudes.DataSource = null;
            dgvEquipamientos.DataSource = null;

            IdServiciosModalidad = Convert.ToInt32(cboModalidades.SelectedValue);
            IdTipoFacturacion = Convert.ToInt32(cboTipoFacturacion.SelectedValue);

            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.IsBackground = true;
            hilo.Start();
        }

        private void cargarDatos()
        {
            DataTarifas = Tarifas.GetData(IdTipoFacturacion, IdServiciosModalidad);

            DataSolicitudes = Partes_Solicitudes.GetSolicitudesConCargo();
            DataColumn ColImporte = new DataColumn("Importe", typeof(Decimal));
            ColImporte.DefaultValue = 0;
            DataSolicitudes.Columns.Add(ColImporte);

            DataEquipamientos = Equipos_Tipos.ListarPorTipoServicios(0);

            myDel MD = new myDel(asignarDatos);

            this.Invoke(MD, new object[] { });

            pgCircular.Stop();

        }

        private void asignarDatos()
        {
            dgvServicios.DataSource = DataTarifas;

            for (int i = 0; i < dgvServicios.ColumnCount; i++)
                dgvServicios.Columns[i].Visible = false;

            dgvServicios.Columns["Descripcion"].Visible = true;
            dgvServicios.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvServicios.Columns["Importe"].Visible = true;
            dgvServicios.Columns["Importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvServicios.Columns["Importe"].DefaultCellStyle.Format = "0.00";




            dgvSolicitudes.DataSource = DataSolicitudes;
            dgvSolicitudes.ReadOnly = false;

            for (int i = 0; i < dgvSolicitudes.ColumnCount; i++)
                dgvSolicitudes.Columns[i].Visible = false;

            dgvSolicitudes.Columns["Nombre"].Visible = true;

            dgvSolicitudes.Columns["Importe"].Visible = true;
            dgvSolicitudes.Columns["Importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvSolicitudes.Columns["Importe"].DefaultCellStyle.Format = "0.00";
            dgvSolicitudes.Columns["Nombre"].ReadOnly = true;

            dgvEquipamientos.DataSource = DataEquipamientos;
        }

        private void frmTarifario_Load(object sender, EventArgs e)
        {
            DataView dataView = Tablas.DataTiposFacturacion.DefaultView;
            dataView.Sort = Config.GetValor_N("Id_Tipo_Facturacion") == (Int32)Tipo_Facturacion.Id_Tipo_Facturacion.POR_ZONAS ? "Nombre ASC" : "Codigo ASC";
            DataTipoFacturacion = dataView.ToTable(true);

            cboTipoFacturacion.DataSource = DataTipoFacturacion;
            cboTipoFacturacion.DisplayMember = "Nombre";
            cboTipoFacturacion.ValueMember = "Id";

            cboModalidades.DataSource = Tablas.DataServicios_Modalidades;
            cboModalidades.DisplayMember = "Nombre";
            cboModalidades.ValueMember = "Id";
        }

        private void dgvServicios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if(dgvServicios.Columns[e.ColumnIndex].Name == "Descripcion")
            {
                if (DataTarifas.Rows[e.RowIndex]["Id_Servicios_Sub"].ToString() == "0")
                {
                    dgvServicios.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                    dgvServicios.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                    dgvServicios.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("Tahoma", 10, FontStyle.Bold);
                }
            }

            if (dgvServicios.Columns[e.ColumnIndex].Name == "Importe")
            {
                if (DataTarifas.Rows[e.RowIndex]["Id_Servicios_Sub"].ToString() == "0")
                {
                    dgvServicios.Rows[e.RowIndex].Cells["importe"].Style.ForeColor = Color.Transparent;
                    dgvServicios.Rows[e.RowIndex].Cells["importe"].Style.SelectionForeColor = Color.Transparent;
                }
            }
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTarifario_KeyDown(object sender, KeyEventArgs e)
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
