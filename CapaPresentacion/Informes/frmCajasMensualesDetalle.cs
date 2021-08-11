using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CapaPresentacion.Informes
{
    public partial class frmCajasMensualesDetalle : Form
    {
        public DataTable dtDetalles;
        public frmCajasMensualesDetalle()
        {
            InitializeComponent();
        }

        private void frmCajasMensualesDetalle_Load(object sender, EventArgs e)
        {
            dgvDetalles.DataSource = dtDetalles;
        }
    }
}
