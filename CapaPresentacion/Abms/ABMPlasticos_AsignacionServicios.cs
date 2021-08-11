using CapaNegocios;
using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Abms
{
    public partial class ABMPlasticos_AsignacionServicios : Form
    {
        public Usuarios oUsuario = new Usuarios();
        public Plasticos oPlastico = new Plasticos();
        public Plasticos_Usuarios oPlasticosUsuarios = new Plasticos_Usuarios();

        private Thread hilo;
        private delegate void myDel();
        private DataTable dtServicios = new DataTable();
        private DataTable dtServiciosAsociados = new DataTable();
        private DataTable dtServiciosUsuario = new DataTable();

        private void comenzarCarga()
        {
            pgCircular.Start();

            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.IsBackground = true;
            hilo.Start();
        }

        private void cargarDatos()
        {
            try
            {

                dtServiciosUsuario.Clear();
                dtServiciosAsociados.Clear();
                dtServicios.Clear();
                dtServiciosUsuario = oPlastico.ListarServiciosPorAsociar(oUsuario.Id);
                if (dtServiciosUsuario.Rows.Count > 0)
                {
                    dtServiciosAsociados = oPlasticosUsuarios.Listar(oPlastico.Id, oUsuario.Id);
                    foreach (DataRow usuario_servicio in dtServiciosUsuario.Rows)
                    {
                        if (dtServiciosAsociados.Select(String.Format("id_usuarios_servicios={0}", usuario_servicio["id"].ToString())).Count() == 0)
                            dtServicios.Rows.Add(Convert.ToInt32(usuario_servicio["id"]), usuario_servicio["servicio"].ToString(), usuario_servicio["estado"].ToString(), usuario_servicio["calle"].ToString() + " " + usuario_servicio["altura"].ToString(), usuario_servicio["localidad"].ToString());
                    }
                }
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
            if (dtServicios.Rows.Count > 0)
            {
                dgvServiciosAsociar.DataSource = dtServicios;
                dgvServiciosAsociar.Columns["idServicioAsociar"].Visible = false;
                dgvServiciosAsociar.Columns["ServicioEstado"].HeaderText = "Estado";
                dgvServiciosAsociar.Columns["ServicioDireccion"].HeaderText = "Dirección";
                dgvServiciosAsociar.Columns["ServicioLocalidad"].HeaderText = "Localidad";
                dgvServiciosAsociar.Columns["seleccion"].HeaderText = "";
                dgvServiciosAsociar.Columns["seleccion"].Width = 20;

                lblTotal.Text = String.Format("Total de Registros: {0}", dgvServiciosAsociar.Rows.Count);
            }
            else
            {
                MessageBox.Show("Todos los servicios del usuario ya han sido asignados a plásticos.");
                btnAsignar.Enabled = false;
                this.Close();
            }
        }

        private void ArmarTablaServicios()
        {
            dtServicios.Columns.Add("idServicioAsociar", typeof(int));
            dtServicios.Columns.Add("Servicio", typeof(string));
            dtServicios.Columns.Add("ServicioEstado", typeof(string));
            dtServicios.Columns.Add("ServicioDireccion", typeof(string));
            dtServicios.Columns.Add("ServicioLocalidad", typeof(string));
            dtServicios.Columns.Add("seleccion", typeof(bool));
        }

        private void GuardarAsignacionServicio()
        {
            if (dgvServiciosAsociar.SelectedRows.Count > 0)
            {
                try
                {
                    foreach (DataRow fila in dtServicios.Rows)
                    {
                        if (fila["seleccion"] != DBNull.Value && (Convert.ToInt32(fila["seleccion"]) == 1))
                        {
                            oPlasticosUsuarios.Id_Plastico = oPlastico.Id;
                            oPlasticosUsuarios.Id_Usuarios_Servicios = Convert.ToInt32(fila["idServicioAsociar"]);
                            oPlasticosUsuarios.Id_Usuario = oUsuario.Id;
                            oPlasticosUsuarios.Fecha_Inicio = txtDesde.Value;
                            oPlasticosUsuarios.Fecha_Solicitud = txtSolicitud.Value;
                            oPlasticosUsuarios.Id_Usuario = oUsuario.Id;
                            oPlasticosUsuarios.Activo = 1;
                            oPlasticosUsuarios.Guardar(oPlasticosUsuarios);
                        }
                    }

                    MessageBox.Show("Asignación registrada correctamente.");

                    this.DialogResult = DialogResult.OK;
                }
                catch
                {
                    MessageBox.Show("Controle las fechas ingresadas.");
                    txtDesde.Focus();
                }

            }
        }

        public ABMPlasticos_AsignacionServicios()
        {
            InitializeComponent();
        }

        private void ABMAsignacionServicios_Load(object sender, EventArgs e)
        {
            lblPlastico.Text += String.Format(" {0}", oPlastico.Numero);
            lblUsuario.Text += String.Format(" {0} {1}", oUsuario.Apellido, oUsuario.Nombre);
            txtSolicitud.Value = DateTime.Now;
            ArmarTablaServicios();
            comenzarCarga();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            if (dtServicios.Select("seleccion=1").Count() > 0)
                GuardarAsignacionServicio();
            else
                MessageBox.Show("No se han seleccionado servicios.");
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void ABMAsignacionServicios_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.DialogResult = DialogResult.Cancel;
        }
    }
}//22119fede
