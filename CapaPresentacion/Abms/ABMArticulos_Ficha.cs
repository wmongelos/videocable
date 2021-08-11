using CapaNegocios;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacion.Abms
{
    public partial class ABMArticulos_Ficha : Form
    {
        public DataRow DataRow;
        private Articulos oArticulos = new Articulos();
        private Articulos_Rubros oArticulos_Rubros = new Articulos_Rubros();

        public ABMArticulos_Ficha()
        {
            InitializeComponent();
        }

        private void ABMArticulos_Ficha_Load(object sender, EventArgs e)
        {
            cboArticulos_Rubros.DataSource = oArticulos_Rubros.Listar();
            cboArticulos_Rubros.ValueMember = "Id";
            cboArticulos_Rubros.DisplayMember = "Descripcion";

            if (this.DataRow != null)
            {
                oArticulos.Id = Convert.ToInt32(this.DataRow["Id"]);

                txtDescripcion.Text = this.DataRow["Descripcion"].ToString();
                cboArticulos_Rubros.SelectedValue = this.DataRow["Id_Articulos_Rubros"];
                spStock.Value = Convert.ToInt32(this.DataRow["Stock"].ToString());
                spStock_Minimo.Value = Convert.ToInt32(this.DataRow["Stock_Minimo"].ToString());
                spImporte.Value = Convert.ToDecimal(this.DataRow["Importe"].ToString());

            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            oArticulos.Descripcion = txtDescripcion.Text;
            oArticulos.Id_Productos_Rubros = Convert.ToInt32(cboArticulos_Rubros.SelectedValue);
            oArticulos.Stock = Convert.ToInt32(spStock.Value);
            oArticulos.Stock_Minimo = Convert.ToInt32(spStock_Minimo.Value);
            oArticulos.Importe = Convert.ToDecimal(spImporte.Value);

            oArticulos.Guardar(oArticulos);

            this.DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void ABMArticulos_Ficha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.DialogResult = DialogResult.Cancel;
        }

    }
}
