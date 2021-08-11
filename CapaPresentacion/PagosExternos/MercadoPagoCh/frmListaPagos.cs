using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CapaNegocios.PagosExternos;
using PlataformasPagos.CaptarPagos;

namespace CapaPresentacion.PagosExternos.MercadoPagoCh
{
    public partial class frmListaPagos : Form
    {
        #region PROPIEDADES
        private List<CapaNegocios.PagosExternos.PagoExterno> lista = new List<CapaNegocios.PagosExternos.PagoExterno>();
        private CapaNegocios.PagosExternos.PagoExterno oGestionPagos = new CapaNegocios.PagosExternos.PagoExterno();
        #endregion

        #region METODOS 

        public frmListaPagos()
        {
            InitializeComponent();
        }

        private void GuardarPagos()
        {
            int cantidadErrores = 0;
            foreach (CapaNegocios.PagosExternos.PagoExterno item in lista)
            {
                if (!item.Guardar(item))
                    cantidadErrores++;
            }
            if (cantidadErrores > 0)
                MessageBox.Show("Hubo errores al intentar procesar los pagos", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
            
        #endregion

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnBuscar_ClickAsync(object sender, EventArgs e)
        {
            List<CapaNegocios.PagosExternos.PagoExterno> listaVacia = new List<CapaNegocios.PagosExternos.PagoExterno>();
            this.tlvLista.SetObjects(listaVacia);

            CapaNegocios.PagosExternos.MercadoPagoCh.MPCh oMPCh = new CapaNegocios.PagosExternos.MercadoPagoCh.MPCh();

            lista = oMPCh.Listar();
            if (lista.Count>0)
            {
                this.tlvLista.SetObjects(lista);
                btnExportar.Enabled = true;
                btnPasarPagos.Enabled = true;
                lblCantidades.Text = $"Cantidad de pagos encontrados: {lista.Count}";
            }
            else
            {
                this.tlvLista.SetObjects(null);
                MessageBox.Show("No se encontraron resultados", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {

        }

        private void btnPasarPagos_Click(object sender, EventArgs e)
        {
            GuardarPagos();
        }

        private void tlvLista_FormatRow(object sender, BrightIdeasSoftware.FormatRowEventArgs e)
        {
            CapaNegocios.PagosExternos.PagoExterno customer = (CapaNegocios.PagosExternos.PagoExterno)e.Model;
            if (customer.Id > 0)
                e.Item.BackColor = Color.LightGreen;
           
        }
    }
}
