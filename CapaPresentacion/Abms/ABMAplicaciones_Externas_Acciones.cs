using CapaNegocios;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;
namespace CapaPresentacion
{
    public partial class frmAplicaciones_Externas_Acciones : Form
    {
        #region
        private Thread hilo;
        private delegate void myDel();
        private DataTable dt_tipos_servicios = new DataTable();
        private DataTable dt_aplicaciones_ejecutables = new DataTable();
        private Servicios_Tipos oServicios_Tipos = new Servicios_Tipos();
        public Aplicaciones_Externas oApExt;
        private Partes_Solicitudes oParte_falla = new Partes_Solicitudes();
        private DataTable dtOperaciones;
        private int flag, id_parte_operaciones;

        #endregion


        public frmAplicaciones_Externas_Acciones()
        {
            InitializeComponent();
        }
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
                dt_aplicaciones_ejecutables = oApExt.ListarAplicacionesEjecutables();
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
            dgv1.Columns.Clear();
            dgv1.DataSource = dt_aplicaciones_ejecutables;
            dgv1.Columns["id_app"].HeaderText = "ID";
            dgv1.Columns["id_Servicios_tipos"].Visible = false;
            dgv1.Columns["nombre"].HeaderText = "Nombre";
            dgv1.Columns["id_partes_operaciones"].Visible = false;
            dgv1.Columns["id_partes_fallas"].Visible = false;
            dgv1.Columns["tipo"].HeaderText = "Tipo";
            dgv1.Columns["ejecutable"].HeaderText = "Ejecutable";
            dgv1.Columns["borrado"].Visible = false;
            if (dgv1.Rows.Count > 0)
                dgv1.SelectedRows[0].Selected = true;
            btnActualizar.Enabled = true;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            btnCancelar.Enabled = false;
            btnGuardar.Enabled = false;
            rbtEjecutable.Checked = false;
            rbtMetodo.Checked = false;
        }

