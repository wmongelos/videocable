using CapaNegocios;
using System;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmCaja_Diaria : Form

    {
        private Thread hilo;
        private delegate void myDel();

        private DataTable dtusuarios_recibos;
        private DataTable dtusuarios_recibos_1;
        private DataTable dtusuarios_recibos_2;
        private DataTable dtformasCta1, dtformasCta2;
        private DataTable dtPagosCuenta1 = new DataTable();
        private DataTable dtPagosCuenta2 = new DataTable();
        private Decimal monto1 = 0;
        private Decimal monto2 = 0;
        private Int32 GrillaFoco, idFormaSeleccionada;
        private decimal montoRetirado = 0;
        private Caja_Diaria ocaja_diaria = new Caja_Diaria();
        private Caja_Egreso oEgreso = new Caja_Egreso();
        private Puntos_Cobros opuntos_cobros = new Puntos_Cobros();
        private Usuarios_CtaCte_Recibos oUsuariosCtaCteRecibos = new Usuarios_CtaCte_Recibos();
        private DataTable dtDetalleRecibo = new DataTable();
        private string salida;

        Int32 IdCaja = 0;

        private void comenzarCarga()
        {
            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
        }

        private void cargarDatos()
        {
            try
            {
                oEgreso.MontoRetirado(this.IdCaja,out montoRetirado,out salida);
                dtusuarios_recibos = ocaja_diaria.ListarDetallesRecibosAVC(Puntos_Cobros.Id_Punto, IdCaja, 1, false); ////ocaja_diaria.trae_ultimo_recibos(1, 1);
                dtusuarios_recibos_2 = ocaja_diaria.ListarDetallesRecibosAVC(Puntos_Cobros.Id_Punto, IdCaja, 2, false); ////ocaja_diaria.trae_ultimo_recibos(1, 1);

                dtformasCta1 = ocaja_diaria.Listar_Recibos_Det(Puntos_Cobros.Id_Punto, 0, IdCaja, 1); ////ocaja_diaria.trae_ultimo_recibos(1, 1);
                dtformasCta2 = ocaja_diaria.Listar_Recibos_Det(Puntos_Cobros.Id_Punto, 0, IdCaja, 2); ////ocaja_diaria.trae_ultimo_recibos(1, 1);

                GrillaFoco = 1;
                dtPagosCuenta1 = ocaja_diaria.ListarDetallesCtaCteDetPagos(Puntos_Cobros.Id_Punto, IdCaja, 1);
                dtPagosCuenta2 = ocaja_diaria.ListarDetallesCtaCteDetPagos(Puntos_Cobros.Id_Punto, IdCaja, 2);


                myDel MD = new myDel(calcularmayor);
                this.Invoke(MD, new object[] { });

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Informacion" + ex.Message);
            }
        }

        private void calcularmayor()
        {
            Int32 recibo1 = 0;
            Int32 recibo2 = 0;

            foreach (DataRow lin in dtusuarios_recibos.Rows)
            {
                var v_cuenta = Int32.Parse(lin["cuenta"].ToString());
                var v_recibo = Int32.Parse(lin["numero"].ToString());
                if (v_cuenta == 1)
                {
                    if (v_recibo > recibo1)
                    {
                        recibo1 = v_recibo;
                    }
                }
                else
                {
                    if (v_recibo > recibo2)
                    {
                        recibo2 = v_recibo;
                    }
                }
            }

            txtultimorecibo1.Text = recibo1.ToString();
            txtultimorecibo2.Text = recibo2.ToString();
            asignarDatos();
        }

        private void colores()
        {
            foreach (DataGridViewRow dr in dgvRecibos1.Rows)
            {

                DataGridViewTextBoxCell noaparece = new DataGridViewTextBoxCell();

                if (Convert.ToUInt32(dr.Cells["borrado"].Value.ToString()) == 1)
                {
                    dr.DefaultCellStyle.ForeColor = Color.Red;

                }
            }
        }

        private void asignarDatos()
        {


            dtusuarios_recibos_1 = dtusuarios_recibos.Copy();

            DataView v1 = dtusuarios_recibos_1.DefaultView;
            v1.RowFilter = string.Format("numero <= {0}", txtultimorecibo1.Text);
            v1.Sort = "id_comprobantes_tipo ASC";
            dtusuarios_recibos_1 = v1.ToTable();
            dgvRecibos1.DataSource = dtusuarios_recibos_1;

            DataView v2 = dtusuarios_recibos_2.DefaultView;
            dtusuarios_recibos_2 = v2.ToTable();
            dgvRecibos2.DataSource = dtusuarios_recibos_2;

            foreach (DataGridViewColumn item in dgvRecibos1.Columns)
                item.Visible = false;

            dgvRecibos1.Columns["fecha_movimiento"].HeaderText = "Fecha movimiento";
            dgvRecibos1.Columns["fecha_movimiento"].Visible = true;
            dgvRecibos1.Columns["nomape"].Visible = true;
            dgvRecibos1.Columns["nomape"].HeaderText = "Usuario";

            dgvRecibos1.Columns["numero_muestra"].HeaderText = "Numero";
            dgvRecibos1.Columns["numero_muestra"].Visible = true;
            dgvRecibos1.Columns["fecha_movimiento"].HeaderText = "Fecha";
            dgvRecibos1.Columns["fecha_movimiento"].Visible = true;

            dgvRecibos1.Columns["importe_recibo"].Visible = true;
            dgvRecibos1.Columns["importe_recibo"].HeaderText = "$";
            dgvRecibos1.Columns["Importe_recibo"].DefaultCellStyle.Format = "c2";
            dgvRecibos1.Columns["Importe_recibo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            foreach (DataGridViewColumn item in dgvRecibos2.Columns)
                item.Visible = false;

            dgvRecibos2.Columns["fecha_movimiento"].HeaderText = "Fecha movimiento";
            dgvRecibos2.Columns["fecha_movimiento"].Visible = true;
            dgvRecibos2.Columns["nomape"].Visible = true;
            dgvRecibos2.Columns["nomape"].HeaderText = "Usuario";
            dgvRecibos2.Columns["numero_muestra"].HeaderText = "Numero";
            dgvRecibos2.Columns["numero_muestra"].Visible = true;
            dgvRecibos2.Columns["fecha_movimiento"].HeaderText = "Fecha";
            dgvRecibos2.Columns["fecha_movimiento"].Visible = true;
            dgvRecibos2.Columns["importe_recibo"].Visible = true;
            dgvRecibos2.Columns["importe_recibo"].HeaderText = "$";
            dgvRecibos2.Columns["Importe_recibo"].DefaultCellStyle.Format = "c2";
            dgvRecibos2.Columns["Importe_recibo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


            dgvformas.DataSource = tabControl1.SelectedIndex == 0 ? dtformasCta1 : dtformasCta2;

            for (int i = 0; i < dgvformas.Columns.Count; i++)
                dgvformas.Columns[i].Visible = false;

            dgvformas.Columns["forma"].HeaderText = "Forma de pago";
            dgvformas.Columns["forma"].Visible = true;

            dgvformas.Columns["importe"].HeaderText = "$";
            dgvformas.Columns["importe"].Visible = true;
            dgvformas.Columns["importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvformas.Columns["Importe"].DefaultCellStyle.Format = "c2";

            suma();
        }

        private void suma()
        {
            

            Int32 desde1 = 0;
            Int32 desde2 = 0;
            Int32 hasta1 = 0;
            Int32 hasta2 = 0;
            txtmonto1.Text = "0";
            txtmonto2.Text = "0";



            try
            {
                if (dtusuarios_recibos_1.Rows.Count > 0) { }
                monto1 = Convert.ToDecimal(dtusuarios_recibos_1.Compute("SUM(importe_recibo)", string.Empty));
                object Monto_anulado1 = dtusuarios_recibos_1.Compute("sum(Importe_recibo)", "borrado=1");
                object Cant_anulado1 = dtusuarios_recibos_1.Compute("count(Importe_recibo)", "borrado=1");

                Monto_anulado1 = Monto_anulado1.ToString() == "" ? 0 : Monto_anulado1;
                Cant_anulado1 = Cant_anulado1.ToString() == "" ? 0 : Cant_anulado1;

                desde1 = Convert.ToInt32(dtusuarios_recibos_1.Compute("MIN(numero)", string.Empty));
                hasta1 = Convert.ToInt32(dtusuarios_recibos_1.Compute("MAX(numero)", string.Empty));
                txtcantidad1.Text = (hasta1 - desde1 + 1).ToString();
                txtmonto1.Text =(monto1 - montoRetirado).ToString();
                txttotal1.Text = (monto1 - Convert.ToDecimal(Monto_anulado1)).ToString();
                txtanulados1_cant.Text = Cant_anulado1.ToString();
                txtanulados1_plata.Text = Monto_anulado1.ToString();
                txtprimerrecibo1.Text = desde1.ToString();
                txthasta1.Text = hasta1.ToString();
                txtRetirado.Text = montoRetirado.ToString();
            }
            catch
            {
            }

            try
            {

                monto2 = Convert.ToDecimal(dtusuarios_recibos_2.Compute("SUM(importe_recibo)", string.Empty));
                object Monto_anulado2 = dtusuarios_recibos_2.Compute("sum(Importe_recibo)", "borrado=1");
                object Cant_anulado2 = dtusuarios_recibos_2.Compute("count(Importe_recibo)", "borrado=1");

                Monto_anulado2 = Monto_anulado2.ToString() == "" ? 0 : Monto_anulado2;
                Cant_anulado2 = Cant_anulado2.ToString() == "" ? 0 : Cant_anulado2;

                desde2 = Convert.ToInt32(dtusuarios_recibos_2.Compute("MIN(numero)", string.Empty));
                hasta2 = Convert.ToInt32(dtusuarios_recibos_2.Compute("MAX(numero)", string.Empty));
                txtcantidad2.Text = (hasta2 - desde2 + 1).ToString();
                txtmonto2.Text = monto2.ToString();
                txttotal2.Text = (monto2 - Convert.ToDecimal(Monto_anulado2)).ToString();
                txtanulados2_cant.Text = Cant_anulado2.ToString();
                txtanulados2_plata.Text = Monto_anulado2.ToString();
                txtprimerrecibo2.Text = desde2.ToString();
                txthasta2.Text = hasta1.ToString();


            }
            catch
            {
            }
            colores();
            try
            {
                txttotal.Text = (Convert.ToDecimal(txttotal1.Text) + Convert.ToDecimal(txttotal2.Text)).ToString();
            }
            catch
            {

            }
        }

        private void Cambiar_formas_de_pago()
        {
            decimal monto = 0;
            int idUsuario = 0;
            int idLocacion = 0;
            int idReciboSeleccionado = 0;
            int idComprobanteSeleccionado = 0;
            int cuenta;

            if (GrillaFoco == 1)
            {
                monto = Convert.ToDecimal(dgvRecibos1.SelectedRows[0].Cells["Importe_recibo"].Value);
                idUsuario = Convert.ToInt32(dgvRecibos1.SelectedRows[0].Cells["id_usuarios"].Value);
                idLocacion = Convert.ToInt32(dgvRecibos1.SelectedRows[0].Cells["id_usuarios_locaciones"].Value);
                idReciboSeleccionado = Convert.ToInt32(dgvRecibos1.SelectedRows[0].Cells["id"].Value);
                idComprobanteSeleccionado = Convert.ToInt32(dgvRecibos1.SelectedRows[0].Cells["id_comprobantes"].Value);
                cuenta = 1;
            }
            else
            {
                monto = Convert.ToDecimal(dgvRecibos2.SelectedRows[0].Cells["Importe_recibo"].Value);
                idUsuario = Convert.ToInt32(dgvRecibos2.SelectedRows[0].Cells["id_usuarios"].Value);
                idLocacion = Convert.ToInt32(dgvRecibos2.SelectedRows[0].Cells["id_usuarios_locaciones"].Value);
                idReciboSeleccionado = Convert.ToInt32(dgvRecibos2.SelectedRows[0].Cells["id"].Value);
                idComprobanteSeleccionado = Convert.ToInt32(dgvRecibos2.SelectedRows[0].Cells["id_comprobantes"].Value);
                cuenta = 2;
            }
            
            frmUsuariosPagos oFrmUsuariosPagos = new frmUsuariosPagos(edicion: true, monto, idLocacion, idUsuario, cuenta);
            oFrmUsuariosPagos.cuenta = 1;
            oFrmUsuariosPagos.viene = 2;
            if (oFrmUsuariosPagos.ShowDialog() == DialogResult.OK)
            {
                this.dtDetalleRecibo = oFrmUsuariosPagos.dtDetalleRecibo;
                try
                {
                    oUsuariosCtaCteRecibos.CambiarFormaPagoRecibo(idReciboSeleccionado, idComprobanteSeleccionado, dtDetalleRecibo);
                    MessageBox.Show("Cambios realizados correctamente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarDatos();
                }
                catch
                {
                    MessageBox.Show("Hubo un error al cambiar la forma de pago.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void formatearPagos()
        {
            foreach (DataGridViewColumn item in dgvPagos.Columns)
                item.Visible = false;
            dgvPagos.Columns["nombre"].Visible = true;
            dgvPagos.Columns["nombre"].DisplayIndex = 0;
            dgvPagos.Columns["nombre"].HeaderText = "Forma de pago";


            dgvPagos.Columns["importe"].HeaderText = "$";
            dgvPagos.Columns["importe"].Visible = true;
            dgvPagos.Columns["importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPagos.Columns["Importe"].DefaultCellStyle.Format = "c2";

        }

        private void ImprimirCaja()
        {
            Impresiones.Impresion oImpresion = new Impresiones.Impresion();
            DataTable dtDatosCaja = ocaja_diaria.GetEstructuraDatosCajaDiariaImpresion();
            DataTable dtDatosFormasPago = ocaja_diaria.GetEstructuraDatosFormasPagoImpresion();
            DataRow drAux = dtDatosCaja.NewRow();
            drAux["recibo_desde"] = 0;
            drAux["recibo_hasta"] = 0;
            drAux["cant_total_recibos"] = 0;
            drAux["monto_total_recibos"] = 0;
            drAux["cant_total_anulados"] = 0;
            drAux["monto_total_anulados"] = 0;
            drAux["cant_final_recibos"] = 0;
            drAux["monto_final_recibos"] = 0;
            if (tabControl1.SelectedIndex == 0)
            {
                drAux["id_personal"] = Personal.Id_Login;
                drAux["personal"] = Personal.Name_Login;
                drAux["punto_cobro"] = Puntos_Cobros.Id_Punto;
                drAux["numero_caja"] = "Caja no cerrada - CUENTA 1";
                if (dtusuarios_recibos_1.Rows.Count > 0)
                {
                    drAux["recibo_desde"] = dtusuarios_recibos_1.Compute("MIN(numero)", string.Empty);
                    drAux["recibo_hasta"] = dtusuarios_recibos_1.Compute("MAX(numero)", string.Empty);
                    drAux["cant_total_recibos"] = dtusuarios_recibos_1.Compute("count(Importe_recibo)", string.Empty);
                    drAux["monto_total_recibos"] = dtusuarios_recibos_1.Compute("SUM(importe_recibo)", string.Empty);
                    drAux["cant_total_anulados"] = dtusuarios_recibos_1.Compute("count(Importe_recibo)", "borrado=1");
                    if (Convert.ToInt32(drAux["cant_total_anulados"]) > 0)
                        drAux["monto_total_anulados"] = dtusuarios_recibos_1.Compute("sum(Importe_recibo)", "borrado=1");
                    else
                        drAux["monto_total_anulados"] = 0;
                    drAux["cant_final_recibos"] = Convert.ToInt32(drAux["cant_total_recibos"]) - Convert.ToInt32(drAux["cant_total_anulados"]);
                    drAux["monto_final_recibos"] = Convert.ToDecimal(drAux["monto_total_recibos"]) - Convert.ToDecimal(drAux["monto_total_anulados"]);
                }
            }
            else
            {
                drAux["id_personal"] = Personal.Id_Login;
                drAux["personal"] = Personal.Name_Login;
                drAux["punto_cobro"] = Puntos_Cobros.Id_Punto;
                drAux["numero_caja"] = "Caja no cerrada - CUENTA 2";
                if (dtusuarios_recibos_2.Rows.Count > 0)
                {
                    drAux["recibo_desde"] = dtusuarios_recibos_2.Compute("MIN(numero)", string.Empty);
                    drAux["recibo_hasta"] = dtusuarios_recibos_2.Compute("MAX(numero)", string.Empty);
                    drAux["cant_total_recibos"] = dtusuarios_recibos_2.Compute("count(Importe_recibo)", string.Empty);
                    drAux["monto_total_recibos"] = dtusuarios_recibos_2.Compute("SUM(importe_recibo)", string.Empty);
                    drAux["cant_total_anulados"] = dtusuarios_recibos_2.Compute("count(Importe_recibo)", "borrado=1");
                    if (Convert.ToInt32(drAux["cant_total_anulados"]) > 0)
                        drAux["monto_total_anulados"] = dtusuarios_recibos_2.Compute("sum(Importe_recibo)", "borrado=1");
                    else
                        drAux["monto_total_anulados"] = 0;
                    drAux["cant_final_recibos"] = Convert.ToInt32(drAux["cant_total_recibos"]) - Convert.ToInt32(drAux["cant_total_anulados"]);
                    drAux["monto_final_recibos"] = Convert.ToDecimal(drAux["monto_total_recibos"]) - Convert.ToDecimal(drAux["monto_total_anulados"]);
                }
            }
            dtDatosCaja.Rows.Add(drAux);

            if (tabControl1.SelectedIndex == 0)
            {
                if (dtformasCta1.Rows.Count > 0)
                {
                    foreach (DataRow formaPago in dtformasCta1.Rows)
                    {
                        drAux = dtDatosFormasPago.NewRow();
                        drAux["monto"] = 0;
                        drAux["forma_pago"] = formaPago["forma"];
                        drAux["cantidad"] = dtPagosCuenta1.Select(String.Format("id_formas_de_pago={0}", formaPago["id_formas_de_pago"].ToString())).Length;
                        if (Convert.ToInt32(drAux["cantidad"]) > 0)
                            drAux["monto"] = formaPago["importe"];
                        dtDatosFormasPago.Rows.Add(drAux);
                    }
                }
            }
            else
            {
                if (dtformasCta2.Rows.Count > 0)
                {
                    foreach (DataRow formaPago in dtformasCta2.Rows)
                    {
                        drAux = dtDatosFormasPago.NewRow();
                        drAux["monto"] = 0;
                        drAux["forma_pago"] = formaPago["forma"];
                        drAux["cantidad"] = dtPagosCuenta2.Select(String.Format("id_formas_de_pago={0}", formaPago["id_formas_de_pago"].ToString())).Length;

                        if (Convert.ToInt32(drAux["cantidad"]) > 0)
                            drAux["monto"] = formaPago["importe"];
                        dtDatosFormasPago.Rows.Add(drAux);
                    }
                }
            }



            oImpresion.ImprimirInformeCajaDiaria(dtDatosCaja, dtDatosFormasPago);
        }

        public frmCaja_Diaria(Int32 Id)
        {
            InitializeComponent();
            IdCaja = Id;
        }

        private void frmCaja_diaria_Load(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void txttotal_TextChanged(object sender, EventArgs e)
        {
            LBTotal.Text = "TOTAL $ (" + txttotal.Text.Trim() + ")";
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCaja_Diaria_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void cmbCierraCaja_Click(object sender, EventArgs e)
        {
            if (IdCaja > 0)
                MessageBox.Show("La Caja sa encuentra cerrada");
            else
            {

                if (MessageBox.Show("¿Desea cerrar la caja?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    ocaja_diaria.Id = 0;
                    ocaja_diaria.Id_Personal = Personal.Id_Login;
                    ocaja_diaria.Id_Puntos_cobros = Puntos_Cobros.Id_Punto;
                    ocaja_diaria.Id_Cierre_General = 0;
                    ocaja_diaria.Numero = 0;
                    ocaja_diaria.Importe_cuenta1 = Decimal.Parse(txttotal1.Text);
                    ocaja_diaria.Importe_cuenta2 = Decimal.Parse(txttotal2.Text);
                    ocaja_diaria.Recibo_cuenta1_desde = Int32.Parse(txtprimerrecibo1.Text);
                    ocaja_diaria.Recibo_cuenta1_hasta = Int32.Parse(txthasta1.Text);

                    ocaja_diaria.Recibo_cuenta2_desde = Int32.Parse(txtprimerrecibo2.Text);
                    ocaja_diaria.Recibo_cuenta2_hasta = Int32.Parse(txthasta2.Text);

                    ocaja_diaria.Fecha = DateTime.Now;//// .Today;
                    string salida = "";
                    int errores = 0;
                    int idCajaNueva = ocaja_diaria.Guardar(ocaja_diaria,out salida);
                    if (idCajaNueva > 0)
                    {
                        oEgreso.ActualizarEgresosCajas(idCajaNueva);
                        if(!ocaja_diaria.Asignar_Numero_Recibos(dtusuarios_recibos_1, idCajaNueva,out salida))
                        {
                            MessageBox.Show($"Error al asignar número de caja a los recibos (cuenta número uno).\n {salida}", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            errores++;
                        }
                        if (!ocaja_diaria.Asignar_Numero_Recibos(dtusuarios_recibos_2, idCajaNueva, out salida))
                        {
                            MessageBox.Show($"Error al asignar número de caja a los recibos (cuenta número dos).\n {salida}", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            errores++;
                        }
                        
                        Log.guardarEvento(Log.ACCION.CIERRE_CAJA);
                        if (errores == 0)
                        {
                            MessageBox.Show("Caja cerrada correctamente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
    
                    }
                    else
                        MessageBox.Show($"Error al cerrar la caja.\n {salida}", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btnRefresca1_Click(object sender, EventArgs e)
        {
            asignarDatos();
        }

        private void btnRefresca2_Click(object sender, EventArgs e)
        {
            asignarDatos();
        }

        private void btnFormasDePago_Click(object sender, EventArgs e)
        {
            Cambiar_formas_de_pago();

        }

        private void dgvRecibos1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            GrillaFoco = 1;

        }

        private void dgvRecibos2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            GrillaFoco = 2;

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (IdCaja > 0)
                MessageBox.Show("La Caja sa encuentra cerrada");
            else
                Cambiar_formas_de_pago();
        }

        private void dgvRecibos1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dgvRecibos1.SelectedRows[0].Cells["id"].Value);
                DataView dv = new DataView(dtPagosCuenta1);
                dv.RowFilter = "id_usuarios_ctacte_recibos = " + id;
                dgvPagos.DataSource = dv.ToTable();
                formatearPagos();
            }
            catch
            {

            }
        }

        private void dgvRecibos2_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dgvRecibos2.SelectedRows[0].Cells["id"].Value);
                DataView dv = new DataView(dtPagosCuenta2);
                dv.RowFilter = "id_usuarios_ctacte_recibos = " + id;
                dgvPagos.DataSource = dv.ToTable();
                formatearPagos();
            }
            catch
            {

            }
        }

        private void boton1_Click(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            asignarDatos();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if(tabControl1.SelectedIndex == 0) 
            { 
                if (dgvRecibos1.Rows.Count > 0)
                {
                    Tools tools = new Tools();
                    this.Cursor = Cursors.WaitCursor;
                    try
                    {
                        tools.ExportDataTableToExcel(dtusuarios_recibos_1, "Deudas usuarios caja 1");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error al exportar a excel");
                    }
                    finally { this.Cursor = Cursors.Default; }
                }
                else
                    MessageBox.Show("Grilla caja 1 vacia");
            }
            else 
            { 
                if (dgvRecibos2.Rows.Count > 0)
                {
                    Tools tools = new Tools();
                    this.Cursor = Cursors.WaitCursor;
                    try
                    {
                        tools.ExportDataTableToExcel(dtusuarios_recibos_2, "Deudas usuarios caja 2");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error al exportar a excel");
                    }
                    finally { this.Cursor = Cursors.Default; }
                }
                else
                    MessageBox.Show("Grilla caja 2 vacia");
            }
        }

        private void btnRetiros_Click(object sender, EventArgs e)
        {
            Contabilidad.frmRetiros oFrmRetiros;
            if (this.IdCaja == 0)
                oFrmRetiros = new Contabilidad.frmRetiros(1, monto1);
            else
                oFrmRetiros = new Contabilidad.frmRetiros(2, monto1, this.IdCaja);
            frmPopUp oPop = new frmPopUp();
            oPop.Formulario = oFrmRetiros;
            oPop.Maximizar = false;
            if (oPop.ShowDialog() == DialogResult.OK)
            {
                comenzarCarga();

            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            //if((tabControl1.SelectedIndex==0 && dtusuarios_recibos_1.Rows.Count>0) || (tabControl1.SelectedIndex==1 && dtusuarios_recibos_2.Rows.Count>0))
            ImprimirCaja();
        }

        private void dgvformas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                idFormaSeleccionada = Convert.ToInt32(dgvformas.SelectedRows[0].Cells["id_formas_de_pago"].Value);
                DataView dvRecibos = dtPagosCuenta1.DefaultView;
                dvRecibos.RowFilter = string.Format("id_formas_de_pago={0}", idFormaSeleccionada);

                frmPopUp oPop = new frmPopUp();
                Contabilidad.frmFormaPagosRecibos oPagos = new Contabilidad.frmFormaPagosRecibos();
                oPagos.dtRecibos = dvRecibos.ToTable();
                oPagos.nombreForma = dgvformas.SelectedRows[0].Cells["forma"].Value.ToString();
                oPagos.monto = Convert.ToDecimal(dgvformas.SelectedRows[0].Cells["importe"].Value);
                oPop.Formulario = oPagos;
                oPop.ShowDialog();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
