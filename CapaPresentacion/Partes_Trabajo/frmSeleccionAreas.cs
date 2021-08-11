using CapaNegocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacion.Partes_Trabajo
{
    public partial class frmSeleccionAreas : Form
    {
        public List<Int32> listaAreasAgregar = new List<int>();

        DataTable dtAreas = new DataTable();
        Personal_Areas oPersonalAreas = new Personal_Areas();

        public frmSeleccionAreas()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSeleccionAreas_Load(object sender, EventArgs e)
        {
            try
            {
                dtAreas = oPersonalAreas.Listar();
                dgvAreas.DataSource = dtAreas;
                dgvAreas.Columns["id"].Visible = false;
                dgvAreas.Columns["borrado"].Visible = false;
                dgvAreas.Columns["req_horario"].Visible = false;

                int control = 0;
                foreach (DataGridViewColumn columna in dgvAreas.Columns)
                {
                    if (columna.Name == "colSeleccionArea")
                        control = 1;
                }

                if (control == 1)
                    dgvAreas.Columns.RemoveAt(dgvAreas.Columns["colSeleccionArea"].Index);

                DataGridViewCheckBoxColumn colSeleccionArea = new DataGridViewCheckBoxColumn();
                colSeleccionArea.Name = "colSeleccionArea";

                dgvAreas.Columns.Add(colSeleccionArea);

                dgvAreas.Columns["colSeleccionArea"].HeaderText = "";
                dgvAreas.Columns["colSeleccionArea"].Width = 30;
                dgvAreas.Columns["Nombre"].ReadOnly = true;



                lblTotal.Text = String.Format("Total de Registros: {0}", dtAreas.Rows.Count);

            }
            catch
            {
                MessageBox.Show("Error al cargar áreas.");
            }
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            if (dgvAreas.Rows.Count > 0)
            {
                foreach (DataGridViewRow fila in dgvAreas.Rows)
                {
                    if (Convert.ToInt32(fila.Cells["colSeleccionArea"].Value) == 1)
                        listaAreasAgregar.Add(Convert.ToInt32(fila.Cells["id"].Value));
                }

                if (listaAreasAgregar.Count > 0)
                    this.DialogResult = DialogResult.OK;
                else
                    MessageBox.Show("No se han seleccionado áreas.");
            }
        }
    }
}
