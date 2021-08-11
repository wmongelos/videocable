using CapaNegocios;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;


namespace CapaPresentacion.Abms
{
    public partial class ABMClientes : Form
    {
        private Usuarios oUsuario = new Usuarios();
        private Usuarios_Locaciones oLocacion = new Usuarios_Locaciones();

        private Thread hilo;
        private delegate void myDel();

        private int idUsuario = 0;

        private DataTable dtDatosUsuario = new DataTable();
        private DataTable dtDatosLocacion = new DataTable();
        public ABMClientes(int idUsuario)
        {
            this.idUsuario = idUsuario;
            InitializeComponent();
        }

        #region [METODOS]
        private void comenzarCarga()
        {

            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
        }

        private void cargarDatos()
        {
            try
            {
                if (idUsuario > 0)
                {
                    dtDatosUsuario = oUsuario.Buscar_datos_usuario(idUsuario);
                    dtDatosLocacion = oLocacion.ListarLocacionesDeServicio(idUsuario);
                    oLocacion.Id = Convert.ToInt32(dtDatosLocacion.Rows[0]["id"]);

                }

                myDel MD = new myDel(asignarDatos);
                this.Invoke(MD, new object[] { });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Informacion" + ex.Message);
            }
        }


        private void BloquearCampos()
        {
            foreach (Control item in pnlMain.Controls)
            {
                if (item is TextBoxBase || item is ComboBox || item is NumericUpDown || item is CheckBox || item is DateTimePicker)
                    item.Enabled = false;
            }
        }

        private void DesbloquearControles()
        {
            foreach (Control item in pnlMain.Controls)
            {
                if (item is TextBoxBase || item is ComboBox || item is NumericUpDown || item is CheckBox || item is DateTimePicker)
                    item.Enabled = true;
            }
        }
        private void asignarDatos()
        {
            cboTipoDNI.DataSource = Tablas.DataTipoDNI;
            cboTipoDNI.DisplayMember = "nombre";
            cboTipoDNI.ValueMember = "id";

            cboCondIVA.DataSource = Tablas.DataCondIVA;
            cboCondIVA.DisplayMember = "Descripcion";
            cboCondIVA.ValueMember = "Id";

            if (idUsuario > 0)
            {
                BloquearCampos();
                LlenarCampos();
            }

        }

