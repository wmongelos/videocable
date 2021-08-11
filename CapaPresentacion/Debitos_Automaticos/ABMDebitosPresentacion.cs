using CapaNegocios;
using CapaPresentacion.Impresiones;
using System;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
namespace CapaPresentacion.Abms
{
    public partial class ABMDebitosPresentacion : Form
    {
        private int idTarifaActual;
        DataTable dtFormasDePago = new DataTable();
        DataTable dtPresentaciones = new DataTable();
        DataTable dtDebitosActivos = new DataTable();
        DataTable dtDebitosUsuariosServicios = new DataTable();
        DateTime fechaDesde, fechaHasta;
        DialogResult dialogResult;
        Formas_de_pago oFormasDePago = new Formas_de_pago();
        Presentacion_Debitos oPresentacionDebitos = new Presentacion_Debitos();
        Presentacion_Plasticos oPresentacionPlasticos = new Presentacion_Plasticos();
        Presentacion_Usuarios_Servicios oPresentacionUsuariosServicios = new Presentacion_Usuarios_Servicios();
        Usuarios oUsuarios = new Usuarios();
        Facturacion oFacturacion = new Facturacion();
        Servicios_Tarifas oServiciosTarifas = new Servicios_Tarifas();
        Thread hilo;
        DateTime dateTimeAux = new DateTime(1, 1, 1);
        delegate void myDel();
        Tools oTools = new Tools();

        private void ComenzarCarga()
        {
            pgCircular.Start();
            hilo = new Thread(new ThreadStart(CargarDatos));
            hilo.IsBackground = true;
            hilo.Start();
        }

        private void CargarDatos()
        {
            try
            {
                dtFormasDePago = oFormasDePago.ListarPorTipodeForma(Convert.ToInt32(Formas_de_pago.Tipos_Formas_Pagos.DEBITO_AUTOMATICO));
                dtPresentaciones = oPresentacionDebitos.Listar(0, dateTimeAux, fechaDesde, fechaHasta);
                myDel MD = new myDel(AsignarDatos);
                this.Invoke(MD, new object[] { });
                pgCircular.Stop();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
            }
        }

