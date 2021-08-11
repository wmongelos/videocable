using CapaNegocios;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;




namespace CapaPresentacion.Partes_Trabajo
{
    public partial class frmEsperas : frmUsuarioLocacion
    {
        private Thread hilo;
        private delegate void myDel();

        private Usuarios_Servicios oUsuario_Servicio = new Usuarios_Servicios();
        private Servicios_Estados_Historial oServicios_Estados_Historial = new Servicios_Estados_Historial();
        DataTable dtCambios = new DataTable();

        public frmEsperas()
        {
            InitializeComponent();

        }
        private void frmEsperas_Load(object sender, EventArgs e)
        {
            comenzarCarga();
        }
        private void comenzarCarga()
        {
            dgvCambios.DataSource = null;
            hilo = new Thread(new ThreadStart(cargardatos));
            hilo.Start();
        }

        private void cargardatos()
        {
            try
            {
                oServicios_Estados_Historial.id_servicios_estados = 3;
                oServicios_Estados_Historial.id_usuarios = this.Usuario_Id;
                dtCambios = oServicios_Estados_Historial.Listar_Por_estados();

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
            dgvCambios.DataSource = dtCambios;


            for (int i = 0; i < dgvCambios.Columns.Count; i++)
                dgvCambios.Columns[i].Visible = false;

            dgvCambios.Columns["descripcion"].Visible = true;
            dgvCambios.Columns["fecha"].Visible = true;
            dgvCambios.Columns["estado"].Visible = true;
        }

        private void btnCancela_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGenerarAviso_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Confirma fecha de espera?", "Fecha de esperade corte", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                genera_espera();
            }
        }
        private void genera_espera()
        {
            foreach (DataRow dr in dtServicios.Rows)
            {
                if (Convert.ToBoolean(dr["elige"].ToString()) == true)
                {
                    oUsuario_Servicio.Id_Servicios_Estados = 3;
                    oUsuario_Servicio.Fecha_Estado = dtFecha.Value;// DateTime.Now;
                    oUsuario_Servicio.ActualizarEstado(Convert.ToInt32(dr["id"].ToString()), 0);

                    oServicios_Estados_Historial.id_servicios = Convert.ToInt32(dr["id_servicios"].ToString());
                    oServicios_Estados_Historial.id_usuarios = this.Usuario_Id;
                    oServicios_Estados_Historial.id_usuarios_servicios = Convert.ToInt32(dr["id"].ToString());
                    oServicios_Estados_Historial.id_servicios_estados = 3; // Convert.ToInt32(dr["id_servicios_estados"].ToString());
                    oServicios_Estados_Historial.fecha = dtFecha.Value;
                    oServicios_Estados_Historial.Guardar(oServicios_Estados_Historial);

                }

                this.Close();

            }
        }


    }
}
