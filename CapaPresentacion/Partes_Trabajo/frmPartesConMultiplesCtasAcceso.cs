using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CapaPresentacion.Partes_Trabajo
{
    public partial class frmPartesConMultiplesCtasAcceso : Form
    {
        private DataTable dtPartes = new DataTable();
        private string texto;

        public frmPartesConMultiplesCtasAcceso(DataTable dtPartes, string texto = "")
        {
            InitializeComponent();
            this.dtPartes = dtPartes;
            this.texto = texto;
        }

        private void frmPartesConMultiplesCtasAcceso_Load(object sender, EventArgs e)
        {
            dgvPartes.DataSource = dtPartes;
            foreach (DataGridViewColumn col in dgvPartes.Columns)
            {
                col.Visible = false;
            }

            dgvPartes.Columns["codUsuario"].Visible = true;
            dgvPartes.Columns["codUsuario"].HeaderText = "Codigo de usuario";
            dgvPartes.Columns["idParte"].Visible = true;
            dgvPartes.Columns["idParte"].HeaderText = "Parte";

            lblTexto.Text = texto;
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPartesConMultiplesCtasAcceso_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
