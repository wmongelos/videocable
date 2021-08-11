using CapaNegocios;
using CapaPresentacion.Impresiones;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Partes_Trabajo
{
    public partial class frmAgenda : Form
    {
        #region PROPIEDADES
        private DataTable dt_horarios = new DataTable();
        private DataTable dt_tecnicos = new DataTable();
        private DataRow[] partes;
        private DataTable dt_partes = new DataTable();
        private DataTable dt_tecnicos_grilla = new DataTable();
        private dsInformes oDs = new dsInformes();
        private Agenda_Encabezado agenda = new Agenda_Encabezado();
        private Personal tecnico = new Personal();
        private Partes oParte = new Partes();
        private Equipos oEquipos = new Equipos();
        private Servicios oServicios = new Servicios();
        private Partes_Equipos oPartesEquipos = new Partes_Equipos();
        private List<Int32> lista_estados_enviar = new List<Int32>();
        private Thread hilo;
        private int id_encabezadodtpk = 0;
        private int id_parte = 0;//toma id de parte, ya sea que provenga de otro form o se asigne desde este mismo
        private int id_seleccion = -1;//toma el indice de la posicion del tecnico en la grilla dgv, está declarado con -1 ya que el índice puede ser 0
        private int id_encabezado_eliminar = 0;
        private bool reasignacion = false;
        private string hora_eliminar = "";
        private int id_tecnico_anterior = 0;
        public delegate void myDel();
        List<Int32> lista_id_partes = new List<Int32>();
        private Partes_Historial oPartesHistorial = new Partes_Historial();
        private int cantidadPartesPendientesFechaSeleccionada = 0;
        private int cantidadPartesPendientesTotal = 0, cantPartesSinAsignar = 0;
        public Boolean vieneDeParte = false;
        public bool reprogramarParte = false;

        private static frmAgenda _instancia = null;
        private static bool formAbierto;
        public static bool pendienteDeAbrir;
        #endregion

        #region[METODOS CREADOS]

        public void ArmarColsDataTables()
        {
            dt_horarios = new DataTable();
            dt_partes = new DataTable();
            dt_tecnicos = new DataTable();
            dt_tecnicos_grilla = new DataTable();
            dt_horarios.Columns.Add("id");
            dt_horarios.Columns.Add("Hora");
            dt_horarios.Columns.Add("N_Parte");
            dt_horarios.Columns.Add("Usuario");
            dt_horarios.Columns.Add("Falla");
            dt_horarios.Columns.Add("Detalles");
            dt_horarios.Columns.Add("Locacion");
            dt_horarios.Columns.Add("EstadoParte");
            dt_horarios.Columns.Add("reservado");
            dt_horarios.Columns.Add("Seleccion", typeof(bool));

            dt_partes.Columns.Add("Id_Parte");
            dt_partes.Columns.Add("falla");

            dt_partes.Columns.Add("Asignado");
            dt_partes.Columns.Add("Usuario");
            dt_partes.Columns.Add("Calle");
            dt_partes.Columns.Add("Altura");
            dt_partes.Columns.Add("Piso");
            dt_partes.Columns.Add("Depto");
            dt_partes.Columns.Add("Tecnico");
            dt_partes.Columns.Add("Id_Usuarios_Servicios");
            dt_partes.Columns.Add("Id_Usuarios");
            dt_partes.Columns.Add("Id_Servicios");
            dt_partes.Columns.Add("Id_partes_operaciones");
            dt_partes.Columns.Add("Id_partes_estados");
            dt_partes.Columns.Add("fecha_programado", typeof(DateTime));

            dt_tecnicos_grilla.Columns.Add("Codigo");
            dt_tecnicos_grilla.Columns.Add("Nombre");
            dt_tecnicos_grilla.Columns.Add("N_Partes");
        }

        public void comenzarCarga()
        {
            pgCircular.Start();
            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.IsBackground = true;
            hilo.Start();
        }

        public void cargarDatos()
        {
            try
            {
                CargarGrillaTecnicos();

                if (lista_id_partes.Count > 0)
                    CargarGrillaPartes();

                myDel MD = new myDel(asignarDatos);

                this.Invoke(MD, new object[] { });

                pgCircular.Stop();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Información" + ex.Message);
            }
        }

        public void CargarGrillaTecnicos()
        {
            dt_tecnicos = agenda.Buscar_tecnico();

            if (dt_tecnicos.Rows.Count > 0)
            {
                DataRow fila;
                int x = 0;
                DataTable dt_encabezado = new DataTable();
                foreach (DataRow row in dt_tecnicos.Rows)
                {
                    fila = dt_tecnicos_grilla.NewRow();
                    fila["Codigo"] = row["Id"].ToString();
                    fila["Nombre"] = row["Nombre"].ToString();
                    dt_encabezado = agenda.Buscar_encabezado(row, dtpFecha.Value.Date.ToString("yyyy/MM/dd"));
                    if (dt_encabezado.Rows.Count > 0)
                    {
                        int cant_partes = agenda.Buscar_cant_partes(dt_encabezado).Rows.Count;
                        if (cant_partes > 0)
                            fila["N_Partes"] = cant_partes;
                        else
                        {
                            fila["N_Partes"] = "";
                            fila["N_Partes"] = "0";
                        }
                    }
                    else
                    {
                        fila["N_Partes"] = "";
                        fila["N_Partes"] = "0";
                    }
                    dt_tecnicos_grilla.Rows.Add(fila);
                    x++;
                }
            }
        }

        public void CargarGrillaPartes()
        {
            if (lista_id_partes.Count > 0)
            {
                DataRow fila_parte;
                DataRow fila_parte_db;

                foreach (int id_parte in lista_id_partes)
                {
                    fila_parte = dt_partes.NewRow();
                    fila_parte_db = agenda.TraerDatosParte(id_parte);
                    if (Convert.ToInt32(fila_parte_db["Id_Parte"]) > 0)
                    {
                        fila_parte["Id_Parte"] = fila_parte_db["Id_Parte"];

                        if (Convert.ToInt32(fila_parte_db["Id_Partes_Estados"]) == Convert.ToInt32(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_TECNICO))
                            fila_parte["Asignado"] = "NO";
                        else
                            fila_parte["Asignado"] = "SI";

                        fila_parte["falla"] = fila_parte_db["falla"];

                        fila_parte["Usuario"] = fila_parte_db["Usuario"];
                        fila_parte["Calle"] = fila_parte_db["Calle"];
                        fila_parte["Altura"] = fila_parte_db["Altura"];
                        fila_parte["Piso"] = fila_parte_db["Piso"];
                        fila_parte["Depto"] = fila_parte_db["Depto"];
                        fila_parte["Tecnico"] = fila_parte_db["Tecnico"];
                        fila_parte["Id_Usuarios_Servicios"] = fila_parte_db["Id_Usuarios_Servicios"];
                        fila_parte["Id_Usuarios"] = fila_parte_db["Id_Usuarios"];
                        fila_parte["Id_Servicios"] = fila_parte_db["Id_Servicios"];
                        fila_parte["Id_partes_operaciones"] = fila_parte_db["Id_partes_operaciones"];
                        fila_parte["Id_partes_estados"] = fila_parte_db["Id_partes_estados"];
                        fila_parte["fecha_programado"] = fila_parte_db["fecha_programado"];
                        dt_partes.Rows.Add(fila_parte);
                    }
                }
            }

        }

        public void asignarDatos()
        {
            if (dt_tecnicos.Rows.Count > 0)
            {
                dgv_Tecnicos.DataSource = dt_tecnicos_grilla;
                dgv_Tecnicos.Columns["Codigo"].Visible = false;
                dgv_Tecnicos.Columns["N_Partes"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv_Tecnicos.Columns["N_Partes"].HeaderText = "Partes asignados";

                dgv_partes.DataSource = dt_partes;
                dgv_partes.Columns["Id_Parte"].HeaderText = "Nro.";
                dgv_partes.Columns["falla"].HeaderText = "Solicitud";
                dgv_partes.Columns["fecha_programado"].HeaderText = "Programado para";
                dgv_partes.Columns["Usuario"].Visible = false;
                dgv_partes.Columns["Calle"].Visible = false;
                dgv_partes.Columns["Altura"].Visible = false;
                dgv_partes.Columns["Piso"].Visible = false;
                dgv_partes.Columns["Depto"].Visible = false;
                dgv_partes.Columns["Tecnico"].Visible = false;
                dgv_partes.Columns["Id_Usuarios_Servicios"].Visible = false;
                dgv_partes.Columns["Id_Usuarios"].Visible = false;
                dgv_partes.Columns["Id_Servicios"].Visible = false;
                dgv_partes.Columns["Id_partes_operaciones"].Visible = false;
                dgv_partes.Columns["Id_partes_estados"].Visible = false;
                dgv_partes.Columns["Id_Parte"].Width = 40;
                dgv_partes.Columns["Asignado"].Width = 50;
                dgv_partes.Columns["fecha_programado"].Width = 70;

                if (dgv_partes.Rows.Count > 0)
                {
                    ActualizarDatosCabecera();
                    //ColorearGrillaPartes(dgv_partes);
                    dtpFecha.Value = Convert.ToDateTime(dgv_partes.Rows[dgv_partes.Rows.Count - 1].Cells["fecha_programado"].Value);
                    dgv_partes.Rows[dgv_partes.Rows.Count - 1].Selected = true;
                }

                id_seleccion = dgv_Tecnicos.SelectedRows[0].Index;
                dt_horarios = Traer_agenda(id_seleccion);

                dgv_Horarios.DataSource = dt_horarios;

                dgv_Horarios.Columns["EstadoParte"].Visible = false;
                dgv_Horarios.Columns["id"].Visible = false;
                dgv_Horarios.Columns["reservado"].Visible = false;
                dgv_Horarios.Columns["N_Parte"].Width = 45;
                dgv_Horarios.Columns["Hora"].Width = 50;
                dgv_Horarios.Columns["Seleccion"].Width = 70;
                dgv_Horarios.Columns["Seleccion"].HeaderText = "Reservar";
                dgv_Horarios.Columns["N_Parte"].HeaderText = "N° de parte";
                dgv_Horarios.Columns["Falla"].HeaderText = "Solicitud";

                lblNPartesPendientes.Text = String.Format("N° de partes pendientes de técnico: {0} de {1}", cantidadPartesPendientesFechaSeleccionada, cantidadPartesPendientesTotal);
                lblFechaSeleccionada.Text = String.Format("Fecha seleccionada: {0}", dtpFecha.Value.ToString("dd/MM/yyyy"));
                Colorear_grilla(dgv_Horarios);
                if (reprogramarParte && dgv_partes.Rows.Count > 0)
                    SeleccionarHorarios(Convert.ToInt32(dgv_partes.Rows[0].Cells["id_parte"].Value));
            }
            else
            {
                MessageBox.Show("No hay técnicos registrados en el sistema.");
                btnBuscarParte.Enabled = false;
                btnConfirmar.Enabled = false;
                btnImprimir.Enabled = false;
                btnTerminar.Visible = false;
                btnSobreturno.Enabled = false;
                btnReasignar.Enabled = false;
                btnEliminar.Enabled = false;
                btnVerServicios.Enabled = false;
                btnFechaAtras.Enabled = false;
                btnFechaAdelante.Enabled = false;
                dtpFecha.Enabled = false;
                dgv_Horarios.Enabled = false;
                btnReservarHorarios.Enabled = false;
            }


        }

        private void SeleccionarHorarios(int idParte)
        {
            try
            {
                if (dgv_Horarios.Rows.Count > 0)
                {
                    foreach (DataGridViewRow fila in dgv_Horarios.Rows)
                    {
                        if (fila.Cells["n_parte"].Value != DBNull.Value && Convert.ToInt32(fila.Cells["n_parte"].Value) == idParte)
                            fila.Selected = true;
                    }
                }
            }
            catch { };
        }


        public void comenzarCargaAgendaDiaria()
        {
            pgCircular.Start();
            hilo = new Thread(new ThreadStart(cargarDatosAgendaDiaria));
            hilo.Start();
        }

        public void cargarDatosAgendaDiaria()
        {
            try
            {

                myDel MD = new myDel(asignarDatosAgendaDiaria);

                this.Invoke(MD, new object[] { });

                pgCircular.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Información" + ex.Message);
            }
        }

        public void asignarDatosAgendaDiaria()
        {
            ActualizarCantPartesTecnicos(dtpFecha.Value.Date);

            ActualizarEstadosPartes(dt_partes);
            //ColorearGrillaPartes(dgv_partes);

            dt_horarios = Traer_agenda(id_seleccion);

            dgv_Horarios.DataSource = dt_horarios;

            dgv_Horarios.Columns["EstadoParte"].Visible = false;
            dgv_Horarios.Columns["id"].Visible = false;
            dgv_Horarios.Columns["reservado"].Visible = false;
            dgv_Horarios.Columns["N_Parte"].Width = 45;
            dgv_Horarios.Columns["Hora"].Width = 50;
            dgv_Horarios.Columns["Seleccion"].Width = 70;
            dgv_Horarios.Columns["Seleccion"].HeaderText = "Reservar";

            Colorear_grilla(dgv_Horarios);
        }

        public void Id_recibido(List<Int32> l_id_partes)//recibe id de parte de otro formulario
        {
            lista_id_partes = l_id_partes;
            if (frmAgenda.formAbierto)
            {
                CargarGrillaPartes();
                ActualizarEstadosPartes(dt_partes);
            }


        }

        public void ActualizarCantPartesTecnicos(DateTime fecha)//actualiza la cantidad de partes asignados al técnico en la fecha
        {
            DataTable dt_encabezado = new DataTable();

            dt_encabezado = agenda.Buscar_encabezado(dt_tecnicos.Rows[dgv_Tecnicos.SelectedRows[0].Index], fecha.Date.ToString("yyyy/MM/dd"));
            if (dt_encabezado.Rows.Count > 0)
            {
                int cantPartes = agenda.Buscar_cant_partes(dt_encabezado).Rows.Count;
                if (cantPartes > 0)
                {
                    dgv_Tecnicos.SelectedRows[0].Cells["N_Partes"].Value = "";
                    dgv_Tecnicos.SelectedRows[0].Cells["N_Partes"].Value = cantPartes;

                }
                else
                {
                    dgv_Tecnicos.SelectedRows[0].Cells["N_Partes"].Value = "";
                    dgv_Tecnicos.SelectedRows[0].Cells["N_Partes"].Value = "0";
                }
            }
            else
            {
                dgv_Tecnicos.SelectedRows[0].Cells["N_Partes"].Value = "";
                dgv_Tecnicos.SelectedRows[0].Cells["N_Partes"].Value = "0";
            }
        }

        public void ActualizarEstadosPartes(DataTable dt_partes)
        {
            DataRow fila_parte_db;
            foreach (DataRow fila_parte in dt_partes.Rows)
            {
                fila_parte_db = agenda.TraerDatosParte(Convert.ToInt32(fila_parte["Id_Parte"]));
                fila_parte["falla"] = fila_parte_db["falla"];

                fila_parte["Usuario"] = fila_parte_db["Usuario"];
                fila_parte["Calle"] = fila_parte_db["Calle"];
                fila_parte["Altura"] = fila_parte_db["Altura"];
                fila_parte["Piso"] = fila_parte_db["Piso"];
                fila_parte["Depto"] = fila_parte_db["Depto"];
                fila_parte["Tecnico"] = fila_parte_db["Tecnico"];
                fila_parte["Id_Usuarios_Servicios"] = fila_parte_db["Id_Usuarios_Servicios"];
                fila_parte["Id_Usuarios"] = fila_parte_db["Id_Usuarios"];
                fila_parte["Id_Servicios"] = fila_parte_db["Id_Servicios"];
                fila_parte["Id_partes_operaciones"] = fila_parte_db["Id_partes_operaciones"];
                fila_parte["Id_partes_estados"] = fila_parte_db["Id_partes_estados"];
                fila_parte["fecha_programado"] = fila_parte_db["fecha_programado"];
                if (Convert.ToInt32(fila_parte_db["Id_Partes_Estados"]) == Convert.ToInt32(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_TECNICO))
                    fila_parte["Asignado"] = "NO";
                else
                    fila_parte["Asignado"] = "SI";
            }
            dgv_partes.DataSource = null;
            dgv_partes.DataSource = dt_partes;

            dgv_partes.Columns["Id_Parte"].HeaderText = "Nro.";
            dgv_partes.Columns["fecha_programado"].HeaderText = "Programado para:";
            dgv_partes.Columns["falla"].HeaderText = "Solicitud";
            dgv_partes.Columns["Usuario"].Visible = false;
            dgv_partes.Columns["Calle"].Visible = false;
            dgv_partes.Columns["Altura"].Visible = false;
            dgv_partes.Columns["Piso"].Visible = false;
            dgv_partes.Columns["Depto"].Visible = false;
            dgv_partes.Columns["Tecnico"].Visible = false;
            dgv_partes.Columns["Id_Usuarios_Servicios"].Visible = false;
            dgv_partes.Columns["Id_Usuarios"].Visible = false;
            dgv_partes.Columns["Id_Servicios"].Visible = false;
            dgv_partes.Columns["Id_partes_operaciones"].Visible = false;
            dgv_partes.Columns["Id_partes_estados"].Visible = false;
            dgv_partes.Columns["Id_Parte"].Width = 40;
            dgv_partes.Columns["Asignado"].Width = 50;
            dgv_partes.Columns["fecha_programado"].Width = 70;
        }

        public void Colorear_grilla(DataGridView dgv_Horarios)
        {
            if (dgv_Horarios.Rows.Count > 0)
            {
                foreach (DataGridViewRow fila in dgv_Horarios.Rows)
                {

                    if (fila.Cells["N_Parte"].Value.ToString().Length > 0)
                    {
                        int EstadoParte = Convert.ToInt32(fila.Cells["EstadoParte"].Value);

                        if (EstadoParte == Convert.ToInt32(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_EQUIPO))
                        {
                            fila.Cells["Hora"].Style.BackColor = Color.Yellow;
                            fila.Cells["N_Parte"].Style.BackColor = Color.Yellow;
                            fila.Cells["Usuario"].Style.BackColor = Color.Yellow;
                            fila.Cells["Falla"].Style.BackColor = Color.Yellow;
                            fila.Cells["Detalles"].Style.BackColor = Color.Yellow;
                            fila.Cells["Locacion"].Style.BackColor = Color.Yellow;
                            fila.Cells["Seleccion"].Style.BackColor = Color.Yellow;
                        }
                        else if (EstadoParte == Convert.ToInt32(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_TECNICO))
                        {
                            fila.Cells["Hora"].Style.BackColor = Color.Tomato;
                            fila.Cells["N_Parte"].Style.BackColor = Color.Tomato;
                            fila.Cells["Usuario"].Style.BackColor = Color.Tomato;
                            fila.Cells["Falla"].Style.BackColor = Color.Tomato;
                            fila.Cells["Detalles"].Style.BackColor = Color.Tomato;
                            fila.Cells["Locacion"].Style.BackColor = Color.Tomato;
                            fila.Cells["Seleccion"].Style.BackColor = Color.Tomato;
                        }
                        else if (EstadoParte == Convert.ToInt32(Partes.Partes_Estados.ASIGNADO))
                        {
                            fila.Cells["Hora"].Style.BackColor = Color.LightGreen;
                            fila.Cells["N_Parte"].Style.BackColor = Color.LightGreen;
                            fila.Cells["Usuario"].Style.BackColor = Color.LightGreen;
                            fila.Cells["Falla"].Style.BackColor = Color.LightGreen;
                            fila.Cells["Detalles"].Style.BackColor = Color.LightGreen;
                            fila.Cells["Locacion"].Style.BackColor = Color.LightGreen;
                            fila.Cells["Seleccion"].Style.BackColor = Color.LightGreen;
                        }
                        else if (EstadoParte == Convert.ToInt32(Partes.Partes_Estados.REALIZADO))
                        {
                            fila.Cells["Hora"].Style.BackColor = Color.DarkGray;
                            fila.Cells["N_Parte"].Style.BackColor = Color.DarkGray;
                            fila.Cells["Usuario"].Style.BackColor = Color.DarkGray;
                            fila.Cells["Falla"].Style.BackColor = Color.DarkGray;
                            fila.Cells["Detalles"].Style.BackColor = Color.DarkGray;
                            fila.Cells["Locacion"].Style.BackColor = Color.DarkGray;
                            fila.Cells["Seleccion"].Style.BackColor = Color.DarkGray;
                        }
                        else if (EstadoParte == Convert.ToInt32(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_TARJETA))
                        {
                            fila.Cells["Hora"].Style.BackColor = Color.DarkOrange;
                            fila.Cells["N_Parte"].Style.BackColor = Color.DarkOrange;
                            fila.Cells["Usuario"].Style.BackColor = Color.DarkOrange;
                            fila.Cells["Falla"].Style.BackColor = Color.DarkOrange;
                            fila.Cells["Detalles"].Style.BackColor = Color.DarkOrange;
                            fila.Cells["Locacion"].Style.BackColor = Color.DarkOrange;
                            fila.Cells["Seleccion"].Style.BackColor = Color.DarkOrange;
                        }


                    }
                    else
                    {
                        try
                        {

                            if (fila.Cells["reservado"].Value == DBNull.Value || Convert.ToInt32(fila.Cells["reservado"].Value) == 0)
                            {
                                fila.Cells["Hora"].Style.BackColor = Color.White;
                                fila.Cells["N_Parte"].Style.BackColor = Color.White;
                                fila.Cells["Usuario"].Style.BackColor = Color.White;
                                fila.Cells["Falla"].Style.BackColor = Color.White;
                                fila.Cells["Detalles"].Style.BackColor = Color.White;
                                fila.Cells["Locacion"].Style.BackColor = Color.White;
                                fila.Cells["Seleccion"].Style.BackColor = Color.White;
                            }
                            else
                            {
                                fila.Cells["Hora"].Style.BackColor = Color.CornflowerBlue;
                                fila.Cells["N_Parte"].Style.BackColor = Color.CornflowerBlue;
                                fila.Cells["Usuario"].Style.BackColor = Color.CornflowerBlue;
                                fila.Cells["Falla"].Style.BackColor = Color.CornflowerBlue;
                                fila.Cells["Detalles"].Style.BackColor = Color.CornflowerBlue;
                                fila.Cells["Locacion"].Style.BackColor = Color.CornflowerBlue;
                                fila.Cells["Seleccion"].Style.BackColor = Color.CornflowerBlue;
                            }
                        }
                        catch
                        { }
                    }
                }
            }
        }

        public void ImprimirParte()
        {
            this.TopMost = false;
            Impresion oImpresiones = new Impresion();
            try
            {
                oImpresiones.ImprimirParte(Convert.ToInt32(dgv_Horarios.SelectedRows[0].Cells["N_Parte"].Value));
            }
            catch (Exception)
            {
            }
            // finally { // this.TopMost = true; }

        }

        public void ColorearGrillaPartes(DataGridView dgvPartes)
        {
            if (dgvPartes.Rows.Count > 0)
            {
                foreach (DataGridViewRow fila in dgvPartes.Rows)
                {
                    if (fila.Cells["asignado"].Value.ToString() == "SI")
                    {
                        fila.Cells["id_parte"].Style.BackColor = Color.LightGreen;
                        fila.Cells["falla"].Style.BackColor = Color.LightGreen;
                        fila.Cells["servicio"].Style.BackColor = Color.LightGreen;
                        fila.Cells["fecha_programado"].Style.BackColor = Color.LightGreen;
                        fila.Cells["calle"].Style.BackColor = Color.LightGreen;
                        fila.Cells["altura"].Style.BackColor = Color.LightGreen;
                        fila.Cells["piso"].Style.BackColor = Color.LightGreen;
                        fila.Cells["depto"].Style.BackColor = Color.LightGreen;
                        fila.Cells["asignado"].Style.BackColor = Color.LightGreen;
                    }
                    else
                    {
                        fila.Cells["id_parte"].Style.BackColor = Color.White;
                        fila.Cells["falla"].Style.BackColor = Color.White;
                        fila.Cells["servicio"].Style.BackColor = Color.White;
                        fila.Cells["fecha_programado"].Style.BackColor = Color.White;
                        fila.Cells["calle"].Style.BackColor = Color.White;
                        fila.Cells["altura"].Style.BackColor = Color.White;
                        fila.Cells["piso"].Style.BackColor = Color.White;
                        fila.Cells["depto"].Style.BackColor = Color.White;
                        fila.Cells["asignado"].Style.BackColor = Color.White;
                    }
                }
            }
        }

        private void AgregarParte()
        {
            int IdParteEstado = 0;
            if (dgv_Horarios.SelectedRows[0].Cells["N_Parte"].Value.ToString().Length > 0)//controla si la fila seleccionada ya tiene un parte cargado
                MessageBox.Show("El horario actual se encuentra ocupado por otro parte. Para emplear este horario reasigne el parte del mismo.");
            else
            {

                if (String.IsNullOrEmpty(dgv_Horarios.SelectedRows[0].Cells["reservado"].Value.ToString()) || Convert.ToInt32(dgv_Horarios.SelectedRows[0].Cells["reservado"].Value) == 0)
                {
                    partes = dt_partes.Select("Id_Parte=" + id_parte + "");

                    string fecha_movil = dtpFecha.Value.Date.ToShortDateString() + " " + dgv_Horarios.SelectedRows[0].Cells["Hora"].Value.ToString();

                    if (String.IsNullOrEmpty(partes[0]["Tecnico"].ToString()) || partes[0]["Tecnico"].ToString() == "0")
                    {
                        bool respuesta_asignar_parte;

                        respuesta_asignar_parte = agenda.Asignar_Parte(Convert.ToInt32(dt_tecnicos.Rows[id_seleccion]["Id"].ToString()), id_parte, Convert.ToInt32(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_TECNICO), Convert.ToDateTime(fecha_movil));
                        IdParteEstado = oParte.SetearEstadoParte(Convert.ToInt32(partes[0]["id_parte"]), 0, 0, DateTime.Now, 0, 0, "");
                        oPartesHistorial.Id_Partes_Estados = IdParteEstado;


                        if (respuesta_asignar_parte)
                        {
                            DataTable dt = new DataTable();
                            dt = agenda.Id_agenda_detalle(Convert.ToInt32(dt_tecnicos.Rows[id_seleccion]["Id"].ToString()), dtpFecha.Value.Date);

                            if (dt.Rows.Count > 0)
                            {
                                if (agenda.Insertar_detalle_agenda(dt.Rows[0]["Id"].ToString(), id_parte.ToString(), dgv_Horarios.CurrentRow.Cells["Hora"].Value.ToString(), dgv_Horarios.CurrentRow.Cells["Detalles"].Value.ToString(), 0))//inserta el horario ocupado en db
                                {
                                    id_encabezadodtpk = Convert.ToInt32(dt.Rows[0]["Id"]);

                                    oPartesHistorial.Id_Parte = id_parte;
                                    oPartesHistorial.Id_Usuarios = Convert.ToInt32(partes[0]["id_usuarios"]);
                                    oPartesHistorial.Id_Personal = Personal.Id_Login;
                                    oPartesHistorial.Fecha_Movimiento = DateTime.Now;
                                    oPartesHistorial.Id_area = Personal.Id_Area;
                                    oPartesHistorial.Detalles = "TÉCNICO ASIGNADO.";
                                    oPartesHistorial.GuardarNuevoDetalle(oPartesHistorial);
                                    oParte.ActualizarFechaProgramado(Convert.ToInt32(partes[0]["Id_Parte"]), dtpFecha.Value);

                                    MessageBox.Show("Parte asignado correctamente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);


                                }
                                else
                                {
                                    agenda.Actualizar_parte(partes[0]["N_Parte"].ToString(), 0, Convert.ToInt32(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_TECNICO));

                                    MessageBox.Show("No se pudo registrar el horario asignado");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Error al asignar parte");
                        }
                    }
                    else if (dt_tecnicos.Rows[id_seleccion]["Id"].ToString() == partes[0]["Tecnico"].ToString())
                    {
                        DataTable dt = new DataTable();
                        dt = agenda.Id_agenda_detalle(Convert.ToInt32(dt_tecnicos.Rows[id_seleccion]["Id"].ToString()), dtpFecha.Value.Date);

                        if (dt.Rows.Count > 0)
                        {

                            if (dt.Rows[0]["Id"].ToString() == id_encabezado_eliminar.ToString() || id_encabezado_eliminar == 0)
                            {
                                if (id_encabezado_eliminar == 0)
                                {
                                    if (Convert.ToInt32(dt.Rows[0]["Id"]) == id_encabezadodtpk)
                                    {
                                        if (agenda.Insertar_detalle_agenda(dt.Rows[0]["Id"].ToString(), partes[0]["Id_Parte"].ToString(), dgv_Horarios.CurrentRow.Cells["Hora"].Value.ToString(), dgv_Horarios.CurrentRow.Cells["Detalles"].Value.ToString(), 0))//inserta el horario ocupado en db
                                        {
                                            oPartesHistorial.Id_Parte = id_parte;
                                            oPartesHistorial.Id_Partes_Estados = Convert.ToInt32(partes[0]["tecnico"]);
                                            oPartesHistorial.Id_Usuarios = Convert.ToInt32(partes[0]["id_usuarios"]);
                                            oPartesHistorial.Id_Personal = Personal.Id_Login;
                                            oPartesHistorial.Fecha_Movimiento = DateTime.Now;
                                            oPartesHistorial.Id_area = Personal.Id_Area;
                                            oPartesHistorial.Detalles = "TÉCNICO ASIGNADO.";
                                            oPartesHistorial.GuardarNuevoDetalle(oPartesHistorial);
                                            oParte.ActualizarFechaProgramado(Convert.ToInt32(partes[0]["Id_Parte"]), dtpFecha.Value);
                                            if (reasignacion)
                                            {
                                                if (agenda.Eliminar_parte_asignado(id_encabezado_eliminar.ToString(), id_parte.ToString(), hora_eliminar))
                                                {

                                                    reasignacion = false;
                                                    hora_eliminar = "";
                                                    id_encabezado_eliminar = 0;
                                                    if (reprogramarParte == false)
                                                        dt_partes.Clear();
                                                }
                                                else
                                                {
                                                    agenda.Eliminar_parte_asignado(agenda.Buscar_encabezado(dt_tecnicos.Rows[id_seleccion], dtpFecha.Value.Date.ToString("yyyy-MM-dd HH:mm")).Rows[0]["Id"].ToString(), id_parte.ToString(), dgv_Horarios.CurrentRow.Cells["Hora"].Value.ToString());
                                                    MessageBox.Show("Error al borrar horario anterior.");
                                                }
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("No se pudo registrar el horario asignado");
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Ya se encuentra asignado a otra fecha.");
                                    }
                                }
                                else
                                {
                                    if (agenda.Insertar_detalle_agenda(dt.Rows[0]["Id"].ToString(), partes[0]["Id_Parte"].ToString(), dgv_Horarios.CurrentRow.Cells["Hora"].Value.ToString(), dgv_Horarios.CurrentRow.Cells["Detalles"].Value.ToString(), 0))//inserta el horario ocupado en db
                                    {
                                        oPartesHistorial.Id_Parte = id_parte;
                                        oPartesHistorial.Id_Partes_Estados = Convert.ToInt32(partes[0]["tecnico"]);
                                        oPartesHistorial.Id_Usuarios = Convert.ToInt32(partes[0]["id_usuarios"]);
                                        oPartesHistorial.Id_Personal = Personal.Id_Login;
                                        oPartesHistorial.Fecha_Movimiento = DateTime.Now;
                                        oPartesHistorial.Id_area = Personal.Id_Area;
                                        oPartesHistorial.Detalles = "TÉCNICO ASIGNADO.";
                                        oPartesHistorial.GuardarNuevoDetalle(oPartesHistorial);
                                        oParte.ActualizarFechaProgramado(Convert.ToInt32(partes[0]["Id_Parte"]), dtpFecha.Value);
                                        if (reasignacion)
                                        {
                                            if (agenda.Eliminar_parte_asignado(id_encabezado_eliminar.ToString(), id_parte.ToString(), hora_eliminar))
                                            {

                                                reasignacion = false;
                                                hora_eliminar = "";
                                                id_encabezado_eliminar = 0;
                                                if (reprogramarParte == false)
                                                    dt_partes.Clear();

                                            }
                                            else
                                            {
                                                agenda.Eliminar_parte_asignado(agenda.Buscar_encabezado(dt_tecnicos.Rows[id_seleccion], dtpFecha.Value.Date.ToString("yyyy-MM-dd HH:mm")).Rows[0]["Id"].ToString(), id_parte.ToString(), dgv_Horarios.CurrentRow.Cells["Hora"].Value.ToString());
                                                MessageBox.Show("Error al borrar horario anterior.");
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("No se pudo registrar el horario asignado");
                                    }
                                }
                            }
                            else
                            {
                                if (reasignacion == false)
                                {

                                    MessageBox.Show("Ya se encuentra asignado a otra fecha. Para poder realizar esta acción reasigne el parte.");

                                }
                                else
                                {

                                    if (agenda.Insertar_detalle_agenda(dt.Rows[0]["Id"].ToString(), partes[0]["Id_Parte"].ToString(), dgv_Horarios.CurrentRow.Cells["Hora"].Value.ToString(), dgv_Horarios.CurrentRow.Cells["Detalles"].Value.ToString(), 0))//inserta el horario ocupado en db
                                    {
                                        oPartesHistorial.Id_Parte = id_parte;
                                        oPartesHistorial.Id_Partes_Estados = Convert.ToInt32(partes[0]["tecnico"]);
                                        oPartesHistorial.Id_Usuarios = Convert.ToInt32(partes[0]["id_usuarios"]);
                                        oPartesHistorial.Id_Personal = Personal.Id_Login;
                                        oPartesHistorial.Fecha_Movimiento = DateTime.Now;
                                        oPartesHistorial.Id_area = Personal.Id_Area;
                                        oPartesHistorial.Detalles = "TÉCNICO ASIGNADO.";
                                        oPartesHistorial.GuardarNuevoDetalle(oPartesHistorial);
                                        oParte.ActualizarFechaProgramado(Convert.ToInt32(partes[0]["Id_Parte"]), dtpFecha.Value);

                                        if (agenda.Borrar_partes(id_encabezado_eliminar, id_parte))
                                        {
                                            reasignacion = false;
                                            hora_eliminar = "";
                                            id_encabezado_eliminar = 0;
                                            if (reprogramarParte == false)
                                                dt_partes.Clear();
                                        }
                                        else
                                        {
                                            agenda.Activar_partes(id_encabezado_eliminar, id_parte);
                                            agenda.Eliminar_parte_asignado(dt.Rows[0]["Id"].ToString(), partes[0]["Id_Parte"].ToString(), dgv_Horarios.CurrentRow.Cells["Hora"].Value.ToString());
                                            agenda.Actualizar_parte(id_parte.ToString(), id_tecnico_anterior, 0);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("No se pudo registrar el horario asignado");
                                    }
                                }
                            }

                        }


                    }
                    else
                    {
                        if (reasignacion)
                        {
                            bool respuesta_asignar_parte;


                            respuesta_asignar_parte = agenda.Asignar_Parte(Convert.ToInt32(dt_tecnicos.Rows[id_seleccion]["Id"].ToString()), id_parte, Convert.ToInt32(partes[0]["Id_Partes_estados"]), Convert.ToDateTime(fecha_movil));


                            if (respuesta_asignar_parte)
                            {
                                DataTable dt = new DataTable();
                                dt = agenda.Id_agenda_detalle(Convert.ToInt32(dt_tecnicos.Rows[id_seleccion]["Id"].ToString()), dtpFecha.Value.Date);

                                if (dt.Rows.Count > 0)
                                {
                                    if (agenda.Insertar_detalle_agenda(dt.Rows[0]["Id"].ToString(), partes[0]["Id_Parte"].ToString(), dgv_Horarios.CurrentRow.Cells["Hora"].Value.ToString(), dgv_Horarios.CurrentRow.Cells["Detalles"].Value.ToString(), 0))//inserta el horario ocupado en db
                                    {
                                        oPartesHistorial.Id_Parte = id_parte;
                                        oPartesHistorial.Id_Partes_Estados = Convert.ToInt32(partes[0]["tecnico"]);
                                        oPartesHistorial.Id_Usuarios = Convert.ToInt32(partes[0]["id_usuarios"]);
                                        oPartesHistorial.Id_Personal = Personal.Id_Login;
                                        oPartesHistorial.Fecha_Movimiento = DateTime.Now;
                                        oPartesHistorial.Id_area = Personal.Id_Area;
                                        oPartesHistorial.Detalles = "TÉCNICO ASIGNADO.";
                                        oPartesHistorial.GuardarNuevoDetalle(oPartesHistorial);
                                        oParte.ActualizarFechaProgramado(Convert.ToInt32(partes[0]["Id_Parte"]), dtpFecha.Value);

                                        if (agenda.Borrar_partes(id_encabezado_eliminar, id_parte))
                                        {
                                            reasignacion = false;
                                            hora_eliminar = "";
                                            id_encabezado_eliminar = 0;
                                            if (reprogramarParte == false)
                                                dt_partes.Clear();
                                        }
                                        else
                                        {
                                            agenda.Activar_partes(id_encabezado_eliminar, id_parte);
                                            agenda.Eliminar_parte_asignado(dt.Rows[0]["Id"].ToString(), partes[0]["Id_Parte"].ToString(), dgv_Horarios.CurrentRow.Cells["Hora"].Value.ToString());
                                            agenda.Actualizar_parte(id_parte.ToString(), id_tecnico_anterior, 0);
                                        }

                                    }
                                    else
                                        MessageBox.Show("No se pudo registrar el horario asignado");
                                }
                                else
                                    MessageBox.Show("No hay encabezado");
                            }
                            else
                                MessageBox.Show("Error al asignar parte");
                        }
                        else
                        {
                            MessageBox.Show("Ya se encuentra asignado a otro técnico");
                        }

                    }
                    CancelarAsignacionParte();
                }
                else
                    MessageBox.Show("El horario se encuentra reservado.");
            }

        }

        private void SalirAgenda()
        {
            this.TopMost = false;
            int control_no_asignados = 0;
            foreach (DataGridViewRow fila_grilla_partes in dgv_partes.Rows)
            {
                if (fila_grilla_partes.Cells["Asignado"].Value.ToString() == "NO")
                    control_no_asignados++;
            }

            if (control_no_asignados > 0)
            {
                frmCancelarPartes frmCancelar = new frmCancelarPartes();
                frmPopUp frmpopup = new frmPopUp();
                frmpopup.Maximizar = false;
                frmpopup.Formulario = frmCancelar;
                frmpopup.ShowDialog();
                if (frmCancelar.DialogResult == DialogResult.No)
                {
                    if (reprogramarParte)
                        this.DialogResult = DialogResult.OK;
                    else
                    {
                        if (lista_id_partes.Count > 0)
                            this.DialogResult = DialogResult.No;
                        else
                        {
                            frmAgenda._instancia = null;
                            this.Close();
                        }
                    }
                }
                else
                {
                    frmAgenda._instancia = null;
                    this.Close();
                }

            }
            else
            {
                frmAgenda._instancia = null;
                this.Close();
            }
            // this.TopMost = true;
        }

        private void EliminarAsignacionParte()
        {
            if (dgv_Horarios.CurrentRow.Cells["N_Parte"].Value.ToString().Length == 0)
                MessageBox.Show("El horario no tiene un parte asignado");
            else
            {
                if (Convert.ToInt32(dgv_Horarios.CurrentRow.Cells["EstadoParte"].Value) == Convert.ToInt32(Partes.Partes_Estados.REALIZADO))
                    MessageBox.Show("Este parte ya se encuentra realizado, no puede ser eliminado ni reasignado.");
                else
                {
                    id_seleccion = dgv_Tecnicos.SelectedRows[0].Index;
                    string id_encabezado = agenda.Buscar_encabezado(dt_tecnicos.Rows[id_seleccion], dtpFecha.Value.Date.ToString("yyyy-MM-dd HH:mm")).Rows[0]["Id"].ToString();
                    string parte = dgv_Horarios.CurrentRow.Cells["N_Parte"].Value.ToString();

                    if (agenda.Eliminar_parte_asignado(id_encabezado, parte, dgv_Horarios.CurrentRow.Cells["Hora"].Value.ToString()))
                    {

                        int cont = 0;
                        foreach (DataGridViewRow fila in dgv_Horarios.Rows)
                        {
                            if (fila.Cells["N_Parte"].Value.ToString() == parte)//cuenta cantidad de horarios que tiene el parte
                            {
                                cont++;
                            }

                            if (fila.Cells["N_Parte"].Value.ToString() == parte && fila.Cells["Hora"].Value.ToString() == dgv_Horarios.CurrentRow.Cells["Hora"].Value.ToString())//limpiar el horario de la asignacio eliminada
                            {
                                fila.Cells["N_Parte"].Value = "";
                                fila.Cells["Usuario"].Value = "";
                                fila.Cells["Falla"].Value = "";
                                fila.Cells["Detalles"].Value = "";
                                fila.Cells["Locacion"].Value = "";
                                fila.Cells["EstadoParte"].Value = "";

                            }

                        }

                        if (cont == 1)//si solo queda un horario asignado al parte cambia el estado del parte
                        {

                            if (agenda.Actualizar_parte(parte, 0, Convert.ToInt32(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_TECNICO)) == false)
                            {
                                MessageBox.Show("Error borrado parte");
                            }
                            else
                            {

                                foreach (DataGridViewRow fila in dgv_partes.Rows)
                                {
                                    if (fila.Cells["Id_Parte"].Value.ToString() == parte)
                                    {
                                        fila.Cells["Asignado"].Value = "NO";
                                    }
                                }

                            }
                        }
                        MessageBox.Show("Asignación eliminada correctamente");
                    }
                    else
                    {
                        MessageBox.Show("Error en la eliminación de la asignación");
                    }
                    id_encabezado = "";
                    parte = "";
                }
            }

        }

        private void CancelarAsignacionParte()
        {
            id_parte = 0;
            reasignacion = false;
            hora_eliminar = "";
            id_encabezado_eliminar = 0;
            lblParteSeleccionado.Text = String.Format("Parte seleccionado:");
            //dt_partes.Clear();
            dgv_partes.DataSource = dt_partes;

        }

        private void AgregarSobreturnoGrillaHorarios()
        {
            this.TopMost = false;
            frmAgregarSobreturno frmSobreturno = new frmAgregarSobreturno();

            frmSobreturno.tomar_datatable_grilla(dt_horarios);//agrega sobreturnos a la grilla
            if (frmSobreturno.ShowDialog() == DialogResult.OK)
            {
                dt_horarios = frmSobreturno.retornar_grilla();
                string id_encabezado = agenda.Buscar_encabezado(dt_tecnicos.Rows[id_seleccion], dtpFecha.Value.Date.ToString("yyyy-MM-dd HH:mm")).Rows[0]["Id"].ToString();
                agenda.Insertar_detalle_agenda(id_encabezado, "0", dt_horarios.Rows[dt_horarios.Rows.Count - 1]["hora"].ToString(), "", 0);
                dgv_Horarios.DataSource = dt_horarios;
            }
            // this.TopMost = true;
        }

        private void ConfirmarParte()
        {
            this.TopMost = false;
            try
            {
                int id = Convert.ToInt32(dgv_Horarios.CurrentRow.Cells["N_Parte"].Value.ToString());
                if (Convert.ToInt32(dgv_Horarios.CurrentRow.Cells["EstadoParte"].Value.ToString()) == Convert.ToInt32(Partes.Partes_Estados.REALIZADO))
                    MessageBox.Show("Este parte ya fue confirmado.");
                else
                {
                    if (Convert.ToInt32(dgv_Horarios.CurrentRow.Cells["EstadoParte"].Value.ToString()) == Convert.ToInt32(Partes.Partes_Estados.ASIGNADO))
                    {

                        frmConfirmaParte frm = new frmConfirmaParte(id, frmConfirmaParte.FUNCIONALIDAD.CONFIRMAR_ANULAR);
                        frm.WindowState = FormWindowState.Maximized;
                        frm.ShowDialog();
                        if (frm.DialogResult == DialogResult.OK)
                            cargarDatosAgendaDiaria();
                    }
                    else
                        MessageBox.Show("El parte no se puede confirmar ya que no se encuentra asignado.");
                }
            }
            catch { }
            // this.TopMost = true;
        }

        private void BusquedaParte()
        {
            Busquedas.frmBusquedaPartes asignacion_parte = new Busquedas.frmBusquedaPartes();

            lista_estados_enviar.Add(Convert.ToInt32(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_TECNICO));

            asignacion_parte.AsignarListaEstados(lista_estados_enviar);

            frmPopUp frmpopup = new frmPopUp();
            frmpopup.Formulario = asignacion_parte;
            frmpopup.Maximizar = false;

            this.TopMost = false;
            if (frmpopup.ShowDialog() == DialogResult.OK)
            {
                id_parte = asignacion_parte.id_parte_seleccionado;

                if (id_parte > 0)
                {
                    int control = 0;

                    foreach (DataRow fila in dt_partes.Rows)
                    {
                        if (id_parte == Convert.ToInt32(fila[0]))
                        {
                            control = 1;
                            break;
                        }
                    }


                    if (control == 1)
                    {
                        MessageBox.Show("El parte ya se encuentra en la grilla de asignación.");
                    }
                    else
                    {


                        DataRow fila_parte_db;
                        DataRow fila_parte;
                        fila_parte = dt_partes.NewRow();
                        fila_parte_db = agenda.TraerDatosParte(id_parte);

                        fila_parte["Id_Parte"] = fila_parte_db["Id_Parte"];

                        if (Convert.ToInt32(fila_parte_db["Id_Partes_Estados"]) == 2)
                        {
                            fila_parte["Asignado"] = "NO";
                        }
                        else
                        {
                            fila_parte["Asignado"] = "SI";
                        }

                        fila_parte["falla"] = fila_parte_db["falla"];

                        fila_parte["Usuario"] = fila_parte_db["Usuario"];
                        fila_parte["Calle"] = fila_parte_db["Calle"];
                        fila_parte["Altura"] = fila_parte_db["Altura"];
                        fila_parte["Piso"] = fila_parte_db["Piso"];
                        fila_parte["Depto"] = fila_parte_db["Depto"];
                        fila_parte["Tecnico"] = fila_parte_db["Tecnico"];
                        fila_parte["Id_Usuarios_Servicios"] = fila_parte_db["Id_Usuarios_Servicios"];
                        fila_parte["Id_Usuarios"] = fila_parte_db["Id_Usuarios"];
                        fila_parte["Id_Servicios"] = fila_parte_db["Id_Servicios"];
                        fila_parte["Id_partes_operaciones"] = fila_parte_db["Id_partes_operaciones"];
                        fila_parte["Id_partes_estados"] = fila_parte_db["Id_partes_estados"];
                        fila_parte["fecha_programado"] = fila_parte_db["fecha_programado"];
                        dt_partes.Rows.Add(fila_parte);
                        dgv_partes.DataSource = dt_partes;
                        try
                        {
                            dtpFecha.Value = Convert.ToDateTime(dgv_partes.Rows[dt_partes.Rows.IndexOf(fila_parte)].Cells["fecha_programado"].Value);
                        }
                        catch { dtpFecha.Value = DateTime.Now; }
                        ActualizarDatosCabecera();

                        dgv_partes.Rows[dgv_partes.Rows.Count - 1].Selected = true;

                    }
                }
            }
            // this.TopMost = true;
        }

        private void ReasignarParte()
        {
            if (dgv_Horarios.CurrentRow.Cells["N_Parte"].Value.ToString().Length == 0 || Convert.ToInt32(dgv_Horarios.CurrentRow.Cells["EstadoParte"].Value) == Convert.ToInt32(Partes.Partes_Estados.REALIZADO))
                MessageBox.Show("No se puede reasignar. Puede que el horario se encuentre vacío o el parte relacionado a éste ya se encuentre realizado.");
            else
            {
                id_parte = Convert.ToInt32(dgv_Horarios.CurrentRow.Cells["N_Parte"].Value);
                lblParteSeleccionado.Text = String.Format("Parte seleccionado:");
                reasignacion = true;
                hora_eliminar = dgv_Horarios.CurrentRow.Cells["Hora"].Value.ToString();
                id_encabezado_eliminar = Convert.ToInt32(agenda.Buscar_encabezado(dt_tecnicos.Rows[id_seleccion], dtpFecha.Value.Date.ToString("yyyy-MM-dd HH:mm")).Rows[0]["Id"]);
                id_tecnico_anterior = Convert.ToInt32(dt_tecnicos.Rows[id_seleccion]["Id"]);


                if (reprogramarParte == false)
                {
                    dt_partes.Clear();
                    DataRow fila_parte_db;
                    DataRow fila_parte;
                    fila_parte = dt_partes.NewRow();
                    fila_parte_db = agenda.TraerDatosParte(id_parte);

                    fila_parte["Id_Parte"] = fila_parte_db["Id_Parte"];

                    if (Convert.ToInt32(fila_parte_db["Id_Partes_Estados"]) == 2)
                    {
                        fila_parte["Asignado"] = "NO";
                    }
                    else
                    {
                        fila_parte["Asignado"] = "SI";
                    }



                    fila_parte["falla"] = fila_parte_db["falla"];

                    fila_parte["Usuario"] = fila_parte_db["Usuario"];
                    fila_parte["Calle"] = fila_parte_db["Calle"];
                    fila_parte["Altura"] = fila_parte_db["Altura"];
                    fila_parte["Piso"] = fila_parte_db["Piso"];
                    fila_parte["Depto"] = fila_parte_db["Depto"];
                    fila_parte["Tecnico"] = fila_parte_db["Tecnico"];
                    fila_parte["Id_Usuarios_Servicios"] = fila_parte_db["Id_Usuarios_Servicios"];
                    fila_parte["Id_Usuarios"] = fila_parte_db["Id_Usuarios"];
                    fila_parte["Id_Servicios"] = fila_parte_db["Id_Servicios"];
                    fila_parte["Id_partes_operaciones"] = fila_parte_db["Id_partes_operaciones"];
                    fila_parte["Id_partes_estados"] = fila_parte_db["Id_partes_estados"];
                    fila_parte["fecha_programado"] = fila_parte_db["fecha_programado"];

                    dt_partes.Rows.Add(fila_parte);

                    dgv_partes.DataSource = dt_partes;

                }


            }

            Colorear_grilla(dgv_Horarios);
        }

        private void ActualizarDatosCabecera()
        {
            if (dgv_partes.Rows.Count > 0)
            {
                if (dgv_partes.SelectedRows.Count > 0)
                {
                    id_parte = Convert.ToInt32(dgv_partes.SelectedRows[0].Cells["Id_Parte"].Value);
                    lblParteSeleccionado.Text = String.Format("Parte seleccionado: {0}", dgv_partes.SelectedRows[0].Cells["Id_Parte"].Value.ToString());
                }
                else
                {
                    id_parte = Convert.ToInt32(dgv_partes.Rows[0].Cells["Id_Parte"].Value);
                    lblParteSeleccionado.Text = String.Format("Parte seleccionado: {0}", dgv_partes.Rows[0].Cells["Id_Parte"].Value.ToString());
                }

            }
        }

        private void SetearLecturaColumnas()
        {
            dgv_Horarios.DataSource = dt_horarios;
            dgv_Horarios.ReadOnly = false;
            dgv_Horarios.Columns["id"].ReadOnly = true;
            dgv_Horarios.Columns["Hora"].ReadOnly = true;
            dgv_Horarios.Columns["N_Parte"].ReadOnly = true;
            dgv_Horarios.Columns["Usuario"].ReadOnly = true;
            dgv_Horarios.Columns["Falla"].ReadOnly = true;
            dgv_Horarios.Columns["Locacion"].ReadOnly = true;
            dgv_Horarios.Columns["N_Parte"].HeaderText = "N° de parte";
            dgv_Horarios.Columns["Falla"].HeaderText = "Solicitud";
        }

        private void SetearDetalles()
        {
            try
            {
                if (dgv_Horarios.SelectedRows.Count > 0 && String.IsNullOrEmpty(dgv_Horarios.SelectedRows[0].Cells["N_Parte"].Value.ToString()) == false)
                {
                    if (Convert.ToInt32(dgv_Horarios.SelectedRows[0].Cells["EstadoParte"].Value) != Convert.ToInt32(Partes.Partes_Estados.REALIZADO))
                        agenda.SetearDetallesAsignacion(Convert.ToInt32(dgv_Horarios.SelectedRows[0].Cells["id"].Value), dgv_Horarios.SelectedRows[0].Cells["Detalles"].Value.ToString());

                }
            }
            catch
            {

            }

        }

        private void ReservarHorarios()
        {
            int x = 0;
            this.TopMost = false;
            foreach (DataGridViewRow fila in dgv_Horarios.Rows)
            {
                if (fila.Cells["seleccion"].Value != DBNull.Value && Convert.ToInt32(fila.Cells["Seleccion"].Value) == 1 && String.IsNullOrEmpty(fila.Cells["N_Parte"].Value.ToString()))
                {
                    x++;
                    break;
                }
            }

            if (x > 0)
            {
                frmPopUp frmpopup = new frmPopUp();
                frmAsignarDetalleReserva frmDetalleReserva = new frmAsignarDetalleReserva();
                frmpopup.Maximizar = false;
                frmpopup.Formulario = frmDetalleReserva;
                frmpopup.ShowDialog();
                if (frmDetalleReserva.DialogResult == DialogResult.OK)
                {
                    string detalle = frmDetalleReserva.detalle;
                    DataTable dtEncabezado = agenda.Buscar_encabezado(dt_tecnicos.Rows[id_seleccion], dtpFecha.Value.Date.ToString("yyyy-MM-dd HH:mm"));

                    foreach (DataGridViewRow fila in dgv_Horarios.Rows)
                    {
                        if (fila.Cells["seleccion"].Value != DBNull.Value && Convert.ToInt32(fila.Cells["Seleccion"].Value) == 1 && String.IsNullOrEmpty(fila.Cells["N_Parte"].Value.ToString()))
                        {
                            try
                            {
                                agenda.Insertar_detalle_agenda(dtEncabezado.Rows[0]["id"].ToString(), "0", fila.Cells["hora"].Value.ToString(), detalle, 1);
                                x++;
                            }
                            catch
                            {

                            }
                        }
                    }


                    comenzarCargaAgendaDiaria();
                }
            }
            else
                MessageBox.Show("No se puede realizar la reserva. Verifique haber seleccionado horarios que estén disponibles");
            // this.TopMost = true;
        }

        private void HabilitarAcciones()
        {
            try
            {
                if (dgv_Horarios.Rows.Count > 0)
                {

                    if (String.IsNullOrEmpty(dgv_Horarios.CurrentRow.Cells["N_Parte"].Value.ToString()))
                    {
                        if (String.IsNullOrEmpty(dgv_Horarios.CurrentRow.Cells["reservado"].Value.ToString()) == true || Convert.ToInt32(dgv_Horarios.CurrentRow.Cells["reservado"].Value) == 0)
                        {
                            btnAsignarEquipos.Enabled = false;
                            btnAsignacionTarjeta.Enabled = false;
                            btnQuitarReservas.Enabled = false;
                            btnEliminar.Enabled = false;
                            btnReasignar.Enabled = false;
                            btnConfirmar.Enabled = false;
                            btnImprimir.Enabled = false;
                            btnVerServicios.Enabled = false;
                        }
                        else
                        {
                            btnAsignarEquipos.Enabled = false;
                            btnAsignacionTarjeta.Enabled = false;
                            btnQuitarReservas.Enabled = true;
                            btnEliminar.Enabled = false;
                            btnReasignar.Enabled = false;
                            btnConfirmar.Enabled = false;
                            btnImprimir.Enabled = false;
                            btnVerServicios.Enabled = false;
                        }
                    }
                    else
                    {
                        int estadoParte = Convert.ToInt32(dgv_Horarios.CurrentRow.Cells["EstadoParte"].Value);

                        if (estadoParte == Convert.ToInt32(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_EQUIPO))
                        {
                            btnAsignarEquipos.Enabled = true;
                            btnQuitarReservas.Enabled = false;
                            btnAsignacionTarjeta.Enabled = false;
                            btnEliminar.Enabled = true;
                            btnReasignar.Enabled = true;
                            btnConfirmar.Enabled = false;
                        }
                        else if (estadoParte == Convert.ToInt32(Partes.Partes_Estados.ASIGNADO))
                        {
                            btnAsignarEquipos.Enabled = false;
                            btnQuitarReservas.Enabled = false;
                            btnAsignacionTarjeta.Enabled = false;
                            btnEliminar.Enabled = true;
                            btnReasignar.Enabled = true;
                            btnConfirmar.Enabled = true;
                        }
                        else if (estadoParte == Convert.ToInt32(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_TARJETA))
                        {
                            btnAsignarEquipos.Enabled = false;
                            btnQuitarReservas.Enabled = false;
                            btnAsignacionTarjeta.Enabled = true;
                            btnEliminar.Enabled = true;
                            btnReasignar.Enabled = true;
                            btnConfirmar.Enabled = false;

                        }
                        else
                        {
                            btnAsignarEquipos.Enabled = false;
                            btnAsignacionTarjeta.Enabled = false;
                            btnQuitarReservas.Enabled = false;
                            btnEliminar.Enabled = false;
                            btnReasignar.Enabled = false;
                            btnConfirmar.Enabled = false;
                        }
                        btnImprimir.Enabled = true;
                        btnVerServicios.Enabled = true;
                    }
                    SetearCabeceraPrincipal();
                }

            }
            catch
            {
                MessageBox.Show("Error al asignar datos a la grilla de horarios.");
            }
        }

        private void SetearCabeceraPrincipal()
        {
            try
            {
                lblHorarioSeleccionado.Text = String.Format("Horario: {0}", dgv_Horarios.CurrentRow.Cells["Hora"].Value.ToString());
                if (dgv_Horarios.CurrentRow.Cells["N_Parte"].Value.ToString().Length > 0)
                    lblParte.Text = String.Format("Parte: {0}", dgv_Horarios.CurrentRow.Cells["N_Parte"].Value.ToString());
                else
                    lblParte.Text = String.Format("Parte: Sin parte asignado.");

            }
            catch
            {
                MessageBox.Show("Error al setear cabecera principal-");
            }
        }

        private void LimpiarCabeceraPrincipal()
        {
            lblHorarioSeleccionado.Text = String.Format("Horario:");
            lblParte.Text = String.Format("Parte:");
        }

        private DataTable Traer_agenda(int indice)//genera y completa la grilla de horarios correspondiente a un técnico y fecha seleccionados
        {
            if (id_seleccion >= 0)
            {
                dt_horarios.Clear();

                string hora_inicio_1, hora_fin_1, hora_inicio_2, hora_fin_2, rango;
                hora_inicio_1 = dt_tecnicos.Rows[id_seleccion]["hora_inicio_1"].ToString();
                hora_inicio_2 = dt_tecnicos.Rows[id_seleccion]["hora_inicio_2"].ToString();
                hora_fin_1 = dt_tecnicos.Rows[id_seleccion]["hora_fin_1"].ToString();
                hora_fin_2 = dt_tecnicos.Rows[id_seleccion]["hora_fin_2"].ToString();
                rango = dt_tecnicos.Rows[id_seleccion]["rango"].ToString();

                DataTable encabezado = new DataTable();

                encabezado = agenda.Buscar_encabezado(dt_tecnicos.Rows[id_seleccion], dtpFecha.Value.Date.ToString("yyyy-MM-dd HH:mm"));

                if (encabezado.Rows.Count > 0)// en caso de haber encabezado, buscar en los detalles de ese encabezado si hay horarios registrados con partes
                {

                    DataTable detalles_agenda = new DataTable();

                    detalles_agenda = agenda.Buscar_detalles_agenda(encabezado);//trae los horarios ocupados de esa fecha

                    dt_horarios = LlenarGrillaHorarios(encabezado, detalles_agenda, dt_horarios);//genera el datatable que luego será volcado a la grilla 2 con los horarios
                }
                else//si no existe el encabezado, lo genera y carga la grilla con los horarios en memoria
                {
                    if (agenda.Insertar_Encabezado(dt_tecnicos.Rows[id_seleccion], dtpFecha.Value.Date))
                    {
                        DataTable detalles_agenda = new DataTable();

                        encabezado = agenda.Buscar_encabezado(dt_tecnicos.Rows[id_seleccion], dtpFecha.Value.Date.ToString("yyyy-MM-dd HH:mm"));

                        dt_horarios = LlenarGrillaHorarios(encabezado, detalles_agenda, dt_horarios);
                    }
                    else
                    {
                        MessageBox.Show("Error al crear el encabezado");
                    }
                }
            }
            else
            {
                MessageBox.Show("No se ha seleccionado técnico");
            }
            return dt_horarios;
        }

        private DataTable LlenarGrillaHorarios(DataTable encabezado, DataTable agenda_detalle, DataTable dt_horarios)
        {
            if (
                (encabezado.Rows[0]["rango"].ToString() != "" && encabezado.Rows[0]["hora_inicio_1"].ToString() != "" && encabezado.Rows[0]["hora_fin_1"].ToString() != "" && encabezado.Rows[0]["hora_inicio_2"].ToString() != "" && encabezado.Rows[0]["hora_fin_2"].ToString() != "")
                ||
                (encabezado.Rows[0]["rango"].ToString() != "" && encabezado.Rows[0]["hora_inicio_1"].ToString() != "" && encabezado.Rows[0]["hora_fin_1"].ToString() != "" && encabezado.Rows[0]["hora_inicio_2"].ToString() == "" && encabezado.Rows[0]["hora_fin_2"].ToString() == "")
                ||
                (encabezado.Rows[0]["rango"].ToString() != "" && encabezado.Rows[0]["hora_inicio_1"].ToString() == "" && encabezado.Rows[0]["hora_fin_1"].ToString() == "" && encabezado.Rows[0]["hora_inicio_2"].ToString() != "" && encabezado.Rows[0]["hora_fin_2"].ToString() != "")
               )
            {


                TimeSpan hora_min = new TimeSpan();

                TimeSpan incremento = new TimeSpan();

                TimeSpan hora_incrementada = new TimeSpan();

                DataRow fila;

                incremento = TimeSpan.FromMinutes(Convert.ToDouble(encabezado.Rows[0]["rango"]));

                if (encabezado.Rows[0]["hora_fin_2"].ToString() == "")//si el turno vespertino esta vacío
                {
                    hora_min = Convert.ToDateTime(encabezado.Rows[0]["hora_inicio_1"].ToString()).TimeOfDay;

                    hora_incrementada = hora_min;

                    while (TimeSpan.Compare(hora_incrementada, TimeSpan.Parse(encabezado.Rows[0]["hora_fin_1"].ToString())) < 0)
                    {
                        fila = dt_horarios.NewRow();
                        fila[dt_horarios.Columns["Hora"]] = hora_incrementada.ToString(@"hh\:mm");

                        dt_horarios.Rows.Add(fila);

                        hora_incrementada = hora_incrementada.Add(incremento);
                    }

                }
                else if (encabezado.Rows[0]["hora_fin_1"].ToString() == "")
                {
                    hora_min = Convert.ToDateTime(encabezado.Rows[0]["hora_inicio_2"].ToString()).TimeOfDay;

                    hora_incrementada = hora_min;

                    while (TimeSpan.Compare(hora_incrementada, TimeSpan.Parse(encabezado.Rows[0]["hora_fin_2"].ToString())) < 0)
                    {
                        fila = dt_horarios.NewRow();
                        fila[dt_horarios.Columns["Hora"]] = hora_incrementada.ToString(@"hh\:mm");

                        dt_horarios.Rows.Add(fila);

                        hora_incrementada = hora_incrementada.Add(incremento);
                    }
                }
                else
                {
                    hora_min = Convert.ToDateTime(encabezado.Rows[0]["hora_inicio_1"].ToString()).TimeOfDay;

                    hora_incrementada = hora_min;

                    while (TimeSpan.Compare(hora_incrementada, TimeSpan.Parse(encabezado.Rows[0]["hora_fin_1"].ToString())) < 0)
                    {
                        fila = dt_horarios.NewRow();
                        fila[dt_horarios.Columns["Hora"]] = hora_incrementada.ToString(@"hh\:mm");

                        dt_horarios.Rows.Add(fila);

                        hora_incrementada = hora_incrementada.Add(incremento);
                    }


                    hora_incrementada = Convert.ToDateTime(encabezado.Rows[0]["hora_inicio_2"].ToString()).TimeOfDay;

                    while (TimeSpan.Compare(hora_incrementada, TimeSpan.Parse(encabezado.Rows[0]["hora_fin_2"].ToString())) < 0)
                    {
                        fila = dt_horarios.NewRow();
                        fila[dt_horarios.Columns["Hora"]] = hora_incrementada.ToString(@"hh\:mm");

                        dt_horarios.Rows.Add(fila);

                        hora_incrementada = hora_incrementada.Add(incremento);
                    }


                }
                //.............................................................................

                if (agenda_detalle.Rows.Count > 0)
                {

                    foreach (DataRow fila_detalle in agenda_detalle.Rows)
                    {

                        DataTable datos_parte = new DataTable();

                        datos_parte = agenda.Buscar_datos_parte(Convert.ToInt32(fila_detalle["id_parte"]));


                        fila = dt_horarios.NewRow();

                        if (datos_parte.Rows.Count > 0)
                        {
                            string codUsuario = "[" + datos_parte.Rows[0]["codigo"].ToString() + "]";
                            fila[dt_horarios.Columns["N_Parte"]] = datos_parte.Rows[0]["Id"].ToString();
                            fila[dt_horarios.Columns["Usuario"]] = codUsuario + datos_parte.Rows[0]["usuario"].ToString();
                            fila[dt_horarios.Columns["Falla"]] = datos_parte.Rows[0]["falla"].ToString();
                            fila[dt_horarios.Columns["Locacion"]] = datos_parte.Rows[0]["Locacion"].ToString();
                            fila[dt_horarios.Columns["EstadoParte"]] = datos_parte.Rows[0]["id_partes_estados"].ToString();
                        }
                        else
                        {
                            fila[dt_horarios.Columns["N_Parte"]] = "";
                            fila[dt_horarios.Columns["Usuario"]] = "";
                            fila[dt_horarios.Columns["Falla"]] = "";
                            fila[dt_horarios.Columns["Locacion"]] = "";
                            fila[dt_horarios.Columns["EstadoParte"]] = "";
                        }
                        fila[dt_horarios.Columns["id"]] = fila_detalle["id"].ToString();
                        fila[dt_horarios.Columns["Hora"]] = TimeSpan.Parse(fila_detalle["hora"].ToString()).ToString(@"hh\:mm");
                        fila[dt_horarios.Columns["Detalles"]] = fila_detalle["Detalles"].ToString();
                        fila[dt_horarios.Columns["reservado"]] = fila_detalle["reservado"].ToString();

                        bool encontro = false;


                        foreach (DataRow fila_contenido in dt_horarios.Rows)
                        {
                            if (fila["hora"].ToString() == fila_contenido["hora"].ToString())
                            {
                                fila_contenido["id"] = fila["id"];
                                fila_contenido["N_Parte"] = fila["N_Parte"];
                                fila_contenido["Usuario"] = fila["Usuario"];
                                fila_contenido["Falla"] = fila["falla"];
                                fila_contenido["Detalles"] = fila["Detalles"];
                                fila_contenido["Locacion"] = fila["Locacion"];
                                fila_contenido["EstadoParte"] = fila["EstadoParte"];
                                fila_contenido["reservado"] = fila["reservado"];

                                encontro = true;
                                break;
                            }
                            else
                            {
                                encontro = false;
                            }
                        }

                        if (encontro == false)
                        {
                            dt_horarios.Rows.Add(fila);
                        }
                    }

                    dt_horarios.DefaultView.Sort = "Hora ASC";
                }
            }
            return dt_horarios;

        }

        private void CalcularCantidadPartesPendientes(DateTime fechaDesde, DateTime fechaHasta)
        {
            try
            {
                cantidadPartesPendientesFechaSeleccionada = oParte.ListarPorRangoDeFechas(fechaDesde, fechaHasta, Partes.Tipo_Fecha.FECHA_PROGRAMADO).Select(String.Format("id_partes_estados={0}", Convert.ToInt32(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_TECNICO))).Length;
                cantidadPartesPendientesTotal = oParte.Listar(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_TECNICO).Rows.Count;
            }
            catch
            {
                cantidadPartesPendientesFechaSeleccionada = 0;
                cantidadPartesPendientesTotal = 0;
            }
        }

        private void VerificarSiSePuedeAsignarIpFija(int RowIndex)
        {
            if (dgv_Horarios.Rows.Count > 0 && dgv_Horarios.Rows[RowIndex].Cells["Id"].Value != DBNull.Value)
            {

                int idParte = Convert.ToString(dgv_Horarios.Rows[RowIndex].Cells["N_Parte"].Value.ToString()) != "" ? Convert.ToInt32(dgv_Horarios.Rows[RowIndex].Cells["N_Parte"].Value) : 0;


                bool estadoBotonAsignarIpFija = false;
                Partes_Usuarios_Servicios oPUS = new Partes_Usuarios_Servicios();
                DataTable partesServicio = oPUS.ListarServiciosPorParte(idParte, Partes_Usuarios_Servicios.CONDICION_REQ_EQUIPOS.TODOS);
                foreach (DataRow row in partesServicio.Rows)
                {
                    if (Convert.ToInt32(row["Asignacion_Ip_Fija"]) ==
                        Convert.ToInt32(Partes_Usuarios_Servicios.CONDICION_IP_FIJA.PENDIENTE_DE_ASIGNACION))
                    {
                        estadoBotonAsignarIpFija = true;
                    }
                }
                btnAsignarIpFija.Enabled = estadoBotonAsignarIpFija;
            }
        }

        #endregion
        private frmAgenda()
        {
            InitializeComponent();
            formAbierto = false;
            pendienteDeAbrir = false;
        }

        public static frmAgenda GetInstancia()
        {
            if (_instancia == null)
                _instancia = new frmAgenda();
            return _instancia;
        }

        public void Mostrar()
        {
            if (!formAbierto)
            {
                this.ShowDialog();
                formAbierto = true;
                
            }
            this.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();
        }

        private void FrmAgenda_Load(object sender, EventArgs e)
        {
            ArmarColsDataTables();
            SetearLecturaColumnas();
            CalcularCantidadPartesPendientes(dtpFecha.Value, dtpFecha.Value);
            lblNPartesPendientes.Text = String.Format("N° de partes pendientes de técnico: {0} de {1}", cantidadPartesPendientesFechaSeleccionada, cantidadPartesPendientesTotal);
            lblFechaSeleccionada.Text = String.Format("Fecha seleccionada: {0}", dtpFecha.Value.ToString("dd/MM/yyyy"));
            if (reprogramarParte)
                btnReasignar.Text = "Reprogramar";
            else
                btnReasignar.Text = "Reasignar";
            comenzarCarga();
            foreach (DataGridViewColumn columna in dgv_Horarios.Columns)
                columna.SortMode = DataGridViewColumnSortMode.NotSortable;

            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
        }

        #region[METODOS GRILLAS]
        public void dgv_Tecnicos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_Tecnicos.SelectedRows.Count > 0)
            {
                lbl_Tecnico.Text = "Técnico seleccionado: ";
                lbl_Tecnico.Text += dgv_Tecnicos.SelectedRows[0].Cells["Nombre"].Value.ToString();
                id_seleccion = dgv_Tecnicos.SelectedRows[0].Index;//posicion del técnico en la grilla

                comenzarCargaAgendaDiaria();
                btnSobreturno.Enabled = true;
            }
        }

        private void dgv_Horarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (id_parte != 0)
                {
                    if (dtpFecha.Value.Date >= DateTime.Today)
                        AgregarParte();
                    else
                        MessageBox.Show("No se puede asignar en días pasados.");

                    id_tecnico_anterior = 0;
                    reasignacion = false;

                    comenzarCargaAgendaDiaria();

                }
            }
            catch
            {
                MessageBox.Show("Hubo un error en la asignación del parte.");
            }
        }

        private void dgv_Horarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            HabilitarAcciones();
        }

        private void dgv_Horarios_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgv_Horarios.Columns["Detalles"].Index)
                SetearDetalles();
        }
        #endregion

        #region[METODOS BOTONES]
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea eliminar la asignación seleccionada?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                EliminarAsignacionParte();
                comenzarCargaAgendaDiaria();
            }
        }

        private void btnReasignar_Click(object sender, EventArgs e)
        {
            ReasignarParte();
            ActualizarDatosCabecera();

        }

        private void btn_Buscar_Parte_Click_2(object sender, EventArgs e)
        {
            LimpiarCabeceraPrincipal();
            BusquedaParte();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            ConfirmarParte();
        }

        private void btnSobreturno_Click(object sender, EventArgs e)
        {
            LimpiarCabeceraPrincipal();
            AgregarSobreturnoGrillaHorarios();
        }

        private void btnCancelarAsignacion_Click_2(object sender, EventArgs e)
        {
            CancelarAsignacionParte();
        }
        #endregion

        private void imgReturn_Click(object sender, EventArgs e)
        {
            SalirAgenda();
        }

        private void frmAgenda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                SalirAgenda();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            ImprimirParte();
        }

        private void btnFechaAdelante_Click(object sender, EventArgs e)
        {
            LimpiarCabeceraPrincipal();
            dtpFecha.Value = dtpFecha.Value.AddDays(1);
            SetearLecturaColumnas();
            CalcularCantidadPartesPendientes(dtpFecha.Value, dtpFecha.Value);
            lblNPartesPendientes.Text = String.Format("N° de partes pendientes de técnico: {0} de {1}", cantidadPartesPendientesFechaSeleccionada, cantidadPartesPendientesTotal);
            lblFechaSeleccionada.Text = String.Format("Fecha seleccionada: {0}", dtpFecha.Value.ToString("dd/MM/yyyy"));
            foreach (DataGridViewColumn columna in dgv_Horarios.Columns)
                columna.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void btnFechaAtras_Click(object sender, EventArgs e)
        {
            LimpiarCabeceraPrincipal();
            dtpFecha.Value = dtpFecha.Value.AddDays(-1);
            SetearLecturaColumnas();
            CalcularCantidadPartesPendientes(dtpFecha.Value, dtpFecha.Value);
            lblNPartesPendientes.Text = String.Format("N° de partes pendientes de técnico: {0} de {1}", cantidadPartesPendientesFechaSeleccionada, cantidadPartesPendientesTotal);
            lblFechaSeleccionada.Text = String.Format("Fecha seleccionada: {0}", dtpFecha.Value.ToString("dd/MM/yyyy"));
            foreach (DataGridViewColumn columna in dgv_Horarios.Columns)
                columna.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            LimpiarCabeceraPrincipal();
            dt_horarios.Clear();
            dgv_Horarios.DataSource = null;
            id_seleccion = dgv_Tecnicos.SelectedRows[0].Index;
            comenzarCargaAgendaDiaria();
            SetearLecturaColumnas();
            CalcularCantidadPartesPendientes(dtpFecha.Value, dtpFecha.Value);
            lblNPartesPendientes.Text = String.Format("N° de partes pendientes de técnico: {0} de {1}", cantidadPartesPendientesFechaSeleccionada, cantidadPartesPendientesTotal);
            lblFechaSeleccionada.Text = String.Format("Fecha seleccionada: {0}", dtpFecha.Value.ToString("dd/MM/yyyy"));
            foreach (DataGridViewColumn columna in dgv_Horarios.Columns)
                columna.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void btnReservarHorarios_Click(object sender, EventArgs e)
        {
            ReservarHorarios();
            foreach (DataGridViewColumn columna in dgv_Horarios.Columns)
                columna.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void btnLimpiarGrilla_Click(object sender, EventArgs e)
        {
            CancelarAsignacionParte();
        }

        private void btnQuitarReservas_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("El horario se encuentra reservado. ¿Desea quitar la reserva?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                agenda.BorrarReserva(Convert.ToInt32(dgv_Horarios.SelectedRows[0].Cells["id"].Value));
                comenzarCargaAgendaDiaria();
            }
        }

        private void btnAsignarEquipos_Click(object sender, EventArgs e)
        {
            frmAsignacionEquipos frmAsignacion = new frmAsignacionEquipos(Convert.ToInt32(dgv_Horarios.SelectedRows[0].Cells["N_Parte"].Value), frmAsignacionEquipos.TIPO_LLAMADA_FORM.SHOW_DIALOG);
            frmPopUp frmpopup = new frmPopUp();
            frmpopup.Maximizar = false;
            frmpopup.Formulario = frmAsignacion;
            this.TopMost = false;
            frmpopup.ShowDialog();
            if (frmAsignacion.DialogResult == DialogResult.OK)
                comenzarCargaAgendaDiaria();
            // this.TopMost = true;
        }

        private void btnReservarHorarios_Click_1(object sender, EventArgs e)
        {
            LimpiarCabeceraPrincipal();
            ReservarHorarios();
        }

        private void dgv_Tecnicos_Enter(object sender, EventArgs e)
        {
            LimpiarCabeceraPrincipal();
        }

        private void btnAsignacionTarjeta_Click(object sender, EventArgs e)
        {
            frmAsignacionEquipos frmAsignacion = new frmAsignacionEquipos(Convert.ToInt32(dgv_Horarios.SelectedRows[0].Cells["N_Parte"].Value), frmAsignacionEquipos.TIPO_LLAMADA_FORM.SHOW_DIALOG);
            frmPopUp frmpopup = new frmPopUp();
            frmpopup.Maximizar = false;
            frmpopup.Formulario = frmAsignacion;
            this.TopMost = false;
            frmpopup.ShowDialog();
            if (frmAsignacion.DialogResult == DialogResult.OK)
                comenzarCargaAgendaDiaria();
            // this.TopMost = true;
        }

        private void dgv_partes_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            ActualizarDatosCabecera();
            dtpFecha.Value = Convert.ToDateTime(dgv_partes.CurrentRow.Cells["fecha_programado"].Value);
            SetearLecturaColumnas();
            SeleccionarHorarios(Convert.ToInt32(dgv_partes.CurrentRow.Cells["id_parte"].Value));

        }

        private void btnVerServicios_Click(object sender, EventArgs e)
        {
            frmServiciosDelParte frmServiciosParte = new frmServiciosDelParte(Convert.ToInt32(dgv_Horarios.SelectedRows[0].Cells["N_Parte"].Value));
            frmPopUp frmpopup = new frmPopUp();
            frmpopup.Maximizar = false;
            frmpopup.Formulario = frmServiciosParte;
            this.TopMost = false;
            frmpopup.ShowDialog();
            // this.TopMost = true;
        }

        private void dgv_partes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_partes_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            comenzarCargaAgendaDiaria();
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            SalirAgenda();
        }

        private void lblMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void dgv_Horarios_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            VerificarSiSePuedeAsignarIpFija(e.RowIndex);
        }

        private void btnTerminar_Click(object sender, EventArgs e)
        {
            SalirAgenda();
        }
    }
}//291019fede