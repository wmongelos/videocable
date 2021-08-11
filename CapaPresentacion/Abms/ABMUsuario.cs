using CapaNegocios;
using System;
using System.Data;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;

namespace CapaPresentacion.Abms
{
    public partial class ABMUsuario : Form
    {
        public DataTable DataLocaciones = new DataTable();
        private Int32 Id_Usuarios_Locacion = 0;
        string cuit;
        decimal Porcentaje;
        Tools oTool = new Tools();
        DataTable dt_Percepciones_Esp = new DataTable();
        Usuarios oUsuario_Percepcion_Esp = new Usuarios();
        public ABMUsuario()
        {
            InitializeComponent();
        }

        private void ABMUsuario_Load(object sender, System.EventArgs e)
        {
            Id_Usuarios_Locacion = Usuarios.CurrentUsuario.Id_Usuarios_Locacion;

            Configuracion oConfiguracion = new Configuracion();

            cboTipoDNI.DataSource = Tablas.DataTipoDNI;
            cboTipoDNI.DisplayMember = "Tipo";
            cboTipoDNI.ValueMember = "Id";

            cboCondIVA.DataSource = Tablas.DataCondIVA;
            cboCondIVA.DisplayMember = "Descripcion";
            cboCondIVA.ValueMember = "Id";

            try
            {
                cboCalculoBonificaciones.SelectedIndex = Usuarios.CurrentUsuario.Calculo_Bonificacion;
            }
            catch
            {
                cboCalculoBonificaciones.SelectedIndex = oConfiguracion.GetValor_N("BonificacionUsuLoc");
            }

            try
            {
                dtpFechaNacimiento.Value = Convert.ToDateTime(Usuarios.CurrentUsuario.Nacimiento);
            }
            catch
            {
                dtpFechaNacimiento.Value = DateTime.Now;
            }


            txtNombre.Text = Usuarios.CurrentUsuario.Nombre; ;
            txtApellido.Text = Usuarios.CurrentUsuario.Apellido;
            txtNumero.Text = Usuarios.CurrentUsuario.Numero_Documento.ToString();
            txtCUIT.Text = Usuarios.CurrentUsuario.CUIT.ToString();
            txtCorreo.Text = Usuarios.CurrentUsuario.Correo_Electronico;
            chkAdhesionFacturaElec.CheckState = Usuarios.CurrentUsuario.Adhesion_FacDigital == 1 ? CheckState.Checked : CheckState.Unchecked;
            chkDebitoAutomatico.CheckState = Usuarios.CurrentUsuario.Debito_Automatico == 1 ? CheckState.Checked : CheckState.Unchecked;
            spImpuestoProv.Value = Usuarios.CurrentUsuario.Impuesto_Provincial;
            chkExentoProv.CheckState = Usuarios.CurrentUsuario.Exento_Impuesto_Provincial == 1 ? CheckState.Checked : CheckState.Unchecked;

            cboCondIVA.SelectedValue = Usuarios.CurrentUsuario.Id_Comprobantes_Iva;
            cboTipoDNI.SelectedValue = Usuarios.CurrentUsuario.Id_Usuarios_TipoDoc;

            lblLocacion.Text = String.Format("{0}: {1} {2} Depto: {3} Piso: {4}", lblLocacion.Text, Usuarios.CurrentUsuario.Calle, Usuarios.CurrentUsuario.Altura, Usuarios.CurrentUsuario.Depto, Usuarios.CurrentUsuario.piso);

            txtCalle.Text = Usuarios.CurrentUsuario.Calle.ToString();
            txtAltura.Text = Usuarios.CurrentUsuario.Altura.ToString();
            txtPiso.Text = Usuarios.CurrentUsuario.piso.ToString();
            txtDepto.Text = Usuarios.CurrentUsuario.Depto.ToString();

            prefijo1.Text = Usuarios.CurrentUsuario.Prefijo_1.ToString();
            prefijo2.Text = Usuarios.CurrentUsuario.Prefijo_2.ToString();
            txtTel1.Text = Usuarios.CurrentUsuario.Telefono_1.ToString();
            txtTel2.Text = Usuarios.CurrentUsuario.Telefono_2.ToString();
            txtObservacion.Text = Usuarios.CurrentUsuario.Observacion;
            FormatearDgvEsp();
        }

