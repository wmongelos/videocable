using CapaNegocios;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmAgregarSubservicio : Form
    {
        private int IdUsuarioServicio = 0;
        private int IdServicio = 0;
        private string ServicioNombre = "";
        private Thread hilo;
        private delegate void myDel();
        private DataTable DtSubserviciosDisponibles = new DataTable();
        private DataTable DtUsuarioServicio = new DataTable();
        Usuarios_Servicios oUsuarioServicio = new Usuarios_Servicios();
        Partes oPartes = new Partes();
        Partes_Solicitudes oPartesSolicitudes = new Partes_Solicitudes();
        Partes_Historial oPartesHistorial = new Partes_Historial();
        Servicios_Estados_Historial oServicioEstadoHistorial = new Servicios_Estados_Historial();
        Servicios_Tarifas oServiciosTarifas = new Servicios_Tarifas();
        private decimal ImporteTotal = 0;
        private Comprobantes oComprobante = new Comprobantes();
        private Comprobantes_Tipo oComprobante_tipo = new Comprobantes_Tipo();
        private Servicios_Tarifas_Sub oServicios_tarifas_sub = new Servicios_Tarifas_Sub();
        private Usuarios_CtaCte oUsuario_ctacte = new Usuarios_CtaCte();
        private Usuarios_CtaCte_Det oUsuario_ctactedet = new Usuarios_CtaCte_Det();
        DataRow drDatosComprobanteVenta;

        private void comenzarCarga()
        {
            pgCircular.Start();
            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
        }

        private void cargarDatos()
        {
            DtUsuarioServicio = oUsuarioServicio.Traer_datos_usuarios_servicios(IdUsuarioServicio);
            myDel MD = new myDel(asignarDatos);
            this.Invoke(MD, new object[] { });
            pgCircular.Stop();
        }

        private void asignarDatos()
        {
            lblServicio.Text = String.Format("Servicio: {0}", ServicioNombre);
            foreach (DataRow fila in DtSubserviciosDisponibles.Rows)
                fila["colSeleccion"] = false;
            dgvSubServDisponibles.DataSource = DtSubserviciosDisponibles;
            for (int x = 0; x < dgvSubServDisponibles.Columns.Count; x++)
                dgvSubServDisponibles.Columns[x].Visible = false;

            dgvSubServDisponibles.Columns["subservicio"].Visible = true;
            dgvSubServDisponibles.Columns["servicio"].Visible = true;
            dgvSubServDisponibles.Columns["velocidad"].Visible = true;
            dgvSubServDisponibles.Columns["velocidad_tipo"].Visible = true;
            dgvSubServDisponibles.Columns["importe"].Visible = true;
            dgvSubServDisponibles.Columns["colSeleccion"].Visible = true;
            dgvSubServDisponibles.Columns["subservicio"].HeaderText = "Sub Servicio";
            dgvSubServDisponibles.Columns["servicio"].HeaderText = "Servicio";
            dgvSubServDisponibles.Columns["velocidad"].HeaderText = "Velocidad";
            dgvSubServDisponibles.Columns["velocidad_tipo"].HeaderText = "Tipo de velocidad";
            dgvSubServDisponibles.Columns["importe"].HeaderText = "Importe";
            dgvSubServDisponibles.Columns["colSeleccion"].HeaderText = "Seleccionar";
            dgvSubServDisponibles.Columns["velocidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvSubServDisponibles.Columns["importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvSubServDisponibles.ReadOnly = false;
            dgvSubServDisponibles.Columns["subservicio"].ReadOnly = true;
            dgvSubServDisponibles.Columns["servicio"].ReadOnly = true;
            dgvSubServDisponibles.Columns["velocidad"].ReadOnly = true;
            dgvSubServDisponibles.Columns["velocidad_tipo"].ReadOnly = true;
            dgvSubServDisponibles.Columns["importe"].ReadOnly = true;
            dgvSubServDisponibles.Columns["colSeleccion"].ReadOnly = false;
            AsignarValores();
            lblTotal.Text = String.Format("Total de Registros: {0}", dgvSubServDisponibles.Rows.Count);
        }

        private void AsignarValores()
        {
            if (dgvSubServDisponibles.Rows.Count > 0)
            {
                if (dgvSubServDisponibles.SelectedRows.Count > 0)
                    lblSubServSeleccionado.Text = String.Format("Subservicio seleccionado: {0}", dgvSubServDisponibles.SelectedRows[0].Cells["subservicio"].Value);
                else
                    lblSubServSeleccionado.Text = String.Format("Subservicio seleccionado: {0}", dgvSubServDisponibles.Rows[0].Cells["subservicio"].Value);
            }
        }

        private void GuardarSubservicioAgregado()
        {
            int Dias = DateTime.DaysInMonth(dtpFecha.Value.Year, dtpFecha.Value.Month) - dtpFecha.Value.Day;
            if (dgvSubServDisponibles.SelectedRows.Count > 0)
            {
                foreach (DataRow fila in DtSubserviciosDisponibles.Rows)
                {
                    if (Convert.ToBoolean(fila["colSeleccion"]) == true)
                    {
                        oUsuarioServicio.Guardar_Subservicios(0, IdUsuarioServicio, Convert.ToInt32(fila["id_servicios_sub"]), Convert.ToInt32(fila["id_servicios_velocidad"]), Convert.ToInt32(fila["id_servicio_velocidad_tip"]), Convert.ToInt32(fila["requiere_ip"]), 0, 0, 0, string.Empty, new DateTime(), new DateTime(), (int)Borrados.Estado.Activo);
                        if (dtpFecha.Value.Day > 1)
                            ImporteTotal += (Convert.ToDecimal(fila["importe"]) / 30) * Dias;
                        else
                            ImporteTotal += Convert.ToDecimal(fila["importe"]);
                    }
                }
                oPartes.Id_Servicios = IdServicio;
                oPartes.Id_Usuarios_Servicios = IdUsuarioServicio;
                oPartes.Id_Usuarios = Convert.ToInt32(DtUsuarioServicio.Rows[0]["id_usuarios"]);
                oPartes.Id_Usuarios_Locaciones = Convert.ToInt32(DtUsuarioServicio.Rows[0]["id_usuarios_locaciones"]);
                oPartes.Id_Zonas = Convert.ToInt32(DtUsuarioServicio.Rows[0]["id_zonas"]);
                try
                {
                    oPartes.Id_Partes_Fallas = Convert.ToInt32(oPartesSolicitudes.GetFallasPorTipoServYOp(Convert.ToInt32(DtUsuarioServicio.Rows[0]["id_servicios_tipo"]), Convert.ToInt32(Partes.Partes_Operaciones.PARTE_INTERNO)).Rows[0]["id"]);
                }
                catch
                {
                    oPartes.Id_Partes_Fallas = 0;
                }
                oPartes.Id_Partes_Soluciones = 0;
                oPartes.Id_Tecnico = Personal.Id_Login;
                oPartes.Id_Movil = 0;
                oPartes.Id_Operadores = Personal.Id_Login;
                oPartes.Id_Areas = Personal.Id_Area;
                oPartes.Fecha_Programado = DateTime.Now;
                oPartes.Fecha_Reclamo = DateTime.Now;
                oPartes.Fecha_Realizado = DateTime.Now;
                oPartes.Detalle_Solucion = "";
                oPartes.Detalle_Falla = "PARTE INTERNO";
                oPartes.Id_Partes_Estados = Convert.ToInt32(Partes.Partes_Estados.REALIZADO);
                oPartes.Id_Usuarios_Cuenta_Corriente = 0;
                oPartes.Id = oPartes.Guardar(oPartes, 0);
                oPartes.ParteRealizado(oPartes.Id, oPartes.Fecha_Realizado, oPartes.Id_Partes_Soluciones, oPartes.Id_Partes_Fallas, oPartes.Detalle_Solucion);

                oPartesHistorial.Id_Parte = oPartes.Id;
                oPartesHistorial.Id_Usuarios = oPartes.Id_Usuarios;
                oPartesHistorial.Id_Personal = Personal.Id_Login;
                oPartesHistorial.Fecha_Movimiento = DateTime.Now;
                oPartesHistorial.Id_area = Personal.Id_Area;
                oPartesHistorial.Id_Partes_Estados = oPartes.Id_Partes_Estados;
                oPartesHistorial.Detalles = "PARTE INTERNO";
                oPartesHistorial.GuardarNuevoDetalle(oPartesHistorial);

                if (chkGenerarDeuda.Checked == true)
                {
                    drDatosComprobanteVenta = oComprobante_tipo.GetNumeracion(Convert.ToInt32(Comprobantes_Tipo.Tipo.COMPROBANTE_DEUDA), Puntos_Cobros.Id_Punto);

                    oComprobante.Id_Usuarios = Convert.ToInt32(oPartes.Id_Usuarios);
                    oComprobante.Fecha = DateTime.Today;
                    oComprobante.Punto_Venta = Convert.ToInt32(drDatosComprobanteVenta["numPuntoVenta"]);
                    oComprobante.Id_Comprobantes_Tipo = Convert.ToInt32(Comprobantes_Tipo.Tipo.COMPROBANTE_DEUDA);
                    oComprobante.Numero = Convert.ToInt32(drDatosComprobanteVenta["numComprobante"]);
                    oComprobante.Importe = ImporteTotal;
                    oComprobante.Id_Usuarios_Locaciones = Convert.ToInt32(oPartes.Id_Usuarios_Locaciones);
                    oComprobante.Id = oComprobante.Guardar(oComprobante);

                    oUsuario_ctacte.Id_Usuarios = oPartes.Id_Usuarios;
                    oUsuario_ctacte.Id_Comprobantes = oComprobante.Id;
                    oUsuario_ctacte.Fecha_Movimiento = DateTime.Today;
                    oUsuario_ctacte.Fecha_Desde = dtpFecha.Value;
                    oUsuario_ctacte.Fecha_Hasta = dtpFecha.Value.AddDays(Dias);
                    string muestra;
                    char pad = '0';
                    muestra = "COMPROBANTE DE DEUDA " + Convert.ToInt32(drDatosComprobanteVenta["numPuntoVenta"]).ToString().PadLeft(4, pad) + "-" + oUsuario_ctacte.Id_Comprobantes.ToString().PadLeft(8, pad);
                    oUsuario_ctacte.Descripcion = muestra;
                    oUsuario_ctacte.Importe_Original = oComprobante.Importe;
                    oUsuario_ctacte.Importe_Punitorio = 0;
                    oUsuario_ctacte.Importe_Bonificacion = 0;
                    oUsuario_ctacte.Importe_Final = oComprobante.Importe;
                    oUsuario_ctacte.Importe_Saldo = oComprobante.Importe;
                    oUsuario_ctacte.Id_Usuarios_Locacion = oPartes.Id_Usuarios_Locaciones;
                    oUsuario_ctacte.Numero = oComprobante.Numero.ToString();
                    oUsuario_ctacte.Id_Comprobantes_Tipo = Convert.ToInt32(Comprobantes_Tipo.Tipo.COMPROBANTE_DEUDA);
                    oUsuario_ctacte.Id_Comprobantes_Ref = 0;
                    oUsuario_ctacte.Id_Facturacion = 0;
                    oUsuario_ctacte.Generado_facturacion_mensual = Convert.ToInt32(Usuarios_CtaCte.GENERADO_FACTURACION_MENSUAL.NO);
                    oUsuario_ctacte.Id_Personal = Personal.Id_Login;
                    oUsuario_ctacte.Id_Origen = (int)Usuarios_CtaCte.ORIGEN.OTROS;
                    oUsuario_ctacte.Guardar(oUsuario_ctacte);

                    foreach (DataRow fila in DtSubserviciosDisponibles.Rows)
                    {

                        if (Convert.ToBoolean(fila["colSeleccion"]) == true)
                        {
                            oUsuario_ctactedet.Id_Usuarios_CtaCte = oUsuario_ctacte.Id;
                            oUsuario_ctactedet.Id_Usuarios_Locaciones = oPartes.Id_Usuarios_Locaciones;
                            oUsuario_ctactedet.Id_Zonas = oPartes.Id_Zonas;
                            oUsuario_ctactedet.Id_Servicios = oPartes.Id_Servicios;
                            oUsuario_ctactedet.Id_Tipo = oPartes.Id_Partes_Fallas;
                            oUsuario_ctactedet.Tipo = "S";
                            if (dtpFecha.Value.Day > 1)
                            {
                                oUsuario_ctactedet.Importe_Original = (Convert.ToDecimal(fila["importe"]) / 30) * Dias;
                                oUsuario_ctactedet.Importe_Saldo = (Convert.ToDecimal(fila["importe"]) / 30) * Dias;
                            }
                            else
                            {
                                oUsuario_ctactedet.Importe_Original = Convert.ToDecimal(fila["importe"]);
                                oUsuario_ctactedet.Importe_Saldo = Convert.ToDecimal(fila["importe"]);
                            }
                            oUsuario_ctactedet.Id_Usuarios_Servicios = oPartes.Id_Usuarios_Servicios;
                            oUsuario_ctactedet.Id_Velocidades = Convert.ToInt32(fila["id_servicios_velocidad"]);
                            oUsuario_ctactedet.Id_Velocidades_Tip = Convert.ToInt32(fila["id_servicio_velocidad_tip"]);
                            oUsuario_ctactedet.Requiere_IP = Convert.ToInt32(fila["requiere_ip"]);
                            oUsuario_ctactedet.Cantidad_Periodos = 1;
                            oUsuario_ctactedet.Fecha_Desde = DateTime.Now;
                            oUsuario_ctactedet.Fecha_Hasta = DateTime.Now;
                            oUsuario_ctactedet.Id_bonificacion_Aplicada = 0;
                            oUsuario_ctactedet.Nombre_Bonificacion = String.Empty;
                            oUsuario_ctactedet.Periodo_Ano = oUsuario_ctactedet.Fecha_Desde.Year;
                            oUsuario_ctactedet.Periodo_Mes = oUsuario_ctactedet.Fecha_Desde.Month;
                            oUsuario_ctactedet.Porcentaje_Bonificacion = 0;
                            oUsuario_ctactedet.Guardar(oUsuario_ctactedet);
                        }
                    }
                }
                MessageBox.Show("Sub servicios agregado correctamente.");
                this.DialogResult = DialogResult.OK;
            }

        }

        public frmAgregarSubservicio(int IdUsuarioServicioRecibido, int IdServicioRecibido, string ServicioNombreRecibido, DataTable DtSubServicios)
        {
            IdUsuarioServicio = IdUsuarioServicioRecibido;
            IdServicio = IdServicioRecibido;
            ServicioNombre = ServicioNombreRecibido;
            DtSubserviciosDisponibles = DtSubServicios;
            DtSubserviciosDisponibles.Columns.Add("colSeleccion", typeof(bool));
            InitializeComponent();
        }

        private void btnAgregarSubServ_Click(object sender, EventArgs e)
        {

            if (chkGenerarDeuda.Checked == false)
            {
                DialogResult dialogResult = MessageBox.Show("¿Está seguro de no generar deuda en este momento?", "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                    GuardarSubservicioAgregado();
                else
                    chkGenerarDeuda.Focus();
            }
            else
                GuardarSubservicioAgregado();
        }

        private void frmAgregarSubservicio_Load(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void dgvSubServDisponibles_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            AsignarValores();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void frmAgregarSubservicio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.DialogResult = DialogResult.OK;

        }
    }
}//27112019MAXI CAMPO ID_ORIGEN