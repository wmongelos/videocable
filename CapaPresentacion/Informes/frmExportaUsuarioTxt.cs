using CapaNegocios;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Informes
{
    public partial class frmExportaUsuarioTxt : Form
    {
        private Thread hilo;
        private delegate void myDel();
        private Usuarios oUsu = new Usuarios();
        private DataTable dtUsuarios;
        private Tools oTool = new Tools();
        #region metodos
        public frmExportaUsuarioTxt()
        {
            InitializeComponent();
        }

        private void ComenzarCarga()
        {

            hilo = new Thread(new ThreadStart(CargarDatos));
            hilo.IsBackground = true;
            hilo.Start();
            btnExportar.Enabled = false;
        }

        private void CargarDatos()
        {
            try
            {
                dtUsuarios = oUsu.ListarUsuariosExportacionTXT();
                myDel MD = new myDel(AsignarDatos);
                this.Invoke(MD, new object[] { });
            }
            catch
            {
                MessageBox.Show("Error al cargar información.");
            }

        }

        private void AsignarDatos()
        {
            dgv.DataSource = dtUsuarios;

            for (int i = 0; i < dgv.ColumnCount; i++)
                dgv.Columns[i].Visible = true;
            dgv.Columns["Codigo"].HeaderText = "Codigo";
            dgv.Columns["Apellido"].HeaderText = "Apellido";
            dgv.Columns["Nombre"].HeaderText = "Nombre";
            dgv.Columns["numero_documento"].HeaderText = "N° Documento";
            dgv.Columns["cuit"].HeaderText = "Cuit";
            dgv.Columns["Localidad"].HeaderText = "Localidad";
            dgv.Columns["telefono"].HeaderText = "Telefono";
            dgv.Columns["Mail"].HeaderText = "Mail";
            dgv.Columns["saldo"].HeaderText = "Saldo";
            btnExportar.Enabled = true;
        }
        #endregion

        #region Eventos
        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void frmExportaUsuarioTxt_Load(object sender, EventArgs e)
        {
            ComenzarCarga();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            string[] Cadenas = new string[dtUsuarios.Rows.Count + 1];

            Cadenas[0] = "codcli" + "," + "name" + "," + "lastname" + "," + "dni" + "," + "cuit" + "," + "adress" + "," + "city" + "," + "city_slug" + "," + "phone_number" + "," + "email" + "," + "s_status" + "," + "plan" + "," + "a_status" + "," + "debt" + "," + "due_debt1" + "," + "due_debt2" + "," + "priority" + "," + "message";
            for (int i = 1; i < dtUsuarios.Rows.Count + 1; i++)
            {
                Cadenas[i] = dtUsuarios.Rows[i - 1]["codigo"].ToString() + "," + dtUsuarios.Rows[i - 1]["Nombre"].ToString() + "," + dtUsuarios.Rows[i - 1]["Apellido"].ToString() + "," + dtUsuarios.Rows[i - 1]["numero_documento"].ToString() + "," + dtUsuarios.Rows[i - 1]["cuit"].ToString() + "," + dtUsuarios.Rows[i - 1]["Mail"].ToString() + "," + dtUsuarios.Rows[i - 1]["Localidad"].ToString() + "," + dtUsuarios.Rows[i - 1]["LocalidadAbv"].ToString() + "," + dtUsuarios.Rows[i - 1]["Telefono"].ToString() + "," + " " + "," + " " + "," + " " + "," + "ACTIVO" + "," + " " + "," + " " + "," + " " + "," + " " + "," + " ";
            }
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Text Files (*.csv)|*.csv|All Files (*.*)|*.*";
            saveDialog.DefaultExt = "csv";
            saveDialog.RestoreDirectory = true;
            saveDialog.FilterIndex = 2;
            if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                oTool.ExportarCvs(saveDialog.FileName, 1, Cadenas);
                MessageBox.Show("El archivo se exporto correctamente");
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al exportar el archivo.");
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            dtUsuarios.DefaultView.RowFilter = String.Format("Convert([codigo], System.String) LIKE '%{0}%' OR nombre LIKE '%{0}%' OR Convert([numero_documento], System.String) LIKE '%{0}%' OR Convert([prefijo_1], System.String) LIKE '%{0}%' OR Convert([prefijo_2], System.String) LIKE '%{0}%' OR Convert([telefono_2], System.String) LIKE '%{0}%' OR Convert([saldo], System.String) LIKE '%{0}%'", txtBuscar.Text);
        }
    }
}
