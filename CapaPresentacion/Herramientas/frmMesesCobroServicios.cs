using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Globalization;
using CapaNegocios;
using System.Windows.Forms;

namespace CapaPresentacion.Herramientas
{

    public partial class frmMesesCobroServicios : Form
    {
        private Thread hilo;
        private delegate void myDel();
        private DataTable dt_UsuServ, dtTarifa_Sub,dtServEsp, dtServicios;
        private Servicios_Tarifas_Sub_Esp otarEsp = new Servicios_Tarifas_Sub_Esp();
        private Servicios oServ = new Servicios();
        private Servicios_Tarifas oTarifa = new Servicios_Tarifas();
        int idTarifaActual = 0, Filtro = 0, todoOk=0;

        private Configuracion oConfig = new Configuracion();
        private Tipo_Facturacion.Id_Tipo_Facturacion TipoFacturacion = Tipo_Facturacion.Id_Tipo_Facturacion.POR_ZONAS;
        private DataTable dtZonas;
        private DataTable dtCategorias;

        private Zonas oZonas = new Zonas();
        private Servicios_Categorias oCat = new Servicios_Categorias();

        public frmMesesCobroServicios()
        {
            InitializeComponent();
        }


        private void comenzarCarga()
        {

            //dgvUsuServ.DataSource = null;
            //dgvTarifasEsp.DataSource = null;

            cboServicio.SelectedValue = 0;
            cboTipoFacturacion.SelectedValue = 0;

            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
        }


