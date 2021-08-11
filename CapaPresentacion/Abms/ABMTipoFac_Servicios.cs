using CapaNegocios;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Abms
{
    public partial class ABMTipoFac_Servicios : Form
    {
        #region [PROPIEDADES]
        private Thread hilo;
        private delegate void myDel();
        private Int32 IdTipoFac;
        private DataTable dt;
        private DataTable dtServicios;
        private DataTable dtTipoFacServiciosSub;
        private DataTable dtTipoFacServicios;
        private Servicios oSer = new Servicios();
        private Servicios_Categorias oCat = new Servicios_Categorias();
        private Zonas oZon = new Zonas();
        private Configuracion oConfig = new Configuracion();
        private Tipo_Facturacion oTipoFac = new Tipo_Facturacion();
        #endregion

        #region [METODOS]
        private void ComenzarCarga()
        {
            pgCircular.Start();

            dgv.DataSource = null;

            hilo = new Thread(new ThreadStart(CargarDatos));
            hilo.Start();
        }

        private void CargarDatos()
        {
            try
            {
                if (oConfig.GetValor_N("Id_Tipo_Facturacion") == Convert.ToInt32(Tipo_Facturacion.Id_Tipo_Facturacion.POR_CATEGORIAS))
                    dt = oCat.Listar();
                else
                    dt = oZon.Listar();

                dtServicios = oSer.Listar();

                myDel MD = new myDel(AsignarDatos);

                this.Invoke(MD, new object[] { });

                pgCircular.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Informacion" + ex.Message);
            }
        }

        private void AsignarDatos()
        {
            dgv.DataSource = dt;

            foreach (DataGridViewColumn dataColumn in dgv.Columns)
                dataColumn.Visible = false;

            dgv.Columns["Id"].HeaderText = "Codigo";
            dgv.Columns["Id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dgv.Columns["Id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["Nombre"].HeaderText = "Categoria";
            dgv.Columns["Id"].Visible = true;
            dgv.Columns["Nombre"].Visible = true;
            dgv.Enabled = true;


            //if(dtTipoFacServicios.Rows.Count > 0)
            //    dgvServicios.Columns["requiere_velocidad"].Visible = false;
            
            //if(dtTipoFacServiciosSub.Rows.Count > 0)
            //    dgvServiciosSub.Columns["valor_defecto"].Visible = false;

            cboServicios.DataSource = dtServicios;
            cboServicios.ValueMember = "Id";
            cboServicios.DisplayMember = "Descripcion";
            cboServicios.Enabled = true;
            FormatearGrillaSubServicios();



            lblTotal.Text = String.Format("Total de Registros: {0}", dt.Rows.Count);
        }

        private void CargarServicios(int idTipoFacturacion)
        {
            dgvServiciosSub.DataSource = null;

            dtTipoFacServicios = oTipoFac.GetServiciosPorTipo(idTipoFacturacion);

            dgvServicios.DataSource = dtTipoFacServicios;

            foreach (DataGridViewColumn dataColumn in dgvServicios.Columns)
                dataColumn.Visible = false;

            dgvServicios.Columns["servicios"].HeaderText = "Servicios";
            dgvServicios.Columns["servicios"].Visible = true;

            dgvServicios.Enabled = true;
        }

        private void CargarServiciosSub(int idServicios)
        {
            dtTipoFacServiciosSub = oTipoFac.GetServiciosSubPorTipo(IdTipoFac, idServicios);

            dgvServiciosSub.DataSource = dtTipoFacServiciosSub;

            foreach (DataGridViewColumn dataColumn in dgvServiciosSub.Columns)
                dataColumn.Visible = false;

            dgvServiciosSub.Columns["servicios_sub"].HeaderText = "Sub Servicios";
            dgvServiciosSub.Columns["servicios_sub"].Visible = true;
        }

        private void ABMSubServicios(int IdServicios)
        {
            using (frmPopUp frm = new frmPopUp())
            {
                ABMTipoFac_Servicios_Sub frmAux = new ABMTipoFac_Servicios_Sub
                {
                    Id_Servicios = IdServicios,
                    Id_Tipo_Facturacion = IdTipoFac,
                    Servicios = cboServicios.Text,
                    dtServiciosSubTipo = dtTipoFacServiciosSub
                };

                frm.Formulario = frmAux;
                frm.Maximizar = false;

                if (frm.ShowDialog() == DialogResult.OK)
                    CargarServicios(IdTipoFac);
            }
        }
        #endregion

        public ABMTipoFac_Servicios()
        {
            InitializeComponent();
        }

        private void ABMTipoFac_Servicios_Load(object sender, EventArgs e)
        {
            if (oConfig.GetValor_N("Id_Tipo_Facturacion") == 2)
            {
                lblTituloHeader.Text = "Servicios por Categorias";
                lblTipoFacturacion.Text = "Categorias";
            }

            ComenzarCarga();
        }

        private void ABMTipoFac_Servicios_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                IdTipoFac = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["Id"].Value.ToString());

                CargarServicios(IdTipoFac);
            }
            catch { }
        }

        private void dgvServicios_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Int32 id = Convert.ToInt32(dgvServicios.SelectedRows[0].Cells["Id_Servicios"].Value);

                CargarServiciosSub(id);
            }
            catch { }
        }

        private void btnAgregarSer_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show(String.Format("Debe agregar {0} de servicios", lblTipoFacturacion.Text), "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            else
            {
                if (MessageBox.Show("¿Desea Agregar el Servicio Seleccionado?", "Mensaje del Sistema",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Int32 IdServicios = Convert.ToInt32(cboServicios.SelectedValue);

                    DataRow[] dr = dtTipoFacServicios.Select(String.Format("Id_Servicios = {0}", IdServicios));

                    if (dr.Length > 0)
                        MessageBox.Show("El Servicio Seleccionado ya se encuentra Asociado", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    else
                        ABMSubServicios(IdServicios);
                }
            }
        }

        private void btnEliminaSer_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea Eliminar el Servicio Seleccionado?", "Mensaje del Sistema",
               MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Int32 IdServicios = Convert.ToInt32(dgvServicios.SelectedRows[0].Cells["Id_Servicios"].Value);

                oTipoFac.EliminarServicios(IdTipoFac, IdServicios);

                CargarServicios(IdTipoFac);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                Int32 IdServicios = Convert.ToInt32(dgvServicios.SelectedRows[0].Cells["Id_Servicios"].Value);

                ABMSubServicios(IdServicios);
            }
            catch { }
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FormatearGrillaSubServicios()
        {
            try
            {
                dgvServiciosSub.Columns["idtipodesub"].Visible = false;
                dgvServiciosSub.Columns["servicios_sub"].HeaderText = "Subservicios";
            }
            catch
            {
                MessageBox.Show("No se puede formatear grilla de subservicios. Verifique que los servicios hayan sido asignados.");
            }

        }
    }
}
