using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CapaNegocios;

namespace CapaPresentacion.Busquedas
{
    public partial class frmAvisosTipos : Form
    {
        private Usuarios_Avisos oUsuariosAvisos = new Usuarios_Avisos();
        DataTable dt = new DataTable();
        public string mensaje = "";
        public frmAvisosTipos()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dt = oUsuariosAvisos.ListarMensajesServicios();
            dgvTiposAvisos.DataSource = dt;
            dgvTiposAvisos.Columns["id"].Visible = false;
            dgvTiposAvisos.Columns["id_Servicio"].Visible = false;
            dgvTiposAvisos.Columns["borrado"].Visible = false;
            dgvTiposAvisos.Columns["detalle"].HeaderText = "Tipo de aviso";



        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if(dgvTiposAvisos.SelectedRows.Count>0)
            {
                mensaje = dgvTiposAvisos.SelectedRows[0].Cells["detalle"].Value.ToString();
                this.DialogResult = DialogResult.OK;

            }
        }

        private void dgvTiposAvisos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTiposAvisos.SelectedRows.Count > 0)
            {
                mensaje = dgvTiposAvisos.SelectedRows[0].Cells["detalle"].Value.ToString();
                this.DialogResult = DialogResult.OK;

            }
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAvisosTipos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
