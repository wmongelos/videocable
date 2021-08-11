using CapaNegocios;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacion.Partes_Trabajo
{
    public partial class frmAsignarBonif_Puntual : Form
    {
        private Bonificaciones_Especiales oBoni = new Bonificaciones_Especiales();
        private DataTable dt = new DataTable();
        public Decimal Importe
        {
            get { return spImporte.Value; }
            set { spImporte.Value = value; }
        }

        public Decimal ImporteFinal
        {
            get { return spImporteFinal.Value; }
        }

        public String Bonificacion { get; set; }
        public Int32 Bonificacion_Id { get; set; }
        public Decimal Bonificacion_Porce { get; set; }
        public Decimal Bonificacion_Importe { get; set; }


        public frmAsignarBonif_Puntual()
        {
            InitializeComponent();
        }

        private void cargarDatos()
        {
            try
            {
                dt = oBoni.Listar();

                cboBonificaciones.DataSource = dt;
                cboBonificaciones.ValueMember = "id";
                cboBonificaciones.DisplayMember = "nombre";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Informacion" + ex.Message);
            }
        }

        private void frmAsignarBonif_Puntual_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboBonificaciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(cboBonificaciones.SelectedValue);

                DataRow[] rowFilter = dt.Select(String.Format("id = {0}", id));

                if (rowFilter.Length > 0)
                {
                    spBoniPorc.Value = Convert.ToDecimal(rowFilter[0]["porcentaje"]);
                }
                else
                    spBoniPorc.Value = 0;


                if (spBoniPorc.Value > 0)
                {
                    spBoniImporte.Value = (spBoniPorc.Value * spImporte.Value) / 100;
                    spImporteFinal.Value = spImporte.Value - spBoniImporte.Value;
                }
                else
                    spImporteFinal.Value = spImporte.Value;
            }
            catch { }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            this.Bonificacion_Id = Convert.ToInt32(cboBonificaciones.SelectedValue);
            this.Bonificacion = cboBonificaciones.Text;
            this.Bonificacion_Porce = spBoniPorc.Value;
            this.Bonificacion_Importe = spBoniImporte.Value;

            this.DialogResult = DialogResult.OK;
        }
    }
}
