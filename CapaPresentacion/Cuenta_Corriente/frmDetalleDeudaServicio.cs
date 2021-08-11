using CapaNegocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Cuenta_Corriente
{
    public partial class frmDetalleDeudaServicio : Form
    {
        #region DECLARACIONES
        private Thread hilo;
        private delegate void myDel();
        private DataTable dtDeudas = new DataTable();
        public DateTime fecha;
        public int idUsuario;
        public int idServicio;
        private Usuarios_CtaCte_Det oDet = new Usuarios_CtaCte_Det();

        #endregion
        #region METODOS
        private void ComenzarCarga()
        {
            dtDeudas.Clear();
            dgvDeudas.DataSource = null;
            pgCircular.Start();
            hilo = new Thread(new ThreadStart(CargarDatos));
            hilo.Start();
        }

        private void CargarDatos()
        {
            dtDeudas = oDet.ListarDeudaPorServicio(idUsuario, idServicio,fecha);
            myDel MD = new myDel(AsignarDatos);
            this.Invoke(MD, new object[] { });
            pgCircular.Stop();
        }

        private void AsignarDatos()
        {
            dtDeudas.Columns.Add("Periodo", typeof(string));
            DateTime fecha = Convert.ToDateTime(dtDeudas.Rows[0]["fecha_desde"]);
            int numPeriodo = 1;
            dtDeudas.Rows[0]["periodo"] = "1";
            foreach (DataRow item in dtDeudas.Rows)
            {
                if (Convert.ToDateTime(item["fecha_desde"]) != fecha)
                {
                    numPeriodo++;
                    fecha = Convert.ToDateTime(item["fecha_desde"]);
                    item["periodo"] = numPeriodo.ToString();
                }
            }
            dgvDeudas.DataSource = dtDeudas;
            for (int i = 0; i < dgvDeudas.Columns.Count; i++)
                dgvDeudas.Columns[i].Visible = false;

            dgvDeudas.Columns["periodo"].Visible = true;
            dgvDeudas.Columns["detalles"].Visible = true;
            dgvDeudas.Columns["detalles"].HeaderText = "Descripcion";
            dgvDeudas.Columns["detalles"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvDeudas.Columns["fecha_desde"].Visible = true;
            dgvDeudas.Columns["fecha_desde"].HeaderText = "Fecha desde";

            dgvDeudas.Columns["fecha_hasta"].Visible = true;
            dgvDeudas.Columns["fecha_hasta"].HeaderText = "Fecha hasta";
            dgvDeudas.Columns["detalles"].Visible = true;
            dgvDeudas.Columns["sub_servicio"].Visible = true;
            dgvDeudas.Columns["sub_servicio"].HeaderText = "Item";

            dgvDeudas.Columns["importe_original"].Visible=true;
            dgvDeudas.Columns["importe_original"].HeaderText = "Importe original";
            dgvDeudas.Columns["importe_original"].DefaultCellStyle.Format = "c2";
            dgvDeudas.Columns["importe_original"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvDeudas.Columns["importe_punitorio"].Visible = true;
            dgvDeudas.Columns["importe_punitorio"].HeaderText = "Importe punitorio";
            dgvDeudas.Columns["importe_punitorio"].DefaultCellStyle.Format = "c2";
            dgvDeudas.Columns["importe_punitorio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvDeudas.Columns["importe_saldo"].Visible = true;
            dgvDeudas.Columns["importe_saldo"].HeaderText = "Importe saldo";
            dgvDeudas.Columns["importe_saldo"].DefaultCellStyle.Format = "c2";
            dgvDeudas.Columns["importe_saldo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvDeudas.Columns["importe_bonificacion"].DefaultCellStyle.Format = "c2";          
            dgvDeudas.Columns["importe_bonificacion"].HeaderText = "Importe bonificacion";
            dgvDeudas.Columns["importe_bonificacion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            
            lblTotal.Text = String.Format("Total de Registros: {0}", dgvDeudas.Rows.Count);
            object sum = dtDeudas.Compute("sum(Importe_saldo)", string.Format("importe_saldo<>0"));
            lblMontoTotal.Text = "Total: $ " + sum.ToString();

        }

        #endregion

        public frmDetalleDeudaServicio()
        {
            InitializeComponent();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDetalleDeudaServicio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void frmDetalleDeudaServicio_Load(object sender, EventArgs e)
        {
            ComenzarCarga();
        }
    }
}
