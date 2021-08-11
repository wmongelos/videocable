using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacion.Herramientas
{
    public partial class frmSeleccionValores : Form
    {
        private readonly DataTable dt = new DataTable();
        private string valueMember;
        private string displayMember;

        public List<int> valoresSeleccionados = new List<int>();
        public bool SeleccionarAlMenosUno { get; set; }
        public bool PermitirSeleccionMultiple { get; set; } = true;

        public frmSeleccionValores(string titulo, DataTable dt, string valueMember, string displayMember)
        {
            InitializeComponent();
            lblTituloHeader.Text = titulo;
            this.dt = dt;
            this.valueMember = valueMember;
            this.displayMember = displayMember;
        }

        private void frmSeleccionValores_Load(object sender, EventArgs e)
        {
            this.listItems.DataSource = dt;
            this.listItems.DisplayMember = displayMember;
            this.listItems.ValueMember = valueMember;

            if(valoresSeleccionados.Count > 0)
            {
                int i = 0;
                List<int> indicesSeleccionados = new List<int>();
                foreach (object item in listItems.Items)
                {
                    var row = (item as DataRowView).Row;
                    if (valoresSeleccionados.Contains(row.Field<int>(valueMember)))
                    {
                        indicesSeleccionados.Add(i);
                    }
                    i++;
                }

                foreach (int indice in indicesSeleccionados)
                {
                    listItems.SetItemChecked(indice, true);
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            valoresSeleccionados.Clear();
            foreach (object item in listItems.CheckedItems)
            {
                var row = (item as DataRowView).Row;
                valoresSeleccionados.Add(row.Field<int>(valueMember));
            }

            if (SeleccionarAlMenosUno && valoresSeleccionados.Count == 0)
            {
                MessageBox.Show("Es necesario seleccionar el menos un item", "Mensaje del sistema");
                return;
            }

            if (!PermitirSeleccionMultiple && valoresSeleccionados.Count > 1)
            {
                MessageBox.Show("Solo es posible seleccionar un valor", "Mensaje del sistema");
                return;
            }

            this.DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnSelec_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listItems.Items.Count ; i++)
            {
                listItems.SetItemChecked(i, true);
            }
        }

        private void btnDeselec_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listItems.Items.Count; i++)
            {
                listItems.SetItemChecked(i, false);
            }
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSeleccionValores_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
