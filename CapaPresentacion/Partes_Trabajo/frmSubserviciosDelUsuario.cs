using CapaNegocios;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmSubserviciosDelUsuario : Form
    {
        int IdUsuario = 0;
        int IdLocacion = 0;
        private Thread hilo;
        private delegate void myDel();
        private DataTable DtServiciosContratados = new DataTable();
        private DataTable DtSubServiciosContratados = new DataTable();
        private DataTable DtDatosUsuario = new DataTable();
        private DataTable DtSubserviciosDisponibles = new DataTable();
        private Usuarios_Locaciones oUsuarioLocacion = new Usuarios_Locaciones();
        private Usuarios oUsuario = new Usuarios();
        private Usuarios_Servicios oUsuarioServicio = new Usuarios_Servicios();
        private Servicios_Tarifas oServiciosTarifas = new Servicios_Tarifas();
        private int TipoFacturacion;
        private Configuracion oConfiguracion = new Configuracion();
        int IndexColumna = 0;

        private void comenzarCarga()
        {
            pgCircular.Start();
            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
        }

        private void cargarDatos()
        {
            oUsuarioLocacion = oUsuarioLocacion.GetLocacion(IdLocacion);
            if (oUsuarioLocacion.Activo == Convert.ToInt32(Usuarios_Locaciones.Locacion_Estados.ACTIVA))
            {
                DtDatosUsuario = oUsuario.Buscar_datos_usuario(IdUsuario);
                DtServiciosContratados = oUsuarioServicio.ListarServicios(IdUsuario, IdLocacion);
                myDel MD = new myDel(asignarDatos);
                this.Invoke(MD, new object[] { });
            }
            else
                MessageBox.Show("La locación seleccionada no se encuentra activa.");

            pgCircular.Stop();
        }

        private void asignarDatos()
        {
            lblUsuario.Text = String.Format("Usuario: {0} {1}", DtDatosUsuario.Rows[0]["apellido"], DtDatosUsuario.Rows[0]["Nom_usu"]);
            lblLocacion.Text = String.Format("Locación seleccionada: {0} {1}, {2}", oUsuarioLocacion.Calle, oUsuarioLocacion.Altura, oUsuarioLocacion.Localidad);


            dgvServiciosContratados.DataSource = DtServiciosContratados;

            for (int x = 0; x < dgvServiciosContratados.Columns.Count; x++)
                dgvServiciosContratados.Columns[x].Visible = false;

            dgvServiciosContratados.Columns["servicio"].Visible = true;
            dgvServiciosContratados.Columns["serviciotipo"].Visible = true;
            dgvServiciosContratados.Columns["estado"].Visible = true;
            dgvServiciosContratados.Columns["servicio"].HeaderText = "Servicio";
            dgvServiciosContratados.Columns["serviciotipo"].HeaderText = "Tipo de servicio";
            dgvServiciosContratados.Columns["estado"].HeaderText = "Estado";

            if (dgvServiciosContratados.Rows.Count > 0)
            {
                AsignarValores();
                Controles(true);
            }
            else
            {
                MessageBox.Show("El usuario no tiene servicios contratados en la locación seleccionada.");
                Controles(false);
            }
            lblTotal.Text = String.Format("Total de Registros: {0}", dgvServiciosContratados.Rows.Count);
        }

        private void AsignarValores()
        {
            if (dgvServiciosContratados.Rows.Count > 0)
            {
                dgvSubServContratados.DataSource = null;
                DtSubServiciosContratados.Clear();
                if (dgvServiciosContratados.SelectedRows.Count > 0)
                    DtSubServiciosContratados = oUsuarioServicio.ListarServiciosSub(Convert.ToInt32(dgvServiciosContratados.SelectedRows[0].Cells["id"].Value));
                else
                    DtSubServiciosContratados = oUsuarioServicio.ListarServiciosSub(Convert.ToInt32(dgvServiciosContratados.Rows[0].Cells["id"].Value));
                DataGridViewLinkColumn colEliminar = new DataGridViewLinkColumn();
                colEliminar.Name = "colEliminar";
                colEliminar.HeaderText = "";
                colEliminar.Text = "Quitar";
                colEliminar.UseColumnTextForLinkValue = true;
                colEliminar.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                IndexColumna = dgvSubServContratados.Columns.IndexOf(colEliminar);
                if (IndexColumna >= 0)
                    dgvSubServContratados.Columns.RemoveAt(IndexColumna);
                dgvSubServContratados.DataSource = DtSubServiciosContratados;
                for (int x = 0; x < dgvSubServContratados.Columns.Count; x++)
                    dgvSubServContratados.Columns[x].Visible = false;
                dgvSubServContratados.Columns.Add(colEliminar);
                dgvSubServContratados.Columns["descripcion"].Visible = true;
                dgvSubServContratados.Columns["tiposubservicio"].Visible = true;
                dgvSubServContratados.Columns["descripcion"].HeaderText = "Subservicio";
                dgvSubServContratados.Columns["tiposubservicio"].HeaderText = "Tipo de subservicio";
                dgvSubServContratados.Columns["colEliminar"].Width = 70;
            }
        }

        private void Controles(bool state)
        {
            btnAgregarSubServ.Enabled = state;
        }

        private void AgregarSubservicio()
        {
            int IdTipoFacturacion = 0;

            if (TipoFacturacion == Convert.ToInt32(Tipo_Facturacion.Id_Tipo_Facturacion.POR_CATEGORIAS))
                IdTipoFacturacion = Convert.ToInt32(dgvServiciosContratados.SelectedRows[0].Cells["id_servicios_categorias"].Value);
            else
                IdTipoFacturacion = Convert.ToInt32(dgvServiciosContratados.SelectedRows[0].Cells["id_zona"].Value);
            DtSubserviciosDisponibles = oUsuarioServicio.ListarSubserviciosDisponibles(Convert.ToInt32(oServiciosTarifas.TraerDatosTarifaActual().Rows[0]["id"]), Convert.ToInt32(dgvServiciosContratados.SelectedRows[0].Cells["id_servicios"].Value), IdTipoFacturacion);
            if (DtSubserviciosDisponibles.Rows.Count > 0)
            {
                frmAgregarSubservicio frmAgregarSub;
                if (dgvServiciosContratados.SelectedRows.Count > 0)
                    frmAgregarSub = new frmAgregarSubservicio(Convert.ToInt32(dgvServiciosContratados.SelectedRows[0].Cells["id"].Value), Convert.ToInt32(dgvServiciosContratados.SelectedRows[0].Cells["id_servicios"].Value), dgvServiciosContratados.SelectedRows[0].Cells["servicio"].Value.ToString(), DtSubserviciosDisponibles);
                else
                    frmAgregarSub = new frmAgregarSubservicio(Convert.ToInt32(dgvServiciosContratados.Rows[0].Cells["id"].Value), Convert.ToInt32(dgvServiciosContratados.SelectedRows[0].Cells["id_servicios"].Value), dgvServiciosContratados.SelectedRows[0].Cells["servicio"].Value.ToString(), DtSubserviciosDisponibles);
                frmPopUp frmpopup = new frmPopUp();
                frmpopup.Maximizar = false;
                frmpopup.Formulario = frmAgregarSub;
                frmpopup.ShowDialog();
                if (frmAgregarSub.DialogResult == DialogResult.OK)
                    comenzarCarga();
            }
            else
                MessageBox.Show("No hay sub servicios diponibles.");
        }

        private void EliminarSubservicio(int Id)
        {
            oUsuarioServicio.QuitarSubservicio(Id);
        }

        public frmSubserviciosDelUsuario(int IdUsuarioRecibido, int IdLocacionRecibida)
        {
            IdUsuario = IdUsuarioRecibido;
            IdLocacion = IdLocacionRecibida;
            InitializeComponent();
        }

        private void frmServiciosDelUsuario_Load(object sender, EventArgs e)
        {
            TipoFacturacion = oConfiguracion.GetValor_N("Id_Tipo_Facturacion");
            if (IdUsuario > 0)
                comenzarCarga();
        }

        private void dgvServiciosContratados_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            AsignarValores();
        }

        private void btnAgregarSubServ_Click(object sender, EventArgs e)
        {
            AgregarSubservicio();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSubserviciosDelUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void dgvSubServContratados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSubServContratados.Columns[e.ColumnIndex].Name.Equals("colEliminar"))
            {
                DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea quitar el subservicio?", "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    EliminarSubservicio(Convert.ToInt32(dgvSubServContratados.SelectedRows[0].Cells["id"].Value));
                    comenzarCarga();
                }
            }
        }
    }
}
