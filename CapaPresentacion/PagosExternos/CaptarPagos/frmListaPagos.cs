using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PlataformasPagos.CaptarPagos;

namespace CapaPresentacion.PagosExternos.CaptarPagos
{
    public partial class frmListaPagos : Form
    {
        #region PROPIEDADES
        private CapaNegocios.PagosExternos.PagoExterno oGestionPagos = new CapaNegocios.PagosExternos.PagoExterno();
        private DataReport[] resultado;
        #endregion

        #region METODOS 

        public frmListaPagos()
        {
            InitializeComponent();
        }

        private void ActualizarPagos()
        {
            List<CapaNegocios.PagosExternos.PagoExterno> oLista = new List<CapaNegocios.PagosExternos.PagoExterno>();
            CapaNegocios.PagosExternos.PagoExterno oPagoExterno = new CapaNegocios.PagosExternos.PagoExterno();
            oLista = oGestionPagos.Listar(dtpDesde.Value,dtpHasta.Value);
            foreach (DataReport item in resultado)
            {
                foreach (CapaNegocios.PagosExternos.PagoExterno item2 in oLista)
                {
                    if (item.IdPago == item2.IdPago && item.Monto != item2.ImportePago)
                        oPagoExterno.ActualizarPago(item.IdPago, 1, item.Monto,item.FechaCobro);
                }  
            }
        }
            
        #endregion

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnBuscar_ClickAsync(object sender, EventArgs e)
        {
            List<DataReport> listaVacia = new List<DataReport>();
            this.tlvLista.SetObjects(listaVacia);
            DateTime fechaDesde = dtpDesde.Value;
            DateTime fechaHasta = dtpHasta.Value;

            PlataformasPagos.CaptarPagos.CaptarPagos.TipoBusqueda buqueda = PlataformasPagos.CaptarPagos.CaptarPagos.TipoBusqueda.PAGO;
            if (rbtPago.Checked)
                buqueda = PlataformasPagos.CaptarPagos.CaptarPagos.TipoBusqueda.PAGO;
            if (rbtImpago.Checked)
                buqueda = PlataformasPagos.CaptarPagos.CaptarPagos.TipoBusqueda.IMPAGO;
            if (rbTodos.Checked)
                buqueda = PlataformasPagos.CaptarPagos.CaptarPagos.TipoBusqueda.TODO;
            CapaNegocios.PagosExternos.CaptarPagos.CaptarPagosImplement oCaptar = new CapaNegocios.PagosExternos.CaptarPagos.CaptarPagosImplement();
            oCaptar.SetEntidad();
            oCaptar.SetHash();
            resultado = await oCaptar.ListarBotonesAsync(fechaDesde, fechaHasta, buqueda);
            if (resultado[0] != null)
            {
                List<DataReport> lista = new List<DataReport>(resultado);
                this.tlvLista.SetObjects(lista);
                btnExportar.Enabled = true;
                btnPasarPagos.Enabled = true;
            }
            else
                MessageBox.Show("No se encontraron resultados", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {

        }

        private void btnPasarPagos_Click(object sender, EventArgs e)
        {
            ActualizarPagos();
        }
    }
}
