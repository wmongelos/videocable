using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CapaPresentacion.General
{
    public partial class frmAdvertencia : Form
    {
        private string titulo;
        private string descripcion;

        public frmAdvertencia(string titulo, string descripcion)
        {
            InitializeComponent();
            this.titulo = titulo;
            this.descripcion = descripcion;
        }

        private void frmAdvertencia_Load(object sender, EventArgs e)
        {
            lblTitulo.Text = this.titulo;
            lblDescripcion.Text = this.descripcion;
        }

        private void boton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
