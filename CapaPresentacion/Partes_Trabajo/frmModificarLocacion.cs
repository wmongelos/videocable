using CapaNegocios;
using CapaPresentacion.Busquedas;
using CapaPresentacion.Impresiones;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Partes_Trabajo
{
    public partial class frmModificarLocacion : Form
    {
        #region[PROPIEDADES]
        private Thread hilo;
        private delegate void myDel();
        private DataTable dtLocalidades;
        private DataTable dtServiciosUsuario;
        private DataTable dtSolicitudes;
        private Partes oPartes = new Partes();
        private Usuarios_Locaciones oUsuariosLocaciones = new Usuarios_Locaciones();
        private Localidades oLocalidad = new Localidades();
        private Localidades_Calles oLocalidadesCalles = new Localidades_Calles();
        private Usuarios_Servicios oUsuariosServicios = new Usuarios_Servicios();
        private Partes_Solicitudes oSolicitudes = new Partes_Solicitudes();
        private List<Int32> listaIdsPartes = new List<Int32>();
        private int idLocalidadCalle;
        private int idLocalidadCalleE1;
        private int idLocalidadCalleE2;
        private Configuracion oConfig = new Configuracion();
        private int configAgenda;
        private int idLocacionNueva;
        private bool buscarLocacion = false;
        private Usuarios_Locaciones oUsuarioLocacionAnterior = new Usuarios_Locaciones();
        private Partes_Historial oPartesHistorial = new Partes_Historial();
        private DataTable dtUsuarios = new DataTable();
        private int idUsuario;
        private int idLocacion;
        public DataRow drUsuarioSeleccionado;
        public Boolean huboCambios = false;
        private Usuarios oUsuarios = new Usuarios();
        private Partes_Solicitudes oPartesSolicitudes = new Partes_Solicitudes();
        private decimal montoTotalCambio = 0;
        private int idTarifaActual = 0;
        private Servicios_Tarifas oServiciosTarifas = new Servicios_Tarifas();
        DialogResult dialogResult;
        private DataRow drDatosComprobanteVenta = null;
        private int nComprobante = 0;
        private Usuarios_CtaCte oUsuariosCtaCte = new Usuarios_CtaCte();
        private Usuarios_CtaCte_Det oUsuariosCtaCteDet = new Usuarios_CtaCte_Det();
        private Comprobantes oComprobantes = new Comprobantes();
        private Comprobantes_Tipo oComprobantesTipo = new Comprobantes_Tipo();
        private DataTable dtMontosSolicitud;
        private bool trabajaPorZona;
        #endregion

        #region[MÉTODOS]
        private void SetearCabeceraUsuario()
        {
            DataView v1 = dtUsuarios.DefaultView;
            DataTable dt = new DataTable();
            if (idLocacion > 0)
                v1.RowFilter = string.Format("id_usuarios_locaciones = {0} ", idLocacion);
            else
                v1.RowFilter = string.Format("id = {0} ", idUsuario);

            dt = v1.ToTable();
            drUsuarioSeleccionado = dt.Rows[0];
            LBApellido.Text = drUsuarioSeleccionado["apellido"].ToString().Trim() + " , " + (drUsuarioSeleccionado["nombre"].ToString()).ToUpperInvariant() + " [" + drUsuarioSeleccionado["codigo"].ToString() + "]";
            LBNumero_documento.Text = "Documento : (" + drUsuarioSeleccionado["tipo_doc"].ToString() + ") Nro " + drUsuarioSeleccionado["numero_documento"].ToString();
            lbcuit.Text = "C. Iva : (" + drUsuarioSeleccionado["condicion_iva"].ToString() + ") Nro " + drUsuarioSeleccionado["cuit"].ToString();
            lblLocacion.Text = String.Format("Locación: {0}, {1} {2} ", drUsuarioSeleccionado["localidad"], drUsuarioSeleccionado["calle"], drUsuarioSeleccionado["altura"]);
            lbcorreo.Text = "Mail: " + drUsuarioSeleccionado["Correo_electronico"].ToString();
        }

        private void comenzarCarga()
        {
            pgCircular.Start();
            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.IsBackground = true;
            hilo.Start();
        }

        private void cargarDatos()
        {
            try
            {
                if (dtLocalidades.Rows.Count == 0)
                    dtLocalidades = oLocalidad.Listar_con_calles();
                if (idLocacion > 0)
                {
                    oUsuariosLocaciones = oUsuariosLocaciones.GetLocacion(idLocacion);
                    oUsuarios.Codigo = Usuarios.CurrentUsuario.Codigo;
                    oUsuarios.Usuario = "";
                    oUsuarios.Calle = "";
                    oUsuarios.Altura = 0;
                    oUsuarios.Apellido = "";
                    oUsuarios.Nombre = "";
                    oUsuarios.Depto = "";
                    oUsuarios.CUIT = 0;
                    oUsuarios.Numero_Documento = 0;
                    dtUsuarios = oUsuarios.getDatos_ultimo();
                    dtServiciosUsuario = oUsuariosServicios.Listar_Servicios_Activos(oUsuariosLocaciones.Id);

                }

                myDel MD = new myDel(asignarDatos);
                this.Invoke(MD, new object[] { });
                pgCircular.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Informacion" + ex.Message);
            }
        }

        private void asignarDatos()
        {
            if (oUsuariosLocaciones.Id > 0)
            {
                dtServiciosUsuario.Columns.Add("Trasladar", typeof(bool));


                dtServiciosUsuario.Columns.Add("Cobrar", typeof(bool));
                foreach (DataRow fila in dtServiciosUsuario.Rows)
                    fila["cobrar"] = true;
                dgvServicios.DataSource = dtServiciosUsuario;
                for (int x = 0; x < dgvServicios.Columns.Count; x++)
                    dgvServicios.Columns[x].Visible = false;

                dgvServicios.Columns["servicio"].Visible = true;
                dgvServicios.Columns["tipo_servicio"].Visible = true;
                dgvServicios.Columns["trasladar"].Visible = true;
                dgvServicios.Columns["cobrar"].Visible = true;
                dgvServicios.Columns["servicio"].HeaderText = "Servicio";
                dgvServicios.Columns["tipo_servicio"].HeaderText = "Tipo de servicio";
                dgvServicios.Columns["trasladar"].Width = 70;
                dgvServicios.Columns["cobrar"].Width = 70;
                SetearCabeceraUsuario();
                lblLocacionActual.Text = FormatearTextoLocacion("Locación de origen", oUsuariosLocaciones.Calle, oUsuariosLocaciones.Altura.ToString(), oUsuariosLocaciones.Piso, oUsuariosLocaciones.Depto, String.Empty, oUsuariosLocaciones.Localidad);
                txtCPServicio.Text = oUsuariosLocaciones.Codigo_Postal.ToString();
            }
            else
                txtCPServicio.Text = dtLocalidades.Rows[0]["codigo_postal"].ToString();

            lblLocacionNueva.Text = "Locación de destino:";
            lblTotal.Text = String.Format("Total de Registros: {0}", dtServiciosUsuario.Rows.Count);

            cboLocalidades.DataSource = dtLocalidades;
            cboLocalidades.DisplayMember = "Nombre";
            cboLocalidades.ValueMember = "Id";
        }
        private int ControlarTxtOpcional()
        {
            int control = 0;

            if (txtEntreCalle1.Text.Length == 0)
            {
                control = 1;
                txtEntreCalle1.Focus();
            }

            if (txtEntreCalle2.Text.Length == 0)
            {
                control = 1;
                txtEntreCalle2.Focus();

            }

            if (txtParcelaServicio.Text.Length == 0)
            {
                control = 1;
                txtParcelaServicio.Focus();

            }

            if (txtPisoServicio.Text.Length == 0)
            {
                control = 1;
                txtPisoServicio.Focus();

            }

            if (txtDeptoServicio.Text.Length == 0)
            {
                control = 1;
                txtDeptoServicio.Focus();

            }

            return control;
        }
        private int ControlarTxt()
        {
            int control = 0;

            if (txtCalle.Text.Length == 0)
            {
                control = 1;
                txtCalle.Focus();
            }
            if (txtCPServicio.Text.Length == 0)
            {
                control = 1;
                cboLocalidades.Focus();
            }


            if (spAltura.Value == 0)
            {
                control = 1;
                spAltura.Focus();
            }

            return control;
        }

        private int ControlarLocalidadYcalles()
        {
            int control = 0;

            int valor_localidad = Convert.ToInt32(cboLocalidades.SelectedValue);

            if (idLocalidadCalle != valor_localidad)
            {
                control = 1;
                MessageBox.Show("La calle no se corresponde con la localidad seleccionada.");
            }
            return control;
        }

        public void GuardarRegistro()
        {
            if (trabajaPorZona)
            {
                if (ServiciosNoDisponiblesEnNuevaLocalidad(out string mensajeDeError))
                {
                    MessageBox.Show(mensajeDeError, "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            if (ControlarTxt() == 0)
            {
                if (ControlarLocalidadYcalles() == 0)
                {
                    if (ControlarTxtOpcional() < 2)
                    {
                        if (MessageBox.Show("Hay campos sin llenar ¿Desea continuar?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            if ((buscarLocacion == false && oUsuariosLocaciones.VerificarExistenciaLocacion(Convert.ToInt32(cboLocalidades.SelectedValue), Convert.ToInt32(txtCalle.Tag), Convert.ToInt32(spAltura.Value), txtPisoServicio.Text, txtDeptoServicio.Text, txtEntreCalle1.Text, txtEntreCalle2.Text, Usuarios_Locaciones.CONTEMPLAR_NOMBRE_LIMITES_CALLES.SI).Rows.Count == 0) || buscarLocacion == true)
                            {
                                if (CalcularMontoFinal())
                                {
                                    if (montoTotalCambio > 0)
                                        dialogResult = MessageBox.Show(String.Format("Se generará un comprobante con un monto de ${0}. ¿Desea continuar?", montoTotalCambio), "", MessageBoxButtons.YesNo);
                                    if (montoTotalCambio == 0 || dialogResult == DialogResult.Yes)
                                    {

                                        int locacion_antigua = idLocacion;
                                        if (buscarLocacion == false)
                                        {
                                            oUsuariosLocaciones.Id = 0;
                                            oUsuariosLocaciones.Id_Localidades = Convert.ToInt32(cboLocalidades.SelectedValue);
                                            oUsuariosLocaciones.Id_Provincias = Convert.ToInt32(oLocalidad.Listar_con_calles().Select("Id=" + cboLocalidades.SelectedValue + "")[0]["Id_Provincias"].ToString());
                                            oUsuariosLocaciones.Id_Calle = Convert.ToInt32(txtCalle.Tag);
                                            oUsuariosLocaciones.Calle = txtCalle.Text.ToString();
                                            oUsuariosLocaciones.Altura = Convert.ToInt32(spAltura.Value);
                                            oUsuariosLocaciones.Piso = txtPisoServicio.Text.ToString();
                                            oUsuariosLocaciones.Depto = txtDeptoServicio.Text.ToString();
                                            oUsuariosLocaciones.Codigo_Postal = txtCPServicio.Text.ToString();
                                            oUsuariosLocaciones.id_manzana = 0;
                                            oUsuariosLocaciones.Parcela = txtParcelaServicio.Text.ToString();
                                            oUsuariosLocaciones.Id_Calle_Entre_1 = 0;
                                            oUsuariosLocaciones.Entre_Calle_1 = txtEntreCalle1.Text;
                                            oUsuariosLocaciones.Id_Calle_Entre_2 = 0;
                                            oUsuariosLocaciones.Entre_Calle_2 = txtEntreCalle2.Text;
                                            oUsuariosLocaciones.Telefono_1 = 0;
                                            oUsuariosLocaciones.Observacion = "";
                                            oUsuariosLocaciones.Activo = Convert.ToInt32(Usuarios_Locaciones.Locacion_Estados.PENDIENTE_DE_ACTIVACION);
                                            oUsuariosLocaciones.Tipo = "SV";
                                            oUsuariosLocaciones.Prefijo_1 = 0;
                                            oUsuariosLocaciones.Telefono_1 = 0;
                                            oUsuariosLocaciones.Prefijo_2 = 0;
                                            oUsuariosLocaciones.Telefono_2 = 0;
                                            idLocacionNueva = oUsuariosLocaciones.Guardar(oUsuariosLocaciones.Id_Usuarios, oUsuariosLocaciones);
                                        }
                                        else
                                            idLocacionNueva = oUsuariosLocaciones.Id;

                                        //generar partes de acuerdo a configuración
                                        DataTable dtPartesCambioDomicilio = oPartes.Get_Estructura_Partes();
                                        DataTable dtPartesGenerados = new DataTable();
                                        foreach (DataGridViewRow fila_servicio_activo in dgvServicios.Rows)
                                        {

                                            if (fila_servicio_activo.Cells["Trasladar"].Value != DBNull.Value && (Convert.ToInt32(fila_servicio_activo.Cells["Trasladar"].Value) == 1))
                                            {
                                                DataRow drParte = dtPartesCambioDomicilio.NewRow();

                                                DataTable dt_partes_fallas = new DataTable();
                                                dt_partes_fallas = oSolicitudes.GetFallasPorTipoServYOp(Convert.ToInt32(fila_servicio_activo.Cells["Id_Servicios_Tipo"].Value), Convert.ToInt32(Partes.Partes_Operaciones.CAMBIO_DE_DOMICILIO));
                                                drParte["Id"] = 0;
                                                drParte["Id_Usuarios"] = oUsuariosLocaciones.Id_Usuarios;
                                                drParte["Id_Servicios"] = Convert.ToInt32(fila_servicio_activo.Cells["id_servicios"].Value);
                                                drParte["Id_Usuarios_Servicios"] = Convert.ToInt32(fila_servicio_activo.Cells["id"].Value);
                                                drParte["Id_Servicios_Tipos"] = Convert.ToInt32(fila_servicio_activo.Cells["id_servicios_tipo"].Value);
                                                drParte["Id_Servicios_Grupos"] = Convert.ToInt32(fila_servicio_activo.Cells["id_servicios_grupo"].Value);
                                                drParte["Id_Usuarios_Locaciones"] = idLocacionNueva;
                                                drParte["Id_Zonas"] = Convert.ToInt32(fila_servicio_activo.Cells["id_Zonas"].Value);
                                                try
                                                {
                                                    drParte["Id_Partes_Fallas"] = Convert.ToInt32(dt_partes_fallas.Rows[0]["id"]);
                                                }
                                                catch { drParte["Id_Partes_Fallas"] = 0; }
                                                drParte["Id_Partes_Soluciones"] = 0;
                                                drParte["Id_Movil"] = 0;
                                                drParte["Fecha_Programado"] = DateTime.Now;

                                                drParte["Id_Partes_Estados"] = Convert.ToInt32(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_TECNICO);
                                                drParte["Id_Tecnico"] = 0;


                                                drParte["Id_Operadores"] = Personal.Id_Login;
                                                drParte["Id_Areas"] = Personal.Id_Area;
                                                drParte["Fecha_Reclamo"] = DateTime.Today.Date;

                                                try
                                                {
                                                    drParte["Detalle_Falla"] = dt_partes_fallas.Rows[0]["nombre"].ToString();
                                                }
                                                catch { drParte["Detalle_Falla"] = ""; }

                                                drParte["Detalle_Solucion"] = "";
                                                drParte["CorteAutomatico"] = Convert.ToInt32(fila_servicio_activo.Cells["corteautomatico"].Value);
                                                drParte["Id_Locacion_Anterior"] = this.idLocacion;
                                                if (chkTraspasoCtaCte.Checked == true && chkTraspasoPartes.Checked == true)
                                                    drParte["traspasa"] = (int)Partes.Traspaso.TODO;
                                                else
                                                {
                                                    if (chkTraspasoCtaCte.Checked == true && chkTraspasoPartes.Checked == false)
                                                        drParte["traspasa"] = (int)Partes.Traspaso.CUENTA_CORRIENTE;
                                                    if (chkTraspasoCtaCte.Checked == false && chkTraspasoPartes.Checked == true)
                                                        drParte["traspasa"] = (int)Partes.Traspaso.PARTES;
                                                    if (chkTraspasoCtaCte.Checked == false && chkTraspasoPartes.Checked == false)
                                                        drParte["traspasa"] = (int)Partes.Traspaso.NADA;
                                                }

                                                dtPartesCambioDomicilio.Rows.Add(drParte);
                                            }
                                        }

                                        //generar historial de partes
                                        if (dtPartesCambioDomicilio.Rows.Count > 0)
                                        {
                                            dtPartesGenerados = oPartes.AgruparPartesTrabajo(dtPartesCambioDomicilio);

                                            foreach (DataRow item in dtPartesGenerados.Rows)
                                            {
                                                listaIdsPartes.Add(Convert.ToInt32(item["id"]));
                                                oPartes.SetearEstadoParte(Convert.ToInt32(item["id"]), 0, configAgenda == Convert.ToInt32(Agenda_Encabezado.Uso_agenda.TRABAJA_CON_AGENDA) ? Convert.ToInt32(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_TECNICO) : 0, DateTime.Now, 0, 0, string.Empty);
                                            }
                                            if (dtPartesGenerados.Rows.Count > 0)
                                                oPartes.GenerarHistorialPartes(dtPartesGenerados);
                                        }

                                        if (montoTotalCambio > 0)
                                        {
                                            drDatosComprobanteVenta = oComprobantesTipo.GetNumeracion(Convert.ToInt32(Comprobantes_Tipo.Tipo.COMPROBANTE_DEUDA), Puntos_Cobros.Id_Punto);
                                            nComprobante = Convert.ToInt32(drDatosComprobanteVenta["numComprobante"]);

                                            if (nComprobante > 0)
                                                oComprobantesTipo.SetNumeracion(Convert.ToInt32(drDatosComprobanteVenta["idPuntoVenta"]), Convert.ToInt32(Comprobantes_Tipo.Tipo.COMPROBANTE_DEUDA), nComprobante);

                                            oComprobantes.Id_Usuarios = idUsuario;
                                            oComprobantes.Fecha = DateTime.Today;
                                            oComprobantes.Punto_Venta = Convert.ToInt32(drDatosComprobanteVenta["numPuntoVenta"]);
                                            oComprobantes.Id_Comprobantes_Tipo = Convert.ToInt32(Comprobantes_Tipo.Tipo.COMPROBANTE_DEUDA);
                                            oComprobantes.Numero = nComprobante;
                                            oComprobantes.Importe = 0;


                                            oComprobantes.Importe = montoTotalCambio;

                                            oComprobantes.Id_Usuarios_Locaciones = locacion_antigua;
                                            oComprobantes.Id_Personal = Personal.Id_Login;
                                            oComprobantes.Id = oComprobantes.Guardar(oComprobantes);

                                            oUsuariosCtaCte.Id_Usuarios = oComprobantes.Id_Usuarios;
                                            oUsuariosCtaCte.Id_Comprobantes = oComprobantes.Id;
                                            oUsuariosCtaCte.Fecha_Movimiento = DateTime.Today;
                                            oUsuariosCtaCte.Fecha_Desde = DateTime.Now;
                                            oUsuariosCtaCte.Fecha_Hasta = DateTime.Now;
                                            string muestra;
                                            char pad = '0';
                                            muestra = "COMPROBANTE DE DEUDA " + Convert.ToInt32(drDatosComprobanteVenta["numPuntoVenta"]).ToString().PadLeft(4, pad) + "-" + oUsuariosCtaCte.Id_Comprobantes.ToString().PadLeft(8, pad);
                                            oUsuariosCtaCte.Descripcion = muestra;
                                            oUsuariosCtaCte.Importe_Original = 0;
                                            oUsuariosCtaCte.Importe_Original = oComprobantes.Importe;
                                            oUsuariosCtaCte.Importe_Punitorio = 0;
                                            oUsuariosCtaCte.Importe_Bonificacion = oUsuariosCtaCte.Importe_Original - oComprobantes.Importe;
                                            oUsuariosCtaCte.Importe_Final = oComprobantes.Importe;
                                            oUsuariosCtaCte.Importe_Saldo = oUsuariosCtaCte.Importe_Final;
                                            oUsuariosCtaCte.Id_Usuarios_Locacion = oComprobantes.Id_Usuarios_Locaciones;
                                            oUsuariosCtaCte.Numero = oComprobantes.Numero.ToString();
                                            oUsuariosCtaCte.Id_Comprobantes_Tipo = Convert.ToInt32(Comprobantes_Tipo.Tipo.COMPROBANTE_DEUDA);
                                            oUsuariosCtaCte.Id_Comprobantes_Ref = 0;
                                            oUsuariosCtaCte.Id_Facturacion = 0;
                                            oUsuariosCtaCte.Generado_facturacion_mensual = Convert.ToInt32(Usuarios_CtaCte.GENERADO_FACTURACION_MENSUAL.NO);
                                            oUsuariosCtaCte.Id_Personal = Personal.Id_Login;
                                            oUsuariosCtaCte.Id_Origen = (int)Usuarios_CtaCte.ORIGEN.OTROS;

                                            oUsuariosCtaCte.Guardar(oUsuariosCtaCte);
                                            foreach (DataRow servicio in dtServiciosUsuario.Rows)
                                            {
                                                if (servicio["trasladar"] != DBNull.Value && Convert.ToBoolean(servicio["trasladar"]) && servicio["cobrar"] != DBNull.Value && Convert.ToBoolean(servicio["cobrar"]))
                                                {
                                                    oUsuariosCtaCteDet.Id_Usuarios_CtaCte = oUsuariosCtaCte.Id;
                                                    oUsuariosCtaCteDet.Id_Usuarios_Locaciones = oUsuariosCtaCte.Id_Usuarios_Locacion;
                                                    oUsuariosCtaCteDet.Id_Zonas = Convert.ToInt32(servicio["id_tipo_facturacion"]);
                                                    oUsuariosCtaCteDet.Id_Servicios = Convert.ToInt32(servicio["id_servicios"]);
                                                    oUsuariosCtaCteDet.Id_Tipo = Convert.ToInt32(dtMontosSolicitud.Select(String.Format("idservicio='{0}'", oUsuariosCtaCteDet.Id_Servicios))[0]["idsolicitud"]);
                                                    oUsuariosCtaCteDet.Tipo = "P";
                                                    oUsuariosCtaCteDet.Importe_Original = Convert.ToDecimal(dtMontosSolicitud.Select(String.Format("idservicio='{0}'", oUsuariosCtaCteDet.Id_Servicios))[0]["monto"]);
                                                    oUsuariosCtaCteDet.Importe_Punitorio = 0;
                                                    oUsuariosCtaCteDet.Importe_Saldo = oUsuariosCtaCteDet.Importe_Original;
                                                    oUsuariosCtaCteDet.Importe_Final = oUsuariosCtaCteDet.Importe_Original;
                                                    oUsuariosCtaCteDet.Importe_Bonificacion = 0;
                                                    oUsuariosCtaCteDet.Id_Usuarios_Servicios = Convert.ToInt32(servicio["id"]);
                                                    oUsuariosCtaCteDet.Id_Velocidades_Tip = 0;
                                                    oUsuariosCtaCteDet.Id_Velocidades = 0;
                                                    oUsuariosCtaCteDet.Requiere_IP = 0;
                                                    oUsuariosCtaCteDet.Cantidad_Periodos = 1;
                                                    oUsuariosCtaCteDet.Id_Usuarios_Servicios_sub = 0;
                                                    oUsuariosCtaCteDet.Id_bonificacion_Aplicada = 0;
                                                    oUsuariosCtaCteDet.Porcentaje_Bonificacion = 0;
                                                    oUsuariosCtaCteDet.Nombre_Bonificacion = String.Empty;
                                                    oUsuariosCtaCteDet.Fecha_Desde = DateTime.Now;
                                                    oUsuariosCtaCteDet.Fecha_Hasta = DateTime.Now;
                                                    oUsuariosCtaCteDet.Periodo_Mes = DateTime.Now.Month;
                                                    oUsuariosCtaCteDet.Periodo_Ano = DateTime.Now.Year;
                                                    oUsuariosCtaCteDet.Guardar(oUsuariosCtaCteDet);
                                                }
                                            }
                                        }
                                        MessageBox.Show("Partes de cambio de domicilio generados correctamente.");
                                        if (configAgenda == Convert.ToInt32(Agenda_Encabezado.Uso_agenda.TRABAJA_CON_AGENDA))
                                        {
                                            dialogResult = MessageBox.Show("¿Desea acceder a la Agenda de trabajo para asignar un técnico al parte?", "", MessageBoxButtons.YesNo);
                                            if (dialogResult == DialogResult.Yes)
                                            {
                                                frmMain frmmain = frmMain.Instance();
                                                frmAgenda agenda = frmAgenda.GetInstancia();
                                                agenda.Id_recibido(listaIdsPartes);
                                                agenda.Mostrar();
                                            }
                                            else
                                            {
                                                this.Close();
                                            }

                                        }
                                        else
                                        {
                                            Impresion oImpresiones = new Impresion();
                                            foreach (DataRow item in dtPartesGenerados.Rows)
                                                oImpresiones.ImprimirParte(Convert.ToInt32(item["id"]));
                                            this.DialogResult = DialogResult.OK;
                                            this.Close();
                                        }
                                    }
                                    else
                                        MessageBox.Show("La locación que está intentando asignar ya se encuentra en el sistema.");
                                }
                                else
                                    MessageBox.Show("No ha seleccionado servicios. Debe seleccionar algún servicio para realizar el cambio de domicilio.");
                            }
                        }
                    }
                    else
                        MessageBox.Show("Hay campos sin completar.");
                }
            }
            else
                MessageBox.Show("Hay campos en blanco.");
        }

        public void Actualizar_Label_LocNueva()
        {
            lblLocacionNueva.Text = "Locación de destino:";
            lblLocacionNueva.Text += " Calle: " + txtCalle.Text + " Nro.: " + spAltura.Value + " Piso: " + txtPisoServicio.Text + " Depto.: " + txtDeptoServicio.Text + ", " + cboLocalidades.Text;
        }

        private void BuscarCalles()
        {
            frmBusquedaCalles frmBuscar_Calles = new frmBusquedaCalles();


            frmBuscar_Calles.lista_id_localidades.Add(Convert.ToInt32(cboLocalidades.SelectedValue));

            frmPopUp frmpopup = new frmPopUp();
            frmpopup.Formulario = frmBuscar_Calles;
            frmpopup.Maximizar = false;

            frmpopup.ShowDialog();

            if (frmpopup.DialogResult == DialogResult.OK)
            {


                txtCalle.Text = "";
                txtCalle.Text = frmBuscar_Calles.oCalles.Nombre;
                txtCalle.Tag = frmBuscar_Calles.oCalles.Id;
                idLocalidadCalle = frmBuscar_Calles.oCalles.Id_Localidades;
                spAltura.Minimum = frmBuscar_Calles.oCalles.Altura_Desde;
                spAltura.Maximum = frmBuscar_Calles.oCalles.Altura_Hasta;

                spAltura.Value = spAltura.Minimum;

            }
        }

        private void BuscarCallesEntre(textboxAdv txtbox)
        {
            frmBusquedaCalles frmBuscar_Calles = new frmBusquedaCalles();


            frmBuscar_Calles.lista_id_localidades.Add(Convert.ToInt32(cboLocalidades.SelectedValue));


            frmPopUp frmpopup = new frmPopUp();
            frmpopup.Formulario = frmBuscar_Calles;
            frmpopup.Maximizar = false;

            frmpopup.ShowDialog();

            if (frmpopup.DialogResult == DialogResult.OK)
            {
                txtbox.Text = frmBuscar_Calles.oCalles.Nombre;
                txtbox.Tag = frmBuscar_Calles.oCalles.Id;
                if (txtbox.Name == "txtEntreCalle1")
                    idLocalidadCalleE1 = frmBuscar_Calles.oCalles.Id_Localidades;
                else
                    idLocalidadCalleE2 = frmBuscar_Calles.oCalles.Id_Localidades;
            }
        }

        private void ActivarControlesLocacion(bool state)
        {
            cboLocalidades.Enabled = state;
            spAltura.Enabled = state;
            btnBuscarcalle.Enabled = state;
            txtParcelaServicio.Enabled = state;
            txtPisoServicio.Enabled = state;
            txtDeptoServicio.Enabled = state;
            txtEntreCalle1.Enabled = state;
            txtEntreCalle2.Enabled = state;
        }

        private void LimpiarDatosControles()
        {
            cboLocalidades.SelectedValue = oUsuariosLocaciones.Id_Localidades;
            txtCPServicio.Text = "";
            txtCalle.Text = "";
            txtCalle.Tag = "";
            idLocalidadCalle = 0;
            spAltura.Value = spAltura.Minimum;
            txtParcelaServicio.Text = "";
            txtPisoServicio.Text = "";
            txtDeptoServicio.Text = "";

            txtEntreCalle1.Text = "";
            txtEntreCalle2.Text = "";
            txtEntreCalle1.Tag = "";
            txtEntreCalle2.Tag = "";
            idLocalidadCalleE1 = 0;
            idLocalidadCalleE2 = 0;
        }

        private void CargarDatosLocacion()
        {
            frmBusquedaUsuarios frmUsuarioBusqueda = new frmBusquedaUsuarios(1, Usuarios.CurrentUsuario.Codigo.ToString(), "");
            frmPopUp frmpopup = new frmPopUp();
            frmpopup.Maximizar = false;
            frmpopup.Formulario = frmUsuarioBusqueda;
            frmpopup.ShowDialog();

            if (frmUsuarioBusqueda.DialogResult == DialogResult.OK)
            {
                if (Convert.ToInt32(frmUsuarioBusqueda.usuario_e["id"]) == idUsuario)
                {
                    idLocacionNueva = Convert.ToInt32(frmUsuarioBusqueda.usuario_e["id_usuarios_locaciones"]);
                    if (idLocacionNueva != oUsuariosLocaciones.Id)
                    {
                        btnGuardarLocacion.Enabled = true;
                        oUsuarioLocacionAnterior = oUsuariosLocaciones;
                        oUsuariosLocaciones = oUsuariosLocaciones.GetLocacion(idLocacionNueva);
                        cboLocalidades.SelectedValue = oUsuariosLocaciones.Id_Localidades;
                        txtCPServicio.Text = oUsuariosLocaciones.Codigo_Postal;
                        txtCalle.Text = oUsuariosLocaciones.Calle;
                        txtCalle.Tag = oUsuariosLocaciones.Id_Calle;
                        idLocalidadCalle = oUsuariosLocaciones.Id_Localidades;
                        txtEntreCalle1.Text = oUsuariosLocaciones.Entre_Calle_1;
                        txtEntreCalle1.Tag = oUsuariosLocaciones.Id_Calle_Entre_1;
                        idLocalidadCalleE1 = oUsuariosLocaciones.Id_Localidades;
                        txtEntreCalle2.Text = oUsuariosLocaciones.Entre_Calle_2;
                        txtEntreCalle2.Tag = oUsuariosLocaciones.Id_Calle_Entre_2;
                        idLocalidadCalleE2 = oUsuariosLocaciones.Id_Localidades;
                        spAltura.Minimum = oUsuariosLocaciones.Altura_desde;
                        spAltura.Maximum = oUsuariosLocaciones.Altura_hasta;
                        try
                        {
                            spAltura.Value = oUsuariosLocaciones.Altura;
                        }
                        catch (Exception)
                        {

                            spAltura.Value = spAltura.Minimum;
                        }

                        txtPisoServicio.Text = oUsuariosLocaciones.Piso;
                        txtDeptoServicio.Text = oUsuariosLocaciones.Depto;
                        txtParcelaServicio.Text = oUsuariosLocaciones.Parcela;
                      
                    }
                    else
                    {
                        MessageBox.Show("La locación de destino debe ser distinta a la locación de origen.");
                        btnGuardarLocacion.Enabled = false;
                    }
                }
                else
                    MessageBox.Show("La locación seleccionada no se corresponde con el usuario sobre el que está trabajando.");
            }
        }

        private string FormatearTextoLocacion(string textoInicial, string calle, string altura, string piso, string depto, string parcela, string localidad)
        {
            string textoLocacion = String.Empty;
            if (textoInicial != String.Empty)
                textoLocacion = String.Format("{0}: ", textoInicial);
            else
                textoLocacion = String.Format("Locación:");

            if (calle != String.Empty)
                textoLocacion += String.Format("Calle {0}, ", calle);

            if (piso != String.Empty)
                textoLocacion += String.Format("Piso {0}, ", piso);

            if (depto != String.Empty)
                textoLocacion += String.Format("Depto {0}, ", depto);

            if (parcela != String.Empty)
                textoLocacion += String.Format("Parcela {0}, ", parcela);

            if (localidad != String.Empty)
                textoLocacion += String.Format("Localidad {0}", localidad);
            return textoLocacion;
        }

        private bool CalcularMontoFinal()
        {
            bool serviciosSeleccionados = false;
            decimal montoIndividual = 0;
            int idSolicitud = 0;
            DataRow drDatosSolicitud;
            montoTotalCambio = 0;
            if (dtServiciosUsuario.Rows.Count > 0)
            {
                dtMontosSolicitud.Clear();
                foreach (DataRow fila in dtServiciosUsuario.Rows)
                {
                    if (fila["trasladar"] != DBNull.Value && Convert.ToBoolean(fila["trasladar"]))
                    {
                        montoIndividual = 0;
                        idSolicitud = 0;
                        serviciosSeleccionados = true;
                        try
                        {
                            drDatosSolicitud = oPartesSolicitudes.ListarServicioTipo(Convert.ToInt32(fila["id_servicios_tipo"]), idTarifaActual, Convert.ToInt32(fila["id_servicios"]), "P", Convert.ToInt32(fila["id_tipo_facturacion"])).Select(String.Format("id_partes_operaciones={0}", Convert.ToInt32(Partes.Partes_Operaciones.CAMBIO_DE_DOMICILIO)))[0];

                            montoIndividual = Convert.ToDecimal(drDatosSolicitud["importe"]);
                            idSolicitud = Convert.ToInt32(drDatosSolicitud["id"]);

                        }
                        catch
                        {
                            montoIndividual = 0;
                        }
                        if (fila["cobrar"] != DBNull.Value && Convert.ToBoolean(fila["cobrar"]))
                            montoTotalCambio += montoIndividual;
                        dtMontosSolicitud.Rows.Add(fila["id_servicios"], idSolicitud, montoIndividual.ToString());
                    }
                }
            }
            return serviciosSeleccionados;
        }

        private bool ServiciosNoDisponiblesEnNuevaLocalidad(out string mensajeDeError)
        {
            int idLocacalidadSeleccionada = Convert.ToInt32(cboLocalidades.SelectedValue);
            int idZonaNueva = 0;
            DataTable dtZonaLocalidad = new Localidades().ListarLocalidad_Zona(idLocacalidadSeleccionada);
            if (dtZonaLocalidad.Rows.Count > 0)
                idZonaNueva = Convert.ToInt32(new Localidades().ListarLocalidad_Zona(idLocacalidadSeleccionada).Rows[0]["Id_zona"]);

            List<int> serviciosPosibles = new Tipo_Facturacion()
                .Listar(idZonaNueva, soloServicios: true)
                .AsEnumerable()
                .Select(x => x.Field<int>("id_servicios"))
                .ToList();

            List<int> serviciosSeleccionados = new List<int>();
            StringBuilder sb = new StringBuilder("Advertencia: Servicios no disponibles en la nueva localidad seleccionada\n");
            bool serviciosNoDisponible = false;
            foreach (DataGridViewRow fila_servicio_activo in dgvServicios.Rows)
            {
                if (fila_servicio_activo.Cells["Trasladar"].Value != DBNull.Value && (Convert.ToInt32(fila_servicio_activo.Cells["Trasladar"].Value) == 1))
                {
                    int servicioSelec = Convert.ToInt32(fila_servicio_activo.Cells["id_servicios"].Value);
                    serviciosSeleccionados.Add(servicioSelec);
                    if (!serviciosPosibles.Contains(servicioSelec))
                    {
                        sb.Append($"{fila_servicio_activo.Cells["servicio"].Value}\n");
                        serviciosNoDisponible = true;
                    }
                }
            }
            mensajeDeError = sb.ToString();

            return serviciosNoDisponible;
        }

        #endregion

        public frmModificarLocacion(int idUsuario, int idLocacion)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;
            this.idLocacion = idLocacion;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmModificarLocacion_Load(object sender, EventArgs e)
        {
            dtLocalidades = new DataTable();
            dtServiciosUsuario = new DataTable();
            dtSolicitudes = new DataTable();
            dtUsuarios = new DataTable();
            dtMontosSolicitud = new DataTable();
            dtMontosSolicitud.Columns.Add("idServicio", typeof(string));
            dtMontosSolicitud.Columns.Add("idSolicitud", typeof(string));
            dtMontosSolicitud.Columns.Add("monto", typeof(string));
            ActivarControlesLocacion(false);
            idTarifaActual = Convert.ToInt32(oServiciosTarifas.TraerDatosTarifaActual().Rows[0]["id"]);
            configAgenda = oConfig.GetValor_N("Agenda_Trabajo");
            trabajaPorZona = oConfig.GetValor_N("Id_Tipo_Facturacion") == Convert.ToInt32(Tipo_Facturacion.Id_Tipo_Facturacion.POR_ZONAS);
            comenzarCarga();
            this.Focus();
        }

        private void btnBuscarcalle_Click(object sender, EventArgs e)
        {
            BuscarCalles();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarRegistro();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void CargaCodigoPostal()
        {
            try
            {
                txtCPServicio.Text = dtLocalidades.Select("id=" + cboLocalidades.SelectedValue)[0]["codigo_postal"].ToString();
            }
            catch
            { }
        }
        private void cboLocalidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargaCodigoPostal();
        }

        private void txtCalle_TextChanged(object sender, EventArgs e)
        {
            lblLocacionNueva.Text = FormatearTextoLocacion("Locación de destino", txtCalle.Text, spAltura.Value.ToString(), txtPisoServicio.Text, txtDeptoServicio.Text, String.Empty, cboLocalidades.Text);
        }

        private void spinner1_ValueChanged(object sender, EventArgs e)
        {
            lblLocacionNueva.Text = FormatearTextoLocacion("Locación de destino", txtCalle.Text, spAltura.Value.ToString(), txtPisoServicio.Text, txtDeptoServicio.Text, String.Empty, cboLocalidades.Text);
        }

        private void txtPisoServicio_TextChanged(object sender, EventArgs e)
        {
            lblLocacionNueva.Text = FormatearTextoLocacion("Locación de destino", txtCalle.Text, spAltura.Value.ToString(), txtPisoServicio.Text, txtDeptoServicio.Text, String.Empty, cboLocalidades.Text);
        }

        private void txtDeptoServicio_TextChanged(object sender, EventArgs e)
        {
            lblLocacionNueva.Text = FormatearTextoLocacion("Locación de destino", txtCalle.Text, spAltura.Value.ToString(), txtPisoServicio.Text, txtDeptoServicio.Text, String.Empty, cboLocalidades.Text);
        }

        private void txtManzServicio_TextChanged(object sender, EventArgs e)
        {
            Actualizar_Label_LocNueva();
        }

        private void btnGuardarLocacion_Click(object sender, EventArgs e)
        {
            GuardarRegistro();
            huboCambios = true;
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void frmModificarLocacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnBuscarEntreCalle1_Click(object sender, EventArgs e)
        {
            BuscarCallesEntre(txtEntreCalle1);
        }

        private void btnBuscarEntreCalle2_Click(object sender, EventArgs e)
        {
            BuscarCallesEntre(txtEntreCalle2);
        }

        private void btnLocacionNueva_Click(object sender, EventArgs e)
        {
            buscarLocacion = false;
            btnGuardarLocacion.Enabled = true;
            ActivarControlesLocacion(true);
            LimpiarDatosControles();
            lblLocacionNueva.Visible = true;
            cboLocalidades.Focus();
            CargaCodigoPostal();
        }

        private void btnBuscarLocacion_Click(object sender, EventArgs e)
        {
            buscarLocacion = true;
            LimpiarDatosControles();
            ActivarControlesLocacion(false);
            CargarDatosLocacion();
        }

        private void txtParcelaServicio_TextChanged(object sender, EventArgs e)
        {
            lblLocacionNueva.Text = FormatearTextoLocacion("Locación de destino", txtCalle.Text, spAltura.Value.ToString(), txtPisoServicio.Text, txtDeptoServicio.Text, String.Empty, cboLocalidades.Text);
        }

        private void dgvServicios_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvServicios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvServicios.CommitEdit(DataGridViewDataErrorContexts.Commit);

        }

        private void dgvServicios_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {


            int cantTraspasar = 0;

            if (dgvServicios.Columns[e.ColumnIndex].Name == "Trasladar")
            {
                try
                {
                    foreach (DataRow item in dtServiciosUsuario.Rows)
                    {
                        if (Convert.ToBoolean(item["Trasladar"]) == true)
                            cantTraspasar++;
                    }
                    if (cantTraspasar == dgvServicios.Rows.Count)
                    {
                        chkTraspasoCtaCte.Enabled = true;
                        chkTraspasoCtaCte.Checked = oConfig.GetValor_N("TraspasoCtaCte") == 1 ? true : false;
                        chkTraspasoPartes.Enabled = true;
                        chkTraspasoPartes.Checked = oConfig.GetValor_N("TraspasoPartes") == 1 ? true : false;

                    }
                    else
                    {
                        chkTraspasoCtaCte.Enabled = false;
                        chkTraspasoCtaCte.Checked = false;
                        chkTraspasoPartes.Enabled = false;
                        chkTraspasoPartes.Checked = false;
                    }

                }
                catch (Exception)
                {

                }
            }
        }
    }
}