using CapaNegocios;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacion.Inventario
{
    public partial class FrmConfirmarComprobantesCompras : Form
    {
        private int idProveedorSelec;
        private DataTable dtItemsSelec;
        private DataTable dtArticulos;
        private int tipoInventario; //1 para Articulos , 2 para Equipos

        public FrmConfirmarComprobantesCompras(DataTable dt, int tipoInventario)
        {
            InitializeComponent();
            CargarComboTipoComprobantes();
            dtItemsSelec = dt;
            dtArticulos = new Articulos().Listar();
            this.tipoInventario = tipoInventario;
        }

        private void CargarComboTipoComprobantes()
        {
            Comprobantes_Tipo oCompTipos = new Comprobantes_Tipo();

            cboTipoComprobante.DataSource = oCompTipos.Listar();
            cboTipoComprobante.DisplayMember = "Nombre";
            cboTipoComprobante.ValueMember = "Id";

            cboTipoComprobante.SelectedIndex = -1;
        }

        private void SeleccionDeProveedor()
        {
            using (frmPopUp frm = new frmPopUp())
            {
                FrmBuscadorGen frmBuscar = new FrmBuscadorGen();

                frmBuscar.List = FrmBuscadorGen.Tipo.PROVEEDORES;
                frm.Formulario = frmBuscar;
                frm.Maximizar = false;

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    txtSelecProv.Text = frmBuscar.Value;
                    this.idProveedorSelec = frmBuscar.Id;
                }
            }
        }

        private void btnSelecProv_Click(object sender, EventArgs e)
        {
            SeleccionDeProveedor();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (txtSelecProv.Text != "SELECCIONAR PROVEEDOR")
            {
                if (cboTipoComprobante.SelectedIndex != -1)
                {
                    if (!String.IsNullOrEmpty(txtNumRemito.Text))
                    {
                        if (MessageBox.Show("¿Guardar comprobante de compra?", "Mensaje del sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            try
                            {
                                Comprobantes_Compras oComCompras = new Comprobantes_Compras();
                                //Guardar comprobantes_compras
                                oComCompras.Fecha = dtpFecha.Value;
                                oComCompras.Id_Comprobantes_Tipo = Convert.ToInt32(cboTipoComprobante.SelectedValue);
                                oComCompras.Id_Proveedor = this.idProveedorSelec;
                                oComCompras.Importe = spImporteTotal.Value;
                                oComCompras.Numero_Remito = Convert.ToDouble(txtNumRemito.Text);
                                oComCompras.Id_Personal = Personal.Id_Login;
                                oComCompras.Observacion = txtObservacion.Text;

                                oComCompras.Guardar(oComCompras);

                                //Guardar comprobantes_compras_det
                                foreach (DataRow row in dtItemsSelec.Rows)
                                {
                                    Comprobantes_Compras_Det oComComprasDet = new Comprobantes_Compras_Det();

                                    if (tipoInventario == 1) //Articulos
                                    {
                                        oComComprasDet.Id_Comprobantes_Compras = oComCompras.Id;
                                        oComComprasDet.Id_Tipo = Convert.ToInt32(row["id"]);
                                        oComComprasDet.Tipo = "A";
                                        oComComprasDet.Cantidad = Convert.ToInt32(row["cantidad"]);
                                        oComComprasDet.Importe = Convert.ToDecimal(row["importe"]);
                                        oComComprasDet.Stock_Previo = Convert.ToInt32(row["stockPrevio"]);

                                        oComComprasDet.Guardar(oComComprasDet);

                                        //Actualizacion de stock y precios en tabla articulos
                                        DataRow[] drs = dtArticulos.Select("Id = " + Convert.ToInt32(row["id"]));

                                        Articulos oArticulos = new Articulos();
                                        oArticulos.Id = Convert.ToInt32(drs[0]["Id"]);
                                        oArticulos.Descripcion = Convert.ToString(drs[0]["Descripcion"]);
                                        oArticulos.Id_Productos_Rubros = Convert.ToInt32(drs[0]["Id_Articulos_Rubros"]);
                                        oArticulos.Stock = Convert.ToInt32(drs[0]["Stock"]) + Convert.ToInt32(row["cantidad"]);
                                        oArticulos.Stock_Minimo = Convert.ToInt32(drs[0]["Stock_Minimo"]);
                                        oArticulos.Importe = Convert.ToDecimal(row["importe"]);

                                        oArticulos.Guardar(oArticulos);
                                    }
                                    else if (tipoInventario == 2) //Equipos
                                    {
                                        //Guardar nuevo equipo en la tabla equipos
                                        Equipos oEquipo = new Equipos();
                                        oEquipo.Id_Equipos_Estados = 1;
                                        oEquipo.Id_Usuarios = 0;
                                        oEquipo.Id_Usuarios_servicios = 0;
                                        oEquipo.Id_Equipos_Tipos = Convert.ToInt32(row["id_tipo"]);
                                        oEquipo.Id_Equipos_Marcas = Convert.ToInt32(row["id_marca"]);
                                        oEquipo.Id_Equipos_Modelos = Convert.ToInt32(row["id_modelo"]);
                                        oEquipo.Serie = row["serie"].ToString();
                                        oEquipo.Mac = row["mac"].ToString();

                                        int idEquipoNuevo = oEquipo.Guardar(oEquipo);

                                        oComComprasDet.Id_Comprobantes_Compras = oComCompras.Id;
                                        oComComprasDet.Id_Tipo = idEquipoNuevo;
                                        oComComprasDet.Tipo = "E";
                                        oComComprasDet.Cantidad = 0;
                                        oComComprasDet.Importe = Convert.ToDecimal(row["importe"]);
                                        oComComprasDet.Stock_Previo = 0;

                                        oComComprasDet.Guardar(oComComprasDet);
                                    }

                                }

                                MessageBox.Show("Comprobante de compra guardado correctamente", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.DialogResult = DialogResult.OK;
                            }
                            catch (Exception)
                            { MessageBox.Show("Error al guardar comprobante de compra"); }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ingresar el número de remito", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtNumRemito.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Seleccionar un tipo de comprobante", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cboTipoComprobante.Focus();
                }
            }
            else
            {
                MessageBox.Show("Seleccionar un proveedor", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SeleccionDeProveedor();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmConfirmarArticulos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

    }
}
