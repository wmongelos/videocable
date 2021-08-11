using CapaNegocios;
using CapaPresentacion.Impresiones;
using System;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmServiciosInformes : Form
    {
        #region PROPIEDADES
        private DataTable dt_EstadosServicios = new DataTable();
        private DataTable dt_Datos;
        private int grupo_seleccionado;
        private int tipo_servicio_seleccionado;
        private int servicio_seleccionado;
        private int seleccion;
        private int ver_detalles;
        private Thread hilo;
        private delegate void myDel();
        private Servicios oServicios = new Servicios();
        private Servicios_Informes oServiciosInformes = new Servicios_Informes();
        private int id_estado;
        private string grupo, tipo_serv, serv, subserv, estadoServicios;
        private int total;
        #endregion

        #region MÉTODOS
        private void comenzarCarga()
        {
            pgCircular.Start();

            dgvDatos.DataSource = null;

            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.IsBackground = true;
            hilo.Start();
        }

        private void cargarDatos()
        {

            switch (seleccion)
            {
                case 0:
                    if (ver_detalles == 0)
                    {
                        if (dt_EstadosServicios.Rows.Count == 0)
                            dt_EstadosServicios = oServicios.ListarEstados();

                        dt_Datos = oServiciosInformes.ListarCantidadServicios(id_estado, seleccion, 0);
                    }
                    else
                        dt_Datos = oServiciosInformes.VerDetalles(id_estado, seleccion, grupo_seleccionado);
                    break;

                case 1:
                    if (ver_detalles == 0)
                        dt_Datos = oServiciosInformes.ListarCantidadServicios(id_estado, seleccion, grupo_seleccionado);
                    else
                        dt_Datos = oServiciosInformes.VerDetalles(id_estado, seleccion, tipo_servicio_seleccionado);
                    break;

                case 2:
                    if (ver_detalles == 0)
                        dt_Datos = oServiciosInformes.ListarCantidadServicios(id_estado, seleccion, tipo_servicio_seleccionado);
                    else
                        dt_Datos = oServiciosInformes.VerDetalles(id_estado, seleccion, servicio_seleccionado);
                    break;

                case 3:
                    if (ver_detalles == 0)
                        dt_Datos = oServiciosInformes.ListarCantidadServicios(0, seleccion, servicio_seleccionado);
                    else
                        dt_Datos = oServiciosInformes.VerDetalles(id_estado, seleccion, servicio_seleccionado);
                    break;
            }

            myDel MD = new myDel(asignarDatos);

            this.Invoke(MD, new object[] { });

            pgCircular.Stop();

        }

        private void asignarDatos()
        {
            dgvDatos.DataSource = null;

            BorrarColumnas();

            cboEstados.DataSource = dt_EstadosServicios;
            cboEstados.DisplayMember = "estado";
            cboEstados.ValueMember = "id";


            dgvDatos.DataSource = dt_Datos;

            dgvDatos.Columns["id"].Visible = false;


            if (ver_detalles == 0)
            {
                dgvDatos.Columns["Nombre"].HeaderText = "Nombre";
                if (seleccion < 3)
                {
                    dgvDatos.Columns["cant_servicios"].HeaderText = "Cantidad de contrataciones";
                    dgvDatos.Columns["cant_servicios"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                }
                else
                {
                    dgvDatos.Columns["cant_servicios"].HeaderText = "Cantidad de contrataciones";
                    dgvDatos.Columns["cant_servicios"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvDatos.Columns["tipo_subservicio"].HeaderText = "Tipo de subservicio";
                }

                AgregarColumnas();
            }


            ActualizarUbicacion();
        }

        private void BorrarColumnas()
        {
            if (dgvDatos.Columns.Count > 0)
            {

                dgvDatos.Columns.Remove("colVerItems");
                dgvDatos.Columns.Remove("colVerDetalles");

            }
        }

        private void AgregarColumnas()
        {
            DataGridViewLinkColumn colVerItems = new DataGridViewLinkColumn();
            colVerItems.Name = "colVerItems";
            colVerItems.HeaderText = "Ver items";
            colVerItems.Text = "Ver items";
            colVerItems.UseColumnTextForLinkValue = true;

            DataGridViewLinkColumn colVerDetalles = new DataGridViewLinkColumn();
            colVerDetalles.Name = "colVerDetalles";
            colVerDetalles.HeaderText = "Ver detalles";
            colVerDetalles.Text = "Ver detalles";
            colVerDetalles.UseColumnTextForLinkValue = true;

            dgvDatos.Columns.Add(colVerItems);
            dgvDatos.Columns.Add(colVerDetalles);


            if (seleccion == 3)
                dgvDatos.Columns["colVerItems"].Visible = false;
            else
                dgvDatos.Columns["colVerItems"].Visible = true;

        }

        private void VerItems()
        {
            try
            {
                switch (seleccion)
                {
                    case 0:
                        grupo_seleccionado = Convert.ToInt32(dgvDatos.CurrentRow.Cells["id"].Value);
                        lblGrupoCabecera.Text = "";
                        lblGrupoCabecera.Text += string.Format("{0} {1}", "Grupo: ", dgvDatos.CurrentRow.Cells["nombre"].Value);
                        break;
                    case 1:
                        tipo_servicio_seleccionado = Convert.ToInt32(dgvDatos.CurrentRow.Cells["id"].Value);
                        lblTipoCabecera.Text = "";
                        lblTipoCabecera.Text += string.Format("{0} {1}", "Tipo de servicio: ", dgvDatos.CurrentRow.Cells["nombre"].Value);
                        break;
                    case 2:
                        servicio_seleccionado = Convert.ToInt32(dgvDatos.CurrentRow.Cells["id"].Value);
                        lblServiciosCabecera.Text = "";
                        lblServiciosCabecera.Text += string.Format("{0} {1}", "Servicio: ", dgvDatos.CurrentRow.Cells["nombre"].Value);
                        break;
                }
                seleccion++;

                if (seleccion == 3)
                    btnConsultar.Enabled = false;

            }
            catch { }
        }

        private void VerDetalles()
        {
            switch (seleccion)
            {
                case 0:
                    grupo_seleccionado = Convert.ToInt32(dgvDatos.CurrentRow.Cells["id"].Value);
                    lblGrupoCabecera.Text = "";
                    lblGrupoCabecera.Text += string.Format("{0} {1}", "Grupo: ", dgvDatos.CurrentRow.Cells["nombre"].Value);
                    break;
                case 1:
                    tipo_servicio_seleccionado = Convert.ToInt32(dgvDatos.CurrentRow.Cells["id"].Value);
                    lblTipoCabecera.Text = "";
                    lblTipoCabecera.Text += string.Format("{0} {1}", "Tipo de servicio: ", dgvDatos.CurrentRow.Cells["nombre"].Value);
                    break;
                case 2:
                    servicio_seleccionado = Convert.ToInt32(dgvDatos.CurrentRow.Cells["id"].Value);
                    lblServiciosCabecera.Text = "";
                    lblServiciosCabecera.Text += string.Format("{0} {1}", "Servicio: ", dgvDatos.CurrentRow.Cells["nombre"].Value);
                    break;
                case 3:
                    lblSubServCabecera.Text = "";
                    lblSubServCabecera.Text += string.Format("{0} {1}", "Sub servicio: ", dgvDatos.CurrentRow.Cells["nombre"].Value);
                    break;
            }


            ver_detalles = 1;

        }

        private void Retroceder()
        {
            switch (seleccion)
            {
                case 0:
                    lblGrupoCabecera.Text = string.Format("{0} {1}", "Grupo", "");
                    break;
                case 1:
                    if (ver_detalles == 0)
                    {
                        lblGrupoCabecera.Text = string.Format("{0} {1}", "Grupo", "");
                        lblTipoCabecera.Text = string.Format("{0} {1}", "Tipo de servicio", "");
                    }
                    else
                        lblTipoCabecera.Text = string.Format("{0} {1}", "Tipo de servicio", "");
                    break;
                case 2:
                    if (ver_detalles == 0)
                    {
                        lblTipoCabecera.Text = string.Format("{0} {1}", "Tipo de servicio", "");
                        lblServiciosCabecera.Text = string.Format("{0} {1}", "Servicio", "");
                    }
                    else
                        lblServiciosCabecera.Text = string.Format("{0} {1}", "Servicio", "");
                    break;
                case 3:
                    lblSubServCabecera.Text = string.Format("{0} {1}", "Sub servicio", "");
                    break;
            }



            if (seleccion == 3)
                btnConsultar.Enabled = true;

            if (ver_detalles == 0)
            {
                if (seleccion != 0)
                    seleccion--;
            }

            ver_detalles = 0;
        }

        private void ActualizarUbicacion()
        {
            switch (seleccion)
            {
                case 0:
                    lblGrupos.ForeColor = Color.Blue;
                    lblTiposServicios.ForeColor = Color.Black;
                    lblServicios.ForeColor = Color.Black;
                    lblSubservicios.ForeColor = Color.Black;

                    break;

                case 1:
                    lblGrupos.ForeColor = Color.Black;
                    lblTiposServicios.ForeColor = Color.Blue;
                    lblServicios.ForeColor = Color.Black;
                    lblSubservicios.ForeColor = Color.Black;

                    break;
                case 2:
                    lblGrupos.ForeColor = Color.Black;
                    lblTiposServicios.ForeColor = Color.Black;
                    lblServicios.ForeColor = Color.Blue;
                    lblSubservicios.ForeColor = Color.Black;

                    break;
                case 3:
                    lblGrupos.ForeColor = Color.Black;
                    lblTiposServicios.ForeColor = Color.Black;
                    lblServicios.ForeColor = Color.Black;
                    lblSubservicios.ForeColor = Color.Blue;
                    break;

            }

        }

        private void FiltrarGrilla()
        {
            if (ver_detalles == 1)
                dt_Datos.DefaultView.RowFilter = String.Format("Usuario Like '%{0}%' or servicio Like '%{0}%' or estado Like '%{0}%' or localidad Like '%{0}%' ", txtBuscar.Text);
            else
                dt_Datos.DefaultView.RowFilter = String.Format("nombre Like '%{0}%'", txtBuscar.Text);
        }

        private void ImprimirReportes()
        {
            try
            {
                total = 0;
                dsInformes oDs = new dsInformes();
                frmReportViewer frm = new frmReportViewer();
                frm.oViewer.ReportSource = null;

                if (dgvDatos.Rows.Count > 0)
                {
                    if (ver_detalles != 1)
                    {

                        foreach (DataGridViewRow fila in dgvDatos.Rows)
                        {
                            oDs.Tables["ServiciosInformesCant"].Rows.Add(
                            new object[]
                            {
                        fila.Cells["nombre"].Value.ToString(),
                        fila.Cells["cant_servicios"].Value.ToString()
                            }
                            );
                        }

                        rptServiciosInformes rpt = new rptServiciosInformes();
                        rpt.SetDataSource(oDs.Tables["ServiciosInformesCant"]);

                        switch (seleccion)
                        {
                            case 0:
                                rpt.SetParameterValue("FiltroServicios", "GRUPOS");
                                rpt.SetParameterValue("EstadoServicios", estadoServicios);
                                rpt.SetParameterValue("GrupoServicios", "-------");
                                rpt.SetParameterValue("TipoServicios", "-------");
                                rpt.SetParameterValue("Servicios", "-------");
                                break;

                            case 1:
                                rpt.SetParameterValue("FiltroServicios", "TIPOS DE SERVICIOS");
                                rpt.SetParameterValue("EstadoServicios", estadoServicios);
                                rpt.SetParameterValue("GrupoServicios", grupo);
                                rpt.SetParameterValue("TipoServicios", "-------");
                                rpt.SetParameterValue("Servicios", "-------");
                                break;
                            case 2:
                                rpt.SetParameterValue("FiltroServicios", "SERVICIOS");
                                rpt.SetParameterValue("EstadoServicios", estadoServicios);
                                rpt.SetParameterValue("GrupoServicios", grupo);
                                rpt.SetParameterValue("TipoServicios", tipo_serv);
                                rpt.SetParameterValue("Servicios", "-------");
                                break;
                            case 3:
                                rpt.SetParameterValue("FiltroServicios", "SUBSERVICIOS");
                                rpt.SetParameterValue("EstadoServicios", estadoServicios);
                                rpt.SetParameterValue("GrupoServicios", grupo);
                                rpt.SetParameterValue("TipoServicios", tipo_serv);
                                rpt.SetParameterValue("Servicios", serv);
                                break;
                        }

                        SumarCantidadServicios();
                        rpt.SetParameterValue("Total", total.ToString());

                        frm.oViewer.ReportSource = rpt;
                        frm.ShowDialog();



                    }
                    else
                    {
                        if (seleccion < 3)
                        {
                            foreach (DataGridViewRow fila in dgvDatos.Rows)
                            {
                                oDs.Tables["DetalleServicios"].Rows.Add(
                                new object[]
                                {
                                fila.Cells["servicio"].Value.ToString(),
                                fila.Cells["Tipo_de_servicio"].Value.ToString(),

                                fila.Cells["usuario"].Value.ToString(),

                                fila.Cells["calle"].Value.ToString(),
                                fila.Cells["altura"].Value.ToString(),
                                fila.Cells["localidad"].Value.ToString(),
                                }
                                );
                            }

                            rptServiciosInformesDet rpt = new rptServiciosInformesDet();
                            rpt.SetDataSource(oDs.Tables["DetalleServicios"]);

                            switch (seleccion)
                            {
                                case 0:
                                    rpt.SetParameterValue("FiltroServicios", "GRUPOS");
                                    rpt.SetParameterValue("EstadoServicios", estadoServicios);
                                    rpt.SetParameterValue("GrupoServicios", grupo);
                                    rpt.SetParameterValue("TipoServicios", "-------");
                                    rpt.SetParameterValue("Servicios", "-------");
                                    break;

                                case 1:
                                    rpt.SetParameterValue("FiltroServicios", "TIPOS DE SERVICIOS");
                                    rpt.SetParameterValue("EstadoServicios", estadoServicios);
                                    rpt.SetParameterValue("GrupoServicios", grupo);
                                    rpt.SetParameterValue("TipoServicios", "-------");
                                    rpt.SetParameterValue("Servicios", "-------");
                                    break;
                                case 2:
                                    rpt.SetParameterValue("FiltroServicios", "SERVICIOS");
                                    rpt.SetParameterValue("EstadoServicios", estadoServicios);
                                    rpt.SetParameterValue("GrupoServicios", grupo);
                                    rpt.SetParameterValue("TipoServicios", tipo_serv);
                                    rpt.SetParameterValue("Servicios", "-------");
                                    break;
                                case 3:
                                    rpt.SetParameterValue("FiltroServicios", "SUBSERVICIOS");
                                    rpt.SetParameterValue("EstadoServicios", estadoServicios);
                                    rpt.SetParameterValue("GrupoServicios", grupo);
                                    rpt.SetParameterValue("TipoServicios", tipo_serv);
                                    rpt.SetParameterValue("Servicios", serv);
                                    break;
                            }

                            SumarCantidadServicios();
                            rpt.SetParameterValue("Total", total.ToString());

                            frm.oViewer.ReportSource = rpt;
                            frm.ShowDialog();








                        }
                        else
                        {
                            foreach (DataGridViewRow fila in dgvDatos.Rows)
                            {
                                oDs.Tables["DetalleSubServicios"].Rows.Add(
                                new object[]
                                {
                                fila.Cells["subservicio"].Value.ToString(),
                                fila.Cells["estado"].Value.ToString(),

                                fila.Cells["usuario"].Value.ToString(),

                                fila.Cells["calle"].Value.ToString(),
                                fila.Cells["altura"].Value.ToString(),
                                fila.Cells["localidad"].Value.ToString(),
                                }
                                );
                            }

                            rptSubServiciosDet rpt = new rptSubServiciosDet();
                            rpt.SetDataSource(oDs.Tables["DetalleSubServicios"]);

                            switch (seleccion)
                            {
                                case 0:
                                    rpt.SetParameterValue("FiltroServicios", "GRUPOS");
                                    rpt.SetParameterValue("EstadoServicios", estadoServicios);
                                    rpt.SetParameterValue("GrupoServicios", grupo);
                                    rpt.SetParameterValue("TipoServicios", "-------");
                                    rpt.SetParameterValue("Servicios", "-------");
                                    break;

                                case 1:
                                    rpt.SetParameterValue("FiltroServicios", "TIPOS DE SERVICIOS");
                                    rpt.SetParameterValue("EstadoServicios", estadoServicios);
                                    rpt.SetParameterValue("GrupoServicios", grupo);
                                    rpt.SetParameterValue("TipoServicios", "-------");
                                    rpt.SetParameterValue("Servicios", "-------");
                                    break;
                                case 2:
                                    rpt.SetParameterValue("FiltroServicios", "SERVICIOS");
                                    rpt.SetParameterValue("EstadoServicios", estadoServicios);
                                    rpt.SetParameterValue("GrupoServicios", grupo);
                                    rpt.SetParameterValue("TipoServicios", tipo_serv);
                                    rpt.SetParameterValue("Servicios", "-------");
                                    break;
                                case 3:
                                    rpt.SetParameterValue("FiltroServicios", "SUBSERVICIOS");
                                    rpt.SetParameterValue("EstadoServicios", estadoServicios);
                                    rpt.SetParameterValue("GrupoServicios", grupo);
                                    rpt.SetParameterValue("TipoServicios", tipo_serv);
                                    rpt.SetParameterValue("Servicios", serv);
                                    break;
                            }

                            SumarCantidadServicios();
                            rpt.SetParameterValue("Total", total.ToString());

                            frm.oViewer.ReportSource = rpt;
                            frm.ShowDialog();



                        }



                    }


                }
                else
                    MessageBox.Show("No hay datos en la grilla para imprimir.");
            }
            catch (Exception)
            {
                MessageBox.Show("Hubo errores al intentar imprimir el informe.");
            }
        }

        private void SetearDatosInforme()
        {
            try
            {
                switch (seleccion)
                {
                    case 0:
                        grupo = dgvDatos.CurrentRow.Cells["nombre"].Value.ToString();

                        break;
                    case 1:
                        tipo_serv = dgvDatos.CurrentRow.Cells["nombre"].Value.ToString();
                        break;
                    case 2:
                        serv = dgvDatos.CurrentRow.Cells["nombre"].Value.ToString();
                        break;
                    case 3:
                        subserv = dgvDatos.CurrentRow.Cells["nombre"].Value.ToString();
                        break;

                }
            }
            catch { }
        }

        private void SumarCantidadServicios()
        {
            foreach (DataGridViewRow fila in dgvDatos.Rows)
            {
                if (ver_detalles == 0)
                    total += Convert.ToInt32(fila.Cells["cant_servicios"].Value);
                else
                    total++;
            }
        }
        #endregion

        public frmServiciosInformes()
        {
            InitializeComponent();
        }

        private void frmServiciosInformes_Load(object sender, EventArgs e)
        {
            id_estado = Convert.ToInt32(Servicios.Servicios_Estados.SIN_CONECTAR);
            estadoServicios = "SIN CONECTAR";
            seleccion = 0;
            ver_detalles = 0;
            comenzarCarga();

        }

        private void frmServiciosInformes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                id_estado = Convert.ToInt32(cboEstados.SelectedValue);
                estadoServicios = cboEstados.Text;

                comenzarCarga();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar información: " + ex.Message);
            }
        }


        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            SetearDatosInforme();

            if (dgvDatos.Columns[e.ColumnIndex].Name.Equals("colVerItems"))
            {
                VerItems();
                comenzarCarga();
            }
            else if (dgvDatos.Columns[e.ColumnIndex].Name.Equals("colVerDetalles"))
            {
                VerDetalles();

                comenzarCarga();
            }

        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.Rows.Count > 0)
            {
                Tools tools = new Tools();
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    tools.ExportToExcel(dgvDatos, "Servicios Informe");
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FiltrarGrilla();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text.Length == 0)
            {
                if (ver_detalles == 1)
                    dt_Datos.DefaultView.RowFilter = "id>0";
                else
                    dt_Datos.DefaultView.RowFilter = "id>0";
            }
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

            ImprimirReportes();
        }
    }
}
