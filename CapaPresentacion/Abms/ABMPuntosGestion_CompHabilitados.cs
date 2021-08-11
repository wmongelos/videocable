using CapaNegocios;
using System;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Abms
{
    public partial class ABMPuntosGestion_CompHabilitados : Form
    {
        public int id_punto_cobro = 0;
        string sucursalPuntoCobro;
        string descripcionPuntoCobro;

        private Thread hilo;
        private delegate void myDel();
        DataTable dtPtoVentaComp = new DataTable();
        DataTable dtTipoComprobantes = new DataTable();
        DataTable dtComprobantesHab = new DataTable();
        Puntos_Venta_Comp oPuntos_Venta_Comp = new Puntos_Venta_Comp();
        Comprobantes_Habilitados oComprobantesHab = new Comprobantes_Habilitados();
        TipoComprobantes oTipoComprobantes = new TipoComprobantes();

        private void comenzarCarga()
        {
            pgCircular.Start();

            //dgvTiposComp.DataSource = null;

            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
        }

        private void cargarDatos()
        {
            dtTipoComprobantes = oTipoComprobantes.Listar();
            dtPtoVentaComp = oPuntos_Venta_Comp.Listar();
            dtComprobantesHab = oComprobantesHab.Listar(id_punto_cobro);

            var colPredeterminado = new DataColumn("Predeterminado", typeof(bool));
            colPredeterminado.DefaultValue = false;
            dtPtoVentaComp.Columns.Add(colPredeterminado);

            var colElegir = new DataColumn("Elegir", typeof(bool));
            colElegir.DefaultValue = false;
            dtPtoVentaComp.Columns.Add(colElegir);

            myDel MD = new myDel(asignarDatos);

            this.Invoke(MD, new object[] { });

            pgCircular.Stop();

        }

        private void asignarDatos()
        {
            dgvTiposComprobantes.DataSource = dtTipoComprobantes;

            dgvTiposComprobantes.Columns["id"].Visible = false;
            dgvTiposComprobantes.Columns["Presenta_Ventas"].Visible = false;
            dgvTiposComprobantes.Columns["nombre"].HeaderText = "Nombre";
            dgvTiposComprobantes.Columns["letra"].HeaderText = "Letra";

            dgvTiposComprobantes.Columns["codigo_afip"].HeaderText = "Código Afip";

            dgvTiposComprobantes.Focus();

            if (dgvTiposComprobantes.Rows.Count > 0)
                ArmarTablaPuntosVenta();
        }

        public void ArmarTablaPuntosVenta()
        {
            try
            {
                dtPtoVentaComp.DefaultView.RowFilter = "id_comprobantes_tipo = " + dgvTiposComprobantes.SelectedRows[0].Cells["id"].Value;
                if (dtComprobantesHab.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtPtoVentaComp.Rows)
                    {
                        Int32 id = Convert.ToInt32(dr["Id"]);

                        DataRow[] drFilter = dtComprobantesHab.Select(String.Format("id_punto_vta_comp = {0}", id));
                        if (drFilter.Length > 0)
                        {
                            dr["Elegir"] = true;

                            if (Convert.ToInt32(drFilter[0]["predeterminado"]) == 1)
                                dr["Predeterminado"] = true;
                        }

                    }
                }


            }
            catch { }

            dgvPuntosVentaHab.DataSource = dtPtoVentaComp;
            dgvPuntosVentaHab.Columns["id"].Visible = false;
            dgvPuntosVentaHab.Columns["id_punto_venta"].Visible = false;
            dgvPuntosVentaHab.Columns["id_comprobantes_tipo"].Visible = false;
        }

        public void Guardar()
        {
            try
            {
                bool predeterminadoValido = false;
                bool seSeleccionAlMenosUno = false;
                foreach (DataGridViewRow fila in dgvPuntosVentaHab.Rows)
                {
                    if (Convert.ToBoolean(fila.Cells["Elegir"].Value))
                    {
                        seSeleccionAlMenosUno = true;
                        if (Convert.ToBoolean(fila.Cells["Predeterminado"].Value))
                            predeterminadoValido = true;
                    }
                }

                if (!predeterminadoValido && seSeleccionAlMenosUno)
                {
                    MessageBox.Show("El punto de venta predeterminado no es valido", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                foreach (DataGridViewRow row in dgvPuntosVentaHab.Rows)
                {
                    DataTable dtCompHab = oComprobantesHab.Listar(this.id_punto_cobro, true);
                    DataRow[] dr = dtCompHab.Select("Id_Punto_Vta_Comp = " + Convert.ToInt32(row.Cells["id"].Value));
                    if (Convert.ToBoolean(row.Cells["Elegir"].Value))
                    {
                        if (dr.Length > 0)
                            oComprobantesHab.Id = Convert.ToInt32(dr[0]["id"]);
                        else
                            oComprobantesHab.Id = 0;

                        oComprobantesHab.Id_Punto_Vta_Comp = Convert.ToInt32(row.Cells["id"].Value);
                        oComprobantesHab.Id_Punto_Cobro = this.id_punto_cobro;
                        int predeterminado = (Convert.ToBoolean(row.Cells["Predeterminado"].Value)) ? 1 : 0;
                        oComprobantesHab.Predeterminado = predeterminado;
                        oComprobantesHab.Borrado = 0;
                        oComprobantesHab.Guardar(oComprobantesHab);
                    }
                    else
                    {
                        if (dr.Length > 0)
                        {
                            oComprobantesHab.Id = Convert.ToInt32(dr[0]["id"]);
                            oComprobantesHab.Id_Punto_Vta_Comp = Convert.ToInt32(row.Cells["id"].Value);
                            oComprobantesHab.Id_Punto_Cobro = this.id_punto_cobro;
                            oComprobantesHab.Predeterminado = 0;
                            oComprobantesHab.Borrado = 1;
                            oComprobantesHab.Guardar(oComprobantesHab);
                        }
                    }
                }

                MessageBox.Show("Los puntos de ventas fueron modificados correctamente!", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw;
            }

            comenzarCarga();

        }

        private bool Predeterminados()
        {
            bool resultado = false;

            foreach (DataGridViewRow fila in dgvPuntosVentaHab.Rows)
            {
                if (Convert.ToInt32(fila.Cells["colPredeterminado"].Value) == 1)
                {
                    resultado = true;
                    break;
                }
            }
            return resultado;
        }

        public void ColorearGrillaPtosVenta()
        {
            foreach (DataGridViewRow fila in dgvPuntosVentaHab.Rows)
            {
                if (Convert.ToInt32(fila.Cells["colSeleccion"].Value) == 1)
                    fila.DefaultCellStyle.BackColor = Color.Silver;
            }
        }

        public ABMPuntosGestion_CompHabilitados(int id_punto, string sucursal, string descripcion)
        {
            id_punto_cobro = id_punto;
            sucursalPuntoCobro = sucursal;
            descripcionPuntoCobro = descripcion;
            InitializeComponent();
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void ABMAsigancionComprobantesTipos_Load(object sender, EventArgs e)
        {

            lblSucursal.Text = String.Format("Sucursal: {0}", sucursalPuntoCobro);
            lblDescripcion.Text = String.Format("Descripción: {0}", descripcionPuntoCobro);
            comenzarCarga();
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void dgvTiposComprobantes_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            ArmarTablaPuntosVenta();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void ABMCompHabilitados_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.DialogResult = DialogResult.OK;
        }

        private void dgvPuntosVentaHab_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPuntosVentaHab.Columns[e.ColumnIndex].Name == "Predeterminado")
            {
                foreach (DataGridViewRow row in dgvPuntosVentaHab.Rows)
                {
                    row.Cells["Predeterminado"].Value = false;
                }
                dgvPuntosVentaHab.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
            }
        }
    }
}