        private Boolean ValidarUsuario()
        {
            errorIcon.Clear();

            if (txtApellido.Text.Trim() == String.Empty || txtNombre.Text.Trim() == String.Empty)
            {
                if (txtApellido.Text.Trim() == String.Empty)
                {
                    errorIcon.SetError(txtApellido, "Debe Ingresar el Apellido");
                    txtApellido.Focus();
                }
                else
                {
                    errorIcon.SetError(txtNombre, "Debe Ingresar el Nombre");
                    txtNombre.Focus();
                }
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

            return true;
        }



        private decimal DefinirPercepcion() 
        {

            decimal PercepcionDefinida = 0;
            if (dt_Percepciones_Esp.Rows.Count > 0)
            {
                DataTable dtDinamica = new DataTable();
                dtDinamica.Clear();
                dtDinamica = oUsuario_Percepcion_Esp.ObtenerPercepcionEspecialActual(Usuarios.CurrentUsuario.Id);
                if (dtDinamica.Rows.Count > 0)
                    PercepcionDefinida = Convert.ToDecimal(dtDinamica.Rows[0]["percepcion_esp"].ToString());
                else
                    PercepcionDefinida = Convert.ToDecimal(spImpuestoProv.Value);
            }
            else
                PercepcionDefinida = Convert.ToDecimal(spImpuestoProv.Value);
            return PercepcionDefinida;
        }
        private void FormatearDgvEsp() 
        {
            dt_Percepciones_Esp = oUsuario_Percepcion_Esp.Listar_PercepcionesEsp(Usuarios.CurrentUsuario.Id);
            dgvEspeciales.DataSource = dt_Percepciones_Esp;

            for (int i = 0; i < dgvEspeciales.ColumnCount; i++)
                dgvEspeciales.Columns[i].Visible = false;

            dgvEspeciales.Columns["desde"].Visible = true;
            dgvEspeciales.Columns["hasta"].Visible = true;
            dgvEspeciales.Columns["percepcion_esp"].Visible = true;
            dgvEspeciales.Columns["nombre"].Visible = true;

            dgvEspeciales.Columns["desde"].HeaderText = "Desde";
            dgvEspeciales.Columns["hasta"].HeaderText = "Hasta";
            dgvEspeciales.Columns["percepcion_Esp"].HeaderText = "Percepcion";
            dgvEspeciales.Columns["nombre"].HeaderText = "Personal";

        }

        private void ABMUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.DialogResult = DialogResult.Cancel;
        }

        private void imgReturn_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnAgregarLocacionFiscal_Click(object sender, System.EventArgs e)
        {
            using (frmPopUp frm = new frmPopUp())
            {
                ABMLocaciones_Fiscales frmFiscal = new ABMLocaciones_Fiscales(Usuarios.CurrentUsuario.Id);
                frm.Maximizar = false;
                frm.Formulario = frmFiscal;

                frm.ShowDialog();
            }
        }

