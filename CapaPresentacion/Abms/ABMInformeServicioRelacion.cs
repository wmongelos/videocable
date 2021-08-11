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
    public partial class ABMInformeServicioRelacion : Form
    {
        private Thread hilo;
        private delegate void myDel();
        private InformeCajasMensual oInforme = new InformeCajasMensual();
        private Servicios oServicio = new Servicios();
        private DataTable dtInformes = new DataTable();
        private DataTable dtServicios = new DataTable();
        private DataTable dtServiciosRelacion = new DataTable();
        private bool finAsignarDatos;
        private int idInfSeleccionado=1, idSerSeleccionado=0, idRelSeleccionado=0;
        #region MÉTODOS

        private void comenzarCarga()
        {
            dgvServiciosRelacionados.DataSource = null;
            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
        }

        private void cargarDatos()
        {
            try
            {
                dtInformes = oInforme.ListarInfomes();
                dtServicios = oServicio.Listar();
                if (dtInformes.Rows.Count > 0)
                    dtServiciosRelacion = oInforme.ListarServiciosPorInforme();
                myDel MD = new myDel(asignarDatos);
                this.Invoke(MD, new object[] { });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Información" + ex.Message);
            }
        }

        private void asignarDatos()
        {
            try
            {
                cboServicios.DataSource = dtServicios;
                cboServicios.DisplayMember = "descripcion";
                cboServicios.ValueMember = "id";

                cboInformes.DataSource = dtInformes;
                cboInformes.DisplayMember = "nombre";
                cboInformes.ValueMember = "id";

                dgvServiciosRelacionados.DataSource = dtServiciosRelacion;
                dgvServiciosRelacionados.Columns["id_informe_servicio"].Visible = false;
                dgvServiciosRelacionados.Columns["id"].Visible = false;
                dgvServiciosRelacionados.Columns["id_servicio"].Visible = false;
                DataGridViewLinkColumn dc = new DataGridViewLinkColumn();
                dc.UseColumnTextForLinkValue = true;
                dc.HeaderText = "Quitar";
                dc.DataPropertyName = "quitar";
                dc.Name = "quitar";
                dc.Text = "QUITAR";
                dc.ActiveLinkColor = Color.Black;
                dc.LinkBehavior = LinkBehavior.SystemDefault;
                dc.LinkColor = Color.Blue;
                dc.TrackVisitedState = true;
                dc.VisitedLinkColor = Color.YellowGreen;

                dgvServiciosRelacionados.Columns.Add(dc);
                dgvServiciosRelacionados.Columns["quitar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                cboInformes.SelectedValue = idInfSeleccionado;
                finAsignarDatos = true;
                AsignarValores();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString());
            }
        }


        private void AsignarValores()
        {
            if (finAsignarDatos)
            {
                idInfSeleccionado = Convert.ToInt32(cboInformes.SelectedValue);
                DataView dv = dtServiciosRelacion.DefaultView;
                dv.RowFilter = $"id_informe_servicio = {idInfSeleccionado}";
            }
        }

        #endregion

        public ABMInformeServicioRelacion()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            idInfSeleccionado = Convert.ToInt32(cboInformes.SelectedValue);
            idSerSeleccionado = Convert.ToInt32(cboServicios.SelectedValue);
            DataView dv = dtServiciosRelacion.DefaultView;
            dv.RowFilter = $"id_informe_servicio = {idInfSeleccionado} and id_servicio={idSerSeleccionado}";
            if (dv.Count > 0)
                MessageBox.Show("Ya existe la relacion de informe y servicio", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                InformeCajasMensual oInformes = new InformeCajasMensual();
                int idNuevo = 0;
                if(oInforme.GuardarRelacion(idInfSeleccionado, idSerSeleccionado, out idNuevo))
                {
                    dtServiciosRelacion.Rows.Add(idNuevo, idInfSeleccionado, idSerSeleccionado, cboServicios.Text);
                    dtServiciosRelacion.AcceptChanges();

                }
            }
            dv.RowFilter = $"id_informe_servicio = {idInfSeleccionado}";

        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void ABMInformeServicioRelacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.DialogResult = DialogResult.OK;
        }

        private void dgvServiciosRelacionados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvServiciosRelacionados.Columns[e.ColumnIndex].Name == "quitar")
            {
                idRelSeleccionado = Convert.ToInt32(dgvServiciosRelacionados.SelectedRows[0].Cells["id"].Value);
                int indice = 0;

                if (oInforme.EliminarRelacion(idRelSeleccionado))
                {
                    for (int i = dtServiciosRelacion.Rows.Count - 1; i >= 0; i--)
                    {
                        DataRow dr = dtServiciosRelacion.Rows[i];
                        if (Convert.ToInt32(dr["id"]) == idRelSeleccionado)
                            indice = i;
                    }
                    dtServiciosRelacion.Rows.RemoveAt(indice);
                }
            }
        }

        private void ABMInformeServicioRelacion_Load(object sender, EventArgs e)
        {
            comenzarCarga();
        }


        private void cboInformes_SelectedValueChanged(object sender, EventArgs e)
        {
            AsignarValores();
        }
    }
}
