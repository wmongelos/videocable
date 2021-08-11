using CapaNegocios;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacion.Abms
{
    public partial class ABMUsuarios_LocacionFiscal : Form
    {
        public string RSocial;
        public int Id_TipoDoc;
        public Double NumeroDoc;
        public string Docimilio;
        public int Altura;
        public string Piso;
        public string Depto;
        public string Codigo_Postal;
        public int idCondicionIVA;
        public Double Cuit;
        private Usuarios oUsuario = new Usuarios();
        private Comprobantes oComprobante = new Comprobantes();
        private Usuarios_Dom_Fiscal oDomFiscal = new Usuarios_Dom_Fiscal();
        private Localidades oLocalidades = new Localidades();
        private DataTable dtLocalidades = new DataTable();

        public ABMUsuarios_LocacionFiscal(int idUsuarioRecibido)
        {
            oUsuario.Id = idUsuarioRecibido;
            InitializeComponent();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            this.RSocial = txtRSocial.Text;
            this.idCondicionIVA = Convert.ToInt32(cboCondIVA.SelectedValue);
            this.Id_TipoDoc = 0;
            this.Cuit = Convert.ToDouble(txtCUIT.Text);
            this.Docimilio = txtCalle.Text;
            this.Altura = Convert.ToInt32(txtAltura.Text);
            this.Piso = txtPiso.Text;
            this.Depto = txtDepto.Text;
            this.Codigo_Postal = txtCP.Text;
            this.NumeroDoc = 0;

            if (oUsuario.Id > 0)
            {
                Usuarios_Dom_Fiscal oDomFiscal = new Usuarios_Dom_Fiscal();
                oDomFiscal.Id_Usuarios = oUsuario.Id;
                oDomFiscal.R_Social = this.RSocial;
                oDomFiscal.Id_Usuarios_TipoDoc = this.Id_TipoDoc;
                oDomFiscal.Cuit = this.Cuit;
                oDomFiscal.Calle = this.Docimilio;
                oDomFiscal.Altura = this.Altura;
                oDomFiscal.Piso = this.Piso;
                oDomFiscal.Depto = this.Depto;
                oDomFiscal.Codigo_Postal = this.Codigo_Postal;
                oDomFiscal.Numero_Documento = oUsuario.Numero_Documento;
                oDomFiscal.Id_Usuarios_TipoDoc = this.Id_TipoDoc;
                oDomFiscal.idCondicionIva = this.idCondicionIVA;

                oDomFiscal.Guardar(oDomFiscal);
            }

            this.DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void ABMLocacionF_Load(object sender, EventArgs e)
        {
            dtLocalidades = oLocalidades.Listar();


            if (oUsuario.Id == 0)
            {
                DataTable dtCompIVA = oComprobante.ListarTipoIVA();
                cboCondIVA.DataSource = dtCompIVA;
                cboCondIVA.DisplayMember = "Descripcion";
                cboCondIVA.ValueMember = "Id";
                cboCondIVA.SelectedIndex = 0;
            }
            else
            {
                DataTable dt = oDomFiscal.Listar(oUsuario.Id);
                oUsuario = oUsuario.traerUsuario(oUsuario.Id);
                if (dt.Rows.Count > 0)
                {
                    txtRSocial.Text = dt.Rows[0]["R_Social"].ToString();
                    cboCondIVA.SelectedValue = Convert.ToInt32(dt.Rows[0]["id_condicion_iva"]);
                    txtCUIT.Text = dt.Rows[0]["cuit"].ToString();
                    txtCalle.Text = dt.Rows[0]["R_Social"].ToString();
                    txtAltura.Text = dt.Rows[0]["Altura"].ToString();
                    txtPiso.Text = dt.Rows[0]["Piso"].ToString();
                    txtDepto.Text = dt.Rows[0]["Depto"].ToString();
                    txtCP.Text = dt.Rows[0]["Codigo_Postal"].ToString();
                    DataTable dtCompIVA = oComprobante.ListarTipoIVA();

                    cboCondIVA.DataSource = dtCompIVA;
                    cboCondIVA.DisplayMember = "Descripcion";
                    cboCondIVA.ValueMember = "Id";
                }


            }
        }

        private void ABMUsuarios_LocacionFiscal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