        private void btnGuardar_Click(object sender, System.EventArgs e)
        {
            if (MessageBox.Show("¿Desea Guardar los cambios realizados?", "Mensaje del Sistema",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (this.ValidarUsuario())
                {
                    Usuarios oUsuario = new Usuarios();
                    oUsuario.Id = Usuarios.CurrentUsuario.Id;
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
                    oUsuario.Impuesto_Provincial = Convert.ToDecimal(spImpuestoProv.Value);
                    //oUsuario.Impuesto_Provincial = DefinirPercepcion();
                    oUsuario.Exento_Impuesto_Provincial = chkExentoProv.CheckState == CheckState.Checked ? 1 : 0;
                    oUsuario.Codigo = Usuarios.CurrentUsuario.Codigo;
                    oUsuario.Id_Usuarios_Tipos = Usuarios.CurrentUsuario.Id_Usuarios_Tipos;
                    if (oUsuario.Id_Comprobantes_Iva == 1)
                    {
                        spImpuestoProv.Value = 0;
                        oUsuario.Impuesto_Provincial = spImpuestoProv.Value;
                    }
                    oUsuario.Guardar(oUsuario);

                    Usuarios_Locaciones oUsuariosLocaciones = new Usuarios_Locaciones();
                    if (prefijo1.Text == "" || txtTel1.Text == "")
                    {
                        prefijo1.Text = "0";
                        txtTel1.Text = "0";
                    }
                    if (prefijo2.Text == "" || txtTel2.Text == "")
                    {
                        prefijo2.Text = "0";
                        txtTel2.Text = "0";
                    }
                    oUsuariosLocaciones.ActualizarDatosLocacion(Id_Usuarios_Locacion, Convert.ToInt32(prefijo1.Text), Convert.ToDouble(txtTel1.Text), Convert.ToInt32(prefijo2.Text), Convert.ToDouble(txtTel2.Text), txtObservacion.Text, Convert.ToInt32(txtAltura.Text), txtPiso.Text, txtDepto.Text);


                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private void btnCancelar_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void chkExentoProv_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExentoProv.Checked == true)
            {
                spImpuestoProv.Value = 0;
                spImpuestoProv.Enabled = false;
            }
            else
            {
                spImpuestoProv.Enabled = true;
            }

        }

        private void btnPercepcion_Click(object sender, EventArgs e)
        {
            if (txtCUIT.Text != "")
            {
                cuit = txtCUIT.Text;
                Porcentaje = oTool.NuevoAbonadoPADRONARBA(cuit);
                spImpuestoProv.Value = Porcentaje;
            }
            else
                MessageBox.Show("Ingrese un cuit.");

        }

        private void btnEspeciales_Click(object sender, EventArgs e)
        {
            DataTable dtDinamica = new DataTable();
            dtDinamica.Clear();
            int Id_Usuario;
            string Cuit, Numero_Tramite;
            DateTime desde, hasta, hastaVerif;
            decimal PercepcionEsp = 0;
            Numero_Tramite = txtTramite.Text.ToString();
            Id_Usuario = Usuarios.CurrentUsuario.Id;
            Cuit = txtCUIT.Text.ToString();
            desde = dtpDesde.Value;
            hasta = dtpHasta.Value;
            PercepcionEsp = Convert.ToDecimal(spnEspecial.Value);
            dtDinamica = oUsuario_Percepcion_Esp.VerificarUltimaPercepcionEsp(Id_Usuario);
            if (txtTramite.Text == "")
                MessageBox.Show("Debe seleccionar un numero de Tramite valido.");
            else
            { 
                if(dtDinamica.Rows.Count > 0) 
                {             
                    hastaVerif = Convert.ToDateTime(dtDinamica.Rows[0]["hasta"].ToString()).Date;
                    if (dtpDesde.Value.Date <= hastaVerif)
                        MessageBox.Show("La fecha desde se superpone con la ultima actualizacion de Percepcion de este usuario. \n La misma debe ser mayor a : " + hastaVerif.ToString());
                    else
                    {
                        if (dtpDesde.Value.Date >= dtpHasta.Value.Date)
                            MessageBox.Show("La fecha desde no puede ser mayor o igual a la fecha hasta, reconfigure las fechas.");
                        else
                            oUsuario_Percepcion_Esp.GuardarPercepcionEspeciales(desde, hasta, Id_Usuario, PercepcionEsp, Cuit,Numero_Tramite);
                    }
                }
                else
                    oUsuario_Percepcion_Esp.GuardarPercepcionEspeciales(desde, hasta, Id_Usuario, PercepcionEsp, Cuit,Numero_Tramite);
            }
            FormatearDgvEsp();
        }
    }
}
