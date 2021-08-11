using CapaNegocios;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Informes
{
    public partial class frmInformesServicios : Form
    {
        private int idEstadoServicio = 0, idTipoFacturacion = 0;
        DataTable dtServiciosEstados, dtTiposFacturacion, dtDatos;
        Tablas oTablas = new Tablas();
        Thread hilo;
        Informes_Servicios oInformesServicios = new Informes_Servicios();
        Tools oTools = new Tools();
        private delegate void myDel();
        Facturacion_Mensual_Historial oFacturacionMensualHistorial = new Facturacion_Mensual_Historial();
        int mes, ano;
        int idFacturacionMensual;

        private void ComenzarCarga()
        {
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
                idFacturacionMensual = 0;
                try
                {
                    idFacturacionMensual = Convert.ToInt32(oFacturacionMensualHistorial.RetornarId(mes, ano).Rows[0]["id"]);
                }
                catch { idFacturacionMensual = 0; }
                dtDatos = oInformesServicios.ListarDatosInforme(idEstadoServicio, idTipoFacturacion, idFacturacionMensual);
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

        private void AsignarDatos()
        {
            int totalServicios = 0, totalUsuarios = 0;
            if (dtDatos.Rows.Count > 0)
            {
                totalServicios = Convert.ToInt32(dtDatos.Compute("sum(cantidad_servicios)", ""));
                totalUsuarios = Convert.ToInt32(dtDatos.Compute("sum(cantidad_usuarios)", ""));
            }
            dgvDatos.DataSource = dtDatos;

            for (int x = 0; x < dgvDatos.ColumnCount; x++)
                dgvDatos.Columns[x].Visible = false;

            dgvDatos.Columns["grupo"].Visible = true;
            dgvDatos.Columns["tipo"].Visible = true;
            dgvDatos.Columns["servicio"].Visible = true;
            dgvDatos.Columns["cantidad_servicios"].Visible = true;
            dgvDatos.Columns["cantidad_usuarios"].Visible = true;
            if (idFacturacionMensual > 0)
            {
                dgvDatos.Columns["facturado"].Visible = true;
                dgvDatos.Columns["facturado"].HeaderText = "Facturado";
            }

            dgvDatos.Columns["grupo"].HeaderText = "Grupo";
            dgvDatos.Columns["tipo"].HeaderText = "Tipo";
            dgvDatos.Columns["servicio"].HeaderText = "Servicio";
            dgvDatos.Columns["cantidad_servicios"].HeaderText = "Cantidad de servicios contratados";
            dgvDatos.Columns["cantidad_usuarios"].HeaderText = "Cantidad de usuarios";

            lblTotales.Text = String.Format("Total de servicios:{0}      Total de usuarios:{1}", totalServicios, totalUsuarios);


            try
            {
                dgvDatos.Rows[dgvDatos.Rows.Count - 1].Selected = true;
            }
            catch { }
            foreach (DataGridViewRow fila in dgvDatos.Rows)
                fila.Height = 30;
            btnBuscar.Enabled = true;
            btnExportar.Enabled = true;
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


        public frmInformesServicios()
        {
            InitializeComponent();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                ExportarAExcel();
            }
            catch { MessageBox.Show("Controle que la librería Excel se encuentre instalada."); }
        }

        private void chkFacturacion_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFacturacion.Checked)
                dtpFecha.Enabled = true;
            else
                dtpFecha.Enabled = false;
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void frmInformesServicios_Load(object sender, EventArgs e)
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
    }
}//111119fede
