using CapaNegocios;
using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Partes_Trabajo
{
    public partial class frmPostergarFechaCorteServ : Form
    {
        DataTable DtCortes = new DataTable();
        Usuarios_CtaCte oUsuariosCtaCte = new Usuarios_CtaCte();
        Usuarios_Servicios oUsuariosServicios = new Usuarios_Servicios();
        Servicios_Estados_Historial oServiciosEstadosHistorial = new Servicios_Estados_Historial();
        private int IdUsuario, IdLocacion, IdUsuariosServicios;
        private Thread hilo;
        private delegate void myDel();
        private Usuarios oUsuarios = new Usuarios();
        private DataTable DtUsuarios = new DataTable();
        private DataTable DtLocaciones = new DataTable();
        private DataTable DtServiciosContratados = new DataTable();
        private DataTable DtHistorial = new DataTable();
        private Usuarios_Locaciones oUsuariosLocaciones = new Usuarios_Locaciones();
        private DataView DtvLocacion = new DataView();
        private DataRow[] DrServiciosSeleccionados;


        private void ComenzarCarga()
        {
            dgvHistorial.DataSource = null;
            pgCircular.Start();
            hilo = new Thread(new ThreadStart(CargarDatos));
            hilo.Start();
        }

        private void CargarDatos()
        {
            DtUsuarios = oUsuarios.Buscar_datos_usuario(IdUsuario);
            DtLocaciones = oUsuariosLocaciones.ListarLocacionesServicio(IdUsuario);
            if (IdLocacion > 0)
            {
                DtvLocacion = DtLocaciones.DefaultView;
                DtvLocacion.RowFilter = String.Format("id={0}", IdLocacion);
                DtLocaciones = DtvLocacion.ToTable();
            }
            DtServiciosContratados = oUsuariosServicios.Listar_activos(IdUsuario);
            if (DtServiciosContratados.Rows.Count > 0)
            {
                DtServiciosContratados.Columns.Add("Elige", typeof(Boolean));
                foreach (DataRow dr in DtServiciosContratados.Rows)
                    dr["elige"] = false;
            }
            myDel MD = new myDel(AsignarDatos);
            this.Invoke(MD, new object[] { });
            pgCircular.Stop();
        }

        private void AsignarDatos()
        {
            LBApellido.Text = DtUsuarios.Rows[0]["apellido"].ToString().Trim() + " , " + (DtUsuarios.Rows[0]["nom_usu"].ToString()).ToUpperInvariant() + " [" + DtUsuarios.Rows[0]["codigo"].ToString() + "]";
            LBNumero_documento.Text = "Documento : (" + DtUsuarios.Rows[0]["id_usuarios_tipodoc"].ToString() + ") Nro " + DtUsuarios.Rows[0]["numero_documento"].ToString();
            lbcuit.Text = "C. Iva : (" + DtUsuarios.Rows[0]["descripcion"].ToString() + ") Nro " + DtUsuarios.Rows[0]["cuit"].ToString();
            lbcorreo.Text = "Mail: " + DtUsuarios.Rows[0]["Correo_electronico"].ToString();

            dgvLocaciones.DataSource = DtLocaciones;
            for (int x = 0; x < dgvLocaciones.Columns.Count; x++)
                dgvLocaciones.Columns[x].Visible = false;
            dgvLocaciones.Columns["calle"].Visible = true;
            dgvLocaciones.Columns["altura"].Visible = true;
            dgvLocaciones.Columns["piso"].Visible = true;
            dgvLocaciones.Columns["depto"].Visible = true;
            dgvLocaciones.Columns["localidad"].Visible = true;

            dgvServicios.DataSource = DtServiciosContratados;
            for (int x = 0; x < dgvServicios.Columns.Count; x++)
                dgvServicios.Columns[x].Visible = false;
            dgvServicios.Columns["servicio"].Visible = true;
            dgvServicios.Columns["tiposervicio"].Visible = true;
            dgvServicios.Columns["estado"].Visible = true;
            dgvServicios.Columns["elige"].Visible = true;
            dgvServicios.Columns["elige"].HeaderText = "Pasar a espera";
            DtServiciosContratados.DefaultView.RowFilter = String.Format("id_usuarios_locaciones={0}", IdLocacion);
            CargarHistorialUsuarioServicio();
            lblTotal.Text = String.Format("Total de Registros: {0}", dgvServicios.Rows.Count);
        }

        private void CargarHistorialUsuarioServicio()
        {
            if (dgvServicios.Rows.Count > 0)
            {
                if (dgvServicios.SelectedRows.Count > 0)
                    IdUsuariosServicios = Convert.ToInt32(dgvServicios.SelectedRows[0].Cells["id"].Value);
                else
                    IdUsuariosServicios = Convert.ToInt32(dgvServicios.Rows[0].Cells["id"].Value);

                DtHistorial.Clear();
                DtHistorial = oServiciosEstadosHistorial.ListarPorUsuarioSevicio(IdUsuariosServicios);
                dgvHistorial.DataSource = DtHistorial;
                for (int x = 0; x < dgvHistorial.Columns.Count; x++)
                    dgvHistorial.Columns[x].Visible = false;
                dgvHistorial.Columns["estado"].Visible = true;
                dgvHistorial.Columns["fecha_estado"].Visible = true;
                dgvHistorial.Columns["fecha"].Visible = true;
                dgvHistorial.Columns["estado"].HeaderText = "Pasado a:";
                dgvHistorial.Columns["fecha"].HeaderText = "Fecha de operación:";
                dgvHistorial.Columns["fecha_estado"].HeaderText = "Postergado para:";
                DtHistorial.DefaultView.RowFilter = String.Format("id_servicios_estados={0}", Convert.ToInt32(Servicios.Servicios_Estados.EN_ESPERA));
            }
        }












        private void Postergar()
        {
            if (dgvServicios.SelectedRows.Count > 0)
            {
                DrServiciosSeleccionados = DtServiciosContratados.Select("elige=1");
                if (DrServiciosSeleccionados.Count() > 0)
                {
                    foreach (DataRow fila in DrServiciosSeleccionados)
                    {
                        if (Convert.ToInt32(fila["elige"]) == 1)
                        {
                            try
                            {
                                oUsuariosServicios.ActualizarEstado(Convert.ToInt32(fila["id"]), Convert.ToInt32(Servicios.Servicios_Estados.EN_ESPERA));
                                oUsuariosServicios.ActualizarFechaEstado(Convert.ToInt32(fila["id"]), dtpFecha.Value.Date);
                                oServiciosEstadosHistorial.id_servicios_estados = Convert.ToInt32(Servicios.Servicios_Estados.EN_ESPERA);
                                oServiciosEstadosHistorial.id_servicios = Convert.ToInt32(fila["id_servicios"]);
                                oServiciosEstadosHistorial.id_usuarios = Convert.ToInt32(fila["id_usuarios"]);
                                oServiciosEstadosHistorial.id_usuarios_servicios = Convert.ToInt32(fila["id"]);
                                oServiciosEstadosHistorial.fecha = DateTime.Now;
                                oServiciosEstadosHistorial.Guardar(oServiciosEstadosHistorial);

                            }
                            catch
                            {
                                MessageBox.Show("Hubo errores en la operación.");
                            }
                        }
                    }
                    CargarHistorialUsuarioServicio();
                    this.DialogResult = DialogResult.OK;
                }
                else
                    MessageBox.Show("No se han seleccionado servicios.");

            }
        }

        public frmPostergarFechaCorteServ(int IdUsuarioRecibido, int IdLocacionRecibida)
        {
            IdUsuario = IdUsuarioRecibido;
            IdLocacion = IdLocacionRecibida;
            InitializeComponent();
        }

        private void frmPostergarFechaCorteServ_Load(object sender, EventArgs e)
        {
            dtpFecha.CustomFormat = "dd-MM-yyyy";
            dgvServicios.ReadOnly = false;

            ComenzarCarga();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPostergarFechaCorteServ_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnPostergar_Click(object sender, EventArgs e)
        {
            Postergar();
        }

        private void dgvLocaciones_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvLocaciones.SelectedRows.Count > 0)
                DtServiciosContratados.DefaultView.RowFilter = String.Format("id_usuarios_locaciones={0}", Convert.ToInt32(dgvLocaciones.SelectedRows[0].Cells["id"].Value));
        }

        private void dgvServicios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvServicios_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            CargarHistorialUsuarioServicio();
        }

        private void dgvServicios_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
