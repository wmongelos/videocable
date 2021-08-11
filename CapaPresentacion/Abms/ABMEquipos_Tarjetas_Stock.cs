using CapaNegocios;
using System;
using System.Data;

using System.Windows.Forms;

namespace CapaPresentacion.Abms
{
    public partial class ABMEquipos_Tarjetas_Stock : Form
    {
        public Int32 Id_Equipos_Tipos;
        public Int32 Id_Estado;

        private DataTable dt = new DataTable();

        public ABMEquipos_Tarjetas_Stock()
        {
            dt.Columns.Add("Tarjeta", typeof(String));

            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtNroTarjeta.Text.ToLower() != String.Empty)
            {
                dt.Rows.Add(txtNroTarjeta.Text);

                txtNroTarjeta.Text = "";
                txtNroTarjeta.Focus();
            }
            else
                txtNroTarjeta.Focus();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvStock.SelectedRows.Count > 0)
                dgvStock.Rows.Remove(dgvStock.SelectedRows[0]);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    Equipos_Tarjetas oEquiposTarjetas = new Equipos_Tarjetas();

                    oEquiposTarjetas.Id = 0;
                    oEquiposTarjetas.Numero = item["Tarjeta"].ToString();
                    oEquiposTarjetas.Id_Equipos_Tipos = this.Id_Equipos_Tipos;
                    oEquiposTarjetas.Id_Estado = this.Id_Estado;

                    oEquiposTarjetas.Guardar(oEquiposTarjetas);
                }

                this.DialogResult = DialogResult.OK;
            }
            else
                txtNroTarjeta.Focus();
        }

        private void ABMEquipos_Tarjetas_Stock_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void ABMEquipos_Tarjetas_Stock_Load(object sender, EventArgs e)
        {
            dgvStock.DataSource = dt;
        }
    }
}
