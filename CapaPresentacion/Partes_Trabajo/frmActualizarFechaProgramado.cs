using CapaNegocios;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaPresentacion.Partes_Trabajo
{
    public partial class frmActualizarFechaProgramado : Form
    {
        public int id_parte;
        Partes oPartes = new Partes();
        public Partes_Historial oPartesHistorial = new Partes_Historial();
        public List<Partes_Historial> ListaPartesHistorial = new List<Partes_Historial>();


        public frmActualizarFechaProgramado()
        {
            InitializeComponent();
        }

        private void lblTituloHeader_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            try
            {

                if (DateTime.Compare(dtpFecha.Value.Date, DateTime.Now.Date) >= 0)
                {
                    foreach (Partes_Historial parteHistorial in ListaPartesHistorial)
                    {
                        oPartes.ActualizarFechaProgramado(parteHistorial.Id_Parte, dtpFecha.Value);
                        parteHistorial.Detalles = txtDetalle.Text;
                        oPartesHistorial.GuardarNuevoDetalle(parteHistorial);
                    }
                    this.DialogResult = DialogResult.OK;
                }
                else
                    MessageBox.Show("La fecha seleccionada debe ser mayor o igual a la fecha de hoy.");
            }
            catch
            {
                MessageBox.Show("Error al reprogramar parte.");
                this.Close();
            }

        }

        private void frmActualizarFechaProgramado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
