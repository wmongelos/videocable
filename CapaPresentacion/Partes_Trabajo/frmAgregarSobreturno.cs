using CapaNegocios;
using System;
using System.Data;
using System.Windows.Forms;
namespace CapaPresentacion.Partes_Trabajo
{
    public partial class frmAgregarSobreturno : Form
    {
        Agenda_Encabezado agenda = new Agenda_Encabezado();
        DataTable dt = new DataTable();

        public frmAgregarSobreturno()
        {
            InitializeComponent();
        }

        private void frmAgregarSobreturno_Load(object sender, EventArgs e)
        {
            for (int x = 0; x < 24; x++)
            {
                if (x.ToString().Length == 1)
                {
                    combo1.Items.Add("0" + x);
                }
                else
                {
                    combo1.Items.Add(x);
                }

            }

            for (int x = 0; x < 60; x++)
            {
                if (x.ToString().Length == 1)
                {
                    combo2.Items.Add("0" + x);
                }
                else
                {
                    combo2.Items.Add(x);
                }

            }
        }

        private void combo1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void boton2_Click(object sender, EventArgs e)
        {
            if (combo1.SelectedItem != null && combo2.SelectedItem != null)
            {
                dt = agenda.Agregar_sobreturno(combo1.SelectedItem.ToString() + ":" + combo2.SelectedItem.ToString(), dt);
                if (dt.Rows.Count > 0)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("El horario ya se encuentra cargado, ingrese otro");
                }
            }
            else
            {
                MessageBox.Show("Hay campos en blanco");
            }
        }

        public void tomar_datatable_grilla(DataTable dt_grilla)
        {
            dt = dt_grilla;
        }

        public DataTable retornar_grilla()
        {
            return dt;
        }

        private void boton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            if (combo1.SelectedItem != null && combo2.SelectedItem != null)
            {
                dt = agenda.Agregar_sobreturno(combo1.SelectedItem.ToString() + ":" + combo2.SelectedItem.ToString(), dt);
                if (dt.Rows.Count > 0)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("El horario ya se encuentra cargado, ingrese otro");
                }
            }
            else
            {
                MessageBox.Show("Hay campos en blanco");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
