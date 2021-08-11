using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CapaNegocios;
using System.Threading;
using System.Globalization;

namespace CapaPresentacion.Cuenta_Corriente
{
    public partial class FrmUsuariosCtaCteArreglo : Form
    {
        public FrmUsuariosCtaCteArreglo()
        {
            InitializeComponent();
        }
        #region Propiedades
        private Thread hilo;
        private delegate void myDel();
        private DataTable dt_FacturasSinRecibo;
        private Usuarios_CtaCte oUsuCtacte = new Usuarios_CtaCte();
        private Usuarios_CtaCte_Det oUsuCtacte_det = new Usuarios_CtaCte_Det();
        private Usuarios_CtaCte_Recibos oUsuCtacte_Recibos = new Usuarios_CtaCte_Recibos();
        private Comprobantes_Tipo oComprobante_Tipo = new Comprobantes_Tipo();
        private Comprobantes oCompro = new Comprobantes();
        public int id_usuario_viene = 0;
        private Usuarios oUsu = new Usuarios();
        Int32 FilasTotales;
        int Comprobante_Tipo = 0;
        #endregion

        #region Metodos
        private void comenzarCarga()
        {
            pgCircular.Start();

            dgv.DataSource = null;

            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
        }

        private void cargarDatos()
        {
            try
            {
                dt_FacturasSinRecibo = oUsuCtacte.ListarFacturasSinRecibos(Comprobante_Tipo);

                myDel MD = new myDel(asignarDatos);

                this.Invoke(MD, new object[] { });

                pgCircular.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Informacion" + ex.Message);
            }

        }

