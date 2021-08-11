using CapaNegocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Abms
{
    public partial class frmBusquedaServicios : Form
    {
        private int idItemSeleccionado, nivelSeleccionado, TipoFacturacion, Nivel, IdGrupoSeleccionado, IdTipoServicioSeleccionado, IdServicioSeleccionado, idSubServSeleccionado, IdCatZonaSeleccionada, idTarifaActual;
        private int NivelFila, IndexSeleccionado;
        private int seleccion = Convert.ToInt32(Bonificaciones_Aplicacion.SELECCION.TODOS);
        private bool verDetalles = false;
        private Thread hilo;
        private delegate void myDel();
        private Configuracion oConfiguracion = new Configuracion();
        private Servicios_Categorias oCategorias = new Servicios_Categorias();
        private Zonas oZonas = new Zonas();
        private Servicios oServicios = new Servicios();
        private Servicios_Tipos oServiciosTipos = new Servicios_Tipos();
        private Bonificaciones oBonificaciones = new Bonificaciones();
        private Bonificaciones_Aplicacion oBonificacionesAplicacion = new Bonificaciones_Aplicacion();
        private Servicios_Tarifas oServiciosTarifas = new Servicios_Tarifas();
        private Localidades oLocalidades = new Localidades();
        private DataTable DtDatos = new DataTable();
        private DataTable DtCategoriasZonas = new DataTable();
        private DataTable DtDatosAux = new DataTable();
        private DataTable dtGrupos = new DataTable();
        private DataTable dtTipos = new DataTable();
        private DataTable dtServicios = new DataTable();
        private DataTable dtSubServicios = new DataTable();
        private DataTable DtDatosBonificacion = new DataTable();
        private DataTable DtVelocidadesSubServicio = new DataTable();
        private DataTable dtLocalidades = new DataTable();
        public DataRow DrDatosItem;
        private Tipo_Facturacion oTipoFacturacion = new Tipo_Facturacion();
        private DataTable dtSolicitudes = new DataTable();
        private DataTable dtEquiposTipos = new DataTable();
        private Partes_Solicitudes oPartesSolicitudes = new Partes_Solicitudes();
        private Equipos_Tipos oEquiposTipos = new Equipos_Tipos();
        public bool desplegarFormLocalidades = false;
        public List<int> listaLocalidades = new List<int>();
        private int idCatZona = 0;
        public int idCatZonaRetorno;

        private void ComenzarCarga()
        {
            pgCircular.Start();
            hilo = new Thread(new ThreadStart(CargarDatos));
            hilo.IsBackground = true;
            hilo.Start();
        }

        private void CargarDatos()
        {
            DtDatosAux.Clear();
            if (DtCategoriasZonas.Rows.Count == 0)
            {
                if (TipoFacturacion == Convert.ToInt32(Tipo_Facturacion.Id_Tipo_Facturacion.POR_CATEGORIAS))
                    DtCategoriasZonas = oCategorias.Listar();
                else
                {
                    DtCategoriasZonas = oZonas.Listar();
                    dtLocalidades = oLocalidades.Listar();
                    dtLocalidades.Rows.Add(0, 0, "TODAS", "0", "0", "0", "0");

                }

                if (idCatZona > 0)
                    IdCatZonaSeleccionada = idCatZona;
                else
                {
                    if (DtCategoriasZonas.Rows.Count > 0)
                        IdCatZonaSeleccionada = Convert.ToInt32(DtCategoriasZonas.Rows[0]["id"]);
                }
            }

            dtGrupos = oServicios.ListarGrupos();
            dtTipos = oServiciosTipos.Listar();
            dtServicios = oTipoFacturacion.GetServiciosPorTipo(IdCatZonaSeleccionada);
            foreach (DataRow grupo in dtGrupos.Rows)
            {
                DtDatos.Rows.Add(grupo["id"], IdCatZonaSeleccionada.ToString(), Convert.ToInt32(Bonificaciones_Aplicacion.NIVEL.GRUPO).ToString(), "Grupo", grupo["nombre"], grupo["id"], "0", "0", "0", "0", "0", "", "", "");
                foreach (DataRow tipoDeServicio in dtTipos.Select(String.Format("id_servicios_grupos={0}", grupo["id"].ToString())))
                {
                    DtDatos.Rows.Add(tipoDeServicio["id"], IdCatZonaSeleccionada.ToString(), Convert.ToInt32(Bonificaciones_Aplicacion.NIVEL.TIPO_SERVICIO).ToString(), "Tipo de servicio", "  " + tipoDeServicio["nombre"], tipoDeServicio["id_servicios_grupos"], tipoDeServicio["id"], "0", "0", "0", "0", "", "", "");
                    dtSolicitudes = oPartesSolicitudes.Traer_Por_Tipo_Servicio(Convert.ToInt32(tipoDeServicio["id"]));
                    dtEquiposTipos = oEquiposTipos.ListarPorTipoServicios(Convert.ToInt32(tipoDeServicio["id"]));

                    foreach (DataRow servicio in dtServicios.Select(String.Format("id_tipo={0}", tipoDeServicio["id"].ToString())))
                    {
                        DtDatos.Rows.Add(servicio["id_servicios"], IdCatZonaSeleccionada.ToString(), Convert.ToInt32(Bonificaciones_Aplicacion.NIVEL.SERVICIO).ToString(), "Servicio", "        " + servicio["servicios"], servicio["id_grupo"], servicio["id_tipo"], servicio["id_servicios"], "0", "0", "0", "", "", "");
                        dtSubServicios = oTipoFacturacion.GetServiciosSubPorTipo(IdCatZonaSeleccionada, Convert.ToInt32(servicio["id_servicios"]));
                        foreach (DataRow subservicio in dtSubServicios.Rows)
                            DtDatos.Rows.Add(subservicio["id_servicios_sub"], IdCatZonaSeleccionada.ToString(), Convert.ToInt32(Bonificaciones_Aplicacion.NIVEL.SUBSERVICIO).ToString(), "Sub Servicio", "           " + subservicio["servicios_sub"], servicio["id_grupo"], servicio["id_tipo"], servicio["id_servicios"], subservicio["id_servicios_sub"], "S", servicio["requiere_velocidad"], "", servicio["servicios"], subservicio["idtipodesub"]);

                        if (dtSolicitudes.Rows.Count > 0)
                        {
                            foreach (DataRow solicitud in dtSolicitudes.Select("borrado=0"))
                                DtDatos.Rows.Add(solicitud["id"], IdCatZonaSeleccionada.ToString(), Convert.ToInt32(Bonificaciones_Aplicacion.NIVEL.SUBSERVICIO).ToString(), "Solicitud", "           " + solicitud["nombre"], servicio["id_grupo"], servicio["id_tipo"], servicio["id_servicios"], solicitud["id"], "P", "0", "", servicio["servicios"], "0");
                        }

                        if (dtEquiposTipos.Rows.Count > 0)
                        {
                            foreach (DataRow equipotipo in dtEquiposTipos.Rows)
                                DtDatos.Rows.Add(equipotipo["id"], IdCatZonaSeleccionada.ToString(), Convert.ToInt32(Bonificaciones_Aplicacion.NIVEL.SUBSERVICIO).ToString(), "Equipo", "           " + equipotipo["nombre"], servicio["id_grupo"], servicio["id_tipo"], servicio["id_servicios"], equipotipo["id"], "E", "0", "", servicio["servicios"], "0");
                        }
                        dtSubServicios.Clear();
                    }
                    dtSolicitudes.Clear();
                }
            }
            myDel MD = new myDel(AsignarDatos);
            this.Invoke(MD, new object[] { });
            pgCircular.Stop();
        }

        private void AsignarDatos()
        {
            dgvDatos.DataSource = null;
            dgvDatos.DataSource = DtDatos;
            for (int x = 0; x < dgvDatos.Columns.Count; x++)
                dgvDatos.Columns[x].Visible = false;
            dgvDatos.Columns["nombre"].Visible = true;
            dgvDatos.Columns["nombre"].HeaderText = "Nombre";

            DataRow dr = DtCategoriasZonas.NewRow();
            dr["id"] = "0";
            dr["nombre"] = "TODAS";
            DtCategoriasZonas.Rows.Add(dr);
            cboCatZona.DataSource = DtCategoriasZonas;
            cboCatZona.DisplayMember = "nombre";
            cboCatZona.ValueMember = "id";
            cboCatZona.SelectedValue = IdCatZonaSeleccionada;
            ColorearGrilla();
            OcultarFilas();
            foreach (DataGridViewColumn columna in dgvDatos.Columns)
                columna.SortMode = DataGridViewColumnSortMode.NotSortable;
            if (IndexSeleccionado >= 0 && dgvDatos.Rows.Count > 0)
                dgvDatos.Rows[IndexSeleccionado].Selected = true;
            lblTotal.Text = String.Format("Total de Registros: {0}", dgvDatos.Rows.Count);
        }

        private void ColorearGrilla()
        {
            foreach (DataGridViewRow fila in dgvDatos.Rows)
            {
                NivelFila = Convert.ToInt32(fila.Cells["nivel"].Value);
                if (NivelFila == Convert.ToInt32(Bonificaciones_Aplicacion.NIVEL.GRUPO))
                    fila.DefaultCellStyle.BackColor = Color.MediumSeaGreen;
                else if (NivelFila == Convert.ToInt32(Bonificaciones_Aplicacion.NIVEL.TIPO_SERVICIO))
                    fila.DefaultCellStyle.BackColor = Color.MediumAquamarine;
                else if (NivelFila == Convert.ToInt32(Bonificaciones_Aplicacion.NIVEL.SERVICIO))
                    fila.DefaultCellStyle.BackColor = Color.PaleTurquoise;
                else if (NivelFila == Convert.ToInt32(Bonificaciones_Aplicacion.NIVEL.SUBSERVICIO))
                    fila.DefaultCellStyle.BackColor = Color.LightGray;
            }
        }

        private void OcultarFilas()
        {
            foreach (DataGridViewRow fila in dgvDatos.Rows)
                if (Convert.ToInt32(fila.Cells["nivel"].Value) != Convert.ToInt32(Bonificaciones_Aplicacion.NIVEL.GRUPO))
                    fila.Visible = false;
        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                IndexSeleccionado = dgvDatos.SelectedRows[0].Index;
                VerDetalles();
            }
            catch
            { //MessageBox.Show("Error al seleccionar fila."); 
            }
        }

        private void imgPlLocalidad_Click(object sender, EventArgs e)
        {

        }

        private void VerDetalles()
        {
            idItemSeleccionado = Convert.ToInt32(dgvDatos.SelectedRows[0].Cells["id"].Value);
            nivelSeleccionado = Convert.ToInt32(dgvDatos.SelectedRows[0].Cells["nivel"].Value);
            IdGrupoSeleccionado = Convert.ToInt32(dgvDatos.SelectedRows[0].Cells["id_grupo"].Value);
            IdTipoServicioSeleccionado = Convert.ToInt32(dgvDatos.SelectedRows[0].Cells["id_tipo_servicio"].Value);
            IdServicioSeleccionado = Convert.ToInt32(dgvDatos.SelectedRows[0].Cells["id_servicio"].Value);
            idSubServSeleccionado = Convert.ToInt32(dgvDatos.SelectedRows[0].Cells["id_servicio_sub"].Value);

            if (verDetalles == false)
            {
                verDetalles = true;
                foreach (DataGridViewRow fila in dgvDatos.Rows)
                {
                    if (IdGrupoSeleccionado > 0 && IdTipoServicioSeleccionado == 0 && Convert.ToInt32(fila.Cells["nivel"].Value) == Convert.ToInt32(Bonificaciones_Aplicacion.NIVEL.TIPO_SERVICIO) && Convert.ToInt32(fila.Cells["id_grupo"].Value) == IdGrupoSeleccionado)
                        fila.Visible = true;
                    else if (IdTipoServicioSeleccionado > 0 && IdServicioSeleccionado == 0 && Convert.ToInt32(fila.Cells["nivel"].Value) == Convert.ToInt32(Bonificaciones_Aplicacion.NIVEL.SERVICIO) && Convert.ToInt32(fila.Cells["id_tipo_servicio"].Value) == IdTipoServicioSeleccionado)
                        fila.Visible = true;
                    else if (IdServicioSeleccionado > 0 && idSubServSeleccionado == 0 && Convert.ToInt32(fila.Cells["nivel"].Value) == Convert.ToInt32(Bonificaciones_Aplicacion.NIVEL.SUBSERVICIO) && Convert.ToInt32(fila.Cells["id_servicio"].Value) == IdServicioSeleccionado)
                        fila.Visible = true;
                }
            }
            else
            {
                verDetalles = false;
                foreach (DataGridViewRow fila in dgvDatos.Rows)
                {
                    if (IdGrupoSeleccionado > 0 && IdTipoServicioSeleccionado == 0 && Convert.ToInt32(fila.Cells["id_tipo_servicio"].Value) != 0 && Convert.ToInt32(fila.Cells["id_grupo"].Value) == IdGrupoSeleccionado)
                        fila.Visible = false;
                    else if (IdTipoServicioSeleccionado > 0 && IdServicioSeleccionado == 0 && Convert.ToInt32(fila.Cells["id_servicio"].Value) != 0 && Convert.ToInt32(fila.Cells["id_tipo_servicio"].Value) == IdTipoServicioSeleccionado)
                        fila.Visible = false;
                    else if (IdServicioSeleccionado > 0 && idSubServSeleccionado == 0 && Convert.ToInt32(fila.Cells["id_servicio_sub"].Value) != 0 && Convert.ToInt32(fila.Cells["id_servicio"].Value) == IdServicioSeleccionado)
                        fila.Visible = false;
                }
            }
        }

        private void SetearTitulo()
        {
            if (seleccion == Convert.ToInt32(Bonificaciones_Aplicacion.SELECCION.SERVICIOS_Y_SUBSERVICIOS))
                lblTituloGrilla.Text = String.Format("Seleccione el servicio o sub servicio que requiera:");
            else if (seleccion == Convert.ToInt32(Bonificaciones_Aplicacion.SELECCION.GRUPO))
                lblTituloGrilla.Text = String.Format("Seleccione el grupo que requiera:");
            else if (seleccion == Convert.ToInt32(Bonificaciones_Aplicacion.SELECCION.TIPO_SERVICIO))
                lblTituloGrilla.Text = String.Format("Seleccione el tipo servicio que requiera:");
            else if (seleccion == Convert.ToInt32(Bonificaciones_Aplicacion.SELECCION.SERVICIO))
                lblTituloGrilla.Text = String.Format("Seleccione el servicio que requiera:");
            else if (seleccion == Convert.ToInt32(Bonificaciones_Aplicacion.SELECCION.SUBSERVICIO))
                lblTituloGrilla.Text = String.Format("Seleccione el sub servicio que requiera:");
            else
                lblTituloGrilla.Text = String.Format("Seleccione el grupo/tipo/servicio o sub servicio que requiera:");
        }

        public frmBusquedaServicios(int SeleccionRecibida, int idCatZona)
        {
            seleccion = SeleccionRecibida;
            this.idCatZona = idCatZona;

            InitializeComponent();
        }

        private void ABMBonificaciones_Aplicacion_Load(object sender, EventArgs e)
        {
            DtDatos.Columns.Add("id", typeof(string));
            DtDatos.Columns.Add("id_cat_zona", typeof(string));

            DtDatos.Columns.Add("nivel", typeof(string));
            DtDatos.Columns.Add("textonivel", typeof(string));
            DtDatos.Columns.Add("nombre", typeof(string));
            DtDatos.Columns.Add("id_grupo", typeof(string));
            DtDatos.Columns.Add("id_tipo_servicio", typeof(string));
            DtDatos.Columns.Add("id_servicio", typeof(string));
            DtDatos.Columns.Add("id_servicio_sub", typeof(string));
            DtDatos.Columns.Add("tipo_servicio_sub", typeof(string));
            DtDatos.Columns.Add("requerimiento_velocidad", typeof(string));
            DtDatos.Columns.Add("orden", typeof(string));
            DtDatos.Columns.Add("servicio", typeof(string));
            DtDatos.Columns.Add("idtipodesub", typeof(string));
            TipoFacturacion = oConfiguracion.GetValor_N("Id_Tipo_Facturacion");
            if (TipoFacturacion == Convert.ToInt32(Tipo_Facturacion.Id_Tipo_Facturacion.POR_CATEGORIAS))
                lblZonaCategoria.Text = String.Format("Categoría:");
            else
                lblZonaCategoria.Text = String.Format("Zona:");
            Nivel = Convert.ToInt32(Bonificaciones_Aplicacion.NIVEL.GRUPO);
            oServiciosTarifas.Fecha_Actual = DateTime.Now;
            idTarifaActual = oServiciosTarifas.getTarifa();
            SetearTitulo();
            if (idCatZona > 0)
                IdCatZonaSeleccionada = idCatZona;
            ComenzarCarga();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBonificacionItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count > 0)
            {
                if (seleccion != Convert.ToInt32(Bonificaciones_Aplicacion.SELECCION.TODOS))
                {
                    int nivelSeleccion = Convert.ToInt32(dgvDatos.SelectedRows[0].Cells["nivel"].Value);
                    if (seleccion == Convert.ToInt32(Bonificaciones_Aplicacion.SELECCION.SERVICIOS_Y_SUBSERVICIOS) && (nivelSeleccion == Convert.ToInt32(Bonificaciones_Aplicacion.SELECCION.GRUPO) || nivelSeleccion == Convert.ToInt32(Bonificaciones_Aplicacion.SELECCION.TIPO_SERVICIO)))
                        MessageBox.Show("La bonificación es del tipo repetición. Sólo puede seleccionar servicios y sub servicios.");
                    else if (seleccion == Convert.ToInt32(Bonificaciones_Aplicacion.SELECCION.GRUPO) && seleccion != nivelSeleccion)
                        MessageBox.Show("Sólo puede seleccionar grupos de servicios.");
                    else if (seleccion == Convert.ToInt32(Bonificaciones_Aplicacion.SELECCION.TIPO_SERVICIO) && seleccion != nivelSeleccion)
                        MessageBox.Show("Sólo puede seleccionar tipos de servicios.");
                    else if (seleccion == Convert.ToInt32(Bonificaciones_Aplicacion.SELECCION.SERVICIO) && seleccion != nivelSeleccion)
                        MessageBox.Show("Sólo puede seleccionar servicios.");
                    else if (seleccion == Convert.ToInt32(Bonificaciones_Aplicacion.SELECCION.SUBSERVICIO) && seleccion != nivelSeleccion)
                        MessageBox.Show("Sólo puede seleccionar sub servicios.");
                    else if (seleccion == Convert.ToInt32(Bonificaciones_Aplicacion.SELECCION.GRUPOS_TIPOS_SERVICIOS) && nivelSeleccion == Convert.ToInt32(Bonificaciones_Aplicacion.SELECCION.SUBSERVICIO))
                        MessageBox.Show("Sólo puede seleccionar grupos, tipos y servicios.");
                    else
                    {
                        DrDatosItem = DtDatos.Rows[dgvDatos.SelectedRows[0].Index];
                        if (desplegarFormLocalidades)
                        {
                            Busquedas.frmBusquedaLocalidades frmLocalidades = new Busquedas.frmBusquedaLocalidades(Convert.ToInt32(DrDatosItem["id_cat_zona"]), "zona", String.Format("{0}: {1}", DrDatosItem["textonivel"], DrDatosItem["nombre"]));
                            frmPopUp frmpopup = new frmPopUp();
                            frmpopup.Maximizar = false;
                            frmpopup.Formulario = frmLocalidades;
                            frmpopup.ShowDialog();
                            if (frmLocalidades.DialogResult == DialogResult.OK)
                            {
                                listaLocalidades = frmLocalidades.listaLocalidadesSeleccionadas;
                                this.DialogResult = DialogResult.OK;
                            }
                        }
                        else
                            this.DialogResult = DialogResult.OK;
                    }

                }
                else
                {
                    DrDatosItem = DtDatos.Rows[dgvDatos.SelectedRows[0].Index];
                    if (desplegarFormLocalidades)
                    {
                        Busquedas.frmBusquedaLocalidades frmLocalidades = new Busquedas.frmBusquedaLocalidades(Convert.ToInt32(DrDatosItem["id_cat_zona"]), "zona", String.Format("{0}: {1}", DrDatosItem["textonivel"], DrDatosItem["nombre"]));
                        frmPopUp frmpopup = new frmPopUp();
                        frmpopup.Maximizar = false;
                        frmpopup.Formulario = frmLocalidades;
                        frmpopup.ShowDialog();
                        if (frmLocalidades.DialogResult == DialogResult.OK)
                        {
                            listaLocalidades = frmLocalidades.listaLocalidadesSeleccionadas;
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                    else
                        this.DialogResult = DialogResult.OK;
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            IdCatZonaSeleccionada = Convert.ToInt32(cboCatZona.SelectedValue);
            idCatZonaRetorno = Convert.ToInt32(cboCatZona.SelectedValue);
            IndexSeleccionado = 0;
            DtDatos.Clear();
            DtDatosAux.Clear();

            dgvDatos.DataSource = null;
            Nivel = Convert.ToInt32(Bonificaciones_Aplicacion.NIVEL.GRUPO);
            ComenzarCarga();
        }
    }
}//041119fede
