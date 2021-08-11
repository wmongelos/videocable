using CapaNegocios;
using System;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Abms
{
    public partial class ABMTarifas_Editor_Serv : Form
    {
        public Int32 idTarifa, idTipo;
        public String nombreTarifa;
        private Thread hilo;
        private delegate void myDel();
        private Boolean aumentoTipoServicio;
        private Configuracion oConfiguracion = new Configuracion();
        private DataTable dtZonasCategorias = new DataTable();
        private DataTable dtServicios = new DataTable();
        private Servicios oServicios = new Servicios();
        private Servicios_Categorias oServiciosCategorias = new Servicios_Categorias();
        private Zonas oServiciosZonas = new Zonas();
        private frmPopUp oPop;
        private ABMTarifas_Editor oFrmTarifasServicios;
        private Int32 idServicio, idTipoServicio, idFormaFacturacion, requiereVelocidad, idModalidad, idZonaCategoria;
        private DataTable dtServiciosAgrupados = new DataTable();
        private Servicios_Tipos oServiciosTipos = new Servicios_Tipos();
        private String nombreServicio, nombreTipoServicio;


        private void comenzarCarga()
        {
            pgCircular.Start();
            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
        }

        private void cargarDatos()
        {
            try
            {
                idFormaFacturacion = Convert.ToInt32(oConfiguracion.GetValor_Decimal("Id_Tipo_Facturacion"));
                if (idFormaFacturacion == 1)
                    dtZonasCategorias = oServiciosZonas.Listar();
                else
                    dtZonasCategorias = oServiciosCategorias.Listar();
                if (dtZonasCategorias.Rows.Count == 0)
                    MessageBox.Show("No hay cargada ninguna zona o categoria aún", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    myDel MD = new myDel(asignarDatos);
                    this.Invoke(MD, new object[] { });
                    pgCircular.Stop();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Informacion" + ex.Message);
            }
        }

        private void asignarDatos()
        {
            try
            {

                lblTarifaNuevaDato.Text = nombreTarifa;
                dtServiciosAgrupados.Columns.Add("idGrupo1", typeof(Int32));
                dtServiciosAgrupados.Columns.Add("idServicio1", typeof(Int32));
                dtServiciosAgrupados.Columns.Add("descripcion1", typeof(String));
                dtServiciosAgrupados.Columns.Add("tipo1", typeof(String));
                dtServiciosAgrupados.Columns.Add("modalidad1", typeof(String));
                dtServiciosAgrupados.Columns.Add("requiereEquipo1", typeof(String));
                dtServiciosAgrupados.Columns.Add("requiereVelocidad1", typeof(String));
                dtServiciosAgrupados.Columns.Add("requiereTarjeta1", typeof(String));
                dtServiciosAgrupados.Columns.Add("idServiciosTipos1", typeof(Int32));
                dtServiciosAgrupados.Columns.Add("idServiciosModalidad1", typeof(Int32));
                dtServiciosAgrupados.Columns.Add("idServiciosGrupos1", typeof(Int32));
                dtServiciosAgrupados.Columns.Add("idTipoFacturacion1", typeof(Int32));
                dtServiciosAgrupados.Columns.Add("grupo1", typeof(String));
                dtServiciosAgrupados.Columns.Add("diasBonificacion1", typeof(Int32));
                dtServiciosAgrupados.Columns.Add("fechaInicioServicio1", typeof(Int32));
                dtServiciosAgrupados.Columns.Add("requiereServicioPadre1", typeof(Int32));
            }
            catch (Exception)
            {

                throw;
            }
            dgvZonasCategorias.DataSource = null;
            dgvZonasCategorias.DataSource = dtZonasCategorias;
            if (dtZonasCategorias.Rows.Count > 0)
            {
                if (idFormaFacturacion == 1)
                {
                    dgvZonasCategorias.Columns["nombre"].HeaderText = "Zonas";

                }
                else
                    dgvZonasCategorias.Columns["nombre"].HeaderText = "Categorias";

                dgvZonasCategorias.Columns["id"].Visible = false;
                dgvZonasCategorias.Columns["borrado"].Visible = false;
                dgvZonasCategorias.Rows[0].Selected = true;
                foreach (DataGridViewRow item in dgvZonasCategorias.Rows)
                    item.Height = 28;
                asignarValores();
            }

        }

        public ABMTarifas_Editor_Serv()
        {
            InitializeComponent();
        }
        private void asignarValores()
        {

            dtServiciosAgrupados.Clear();
            dgvServicios.DataSource = null;
            if (dgvZonasCategorias.SelectedRows.Count > 0)
                idZonaCategoria = Convert.ToInt32(dgvZonasCategorias.SelectedRows[0].Cells["id"].Value);
            dtServicios = oServicios.ListarPorTipoFacturacion(idZonaCategoria);
            DataTable dtTiposServicios = oServiciosTipos.Listar();
            foreach (DataRow item in dtTiposServicios.Rows)
            {
                DataRow drTipo = dtServiciosAgrupados.NewRow();
                drTipo["descripcion1"] = item["Nombre"].ToString();
                drTipo["idGrupo1"] = -1;
                drTipo["idServiciosTipos1"] = Convert.ToInt32(item["id"]);
                drTipo["Tipo1"] = item["nombre"].ToString();


                int idTipo = Convert.ToInt32(item["id"]);
                DataRow[] drServicios = dtServicios.Select(string.Format("id_servicios_tipos={0}", idTipo));
                if (drServicios.Length > 0)
                {
                    dtServiciosAgrupados.Rows.Add(drTipo);
                    foreach (DataRow item2 in drServicios)
                    {
                        DataRow dr = dtServiciosAgrupados.NewRow();
                        dr["idGrupo1"] = Convert.ToInt32(item2["id_servicios_grupos"]);
                        dr["idServicio1"] = Convert.ToInt32(item2["id_servicios"]);
                        dr["descripcion1"] = item2["descripcion"].ToString();
                        dr["tipo1"] = item2["Tipo"].ToString();
                        dr["modalidad1"] = item2["modalidad"].ToString();
                        dr["requiereEquipo1"] = item2["requiere_equipo"].ToString();
                        dr["requiereVelocidad1"] = item2["requiere_velocidad"].ToString();
                        dr["requiereTarjeta1"] = item2["requiere_tarjeta"].ToString();
                        dr["idServiciosTipos1"] = Convert.ToInt32(item2["id_servicios_tipos"]);
                        dr["idServiciosModalidad1"] = Convert.ToInt32(item2["id_servicios_modalidad"]);
                        dr["idServiciosGrupos1"] = Convert.ToInt32(item2["id_servicios_grupos"]);
                        dr["idTipoFacturacion1"] = Convert.ToInt32(item2["id_tipo_facturacion"]);
                        dr["grupo1"] = item2["Grupo"].ToString();
                        dr["diasBonificacion1"] = Convert.ToInt32(item2["dias_bonificacion"]);
                        dr["fechaInicioServicio1"] = Convert.ToInt32(item2["fecha_inicio_servicio"]);
                        dr["requiereServicioPadre1"] = Convert.ToInt32(item2["requiere_servicio_padre"]);
                        dtServiciosAgrupados.Rows.Add(dr);
                    }
                    drServicios = null;
                }
            }
            if (dtServicios.Rows.Count > 0)
            {
                dgvServicios.DataSource = dtServiciosAgrupados;
                FormatearGrillaServicios();
            }

        }
        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormatearGrillaServicios()
        {
            foreach (DataGridViewColumn item in dgvServicios.Columns)
                item.Visible = false;

            dgvServicios.Columns["descripcion1"].Visible = true;
            dgvServicios.Columns["descripcion1"].HeaderText = "Servicios";

            foreach (DataGridViewRow item in dgvServicios.Rows)
            {
                Int32 idGrupo = Convert.ToInt32(item.Cells["idGRupo1"].Value);
                if (idGrupo == -1)
                {
                    item.DefaultCellStyle.BackColor = Color.FromArgb(15, 76, 100);
                    item.DefaultCellStyle.ForeColor = Color.White;
                    item.Height = 36;

                }
                else
                {
                    String descripcion = item.Cells["descripcion1"].Value.ToString();
                    item.Cells["descripcion1"].Value = "\t" + descripcion;
                    item.DefaultCellStyle.BackColor = Color.FromArgb(200, 220, 255);
                    item.DefaultCellStyle.ForeColor = Color.Black;
                    item.Height = 28;


                }
            }
        }


        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmTarifasListado_Load(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void dgvZonasCategorias_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                asignarValores();
            }
            catch (Exception)
            {
            }
        }

        private void ABMTarifas_Editor_Serv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (hilo.ThreadState != ThreadState.Running)
                    this.Close();
            }
        }

        private void dgvZonasCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                asignarValores();
            }
            catch (Exception)
            {
            }

        }

        private void btnActualizar_Click_1(object sender, EventArgs e)
        {
            AbrirEditorTarifas();
        }

        private void dgvServicios_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                AbrirEditorTarifas();
        }

        private void dgvServicios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvServicios.SelectedRows.Count > 0)
                {
                    idServicio = Convert.ToInt32(dgvServicios.SelectedRows[0].Cells["id"].Value);
                    idTipo = Convert.ToInt32(dgvServicios.SelectedRows[0].Cells["idServiciosTipos1"].Value);
                    nombreTipoServicio = dgvServicios.SelectedRows[0].Cells["Tipo1"].Value.ToString();
                }

            }
            catch (Exception)
            {

            }
        }

        private void dgvServicios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AbrirEditorTarifas();
        }
        private void AbrirEditorTarifas()
        {
            if (dgvServicios.SelectedRows.Count > 0)
            {
                Int32 idSeleccionado = Convert.ToInt32(dgvServicios.SelectedRows[0].Cells["idGrupo1"].Value);
                if (idSeleccionado != -1)
                {

                    idServicio = Convert.ToInt32(dgvServicios.SelectedRows[0].Cells["idServicio1"].Value);
                    idTipoServicio = Convert.ToInt32(dgvServicios.SelectedRows[0].Cells["idServiciosTipos1"].Value);
                    nombreServicio = dgvServicios.SelectedRows[0].Cells["descripcion1"].Value.ToString();
                    nombreTipoServicio = dgvServicios.SelectedRows[0].Cells["tipo1"].Value.ToString();
                    String reqiereVelocidadString = dgvServicios.SelectedRows[0].Cells["requiereVelocidad1"].Value.ToString();
                    if (reqiereVelocidadString == "SI")
                        requiereVelocidad = 1;
                    if (reqiereVelocidadString == "NO")
                        requiereVelocidad = 0;
                    idModalidad = Convert.ToInt32(dgvServicios.SelectedRows[0].Cells["idServiciosModalidad1"].Value);
                    oPop = new frmPopUp();
                    oFrmTarifasServicios = new ABMTarifas_Editor();
                    oFrmTarifasServicios.idServicio = this.idServicio;
                    oFrmTarifasServicios.idTipoServicio = this.idTipoServicio;
                    oFrmTarifasServicios.idTipoFacturacion = this.idZonaCategoria;
                    oFrmTarifasServicios.requiereVelocidad = this.requiereVelocidad;
                    oFrmTarifasServicios.idModalidad = this.idModalidad;
                    oFrmTarifasServicios.nombreServicio = this.nombreServicio;
                    oFrmTarifasServicios.velocidad = false;
                    oFrmTarifasServicios.especial = false;
                    oFrmTarifasServicios.idTarifa = this.idTarifa; ;
                    oFrmTarifasServicios.nombreTipoServicio = this.nombreTipoServicio;
                    oFrmTarifasServicios.aumentoTipoServicio = false;
                    oPop.Formulario = oFrmTarifasServicios;
                    oPop.Maximizar = false;
                    if (oPop.ShowDialog() == DialogResult.OK)
                        comenzarCarga();
                }
                else
                {
                    idTipoServicio = Convert.ToInt32(dgvServicios.SelectedRows[0].Cells["idServiciosTipos1"].Value);
                    nombreServicio = dgvServicios.SelectedRows[0].Cells["descripcion1"].Value.ToString();
                    nombreTipoServicio = dgvServicios.SelectedRows[0].Cells["tipo1"].Value.ToString();

                    idModalidad = 0;
                    oPop = new frmPopUp();
                    oFrmTarifasServicios = new ABMTarifas_Editor();
                    oFrmTarifasServicios.idServicio = 0;
                    oFrmTarifasServicios.idTipoServicio = this.idTipoServicio;
                    oFrmTarifasServicios.idTipoFacturacion = this.idZonaCategoria;
                    oFrmTarifasServicios.requiereVelocidad = 0;
                    oFrmTarifasServicios.idModalidad = 0;
                    oFrmTarifasServicios.nombreServicio = "";
                    oFrmTarifasServicios.velocidad = false;
                    oFrmTarifasServicios.especial = false;
                    oFrmTarifasServicios.idTarifa = this.idTarifa;
                    oFrmTarifasServicios.nombreTipoServicio = this.nombreTipoServicio;
                    oFrmTarifasServicios.aumentoTipoServicio = true;
                    oPop.Formulario = oFrmTarifasServicios;
                    oPop.Maximizar = false;
                    if (oPop.ShowDialog() == DialogResult.OK)
                        comenzarCarga();
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            AbrirEditorTarifas();
        }
    }
}
