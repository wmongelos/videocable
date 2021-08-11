using CapaNegocios;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;
namespace CapaPresentacion
{
    public partial class frmCambioVelocidad : Form
    {
        public string Descripcion { set; get; }
        public int Cantidad { set; get; }
        public decimal precioUnitario { set; get; }
        public decimal Final { set; get; }
        public int idVelocidad { set; get; }
        public int idVelocidadTip { set; get; }
        public int idSubServicio { set; get; }
        public DateTime FechaDesde { set; get; }
        public decimal tarifaActual = 0;
        private delegate void myDel();
        private Thread hilo;

        //OBJETOS
        private Servicios_Velocidades oServiciosVelocidades = new Servicios_Velocidades();
        private Servicios_Tarifas oServiciosTarifas = new Servicios_Tarifas();
        private Servicios_Tarifas_Sub oServiciosTarifasSub = new Servicios_Tarifas_Sub();
        //INT
        private int idUsuarioServicio, idTarifaVigente, idTipoFacturacion, auxFlag = 0, idVelocidadActual = 0;
        //STRING
        private string nombreVelocidadActual;
        //DATATABLES
        private DataTable dataSubservicios = new DataTable();
        private DataTable dataTarifas = new DataTable();
        public DataTable dataMovimientos = new DataTable();

        private void ComenzarCarga()
        {
            hilo = new Thread(new ThreadStart(CargarDatos));
            hilo.Start();
        }

        private void frmCambioVelocidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void dgvMovimientos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionarDatos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void CargarDatos()
        {
            dataSubservicios = oServiciosVelocidades.ListarVelocidadesUsuarios(idUsuarioServicio);
            myDel MD = new myDel(AsignarDatos);
            this.Invoke(MD, new object[] { });
        }

        private void AsignarDatos()
        {
            nombreVelocidadActual = dataSubservicios.Rows[0]["velocidad"].ToString();
            idVelocidadActual = Convert.ToInt32(dataSubservicios.Rows[0]["id_servicios_velocidades"]);
            lblVelocidadActual.Text = nombreVelocidadActual + " MB";
            idSubServicio = Convert.ToInt32(dataSubservicios.Rows[0]["id_Servicios_sub"]);
            oServiciosTarifas.Fecha_Actual = FechaDesde;
            idTarifaVigente = oServiciosTarifas.getTarifa();
            idTipoFacturacion = Convert.ToInt32(dataSubservicios.Rows[0]["id_tipo_facturacion"]);
            idVelocidadTip = Convert.ToInt32(dataSubservicios.Rows[0]["id_servicios_velocidades_tip"]);
            dataTarifas = oServiciosTarifasSub.ListarTarifasVelocidades(idSubServicio, idTarifaVigente, idTipoFacturacion, idVelocidadTip);
            dgvMovimientos.DataSource = dataTarifas;
            auxFlag = 1;
            dgvMovimientos.Columns["id_servicio_velocidad_tip"].Visible = false;
            dgvMovimientos.Columns["id_servicios_velocidad"].Visible = false;

            dgvMovimientos.Columns["importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvMovimientos.Columns["importe"].DefaultCellStyle.Format = "c";
            dgvMovimientos.Columns["importe"].HeaderText = "Importe";
            dgvMovimientos.Columns["velocidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvMovimientos.Columns["velocidad"].HeaderText = "Velocidad";
            dgvMovimientos.Columns["servicio"].HeaderText = "Servicio";

            DataRow[] tarifas = dataTarifas.Select(string.Format("id_servicios_velocidad={0}", idVelocidadActual));
            tarifaActual = Convert.ToDecimal(tarifas[0]["importe"]);
            SeleccionarDatos();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void dgvMovimientos_SelectionChanged(object sender, EventArgs e)
        {
            SeleccionarDatos();
        }

        public frmCambioVelocidad(int id_usuario_servicio)
        {
            InitializeComponent();
            this.idUsuarioServicio = id_usuario_servicio;
            dataMovimientos.Columns.Add("Descripcion", typeof(String));
            dataMovimientos.Columns.Add("Unitario", typeof(decimal));
            dataMovimientos.Columns.Add("Cantidad", typeof(String));
            dataMovimientos.Columns.Add("Final", typeof(decimal));
        }

        private void frmCambioVelocidad_Load(object sender, EventArgs e)
        {
            ComenzarCarga();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SeleccionarDatos()
        {
            if (auxFlag == 1)
            {
                try
                {
                    idVelocidad = Convert.ToInt32(dgvMovimientos.SelectedRows[0].Cells["id_servicios_velocidad"].Value);
                    idVelocidadTip = Convert.ToInt32(dgvMovimientos.SelectedRows[0].Cells["id_servicio_velocidad_tip"].Value);
                    nombreVelocidadActual = dgvMovimientos.SelectedRows[0].Cells["velocidad"].Value.ToString();
                    precioUnitario = Convert.ToDecimal(dgvMovimientos.SelectedRows[0].Cells["importe"].Value);
                    Descripcion = string.Format("{0} : {1}", dgvMovimientos.SelectedRows[0].Cells["servicio"].Value.ToString(), nombreVelocidadActual);
                    Final = precioUnitario;
                }
                catch { }
            }
        }
    }
}
