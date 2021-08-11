using CapaNegocios;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacion.Informes
{
    public partial class frmConsultaEquipoUsuario : Form
    {
        #region PROPIEDADES
        private Configuracion oConfig = new Configuracion();
        private DataTable dtTipoEquipo = new DataTable();
        private DataTable dtEstadoEquipo = new DataTable();
        private DataTable dtMarcaEquipo = new DataTable();
        private DataTable dtModeloEquipo = new DataTable();
        private DataTable dtLocalidad = new DataTable();
        private DataTable dtCalle = new DataTable();
        private DataTable dtTipoFacturacion = new DataTable();
        private DataTable dtTipoServicio = new DataTable();
        private DataTable dtModalidad = new DataTable();
        private DataTable dtServicio = new DataTable();
        private DataTable dtAltura = new DataTable();
        private bool cargando = false;
        private bool asignados = false;
        public int tipoEquipoSeleccionado = -2;
        public int estadoEquipoSeleccionado = -2;
        public int marcaEquipoSeleccionado = -2;
        public int modeloEquipoSeleccionado = -2;
        public int localidadSeleccionado = -2;
        public int calleSeleccionado = -2;
        public int alturaSeleccionado = -2;
        public int tipoFiltroAlturaSeleccionado = -2;
        public int tipoFacturacionSeleccionado = -2;
        public int TipoServicioSeleccionado = -2;
        public int modalidadSeleccionado = -2;
        public int servicioSeleccionado = -2;

        #endregion
        #region METODOS

        #endregion
        public frmConsultaEquipoUsuario()
        {
            InitializeComponent();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frmConsultaEquipoUsuario_Load(object sender, EventArgs e)
        {

            dtTipoEquipo = Tablas.DataEquiposTipos.Copy();
            dtEstadoEquipo = Tablas.DataEquiposEstados.Copy();
            dtMarcaEquipo = Tablas.DataEquiposMarcas.Copy();
            dtModeloEquipo = Tablas.DataEquiposModelos.Copy();
            dtLocalidad = Tablas.DataLocalidades.Copy();
            dtCalle = Tablas.DataCalles.Copy();
            dtTipoFacturacion = Tablas.DataTiposFacturacion.Copy();
            dtTipoServicio = Tablas.DataServicios_Tipos.Copy();
            dtModalidad = Tablas.DataServicios_Modalidades.Copy();
            dtServicio = Tablas.DataServicios.Copy();
            dtAltura.Columns.Add("nombre", typeof(string));
            dtAltura.Columns.Add("id", typeof(int));

            dtAltura.Rows.Add(">", 1);
            dtAltura.Rows.Add("=", 2);
            dtAltura.Rows.Add("<", 3);


            // TIPO EQUIPO
            DataRow drTipoEquipoSeleccionar = dtTipoEquipo.NewRow();
            drTipoEquipoSeleccionar["id"] = -1;
            drTipoEquipoSeleccionar["nombre"] = "SELECCIONAR";
            dtTipoEquipo.Rows.Add(drTipoEquipoSeleccionar);
            DataRow drTipoEquipoTodos = dtTipoEquipo.NewRow();
            drTipoEquipoTodos["id"] = -2;
            drTipoEquipoTodos["nombre"] = "TODOS";
            dtTipoEquipo.Rows.Add(drTipoEquipoTodos);

            // ESTADO EQUIPO
            dtEstadoEquipo.Clear();
            DataRow drEstadoEquipoSeleccionar = dtEstadoEquipo.NewRow();
            drEstadoEquipoSeleccionar["id"] = 3;
            drEstadoEquipoSeleccionar["nombre"] = "ASIGNADO A USUARIO";
            dtEstadoEquipo.Rows.Add(drEstadoEquipoSeleccionar);
            //DataRow drEstadoEquipoTodos = dtEstadoEquipo.NewRow();
            //drEstadoEquipoTodos["id"] = -2;
            //drEstadoEquipoTodos["nombre"] = "TODOS";
            //dtEstadoEquipo.Rows.Add(drEstadoEquipoTodos);


            // MARCA EQUIPO
            DataRow drMarcaEquipoSeleccionar = dtMarcaEquipo.NewRow();
            drMarcaEquipoSeleccionar["id"] = -1;
            drMarcaEquipoSeleccionar["nombre"] = "SELECCIONAR";
            dtMarcaEquipo.Rows.Add(drMarcaEquipoSeleccionar);
            DataRow drMarcaEquipoTodos = dtMarcaEquipo.NewRow();
            drMarcaEquipoTodos["id"] = -2;
            drMarcaEquipoTodos["nombre"] = "TODOS";
            dtMarcaEquipo.Rows.Add(drMarcaEquipoTodos);

            // MODELO EQUIPO
            DataRow drModeloEquipoSeleccionar = dtModeloEquipo.NewRow();
            drModeloEquipoSeleccionar["id"] = -1;
            drModeloEquipoSeleccionar["nombre"] = "SELECCIONAR";
            dtModeloEquipo.Rows.Add(drModeloEquipoSeleccionar);
            DataRow drModeloEquipoTodos = dtModeloEquipo.NewRow();
            drModeloEquipoTodos["id"] = -2;
            drModeloEquipoTodos["nombre"] = "TODOS";
            dtModeloEquipo.Rows.Add(drModeloEquipoTodos);

            // LOCALIDADES
            DataRow drLocalidadesSeleccionar = dtLocalidad.NewRow();
            drLocalidadesSeleccionar["id"] = -1;
            drLocalidadesSeleccionar["nombre"] = "SELECCIONAR";
            dtLocalidad.Rows.Add(drLocalidadesSeleccionar);
            DataRow drLocalidadesTodos = dtLocalidad.NewRow();
            drLocalidadesTodos["id"] = -2;
            drLocalidadesTodos["nombre"] = "TODOS";
            dtLocalidad.Rows.Add(drLocalidadesTodos);

            // CALLES
            DataRow drCallesSeleccionar = dtCalle.NewRow();
            drCallesSeleccionar["id"] = -1;
            drCallesSeleccionar["nombre"] = "SELECCIONAR";
            dtCalle.Rows.Add(drCallesSeleccionar);
            DataRow drCallesTodos = dtCalle.NewRow();
            drCallesTodos["id"] = -2;
            drCallesTodos["nombre"] = "TODOS";
            dtCalle.Rows.Add(drCallesTodos);

            // TIPO FACTURACION
            DataRow drTipoFacSeleccionar = dtTipoFacturacion.NewRow();
            drTipoFacSeleccionar["id"] = -1;
            drTipoFacSeleccionar["nombre"] = "SELECCIONAR";
            dtTipoFacturacion.Rows.Add(drTipoFacSeleccionar);
            DataRow drTipoFacTodos = dtTipoFacturacion.NewRow();
            drTipoFacTodos["id"] = -2;
            drTipoFacTodos["nombre"] = "TODOS";
            dtTipoFacturacion.Rows.Add(drTipoFacTodos);

            // TIPO SERVICIO
            DataRow drTipoServicioSeleccionar = dtTipoServicio.NewRow();
            drTipoServicioSeleccionar["id"] = -1;
            drTipoServicioSeleccionar["nombre"] = "SELECCIONAR";
            dtTipoServicio.Rows.Add(drTipoServicioSeleccionar);
            DataRow drTipoServicioTodos = dtTipoServicio.NewRow();
            drTipoServicioTodos["id"] = -2;
            drTipoServicioTodos["nombre"] = "TODOS";
            dtTipoServicio.Rows.Add(drTipoServicioTodos);

            // MODALIDAD SERVICIO
            DataRow drModalidadServicioSeleccionar = dtModalidad.NewRow();
            drModalidadServicioSeleccionar["id"] = -1;
            drModalidadServicioSeleccionar["nombre"] = "SELECCIONAR";
            dtModalidad.Rows.Add(drModalidadServicioSeleccionar);
            DataRow drModalidadServicioTodos = dtModalidad.NewRow();
            drModalidadServicioTodos["id"] = -2;
            drModalidadServicioTodos["nombre"] = "TODOS";
            dtModalidad.Rows.Add(drModalidadServicioTodos);


            //  SERVICIO
            DataRow drServicioSeleccionar = dtServicio.NewRow();
            drServicioSeleccionar["id"] = -1;
            drServicioSeleccionar["descripcion"] = "SELECCIONAR";
            dtServicio.Rows.Add(drServicioSeleccionar);
            DataRow drServicioTodos = dtServicio.NewRow();
            drServicioTodos["id"] = -2;
            drServicioTodos["descripcion"] = "TODOS";
            dtServicio.Rows.Add(drServicioTodos);

            cboTipoEquipo.DataSource = dtTipoEquipo;
            cboTipoEquipo.ValueMember = "id";
            cboTipoEquipo.DisplayMember = "nombre";
            cboTipoEquipo.SelectedValue =-1;


            cboEstado.DataSource = dtEstadoEquipo;
            cboEstado.ValueMember = "id";
            cboEstado.DisplayMember = "nombre";
            cboEstado.SelectedIndex = 0;

            cboMarca.DataSource = dtMarcaEquipo;
            cboMarca.ValueMember = "id";
            cboMarca.DisplayMember = "nombre";
            cboMarca.SelectedValue = -1;

            cboModelo.DataSource = dtModeloEquipo;
            cboModelo.ValueMember = "id";
            cboModelo.DisplayMember = "nombre";
            cboModelo.SelectedValue = -1;

            cboLocalidad.DataSource = dtLocalidad;
            cboLocalidad.ValueMember = "id";
            cboLocalidad.DisplayMember = "nombre";
            cboLocalidad.SelectedValue = -1;

            cboCalle.DataSource = dtCalle;
            cboCalle.ValueMember = "id";
            cboCalle.DisplayMember = "nombre";
            cboCalle.SelectedValue = -1;

            cboAltura.DataSource = dtAltura;
            cboAltura.ValueMember = "id";
            cboAltura.DisplayMember = "nombre";
            cboAltura.SelectedValue = 1;

            cboTipoFacturacion.DataSource = dtTipoFacturacion;
            cboTipoFacturacion.ValueMember = "id";
            cboTipoFacturacion.DisplayMember = "nombre";
            cboTipoFacturacion.SelectedValue = -1;

            cboTipoServicio.DataSource = dtTipoServicio;
            cboTipoServicio.ValueMember = "id";
            cboTipoServicio.DisplayMember = "nombre";
            cboTipoServicio.SelectedValue = -1;

            cboModalidad.DataSource = dtModalidad;
            cboModalidad.ValueMember = "id";
            cboModalidad.DisplayMember = "nombre";
            cboModalidad.SelectedValue = -1;

            cboServicio.DataSource = dtServicio;
            cboServicio.ValueMember = "id";
            cboServicio.DisplayMember = "descripcion";
            cboServicio.SelectedValue = -1;

            cargando = true;
        }

        private void cboTipoEquipo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            tipoEquipoSeleccionado = Convert.ToInt32(cboTipoEquipo.SelectedValue);
            if (tipoEquipoSeleccionado == -1)
            {
                cboMarca.Enabled = false;
                cboMarca.SelectedValue = -1;
                cboModelo.Enabled = false;
                cboModelo.SelectedValue = -1;
                cboEstado.Enabled = false;
                cboEstado.SelectedValue = -1;
            }
            else if (tipoEquipoSeleccionado == -2 || tipoEquipoSeleccionado >0)
                cboMarca.Enabled = true;
        }

        private void cboMarca_SelectionChangeCommitted(object sender, EventArgs e)
        {
            marcaEquipoSeleccionado = Convert.ToInt32(cboMarca.SelectedValue);
            if (marcaEquipoSeleccionado == -1)
            {
                cboModelo.Enabled = false;
                cboModelo.SelectedValue = -1;
                cboEstado.Enabled = false;
                cboEstado.SelectedValue = -1;
            }
            else if (marcaEquipoSeleccionado == -2 || marcaEquipoSeleccionado > 0)
                cboModelo.Enabled = true;
            if (marcaEquipoSeleccionado > 0)
            {
                DataView dvFiltroMarca = dtModeloEquipo.DefaultView;
                dvFiltroMarca.RowFilter = $"id_equipos_marcas={marcaEquipoSeleccionado} or id=-2";
            }

        }

        private void cboModelo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            modeloEquipoSeleccionado = Convert.ToInt32(cboModelo.SelectedValue);
            //if (modeloEquipoSeleccionado != -1)
            //    cboEstado.Enabled = true;
            if (modeloEquipoSeleccionado != -1)
            {
                cboLocalidad.Enabled = true;
                grupoLocacion.Enabled = true;
            }
            else
                grupoLocacion.Enabled = false;
        }

        private void cboEstado_SelectionChangeCommitted(object sender, EventArgs e)
        {
            estadoEquipoSeleccionado  = Convert.ToInt32(cboEstado.SelectedValue);
            if (estadoEquipoSeleccionado !=(int)Equipos.Equipos_Estados.ASIGNADO_A_USUARIO)
            {
                grupoLocacion.Enabled = false;
                grupoCategoria.Enabled = false;
                grupoServicio.Enabled = false;
                asignados = false;

            }
            else
            {
                grupoLocacion.Enabled = true;
                asignados = true;
            }
        }

        private void cboLocalidad_SelectionChangeCommitted(object sender, EventArgs e)
        {
            localidadSeleccionado = Convert.ToInt32(cboLocalidad.SelectedValue);
            if (localidadSeleccionado != -1)
            {
                cboCalle.Enabled = true;
                cboAltura.Enabled = true;
                grupoCategoria.Enabled = true;
                if(localidadSeleccionado != -2)
                {
                    DataView dvCalles = dtCalle.DefaultView;
                    dvCalles.RowFilter = $"id_localidades ={localidadSeleccionado} or id<0";

                }
            }
            else
            {
                cboCalle.Enabled = false;
                cboAltura.Enabled = false;
                grupoCategoria.Enabled = false;

            }
        }

        private void cboTipoFacturacion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            tipoFacturacionSeleccionado= Convert.ToInt32(cboTipoFacturacion.SelectedValue);
            if (tipoFacturacionSeleccionado != -1)
                grupoServicio.Enabled = true;   
            else
                grupoServicio.Enabled = false;
        }

        private void cboTipoServicio_SelectionChangeCommitted(object sender, EventArgs e)
        {
            TipoServicioSeleccionado = Convert.ToInt32(cboTipoServicio.SelectedValue);
            if (TipoServicioSeleccionado != -1)
                cboModalidad.Enabled = true;
            else
                cboModalidad.Enabled = false;
        }

        private void cboModalidad_SelectionChangeCommitted(object sender, EventArgs e)
        {
            modalidadSeleccionado= Convert.ToInt32(cboModalidad.SelectedValue);
            if (modalidadSeleccionado != -1)
            {
                cboServicio.Enabled = true;
                DataView dvServicios = dtServicio.DefaultView;
                if (modalidadSeleccionado > 0)
                {
                    if(TipoServicioSeleccionado>0)
                        dvServicios.RowFilter = $"id_servicios_modalidad={modalidadSeleccionado} and id_Servicios_tipos={TipoServicioSeleccionado}";
                    else
                        dvServicios.RowFilter = $"id_servicios_modalidad={modalidadSeleccionado}";

                }
                else
                    dvServicios.RowFilter = "";
            }
            else
                cboServicio.Enabled = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string filtroTipoEquipo = "";
            string filtroEstadoEquipo = "";
            string filtroMarcaEquipo = "";
            string filtroModeloEquipo = "";
            string filtroLocalidad = "";
            string filtroCalle = "";
            string filtroTipoAltura = "";
            string filtroAltura = "";
            string filtroTipoFacturacion = "";
            string filtroTipoServicio = "";
            string filtroModalidadServicio = "";
            string filtroServicio = "";

            if (tipoEquipoSeleccionado == -2)
                filtroTipoEquipo = "equipos.id_equipos_tipos>0 and ";
            else
                filtroTipoEquipo = $"equipos.id_equipos_tipos={tipoEquipoSeleccionado} and ";

            //if (estadoEquipoSeleccionado == -2)
            //    filtroEstadoEquipo = " equipos.id_equipos_estados>0 and ";
            //else
            filtroEstadoEquipo = $" equipos.id_equipos_estados=3 and ";

            if (marcaEquipoSeleccionado == -2)
                filtroMarcaEquipo = " equipos.id_equipos_marcas>0 and ";
            else
                filtroMarcaEquipo = $" equipos.id_equipos_marcas={marcaEquipoSeleccionado} and ";

            if (modeloEquipoSeleccionado == -2)
                filtroModeloEquipo = " equipos.id_equipos_modelos>0 and ";
            else
                filtroModeloEquipo = $" equipos.id_equipos_modelos={modeloEquipoSeleccionado} and ";

            if (localidadSeleccionado == -2)
                filtroLocalidad = " localidades.id>0 and ";
            else
                filtroLocalidad = $" localidades.id={localidadSeleccionado} and ";

            if (calleSeleccionado == -2)
                filtroCalle = " localidades_calles.id>0 and ";
            else
                filtroCalle = $" localidades_calles.id={localidadSeleccionado} and ";

            filtroTipoAltura = cboAltura.Text;
            filtroAltura = " Usuarios_Locaciones.altura" + cboAltura.Text + " " + spnAltura.Value.ToString() + " and ";

            if (tipoFacturacionSeleccionado == -2)
                filtroTipoFacturacion = " usuarios_servicios.id_tipo_facturacion>0 and ";
            else
                filtroTipoFacturacion = $" usuarios_servicios.id_tipo_facturacion={tipoFacturacionSeleccionado} and ";

            if (TipoServicioSeleccionado == -2)
                filtroTipoServicio = " servicios.id_servicios_tipos>0 and ";
            else
                filtroTipoServicio = $" servicios.id_servicios_tipos={TipoServicioSeleccionado} and ";

            if (modalidadSeleccionado == -2)
                filtroModalidadServicio = " servicios.id_servicios_modalidad>0 and ";
            else
                filtroModalidadServicio = $" servicios.id_servicios_modalidad={modalidadSeleccionado} and ";

            if (servicioSeleccionado == -2)
                filtroServicio = " servicios.id>0 ";
            else
                filtroServicio = $" servicios.id={servicioSeleccionado} ";

            Informes.ConsultaEquipoResultado frm = new ConsultaEquipoResultado();
            frm.filtro = filtroTipoEquipo  + filtroMarcaEquipo + filtroModeloEquipo + filtroLocalidad + filtroCalle + filtroAltura + filtroTipoFacturacion + filtroTipoServicio + filtroModalidadServicio + filtroServicio;
            frm.asignados =true;
            frm.Show();
        }

        private void cboCalle_SelectionChangeCommitted(object sender, EventArgs e)
        {
            calleSeleccionado = Convert.ToInt32(cboCalle.SelectedValue);
        }

        private void cboAltura_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void cboServicio_SelectionChangeCommitted(object sender, EventArgs e)
        {
            servicioSeleccionado = Convert.ToInt32(cboServicio.SelectedValue);

        }

        private void frmConsultaEquipoUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                cboAltura.SelectedIndex = 0;
                foreach (Control item in grupoEquipo.Controls)
                {
                    if(item is ComboBox)
                    {
                        ComboBox cmbo =(ComboBox)item;
                        cmbo.SelectedValue = -2;
                        item.Enabled = true;
                    }
                }
                grupoLocacion.Enabled = true;
                foreach (Control item in grupoLocacion.Controls)
                {
                    if (item is ComboBox)
                    {
                        ComboBox cmbo = (ComboBox)item;
                        cmbo.SelectedValue = -2;
                        item.Enabled = true;

                    }
                }
                grupoCategoria.Enabled = true;

                foreach (Control item in grupoCategoria.Controls)
                {
                    if (item is ComboBox)
                    {
                        ComboBox cmbo = (ComboBox)item;
                        cmbo.SelectedValue = -2;
                        item.Enabled = true;

                    }
                }
                grupoServicio.Enabled = true;

                foreach (Control item in grupoServicio.Controls)
                {
                    if (item is ComboBox)
                    {
                        ComboBox cmbo = (ComboBox)item;
                        cmbo.SelectedValue = -2;
                        item.Enabled = true;

                    }
                }
                cboAltura.SelectedIndex = 0;
                cboEstado.SelectedIndex = 0;
            }
        }
    }
}
