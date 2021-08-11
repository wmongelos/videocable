using CapaNegocios;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacion.Abms
{
    public partial class ABMManzanas_DatosAsignacionCalle : Form
    {
        private int id_calle;
        private int id_manzana;
        private Manzanas_Calles oManzanas_Calles = new Manzanas_Calles();


        public void recibir_id_calle_id_manzana(int id_calle_recibido, int id_manzana_recibido)
        {
            id_calle = id_calle_recibido;
            id_manzana = id_manzana_recibido;

        }

        public void llenar_datos_formulario()
        {
            DataTable datos_calle = oManzanas_Calles.Buscar_Calle(id_calle);
            if (datos_calle.Rows.Count > 0)
            {
                lblTituloHeader.Text = String.Format("{0} {1}", "Calle:", datos_calle.Rows[0]["Nombre"].ToString());

                int altura_desde = Convert.ToInt32(datos_calle.Rows[0]["Altura_Desde"].ToString());
                int altura_hasta = Convert.ToInt32(datos_calle.Rows[0]["Altura_Hasta"].ToString());

                spnDesde.Minimum = altura_desde;
                spnDesde.Maximum = altura_hasta;

                spnHasta.Minimum = altura_desde;
                spnHasta.Maximum = altura_hasta;



                cboParidad.Items.Add("PAR");
                cboParidad.Items.Add("IMPAR");
            }
            else
            {
                MessageBox.Show("Error al traer datos de calle");
            }
        }

        public void guardar_asignacion_calle()
        {


            if (cboParidad.SelectedItem != null)
            {
                if (Convert.ToInt32(spnDesde.Value) < Convert.ToInt32(spnHasta.Value))
                {
                    oManzanas_Calles.Id_Calle = id_calle;
                    oManzanas_Calles.Id_Manzana = id_manzana;
                    if (cboParidad.SelectedItem.ToString() == "PAR")
                    {
                        oManzanas_Calles.Paridad = 0;
                    }
                    else
                    {
                        oManzanas_Calles.Paridad = 1;
                    }
                    oManzanas_Calles.Altura_desde = Convert.ToInt32(spnDesde.Value);
                    oManzanas_Calles.Altura_hasta = Convert.ToInt32(spnHasta.Value);

                    try
                    {
                        oManzanas_Calles.Agregar_Manzana_Calle(oManzanas_Calles);
                        this.DialogResult = DialogResult.OK;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error al guardar asignación de calle");
                    }
                }
                else
                {
                    MessageBox.Show("El valor de altura inicial debe ser menor que la altura final de la calle.");
                }
            }
            else
            {
                MessageBox.Show("Datos en blanco.");
            }

        }

        public ABMManzanas_DatosAsignacionCalle()
        {
            InitializeComponent();
        }

        private void ABMDatosAsignacionCalle_Load(object sender, EventArgs e)
        {
            llenar_datos_formulario();

        }

        private void boton2_Click(object sender, EventArgs e)
        {
            guardar_asignacion_calle();
        }

        private void boton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ABMDatosAsignacionCalle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
