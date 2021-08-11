using CapaNegocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;

namespace CapaPresentacion.Partes_Trabajo
{
    public partial class frmListadoBajasServicio : Form
    {
        private Partes oPartes = new Partes();
        private Usuarios_Servicios oUsuariosServicios = new Usuarios_Servicios();
        private Partes_Usuarios_Servicios oPartesUsuariosServicios = new Partes_Usuarios_Servicios();
        private Servicios_Estados_Historial oServiciosEstadosHistorial = new Servicios_Estados_Historial();
        private Thread hilo;
        private delegate void myDel();
        private DataTable dtPartes = new DataTable();
        private DateTime fechaDesde, fechaHasta;
        private Partes.Tipo_Fecha oTipoFecha;
        private bool yaCargo = false;

        //VARIABLES PARA EL CASS
        DataTable dtAplicacionesFiltradas = Tablas.DataCass;
        Cass oCass;

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
                dtPartes = oPartes.ListarPorRangoDeFechas(fechaDesde, fechaHasta, oTipoFecha, idTipoServicio : 0, filtrarRealizadosYAnulados : true);
                if (dtPartes.Rows.Count > 0)
                {
                    DataView dtvPartes = new DataView(dtPartes);
                    dtvPartes.RowFilter = String.Format("id_partes_operaciones in (1,2,3,4,17,18)");
                    dtPartes = dtvPartes.ToTable();
                }
                myDel MD = new myDel(AsignarDatos);
                this.Invoke(MD, new object[] { });
            }
            catch
            {
                //throw;
                MessageBox.Show("Error al cargar información.");
            }
            pgCircular.Stop();
        }

        private void AsignarDatos()
        {

            DataColumn colSeleccion = new DataColumn("colSeleccion", typeof(bool));
            colSeleccion.DefaultValue = true;

            dtPartes.Columns.Add(colSeleccion);

            dgvPartes.DataSource = dtPartes;
            for (int x = 0; x < dgvPartes.Columns.Count; x++)
                dgvPartes.Columns[x].Visible = false;

            dgvPartes.Columns["id"].Visible = true;
            dgvPartes.Columns["id"].DisplayIndex = 0;

            dgvPartes.Columns["fecha_programado"].Visible = true;
            dgvPartes.Columns["fecha_programado"].DisplayIndex = 8;

            dgvPartes.Columns["estado"].Visible = true;
            dgvPartes.Columns["estado"].DisplayIndex = 9;

            dgvPartes.Columns["solicitud"].Visible = true;
            dgvPartes.Columns["solicitud"].DisplayIndex = 8;

            dgvPartes.Columns["codigo_usuario"].Visible = true;
            dgvPartes.Columns["codigo_usuario"].DisplayIndex = 1;

            dgvPartes.Columns["usuario"].Visible = true;
            dgvPartes.Columns["usuario"].DisplayIndex = 2;

            dgvPartes.Columns["servicio"].Visible = true;
            dgvPartes.Columns["servicio"].DisplayIndex = 6;

            dgvPartes.Columns["calle"].Visible = true;
            dgvPartes.Columns["calle"].DisplayIndex = 4;

            dgvPartes.Columns["altura"].Visible = true;
            dgvPartes.Columns["altura"].DisplayIndex = 5;

            dgvPartes.Columns["localidad"].Visible = true;
            dgvPartes.Columns["localidad"].DisplayIndex = 3;

            dgvPartes.Columns["operador"].Visible = true;
            dgvPartes.Columns["operador"].DisplayIndex = 7;

            dgvPartes.Columns["colSeleccion"].Visible = true;

            dgvPartes.Columns["codigo_usuario"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPartes.Columns["id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPartes.Columns["altura"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPartes.Columns["solicitud"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPartes.Columns["localidad"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPartes.Columns["servicio"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPartes.Columns["operador"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dgvPartes.Columns["id"].HeaderText = "Parte";
            dgvPartes.Columns["fecha_programado"].HeaderText = "F. Programado";
            dgvPartes.Columns["solicitud"].HeaderText = "Solicitud";
            dgvPartes.Columns["codigo_usuario"].HeaderText = "Cód. Usuario";
            dgvPartes.Columns["usuario"].HeaderText = "Usuario";
            dgvPartes.Columns["servicio"].HeaderText = "Servicio";
            dgvPartes.Columns["calle"].HeaderText = "Calle";
            dgvPartes.Columns["altura"].HeaderText = "Altura";
            dgvPartes.Columns["localidad"].HeaderText = "Localidad";
            dgvPartes.Columns["operador"].HeaderText = "Personal";
            dgvPartes.Columns["colSeleccion"].HeaderText = "Seleccionar";

            dgvPartes.ReadOnly = false;
            dgvPartes.Columns["id"].ReadOnly = true;
            dgvPartes.Columns["solicitud"].ReadOnly = true;
            dgvPartes.Columns["codigo_usuario"].ReadOnly = true;
            dgvPartes.Columns["usuario"].ReadOnly = true;
            dgvPartes.Columns["servicio"].ReadOnly = true;
            dgvPartes.Columns["calle"].ReadOnly = true;
            dgvPartes.Columns["altura"].ReadOnly = true;
            dgvPartes.Columns["localidad"].ReadOnly = true;
            dgvPartes.Columns["operador"].ReadOnly = true;
            dgvPartes.Columns["colSeleccion"].ReadOnly = false;


            lblTotal.Text = String.Format("Total de Registros: {0}", dgvPartes.Rows.Count);


            try
            {
                dgvPartes.Rows[dgvPartes.Rows.Count - 1].Selected = true;
            }
            catch { }

            if(yaCargo == false)
            {
                dtPartes.Columns.Add("idEstadoAppExterna", typeof(Int32));
                dtPartes.Columns.Add("Detalle", typeof(String));
            }
            btnGenerarCortes.Enabled = true;
            btnBuscar.Enabled = true;


        }

        private void GenerarCortes(bool operacionFinal = false)
        {
            int contErrores = 0;
            List<int> listaPartesSeleccionados = new List<int>();
            foreach (DataGridViewRow fila in dgvPartes.Rows)
            {
                if (fila.Cells["colSeleccion"].Value != DBNull.Value)
                {
                    if (Convert.ToBoolean(fila.Cells["colSeleccion"].Value))
                        listaPartesSeleccionados.Add(Convert.ToInt32(fila.Cells["id"].Value));
                }
            }
             if (listaPartesSeleccionados.Count > 0)
             {
                 DataTable dtUsuariosServicios = new DataTable();
                 foreach (int parte in listaPartesSeleccionados)
                 {
                     dtUsuariosServicios.Clear();
                     dtUsuariosServicios = oPartesUsuariosServicios.ListarServiciosPorParte(parte, Partes_Usuarios_Servicios.CONDICION_REQ_EQUIPOS.TODOS);
                     if (dtUsuariosServicios.Rows.Count > 0)
                     {
                         foreach (DataRow servicio in dtUsuariosServicios.Rows)
                         {
                            DateTime fechaProgramado = new DateTime();
                            fechaProgramado = Convert.ToDateTime(servicio["Programado"]);
                             try
                             {
                                int id_usuario_servicio_sub = 0, id_parteActual = 0;
                                id_parteActual = Convert.ToInt32(servicio["id_parte"].ToString());
                                if (operacionFinal == false)
                                {
                                    if (Convert.ToInt32(servicio["id_partes_operaciones"]) == (int)Partes.Partes_Operaciones.BAJA)
                                    {
                                        int id_corte = Convert.ToInt32(servicio["id_Corte"]);
                                        oUsuariosServicios.ActualizarEstadoCorte(Convert.ToInt32(servicio["id_usuarios_servicios"]), id_corte);
                                        oUsuariosServicios.ActualizarFechaEstado(Convert.ToInt32(servicio["id_usuarios_servicios"].ToString()), DateTime.Now);
                                        oServiciosEstadosHistorial.id_servicios = Convert.ToInt32(servicio["id_servicios"].ToString());
                                        oServiciosEstadosHistorial.id_usuarios = Convert.ToInt32(servicio["id_usuarios"].ToString());
                                        oServiciosEstadosHistorial.id_usuarios_servicios = Convert.ToInt32(servicio["id_usuarios_servicios"].ToString());
                                        oServiciosEstadosHistorial.fecha = DateTime.Now;
                                        oServiciosEstadosHistorial.Guardar(oServiciosEstadosHistorial);
                                    }
                                    else if (Convert.ToInt32(servicio["id_partes_operaciones"]) == (int)Partes.Partes_Operaciones.QUITAR_SUBSERVICIO)
                                    {
                                        id_usuario_servicio_sub = Convert.ToInt32(servicio["id_usu_serv_sub"].ToString());
                                        oUsuariosServicios.QuitarSubservicio(id_usuario_servicio_sub);

                                    }
                                    else if(Convert.ToInt32(servicio["id_partes_operaciones"]) == (int)Partes.Partes_Operaciones.AGREGAR_SUBSERVICIO)
                                    {
                                        id_usuario_servicio_sub = Convert.ToInt32(servicio["id_usu_serv_sub"].ToString());
                                        oUsuariosServicios.ActualizarEstadoUsuarioServicioSub(id_usuario_servicio_sub,(int)Borrados.Estado.Activo);
                                    }
                                    btnConfirmaAcciones.Enabled = true;
                                }
                                else
                                {
                                    //if()
                                    if(Convert.ToInt32(servicio["id_app_ext"]) == (int) Aplicaciones_Externas.Aplicacion_Externa.CASS ||
                                       Convert.ToInt32(servicio["id_app_ext"]) == (int)Aplicaciones_Externas.Aplicacion_Externa.ISP)
                                    {
                                        DataTable dtResultado = new DataTable();
                                        dtResultado.Clear();
                                        dtResultado.Columns.Add("Detalle", typeof(String));
                                        dtResultado.Columns.Add("idEstadoAppExterna", typeof(Int32));
                                        int tipoSalidaParte = 0;
                                        string salidaCadenaParte = "", salidaCadenaCass = "", salidaOperacionesFinal = "";
                                        if (fechaProgramado.Date == DateTime.Now.Date)
                                        {
                                            if (oPartes.gestionarAppExternaIdParte(id_parteActual, out salidaCadenaCass, out salidaOperacionesFinal) == 1)
                                            {
                                                oPartes.ConfirmarParte(id_parteActual, 0, "Baja de Servicio", DateTime.Now, Partes.TipoProblemas.OTRO, "Baja de Servicio", 1, out tipoSalidaParte, out salidaCadenaParte);
                                                foreach (DataGridViewRow data in dgvPartes.Rows)
                                                {
                                                    if (Convert.ToInt32(dgvPartes.Rows[data.Index].Cells["id"].Value) == id_parteActual)
                                                    {
                                                        data.Cells["idEstadoAppExterna"].Value = (int)Aplicaciones_Externas.Estado_Acciones.EXITOSA;
                                                        data.Cells["Detalle"].Value = salidaOperacionesFinal.ToString();
                                                        data.DefaultCellStyle.BackColor = Color.SeaGreen;
                                                        data.DefaultCellStyle.SelectionBackColor = Color.SeaGreen;
                                                    }
                                                }

                                            }
                                            else
                                            {
                                                foreach (DataGridViewRow data in dgvPartes.Rows)
                                                {
                                                    if (Convert.ToInt32(dgvPartes.Rows[data.Index].Cells["id"].Value) == id_parteActual)
                                                    {
                                                        data.Cells["idEstadoAppExterna"].Value = (int)Aplicaciones_Externas.Estado_Acciones.FALLIDA;
                                                        data.Cells["Detalle"].Value = salidaCadenaCass.ToString();
                                                        data.DefaultCellStyle.BackColor = Color.Red;
                                                        data.DefaultCellStyle.SelectionBackColor = Color.Red;
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {

                                            foreach (DataGridViewRow data in dgvPartes.Rows)
                                            {
                                                if (Convert.ToInt32(dgvPartes.Rows[data.Index].Cells["id"].Value) == id_parteActual)
                                                {
                                                    data.Cells["idEstadoAppExterna"].Value = (int)Aplicaciones_Externas.Estado_Acciones.FALLIDA;
                                                    data.Cells["Detalle"].Value = "NO ES LA FECHA DE PROGRAMADO.";
                                                    data.DefaultCellStyle.BackColor = Color.Red;
                                                    data.DefaultCellStyle.SelectionBackColor = Color.Red;
                                                }
                                            }
                                        }
                                        
                                    }
                                    else
                                    {
                                        if (fechaProgramado.Date == DateTime.Now.Date) {
                                            foreach (DataGridViewRow data in dgvPartes.Rows)
                                            {
                                                if (Convert.ToInt32(dgvPartes.Rows[data.Index].Cells["id"].Value) == id_parteActual)
                                                {
                                                    data.Cells["idEstadoAppExterna"].Value = (int)Aplicaciones_Externas.Estado_Acciones.EXITOSA;
                                                    data.Cells["Detalle"].Value = "No pertence a aplicaciones externas, exitoso";
                                                    data.DefaultCellStyle.BackColor = Color.SeaGreen;
                                                    data.DefaultCellStyle.SelectionBackColor = Color.SeaGreen;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            foreach (DataGridViewRow data in dgvPartes.Rows)
                                            {
                                                if (Convert.ToInt32(dgvPartes.Rows[data.Index].Cells["id"].Value) == id_parteActual)
                                                {
                                                    data.Cells["idEstadoAppExterna"].Value = (int)Aplicaciones_Externas.Estado_Acciones.FALLIDA;
                                                    data.Cells["Detalle"].Value = "No es la fecha de programado";
                                                    data.DefaultCellStyle.BackColor = Color.Red;
                                                    data.DefaultCellStyle.SelectionBackColor = Color.Red;
                                                }
                                            }
                                        }
 
                                        
                                    }
                                    btnConfirmaAcciones.Enabled = false;

                                }
                             }
                             catch(Exception ex)
                             {
                                string msg = ex.ToString();
                                 contErrores++;
                             }
                            dgvPartes.Refresh();
                         }

                     }
                 }
                 if (contErrores == 0)
                     MessageBox.Show("Operación realizada correctamente.");
                 else
                     MessageBox.Show("Error al realizar operación.");

                //ComenzarCarga();

             }
             else
                 MessageBox.Show("No se ha seleccionado ningún parte.");
            
        }

        private void colorearGrilla()
        {

        }

        private void BusquedaEnGrillaPartes()
        {
            int Id = 0;
            if (txtBuscar.Text.Length > 0)
            {

                if (Int32.TryParse(txtBuscar.Text, out Id))
                    dtPartes.DefaultView.RowFilter = String.Format("id='" + txtBuscar.Text + "' or codigo_usuario='" + txtBuscar.Text + "'");
                else
                    dtPartes.DefaultView.RowFilter = String.Format("servicio Like '%" + txtBuscar.Text + "%' or usuario Like '%" + txtBuscar.Text + "%' or solicitud Like '%" + txtBuscar.Text + "%' or estado Like '%" + txtBuscar.Text + "%'  or localidad Like '%" + txtBuscar.Text + "%'");

            }
            else
                dtPartes.DefaultView.RowFilter = "id>0";

        }

        private void frmListadoBajasServicio_Load(object sender, EventArgs e)
        {
            btnConfirmaAcciones.Enabled = false;
            fechaDesde = new DateTime();
            fechaHasta = new DateTime();
            fechaDesde = dtpFechaDesde.Value;
            fechaHasta = dtpFechaHasta.Value;
            oTipoFecha = Partes.Tipo_Fecha.FECHA_PROGRAMADO;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            btnBuscar.Enabled = false;
            btnConfirmaAcciones.Enabled = false;
            btnGenerarCortes.Enabled = false;
            fechaDesde = dtpFechaDesde.Value;
            fechaHasta = dtpFechaHasta.Value;
            ComenzarCarga();
        }

        private void btnGenerarCortes_Click(object sender, EventArgs e)
        {
            if (dgvPartes.Rows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Seguro que desea generar Acciones?", "Generar Acciones", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                    GenerarCortes(false);
            }

            else
                MessageBox.Show("No hay partes en la grilla.");
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BusquedaEnGrillaPartes();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListadoBajasServicio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Tools tools = new Tools();
            tools.ExportToExcel(dgvPartes, "CORTES");
        }

        private void btnConfirmaAcciones_Click(object sender, EventArgs e)
        {
            if (dgvPartes.Rows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Desea confirmar partes y confirmar las acciones?", "Confirmar Acciones", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                    GenerarCortes(true);
            }

            else
                MessageBox.Show("No hay partes en la grilla.");
        }

        public frmListadoBajasServicio()
        {
            InitializeComponent();
        }
    }
}//300919fede
