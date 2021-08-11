using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;
using CapaNegocios;
using CapaPresentacion;

namespace CapaPresentacion
{
    public partial class frmEquiposEnStock : Form
    {
        private Thread hilo;
        private delegate void myDel();
        public DataTable dtEquiposEnStock = new DataTable();
        public int id_Equipo, id_Equipo_tipo;
        public string Descripcion;

        private void comenzarCarga()
        {
            dgv.DataSource = null;
            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
        }

        private void cargarDatos()
        {
            try
            {
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

            dgv.DataSource = dtEquiposEnStock;
            for (int i = 0; i < dgv.ColumnCount; i++)
                dgv.Columns[i].Visible = true;

            dgv.Columns["SERIE"].Visible = true;
            dgv.Columns["MAC"].Visible = true;
            dgv.Columns["TIPO_EQUIPO"].Visible = true;
            dgv.Columns["MARCA"].Visible = true;
            dgv.Columns["MODELO"].Visible = true;
            dgv.Columns["NUMERO_TARJETA"].Visible = true;
            dgv.Columns["id"].Visible = true;

            dgv.Columns["SERIE"].HeaderText = "Serie";
            dgv.Columns["MAC"].HeaderText = "MAC";
            dgv.Columns["TIPO_EQUIPO"].HeaderText = "Tipo Equipo";
            dgv.Columns["Marca"].HeaderText = "Marca";
            dgv.Columns["Modelo"].HeaderText = "Modelo";
            dgv.Columns["Numero_tarjeta"].HeaderText = "Tarjeta";


        }

        public frmEquiposEnStock()
        {
            InitializeComponent();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEquiposEnStock_Load(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            id_Equipo = Convert.ToInt32(dgv.SelectedRows[0].Cells["id"].Value);
            id_Equipo_tipo = Convert.ToInt32(dgv.SelectedRows[0].Cells["id_Equipos_Tipos"].Value);
            Descripcion = dgv.SelectedRows[0].Cells["TIPO_EQUIPO"].Value.ToString();
            this.Close();
        }
    }
}
