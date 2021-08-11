using CapaNegocios;
using CapaPresentacion.Herramientas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CapaPresentacion.Partes_Trabajo
{
    public partial class frmConsultaHistorial : Form
    {
        private const string TAB = "    ";

        private DataTable dtPreview = new DataTable();
        private DataTable dt = new DataTable();
        private Partes_Informes oPartesInformes = new Partes_Informes();
        private Partes_Estados oPartesEstados = new Partes_Estados();
        private Localidades oLocalidades = new Localidades();
        private Zonas oZonas = new Zonas();
        private Partes oPartes = new Partes();
        private Personal_Areas oPersonalAreas = new Personal_Areas();
        private Personal oPersonal = new Personal();
        private Servicios oServicios = new Servicios();

        private DataTable dtEstados = new DataTable();
        private DataTable dtZonas = new DataTable();
        private DataTable dtLocalidades = new DataTable();
        private DataTable dtPartesOperaciones = new DataTable();
        private DataTable dtAreasPersonal = new DataTable();
        private DataTable dtPersonal = new DataTable();
        private DataTable dtServicios = new DataTable();

        private static List<int> estadosSeleccionados = new List<int>();
        private static List<int> zonasSeleccionadas = new List<int>();
        private static List<int> localidadesSeleccionadas = new List<int>();
        private static List<int> operacionesSeleccionadas = new List<int>();
        private static List<int> areaPersonalSeleccionadas = new List<int>();
        private static List<int> personalSeleccionado = new List<int>();
        private static List<int> serviciosSeleccionados = new List<int>();

        private int estadosMax = 0;
        private int zonasMax = 0;
        private int localidadesMax = 0;
        private int operacionesMax = 0;
        private int areaPersonalMax = 0;
        private int personalMax = 0;
        private int serviciosMax = 0;

        private static Dictionary<int, string> estadosDictionary = new Dictionary<int, string>();
        private static Dictionary<int, string> serviciosDictionary = new Dictionary<int, string>();
        private static Dictionary<int, string> zonasDictionary = new Dictionary<int, string>();
        private static Dictionary<int, string> localidadesDictionary = new Dictionary<int, string>();
        private static Dictionary<int, string> operacionesDictionary = new Dictionary<int, string>();
        private static Dictionary<int, string> areaPersonalDictionary = new Dictionary<int, string>();
        private static Dictionary<int, string> personalDictionary = new Dictionary<int, string>();

        public frmConsultaHistorial()
        {
            InitializeComponent();
            EstablecerDateTimePicker();

            DataColumn dcTipo = new DataColumn("tipo", typeof(int)) { DefaultValue = 0 };
            DataColumn dcTitulo = new DataColumn("titulo", typeof(string)) { ColumnName = "Campos seleccionados" };
            dtPreview.Columns.Add(dcTipo);
            dtPreview.Columns.Add(dcTitulo);
        }

        private void frmConsultaHistorial_Load(object sender, EventArgs e)
        {
            dtEstados = oPartesEstados.Listar();
            dtZonas = oZonas.Listar();
            dtLocalidades = oLocalidades.Listar();
            dtPartesOperaciones = oPartes.ListarOperaciones();
            dtPartesOperaciones.DefaultView.RowFilter = $"id <> {Convert.ToInt32(Partes.Partes_Operaciones.INFRAESTRUCTURA)}";
            dtPartesOperaciones = dtPartesOperaciones.DefaultView.ToTable();
            dtAreasPersonal = oPersonalAreas.Listar();
            dtPersonal = oPersonal.ListarPersonalYArea();
            dtServicios = oServicios.Listar();

            LimpiarVariables();

            dgv.DataSource = dtPreview;
            dgv.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);

            dgv.Columns["tipo"].Visible = false;

            dtPreview.Rows.Add(1, "Estados");
            dtPreview.Rows.Add(0, $"{TAB}TODOS");
            foreach (DataRow row in dtEstados.Rows)
            {
                estadosSeleccionados.Add(Convert.ToInt32(row["id"]));
                estadosDictionary.Add(Convert.ToInt32(row["id"]), row["nombre"].ToString());
            }
            estadosMax = estadosSeleccionados.Count;

            dtPreview.Rows.Add(1, "Zonas");
            dtPreview.Rows.Add(0, $"{TAB}TODOS");
            foreach (DataRow row in dtZonas.Rows)
            {
                zonasSeleccionadas.Add(Convert.ToInt32(row["id"]));
                zonasDictionary.Add(Convert.ToInt32(row["id"]), row["nombre"].ToString());
            }
            zonasMax = zonasSeleccionadas.Count;

            dtPreview.Rows.Add(1, "Localidades");
            dtPreview.Rows.Add(0, $"{TAB}TODOS");
            foreach (DataRow row in dtLocalidades.Rows)
            {
                localidadesSeleccionadas.Add(Convert.ToInt32(row["id"]));
                localidadesDictionary.Add(Convert.ToInt32(row["id"]), row["nombre"].ToString());
            }
            localidadesMax = localidadesSeleccionadas.Count;

            dtPreview.Rows.Add(1, "Operaciones");
            dtPreview.Rows.Add(0, $"{TAB}TODOS");
            foreach (DataRow row in dtPartesOperaciones.Rows)
            {
                operacionesSeleccionadas.Add(Convert.ToInt32(row["id"]));
                operacionesDictionary.Add(Convert.ToInt32(row["id"]), row["nombre"].ToString());
            }
            operacionesMax = operacionesSeleccionadas.Count;

            dtPreview.Rows.Add(1, "Area personal");
            dtPreview.Rows.Add(0, $"{TAB}TODOS");
            foreach (DataRow row in dtAreasPersonal.Rows)
            {
                areaPersonalSeleccionadas.Add(Convert.ToInt32(row["id"]));
                areaPersonalDictionary.Add(Convert.ToInt32(row["id"]), row["nombre"].ToString());
            }
            areaPersonalMax = areaPersonalSeleccionadas.Count;

            dtPreview.Rows.Add(1, "Personal");
            dtPreview.Rows.Add(0, $"{TAB}TODOS");
            foreach (DataRow row in dtPersonal.Rows)
            {
                personalSeleccionado.Add(Convert.ToInt32(row["id"]));
                personalDictionary.Add(Convert.ToInt32(row["id"]), row["nombre"].ToString());
            }
            personalMax = personalSeleccionado.Count;

            dtPreview.Rows.Add(1, "Servicios");
            dtPreview.Rows.Add(0, $"{TAB}TODOS");
            foreach (DataRow row in dtServicios.Rows)
            {
                serviciosSeleccionados.Add(Convert.ToInt32(row["id"]));
                serviciosDictionary.Add(Convert.ToInt32(row["id"]), row["descripcion"].ToString());
            }
            serviciosMax = serviciosSeleccionados.Count;
        }

        private void LimpiarVariables()
        {
            estadosDictionary.Clear();
            serviciosDictionary.Clear();
            zonasDictionary.Clear();
            localidadesDictionary.Clear();
            operacionesDictionary.Clear();
            areaPersonalDictionary.Clear();
            personalDictionary.Clear();

            estadosSeleccionados.Clear();
            zonasSeleccionadas.Clear();
            localidadesSeleccionadas.Clear();
            operacionesSeleccionadas.Clear();
            areaPersonalSeleccionadas.Clear();
            personalSeleccionado.Clear();
            serviciosSeleccionados.Clear();
        }

        public void ReCargarDataTable(string textoBuscador = "")
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dt = oPartesInformes.Listar_historial(estadosSeleccionados,
                    zonasSeleccionadas, localidadesSeleccionadas,
                    operacionesSeleccionadas, dtpDesde.Value, dtpHasta.Value, SeleccionTipoFecha(),
                    areaPersonalSeleccionadas, personalSeleccionado,
                    serviciosSeleccionados);

                //Se vuelve a mandar el datatable actualizado
                imgVolver.Enabled = true;
                frmVistaHistorial.BorrarInstancia();
                frmVistaHistorial oVista = frmVistaHistorial.Instancia(this);
                oVista.CargarDataTableVista(dt);
                oVista.CargarBuscadorVista(textoBuscador);
                frmMain fm = frmMain.Instance();
                fm.openForm(oVista);
            }
            catch (Exception ex) { throw ex; }
            finally { this.Cursor = Cursors.Default; }
        }

        private void EstablecerDateTimePicker()
        {
            DateTime fechaHoy = DateTime.Now;
            dtpDesde.Value = new DateTime(fechaHoy.Year, fechaHoy.Month, 1);
            dtpHasta.Value = DateTime.Now;
        }

        private int SeleccionTipoFecha()
        {
            if (radioButton1.Checked) return 0;
            else if (radioButton2.Checked) return 1;
            else return 3;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ReCargarDataTable();
        }

        private void imgVolver_Click(object sender, EventArgs e)
        {
            frmVistaHistorial oVista = frmVistaHistorial.Instancia(this);
            frmMain fm = frmMain.Instance();
            fm.openForm(oVista);
        }

        private void CargarDataGridView()
        {
            dtPreview.Clear();
            dtPreview.Rows.Add(1, "Servicios");
            if (serviciosSeleccionados.Count == serviciosMax)
            {
                dtPreview.Rows.Add(0, $"{TAB}TODOS");
            }
            else
            {
                foreach (int id in serviciosSeleccionados)
                {
                    dtPreview.Rows.Add(0, $"{TAB}{serviciosDictionary[id]}");
                }
            }

            dtPreview.Rows.Add(1, "Areas personal");
            if (areaPersonalSeleccionadas.Count == areaPersonalMax)
            {
                dtPreview.Rows.Add(0, $"{TAB}TODOS");
            }
            else
            {
                foreach (int id in areaPersonalSeleccionadas)
                {
                    dtPreview.Rows.Add(0, $"{TAB}{areaPersonalDictionary[id]}");
                }
            }

            dtPreview.Rows.Add(1, "Personal");
            if (personalSeleccionado.Count == personalMax)
            {
                dtPreview.Rows.Add(0, $"{TAB}TODOS");
            }
            else
            {
                foreach (int id in personalSeleccionado)
                {
                    dtPreview.Rows.Add(0, $"{TAB}{personalDictionary[id]}");
                }
            }

            dtPreview.Rows.Add(1, "Estados");
            if (estadosSeleccionados.Count == estadosMax)
            {
                dtPreview.Rows.Add(0, $"{TAB}TODOS");
            }
            else
            {
                foreach (int id in estadosSeleccionados)
                {
                    dtPreview.Rows.Add(0, $"{TAB}{estadosDictionary[id]}");
                }
            }

            dtPreview.Rows.Add(1, "Zonas");
            if (zonasSeleccionadas.Count == zonasMax)
            {
                dtPreview.Rows.Add(0, $"{TAB}TODOS");
            }
            else
            {
                foreach (int id in zonasSeleccionadas)
                {
                    dtPreview.Rows.Add(0, $"{TAB}{zonasDictionary[id]}");
                }
            }

            dtPreview.Rows.Add(1, "Localidades");
            if (localidadesSeleccionadas.Count == localidadesMax)
            {
                dtPreview.Rows.Add(0, $"{TAB}TODOS");
            }
            else
            {
                foreach (int id in localidadesSeleccionadas)
                {
                    dtPreview.Rows.Add(0, $"{TAB}{localidadesDictionary[id]}");
                }
            }

            dtPreview.Rows.Add(1, "Operaciones");
            if (operacionesSeleccionadas.Count == operacionesMax)
            {
                dtPreview.Rows.Add(0, $"{TAB}TODOS");
            }
            else
            {
                foreach (int id in operacionesSeleccionadas)
                {
                    dtPreview.Rows.Add(0, $"{TAB}{operacionesDictionary[id]}");
                }
            }

            PintarDataGridView();
        }

        private void SeleccionarEstados()
        {
            using (frmPopUp popUp = new frmPopUp())
            {
                frmSeleccionValores frmSelec = new frmSeleccionValores("Partes estados", dtEstados, "Id", "Nombre");
                frmSelec.valoresSeleccionados = estadosSeleccionados;
                frmSelec.SeleccionarAlMenosUno = true;
                popUp.Formulario = frmSelec;
                popUp.Maximizar = false;
                if (popUp.ShowDialog() == DialogResult.OK)
                {
                    estadosSeleccionados = frmSelec.valoresSeleccionados;
                    CargarDataGridView();
                }
            }
        }

        private void SeleccionarZonas()
        {
            using (frmPopUp popUp = new frmPopUp())
            {
                frmSeleccionValores frmSelec = new frmSeleccionValores("Zonas", dtZonas, "Id", "Nombre");
                frmSelec.valoresSeleccionados = zonasSeleccionadas;
                frmSelec.SeleccionarAlMenosUno = true;
                popUp.Formulario = frmSelec;
                popUp.Maximizar = false;
                if (popUp.ShowDialog() == DialogResult.OK)
                {
                    zonasSeleccionadas = frmSelec.valoresSeleccionados;
                    CargarDataGridView();
                }
            }
        }

        private void SeleccionarLocalidades()
        {
            using (frmPopUp popUp = new frmPopUp())
            {
                frmSeleccionValores frmSelec = new frmSeleccionValores("Localidades", dtLocalidades, "Id", "Nombre");
                frmSelec.valoresSeleccionados = localidadesSeleccionadas;
                frmSelec.SeleccionarAlMenosUno = true;
                popUp.Formulario = frmSelec;
                popUp.Maximizar = false;
                if (popUp.ShowDialog() == DialogResult.OK)
                {
                    localidadesSeleccionadas = frmSelec.valoresSeleccionados;
                    CargarDataGridView();
                }
            }
        }

        private void SeleccionarOperaciones()
        {
            using (frmPopUp popUp = new frmPopUp())
            {
                frmSeleccionValores frmSelec = new frmSeleccionValores("Operaciones", dtPartesOperaciones, "Id", "Nombre");
                frmSelec.valoresSeleccionados = operacionesSeleccionadas;
                frmSelec.SeleccionarAlMenosUno = true;
                popUp.Formulario = frmSelec;
                popUp.Maximizar = false;
                if (popUp.ShowDialog() == DialogResult.OK)
                {
                    operacionesSeleccionadas = frmSelec.valoresSeleccionados;
                    CargarDataGridView();
                }
            }
        }

        private void SeleccionarAreaPersonal()
        {
            using (frmPopUp popUp = new frmPopUp())
            {
                frmSeleccionValores frmSelec = new frmSeleccionValores("Areas de personal", dtAreasPersonal, "Id", "Nombre");
                frmSelec.valoresSeleccionados = areaPersonalSeleccionadas;
                frmSelec.SeleccionarAlMenosUno = true;
                popUp.Formulario = frmSelec;
                popUp.Maximizar = false;
                if (popUp.ShowDialog() == DialogResult.OK)
                {
                    areaPersonalSeleccionadas = frmSelec.valoresSeleccionados;
                    CargarDataGridView();
                }
            }
        }

        private void SeleccionarPersonal()
        {
            using (frmPopUp popUp = new frmPopUp())
            {
                frmSeleccionValores frmSelec = new frmSeleccionValores("Personal", dtPersonal, "id", "nombre");
                frmSelec.valoresSeleccionados = personalSeleccionado;
                frmSelec.SeleccionarAlMenosUno = true;
                popUp.Formulario = frmSelec;
                popUp.Maximizar = false;
                if (popUp.ShowDialog() == DialogResult.OK)
                {
                    personalSeleccionado = frmSelec.valoresSeleccionados;
                    CargarDataGridView();
                }
            }
        }

        private void SeleccionarServicios()
        {
            using (frmPopUp popUp = new frmPopUp())
            {
                frmSeleccionValores frmSelec = new frmSeleccionValores("Servicios", dtServicios, "Id", "Descripcion");
                frmSelec.valoresSeleccionados = serviciosSeleccionados;
                frmSelec.SeleccionarAlMenosUno = true;
                popUp.Formulario = frmSelec;
                popUp.Maximizar = false;
                if (popUp.ShowDialog() == DialogResult.OK)
                {
                    serviciosSeleccionados = frmSelec.valoresSeleccionados;
                    CargarDataGridView();
                }
            }
        }

        private void btnSelecEstados_Click(object sender, EventArgs e)
        {
            SeleccionarEstados();
        }

        private void btnSelecZonas_Click(object sender, EventArgs e)
        {
            SeleccionarZonas();
        }

        private void btnSelecLocalidad_Click(object sender, EventArgs e)
        {
            SeleccionarLocalidades();
        }

        private void btnSelecOperacion_Click(object sender, EventArgs e)
        {
            SeleccionarOperaciones();
        }

        private void btnSelecAreaPersonal_Click(object sender, EventArgs e)
        {
            SeleccionarAreaPersonal();
        }

        private void btnSelecPersonal_Click(object sender, EventArgs e)
        {
            SeleccionarPersonal();
        }

        private void btnSelecServicios_Click(object sender, EventArgs e)
        {
            SeleccionarServicios();
        }
        
        private void PintarDataGridView()
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (Convert.ToInt32(row.Cells["tipo"].Value) == 1)
                {
                    row.DefaultCellStyle.BackColor = Color.LightGray;
                    row.DefaultCellStyle.Font = new Font(row.DefaultCellStyle.Font.FontFamily, row.DefaultCellStyle.Font.Size + 1f, FontStyle.Bold);
                }
            }
        }

        private void frmConsultaHistorial_Shown(object sender, EventArgs e)
        {
            PintarDataGridView();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmConsultaHistorial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
