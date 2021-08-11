using CapaNegocios;
using CapaPresentacion.Abms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmOrganismos : Form
    {
        private Organismos oOrganismos = new Organismos();
        private Organismos_Subservicios_Relacion oOrgSubRel = new Organismos_Subservicios_Relacion();
        private Servicios oServicios = new Servicios();
        private DataTable dtSubservicios = new DataTable();
        private int indexOrganismoSeleccionado;

        public frmOrganismos()
        {
            InitializeComponent();
        }

        private void frmOrganismos_Load(object sender, EventArgs e)
        {
            CargarOrganismos();
            CargarServicios();
        }

        private void CargarOrganismos()
        {
            dgvOrganismos.DataSource = oOrganismos.Listar();
            foreach (DataGridViewColumn col in dgvOrganismos.Columns)
                col.Visible = false;
            dgvOrganismos.Columns["Descripcion"].Visible = true;
            dgvOrganismos.Columns["Descripcion"].HeaderText = "Organismos";
        }

        private void CargarServicios()
        {
            comboServicios.DataSource = oServicios.Listar();
            comboServicios.DisplayMember = "Descripcion";
            comboServicios.ValueMember = "Id";
        }

        private void MostrarServiciosDeOrganismo(int rowIndex)
        {
            dtSubservicios = oOrgSubRel.ListarPorOrganismo(Convert.ToInt32(dgvOrganismos.Rows[rowIndex].Cells["id"].Value));
            dgvSubservicios.DataSource = dtSubservicios;
            foreach (DataGridViewColumn col in dgvSubservicios.Columns)
                col.Visible = false;

            dgvSubservicios.Columns["servicios"].Visible = true;
            dgvSubservicios.Columns["subservicio"].Visible = true;
            dgvSubservicios.Columns["nombre"].Visible = true;
            dgvSubservicios.Columns["servicios"].HeaderText = "Servicio";
            dgvSubservicios.Columns["subservicio"].HeaderText = "Subservicio";
            dgvSubservicios.Columns["nombre"].HeaderText = "Tipo Subservicio";

            dgvSubservicios.Sort(dgvSubservicios.Columns["servicios"], ListSortDirection.Ascending);

            lblTotal.Text = String.Format("Total de Registros: {0}", dtSubservicios.Rows.Count);
            dgvSubservicios.ReadOnly = true;
        }

        private void AgregarServicioAlOrganismoSeleccionado()
        {
            if (dgvOrganismos.Rows.Count == 0)
            {
                if (MessageBox.Show("No hay Organismos cargados. ¿Desea cargar un organismo para realizar esta operacion?", "Mensaje del Sistema",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (frmPopUp frm = new frmPopUp())
                    {
                        frm.Formulario = new ABMOrganismos();
                        frm.Maximizar = false;
                        frm.Show();
                    }
                    CargarOrganismos();
                }
                else
                {
                    MessageBox.Show("Operacion cancelada.");
                    this.Close();
                }

            }
            else
            {
                Int32 IdServicios = Convert.ToInt32(comboServicios.SelectedValue);
                MostrarSubServicios(IdServicios);
            }
        }

        private void MostrarSubServicios(int idServicio)
        {
            using (frmPopUp popUp = new frmPopUp())
            {
                DataTable subsYaSeleccionados = new Organismos_Subservicios_Relacion().GetIdsSubserviciosDeOrganismo(Convert.ToInt32(dgvOrganismos.Rows[indexOrganismoSeleccionado].Cells["Id"].Value));
                List<int> idsSubsYaSeleccionados = new List<int>();
                foreach (DataRow row in subsYaSeleccionados.Rows)
                    idsSubsYaSeleccionados.Add(Convert.ToInt32(row["id_subservicio"]));

                FrmSeleccionSubServicios frmAux = new FrmSeleccionSubServicios(Convert.ToInt32(comboServicios.SelectedValue), comboServicios.Text, idsSubsYaSeleccionados);
                popUp.Formulario = frmAux;
                popUp.Maximizar = false;
                if (popUp.ShowDialog() == DialogResult.OK)
                {
                    //Se guardan los nuevos subservicios asociados al organismo seleccionado
                    foreach (int idSubServicio in frmAux.idsSubServiciosSeleccionados)
                    {
                        if (!idsSubsYaSeleccionados.Contains(idSubServicio))
                        {
                            Organismos_Subservicios_Relacion oOrg = new Organismos_Subservicios_Relacion();
                            oOrg.Id_Organismo = Convert.ToInt32(dgvOrganismos.Rows[indexOrganismoSeleccionado].Cells["Id"].Value);
                            oOrg.Id_SubServicio = idSubServicio;
                            oOrg.Guardar(oOrg);
                        }
                    }

                    //Se eliminan los subservicios deselecionados
                    foreach (int idSubServicio in frmAux.idsSubServiciosNoSeleccionados)
                    {
                        if (idsSubsYaSeleccionados.Contains(idSubServicio))
                        {
                            Organismos_Subservicios_Relacion oOrg = new Organismos_Subservicios_Relacion();
                            oOrg.Id_Organismo = Convert.ToInt32(dgvOrganismos.Rows[indexOrganismoSeleccionado].Cells["Id"].Value);
                            oOrg.Id_SubServicio = idSubServicio;
                            oOrg.Eliminar(oOrg);
                        }
                    }

                    MessageBox.Show("Los subservicios seleccionados se modificaron correctamente", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MostrarServiciosDeOrganismo(indexOrganismoSeleccionado);
                }
            }
        }

        private void SeleccionarServicio(int rowIndex)
        {
            comboServicios.SelectedValue = Convert.ToInt32(dgvSubservicios.Rows[rowIndex].Cells["id_servicios"].Value);
        }

        private void btnAgregarSer_Click(object sender, EventArgs e)
        {
            AgregarServicioAlOrganismoSeleccionado();
        }

        private void dgvSubservicios_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionarServicio(e.RowIndex);
        }

        private void dgvOrganismos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            indexOrganismoSeleccionado = e.RowIndex;
            MostrarServiciosDeOrganismo(indexOrganismoSeleccionado);
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmOrganismos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

    }
}
