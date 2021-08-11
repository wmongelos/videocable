using CapaNegocios;
using System;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Complementarias
{
    public partial class frmSeleccionarEquipo : Form
    {
        public int idUsuario, idUsuarioServicio, idServicio, idZona, idLocacion, idTipoServicio;
        private Equipos oEquipos = new Equipos();
        private Thread hilo;
        private delegate void myDel();
        private DataTable dtEquipos = new DataTable();
        private DataGridViewLinkColumn columnaCambiar = new DataGridViewLinkColumn();
        private int idTarjeta, idTipoEquipo, idTarjetaAnterior, idTarjetaNueva, idParte, idUsuarioServ;
        private string numeroTarjeta;
        private frmPopUp oFrmPop;
        private Partes oPartes = new Partes();
        private Partes_Solicitudes oPartes_Fallas = new Partes_Solicitudes();
        private Partes_Historial oPartesHistorial = new Partes_Historial();
        private Equipos_Tarjetas oEquiposTrajetas = new Equipos_Tarjetas();
        private CapaPresentacion.Busquedas.frmBusquedaTarjetasEquipos oFrmTarjetas;


        public frmSeleccionarEquipo(int idUsuarioServicio)
        {
            InitializeComponent();
            this.idUsuarioServ = idUsuarioServicio;
        }
        private void ComenzarCarga()
        {
            pgCircular.Start();
            hilo = new Thread(new ThreadStart(CargarDatos));
            hilo.Start();
        }
        private void CargarDatos()
        {
            dtEquipos = oEquipos.BuscarEquipoPorUsuarioServicio(idUsuarioServ);
            myDel MD = new myDel(AsignarDatos);
            this.Invoke(MD, new object[] { });
            pgCircular.Stop();
        }
        private void AsignarDatos()
        {
            dgvPresentacion.Columns.Clear();
            dgvPresentacion.DataSource = dtEquipos;

            dgvPresentacion.Columns["id"].Visible = false;
            dgvPresentacion.Columns["id_tarjeta"].Visible = false;
            dgvPresentacion.Columns["id_equipos_tipos"].Visible = false;
            dgvPresentacion.Columns["requiere_tarjeta"].Visible = false;
            dgvPresentacion.Columns["marca"].DisplayIndex = 0;
            dgvPresentacion.Columns["modelo"].DisplayIndex = 1;
            dgvPresentacion.Columns["marca"].HeaderText = "Marca";
            dgvPresentacion.Columns["modelo"].HeaderText = "Modelo";
            dgvPresentacion.Columns["numtarjeta"].HeaderText = "Tarjeta actual";
            dgvPresentacion.Columns["serie"].HeaderText = "Numero de serie";
            dgvPresentacion.Columns["mac"].HeaderText = "Mac";

            columnaCambiar.Name = "clnCambiar";
            columnaCambiar.HeaderText = "";
            columnaCambiar.Width = 60;
            columnaCambiar.Text = "Cambiar tarjeta";
            columnaCambiar.LinkColor = Color.Blue;
            columnaCambiar.ActiveLinkColor = Color.Blue;
            columnaCambiar.UseColumnTextForLinkValue = true;
            columnaCambiar.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            columnaCambiar.DisplayIndex = dgvPresentacion.Columns.Count;
            dgvPresentacion.Columns.Add(columnaCambiar);

        }
        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSeleccionarEquipo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void frmSeleccionarEquipo_Load(object sender, EventArgs e)
        {
            ComenzarCarga();
        }

        private void dgvPresentacion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPresentacion.Columns[e.ColumnIndex].Name == "clnCambiar")
            {

                idTarjetaAnterior = Convert.ToInt32(dgvPresentacion.SelectedRows[0].Cells["id_tarjeta"].Value);
                oFrmTarjetas = new Busquedas.frmBusquedaTarjetasEquipos(idTipoEquipo, Convert.ToInt32(Equipos_Tarjetas.Tarjetas_Estados.DISPONIBLE));
                oFrmPop = new frmPopUp();
                oFrmPop.Formulario = oFrmTarjetas;
                oFrmPop.Maximizar = false;
                if (oFrmPop.ShowDialog() == DialogResult.OK)
                {
                    this.idTarjetaNueva = oFrmTarjetas.IdTarjeta;
                    oEquiposTrajetas.AsignarTarjetaEquipo(Convert.ToInt32(dgvPresentacion.SelectedRows[0].Cells["id"].Value), idTarjetaNueva);
                    oEquiposTrajetas.AsignarTarjetaParteEquipo(Convert.ToInt32(dgvPresentacion.SelectedRows[0].Cells["id"].Value), idTarjeta);
                    oEquiposTrajetas.CambiarEstadoTarjeta(idTarjetaNueva, Convert.ToInt32(Equipos_Tarjetas.Tarjetas_Estados.ENTREGADA));
                    if (idTarjetaAnterior != 0)
                        oEquiposTrajetas.CambiarEstadoTarjeta(idTarjetaAnterior, Convert.ToInt32(Equipos_Tarjetas.Tarjetas_Estados.CON_FALLA));

                    DataTable drParteFalla = oPartes_Fallas.GetFallasPorTipoServYOp(idTipoServicio, Convert.ToInt32(Partes.Partes_Operaciones.ASIGNACION_DE_TARJETA));
                    oPartes.Id_Usuarios = idUsuario;
                    oPartes.Id_Servicios = idServicio;
                    oPartes.Id_Usuarios_Servicios = idUsuarioServicio;
                    oPartes.Id_Usuarios_Locaciones = idLocacion;
                    oPartes.Id_Zonas = idZona;
                    oPartes.Id_Partes_Fallas = Convert.ToInt32(drParteFalla.Rows[0]["id"]);
                    oPartes.Id_Partes_Soluciones = 0;
                    oPartes.Id_Movil = 0;
                    oPartes.Id_Operadores = Personal.Id_Login;
                    oPartes.Id_Areas = Personal.Id_Area;
                    oPartes.Fecha_Reclamo = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
                    oPartes.Detalle_Solucion = "."; // txtDetalle.Text;
                    oPartes.Detalle_Falla = drParteFalla.Rows[0]["nombre"].ToString();
                    oPartes.Id_Partes_Estados = Convert.ToInt32(Partes.Partes_Estados.REALIZADO);
                    oPartes.Id_Tecnico = Personal.Id_Login;
                    oPartes.Fecha_Realizado = DateTime.Now;
                    oPartes.Id_Usuarios_Cuenta_Corriente = 0;
                    idParte = oPartes.Guardar(oPartes, 1);

                    oPartesHistorial.Id_Partes_Estados = Convert.ToInt32(Partes.Partes_Estados.REALIZADO);
                    oPartesHistorial.Id_Parte = idParte;
                    oPartesHistorial.Id_Usuarios = idUsuario;
                    oPartesHistorial.Id_Personal = Personal.Id_Login;
                    oPartesHistorial.Fecha_Movimiento = DateTime.Now;
                    oPartesHistorial.Id_area = Personal.Id_Area;
                    oPartesHistorial.Detalles = "TARJETA ASIGNADA.";
                    oPartesHistorial.GuardarNuevoDetalle(oPartesHistorial);
                    ComenzarCarga();
                }
            }
        }

        private void dgvPresentacion_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            AsignarValores();
        }
        private void AsignarValores()
        {

            if (dgvPresentacion.SelectedRows.Count > 0)
            {
                idTarjeta = Convert.ToInt32(dgvPresentacion.SelectedRows[0].Cells["id"].Value);
                this.numeroTarjeta = dgvPresentacion.SelectedRows[0].Cells["numtarjeta"].Value.ToString();
                idTipoEquipo = Convert.ToInt32(dgvPresentacion.SelectedRows[0].Cells["id_equipos_tipos"].Value);
            }
        }
    }
}
