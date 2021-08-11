using CapaNegocios;
using FEAFIPLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CapaPresentacion.Afip
{
    public partial class frmDiferenciasDeComprobantesGiesAfip : Form
    {
        private List<int> NumerosDeComp = new List<int>();
        private int numeroMinimo=0;
        private int numeroMaximo=0;
        private DataTable dtNumerosNoEncontrados = new DataTable();
        private Comprobante oComprobanteAfip = new Comprobante();
        private Contribuyente oAfipContribuyente = new Contribuyente();
        private int puntoVentaSeleccionado;
        private int tipoComprobanteSeleccionado;
        private string descComprobanteSeleccionado;
        private afip oAfip = new afip();

        public frmDiferenciasDeComprobantesGiesAfip()
        {
            InitializeComponent();
        }

        private void frmDiferenciasDeComprobantesGiesAfip_Load(object sender, EventArgs e)
        {
            cboComprobantesTipo.DataSource = new Comprobantes_Tipo().Listar_Comprobantes_Afip();
            cboComprobantesTipo.DisplayMember = "nombre";
            cboComprobantesTipo.ValueMember = "id";
        }

        private void ListarComprobantesConPresentaVentas()
        {
            if (dtpDesde.Value > dtpHasta.Value)
            {
                MessageBox.Show("La fecha desde no puede ser mayor a la fecha hasta", "Mensaje del sistema");
                return;
            }

            puntoVentaSeleccionado = Convert.ToInt32(spPuntodeVenta.Value);
            tipoComprobanteSeleccionado = Convert.ToInt32(cboComprobantesTipo.SelectedValue);
            descComprobanteSeleccionado = cboComprobantesTipo.Text;

            DataTable dtComprobantes = new Iva_Alicuotas().ListarComprobantesQuePresentanVentas(puntoVentaSeleccionado, tipoComprobanteSeleccionado, dtpDesde.Value.Date, dtpHasta.Value.Date);

            if (dtComprobantes.Rows.Count == 0)
                return;

            numeroMinimo = Convert.ToInt32(dtComprobantes.Rows[0]["numero"]);
            numeroMaximo = Convert.ToInt32(dtComprobantes.Rows[dtComprobantes.Rows.Count - 1]["numero"]);
            grbNumero.Enabled = true;
            spDesde.Value = numeroMinimo;
            spHasta.Value = numeroMaximo;
        }

        private void VerificarExistenciaDeTodosLosNumeros()
        {
            List<int> listaNumeros = new List<int>();
            for (int i = numeroMinimo; i <= numeroMaximo; i++)
            {
                listaNumeros.Add(i);
            }

            dtNumerosNoEncontrados = new Iva_Alicuotas().VerificarExistenciaDeNumeros(listaNumeros, puntoVentaSeleccionado, tipoComprobanteSeleccionado, descComprobanteSeleccionado);
            if (dtNumerosNoEncontrados.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron diferencias en el perioro ingresado", "Mensaje del sistema");
                return;
            }
            dgv.DataSource = dtNumerosNoEncontrados;
            FormatearDGV();
            lblTotal.Text = $"Total de Registros: {dtNumerosNoEncontrados.Rows.Count}";
        }

        private void FormatearDGV()
        {
            foreach (DataGridViewColumn col in dgv.Columns)
                col.Visible = false;

            dgv.Columns["numero"].Visible = true;
            dgv.Columns["numero"].HeaderText = "Numero";
            dgv.Columns["punto_venta"].Visible = true;
            dgv.Columns["punto_venta"].HeaderText = "Punto de venta";
            dgv.Columns["descripcion"].Visible = true;
            dgv.Columns["descripcion"].HeaderText = "Tipo de comprobante";
        }

        private void IrABuscarComprobantesNoEncontrados()
        {
            if(dtNumerosNoEncontrados.Rows.Count == 0)
            {
                MessageBox.Show("No hay ningun comprobante para guardar", "Mensaje del sistema");
            }

            oAfip.Conectar(out int ErrorNro, out string ErrorDescripcion);
            if (ErrorNro > 0)
            {
                MessageBox.Show($"Error al conectar con la afip, mensaje de error: {ErrorDescripcion}", "Mensaje del sistema");
                return;
            }

            foreach (DataGridViewRow row in dgv.Rows)
            {
                oComprobanteAfip = oAfip.ObtenerComprobante(puntoVentaSeleccionado, Convert.ToInt32(row.Cells["codigo_afip"].Value), Convert.ToInt32(row.Cells["numero"].Value), out ErrorNro, out ErrorDescripcion);
                GuardarComprobanteEIvaVenta(Convert.ToInt32(row.Cells["numero"].Value), Convert.ToInt32(row.Cells["codigo_afip"].Value));
                row.DefaultCellStyle.BackColor = Color.LightGreen;
            }

            MessageBox.Show("Proceso finalizado", "Mensaje del sistema");
        }

        private void GuardarComprobanteEIvaVenta(int numero, int codAfip)
        {
            Comprobantes oComp = new Comprobantes();
            DataTable dtDatosUsuario = new Usuarios().Buscar_datos_usuario(oComprobanteAfip.DocNro);
            double documento = 0;

            if (dtDatosUsuario.Rows.Count > 0)
            {
                oComp.Id_Usuarios = Convert.ToInt32(dtDatosUsuario.Rows[0]["Id_usuario"]);
                oComp.Id_Usuarios_Locaciones = Convert.ToInt32(dtDatosUsuario.Rows[0]["id_usuario_locacion"]);
                double cuit = Convert.ToDouble(dtDatosUsuario.Rows[0]["cuit"]);
                documento = (cuit == 0) ? Convert.ToDouble(dtDatosUsuario.Rows[0]["numero_documento"]) : cuit;
            }
            else
            {
                oComp.Id_Usuarios = 0;
                oComp.Id_Usuarios_Locaciones = 0;
            }

            oComp.Numero = Convert.ToInt32(numero);
            oComp.Punto_Venta = oComprobanteAfip.PtoVta;
            oComp.Importe = Convert.ToDecimal(oComprobanteAfip.Imptotal);
            oComp.Id_Comprobantes_Tipo = Convert.ToInt32(Convert.ToInt32(cboComprobantesTipo.SelectedValue));
            oComp.Fecha = DateTime.ParseExact(oComprobanteAfip.CbteFch, "yyyyMMdd", CultureInfo.InvariantCulture);
            oComp.Id_Punto_Cobro = Puntos_Cobros.Id_Punto;
            oComp.Id_Punto_Venta = Convert.ToInt32(Convert.ToInt32(spPuntodeVenta.Value));
            oComp.Id_Personal = Personal.Id_Login;
            int idComprobanteGenerado = oComp.Guardar(oComp);

            Facturacion.ESTADO_IVA_VENTAS estadoIvaVentas;
            oAfipContribuyente = oAfip.ObtenerContribuyente(documento, out int ResultadoNro, out string ResultadoString);

            if (oAfipContribuyente.nombre != null)
            {
                if (dtDatosUsuario.Rows.Count == 1)
                    estadoIvaVentas = Facturacion.ESTADO_IVA_VENTAS.VERIFICAR_CTACTE;
                else
                    estadoIvaVentas = Facturacion.ESTADO_IVA_VENTAS.VERIFICAR_USUARIO;
            }
            else
                estadoIvaVentas = Facturacion.ESTADO_IVA_VENTAS.DOCUMENTO_INVALIDO;

            Facturacion oFacturacion = new Facturacion();
            DataTable dtDatosComprobanteTipo = new Comprobantes_Tipo().Listar_Comprobante_Afip_filtrado(codAfip);
            if(estadoIvaVentas == Facturacion.ESTADO_IVA_VENTAS.VERIFICAR_CTACTE)
            {
                oFacturacion.Id_Usuarios = Convert.ToInt32(dtDatosUsuario.Rows[0]["Id_usuario"]);
                oFacturacion.Id_Usuarios_locacion = Convert.ToInt32(dtDatosUsuario.Rows[0]["id_usuario_locacion"]);
                oFacturacion.Calle = Convert.ToString(dtDatosUsuario.Rows[0]["Calle"]);
                oFacturacion.Altura = Convert.ToInt32(dtDatosUsuario.Rows[0]["Altura"]);
                oFacturacion.Localidad = Convert.ToString(dtDatosUsuario.Rows[0]["Localidad"]);
                oFacturacion.Cod_postal = Convert.ToString(dtDatosUsuario.Rows[0]["Codigo_Postal"]);
                oFacturacion.Provincia = Convert.ToString(dtDatosUsuario.Rows[0]["Provincia"]);
                oFacturacion.Razon_Social = oAfipContribuyente.nombre ?? $"{dtDatosUsuario.Rows[0]["apellido"].ToString()} {dtDatosUsuario.Rows[0]["nom_usu"].ToString()}";
                oFacturacion.Fantasia = oAfipContribuyente.nombre ?? $"{dtDatosUsuario.Rows[0]["apellido"].ToString()} {dtDatosUsuario.Rows[0]["nom_usu"].ToString()}";
                oFacturacion.Id_Comprobantes_iva = Convert.ToInt32(dtDatosUsuario.Rows[0]["id_comprobantes_iva"]);
            }
            else
            {
                oFacturacion.Id_Usuarios = 0;
                oFacturacion.Id_Usuarios_locacion = 0;
                oFacturacion.Calle = "";
                oFacturacion.Altura = 0;
                oFacturacion.Localidad = "";
                oFacturacion.Cod_postal = "";
                oFacturacion.Provincia = "";
                oFacturacion.Razon_Social = "";
                oFacturacion.Fantasia = "";
                oFacturacion.Id_Comprobantes_iva = 0;
            }
            oFacturacion.Numero_Doc = documento;
            oFacturacion.Id_Comprobantes = idComprobanteGenerado;
            oFacturacion.Id_Comprobantes_tipo = Convert.ToInt32(Convert.ToInt32(cboComprobantesTipo.SelectedValue));
            oFacturacion.Letra = Convert.ToString(dtDatosComprobanteTipo.Rows[0]["Letra"]);
            oFacturacion.Fecha = DateTime.ParseExact(oComprobanteAfip.CbteFch, "yyyyMMdd", CultureInfo.InvariantCulture);
            oFacturacion.Punto_Venta = oComprobanteAfip.PtoVta;
            oFacturacion.Numero = Convert.ToInt32(numero);
            oFacturacion.Cae = oComprobanteAfip.CodAutorizacion;
            oFacturacion.Cae_vencimiento = DateTime.ParseExact(oComprobanteAfip.FchVto, "yyyyMMdd", CultureInfo.InvariantCulture);
            oFacturacion.Importe_Neto = Convert.ToDecimal(oComprobanteAfip.ImpNeto);
            oFacturacion.Importe_Iva = Convert.ToDecimal(oComprobanteAfip.ImpIVA);
            oFacturacion.Importe_Impuesto_Interno = 0;
            oFacturacion.Importe_Impuesto_Nacional = 0;
            oFacturacion.Importe_Impuesto_Municipal = 0;
            oFacturacion.Importe_Impuesto_Otros = 0;
            oFacturacion.Importe_Impuesto_Provincial = Convert.ToDecimal(oComprobanteAfip.ImpTrib);
            oFacturacion.Importe_Final = Convert.ToDecimal(oComprobanteAfip.Imptotal);
            oFacturacion.Id_Iva_Ventas = oFacturacion.GuardarIvaVentas(oFacturacion, estadoIvaVentas);
            oFacturacion.Guarda_Iva_Alicuotas_Afip(oFacturacion);
        }

        private void ExportarAExcel()
        {
            if (dgv.Rows.Count > 0)
            {
                Tools tools = new Tools();
                try
                {
                    tools.ExportDataTableToExcel(dtNumerosNoEncontrados.DefaultView.ToTable(), "comprobantes", this);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error el exportar a excel: {ex.Message}");
                }
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            ListarComprobantesConPresentaVentas();
            this.Cursor = Cursors.Default;
        }

        private void btnGenerarComp_Click(object sender, EventArgs e)
        {
            btnGenerarComp.Enabled = false;
            IrABuscarComprobantesNoEncontrados();
        }

        private void boton1_Click(object sender, EventArgs e)
        {
            ExportarAExcel();
        }

        private void btnVerificar_Click(object sender, EventArgs e)
        {
            if (spDesde.Value > spHasta.Value)
            {
                if (MessageBox.Show("El número 'Hasta' no puede ser menos al número 'Desde'", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) == DialogResult.OK)
                    spHasta.Focus();
            }
            else
            {
                numeroMinimo = Convert.ToInt32(spDesde.Value);
                numeroMaximo = Convert.ToInt32(spHasta.Value);
                VerificarExistenciaDeTodosLosNumeros();
                btnGenerarComp.Enabled = true;
            }
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDiferenciasDeComprobantesGiesAfip_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void dtpDesde_ValueChanged(object sender, EventArgs e)
        {
            dtpHasta.MinDate = dtpDesde.Value.Date;
        }
    }
}
