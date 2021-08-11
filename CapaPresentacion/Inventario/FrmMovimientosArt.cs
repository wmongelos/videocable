using CapaNegocios;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacion.Inventario
{
    public partial class FrmMovimientosArt : Form
    {
        private Int32 ultimoIndiceCombo = 0;
        private Int32 Id_Destinatario = 0;
        private Int32 Id_Articulo = 0;
        private String Destinatario;
        private Double ImporteArt;
        private Int32 Stock;
        private Int32 StockMin;
        private Int32 IdArtRubros;
        private Int32 TotalItems = 0;
        private Int32 Id_Equipo;
        private String MarcaEquipo;
        private String SerieEquipo;
        private String MacEquipo;
        private Int32 id_Equipo_tipo;
        private DataTable dtArticulosSeleccionados;

        public FrmMovimientosArt()
        {
            InitializeComponent();
            CrearDataTable();
            InicializarDGV();
        }

        private void FrmMovimientosArt_Load(object sender, EventArgs e)
        {
            cboTipoDestino.SelectedIndex = 0;
        }

        private DataTable CrearDataTable()
        {
            dtArticulosSeleccionados = new DataTable();

            DataColumn dcIdArt = new DataColumn
            {
                DataType = typeof(Int32),
                ColumnName = "id",
                Unique = true
            };
            dtArticulosSeleccionados.Columns.Add(dcIdArt);

            DataColumn dcArticulo = new DataColumn
            {
                DataType = typeof(String),
                ReadOnly = true,
                ColumnName = "articulo"
            };
            dtArticulosSeleccionados.Columns.Add(dcArticulo);

            DataColumn dcCantidad = new DataColumn
            {
                DataType = typeof(Int32),
                ReadOnly = false,
                ColumnName = "cantidad"
            };
            dtArticulosSeleccionados.Columns.Add(dcCantidad);

            DataColumn dcImporte = new DataColumn
            {
                DataType = typeof(Double),
                ColumnName = "importe"
            };
            dtArticulosSeleccionados.Columns.Add(dcImporte);

            DataColumn dcStock = new DataColumn
            {
                DataType = typeof(Int32),
                ReadOnly = true,
                ColumnName = "stock"
            };
            dtArticulosSeleccionados.Columns.Add(dcStock);

            DataColumn dcStockAct = new DataColumn
            {
                DataType = typeof(Int32),
                ReadOnly = false,
                ColumnName = "stockAct"
            };
            dtArticulosSeleccionados.Columns.Add(dcStockAct);

            DataColumn dcStockMin = new DataColumn
            {
                DataType = typeof(Int32),
                ReadOnly = true,
                ColumnName = "stockMin"
            };
            dtArticulosSeleccionados.Columns.Add(dcStockMin);

            DataColumn dcIdArtRubros = new DataColumn
            {
                DataType = typeof(Int32),
                ReadOnly = true,
                ColumnName = "idArtRubros"
            };
            dtArticulosSeleccionados.Columns.Add(dcIdArtRubros);

            DataColumn dcTipo = new DataColumn
            {
                DataType = typeof(string),
                ReadOnly = true,
                ColumnName = "tipo"
            };
            dtArticulosSeleccionados.Columns.Add(dcTipo);

            DataColumn dcIdEquipoTipo = new DataColumn
            {
                DataType = typeof(string),
                ReadOnly = true,
                ColumnName = "Id_Equipo_Tipo"
            };
            dtArticulosSeleccionados.Columns.Add(dcIdEquipoTipo);
            return dtArticulosSeleccionados;
        }

        private void InicializarDGV()
        {
            dgv.DataSource = dtArticulosSeleccionados;
            dgv.Columns["id"].Visible = false;
            dgv.Columns["Id_Equipo_Tipo"].Visible = false;
            dgv.Columns["importe"].Visible = false;
            dgv.Columns["cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["cantidad"].ReadOnly = false;
            dgv.Columns["cantidad"].HeaderText = "Cantidad";
            dgv.Columns["articulo"].HeaderText = "Articulo/Equipo";
            dgv.Columns["stock"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["stock"].HeaderText = "Stock";
            dgv.Columns["stockAct"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["stockAct"].HeaderText = "Stock Actualizado";
            dgv.Columns["stockAct"].ReadOnly = false;
            dgv.Columns["stockMin"].Visible = false;
            dgv.Columns["idArtRubros"].Visible = false;
            dgv.Columns["Tipo"].Visible = true;
            dgv.Columns["articulo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void btnBuscarDest_Click(object sender, EventArgs e)
        {
            using (frmPopUp frm = new frmPopUp())
            {
                FrmBuscadorGen frmBuscar = new FrmBuscadorGen();

                if (cboTipoDestino.SelectedIndex == 0)
                {
                    frmBuscar.List = FrmBuscadorGen.Tipo.AREAS;
                    this.Destinatario = "A";
                }

                if (cboTipoDestino.SelectedIndex == 1)
                {
                    frmBuscar.List = FrmBuscadorGen.Tipo.PERSONAL;
                    this.Destinatario = "P";
                }

                if (cboTipoDestino.SelectedIndex == 2)
                {
                    frmBuscar.List = FrmBuscadorGen.Tipo.MOVIL;
                    this.Destinatario = "M";
                }

                frm.Formulario = frmBuscar;
                frm.Maximizar = false;

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.Id_Destinatario = frmBuscar.Id;
                    lblDestinatario.Text = frmBuscar.Value;
                    btnGuardar.Enabled = true;
                    btnAgregar.Enabled = true;
                }

            }
        }

        private void btnBuscarArt_Click(object sender, EventArgs e)
        {
            abrirBuscadorGen();
        }

        private void cboTipoDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoDestino.SelectedIndex != this.ultimoIndiceCombo)
            {
                lblDestinatario.Text = "[ SELECCIONAR ]";
                Id_Destinatario = 0;
                btnGuardar.Enabled = false;
                btnAgregar.Enabled = false;
            }
            this.ultimoIndiceCombo = cboTipoDestino.SelectedIndex;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (lblArticulo.Text != "[ SELECCIONAR ]")
            {
                if (txtCantidad.Text != string.Empty)
                {
                    if (rbArticulo.Checked)
                    {
                        try
                        {
                            DataRow dr = dtArticulosSeleccionados.NewRow();

                            dr["id"] = this.Id_Articulo;
                            dr["articulo"] = lblArticulo.Text;
                            dr["cantidad"] = Convert.ToInt32(txtCantidad.Text);
                            dr["importe"] = this.ImporteArt;
                            dr["stock"] = this.Stock;

                            if (rbAsignar.Checked)
                                dr["stockAct"] = this.Stock - Convert.ToInt32(txtCantidad.Text);
                            else
                                dr["stockAct"] = this.Stock + Convert.ToInt32(txtCantidad.Text);

                            dr["stockMin"] = this.StockMin;
                            dr["idArtRubros"] = this.IdArtRubros;
                            dr["tipo"] = "A";

                            dtArticulosSeleccionados.Rows.Add(dr);

                            this.TotalItems += Convert.ToInt32(txtCantidad.Text);
                        }
                        catch (Exception ex)
                        {
                            if (ex.GetType() == typeof(ConstraintException))
                            {
                                if (dgv.SelectedRows.Count > 0)
                                {
                                    this.TotalItems -= Convert.ToInt32(dgv.SelectedCells[2].Value);
                                    this.TotalItems += Convert.ToInt32(txtCantidad.Text);
                                    dgv.SelectedCells[2].Value = Convert.ToInt32(txtCantidad.Text);
                                    dgv.SelectedCells[5].Value = Convert.ToInt32(dgv.SelectedCells[4].Value) - Convert.ToInt32(txtCantidad.Text);
                                }
                            }
                            else
                                MessageBox.Show("Error");
                        }
                    }

                    if (rbEquipo.Checked)
                    {
                        try
                        {
                            DataRow dr = dtArticulosSeleccionados.NewRow();
                            dr["id"] = this.Id_Equipo;

                            if (!String.IsNullOrEmpty(SerieEquipo) && !String.IsNullOrEmpty(MacEquipo))
                                dr["articulo"] = $"{lblArticulo.Text} - Serie:{SerieEquipo} - Mac:{MacEquipo}";
                            else if (!String.IsNullOrEmpty(SerieEquipo))
                                dr["articulo"] = $"{lblArticulo.Text} - Serie:{SerieEquipo}";
                            else if (!String.IsNullOrEmpty(MacEquipo))
                                dr["articulo"] = $"{lblArticulo.Text} - Mac:{MacEquipo}";
                            else
                                dr["articulo"] = $"{lblArticulo.Text}";

                            dr["cantidad"] = 0;
                            dr["importe"] = 0;
                            dr["stock"] = 0;
                            dr["stockAct"] = 0;
                            dr["stockMin"] = 0;
                            dr["tipo"] = "E";
                            dr["id_Equipo_Tipo"] = this.id_Equipo_tipo;
                            dr["cantidad"] = Convert.ToInt32(txtCantidad.Text);
                            dtArticulosSeleccionados.Rows.Add(dr);
                        }
                        catch (Exception ex)
                        {
                            if (ex.GetType() == typeof(ConstraintException))
                            {
                                if (dgv.SelectedRows.Count > 0)
                                {
                                    this.TotalItems -= Convert.ToInt32(dgv.SelectedCells[2].Value);
                                    this.TotalItems += Convert.ToInt32(txtCantidad.Text);
                                    dgv.SelectedCells[2].Value = Convert.ToInt32(txtCantidad.Text);
                                    dgv.SelectedCells[5].Value = Convert.ToInt32(dgv.SelectedCells[4].Value) - Convert.ToInt32(txtCantidad.Text);
                                }
                            }
                            else
                                MessageBox.Show("Error" + ex.Message);
                        }
                    }

                    txtBuscadorArts.Focus();
                    txtBuscadorArts.SelectAll();
                    lblTotal.Text = String.Format("Total de Registros: {0}", dgv.Rows.Count);
                    lblTotalItems.Text = String.Format("Total de items: {0}", this.TotalItems);
                }
                else
                {
                    MessageBox.Show("Debe ingresar la cantidad a agregar");
                    txtCantidad.Focus();
                }
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 0)
            {
                if (MessageBox.Show("¿Confirmar artículos/equipos?", "Mensaje del sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Articulos_Mov oArticulosMov = new Articulos_Mov
                    {
                        Id_Personal = Personal.Id_Login,
                        Fecha = DateTime.Now,
                        Id_Destinatario = this.Id_Destinatario,
                        Destinatario = this.Destinatario
                    };

                    oArticulosMov.Guardar(oArticulosMov);

                    Articulos_Mov_Det oArtMovDet = new Articulos_Mov_Det();
                    Articulos oArticulos = new Articulos();
                    Equipos oEquipos = new Equipos();

                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        if (row.Cells["Tipo"].Value.ToString() == "A")
                        {
                            oArtMovDet.Id_Articulos_Mov = oArticulosMov.Id;
                            oArtMovDet.Id_Articulos = Convert.ToInt32(row.Cells["id"].Value);
                            oArtMovDet.Cantidad = Convert.ToInt32(row.Cells["cantidad"].Value);
                            oArtMovDet.Importe_Unitario = Convert.ToDouble(row.Cells["importe"].Value);
                            oArtMovDet.Tipo = row.Cells["Tipo"].Value.ToString();
                            oArtMovDet.Guardar(oArtMovDet);

                            oArticulos.Id = Convert.ToInt32(row.Cells["id"].Value);
                            oArticulos.Descripcion = row.Cells["articulo"].Value.ToString();
                            oArticulos.Id_Productos_Rubros = Convert.ToInt32(row.Cells["idArtRubros"].Value);
                            oArticulos.Stock = Convert.ToInt32(row.Cells["stockAct"].Value);
                            oArticulos.Stock_Minimo = Convert.ToInt32(row.Cells["stockMin"].Value);
                            oArticulos.Importe = Convert.ToDecimal(row.Cells["importe"].Value);
                            oArticulos.Guardar(oArticulos);
                        }

                        if (row.Cells["Tipo"].Value.ToString() == "E")
                        {
                            string salida = "";

                            oEquipos.CambiarEstado(Convert.ToInt32(row.Cells["id"].Value), (int)Equipos.Equipos_Estados.ASIGNADO_A_DEPARTAMENTO,out salida);
                            oArtMovDet.Id_Articulos_Mov = oArticulosMov.Id;
                            oArtMovDet.Id_Articulos = Convert.ToInt32(row.Cells["id"].Value);
                            oArtMovDet.Cantidad = Convert.ToInt32(row.Cells["cantidad"].Value);
                            oArtMovDet.Importe_Unitario = 0;
                            oArtMovDet.Tipo = row.Cells["Tipo"].Value.ToString();
                            oArtMovDet.Guardar(oArtMovDet);

                        }
                    }
                    if (MessageBox.Show("¿Imprimir asignacion de artículos?", "Mensaje del sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        ImprimirAsignacion(oArticulosMov.Id);
                    }
                    Resetear();
                }
            }
            else
                MessageBox.Show("Tiene que haber al menos un articulo en la grilla", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void abrirBuscadorGen()
        {
            if (rbArticulo.Checked)
            {
                using (frmPopUp frm = new frmPopUp())
                {
                    FrmBuscadorGen frmBuscar = new FrmBuscadorGen(txtBuscadorArts.Text.Trim().ToUpper());
                    frmBuscar.List = FrmBuscadorGen.Tipo.ARTICULOS;

                    frm.Formulario = frmBuscar;
                    frm.Maximizar = false;

                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        lblArticulo.Text = frmBuscar.Value;
                        this.ImporteArt = frmBuscar.ImporteArt;
                        this.Id_Articulo = frmBuscar.Id;
                        this.Stock = frmBuscar.Stock;
                        this.StockMin = frmBuscar.StockMin;
                        this.IdArtRubros = frmBuscar.IdArtRubros;
                        txtCantidad.Focus();
                    }
                }
            }
            if (rbEquipo.Checked)
            {
                using (frmPopUp frm = new frmPopUp())
                {
                    FrmBuscadorGen frmBuscar = new FrmBuscadorGen(txtBuscadorArts.Text.Trim().ToUpper());
                    frmBuscar.List = FrmBuscadorGen.Tipo.EQUIPOS;
                    frm.Formulario = frmBuscar;
                    frm.Maximizar = false;
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        if (!String.IsNullOrEmpty(frmBuscar.Value))
                            lblArticulo.Text = frmBuscar.Value;
                        else
                            lblArticulo.Text = frmBuscar.Equipo;
                        this.Id_Equipo = frmBuscar.Id;
                        this.MarcaEquipo = frmBuscar.MarcaEquipo;
                        this.SerieEquipo = frmBuscar.SerieEquipo;
                        this.MacEquipo = frmBuscar.MacEquipo;
                        this.id_Equipo_tipo = frmBuscar.idEquipoTipo;
                        btnAgregar.Focus();
                    }

                }
            }
        }

        private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            lblArticulo.Text = dgv.Rows[e.RowIndex].Cells["articulo"].Value.ToString();
            txtCantidad.Text = dgv.Rows[e.RowIndex].Cells["cantidad"].Value.ToString();
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            Resetear();
        }

        private void btnSacar_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 0 && dgv.SelectedRows.Count > 0)
            {
                this.TotalItems -= Convert.ToInt32(dgv.SelectedRows[0].Cells["cantidad"].Value);
                dgv.Rows.Remove(dgv.SelectedRows[0]);
                lblTotal.Text = String.Format("Total de Registros: {0}", dgv.Rows.Count);
                lblTotalItems.Text = String.Format("Total de items: {0}", this.TotalItems);
            }
        }

        private void ImprimirAsignacion(int idArtMov)
        {
            Impresiones.Impresion oImpresion = new Impresiones.Impresion();
            try
            {
                this.Cursor = Cursors.WaitCursor;
                oImpresion.ImprimirDetallesAsignacionMoviles(idArtMov, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en la impresion\n{ex.Message}", "Mensaje del sistema");
            }
            finally { this.Cursor = Cursors.Default; }
        }

        private void Resetear()
        {
            dtArticulosSeleccionados.Clear();
            dgv.DataSource = dtArticulosSeleccionados;
            btnGuardar.Enabled = false;
            btnAgregar.Enabled = false;
            txtBuscadorArts.Text = string.Empty;
            txtCantidad.Text = string.Empty;
            lblDestinatario.Text = "[ SELECCIONAR ]";
            lblArticulo.Text = "[ SELECCIONAR ]";
            cboTipoDestino.SelectedIndex = 0;
            this.ultimoIndiceCombo = 0;
            this.TotalItems = 0;
            if (rbEquipo.Checked)
            {
                txtCantidad.Enabled = false;
                txtCantidad.Text = "1";
            }
            lblTotal.Text = String.Format("Total de Registros: {0}", dgv.Rows.Count);
            lblTotalItems.Text = String.Format("Total de items: {0}", this.TotalItems);
            rbAsignar.Checked = true;
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmMovimientosArt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void rbArticulo_CheckedChanged(object sender, EventArgs e)
        {
            txtCantidad.Enabled = true;
            txtCantidad.Text = "";
        }

        private void rbEquipo_CheckedChanged(object sender, EventArgs e)
        {
            txtCantidad.Enabled = false;
            txtCantidad.Text = "1";
        }

        private void txtBuscadorArts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                abrirBuscadorGen();
        }
    }
}