        private void LlenarCampos()
        {
            txtNombre.Text = dtDatosUsuario.Rows[0]["nom_usu"].ToString();
            txtApellido.Text = dtDatosUsuario.Rows[0]["apellido"].ToString();
            cboTipoDNI.SelectedValue = Convert.ToInt32(dtDatosUsuario.Rows[0]["id_usuarios_tipodoc"]);
            txtNumero.Text = dtDatosUsuario.Rows[0]["numero_documento"].ToString();
            txtCorreo.Text = dtDatosUsuario.Rows[0]["correo_electronico"].ToString();
            try
            {
                dtpFechaNacimiento.Value = Convert.ToDateTime(dtDatosUsuario.Rows[0]["nacimiento"]);
            }
            catch
            {
            }
            cboCondIVA.Text = dtDatosUsuario.Rows[0]["descripcion"].ToString();
            spImpuestoProv.Value = Convert.ToDecimal(dtDatosUsuario.Rows[0]["impuesto_provincial"]);
            txtCUIT.Text = dtDatosUsuario.Rows[0]["cuit"].ToString();
            chkAdhesionFacturaElec.Checked = Convert.ToBoolean(dtDatosUsuario.Rows[0]["adhesion_facdigital"]);
            chkDebitoAutomatico.Checked = Convert.ToBoolean(dtDatosUsuario.Rows[0]["debito_automatico"]);
            cboProfesion.SelectedValue = Convert.ToInt32(dtDatosUsuario.Rows[0]["id_usuarios_profesiones"]);


            txtCalle.Text = dtDatosLocacion.Rows[0]["calle"].ToString();
            txtAltura.Text = dtDatosLocacion.Rows[0]["altura"].ToString();
            txtPiso.Text = dtDatosLocacion.Rows[0]["piso"].ToString();
            txtDepto.Text = dtDatosLocacion.Rows[0]["depto"].ToString();
            txtLocalidad.Text = dtDatosLocacion.Rows[0]["localidad"].ToString();
            txtCodigoPostal.Text = dtDatosLocacion.Rows[0]["codigo_postal"].ToString();


        }
        #endregion

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarUsuario())
            {
                Usuarios oUsuario = new Usuarios();
                oUsuario.Codigo = Convert.ToInt32(txtCodigo.Text);
                oUsuario.Apellido = txtApellido.Text;
                oUsuario.Nombre = txtNombre.Text;
                oUsuario.Id_Usuarios_TipoDoc = Convert.ToInt32(cboTipoDNI.SelectedValue);
                oUsuario.Numero_Documento = Convert.ToDouble(txtNumero.Text);
                oUsuario.Id_Comprobantes_Iva = Convert.ToInt32(cboCondIVA.SelectedValue);
                try
                {
                    oUsuario.CUIT = Convert.ToDouble(txtCUIT.Text);
                }
                catch
                {
                    oUsuario.CUIT = 0;
                }
                oUsuario.Nacimiento = dtpFechaNacimiento.Value;
                oUsuario.Id_Usuarios_Profesiones = Convert.ToInt32(cboProfesion.SelectedValue);
                oUsuario.Correo_Electronico = txtCorreo.Text.Trim();
                oUsuario.Adhesion_FacDigital = chkAdhesionFacturaElec.CheckState == CheckState.Checked ? 1 : 0;
                oUsuario.Debito_Automatico = chkDebitoAutomatico.CheckState == CheckState.Checked ? 1 : 0;
                oUsuario.Calculo_Bonificacion = Convert.ToInt32(cboCalculoBonificaciones.SelectedIndex);
                oUsuario.Impuesto_Provincial = spImpuestoProv.Value;
                oUsuario.Exento_Impuesto_Provincial = chkExentoProv.CheckState == CheckState.Checked ? 1 : 0;
                oUsuario.Id_Usuarios_Tipos = (int)Usuarios.Usuarios_Tipos.CLIENTE;
                oUsuario.Id = this.idUsuario;
                idUsuario = oUsuario.Guardar(oUsuario);

                oLocacion.Id_Calle = 0;
                oLocacion.Calle = txtCalle.Text;
                oLocacion.Entre_Calle_1 = "";
                oLocacion.Entre_Calle_2 = "";
                oLocacion.Id_Calle_Entre_1 = 0;
                oLocacion.Id_Calle_Entre_2 = 0;
                oLocacion.Altura = Convert.ToInt32(txtAltura.Text);
                oLocacion.Depto = txtDepto.Text;
                oLocacion.Piso = txtPiso.Text;
                oLocacion.Id_Locacion_Fiscal_Asociada = 0;
                oLocacion.Id_Localidades = 0;
                oLocacion.Localidad = txtLocalidad.Text;
                oLocacion.Codigo_Postal = txtCodigoPostal.Text;
                oLocacion.Manzana = "0";
                oLocacion.Observacion = "locacion cliente";
                oLocacion.Parcela = "0";
                oLocacion.Prefijo_1 = Convert.ToInt32(txtPrefijo1.Text);
                oLocacion.Telefono_1 = Convert.ToInt32(txtTelefono1.Text);
                oLocacion.Prefijo_2 = Convert.ToInt32(txtPrefijo2.Text);
                oLocacion.Telefono_2 = Convert.ToInt32(txtTelefono2.Text);
                oLocacion.Id_Provincias = 0;
                oLocacion.Id_Usuarios = idUsuario;
                oLocacion.Tipo = "";
                oLocacion.Guardar(idUsuario, oLocacion);

                MessageBox.Show("Cliente guardado correctamente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                oUsuario.LlenarObjeto(oUsuario.Id);
                this.Close();

            }
        }
        private Boolean ValidarUsuario()
        {
            errorIcon.Clear();


            if (txtApellido.Text.Trim() == String.Empty)
            {
                errorIcon.SetError(txtApellido, "Debe Ingresar el Apellido");
                txtApellido.Focus();
                return false;
            }

            if (txtNombre.Text.Trim() == String.Empty)
            {
                errorIcon.SetError(txtNombre, "Debe Ingresar el Nombre");
                txtNombre.Focus();
                return false;

            }

            if (txtNumero.Text.Trim() == String.Empty)
            {
                errorIcon.SetError(txtNumero, "Debe Ingresar el numero de documento");
                txtNumero.Focus();
                return false;
            }

            if (Convert.ToInt32(cboCondIVA.SelectedValue) == Convert.ToInt32(Comprobantes_Iva.Tipo.RESPONSABLE_INSCRIPTO))
            {
                if (Convert.ToDouble(txtCUIT.Text) == 0)
                {
                    errorIcon.SetError(txtCUIT, "Debe Ingresar el Nro. de Cuit");
                    txtCUIT.Focus();
                    return false;
                }
            }

            if (txtCalle.Text.Trim() == String.Empty)
            {
                errorIcon.SetError(txtCalle, "Debe Ingresar el nombre de la calle");
                txtCalle.Focus();
                return false;
            }

            if (txtAltura.Text.Trim() == String.Empty || txtAltura.Text.Equals("0"))
            {
                errorIcon.SetError(txtCalle, "Debe Ingresar la altura de la calle");
                txtAltura.Focus();
                return false;
            }

            if (txtLocalidad.Text.Trim() == String.Empty)
            {
                errorIcon.SetError(txtLocalidad, "Debe Ingresar la altura de la calle");
                txtLocalidad.Focus();
                return false;
            }
            if (txtCodigoPostal.Text.Trim() == String.Empty || txtCodigoPostal.Text.Equals("0"))
            {
                errorIcon.SetError(txtCodigoPostal, "Debe Ingresar la altura de la calle");
                txtCodigoPostal.Focus();
                return false;
            }


            return true;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void ABMClientes_Load(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void cboCondIVA_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ABMClientes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void LimpiarCampos()
        {
            txtCodigo.Text = "0";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtCorreo.Text = "0";
            txtNumero.Text = "0";
            txtCUIT.Text = "0";
            spImpuestoProv.Value = 0;
            chkAdhesionFacturaElec.Checked = false;
            chkDebitoAutomatico.Checked = false;
            chkExentoProv.Checked = false;

            txtCalle.Text = "";
            txtAltura.Text = "0";
            txtPiso.Text = "0";
            txtDepto.Text = "0";
            txtLocalidad.Text = "";
            txtCodigoPostal.Text = "0";
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            DesbloquearControles();
            oUsuario.Id = 0;
            txtNombre.Focus();
            LimpiarCampos();
        }

        private void boton2_Click(object sender, EventArgs e)
        {
            btnNuevo.Enabled = false;
            DesbloquearControles();
            txtNombre.Focus();
        }
    }
}
