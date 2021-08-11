using CapaNegocios;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmServiciosUsuarios : Form
    {
        private Thread hilo;
        private delegate void myDel();
        private DataTable dt_servicios;
        public int id_usuario = 0, id_servicio = 0, id_usuario_servicio = 0, id_servicio_tipo=0;
        Usuarios_Servicios oUsu_Serv = new Usuarios_Servicios();
        public string Descripcion = string.Empty;

        public frmServiciosUsuarios()
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
                dt_servicios = oUsu_Serv.Listar_activos(id_usuario);
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
            dgv.DataSource = dt_servicios;

            for (int i = 0; i < dgv.ColumnCount; i++)
                dgv.Columns[i].Visible = false;

        
            dgv.Columns["servicio"].Visible = true;
            dgv.Columns["tiposervicio"].Visible = true;
            dgv.Columns["estado"].Visible = true;
            dgv.Columns["localidad"].Visible = true;
            dgv.Columns["calle"].Visible = true;
            dgv.Columns["altura"].Visible = true;

            dgv.Columns["servicio"].HeaderText = "Servicio";
            dgv.Columns["tiposervicio"].HeaderText = "Tipo";
            dgv.Columns["estado"].HeaderText = "Estado";
            dgv.Columns["localidad"].HeaderText = "Localidad";
            dgv.Columns["calle"].HeaderText = "Calle";
            dgv.Columns["altura"].HeaderText = "Altura";

        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            id_servicio_tipo = Convert.ToInt32(dgv.SelectedRows[0].Cells["id_servicio_tipo"].Value.ToString());
            id_servicio = Convert.ToInt32(dgv.SelectedRows[0].Cells["id_servicios"].Value.ToString());
            Descripcion = dgv.SelectedRows[0].Cells["servicio"].Value.ToString();
            id_usuario_servicio = Convert.ToInt32(dgv.SelectedRows[0].Cells["id"].Value.ToString());
            if (id_servicio_tipo == (int)Servicios_Tipos.TIPOS.DIGITAL_HD_MINETTI)
                this.Close();
            else
                MessageBox.Show("Este servicio no pertenece al CASS, seleccione un servicio de tipo MINETTI.");
        }

        private void frmServiciosUsuarios_Load(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
