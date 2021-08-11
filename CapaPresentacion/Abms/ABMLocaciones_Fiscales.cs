using CapaNegocios;
using System;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Abms
{
    public partial class ABMLocaciones_Fiscales : Form
    {
        private int idUsuario, idLocacionFiscalSeleccionada;
        Thread hilo;
        delegate void myDel();
        private DataTable dtLocacionesFiscales, dtLocacionesDeServicioAsociadas, dtAuxiliar, dtProvincias, dtCondicionesIVA;
        private Usuarios_Dom_Fiscal oUsuariosDomFiscal = new Usuarios_Dom_Fiscal();
        private Provincias oProvincias = new Provincias();
        private Comprobantes_Iva oComprobantesIVA = new Comprobantes_Iva();
        private Tools oTools = new Tools();
        private Usuarios_Locaciones oUsuariosLocaciones = new Usuarios_Locaciones();

        private void ComenzarCarga()
        {
            dtLocacionesFiscales.Clear();
            dtLocacionesDeServicioAsociadas.Clear();
            pgCircular.Start();
            hilo = new Thread(new ThreadStart(CargarDatos));
            hilo.IsBackground = true;
            hilo.Start();
        }

        private void CargarDatos()
        {
            try
            {
                if (idUsuario > 0)
                    dtLocacionesFiscales = oUsuariosDomFiscal.Listar(idUsuario);
                else
                    dtLocacionesFiscales = oUsuariosDomFiscal.Listar(0);

                myDel MD = new myDel(AsignarDatos);
                this.Invoke(MD, new object[] { });
                pgCircular.Stop();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
            }
        }

        private void AsignarDatos()
        {
            dgvLocacionesFiscales.DataSource = dtLocacionesFiscales;
            for (int x = 0; x < dgvLocacionesFiscales.ColumnCount; x++)
                dgvLocacionesFiscales.Columns[x].Visible = false;

            dgvLocacionesFiscales.Columns["r_social"].Visible = true;
            //dgvLocacionesFiscales.Columns["numero_documento"].Visible = true;
            dgvLocacionesFiscales.Columns["condicion_iva"].Visible = true;
            dgvLocacionesFiscales.Columns["cuit"].Visible = true;
            dgvLocacionesFiscales.Columns["locacion"].Visible = true;
            dgvLocacionesFiscales.Columns["telefono"].Visible = true;

            dgvLocacionesFiscales.Columns["r_social"].HeaderText = "Razón social";
            //dgvLocacionesFiscales.Columns["numero_documento"].HeaderText = "Nro. documento";
            dgvLocacionesFiscales.Columns["condicion_iva"].HeaderText = "Condición de IVA";
            dgvLocacionesFiscales.Columns["cuit"].HeaderText = "CUIT";
            dgvLocacionesFiscales.Columns["locacion"].HeaderText = "Locación";
            dgvLocacionesFiscales.Columns["telefono"].HeaderText = "Teléfono";

            if (dtLocacionesFiscales.Rows.Count > 0)
                AsignarValoresLocacionesServicio(Convert.ToInt32(dtLocacionesFiscales.Rows[0]["id"]));
            Controles(true);

        }

        private void AsignarValoresLocacionesServicio(int idLocacionFiscal)
        {
            dtLocacionesDeServicioAsociadas = oUsuariosDomFiscal.ListarLocacionesDeServicio(idLocacionFiscal);
            dgvLocacionesServicios.DataSource = dtLocacionesDeServicioAsociadas;
            for (int x = 0; x < dgvLocacionesServicios.ColumnCount; x++)
                dgvLocacionesServicios.Columns[x].Visible = false;
            dgvLocacionesServicios.Columns["calle"].Visible = true;
            dgvLocacionesServicios.Columns["altura"].Visible = true;
            dgvLocacionesServicios.Columns["piso"].Visible = true;
            dgvLocacionesServicios.Columns["depto"].Visible = true;
            dgvLocacionesServicios.Columns["localidad"].Visible = true;
            dgvLocacionesServicios.Columns["provincia"].Visible = true;
            dgvLocacionesServicios.Columns["saldo"].Visible = true;

            dgvLocacionesServicios.Columns["calle"].HeaderText = "Calle";
            dgvLocacionesServicios.Columns["altura"].HeaderText = "Altura";
            dgvLocacionesServicios.Columns["piso"].HeaderText = "Piso";
            dgvLocacionesServicios.Columns["depto"].HeaderText = "Depto.";
            dgvLocacionesServicios.Columns["localidad"].HeaderText = "Localidad";
            dgvLocacionesServicios.Columns["provincia"].HeaderText = "Provincia";
            dgvLocacionesServicios.Columns["saldo"].HeaderText = "Saldo";

        }

        private void Controles(bool state)
        {
            btnActualizar.Enabled = state;
            btnNuevo.Enabled = state;
            btnEliminar.Enabled = state;
            btnEditar.Enabled = state;
            dgvLocacionesFiscales.Enabled = state;
            //dgvLocacionesServicio.Enabled = state;
            if (dgvLocacionesFiscales.Rows.Count > 0)
            {
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;
                //btnAgregar.Enabled = true;
            }
            else
            {
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;
                //btnAgregar.Enabled = false;
            }
        }

        private void AbrirPanelCargaEdicion(int idLocacionFiscalSeleccionada)
        {
            this.idLocacionFiscalSeleccionada = idLocacionFiscalSeleccionada;
            DataGridViewRow drLocacionFiscalSeleccionada;

            if (dtProvincias.Rows.Count == 0)
                dtProvincias = oProvincias.Listar();
            if (dtCondicionesIVA.Rows.Count == 0)
                dtCondicionesIVA = oComprobantesIVA.Listar();

            cboProvincia.DataSource = dtProvincias;
            cboProvincia.DisplayMember = "nombre";
            cboProvincia.ValueMember = "id";

            cboCondIVA.DataSource = dtCondicionesIVA;
            cboCondIVA.DisplayMember = "Descripcion";
            cboCondIVA.ValueMember = "Id";

            if (idLocacionFiscalSeleccionada > 0)
            {
                lblTituloPanel.Text = String.Format("Edición de datos de locación fiscal");
                drLocacionFiscalSeleccionada = dgvLocacionesFiscales.SelectedRows[0];
                txtRSocial.Text = drLocacionFiscalSeleccionada.Cells["r_social"].Value.ToString();
                cboCondIVA.SelectedValue = Convert.ToInt32(drLocacionFiscalSeleccionada.Cells["id_condicion_iva"].Value);
                txtCUIT.Text = drLocacionFiscalSeleccionada.Cells["cuit"].Value.ToString();
                cboProvincia.SelectedValue = Convert.ToInt32(drLocacionFiscalSeleccionada.Cells["id_provincia"].Value);
                txtLocalidad.Text = drLocacionFiscalSeleccionada.Cells["localidad"].Value.ToString();
                txtCalle.Text = drLocacionFiscalSeleccionada.Cells["calle"].Value.ToString();
                txtAltura.Text = drLocacionFiscalSeleccionada.Cells["altura"].Value.ToString();
                txtPiso.Text = drLocacionFiscalSeleccionada.Cells["piso"].Value.ToString();
                txtDepto.Text = drLocacionFiscalSeleccionada.Cells["depto"].Value.ToString();
                txtCP.Text = drLocacionFiscalSeleccionada.Cells["codigo_postal"].Value.ToString();
                txtTelefono.Text = drLocacionFiscalSeleccionada.Cells["telefono"].Value.ToString();
            }
            else
                lblTituloPanel.Text = String.Format("Nueva locación fiscal");
            panelCargaEdicion.Location = new Point(
                        this.ClientSize.Width / 2 - panelCargaEdicion.Size.Width / 2,
                        this.ClientSize.Height / 2 - panelCargaEdicion.Size.Height / 2);
            panelCargaEdicion.Anchor = AnchorStyles.None;
            panelCargaEdicion.Visible = true;
            txtRSocial.Focus();
        }

        private bool ValidarDatos()
        {
            if (String.IsNullOrEmpty(txtRSocial.Text))
            {
                MessageBox.Show("Debe ingresar una razón social.");
                txtRSocial.Focus();
                return false;
            }

            if (String.IsNullOrEmpty(txtLocalidad.Text))
            {
                MessageBox.Show("Debe ingresar una localidad.");
                txtLocalidad.Focus();
                return false;
            }

            if (String.IsNullOrEmpty(txtCalle.Text))
            {
                MessageBox.Show("Debe ingresar una calle.");
                txtCalle.Focus();
                return false;
            }

            if (String.IsNullOrEmpty(txtAltura.Text))
            {
                MessageBox.Show("Debe ingresar una altura.");
                txtAltura.Focus();
                return false;
            }

            if (String.IsNullOrEmpty(txtTelefono.Text))
            {
                DialogResult dialogResult = MessageBox.Show("No ha ingresado un teléfono. ¿Desea continuar?", "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                    return true;
                else
                {
                    txtTelefono.Focus();
                    return false;
                }
            }

            if (Convert.ToInt32(cboCondIVA.SelectedValue) != Convert.ToInt32(Comprobantes_Iva.Tipo.CONSUMIDOR_FINAL))
            {
                if (txtCUIT.Text.Length == 0)
                {
                    MessageBox.Show("Eligió una condición de IVA distinta a CONSUMIDOR FINAL, por lo que debe ingresar un Cuit.");
                    txtCUIT.Focus();
                    return false;
                }
                else
                {
                    if (oTools.ValidaCuit(txtCUIT.Text) == false)
                    {
                        MessageBox.Show("El Cuit ingresado no es correcto. Controle el número de cuit ingresado y el formato.");
                        txtCUIT.Focus();
                        return false;
                    }
                }
            }

            return true;
        }

        private void LimpiarDatos()
        {
            txtRSocial.Text = String.Empty;
            txtCUIT.Text = String.Empty;
            txtLocalidad.Text = String.Empty;
            txtCalle.Text = String.Empty;
            txtAltura.Text = String.Empty;
            txtCP.Text = String.Empty;
            txtPiso.Text = String.Empty;
            txtDepto.Text = String.Empty;
            txtTelefono.Text = String.Empty;
            //foreach (Control control in this.Controls)
            //{
            //    if (control is TextBox && control.Tag.ToString() == "txtPanel")
            //        control.Text = String.Empty;
            //}
        }

        private void Guardar()
        {
            if (ValidarDatos())
            {
                //try
                //{
                oUsuariosDomFiscal.Id = idLocacionFiscalSeleccionada;
                oUsuariosDomFiscal.Id_Usuarios = idUsuario;
                oUsuariosDomFiscal.R_Social = txtRSocial.Text;
                oUsuariosDomFiscal.Calle = txtCalle.Text;
                oUsuariosDomFiscal.Altura = Convert.ToInt32(txtAltura.Text);
                oUsuariosDomFiscal.Piso = txtPiso.Text;
                oUsuariosDomFiscal.Depto = txtDepto.Text;
                oUsuariosDomFiscal.ImpuestoProvincial = numProvincial.Value;

                if (String.IsNullOrEmpty(txtCP.Text) || String.IsNullOrWhiteSpace(txtCP.Text))
                    oUsuariosDomFiscal.Codigo_Postal = "0";
                else
                    oUsuariosDomFiscal.Codigo_Postal = txtCP.Text;

                try
                {
                    oUsuariosDomFiscal.Cuit = Convert.ToDouble(txtCUIT.Text);
                }
                catch
                {
                    oUsuariosDomFiscal.Cuit = 0;
                }
                oUsuariosDomFiscal.idCondicionIva = Convert.ToInt32(cboCondIVA.SelectedValue);
                oUsuariosDomFiscal.Telefono = txtTelefono.Text;
                oUsuariosDomFiscal.Localidad = txtLocalidad.Text;
                oUsuariosDomFiscal.Id_Provincia = Convert.ToInt32(cboProvincia.SelectedValue);
                oUsuariosDomFiscal.Guardar(oUsuariosDomFiscal);
                //}
                //catch
                //{
                //    MessageBox.Show("Se produjeron errores al guarda los datos de locación fiscal.");
                //}
                LimpiarDatos();
                panelCargaEdicion.Visible = false; Controles(true);
                ComenzarCarga();


            }
        }

        private void Eliminar()
        {
            DialogResult dialogResult = MessageBox.Show("Está a punto de borrar una locación fiscal. ¿Desea continuar?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                oUsuariosDomFiscal.Eliminar(Convert.ToInt32(dgvLocacionesFiscales.SelectedRows[0].Cells["id"].Value));
                ComenzarCarga();
            }
        }

        private void AsignarLocacionDeServicio()
        {

            try
            {
                idLocacionFiscalSeleccionada = Convert.ToInt32(dgvLocacionesFiscales.SelectedRows[0].Cells["id"].Value);
            }
            catch
            {
                idLocacionFiscalSeleccionada = Convert.ToInt32(dgvLocacionesFiscales.Rows[0].Cells["id"].Value);
            }


            DataTable dtLocacionesUsuario = oUsuariosLocaciones.ListarLocacionesDeServicio(idUsuario);

            Partes_Trabajo.frmLocacionesDeServicioExistentes frm = new Partes_Trabajo.frmLocacionesDeServicioExistentes(dtLocacionesUsuario, 0, 0, 0, String.Empty, String.Empty, String.Empty, String.Empty);
            frmPopUp frmPop = new frmPopUp();
            frmPop.Formulario = frm;

            if (frmPop.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    oUsuariosLocaciones.ActualizarLocacionFiscal(frm.idLocacionSeleccionada, idLocacionFiscalSeleccionada);
                    MessageBox.Show("Locación de servicio asignada correctamente.");
                    ComenzarCarga();
                }
                catch
                {
                    MessageBox.Show("Error al asignar la locación de servicio a la locación fiscal.");
                }
            }
        }

        public ABMLocaciones_Fiscales(int idUsuario)
        {
            this.idUsuario = idUsuario;
            InitializeComponent();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarDatos();
            panelCargaEdicion.Visible = false;
            Controles(true);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Controles(false);
            AbrirPanelCargaEdicion(Convert.ToInt32(dgvLocacionesFiscales.SelectedRows[0].Cells["id"].Value));
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AsignarLocacionDeServicio();
        }

        private void panelCargaEdicion_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            panelCargaEdicion.Visible = false;
            Controles(true);
        }

        private void btnAgregarLocacionServicio_Click(object sender, EventArgs e)
        {
            if (dgvLocacionesFiscales.Rows.Count > 0)
                AsignarLocacionDeServicio();
        }

        private void ABMlocacionesFiscales_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (panelCargaEdicion.Visible)
                {
                    panelCargaEdicion.Visible = false;
                    Controles(true);
                }
                else
                    this.Close();
            }
        }

        private void dgvLocacionesFiscales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                idLocacionFiscalSeleccionada = Convert.ToInt32(dgvLocacionesFiscales.SelectedRows[0].Cells["id"].Value);
            }
            catch
            {
                idLocacionFiscalSeleccionada = Convert.ToInt32(dgvLocacionesFiscales.Rows[0].Cells["id"].Value);
            }
            AsignarValoresLocacionesServicio(idLocacionFiscalSeleccionada);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ComenzarCarga();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Controles(false);
            LimpiarDatos();
            AbrirPanelCargaEdicion(0);
        }

        private void ABMlocacionesFiscales_Load(object sender, EventArgs e)
        {
            dtLocacionesFiscales = new DataTable();
            dtLocacionesDeServicioAsociadas = new DataTable();
            dtAuxiliar = dtLocacionesDeServicioAsociadas.Clone();
            dtProvincias = new DataTable();
            dtCondicionesIVA = new DataTable();
            ComenzarCarga();
        }
    }
}
