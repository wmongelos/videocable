using CapaNegocios;
using CapaPresentacion.Impresiones;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Partes_Trabajo
{
    public partial class frmVistaHistorial : Form
    {
        private GPS oGps = new GPS();
        private DataTable Dt { set; get; } = null;
        private static frmVistaHistorial instancia;
        private Form formPrevio;
        private DataTable dtObservaciones = new DataTable();
        private int Agenda = 0;
        private Configuracion oConfig = new Configuracion();
        private Partes oPartes = new Partes();
        private Partes_Historial oPartesHistorial = new Partes_Historial();
        private int ParteSelec = 0;
        private Partes_Equipos oParteEquipo = new Partes_Equipos();
        private Equipos oEquipos = new Equipos();
        private Thread hilo;
        private bool todoSeleccionado;
        private String Impresora;

        private frmVistaHistorial(Form fr)
        {
            InitializeComponent();
            formPrevio = fr;
            Agenda = oConfig.GetValor_N("Agenda_Trabajo");
        }

        public static frmVistaHistorial Instancia(Form fr)
        {
            if (instancia == null)
                instancia = new frmVistaHistorial(fr);
            return instancia;
        }

        public void CargarDataTableVista(DataTable dt)
        {
            Dt = dt;
            DataColumn colSeleccion = new DataColumn("colSeleccion", typeof(bool));
            colSeleccion.DefaultValue = false;
            Dt.Columns.Add(colSeleccion);
            dgvPartes.DataSource = Dt;
            dgvPartes.ClearSelection();
            FormatearDGV();
            CargarCheckedListBox();
            lblTotal.Text = String.Format("Total de Registros: {0}", dgvPartes.Rows.Count);
        }

        public void CargarBuscadorVista(string texto)
        {
            txtBuscador.Text = texto.Trim();
        }

        public static void BorrarInstancia()
        {
            if (instancia != null)
            {
                instancia.Dispose();
                instancia = null;
            }
        }

        private void FormatearDGV()
        {
            dgvPartes.Columns["id_parte"].Visible = true;
            dgvPartes.Columns["id_parte_usuarios_servicio"].Visible = false;
            dgvPartes.Columns["id_usuarios_servicios"].Visible = false;
            dgvPartes.Columns["id_usuarios_locaciones"].Visible = false;
            dgvPartes.Columns["partes_operaciones"].Visible = false;
            dgvPartes.Columns["fecha_programado"].Visible = false;
            dgvPartes.Columns["fecha_realizado"].Visible = false;
            dgvPartes.Columns["zona"].Visible = false;
            dgvPartes.Columns["localidad"].Visible = false;
            dgvPartes.Columns["calle"].Visible = false;
            dgvPartes.Columns["altura"].Visible = false;
            dgvPartes.Columns["personal"].Visible = false;
            dgvPartes.Columns["area"].Visible = false;
            dgvPartes.Columns["codigo_usuario"].Visible = true;
            dgvPartes.Columns["usuario"].Visible = true;
            dgvPartes.Columns["servicio"].Visible = true;
            dgvPartes.Columns["parte_falla"].Visible = true;
            dgvPartes.Columns["fecha_reclamo"].Visible = true;
            dgvPartes.Columns["estado"].Visible = true;
            dgvPartes.Columns["id_partes_estados"].Visible = false;
            dgvPartes.Columns["id_usuarios"].Visible = false;
            dgvPartes.Columns["requiere_equipo"].Visible = false;
            dgvPartes.Columns["colSeleccion"].Visible = true;

            dgvPartes.Columns["id_parte"].Tag = true;
            dgvPartes.Columns["id_parte_usuarios_servicio"].Tag = false;
            dgvPartes.Columns["id_usuarios_servicios"].Tag = false;
            dgvPartes.Columns["id_usuarios_locaciones"].Tag = false;
            dgvPartes.Columns["partes_operaciones"].Tag = true;
            dgvPartes.Columns["fecha_programado"].Tag = true;
            dgvPartes.Columns["fecha_realizado"].Tag = true;
            dgvPartes.Columns["zona"].Tag = true;
            dgvPartes.Columns["localidad"].Tag = true;
            dgvPartes.Columns["calle"].Tag = true;
            dgvPartes.Columns["altura"].Tag = true;
            dgvPartes.Columns["personal"].Tag = true;
            dgvPartes.Columns["area"].Tag = true;
            dgvPartes.Columns["codigo_usuario"].Tag = true;
            dgvPartes.Columns["usuario"].Tag = true;
            dgvPartes.Columns["servicio"].Tag = true;
            dgvPartes.Columns["parte_falla"].Tag = true;
            dgvPartes.Columns["fecha_reclamo"].Tag = true;
            dgvPartes.Columns["estado"].Tag = true;
            dgvPartes.Columns["id_partes_estados"].Tag = false;
            dgvPartes.Columns["id_usuarios"].Tag = false;
            dgvPartes.Columns["requiere_equipo"].Tag = false;
            dgvPartes.Columns["colSeleccion"].Tag = true;

            dgvPartes.Columns["id_parte"].HeaderText = "Parte";
            dgvPartes.Columns["partes_operaciones"].HeaderText = "Operacion";
            dgvPartes.Columns["fecha_programado"].HeaderText = "Fecha programado";
            dgvPartes.Columns["fecha_realizado"].HeaderText = "Fecha realizado";
            dgvPartes.Columns["zona"].HeaderText = "Zona";
            dgvPartes.Columns["localidad"].HeaderText = "Localidad";
            dgvPartes.Columns["calle"].HeaderText = "Calle";
            dgvPartes.Columns["altura"].HeaderText = "Altura";
            dgvPartes.Columns["personal"].HeaderText = "Personal";
            dgvPartes.Columns["area"].HeaderText = "Area";
            dgvPartes.Columns["codigo_usuario"].HeaderText = "Codigo usuario";
            dgvPartes.Columns["usuario"].HeaderText = "Usuario";
            dgvPartes.Columns["servicio"].HeaderText = "Servicio";
            dgvPartes.Columns["parte_falla"].HeaderText = "Falla";
            dgvPartes.Columns["fecha_reclamo"].HeaderText = "Fecha reclamo";
            dgvPartes.Columns["estado"].HeaderText = "Estado";
            dgvPartes.Columns["colSeleccion"].HeaderText = "Seleccionar";

            dgvPartes.Columns["colSeleccion"].ReadOnly = false;

            dgvPartes.ColumnHeadersDefaultCellStyle.Padding = new Padding(5, 5, 5, 5);
        }

        private void CargarCheckedListBox()
        {
            foreach (DataGridViewColumn campo in dgvPartes.Columns)
                if (Convert.ToBoolean(campo.Tag))
                    checkedListBoxCampos.Items.Add(campo.Name, campo.Visible);

            checkedListBoxCampos.ItemCheck += new ItemCheckEventHandler(checkedListBoxCampos_ItemCheck);
        }

        private void CargarObservacion()
        {
            try
            {
                if (dgvPartes.SelectedRows.Count > 0)
                {
                    dtObservaciones = oGps.ListarObservaciones(Convert.ToInt32(dgvPartes.SelectedRows[0].Cells["id_parte"].Value));
                    dgvObservaciones.DataSource = dtObservaciones;
                    dgvObservaciones.Columns["numord"].Visible = false;
                    dgvObservaciones.Columns["cuando"].Width = 120;
                    dgvObservaciones.Columns["area"].Width = 120;
                    dgvObservaciones.Columns["nombre"].Width = 200;
                    dgvObservaciones.ColumnHeadersDefaultCellStyle.Padding = new Padding(5, 5, 5, 5);
                    lblObservacionesGPS.Text = string.Format("GPS Observaciones: Parte[{0}]", ParteSelec);
                }
            }
            catch (Exception) { }
        }

        private void GestionarBotones()
        {
            if (dgvPartes.SelectedRows.Count > 0)
            {
                int idParteEstado = Convert.ToInt32(dgvPartes.SelectedRows[0].Cells["id_partes_estados"].Value);
                string requireEquipo = dgvPartes.SelectedRows[0].Cells["requiere_equipo"].Value.ToString();

                if (idParteEstado == Convert.ToInt32(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_TECNICO))
                {
                    btnAsignarTecnico.Enabled = true;
                    btnAsignarEquipo.Enabled = false;
                    btnAsignarTarjeta.Enabled = false;
                    btnConfirmar.Enabled = true;
                }
                else if (idParteEstado == Convert.ToInt32(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_EQUIPO))
                {
                    btnAsignarEquipo.Enabled = true;
                    btnAsignarTecnico.Enabled = false;
                    btnAsignarTarjeta.Enabled = false;
                    btnConfirmar.Enabled = false;
                }
                else if (idParteEstado == Convert.ToInt32(Partes.Partes_Estados.ASIGNADO))
                {
                    if (requireEquipo.Equals("SI"))
                        btnAsignarEquipo.Enabled = true;
                    else
                        btnAsignarEquipo.Enabled = false;
                    btnAsignarTecnico.Enabled = false;
                    btnAsignarTarjeta.Enabled = false;
                    btnConfirmar.Enabled = true;
                }
                else if (idParteEstado == Convert.ToInt32(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_TARJETA))
                {
                    btnAsignarTecnico.Enabled = false;
                    btnAsignarEquipo.Enabled = false;
                    btnAsignarTarjeta.Enabled = true;
                    btnConfirmar.Enabled = false;
                }
                else if (idParteEstado == Convert.ToInt32(Partes.Partes_Estados.REALIZADO))
                {
                    btnAsignarEquipo.Enabled = false;
                    btnAsignarTarjeta.Enabled = false;
                    btnAsignarTecnico.Enabled = false;
                    btnConfirmar.Enabled = false;
                }
                else
                {
                    btnAsignarEquipo.Enabled = false;
                    btnAsignarTecnico.Enabled = false;
                    btnAsignarTarjeta.Enabled = false;
                    btnConfirmar.Enabled = false;
                }
            }
            else
            {
                btnAsignarEquipo.Enabled = false;
                btnAsignarTecnico.Enabled = false;
                btnAsignarTarjeta.Enabled = false;
                btnConfirmar.Enabled = false;
            }
        }

        private void AsignarTecnico()
        {
            DataTable dtElegidos = new DataTable();
            DataView dvElegidos = Dt.DefaultView;
            dvElegidos.RowFilter = "colSeleccion = true";
            dtElegidos = dvElegidos.ToTable();

            if (Agenda == Convert.ToInt32(Agenda_Encabezado.Uso_agenda.NO_TRABAJA_CON_AGENDA))
            {
                int IdTecnico = 0;
                int IdPartesEstados = 0;
                frmBusquedaTecnicos frmTecnicos = new frmBusquedaTecnicos();
                frmPopUp frmpopup = new frmPopUp();
                frmpopup.Maximizar = false;
                frmpopup.Formulario = frmTecnicos;

                if (frmpopup.ShowDialog() == DialogResult.OK)
                {
                    IdTecnico = frmTecnicos.tecnicoSel;
                    try
                    {
                        foreach (DataRow item in dtElegidos.Rows)
                        {
                            oPartes.AsignarTecnico(Convert.ToInt32(item["id_parte"]), IdTecnico, Convert.ToInt32(item["id_partes_estados"]));
                            IdPartesEstados = oPartes.SetearEstadoParte(Convert.ToInt32(item["id_parte"]), 0, 0, DateTime.Now, 0, 0, "");
                            oPartesHistorial.Id_Partes_Estados = IdPartesEstados;
                            oPartesHistorial.Id_Parte = Convert.ToInt32(item["id_parte"]);
                            oPartesHistorial.Id_Usuarios = Convert.ToInt32(dgvPartes.SelectedRows[0].Cells["id_usuarios"].Value);
                            oPartesHistorial.Id_Personal = Personal.Id_Login;
                            oPartesHistorial.Fecha_Movimiento = DateTime.Now;
                            oPartesHistorial.Id_area = Personal.Id_Area;
                            oPartesHistorial.Detalles = "TÉCNICO ASIGNADO.";
                            oPartesHistorial.GuardarNuevoDetalle(oPartesHistorial);
                        }

                        MessageBox.Show("Tecnico asignado correctamente", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception c)
                    {
                        MessageBox.Show("Error en la asignación de técnicos.: "+ c.ToString());
                    }
                    ActualizarDataTable();
                }
            }
        }

        private void AsignarEquipo()
        {
            List<int> listaTiposEquipos = new List<int>();
            DataTable dtPartesEquipos = new DataTable();
            int equiposDisponibles = 0;

            dtPartesEquipos = oParteEquipo.ListarPorParte(ParteSelec);

            if (dtPartesEquipos.Rows.Count > 0)
            {
                foreach (DataRow parteEquipo in dtPartesEquipos.Rows)
                {
                    if (!listaTiposEquipos.Contains(Convert.ToInt32(parteEquipo["id_equipos_tipos"])))
                        listaTiposEquipos.Add(Convert.ToInt32(parteEquipo["id_equipos_tipos"]));
                }

                equiposDisponibles = 0;
                foreach (int idTipoEquipo in listaTiposEquipos)
                {
                    if (oEquipos.ConsultarDisponibilidad(idTipoEquipo, 1))
                        equiposDisponibles++;
                }
            }
            else
            {
                equiposDisponibles++;
            }

            if (equiposDisponibles == 0)
                MessageBox.Show("No hay stock disponible.");
            else
            {
                frmAsignacionEquipos frmAsignacion = new frmAsignacionEquipos(ParteSelec, frmAsignacionEquipos.TIPO_LLAMADA_FORM.SHOW_DIALOG);
                frmPopUp frmpopup = new frmPopUp();
                frmpopup.Maximizar = false;
                frmpopup.Formulario = frmAsignacion;
                frmpopup.ShowDialog();
                if (frmAsignacion.DialogResult == DialogResult.OK)
                {
                    ActualizarDataTable();
                }
                //agregar el cambio al historial de partes
            }
        }

        private void AsignarTarjeta()
        {
            if (Convert.ToInt32(dgvPartes.SelectedRows[0].Cells["id_partes_estados"].Value) > 0)
            {
                frmAsignacionEquipos frmAsignacion = new frmAsignacionEquipos(ParteSelec, frmAsignacionEquipos.TIPO_LLAMADA_FORM.SHOW_DIALOG);
                frmPopUp frmpopup = new frmPopUp();
                frmpopup.Maximizar = false;
                frmpopup.Formulario = frmAsignacion;
                frmpopup.ShowDialog();
                if (frmAsignacion.DialogResult == DialogResult.OK)
                {
                    ActualizarDataTable();
                }
                //agregar el cambio al historial de partes
            }
        }

        private void Reprogramar()
        {
            if (dgvPartes.Rows.Count > 0)
            {
                List<int> listaIdsPartesSeleccionados = new List<int>();
                List<Partes_Historial> listaPartesSeleccionados = new List<Partes_Historial>();
                frmActualizarFechaProgramado frmActualizarProgramado = new frmActualizarFechaProgramado();

                foreach (DataGridViewRow fila in dgvPartes.Rows)
                {
                    if (fila.Cells["colSeleccion"].Value != DBNull.Value)
                    {
                        if (Convert.ToBoolean(fila.Cells["colSeleccion"].Value))
                        {
                            if (Convert.ToInt32(fila.Cells["id_partes_estados"].Value) != -1)
                            {
                                if (Convert.ToInt32(fila.Cells["id_partes_estados"].Value) != Convert.ToInt32(CapaNegocios.Partes.Partes_Estados.REALIZADO) && Convert.ToInt32(fila.Cells["id_partes_estados"].Value) != Convert.ToInt32(CapaNegocios.Partes.Partes_Estados.ANULADO))
                                {
                                    Partes_Historial oParteHistorial = new Partes_Historial();
                                    oParteHistorial.Id_Parte = Convert.ToInt32(fila.Cells["id_parte"].Value);
                                    oParteHistorial.Id_Personal = Personal.Id_Login;
                                    oParteHistorial.Id_area = Personal.Id_Area;
                                    oParteHistorial.Id_Usuarios = Convert.ToInt32(fila.Cells["id_usuarios"].Value);
                                    oParteHistorial.Id_Partes_Estados = Convert.ToInt32(fila.Cells["id_partes_estados"].Value);
                                    oParteHistorial.Fecha_Movimiento = DateTime.Now;
                                    listaPartesSeleccionados.Add(oParteHistorial);
                                }
                            }
                        }
                    }
                }

                if (listaPartesSeleccionados.Count > 0)
                {
                    if (Agenda == Convert.ToInt32(Agenda_Encabezado.Uso_agenda.NO_TRABAJA_CON_AGENDA))
                    {
                        frmPopUp frmpopup = new frmPopUp();
                        frmpopup.Maximizar = false;
                        frmActualizarProgramado.ListaPartesHistorial = listaPartesSeleccionados;
                        frmpopup.Formulario = frmActualizarProgramado;
                        frmpopup.ShowDialog();

                        if (frmpopup.DialogResult == DialogResult.OK)
                        {
                            MessageBox.Show("Cambios realizados correctamente", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ActualizarDataTable();
                        }
                    }
                }
                else
                    MessageBox.Show("No se han seleccionado partes, o los partes seleccionados ya se encuentran realizados", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Grilla vascia");
        }

        private void Confirmar()
        {
            if (Convert.ToInt32(dgvPartes.SelectedRows[0].Cells["id_partes_estados"].Value) > 0)
            {
                frmConfirmaParte frm = new frmConfirmaParte(Convert.ToInt32(ParteSelec), frmConfirmaParte.FUNCIONALIDAD.CONFIRMAR_ANULAR);
                frm.WindowState = FormWindowState.Maximized;
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    ActualizarDataTable();
                }
            }
        }

        private void MostrarHistorial()
        {
            if (dgvPartes.SelectedRows.Count > 0)
            {
                frmPartesSeguimientoHistorial frmPartesSeguimiento = new frmPartesSeguimientoHistorial();
                frmPartesSeguimiento.oParte.Id = Convert.ToInt32(ParteSelec);
                frmPopUp frmpopup = new frmPopUp();
                frmpopup.Maximizar = false;
                frmpopup.Formulario = frmPartesSeguimiento;
                frmpopup.ShowDialog();
            }
        }

        private void MostrarServicios()
        {
            if (dgvPartes.SelectedRows.Count > 0)
            {
                frmServiciosDelParte frmServiciosParte = new frmServiciosDelParte(ParteSelec);
                frmPopUp frmpopup = new frmPopUp();
                frmpopup.Maximizar = false;
                frmpopup.Formulario = frmServiciosParte;
                frmpopup.ShowDialog();
            }
        }

        private void ActualizarParteSeleccionado(int index)
        {
            ParteSelec = Convert.ToInt32(dgvPartes.Rows[index].Cells["id_parte"].Value);
        }

        private void Anular()
        {
            DataTable dtElegidos = new DataTable();
            DataView dvElegidos = Dt.DefaultView;
            dvElegidos.RowFilter = "colSeleccion = true";
            dtElegidos = dvElegidos.ToTable();

            foreach (DataRow item in dtElegidos.Rows)
            {
                if(Convert.ToInt32(item["id_partes_estados"])!=(int)Partes.Partes_Estados.REALIZADO)
                    oPartes.AnularParte((Convert.ToInt32(item["id_parte"])));
            }
            dvElegidos.RowFilter = "";
            ActualizarDataTable();


        }

        private void ImprimirPartes(String PrintName)
        {
            Impresora = PrintName;
            ImpresionLote();
        }
        private void ImpresionLote()
        {
            int cantErrores = 0;
            string excepcion = "";
            Impresion print = new Impresion();
            DataTable dtElegidos = new DataTable();
            DataView dvElegidos = Dt.DefaultView;
            dvElegidos.RowFilter = "colSeleccion = true";
            dtElegidos = dvElegidos.ToTable();
            List<int> listaYaImpresos = new List<int>();
            foreach (DataRow fila in dtElegidos.Rows)
            {
                if (!listaYaImpresos.Contains(Convert.ToInt32(fila["id_parte"])))
                {
                    if (print.ImprimirPartes(Convert.ToInt32(fila["id_parte"]), Impresora) == false)
                       break;
                    listaYaImpresos.Add(Convert.ToInt32(fila["id_parte"]));
                }
            }
            if (cantErrores > 0)
                MessageBox.Show("Algunos partes no se imprimieron.: \n " + excepcion);
            dvElegidos.RowFilter = "";

        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgvPartes.Rows.Count > 0)
            {
                Tools tools = new Tools();
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    tools.ExportToExcel(dgvPartes, "Partes Historial");
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al exportar a excel");
                }
                finally { this.Cursor = Cursors.Default; }
            }
            else
                MessageBox.Show("Grilla vacia");
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (pdSelectPrinter.ShowDialog() == DialogResult.OK)
                ImprimirPartes(pdSelectPrinter.PrinterSettings.PrinterName.ToString());
        }

        private void txtBuscador_TextChanged(object sender, EventArgs e)
        {

            Dt.DefaultView.RowFilter = String.Format("servicio like '%{0}%' or usuario like '%{0}%' " +
                "or parte_falla like '%{0}%' or partes_operaciones like '%{0}%' or codigo_usuario like '%{0}%'" +
                "or estado like '%{0}%' or zona like '%{0}%' or localidad like '%{0}%' or personal like '%{0}%' " +
                "or area like '%{0}%' or calle like '%{0}%'", txtBuscador.Text);

            lblTotal.Text = String.Format("Total de Registros: {0}", dgvPartes.Rows.Count);
        }

        private void checkedListBoxCampos_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            dgvPartes.Columns[checkedListBoxCampos.SelectedItem.ToString()].Visible = !checkedListBoxCampos.GetItemChecked(checkedListBoxCampos.SelectedIndex);
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            frmMain frMain = frmMain.Instance();
            frMain.openForm(formPrevio);
            formPrevio.Focus();
        }

        private void frmVistaHistorial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                frmMain frMain = frmMain.Instance();
                frMain.openForm(formPrevio);
                formPrevio.Focus();
            }
        }

        private void dgvPartes_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            ActualizarParteSeleccionado(e.RowIndex);
            
            //if(oConfig.GetValor_N("Agenda_Trabajo") == 1 && (!Debugger.IsAttached || Personal.Id_Login!=1))
            //    CargarObservacion();

            if(oConfig.GetValor_N("ParteTrabajaAppExterna") == 1 && (!Debugger.IsAttached || Personal.Id_Login != 1))
                CargarObservacion();
            try
            {
                GestionarBotones();

            }
            catch (Exception)
            {


            }
        }

        private void btnAsignarTecnico_Click(object sender, EventArgs e)
        {
            AsignarTecnico();
        }

        private void btnAsignarEquipo_Click(object sender, EventArgs e)
        {
            AsignarEquipo();
        }

        private void btnAsignarTarjeta_Click(object sender, EventArgs e)
        {
            AsignarTarjeta();
        }

        private void btnReprogramar_Click(object sender, EventArgs e)
        {
            Reprogramar();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            Confirmar();
        }

        private void btnSeguimiento_Click(object sender, EventArgs e)
        {
            MostrarHistorial();
        }

        private void btnVerServicios_Click(object sender, EventArgs e)
        {
            MostrarServicios();
        }

        private void dgvPartes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (Convert.ToDateTime(dgvPartes.Rows[e.RowIndex].Cells["fecha_realizado"].Value).Date >
                Convert.ToDateTime(dgvPartes.Rows[e.RowIndex].Cells["fecha_programado"].Value).Date)
            {
                e.CellStyle.BackColor = Color.Tomato;
            }
        }

        private void dgvPartes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void ActualizarDataTable()
        {
            this.Cursor = Cursors.WaitCursor;
            frmConsultaHistorial frmconulta = new frmConsultaHistorial();
            frmconulta.ReCargarDataTable(txtBuscador.Text);
            this.Cursor = Cursors.Default;
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            Anular();
        }

        private void dgvPartes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPartes.Columns[e.ColumnIndex].HeaderText == "Seleccionar")
            {
                if (e.RowIndex == -1)
                {
                    todoSeleccionado = !todoSeleccionado;
                    foreach (DataRow item in this.Dt.Rows)
                        item["colSeleccion"] = todoSeleccionado;
                }
                else
                    dgvPartes.Rows[e.RowIndex].Cells["colSeleccion"].Value = !Convert.ToBoolean(dgvPartes.Rows[e.RowIndex].Cells["colSeleccion"].Value);
            }
        }
    }
}
