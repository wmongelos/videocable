using CapaNegocios;
using CapaPresentacion.Busquedas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Abms
{
    public partial class ABMUsuarios : Form
    {
        #region PROPIEDADES
        public int idUsuario;
        private int Recibido = 0;
        private Usuarios oUsuarios = new Usuarios();
        private Usuarios_Dom_Fiscal oUsuarioDomFiscal = new Usuarios_Dom_Fiscal();
        private Usuarios_Tipodoc oUsuariosTipoDoc = new Usuarios_Tipodoc();
        private Usuarios_Profesiones oUsuariosProfesiones = new Usuarios_Profesiones();
        private Comprobantes_Iva oComprobantesIva = new Comprobantes_Iva();
        private Localidades oLocalidades = new Localidades();
        private Usuarios_Locaciones oUsuarioLocacion = new Usuarios_Locaciones();
        private Configuracion oConfiguracion = new Configuracion();
        private Tools oTools = new Tools();
        private Thread hilo;
        private delegate void myDel();
        private DataRow drUsuario_actual;
        private DataTable dtDatosUsuario = new DataTable();
        private DataTable dtLocacionFiscal = new DataTable();
        private DataTable dtLocacion = new DataTable();
        private DataTable dtTiposDoc = new DataTable();
        private DataTable dtTiposUsuario = new DataTable();
        private DataTable dtProfesiones = new DataTable();
        private DataTable dtComprobantesIva = new DataTable();
        private DataTable dtLocalidades = new DataTable();
        private int calculoBonificacionesDB;
        int idProvincia = 0;
        int idCalle = 0;
        int calleAlturaDesde, calleAlturaHasta, idLocacionFiscal, idLocacionServicios;
        string codigoPostal;
        bool PoseeLocacionFiscal = false;
        List<Int32> listLocalidades = new List<Int32>();

        #endregion

        #region MÉTODOS
        private void ComenzarCarga()
        {
            pgCircular.Start();
            hilo = new Thread(new ThreadStart(CargarDatos));
            hilo.Start();
        }

        private void CargarDatos()
        {
            try
            {

                if (idUsuario > 0)
                {
                    dtDatosUsuario = oUsuarios.Buscar_datos_usuario(idUsuario);
                    dtLocacionFiscal = oUsuarioDomFiscal.Listar(idUsuario);
                    dtLocacion = oUsuarioLocacion.ListarLocacionesServicio(idUsuario);
                }

                if (dtTiposDoc.Rows.Count == 0)
                    dtTiposDoc = oUsuariosTipoDoc.Listar();
                if (dtProfesiones.Rows.Count == 0)
                    dtProfesiones = oUsuariosProfesiones.Listar();
                if (dtComprobantesIva.Rows.Count == 0)
                    dtComprobantesIva = oComprobantesIva.Listar();
                if (dtLocalidades.Rows.Count == 0)
                    dtLocalidades = oLocalidades.Listar();
                if (dtTiposUsuario.Rows.Count == 0)
                    dtTiposUsuario = oUsuarios.ListarUsuariosTipos();
                calculoBonificacionesDB = oConfiguracion.GetValor_N("BonificacionUsuLoc");
                myDel MD = new myDel(AsignarDatos);
                this.Invoke(MD, new object[] { });
            }
            catch
            {
                MessageBox.Show("Error al cargar.");
            }
            pgCircular.Stop();

        }

        private void AsignarDatos()
        {
            cboTipoDNI.DataSource = dtTiposDoc;
            cboTipoDNI.DisplayMember = "Tipo";
            cboTipoDNI.ValueMember = "Id";

            cboTipoUsuario.DataSource = dtTiposUsuario;
            cboTipoUsuario.DisplayMember = "Tipo";
            cboTipoUsuario.ValueMember = "Id";

            cboTipoUsuario.SelectedValue = Convert.ToInt32(Usuarios.Usuarios_Tipos.CLIENTE);

            cboProfesion.DataSource = dtProfesiones;
            cboProfesion.DisplayMember = "Nombre";
            cboProfesion.ValueMember = "Id";

            cboCondicionIVALocFiscal.DataSource = dtComprobantesIva;
            cboCondicionIVALocFiscal.DisplayMember = "Descripcion";
            cboCondicionIVALocFiscal.ValueMember = "id";

            cboLocalidades.DataSource = dtLocalidades;
            cboLocalidades.DisplayMember = "nombre";
            cboLocalidades.ValueMember = "id";

            cboCalculoBonificaciones.SelectedIndex = calculoBonificacionesDB;

            if (dtDatosUsuario.Rows.Count > 0)
                AsignarValoresUsuario();
            else
                lblCodigoUsuario.Text = String.Format("Código de usuario: 0");

            if (dtLocacionFiscal.Rows.Count > 0)
                AsignarValoresLocacion();

            if (dtLocacionFiscal.Rows.Count == 0)
            {
                lblCodigoLocacion.Text = String.Format("Código: 0");
                lblCodigoPostal.Text = String.Format("Código postal: {0}", dtLocalidades.Rows[0]["Codigo_Postal"].ToString());
                codigoPostal = dtLocalidades.Rows[0]["Codigo_Postal"].ToString();
            }
            Controles(false);
            ControlLocacionFiscal();
            txtApellido.Focus();
        }

        private void Controles(bool state)
        {
            btnEditar.Enabled = !state;
            btnBuscar.Enabled = !state;
            btnGuardar.Enabled = state;
            btnCancelar.Enabled = state;
            btnBuscarCalle.Enabled = state;
            foreach (Control control in this.Controls)
            {
                if (control is TextBox || control is ComboBox)
                    control.Enabled = state;
            }

            dtpFechaNacimiento.Enabled = state;
            chkAdhesionFacturaElec.Enabled = state;
            chkDebitoAutomatico.Enabled = state;
        }

        private void AsignarValoresUsuario()
        {
            lblCodigoUsuario.Text = String.Format("Código de usuario: {0}", dtDatosUsuario.Rows[0]["codigo"]);
            txtApellido.Text = dtDatosUsuario.Rows[0]["Apellido"].ToString();
            txtNombre.Text = dtDatosUsuario.Rows[0]["Nom_usu"].ToString();
            txtDNI.Text = dtDatosUsuario.Rows[0]["Numero_documento"].ToString();
            txtDNI.Tag = dtDatosUsuario.Rows[0]["Numero_documento"].ToString();
            try
            {
                dtpFechaNacimiento.Value = Convert.ToDateTime(dtDatosUsuario.Rows[0]["Nacimiento"]);
            }
            catch
            {
                MessageBox.Show("Puede que la fecha de nacimiento no haya sido ingresada correctamente.");
            }
            cboTipoDNI.SelectedValue = Convert.ToInt32(dtDatosUsuario.Rows[0]["id_usuarios_tipodoc"]);
            txtCorreo.Text = dtDatosUsuario.Rows[0]["correo_electronico"].ToString();
            cboProfesion.SelectedValue = Convert.ToInt32(dtDatosUsuario.Rows[0]["id_usuarios_profesiones"]);

            cboTipoUsuario.SelectedValue = Convert.ToInt32(dtDatosUsuario.Rows[0]["id_usuarios_tipos"]);
            cboCalculoBonificaciones.SelectedIndex = Convert.ToInt32(dtDatosUsuario.Rows[0]["calculo_bonificacion"]);
            chkAdhesionFacturaElec.Checked = (Convert.ToInt32(dtDatosUsuario.Rows[0]["adhesion_facdigital"]) == 1) ? true : false;
            chkDebitoAutomatico.Checked = (Convert.ToInt32(dtDatosUsuario.Rows[0]["debito_automatico"]) == 1) ? true : false;
        }

        private void AsignarValoresLocacion()
        {
            DataRow drLocacionFiscalSeleccionada = dtLocacionFiscal.Select(String.Format("id_locacion_asociada>0"))[0];
            DataRow drLocacionServiciosSeleccionada = dtLocacion.Select(String.Format("id={0}", drLocacionFiscalSeleccionada["id_locacion_asociada"].ToString()))[0];

            idLocacionFiscal = Convert.ToInt32(drLocacionFiscalSeleccionada["id"]);
            idLocacionServicios = Convert.ToInt32(drLocacionServiciosSeleccionada["id"]);

            lblCodigoLocacion.Text = String.Format("Código: {0}", drLocacionServiciosSeleccionada["id"].ToString());
            txtRSocial.Text = drLocacionFiscalSeleccionada["R_Social"].ToString();
            cboCondicionIVALocFiscal.SelectedValue = drLocacionFiscalSeleccionada["id_condicion_iva"].ToString();
            txtCuitLocFiscal.Text = drLocacionFiscalSeleccionada["cuit"].ToString();
            txtPrefijo1.Text = drLocacionServiciosSeleccionada["prefijo_1"].ToString();
            txtTelFijo.Text = drLocacionServiciosSeleccionada["telefono_1"].ToString();
            txtPrefijo2.Text = drLocacionServiciosSeleccionada["prefijo_2"].ToString();
            txtCelular.Text = drLocacionServiciosSeleccionada["telefono_2"].ToString();

            try
            {
                cboLocalidades.SelectedValue = Convert.ToInt32(drLocacionServiciosSeleccionada["id_localidades"]);
            }
            catch
            {
                cboLocalidades.SelectedValue = Convert.ToInt32(dtLocacion.Rows[0]["id_localidades"]);
            }
            idCalle = Convert.ToInt32(drLocacionServiciosSeleccionada["id_calle"]);
            calleAlturaDesde = Convert.ToInt32(drLocacionServiciosSeleccionada["altura_desde"]);
            calleAlturaHasta = Convert.ToInt32(drLocacionServiciosSeleccionada["altura_hasta"]);
            txtCalle.Text = drLocacionServiciosSeleccionada["Calle"].ToString();
            txtAltura.Text = drLocacionServiciosSeleccionada["Altura"].ToString();
            txtPiso.Text = drLocacionServiciosSeleccionada["Piso"].ToString();
            txtDepto.Text = drLocacionServiciosSeleccionada["depto"].ToString();
            codigoPostal = drLocacionServiciosSeleccionada["Codigo_Postal"].ToString();
            lblCodigoPostal.Text = String.Format("Código postal: {0}", codigoPostal);
            txtCalleEntre1.Text = drLocacionServiciosSeleccionada["entre_calle_1"].ToString();
            txtCalleEntre2.Text = drLocacionServiciosSeleccionada["entre_calle_2"].ToString();
            txtObservacion.Text = drLocacionServiciosSeleccionada["observacion"].ToString();
            lblAltura.Text = String.Format("Altura Desde {0} Hasta {1}", calleAlturaDesde, calleAlturaHasta);
        }

        private void LimpiarVariables()
        {
            idUsuario = 0;
            idProvincia = 0;
            idCalle = 0;
            calleAlturaDesde = 0;
            calleAlturaHasta = 0;
            codigoPostal = String.Empty;
            calculoBonificacionesDB = 0;
            dtDatosUsuario.Clear();
            dtLocacionFiscal.Clear();
            dtLocacion.Clear();
            lblAltura.Text = String.Format("[Debe Seleccionar la Calle ]");
        }

        private void AsignarVariableCalculoBonificacionDB()
        {

        }

        private void ControlLocacionFiscal()
        {
            bool state = true;
            if (idUsuario > 0 && dtLocacionFiscal.Rows.Count == 0)
            {
                state = false;
                txtRSocial.Enabled = state;
                cboCondicionIVALocFiscal.Enabled = state;
                txtCuitLocFiscal.Enabled = state;
                txtPrefijo1.Enabled = state;
                txtTelFijo.Enabled = state;
                txtPrefijo2.Enabled = state;
                txtCelular.Enabled = state;
                cboLocalidades.Enabled = state;
                txtCalle.Enabled = state;
                btnBuscarCalle.Enabled = state;
                txtAltura.Enabled = state;
                txtPiso.Enabled = state;
                txtDepto.Enabled = state;
                txtCalleEntre1.Enabled = state;
                txtCalleEntre2.Enabled = state;
                txtObservacion.Enabled = state;
                PoseeLocacionFiscal = state;
            }
            else
                PoseeLocacionFiscal = state;
        }
        private void LimpiarDatos()
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox || control is ComboBox)
                    control.Text = String.Empty;
            }
            dtpFechaNacimiento.Value = DateTime.Now;
            txtCorreo.Text = "Ejemplo@Email.com";
            txtCorreo.ForeColor = Color.Gray;
            chkAdhesionFacturaElec.Checked = false;
            drUsuario_actual = null;
        }

        private void Buscar()
        {
            oUsuarios.Codigo = 0;
            oUsuarios.Usuario = "";
            oUsuarios.Calle = "";
            oUsuarios.Altura = 0;

            Int32 opcion = 0;
            if (bUsuario.Checked == true) { opcion = 1; }
            if (bNombre.Checked == true) { opcion = 2; }
            if (Bdomicilio.Checked == true) { opcion = 3; }
            if (bDocumento.Checked == true) { opcion = 4; }
            if (txtbuscaraltura.Visible == false) { txtbuscaraltura.Text = ""; }

            frmBusquedaUsuarios frm = new frmBusquedaUsuarios(opcion, txtbusca.Text, txtbuscaraltura.Text);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                drUsuario_actual = frm.usuario_e;
                idUsuario = Convert.ToInt32(drUsuario_actual["id"]);
                ComenzarCarga();
            }
        }

        private void Guardar()
        {
            if (ValidarUsuario())
            {
                try
                {
                    idProvincia = Convert.ToInt32(dtLocalidades.Select(String.Format("id={0}", cboLocalidades.SelectedValue))[0]["id_provincias"]);
                    if (codigoPostal == String.Empty)
                        codigoPostal = "0";

                    oUsuarios.Id = 0;
                    if (idUsuario > 0)
                        oUsuarios.Id = idUsuario;
                    oUsuarios.Nombre = txtNombre.Text;
                    oUsuarios.Apellido = txtApellido.Text;
                    oUsuarios.Id_Usuarios_TipoDoc = Convert.ToInt32(cboTipoDNI.SelectedValue);
                    oUsuarios.Numero_Documento = Convert.ToDouble(txtDNI.Text);
                    oUsuarios.Id_Comprobantes_Iva = Convert.ToInt32(cboCondicionIVALocFiscal.SelectedValue);
                    if (txtCuitLocFiscal.Text != String.Empty)
                        oUsuarios.CUIT = Convert.ToDouble(txtCuitLocFiscal.Text.Replace("-", string.Empty));
                    else
                        oUsuarios.CUIT = 0;
                    oUsuarios.Nacimiento = dtpFechaNacimiento.Value;
                    oUsuarios.Id_Usuarios_Profesiones = Convert.ToInt32(cboProfesion.SelectedValue);
                    oUsuarios.Correo_Electronico = txtCorreo.Text;
                    oUsuarios.Adhesion_FacDigital = (chkAdhesionFacturaElec.Checked == true) ? 1 : 0;
                    oUsuarios.Id_Usuarios_Tipos = Convert.ToInt32(cboTipoUsuario.SelectedValue);
                    oUsuarios.Debito_Automatico = (chkDebitoAutomatico.Checked == true) ? 1 : 0;
                    oUsuarios.Calculo_Bonificacion = cboCalculoBonificaciones.SelectedIndex;
                    oUsuarios.Id = oUsuarios.Guardar(oUsuarios);

                    if ((idUsuario > 0 && dtLocacionFiscal.Rows.Count > 0) || idUsuario == 0)
                    {

                        oUsuarioLocacion.Id = 0;
                        if (idLocacionServicios > 0)
                            oUsuarioLocacion.Id = idLocacionServicios;
                        oUsuarioLocacion.Id_Usuarios = oUsuarios.Id;
                        oUsuarioLocacion.Id_Localidades = Convert.ToInt32(cboLocalidades.SelectedValue);
                        oUsuarioLocacion.Id_Provincias = idProvincia;
                        oUsuarioLocacion.Id_Calle = idCalle;
                        oUsuarioLocacion.Calle = txtCalle.Text;
                        oUsuarioLocacion.Altura = Convert.ToInt32(txtAltura.Text);
                        oUsuarioLocacion.Piso = txtPiso.Text;
                        oUsuarioLocacion.Depto = txtDepto.Text;
                        oUsuarioLocacion.Codigo_Postal = codigoPostal;
                        oUsuarioLocacion.id_manzana = 0;
                        oUsuarioLocacion.Manzana = String.Empty;
                        oUsuarioLocacion.Parcela = String.Empty;
                        oUsuarioLocacion.Id_Calle_Entre_1 = 0;
                        oUsuarioLocacion.Id_Calle_Entre_2 = 0;
                        oUsuarioLocacion.Entre_Calle_1 = txtCalleEntre1.Text;
                        oUsuarioLocacion.Entre_Calle_2 = txtCalleEntre2.Text;
                        oUsuarioLocacion.Observacion = String.Empty;
                        oUsuarioLocacion.Activo = Convert.ToInt32(Usuarios_Locaciones.Locacion_Estados.ACTIVA);
                        oUsuarioLocacion.Tipo = String.Empty;
                        if (txtPrefijo1.Text != String.Empty)
                            oUsuarioLocacion.Prefijo_1 = Convert.ToInt32(txtPrefijo1.Text);
                        else
                            oUsuarioLocacion.Prefijo_1 = 0;
                        if (txtTelFijo.Text != String.Empty)
                            oUsuarioLocacion.Telefono_1 = Convert.ToInt32(txtTelFijo.Text);
                        else
                            oUsuarioLocacion.Telefono_1 = 0;
                        if (txtPrefijo2.Text != String.Empty)
                            oUsuarioLocacion.Prefijo_2 = Convert.ToInt32(txtPrefijo2.Text);
                        else
                            oUsuarioLocacion.Prefijo_2 = 0;
                        if (txtCelular.Text != String.Empty)
                            oUsuarioLocacion.Telefono_2 = Convert.ToInt32(txtCelular.Text);
                        else
                            oUsuarioLocacion.Telefono_2 = 0;
                        if (txtObservacion.Text != String.Empty)
                            oUsuarioLocacion.Observacion = txtObservacion.Text;
                        else
                            oUsuarioLocacion.Observacion = String.Empty;
                        oUsuarioLocacion.Id = oUsuarioLocacion.Guardar(oUsuarios.Id, oUsuarioLocacion);

                        oUsuarioDomFiscal.Id = 0;
                        if (idLocacionFiscal > 0)
                            oUsuarioDomFiscal.Id = idLocacionFiscal;
                        oUsuarioDomFiscal.Id_Usuarios = oUsuarios.Id;
                        oUsuarioDomFiscal.R_Social = txtRSocial.Text;
                        oUsuarioDomFiscal.Id_Usuarios_TipoDoc = oUsuarios.Id_Usuarios_TipoDoc;
                        oUsuarioDomFiscal.Numero_Documento = oUsuarios.Numero_Documento;
                        oUsuarioDomFiscal.Calle = txtCalle.Text;
                        oUsuarioDomFiscal.Altura = Convert.ToInt32(txtAltura.Text);
                        oUsuarioDomFiscal.Piso = txtPiso.Text;
                        oUsuarioDomFiscal.Depto = txtDepto.Text;
                        oUsuarioDomFiscal.Codigo_Postal = codigoPostal;
                        oUsuarioDomFiscal.Cuit = oUsuarios.CUIT;
                        oUsuarioDomFiscal.idCondicionIva = oUsuarios.Id_Comprobantes_Iva;
                        oUsuarioDomFiscal.idLocacionAsociada = oUsuarioLocacion.Id;
                        oUsuarioDomFiscal.Guardar(oUsuarioDomFiscal);
                    }
                    MessageBox.Show("Operación realizada correctamente.");
                    if (Recibido == 1)
                        this.DialogResult = DialogResult.OK;
                    LimpiarDatos();
                    Controles(false);
                }
                catch
                {
                    MessageBox.Show("Se produjo un error al guardar los datos.");
                }
            }
        }

        private bool ValidarUsuario()
        {
            bool resultado = true;
            DialogResult dialogResult;

            if (txtCorreo.Text.Length > 0 && oTools.ComprobarFormatoEmail(txtCorreo.Text) == false)
            {
                resultado = false;
                MessageBox.Show("El correo electrónico no está escrito correctamente. Ejemplo: mi@mail.com.");
                txtCorreo.Focus();
                return resultado;
            }

            if ((idUsuario > 0 && dtLocacionFiscal.Rows.Count > 0) || idUsuario == 0)
            {
                foreach (Control control in this.Controls)
                {
                    if (control is TextBox && control.Tag != null && control.Tag.ToString() != "CamposNoObligatorios" && control.Name != "txtbuscaraltura" && control.Name != "txtbusca" && control.Text == String.Empty)
                    {
                        resultado = false;
                        MessageBox.Show("Hay campos en blanco. Por favor complete la información.");
                        control.Focus();
                        break;
                    }
                }
                if (resultado == false)
                    return resultado;

                if (chkAdhesionFacturaElec.Checked == true)
                {
                    if (txtCorreo.Text.Length == 0)
                    {
                        resultado = false;
                        MessageBox.Show("Eligió la opción adhesión a factura digital, por lo que debe ingresar un correo electrónico.");
                        txtCorreo.Focus();
                        return resultado;
                    }
                }

                if (Convert.ToInt32(cboCondicionIVALocFiscal.SelectedValue) != Convert.ToInt32(Comprobantes_Iva.Tipo.CONSUMIDOR_FINAL))
                {
                    if (txtCuitLocFiscal.Text.Length == 0)
                    {
                        resultado = false;
                        MessageBox.Show("Eligió una condición de IVA distinta a CONSUMIDOR FINAL, por lo que debe ingresar un Cuit.");
                        txtCuitLocFiscal.Focus();
                    }
                    else
                    {
                        if (oTools.ValidaCuit(txtCuitLocFiscal.Text) == false)
                        {
                            resultado = false;
                            MessageBox.Show("El Cuit ingresado no es correcto. Controle el número de cuit ingresado y el formato.");
                            txtCuitLocFiscal.Focus();
                        }
                    }

                    if (txtRSocial.Text.Length == 0)
                    {
                        resultado = false;
                        MessageBox.Show("Eligió una condición de IVA distinta a CONSUMIDOR FINAL, por lo que debe ingresar una razón social.");
                        txtRSocial.Focus();
                    }

                    if (resultado == false)
                        return resultado;
                }

                if (ControlAlturaCalle(Convert.ToInt32(txtAltura.Text), calleAlturaDesde, calleAlturaHasta) == false)
                {
                    resultado = false;
                    MessageBox.Show("La altura ingresada no se encuentra dentro del rango de numeración de la calle. Por favor, ingrese otra altura.");
                    txtAltura.Focus();
                    return resultado;
                }

                if (txtCelular.Text == String.Empty)
                {
                    dialogResult = MessageBox.Show("No ha ingresado un teléfono, ¿desea continuar de todos modos?", "", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                        resultado = true;
                    else
                    {
                        txtCelular.Focus();
                        return false;
                    }
                }
            }
            else
            {
                foreach (Control control in this.Controls)
                {
                    if (control is TextBox && control.Name == "txtapellido" && control.Name == "txtnombre" && control.Name == "txtcorreo" && control.Name == "txtdni" && control.Text == String.Empty)
                    {
                        resultado = false;
                        MessageBox.Show("Hay campos en blanco. Por favor complete la información.");
                        control.Focus();
                        break;
                    }
                }
                if (resultado == false)
                    return resultado;
            }

            if (txtCorreo.Text == String.Empty)
            {
                dialogResult = MessageBox.Show("No ha ingresado una dirección de correo electrónico, ¿desea continuar de todos modos?", "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                    resultado = true;
                else
                {
                    txtCorreo.Focus();
                    return false;
                }
            }
            return resultado;
        }

        private void BuscarCalle()
        {
            using (frmPopUp frmModal = new frmPopUp())
            {
                listLocalidades.Clear();
                listLocalidades.Add(Convert.ToInt32(cboLocalidades.SelectedValue));
                frmBusquedaCalles frm = new frmBusquedaCalles();
                frm.Id_Localidad = Convert.ToInt32(cboLocalidades.SelectedValue);
                frm.lista_id_localidades = listLocalidades;
                frmModal.Formulario = frm;

                if (frmModal.ShowDialog() == DialogResult.OK)
                {

                    txtCalle.Text = frm.Calle;
                    idCalle = Convert.ToInt32(frm.Id_Calle);
                    lblAltura.Text = String.Format("Altura Desde {0} Hasta {1}", frm.oCalles.Altura_Desde, frm.oCalles.Altura_Hasta);
                    calleAlturaDesde = frm.oCalles.Altura_Desde;
                    calleAlturaHasta = frm.oCalles.Altura_Hasta;
                }
                else
                {
                    txtCalle.Text = "";
                    idCalle = 0;
                    calleAlturaDesde = 0;
                    calleAlturaHasta = 0;
                }
            }
        }

        private bool ControlAlturaCalle(int alturaIngresada, int alturaDesde, int alturaHasta)
        {
            bool respuesta = true;
            if (!(alturaIngresada >= alturaDesde && alturaIngresada <= alturaHasta))
                respuesta = false;
            return respuesta;
        }

        #endregion

        #region CONTROLES
        public ABMUsuarios(int Id_Usuario_Recibido)
        {
            idUsuario = Id_Usuario_Recibido;
            InitializeComponent();
        }

        private void ABMUsuarios_Load(object sender, EventArgs e)
        {
            ComenzarCarga();
        }

        private void ABMUsuarios_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            LimpiarVariables();
            LimpiarDatos();
            Buscar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ComenzarCarga();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarDatos();
            LimpiarVariables();
            Controles(true);
            cboTipoUsuario.SelectedValue = Convert.ToInt32(dtTiposUsuario.Select(String.Format("tipo='cliente'"))[0]["id"]);
            cboTipoUsuario.Enabled = false;
            cboTipoDNI.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Controles(false);
            LimpiarDatos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idUsuario == 0)
                MessageBox.Show("No se ha seleccionado un usuario.");
            else
            {
                Controles(true);
                ControlLocacionFiscal();
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idUsuario == 0)
                MessageBox.Show("No se ha seleccionado un usuario.");
            else
            {
                ComenzarCarga();
                Controles(true);
            }
        }

        private void cboLocalidades_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                codigoPostal = dtLocalidades.Select("id={0}", cboLocalidades.SelectedValue.ToString())[0]["Codigo_Postal"].ToString();
                lblCodigoPostal.Text = String.Format("Código postal: {0}", codigoPostal);
            }
            catch
            {

            }
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void txtCorreo_Enter(object sender, EventArgs e)
        {
            if ((txtCorreo.ForeColor == Color.Black && txtCorreo.Text.Length == 0) || txtCorreo.ForeColor == Color.Gray)
            {
                txtCorreo.Text = String.Empty;
                txtCorreo.ForeColor = Color.Black;
            }
        }

        private void btnBuscarCalle_Click(object sender, EventArgs e)
        {
            BuscarCalle();
        }
    }
}
