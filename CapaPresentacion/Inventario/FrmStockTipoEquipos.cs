using CapaNegocios;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Informes
{
    public partial class FrmStockTipoEquipos : Form
    {
        private Thread hilo;
        private delegate void myDel();
        Equipos oEqui = new Equipos();
        Equipos_Tipos oTipoE = new Equipos_Tipos();
        DataTable dtEquipos = new DataTable();
        int idTipoEquipo;
        public DataRow Datarow;

        public FrmStockTipoEquipos()
        {
            InitializeComponent();
        }

        private void comenzarCarga()
        {
            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
        }

        private void cargarDatos()
        {
            try
            {
                dtEquipos = oEqui.ListarStockEquiposTipos();
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
            dgv.DataSource = dtEquipos;
            for (int i = 0; i < dgv.ColumnCount; i++)
                dgv.Columns[i].Visible = false;
            dgv.Columns["Nombre"].Visible = true;
            dgv.Columns["Mac"].Visible = true;
            dgv.Columns["Serie"].Visible = true;

            dgv.Columns["Nombre"].HeaderText = "TIPO";
            dgv.Columns["Mac"].HeaderText = "MAC";
            dgv.Columns["Serie"].HeaderText = "SERIE";

            cboTipoEquiposs.DataSource = oTipoE.Listar();
            cboTipoEquiposs.ValueMember = "Id";
            cboTipoEquiposs.DisplayMember = "Nombre";

            if (this.Datarow != null)
            {
                cboTipoEquiposs.SelectedValue = this.Datarow["id"];
            }
        }

        private void FrmStockTipoEquipos_Load(object sender, EventArgs e)
        {
            comenzarCarga();

        }

        private void cboTipoEquiposs_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                DataView dv = dtEquipos.DefaultView;
                dv.RowFilter = string.Format("id_tipo = {0} ", Convert.ToInt32(cboTipoEquiposs.SelectedValue));
                dgv.DataSource = dv;
                lblTotal.Text = String.Format("Total de Registros: {0}", dgv.Rows.Count);
            }
            catch (Exception)
            {

            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 0)
            {
                Tools tools = new Tools();
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    tools.ExportToExcel(dgv, "Informe equipos por Stock.");
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al exportar a excel");
                }
                finally { this.Cursor = Cursors.Default; }
            }
            else
                MessageBox.Show("Grilla vacia", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmStockTipoEquipos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
