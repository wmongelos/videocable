using CapaNegocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Cuenta_Corriente
{
    public partial class frmListarIncongruenciasPunitorios : Form
    {
        private Thread hilo;
        private delegate void myDel();
        private DataTable dtIncongruencias;

        public frmListarIncongruenciasPunitorios()
        {
            InitializeComponent();
        }

        private void ComenzarCarga()
        {
            this.UseWaitCursor = true;

            dgv.DataSource = null;

            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
        }

        private void cargarDatos()
        {
            try
            {
                dtIncongruencias = new Punitorio().ListarIncongruencias();
                myDel MD = new myDel(asignarDatos);
                this.Invoke(MD, new object[] { });

                this.UseWaitCursor = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Informacion" + ex.Message);
            }
        }

        private void asignarDatos()
        {
            dgv.DataSource = dtIncongruencias;

            foreach (DataGridViewColumn col in dgv.Columns)
            {
                col.Visible = false;
            }

            dgv.Columns["codigo"].Visible = true;
            dgv.Columns["codigo"].HeaderText = "Codigo";
            dgv.Columns["descripcion"].Visible = true;
            dgv.Columns["descripcion"].HeaderText = "Descripcion";

            lblRegistros.Text = $"Cantidad de registros: {dtIncongruencias.Rows.Count}";
        }

        private void frmListarIncongruenciasPunitorios_Load(object sender, EventArgs e)
        {
            ComenzarCarga();
        }

        private void dgv_DoubleClick(object sender, EventArgs e)
        {
            frmMain frm = frmMain.Instance();
            frm.openForm(new frmUsuariosCtaCteConsultaNuevo(Convert.ToInt32(dgv.SelectedRows[0].Cells["id_usuarios"].Value), 0));
            this.Close();
        }

        private void txtBuscador_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtBuscador.Text))
            {
                dtIncongruencias.DefaultView.RowFilter = $"Codigo = {txtBuscador.Text}";
            }
            else
            {
                dtIncongruencias.DefaultView.RowFilter = "";
            }

            lblRegistros.Text = $"Cantidad de registros: {dtIncongruencias.DefaultView.Count}";
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListarIncongruenciasPunitorios_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
