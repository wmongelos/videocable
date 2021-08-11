using CapaNegocios;
using CapaPresentacion.Abms;
using CapaPresentacion.Afip;
using CapaPresentacion.Complementarias;
using CapaPresentacion.Contabilidad;
using CapaPresentacion.Cuenta_Corriente;
using CapaPresentacion.Debitos_Automaticos;
using CapaPresentacion.Facturas;
using CapaPresentacion.Herramientas;
using CapaPresentacion.Impuestos;
using CapaPresentacion.Informes;
using CapaPresentacion.Inventario;
using CapaPresentacion.Partes_Trabajo;
using CapaPresentacion.Seguridad;
using CapaPresentacion.Mapas;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmMain : Form
    {
        //clases que uso para cargar datatables

        UsuariosTipos oUsuariosTipos = new UsuariosTipos();


        //--------
        private Configuracion oConfig = new Configuracion();
        private int config_agenda;
        private DataTable dt = new DataTable();
        private frmPopUp oPop;




        public void openForm(Form oForm)
        {
            for (int i = 0; i < pnContent.Controls.Count; i++)
            {
                if (pnContent.Controls[i].Name != "frmUsuariosPrincipal")
                    pnContent.Controls.RemoveAt(i);
            }

            oForm.TopLevel = false;
            pnContent.Controls.Add(oForm);
            oForm.WindowState = FormWindowState.Maximized;

            oForm.Show();
        }

        private static frmMain aForm = null;

        public static frmMain Instance()
        {
            if (aForm == null)
                aForm = new frmMain();

            return aForm;
        }

        private frmMain()
        {
            InitializeComponent();
            //if (oConfig.GetValor_N("ModPuntoGestion") == 2)
            //    lblUsuario.Cursor = Cursors.Hand;
        }
        private void SetearModoFacturaElectronica()
        {
            if (oConfig.GetValor_N("Factura_Electronica") == 2)
            {
                lblVersion.Text = String.Format("[ GIES | {0} | PRODUCCION ]", Application.ProductVersion.ToString());
                
                lblVersion.BackColor = Color.LimeGreen;
                lblVersion.ForeColor = Color.White;
            }
            else
            {
                lblVersion.Text = String.Format("[ GIES | {0} | HOMOLOGACION ]", Application.ProductVersion.ToString());
                lblVersion.BackColor = Color.Red;
                lblVersion.ForeColor = Color.White;
            }

            lblVersion.Text = String.Format("{0} | Ult. Calculo Punitorio {1}", lblVersion.Text, oConfig.GetValor_C("UltCalculoPunitorio"));

        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            lblAppName.Text = oConfig.GetValor_C("Empresa").Trim() + " - " + Puntos_Cobros.Name_User_Login;
            if (AppDomain.CurrentDomain.BaseDirectory.ToLower() != @"c:\gies\")
                lblAppName.Text = lblAppName.Text + " (BETA) ";
            SetearModoFacturaElectronica();
            lblUsuario.Text = $"{Personal.Name_Login} - {Puntos_Cobros.Name_Punto}";
            config_agenda = oConfig.GetValor_N("Agenda_Trabajo");
            if (config_agenda == Convert.ToInt32(Agenda_Encabezado.Uso_agenda.TRABAJA_CON_AGENDA))
                agendaDeTrabajoToolStripMenuItem.Enabled = true;
            else
                agendaDeTrabajoToolStripMenuItem.Enabled = false;

            if (oConfig.GetValor_N("Id_Tipo_Facturacion") == Convert.ToInt32(Tipo_Facturacion.Id_Tipo_Facturacion.POR_ZONAS))
                serviciosPorCategoriasToolStripMenuItem.Text = "Servicios por Zonas";


            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            UsuariosTipos.dtUsuariosTipos = oUsuariosTipos.Listar();
            openForm(frmUsuariosPrincipal.Instance());

            // archivosToolStripMenuItem.Enabled = Personal.IdRol == 1 ? true : false;
            SetterControles adObj = new SetterControles();
            adObj.SetearControles(this.mnuPrincipal, frmUsuariosPrincipal.Instance());

            backupBaseDeDatosToolStripMenuItem.Enabled = true;

            if (Personal.Id_Login == 0)
            {
                mantenimientoToolStripMenuItem.Visible = true;
                seguridadToolStripMenuItem1.Enabled = true;
                contratosToolStripMenuItem.Enabled = true;
                condicionesDeOperacionesToolStripMenuItem.Enabled = true;
            }
        }

        private void areasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new ABMPersonal_Areas());
        }

        private void personalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openForm(new ABMPersonal());
        }

        private void localidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Provincias oProvincias = new Provincias();
            dt = oProvincias.Listar();
            if (dt.Rows.Count > 0)
                openForm(new ABMLocalidades());
            else
                MessageBox.Show("No hay provincias cargadas aun", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void serviciosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openForm(new ABMServicios());
        }

        private void zonasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new ABMZonas());
        }

        private void tarifasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new ABMTarifas());
        }

        private void tarifasPorServiciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new ABMTarifas_Sub());
        }

        private void provinciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new ABMProvincias());
        }

        private void profesionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new ABMUsuarios_Profesiones());
        }

        private void tiposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new ABMEquipos_Tipos());
        }

        private void fallasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new ABMPartes_Fallas());
        }

        private void equiposToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openForm(new ABMEquipos());
        }

        private void modelosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new ABMEquipos_Modelos());
        }

        private void marcasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new ABMEquipos_Marcas());
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void tiposToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openForm(new ABMServicios_Tipos());
        }

        private void cuentaCorrienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new frmUsuariosCtaCte(0, 0));
        }

        private void callesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new ABMCalles());
        }

        private void tiposDeComprobantesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new ABMTipoComprobantes());
        }

        private void puntosDeCobroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new ABMPuntosGestion());
        }

        private void lblCtaCte_Click(object sender, EventArgs e)
        {
            openForm(new frmUsuariosCtaCte(0, 0));
        }

        private void cajaDiariaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //openForm(new frmCaja_Diaria());
            if (oConfig.GetValor_N("FormatoCaja") == 1)
                openForm(new frmCaja_Diaria(0));
            else
                openForm(new frmCajaDetalle(0));
        }

        private void cajaGeneralToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new frmCaja_General());
        }

        private void solucionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new ABMPartes_Soluciones());
        }

        private void generarParteDeTrabajoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new frmGenerarParte(0, 0, null, 0, 0));
        }

        private void cambioDeEquipoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //openForm(new frmEquiposCambio());
        }

        private void estadosDeEquiposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new frmConsulta_Estados());
        }

        private void facturacionMensualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new frmFacturacionMensualNuevo(false));
        }

        private void configuracionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new frmOpciones());
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new ABMServicios_Categorias());
        }

        private void facturacionElectronicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void comprobantesEmitidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new frmConsultaComp());
        }

        private void categoriasToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            openForm(new ABMServicios_Categorias());
        }

        private void parteDeTrabajoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Usuarios.CurrentUsuario.Id == 0)
                openForm(new frmGenerarParte(0, 0, null, 0, 0));
            else
                openForm(new frmGenerarParte(Usuarios.CurrentUsuario.Id, Usuarios.CurrentUsuario.Id_Usuarios_Locacion, null, 0, 0));
        }

        private void asignarTecnicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmParteAsignaciones frm = new frmParteAsignaciones();
            frm.Parte_Estado = Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_TECNICO;
            openForm(frm);
        }

        private void asignarEquiposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAsignacionEquipos frm = new frmAsignacionEquipos(0, frmAsignacionEquipos.TIPO_LLAMADA_FORM.SHOW);

            openForm(frm);
        }

        private void conexionDeServicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Usuarios.CurrentUsuario.Id = 0;
            frmParteConexion frm = new frmParteConexion(1);
            frm.TipoOperacion = 1;
            frm.MismaLocacion = false;
            frm.IdUsuario = 0;
            openForm(frm);
        }

        private void opcionesDelSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new frmOpciones());
        }

        private void confirmarParteDeTrabajoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new frmConfirmaParte(0, frmConfirmaParte.FUNCIONALIDAD.CONFIRMAR_ANULAR));
        }

        private void serviciosPorCategoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new ABMTipoFac_Servicios());
        }

        private void agendaDeTrabajoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
            DataTable dt_tecnicos = new DataTable();
            Agenda_Encabezado agenda = new Agenda_Encabezado();

            dt_tecnicos = agenda.Buscar_tecnico();
            if (dt_tecnicos.Rows.Count > 0)
                openForm(new frmAgenda());
            else
                MessageBox.Show("Agenda: No hay técnicos registrados en el sistema.");*/

            DataTable dt_tecnicos = new DataTable();
            Agenda_Encabezado agenda = new Agenda_Encabezado();

            dt_tecnicos = agenda.Buscar_tecnico();
            if (dt_tecnicos.Rows.Count > 0)
            {
                frmAgenda frmAgen = frmAgenda.GetInstancia();

                frmAgen.Mostrar();
            }
            else
                MessageBox.Show("Agenda: No hay técnicos registrados en el sistema.");

        }

        private void barriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new ABMBarrios());
        }

        private void manzanasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new ABMManzanas());
        }

        private void plasticosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ABMPlasticos abmPlasticos = new ABMPlasticos();
            openForm(abmPlasticos);
        }

        private void detalleDeMovimientosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cuenta_Corriente.frmInformesCuentaCorriente frmInformesCuenta = new Cuenta_Corriente.frmInformesCuentaCorriente();

            openForm(frmInformesCuenta);
        }

        private void bajaDeServiciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBajaServicios frmBaja = new FrmBajaServicios(Usuarios.CurrentUsuario.Id, Usuarios.CurrentUsuario.Id_Usuarios_Locacion, null);
            openForm(frmBaja);
        }

        private void tareasDiariasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void factibilidadDeServicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmPopUp frm = new frmPopUp())
            {
                frm.Formulario = new frmFactibilidad();
                frm.Maximizar = false;
                frm.ShowDialog();
            }
        }

        private void puntosDeVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ABMPuntosVenta frmPuntosVenta = new ABMPuntosVenta();
            openForm(frmPuntosVenta);
        }

        private void condicionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new ABMServicios_Condiciones(0));
        }

        private void asignarTiposDeEquiposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAsignacionTiposEquipos frmAsignarTipos = new frmAsignacionTiposEquipos(0);
            openForm(frmAsignarTipos);
        }

        private void tarjetasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ABMEquipos_Tarjetas ABMtarjetas = new ABMEquipos_Tarjetas(0, 0);
            openForm(ABMtarjetas);
        }

        private void velocidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ABMServicios_Velocidades ABMVelocidades = new ABMServicios_Velocidades();
            openForm(ABMVelocidades);
        }

        private void formasDePagoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new ABMFormasDePago());
        }

        private void altaDeUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmPopUp frm = new frmPopUp())
            {
                ABMClientes frmABM = new ABMClientes(0);
                frm.Formulario = frmABM;
                frm.Maximizar = false;

                frm.ShowDialog();
            }
        }

        private void pnContent_ControlRemoved(object sender, ControlEventArgs e)
        {
            frmUsuariosPrincipal.Instance().comenzarCarga();
        }

        private void rolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new ABMPersonal_Roles());
        }

        private void serviciosEnEsperaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Usuarios.CurrentUsuario.Id == 0)
                MessageBox.Show("No se ha seleccionado un usuario.");
            else
                openForm(new frmPostergarFechaCorteServ(Usuarios.CurrentUsuario.Id, 0));
        }

        private void cuadroTarifarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new frmCuadroTarifario());
        }

        private void debitosAutomaticosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new frmDebitos());
        }

        private void impuestoProvincialesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new frmImpuestosProvincial());
        }

        private void novedadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new frmUsuariosCtaCteNovedades());
        }

        private void recibosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new frmCobradoresPagos());
        }

        private void presentacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new frmDebitosPresentacion());
        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmPopUp frm = new frmPopUp())
            {
                frm.Formulario = new frmCobradoresConsultaPagos();
                frm.ShowDialog();
            }
            //openForm(new frmCobradoresConsultaPagos());
        }

        private void impuestosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openForm(new frmImpuestos());
        }

        private void rolesDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new ABMPersonal_Roles());
        }

        private void aplicacionExternasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new ABMAplicaciones_Externas());
        }

        private void gestionDeBonificacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new ABMBonificaciones());
        }

        private void consultaDePartesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openForm(new frmPartesHistorial());
        }

        private void ventasYCobrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new frmConsultaVentasCobros());
        }

        private void formasDePagosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new frmConsultaRecibos());
        }

        private void informesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPartesInformes frmNuevoInforme = new frmPartesInformes();
            openForm(frmNuevoInforme);
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new ABMProveedores());
        }

        private void articulosRubrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new ABMArticulos_Rubros());
        }

        private void cajasCerradasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new frmCajasCerradas());
        }

        private void listadoBajasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new frmListadoCortes());

        }

        private void bonificacionesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openForm(new ABMBonificaciones());
        }

        private void lblVersion_Click(object sender, EventArgs e)
        {
           //oPop = new frmPopUp();
           // frmUpdates oUpdates = new frmUpdates();
           // oPop.Formulario = oUpdates;
           // oPop.Maximizar = false;
           // oPop.ShowDialog();
        }

        private void notificacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            oPop = new frmPopUp();
            AbmNotificaciones abmNotificacion = new AbmNotificaciones();
            oPop.Formulario = abmNotificacion;
            oPop.Maximizar = false;
            oPop.ShowDialog();
        }

        private void btnNotificaciones_Click(object sender, EventArgs e)
        {
            openForm(new AbmNotificaciones());
        }

        private void notificacionesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openForm(new AbmNotificaciones());
        }

        private void ipsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new ABMIpfijas(0));
        }

        private void facturacionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openForm(new Facturas.frmFacturasElectronicasAdheridos());
        }

        private void adheridosAFacturasElectronicasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new Facturas.frmEnviaFacturasElectronicas());

        }

        private void destinosAutomaticosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new ABMNotificaciones_Destinos_Aut());
        }

        private void facturacionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void panelDeNotificacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new AbmNotificaciones());
        }

        private void presentaciónDébitosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new ABMDebitosPresentacion());
        }

        private void aplicacionesExternasCompatibilidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new ABMAplicaciones_Externas_Relacion());
        }

        private void usuariosToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void configuracionAplicacionesExternasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new frmPartesServiciosConf());
        }

        private void gestiónDeBajasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new frmListadoBajasServicio());
        }

        private void consultaDeCobranzasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new CapaPresentacion.Contabilidad.frmConsultaCobranzas());
        }

        private void impresionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new frmPartesImpresion());
        }

        private void bajaDeDébitosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new CapaPresentacion.Debitos_Automaticos.frmDebitosBaja());
        }

        private void cambioDeVelocidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new frmCambioServicioVel());
        }

        private void serviciosToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            openForm(new frmInformeServiciosNuevo());
        }

        private void deudasAnexadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new Debitos_Automaticos.frmDebitosDeudasAnexadas());
        }

        private void articulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new ABMArticulos());
        }

        private void movilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new ABMMoviles());
        }

        private void asignacionDeArticulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new FrmMovimientosArt());
        }

        private void recibosToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            frmDebitosRecibos oDebitosRecibos = new frmDebitosRecibos();
            oDebitosRecibos.Show();
        }

        private void reciboDeCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRecibosResumen oFrmRecibosResumen = new frmRecibosResumen();
            oFrmRecibosResumen.Show();

        }

        private void facturacionMensualDebitosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new frmFacturacionMensualNuevo(true));

        }

        private void consultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new frmPartesHistorial());
        }

        private void avanzadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new frmConsultaHistorial());
        }

        private void detalleDeMovimientosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openForm(new FrmMovimientosDetalle());
        }

        private void consultaPorFormasDePagoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new frmListadoFormaDePagos());
        }

        private void ingresoDeStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new FrmComprobantesCompras());
        }

        private void organismosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openForm(new ABMOrganismos());
        }

        private void serviciosToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            openForm(new frmOrganismos());
        }

        private void consultaDeComprobantesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new FrmConsultaComprobantesCompras());
        }

        private void porToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new frmFacturacionServiciosPeriodo());
        }

        private void universoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new frmFacturacionServiciosPorPeriodo());
        }

        private void lblUsuario_Click(object sender, EventArgs e)
        {
            if (oConfig.GetValor_N("ModPuntoGestion") == 2)
            {
                string tipoSucursal = new Puntos_Cobros().PuntoDatos(Puntos_Cobros.Id_Punto).Rows[0]["tipo_sucursal"].ToString();
                using (frmPopUp frm = new frmPopUp())
                {
                    frm.Formulario = new frmCambioPuntosVenta(); //new ABMPuntosGestion_CompHabilitados(Puntos_Cobros.Id_Punto, tipoSucursal, Puntos_Cobros.Name_Punto);
                    frm.Maximizar = false;
                    frm.ShowDialog();
                }
            }
        }

        private void exportarUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new frmExportaUsuarioTxt());
        }

        private void analisisDeDeudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new frmAnalisDeuda());
        }

        private void importacionARBAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new FrmUsuariosARBA());
        }

        private void cobranzaPorTipoDeServiciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new frmHistorialCobros());
        }

        private void facturacionNuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new frmFacturacionMensualNuevo(false));

        }

        private void facturacionNuevoDebitosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new frmFacturacionMensualNuevo(true));

        }

        private void backupBaseDeDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tools tools = new Tools();
            tools.GenerarBKPMysql("");
        }

        private void lblVersion_DoubleClick(object sender, EventArgs e)
        {
           
        }

        private void lblVersion_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int ConfActual = oConfig.GetValor_N("Factura_Electronica");
            if (ConfActual == 1)
            {
                if (MessageBox.Show("Esta cambiando a modo 'PRODUCCIóN', cualquier factura que se emita electronicamente será registrada en AFIP. ¿Desea continuar?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    oConfig.SetValor_N("Factura_Electronica", 2);
                    oConfig.LoadConfiguracion();
                    SetearModoFacturaElectronica();
                }
            }
            else
            {
                if (MessageBox.Show("Esta cambiando a modo 'HOMOLOGACIóN', cualquier factura que se emita electronicamente NO será registrada en AFIP. ¿Desea continuar?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    oConfig.SetValor_N("Factura_Electronica", 1);
                    oConfig.LoadConfiguracion();
                    SetearModoFacturaElectronica();

                }
            }
        }

        private void seguridadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmPopUp frm = new frmPopUp())
            {
                FrmActualizarTablaRolesPermisos frmSEG = new FrmActualizarTablaRolesPermisos();
                frm.Formulario = frmSEG;
                frm.Maximizar = false;
                frm.ShowDialog();
            }
        }

        private void contratosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmPopUp frm = new frmPopUp())
            {
                ABMContratos frmAbm = new ABMContratos();
                frm.Formulario = frmAbm;
                frm.ShowDialog();
            }
        }

        private void contratosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openForm(new ABMServicios_Contratos());
        }

        private void compatibilidadDeServiciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void avisosDeCorteDeServiciosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void enacomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new frmInformeDeudoresENACOM());
        }

        private void generalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new frmAnalisDeuda());
        }

        private void constataciónDeComprobantesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new frmafipservicios()); 
        }

        private void serviciosToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            openForm(new frmFacturacionServicios());
        }

        private void calculoDePunitoriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void actualizarSaldosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmPopUp frm = new frmPopUp())
            {
                frmActualizarSaldosYPunitorios frmActualiza = new frmActualizarSaldosYPunitorios(frmActualizarSaldosYPunitorios.TIPO.SALDO_LOCACION);
                frm.Formulario = frmActualiza;
                frm.Maximizar = false;

                frm.ShowDialog();
            }
        }

        private void facturacionARBAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new frmARBACuatrimestral());
        }

        private void pagosAdelantadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new frmPagosAdelantados());
        }

        private void formularioDeAltaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmPopUp frm = new frmPopUp())
            {
                frm.Formulario = new frmNuevoDebito();
                frm.Maximizar = false;
                frm.ShowDialog();

            }
        }

        private void pagosPorPeriodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new frmConsultaPeriodosPagos());
        }

        private void cassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new FrmCass_Usuarios());
        }

        private void verificacionLibroIVAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new frmafipDatosDelContribuyente());
        }

        private void infraestructuraToolStripMenuItem_Click(object sender, EventArgs e)
        {     
            using (frmPopUp frm = new frmPopUp())
            {
                frm.Formulario = new frmParteInfraestructura();
                frm.Maximizar = false;
                frm.ShowDialog();

            }
        }

        private void constataciónDeComprobantesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openForm(new frmDiferenciasDeComprobantesGiesAfip());
        }

        private void asignacionDeComprobantesConstatadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new frmAsignacionDeIvaVentas());
        }

        private void cuentaCorrienteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            openForm(new FrmUsuariosCtaCteArreglo());
        }

        private void equiposAsignadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Informes.frmConsultaEquipoUsuario ofrm = new frmConsultaEquipoUsuario();
            ofrm.Show();
        }


        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAnalisisDeudaNuevo oNuevo = new frmAnalisisDeudaNuevo();
            oNuevo.Show();
        }

        private void listaDeAvisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new frmUsuariosAvisados());
        }

        private void generarAvisoDeCorteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new frmCortesNuevo(frmCortesNuevo.Tipo.AVISOS));
        }

        private void generarCortesDeServicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new frmCortesNuevo(frmCortesNuevo.Tipo.CORTES));

        }

        private void consultaCajasCerradasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new FrmInformeCajas());
        }

        private void consultaDeComprobantesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmComprobantesGenerados oFrm = new frmComprobantesGenerados();
            oFrm.Show();
        }

        private void usuariosPorServiciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new frmInforme_UsuariosActivos());
        }

        private void usuariosToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            openForm(new frmUsuariosGral());
        }

        private void conciliacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new frmInformeConciliaciones());
        }

        private void consultaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openForm(new frmPartesHistorial());
        }

        private void avanzadaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openForm(new frmConsultaHistorial());
        }

        private void infraestructuraToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openForm(new frmConsultaPartesInfraestructura());
        }

        private void pnContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comprobantesGeneradosFacturadodsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new FrmComprobantesEmitidosyFacturados());
        }

        private void numeraciónCAIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmPopUp frm = new frmPopUp()) {
                frm.Maximizar = false;
                frm.Formulario = new frmCargaNroCai();
                frm.ShowDialog();
            }
        }

        private void balanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new frmConsultaBalance());
        }

        private void iSPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new AppExternas.frmRelacionVelocidades());

        }

        private void cASSToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openForm(new ABMCassRelacionGIES());

        }

        private void actualizarMesesServiciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmPopUp frm = new frmPopUp())
            {
                frm.Maximizar = false;
                frm.Formulario = new frmMesesCobroServicios();
                frm.ShowDialog();
            }

        }

        private void condicionesDeOperacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new ABMOperaciones_Condiciones_Relacion());
        }

        private void cajasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new frmCajasMensuales());
        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
         
        }

        private void bAPROToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new CapaPresentacion.PagosExternos.Bapro.frmBaproTxt());
        }

        private void informesDeCajasPorServiciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new frmCajasMensuales());
        }

        private void geolocalizacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new frmGeolocalizacion());
        }

        private void agregarCoordenadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void areasGeograficasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void bAPROToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            openForm(new CapaPresentacion.PagosExternos.Bapro.frmBaproTxt());

        }

        private void captarPagosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new CapaPresentacion.PagosExternos.CaptarPagos.frmListaPagos());

        }

        private void cajaVirtualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new CapaPresentacion.Contabilidad.frmRecibosVirtuales());
        }

        private void pagosGeneradosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new CapaPresentacion.PagosExternos.frmPagosGuardados());

        }

        private void areasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openForm(new frmABMdeAreasGeograficas());
        }

        private void coordenadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new frmAgregarCoordenadas());
        }

        private void geolocalizaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new frmGeolocalizacion());
        }

        private void configuracionPagosExternosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new CapaPresentacion.PagosExternos.frmConfiguracion());

        }

        private void mercadoPagoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(new CapaPresentacion.PagosExternos.MercadoPagoCh.frmListaPagos());

        }

        private void permisosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void calcularToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmPopUp frm = new frmPopUp())
            {
                frmActualizarSaldosYPunitorios frmActualiza = new frmActualizarSaldosYPunitorios(frmActualizarSaldosYPunitorios.TIPO.SALDO_PUNITORIO);
                frm.Formulario = frmActualiza;
                frm.Maximizar = false;

                frm.ShowDialog();
                if (oConfig.GetValor_N("Factura_Electronica") == 2)
                {
                    lblVersion.Text = String.Format("[ GIES | {0} | PRODUCCION ]", Application.ProductVersion.ToString());
                }
                else
                {
                    lblVersion.Text = String.Format("[ GIES | {0} | HOMOLOGACION ]", Application.ProductVersion.ToString());
                }
                oConfig.LoadConfiguracion();
                lblVersion.Text = String.Format("{0} | Ult. Calculo Punitorio {1}", lblVersion.Text, oConfig.GetValor_C("UltCalculoPunitorio"));
                lblVersion.Refresh();
            }
        }

        private void verIncongruenciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmPopUp frm = new frmPopUp())
            {
                frmListarIncongruenciasPunitorios frmincongruencias = new frmListarIncongruenciasPunitorios();
                frm.Formulario = frmincongruencias;
                frm.Maximizar = false;

                frm.ShowDialog();
            }
        }
    }
}
