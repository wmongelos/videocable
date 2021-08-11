using CapaNegocios;
using CapaNegocios.Panel_Tareas;
using CapaPresentacion.Busquedas;
using CapaPresentacion.Partes_Trabajo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmBajaServicios : Form
    {
        public int idLocacion = 0;
        private Thread hilo;
        private delegate void myDel();
        private DataTable dt = new DataTable();
        private Usuarios_Locaciones oUsuario_Locacion = new Usuarios_Locaciones();
        private Usuarios_Servicios oUsuario_Servicio = new Usuarios_Servicios();
        private Partes oParte = new Partes();
        private Partes_Solicitudes oParte_falla = new Partes_Solicitudes();
        private List<int> lista_id_partes = new List<int>();
        private Partes_Trabajo.frmAgenda agenda;
        private Usuarios oUsuarios = new Usuarios();
        private Servicios_Tipos oServiciosTipos = new Servicios_Tipos();
        private Servicios_Sub oServiciosSub = new Servicios_Sub();
        int idUsuario, codUsuario;
        int config_agenda;
        private Configuracion oConfig = new Configuracion();
        private DataTable dtusuarios = new DataTable();
        public DataRow drUsuario_actual;
        private Equipos oEquipo = new Equipos();
        private Equipos_Tarjetas oEquipoTarjeta = new Equipos_Tarjetas();
        private Servicios oServicio = new Servicios();
        private void comenzarCarga()
        {
            pgCircular.Start();
            dgvServiciosActivos.DataSource = null;
            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
        }

        private void cargarDatos()
        {
            //try
            //{
            config_agenda = oConfig.GetValor_N("Agenda_Trabajo");

            dt = oUsuario_Servicio.Listar_Servicios_Activos(idLocacion);
            if (oUsuario_Locacion.GetLocacion(idLocacion).Activo == Convert.ToInt32(Usuarios_Locaciones.Locacion_Estados.ACTIVA))
            {
                oUsuarios.Codigo = 0;
                oUsuarios.Usuario = "";
                oUsuarios.Calle = "";
                oUsuarios.Altura = 0;
                oUsuarios.Apellido = "";
                oUsuarios.Nombre = "";
                oUsuarios.Depto = "";
                oUsuarios.CUIT = 0;
                oUsuarios.Numero_Documento = 0;

                dtusuarios = oUsuarios.getDatos_ultimo();
            }
            myDel MD = new myDel(asignarDatos);
            this.Invoke(MD, new object[] { });
            pgCircular.Stop();

        }

        private void asignarDatos()
        {
            dgvServiciosActivos.DataSource = dt;

            for (int x = 0; x < dgvServiciosActivos.Columns.Count; x++)
                dgvServiciosActivos.Columns[x].Visible = false;
            
            dgvServiciosActivos.Columns["servicio"].Visible = true;
            dgvServiciosActivos.Columns["tipo_servicio"].Visible = true;
            dgvServiciosActivos.Columns["mac"].Visible = true;
            dgvServiciosActivos.Columns["serie"].Visible = true;
            dgvServiciosActivos.Columns["tarjeta"].Visible = true;

            dgvServiciosActivos.Columns["Servicio"].HeaderText = "Servicio";
            dgvServiciosActivos.Columns["Tipo_servicio"].HeaderText = "Tipo de servicio";
            dgvServiciosActivos.Columns["mac"].HeaderText = "Mac";
            dgvServiciosActivos.Columns["serie"].HeaderText = "Serie";
            dgvServiciosActivos.Columns["tarjeta"].HeaderText = "Tarjeta";
            SetearCabeceraUsuario();

            lblTotal.Text = "Total de registros: ";
            lblTotal.Text += dgvServiciosActivos.Rows.Count;
        }

        private void Generar_bajas()
        {
            if (dgvServiciosActivos.Rows.Count > 0 && dgvServiciosActivos.SelectedRows.Count > 0)
            {
                if (VerificarSiYaTieneParteDeBaja())
                {
                    MessageBox.Show("El servicio ya posee un parte de baja abierto", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DataTable dtPartes = oParte.Get_Estructura_Partes();
                oParte.Id_Usuarios = Convert.ToInt32(dgvServiciosActivos.SelectedRows[0].Cells["Id_Usuarios"].Value);
                oParte.Id_Servicios = Convert.ToInt32(dgvServiciosActivos.SelectedRows[0].Cells["Id_Servicios"].Value);
                oParte.Id_Zonas = Convert.ToInt32(dgvServiciosActivos.SelectedRows[0].Cells["Id_Zonas"].Value);
                oParte.Id_Usuarios_Locaciones = Convert.ToInt32(dgvServiciosActivos.SelectedRows[0].Cells["Id_Usuarios_Locaciones"].Value);

                if (oParte_falla.Listar().Rows.Count > 0)
                {
                    DataTable dt_partes_fallas = new DataTable();
                    dt_partes_fallas = oParte_falla.Traer_Por_Tipo_Servicio(Convert.ToInt32(dgvServiciosActivos.SelectedRows[0].Cells["Id_Servicios_Tipo"].Value));

                    oParte.Id_Partes_Fallas = Convert.ToInt32(dt_partes_fallas.Select("Nombre='BAJA DE SERVICIO'")[0]["Id"].ToString());
                }
                else
                {
                    oParte.Id_Partes_Fallas = 0;
                }

                oParte.Id_Partes_Soluciones = 0;
                oParte.Id_Tecnico = 0;
                oParte.Id_Movil = 0;
                oParte.Id_Partes_Estados = Convert.ToInt32(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_TECNICO);
                oParte.Id_Operadores = Personal.Id_Login;
                oParte.Id_Areas = Personal.Id_Area;
                oParte.Id_Usuarios_Servicios = Convert.ToInt32(dgvServiciosActivos.SelectedRows[0].Cells["Id"].Value);
                oParte.Fecha_Reclamo = DateTime.Now;
                oParte.Fecha_Programado = DateTime.Now;
                oParte.Detalle_Falla = "";
                oParte.Detalle_Solucion = "";
                oParte.Id_Locacion_Anterior = 0;

                DataRow drParte = dtPartes.NewRow();
                drParte["Id"] = 0;
                drParte["Id_Usuarios"] = Convert.ToInt32(dgvServiciosActivos.SelectedRows[0].Cells["Id_Usuarios"].Value);
                drParte["Id_Servicios"] = Convert.ToInt32(dgvServiciosActivos.SelectedRows[0].Cells["Id_Servicios"].Value);
                drParte["Id_Zonas"] = Convert.ToInt32(dgvServiciosActivos.SelectedRows[0].Cells["Id_Zonas"].Value);
                drParte["Id_Usuarios_Servicios"] = Convert.ToInt32(dgvServiciosActivos.SelectedRows[0].Cells["id"].Value);
                drParte["Id_Usuarios_Locaciones"] = Convert.ToInt32(dgvServiciosActivos.SelectedRows[0].Cells["Id_Usuarios_Locaciones"].Value);
                if (oParte_falla.Listar().Rows.Count > 0)
                {
                    DataTable dt_partes_fallas = new DataTable();
                    dt_partes_fallas = oParte_falla.Traer_Por_Tipo_Servicio(Convert.ToInt32(dgvServiciosActivos.SelectedRows[0].Cells["Id_Servicios_Tipo"].Value));

                    drParte["Id_Partes_Fallas"] = Convert.ToInt32(dt_partes_fallas.Select("Nombre='BAJA DE SERVICIO'")[0]["Id"].ToString());
                }
                else
                {
                    drParte["Id_Partes_Fallas"] = 0;
                }
                drParte["Id_Partes_Soluciones"] = 0;
                drParte["Id_Tecnico"] = 0;
                drParte["Id_Movil"] = 0;
                drParte["id_partes_estados"] = Convert.ToInt32(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_TECNICO);
                drParte["Id_Operadores"] = Personal.Id_Login;
                drParte["Id_Areas"] = Personal.Id_Login;
                drParte["Fecha_Reclamo"] = DateTime.Today.Date;
                drParte["Fecha_Programado"] = DateTime.Today.Date;
                drParte["Detalle_Falla"] = "";
                drParte["Detalle_Solucion"] = "";
                drParte["Id_Locacion_Anterior"] = 0;
                drParte["Id_Servicios_Tipos"] = Convert.ToInt32(dgvServiciosActivos.SelectedRows[0].Cells["Id_Servicios_Tipo"].Value);
                DataRow dtDatosTipoServicio = oServiciosTipos.ListarDatosTipoServicio(Convert.ToInt32(dgvServiciosActivos.SelectedRows[0].Cells["Id_Servicios_tipo"].Value));
                drParte["Id_Servicios_Grupos"] = Convert.ToInt32(dtDatosTipoServicio["Id_Servicios_Grupos"]);
                drParte["Id_Comprobantes"] = 0;
                drParte["Tipo"] = "";
                drParte["IdTipoEquipo"] = 0;


                dtPartes.Rows.Add(drParte);
                lista_id_partes.Clear();

                if (dtPartes.Rows.Count > 0)
                {
                    DataTable dtPartesHechos = oParte.AgruparPartesTrabajo(dtPartes);

                    foreach (DataRow item in dtPartesHechos.Rows)
                    {
                        var id = Convert.ToInt32(item["id"]);
                        lista_id_partes.Add(id);

                    }

                }

               if (lista_id_partes.Count > 0)
                {
                    oParte = new Partes();
                    DataRow drInfoServicio;
                    DataTable dtEquiposAsociados = new DataTable();
                    int idUsuarioServicio = Convert.ToInt32(dgvServiciosActivos.SelectedRows[0].Cells["Id"].Value);
                    int idServicioTipo = Convert.ToInt32(dgvServiciosActivos.SelectedRows[0].Cells["Id_Servicios_Tipo"].Value);
                    drInfoServicio = oServicio.getInfoServicio(Convert.ToInt32(dgvServiciosActivos.SelectedRows[0].Cells["Id_Servicios"].Value));
                    dtEquiposAsociados = oEquipo.BuscarEquipoPorUsuarioServicio(idUsuarioServicio);


                    if(drInfoServicio.Table.Rows.Count > 0)
                    {
                        if(drInfoServicio["Requiere_Equipo"].ToString() == "SI")
                        {
                            int id_Falla = oParte.getFallaPorIdServicioTipoYOperacion((int)Partes.Partes_Operaciones.RECUPERACION_EQUIPO, idServicioTipo);
                            if (dtEquiposAsociados.Rows.Count > 0)
                            {
                                DialogResult dialogResult = MessageBox.Show("¿Recuperó el equipo?", "Mensaje del sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (dialogResult == DialogResult.Yes)
                                {
                                    foreach (DataRow Equipo in dtEquiposAsociados.Rows)
                                    {
                                        if (Convert.ToInt32(Equipo["id_tarjeta"]) != 0)
                                            oEquipoTarjeta.CambiarEstadoTarjeta(Convert.ToInt32(Equipo["id_tarjeta"]), Convert.ToInt32(Equipos_Tarjetas.Tarjetas_Estados.CON_FALLA));
                                        oEquipo.PasarEquipoReparacion(Convert.ToInt32(Equipo["id"]), 0);
                                    }
                                }
                                else
                                {
                                    oParte.Id_Usuarios = Convert.ToInt32(dgvServiciosActivos.SelectedRows[0].Cells["Id_Usuarios"].Value);
                                    oParte.Id_Servicios = Convert.ToInt32(dgvServiciosActivos.SelectedRows[0].Cells["Id_Servicios"].Value);
                                    oParte.Id_Zonas = Convert.ToInt32(dgvServiciosActivos.SelectedRows[0].Cells["Id_Zonas"].Value);
                                    oParte.Id_Usuarios_Locaciones = Convert.ToInt32(dgvServiciosActivos.SelectedRows[0].Cells["Id_Usuarios_Locaciones"].Value);
                                    oParte.Id_Partes_Fallas = id_Falla;
                                    oParte.Id_Partes_Soluciones = 0;
                                    oParte.Id_Tecnico = 0;
                                    oParte.Id_Movil = 0;
                                    oParte.Id_Partes_Estados = Convert.ToInt32(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_TECNICO);
                                    oParte.Id_Operadores = Personal.Id_Login;
                                    oParte.Id_Areas = Personal.Id_Area;
                                    oParte.Id_Usuarios_Servicios = Convert.ToInt32(dgvServiciosActivos.SelectedRows[0].Cells["Id"].Value);
                                    oParte.Fecha_Reclamo = DateTime.Now;
                                    oParte.Fecha_Programado = DateTime.Now;
                                    oParte.Detalle_Falla = "RETIRADA DE EQUIPO";
                                    oParte.Detalle_Solucion = "";
                                    oParte.Id_Locacion_Anterior = 0;
                                    oParte.IdAppExterna = Convert.ToInt32(dgvServiciosActivos.SelectedRows[0].Cells["idappexterna"].Value);
                                    oParte.Id_Usuarios_Cuenta_Corriente = 0;
                                    oParte.Guardar(oParte, 1);
                                }
                            }
                        }
                    }

                    int idServicio = Convert.ToInt32(dgvServiciosActivos.SelectedRows[0].Cells["id_servicios"].Value);
                    DataTable datosServicio = new Servicios().BuscarDatosServicio(idServicio);
                    Procesos_Ejecucion.Tipo_De_Ejecucion tipoEjecucion = Convert.ToInt32(datosServicio.Rows[0]["id_aplicaciones_externas"]) > 0 ? Procesos_Ejecucion.Tipo_De_Ejecucion.Automatico : Procesos_Ejecucion.Tipo_De_Ejecucion.Manual;

                    if (config_agenda == Convert.ToInt32(Agenda_Encabezado.Uso_agenda.TRABAJA_CON_AGENDA) &&
                        tipoEjecucion == Procesos_Ejecucion.Tipo_De_Ejecucion.Manual)
                    {
                        agenda = frmAgenda.GetInstancia();
                        agenda.Id_recibido(lista_id_partes);
                        agenda.Mostrar();
                    }
                    else
                    {
                        frmAgregarBajaALote frmBajaLote = new frmAgregarBajaALote(lista_id_partes[0]);
                        frmPopUp popUp = new frmPopUp();
                        popUp.Formulario = frmBajaLote;
                        popUp.Maximizar = false;
                        popUp.ShowDialog();
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("No se han seleccionado servicios.");
                }


            }

        }

        private bool VerificarSiYaTieneParteDeBaja()
        {
            int idLocacion = Convert.ToInt32(dgvServiciosActivos.SelectedRows[0].Cells["Id_Usuarios_Locaciones"].Value);
            int idUsuarioServicio = Convert.ToInt32(dgvServiciosActivos.SelectedRows[0].Cells["id"].Value);
            DataTable dtPartesAbiertos = new Partes().ListarPartesAbiertos(idLocacion, Convert.ToInt32(Partes.Partes_Operaciones.BAJA), idUsuarioServicio);

            return (dtPartesAbiertos.Rows.Count > 0);
        }

        private void Buscar()
        {
            oUsuarios.Codigo = 0;
            oUsuarios.Usuario = "";
            oUsuarios.Calle = "";
            oUsuarios.Altura = 0;

            frmBusquedaUsuarios frm = new frmBusquedaUsuarios(1, "", "");
            frmPopUp oPop = new frmPopUp();
            oPop.Maximizar = false;
            oPop.Formulario = frm;
            if (oPop.ShowDialog() == DialogResult.OK)
            {
                idUsuario = Int32.Parse(frm.usuario_e["id"].ToString());
                idLocacion = Int32.Parse(frm.usuario_e["id_usuarios_locaciones"].ToString());
                comenzarCarga();
            }

        }

        private void AgregarLinkColumn()
        {
            int IndexColumn = -1;
            DataGridViewCheckBoxColumn col_seleccion = new DataGridViewCheckBoxColumn();
            col_seleccion.Name = "col_seleccion";
            col_seleccion.HeaderText = "Seleccionar";
            col_seleccion.Width = 30;
            col_seleccion.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            col_seleccion.TrueValue = true;
            col_seleccion.FalseValue = false;
            IndexColumn = dgvServiciosActivos.Columns.IndexOf(col_seleccion);
            if (IndexColumn >= 0)
                dgvServiciosActivos.Columns.RemoveAt(IndexColumn);
            dgvServiciosActivos.Columns.Add(col_seleccion);
        }


        public FrmBajaServicios(int usu, int loc, DataRow usuSel)
        {
            InitializeComponent();
            this.idUsuario = usu;
            this.idLocacion = loc;
            this.drUsuario_actual = usuSel;

        }

        private void FrmBajaServicios_Load(object sender, EventArgs e)
        {
            if (idUsuario != 0 && idLocacion != 0)
                comenzarCarga();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Generar_bajas();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmBajaServicios_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void SetearCabeceraUsuario()
        {


            LBApellido.Text = Usuarios.CurrentUsuario.Apellido + ", " + Usuarios.CurrentUsuario.Nombre;
            LBNumero_documento.Text = Usuarios.CurrentUsuario.Numero_Documento.ToString();
            lbcuit.Text = "C. Iva : (" + Usuarios.CurrentUsuario.Condicion_Iva + ") Nro " + Usuarios.CurrentUsuario.CUIT;
            lblLocacioncabeza.Text = String.Format("Locación: {0} NRO: {1} PISO: {2} DEPTO: {3}, ", Usuarios.CurrentUsuario.Calle, Usuarios.CurrentUsuario.Altura, Usuarios.CurrentUsuario.piso, Usuarios.CurrentUsuario.Depto, Usuarios.CurrentUsuario.localidad);
            lbcorreo.Text = "Mail: " + Usuarios.CurrentUsuario.Correo_Electronico;

            LBApellido.Location = new Point(pnlSuperior.Width - LBApellido.Width, LBApellido.Location.Y);
            LBNumero_documento.Location = new Point(LBApellido.Location.X - LBNumero_documento.Width, LBApellido.Location.Y);
            lblLocacioncabeza.Location = new Point(pnlSuperior.Width - lblLocacioncabeza.Width, lblLocacioncabeza.Location.Y);

            lbcorreo.Location = new Point(pnlSuperior.Width - lbcorreo.Width, lbcorreo.Location.Y);
        }
    }
}
