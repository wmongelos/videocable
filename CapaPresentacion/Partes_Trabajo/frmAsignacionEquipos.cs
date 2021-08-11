using CapaNegocios;
using CapaPresentacion.Busquedas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Partes_Trabajo
{
    public partial class frmAsignacionEquipos : Form
    {
        int IdParte = 0;
        private Thread hilo;
        private delegate void myDel();
        DataRow DrDatosParte;
        DataTable DtEquiposAsociados = new DataTable();
        DataTable DtServiciosAsociados = new DataTable();
        DataTable DtPartes = new DataTable();
        List<int> ListaEstados = new List<int>();
        Partes oParte = new Partes();
        Partes_Equipos oPartesEquipos = new Partes_Equipos();
        int IdEquipo = 0;
        Equipos oEquipos = new Equipos();
        Partes_Usuarios_Servicios oPartesUsuariosServicios = new Partes_Usuarios_Servicios();
        DataTable DtPartesAux = new DataTable();
        int IndexRow = 0;
        private Equipos_Tarjetas oEquiposTarjetas = new Equipos_Tarjetas();
        private int IdTipoEquipo = 0;
        private Partes_Historial oPartesHistorial = new Partes_Historial();
        private int idPartesOperaciones = 0;
        public int idViejo, idNuevo;
        public bool asigno = false;
        Cass oCass;
        DataTable dtAplicacionesFiltradas = Tablas.DataCass;



        public enum TIPO_LLAMADA_FORM
        {
            SHOW_DIALOG = 1,
            SHOW = 2
        }
        TIPO_LLAMADA_FORM TipoLlamada;

        private void comenzarCarga()
        {
            lblNParte.Text = String.Format("Nro. de parte:");
            DtServiciosAsociados.Clear();
            DtEquiposAsociados.Clear();
            pgCircular.Start();
            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
        }

        private void cargarDatos()
        {
            DtPartesAux.Clear();
            if (IdParte == 0)
            {
                DtPartesAux = oParte.Listar(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_EQUIPO);
                if (DtPartesAux.Rows.Count > 0)
                {
                    foreach (DataRow fila in DtPartesAux.Rows)
                        DtPartes.Rows.Add(fila["id"], fila["falla"], fila["usuario"], fila["direccion"] + ", " + fila["localidad"], fila["fecha"], fila["tecnico"], fila["id_partes_estados"], fila["id_partes_operaciones"]);
                }
            }
            else
            {
                DrDatosParte = oParte.TraerParteRow(IdParte);
                if (DrDatosParte != null)
                {
                    if (DtPartes.Select("id=" + IdParte).Count() == 0)
                        DtPartes.Rows.Add(DrDatosParte["id"], DrDatosParte["solicitud"], DrDatosParte["apellido"] + " " + DrDatosParte["nombre"], DrDatosParte["calle"] + " " + DrDatosParte["altura"] + ", " + DrDatosParte["localidad"], DrDatosParte["fecha_reclamo"], DrDatosParte["tecnico"], DrDatosParte["id_partes_estados"], DrDatosParte["id_partes_operaciones"]);
                }
            }
            myDel MD = new myDel(asignarDatos);
            this.Invoke(MD, new object[] { });
            pgCircular.Stop();
        }

        private void asignarDatos()
        {

            if (DtPartes.Rows.Count > 0)
            {
                dgvPartes.DataSource = DtPartes;
                dgvPartes.Columns["id"].HeaderText = "Nro. de parte";
                dgvPartes.Columns["solicitud"].HeaderText = "Solicitud";
                dgvPartes.Columns["usuario"].HeaderText = "Usuario";
                dgvPartes.Columns["locacion"].HeaderText = "Locación";
                dgvPartes.Columns["fechareclamo"].HeaderText = "Fecha de reclamo";
                dgvPartes.Columns["tecnico"].HeaderText = "Técnico";
                dgvPartes.Columns["id_partes_estados"].Visible = false;
                dgvPartes.Columns["id_partes_operaciones"].Visible = false;
                Colorear_grilla(dgvPartes);

                lblTotal.Text = String.Format("Total de Registros: {0}", dgvEquiposAsociados.Rows.Count);
                SeleccionarFila();
                dgvPartes.FirstDisplayedScrollingRowIndex = IndexRow;
                dgvPartes.Refresh();
                dgvPartes.Rows[IndexRow].Selected = true;
                AsignarValoresServiciosEquipos();
            }

            Controles();
        }

        private void ComenzarCargaServiciosEquipos()
        {
            pgCircular.Start();
            hilo = new Thread(new ThreadStart(CargarDatosServiciosEquipos));
            hilo.Start();
        }

        private void CargarDatosServiciosEquipos()
        {
            myDel MD = new myDel(AsignarValoresServiciosEquipos);
            this.Invoke(MD, new object[] { });
            pgCircular.Stop();
        }

        private void AsignarValoresServiciosEquipos()
        {
            idPartesOperaciones = 0;
            if (dgvPartes.Rows.Count > 0)
            {
                IdParte = Convert.ToInt32(dgvPartes.SelectedRows[0].Cells["id"].Value);
                DtServiciosAsociados.Clear();
                DtEquiposAsociados.Clear();
                if (dgvPartes.SelectedRows.Count > 0)
                {
                    lblNParte.Text = String.Format("Nro. de parte: {0}", dgvPartes.SelectedRows[0].Cells["id"].Value.ToString());
                    DtServiciosAsociados = oPartesUsuariosServicios.ListarServiciosPorParte(Convert.ToInt32(dgvPartes.SelectedRows[0].Cells["id"].Value), Partes_Usuarios_Servicios.CONDICION_REQ_EQUIPOS.REQUIEREN_EQUIPOS);
                    DtEquiposAsociados = oPartesEquipos.ListarPorParte(Convert.ToInt32(dgvPartes.SelectedRows[0].Cells["id"].Value));
                    idPartesOperaciones = Convert.ToInt32(dgvPartes.SelectedRows[0].Cells["id_partes_operaciones"].Value);
                }
                else
                {
                    lblNParte.Text = String.Format("Nro. de parte: {0}", dgvPartes.Rows[0].Cells["id"].Value.ToString());
                    DtServiciosAsociados = oPartesUsuariosServicios.ListarServiciosPorParte(Convert.ToInt32(dgvPartes.Rows[0].Cells["id"].Value), Partes_Usuarios_Servicios.CONDICION_REQ_EQUIPOS.REQUIEREN_EQUIPOS);
                    DtEquiposAsociados = oPartesEquipos.ListarPorParte(Convert.ToInt32(dgvPartes.Rows[0].Cells["id"].Value));
                    idPartesOperaciones = Convert.ToInt32(dgvPartes.Rows[0].Cells["id_partes_operaciones"].Value);
                }

                dgvServiciosParte.DataSource = DtServiciosAsociados;
                for (int x = 0; x < dgvServiciosParte.Columns.Count; x++)
                    dgvServiciosParte.Columns[x].Visible = false;
                dgvServiciosParte.Columns["servicio"].Visible = true;
                dgvServiciosParte.Columns["tiposervicio"].Visible = true;
                dgvServiciosParte.Columns["servicio"].HeaderText = "Servicio";
                dgvServiciosParte.Columns["tiposervicio"].HeaderText = "Tipo de servicio";

                if (dgvServiciosParte.Rows.Count > 0)
                {
                    dgvEquiposAsociados.DataSource = DtEquiposAsociados;
                    for (int x = 0; x < dgvEquiposAsociados.Columns.Count; x++)
                        dgvEquiposAsociados.Columns[x].Visible = false;
                    dgvEquiposAsociados.Columns["tipo_equipo"].Visible = true;
                    dgvEquiposAsociados.Columns["mac"].Visible = true;
                    dgvEquiposAsociados.Columns["serie"].Visible = true;
                    dgvEquiposAsociados.Columns["NumeroTarjeta"].Visible = true;
                    dgvEquiposAsociados.Columns["id"].Visible = true;
                    dgvEquiposAsociados.Columns["parte_equipo_estado"].Visible = true;
                    dgvEquiposAsociados.Columns["servicio"].HeaderText = "Servicio";
                    dgvEquiposAsociados.Columns["tipo_equipo"].HeaderText = "Tipo de equipo";
                    dgvEquiposAsociados.Columns["mac"].HeaderText = "Mac";
                    dgvEquiposAsociados.Columns["serie"].HeaderText = "Serie";
                    dgvEquiposAsociados.Columns["NumeroTarjeta"].HeaderText = "Tarjeta asociada";
                    dgvEquiposAsociados.Columns["id"].HeaderText = "Código";
                    dgvEquiposAsociados.Columns["parte_equipo_estado"].HeaderText = "Estado";

                    FiltrarPartesEquipos();

                    if (dgvEquiposAsociados.Rows.Count > 0)
                        btnAsignarEquipo.Enabled = true;
                    else
                        btnAsignarEquipo.Enabled = false;
                    ColorearGrillaEquipos();
                }

                Controles();
            }
        }

        private void Colorear_grilla(DataGridView dgvPartes)
        {
            if (dgvPartes.Rows.Count > 0)
            {
                foreach (DataGridViewRow fila in dgvPartes.Rows)
                {
                    if (fila.Cells["id"].Value.ToString().Length > 0)
                    {
                        int EstadoParte = Convert.ToInt32(fila.Cells["id_partes_estados"].Value);

                        if (EstadoParte == Convert.ToInt32(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_EQUIPO))
                        {
                            foreach (DataGridViewCell celda in fila.Cells)
                                celda.Style.BackColor = Color.Yellow;
                        }
                        else if (EstadoParte == Convert.ToInt32(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_TECNICO))
                        {
                            foreach (DataGridViewCell celda in fila.Cells)
                                celda.Style.BackColor = Color.Tomato;
                        }
                        else if (EstadoParte == Convert.ToInt32(Partes.Partes_Estados.ASIGNADO))
                        {
                            foreach (DataGridViewCell celda in fila.Cells)
                                celda.Style.BackColor = Color.LightGreen;
                        }
                        else if (EstadoParte == Convert.ToInt32(Partes.Partes_Estados.REALIZADO))
                        {
                            foreach (DataGridViewCell celda in fila.Cells)
                                celda.Style.BackColor = Color.DarkGray;
                        }
                        else if (EstadoParte == Convert.ToInt32(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_TARJETA))
                        {
                            foreach (DataGridViewCell celda in fila.Cells)
                                celda.Style.BackColor = Color.DarkOrange;
                        }
                    }
                }
            }
        }

        private void ColorearGrillaEquipos()
        {
            if (dgvEquiposAsociados.Rows.Count > 0)
            {
                foreach (DataGridViewRow fila in dgvEquiposAsociados.Rows)
                {
                    IdEquipo = Convert.ToInt32(fila.Cells["id_equipos"].Value);
                    if (IdEquipo > 0)
                    {
                        if (dgvServiciosParte.SelectedRows[0].Cells["requiere_tarjeta"].Value.ToString() == "si" && Convert.ToInt32(fila.Cells["id_tarjeta"].Value) == 0)
                            fila.DefaultCellStyle.BackColor = Color.DarkOrange;
                        else
                            fila.DefaultCellStyle.BackColor = Color.LightGreen;
                    }
                    else
                        fila.DefaultCellStyle.BackColor = Color.Yellow;
                }
            }
        }

        private void AsignarEquipo()
        {
            IdTipoEquipo = Convert.ToInt32(dgvEquiposAsociados.SelectedRows[0].Cells["id_equipos_tipos"].Value);
            if (oEquipos.ConsultarDisponibilidad(IdTipoEquipo, 1))
            {
                int idEquipoAnterior = 0;
                if (Convert.ToInt32(dgvEquiposAsociados.SelectedRows[0].Cells["id_equipo_anterior"].Value) == 0)
                    idEquipoAnterior = Convert.ToInt32(dgvEquiposAsociados.SelectedRows[0].Cells["id_equipos"].Value);
                else
                    idEquipoAnterior = Convert.ToInt32(dgvEquiposAsociados.SelectedRows[0].Cells["id_equipo_anterior"].Value);

                frmBusquedaEquipos frmBusquedaEquipo = new frmBusquedaEquipos(Convert.ToInt32(dgvEquiposAsociados.SelectedRows[0].Cells["id"].Value), Convert.ToInt32(Partes_Equipos.TIPO_ITEM_BUSQUEDA_EQUIPO.PARTE_EQUIPO), Convert.ToInt32(dgvServiciosParte.SelectedRows[0].Cells["id_usuarios_servicios"].Value), Convert.ToInt32(dgvEquiposAsociados.SelectedRows[0].Cells["id_equipos_tipos"].Value), Convert.ToInt32(dgvServiciosParte.SelectedRows[0].Cells["id_servicios"].Value), idEquipoAnterior);
                frmPopUp frmpopup = new frmPopUp();
                frmpopup.Maximizar = true;
                frmpopup.Formulario = frmBusquedaEquipo;
                frmpopup.ShowDialog();
                if (frmBusquedaEquipo.DialogResult == DialogResult.OK)
                {
                    asigno = true;
                    comenzarCarga();

                }
            }
            else if (IdTipoEquipo == 0)
                MessageBox.Show("Faltan datos para realizar la asignación de equipos.");
            else
                MessageBox.Show("No hay stock disponible para realizar la asignación de equipos.");
        }

        private void NuevoEquipo()
        {
            if (IdParte > 0)
            {
                if (oEquipos.TraerEquiposPorTipoServicio(Convert.ToInt32(dgvServiciosParte.SelectedRows[0].Cells["id_servicios_tipos"].Value)).Rows.Count > 0)
                {
                    frmBusquedaEquipos frmBusquedaEquipo = new frmBusquedaEquipos(IdParte, Convert.ToInt32(Partes_Equipos.TIPO_ITEM_BUSQUEDA_EQUIPO.PARTE), Convert.ToInt32(dgvServiciosParte.SelectedRows[0].Cells["id_usuarios_servicios"].Value), 0, Convert.ToInt32(dgvServiciosParte.SelectedRows[0].Cells["id_servicios"].Value), 0);
                    frmPopUp frmpopup = new frmPopUp();
                    frmpopup.Maximizar = true;
                    frmpopup.Formulario = frmBusquedaEquipo;
                    frmpopup.ShowDialog();
                    if (frmBusquedaEquipo.DialogResult == DialogResult.OK)
                    {
                        asigno = true;
                        comenzarCarga();
                    }

                }
                else
                    MessageBox.Show("No hay stock disponible para realizar la asignación de equipos.");
            }
        }

        private void AsignarValores()
        {
            if (dgvEquiposAsociados.Rows.Count > 0)
            {
                if (dgvEquiposAsociados.SelectedRows.Count > 0)
                {
                    if (dgvEquiposAsociados.SelectedRows[0].Cells["requiere_tarjeta"].Value.ToString() == "si" && Convert.ToInt32(dgvEquiposAsociados.SelectedRows[0].Cells["id_tarjeta"].Value) == 0)
                        btnAsignarTarjeta.Enabled = true;
                    else
                        btnAsignarTarjeta.Enabled = false;
                }
                else
                {
                    if (dgvEquiposAsociados.Rows[0].Cells["requiere_tarjeta"].Value.ToString() == "si" && Convert.ToInt32(dgvEquiposAsociados.Rows[0].Cells["id_tarjeta"].Value) == 0)
                        btnAsignarTarjeta.Enabled = true;
                    else
                        btnAsignarTarjeta.Enabled = false;
                }
            }
        }

        private void Controles()
        {
            if (dgvPartes.Rows.Count > 0)
            {
                if (dgvServiciosParte.Rows.Count > 0)
                {
                    if (dgvEquiposAsociados.Rows.Count > 0)
                        btnAsignarEquipo.Enabled = true;
                    else
                        btnAsignarEquipo.Enabled = false;
                    btnNuevoEquipo.Enabled = true;
                }
                else
                {
                    btnNuevoEquipo.Enabled = false;
                    btnAsignarEquipo.Enabled = false;
                }
            }
            else
            {
                btnAsignarEquipo.Enabled = false;
                btnNuevoEquipo.Enabled = false;
            }
        }



        private void BusquedaEnGrillaPartes()
        {
            int Id = 0;
            if (txtBuscar.Text.Length > 0)
            {

                if (Int32.TryParse(txtBuscar.Text, out Id))
                    DtPartes.DefaultView.RowFilter = String.Format("id='" + txtBuscar.Text + "'");
                else
                    DtPartes.DefaultView.RowFilter = String.Format("usuario Like '%" + txtBuscar.Text + "%' or solicitud Like '%" + txtBuscar.Text + "%' or locacion Like '%" + txtBuscar.Text + "%'");

            }
            else
                DtPartes.DefaultView.RowFilter = "id>0";

            Colorear_grilla(dgvPartes);
        }

        private void SeleccionarFila()
        {
            foreach (DataGridViewRow fila in dgvPartes.Rows)
            {
                if (Convert.ToInt32(fila.Cells["id"].Value) == IdParte)
                    IndexRow = fila.Index;
            }
        }

        private void FiltrarPartesEquipos()
        {
            if (dgvServiciosParte.SelectedRows.Count > 0)
                DtEquiposAsociados.DefaultView.RowFilter = String.Format("id_usuarios_servicios={0}", dgvServiciosParte.SelectedRows[0].Cells["id_usuarios_servicios"].Value.ToString());
            else if (dgvServiciosParte.Rows.Count > 0)
                DtEquiposAsociados.DefaultView.RowFilter = String.Format("id_usuarios_servicios={0}", dgvServiciosParte.Rows[0].Cells["id_usuarios_servicios"].Value.ToString());
        }

        public frmAsignacionEquipos(int IdParteRecibido, TIPO_LLAMADA_FORM TipoLLamadaRecibida)
        {
            IdParte = IdParteRecibido;
            TipoLlamada = TipoLLamadaRecibida;
            InitializeComponent();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            if (TipoLlamada == TIPO_LLAMADA_FORM.SHOW)
                this.Close();
            else
                this.DialogResult = DialogResult.OK;
        }

        private void frmAsignacionEquipos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (TipoLlamada == TIPO_LLAMADA_FORM.SHOW)
                    this.Close();
                else
                    this.DialogResult = DialogResult.OK;
            }
        }

        private void frmAsignacionEquipos_Load(object sender, EventArgs e)
        {
            DtPartes.Columns.Add("Id", typeof(string));
            DtPartes.Columns.Add("Solicitud", typeof(string));
            DtPartes.Columns.Add("Usuario", typeof(string));
            DtPartes.Columns.Add("Locacion", typeof(string));
            DtPartes.Columns.Add("FechaReclamo", typeof(string));
            DtPartes.Columns.Add("Tecnico", typeof(string));
            DtPartes.Columns.Add("id_partes_estados", typeof(string));
            DtPartes.Columns.Add("id_partes_operaciones", typeof(string));
            comenzarCarga();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmBusquedaPartes frmBusquedaParte = new frmBusquedaPartes();
            bool EstaEnLista = false;
            ListaEstados.Clear();
            ListaEstados.Add(Convert.ToInt32(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_EQUIPO));
            ListaEstados.Add(Convert.ToInt32(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_TARJETA));
            ListaEstados.Add(Convert.ToInt32(Partes.Partes_Estados.ASIGNADO));

            frmBusquedaParte.AsignarListaEstados(ListaEstados);

            frmPopUp frmpopup = new frmPopUp();
            frmpopup.Formulario = frmBusquedaParte;
            frmpopup.Maximizar = false;

            if (frmpopup.ShowDialog() == DialogResult.OK)
            {
                IdParte = frmBusquedaParte.id_parte_seleccionado;
                if (IdParte > 0)
                {
                    foreach (DataGridViewRow fila in dgvPartes.Rows)
                    {
                        if (Convert.ToInt32(fila.Cells["id"].Value) == IdParte)
                        {
                            EstaEnLista = true;
                            break;
                        }
                    }
                    //MessageBox.Show(DtPartes.Select(String.Format("id={0}", IdParte)).Length.ToString());
                    if (EstaEnLista)
                        MessageBox.Show("El parte ya se encuentra en la grilla.");
                    else
                        comenzarCarga();
                }

            }
        }

        private void btnAsignarEquipo_Click(object sender, EventArgs e)
        {

            if (dgvEquiposAsociados.SelectedRows.Count > 0)
            {
                if (Convert.ToInt32(dgvEquiposAsociados.SelectedRows[0].Cells["id_equipos"].Value) == 0)
                    AsignarEquipo();
                else
                    MessageBox.Show("Ya tiene un equipo asignado, para agregar un nuevo equipo, debe hacer click sobre el boton 'NUEVO EQUIPO'", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnNuevoEquipo_Click(object sender, EventArgs e)
        {
            NuevoEquipo();
        }

        private void dgvEquiposAsociados_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            AsignarValores();
        }

        private void dgvPartes_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            ComenzarCargaServiciosEquipos();

        }

        private void dgvPartes_Sorted(object sender, EventArgs e)
        {
            Colorear_grilla(dgvPartes);
        }

        private void dgvEquiposAsociados_Sorted(object sender, EventArgs e)
        {
            ColorearGrillaEquipos();
        }

        private void btnAsignarTarjeta_Click(object sender, EventArgs e)
        {
            int idServicio;
            int idAppExterna;
            oCass = new Cass(Convert.ToInt32(dtAplicacionesFiltradas.Rows[0]["Id"]));
            if (Convert.ToInt32(dgvEquiposAsociados.SelectedRows[0].Cells["id_equipos"].Value) != 0)
            {
                if (dgvServiciosParte.SelectedRows[0].Cells["requiere_tarjeta"].Value.ToString() == "si" || dgvServiciosParte.SelectedRows[0].Cells["requiere_tarjeta"].Value.ToString() == "SI")
                {
                    int IdTarjetaAnterior;
                    Aplicaciones_Externas oAppExternas = new Aplicaciones_Externas();
                    idServicio = Convert.ToInt32(dgvEquiposAsociados.SelectedRows[0].Cells["id_servicios"].Value);
                    frmBusquedaTarjetasEquipos frmBusquedaTarjetas = new frmBusquedaTarjetasEquipos(Convert.ToInt32(dgvEquiposAsociados.SelectedRows[0].Cells["id_equipos_tipos"].Value), Convert.ToInt32(Equipos_Tarjetas.Tarjetas_Estados.DISPONIBLE));
                    frmBusquedaTarjetas.id_usuario_actual = Usuarios.CurrentUsuario.Id;
                    frmPopUp frmpopup = new frmPopUp();
                    frmpopup.Maximizar = false;
                    frmpopup.Formulario = frmBusquedaTarjetas;
                    frmpopup.ShowDialog();
                    if (frmBusquedaTarjetas.DialogResult == DialogResult.OK)
                    {
                        if (oEquiposTarjetas.verificarTarjetaAsignada(frmBusquedaTarjetas.IdTarjeta))
                            MessageBox.Show("Tarjeta ya asignada a un equipo, seleccione otra por favor.");
                        else
                        {
                            IdTarjetaAnterior = Convert.ToInt32(dgvEquiposAsociados.SelectedRows[0].Cells["id_tarjeta"].Value);
                            oEquiposTarjetas.AsignarTarjetaEquipo(Convert.ToInt32(dgvEquiposAsociados.SelectedRows[0].Cells["id_equipos"].Value), frmBusquedaTarjetas.IdTarjeta);
                            oEquiposTarjetas.AsignarTarjetaParteEquipo(Convert.ToInt32(dgvEquiposAsociados.SelectedRows[0].Cells["id"].Value), frmBusquedaTarjetas.IdTarjeta);
                            oEquiposTarjetas.CambiarEstadoTarjeta(frmBusquedaTarjetas.IdTarjeta, Convert.ToInt32(Equipos_Tarjetas.Tarjetas_Estados.ENTREGADA));
                            if (IdTarjetaAnterior != 0)
                                oEquiposTarjetas.CambiarEstadoTarjeta(IdTarjetaAnterior, Convert.ToInt32(Equipos_Tarjetas.Tarjetas_Estados.CON_FALLA));

                            oParte.SetearEstadoParte(Convert.ToInt32(dgvPartes.SelectedRows[0].Cells["id"].Value), 0, 0, DateTime.Now, 0, 0, "");
                            oPartesHistorial.Id_Partes_Estados = Convert.ToInt32(Partes.Partes_Estados.ASIGNADO);
                            oPartesHistorial.Id_Parte = Convert.ToInt32(dgvPartes.SelectedRows[0].Cells["id"].Value);
                            oPartesHistorial.Id_Usuarios = Convert.ToInt32(dgvServiciosParte.Rows[0].Cells["id_usuarios"].Value);
                            oPartesHistorial.Id_Personal = Personal.Id_Login;
                            oPartesHistorial.Fecha_Movimiento = DateTime.Now;
                            oPartesHistorial.Id_area = Personal.Id_Area;
                            oPartesHistorial.Detalles = "TARJETA ASIGNADA.";
                            oPartesHistorial.GuardarNuevoDetalle(oPartesHistorial);
                            idAppExterna = Convert.ToInt32(DtServiciosAsociados.Rows[0]["id_app_ext"]);
                            DataTable dtDatosAppExterna = oAppExternas.Listar(idAppExterna);
                            if (dtDatosAppExterna.Rows.Count > 0)
                            {
                                if (dtDatosAppExterna.Rows[0]["nombre"].ToString().ToLower().Equals("cass"))
                                {
                                    Cass oCass = new Cass(idAppExterna);
                                    DataView dv = Tablas.DataServicios.DefaultView;
                                    dv.RowFilter = "id=" + Convert.ToInt32(dgvEquiposAsociados.SelectedRows[0].Cells["id_servicios"].Value);
                                    DataTable dtDatosServicios = dv.ToTable();

                                }
                            }
                        }

                        comenzarCarga();
                    }
                }
                else
                    MessageBox.Show("Este equipo no requiere asignación de tarjeta.");
            }
            else
                MessageBox.Show("Debe asignar un equipo antes de agregar una tarjeta.");
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BusquedaEnGrillaPartes();
        }

        private void dgvEquiposAsociados_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                idViejo = Convert.ToInt32(dgvEquiposAsociados.Rows[0].Cells["id_equipo_anterior"].Value);
                idNuevo = Convert.ToInt32(dgvEquiposAsociados.Rows[0].Cells["id_equipo"].Value);
                asigno = true;

            }
            catch
            {

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvServiciosParte_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            FiltrarPartesEquipos();
            if (dgvEquiposAsociados.Rows.Count > 0)
                btnAsignarEquipo.Enabled = true;
            else
                btnAsignarEquipo.Enabled = false;
        }
    }
}
/*180919-10:25
líneas modificadas: 495
*/