        private void asignarDatos()
        {
            filtrarDataTable();
            dgv.DataSource = dt_FacturasSinRecibo;

            for (int i = 0; i < dgv.ColumnCount; i++)
                dgv.Columns[i].Visible = false;

            dgv.Columns["Desde"].Visible = true;
            dgv.Columns["hasta"].Visible = true;
            dgv.Columns["codigo"].Visible = true;
            dgv.Columns["usuario"].Visible = true;
            dgv.Columns["comprobante"].Visible = true;
            dgv.Columns["original"].Visible = true;
            dgv.Columns["final"].Visible = true;
            dgv.Columns["numero_documento"].Visible = true;
            dgv.Columns["fecha_movimiento"].Visible = true;

            dgv.Columns["Desde"].HeaderText = "Fecha Desde";
            dgv.Columns["hasta"].HeaderText = "Fecha Hasta";
            dgv.Columns["codigo"].HeaderText = "Codigo Usuario";
            dgv.Columns["usuario"].HeaderText = "Usuario";
            dgv.Columns["comprobante"].HeaderText = "Comprobante";
            dgv.Columns["original"].HeaderText = "Importe Original";
            dgv.Columns["final"].HeaderText = "Importe Final";
            dgv.Columns["numero_documento"].HeaderText = "Numero de Documento";
            dgv.Columns["fecha_movimiento"].HeaderText = "Fecha Movimiento";

            dgv.Columns["original"].DefaultCellStyle.Format = "C2";
            dgv.Columns["original"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["final"].DefaultCellStyle.Format = "C2";
            dgv.Columns["final"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


            btnActualizar.Enabled = true;
            btnBuscar.Enabled = true;
            btnExportar.Enabled = true;

        }

        private void filtrarDataTable()
        {
            DataView dvFiltro = new DataView();
            dvFiltro = dt_FacturasSinRecibo.DefaultView;
            dvFiltro.RowFilter = string.Format("id_recibo = {0} and borrado_ctacte={1}", 0,0);
            dt_FacturasSinRecibo = dvFiltro.ToTable();

            if (id_usuario_viene != 0) 
            { 
                DataView dvFiltroUsu = new DataView();
                dvFiltroUsu = dt_FacturasSinRecibo.DefaultView;
                dvFiltroUsu.RowFilter = string.Format("id_usu = {0}", id_usuario_viene);
                dt_FacturasSinRecibo = dvFiltroUsu.ToTable();
            }
        }
        #endregion

        #region Eventos
        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count == 0)
                MessageBox.Show("No hay registos a actualizar, por favor realice la consulta correctamente.");
            else 
            {
                using (frmPopUp frmPop = new frmPopUp())
                {
                    FrmDatosReciboTipoAjuste frm = new FrmDatosReciboTipoAjuste();
                    frmPop.Formulario = frm;
                    frm.movimiento = Convert.ToDateTime(dgv.SelectedRows[0].Cells["Fecha_Movimiento"].Value.ToString());
                    frm.id_Ctacte = Convert.ToInt32(dgv.SelectedRows[0].Cells["id_ctacte"].Value.ToString());
                    frm.id_usu = Convert.ToInt32(dgv.SelectedRows[0].Cells["id_usu"].Value.ToString());
                    frm.id_locacion = Convert.ToInt32(dgv.SelectedRows[0].Cells["id_locacion"].Value.ToString());
                    frm.desde = Convert.ToDateTime(dgv.SelectedRows[0].Cells["desde"].Value.ToString());
                    frm.hasta = Convert.ToDateTime(dgv.SelectedRows[0].Cells["hasta"].Value.ToString());
                    frm.Importe = Convert.ToDecimal(dgv.SelectedRows[0].Cells["original"].Value.ToString());
                    frm.Comprobante = Convert.ToString(dgv.SelectedRows[0].Cells["Comprobante"].Value.ToString());

                    if (frmPop.ShowDialog() == DialogResult.OK)
                        MessageBox.Show("Datos actualizados correctamente.");
                    else 
                        MessageBox.Show("Operacion cancelada manualmente, o ocurrio un fallo en el proceso.");
                }
                dgv.Focus();
                comenzarCarga();
            }

        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 0)
            {
                Tools tools = new Tools();
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    tools.ExportToExcel(dgv, "Facturas sin recibos");
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al exportar a excel");
                }
                finally { this.Cursor = Cursors.Default; }
            }
            else
                MessageBox.Show("Grilla vacia");
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (rbFacturaA.Checked == false && rbFacturaB.Checked == false)
                MessageBox.Show("Debe seleccionar un tipo de Factura.");
            else 
            { 
                btnActualizar.Enabled = false;
                btnBuscar.Enabled = false;
                btnExportar.Enabled = false;
                if (rbFacturaA.Checked == true)
                    Comprobante_Tipo = (int)Comprobantes_Tipo.Tipo.FACTURA_A;
                else
                    Comprobante_Tipo = (int)Comprobantes_Tipo.Tipo.FACTURA_B;
                comenzarCarga();
            }
        }

        private void btnActualizarTodos_Click(object sender, EventArgs e)
        {
        }
        #endregion

        private void FrmUsuariosCtaCteArreglo_Load(object sender, EventArgs e)
        {
            if (id_usuario_viene != 0)
            {
                DataRow dataUsuario = oUsu.getDatos(id_usuario_viene);
                lblCodUsu.Text = dataUsuario["codigo"].ToString();
                lblIVA.Text = dataUsuario["Condicion_iva"].ToString();
                lblLocalidad.Text = "Calle:" + dataUsuario["calle"].ToString() + "- Altura:" +dataUsuario["altura"].ToString();
            }

        }

        private void txtBuscador_TextChanged(object sender, EventArgs e)
        {
            //dt_FacturasSinRecibo.DefaultView.RowFilter = String.Format("Convert([codigo], System.String) LIKE '%{0}%' OR nombre LIKE '%{0}%' OR Convert([apellido], System.String) LIKE '%{0}%' OR Convert([numero_documento], System.String) LIKE '%{0}%' OR Convert([desde], System.String) LIKE '%{0}%' OR Convert([hasta], System.String) LIKE '%{0}%' OR Convert([fecha_movimiento], System.String) LIKE '%{0}%' OR Convert([original], System.String) LIKE '%{0}%' OR Convert([final], System.String) LIKE '%{0}%' OR Convert([comprobante], System.String) LIKE '%{0}%' OR Convert([usuario], System.String) LIKE '%{0}%'", txtBuscador.Text);
        }
    }
}