        private void AsignarDatos()
        {
            cboFormaDePago.DataSource = dtFormasDePago;
            cboFormaDePago.ValueMember = "id";
            cboFormaDePago.DisplayMember = "nombre";
            dgvPresentaciones.DataSource = dtPresentaciones;
            for (int x = 0; x < dgvPresentaciones.Columns.Count; x++)
                dgvPresentaciones.Columns[x].Visible = false;
            dgvPresentaciones.Columns["periodo"].Visible = true;
            dgvPresentaciones.Columns["monto_total"].Visible = true;
            dgvPresentaciones.Columns["monto_total_pago"].Visible = true;
            dgvPresentaciones.Columns["monto_rechazado"].Visible = true;
            dgvPresentaciones.Columns["monto_prefacturacion"].Visible = true;
            dgvPresentaciones.Columns["cant_plasticos_aceptados"].Visible = true;
            dgvPresentaciones.Columns["cant_plasticos_rechazados"].Visible = true;
            dgvPresentaciones.Columns["forma_de_pago"].Visible = true;

            dgvPresentaciones.Columns["periodo"].HeaderText = "Periodo";
            dgvPresentaciones.Columns["monto_total"].HeaderText = "Monto presentado(ARS)";
            dgvPresentaciones.Columns["monto_total"].Width = 150;
            dgvPresentaciones.Columns["monto_total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPresentaciones.Columns["monto_total_pago"].HeaderText = "Monto pago(ARS)";
            dgvPresentaciones.Columns["monto_total_pago"].Width = 150;
            dgvPresentaciones.Columns["monto_rechazado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPresentaciones.Columns["monto_rechazado"].HeaderText = "Monto rechazado(ARS)";
            dgvPresentaciones.Columns["monto_rechazado"].Width = 150;
            dgvPresentaciones.Columns["cant_plasticos_aceptados"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPresentaciones.Columns["cant_plasticos_aceptados"].HeaderText = "Cantidad plásticos aceptados";
            dgvPresentaciones.Columns["cant_plasticos_aceptados"].Width = 150;
            dgvPresentaciones.Columns["cant_plasticos_rechazados"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPresentaciones.Columns["cant_plasticos_rechazados"].HeaderText = "Cantidad plásticos rechazados";
            dgvPresentaciones.Columns["cant_plasticos_rechazados"].Width = 150;
            dgvPresentaciones.Columns["forma_de_pago"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPresentaciones.Columns["forma_de_pago"].HeaderText = "Forma de pago";
            dgvPresentaciones.Columns["forma_de_pago"].Width = 150;
            dgvPresentaciones.Columns["monto_prefacturacion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPresentaciones.Columns["monto_prefacturacion"].HeaderText = "Monto prefacturación(ARS)";
            dgvPresentaciones.Columns["monto_prefacturacion"].Width = 150;

            DarEstiloGrillaDebitos(dgvPresentaciones, 30);

            lblTotal.Text = String.Format("Total de registros: {0}.", dgvPresentaciones.Rows.Count);
            btnBuscar.Enabled = true;
        }

        private void DarEstiloGrillaDebitos(DataGridView dgvGrillaDebitos, int alturaFilas)
        {
            int idEstado = 0;
            int borrado = 0;
            foreach (DataGridViewRow fila in dgvGrillaDebitos.Rows)
            {
                fila.Height = alturaFilas;
                idEstado = Convert.ToInt16(fila.Cells["id_estado"].Value);
                borrado = Convert.ToInt16(fila.Cells["borrado"].Value);
                if (borrado == 1)
                    fila.DefaultCellStyle.BackColor = Color.Gray;
                else if (idEstado == Convert.ToInt16(Presentacion_Debitos.ESTADO.ARCHIVO_PENDIENTE))
                    fila.DefaultCellStyle.BackColor = Color.Tomato;
                else if (idEstado == Convert.ToInt16(Presentacion_Debitos.ESTADO.RECIBO_PENDIENTE))
                    fila.DefaultCellStyle.BackColor = Color.MediumTurquoise;
                else 
                    fila.DefaultCellStyle.BackColor = Color.LightGreen;
            }
        }

        private void Buscar()
        {
            if (DateTime.Compare(dtpFechaDesde.Value.Date, dtpFechaHasta.Value.Date) < 0)
            {
                btnBuscar.Enabled = false;
                fechaDesde = dtpFechaDesde.Value;
                fechaHasta = dtpFechaHasta.Value;
                ComenzarCarga();
            }
            else
                MessageBox.Show("La primer fecha debe ser menor que la segunda");
        }

        private void ComenzarProcesoPresentacion()
        {
            bool generarPresentacion = true;
            DataTable dtDatosPresentacionExistente = new DataTable();
            DataTable dtDebitosEnviar = new DataTable();
            dtDebitosEnviar = oPresentacionPlasticos.GetEstructuraPresentacionPlasticos();
            if (DateTime.Now.Month == 12)
                oPresentacionDebitos.Fecha_Presentacion = new DateTime(DateTime.Now.Year + 1, 1, 1);
            else
                oPresentacionDebitos.Fecha_Presentacion = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, 1);
            oPresentacionDebitos.Fecha_Creacion = DateTime.Now;
            oPresentacionDebitos.Id_Estado = Convert.ToInt32(Presentacion_Debitos.ESTADO.ARCHIVO_PENDIENTE);
            oPresentacionDebitos.Periodo = oPresentacionDebitos.Fecha_Presentacion.ToString("MMMM yyyy");
            oPresentacionDebitos.Monto_Total = 0;
            oPresentacionDebitos.Id_Forma_De_Pago = Convert.ToInt32(cboFormaDePago.SelectedValue);
            oPresentacionDebitos.Id = 0;

            dtDatosPresentacionExistente = oPresentacionDebitos.Listar(0, oPresentacionDebitos.Fecha_Presentacion, dateTimeAux, dateTimeAux);
            if (dtDatosPresentacionExistente.Rows.Count > 0)
            {
                if (Convert.ToInt16(dtDatosPresentacionExistente.Rows[0]["id_forma_de_pago"]) == oPresentacionDebitos.Id_Forma_De_Pago)
                {
                    if (Convert.ToInt16(dtDatosPresentacionExistente.Rows[0]["id_estado"]) == Convert.ToInt16(Presentacion_Debitos.ESTADO.PAGO_GENERADO))
                    {
                        generarPresentacion = false;
                        MessageBox.Show("La operación no se puede realizar ya que la presentación correspondiente al periodo consultado ya se encuentra generada y pagada.");
                    }
                    else
                    {
                        dialogResult = MessageBox.Show(String.Format("Ya se encuentra realizada una presentación de débitos del periodo {0} pero no se encuentra paga todavía .¿Desea reemplazarla?.", oPresentacionDebitos.Periodo), "", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                            generarPresentacion = true;
                        else
                            generarPresentacion = false;
                    }
                }
            }
        }

        private void VerDetalles()
        {
            oPresentacionDebitos.Id = Convert.ToInt32(dgvPresentaciones.SelectedRows[0].Cells["id"].Value);
            oPresentacionDebitos.Id_Estado = Convert.ToInt16(dgvPresentaciones.SelectedRows[0].Cells["id_estado"].Value);
            oPresentacionDebitos.Id_Prefacturacion_Asociada = Convert.ToInt32(dgvPresentaciones.SelectedRows[0].Cells["id_prefacturacion_asociada"].Value);
            oPresentacionDebitos.Fecha_Creacion = Convert.ToDateTime(dgvPresentaciones.SelectedRows[0].Cells["fecha_creacion"].Value);
            oPresentacionDebitos.Fecha_Presentacion = Convert.ToDateTime(dgvPresentaciones.SelectedRows[0].Cells["fecha_presentacion"].Value);
            oPresentacionDebitos.Periodo = dgvPresentaciones.SelectedRows[0].Cells["periodo"].Value.ToString();
            oPresentacionDebitos.Monto_Total = Convert.ToDecimal(dgvPresentaciones.SelectedRows[0].Cells["monto_total"].Value);
            oPresentacionDebitos.Id_Forma_De_Pago = Convert.ToInt32(dgvPresentaciones.SelectedRows[0].Cells["id_forma_de_pago"].Value);
            DataTable dtDebitosEnviar = new DataTable();
            dtDebitosEnviar = oPresentacionPlasticos.Listar(oPresentacionDebitos.Id);

            ABMDebitosPresentacionDetalles abmPresentacionDetalles = new ABMDebitosPresentacionDetalles(Convert.ToInt16(ABMDebitosPresentacionDetalles.TAREA.CONSULTA_PRESENTACION), dtDebitosEnviar, oPresentacionDebitos.Fecha_Presentacion, oPresentacionDebitos, 0, oPresentacionDebitos.Id_Forma_De_Pago);
            frmPopUp frmPp = new frmPopUp();
            frmPp.Formulario = abmPresentacionDetalles;
            frmPp.Maximizar = true;
            frmPp.ShowDialog();
            if (abmPresentacionDetalles.DialogResult == DialogResult.OK)
                ComenzarCarga();
        }



        public ABMDebitosPresentacion()
        {
            InitializeComponent();
        }

        private void ABMDebitosPresentacion_Load(object sender, EventArgs e)
        {
            fechaDesde = new DateTime(DateTime.Now.Year, 1, 1);
            fechaHasta = new DateTime(DateTime.Now.Year, 12, 1);
            dtpFechaDesde.Value = fechaDesde;
            dtpFechaHasta.Value = fechaHasta;
            ComenzarCarga();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void btnGenerarPresentacion_Click(object sender, EventArgs e)
        {
            ComenzarProcesoPresentacion();
        }

        private void btnGenerarPago_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Permite generar los recibos individuales y el recibo de débitos para la caja. En desarrollo");
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Permite editar En desarrollo");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("En desarrollo");
        }

        private void btnGenerarArchivoPresentacion_Click(object sender, EventArgs e)
        {

        }

        private void btnVerDetalles_Click(object sender, EventArgs e)
        {
            if (dgvPresentaciones.SelectedRows.Count > 0)
                VerDetalles();
            else
                MessageBox.Show("No ha seleccionado una presentación.");
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {

        }

        private void btnImprimirRecibo_Click(object sender, EventArgs e)
        {
            if (dgvPresentaciones.SelectedRows.Count > 0)
            {
                if (Convert.ToInt32(dgvPresentaciones.SelectedRows[0].Cells["id_estado"].Value) == Convert.ToInt16(Presentacion_Debitos.ESTADO.PAGO_GENERADO))
                {
                    Impresion oImpresiones = new Impresion();
                    oImpresiones.ImprimirInformePresentacion(Convert.ToInt32(dgvPresentaciones.SelectedRows[0].Cells["id"].Value));
                }
                else
                    MessageBox.Show("La presentación aún no ha pasado por el proceso de pago. El recibo se generará luego de realizar los pagos correspondientes.");
            }
            else
                MessageBox.Show("No se ha seleccionado una presentación.");
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            if (dgvPresentaciones.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("A continuación se eliminara la presentacion eliminada ¿Desea continuar?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    frmResponsable oFRmResponsable = new frmResponsable();
                    if (oFRmResponsable.ShowDialog() == DialogResult.OK)
                    {

                        int idPresentacion = Convert.ToInt32(dgvPresentaciones.SelectedRows[0].Cells["id"].Value);

                        if (oPresentacionDebitos.Eliminar(idPresentacion) == 0)
                        {
                            MessageBox.Show("Presentacion eliminada correctamente.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ComenzarCarga();
                        }
                        else
                            MessageBox.Show("Hubo un error al intentar eliminar la presentacion seleccionada.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        MessageBox.Show("Operacion cancelada", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}//291119fede
