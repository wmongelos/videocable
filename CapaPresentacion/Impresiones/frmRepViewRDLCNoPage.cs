using System;
using System.Windows.Forms;

namespace CapaPresentacion.Impresiones
{
    public partial class frmRepViewRDLCNoPage : Form
    {
        public frmRepViewRDLCNoPage()
        {
            InitializeComponent();
        }

        private void frmReportViewerRDLC_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }

        private void frmReportViewerRDLC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
