using CapaNegocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CapaPresentacion.Busquedas
{
    public partial class frmBusquedaLocalidades : Form
    {
        private int idZona = 0;
        private string nombreZona;
        private string nombreItem;
        public List<int> listaLocalidadesSeleccionadas = new List<int>();
        private Zonas oZonas = new Zonas();
        private DataTable dtLocalidades = new DataTable();

        public frmBusquedaLocalidades(int idZona, string nombreZona, string item)
        {
            this.idZona = idZona;
            this.nombreZona = nombreZona;
            nombreItem = item;
            InitializeComponent();
        }

        private void frmBusquedaLocalidades_Load(object sender, EventArgs e)
        {
            dtLocalidades = oZonas.ListarLocZonas(idZona);
            dtLocalidades.Columns.Add("seleccionar", typeof(bool));
            if (dtLocalidades.Rows.Count > 0)
            {
                foreach (DataRow localidad in dtLocalidades.Rows)
                    localidad["seleccionar"] = true;
            }
            dgvLocalidades.DataSource = dtLocalidades;
            for (int x = 0; x < dgvLocalidades.ColumnCount; x++)
                dgvLocalidades.Columns[x].Visible = false;
            dgvLocalidades.Columns["localidad"].Visible = true;
            dgvLocalidades.Columns["seleccionar"].Visible = true;
            dgvLocalidades.Columns["localidad"].HeaderText = "Localidad";
            dgvLocalidades.Columns["seleccionar"].HeaderText = "Seleccionar";
            dgvLocalidades.Columns["seleccionar"].Width = 80;
            dgvLocalidades.ReadOnly = false;
            dgvLocalidades.Columns["localidad"].ReadOnly = true;
            dgvLocalidades.Columns["seleccionar"].ReadOnly = false;
            lblItemSeleccionado.Text = nombreItem;
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            listaLocalidadesSeleccionadas.Clear();
            foreach (DataRow localidad in dtLocalidades.Rows)
            {
                if (Convert.ToBoolean(localidad["seleccionar"]))
                    listaLocalidadesSeleccionadas.Add(Convert.ToInt32(localidad["id_localidad"]));
            }

            if (listaLocalidadesSeleccionadas.Count > 0)
            {
                if (listaLocalidadesSeleccionadas.Count() == dtLocalidades.Rows.Count)
                    listaLocalidadesSeleccionadas.Clear();
                this.DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show("No ha seleccionado ninguna localidad. Debe seleccionar al menos una.");
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
