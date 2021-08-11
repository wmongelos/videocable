using CapaNegocios;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;


namespace CapaPresentacion.Informes
{
    public partial class ConsultaEquipoResultado : Form
    {
        public string filtro = "";
        public bool asignados = false; //si se va a buscar equipos asignados entonces se toma la tabla usuarios_servicios_equipos y si no estan asignados a usuarios se toma la tabla equipos
        private Thread hilo;
        private delegate void myDel();
        private Equipos oEquipos = new Equipos();
        private Configuracion oConf = new Configuracion();
        private DataTable dtEquipos = new DataTable();

        private void comenzarCarga()
        {
            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.IsBackground = true;
            hilo.Start();
        }
        private void cargarDatos()
        {
            try
            {
                dtEquipos = oEquipos.ListarInformeAsignados(this.filtro,this.asignados);
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
            dgv.DataSource = dtEquipos;
            if (oConf.GetValor_N("id_tipo_facturacion") == 1)
                dgv.Columns["tipofac"].HeaderText = "Zona";
            else
                dgv.Columns["tipofac"].HeaderText = "Categoria";
            
            dgv.Columns["tipofac"].HeaderText = "Categoria";

            lblTotal.Text = $"Equipos encontrados: {dtEquipos.Rows.Count} ";
            groupBox2.Enabled = true;
        }

        public ConsultaEquipoResultado()
        {
            InitializeComponent();
        }

        private void ConsultaEquipoResultado_Load(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if(rbAbonado.Checked || rbMac.Checked || rbSerie.Checked || rbTarjeta.Checked)
            {
                DataView dvEquipos = dtEquipos.DefaultView;
                dvEquipos.RowFilter = "";
                if (txtFiltro.Text.Length > 0)
                {
                    try
                    {
                        if (rbMac.Checked)
                            dvEquipos.RowFilter = $"mac LIKE '%{txtFiltro.Text}%'";
                        if (rbSerie.Checked)
                            dvEquipos.RowFilter = $"serie LIKE '%{txtFiltro.Text}%'";
                        if (rbTarjeta.Checked)
                            dvEquipos.RowFilter = $"tarjeta LIKE '%{txtFiltro.Text}%'";
                        if (rbAbonado.Checked)
                            dvEquipos.RowFilter = $"codigo LIKE '%{txtFiltro.Text}%' or abonado LIKE '%{txtFiltro.Text}%'";

                       
                        lblTotal.Text = $"Equipos encontrados: {dvEquipos.Count} ";

                    }
                    catch (Exception c)
                    {
                        MessageBox.Show("Hubo un error al intentar filtrar datos:  " + c.ToString());
                    }
                }
                else
                    lblTotal.Text = $"Equipos encontrados: {dtEquipos.Rows.Count} ";

            }
            else
                MessageBox.Show("Debe seleccionar un tipo de filtro","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);

        }

        private void boton1_Click(object sender, EventArgs e)
        {
            Tools oHerramientas = new Tools();
            oHerramientas.ExportDataTableToExcel(dtEquipos,"Equipos");
        }

        private void columnasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var obj = dgv.SelectedCells[0].Value.ToString().Trim();
            Clipboard.SetText(obj);

        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConsultaEquipoResultado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
