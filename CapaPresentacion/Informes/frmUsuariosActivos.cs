using CapaNegocios;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Informes
{
    public partial class frmUsuariosActivos : Form
    {
        #region [PROPIEDADES]
        private Thread hilo;
        private delegate void myDel();
        private DataTable dtServicios = new DataTable();
        private DataTable dtDeudas = new DataTable();
        private Informes_Contables oInformesContables = new Informes_Contables();
        private DataTable dtLocalidades = new DataTable();
        private DataTable dtTiposServicios = new DataTable();
        private DataView dvFiltros;
        private String filtroZona, filtroLocalidad, filtroTipoServicio, filtroServicio;
        private Int32 idTipoServicioSeleccionado, idTipoServicioBuscado, idServicioSeleccionado, idServicioBuscado, idLocalidadSeleccionada, idLocalidadBuscada, idZonaSeleccionada, idZonaBuscada;

        #endregion


        #region METODOS
        private void comenzarCarga()
        {
            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
        }

        private void cargarDatos()
        {
            try
            {
                myDel MD = new myDel(asignarDatos);
                this.Invoke(MD, new object[] { });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Informacion" + ex.Message);
            }
        }

        private void asignarDatos()
        {

            cboZonas.DataSource = Tablas.DataZonas;
            cboZonas.ValueMember = "id";
            cboZonas.DisplayMember = "nombre";
            cboZonas.SelectedValue = 0;
            dtLocalidades = Tablas.DataLocalidades;
            dtLocalidades.Rows.Add(0, 0, "TODAS");
            cboLocalidades.DataSource = dtLocalidades;
            cboLocalidades.DisplayMember = "nombre";
            cboLocalidades.ValueMember = "id";
            cboLocalidades.SelectedValue = 0;
            dtTiposServicios = Tablas.DataServicios_Tipos;
            dtTiposServicios.Rows.Add(0, "TODOS");
            cboTipoSer.DataSource = dtTiposServicios;
            cboTipoSer.DisplayMember = "nombre";
            cboTipoSer.ValueMember = "id";
            cboTipoSer.SelectedValue = 0;
            dtServicios = Tablas.DataServicios.Copy();
            dtServicios.Rows.Add(0, 0, "", "TODOS");
            cboServicio.DataSource = dtServicios;
            cboServicio.DisplayMember = "Descripcion";
            cboServicio.ValueMember = "id";
            cboServicio.SelectedValue = 0;


            dtDeudas = oInformesContables.ListarUsuariosActivos();
            dvFiltros = dtDeudas.DefaultView;
            dgv.DataSource = dvFiltros;
            foreach (DataGridViewColumn item in dgv.Columns)
                item.Visible = false;

            dgv.Columns["servicio"].Visible = true;
            dgv.Columns["tipo"].Visible = true;
            dgv.Columns["zona"].Visible = true;
            dgv.Columns["localidad"].Visible = true;
            dgv.Columns["usuarios"].Visible = true;
            dgv.Columns["usuarios"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        #endregion
        public frmUsuariosActivos()
        {
            InitializeComponent();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAnalisDeuda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnAbonado_Click(object sender, EventArgs e)
        {


        }

        private void frmAnalisDeuda_Load(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void cboZonas_SelectedValueChanged(object sender, EventArgs e)
        {
            if (dtDeudas.Rows.Count > 0)
            {
                bool estaba = false;
                try
                {
                    idZonaSeleccionada = Convert.ToInt32(cboZonas.SelectedValue);
                    if (string.IsNullOrEmpty(filtroZona))
                        estaba = false;
                    else
                        estaba = true;
                    if (idZonaSeleccionada > 0)
                    {
                        filtroZona = "id_zona=" + idZonaSeleccionada;
                        if (estaba)
                            dvFiltros.RowFilter = dvFiltros.RowFilter.Replace("id_zona=" + idZonaBuscada, "id_zona=" + idZonaSeleccionada);
                        else
                        {
                            if (string.IsNullOrEmpty(filtroServicio) && string.IsNullOrEmpty(filtroTipoServicio) && string.IsNullOrEmpty(filtroLocalidad))
                                dvFiltros.RowFilter = filtroZona;
                            else
                                dvFiltros.RowFilter = dvFiltros.RowFilter + " and " + filtroZona;
                        }
                        idZonaBuscada = idZonaSeleccionada;
                    }
                    else
                    {
                        filtroZona = "";
                        if (dvFiltros.RowFilter.Contains("and id_zona"))
                            dvFiltros.RowFilter = dvFiltros.RowFilter.Replace(" and id_zona=" + idZonaBuscada, " ");
                        else
                            dvFiltros.RowFilter = dvFiltros.RowFilter.Replace("id_zona=" + idZonaBuscada, " ");
                    }
                }
                catch (Exception c)
                {

                }
            }
        }

        private void cboLocalidades_SelectedValueChanged(object sender, EventArgs e)
        {
            if (dtDeudas.Rows.Count > 0)
            {
                bool estaba = false;
                try
                {
                    idLocalidadSeleccionada = Convert.ToInt32(cboLocalidades.SelectedValue);
                    if (string.IsNullOrEmpty(filtroLocalidad))
                        estaba = false;
                    else
                        estaba = true;
                    if (idLocalidadSeleccionada > 0)
                    {
                        filtroLocalidad = "id_localidad=" + idLocalidadSeleccionada;
                        if (estaba)
                            dvFiltros.RowFilter = dvFiltros.RowFilter.Replace("id_localidad=" + idLocalidadBuscada, "id_localidad=" + idLocalidadSeleccionada);
                        else
                        {
                            if (string.IsNullOrEmpty(filtroServicio) && string.IsNullOrEmpty(filtroTipoServicio) && string.IsNullOrEmpty(filtroZona))
                                dvFiltros.RowFilter = filtroLocalidad;
                            else
                                dvFiltros.RowFilter = dvFiltros.RowFilter + " and " + filtroLocalidad;
                        }
                        idLocalidadBuscada = idLocalidadSeleccionada;
                    }
                    else
                    {
                        filtroLocalidad = "";
                        if (dvFiltros.RowFilter.Contains("and id_localidad"))
                            dvFiltros.RowFilter = dvFiltros.RowFilter.Replace(" and id_localidad=" + idLocalidadBuscada, " ");
                        else
                            dvFiltros.RowFilter = dvFiltros.RowFilter.Replace("id_localidad=" + idLocalidadBuscada, " ");
                    }
                }
                catch (Exception)
                {

                }
            }
        }



        private void cboServicio_SelectedValueChanged(object sender, EventArgs e)
        {
            if (dtDeudas.Rows.Count > 0)
            {
                bool estaba = false;
                try
                {
                    idServicioSeleccionado = Convert.ToInt32(cboServicio.SelectedValue);
                    if (string.IsNullOrEmpty(filtroServicio))
                        estaba = false;
                    else
                        estaba = true;
                    if (idServicioSeleccionado > 0)
                    {
                        filtroServicio = "id_servicio=" + idServicioSeleccionado;
                        if (estaba)
                            dvFiltros.RowFilter = dvFiltros.RowFilter.Replace("id_servicio=" + idServicioBuscado, "id_servicio=" + idServicioSeleccionado);
                        else
                        {
                            if (string.IsNullOrEmpty(filtroLocalidad) && string.IsNullOrEmpty(filtroTipoServicio) && string.IsNullOrEmpty(filtroZona))
                                dvFiltros.RowFilter = filtroServicio;
                            else
                                dvFiltros.RowFilter = dvFiltros.RowFilter + " and " + filtroServicio;
                        }
                        idServicioBuscado = idServicioSeleccionado;
                    }
                    else
                    {
                        filtroServicio = "";
                        if (dvFiltros.RowFilter.Contains("and id_servicio"))
                            dvFiltros.RowFilter = dvFiltros.RowFilter.Replace(" and id_servicio=" + idServicioBuscado, " ");
                        else
                            dvFiltros.RowFilter = dvFiltros.RowFilter.Replace("id_servicio=" + idServicioBuscado, " ");

                    }
                }
                catch (Exception c)
                {

                }
            }
        }


        private void cboTipoSer_SelectedValueChanged(object sender, EventArgs e)
        {
            if (dtDeudas.Rows.Count > 0)
            {
                bool estaba = false;
                try
                {
                    idTipoServicioSeleccionado = Convert.ToInt32(cboTipoSer.SelectedValue);
                    if (string.IsNullOrEmpty(filtroTipoServicio))
                        estaba = false;
                    else
                        estaba = true;
                    if (idTipoServicioSeleccionado > 0)
                    {
                        filtroTipoServicio = "id_servicio_tipo=" + idTipoServicioSeleccionado;
                        if (estaba)
                            dvFiltros.RowFilter = dvFiltros.RowFilter.Replace("id_servicio_tipo=" + idTipoServicioBuscado, "id_servicio_tipo=" + idTipoServicioSeleccionado);
                        else
                        {
                            if (string.IsNullOrEmpty(filtroLocalidad) && string.IsNullOrEmpty(filtroServicio) && string.IsNullOrEmpty(filtroZona))
                                dvFiltros.RowFilter = filtroTipoServicio;
                            else
                                dvFiltros.RowFilter = dvFiltros.RowFilter + " and " + filtroTipoServicio;
                        }

                        idTipoServicioBuscado = idTipoServicioSeleccionado;
                    }
                    else
                    {
                        filtroTipoServicio = "";
                        if (dvFiltros.RowFilter.Contains("and id_servicio_tipo"))
                            dvFiltros.RowFilter = dvFiltros.RowFilter.Replace(" and id_servicio_tipo=" + idTipoServicioBuscado, " ");
                        else
                            dvFiltros.RowFilter = dvFiltros.RowFilter.Replace("id_servicio_tipo=" + idTipoServicioBuscado, " ");
                    }
                }
                catch (Exception c)
                {
                }
            }
        }

        private void cboLocalidades_Click(object sender, EventArgs e)
        {

        }

        private void cboZonas_Click(object sender, EventArgs e)
        {

        }

        private void cboTipoSer_Click(object sender, EventArgs e)
        {

        }

        private void cboServicio_Click(object sender, EventArgs e)
        {

        }
    }
}
