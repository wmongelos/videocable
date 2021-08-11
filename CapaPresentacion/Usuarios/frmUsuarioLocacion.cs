using CapaNegocios;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmUsuarioLocacion : Form
    {
        private Int32 usuarioid;
        public Int32 Usuario_Id
        {
            get { return usuarioid; }
            set
            {
                usuarioid = value;
                cargarUsuario();
                cargarLocaciones();
            }
        }

        public Int32 Usuario_Locacon_Id;
        public Int32 Usuario_Servicio_Id;
        public Int32 CantidadServicios;
        public DataTable dtLocaciones;
        public DataTable dtServicios = new DataTable();
        public DataTable DtPartes = new DataTable();
        private Usuarios_Locaciones oUsuLoc = new Usuarios_Locaciones();
        private Usuarios_Servicios oUsuSer = new Usuarios_Servicios();
        private Usuarios oUsu = new Usuarios();
        public DataRow drUsuario;

        public frmUsuarioLocacion()
        {
            InitializeComponent();
        }

        private void cargarUsuario()
        {
            drUsuario = oUsu.getDatos(usuarioid);
            lblUsuario.Text = String.Format("[{0}] - {1}, {2}", drUsuario["codigo"].ToString(), drUsuario["apellido"].ToString(), drUsuario["nombre"].ToString());

        }

        private void cargarLocaciones()
        {
            dtLocaciones = oUsuLoc.ListarLocacionesServicio(usuarioid);

            dgvLocaciones.DataSource = dtLocaciones;

            for (int i = 0; i < dgvLocaciones.Columns.Count; i++)
                dgvLocaciones.Columns[i].Visible = false;

            dgvLocaciones.Columns["Calle"].Visible = true;
            dgvLocaciones.Columns["Altura"].Visible = true;
            dgvLocaciones.Columns["Piso"].Visible = true;
            dgvLocaciones.Columns["Depto"].Visible = true;
            dgvLocaciones.Columns["Saldo"].Visible = true;

            if (dtLocaciones.Rows.Count > 0)
                cargarServicios(Convert.ToInt32(dtLocaciones.Rows[0]["Id"]));

        }

        private void cargarServicios(Int32 idLocacion)
        {
            dtServicios = oUsuSer.ListarServicios(usuarioid, idLocacion);
            dtServicios.Columns.Add("elige", typeof(Boolean));
            foreach (DataRow dr in dtServicios.Rows)
            {
                dr["elige"] = false;
            }

            this.Usuario_Locacon_Id = idLocacion;

            dgvServicios.DataSource = dtServicios;
            for (int i = 0; i < dgvServicios.Columns.Count; i++)
                dgvServicios.Columns[i].Visible = false;

            dgvServicios.Columns["servicio"].Visible = true;
            dgvServicios.Columns["estado"].Visible = true;
            dgvServicios.Columns["elige"].Visible = false;

            CantidadServicios = dtServicios.Rows.Count;

            if (CantidadServicios > 0)
                this.Usuario_Servicio_Id = Convert.ToInt32(dtServicios.Rows[0]["Id"]);
        }



        private void dgvLocaciones_SelectionChanged(object sender, EventArgs e)
        {
            dtServicios.Clear();

            dgvServicios.DataSource = null;
            dgvServicios.DataSource = dtServicios;
            if (dgvLocaciones.Rows.Count > 0)
            {
                if (dgvLocaciones.SelectedRows.Count > 0)
                {
                    cargarServicios(Convert.ToInt32(dgvLocaciones.SelectedRows[0].Cells["Id"].Value));
                    //lblocalidad.Text = "(" + dgvLocaciones.SelectedRows[0].Cells["localidad"].Value.ToString().Trim() + ") CALLE : " + dgvLocaciones.SelectedRows[0].Cells["calle"].Value.ToString().Trim() + "  Nro (" + dgvLocaciones.SelectedRows[0].Cells["Altura"].Value.ToString() + ") - " + dgvLocaciones.SelectedRows[0].Cells["piso"].Value.ToString() + " " + dgvLocaciones.SelectedRows[0].Cells["depto"].Value.ToString();
                }
                else
                {
                    cargarServicios(Convert.ToInt32(dgvLocaciones.Rows[0].Cells["Id"].Value));
                    // lblocalidad.Text = "(" + dgvLocaciones.Rows[0].Cells["localidad"].Value.ToString().Trim() + ") CALLE : " + dgvLocaciones.Rows[0].Cells["calle"].Value.ToString().Trim() + "  Nro (" + dgvLocaciones.Rows[0].Cells["Altura"].Value.ToString() + ") - " + dgvLocaciones.Rows[0].Cells["piso"].Value.ToString() + " " + dgvLocaciones.Rows[0].Cells["depto"].Value.ToString();
                }
            }

        }

        private void dgvServicios_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                this.Usuario_Servicio_Id = Convert.ToInt32(dgvServicios.SelectedRows[0].Cells["Id"].Value);
            }
            catch { }
        }

        private void dgvServicios_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvServicios.Columns[e.ColumnIndex].Name == "elige")
            {
                if (Convert.ToBoolean(dgvServicios.CurrentRow.Cells["elige"].Value) == false)
                {
                    dgvServicios.SelectedRows[0].Cells["elige"].Value = true;
                }
                else
                {
                    dgvServicios.SelectedRows[0].Cells["elige"].Value = false;
                }

            }

        }

        private void boton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
