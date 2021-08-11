using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;
using CapaNegocios;

namespace CapaPresentacion.PagosExternos.Bapro
{
    public partial class frmBaproTxt : Form
    {
        #region DECLARACIONES
        private Thread hilo;
        private delegate void myDel();
        private DataTable dt;
        Decimal ImporteTotal;
        Int32 FilasTotales;
        Facturacion oFacturacion = new Facturacion();
        Tools oTool = new Tools();
        private int cantRegistrosTxt = 0;
        private decimal ImporteTotalTxt = 0;
        private string rutaCompleta;
        #endregion
        public frmBaproTxt()
        {
            InitializeComponent();
        }

        #region METODOS




        private void GeneraHeader()
        {
            string[] Parametros = new string[1];
            string Relleno = "";
            var Fecha = DateTime.Now.ToString("yyyyMMdd");
            string Codigo = "814";

            Parametros[0] = Relleno.ToString().PadRight(1,'0') + Codigo.ToString() + Relleno.ToString().PadRight(2,'0') + Fecha.ToString() + Relleno.ToString().PadRight(171,'0');

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Text Files (*.csv)|*.csv|All Files (*.*)|*.*";
            saveDialog.DefaultExt = "csv";
            saveDialog.RestoreDirectory = true;
            saveDialog.FilterIndex = 2;
            saveDialog.FileName = "HEADER BAPRO";
            if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                oTool.ExportarCvs(saveDialog.FileName, 1, Parametros);
            }
            else
            {
                MessageBox.Show("Error al exportar el archivo.");
            }
        }
      
        #endregion

        #region EVENTOS
        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void frmBaproTxt_Load(object sender, EventArgs e)
        {
        }

        private void btnGeneraTxt_Click(object sender, EventArgs e)
        {
            GeneraHeader();
            MessageBox.Show("Archivos Exportados correctamente");
        }

        private void boton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog oOpenFile = new OpenFileDialog();
            oOpenFile.Title = "Seleccionar archivo devuelto por BAPROPAGOS";
            oOpenFile.Filter = "TXT files|*.txt";
            oOpenFile.InitialDirectory = @"C:\";
            if (oOpenFile.ShowDialog() == DialogResult.OK)
            {
                rutaCompleta = oOpenFile.FileName;
                txtArchivo.Text = rutaCompleta;
                btnProcesar.Enabled = true;
            }

        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            CapaNegocios.PagosExternos.Bapro.BaproPagos oBapro = new CapaNegocios.PagosExternos.Bapro.BaproPagos();
            oBapro.LeerTxt(rutaCompleta);

        }
    }
}
