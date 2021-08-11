using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CapaNegocios;
using System.Threading;

namespace CapaPresentacion.Informes
{
    public partial class frmInformeEquipos_Estados : Form
    {
        #region PROPIEDADES
        private Thread hilo;
        private delegate void myDel();
        DataTable dtEquipos_Estados;
        Equipos_Estados oEqui_Estados = new Equipos_Estados();
        int Cantidad = 0;
        #endregion

        public frmInformeEquipos_Estados()
        {
            InitializeComponent();
        }


        #region METODOS
        private void comenzarCarga()
        {
            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
        }

        private void cargarDatos()
        {
            try
            {
                dtEquipos_Estados = oEqui_Estados.Listar_EstadosEnStock();
                myDel MD = new myDel(asignarDatos);
                this.Invoke(MD, new object[] { });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Informacion" + ex.Message);
            }
        }

        private void asignarDatos()
        {
            
            foreach(DataRow drEquipo in dtEquipos_Estados.Rows)
            {
                Cantidad = Cantidad + Convert.ToInt32(drEquipo["Cantidad"]);          
            }
            dtEquipos_Estados.Rows.Add(0,"Total", Convert.ToString(Cantidad), "");
            dgv_Stock_Estados.DataSource = dtEquipos_Estados;
            foreach (DataGridViewColumn item in dgv_Stock_Estados.Columns)
                item.Visible = false;

            dgv_Stock_Estados.Columns["Estado"].Visible = true;
            dgv_Stock_Estados.Columns["Cantidad"].Visible = true;
            dgv_Stock_Estados.Columns["Tipo"].Visible = true;
            dgv_Stock_Estados.Columns["Tipo"].HeaderText = "Tipo";
            dgv_Stock_Estados.Columns["Estado"].HeaderText = "Estado";
            dgv_Stock_Estados.Columns["Cantidad"].HeaderText = "Cantidad";
        }


        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmInformeEquipos_Estados_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void frmInformeEquipos_Estados_Load(object sender, EventArgs e)
        {
            comenzarCarga();
        }
        #endregion

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgv_Stock_Estados.Rows.Count > 0)
            {
                Tools tools = new Tools();
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    tools.ExportToExcel(dgv_Stock_Estados, "Deudas usuarios");
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al exportar a excel");
                }
                finally { this.Cursor = Cursors.Default; }
            }
            else
                MessageBox.Show("Grilla vacia");
        }
    }
}
