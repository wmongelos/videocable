using CapaNegocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;


namespace CapaPresentacion
{
    public partial class frmCuadroTarifario : Form
    {
        private int idTarifa, idTipoFacturacion, idTipoFacturacionConfig, idGrupo, idTipo;
        private List<int> listaServiciosSubContados = new List<int>();
        private Thread hilo;
        private delegate void myDel();
        private DataRow[] drDatosTipos;
        private DataRow[] drDatosServicios;
        private DataRow[] drDatosServiciosSub;
        private DataRow[] drDetallesServiciosSub;
        private DataTable dt = new DataTable();
        private DataTable dtTarifas = new DataTable();
        private DataTable dtGrupos = new DataTable();
        private DataTable dtTipos = new DataTable();
        private DataTable dtServicios = new DataTable();
        private DataTable dtZonaCategoria = new DataTable();
        private DataTable dtDatos = new DataTable();
        private Servicios oServicio = new Servicios();
        private Servicios_Tipos oServicioTipo = new Servicios_Tipos();
        private Servicios_Tarifas oServiciosTarifas = new Servicios_Tarifas();
        private Servicios_Tarifas_Sub oTarifasSub = new Servicios_Tarifas_Sub();
        private Servicios_Categorias oServiciosCategorias = new Servicios_Categorias();
        private Zonas oZonas = new Zonas();
        private Configuracion oConfiguracion = new Configuracion();

        private void comenzarCarga()
        {
            pgCircular.Start();

            dgv.DataSource = null;

            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.IsBackground = true;
            hilo.Start();
        }

