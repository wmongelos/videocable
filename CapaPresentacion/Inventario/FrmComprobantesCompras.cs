using System;
using System.Windows.Forms;

namespace CapaPresentacion.Inventario
{
    public partial class FrmComprobantesCompras : Form
    {
        private FrmAgregarArticulos oAgregarArticulos = new FrmAgregarArticulos();
        private FrmAgregarEquipos oAgregarEquipos = new FrmAgregarEquipos();

        public FrmComprobantesCompras()
        {
            InitializeComponent();
        }

        private void combo1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoInventario.SelectedIndex == 0) //Articulos
            {
                if (pnlFondo.Controls.Count == 0 || !pnlFondo.Controls[0].Equals(oAgregarArticulos.GetPanel()))
                {
                    pnlFondo.Controls.Clear();
                    pnlFondo.Controls.Add(oAgregarArticulos.GetPanel());
                }
            }
            else if (cboTipoInventario.SelectedIndex == 1) //Equipos
            {
                if (pnlFondo.Controls.Count == 0 || !pnlFondo.Controls[0].Equals(oAgregarEquipos.GetPanel()))
                {
                    pnlFondo.Controls.Clear();
                    pnlFondo.Controls.Add(oAgregarEquipos.GetPanel());
                }
            }
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmComprobantesCompras_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

    }
}
