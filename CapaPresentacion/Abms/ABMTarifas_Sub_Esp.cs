using CapaNegocios;
using System;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Abms
{
    public partial class ABMTarifas_Sub_Esp : Form
    {
        public Int32 Id_Tarifas;
        public Int32 Id_Tipo_Facturacion;
        public Int32 Id_Servicios;
        public Int32 Id_Servicios_Sub;
        public Int32 Id_Grupo_Servicio;
        public Int32 OrigenMeses;
        public Servicios._Modalidad Servicio_Modalidad;
        public Boolean Requiere_Velocidades;
        public Boolean Requiere_Servicio_Padre;
        public Boolean Fecha_Inicio_Servicio;
        public Decimal ImporteDiario;

        public String Servicio
        {
            get { return lblServicio.Text; }
            set { lblServicio.Text = String.Format("Servicio: {0}", value); }
        }

        public String SubServicio
        {
            get { return lblSubServicio.Text; }
            set { lblSubServicio.Text = String.Format("Subservicio seleccionado: {0}", value); }
        }

        Boolean agregarEnGrilla;

        private Tipo_Facturacion oTipoFacturacion = new Tipo_Facturacion();
        private Servicios_Velocidades oServicios_Velocidades = new Servicios_Velocidades();
        private Servicios_Tarifas_Sub_Esp oServicios_Tarifas_Sub_Esp = new Servicios_Tarifas_Sub_Esp();

        private DataTable dtServiciosPadre;
        private DataTable dtServicios_Velocidades;
        private DataTable dtServicios_Velocidades_Tipos;
        private DataTable dtServicios_Tarifas_Especiales;

        private Thread hilo;
        private delegate void myDel();

        public ABMTarifas_Sub_Esp()
        {
            InitializeComponent();
        }

        private void ComenzarCarga()
        {
            dgv.Columns.Clear();
            dgv.DataSource = null;

            hilo = new Thread(new ThreadStart(CargarDatos));
            hilo.Start();
        }

        private void CargarDatos()
        {
            dtServiciosPadre = oTipoFacturacion.GetServiciosPorTipo(this.Id_Tipo_Facturacion);
            dtServicios_Velocidades = oServicios_Velocidades.ListarVelocidades();
            dtServicios_Velocidades_Tipos = oServicios_Velocidades.ListarVelocidadesTipos();
            dtServicios_Tarifas_Especiales = oServicios_Tarifas_Sub_Esp.GetServicios_Tarifas_Sub_Esp(this.Id_Tarifas, this.Id_Servicios, this.Id_Servicios_Sub, this.Id_Tipo_Facturacion);
            myDel MD = new myDel(AsignarDatos);

            this.Invoke(MD, new object[] { });
        }

        private void AsignarDatos()
        {
            dgv.DataSource = dtServicios_Tarifas_Especiales;
            DataView dtvServiciosPadre = new DataView(dtServiciosPadre);
            dtvServiciosPadre.RowFilter = String.Format("id_servicios<>{0} and id_grupo={1}", Id_Servicios, Id_Grupo_Servicio);

            cboPeriodosServicios_Padres.DataSource = dtvServiciosPadre.ToTable();
            cboPeriodosServicios_Padres.ValueMember = "Id_Servicios";
            cboPeriodosServicios_Padres.DisplayMember = "Servicios";
            //cboPeriodosServicios_Padres.SelectedItem = Id_Servicios;

            cboPeriodosVelocidades.DataSource = dtServicios_Velocidades;
            cboPeriodosVelocidades.ValueMember = "Id";
            cboPeriodosVelocidades.DisplayMember = "Velocidad";

            cboMensualVelocidades.DataSource = dtServicios_Velocidades;
            cboMensualVelocidades.ValueMember = "Id";
            cboMensualVelocidades.DisplayMember = "Velocidad";

            cboDiariosVelocidades.DataSource = dtServicios_Velocidades;
            cboDiariosVelocidades.ValueMember = "Id";
            cboDiariosVelocidades.DisplayMember = "Velocidad";

            cboPeriodosDiariosVelocidad.DataSource = dtServicios_Velocidades;
            cboPeriodosDiariosVelocidad.ValueMember = "Id";
            cboPeriodosDiariosVelocidad.DisplayMember = "Velocidad";

            cboPeriodosVelocidades_Tipos.DataSource = dtServicios_Velocidades_Tipos;
            cboPeriodosVelocidades_Tipos.ValueMember = "Id";
            cboPeriodosVelocidades_Tipos.DisplayMember = "Nombre";

            cboMensualVelocidades_Tipos.DataSource = dtServicios_Velocidades_Tipos;
            cboMensualVelocidades_Tipos.ValueMember = "Id";
            cboMensualVelocidades_Tipos.DisplayMember = "Nombre";

            cboPeriodosDiariosVelocidadTip.DataSource = dtServicios_Velocidades_Tipos;
            cboPeriodosDiariosVelocidadTip.ValueMember = "Id";
            cboPeriodosDiariosVelocidadTip.DisplayMember = "Nombre";

            cboDiariosVelocidades_Tip.DataSource = dtServicios_Velocidades_Tipos;
            cboDiariosVelocidades_Tip.ValueMember = "Id";
            cboDiariosVelocidades_Tip.DisplayMember = "Nombre";

            //*************configuro las velocidaddes y tipos de velocidades para servicios con modalidad por periodo cerrado
            cboPeriodosCerradoVelocidades.DataSource = dtServicios_Velocidades;
            cboPeriodosCerradoVelocidades.ValueMember = "Id";
            cboPeriodosCerradoVelocidades.DisplayMember = "Velocidad";

            cboPeriodosCerradoVelocidades_Tipos.DataSource = dtServicios_Velocidades_Tipos;
            cboPeriodosCerradoVelocidades_Tipos.ValueMember = "Id";
            cboPeriodosCerradoVelocidades_Tipos.DisplayMember = "Nombre";


            cboPeriodos_Mes_Inicio_Fact.SelectedIndex = 0;
            cboPeriodos_Mes_Inicio_Serv.SelectedIndex = 0;
            cboPeriodos_Mes_Fin_Serv.SelectedIndex = 0;
            dgv.ReadOnly = false;
            for (int i = 0; i < dgv.ColumnCount; i++)
            {
                dgv.Columns[i].Visible = false;
                if (dgv.Columns[i].Name == "importe")
                    dgv.Columns[i].ReadOnly = false;
                else
                    dgv.Columns[i].ReadOnly = true;


            }

            dgv.Columns["velocidad"].HeaderText = "Velocidad";
            dgv.Columns["velocidad_tip"].HeaderText = "Tipo";
            dgv.Columns["importe"].HeaderText = "Importe";
            dgv.Columns["Mes_Facturacion"].HeaderText = "Mes Inicio Fac.";
            dgv.Columns["Mes_Inicio"].HeaderText = "Mes Inicio Serv.";
            dgv.Columns["Mes_Fin"].HeaderText = "Mes Fin Serv.";
            dgv.Columns["Meses_cobro"].HeaderText = "Meses Cobro";
            dgv.Columns["Meses_servicio"].HeaderText = "Meses Serv.";
            dgv.Columns["dias_desde"].HeaderText = "Desde";
            dgv.Columns["dias_hasta"].HeaderText = "Hasta";
            dgv.Columns["porcentaje"].HeaderText = "Porcentaje";

            dgv.Columns["Importe"].DefaultCellStyle.Format = "C2";

            dgv.Columns["Mes_Facturacion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["Mes_Inicio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["Mes_Fin"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["Meses_cobro"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["Meses_servicio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["Importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["porcentaje"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["dias_desde"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["dias_hasta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DataGridViewLinkColumn col = new DataGridViewLinkColumn();
            dgv.Columns.Add(col);
            col.Text = "Eliminar";
            col.DataPropertyName = "Eliminar";
            col.Name = "Acción";
            col.LinkColor = Color.Blue;
            col.VisitedLinkColor = Color.Blue;
            col.UseColumnTextForLinkValue = true;
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            col.Width = 100;

            switch (this.Servicio_Modalidad)
            {
                case Servicios._Modalidad.DIA:
                    tabModalidades.TabPages.Add(tabPageDiarios);

                    if (this.Requiere_Velocidades)
                    {
                        dgv.Columns["Velocidad"].Visible = true;
                        dgv.Columns["Velocidad_Tip"].Visible = true;
                    }

                    spDiariosImporteDiario.Value = this.ImporteDiario;

                    cboDiariosVelocidades.Enabled = this.Requiere_Velocidades;
                    cboDiariosVelocidades_Tip.Enabled = this.Requiere_Velocidades;

                    dgv.Columns["dias_desde"].Visible = true;
                    dgv.Columns["dias_hasta"].Visible = true;
                    dgv.Columns["porcentaje"].Visible = true;
                    dgv.Columns["importe"].Visible = true;

                    break;
                case Servicios._Modalidad.MENSUAL:
                    dgv.Columns["Velocidad"].Visible = true;
                    dgv.Columns["Velocidad_Tip"].Visible = true;
                    dgv.Columns["Importe"].Visible = true;

                    tabModalidades.TabPages.Add(tabPageMensual);
                    break;
                case Servicios._Modalidad.PERIODO:
                    tabModalidades.TabPages.Add(tabPagePeriodos);

                    cboPeriodosVelocidades.Enabled = this.Requiere_Velocidades;
                    cboPeriodosVelocidades_Tipos.Enabled = this.Requiere_Velocidades;

                    cboPeriodosServicios_Padres.Enabled = this.Requiere_Servicio_Padre;

                    if (this.Requiere_Velocidades == true || this.Requiere_Servicio_Padre == false)
                        spPeriodosImporte.Enabled = true;
                    else
                        spPeriodosImporte.Enabled = false;

                    cboPeriodos_Mes_Inicio_Fact.Enabled = !this.Fecha_Inicio_Servicio;
                    cboPeriodos_Mes_Inicio_Serv.Enabled = !this.Fecha_Inicio_Servicio;
                    cboPeriodos_Mes_Fin_Serv.Enabled = !this.Fecha_Inicio_Servicio;


                    dgv.Columns["Mes_Facturacion"].Visible = !this.Fecha_Inicio_Servicio;
                    dgv.Columns["Mes_Inicio"].Visible = !this.Fecha_Inicio_Servicio;
                    dgv.Columns["Mes_Fin"].Visible = !this.Fecha_Inicio_Servicio;


                    dgv.Columns["Velocidad"].Visible = this.Requiere_Velocidades;
                    dgv.Columns["Velocidad_Tip"].Visible = this.Requiere_Velocidades;
                    dgv.Columns["Importe"].Visible = this.Requiere_Velocidades == true || this.Requiere_Servicio_Padre == false;

                    dgv.Columns["Meses_cobro"].Visible = true;
                    dgv.Columns["Meses_servicio"].Visible = true;


                    break;
                case Servicios._Modalidad.UNICO:
                    break;
                case Servicios._Modalidad.PERIODO_CERRADO_POR_MES:
                    tabModalidades.TabPages.Add(tabPagePeriodosCerrados);

                    if (this.Requiere_Velocidades == true || this.Requiere_Servicio_Padre == false)
                        spPeriodosImporte.Enabled = true;
                    else
                        spPeriodosImporte.Enabled = false;


                    dgv.Columns["Mes_Facturacion"].Visible = false;
                    dgv.Columns["Fecha_desde"].Visible = true;
                    dgv.Columns["Fecha_desde"].DisplayIndex = 0;

                    dgv.Columns["Fecha_hasta"].Visible = true;
                    dgv.Columns["Fecha_hasta"].DisplayIndex = 1;

                    dgv.Columns["Velocidad"].Visible = this.Requiere_Velocidades;
                    dgv.Columns["Velocidad"].DisplayIndex = 2;

                    dgv.Columns["Velocidad_Tip"].Visible = this.Requiere_Velocidades;
                    dgv.Columns["Velocidad_Tip"].DisplayIndex = 3;
                    dgv.Columns["Importe"].Visible = this.Requiere_Velocidades == true || this.Requiere_Servicio_Padre == false;
                    dgv.Columns["Meses_cobro"].Visible = false;
                    dgv.Columns["Meses_servicio"].Visible = false;
                    dgv.Columns["Mes_Fin"].Visible = false;
                    dgv.Columns["Mes_Inicio"].Visible = false;
                    cboPeriodosCerradoVelocidades.Enabled = this.Requiere_Velocidades;
                    cboPeriodosCerradoVelocidades_Tipos.Enabled = this.Requiere_Velocidades;

                    break;
                case Servicios._Modalidad.PERIODO_CERRADO_POR_DIA:
                    tabModalidades.TabPages.Add(tabPagePeriodosDiarios);

                    cboPeriodosDiariosVelocidad.Enabled = this.Requiere_Velocidades;
                    cboPeriodosDiariosVelocidadTip.Enabled = this.Requiere_Velocidades;

                    dgv.Columns["Velocidad"].Visible = this.Requiere_Velocidades;
                    dgv.Columns["Velocidad_Tip"].Visible = this.Requiere_Velocidades;

                    dgv.Columns["dias_desde"].Visible = true;
                    dgv.Columns["dias_desde"].HeaderText = "Cantidad de Dias";

                    dgv.Columns["Importe"].Visible = true;

                    break;
                default:
                    break;
            }
            if ((Servicio_Modalidad == Servicios._Modalidad.PERIODO) && (Requiere_Velocidades == false))
            {
                if (dtServicios_Tarifas_Especiales.Rows.Count > 0)
                    btnAgregar.Enabled = false;
            }


        }

        private void AgregarEspeciales()
        {
            DataRow dr = dtServicios_Tarifas_Especiales.NewRow();
            agregarEnGrilla = true;
            dr["id_servicios_tarifas"] = this.Id_Tarifas;
            dr["id_servicios"] = this.Id_Servicios;
            dr["id_servicios_sub"] = this.Id_Servicios_Sub;
            dr["id_tipo_facturacion"] = this.Id_Tipo_Facturacion;
            dr["id"] = 0;

            switch (this.Servicio_Modalidad)
            {
                case Servicios._Modalidad.DIA:
                    if (this.Requiere_Velocidades)
                    {
                        dr["Velocidad"] = cboDiariosVelocidades.Text;
                        dr["Velocidad_Tip"] = cboDiariosVelocidades_Tip.Text;
                        dr["id_servicios_velocidad"] = Convert.ToInt32(cboDiariosVelocidades.SelectedValue);
                        dr["id_servicios_velocidad_tip"] = Convert.ToInt32(cboDiariosVelocidades_Tip.SelectedValue);
                    }

                    dr["dias_desde"] = spDiariosDiasDesde.Value;
                    dr["dias_hasta"] = spDiariosDiasHasta.Value;
                    dr["porcentaje"] = spDiariosPorcentaje.Value;
                    dr["importe"] = spDiariosImporteFinal.Value;
                    dr["origenmeses"] = this.OrigenMeses;

                    break;
                case Servicios._Modalidad.MENSUAL:
                    if (dtServicios_Tarifas_Especiales.Select(String.Format("id_servicios_velocidad={0} and id_servicios_velocidad_tip={1}", Convert.ToInt32(cboMensualVelocidades.SelectedValue), Convert.ToInt32(cboMensualVelocidades_Tipos.SelectedValue))).Length == 0)
                    {
                        dr["Velocidad"] = cboMensualVelocidades.Text;
                        dr["Velocidad_Tip"] = cboMensualVelocidades_Tipos.Text;
                        dr["Importe"] = spMensualImporte.Value;
                        dr["id_servicios_velocidad"] = Convert.ToInt32(cboMensualVelocidades.SelectedValue);
                        dr["id_servicios_velocidad_tip"] = Convert.ToInt32(cboMensualVelocidades_Tipos.SelectedValue);

                        dr["origenmeses"] = this.OrigenMeses;
                        dr["meses_cobro"] = 1;
                        dr["meses_servicio"] = 1;

                    }
                    else
                    {
                        MessageBox.Show("La velocidad seleccionada ya figura en la grilla.");
                        agregarEnGrilla = false;
                    }
                    break;
                case Servicios._Modalidad.PERIODO:
                    if (this.Requiere_Servicio_Padre)
                        dr["id_servicios_base"] = Convert.ToInt32(cboPeriodosServicios_Padres.SelectedValue);
                    dr["origenmeses"] = this.OrigenMeses;

                    if (this.Fecha_Inicio_Servicio == false)
                    {
                        if (dtServicios_Tarifas_Especiales.Select(String.Format("mes_inicio={0} and mes_fin={1}", Convert.ToInt32(cboPeriodos_Mes_Inicio_Serv.SelectedIndex + 1), Convert.ToInt32(cboPeriodos_Mes_Fin_Serv.SelectedIndex + 1))).Length == 0)
                        {
                            dr["mes_facturacion"] = cboPeriodos_Mes_Inicio_Fact.SelectedIndex + 1;
                            dr["mes_inicio"] = cboPeriodos_Mes_Inicio_Serv.SelectedIndex + 1;
                            dr["mes_fin"] = cboPeriodos_Mes_Fin_Serv.SelectedIndex + 1;

                        }
                        else
                        {
                            MessageBox.Show("Ya ha definido el monto para el periodo seleccionado.");
                            agregarEnGrilla = false;
                        }
                    }


                    if (this.Requiere_Velocidades)
                    {
                        dr["Velocidad"] = cboPeriodosVelocidades.Text;
                        dr["Velocidad_Tip"] = cboPeriodosVelocidades_Tipos.Text;
                        dr["id_servicios_velocidad"] = Convert.ToInt32(cboPeriodosVelocidades.SelectedValue);
                        dr["id_servicios_velocidad_tip"] = Convert.ToInt32(cboPeriodosVelocidades_Tipos.SelectedValue);
                    }

                    dr["meses_cobro"] = spPeriodosMesesCobro.Value;
                    dr["meses_servicio"] = spPeriodosMesesServicio.Value;
                    dr["Importe"] = spPeriodosImporte.Value;
                    DataView dvFiltro = dtServiciosPadre.DefaultView;
                    dvFiltro.RowFilter = "id_servicios=" + Id_Servicios;
                    DataTable dtFiltrada = new DataTable();
                    dtFiltrada = dvFiltro.ToTable();
                    dr["origenmeses"] = dtFiltrada.Rows[0]["origenmeses"];

                    break;
                case Servicios._Modalidad.UNICO:
                    break;
                case Servicios._Modalidad.PERIODO_CERRADO_POR_MES:
                    if (this.Requiere_Velocidades)
                    {
                        dr["Velocidad"] = cboPeriodosCerradoVelocidades.Text;
                        dr["Velocidad_Tip"] = cboPeriodosCerradoVelocidades_Tipos.Text;
                        dr["id_servicios_velocidad"] = Convert.ToInt32(cboPeriodosCerradoVelocidades.SelectedValue);
                        dr["id_servicios_velocidad_tip"] = Convert.ToInt32(cboPeriodosCerradoVelocidades_Tipos.SelectedValue);
                    }
                    dr["fecha_desde"] = dtpFechaDesde.Value;
                    dr["fecha_hasta"] = dtpFechaHasta.Value;
                    dr["importe"] = spPeriodoCerradoImporte.Value;
                    dr["origenmeses"] = this.OrigenMeses;

                    break;
                case Servicios._Modalidad.PERIODO_CERRADO_POR_DIA:
                    if (this.Requiere_Velocidades)
                    {
                        dr["Velocidad"] = cboPeriodosDiariosVelocidad.Text;
                        dr["Velocidad_Tip"] = cboPeriodosDiariosVelocidadTip.Text;
                        dr["id_servicios_velocidad"] = Convert.ToInt32(cboPeriodosDiariosVelocidad.SelectedValue);
                        dr["id_servicios_velocidad_tip"] = Convert.ToInt32(cboPeriodosDiariosVelocidadTip.SelectedValue);
                    }

                    dr["dias_desde"] = spPeriodosDiariosCantidad.Value;
                    dr["dias_hasta"] = spPeriodosDiariosCantidad.Value;
                    dr["importe"] = spPeriodosDiariosImporte.Value;
                    dr["origenmeses"] = this.OrigenMeses;

                    break;
                default:
                    break;
            }

            if ((Servicio_Modalidad == Servicios._Modalidad.PERIODO) && (Requiere_Velocidades == false))
            {
                if (dtServicios_Tarifas_Especiales.Rows.Count > 0)
                    btnAgregar.Enabled = false;
            }

            if (agregarEnGrilla)
            {
                dtServicios_Tarifas_Especiales.Rows.Add(dr);
                dtServicios_Tarifas_Especiales.AcceptChanges();
            }

        }

        private void GuardarEspeciales()
        {
            if(dgv.Rows.Count == 0)
            {
                if (MessageBox.Show("Estas dejando el servicio sin tarifas. ¿Desea continuar de todos modos?", "Mensaje del sistem", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
            }
            oServicios_Tarifas_Sub_Esp.Guardar(dtServicios_Tarifas_Especiales, Personal.Id_Login);
            this.DialogResult = DialogResult.OK;
        }

        private void CalcularImporteFinal()
        {
            spDiariosImporteFinal.Value = spDiariosImporteDiario.Value - ((spDiariosImporteDiario.Value * spDiariosPorcentaje.Value) / 100);
        }

        private void ABMTarifas_Sub_Auxiliar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.DialogResult = DialogResult.Cancel;
        }

        private void ABMTarifas_Sub_Auxiliar_Load(object sender, EventArgs e)
        {
            tabModalidades.TabPages.Remove(tabPageMensual);
            tabModalidades.TabPages.Remove(tabPagePeriodos);
            tabModalidades.TabPages.Remove(tabPagePeriodosCerrados);
            tabModalidades.TabPages.Remove(tabPageDiarios);
            tabModalidades.TabPages.Remove(tabPagePeriodosDiarios);

            ComenzarCarga();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 22)
            {
                if (MessageBox.Show("¿Desea ELiminar el Registro Seleccionado?", "Mensaje del Sistema",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value) > 0)
                        oServicios_Tarifas_Sub_Esp.Eliminar(Convert.ToInt32(dgv.CurrentRow.Cells["id"].Value));


                    dgv.Rows.Remove(dgv.CurrentRow);
                    dgv.EndEdit();
                    dtServicios_Tarifas_Especiales.AcceptChanges();
                    btnAgregar.Enabled = true;
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.AgregarEspeciales();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            this.GuardarEspeciales();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count == 0)
            {
                if (MessageBox.Show("Estas dejando el servicio sin tarifas. ¿Desea continuar de todos modos?", "Mensaje del sistem", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
            }
            this.DialogResult = DialogResult.Cancel;
        }

        private void spDiariosImporteDiario_ValueChanged(object sender, EventArgs e)
        {
            CalcularImporteFinal();
        }

        private void spDiariosPorcentaje_ValueChanged(object sender, EventArgs e)
        {
            CalcularImporteFinal();
        }

        private void cboPeriodos_Mes_Inicio_Fact_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboPeriodos_Mes_Inicio_Serv.SelectedIndex = cboPeriodos_Mes_Inicio_Fact.SelectedIndex;
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void dtpFechaDesde_ValueChanged(object sender, EventArgs e)
        {
            dtpFechaHasta.MinDate = dtpFechaDesde.Value.AddDays(1);
        }
    }
}
