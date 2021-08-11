using CapaNegocios;
using System;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Cuenta_Corriente
{
    public partial class frmInformesCuentaCorriente : Form
    {
        #region [PROPIEDADES]
        Thread hilo;
        private delegate void myDel();
        DataTable dtPrincipal = new DataTable();
        DataTable dtImporteGrupos;
        DataTable dtImporteTipos;
        DataTable dtImporteServicios;
        DataTable dtCantPartes;
        DataTable dtCantServicios;
        DataTable dtCantEquipos;
        DataTable dtDetalles;
        DataTable dtDetallesGrilla = new DataTable();
        int idGrupo = 0;
        int idTipo = 0;
        int idServicio = 0;

        bool verDetalles = false;
        int seleccion;
        bool expandirGrupo = true;
        bool expandirTipo = true;
        CuentaCorrienteInforme oCuentaCorrienteInforme = new CuentaCorrienteInforme();
        #endregion

        #region [METODOS]
        private void comenzarCarga()
        {
            pgCircular.Start();

            dgvDatos.DataSource = null;

            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.IsBackground = true;
            hilo.Start();
            btnExportar.Enabled = false;
            btnConsultar.Enabled = false;
        }

        private void cargarDatos()
        {
            dtPrincipal.Clear();
            dtDetallesGrilla.Clear();

            string Desde = dtpFechaDesde.Value.Date.ToString("yyyy-MM-dd");
            string Hasta = dtpFechaHasta.Value.Date.ToString("yyyy-MM-dd");


            if (verDetalles == false)
            {
                if (dtPrincipal.Columns.Count == 0)
                    ArmarTablaPrincipal(dtPrincipal);

                dtImporteGrupos = oCuentaCorrienteInforme.TraerPorGrupoServicio(Desde, Hasta);
                dtImporteTipos = oCuentaCorrienteInforme.TraerPorTipoServicio(Desde, Hasta);
                dtImporteServicios = oCuentaCorrienteInforme.TraerPorServicio(Desde, Hasta);
                LlenarDtPrincipal(dtImporteGrupos, dtImporteTipos, dtImporteServicios, dtPrincipal);
            }
            else
            {
                if (dtDetallesGrilla.Columns.Count == 0)
                    ArmarTablaDetalles(dtDetallesGrilla);

                int id = 0;

                switch (seleccion)
                {
                    case 0:
                        id = idGrupo;
                        break;
                    case 1:
                        id = idTipo;
                        break;
                    case 2:
                        id = idServicio;
                        break;
                }


                dtCantPartes = oCuentaCorrienteInforme.TraerCantPartes(Desde, Hasta, seleccion, id);
                dtCantServicios = oCuentaCorrienteInforme.TraerCantServicios(Desde, Hasta, seleccion, id);
                dtCantEquipos = oCuentaCorrienteInforme.TraerCantEquipos(Desde, Hasta, seleccion, id);
                dtDetalles = oCuentaCorrienteInforme.TraerDetalles(Desde, Hasta, seleccion, id);

                LlenarDtDetalles(dtCantPartes, dtCantServicios, dtCantEquipos, dtDetalles, dtDetallesGrilla);

            }

            myDel MD = new myDel(asignarDatos);

            this.Invoke(MD, new object[] { });

            pgCircular.Stop();
        }

        private void asignarDatos()
        {

            if (verDetalles == false)
            {
                dgvDatos.DataSource = dtPrincipal;

                dgvDatos.Columns["idGrupo"].Visible = false;
                dgvDatos.Columns["idTipo"].Visible = false;
                dgvDatos.Columns["idServicio"].Visible = false;


            }
            else
            {
                dgvDatos.DataSource = dtDetallesGrilla;

                dgvDatos.Columns["tipo"].Visible = false;
                dgvDatos.Columns["idGrupo"].Visible = false;
                dgvDatos.Columns["cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            dgvDatos.Columns["importeFinal"].HeaderText = "Importe final";
            dgvDatos.Columns["importeFinal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            BorrarColumnas();

            AgregarColumnas();

            dgvDatos.Columns["importeFinal"].Width = 200;
            dgvDatos.Columns["Nombre"].Width = 1000;

            expandirGrupo = false;
            expandirTipo = false;

            ColorearGrilla();

            OcultarItems(0, 0, 0);

            foreach (DataGridViewColumn columna in dgvDatos.Columns)
                columna.SortMode = DataGridViewColumnSortMode.NotSortable;

            btnExportar.Enabled = true;
            btnConsultar.Enabled = true;

        }

        private void ArmarTablaPrincipal(DataTable dtPrincipal)
        {
            dtPrincipal.Columns.Add("idGrupo", typeof(int));

            dtPrincipal.Columns.Add("idTipo", typeof(int));
            dtPrincipal.Columns.Add("idServicio", typeof(int));
            dtPrincipal.Columns.Add("Nombre", typeof(string));
            dtPrincipal.Columns.Add("ImporteFinal", typeof(string));
        }

        private void ArmarTablaDetalles(DataTable dtDetallesGrilla)
        {
            dtDetallesGrilla.Columns.Add("idGrupo", typeof(int));
            dtDetallesGrilla.Columns.Add("Nombre", typeof(string));
            dtDetallesGrilla.Columns.Add("cantidad", typeof(int));
            dtDetallesGrilla.Columns.Add("importeFinal", typeof(string));
            dtDetallesGrilla.Columns.Add("Tipo", typeof(string));
        }

        private void LlenarDtPrincipal(DataTable importeGrupos, DataTable importeTipos, DataTable importeServicios, DataTable dtPrincipal)
        {
            dtPrincipal.Clear();
            DataRow[] filasTipos;
            DataRow[] filasServicios;

            foreach (DataRow grupo in importeGrupos.Rows)
            {
                dtPrincipal.Rows.Add(Convert.ToInt32(grupo["idGrupo"]), 0, 0, grupo["nombreGrupo"], String.Format("${0}", grupo["importeFinal"]));

                filasTipos = dtImporteTipos.Select(String.Format("idGrupo={0}", grupo["idGrupo"]));

                foreach (DataRow tipo in filasTipos)
                {
                    dtPrincipal.Rows.Add(Convert.ToInt32(grupo["idGrupo"]), Convert.ToInt32(tipo["idTipo"]), 0, tipo["Nombretipo"], String.Format("${0}", tipo["importeFinal"]));

                    filasServicios = dtImporteServicios.Select(String.Format("idTipo={0}", tipo["idTipo"]));

                    foreach (DataRow servicio in filasServicios)
                        dtPrincipal.Rows.Add(Convert.ToInt32(grupo["idGrupo"]), Convert.ToInt32(servicio["idTipo"]), Convert.ToInt32(servicio["idServicio"]), servicio["Nombreservicio"], String.Format("${0}", servicio["importeFinal"]));

                }

            }


        }

        private void LlenarDtDetalles(DataTable dtCantPartes, DataTable dtCantServicios, DataTable dtCantEquipos, DataTable dtDetalles, DataTable dtDetallesGrilla)
        {
            dtDetallesGrilla.Clear();

            if (dtCantPartes.Rows.Count > 0)
            {
                if (String.IsNullOrEmpty(dtCantPartes.Rows[0]["ImporteFinal"].ToString()) == false)
                    dtDetallesGrilla.Rows.Add(0, dtCantPartes.Rows[0]["Partes"], Convert.ToInt32(dtCantPartes.Rows[0]["cantPartes"]), String.Format("${0}", dtCantPartes.Rows[0]["ImporteFinal"]), "p");
                else
                    dtDetallesGrilla.Rows.Add(0, dtCantPartes.Rows[0]["Partes"], 0, "$0", "p");

                foreach (DataRow fila in dtDetalles.Rows)
                {
                    if (fila["tipo"].ToString() == "P")
                    {

                        dtDetallesGrilla.Rows.Add(1, fila["sub_servicio"], Convert.ToInt32(fila["cant"]), String.Format("${0}", fila["ImporteFinal"]), "p");

                    }
                }
            }

            if (dtCantServicios.Rows.Count > 0)
            {
                if (String.IsNullOrEmpty(dtCantServicios.Rows[0]["ImporteFinal"].ToString()) == false)
                    dtDetallesGrilla.Rows.Add(0, dtCantServicios.Rows[0]["Servicios"], Convert.ToInt32(dtCantServicios.Rows[0]["cantServicios"]), String.Format("${0}", dtCantServicios.Rows[0]["ImporteFinal"]), "s");
                else
                    dtDetallesGrilla.Rows.Add(0, dtCantServicios.Rows[0]["Servicios"], 0, "$0", "s");

                foreach (DataRow fila in dtDetalles.Rows)
                {
                    if (fila["tipo"].ToString() == "S")
                        dtDetallesGrilla.Rows.Add(1, fila["sub_servicio"], Convert.ToInt32(fila["cant"]), String.Format("${0}", fila["ImporteFinal"]), "s");
                }
            }

            if (dtCantEquipos.Rows.Count > 0)
            {
                if (String.IsNullOrEmpty(dtCantEquipos.Rows[0]["ImporteFinal"].ToString()) == false)
                    dtDetallesGrilla.Rows.Add(0, dtCantEquipos.Rows[0]["Equipos"], Convert.ToInt32(dtCantEquipos.Rows[0]["cantEquipos"]), String.Format("${0}", dtCantEquipos.Rows[0]["ImporteFinal"]), "e");
                else
                    dtDetallesGrilla.Rows.Add(0, dtCantEquipos.Rows[0]["Equipos"], 0, 0, "e");

                foreach (DataRow fila in dtDetalles.Rows)
                {
                    if (fila["tipo"].ToString() == "E")
                        dtDetallesGrilla.Rows.Add(1, fila["sub_servicio"], Convert.ToInt32(fila["cant"]), String.Format("${0}", fila["ImporteFinal"]), "e");
                }
            }
        }

        private void OcultarItems(int idGrupo, int idTipo, int idServicio)
        {
            if (verDetalles == false)
            {
                if (idGrupo == 0)
                {
                    foreach (DataGridViewRow fila in dgvDatos.Rows)
                    {
                        if (Convert.ToInt32(fila.Cells["idGrupo"].Value) > 0 && Convert.ToInt32(fila.Cells["idTipo"].Value) > 0)
                            fila.Visible = false;
                    }
                }

                if (idGrupo > 0 && idTipo == 0 && idServicio == 0)
                {
                    foreach (DataGridViewRow fila in dgvDatos.Rows)
                    {
                        if (Convert.ToInt32(fila.Cells["idGrupo"].Value) == idGrupo && Convert.ToInt32(fila.Cells["idTipo"].Value) > 0)
                            fila.Visible = false;
                    }
                }

                if (idGrupo > 0 && idTipo > 0 && idServicio == 0)
                {
                    foreach (DataGridViewRow fila in dgvDatos.Rows)
                    {
                        if (Convert.ToInt32(fila.Cells["idTipo"].Value) == idTipo && Convert.ToInt32(fila.Cells["idServicio"].Value) > 0)
                            fila.Visible = false;
                    }
                }
            }
            else
            {
                if (idGrupo == 0)
                {
                    foreach (DataGridViewRow fila in dgvDatos.Rows)
                    {
                        if (Convert.ToInt32(fila.Cells["idGrupo"].Value) == 1)
                            fila.Visible = false;
                    }
                }
                else
                {
                    if (Convert.ToInt32(dgvDatos.SelectedRows[0].Cells["idGrupo"].Value) == 0 && dgvDatos.SelectedRows[0].Cells["tipo"].Value.ToString() == "p")
                    {
                        foreach (DataGridViewRow fila in dgvDatos.Rows)
                        {
                            if (Convert.ToInt32(fila.Cells["idGrupo"].Value) == 1 && fila.Cells["tipo"].Value.ToString() == "p")
                                fila.Visible = false;
                        }

                    }
                    else if (Convert.ToInt32(dgvDatos.SelectedRows[0].Cells["idGrupo"].Value) == 0 && dgvDatos.SelectedRows[0].Cells["tipo"].Value.ToString() == "s")
                    {
                        foreach (DataGridViewRow fila in dgvDatos.Rows)
                        {
                            if (Convert.ToInt32(fila.Cells["idGrupo"].Value) == 1 && fila.Cells["tipo"].Value.ToString() == "s")
                                fila.Visible = false;
                        }

                    }
                    else if (Convert.ToInt32(dgvDatos.SelectedRows[0].Cells["idGrupo"].Value) == 0 && dgvDatos.SelectedRows[0].Cells["tipo"].Value.ToString() == "e")
                    {
                        foreach (DataGridViewRow fila in dgvDatos.Rows)
                        {
                            if (Convert.ToInt32(fila.Cells["idGrupo"].Value) == 1 && fila.Cells["tipo"].Value.ToString() == "e")
                                fila.Visible = false;
                        }

                    }
                }


            }

        }

        private void ExpandirItems()
        {
            if (verDetalles == false)
            {
                int idGrupo = 0;
                int idTipo = 0;
                int idServicio = 0;

                idGrupo = Convert.ToInt32(dgvDatos.SelectedRows[0].Cells["idGrupo"].Value);
                idTipo = Convert.ToInt32(dgvDatos.SelectedRows[0].Cells["idTipo"].Value);
                idServicio = Convert.ToInt32(dgvDatos.SelectedRows[0].Cells["idServicio"].Value);

                if (idGrupo > 0 && idTipo == 0 && idServicio == 0)
                {
                    foreach (DataGridViewRow fila in dgvDatos.Rows)
                    {
                        if (Convert.ToInt32(fila.Cells["idTipo"].Value) > 0 && Convert.ToInt32(fila.Cells["idServicio"].Value) == 0 && Convert.ToInt32(fila.Cells["idGrupo"].Value) == idGrupo)
                            fila.Visible = true;
                    }

                }
                else if (idGrupo > 0 && idTipo > 0 && idServicio == 0)
                {
                    foreach (DataGridViewRow fila in dgvDatos.Rows)
                    {
                        if (Convert.ToInt32(fila.Cells["idTipo"].Value) > 0 && Convert.ToInt32(fila.Cells["idServicio"].Value) > 0 && Convert.ToInt32(fila.Cells["idTipo"].Value) == idTipo)
                            fila.Visible = true;
                    }

                }

            }
            else
            {


                if (Convert.ToInt32(dgvDatos.SelectedRows[0].Cells["idGrupo"].Value) == 0 && dgvDatos.SelectedRows[0].Cells["tipo"].Value.ToString() == "p")
                {

                    foreach (DataGridViewRow fila in dgvDatos.Rows)
                    {


                        if (Convert.ToInt32(fila.Cells["idGrupo"].Value) > 0 && fila.Cells["tipo"].Value.ToString() == "p")
                        {

                            fila.Visible = true;

                        }
                    }

                }
                else if (Convert.ToInt32(dgvDatos.SelectedRows[0].Cells["idGrupo"].Value) == 0 && dgvDatos.SelectedRows[0].Cells["tipo"].Value.ToString() == "s")
                {
                    foreach (DataGridViewRow fila in dgvDatos.Rows)
                    {
                        if (Convert.ToInt32(fila.Cells["idGrupo"].Value) > 0 && fila.Cells["tipo"].Value.ToString() == "s")
                            fila.Visible = true;
                    }

                }
                else if (Convert.ToInt32(dgvDatos.SelectedRows[0].Cells["idGrupo"].Value) == 0 && dgvDatos.SelectedRows[0].Cells["tipo"].Value.ToString() == "e")
                {
                    foreach (DataGridViewRow fila in dgvDatos.Rows)
                    {
                        if (Convert.ToInt32(fila.Cells["idGrupo"].Value) > 0 && fila.Cells["tipo"].Value.ToString() == "e")
                            fila.Visible = true;
                    }

                }
            }

        }

        private void ColorearGrilla()
        {
            foreach (DataGridViewRow fila in dgvDatos.Rows)
            {
                if (verDetalles == false)
                {
                    if (Convert.ToInt32(fila.Cells["idGrupo"].Value) > 0 && Convert.ToInt32(fila.Cells["idTipo"].Value) == 0 && Convert.ToInt32(fila.Cells["idServicio"].Value) == 0)
                        fila.DefaultCellStyle.BackColor = Color.DarkGray;

                    if (Convert.ToInt32(fila.Cells["idGrupo"].Value) > 0 && Convert.ToInt32(fila.Cells["idTipo"].Value) > 0 && Convert.ToInt32(fila.Cells["idServicio"].Value) == 0)
                        fila.DefaultCellStyle.BackColor = Color.LightGray;
                }
                else
                {
                    if (Convert.ToInt32(fila.Cells["idGrupo"].Value) == 0)
                        fila.DefaultCellStyle.BackColor = Color.DarkGray;

                    if (Convert.ToInt32(fila.Cells["idGrupo"].Value) > 0)
                        fila.DefaultCellStyle.BackColor = Color.LightGray;
                }

            }
        }

        private void BorrarColumnas()
        {
            int control = 0;

            foreach (DataGridViewColumn columna in dgvDatos.Columns)
            {
                if (columna.Name == "colVerDetalles")
                    control = 1;
            }

            if (control == 1)
                dgvDatos.Columns.RemoveAt(dgvDatos.Columns["colVerDetalles"].Index);

            control = 0;

            foreach (DataGridViewColumn columna in dgvDatos.Columns)
            {
                if (columna.Name == "colExpandir")
                    control = 1;
            }

            if (control == 1)
                dgvDatos.Columns.RemoveAt(dgvDatos.Columns["colExpandir"].Index);

        }

        private void AgregarColumnas()
        {
            int control = 0;

            DataGridViewLinkColumn colVerDetalles = new DataGridViewLinkColumn();
            colVerDetalles.Name = "colVerDetalles";
            colVerDetalles.HeaderText = "Detalles";
            colVerDetalles.Text = "Ver";
            colVerDetalles.UseColumnTextForLinkValue = true;

            DataGridViewLinkColumn colExpandir = new DataGridViewLinkColumn();
            colExpandir.Name = "colExpandir";
            colExpandir.HeaderText = "+/-";
            colExpandir.Text = "+";
            colExpandir.UseColumnTextForLinkValue = true;

            foreach (DataGridViewColumn columna in dgvDatos.Columns)
            {
                if (columna.Name == "colVerDetalles")
                    control = 1;
            }

            if (control == 0 && verDetalles == false)
            {
                dgvDatos.Columns.Add(colVerDetalles);
                dgvDatos.Columns["colVerDetalles"].Width = 10;
            }

            control = 0;

            foreach (DataGridViewColumn columna in dgvDatos.Columns)
            {
                if (columna.Name == "colExpandir")
                    control = 1;
            }

            if (control == 0)
            {
                dgvDatos.Columns.Add(colExpandir);

                dgvDatos.Columns["colExpandir"].Width = 15;
            }


        }
        #endregion

        public frmInformesCuentaCorriente()
        {
            InitializeComponent();
        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            if (verDetalles == false)
            {
                idGrupo = Convert.ToInt32(dgvDatos.SelectedRows[0].Cells["idGrupo"].Value);
                idTipo = Convert.ToInt32(dgvDatos.SelectedRows[0].Cells["idTipo"].Value);
                idServicio = Convert.ToInt32(dgvDatos.SelectedRows[0].Cells["idServicio"].Value);

                if (idGrupo > 0 && idTipo == 0)
                {
                    lblGrupoCabecera.Text = string.Format("{0} {1}", "Grupo:", dgvDatos.SelectedRows[0].Cells["nombre"].Value.ToString());
                    lblTipoCabecera.Text = string.Format("{0} {1}", "Tipo de servicio:", "");
                }
                else if (idGrupo > 0 && idTipo > 0 && idServicio == 0)
                {

                    lblGrupoCabecera.Text = string.Format("{0} {1}", "Grupo:", dtPrincipal.Select("idGrupo=" + dgvDatos.SelectedRows[0].Cells["idgrupo"].Value.ToString() + " and idTipo=0")[0]["nombre"]);
                    lblTipoCabecera.Text = string.Format("{0} {1}", "Tipo de servicio:", dgvDatos.SelectedRows[0].Cells["nombre"].Value.ToString());
                    lblServiciosCabecera.Text = string.Format("{0} {1}", "Servicio:", "");
                }
                else if (idGrupo > 0 && idTipo > 0 && idServicio > 0)
                {
                    lblGrupoCabecera.Text = string.Format("{0} {1}", "Grupo:", dtPrincipal.Select("idGrupo=" + dgvDatos.SelectedRows[0].Cells["idgrupo"].Value.ToString() + " and idTipo=0")[0]["nombre"]);
                    lblTipoCabecera.Text = string.Format("{0} {1}", "Tipo de servicio:", dtPrincipal.Select("idGrupo=" + dgvDatos.SelectedRows[0].Cells["idgrupo"].Value.ToString() + " and idTipo=" + dgvDatos.SelectedRows[0].Cells["idtipo"].Value.ToString() + " and idservicio=0")[0]["nombre"]);
                    lblServiciosCabecera.Text = string.Format("{0} {1}", "Servicio:", dgvDatos.SelectedRows[0].Cells["nombre"].Value.ToString());
                }
            }




            if (verDetalles == false)
            {


                if (e.ColumnIndex == dgvDatos.Columns["colExpandir"].Index)
                {


                    if (idGrupo > 0 && idTipo == 0)
                    {
                        if (expandirGrupo)
                        {
                            expandirGrupo = false;
                            ExpandirItems();
                        }
                        else
                        {
                            expandirGrupo = true;
                            OcultarItems(idGrupo, idTipo, idServicio);
                        }
                    }

                    if (idGrupo > 0 && idTipo > 0 && idServicio == 0)
                    {
                        if (expandirTipo)
                        {
                            expandirTipo = false;
                            ExpandirItems();
                        }
                        else
                        {
                            expandirTipo = true;
                            OcultarItems(idGrupo, idTipo, idServicio);
                        }
                    }
                }
                else if (e.ColumnIndex == dgvDatos.Columns["colVerDetalles"].Index)
                {

                    verDetalles = true;
                    if (idGrupo > 0 && idTipo == 0)
                    {
                        seleccion = 0;
                        comenzarCarga();
                    }
                    else if (idTipo > 0 && idServicio == 0)
                    {
                        seleccion = 1;
                        comenzarCarga();
                    }
                    else if (idServicio > 0)
                    {
                        seleccion = 2;
                        comenzarCarga();
                    }
                }
            }
            else
            {
                if (e.ColumnIndex == dgvDatos.Columns["colExpandir"].Index)
                {

                    if (expandirGrupo == false)
                    {
                        expandirGrupo = true;
                        ExpandirItems();
                    }
                    else
                    {
                        expandirGrupo = false;
                        OcultarItems(1, 0, 0);
                    }
                }
            }

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.Rows.Count > 0)
            {
                Tools tools = new Tools();
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    tools.ExportToExcel(dgvDatos, "Informes Cuenta Corriente.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally { this.Cursor = Cursors.Default; }
            }
            else
            {
                MessageBox.Show("Tabla vacia", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
