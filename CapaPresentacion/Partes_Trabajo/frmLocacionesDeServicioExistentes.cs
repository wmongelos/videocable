using CapaNegocios;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Partes_Trabajo
{
    public partial class frmLocacionesDeServicioExistentes : Form
    {
        int idLocalidad, idCalle, altura, idUsuario;
        string piso, depto, limiteCalle1, limiteCalle2;
        public int idLocacionSeleccionada;

        DataTable dtLocacionesExistentes = new DataTable();
        Thread hilo;
        delegate void myDel();
        Usuarios_Locaciones oUsuariosLocaciones = new Usuarios_Locaciones();

        private void frmLocacionesExistentes_Load(object sender, EventArgs e)
        {
            ComenzarCarga();
        }

        private void btnNuevaNotificacion_Click(object sender, EventArgs e)
        {
            if (dgvLocacionesExistentes.Rows.Count > 0)
            {
                if (dgvLocacionesExistentes.SelectedRows.Count > 0)
                    idLocacionSeleccionada = Convert.ToInt32(dgvLocacionesExistentes.SelectedRows[0].Cells["id"].Value);
                else
                    idLocacionSeleccionada = Convert.ToInt32(dgvLocacionesExistentes.Rows[0].Cells["id"].Value);
            }
            this.DialogResult = DialogResult.OK;
        }

        private void frmLocacionesExistentes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void ComenzarCarga()
        {
            pgCircular.Start();
            hilo = new Thread(new ThreadStart(CargarDatos));
            hilo.IsBackground = true;
            hilo.Start();
        }

        private void CargarDatos()
        {
            try
            {
                if (dtLocacionesExistentes.Rows.Count == 0)
                    dtLocacionesExistentes = oUsuariosLocaciones.VerificarExistenciaLocacion(idLocalidad, idCalle, altura, piso, depto, limiteCalle1, limiteCalle2, Usuarios_Locaciones.CONTEMPLAR_NOMBRE_LIMITES_CALLES.SI);
                myDel MD = new myDel(AsignarDatos);
                this.Invoke(MD, new object[] { });
                pgCircular.Stop();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
            }
        }

        private void AsignarDatos()
        {
            dgvLocacionesExistentes.DataSource = dtLocacionesExistentes;
            for (int x = 0; x < dgvLocacionesExistentes.ColumnCount; x++)
                dgvLocacionesExistentes.Columns[x].Visible = false;
            dgvLocacionesExistentes.Columns["calle"].Visible = true;
            dgvLocacionesExistentes.Columns["altura"].Visible = true;
            dgvLocacionesExistentes.Columns["piso"].Visible = true;
            dgvLocacionesExistentes.Columns["depto"].Visible = true;
            dgvLocacionesExistentes.Columns["entre_calle_1"].Visible = true;
            dgvLocacionesExistentes.Columns["entre_calle_2"].Visible = true;
            dgvLocacionesExistentes.Columns["localidad"].Visible = true;
            dgvLocacionesExistentes.Columns["usuario"].Visible = true;
            dgvLocacionesExistentes.Columns["saldo"].Visible = true;

            dgvLocacionesExistentes.Columns["calle"].HeaderText = "Calle";
            dgvLocacionesExistentes.Columns["altura"].HeaderText = "Altura";
            dgvLocacionesExistentes.Columns["piso"].HeaderText = "Piso";
            dgvLocacionesExistentes.Columns["depto"].HeaderText = "Depto.";
            dgvLocacionesExistentes.Columns["entre_calle_1"].HeaderText = "Entre la calle";
            dgvLocacionesExistentes.Columns["entre_calle_2"].HeaderText = "Y la calle";
            dgvLocacionesExistentes.Columns["localidad"].HeaderText = "Localidad";
            dgvLocacionesExistentes.Columns["usuario"].HeaderText = "Usuario";
            dgvLocacionesExistentes.Columns["saldo"].HeaderText = "Saldo";

            dgvLocacionesExistentes.Columns["calle"].Width = 200;
            dgvLocacionesExistentes.Columns["altura"].Width = 70;
            dgvLocacionesExistentes.Columns["piso"].Width = 70;
            dgvLocacionesExistentes.Columns["depto"].Width = 70;
            dgvLocacionesExistentes.Columns["entre_calle_1"].Width = 200;
            dgvLocacionesExistentes.Columns["entre_calle_2"].Width = 200;
            dgvLocacionesExistentes.Columns["localidad"].Width = 150;
            dgvLocacionesExistentes.Columns["usuario"].Width = 150;
            dgvLocacionesExistentes.Columns["saldo"].Width = 70;

            dgvLocacionesExistentes.Columns["altura"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvLocacionesExistentes.Columns["piso"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvLocacionesExistentes.Columns["depto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvLocacionesExistentes.Columns["saldo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvLocacionesExistentes.Columns["saldo"].DefaultCellStyle.Format = "c2";

            foreach (DataGridViewRow fila in dgvLocacionesExistentes.Rows)
                fila.Height = 30;
        }

        //llamar este constructor cuando se necesita verificar la existencia de una locación o cuando se quieren ver las locaciones de un usuario
        public frmLocacionesDeServicioExistentes(DataTable dtLocacionesExistentes, int idLocalidad, int idCalle, int altura, string piso, string depto, string limiteCalle1, string limiteCalle2)
        {
            if (dtLocacionesExistentes.Rows.Count > 0)
                this.dtLocacionesExistentes = dtLocacionesExistentes;
            else
            {
                this.idLocalidad = idLocalidad;
                this.idCalle = idCalle;
                this.altura = altura;
                this.piso = piso;
                this.depto = depto;
                this.limiteCalle1 = limiteCalle1;
                this.limiteCalle2 = limiteCalle2;
            }
            InitializeComponent();
        }


        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
