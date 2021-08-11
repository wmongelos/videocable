using CapaNegocios;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;


namespace CapaPresentacion.Herramientas
{
    public partial class frmisp : Form
    {
        private Equipos oEquipos = new Equipos();
        private DataTable dtUsuariosServiciosEquipos = new DataTable();
        private Aplicaciones_Externas oAplicacionesExternas = new Aplicaciones_Externas();
        private DataTable dtDatosApp = new DataTable();
        private Thread hilo;
        private Isp oISP = new Isp();
        private delegate void myDel();
        int contador = 0;
        private Decimal porcentajeHecho;
        int idProduct;
        int idEquipment;
        int indice = 0;
        int idAaccount;
        int idCustomer = 0;
        int idLocation = 0;
        int retorno;
        DataTable dt = new DataTable();

        #region metodos
        private void comenzarCarga()
        {
            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
        }

        private void cargarDatos()
        {
            try
            {
                dtUsuariosServiciosEquipos = oEquipos.ListarUsuariosServiciosEquipos();
                dtDatosApp = oAplicacionesExternas.Listar(1);
                Isp.cadenaConexion = dtDatosApp.Rows[0]["string_conexion"].ToString();

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
            dgv1.DataSource = dtUsuariosServiciosEquipos;
            foreach (DataGridViewColumn item in dgv1.Columns)
            {
                item.Visible = false;
            }
            dt.Columns.Add("id_usaurio_Servicio_equipo", typeof(int));
            DataColumn dcProducto = new DataColumn();
            dcProducto.DataType = typeof(int);
            dcProducto.ColumnName = "id_producto";
            dcProducto.DefaultValue = 0;
            dt.Columns.Add(dcProducto);
            DataColumn dcAcoount = new DataColumn();
            dcAcoount.DataType = typeof(int);
            dcAcoount.ColumnName = "id_account";
            dcAcoount.DefaultValue = 0;
            dt.Columns.Add(dcAcoount);
            DataColumn dcCustomer = new DataColumn();
            dcCustomer.DataType = typeof(int);
            dcCustomer.ColumnName = "id_customer";
            dcCustomer.DefaultValue = 0;
            dt.Columns.Add(dcCustomer);
            DataColumn dcLocacion = new DataColumn();
            dcLocacion.DataType = typeof(int);
            dcLocacion.ColumnName = "id_location";
            dcLocacion.DefaultValue = 0;
            dt.Columns.Add(dcLocacion);
            DataColumn dEquipo = new DataColumn();
            dEquipo.DataType = typeof(int);
            dEquipo.ColumnName = "id_equipment";
            dEquipo.DefaultValue = 0;
            dt.Columns.Add(dEquipo);

            dgv1.Columns["id"].Visible = true;
            dgv1.Columns["id_equipo"].Visible = true;
            dgv1.Columns["id_equipment"].Visible = true;
            dgv1.Columns["id_account_Acces"].Visible = true;
            dgv1.Columns["id_producto"].Visible = true;
            dgv1.Columns["id_producto_aux"].Visible = true;
            dgv1.Columns["mac"].Visible = true;
            pgBar.Minimum = 0;
            pgBar.Maximum = dtUsuariosServiciosEquipos.Rows.Count;
            lblTotal.Text = string.Format("Total: {0}", dtUsuariosServiciosEquipos.Rows.Count);
        }

        private void procesarDatos(object o, DoWorkEventArgs e)
        {

            string mac = "";
            DataTable dtDatosAccount = new DataTable();
            foreach (DataRow item in dtUsuariosServiciosEquipos.Rows)
            {
                idAaccount = 0;
                idEquipment = 0;
                mac = item["mac"].ToString();
                dtDatosAccount = new DataTable();
                idEquipment = oISP.VerificarExisteEquipo(mac, "");
                if (idEquipment > 0)
                {
                    idAaccount = oISP.obtenerIdAccesAccount(idEquipment);
                    if (idAaccount > 0)
                    {
                        dtDatosAccount = oISP.ListarDatosAccoun(idAaccount);
                        if (dtDatosAccount.Rows.Count > 0)
                        {
                            idLocation = Convert.ToInt32(dtDatosAccount.Rows[0]["location_id"]);
                            idProduct = Convert.ToInt32(dtDatosAccount.Rows[0]["product_id"]);
                            idCustomer = Convert.ToInt32(dtDatosAccount.Rows[0]["customer_id"]);
                            dt.Rows.Add(Convert.ToInt32(item["id"]), idProduct, idAaccount, idCustomer, idLocation, idEquipment);

                        }
                        else
                            idProduct = 0;
                    }
                }


            }
        }

        #endregion

        public frmisp()
        {
            InitializeComponent();
        }

        private void frmisp_Load(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.DoWork += procesarDatos;
            backgroundWorker1.RunWorkerCompleted += termino;
            backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
            backgroundWorker1.RunWorkerAsync();
        }
        private void termino(object o, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Listo", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DataTable dtd = dt;

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pgBar.Value = e.ProgressPercentage;
            porcentajeHecho = (contador * 100) / dtUsuariosServiciosEquipos.Rows.Count;

            lblDato.Text = string.Format("Procesando: {0} de {1} ({2} %)", contador, dtUsuariosServiciosEquipos.Rows.Count, porcentajeHecho.ToString());
            try
            {
                dgv1.Rows[contador].DefaultCellStyle.BackColor = Color.LightGreen;
            }
            catch (Exception C)
            {
                throw;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pgBar.Maximum = dt.Rows.Count;
            this.KeyPreview = false;
            Cursor = Cursors.WaitCursor;
            tarea.DoWork += generarCambios;
            tarea.RunWorkerCompleted += Terminado;
            tarea.RunWorkerAsync();
        }

        private void generarCambios(object o, DoWorkEventArgs e)
        {

        }

        private void tarea_DoWork(object sender, DoWorkEventArgs e)
        {
            int idUSE = 0;
            contador = 0;
            porcentajeHecho = 0;

            foreach (DataRow item in dt.Rows)
            {

                idUSE = Convert.ToInt32(item["id_usaurio_Servicio_equipo"]);
                idProduct = Convert.ToInt32(item["id_producto"]);
                idAaccount = Convert.ToInt32(item["id_account"]);
                idCustomer = Convert.ToInt32(item["id_customer"]);
                idLocation = Convert.ToInt32(item["id_location"]);
                idEquipment = Convert.ToInt32(item["id_equipment"]);
                retorno = oEquipos.ActualizarDatos(idUSE, idProduct, idAaccount, idCustomer, idLocation, idEquipment);
                tarea.ReportProgress(contador, dt.Rows.Count);
                contador++;
            }
        }

        private void Terminado(object o, RunWorkerCompletedEventArgs e)
        {
            pgBar.Value = pgBar.Maximum;
            this.Cursor = Cursors.Arrow;
            MessageBox.Show("Cambios hechs.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }


        private void tarea_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pgBar.Value = e.ProgressPercentage;
            porcentajeHecho = (contador * 100) / dt.Rows.Count;
            lblDato.Text = string.Format("Procesando: {0} de {1} ({2} %)", contador, dt.Rows.Count, porcentajeHecho.ToString());

            try
            {
                if (retorno == 0)
                    dgv1.Rows[contador - 1].DefaultCellStyle.BackColor = Color.Green;
                else
                    dgv1.Rows[contador - 1].DefaultCellStyle.BackColor = Color.IndianRed;

                dgv1.Rows[contador].Selected = true;
            }
            catch { }
        }
    }
}