        private void frmAplicaciones_Externas_Acciones_Load(object sender, EventArgs e)
        {
            if (oApExt != null)
                txtidAplicacion.Text = oApExt.Id_App.ToString();
            CargarTiposServicios();
            flag = 1;
            comenzarCarga();

        }
        private void CargarTiposServicios()
        {
            dt_tipos_servicios = oServicios_Tipos.Listar();
            cboTipoServicio.DataSource = dt_tipos_servicios;
            cboTipoServicio.ValueMember = "id";
            cboTipoServicio.DisplayMember = "nombre";
        }
        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAplicaciones_Externas_Acciones_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void cboTipoServicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                oApExt.Id_Tipo_Servicio = Convert.ToInt32(cboTipoServicio.SelectedValue);
                dtOperaciones = oParte_falla.ListarServicioTipo(oApExt.Id_Tipo_Servicio, 0, 0, "", 0);
                dgv.DataSource = dtOperaciones;
                FormatearGrilla();
            }
        }

        private void rbtMetodo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtMetodo.Checked == true)
            {
                txtejecutable.Enabled = true;
                rbtEjecutable.Checked = false;
                btnBuscar.Enabled = false;
                btnGuardar.Enabled = true;
            }
        }

        private void rbtEjecutable_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtEjecutable.Checked == true)
            {
                txtejecutable.Enabled = true;
                rbtMetodo.Checked = false;
                btnBuscar.Enabled = true;
                btnGuardar.Enabled = true;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //****Seleccionar Archivo
            ofdOpen.Filter = "Aplicaciones (*.exe)|*.exe";
            ofdOpen.FileName = "Aplicaciones";
            ofdOpen.ShowDialog();
            ofdOpen.Title = "Seleccionar aplicacion";
            txtejecutable.Text = ofdOpen.SafeFileName;
        }

        private void FormatearGrilla()
        {
            dgv.Columns["id"].Visible = false;
            dgv.Columns["id_partes_operaciones"].Visible = false;
            dgv.Columns["ParteTrabajo"].Visible = false;

        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            oApExt.id_Partes_Fallas = Convert.ToInt32(dgv.Rows[dgv.SelectedRows[0].Index].Cells["id"].Value);
            oApExt.Id_Partes_Operaciones = Convert.ToInt32(dgv.Rows[dgv.SelectedRows[0].Index].Cells["id_partes_operaciones"].Value);

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            oApExt.Id_App = Convert.ToInt32(txtidAplicacion.Text);
            oApExt.Id_Tipo_Servicio = Convert.ToInt32(cboTipoServicio.SelectedValue);
            oApExt.id_Partes_Fallas = Convert.ToInt32(dgv.Rows[dgv.SelectedRows[0].Index].Cells["id"].Value);
            oApExt.Id_Partes_Operaciones = Convert.ToInt32(dgv.Rows[dgv.SelectedRows[0].Index].Cells["id_partes_operaciones"].Value);
            if (rbtEjecutable.Checked == true)
            {
                oApExt.Tipo = "ejecutable";
                oApExt.Ejecutable = txtejecutable.Text;
            }
            else
            {
                oApExt.Tipo = "metodo";
                oApExt.Ejecutable = "";
            }

            if (oApExt.ExisteAplicacion(oApExt.Id_App) == false)
            {
                oApExt.Guardar_Acciones(oApExt, "");
            }
            else
            {
                oApExt.Guardar_Acciones(oApExt, "editar");
            }
            MessageBox.Show("Datos guardados correctamente");
            comenzarCarga();

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            cboTipoServicio.Enabled = true;
            dgv.Enabled = true;
            txtejecutable.Enabled = true;
            rbtMetodo.Enabled = true;
            rbtEjecutable.Enabled = true;
            btnCancelar.Enabled = true;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            oApExt.Id_App = Convert.ToInt32(txtidAplicacion.Text);
            if (MessageBox.Show("¿Desea eliminar las acciones de esta aplicacion externa?", "Mnesaje del Sisyema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                oApExt.Eliminar_Acciones(oApExt.Id_App);
                comenzarCarga();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cboTipoServicio.Enabled = false;
            dgv.Enabled = false;
            txtejecutable.Enabled = false;
            rbtMetodo.Enabled = false;
            rbtEjecutable.Enabled = false;
            btnGuardar.Enabled = true;
            btnBuscar.Enabled = false;
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
            btnCancelar.Enabled = false;
        }

        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtidAplicacion.Text = dgv1.Rows[dgv1.SelectedRows[0].Index].Cells["id_app"].Value.ToString();
            cboTipoServicio.SelectedValue = dgv1.Rows[dgv1.SelectedRows[0].Index].Cells["id_Servicios_tipos"].Value;
            id_parte_operaciones = Convert.ToInt32(dgv1.Rows[dgv1.SelectedRows[0].Index].Cells["id_partes_operaciones"].Value);
            if (flag == 1)
            {
                oApExt.Id_Tipo_Servicio = Convert.ToInt32(cboTipoServicio.SelectedValue);
                dtOperaciones = oParte_falla.ListarServicioTipo(oApExt.Id_Tipo_Servicio, 0, 0, "P", 0);
                dgv.DataSource = dtOperaciones;
                FormatearGrilla();
                foreach (DataGridViewRow item in dgv.Rows)
                {
                    if (Convert.ToInt32(item.Cells["id_partes_operaciones"].Value) == id_parte_operaciones)
                    {
                        item.Selected = true;
                    }
                }
            }
            if (dgv1.Rows[dgv1.SelectedRows[0].Index].Cells["tipo"].Value.ToString() == "metodo")
            {
                rbtMetodo.Checked = true;
                rbtEjecutable.Checked = false;
                txtejecutable.Text = "";
            }
            else
            {
                rbtMetodo.Checked = false;
                rbtEjecutable.Checked = true;
                txtejecutable.Text = dgv1.Rows[dgv1.SelectedRows[0].Index].Cells["ejecutable"].Value.ToString();
            }
            oApExt.Nombre_App = dgv1.Rows[dgv1.SelectedRows[0].Index].Cells["nombre"].Value.ToString();
            cboTipoServicio.Enabled = false;
            dgv.Enabled = false;
            txtejecutable.Enabled = false;
            rbtMetodo.Enabled = false;
            rbtEjecutable.Enabled = false;
            btnGuardar.Enabled = true;
            btnBuscar.Enabled = false;
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
            btnCancelar.Enabled = false;


        }
    }
}
