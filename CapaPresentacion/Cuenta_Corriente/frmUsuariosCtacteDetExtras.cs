using CapaNegocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;


namespace CapaPresentacion
{
    public partial class frmUsuariosCtacteDetExtras : Form
    {
        public Int32 idUsuarioCtaCteDetExtra;
        public Int32 idBonificacion, idBonifContratacion;
        private Usuarios_Ctacte_Det_Extra oExtras = new Usuarios_Ctacte_Det_Extra();
        private Bonificaciones oBonificaciones = new Bonificaciones();
        private DataTable dtExtras = new DataTable();
        private DataTable dtBonificaciones = new DataTable();
        private DataTable dtDatosBonificaciones = new DataTable();
        private Thread hilo;
        private delegate void myDel();
        private bool parteConexion = false;
        public List<int> listadoBonificaciones = new List<int>();
        private void ComenzarCarga()
        {
            pgCircular.Start();
            hilo = new Thread(new ThreadStart(CargarDatos));
            hilo.Start();
        }

        private void CargarDatos()
        {
            if (parteConexion == false)
                dtExtras = oExtras.ListarExtrasDet(idUsuarioCtaCteDetExtra);
            else
            {
                dtBonificaciones.Columns.Add("Nombre", typeof(String));
                dtBonificaciones.Columns.Add("Porcentaje", typeof(Decimal));

                if (idBonifContratacion != 0)
                {
                    dtDatosBonificaciones = oBonificaciones.ListarPorId(idBonifContratacion);
                    if (dtDatosBonificaciones.Rows.Count > 0)
                    {
                        DataRow drBonifContratacion = dtBonificaciones.NewRow();
                        drBonifContratacion["nombre"] = dtDatosBonificaciones.Rows[0]["nombre"];
                        drBonifContratacion["porcentaje"] = dtDatosBonificaciones.Rows[0]["porcentaje"];

                        dtBonificaciones.Rows.Add(drBonifContratacion);
                    }
                }
                if (idBonificacion != 0)
                {
                    dtDatosBonificaciones = oBonificaciones.ListarPorId(idBonificacion);
                    if (dtDatosBonificaciones.Rows.Count > 0)
                    {
                        DataRow drBonificacion = dtBonificaciones.NewRow();
                        drBonificacion["nombre"] = dtDatosBonificaciones.Rows[0]["nombre"];
                        drBonificacion["porcentaje"] = dtDatosBonificaciones.Rows[0]["porcentaje"];

                        dtBonificaciones.Rows.Add(drBonificacion);
                    }
                }
                if (listadoBonificaciones.Count > 0)
                {
                    foreach (int idBonificacion in listadoBonificaciones)
                    {
                        dtDatosBonificaciones = oBonificaciones.ListarPorId(idBonificacion);
                        if (dtDatosBonificaciones.Rows.Count > 0)
                        {
                            DataRow drBonificacion = dtBonificaciones.NewRow();
                            drBonificacion["nombre"] = dtDatosBonificaciones.Rows[0]["nombre"];
                            drBonificacion["porcentaje"] = dtDatosBonificaciones.Rows[0]["porcentaje"];
                            dtBonificaciones.Rows.Add(drBonificacion);
                        }
                    }
                }


            }
            myDel MD = new myDel(AsignarDatos);
            this.Invoke(MD, new object[] { });
            pgCircular.Stop();
        }

        private void AsignarDatos()
        {
            if (parteConexion == false)
            {
                if (dtExtras.Rows.Count == 0)
                {

                    DataRow drVacio = dtExtras.NewRow();
                    drVacio["extra"] = "SIN NOVEDADES NI BONIFICACIONES";
                    dtExtras.Rows.Add(drVacio);
                    lblImporteDescontado.Visible = false;
                    dgvCtaCteDetExtras.DataSource = dtExtras;
                    foreach (DataGridViewColumn item in dgvCtaCteDetExtras.Columns)
                        item.Visible = false;

                    dgvCtaCteDetExtras.Columns["extra"].Visible = true;
                    dgvCtaCteDetExtras.Columns["extra"].HeaderText = "Modificaciones";

                }
                else
                {
                    dgvCtaCteDetExtras.DataSource = dtExtras;
                    lblImporteDescontado.Text = String.Format("Total descontado: {0}", CalcularTotalDescuento().ToString("c"));
                    FormatearGrilla();
                }
                lblTotal.Text = string.Format("Total de registros: {0}", dtExtras.Rows.Count);
                lblImporteDescontado.Location = new Point(this.Width - lblImporteDescontado.Width, lblImporteDescontado.Location.Y);
            }
            else
            {
                dgvCtaCteDetExtras.DataSource = dtBonificaciones;
                dgvCtaCteDetExtras.Columns["nombre"].Visible = true;
                dgvCtaCteDetExtras.Columns["porcentaje"].Visible = true;

                dgvCtaCteDetExtras.Columns["nombre"].HeaderText = "Bonificaciones aplicadas";
                dgvCtaCteDetExtras.Columns["porcentaje"].HeaderText = "Porcentaje";
                dgvCtaCteDetExtras.Columns["porcentaje"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                lblTituloHeader.Text = "Bonificaciones";
                lblImporteDescontado.Visible = false;
                dgvCtaCteDetExtras.Enabled = true;
                pnlInferior.Visible = false;
                pnlInferior.Visible = false;
            }
        }
        private Decimal CalcularTotalDescuento()
        {
            Decimal total = 0;
            foreach (DataRow item in dtExtras.Rows)
                total = total + Convert.ToDecimal(item["descuento"]);
            return total;
        }
        public frmUsuariosCtacteDetExtras(bool parte)
        {
            this.parteConexion = parte;
            InitializeComponent();
        }

        private void frmUsuariosCtacteDetExtras_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUsuariosCtacteDetExtras_Load(object sender, EventArgs e)
        {
            ComenzarCarga();
        }

        private void FormatearGrilla()
        {
            foreach (DataGridViewColumn item in dgvCtaCteDetExtras.Columns)
                item.Visible = false;

            dgvCtaCteDetExtras.Columns["importe_original"].Visible = true;
            dgvCtaCteDetExtras.Columns["importe_original"].HeaderText = "Importe Original";
            dgvCtaCteDetExtras.Columns["importe_original"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCtaCteDetExtras.Columns["importe_original"].DefaultCellStyle.Format = "c";

            dgvCtaCteDetExtras.Columns["importe_con_descuento"].Visible = true;
            dgvCtaCteDetExtras.Columns["importe_con_descuento"].HeaderText = "Importe con descuento";
            dgvCtaCteDetExtras.Columns["importe_con_descuento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCtaCteDetExtras.Columns["importe_con_descuento"].DefaultCellStyle.Format = "c";


            dgvCtaCteDetExtras.Columns["porcentaje"].Visible = true;
            dgvCtaCteDetExtras.Columns["porcentaje"].HeaderText = "Porcentaje";
            dgvCtaCteDetExtras.Columns["porcentaje"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvCtaCteDetExtras.Columns["extra"].Visible = true;
            dgvCtaCteDetExtras.Columns["extra"].HeaderText = "Tipo";


            dgvCtaCteDetExtras.Columns["detalle"].Visible = true;
            dgvCtaCteDetExtras.Columns["detalle"].HeaderText = "Detalle";

            dgvCtaCteDetExtras.Columns["descuento"].Visible = true;
            dgvCtaCteDetExtras.Columns["descuento"].HeaderText = "Descuento";
            dgvCtaCteDetExtras.Columns["descuento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCtaCteDetExtras.Columns["descuento"].DefaultCellStyle.Format = "c";



        }
    }
}
