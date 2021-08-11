using CapaNegocios;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CapaPresentacion.Contabilidad
{
    public partial class frmCambioPuntosVenta : Form
    {
        private DataTable dt;

        public frmCambioPuntosVenta()
        {
            InitializeComponent();
        }

        private void frmCambioPuntosVenta_Load(object sender, EventArgs e)
        {
            dt = new Puntos_Venta_Comp().ListarPuntosVentaCompConPresentaVentas(Puntos_Cobros.Id_Punto);
            dt.Columns.Add(new DataColumn("predeterminado1", typeof(bool)) { ReadOnly = false });
            formatearDataGridView();
        }

        private void formatearDataGridView()
        {
            dgv.DataSource = dt;
            dgv.Columns["predeterminado1"].ReadOnly = false;

            foreach (DataGridViewRow row in dgv.Rows)
                row.Cells["predeterminado1"].Value = Convert.ToBoolean(row.Cells["predeterminado"].Value); 
            foreach (DataGridViewColumn col in dgv.Columns)
                col.Visible = false;

            dgv.Columns["comprobante_tipo"].Visible = true;
            dgv.Columns["comprobante_tipo"].HeaderText = "Comprobante tipo";
            dgv.Columns["descripcion"].Visible = true;
            dgv.Columns["descripcion"].HeaderText = "Punto de venta";
            dgv.Columns["predeterminado1"].Visible = true;
            dgv.Columns["predeterminado1"].HeaderText = "Predeterminado";
        }

        private void CambiarPuntos(Modalidad_Facturacion.TIPO tipoModalidad)
        {
            foreach (DataRow row in dt.Rows)
            {
                int idTipoComp = Convert.ToInt32(row["id_tipo_comp"]);
                DataTable dtComp = (from myRow in dt.AsEnumerable()
                                    where myRow.Field<int>("id_tipo_comp") == idTipoComp
                                    select myRow).CopyToDataTable();

                bool tienePuntoSeleccionado = false;
                foreach (DataRow rowComp in dtComp.Rows)
                    if (Convert.ToInt32(rowComp["Id_Modalidad_Fact"]) == (int)tipoModalidad)
                        tienePuntoSeleccionado = true;

                if (tienePuntoSeleccionado)
                {
                    bool predeterminadoYaAsignado = false;
                    foreach (DataRow rowComp in dt.Rows)
                    {
                        if(Convert.ToInt32(rowComp["id_tipo_comp"]) == idTipoComp)
                        {
                            if (Convert.ToInt32(rowComp["Id_Modalidad_Fact"]) == (int)tipoModalidad)
                            {
                                if (!predeterminadoYaAsignado)
                                {
                                    rowComp["predeterminado"] = 1;
                                    rowComp["predeterminado1"] = true;
                                    predeterminadoYaAsignado = true;
                                }
                                else
                                {
                                    rowComp["predeterminado"] = 0;
                                    rowComp["predeterminado1"] = false;
                                }
                            }
                            else
                            {
                                rowComp["predeterminado"] = 0;
                                rowComp["predeterminado1"] = false;
                            }
                        }
                    }
                }

            }
        }

        private void GuardarPuntos()
        {
            foreach (DataRow row in dt.Rows)
            {
                Comprobantes_Habilitados oCompHabilitados = new Comprobantes_Habilitados();

                DataTable dtCompHab = oCompHabilitados.Listar(Puntos_Cobros.Id_Punto, true);
                DataRow[] dr = dtCompHab.Select($"Id_Punto_Vta_Comp = {Convert.ToInt32(row["id_puntos_venta_comp"])}");

                if (dr.Length > 0)
                    oCompHabilitados.Id = Convert.ToInt32(dr[0]["id"]);
                else
                    oCompHabilitados.Id = 0;

                oCompHabilitados.Id_Punto_Vta_Comp = Convert.ToInt32(row["id_puntos_venta_comp"]);
                oCompHabilitados.Id_Punto_Cobro = Puntos_Cobros.Id_Punto;
                oCompHabilitados.Predeterminado = Convert.ToInt32(row["predeterminado"]);
                oCompHabilitados.Guardar(oCompHabilitados);
            }
            MessageBox.Show("Puntos cambiados correctamente", "Mensaje del sistema");
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.Columns[e.ColumnIndex].Name == "predeterminado1")
            {
                int idTipoComp = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["id_tipo_comp"].Value);

                int cont = 0;
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (Convert.ToInt32(row.Cells["id_tipo_comp"].Value) == idTipoComp)
                        cont++;
                }

                if(cont == 1)
                {
                    dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 1;
                    dgv.Rows[e.RowIndex].Cells["predeterminado"].Value = 1;
                    return;
                }

                dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = !Convert.ToBoolean(dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                dgv.Rows[e.RowIndex].Cells["predeterminado"].Value = !Convert.ToBoolean(dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) ? 0 : 1;

                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    if(i != e.RowIndex && idTipoComp == Convert.ToInt32(dgv.Rows[i].Cells["id_tipo_comp"].Value))
                    {
                        dgv.Rows[i].Cells[e.ColumnIndex].Value = 0;
                        dgv.Rows[i].Cells["predeterminado"].Value = 0;
                    }
                }
            }
        }

        private void btnActManual_Click(object sender, EventArgs e)
        {
            CambiarPuntos(Modalidad_Facturacion.TIPO.MANUAL);
        }

        private void btnActElectronica_Click(object sender, EventArgs e)
        {
            CambiarPuntos(Modalidad_Facturacion.TIPO.ELECTRONICA);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarPuntos();
            this.DialogResult = DialogResult.OK;
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCambioPuntosVenta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
