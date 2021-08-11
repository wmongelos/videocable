using CapaNegocios;
using CapaPresentacion.Abms;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacion.Inventario
{
    public partial class FrmAgregarEquipos : Form
    {
        private Equipos_Tipos oEquipoTipos = new Equipos_Tipos();
        private Equipos_Marcas oEquipoMarcas = new Equipos_Marcas();
        private Equipos_Modelos oEquipoModelos = new Equipos_Modelos();
        private DataTable dtEquiposCompleto;
        private DataTable dtEquiposSelec;
        private DataTable dtTipos;
        private int indicesCargados;

        public FrmAgregarEquipos()
        {
            InitializeComponent();
            CrearDataTable();
            CrearDataTableEquiposCompleto();
            InicializarDGV();
            CargarComboTipos();
            CargarComboMarcas();
            cboMarcaEquipos.SelectedIndexChanged += new EventHandler(cboMarcaEquipos_IndexChanged);
        }

        private void CrearDataTable()
        {
            dtEquiposSelec = new DataTable();

            DataColumn dcIndice = new DataColumn
            {
                DataType = typeof(int),
                ColumnName = "indice"
            };
            dtEquiposSelec.Columns.Add(dcIndice);

            DataColumn dcTipoId = new DataColumn
            {
                DataType = typeof(Int32),
                ColumnName = "id_tipo"
            };
            dtEquiposSelec.Columns.Add(dcTipoId);

            DataColumn dcTipo = new DataColumn
            {
                DataType = typeof(string),
                ColumnName = "tipo"
            };
            dtEquiposSelec.Columns.Add(dcTipo);

            DataColumn dcMarcaId = new DataColumn
            {
                DataType = typeof(Int32),
                ColumnName = "id_marca"
            };
            dtEquiposSelec.Columns.Add(dcMarcaId);

            DataColumn dcMarca = new DataColumn
            {
                DataType = typeof(string),
                ColumnName = "marca"
            };
            dtEquiposSelec.Columns.Add(dcMarca);

            DataColumn dcModeloId = new DataColumn
            {
                DataType = typeof(Int32),
                ColumnName = "id_modelo"
            };
            dtEquiposSelec.Columns.Add(dcModeloId);

            DataColumn dcModelo = new DataColumn
            {
                DataType = typeof(string),
                ColumnName = "modelo"
            };
            dtEquiposSelec.Columns.Add(dcModelo);

            DataColumn dcCantidad = new DataColumn
            {
                DataType = typeof(int),
                ColumnName = "cantidad"
            };
            dtEquiposSelec.Columns.Add(dcCantidad);

            DataColumn dcImporte = new DataColumn
            {
                DataType = typeof(Decimal),
                ColumnName = "importe_unitario"
            };
            dtEquiposSelec.Columns.Add(dcImporte);

            DataColumn dcConfirmado = new DataColumn
            {
                DataType = typeof(bool),
                DefaultValue = false,
                ColumnName = "confirmado"
            };
            dtEquiposSelec.Columns.Add(dcConfirmado);
        }

        public void CrearDataTableEquiposCompleto()
        {
            dtEquiposCompleto = new DataTable();

            DataColumn dcIndice = new DataColumn
            {
                DataType = typeof(int),
                ColumnName = "indice"
            };
            dtEquiposCompleto.Columns.Add(dcIndice);

            DataColumn dcTipoId = new DataColumn
            {
                DataType = typeof(int),
                ColumnName = "id_tipo"
            };
            dtEquiposCompleto.Columns.Add(dcTipoId);

            DataColumn dcMarcaId = new DataColumn
            {
                DataType = typeof(int),
                ColumnName = "id_marca"
            };
            dtEquiposCompleto.Columns.Add(dcMarcaId);

            DataColumn dcModeloId = new DataColumn
            {
                DataType = typeof(int),
                ColumnName = "id_modelo"
            };
            dtEquiposCompleto.Columns.Add(dcModeloId);

            DataColumn dcImporte = new DataColumn
            {
                DataType = typeof(decimal),
                ColumnName = "importe"
            };
            dtEquiposCompleto.Columns.Add(dcImporte);

            DataColumn dcSerie = new DataColumn
            {
                DataType = typeof(string),
                ColumnName = "serie"
            };
            dtEquiposCompleto.Columns.Add(dcSerie);

            DataColumn dcMac = new DataColumn
            {
                DataType = typeof(string),
                ColumnName = "mac"
            };
            dtEquiposCompleto.Columns.Add(dcMac);
        }

        private void InicializarDGV()
        {
            dgv.DataSource = dtEquiposSelec;

            foreach (DataGridViewColumn col in dgv.Columns)
                col.Visible = false;

            dgv.Columns["tipo"].Visible = true;
            dgv.Columns["marca"].Visible = true;
            dgv.Columns["modelo"].Visible = true;
            dgv.Columns["cantidad"].Visible = true;
            dgv.Columns["importe_unitario"].Visible = true;
            dgv.Columns["confirmado"].Visible = true;
            dgv.Columns["tipo"].HeaderText = "Tipo";
            dgv.Columns["marca"].HeaderText = "Marca";
            dgv.Columns["modelo"].HeaderText = "Modelo";
            dgv.Columns["cantidad"].HeaderText = "Cantidad";
            dgv.Columns["importe_unitario"].HeaderText = "Importe unitario";
            dgv.Columns["confirmado"].HeaderText = "Equipos seleccionados";
        }

        private void CargarComboTipos()
        {
            dtTipos = oEquipoTipos.Listar();
            cboTipoEquipos.DataSource = dtTipos;
            cboTipoEquipos.DisplayMember = "Nombre";
            cboTipoEquipos.ValueMember = "Id";
            cboTipoEquipos.SelectedIndex = -1;
        }

        private void CargarComboMarcas()
        {

            cboMarcaEquipos.DataSource = oEquipoMarcas.Listar();
            cboMarcaEquipos.DisplayMember = "Nombre";
            cboMarcaEquipos.ValueMember = "Id";
            cboMarcaEquipos.SelectedIndex = -1;
        }

        private void CargarComboModelos()
        {
            DataRow[] drs = oEquipoModelos.Listar().Select("Id_Equipos_Marcas = " + Convert.ToInt32(cboMarcaEquipos.SelectedValue));
            if (drs.Length > 0)
            {
                cboModeloEquipos.DataSource = drs.CopyToDataTable();
                cboModeloEquipos.DisplayMember = "Nombre";
                cboModeloEquipos.ValueMember = "Id";
                cboModeloEquipos.SelectedIndex = -1;
            }
        }

        private void CargarEquipo()
        {
            if (cboTipoEquipos.SelectedIndex != -1)
            {
                if (cboMarcaEquipos.SelectedIndex != -1)
                {
                    if (cboModeloEquipos.SelectedIndex != -1)
                    {
                        if (!String.IsNullOrEmpty(txtCantidad.Text))
                        {
                            DataRow dr = dtEquiposSelec.NewRow();

                            dr["indice"] = indicesCargados;
                            dr["id_tipo"] = Convert.ToInt32(cboTipoEquipos.SelectedValue);
                            dr["tipo"] = cboTipoEquipos.Text;
                            dr["id_marca"] = Convert.ToInt32(cboMarcaEquipos.SelectedValue);
                            dr["marca"] = cboMarcaEquipos.Text;
                            dr["id_modelo"] = Convert.ToInt32(cboModeloEquipos.SelectedValue);
                            dr["modelo"] = cboModeloEquipos.Text;
                            dr["cantidad"] = Convert.ToInt32(txtCantidad.Text);
                            dr["importe_unitario"] = spImporte.Value;

                            dtEquiposSelec.Rows.Add(dr);

                            lblTotal.Text = String.Format("Total de Registros: {0}", dgv.Rows.Count);
                            indicesCargados++;
                            cboTipoEquipos.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Seleccionar una cantidad de equipos", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtCantidad.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Seleccionar un modelo de equipo", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cboModeloEquipos.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Seleccionar una marca", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cboMarcaEquipos.Focus();
                }
            }
            else
            {
                MessageBox.Show("Seleccionar un tipo de equipos", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboTipoEquipos.Focus();
            }
        }

        private void SacarEquipo()
        {
            if (dgv.Rows.Count > 0 && dgv.SelectedRows.Count > 0)
            {
                int indiceABorrar = Convert.ToInt32(dgv.SelectedRows[0].Cells["indice"].Value);
                for (int i = 0; i < dtEquiposCompleto.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dtEquiposCompleto.Rows[i][0]) == indiceABorrar)
                    {
                        dtEquiposCompleto.Rows[i].Delete();
                        i--;
                    }
                }
                dgv.Rows.Remove(dgv.SelectedRows[0]);
                lblTotal.Text = String.Format("Total de Registros: {0}", dgv.Rows.Count);
                if (dgv.Rows.Count == 0)
                    Reset();
            }
        }

        private void ModificarEquipo()
        {
            if (dgv.Rows.Count > 0 && dgv.SelectedRows.Count > 0)
            {
                if (!Convert.ToBoolean(dgv.SelectedRows[0].Cells["confirmado"].Value))
                {
                    dgv.SelectedRows[0].Cells["id_tipo"].Value = Convert.ToInt32(cboTipoEquipos.SelectedValue);
                    dgv.SelectedRows[0].Cells["tipo"].Value = cboTipoEquipos.Text;
                    dgv.SelectedRows[0].Cells["id_marca"].Value = Convert.ToInt32(cboMarcaEquipos.SelectedValue);
                    dgv.SelectedRows[0].Cells["marca"].Value = cboMarcaEquipos.Text;
                    dgv.SelectedRows[0].Cells["id_modelo"].Value = Convert.ToInt32(cboModeloEquipos.SelectedValue);
                    dgv.SelectedRows[0].Cells["modelo"].Value = cboModeloEquipos.Text;
                    dgv.SelectedRows[0].Cells["cantidad"].Value = txtCantidad.Text;
                    dgv.SelectedRows[0].Cells["importe_unitario"].Value = spImporte.Value;
                }
                else
                {
                    MessageBox.Show("No se puede modificar equipos con el mac o serie ya asginados, se tiene que borrar el registro y crear otro");
                }
            }
        }

        private void ConfirmarEquipos()
        {
            if (dtEquiposCompleto.Rows.Count > 0)
            {
                bool flag = false;
                DialogResult = DialogResult.Yes;
                foreach (DataGridViewRow row in dgv.Rows)
                    if (!Convert.ToBoolean(row.Cells["confirmado"].Value))
                    { flag = true; break; }
                if (flag)
                    DialogResult = MessageBox.Show("Hay equipos que no se le seleccionaron los series y/o mac \nSi continua los equipos sin asignación no se guardaran \n¿Continuar de todos modos?", "Mensaje del sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (DialogResult == DialogResult.Yes)
                {
                    using (frmPopUp frm = new frmPopUp())
                    {
                        FrmConfirmarComprobantesCompras frmConf = new FrmConfirmarComprobantesCompras(dtEquiposCompleto, 2);
                        frm.Formulario = frmConf;
                        frm.Maximizar = false;
                        if (frm.ShowDialog() == DialogResult.OK)
                            Reset();
                    }
                }

            }
            else
                MessageBox.Show("No se confirmo ningun numero de Mac o Serie", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void IntroducirMacYSerie()
        {
            if (dgv.SelectedRows.Count > 0)
            {
                using (frmPopUp frm = new frmPopUp())
                {
                    DataRow[] drs = dtTipos.Select("id = " + Convert.ToInt32(dgv.SelectedRows[0].Cells["id_tipo"].Value));
                    int verificarSerie = Convert.ToInt32(drs[0]["Verificar_Serie"]);
                    int verificarMac = Convert.ToInt32(drs[0]["Verificar_Mac"]);

                    ABMEquipos_Stock frmAbm = new ABMEquipos_Stock(Convert.ToInt32(dgv.SelectedRows[0].Cells["id_tipo"].Value),
                                                                    Convert.ToInt32(dgv.SelectedRows[0].Cells["id_marca"].Value),
                                                                    Convert.ToInt32(dgv.SelectedRows[0].Cells["id_modelo"].Value),
                                                                    Convert.ToInt32(dgv.SelectedRows[0].Cells["cantidad"].Value),
                                                                    verificarSerie, verificarMac, false);

                    frm.Formulario = frmAbm;
                    frm.Maximizar = false;
                    if (frm.ShowDialog() == DialogResult.OK)
                        CargarDataTableEquiposCompleto(frmAbm.dt);
                }
            }
        }

        private void CargarDataTableEquiposCompleto(DataTable dtAdd)
        {
            for (int i = 0; i < dtAdd.Rows.Count; i++)
            {
                DataRow dr = dtEquiposCompleto.NewRow();
                dr["indice"] = Convert.ToInt32(dgv.SelectedRows[0].Cells["indice"].Value);
                dr["id_tipo"] = Convert.ToInt32(dgv.SelectedRows[0].Cells["id_tipo"].Value);
                dr["id_marca"] = Convert.ToInt32(dgv.SelectedRows[0].Cells["id_marca"].Value);
                dr["id_modelo"] = Convert.ToInt32(dgv.SelectedRows[0].Cells["id_modelo"].Value);
                dr["importe"] = Convert.ToDecimal(dgv.SelectedRows[0].Cells["importe_unitario"].Value);
                dr["serie"] = dtAdd.Rows[i][0].ToString();
                dr["mac"] = dtAdd.Rows[i][1].ToString();
                dtEquiposCompleto.Rows.Add(dr);
            }
            dgv.SelectedRows[0].Cells["cantidad"].Value = dtAdd.Rows.Count;
            txtCantidad.Text = dtAdd.Rows.Count.ToString();
            dgv.SelectedRows[0].Cells["confirmado"].Value = true;
            dgv.Refresh();
        }

        private void Reset()
        {
            dtEquiposCompleto.Clear();
            dtEquiposSelec.Clear();
            dgv.DataSource = dtEquiposSelec;
            dgv.Refresh();
            cboTipoEquipos.SelectedIndex = -1;
            cboMarcaEquipos.SelectedIndex = -1;
            cboModeloEquipos.SelectedIndex = -1;
            txtCantidad.Text = string.Empty;
            spImporte.Value = Decimal.Zero;
        }

        private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            cboTipoEquipos.SelectedValue = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["id_tipo"].Value);
            cboMarcaEquipos.SelectedValue = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["id_marca"].Value);
            cboModeloEquipos.SelectedValue = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["id_modelo"].Value);
            txtCantidad.Text = dgv.Rows[e.RowIndex].Cells["cantidad"].Value.ToString();
            spImporte.Value = Convert.ToDecimal(dgv.Rows[e.RowIndex].Cells["importe_unitario"].Value);
        }

        private void dgv_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dgv.Rows[e.RowIndex].Selected = true;
        }

        private void cboMarcaEquipos_IndexChanged(object sender, EventArgs e)
        {
            cboModeloEquipos.Enabled = true;
            CargarComboModelos();
        }

        private void llAddTipo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (frmPopUp frm = new frmPopUp())
            {
                ABMEquipos_Tipos frmAbm = new ABMEquipos_Tipos();

                frm.Formulario = frmAbm;
                frm.Maximizar = false;
                frm.ShowDialog();
            }
        }

        private void llAddMarca_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (frmPopUp frm = new frmPopUp())
            {
                ABMEquipos_Marcas frmAbm = new ABMEquipos_Marcas();

                frm.Formulario = frmAbm;
                frm.Maximizar = false;
                frm.ShowDialog();
            }
        }

        private void llAddModelo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (frmPopUp frm = new frmPopUp())
            {
                ABMEquipos_Modelos frmAbm = new ABMEquipos_Modelos();

                frm.Formulario = frmAbm;
                frm.Maximizar = false;
                frm.ShowDialog();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            CargarEquipo();
            IntroducirMacYSerie();
        }

        private void btnIntroducirEquipos_Click(object sender, EventArgs e)
        {
            IntroducirMacYSerie();
        }

        private void btnSacar_Click(object sender, EventArgs e)
        {
            SacarEquipo();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ModificarEquipo();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            ConfirmarEquipos();
        }

        public Panel GetPanel()
        {
            return this.pnlEquipos;
        }

    }
}
