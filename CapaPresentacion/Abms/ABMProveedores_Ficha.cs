using CapaNegocios;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacion.Abms
{
    public partial class ABMProveedores_Ficha : Form
    {
        public DataRow DataRow;
        private Proveedores oProveedor = new Proveedores();
        private Comprobantes_Iva oIva = new Comprobantes_Iva();

        public ABMProveedores_Ficha()
        {
            InitializeComponent();
        }

        private void ABMProveedores_Ficha_Load(object sender, EventArgs e)
        {
            cboCondicion_Iva.DataSource = oIva.Listar();
            cboCondicion_Iva.ValueMember = "Id";
            cboCondicion_Iva.DisplayMember = "Descripcion";

            if (this.DataRow != null)
            {
                oProveedor.Id = Convert.ToInt32(this.DataRow["Id"]);

                txtRSocial.Text = this.DataRow["Razon_Social"].ToString();
                cboCondicion_Iva.SelectedValue = this.DataRow["Id_Comprobantes_Iva"];
                txtCuit.Text = this.DataRow["Cuit"].ToString();
                txtDomicilio.Text = this.DataRow["Domicilio"].ToString();

                txtPrefijo_1.Text = this.DataRow["Prefijo_1"].ToString();
                txtTelefono_1.Text = this.DataRow["Telefono_1"].ToString();
                txtPrefijo_2.Text = this.DataRow["Prefijo_2"].ToString();
                txtTelefono_2.Text = this.DataRow["Telefono_2"].ToString();

                txtContacto.Text = this.DataRow["Contacto"].ToString();
                txtEmail.Text = this.DataRow["Email"].ToString();
                txtPaginaWeb.Text = this.DataRow["Web"].ToString();
                txtObservaciones.Text = this.DataRow["Observacion"].ToString();

            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            oProveedor.Razon_Social = txtRSocial.Text.Trim();
            oProveedor.Id_Comprobantes_Iva = Convert.ToInt32(cboCondicion_Iva.SelectedValue);
            oProveedor.Cuit = txtCuit.Text.Trim();
            oProveedor.Domicilio = txtDomicilio.Text.Trim();
            oProveedor.Prefijo_1 = txtPrefijo_1.Text == string.Empty ? 0 : Convert.ToDecimal(txtPrefijo_1.Text.Trim());
            oProveedor.Telefono_1 = txtTelefono_1.Text == string.Empty ? 0 : Convert.ToDecimal(txtTelefono_1.Text.Trim());
            oProveedor.Prefijo_2 = txtPrefijo_2.Text == string.Empty ? 0 : Convert.ToDecimal(txtPrefijo_2.Text.Trim());
            oProveedor.Telefono_2 = txtTelefono_2.Text == string.Empty ? 0 : Convert.ToDecimal(txtTelefono_2.Text.Trim());
            oProveedor.Contacto = txtContacto.Text.Trim();
            oProveedor.Email = txtEmail.Text.Trim();
            oProveedor.Web = txtPaginaWeb.Text.Trim();
            oProveedor.Observacion = txtObservaciones.Text.Trim();

            oProveedor.Guardar(oProveedor);

            this.DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void ABMProveedores_Ficha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.DialogResult = DialogResult.Cancel;
        }



    }
}
