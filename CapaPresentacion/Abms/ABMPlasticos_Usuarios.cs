using CapaNegocios;
using CapaPresentacion.Busquedas;
using CapaPresentacion.Debitos_Automaticos;
using System;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Abms
{
    public partial class ABMPlasticos_Usuarios : Form
    {
        private Thread hilo;
        private delegate void myDel();
        Plasticos oPlasticos = new Plasticos();
        private DataTable DtPlasticosUsuarios = new DataTable();
        private int IdPlastico = 0;
        private string NumeroPlastico;
        private string TitularPlastico;
        Plasticos_Usuarios oPlasticosUsuarios = new Plasticos_Usuarios();
        Usuarios oUsuarios = new Usuarios();
        private int IdUsuario = 0;
        private void comenzarCarga()
        {
            pgCircular.Start();
            dgvServiciosAsociados.DataSource = null;
            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
        }

        private void cargarDatos()
        {
            try
            {
                DtPlasticosUsuarios = oPlasticosUsuarios.Listar(IdPlastico, 0);
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
            dgvServiciosAsociados.DataSource = DtPlasticosUsuarios;
            for (int x = 0; x < dgvServiciosAsociados.ColumnCount; x++)
                dgvServiciosAsociados.Columns[x].Visible = false;

            dgvServiciosAsociados.Columns["codigo"].Visible = true;
            dgvServiciosAsociados.Columns["servicio"].Visible = true;
            dgvServiciosAsociados.Columns["usuario"].Visible = true;
            dgvServiciosAsociados.Columns["locacion"].Visible = true;

            dgvServiciosAsociados.Columns["fecha_inicio"].Visible = true;
            dgvServiciosAsociados.Columns["fecha_solicitud"].Visible = true;

            dgvServiciosAsociados.Columns["codigo"].HeaderText = "Codigo";
            dgvServiciosAsociados.Columns["codigo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvServiciosAsociados.Columns["servicio"].HeaderText = "Servicio";
            dgvServiciosAsociados.Columns["usuario"].HeaderText = "Usuario";
            dgvServiciosAsociados.Columns["locacion"].HeaderText = "Locacion";
            dgvServiciosAsociados.Columns["locacion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvServiciosAsociados.Columns["fecha_inicio"].HeaderText = "Fecha de inicio";
            dgvServiciosAsociados.Columns["fecha_solicitud"].HeaderText = "Fecha de solicitud";


            AsignarValores();
        }

        private void AsignarValores()
        {
            if (dgvServiciosAsociados.Rows.Count > 0)
            {
                if (dgvServiciosAsociados.SelectedRows.Count > 0)
                {
                    lblServicio.Text = String.Format("Servicio: {0}", dgvServiciosAsociados.SelectedRows[0].Cells["servicio"].Value);
                    lblUsuario.Text = String.Format("Usuario: {0}", dgvServiciosAsociados.SelectedRows[0].Cells["usuario"].Value);
                }
                else
                {
                    lblServicio.Text = String.Format("Servicio: {0}", dgvServiciosAsociados.Rows[0].Cells["servicio"].Value);
                    lblUsuario.Text = String.Format("Usuario: {0}", dgvServiciosAsociados.Rows[0].Cells["usuario"].Value);
                }
            }
        }

        private void EditarServicioAsignado()
        {
            if (dgvServiciosAsociados.Rows.Count > 0)
            {
                dgvServiciosAsociados.Enabled = false;
            }
            else
                MessageBox.Show("No se ha seleccionado un registro.");
        }

        private void CancelarEdicionServicio()
        {
            dgvServiciosAsociados.Enabled = true;

        }

        public ABMPlasticos_Usuarios(int IdPlasticoRecibido, string NumeroPlasticoRecibido, string TitularPlasticoRecibido)
        {
            IdPlastico = IdPlasticoRecibido;
            NumeroPlastico = NumeroPlasticoRecibido;
            TitularPlastico = TitularPlasticoRecibido;
            InitializeComponent();
        }

        private void ABMPlasticosUsuarios_Load(object sender, EventArgs e)
        {
            lblNumPlastico.Text = String.Format("Número: {0}", NumeroPlastico);
            lblTitular.Text = String.Format("Titular: {0}", TitularPlastico);
            comenzarCarga();
        }

        private void btnAgregarServicio_Click(object sender, EventArgs e)
        {
            int idUsuarioActual = Usuarios.CurrentUsuario.Id;
            frmBusquedaUsuarios frmBusquedaUsuarios = new frmBusquedaUsuarios(1, "", "");
            frmPopUp frmpopup = new frmPopUp();
            frmpopup.Maximizar = false;
            frmpopup.Formulario = frmBusquedaUsuarios;

            if (MessageBox.Show("¿Desea agregar un servicio del usuario actual?", "Mensaje del sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                frmpopup.ShowDialog();
                if (frmBusquedaUsuarios.DialogResult != DialogResult.OK)
                {
                    return;
                }
            }

            ABMPlasticos_AsignacionServicios frmAsignacionServicio = new ABMPlasticos_AsignacionServicios();
            frmAsignacionServicio.oPlastico.Id = IdPlastico;
            frmAsignacionServicio.oPlastico.Numero = NumeroPlastico.ToString();
            frmAsignacionServicio.oPlastico.Titular = TitularPlastico;
            frmAsignacionServicio.oUsuario = Usuarios.CurrentUsuario;
            frmpopup.Formulario = frmAsignacionServicio;
            frmpopup.ShowDialog();
            if (frmAsignacionServicio.DialogResult == DialogResult.OK)
            {
                IdUsuario = Usuarios.CurrentUsuario.Id;
                if (oPlasticosUsuarios.Listar(0, IdUsuario).Rows.Count > 0)
                    oUsuarios.ActualizarEstadoDebitoAutomatico(IdUsuario, 1);
                else
                    oUsuarios.ActualizarEstadoDebitoAutomatico(IdUsuario, 0);
                comenzarCarga();
            }
            else
            {
                DataTable dtDatosDomFiscal = new Usuarios_Dom_Fiscal().Listar(idUsuarioActual);
                Usuarios oUsu = new Usuarios().traerUsuario(idUsuarioActual);
                Usuarios.CurrentUsuario.Id = idUsuarioActual;
                Usuarios.CurrentUsuario.Id_Usuarios_Locacion = oUsu.Id_Usuarios_Locacion;
                Usuarios.CurrentUsuario.Id_Localidad = oUsu.Id_Localidad;
                int idUsuDomFiscal = 0;
                if (dtDatosDomFiscal.Rows.Count > 0)
                    idUsuarioActual = dtDatosDomFiscal.Rows[0]["id"] != null ? Convert.ToInt32(dtDatosDomFiscal.Rows[0]["id"]) : 0;
                Usuarios.Current_IdUsuarioLocacionFiscal = idUsuDomFiscal;
                new Usuarios().LlenarObjeto(idUsuarioActual);
            }
        }

        private void btnEditarServicio_Click(object sender, EventArgs e)
        {
            EditarServicioAsignado();
        }


        private void btnCancelarServicio_Click(object sender, EventArgs e)
        {
            CancelarEdicionServicio();
        }

        private void dgvServiciosAsociados_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            AsignarValores();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void ABMPlasticosUsuarios_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.DialogResult = DialogResult.OK;
        }

        private void dgvServiciosAsociados_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(dgvServiciosAsociados.Rows[e.RowIndex].Cells["activo1"].Value) == 0)
                    dgvServiciosAsociados.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Tomato;
                else
                    dgvServiciosAsociados.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.PaleGreen;

            }
            catch (Exception)
            {

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmNuevoDebito oFrm = new frmNuevoDebito();
            oFrm.titular = TitularPlastico;
            oFrm.numTarjeta = this.NumeroPlastico.ToString();
            oFrm.estado = "ACTIVA";
            oFrm.agregaServicio = true;
            if (oFrm.ShowDialog() == DialogResult.OK)
                comenzarCarga();
        }

        private void btnReactivar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(dgvServiciosAsociados.SelectedRows[0].Cells["activo1"].Value) == 0)
            {
                int idPlasticoUsuario = Convert.ToInt32(dgvServiciosAsociados.SelectedRows[0].Cells["id"].Value);
                int idPlastico = Convert.ToInt32(dgvServiciosAsociados.SelectedRows[0].Cells["id_plastico"].Value);
                string salida;
                if (oPlasticosUsuarios.ReactivarServicio(idPlasticoUsuario, idPlastico, out salida))
                {
                    dgvServiciosAsociados.SelectedRows[0].DefaultCellStyle.BackColor = Color.PaleGreen;
                    foreach (DataRow item in DtPlasticosUsuarios.Rows)
                    {
                        if (Convert.ToInt32(item["id"]) == idPlasticoUsuario)
                            item["activo1"] = 1;
                    }
                    MessageBox.Show("Servicio adherido al débito automático reactivado correctamente ", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                    MessageBox.Show("Hubo un error al intentar reactivar el servicio. \n" + salida, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvServiciosAsociados_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(dgvServiciosAsociados.SelectedRows[0].Cells["activo1"].Value) == 0)
                    btnReactivar.Enabled = true;
                else
                    btnReactivar.Enabled = false;
            }
            catch (Exception)
            {

            }
           


        }
    }
}
