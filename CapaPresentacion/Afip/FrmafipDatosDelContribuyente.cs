using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CapaNegocios;
using FEAFIPLib;

namespace CapaPresentacion.Afip
{
    public partial class frmafipDatosDelContribuyente : Form
    {
        private afip oAfip = new afip();
        private wsfev1 oAfipLIbreria = new wsfev1();
        private wsPadron oAfipPadron = new wsPadron();
        private Configuracion oConfiguracion = new Configuracion();
        private Contribuyente oAfipContribuyente = new Contribuyente();
        private Int32 ErrorNro;
        private String ErrorDescripcion;
        private Double Cuit;

        public frmafipDatosDelContribuyente()
        {
            InitializeComponent();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void CargarDatos()
        {
            oAfipPadron.CUIT = Convert.ToDouble(oConfiguracion.GetValor_C("Cuit")); ;
            oAfipPadron.ModoProduccion = true;
            this.AsignarDatos();
        }

        private void AsignarDatos()
        {
            Cuit = 20233939405;
            ErrorNro = 0;
            ErrorDescripcion = "";
            oAfipContribuyente = oAfip.ObtenerContribuyente(Cuit, out ErrorNro, out ErrorDescripcion);

            if (ErrorNro == 0)
                LeerContribuyente();
            else
                MessageBox.Show(ErrorDescripcion);
        }

        private void LeerContribuyente()
        {


            lbApellido.Text = oAfipContribuyente.apellido;
            lbNombre.Text = oAfipContribuyente.nombre;
            lbestado.Text = oAfipContribuyente.estadoClave;
            lbtipopersona.Text = oAfipContribuyente.tipoPersona;
            lbDireccion.Text = oAfipContribuyente.domicilioFiscal.direccion;
            lbLocalidad.Text = oAfipContribuyente.domicilioFiscal.localidad;
            oAfipPadron.descargarConstancia(Cuit, "c://gies//Constancia.pdf");
            
            lbLocalidad.Text= oAfipContribuyente.condicionIVADesc;
          

        }

        private void BajarPdf()
        {
            String ruta;
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Archivo de pdf (*pdf)|*pdf";
            saveDialog.FilterIndex = 2;
         //   saveDialog.FileName = nombreArchivo;
            MessageBox.Show("Seleccione el destino ");
            if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ruta = saveDialog.FileName+"Constancia.pdf";
                MessageBox.Show(ruta);
                oAfipPadron.descargarConstancia (Cuit, ruta);
            }
        }

        private void frmDatosDelContribuyente_Load(object sender, EventArgs e)
        {
            this.CargarDatos();
        }

        private void btnConstancia_Click(object sender, EventArgs e)
        {
            BajarPdf();
        }

        private void frmafipDatosDelContribuyente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