        private void cargarDatos()
        {
            try
            {
                //dtTarifa_Sub = otarEsp.GetTarifaSubEspGroupServicios(idTarifaActual);
                //dt_UsuServ = otarEsp.GetUsuServGroupServicios();
                //dtServEsp = oServ.ListarEspeciales();

                TipoFacturacion = oConfig.GetValor_N("Id_Tipo_Facturacion") == 1 ? Tipo_Facturacion.Id_Tipo_Facturacion.POR_ZONAS : Tipo_Facturacion.Id_Tipo_Facturacion.POR_CATEGORIAS;
                switch (TipoFacturacion)
                {
                    case Tipo_Facturacion.Id_Tipo_Facturacion.POR_ZONAS:
                        dtZonas = oZonas.Listar();
                        dtZonas.Rows.Add(0, "[SELECCIONAR]");

                        break;
                    case Tipo_Facturacion.Id_Tipo_Facturacion.POR_CATEGORIAS:
                        dtCategorias = oCat.Listar();
                        dtCategorias.Rows.Add(0, "[SELECCIONAR]");

                        break;
                }


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

            cboTipoFacturacion.DataSource = TipoFacturacion == Tipo_Facturacion.Id_Tipo_Facturacion.POR_ZONAS ? dtZonas : dtCategorias;
            cboTipoFacturacion.DisplayMember = TipoFacturacion == Tipo_Facturacion.Id_Tipo_Facturacion.POR_ZONAS ? "Nombre" : "nombre";
            cboTipoFacturacion.ValueMember = TipoFacturacion == Tipo_Facturacion.Id_Tipo_Facturacion.POR_ZONAS ? "Id" : "Id";
            cboTipoFacturacion.SelectedValue = 0;
            cboTipoFacturacion.SelectedIndexChanged += cboTipoFacturacion_SelectedValueChanged;

            //dgvTarifasEsp.DataSource = dtTarifa_Sub;
            //dgvUsuServ.DataSource = dt_UsuServ;

            //for (int i = 0; i < dgvTarifasEsp.ColumnCount; i++)
            //    dgvTarifasEsp.Columns[i].Visible = true;

            //dgvTarifasEsp.Columns["id_serv"].Visible = false;
            //dgvTarifasEsp.Columns["servicio"].HeaderText = "Servicio";
            //dgvTarifasEsp.Columns["mes_cobro"].HeaderText = "Mes de Cobro";
            //dgvTarifasEsp.Columns["mes_servicio"].HeaderText = "Mes de Servicio";
            //dgvTarifasEsp.Columns["importe"].HeaderText = "Importe Final";
            //dgvTarifasEsp.Columns["Importe"].DefaultCellStyle.Format = "C2";
            //dgvTarifasEsp.Columns["Importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgvTarifasEsp.Columns["Importe"].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("en-US");

            //for (int i = 0; i < dgvUsuServ.ColumnCount; i++)
            //    dgvUsuServ.Columns[i].Visible = true;

            //dgvUsuServ.Columns["id_serv"].Visible = false;
            //dgvUsuServ.Columns["mes_cobro"].Visible = false;
            //dgvUsuServ.Columns["mes_servicio"].Visible = false;
            //dgvUsuServ.Columns["servicio"].HeaderText = "Servicio";


            //cboServicios.DataSource = dtServEsp;
            //cboServicios.ValueMember = "Id";
            //cboServicios.DisplayMember = "Descripcion";

            //foreach(DataRow dr1 in dtTarifa_Sub.Rows)
            //{
            //    foreach(DataRow dr2 in dt_UsuServ.Rows)
            //    {
            //        if (Convert.ToInt32(dr1["id_serv"]) == Convert.ToInt32(dr2["id_serv"])) 
            //        {
            //            if( Convert.ToInt32(dr1["Mes_Cobro"]) == Convert.ToInt32(dr2["Mes_Cobro"]) &&
            //                Convert.ToInt32(dr1["Mes_Servicio"]) == Convert.ToInt32(dr2["Mes_Servicio"]) &&
            //                Convert.ToInt32(dr1["id_tipo_facturacion"]) == Convert.ToInt32(dr2["id_tipo_facturacion"]))
            //            { 
            //                todoOk = 1;
            //            }
            //            else
            //            {
            //                todoOk = 2;
            //                break;
            //            }
            //        }
            //    }
            //    if (todoOk == 2)
            //        break;
            //}
            //if (todoOk == 1) 
            //{ 
            //    lblServiciosTarifas.ForeColor = Color.Green;
            //    lblServUsuServ.ForeColor = Color.Green;
            //}
            //else 
            //{
            //    lblServiciosTarifas.ForeColor = Color.Green;
            //    lblServUsuServ.ForeColor = Color.Red;
            //}
        }

        private void frmMesesCobroServicios_Load(object sender, EventArgs e)
        {
            oTarifa.Fecha_Actual = DateTime.Now;
            idTarifaActual = oTarifa.getTarifa();
            comenzarCarga();
        }

        public static DataTable JoinDataTable(DataTable dataTable1, DataTable dataTable2, string joinField)
        {
            var dt = new DataTable();
            var joinTable = from t1 in dataTable1.AsEnumerable()
                            join t2 in dataTable2.AsEnumerable()
                                on t1[joinField] equals t2[joinField]
                            select new { t1, t2 };

            foreach (DataColumn col in dataTable1.Columns)
                dt.Columns.Add(col.ColumnName, typeof(string));

            dt.Columns.Remove(joinField);

            foreach (DataColumn col in dataTable2.Columns)
                dt.Columns.Add(col.ColumnName, typeof(string));

            foreach (var row in joinTable)
            {
                var newRow = dt.NewRow();
                newRow.ItemArray = row.t1.ItemArray.Union(row.t2.ItemArray).ToArray();
                dt.Rows.Add(newRow);
            }
            return dt;
        }

        DataTable dtTipoFacturacion;

        private void cboTipoFacturacion_SelectedValueChanged(object sender, EventArgs e)
        {
            Tipo_Facturacion oTipoFacturacion = new Tipo_Facturacion();
            if(oConfig.GetValor_N("Id_Tipo_Facturacion") ==  (int)Tipo_Facturacion.Id_Tipo_Facturacion.POR_ZONAS)
                dtTipoFacturacion = oTipoFacturacion.ListarConOrigenMeses(Convert.ToInt32(cboTipoFacturacion.SelectedValue));
            else if (oConfig.GetValor_N("Id_Tipo_Facturacion") == (int)Tipo_Facturacion.Id_Tipo_Facturacion.POR_CATEGORIAS)
                dtTipoFacturacion = oTipoFacturacion.Listar(Convert.ToInt32(cboTipoFacturacion.SelectedValue), true);

            dtTipoFacturacion.Rows.Add(0, 0, 0, 0, 0, "[SELECCIONAR]");

            cboServicio.DataSource = dtTipoFacturacion;
            cboServicio.DisplayMember = "servicio";
            cboServicio.ValueMember = "Id_Servicios";
            cboServicio.SelectedValue = 0;
            cboServicio.Visible = true;

            if (Convert.ToInt32(cboTipoFacturacion.SelectedValue) == 0)
                cboServicio.Visible = false;

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboTipoFacturacion.SelectedValue) != 0 && Convert.ToInt32(cboServicio.SelectedValue) != 0)
            {
                int id_tipo_facturacion = Convert.ToInt32(cboTipoFacturacion.SelectedValue);
                int id_servicio = Convert.ToInt32(cboServicio.SelectedValue);
                DataView dv = Tablas.DataServicios.DefaultView;
                dv.RowFilter = "id=" + id_servicio + "";
                DataTable dtFiltrado = dv.ToTable();

                string requiereVelocidad = dtFiltrado.Rows[0]["requiere_velocidad"].ToString();
                int servicioModalidad = Convert.ToInt32(dtFiltrado.Rows[0]["id_servicios_modalidad"]);
                int opcion;

                if(servicioModalidad== (int)Servicios._Modalidad.DIA)
                {
                    MessageBox.Show("No se pueden actualizar los Servicios con Modalidad Prepaga");
                    comenzarCarga();
                }
                else if (servicioModalidad==(int)Servicios._Modalidad.MENSUAL)
                {
                    if (otarEsp.ActualizaEspecialesRamiro(idTarifaActual, id_servicio, id_tipo_facturacion))
                        MessageBox.Show("Datos actualizados correctamente");
                    else
                        MessageBox.Show("No se pudieron actualizar los datos");

                    comenzarCarga();
                }
                else
                {
                    opcion = 1;
                    if (otarEsp.ActualizaEspecialesRamiro(idTarifaActual, id_servicio, id_tipo_facturacion, opcion))
                        MessageBox.Show("Datos actualizados correctamente");
                    else
                        MessageBox.Show("No se pudieron actualizar los datos");

                    comenzarCarga();
                }
            }
            else
                MessageBox.Show("Complete los campos antes de actualizar");

            //if(rbTodos.Checked == true) 
            //{ 
            //    if(otarEsp.ActualizaEspeciales(idTarifaActual, 0))
            //        MessageBox.Show("Datos actualizados correctamente");
            //    else
            //        MessageBox.Show("No se pudieron actualizar los datos.");

            //}
            //else 
            //{
            //    int id_servicio = 0;
            //    id_servicio = Convert.ToInt32(cboServicios.SelectedValue);
            //    if (otarEsp.ActualizaEspeciales(idTarifaActual, id_servicio))
            //        MessageBox.Show("Datos actualizados correctamente");
            //    else
            //        MessageBox.Show("No se pudieron actualizar los datos");
            //}
            //comenzarCarga();

        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbServicioEspecifico_CheckedChanged(object sender, EventArgs e)
        {
            //if (rbServicioEspecifico.Checked == true)
            //    cboServicios.Visible = true;
        }

        private void rbTodos_CheckedChanged(object sender, EventArgs e)
        {
            //if(rbTodos.Checked == true) 
            //    cboServicios.Visible = false;
        }
    }
}
