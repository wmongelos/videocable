using CapaNegocios;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Informes
{
    public partial class frmAnalisisDeudaNuevo : Form
    {
        public frmAnalisisDeudaNuevo()
        {
            InitializeComponent();
        }
        #region [PROPIEDADES]
        private Configuracion oConf = new Configuracion();
        private Thread hilo;
        private delegate void myDel();
        private DataTable dtMeses = new DataTable();
        private DataTable dtYears = new DataTable();
        private DataTable dtDatos = new DataTable();
        private DataTable dtLocalidades;
        private DataTable dtTipoFac;
        private Informes_Contables oInformes = new Informes_Contables();
        private decimal Total = 0;
        int mes, anio, tipoFac;
        #endregion

        #region [METODOS]
        private void ComenzarCarga()
        {
            pgCircular.Start();
            hilo = new Thread(new ThreadStart(CargarDatos));
            hilo.IsBackground = true;
            hilo.Start();
            btnBuscar.Enabled = false;
            btnExportar.Enabled = false;
        }

        private void CargarDatos()
        {
            try
            {
                dtDatos = oInformes.ListarAnalisisDeuda(mes, anio);
                myDel MD = new myDel(AsignarDatos);
                this.Invoke(MD, new object[] { });
            }
            catch
            {
                MessageBox.Show("Error al cargar información.");
            }
            pgCircular.Stop();
        }

        private void AsignarDatos()
        {
            dgvDatos.DataSource = null;
            dgvDatos.DataSource = dtDatos;
            FormatearGrilla();
            CalcularTotales();
            btnBuscar.Enabled = true;
            btnExportar.Enabled = true;
            if (dtDatos.Rows.Count > 0)
                pnlFiltros.Enabled = true;
            else
                pnlFiltros.Enabled = false;
        }

        private void FormatearGrilla()
        {

            dgvDatos.Columns["id_zona"].Visible = false;
            dgvDatos.Columns["id_tipo_facturacion"].Visible = false;
            dgvDatos.Columns["id_servicio_tipo"].Visible = false;
            dgvDatos.Columns["id_categoria"].Visible = false;
            dgvDatos.Columns["id_localidad"].Visible = false;
            dgvDatos.Columns["id_servicio"].Visible = false;
            if (oConf.GetValor_N("id_tipo_facturacion") == 1)
            {
                dgvDatos.Columns["categoria"].Visible = false;
                dgvDatos.Columns["localidad"].Visible = true;
                dgvDatos.Columns["zona"].Visible = true;

            }
            else
            {
                dgvDatos.Columns["zona"].Visible = false;
                dgvDatos.Columns["localidad"].Visible = false;
                dgvDatos.Columns["categoria"].Visible = true;

            }
            dgvDatos.Columns["facturado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDatos.Columns["facturado"].DefaultCellStyle.Format = "C2";
            dgvDatos.Columns["facturado"].HeaderText = "Facturado";
            dgvDatos.Columns["localidad"].HeaderText = "Localidad";
            dgvDatos.Columns["tipo"].HeaderText = "Tipo de servicio";
            dgvDatos.Columns["servicio"].HeaderText = "Servicio";
            dgvDatos.Columns["deuda"].HeaderText = "Deuda";
            dgvDatos.Columns["deuda"].DefaultCellStyle.Format = "C2";
            dgvDatos.Columns["deuda"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDatos.Columns["zona"].HeaderText = "Zona";
            dgvDatos.Columns["categoria"].HeaderText = "Categoria";

          
        }
        private void CalcularTotales()
        {
            decimal totalFac = 0,totalSinCobrar=0;

            foreach (DataRow fila in dtDatos.Rows)
            {
                totalFac = totalFac + Convert.ToDecimal(fila["facturado"]);
                totalSinCobrar = totalSinCobrar + Convert.ToDecimal(fila["deuda"]);
            }
            lblTotalFacturado.Text = $"Total facturado:{totalFac.ToString("c2")}";
            lblDeuda.Text = $"Total adeudado:{totalSinCobrar.ToString("c2")}";

        }
        #endregion
        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAnalisisDeudaNuevo_Load(object sender, EventArgs e)
        {
            dtMeses.Columns.Add("mes", typeof(string));
            dtYears.Columns.Add("year", typeof(string));
            dtYears.Columns.Add("year_id", typeof(int));
            for (int i = 1; i < 13; i++)
            {
                if (i < 10)
                    dtMeses.Rows.Add("0" + i.ToString());
                else
                    dtMeses.Rows.Add(i.ToString());

            }
            int cantYaears = 15;
            int actualYear = DateTime.Now.Year;
            actualYear = actualYear - 10;
            for (int i = actualYear; i < actualYear + cantYaears; i++)
                dtYears.Rows.Add(i.ToString(), i);//el string es para lo que se ve y el int es para el valor que puede leer de la base en caso que el plastico ya exista

            cboMesDesde.DataSource = dtMeses;
            cboMesDesde.DisplayMember = "mes";
            cboAnioDesde.DataSource = dtYears;
            cboAnioDesde.DisplayMember = "year";
            cboAnioDesde.ValueMember = "year_id";
           
            dtTipoFac = Tablas.DataTiposFacturacion.Copy();
            cboTipoFac.DataSource = dtTipoFac;
            cboTipoFac.DisplayMember = "nombre";
            cboTipoFac.ValueMember = "id";
            dtTipoFac.Rows.Add(0, "TODAS");

            dtLocalidades = Tablas.DataLocalidades.Copy();
            dtLocalidades.Rows.Add(0,0,"TODAS");
            cboLocalidades.DataSource = dtLocalidades;
            cboLocalidades.DisplayMember = "nombre";
            cboLocalidades.ValueMember = "id";
            if (oConf.GetValor_N("id_tipo_facturacion") == 1)
            {
                cboLocalidades.Visible = true;
                cboLocalidades.SelectedValue = 0;
                lblTipoFac.Text = "Zonas:";
            }
            else
            {
                lblTipoFac.Text = "Categorias:";
                cboLocalidades.Visible = false;
            }


        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            Tools oTools = new Tools();
            oTools.ExportDataTableToExcel(dtDatos, "Informes de deudas");
        }

        private void cboTipoFac_SelectionChangeCommitted(object sender, EventArgs e)
        {
            tipoFac = Convert.ToInt32(cboTipoFac.SelectedValue);
            if (oConf.GetValor_N("id_tipo_facturacion") == 1)
            {

                DataView dv = dtDatos.DefaultView;
                if(tipoFac>0)
                    dv.RowFilter = $"id_tipo_facturacion={tipoFac}";
                else
                    dv.RowFilter = $"id_tipo_facturacion>0";
            }
        }

        private void frmAnalisisDeudaNuevo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void dgvDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void cboLocalidades_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int localidad = Convert.ToInt32(cboLocalidades.SelectedValue);
            if (oConf.GetValor_N("id_tipo_facturacion") == 1)
            {
                DataView dv = dtDatos.DefaultView;
                if (localidad > 0) { 
                    if(tipoFac>0)
                        dv.RowFilter = $"id_localidad={localidad} and id_tipo_facturacion={tipoFac}";
                    else
                        dv.RowFilter = $"id_localidad={localidad}";
                }
                else
                {
                    if (tipoFac > 0)
                        dv.RowFilter = $"id_tipo_facturacion={tipoFac}";
                    else
                        dv.RowFilter = "";


                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            mes = Convert.ToInt32(cboMesDesde.Text);
            anio = Convert.ToInt32(cboAnioDesde.Text);

            ComenzarCarga();

        }
    }
}
