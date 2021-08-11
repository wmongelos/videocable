using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace CapaPresentacion.Impresiones
{
    public partial class frmReportViewerRDLC : Form
    {
        public frmReportViewerRDLC()
        {
            InitializeComponent();
        }

        private void frmReportViewerRDLC_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }

        public void SetearReportViewerPorDataSet(string archivoRDLC, ReportDataSource[] reportesDataSource)
        {
            //En caso que el reporte este en el proyecto
            //this.reportViewer1.LocalReport.ReportEmbeddedResource = archivoRDLC;
            //En caso que el reporte este fuera del proyecto
            this.reportViewer1.LocalReport.ReportPath = archivoRDLC;

            var pageSettings = this.reportViewer1.GetPageSettings();
            pageSettings.Margins = new Margins(0, 0, 0, 0);
            this.reportViewer1.SetPageSettings(pageSettings);

            this.reportViewer1.LocalReport.DataSources.Clear();

            if (reportesDataSource != null)
            {
                for (int i = 0; i < reportesDataSource.Length; i++)
                    this.reportViewer1.LocalReport.DataSources.Add(reportesDataSource[i]);
            }

            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();
        }

        public void SetearReportViewerPorParametros(string archivoRDLC, List<ReportParameter> reportesParametros)
        {
            this.reportViewer1.LocalReport.ReportPath = archivoRDLC;

            var pageSettings = this.reportViewer1.GetPageSettings();
            pageSettings.Margins = new Margins(0, 0, 0, 0);
            this.reportViewer1.SetPageSettings(pageSettings);
            this.reportViewer1.LocalReport.DataSources.Clear();

            if (reportesParametros != null)
            {
                foreach (ReportParameter parametro in reportesParametros)
                {
                    this.reportViewer1.LocalReport.SetParameters(parametro);
                }
            }

            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();
        }

        private void frmReportViewerRDLC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
