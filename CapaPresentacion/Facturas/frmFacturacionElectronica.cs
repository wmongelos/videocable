﻿using CapaNegocios;
using System;
using System.ComponentModel;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FacturacionElectronica : Form
    {
        private Thread hilo;
        private delegate void myDel();
        private DataTable dt;
        private Comprobantes oComp = new Comprobantes();
        private Comprobantes_Tipo oComprobante_Tipo = new Comprobantes_Tipo();
        private Servicios_Sub oSubServicio = new Servicios_Sub();

        private int mes;
        private int año;

        public FacturacionElectronica()
        {
            InitializeComponent();
        }

        private void comenzarCarga()
        {
            pgCircular.Start();

            dgv.DataSource = null;

            mes = Convert.ToInt32(cboMeses.SelectedIndex + 1);
            año = Convert.ToInt32(spAño.Value);


            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
        }

        private void cargarDatos()
        {
            try
            {
                dt = oComp.ListarLoteFacturacionElec(mes, año);

                myDel MD = new myDel(asignarDatos);

                this.Invoke(MD, new object[] { });

                pgCircular.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Informacion" + ex.Message);
            }
        }

        private bool validar(int column, int row)
        {
            DataGridViewCell celda_1 = dgv[column, row];
            DataGridViewCell celda_2 = dgv[column, row - 1];

            if (celda_1.Value == null || celda_2.Value == null)
                return false;

            return celda_1.Value.ToString() == celda_2.Value.ToString();
        }

        private void asignarDatos()
        {
            dgv.DataSource = dt;

            dgv.Columns["id"].HeaderText = "Nro. Usuario";
            dgv.Columns["id"].Visible = true;

            dgv.Columns["usuario"].HeaderText = "Usuario";
            dgv.Columns["usuario"].Visible = true;

            dgv.Columns["descripcion"].HeaderText = "Comprobante";
            dgv.Columns["descripcion"].Visible = true;

            dgv.Columns["idctacte"].Visible = false;
            dgv.Columns["id_usuarios_locacion"].Visible = false;

            dgv.Columns["importe_original"].HeaderText = "Importe";
            dgv.Columns["importe_original"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["importe_original"].DefaultCellStyle.Format = "C2";
            dgv.Columns["importe_original"].Visible = true;


            cboMeses.Enabled = true;
            spAño.Enabled = true;

        }

        private void FacturacionElectronica_Load(object sender, EventArgs e)
        {
            cboMeses.SelectedIndex = DateTime.Today.Month - 1;
            spAño.Value = DateTime.Today.Year;
            comenzarCarga();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FacturacionElectronica_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            bgw.RunWorkerAsync();
        }

        private void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            Usuarios_CtaCte oUsuCtaCte = new Usuarios_CtaCte();

            foreach (DataRow dr in dt.Rows)
            {
                int idUsuario = Convert.ToInt32(dr["id"]);
                int idCtaCte = Convert.ToInt32(dr["idctacte"]);
                int idUsuarioLocacion = Convert.ToInt32(dr["id_usuarios_locacion"]);
                decimal importeTotal = Convert.ToDecimal(dr["importe_original"]);
                DataRow drGetNum = oComprobante_Tipo.GetNumeracion(Convert.ToInt32(Comprobantes_Tipo.Tipo.FACTURA_B), Puntos_Cobros.Id_Punto);
                oComprobante_Tipo.SetNumeracion(Convert.ToInt32(drGetNum["idPuntoVenta"]), Convert.ToInt32(Comprobantes_Tipo.Tipo.FACTURA_B), Convert.ToInt32(drGetNum["numComprobante"]));

                Comprobantes oComprobante = new Comprobantes();
                oComprobante.Id_Usuarios = idUsuario;
                oComprobante.Fecha = DateTime.Today;
                oComprobante.Punto_Venta = Convert.ToInt32(drGetNum["numPuntoVenta"]);
                oComprobante.Numero = Convert.ToInt32(drGetNum["numComprobante"]);
                oComprobante.Id_Comprobantes_Tipo = (int)Comprobantes_Tipo.Tipo.FACTURA_B;
                oComprobante.Importe = importeTotal;
                oComprobante.Id_Usuarios_Locaciones = idUsuarioLocacion;

                oComprobante.Id = oComprobante.Guardar(oComprobante);

                if (oComprobante.Id > 0)
                {


                    oUsuCtaCte.SetFacturaElectronica(oComprobante.Id, oComprobante.Id_Comprobantes_Tipo, String.Format("COMPROBANTE FACTURA B {0}-{1}", oComprobante.Punto_Venta.ToString().PadLeft(4, '0'),
                        oComprobante.Numero.ToString().PadLeft(4, '0')), idCtaCte, 0);
                }
            }
        }

        private void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Proceso Finalizado", "Mensaje del Sistema");
        }

        private void dgv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;

            if (e.RowIndex < 1 || e.ColumnIndex < 0)
                return;

            if (validar(e.ColumnIndex, e.RowIndex))
                e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
            else
                e.AdvancedBorderStyle.Top = dgv.AdvancedCellBorderStyle.Top;
        }

        private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (validar(e.ColumnIndex, e.RowIndex))
                {
                    e.Value = "";
                    e.FormattingApplied = true;
                }
            }
            catch { }
        }
    }
}
