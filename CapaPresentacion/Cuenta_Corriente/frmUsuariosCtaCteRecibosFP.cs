using CapaNegocios;
using System;
using System.Windows.Forms;

namespace CapaPresentacion.Cuenta_Corriente
{
    public partial class frmUsuariosCtaCteRecibosFP : Form
    {
        public Int32 Id_Usuarios_ctacte_recibos;
        private Usuarios_CtaCte_Recibos oUsuarioRecibos = new Usuarios_CtaCte_Recibos();

        public frmUsuariosCtaCteRecibosFP()
        {
            InitializeComponent();
        }

        public void LoadData()
        {
            dgv.DataSource = oUsuarioRecibos.ListaFormaPago(this.Id_Usuarios_ctacte_recibos);
            dgv.Columns["importe"].DefaultCellStyle.Format = "C2";
            AsignarDatos();

        }

        public void AsignarDatos()
        {
            dgv.Columns["formapago"].HeaderText = "Forma de Pago";
            dgv.Columns["importe"].HeaderText = "Importe";
            dgv.Columns["cuit"].HeaderText = "Cuit";
            dgv.Columns["nombre"].HeaderText = "Nombre";
            dgv.Columns["banco"].HeaderText = "Banco";
            dgv.Columns["sucursal"].HeaderText = "Sucursal";
            dgv.Columns["fecha_comprobante"].HeaderText = "FechaComprobante";
            dgv.Columns["fecha_acreditacion"].HeaderText = "FechaAcreditacion";
            dgv.Columns["id_formas_de_pago"].Visible = false;


            dgv.Columns["formapago"].Width = 130;
            dgv.Columns["fecha_comprobante"].Width = 130;
            dgv.Columns["fecha_acreditacion"].Width = 130;
            dgv.Columns["nombre"].Width = 70;
            dgv.Columns["banco"].Width = 70;
            dgv.Columns["sucursal"].Width = 70;
            dgv.Columns["numero"].Width = 60;
        }

        private void frmUsuariosCtaCteRecibosFP_Load(object sender, EventArgs e)
        {
            this.LoadData();
        }

        private void frmUsuariosCtaCteRecibosFP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.DialogResult = DialogResult.Cancel;
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
