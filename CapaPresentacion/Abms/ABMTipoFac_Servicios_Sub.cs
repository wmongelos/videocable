using CapaNegocios;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacion.Abms
{
    public partial class ABMTipoFac_Servicios_Sub : Form
    {
        private DataTable dtServiciosSub = new DataTable();
        private Servicios_Sub oSub = new Servicios_Sub();

        public Int32 Id_Servicios;
        public Int32 Id_Tipo_Facturacion;

        public String Servicios
        {
            get { return lblTituloHeader.Text; }
            set { lblTituloHeader.Text = value; }
        }

        public DataTable dtServiciosSubTipo;

        public ABMTipoFac_Servicios_Sub()
        {
            InitializeComponent();
        }

        public void CargarDatos()
        {
            dtServiciosSub = oSub.ListarPorServicio(this.Id_Servicios);

            DataColumn colSel = new DataColumn("Seleccionar", typeof(Boolean))
            {
                DefaultValue = false
            };

            dtServiciosSub.Columns.Add(colSel);

            dgv.DataSource = dtServiciosSub;

            foreach (DataRow dr in dtServiciosSub.Rows)
            {
                if (dtServiciosSubTipo != null)
                {
                    DataRow[] drFilter = dtServiciosSubTipo.Select(String.Format("Id_Servicios_Sub = {0}", dr["Id"].ToString()));

                    if (drFilter.Length > 0)
                        dr["Seleccionar"] = true;

                    dtServiciosSub.AcceptChanges();
                }
            }

            for (int i = 0; i < dgv.Columns.Count; i++)
                dgv.Columns[i].Visible = false;

            dgv.Columns["Descripcion"].Visible = true;
            dgv.Columns["Seleccionar"].Visible = true;
            dgv.ReadOnly = false;
            dgv.Columns["Seleccionar"].ReadOnly = false;
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void ABMCategorias_Servicios_Sub_Load(object sender, EventArgs e)
        {
            this.CargarDatos();
        }

        private void ABMCategorias_Servicios_Sub_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.DialogResult = DialogResult.Cancel;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DataRow[] drFilter = dtServiciosSub.Select("Seleccionar = true");

            if (drFilter.Length == 0)
                MessageBox.Show("Debe Seleccionar al menos un Subservicio", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                //Servicios_Categorias oSerCat = new Servicios_Categorias();
                //oSerCat.GuardarServiciosSub(this.Id_Tipo_Facturacion, this.Id_Servicios, dtServiciosSub);

                Tipo_Facturacion oTipoFac = new Tipo_Facturacion();
                oTipoFac.Guardar(this.Id_Tipo_Facturacion, this.Id_Servicios, dtServiciosSub);

                this.DialogResult = DialogResult.OK;
            }
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgv.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
