using CapaNegocios;
using CapaPresentacion.Impresiones;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmCaja_General : Form
    {
        #region PROPIEDADES
        private decimal total = 0, importe_total_cuenta1 = 0, importe_total_cuenta2 = 0, flag = 0;
        private Thread hilo;
        private delegate void myDel();
        private Caja_Diaria ocaja_diaria = new Caja_Diaria();
        private Caja_general ocaja_general = new Caja_general();
        private Puntos_Cobros opuntos_cobro = new Puntos_Cobros();

        private DataTable dtcajas_sin_cerrar = new DataTable();
        private DataTable dt_aux1 = new DataTable();
        private DataView dt_view = new DataView();
        private DataTable dt_cajas_confirmadas = new DataTable();
        private DataTable dt_segunda = new DataTable();
        #endregion

        public frmCaja_General()
        {
            InitializeComponent();
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea cerrar la caja general?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                //try
                //{
                foreach (DataGridViewRow item in dgv1.Rows)
                {
                    importe_total_cuenta1 = importe_total_cuenta1 + decimal.Parse(item.Cells["Importe_cuenta1"].Value.ToString());
                    importe_total_cuenta2 = importe_total_cuenta2 + decimal.Parse(item.Cells["Importe_cuenta2"].Value.ToString());

                }
                total = importe_total_cuenta1 + importe_total_cuenta2;
                ocaja_general.Id = 0;
                ocaja_general.Importe_cuenta1 = importe_total_cuenta1;
                ocaja_general.Importe_cuenta2 = importe_total_cuenta2;
                ocaja_general.importe_total = total;

                ocaja_general.Id_Cierre_General = 0;
                ocaja_general.Id_Personal = Personal.Id_Login;
                ocaja_general.Fecha = DateTime.Now;

                DataView dv = dt_cajas_confirmadas.DefaultView;
                dv.Sort = "fecha desc";
                DataTable sortedDT = dv.ToTable();

                int idCajaGenerada = ocaja_general.Guardar(ocaja_general);

                ocaja_general.Asignar_Numero_De_Caja(sortedDT, idCajaGenerada);
                Impresion oImpresion = new Impresion();
                oImpresion.ImprimirCierreGeneralPuntos(idCajaGenerada);
                oImpresion.ImprimirCajaGral(sortedDT, idCajaGenerada, 1);
                oImpresion.ImprimirCajaGral(sortedDT, idCajaGenerada, 2);



                //      MessageBox.Show("Caja cerrada correctamente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);





                this.Close();
                //}
                //catch (Exception)
                //{
                //    MessageBox.Show("Error al cerrar caja general", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
            }
        }

        private void dgvCajas_diarias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {



        }

        private void dgvCajas_diarias_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            asignavalores();

        }

        private void dgvCajas_diarias_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {


        }
        private void btnsacar_Click(object sender, EventArgs e)
        {

        }
        private void dgv1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dgv1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

        }
        private void dgvCajas_diarias_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }
        private void dgvCajas_diarias_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCajas_diarias.Columns[e.ColumnIndex].Name == "seleccionar")
            {
                txtcierretotal.Focus();
                Pasar();
            }
        }
        private void dgvCajas_diarias_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvCajas_diarias.IsCurrentCellDirty)
            {
                dgvCajas_diarias.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        private void frmCaja_General_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
        private void frmcaja_general_Load(object sender, EventArgs e)
        {
            ComenzarCarga();
        }
        private void dgvCajas_diarias_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvCajas_diarias.SelectedRows[0].Cells["seleccionar"].Value.ToString() == "False")
            {
                dgvCajas_diarias.SelectedRows[0].Cells["seleccionar"].Value = true;
            }
            else
            {
                dgvCajas_diarias.SelectedRows[0].Cells["seleccionar"].Value = false;
            }

        }
        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Inicio
        private void ComenzarCarga()
        {


            hilo = new Thread(new ThreadStart(CargarDatos));
            hilo.IsBackground = true;
            hilo.Start();
        }
        private void CargarDatos()
        {

            dtcajas_sin_cerrar = ocaja_diaria.Listar_Caja_Diaria(0, 0, 0);
            dt_cajas_confirmadas = dtcajas_sin_cerrar.Clone();
            myDel MD = new myDel(AsignarDatos);
            this.Invoke(MD, new object[] { });

        }
        private void AsignarDatos()
        {
            if (flag == 0)
            {
                DataColumn colSel = new DataColumn("seleccionar", typeof(Boolean));
                DataColumn colSel2 = new DataColumn("seleccionar", typeof(Boolean));
                colSel.DefaultValue = false;
                dtcajas_sin_cerrar.Columns.Add(colSel);
                dt_cajas_confirmadas.Columns.Add(colSel2);
                dgvCajas_diarias.DataSource = dtcajas_sin_cerrar;
                dibujargrilla();
                dgv1.DataSource = dt_cajas_confirmadas;
                Formatear();
                flag = 1;
            }
        }
        private void asignavalores()
        {

            try
            {
                txtultimorecibo1.Text = dgvCajas_diarias.SelectedRows[0].Cells["Recibo_cuenta1_hasta"].Value.ToString();
                txtultimorecibo2.Text = dgvCajas_diarias.SelectedRows[0].Cells["Recibo_cuenta2_hasta"].Value.ToString();
                txtprimerrecibo1.Text = dgvCajas_diarias.SelectedRows[0].Cells["Recibo_cuenta1_desde"].Value.ToString();
                txtprimerrecibo2.Text = dgvCajas_diarias.SelectedRows[0].Cells["Recibo_cuenta2_desde"].Value.ToString();
                txttotal1.Text = dgvCajas_diarias.SelectedRows[0].Cells["Importe_cuenta1"].Value.ToString();
                txttotal2.Text = dgvCajas_diarias.SelectedRows[0].Cells["Importe_cuenta2"].Value.ToString();
                txttotal.Text = dgvCajas_diarias.SelectedRows[0].Cells["total"].Value.ToString();
            }
            catch
            {

            }

        }
        private void dibujargrilla()
        {
            dgvCajas_diarias.Columns["Recibo_cuenta1_desde"].Visible = false;
            dgvCajas_diarias.Columns["Recibo_cuenta1_hasta"].Visible = false;
            dgvCajas_diarias.Columns["Recibo_cuenta2_desde"].Visible = false;
            dgvCajas_diarias.Columns["Recibo_cuenta2_hasta"].Visible = false;
            dgvCajas_diarias.Columns["Importe_cuenta1"].Visible = false;
            dgvCajas_diarias.Columns["Importe_cuenta2"].Visible = false;
            dgvCajas_diarias.Columns["id_punto_cobro"].Visible = false;
            dgvCajas_diarias.Columns["total"].DefaultCellStyle.Format = "c";
            dgvCajas_diarias.Columns["total"].HeaderText = "Total";
            dgvCajas_diarias.Columns["total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCajas_diarias.Columns["pto_cobro"].Width = 150;
            dgvCajas_diarias.Columns["pto_cobro"].HeaderText = "Punto de cobro";
            dgvCajas_diarias.Columns["id"].Visible = false;
            dgvCajas_diarias.Columns[0].Width = 40;
            dgvCajas_diarias.Columns["fecha"].HeaderText = "Fecha";

        }

        private void btnSeleccionarTodo_Click(object sender, EventArgs e)
        {
            if (dgvCajas_diarias.Rows.Count > 0)
            {
                foreach (DataGridViewRow item in dgvCajas_diarias.Rows)
                    item.Cells["seleccionar"].Value = true;
            }
        }

        private void btnConsultaDeCaja_Click(object sender, EventArgs e)
        {
            Configuracion oConfig = new Configuracion();
            frmPopUp ofrmPop = new frmPopUp();
            
            if (oConfig.GetValor_N("FormatoCaja") == 1)
            {
                frmCaja_Diaria frmCaja = new frmCaja_Diaria(Convert.ToInt32(dgvCajas_diarias.SelectedRows[0].Cells["id"].Value.ToString()));
                ofrmPop.Formulario = frmCaja;
                ofrmPop.Maximizar = true;

            }
            else
            {
                frmCajaDetalle frmCaja = new frmCajaDetalle(Convert.ToInt32(dgvCajas_diarias.SelectedRows[0].Cells["id"].Value.ToString()));
                ofrmPop.Formulario = frmCaja;
                ofrmPop.Maximizar = true;

            }
            ofrmPop.ShowDialog();

        }

        private void Formatear()
        {

            dgv1.Columns["Recibo_cuenta1_desde"].HeaderText = "Cuenta1 Recibo desde";
            dgv1.Columns["Recibo_cuenta1_hasta"].HeaderText = "Cuenta1 Recibo hasta";
            dgv1.Columns["Recibo_cuenta2_desde"].HeaderText = "Cuenta2 Recibo desde";
            dgv1.Columns["Recibo_cuenta2_hasta"].HeaderText = "Cuenta2 Recibo hasta";
            dgv1.Columns["total"].DefaultCellStyle.Format = "c";
            dgv1.Columns["total"].HeaderText = "Total";
            dgv1.Columns["total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv1.Columns["Importe_cuenta1"].Visible = false;
            dgv1.Columns["Importe_cuenta2"].Visible = false;
            dgv1.Columns["seleccionar"].Visible = false;
            dgv1.Columns["seleccionar"].HeaderText = "Seleccionar";
            dgv1.Columns["id_punto_cobro"].Visible = false;
            dgv1.Columns["pto_cobro"].HeaderText = "Punto de Cobro";
            dgv1.Columns["fecha"].HeaderText = "Fecha";
            dgv1.Columns["id"].Visible = false;


        }
        private void Pasar()
        {
            DataTable dt = dtcajas_sin_cerrar.Copy();
            dt_view = dt.DefaultView;
            dt_view.RowFilter = string.Format("seleccionar=TRUE");
            dt_cajas_confirmadas = dt_view.ToTable();
            dgv1.DataSource = dt_cajas_confirmadas;
            dgv1.Refresh();
            suma_total();
        }
        private void suma_total()
        {
            decimal monto = 0;
            decimal monto1 = 0;
            decimal monto2 = 0;
            for (int i = 0; i < dgvCajas_diarias.Rows.Count; i++)
            {
                Boolean sel = Convert.ToBoolean(dgvCajas_diarias.Rows[i].Cells["seleccionar"].Value.ToString());
                decimal m = Convert.ToDecimal(dgvCajas_diarias.Rows[i].Cells["total"].Value.ToString());
                decimal m1 = Convert.ToDecimal(dgvCajas_diarias.Rows[i].Cells["importe_cuenta1"].Value.ToString());
                decimal m2 = Convert.ToDecimal(dgvCajas_diarias.Rows[i].Cells["importe_cuenta2"].Value.ToString());

                if (sel == true)
                {

                    monto1 = monto1 + m1;
                    monto2 = monto2 + m2;
                    monto = monto + m;
                }
            }
            txtcierretotal.Text = monto.ToString();
            txtsuma1.Text = monto1.ToString();
            txtsuma2.Text = monto2.ToString();

        }
        #endregion
    }
}
