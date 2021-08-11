using CapaNegocios;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Partes_Trabajo
{
    public partial class frmPartesInformes : Form
    {
        #region PROPIEDADES


        private int idTipoFacturacion, idFiltroSeleccionado, idTipoFechaSeleccionada;
        private bool realizarConsulta = false;
        private string tituloSubTitulo = String.Empty;
        private string consulta = String.Empty;
        private DataTable dtDatosPartes = new DataTable();
        private DataTable dtFiltrosSeleccionados = new DataTable();
        private DataTable dtDatosConceptos = new DataTable();
        private DataTable dtDatosAux = new DataTable();
        private DateTime fechaDesde = new DateTime();
        private DateTime fechaHasta = new DateTime();
        private Thread hilo;
        private delegate void myDel();

        private Partes_Informes oPartesInformes = new Partes_Informes();
        private Partes oParte = new Partes();
        private Configuracion oConfiguracion = new Configuracion();
        private Servicios_Categorias oServiciosCategorias = new Servicios_Categorias();
        private Zonas oZonas = new Zonas();
        private Localidades oLocalidades = new Localidades();
        private Servicios oServicios = new Servicios();
        private Servicios_Tipos oServiciosTipos = new Servicios_Tipos();
        private Agenda_Encabezado oAgendaEncabezado = new Agenda_Encabezado();
        #endregion

        #region MÉTODOS
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
                if (realizarConsulta == false)
                    BuscarDatosConcepto();
                else
                    dtDatosPartes = oPartesInformes.Listar(dtFiltrosSeleccionados, fechaDesde, fechaHasta, idTipoFechaSeleccionada);

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
            if (realizarConsulta == false)
            {
                dgvDatosConceptos.DataSource = null;
                if (idFiltroSeleccionado == Convert.ToInt32(Partes_Informes.Partes_Filtros.TODOS))
                {
                    dtFiltrosSeleccionados.Rows.Add(idFiltroSeleccionado, "0", "Todos", "-------");
                    ActualizarGrillaFiltros();
                }
                else
                {
                    dgvDatosConceptos.DataSource = dtDatosConceptos;
                    dgvDatosConceptos.Columns["idTipoConcepto"].Visible = false;
                    dgvDatosConceptos.Columns["idConcepto"].Visible = false;
                    dgvDatosConceptos.Columns["tipo"].Visible = false;
                    plConceptos.Visible = true;
                    lblTituloPanel.Text = String.Format("{0}", tituloSubTitulo);
                }
            }
            else
            {
                dgvPartes.DataSource = null;
                dgvPartes.DataSource = dtDatosPartes;

                for (int x = 0; x < dgvPartes.Columns.Count; x++)
                    dgvPartes.Columns[x].Visible = false;

                dgvPartes.Columns["id"].Visible = true;
                dgvPartes.Columns["solicitud"].Visible = true;
                dgvPartes.Columns["codigo"].Visible = true;
                dgvPartes.Columns["apellido"].Visible = true;
                dgvPartes.Columns["nombre"].Visible = true;

                dgvPartes.Columns["calle"].Visible = true;
                dgvPartes.Columns["altura"].Visible = true;
                dgvPartes.Columns["localidad"].Visible = true;
                dgvPartes.Columns["operador"].Visible = true;

                dgvPartes.Columns["id"].HeaderText = "Parte";
                dgvPartes.Columns["solicitud"].HeaderText = "Solicitud";
                dgvPartes.Columns["codigo"].HeaderText = "Código de usuario";


                dgvPartes.Columns["calle"].HeaderText = "Calle";
                dgvPartes.Columns["altura"].HeaderText = "Altura";
                dgvPartes.Columns["localidad"].HeaderText = "Localidad";
                dgvPartes.Columns["operador"].HeaderText = "Personal";

                dgvPartes.Columns["id"].Width = 50;
                dgvPartes.Columns["solicitud"].Width = 200;
                dgvPartes.Columns["codigo"].Width = 50;


                dgvPartes.Columns["calle"].Width = 200;
                dgvPartes.Columns["altura"].Width = 50;
                dgvPartes.Columns["localidad"].Width = 200;
                dgvPartes.Columns["operador"].Width = 150;
                AgregarLinkColumn();

                dgvPartes.Columns["id"].ReadOnly = true;
                dgvPartes.Columns["solicitud"].ReadOnly = true;
                dgvPartes.Columns["codigo"].ReadOnly = true;


                dgvPartes.Columns["calle"].ReadOnly = true;
                dgvPartes.Columns["altura"].ReadOnly = true;
                dgvPartes.Columns["localidad"].ReadOnly = true;
                dgvPartes.Columns["operador"].ReadOnly = true;
                dgvPartes.Columns["colVerServicios"].ReadOnly = true;

                lblTotal.Text = String.Format("Total de Registros: {0}", dgvPartes.Rows.Count);
            }
        }

        private void BuscarDatosConcepto()
        {
            if (idFiltroSeleccionado == Convert.ToInt32(Partes_Informes.Partes_Filtros.CATEGORIA))
            {
                dtDatosAux = oServiciosCategorias.Listar();
                foreach (DataRow fila in dtDatosAux.Rows)
                    dtDatosConceptos.Rows.Add(idFiltroSeleccionado, fila["id"].ToString(), "Categoría", fila["nombre"].ToString(), false);
                tituloSubTitulo = "Categorías";
            }
            else if (idFiltroSeleccionado == Convert.ToInt32(Partes_Informes.Partes_Filtros.ZONA))
            {
                dtDatosAux = oZonas.Listar();
                foreach (DataRow fila in dtDatosAux.Rows)
                    dtDatosConceptos.Rows.Add(idFiltroSeleccionado, fila["id"].ToString(), "Zona", fila["nombre"].ToString(), false);
                tituloSubTitulo = "Zonas";
            }
            else if (idFiltroSeleccionado == Convert.ToInt32(Partes_Informes.Partes_Filtros.LOCALIDAD))
            {
                dtDatosAux = oLocalidades.Listar();
                foreach (DataRow fila in dtDatosAux.Rows)
                    dtDatosConceptos.Rows.Add(idFiltroSeleccionado, fila["id"].ToString(), "Localidad", fila["nombre"].ToString(), false);
                tituloSubTitulo = "Localidades";
            }
            else if (idFiltroSeleccionado == Convert.ToInt32(Partes_Informes.Partes_Filtros.OPERACION))
            {
                dtDatosAux = oParte.ListarOperaciones();
                foreach (DataRow fila in dtDatosAux.Rows)
                    dtDatosConceptos.Rows.Add(idFiltroSeleccionado, fila["id"].ToString(), "Operación", fila["nombre"].ToString(), false);
                tituloSubTitulo = "Operaciones";
            }
            else if (idFiltroSeleccionado == Convert.ToInt32(Partes_Informes.Partes_Filtros.GRUPO))
            {
                dtDatosAux = oServicios.ListarGrupos();
                foreach (DataRow fila in dtDatosAux.Rows)
                    dtDatosConceptos.Rows.Add(idFiltroSeleccionado, fila["id"].ToString(), "Grupo de servicio", fila["nombre"].ToString(), false);
                tituloSubTitulo = "Grupos de servicio";
            }
            else if (idFiltroSeleccionado == Convert.ToInt32(Partes_Informes.Partes_Filtros.TIPO))
            {
                dtDatosAux = oServiciosTipos.Listar();
                foreach (DataRow fila in dtDatosAux.Rows)
                    dtDatosConceptos.Rows.Add(idFiltroSeleccionado, fila["id"].ToString(), "Tipo de servicio", fila["nombre"].ToString(), false);
                tituloSubTitulo = "Tipos de servicio";
            }
            else if (idFiltroSeleccionado == Convert.ToInt32(Partes_Informes.Partes_Filtros.SERVICIO))
            {
                dtDatosAux = oServicios.Listar();
                foreach (DataRow fila in dtDatosAux.Rows)
                    dtDatosConceptos.Rows.Add(idFiltroSeleccionado, fila["id"].ToString(), "Servicio", fila["descripcion"].ToString(), false);
                tituloSubTitulo = "Servicio";
            }
            else if (idFiltroSeleccionado == Convert.ToInt32(Partes_Informes.Partes_Filtros.TECNICO))
            {
                dtDatosAux = oAgendaEncabezado.Buscar_tecnico();
                foreach (DataRow fila in dtDatosAux.Rows)
                    dtDatosConceptos.Rows.Add(idFiltroSeleccionado, fila["id"].ToString(), "Técnico", fila["nombre"].ToString(), false);
                tituloSubTitulo = "Técnico";
            }
        }

        private void AgregarConceptoAGrillaFiltros()
        {
            foreach (DataRow fila in dtDatosConceptos.Rows)
            {
                if (fila["Seleccionar"] != DBNull.Value && Convert.ToBoolean(fila["Seleccionar"]) == true)
                    dtFiltrosSeleccionados.Rows.Add(fila["idTipoConcepto"], fila["idConcepto"], fila["Tipo"], fila["Nombre"]);
            }
            plConceptos.Visible = false;
            dtDatosAux.Clear();
            dtDatosConceptos.Clear();
            dgvDatosConceptos.DataSource = null;
            ActualizarGrillaFiltros();
        }

        private void ActualizarGrillaFiltros()
        {
            dgvFiltrosSeleccionados.DataSource = null;
            dgvFiltrosSeleccionados.DataSource = dtFiltrosSeleccionados;
            dgvFiltrosSeleccionados.Columns["idTipoConcepto"].Visible = false;
            dgvFiltrosSeleccionados.Columns["idConcepto"].Visible = false;
        }

        private void QuitarFiltro()
        {
            if (dgvFiltrosSeleccionados.Rows.Count > 0)
            {
                dtFiltrosSeleccionados.Rows.RemoveAt(dgvFiltrosSeleccionados.SelectedRows[0].Index);
                ActualizarGrillaFiltros();
            }
            else
                MessageBox.Show("No hay datos en la grilla.");
        }

        private void AgregarFiltro()
        {
            realizarConsulta = false;
            idFiltroSeleccionado = Convert.ToInt32(cboFiltroConcepto.SelectedIndex);
            dtDatosAux.Clear();
            dtDatosConceptos.Clear();
            dgvDatosConceptos.DataSource = null;
            if (dtFiltrosSeleccionados.Select(String.Format("idTipoConcepto={0}", Convert.ToInt32(Partes_Informes.Partes_Filtros.TODOS))).Length == 0)
            {
                if (dtFiltrosSeleccionados.Rows.Count > 0 && dtFiltrosSeleccionados.Select(String.Format("idTipoConcepto={0}", idFiltroSeleccionado)).Length > 0)
                    MessageBox.Show("Ya se agregó un concepto de este tipo a la grilla.");
                else
                    comenzarCarga();
            }
            else
                MessageBox.Show("Ya se agregó el filtro TODOS a las opciones de búsqueda. Quitelo de la grilla para agregar filtros distintos.");
        }

        private void AgregarLinkColumn()
        {
            int IndexColumn = -1;
            IndexColumn = -1;
            DataGridViewLinkColumn ColVerServicios = new DataGridViewLinkColumn();
            ColVerServicios.Name = "ColVerServicios";
            ColVerServicios.HeaderText = "Servicios";
            ColVerServicios.Text = "Ver";
            ColVerServicios.Width = 50;
            ColVerServicios.UseColumnTextForLinkValue = true;
            ColVerServicios.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            IndexColumn = dgvPartes.Columns.IndexOf(ColVerServicios);
            if (IndexColumn >= 0)
                dgvPartes.Columns.RemoveAt(IndexColumn);
            dgvPartes.Columns.Add(ColVerServicios);
        }

        private void BusquedaEnGrillaPartes()
        {
            int Id = 0;
            if (txtBuscar.Text.Length > 0)
            {

                if (Int32.TryParse(txtBuscar.Text, out Id))
                    dtDatosPartes.DefaultView.RowFilter = String.Format("id='" + txtBuscar.Text + "'");
                else
                    dtDatosPartes.DefaultView.RowFilter = String.Format("servicio Like '%" + txtBuscar.Text + "%' or apellido Like '%" + txtBuscar.Text + "%' or nombre Like '%" + txtBuscar.Text + "%' or solicitud Like '%" + txtBuscar.Text + "%' or estado Like '%" + txtBuscar.Text + "%'  or localidad Like '%" + txtBuscar.Text + "%'");

            }
            else
                dtDatosPartes.DefaultView.RowFilter = "id>0";
        }
        #endregion

        public frmPartesInformes()
        {
            InitializeComponent();
        }

        private void frmPartesInformes_Load(object sender, EventArgs e)
        {
            cboFiltroConcepto.DataSource = Enum.GetValues(typeof(Partes_Informes.Partes_Filtros));
            cboTipoFecha.DataSource = Enum.GetValues(typeof(Partes_Informes.Tipo_Fecha));
            idTipoFacturacion = oConfiguracion.GetValor_N("Id_Tipo_Facturacion");

            dtFiltrosSeleccionados.Columns.Add("idTipoConcepto", typeof(string));
            dtFiltrosSeleccionados.Columns.Add("idConcepto", typeof(string));
            dtFiltrosSeleccionados.Columns.Add("Tipo", typeof(string));
            dtFiltrosSeleccionados.Columns.Add("Concepto", typeof(string));

            dtDatosConceptos.Columns.Add("idTipoConcepto", typeof(string));
            dtDatosConceptos.Columns.Add("idConcepto", typeof(string));
            dtDatosConceptos.Columns.Add("Tipo", typeof(string));
            dtDatosConceptos.Columns.Add("Nombre", typeof(string));
            dtDatosConceptos.Columns.Add("Seleccionar", typeof(bool));
        }

        private void frmPartesInformes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            realizarConsulta = true;
            fechaDesde = dtpFechaDesde.Value;
            fechaHasta = dtpFechaHasta.Value;
            idTipoFechaSeleccionada = cboTipoFecha.SelectedIndex;
            comenzarCarga();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarFiltro();
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            QuitarFiltro();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BusquedaEnGrillaPartes();
        }

        private void dgvPartes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPartes.Columns[e.ColumnIndex].Name.Equals("ColVerServicios"))
            {
                frmServiciosDelParte frmServiciosParte = new frmServiciosDelParte(Convert.ToInt32(dgvPartes.SelectedRows[0].Cells["id"].Value));
                frmPopUp frmpopup = new frmPopUp();
                frmpopup.Maximizar = false;
                frmpopup.Formulario = frmServiciosParte;
                frmpopup.ShowDialog();

            }
        }

        private void imgPlLocalidad_Click(object sender, EventArgs e)
        {
            plConceptos.Visible = false;
        }

        private void btnAsignarLocalidad_Click(object sender, EventArgs e)
        {
            AgregarConceptoAGrillaFiltros();
        }
    }
}
