using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using CapaNegocios;
using CapaPresentacion;
using System.Globalization;

namespace CapaPresentacion.Informes
{
    public partial class frmInformeServiciosNuevo : Form
    {

        private int idEstadoServicio = 0, idTipoFacturacion = 0, id_Facturacion_Empresa = 0;
        DataTable dtServiciosEstados, dtTiposFacturacion, dtDatos;
        Tablas oTablas = new Tablas();
        Thread hilo;
        Informes_Servicios oInformesServicios = new Informes_Servicios();
        Tools oTools = new Tools();
        Configuracion oConfig = new Configuracion();
        BindingSource oBinding = new BindingSource();
        private delegate void myDel();
        int mes, ano, condicion_fecha, Filas_Totales;
        DateTime fecha_factura;
        public frmInformeServiciosNuevo()
        {
            InitializeComponent();
        }


        private void ComenzarCarga()
        {
            if (chkFacturacion.Checked == true)
                condicion_fecha = 1;
            else
                condicion_fecha = 0;

            fecha_factura = dtpFecha.Value;
            id_Facturacion_Empresa = Convert.ToInt32(oConfig.GetValor_N("Id_Tipo_Facturacion"));
            idEstadoServicio = Convert.ToInt32(cboEstadoServicio.SelectedValue);
            idTipoFacturacion = Convert.ToInt32(cboTipoFacturacion.SelectedValue);
            pgCircular.Start();
            hilo = new Thread(new ThreadStart(CargarDatos));
            hilo.IsBackground = true;
            hilo.Start();
            btnBuscar.Enabled = false;
            btnExportar.Enabled = false;
        }

        private void CargarDatos()
        {
            try
            {
                dtDatos = oInformesServicios.Listar_Datos_Informe_Servicios(idEstadoServicio, idTipoFacturacion, id_Facturacion_Empresa, fecha_factura, condicion_fecha);
                oBinding.DataSource = dtDatos;

                myDel MD = new myDel(AsignarDatos);
                this.Invoke(MD, new object[] { });
            }
            catch
            {
                //throw;
                MessageBox.Show("Error al cargar información.");
            }
            pgCircular.Stop();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            oBinding = new BindingSource();
            dtDatos = new DataTable();
            this.Cursor = Cursors.WaitCursor;
            lblCargando.Visible = true;
            foreach (Control item in this.Controls)
            {
                if (item.Name != "pgCircular")
                    item.Enabled = false;
            }
            ComenzarCarga();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.Rows.Count > 0)
            {
                oTools.ExportToExcel(dgvDatos, "Cantidad de servicios");
            }
            else
                MessageBox.Show("No hay datos en la grilla.");
        }

        private void chkFacturacion_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnExportar_Click_1(object sender, EventArgs e)
        {
            Tools oTools = new Tools();
            oTools.ExportDataTableToExcel(dtDatos.DefaultView.ToTable(), "informe", this);
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            if(dtDatos.Rows.Count > 0)
                dtDatos.DefaultView.RowFilter = String.Format("Convert(codigo, 'System.String') LIKE '%{0}%' or Servicio LIKE '%{0}%' or nombre LIKE '%{0}%' or apellido LIKE '%{0}%' or localidad LIKE '%{0}%'", txtFiltro.Text);
        }

        private void frmInformeServiciosNuevo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void chkFacturacion_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkFacturacion.Checked == true)
                dtpFecha.Enabled = true;
            else
                dtpFecha.Enabled = false;
              
        }

        private void frmInformeServiciosNuevo_Load(object sender, EventArgs e)
        {
            dtServiciosEstados = new DataTable();
            dtTiposFacturacion = new DataTable();
            dtServiciosEstados = Tablas.DataServicios_Estados;
            dtTiposFacturacion = Tablas.DataTiposFacturacion;

            DataRow drServiciosEstados = dtServiciosEstados.NewRow();
            drServiciosEstados["id"] = 0;
            drServiciosEstados["estado"] = "TODOS";
            dtServiciosEstados.Rows.Add(drServiciosEstados);

            DataRow drTiposFacturacion = dtTiposFacturacion.NewRow();
            drTiposFacturacion["id"] = 0;
            drTiposFacturacion["nombre"] = "TODOS";
            dtTiposFacturacion.Rows.Add(drTiposFacturacion);

            cboEstadoServicio.DataSource = dtServiciosEstados;
            cboEstadoServicio.DisplayMember = "estado";
            cboEstadoServicio.ValueMember = "id";
            cboEstadoServicio.SelectedIndex = 0;
            cboTipoFacturacion.DataSource = dtTiposFacturacion;
            cboTipoFacturacion.DisplayMember = "nombre";
            cboTipoFacturacion.ValueMember = "id";
            cboTipoFacturacion.SelectedIndex = 0;
        }

        private void AsignarDatos()
        {
            dgvDatos.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvDatos.RowHeadersVisible = false;

            dgvDatos.DataSource = oBinding;
            foreach (DataGridViewColumn item in dgvDatos.Columns)
            {
                //item.AutoSizeMode= DataGridViewAutoSizeColumnMode.AllCells;
                item.HeaderText = char.ToUpper(item.Name[0]) + item.Name.Substring(1);
                item.HeaderText = item.HeaderText.Replace('_', ' ');
                //if (item.ValueType.ToString() == "System.Decimal")
                //{
                //    item.DefaultCellStyle.Format = "C2";
                //    item.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //}
            }


            btnBuscar.Enabled = true;
            btnExportar.Enabled = true;

            lblTotales.Text = "Total de registros: " + dtDatos.Rows.Count.ToString();
            lblCargando.Visible = false;
            this.Cursor = Cursors.Default;
            foreach (Control item in this.Controls)
                    item.Enabled = true;
        }

        private void Buscar()
        {
            mes = dtpFecha.Value.Month;
            ano = dtpFecha.Value.Year;
            ComenzarCarga();
        }

        private void ExportarAExcel()
        {
            if (dgvDatos.Rows.Count > 0)
            {
                oTools.ExportToExcel(dgvDatos, "Cantidad de servicios");
            }
            else
                MessageBox.Show("No hay datos en la grilla.");
        }


        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
