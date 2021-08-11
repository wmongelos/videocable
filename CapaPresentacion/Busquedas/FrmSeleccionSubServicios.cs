using CapaNegocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmSeleccionSubServicios : Form
    {
        private int id_servicio;
        private DataTable dtSubServicios;
        private List<int> idsSubServiciosSeleccionadosPreviamente;

        public List<int> idsSubServiciosSeleccionados { get; private set; } = new List<int>();
        public List<int> idsSubServiciosNoSeleccionados { get; private set; } = new List<int>();

        public FrmSeleccionSubServicios(int id_servicio, string titulo, List<int> idsSubServiciosSeleccionadosPreviamente = null)
        {
            InitializeComponent();
            this.id_servicio = id_servicio;
            this.idsSubServiciosSeleccionadosPreviamente = idsSubServiciosSeleccionadosPreviamente;
            this.lblTituloHeader.Text = titulo;
        }

        private void FrmSeleccionSubServicios_Load(object sender, EventArgs e)
        {
            CargarSubServicios();
        }

        private void CargarSubServicios()
        {
            Servicios_Sub oSub = new Servicios_Sub();
            dtSubServicios = oSub.ListarPorServicio(this.id_servicio);

            DataColumn colSel = new DataColumn("Seleccionar", typeof(Boolean))
            {
                DefaultValue = false
            };
            dtSubServicios.Columns.Add(colSel);

            dgvSubservicios.DataSource = dtSubServicios;
            for (int i = 0; i < dgvSubservicios.Columns.Count; i++)
                dgvSubservicios.Columns[i].Visible = false;

            dgvSubservicios.Columns["Descripcion"].Visible = true;
            dgvSubservicios.Columns["Seleccionar"].Visible = true;
            dgvSubservicios.Columns["Descripcion"].ReadOnly = true;
            dgvSubservicios.Columns["Seleccionar"].ReadOnly = false;

            foreach (DataRow dr in dtSubServicios.Rows)
            {
                if (idsSubServiciosSeleccionadosPreviamente != null)
                {
                    if (idsSubServiciosSeleccionadosPreviamente.Contains(Convert.ToInt32(dr["Id"])))
                        dr["Seleccionar"] = true;

                    dtSubServicios.AcceptChanges();
                }
            }
        }

        private void GuardarSubServicios()
        {
            foreach (DataRow row in dtSubServicios.Rows)
            {
                if (Convert.ToBoolean(row["Seleccionar"]))
                {
                    idsSubServiciosSeleccionados.Add(Convert.ToInt32(row["Id"]));
                }
                else
                {
                    idsSubServiciosNoSeleccionados.Add(Convert.ToInt32(row["Id"]));
                }

            }
            this.DialogResult = DialogResult.OK;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarSubServicios();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmSeleccionSubServicios_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

    }
}
