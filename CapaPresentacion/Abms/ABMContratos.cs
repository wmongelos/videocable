using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using CapaNegocios;


namespace CapaPresentacion.Abms
{
   
    public partial class ABMContratos : Form
    {
        private Contrato oContrado = new Contrato();
        private DataTable dtContratos = new DataTable();
        private Thread hilo;
        private delegate void myDel();
        public bool Seleccionar = false;
        public Int32 IdContrato = 0;

        #region METODOS
        private void comenzarCarga()
        {
            pgCircular.Start();
            dgvContratos.DataSource = null;
            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
        }

        private void cargarDatos()
        {
            try
            {
                dtContratos = oContrado.Listar();
                myDel MD = new myDel(asignarDatos);
                this.Invoke(MD, new object[] { });
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
            }
            pgCircular.Stop();
        }

        private void asignarDatos()
        {
            pnlBotones.Visible = !Seleccionar;
            pnlSeleccion.Visible = Seleccionar;

            dgvContratos.DataSource = dtContratos;
        }

        #endregion
        public ABMContratos()
        {
            InitializeComponent();
        }

        private void ABMContratos_Load(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if(dgvContratos.SelectedRows.Count>0)
            {
                IdContrato = Convert.ToInt32(dgvContratos.SelectedRows[0].Cells["id"].Value);
                this.DialogResult = DialogResult.OK;
            }
        }

        private void dgvContratos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(Seleccionar)
            {
                IdContrato = Convert.ToInt32(dgvContratos.SelectedRows[0].Cells["id"].Value);
                this.DialogResult = DialogResult.OK;
            }
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ABMContratos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