        private void cargarDatos()
        {
            dt.Clear();
            dtDatos.Clear();
            listaServiciosSubContados.Clear();
            dt = oTarifasSub.ListarCuadroTarifario(idTarifa, idTipoFacturacion);

            foreach (DataRow filaGrupo in dtGrupos.Rows)
            {
                if (Convert.ToInt32(filaGrupo["id"]) != 0)
                {
                    DataRow[] drDatosServiciosGrupos = dt.Select(String.Format("id_servicios_grupos={0}", filaGrupo["id"]));
                    if (drDatosServiciosGrupos.Length > 0)
                        dtDatos.Rows.Add("0", filaGrupo["id"], "0", "0", "0", filaGrupo["Nombre"], "");

                    drDatosTipos = null;
                    drDatosTipos = dtTipos.Select(String.Format("id_servicios_grupos={0}", filaGrupo["id"]));
                    if (drDatosTipos.Length > 0)
                    {
                        foreach (DataRow filaTipo in drDatosTipos)
                        {
                            if (Convert.ToInt32(filaTipo["id"]) != 0)
                            {
                                DataRow[] drDatosServiciosTipos = dt.Select(String.Format("id_servicios={0}", filaTipo["id"]));
                                if (drDatosServiciosTipos.Length > 0)
                                    dtDatos.Rows.Add("1", filaGrupo["id"], filaTipo["id"], "0", "0", String.Format(" {0}", filaTipo["Nombre"]), "");

                                drDatosServicios = null;
                                drDatosServicios = dtServicios.Select(String.Format("id_servicios_tipos={0}", filaTipo["id"]));
                                if (drDatosServicios.Length > 0)
                                {
                                    foreach (DataRow filaServicio in drDatosServicios)
                                    {
                                        drDatosServiciosSub = null;
                                        drDatosServiciosSub = dt.Select(String.Format("id_servicios={0}", filaServicio["id"]));
                                        if (drDatosServiciosSub.Length > 0)
                                        {
                                            dtDatos.Rows.Add("2", filaGrupo["id"], filaTipo["id"], filaServicio["id"], "0", String.Format("   {0}", filaServicio["Descripcion"]), "");

                                            foreach (DataRow filaServiciosSub in drDatosServiciosSub)
                                            {
                                                if (Convert.ToInt32(filaServiciosSub["idtipodesub"]) == Convert.ToInt32(Servicios_Sub.SERVICIO_SUB_TIPOS.SUBSERVICIO) && (Convert.ToInt32(filaServiciosSub["requiere_ip"]) == 1 || Convert.ToInt32(filaServiciosSub["id_servicios_modalidad"]) == Convert.ToInt32(Servicios._Modalidad.PERIODO) || Convert.ToInt32(filaServiciosSub["id_servicios_modalidad"]) == Convert.ToInt32(Servicios._Modalidad.PERIODO_CERRADO_POR_MES) || Convert.ToInt32(filaServiciosSub["id_servicios_modalidad"]) == Convert.ToInt32(Servicios._Modalidad.PERIODO_CERRADO_POR_DIA)))
                                                {
                                                    if (listaServiciosSubContados.Contains(Convert.ToInt32(filaServiciosSub["id_servicios_sub"])) == false)
                                                    {
                                                        listaServiciosSubContados.Add(Convert.ToInt32(filaServiciosSub["id_servicios_sub"]));
                                                        dtDatos.Rows.Add("3", filaGrupo["id"], filaTipo["id"], filaServicio["id"], filaServiciosSub["id_servicios_sub"], String.Format("     {0}", filaServiciosSub["subservicio"]), "");
                                                        drDetallesServiciosSub = null;
                                                        drDetallesServiciosSub = dt.Select(String.Format("id_servicios={0} and id_servicios_sub={1}", filaServicio["id"], filaServiciosSub["id_servicios_sub"]));

                                                        foreach (DataRow filaDetalles in drDetallesServiciosSub)
                                                        {
                                                            if (Convert.ToInt32(filaServiciosSub["id_servicios_modalidad"]) == Convert.ToInt32(Servicios._Modalidad.PERIODO_CERRADO_POR_DIA))
                                                            {
                                                                if (Convert.ToInt32(filaServiciosSub["requiere_ip"]) == 1)
                                                                    dtDatos.Rows.Add("4", filaGrupo["id"], filaTipo["id"], filaServicio["id"], filaDetalles["id_servicios_sub"], String.Format("       {0} {1}MB {2}, desde: {3}, hasta: {4}", filaDetalles["subservicio"], filaDetalles["velocidad"], filaDetalles["velocidad_tipo"], filaDetalles["dias_desde"], filaDetalles["dias_hasta"]), filaDetalles["importe"].ToString());
                                                                else
                                                                    dtDatos.Rows.Add("4", filaGrupo["id"], filaTipo["id"], filaServicio["id"], filaDetalles["id_servicios_sub"], String.Format("       {0}, desde: {1}, hasta: {2}", filaDetalles["subservicio"], filaDetalles["dias_desde"], filaDetalles["dias_hasta"]), filaDetalles["importe"].ToString());
                                                            }
                                                            else
                                                            {
                                                                if (Convert.ToInt32(filaServiciosSub["requiere_ip"]) == 1)
                                                                    dtDatos.Rows.Add("4", filaGrupo["id"], filaTipo["id"], filaServicio["id"], filaDetalles["id_servicios_sub"], String.Format("       {0} {1}MB {2}, meses de cobro: {3}, meses de servicio: {4}", filaDetalles["subservicio"], filaDetalles["velocidad"], filaDetalles["velocidad_tipo"], filaDetalles["meses_cobro"], filaDetalles["meses_servicio"]), filaDetalles["importe"].ToString());
                                                                else
                                                                    dtDatos.Rows.Add("4", filaGrupo["id"], filaTipo["id"], filaServicio["id"], filaDetalles["id_servicios_sub"], String.Format("       {0}, meses de cobro: {1}, meses de servicio: {2}", filaDetalles["subservicio"], filaDetalles["meses_cobro"], filaDetalles["meses_servicio"]), filaDetalles["importe"].ToString());
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                    dtDatos.Rows.Add("3", filaGrupo["id"], filaTipo["id"], filaServicio["id"], filaServiciosSub["id_servicios_sub"], String.Format("     {0}", filaServiciosSub["subservicio"]), filaServiciosSub["importe"].ToString());
                                            }
                                        }
                                        //    else
                                        //        dtDatos.Rows.Add("3", filaGrupo["id"], filaTipo["id"], filaServicio["id"], "0", "      No se han definido importes para esta tarifa.", "");
                                    }
                                }
                                //else
                                //    dtDatos.Rows.Add("2", filaGrupo["id"], filaTipo["id"], "0", "0", "   No posee servicios asignados.", "");
                            }
                        }
                    }
                    else
                        dtDatos.Rows.Add("1", filaGrupo["id"], "0", "0", "0", "  No posee tipos de servicios asignados.", "");
                }
            }

            myDel MD = new myDel(asignarDatos);

            this.Invoke(MD, new object[] { });

            pgCircular.Stop();
        }

        private void asignarDatos()
        {
            dgv.DataSource = dtDatos;

            for (int i = 0; i < dgv.ColumnCount; i++)
            {
                dgv.Columns[i].Visible = false;
                dgv.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dgv.Columns["nombre"].Visible = true;
            dgv.Columns["nombre"].HeaderText = "Nombre";
            dgv.Columns["importe"].Visible = true;
            dgv.Columns["importe"].HeaderText = "Importe";
            dgv.Columns["importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["importe"].DefaultCellStyle.Format = "c";
            dgv.Columns["importe"].Width = 70;

            cboTarifas.SelectedValue = idTarifa;
            cboZonaCategoria.SelectedValue = idTipoFacturacion;
            AsignarValores();
            if (dgv.Rows.Count > 0)
                ColorearGrilla();
        }

        private void AsignarValores()
        {
            lblTarifaSeleccionada.Text = String.Format("Tarifa seleccionada: {0}", cboTarifas.Text);
            if (idTipoFacturacionConfig == Convert.ToInt32(Tipo_Facturacion.Id_Tipo_Facturacion.POR_CATEGORIAS))
                lblZonaCatSeleccionada.Text = String.Format("Categoría seleccionada: {0}", cboZonaCategoria.Text);
            else
                lblZonaCatSeleccionada.Text = String.Format("Zona seleccionada: {0}", cboZonaCategoria.Text);
        }

        private void ColorearGrilla()
        {
            int tipoFila = 0;
            foreach (DataGridViewRow fila in dgv.Rows)
            {
                tipoFila = Convert.ToInt32(fila.Cells["tipoFila"].Value);
                switch (tipoFila)
                {
                    case 0:
                        fila.DefaultCellStyle.BackColor = Color.MediumSeaGreen;
                        break;
                    case 1:
                        fila.DefaultCellStyle.BackColor = Color.MediumAquamarine;
                        break;
                    case 2:
                        fila.DefaultCellStyle.BackColor = Color.PaleTurquoise;
                        break;
                    case 3:
                        fila.DefaultCellStyle.BackColor = Color.LightGray;
                        break;
                    case 4:
                        fila.DefaultCellStyle.BackColor = Color.WhiteSmoke;
                        break;
                }
            }
        }

        private void FiltrarGrilla()
        {
            //MessageBox.Show(idGrupo.ToString());
            //MessageBox.Show(idTipo.ToString());

            foreach (DataGridViewRow fila in dgv.Rows)
                fila.Visible = false;

            if (idGrupo == 0 && idTipo == 0)
            {
                foreach (DataGridViewRow fila in dgv.Rows)
                    fila.Visible = true;
            }
            else if (idGrupo > 0 && idTipo == 0)
            {
                foreach (DataGridViewRow fila in dgv.Rows)
                {
                    if (Convert.ToInt32(fila.Cells["idgrupo"].Value) == idGrupo)
                        fila.Visible = true;
                }
            }
            else if (idGrupo > 0 && idTipo > 0)
            {
                foreach (DataGridViewRow fila in dgv.Rows)
                {
                    if ((Convert.ToInt32(fila.Cells["idgrupo"].Value) == idGrupo && Convert.ToInt32(fila.Cells["idtipo"].Value) == 0) || (Convert.ToInt32(fila.Cells["idgrupo"].Value) == idGrupo && Convert.ToInt32(fila.Cells["idtipo"].Value) == idTipo))
                        fila.Visible = true;
                }
            }
        }

        public frmCuadroTarifario()
        {
            InitializeComponent();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboGrupos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboTipos_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                idGrupo = Convert.ToInt32(cboGrupos.SelectedValue);
                idTipo = Convert.ToInt32(cboTipos.SelectedValue);

                FiltrarGrilla();
            }
            catch { }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            Tools oTools = new Tools();
            oTools.ExportToExcel(dgv, "Cuadro Tarifario");
        }

        private void frmCuadroTarifario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void frmCuadroTarifario_Load(object sender, EventArgs e)
        {
            dtDatos.Columns.Add("tipoFila", typeof(string));
            dtDatos.Columns.Add("idGrupo", typeof(string));
            dtDatos.Columns.Add("idTipo", typeof(string));
            dtDatos.Columns.Add("idServicio", typeof(string));
            dtDatos.Columns.Add("idServicioSub", typeof(string));
            dtDatos.Columns.Add("Nombre", typeof(string));
            dtDatos.Columns.Add("importe", typeof(string));

            idTipoFacturacionConfig = oConfiguracion.GetValor_N("id_tipo_facturacion");
            cboTarifas.DataSource = oServiciosTarifas.Listar();
            cboTarifas.DisplayMember = "Nombre";
            cboTarifas.ValueMember = "Id";

            dtGrupos = oServicio.ListarGrupos();
            dtGrupos.Rows.Add(0, "TODOS").AcceptChanges();
            DataView dtv = dtGrupos.DefaultView;
            dtv.Sort = "Id";
            dtGrupos = dtv.ToTable();
            cboGrupos.DataSource = dtGrupos;
            cboGrupos.DisplayMember = "Nombre";
            cboGrupos.ValueMember = "Id";

            dtTipos = oServicioTipo.Listar();
            dtTipos.Rows.Add(0, "TODOS").AcceptChanges();
            dtv = dtTipos.DefaultView;
            dtv.Sort = "Id";
            dtTipos = dtv.ToTable();
            cboTipos.DataSource = dtTipos;
            cboTipos.DisplayMember = "Nombre";
            cboTipos.ValueMember = "Id";

            dtServicios = oServicio.Listar();

            if (idTipoFacturacionConfig == Convert.ToInt32(Tipo_Facturacion.Id_Tipo_Facturacion.POR_CATEGORIAS))
            {
                dtZonaCategoria = oServiciosCategorias.Listar();
                lblZonaCategoria.Text = String.Format("Categorías:");
            }
            else
            {
                dtZonaCategoria = oZonas.Listar();
                lblZonaCategoria.Text = String.Format("Zonas:");
            }

            cboZonaCategoria.DataSource = dtZonaCategoria;
            cboZonaCategoria.DisplayMember = "Nombre";
            cboZonaCategoria.ValueMember = "Id";

            oServiciosTarifas.Fecha_Actual = DateTime.Now;
            idTarifa = oServiciosTarifas.getTarifa();

            idTipoFacturacion = Convert.ToInt32(dtZonaCategoria.Rows[0]["Id"]);


            comenzarCarga();
        }

        private void cboGrupos_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                dtTipos.DefaultView.RowFilter = String.Empty;

                Int32 Grupos_Id = Convert.ToInt32(cboGrupos.SelectedValue);
                DataRow[] drFilter = dtTipos.Select(String.Format("Id = 0 AND id_servicios_grupos = {0}", Grupos_Id));

                if (drFilter.Length == 0)
                    dtTipos.Rows.Add(0, "TODOS", cboGrupos.Text, Grupos_Id).AcceptChanges();

                DataView dtvt = dtTipos.DefaultView;
                dtvt.Sort = "Id";
                dtvt.RowFilter = String.Format("id_servicios_grupos = {0}", Grupos_Id);
                cboTipos.DataSource = dtvt.ToTable();
                cboTipos.DisplayMember = "Nombre";
                cboTipos.ValueMember = "Id";

                idGrupo = Convert.ToInt32(cboGrupos.SelectedValue);
                idTipo = Convert.ToInt32(cboTipos.SelectedValue);

                FiltrarGrilla();
            }
            catch { }

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            idTarifa = Convert.ToInt32(cboTarifas.SelectedValue);
            idTipoFacturacion = Convert.ToInt32(cboZonaCategoria.SelectedValue);
            comenzarCarga();
        }
    }
}
