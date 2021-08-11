using CapaNegocios;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Abms
{
    public partial class ABMPuntosVenta_AsignacionCompTipos : Form
    {
        public int id_punto_venta = 0;
        private Thread hilo;
        private delegate void myDel();
        private DataTable dtComprobantesTipo = new DataTable();
        private Puntos_Venta_Comp oPuntos_Venta_Comp = new Puntos_Venta_Comp();

        private void comenzarCarga()
        {
            pgCircular.Start();

            dgvTiposComp.DataSource = null;

            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
        }

        private void cargarDatos()
        {
            dtComprobantesTipo = oPuntos_Venta_Comp.ListarComprobantesAsignados(id_punto_venta);

            myDel MD = new myDel(asignarDatos);

            this.Invoke(MD, new object[] { });

            pgCircular.Stop();

        }

        private void asignarDatos()
        {

            DataGridViewCheckBoxColumn colSeleccion = new DataGridViewCheckBoxColumn();
            colSeleccion.HeaderText = "Asignar";
            colSeleccion.Name = "colSeleccion";

            int control = 0;

            foreach (DataGridViewColumn columna in dgvTiposComp.Columns)
            {
                if (columna.Index == dgvTiposComp.Columns["colSeleccion"].Index)
                {
                    control = 1;
                    break;
                }
            }

            if (control == 1)
                dgvTiposComp.Columns.RemoveAt(dgvTiposComp.Columns["colSeleccion"].Index);


            dgvTiposComp.DataSource = dtComprobantesTipo;
            dgvTiposComp.Columns.Add(colSeleccion);


            dgvTiposComp.Columns["id"].Visible = false;
            dgvTiposComp.Columns["id_comp_venta"].Visible = false;
            dgvTiposComp.Columns["codigo_afip"].HeaderText = "Código Afip";
            dgvTiposComp.Columns["numero"].HeaderText = "Número";
            dgvTiposComp.Columns["nombre"].HeaderText = "Factura Tipo";
            dgvTiposComp.Columns["letra"].HeaderText = "Letra";


            foreach (DataGridViewRow fila in dgvTiposComp.Rows)
            {
                if (fila.Cells["id_comp_venta"].Value != DBNull.Value && Convert.ToInt32(fila.Cells["id_comp_venta"].Value) > 0)
                    fila.Cells["colSeleccion"].Value = 1;

            }
        }

        public void Guardar()
        {
            if (dgvTiposComp.Rows.Count > 0)
            {
                foreach (DataGridViewRow fila in dgvTiposComp.Rows)
                {
                    if (Convert.ToInt32(fila.Cells["colSeleccion"].Value) == 1)
                    {
                        oPuntos_Venta_Comp.Id_Comprobantes_Tipo = Convert.ToInt32(fila.Cells["id"].Value);
                        oPuntos_Venta_Comp.Id_Punto_Venta = id_punto_venta;

                        if (fila.Cells["numero"].Value == DBNull.Value)
                            oPuntos_Venta_Comp.Numero = 0;
                        else
                            oPuntos_Venta_Comp.Numero = Convert.ToInt32(fila.Cells["numero"].Value);

                        if (fila.Cells["id_comp_venta"].Value == DBNull.Value)
                            oPuntos_Venta_Comp.Id = 0;
                        else
                            oPuntos_Venta_Comp.Id = Convert.ToInt32(fila.Cells["id_comp_venta"].Value);

                        oPuntos_Venta_Comp.GuardarAsignacionTipoComp(oPuntos_Venta_Comp);
                    }
                    else
                    {
                        if (fila.Cells["id_comp_venta"].Value != DBNull.Value)
                        {
                            oPuntos_Venta_Comp.Eliminar(Convert.ToInt32(fila.Cells["id_comp_venta"].Value));
                        }
                    }
                }
                MessageBox.Show("Operación realizada correctamente.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        public ABMPuntosVenta_AsignacionCompTipos(int id_punto)
        {
            id_punto_venta = id_punto;

            InitializeComponent();
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void ABMAsigancionComprobantesTipos_Load(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ABMPuntosVenta_AsignacionCompTipos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void dgvTiposComp_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void dgvTiposComp_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

        }

        private void dgvTiposComp_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int index = 0;
            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
            TextBox tb = e.Control as TextBox;
            if (tb != null)
            {
                tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);

            }
        }
        private void Column1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
