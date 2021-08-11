using CapaNegocios;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;
namespace CapaPresentacion
{
    public partial class ABMUsuarios_Telefonos : Form
    {

        private Thread hilo;
        private delegate void myDel();
        private Usuarios oUsu = new Usuarios();
        private Usuarios_Locaciones oUsuLoc = new Usuarios_Locaciones();

        private DataRow dr;
        private Int32 Usuario_Id = 0;
        private DataTable dtLocaciones;
        private Int32 Locacion_Id = 0;

        public ABMUsuarios_Telefonos(int idusuario, int idlocacion)
        {
            InitializeComponent();


            if (idusuario > 0)
            {
                this.Usuario_Id = idusuario;
                this.Locacion_Id = idlocacion;
                dr = oUsu.getDatos(this.Usuario_Id);

                lblUsuario.Text = String.Format("[{0}] - {1}, {2}", dr["codigo"].ToString(), dr["apellido"].ToString(), dr["nombre"].ToString());
                txtCorreo.Text = dr["correo_electronico"].ToString();


            }
        }


        #region carga de datos
        private void comenzarCarga()
        {
            pgCircular.Start();
            dgvLocaciones.DataSource = null;
            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
        }

        private void cargarDatos()
        {
            dtLocaciones = oUsuLoc.ListarLocacionesServicio(this.Usuario_Id);
            myDel MD = new myDel(asignarDatos);
            this.Invoke(MD, new object[] { });
            pgCircular.Stop();
        }


        private void asignarDatos()
        {
            //Int32 idl = this.Locacion_Id;

            dgvLocaciones.DataSource = dtLocaciones;

            for (int i = 0; i < dtLocaciones.Columns.Count; i++)
                dgvLocaciones.Columns[i].Visible = false;

            dgvLocaciones.Columns["calle"].Visible = true;
            dgvLocaciones.Columns["Altura"].Visible = true;
            dgvLocaciones.Columns["Piso"].Visible = true;
            dgvLocaciones.Columns["Depto"].Visible = true;
            dgvLocaciones.Columns["Localidad"].Visible = true;




            /* int posi = 0;
             for (int i = 0; i < dgvLocaciones.Rows.Count; i++)
             {
                 if (Int32.Parse(dgvLocaciones.Rows[i].Cells["id"].Value.ToString()) == idl)
                     posi = i;
             }
             */

            //dgvLocaciones.Rows[posi].Selected = true;
            filtra_por_locaciones();
        }
        #endregion

        private void dgvLocaciones_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            filtra_por_locaciones();
        }

        private void filtra_por_locaciones()
        {
            try
            {
                lblocalidad.Text = "Localidad: " + dgvLocaciones.SelectedRows[0].Cells["calle"].Value.ToString().Trim() + "  Nro (" + dgvLocaciones.SelectedRows[0].Cells["Altura"].Value.ToString() + ") - " + dgvLocaciones.SelectedRows[0].Cells["piso"].Value.ToString() + " " + dgvLocaciones.SelectedRows[0].Cells["depto"].Value.ToString();
                Locacion_Id = Convert.ToInt32(dgvLocaciones.SelectedRows[0].Cells["id"].Value.ToString());
                txtPrefijo_1.Text = dgvLocaciones.SelectedRows[0].Cells["prefijo_1"].Value.ToString();
                txtPrefijo_2.Text = dgvLocaciones.SelectedRows[0].Cells["prefijo_2"].Value.ToString();
                txtTelefono_1.Text = dgvLocaciones.SelectedRows[0].Cells["telefono_1"].Value.ToString();
                txtTelefono_2.Text = dgvLocaciones.SelectedRows[0].Cells["telefono_2"].Value.ToString();

            }
            catch { }
        }

        private void graba_final()
        {

            oUsu.Id = Convert.ToInt32(dr["Id"].ToString());
            oUsu.Correo_Electronico = txtCorreo.Text;
            oUsu.Guardar_Correo(oUsu);

            foreach (DataGridViewRow drg in dgvLocaciones.Rows)
            {
                oUsuLoc.Id = Convert.ToInt32(drg.Cells["Id"].Value.ToString());
                oUsuLoc.Prefijo_1 = Convert.ToInt32(drg.Cells["Prefijo_1"].Value.ToString());
                oUsuLoc.Prefijo_2 = Convert.ToInt32(drg.Cells["Prefijo_2"].Value.ToString());

                oUsuLoc.Telefono_1 = Convert.ToInt32(drg.Cells["Telefono_1"].Value.ToString());
                oUsuLoc.Telefono_2 = Convert.ToInt32(drg.Cells["Telefono_2"].Value.ToString());
                oUsuLoc.modifica(oUsuLoc);
            }

            this.Close();

        }

        #region graba en grilla
        private void txtPrefijo_2_Leave(object sender, EventArgs e)
        {
            graba_dgv();
        }

        private void txtTelefono_2_Leave(object sender, EventArgs e)
        {
            graba_dgv();
        }

        private void txtPrefijo_1_Leave(object sender, EventArgs e)
        {
            graba_dgv();
        }

        private void txtTelefono_1_Leave(object sender, EventArgs e)
        {
            graba_dgv();
        }
        private void graba_dgv()
        {
            dgvLocaciones.SelectedRows[0].Cells["prefijo_1"].Value = txtPrefijo_1.Text;
            dgvLocaciones.SelectedRows[0].Cells["prefijo_2"].Value = txtPrefijo_2.Text;
            dgvLocaciones.SelectedRows[0].Cells["telefono_1"].Value = txtTelefono_1.Text;
            dgvLocaciones.SelectedRows[0].Cells["telefono_2"].Value = txtTelefono_2.Text;
        }
        #endregion



        private void btnAplicar_Click(object sender, EventArgs e)
        {
            graba_final();
        }

        private void boton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ABMUsuarios_Telefonos_Load(object sender, EventArgs e)
        {
            comenzarCarga();
        }



        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ABMUsuarios_Telefonos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}

