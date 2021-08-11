using CapaNegocios;
using System;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmCobradoresConsultaPagos : Form
    {
        #region
        private Int32 id_cobrador, tipo_comprobante, idCaja;
        private DataTable dt_cobradores = new DataTable();
        private DataTable dt_resultado = new DataTable();
        private Thread hilo;
        private delegate void myDel();
        private Puntos_Cobros oPuntosCobros = new Puntos_Cobros();
        private DataView dtw = new DataView();
        private decimal importe_recibo, importe_rendido, importe_rendido_nuevo, saldo, Importe_Ajuste, Importe_ajuste_nuevo;
        private DateTime fecha;
        private int id_comprobantes;
        private frmCobradoresPagosUsuarios oFrmcobradoresPagosUsuarios;
        private frmPopUp oPop;
        private Usuarios_CtaCte_Recibos oUsuarios_CtaCte_Recibos = new Usuarios_CtaCte_Recibos();
        #endregion


        public frmCobradoresConsultaPagos()
        {
            InitializeComponent();
        }
        private void comenzarCarga()
        {
            pgCircular.Start();
            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
        }

        private void cargarDatos()
        {
            try
            {
                dt_cobradores = oPuntosCobros.ListarPorTipoSucursal("COBRADOR");

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
            cboCobradores.DataSource = dt_cobradores;
            cboCobradores.ValueMember = "Id";
            cboCobradores.DisplayMember = "Descripcion";
            txtimporte.Text = importe_recibo.ToString();
            txtAjuste.Text = Importe_Ajuste.ToString();
        }
        private void frmCobradoresConsultaPagos_Load(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void rbtCuenta1_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtCuenta1.Checked == true)
            {
                btnBuscar.Enabled = true;
                tipo_comprobante = 5;
            }
            else
            {
                btnBuscar.Enabled = false;
            }
        }

        private void rbtCuenta2_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtCuenta2.Checked == true)
            {
                btnBuscar.Enabled = true;
                tipo_comprobante = 10;
            }
            else
            {
                btnBuscar.Enabled = false;
            }
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCobradoresConsultaPagos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (pnlEditar.Visible == true)
                {
                    pnlEditar.Visible = false;
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void btnPasarpagos_Click(object sender, EventArgs e)
        {

            oFrmcobradoresPagosUsuarios = new frmCobradoresPagosUsuarios();
            oPop = new frmPopUp();
            if (rbtCuenta1.Checked)
                oFrmcobradoresPagosUsuarios.Cuenta = 1;

            if (rbtCuenta2.Checked)
                oFrmcobradoresPagosUsuarios.Cuenta = 2;


            oFrmcobradoresPagosUsuarios.idCobrador = Convert.ToInt32(cboCobradores.SelectedValue);
            oFrmcobradoresPagosUsuarios.id_comprobante = id_comprobantes;
            oFrmcobradoresPagosUsuarios.importe_recibo = importe_recibo;
            oFrmcobradoresPagosUsuarios.importe_rendido = importe_rendido;
            oFrmcobradoresPagosUsuarios.saldo = saldo;
            oFrmcobradoresPagosUsuarios.idusuarioctacterecibo = Convert.ToInt32(dgv.Rows[dgv.SelectedRows[0].Index].Cells["idusuariosctacterecibos"].Value);
            oFrmcobradoresPagosUsuarios.idCaja = this.idCaja;
            oPop.Formulario = oFrmcobradoresPagosUsuarios;
            oPop.Maximizar = false;
            if (oPop.ShowDialog() == DialogResult.OK)
            {
                //                comenzarCarga();
            }
            Buscar();
            comenzarCarga();
        }

        private void cboCobradores_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            //pnlEditar.Visible = true;
            txtimporte.Text = importe_recibo.ToString();
            txtAjuste.Text = Importe_Ajuste.ToString();
            oPop = new frmPopUp();
            oPop.pnlPanel = pnlEditar;
            oPop.ShowDialog();

        }

        private void pnlEditar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            using (frmPopUp frm = new frmPopUp())
            {
                Cobradores.frmCobradoresConsultaDetalle frmABM = new Cobradores.frmCobradoresConsultaDetalle();
                frmABM.id_Referencia_Recibo = Convert.ToInt32(dgv.SelectedRows[0].Cells["id_Recibo_ref"].Value.ToString());
                frm.Formulario = frmABM;
                frm.Maximizar = false;

                if (frm.ShowDialog() == DialogResult.OK)
                    cargarDatos();
            }
        }

        private void rbCancelados_CheckedChanged(object sender, EventArgs e)
        {
            if(rbCancelados.Checked == true)
            {
                DeshabilitarFiltro();
                Buscar();
                DataView dv = new DataView();
                dv = dt_resultado.DefaultView;
                dv.RowFilter = String.Format("importe_saldo <= {0}",0);
                dv.Sort = "fecha_movimiento desc";
                dt_resultado = dv.ToTable();
                Formatear_Grilla();
                HabilitarFiltro();
            }
        }

        private void rbPendientes_CheckedChanged(object sender, EventArgs e)
        {
            if(rbPendientes.Checked == true) 
            {
                DeshabilitarFiltro();
                Buscar();
                DataView dv = new DataView();
                dv = dt_resultado.DefaultView;
                dv.RowFilter = String.Format("importe_saldo > {0}", 0);
                dv.Sort = "fecha_movimiento desc";
                dt_resultado = dv.ToTable();
                Formatear_Grilla();
                HabilitarFiltro();
            }
        }
        private void HabilitarFiltro()
        {
            lblBuscar.Visible = true;
            txtBuscar.Visible = true;
        }

        private void DeshabilitarFiltro()
        {
            lblBuscar.Visible = false;
            txtBuscar.Visible = false;
        }
        private void rbTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTodos.Checked == true) 
            {
                DeshabilitarFiltro();
                Buscar();
                HabilitarFiltro();
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            dt_resultado.DefaultView.RowFilter = String.Format("Convert([Fecha_movimiento], System.String) LIKE '%{0}%' OR Convert([numero], System.String) LIKE '%{0}%' OR Convert([numero_hata], System.String) LIKE '%{0}%' OR Convert([importe_recibo], System.String) LIKE '%{0}%'", txtBuscar.Text);
        }

        private void btnDescartar_Click(object sender, EventArgs e)
        {
            oPop.Cerrar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            importe_rendido_nuevo = decimal.Parse(txtimporte.Text);
            Importe_ajuste_nuevo = decimal.Parse(txtAjuste.Text);
            try
            {
                oUsuarios_CtaCte_Recibos.Editar_Importe_Recibo_Cobrador(id_comprobantes, importe_rendido_nuevo, Importe_ajuste_nuevo);
                MessageBox.Show("Importe modificado correctamente");
                oPop.Cerrar();
                dt_resultado = oPuntosCobros.Listar_Cobradores_Consulta_Pagos(id_cobrador, Convert.ToInt32(Comprobantes_Tipo.Tipo.RECIBO_COBRADOR));
                //dt_resultado.
                dgv.DataSource = dt_resultado;
                Formatear_Grilla();
                Diferencia_Saldo();
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnPasarpagos.Enabled = true;
            btnEditar.Enabled = true;
            id_comprobantes = Convert.ToInt32(dgv.Rows[dgv.SelectedRows[0].Index].Cells["id_comprobantes"].Value);
            importe_recibo = Convert.ToDecimal(dgv.Rows[dgv.SelectedRows[0].Index].Cells["importe_recibo"].Value);
            importe_rendido = Convert.ToDecimal(dgv.Rows[dgv.SelectedRows[0].Index].Cells["importe_rendido"].Value);
            saldo = Convert.ToDecimal(dgv.Rows[dgv.SelectedRows[0].Index].Cells["importe_saldo"].Value);
            Importe_Ajuste = Convert.ToDecimal(dgv.Rows[dgv.SelectedRows[0].Index].Cells["importe_ajuste"].Value);
            idCaja = Convert.ToInt32(dgv.Rows[dgv.SelectedRows[0].Index].Cells["id_caja"].Value);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            Buscar();
            groupBox1.Enabled = true;


        }

        private void Buscar()
        {
            dt_resultado.Clear();
            id_cobrador = Convert.ToInt32(cboCobradores.SelectedValue);
            if (rbtCuenta1.Checked)
                dt_resultado = oPuntosCobros.Listar_Cobradores_Consulta_Pagos(id_cobrador, Convert.ToInt32(Comprobantes_Tipo.Tipo.RECIBO_COBRADOR));
            else
                dt_resultado = oPuntosCobros.Listar_Cobradores_Consulta_Pagos(id_cobrador, Convert.ToInt32(Comprobantes_Tipo.Tipo.RECIBO_COBRADOR_INTERNO));

            DataView dv = new DataView();
            dv = dt_resultado.DefaultView;
            dv.Sort = "fecha_movimiento desc";
            dt_resultado = dv.ToTable();
 
            Formatear_Grilla();
            Diferencia_Saldo();
            lblTotal.Text = string.Format("Total de registros: {0}", dt_resultado.Rows.Count);

        }
        private void Formatear_Grilla()
        {
            dgv.DataSource = dt_resultado;
            dgv.Columns["id"].Visible = false;
            dgv.Columns["tipo_sucursal"].Visible = false;
            dgv.Columns["id_comprobantes"].Visible = false;
            dgv.Columns["descripcion"].Visible = false;
            dgv.Columns["id_Caja"].Visible = false;
            dgv.Columns["id_recibo_ref"].Visible = false;

            dgv.Columns["idusuariosctacterecibos"].Visible = false;
            dgv.Columns["fecha_movimiento"].HeaderText = "Fecha";
            dgv.Columns["fecha_movimiento"].DisplayIndex = 0;
            dgv.Columns["fecha_movimiento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv.Columns["numero"].HeaderText = "Desde";
            dgv.Columns["numero"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv.Columns["numero_hata"].HeaderText = "Hasta";
            dgv.Columns["numero_hata"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv.Columns["importe_recibo"].HeaderText = "Importe Recibo";
            dgv.Columns["importe_recibo"].DefaultCellStyle.Format = "c";
            dgv.Columns["importe_recibo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["importe_rendido"].HeaderText = "Importe Rendido";
            dgv.Columns["importe_rendido"].DefaultCellStyle.Format = "c";
            dgv.Columns["importe_rendido"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["importe_saldo"].HeaderText = "Saldo";
            dgv.Columns["importe_saldo"].DefaultCellStyle.Format = "c";
            dgv.Columns["importe_saldo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["importe_ajuste"].HeaderText = "Ajuste";
            dgv.Columns["importe_ajuste"].DefaultCellStyle.Format = "c";
            dgv.Columns["importe_ajuste"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        private void Diferencia_Saldo()
        {

            foreach (DataGridViewRow dr in dgv.Rows)
            {

                fecha = Convert.ToDateTime(dr.Cells["fecha_movimiento"].Value);
                dr.Cells["fecha_movimiento"].Value = fecha.ToString("dd/MM/yyyy");
                importe_recibo = Convert.ToDecimal(dr.Cells["importe_recibo"].Value);
                importe_rendido = Convert.ToDecimal(dr.Cells["importe_rendido"].Value);
                Importe_Ajuste = Convert.ToDecimal(dr.Cells["importe_ajuste"].Value);
                saldo = importe_rendido - importe_recibo - Importe_Ajuste;
                if (saldo < 0)
                {
                    dr.DefaultCellStyle.BackColor = Color.LightSalmon;
                }
                dr.Cells["importe_saldo"].Value = saldo;
            }
        }
    }
}
