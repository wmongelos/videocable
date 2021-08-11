using CapaNegocios;
using CapaPresentacion.Partes_Trabajo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Busquedas
{
    public partial class frmBusquedaEquipos : Form
    {
        int IdItem;
        int TipoItem;
        int IdUsuariosServicios;
        private int IdParte;
        private int TipoEquipo = 0;
        private decimal importeEquipo = 0;
        private int idEquipoAnterior = 0;
        private int IdParteEstado = 0;
        private int idServicio = 0;
        private string mac, serie, marca, modelo;
        private Thread hilo;
        private delegate void myDel();
        public int idTarjeta;

        string macNueva = "";

        private Usuarios oUsuario = new Usuarios();
        private Equipos_Tipos oEquipo_Tipos = new Equipos_Tipos();
        private Equipos_Marcas oEquipo_Marca = new Equipos_Marcas();
        private Equipos_Modelos oEquipo_Model = new Equipos_Modelos();
        private Equipos_Estados oEquipo_Estado = new Equipos_Estados();
        private Partes_Equipos oParte_Equipo = new Partes_Equipos();
        private Equipos oEquipos = new Equipos();
        private Partes_Usuarios_Servicios oPartesUsuariosServicios = new Partes_Usuarios_Servicios();
        private Usuarios_Servicios oUsuariosServicios = new Usuarios_Servicios();
        private Partes oParte = new Partes();
        private Comprobantes oComprobantes = new Comprobantes();
        private Comprobantes_Tipo oComprobantesTipo = new Comprobantes_Tipo();
        private Servicios_Tarifas oServicios_tarifas = new Servicios_Tarifas();
        private Servicios_Tarifas_Sub oServiciosTarifasSub = new Servicios_Tarifas_Sub();
        private Usuarios_CtaCte oUsuariosCtaCte = new Usuarios_CtaCte();
        private Usuarios_CtaCte_Det oUsuariosCtaCteDet = new Usuarios_CtaCte_Det();
        private Servicios_Tarifas oServiciosTarifas = new Servicios_Tarifas();
        private Partes_Historial oPartesHistorial = new Partes_Historial();

        public List<Partes_Equipos> lista_partes_equipos = new List<Partes_Equipos>();
        public List<int> lista_equipos_contados = new List<int>();
        //public Int32 Id_Equipo = 0;

        private DataRow DrDatosParte;

        private DataTable DtServiciosParte = new DataTable();
        private DataTable DtPartesEquipos = new DataTable();
        private DataTable dtDatosEquipoAnterior = new DataTable();
        private DataTable DtEquipos = new DataTable();
        private DataTable dtPartes = new DataTable();
        public DataTable dtEquiposSeleccionados = new DataTable();

        private DataRow drDatosComprobanteVenta = null;
        private DialogResult dialogResult;
        Configuracion oConfig = new Configuracion();

        public enum TIPO_ITEM_BUSQUEDA_EQUIPO
        {
            PARTE = 1,
            PARTE_EQUIPO = 2,
            SIN_PARTE = 3
        }

        public frmBusquedaEquipos(int IdItemRecibido, int TipoItemRecibido, int IdUsuariosServiciosRecibido, int TipoEquipoRecibido, int idServicioRecibido, int idEquipoAnterior)
        {
            IdItem = IdItemRecibido;
            TipoItem = TipoItemRecibido;
            IdUsuariosServicios = IdUsuariosServiciosRecibido;
            TipoEquipo = TipoEquipoRecibido;
            idServicio = idServicioRecibido;
            this.idEquipoAnterior = idEquipoAnterior;
            InitializeComponent();
        }
        private void bloquearControles()
        {
            foreach (Control item in this.Controls)
                item.Enabled = false;
            pgCircular.Enabled = true;

        }
        private void desbloquearControles()
        {
            foreach (Control item in this.Controls)
                item.Enabled = true;
        }
        private void comenzarCarga()
        {
            bloquearControles();
            pgCircular.Start();
            dgvEquipos.DataSource = null;
            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
        }

        private void cargarDatos()
        {
            try
            {
                if (TipoItem == Convert.ToInt32(TIPO_ITEM_BUSQUEDA_EQUIPO.PARTE_EQUIPO))
                {
                    IdParte = Convert.ToInt32(oParte_Equipo.BuscarParteEquipo(IdItem).Rows[0]["Id_Partes"]);
                    DtServiciosParte = oPartesUsuariosServicios.BuscarPorParteEquipo(IdItem);
                }
                else
                {
                    IdParte = IdItem;
                    DtServiciosParte = oUsuariosServicios.Traer_datos_usuarios_servicios(IdUsuariosServicios);
                }
                DrDatosParte = oParte.TraerParteRow(IdParte);


                if (idEquipoAnterior > 0)
                    dtDatosEquipoAnterior = oEquipos.BuscarDatosEquipo(idEquipoAnterior);

                myDel MD = new myDel(asignarDatos);
                this.Invoke(MD, new object[] { });

            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
            }
            pgCircular.Stop();
        }

        private void asignarDatos()
        {
            try
            {
                lblNParte.Text = String.Format("N° de parte: {0}", DrDatosParte["id"]);
                lblUsuario.Text = String.Format("Usuario: {0} {1}", DrDatosParte["apellido"], DrDatosParte["nombre"]);
                lblLocacion.Text = String.Format("Locación: {0}, {1} {2}", DrDatosParte["localidad"], DrDatosParte["calle"], DrDatosParte["altura"]);
                lblServicioSeleccionado.Text = String.Format("Servicio seleccionado: {0}", DtServiciosParte.Rows[0]["servicio"]);
                if (DtEquipos.Rows.Count > 0)
                {
                    dgvEquipos.DataSource = DtEquipos;
                    for (int x = 0; x < dgvEquipos.Columns.Count; x++)
                        dgvEquipos.Columns[x].Visible = false;
                    foreach (DataGridViewRow item in dgvEquipos.Rows)
                        item.Height = 30;
                    dgvEquipos.Columns["serie"].Visible = true;
                    dgvEquipos.Columns["mac"].Visible = true;
                    dgvEquipos.Columns["tipo_equipo"].Visible = true;
                    dgvEquipos.Columns["marca"].Visible = true;
                    dgvEquipos.Columns["modelo"].Visible = true;
                    dgvEquipos.Columns["numero_tarjeta"].Visible = true;
                    dgvEquipos.Columns["serie"].HeaderText = "Serie";
                    dgvEquipos.Columns["mac"].HeaderText = "Mac";
                    dgvEquipos.Columns["tipo_equipo"].HeaderText = "Tipo de equipo";
                    dgvEquipos.Columns["marca"].HeaderText = "Marca";
                    dgvEquipos.Columns["modelo"].HeaderText = "Modelo";
                    dgvEquipos.Columns["numero_tarjeta"].HeaderText = "Número de tarjeta";
                    AsignarValores();
                    lblTotal.Text = String.Format("Total de Registros: {0}", dgvEquipos.Rows.Count);
                }

            }
            catch
            {

            }
            desbloquearControles();
        }

        private void AsignarValores()
        {
            try
            {
                lblEquipoSeleccionado.Text = String.Format("Equipo seleccionado: {0}, Serie: {1}", dgvEquipos.CurrentRow.Cells["tipo_equipo"].Value, dgvEquipos.CurrentRow.Cells["serie"].Value);
            }
            catch
            { }
        }

        private void FiltroGeneral()
        {
            if (txtBuscar.Text.Length > 0)
                DtEquipos.DefaultView.RowFilter = String.Format("serie Like '%" + txtBuscar.Text + "%' OR mac Like'%" + macNueva + "%' OR tipo_equipo LIKE '%" + txtBuscar.Text + "%' OR marca LIKE '%" + txtBuscar.Text + "%' OR modelo LIKE '%" + txtBuscar.Text + "%'");
            else
                DtEquipos.DefaultView.RowFilter = "id>0";
            lblTotal.Text = String.Format("Total de Registros: {0}", dgvEquipos.Rows.Count);
        }

        private void AsignarEquipo()
        {
            if (dgvEquipos.SelectedRows.Count > 0)
            {

                try
                {
                    importeEquipo = 0;
                    int idTarifaActual = 0;
                    oServiciosTarifas.Fecha_Actual = DateTime.Now;
                    idTarifaActual = oServiciosTarifas.getTarifa();

                    try
                    {
                        importeEquipo = Convert.ToDecimal(oServiciosTarifasSub.ObtienePrecio(idTarifaActual, Convert.ToInt32(DrDatosParte["id_zonas"]), idServicio, Convert.ToInt32(dgvEquipos.SelectedRows[0].Cells["id_equipos_tipos"].Value), 0, 0, "E").Rows[0]["importe"]);
                    }
                    catch
                    {
                        importeEquipo = 0;
                    }
                    if (TipoItem == Convert.ToInt32(TIPO_ITEM_BUSQUEDA_EQUIPO.PARTE))
                        if(importeEquipo>0)
                            dialogResult = MessageBox.Show(String.Format("Al agregar el equipo nuevo en está instancia,{0} se le cobrará un monto de ${1}.{0} ¿Desea continuar?", Environment.NewLine, importeEquipo), "", MessageBoxButtons.YesNo);
                        else
                            dialogResult = MessageBox.Show("Al agregar este equipo no se cobrara ningun valor ¿Desea continuar?", "", MessageBoxButtons.YesNo);
                    if ((TipoItem == Convert.ToInt32(TIPO_ITEM_BUSQUEDA_EQUIPO.PARTE) && dialogResult == DialogResult.Yes) || TipoItem == Convert.ToInt32(TIPO_ITEM_BUSQUEDA_EQUIPO.PARTE_EQUIPO))
                    {
                        if (TipoItem == Convert.ToInt32(TIPO_ITEM_BUSQUEDA_EQUIPO.PARTE))
                        {
                            oParte_Equipo.Id_Partes = Convert.ToInt32(DrDatosParte["id"]);
                            oParte_Equipo.Id_Usuarios = Convert.ToInt32(DrDatosParte["id_usuarios"]);
                            oParte_Equipo.Id_Equipos_Tipos = Convert.ToInt32(dgvEquipos.SelectedRows[0].Cells["id_equipos_tipos"].Value);
                            oParte_Equipo.Id_Servicios = idServicio;
                            oParte_Equipo.Id_Usuarios_Servicios = IdUsuariosServicios;
                            oParte_Equipo.Id = oParte_Equipo.Guardar(oParte_Equipo);
                        }
                        else
                            oParte_Equipo.Id = IdItem;

                        if (oParte_Equipo.Id > 0)
                        {
                            oParte_Equipo.AsignarEquipo(oParte_Equipo.Id, Convert.ToInt32(dgvEquipos.SelectedRows[0].Cells["id"].Value));

                            if (TipoItem == Convert.ToInt32(TIPO_ITEM_BUSQUEDA_EQUIPO.PARTE))
                            {
                                if(importeEquipo > 0) { 
                                    int nComprobante = 0;

                                    drDatosComprobanteVenta = oComprobantesTipo.GetNumeracion(Convert.ToInt32(Comprobantes_Tipo.Tipo.COMPROBANTE_DEUDA), Puntos_Cobros.Id_Punto);
                                    nComprobante = Convert.ToInt32(drDatosComprobanteVenta["numComprobante"]);
                                    if (nComprobante > 0)
                                        oComprobantesTipo.SetNumeracion(Convert.ToInt32(drDatosComprobanteVenta["idPuntoVenta"]), Convert.ToInt32(Comprobantes_Tipo.Tipo.COMPROBANTE_DEUDA), nComprobante);

                                    oComprobantes.Id_Usuarios = Convert.ToInt32(DrDatosParte["id_usuarios"]);
                                    oComprobantes.Fecha = DateTime.Today;
                                    oComprobantes.Punto_Venta = Convert.ToInt32(drDatosComprobanteVenta["numPuntoVenta"]);
                                    oComprobantes.Id_Comprobantes_Tipo = Convert.ToInt32(Comprobantes_Tipo.Tipo.COMPROBANTE_DEUDA);
                                    oComprobantes.Numero = nComprobante;
                                    oComprobantes.Importe = 0;
                                    oComprobantes.Importe = importeEquipo;
                                    oComprobantes.Id_Usuarios_Locaciones = Convert.ToInt32(DrDatosParte["id_usuarios_locaciones"]);
                                    oComprobantes.Id = oComprobantes.Guardar(oComprobantes);

                                    oUsuariosCtaCte.Id_Usuarios = oComprobantes.Id_Usuarios;
                                    oUsuariosCtaCte.Id_Comprobantes = oComprobantes.Id;
                                    oUsuariosCtaCte.Fecha_Movimiento = DateTime.Today;
                                    oUsuariosCtaCte.Fecha_Desde = DateTime.Now;
                                    oUsuariosCtaCte.Fecha_Hasta = oUsuariosCtaCte.Fecha_Desde;
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
                                    oUsuariosCtaCte.Id_Origen = (int)Usuarios_CtaCte.ORIGEN.ASIGNACION_EQUIPOS;
                                    oUsuariosCtaCte.Guardar(oUsuariosCtaCte);

                                    oUsuariosCtaCteDet.Id_Usuarios_CtaCte = oUsuariosCtaCte.Id;
                                    oUsuariosCtaCteDet.Id_Usuarios_Locaciones = oComprobantes.Id_Usuarios_Locaciones;
                                    oUsuariosCtaCteDet.Id_Zonas = Convert.ToInt32(DrDatosParte["id_zonas"]);
                                    oUsuariosCtaCteDet.Id_Servicios = oParte_Equipo.Id_Servicios;
                                    oUsuariosCtaCteDet.Id_Tipo = Convert.ToInt32(DrDatosParte["id_partes_fallas"]);
                                    oUsuariosCtaCteDet.Tipo = "P";
                                    oUsuariosCtaCteDet.Importe_Original = oUsuariosCtaCte.Importe_Original;
                                    oUsuariosCtaCteDet.Importe_Saldo = oUsuariosCtaCte.Importe_Original;
                                    oUsuariosCtaCteDet.Id_Usuarios_Servicios = oParte_Equipo.Id_Usuarios_Servicios;
                                    oUsuariosCtaCteDet.Fecha_Desde = DateTime.Today;
                                    oUsuariosCtaCteDet.Fecha_Hasta = DateTime.Today;
                                    oUsuariosCtaCteDet.Id_Velocidades = 0;
                                    oUsuariosCtaCteDet.Id_Velocidades_Tip = 0;
                                    oUsuariosCtaCteDet.Requiere_IP = 0;
                                    oUsuariosCtaCteDet.Cantidad_Periodos = 1;
                                    oUsuariosCtaCteDet.Id_bonificacion_Aplicada = 0;
                                    oUsuariosCtaCteDet.Nombre_Bonificacion = String.Empty;
                                    oUsuariosCtaCteDet.Periodo_Ano = oUsuariosCtaCte.Fecha_Desde.Year;
                                    oUsuariosCtaCteDet.Periodo_Mes = oUsuariosCtaCte.Fecha_Desde.Month;
                                    oUsuariosCtaCteDet.Porcentaje_Bonificacion = 0;
                                    oUsuariosCtaCteDet.Detalles = "ASIGNACION DE NUEVO EQUIPO CON CARGO";
                                    oUsuariosCtaCteDet.Guardar(oUsuariosCtaCteDet);
                                }
                            }

                            oEquipos.AsignarEquipoAUsuario(Convert.ToInt32(dgvEquipos.SelectedRows[0].Cells["id"].Value), Convert.ToInt32(DrDatosParte["id_usuarios"]), IdUsuariosServicios, Convert.ToInt32(Equipos.Equipos_Estados.EN_PROCESO_DE_ASIGNACION));

                            IdParteEstado = oParte.SetearEstadoParte(Convert.ToInt32(DrDatosParte["id"]), 0, 0, DateTime.Now, 0, 0, "");

                            oPartesHistorial.Id_Parte = Convert.ToInt32(DrDatosParte["id"]);
                            oPartesHistorial.Id_Usuarios = Convert.ToInt32(DrDatosParte["id_usuarios"]);
                            oPartesHistorial.Id_Personal = Personal.Id_Login;
                            oPartesHistorial.Fecha_Movimiento = DateTime.Now;
                            oPartesHistorial.Id_area = Personal.Id_Area;
                            oPartesHistorial.Detalles = "EQUIPO ASIGNADO";
                            oPartesHistorial.Id_Partes_Estados = IdParteEstado;
                            oPartesHistorial.GuardarNuevoDetalle(oPartesHistorial);
                            MessageBox.Show("Equipo asignado correctamente.");

                        }
                        else
                            MessageBox.Show("Hubo un error en la operación. Id del registro parte_equipo es 0.");

                        if (oEquipo_Tipos.VerificarRequerimientoConfig(Convert.ToInt32(dgvEquipos.SelectedRows[0].Cells["id_equipos_tipos"].Value)))
                        {
                            string usuario, clave, ip;
                            usuario = String.Empty;
                            clave = String.Empty;
                            ip = String.Empty;
                            if (dtDatosEquipoAnterior.Rows.Count > 0)
                            {
                                usuario = dtDatosEquipoAnterior.Rows[0]["equipo_usuario"].ToString();
                                clave = dtDatosEquipoAnterior.Rows[0]["equipo_clave"].ToString();
                                ip = dtDatosEquipoAnterior.Rows[0]["equipo_ip"].ToString();
                                mac = dtDatosEquipoAnterior.Rows[0]["mac"].ToString();
                                serie = dtDatosEquipoAnterior.Rows[0]["serie"].ToString();

                            }

                            if (idEquipoAnterior == 0 || String.IsNullOrEmpty(dtDatosEquipoAnterior.Rows[0]["equipo_usuario"].ToString()) || String.IsNullOrEmpty(dtDatosEquipoAnterior.Rows[0]["equipo_clave"].ToString()))
                            {

                                Partes_Trabajo.frmDatosConfiguracionEquipo frmDatosConfig = new Partes_Trabajo.frmDatosConfiguracionEquipo(Convert.ToInt32(dgvEquipos.SelectedRows[0].Cells["id"].Value), usuario, clave, ip);
                                frmPopUp frmPU = new frmPopUp();
                                frmPU.Formulario = frmDatosConfig;
                                frmPU.Maximizar = false;
                                frmPU.ShowDialog();
                            }
                            else
                                oEquipos.ActualizarDatosConfig(Convert.ToInt32(dgvEquipos.SelectedRows[0].Cells["id"].Value), usuario, clave, ip);


                        }
                    }                   
                    else
                    {
                        try
                        {
                            if(this.idTarjeta > 0)
                                oEquipos.AsignarEquipoAUsuarioconTarjeta(Convert.ToInt32(dgvEquipos.SelectedRows[0].Cells["id"].Value), Usuarios.CurrentUsuario.Id, IdUsuariosServicios, Convert.ToInt32(Equipos.Equipos_Estados.ASIGNADO_A_USUARIO), idTarjeta);
                            else
                                oEquipos.AsignarEquipoAUsuario(Convert.ToInt32(dgvEquipos.SelectedRows[0].Cells["id"].Value), Usuarios.CurrentUsuario.Id, IdUsuariosServicios, Convert.ToInt32(Equipos.Equipos_Estados.ASIGNADO_A_USUARIO));
                            frmDatosConfiguracionEquipo frmDatosConfig2 = new frmDatosConfiguracionEquipo(Convert.ToInt32(dgvEquipos.SelectedRows[0].Cells["id"].Value), "0", "0", "0");
                            using (frmPopUp frmPU = new frmPopUp())
                            {
                                frmPU.Formulario = frmDatosConfig2;
                                frmPU.Maximizar = false;
                                frmPU.ShowDialog();
                            }
                        }
                        catch (Exception) { }
                    }

                    this.DialogResult = DialogResult.OK;
                }
                catch
                {
                    MessageBox.Show("Error al asignar el equipo.");
                    throw;
                }
            }
            else
                MessageBox.Show("No se ha seleccionado un equipo.");
        }

        private void frmBusquedaEquipos_Load(object sender, System.EventArgs e)
        {
            comenzarCarga();
        }

        private void frmBusquedaEquipamiento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void dgvEquipos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            AsignarValores();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (rbMac.Checked == true)
            {
                if (txtBuscar.TextLength == 12)
                {
                    string macNueva = "";
                    for (int i = 0; i < txtBuscar.TextLength; i = i + 2)
                    {
                        string respuesta = txtBuscar.Text.Substring(i, 2);
                        if (macNueva != "")
                            macNueva = macNueva + ":" + respuesta;
                        else
                            macNueva = respuesta;
                    }
                    txtBuscar.Text = macNueva;
                }
                FiltroGeneral();

            }
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            AsignarEquipo();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvEquipos_DoubleClick(object sender, EventArgs e)
        {
            AsignarEquipo();

        }

        private void boton1_Click(object sender, EventArgs e)
        {
            if (rbMac.Checked)
                DtEquipos = oEquipos.BuscarEquipos(Convert.ToInt32(DtServiciosParte.Rows[0]["id_servicios_tipo"]), txtMac.Text);
            else if (rbMarca.Checked)
                DtEquipos = oEquipos.BuscarEquipos(Convert.ToInt32(DtServiciosParte.Rows[0]["id_servicios_tipo"]), "", "", txtBuscar.Text);
            else if (rbModelo.Checked)
                DtEquipos = oEquipos.BuscarEquipos(Convert.ToInt32(DtServiciosParte.Rows[0]["id_servicios_tipo"]), "", "", "", txtBuscar.Text);
            else if (rbSerie.Checked)
                DtEquipos = oEquipos.BuscarEquipos(Convert.ToInt32(DtServiciosParte.Rows[0]["id_servicios_tipo"]), "", txtBuscar.Text);

            if (DtEquipos.Rows.Count > 0)
            {
                dgvEquipos.DataSource = DtEquipos;
                for (int x = 0; x < dgvEquipos.Columns.Count; x++)
                    dgvEquipos.Columns[x].Visible = false;
                foreach (DataGridViewRow item in dgvEquipos.Rows)
                    item.Height = 30;

                dgvEquipos.Columns["serie"].Visible = true;
                dgvEquipos.Columns["mac"].Visible = true;
                dgvEquipos.Columns["tipo_equipo"].Visible = true;
                dgvEquipos.Columns["marca"].Visible = true;
                dgvEquipos.Columns["modelo"].Visible = true;
                dgvEquipos.Columns["numero_tarjeta"].Visible = true;
                dgvEquipos.Columns["serie"].HeaderText = "Serie";
                dgvEquipos.Columns["mac"].HeaderText = "Mac";
                dgvEquipos.Columns["tipo_equipo"].HeaderText = "Tipo de equipo";
                dgvEquipos.Columns["marca"].HeaderText = "Marca";
                dgvEquipos.Columns["modelo"].HeaderText = "Modelo";
                dgvEquipos.Columns["numero_tarjeta"].HeaderText = "Número de tarjeta";
                AsignarValores();
                lblTotal.Text = String.Format("Total de Registros: {0}", dgvEquipos.Rows.Count);
                desbloquearControles();
            }


        }

        private void rbMac_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMac.Checked == true)
            {
                txtMac.Visible = true;
                txtMac.Location = txtBuscar.Location;

            }
            else
            {
                txtMac.Visible = false;
            }

        }

        private void txtMac_TextChanged(object sender, EventArgs e)
        {
        }

        private void rbSerie_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void copiarMACToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dgvEquipos_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    var hti = dgvEquipos.HitTest(e.X, e.Y);
                    // Add this
                    dgvEquipos.CurrentCell = dgvEquipos.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    // Can leave these here - doesn't hurt
                    dgvEquipos.Rows[e.RowIndex].Selected = true;
                    dgvEquipos.Focus();
                    cmsDerecho.Show(Cursor.Position);

                }
                catch
                {

                }
            }
        }

        private void cmsDerecho_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                if (e.ClickedItem.Name == "mnuCopiarMAC")
                    Clipboard.SetText(string.Join(",", dgvEquipos.SelectedRows[0].Cells["mac"].Value.ToString()));
                if (e.ClickedItem.Name == "mnuCopiarSERIE")
                    Clipboard.SetText(string.Join(",", dgvEquipos.SelectedRows[0].Cells["serie"].Value.ToString()));
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void dgvEquipos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                AsignarEquipo();

        }

        private void lblTituloPanel_Click(object sender, EventArgs e)
        {

        }

        private void dgvEquipos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
//200919-13:39 fede
//27112019MAXI CAMPO ID_ORIGEN