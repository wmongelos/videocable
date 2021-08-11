using CapaNegocios;
using System;
using System.Data;
using System.IO;
using System.Threading;
using System.Windows.Forms;


namespace CapaPresentacion.Informes
{
    public partial class FrmUsuariosARBA : Form
    {
        #region PROPIEDADES
        Tools oTool = new Tools();
        private Thread hilo;
        private delegate void myDel();
        private DataTable dt, dtUsuARBA;
        Usuarios oUsu = new Usuarios();
        #endregion

        public FrmUsuariosARBA()
        {
            InitializeComponent();
        }

        #region METODOS

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
                dt = oUsu.ListarTodosUsuariosARBA();
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
            dgv.DataSource = dt;

            for (int i = 0; i < dgv.ColumnCount; i++)
                dgv.Columns[i].Visible = false;

            dgv.Columns["Name"].Visible = true;
            dgv.Columns["Numero_Documento"].Visible = true;
            dgv.Columns["Cuit"].Visible = true;
            dgv.Columns["Id_Comprobantes_Iva"].Visible = true;

            dgv.Columns["Name"].HeaderText = "Nombre";
        }
        #endregion


        #region EVENTOS

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActualizaPadron_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            saveDialog.DefaultExt = "csv";
            saveDialog.RestoreDirectory = true;
            saveDialog.FilterIndex = 2;
            if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                string root = saveDialog.FileName;
                string Destino = @"C:\GIES\";
                File.Copy(root, @"C:\GIES\PadronARBA.txt", true);
                oTool.LeeTxtPadronARBA(saveDialog.FileName);
                MessageBox.Show("Patron Actualizado.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al actualizar el patron.");
            }
        }
        #endregion

        private void FrmUsuariosARBA_Load(object sender, EventArgs e)
        {
            comenzarCarga();
        }
    }
}
