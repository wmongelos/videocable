using CapaNegocios;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacion.Cuenta_Corriente
{
    public partial class frmUsuariosCtaCteDetEdicion : Form
    {
        public Int32 Id_Comprobantes;
        public Int32 Id_CtaCte;
        public Comprobantes_Tipo.Tipo? Comprobante_Tipo;
        public String Comprobante
        {
            get { return lblComprobante.Text; }
            set { lblComprobante.Text = value; }
        }

        private Usuarios_CtaCte_Det usuarios_CtaCte_Det = new Usuarios_CtaCte_Det();
        private DataTable data = new DataTable();
        private bool percepcionesModificadas;
        private bool esDebitoAutomatico;

        public frmUsuariosCtaCteDetEdicion()
        {
            InitializeComponent();
            Comprobante_Tipo = null;
        }

        private void CargarDatos()
        {
            data = usuarios_CtaCte_Det.ListarDetalle(this.Id_Comprobantes);
            data.AcceptChanges();

            esDebitoAutomatico = new Usuarios_CtaCte().esDebitoAutomatico(Id_CtaCte);       

            if (data.Rows.Count == 0)
                return;

            dgvCtaCteDet.ReadOnly = false;
            dgvCtaCteDet.DataSource = data;

            if(Comprobante_Tipo != null && (Comprobante_Tipo == Comprobantes_Tipo.Tipo.FACTURA_A || Comprobante_Tipo == Comprobantes_Tipo.Tipo.FACTURA_B))
            {
                foreach (DataGridViewColumn col in dgvCtaCteDet.Columns)
                {
                    col.ReadOnly = true;
                }
                dgvCtaCteDet.Columns["importe_punitorio"].ReadOnly = false;
            }

            Decimal total = Convert.ToDecimal(data.Compute("SUM(importe_saldo)", string.Empty));

            lblTotal.Text = String.Format("Importe Original: {0}", total.ToString("C2"));

            for (int i = 0; i < dgvCtaCteDet.ColumnCount; i++)
                dgvCtaCteDet.Columns[i].Visible = false;

            dgvCtaCteDet.Columns["servicio"].Visible = true;
            dgvCtaCteDet.Columns["servicio"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvCtaCteDet.Columns["sub_servicio"].Visible = true;
            dgvCtaCteDet.Columns["sub_servicio"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCtaCteDet.Columns["sub_servicio"].HeaderText = "SubServicio";

            dgvCtaCteDet.Columns["importe_original"].Visible = true;
            dgvCtaCteDet.Columns["importe_original"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCtaCteDet.Columns["importe_original"].HeaderText = "Imp. Original";

            dgvCtaCteDet.Columns["importe_punitorio"].Visible = true;
            dgvCtaCteDet.Columns["importe_punitorio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCtaCteDet.Columns["importe_punitorio"].HeaderText = "Imp. Punitorio";

            dgvCtaCteDet.Columns["importe_bonificacion"].Visible = true;
            dgvCtaCteDet.Columns["importe_bonificacion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCtaCteDet.Columns["importe_bonificacion"].HeaderText = "Imp. Bonificacion";

            dgvCtaCteDet.Columns["importe_provincial"].Visible = true;
            dgvCtaCteDet.Columns["importe_provincial"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCtaCteDet.Columns["importe_provincial"].HeaderText = "Imp. Provincial";

            dgvCtaCteDet.Columns["importe_saldo"].Visible = true;
            dgvCtaCteDet.Columns["importe_saldo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCtaCteDet.Columns["importe_saldo"].HeaderText = "Imp. Saldo";

        }

        public void Saldos()
        {
            Decimal total = Convert.ToDecimal(data.Compute("SUM(importe_saldo)", string.Empty));

            lblTotal.Text = String.Format("{0} | Importe Actual: {1}", lblTotal.Text, total.ToString("C2"));
        }

        private void frmUsuariosCtaCteDetEdicion_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void frmUsuariosCtaCteDetEdicion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                DialogResult = DialogResult.Cancel;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void dgvCtaCteDet_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Decimal importe_original = Convert.ToDecimal(dgvCtaCteDet.Rows[e.RowIndex].Cells["importe_original"].Value);
                Decimal importe_punitorio = Convert.ToDecimal(dgvCtaCteDet.Rows[e.RowIndex].Cells["importe_punitorio"].Value);
                Decimal importe_bonificacion = Convert.ToDecimal(dgvCtaCteDet.Rows[e.RowIndex].Cells["importe_bonificacion"].Value);
                Decimal importe_provincial = Convert.ToDecimal(dgvCtaCteDet.Rows[e.RowIndex].Cells["importe_provincial"].Value);
                Decimal importe_saldo = (importe_original + importe_punitorio + importe_provincial) - importe_bonificacion;

                data.Rows[e.RowIndex]["importe_saldo"] = importe_saldo;

                Saldos();
            }
            catch { }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (esDebitoAutomatico)
            {
                MessageBox.Show("No se pueden modificar las percepciones de un debito automatico", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (MessageBox.Show("¿Desea Confirmar la Edicion del Comprobante?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LogTabla oLogTabla = new LogTabla();
                usuarios_CtaCte_Det.Edicion(data, this.Id_Comprobantes, this.Id_CtaCte);
               
                data.AcceptChanges();

                DialogResult = DialogResult.OK;
            }
        }

        private void btnRestablecer_Click(object sender, EventArgs e)
        {
            data.RejectChanges();
        }
    }
}

