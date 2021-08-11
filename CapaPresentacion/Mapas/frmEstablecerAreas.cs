using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocios;
using CapaNegocios.Mapas;

namespace CapaPresentacion.Mapas
{
    public partial class frmEstablecerAreas : Form
    {
        DataTable dtPoligonos = new DataTable();
        DataTable dtPersonalArea = new DataTable();
        DataTable dtPoligonosArea = new DataTable();

        Int32 idCurrentPoligono;

        Personal_Areas oPersonalAreas = new Personal_Areas();
        Poligono_Personal_Area oPoligonoPersonalArea = new Poligono_Personal_Area();
        public frmEstablecerAreas(DataTable dt)
        {
            InitializeComponent();
            this.dtPoligonos = dt;
        }

        private void frmEstablecerAreas_Load(object sender, EventArgs e)
        {
            dgvPoligonos.DataSource = dtPoligonos;
            dgvPoligonos.Columns["id"].Visible = false;
            dgvPoligonos.Columns["ST_AsText(puntos)"].Visible = false;
            dgvPoligonos.Columns["descripcion"].HeaderText = "SECTORES";

            dtPersonalArea = oPersonalAreas.Listar();
            dgvPersonalArea.DataSource = dtPersonalArea;
            dgvPersonalArea.Columns["id"].Visible = false;
            dgvPersonalArea.Columns["borrado"].Visible = false;
            dgvPersonalArea.Columns["req_horario"].Visible = false;
            dgvPersonalArea.Columns["nombre"].HeaderText = "AREAS";

            idCurrentPoligono = Convert.ToInt32(dgvPoligonos.SelectedRows[0].Cells["id"].Value);
            dtPoligonosArea = oPoligonoPersonalArea.Listar(idCurrentPoligono);
            dgvPoligonosArea.DataSource = dtPoligonosArea;
            dgvPoligonosArea.Columns["id_poligono"].Visible = false;
            dgvPoligonosArea.Columns["id_personal_area"].Visible = false;
            dgvPoligonosArea.Columns["nombre"].HeaderText = "AREAS ASIGNADAS";

            actualizarGrillas();

        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvPoligonos_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            idCurrentPoligono = Convert.ToInt32(dgvPoligonos.SelectedRows[0].Cells["id"].Value);
            dtPoligonosArea = oPoligonoPersonalArea.Listar(idCurrentPoligono);
            dgvPoligonosArea.DataSource = dtPoligonosArea;

            actualizarGrillas();

        }

        private void dgvPersonalArea_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int id_personal_area = Convert.ToInt32(dgvPersonalArea.SelectedRows[0].Cells["id"].Value);
            dgvPersonalArea.CurrentCell = null;
            oPoligonoPersonalArea.Guardar(idCurrentPoligono, id_personal_area);
            dtPoligonosArea = oPoligonoPersonalArea.Listar(idCurrentPoligono);
            dgvPoligonosArea.DataSource = dtPoligonosArea;
            actualizarGrillas();
        }

        private void actualizarGrillas()
        {
            for (int i = 0; i < dgvPersonalArea.Rows.Count; i++)
            {
                dgvPersonalArea.Rows[i].Visible = true;
            }

            for (int i = 0; i < dgvPersonalArea.Rows.Count; i++)
            {
                for (int j = 0; j < dgvPoligonosArea.Rows.Count; j++)
                {
                    if (dgvPoligonosArea.Rows[j].Cells["nombre"].Value.Equals(dgvPersonalArea.Rows[i].Cells["nombre"].Value))
                    {
                        dgvPersonalArea.Rows[i].Visible = false;
                    }
                }
            }
        }

        private void dgvPoligonosArea_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int id_personal_area = Convert.ToInt32(dgvPoligonosArea.SelectedRows[0].Cells["id_personal_area"].Value);
            dgvPoligonosArea.CurrentCell = null;
            oPoligonoPersonalArea.Eliminar(idCurrentPoligono, id_personal_area);
            dtPoligonosArea = oPoligonoPersonalArea.Listar(idCurrentPoligono);
            dgvPoligonosArea.DataSource = dtPoligonosArea;
            actualizarGrillas();
        }
    }
}
