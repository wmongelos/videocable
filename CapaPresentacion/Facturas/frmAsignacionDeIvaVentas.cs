using CapaNegocios;
using CapaPresentacion.Busquedas;
using CapaPresentacion.Cuenta_Corriente;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CapaPresentacion.Facturas
{
    public partial class frmAsignacionDeIvaVentas : Form
    {
        DataTable dtIvaVentas = new DataTable();

        public frmAsignacionDeIvaVentas()
        {
            InitializeComponent();
        }

        private void Buscar()
        {
            Cursor = Cursors.WaitCursor;
            Climpuestos oImpuestos = new Climpuestos();
            dtIvaVentas = oImpuestos.ListarIvaVentasConEstadoPendiente();
            filtrarPorEstados();
            dgv.DataSource = dtIvaVentas;
            formatearGrilla();
            lblTotal.Text = $"Total de Registros: {dtIvaVentas.DefaultView.ToTable().Rows.Count}";
            Cursor = Cursors.Default;
        }

        private void formatearGrilla()
        {
            foreach (DataGridViewColumn col in dgv.Columns)
                col.Visible = false;

            dgv.Columns["numero_documento"].Visible = true;
            dgv.Columns["numero_documento"].HeaderText = "DNI/Cuit";
            dgv.Columns["codigo"].Visible = true;
            dgv.Columns["codigo"].HeaderText = "Codigo";
            dgv.Columns["fecha"].Visible = true;
            dgv.Columns["fecha"].HeaderText = "Fecha";
            dgv.Columns["punto_venta"].Visible = true;
            dgv.Columns["punto_venta"].HeaderText = "Punto de venta";
            dgv.Columns["usuario"].Visible = true;
            dgv.Columns["usuario"].HeaderText = "Usuario";
            dgv.Columns["cae"].Visible = true;
            dgv.Columns["cae"].HeaderText = "CAE";
            dgv.Columns["vencimiento"].Visible = true;
            dgv.Columns["vencimiento"].HeaderText = "Vencimiento";
            dgv.Columns["comprobante_descripcion"].Visible = true;
            dgv.Columns["comprobante_descripcion"].HeaderText = "Descripcion";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void AsignarUsuario()
        {
            if (dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona una fila de la grilla para asignarle el usuario", "Mensaje del sistema");
                return;
            }

            if (Convert.ToInt32(dgv.SelectedRows[0].Cells["estado"].Value) != Convert.ToInt32(Facturacion.ESTADO_IVA_VENTAS.VERIFICAR_USUARIO) &&
                Convert.ToInt32(dgv.SelectedRows[0].Cells["estado"].Value) != Convert.ToInt32(Facturacion.ESTADO_IVA_VENTAS.DOCUMENTO_INVALIDO))
            {
                MessageBox.Show("La fila seleccionada no corresponde a la acción que desea realizar", "Mensaje del sistema");
                return;
            }

            string doc = dgv.SelectedRows[0].Cells["numero_documento"].Value.ToString() == "0" ? "" : dgv.SelectedRows[0].Cells["numero_documento"].Value.ToString();
            frmPopUp popUp = new frmPopUp();
            frmBusquedaUsuarios frmBusquedaUs = new frmBusquedaUsuarios(4, doc, "", setearCurrentUsuario: false);
            popUp.Formulario = frmBusquedaUs;
            popUp.Maximizar = true;
            if (popUp.ShowDialog() == DialogResult.OK)
            {
                DataRow drUsuario = frmBusquedaUs.usuario_e;
                int idLocacion = Convert.ToInt32(drUsuario["id_locacion"]);
                int idComprobante = Convert.ToInt32(dgv.SelectedRows[0].Cells["id_comprobantes"].Value);
                int idIvaVenta = Convert.ToInt32(dgv.SelectedRows[0].Cells["id_iva_ventas"].Value);
                if(new Facturacion().AsignarDatosUsuarioAComprobanteEIvaVentas(idLocacion, idComprobante, idIvaVenta) == 0)
                {
                    MessageBox.Show("Los datos del comprobante fueron actualizados correctamente", "Mensaje del sistema");
                    Buscar();
                }
                else
                {
                    MessageBox.Show("Hubo un error al actualizar los datos de comprobante seleccionado", "Mensaje del sistema");
                }
            }
        }

        private void AsignarCtacte()
        {
            if (dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona una fila de la grilla para asignarle el usuario", "Mensaje del sistema");
                return;
            }

            if (Convert.ToInt32(dgv.SelectedRows[0].Cells["estado"].Value) != Convert.ToInt32(Facturacion.ESTADO_IVA_VENTAS.VERIFICAR_CTACTE) &&
                Convert.ToInt32(dgv.SelectedRows[0].Cells["estado"].Value) != Convert.ToInt32(Facturacion.ESTADO_IVA_VENTAS.DOCUMENTO_INVALIDO))
            {
                MessageBox.Show("La fila seleccionada no corresponde a la acción que desea realizar", "Mensaje del sistema");
                return;
            }

            DataTable dtComprobantes = new DataTable();
            if (Convert.ToInt32(dgv.SelectedRows[0].Cells["estado"].Value) == Convert.ToInt32(Facturacion.ESTADO_IVA_VENTAS.VERIFICAR_CTACTE))
            {
                int idUsuarioLocacion = Convert.ToInt32(dgv.SelectedRows[0].Cells["id_usuarios_locacion"].Value);
                int idUsuario = Convert.ToInt32(dgv.SelectedRows[0].Cells["id_usuario"].Value);
                dtComprobantes = new Usuarios_CtaCte().ListarCtaCteCompletaNuevo(idUsuario, idUsuarioLocacion);
            }
            else
            {
                DateTime fecha = Convert.ToDateTime(dgv.SelectedRows[0].Cells["fecha"].Value);
                decimal importeFinal = Convert.ToDecimal(dgv.SelectedRows[0].Cells["importe_final"].Value); ;
                dtComprobantes = new Usuarios_CtaCte().ListarCtaCteCompletaNuevo(0, 0, fecha, importeFinal);
            }

            frmPopUp popUp = new frmPopUp();
            frmSeleccionComprobantes frmSelecComp = new frmSeleccionComprobantes(permitirSeleccionarUnoSolo : true, permitirImportesEnCero : true);
            frmSelecComp.dtComprobantes = dtComprobantes;
            popUp.Formulario = frmSelecComp;
            popUp.Maximizar = true;
            popUp.ShowDialog();
            if (frmSelecComp.DialogResult == DialogResult.OK)
            {
                int idCompTipo = Convert.ToInt32(frmSelecComp.dtComprobantes.Rows[0]["id_comprobantes_tipo"]);
                if(idCompTipo == Convert.ToInt32(Comprobantes_Tipo.Tipo.FACTURA_A) ||
                   idCompTipo == Convert.ToInt32(Comprobantes_Tipo.Tipo.FACTURA_B) ||
                   idCompTipo == Convert.ToInt32(Comprobantes_Tipo.Tipo.REMITO) ||
                   idCompTipo == Convert.ToInt32(Comprobantes_Tipo.Tipo.COMPROBANTE_DEUDA))
                {
                    int idCuentaCorriente = Convert.ToInt32(frmSelecComp.dtComprobantes.Rows[0]["id"]);
                    string descripcionCtacte = dtComprobantes.Rows[0]["descripcion"].ToString(); 
                    int idComprobante = Convert.ToInt32(dgv.SelectedRows[0].Cells["id_comprobantes"].Value);
                    int idIvaVenta = Convert.ToInt32(dgv.SelectedRows[0].Cells["id_iva_ventas"].Value);

                    if(idCompTipo == Convert.ToInt32(Comprobantes_Tipo.Tipo.FACTURA_A) ||
                       idCompTipo == Convert.ToInt32(Comprobantes_Tipo.Tipo.FACTURA_B))
                    {
                        DialogResult dResult = MessageBox.Show("El comprobante seleccionado de la cuenta es una factura. ¿Sobreescribir de todos modos?\nSi pone que no el comprobante se cerrara sin sobreescribir la factura", "Mensaje del sistema", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                        if (dResult == DialogResult.Cancel)
                            return;
                        
                        if(dResult == DialogResult.Yes)
                            new Usuarios_CtaCte().CambiarComprobanteEIvaVentasDeCtacte(idCuentaCorriente, idComprobante, descripcionCtacte, idCompTipo, idIvaVenta);
                    }
                    else
                    {
                        new Usuarios_CtaCte().CambiarComprobanteEIvaVentasDeCtacte(idCuentaCorriente, idComprobante, descripcionCtacte, idCompTipo, idIvaVenta);
                    }

                    if(Convert.ToInt32(dgv.SelectedRows[0].Cells["estado"].Value) == Convert.ToInt32(Facturacion.ESTADO_IVA_VENTAS.DOCUMENTO_INVALIDO))
                    {
                        int idLocacion = Convert.ToInt32(frmSelecComp.dtComprobantes.Rows[0]["id_usuarios_locacion"]);
                        new Facturacion().AsignarDatosUsuarioAComprobanteEIvaVentas(idLocacion, idComprobante, idIvaVenta);
                    }

                    new Facturacion().ActualizarEstadoIvaVentas(idIvaVenta, Facturacion.ESTADO_IVA_VENTAS.CERRADO);
                    new Usuarios_CtaCte().GuardarCtaCteComprobante(idCuentaCorriente, idComprobante);
                    MessageBox.Show("Asignado a la cuenta corriente correctamente", "Mensaje del sistema");
                    Buscar();
                }
                else
                {
                    MessageBox.Show("Tipo de comprobante no valido, el tipo debe ser Factura A o B, Remito o Comprobante de deuda", "Mensaje del sistema");
                    return;
                }
            }
        }

        private void filtrarPorEstados()
        {
            if (rbCompCerrados.CheckState == CheckState.Checked)
            {
                dtIvaVentas.DefaultView.RowFilter = "";
            }
            else
            {
                dtIvaVentas.DefaultView.RowFilter = "estado <> 4";
            }
        }

        private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["estado"].Value) == Convert.ToInt32(Facturacion.ESTADO_IVA_VENTAS.VERIFICAR_CTACTE))
            {
                dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
            }
            else if (Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["estado"].Value) == Convert.ToInt32(Facturacion.ESTADO_IVA_VENTAS.VERIFICAR_USUARIO))
            {
                dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Aqua;
            }
            else if (Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["estado"].Value) == Convert.ToInt32(Facturacion.ESTADO_IVA_VENTAS.DOCUMENTO_INVALIDO))
            {
                dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Tomato;
            }
            else if (Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["estado"].Value) == Convert.ToInt32(Facturacion.ESTADO_IVA_VENTAS.CERRADO))
            {
                dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(64,64,64);
                dgv.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
            }
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            dtIvaVentas.DefaultView.RowFilter = String.Format("razon_social like '%{0}%' or fantasia like '%{0}%' " +
               "or comprobante_descripcion like '%{0}%' or codigo like '%{0}%'", txtFiltro.Text);

            lblTotal.Text = String.Format("Total de Registros: {0}", dgv.Rows.Count);
        }

        private void btnAsigUsuario_Click(object sender, EventArgs e)
        {
            AsignarUsuario();
        }

        private void btnAsigCtacte_Click(object sender, EventArgs e)
        {
            AsignarCtacte();
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["estado"].Value) == Convert.ToInt32(Facturacion.ESTADO_IVA_VENTAS.VERIFICAR_CTACTE))
            {
                AsignarCtacte();
            }
            else if (Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["estado"].Value) == Convert.ToInt32(Facturacion.ESTADO_IVA_VENTAS.VERIFICAR_USUARIO))
            {
                AsignarUsuario();
            }
            else if (Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["estado"].Value) == Convert.ToInt32(Facturacion.ESTADO_IVA_VENTAS.DOCUMENTO_INVALIDO))
            {
                AsignarUsuario();
            }
        }

        private void rbCompCerrados_CheckedChanged(object sender, EventArgs e)
        {
            if(dtIvaVentas.Rows.Count > 0)
            {
                filtrarPorEstados();
                lblTotal.Text = $"Total de Registros: {dtIvaVentas.DefaultView.ToTable().Rows.Count}";
            }
        }

        private void frmAsignacionDeIvaVentas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
