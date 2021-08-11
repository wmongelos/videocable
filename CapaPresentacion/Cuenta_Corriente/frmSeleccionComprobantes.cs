using CapaNegocios;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion.Cuenta_Corriente
{
    public partial class frmSeleccionComprobantes : Form
    {
        #region PROPIEDADES
        public DataTable dtComprobantes;
        private bool permitirSeleccionarUnoSolo;
        private bool permitirImportesEnCero;
        public bool NotaDeCredito = false;

        #endregion

        #region METODOS
        private void FormatearGrilla()
        {
            try
            {
                Decimal saldo = 0;
                foreach (DataGridViewRow dr in dgvComprobantes.Rows)
                {
                    if (dr.Cells["tipo"].Value.ToString() == "F")
                    {
                        if (Convert.ToInt32(dr.Cells["id_comprobantes_tipo"].Value.ToString()) == (int)Comprobantes_Tipo.Tipo.CREDITO_A_CUENTA)
                        {
                            dr.Cells["importe_pago"].Value = 0;
                        }
                        else
                        {
                            dr.Cells["importe_pago"].Value = 0;
                            dr.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                            dr.DefaultCellStyle.ForeColor = Color.Black;
                        }
                    }
                    else
                    {
                        dr.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                        dr.Cells["importe_saldo_comprobante"].Value = 0;
                        dr.Cells["importe_saldo_comprobante"].Style.ForeColor = Color.Transparent;
                        dr.Cells["descripcion"].Value = dr.Cells["descripcion"].Value.ToString();
                    }
                    dr.Cells["importe_saldo"].Style.ForeColor = Color.Black;
                    dr.Cells["importe_saldo"].Style.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                    saldo = (decimal.Parse(dr.Cells["importe_final"].Value.ToString()) - decimal.Parse(dr.Cells["importe_pago"].Value.ToString()));
                }
                dgvComprobantes.ReadOnly = false;
                foreach (DataGridViewColumn item in dgvComprobantes.Columns)
                {
                    item.Visible = false;
                    item.SortMode = DataGridViewColumnSortMode.NotSortable;
                    if (item.Name == "seleccionar")
                        item.ReadOnly = false;
                    else
                        item.ReadOnly = true;
                }


                dgvComprobantes.Columns["seleccionar"].Visible = true;

                dgvComprobantes.Columns["fecha_movimiento"].Visible = true;
                dgvComprobantes.Columns["fecha_movimiento"].HeaderText = "FECHA";
                dgvComprobantes.Columns["fecha_movimiento"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvComprobantes.Columns["fecha_movimiento"].DisplayIndex = 0;

                dgvComprobantes.Columns["descripcion"].Visible = true;
                dgvComprobantes.Columns["descripcion"].Width = 300;
                dgvComprobantes.Columns["descripcion"].HeaderText = "DETALLE";
                dgvComprobantes.Columns["descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dgvComprobantes.Columns["fecha_desde"].Visible = true;
                dgvComprobantes.Columns["fecha_desde"].HeaderText = "DESDE";
                dgvComprobantes.Columns["fecha_desde"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;


                dgvComprobantes.Columns["Importe_saldo"].Visible = true;
                dgvComprobantes.Columns["Importe_saldo"].DefaultCellStyle.Format = "c2";
                dgvComprobantes.Columns["Importe_saldo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvComprobantes.Columns["importe_saldo"].Width = 150;
                dgvComprobantes.Columns["Importe_saldo"].HeaderText = "SALDO";
                dgvComprobantes.Columns["Importe_saldo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                dgvComprobantes.Columns["Importe_final"].Visible = true;
                dgvComprobantes.Columns["Importe_final"].DefaultCellStyle.Format = "c2";
                dgvComprobantes.Columns["Importe_final"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvComprobantes.Columns["Importe_final"].Width = 150;
                dgvComprobantes.Columns["Importe_final"].HeaderText = "IMPORTE FINAL";
                dgvComprobantes.Columns["Importe_final"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvComprobantes.Columns["Importe_final"].DisplayIndex = dgvComprobantes.Columns["Importe_saldo"].DisplayIndex - 1;
                dgvComprobantes.Columns["seleccionar"].DisplayIndex = 0;
                dgvComprobantes.Columns["seleccionar"].HeaderText = "Seleccionar";
                dgvComprobantes.Columns["seleccionar"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

                if (dgvComprobantes.Columns["DetelleComp"] == null)
                {
                    DataGridViewLinkColumn link = new DataGridViewLinkColumn();

                    link.Text = "Detalle";
                    link.DataPropertyName = "Detalle";
                    link.Name = "cDetalle";
                    link.LinkColor = Color.White;
                    link.VisitedLinkColor = Color.White;
                    link.UseColumnTextForLinkValue = true;
                    link.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    link.HeaderText = "Detalle de Comp.";
                    link.DefaultCellStyle.BackColor = Color.White;

                    dgvComprobantes.Columns.Add(link);
                }

                //coloreo la grilla segun el tipo de comprobante
                if (dgvComprobantes.Rows.Count > 0)
                {
                    foreach (DataGridViewRow item in dgvComprobantes.Rows)
                    {
                        int idTipoComprobante = Convert.ToInt32(item.Cells["id_comprobantes_Tipo"].Value);
                        switch (idTipoComprobante)
                        {
                            case 10:
                                //Tipo Plan de pago
                                item.DefaultCellStyle.BackColor = Color.LightGreen;

                                break;
                            case 7:
                                //comprobante de deuda
                                item.DefaultCellStyle.BackColor = Color.LightBlue;
                                break;
                            case 5:
                                //recibo
                                item.DefaultCellStyle.BackColor = Color.Thistle;
                                break;
                            case 9:
                                //recibo
                                item.DefaultCellStyle.BackColor = Color.Thistle;
                                break;
                            default:
                                item.DefaultCellStyle.BackColor = Color.White;
                                break;
                        }
                        item.Height = 30;
                        if (Convert.ToDecimal(item.Cells["Importe_saldo"].Value) > 0)
                        {
                            item.DefaultCellStyle.BackColor = Color.Tomato;
                        }
                    }

                }
            }
            catch { }

        }

        #endregion
        public frmSeleccionComprobantes(bool permitirSeleccionarUnoSolo, bool permitirImportesEnCero)
        {
            InitializeComponent();
            this.permitirSeleccionarUnoSolo = permitirSeleccionarUnoSolo;
            this.permitirImportesEnCero = permitirImportesEnCero;
        }

        private void CargarInformacion()
        {
            DataColumn dcSeleccionar = new DataColumn();
            dcSeleccionar.ColumnName = "seleccionar";
            dcSeleccionar.DataType = typeof(bool);
            dcSeleccionar.DefaultValue = false;
            dtComprobantes.Columns.Add(dcSeleccionar);
            dgvComprobantes.DataSource = dtComprobantes;
            if (NotaDeCredito)
                lbTitulo.Text = "Seleccionar facturas";
            FormatearGrilla();
        }

        private void frmSeleccionComprobantes_Load(object sender, EventArgs e)
        {
            CargarInformacion();
        }


        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (permitirSeleccionarUnoSolo)
            {
                int cantidadSeleccionados = 0;
                foreach (DataGridViewRow row in dgvComprobantes.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["seleccionar"].Value))
                        cantidadSeleccionados++;
                }
                if(cantidadSeleccionados > 1)
                {
                    MessageBox.Show("No es posible seleccionar mas de un comprobante", "Mensaje del sistema");
                    return;
                }
            }

            DataTable dtComprobantesSeleccionados;
            Boolean importesCero = false;
            DataView dv = dtComprobantes.DefaultView;
            dv.RowFilter = "seleccionar=true";
            dtComprobantesSeleccionados = dv.ToTable();
            if(dtComprobantesSeleccionados.Rows.Count == 0)
            {
                MessageBox.Show("Para realizar la factura es necesario seleccionar al menos un comprobante", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dv.RowFilter = "";
                FormatearGrilla();
                return;
            }
            if (!permitirImportesEnCero)
            {
                foreach (DataRow item in dtComprobantesSeleccionados.Rows)
                {
                    if (Convert.ToDecimal(item["importe_final"]) == 0)
                        importesCero = true;
                }
                if (importesCero)
                {
                    MessageBox.Show("No se puede pasar a factura comprobantes con importe en cero.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dv.RowFilter = "";
                    FormatearGrilla();
                    return;
                }
            }
            this.dtComprobantes = dtComprobantesSeleccionados;
            this.DialogResult = DialogResult.OK;
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void frmSeleccionComprobantes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
