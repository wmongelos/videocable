using CapaNegocios;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Abms
{
    public partial class ABMBonificaciones_CondicionesRepeticion : Form
    {
        private int IdBonificacionAplicacion = 0;
        private Thread hilo;
        private delegate void myDel();
        private DataTable DtDatosBonificacionAplicacion = new DataTable();
        private Bonificaciones_Aplicacion oBonificacionAplicacion = new Bonificaciones_Aplicacion();
        private DataTable DtCondiciones = new DataTable();
        private Bonificaciones_Aplicacion_Condiciones oBonificacionesAplicacionCondiciones = new Bonificaciones_Aplicacion_Condiciones();
        private Bonificaciones_Condiciones_Porcentaje oBonificacionPorcentajes = new Bonificaciones_Condiciones_Porcentaje();
        private DataTable DtPorcentajes = new DataTable();

        private void ComenzarCarga()
        {
            pgCircular.Start();
            hilo = new Thread(new ThreadStart(CargarDatos));
            hilo.IsBackground = true;
            hilo.Start();
        }

        private void CargarDatos()
        {
            try
            {
                DtCondiciones = oBonificacionesAplicacionCondiciones.ListarPorIdBonificacionAplicacion(IdBonificacionAplicacion);
                myDel MD = new myDel(AsignarDatos);
                this.Invoke(MD, new object[] { });
                pgCircular.Stop();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
            }
        }

        private void AsignarDatos()
        {
            dgvCondiciones.DataSource = DtCondiciones;
            for (int x = 0; x < dgvCondiciones.Columns.Count; x++)
                dgvCondiciones.Columns[x].Visible = false;
            dgvCondiciones.Columns["cantidad"].Visible = true;
            dgvCondiciones.Columns["tipo_condicion_texto"].Visible = true;
            dgvCondiciones.Columns["nivel_texto"].Visible = true;
            dgvCondiciones.Columns["nombre_item"].Visible = true;
            dgvCondiciones.Columns["cantidad"].HeaderText = "Cantidad";
            dgvCondiciones.Columns["tipo_condicion_texto"].HeaderText = "Tipo";
            dgvCondiciones.Columns["nivel_texto"].HeaderText = "Nivel";
            dgvCondiciones.Columns["nombre_item"].HeaderText = "Nombre";
            if (dgvCondiciones.Rows.Count > 0)
            {
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;
            }
            else
            {
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;
            }
            AsignarValores();
            lblTotal.Text = String.Format("Total de Registros: {0}", dgvCondiciones.Rows.Count);
        }

        private void AsignarValores()
        {
            if (dgvCondiciones.Rows.Count > 0)
            {
                DtPorcentajes.Clear();
                if (dgvCondiciones.SelectedRows.Count > 0)
                    DtPorcentajes = oBonificacionPorcentajes.ListarPorIdCondicion(Convert.ToInt32(dgvCondiciones.SelectedRows[0].Cells["id"].Value));
                else
                    DtPorcentajes = oBonificacionPorcentajes.ListarPorIdCondicion(Convert.ToInt32(dgvCondiciones.Rows[0].Cells["id"].Value));

                dgvPorcentajes.DataSource = null;
                dgvPorcentajes.DataSource = DtPorcentajes;
                for (int x = 0; x < dgvPorcentajes.Columns.Count; x++)
                    dgvPorcentajes.Columns[x].Visible = false;

                dgvPorcentajes.Columns["porcentaje"].Visible = true;
                dgvPorcentajes.Columns["desde"].Visible = true;
                dgvPorcentajes.Columns["hasta"].Visible = true;

                dgvPorcentajes.Columns["porcentaje"].HeaderText = "%";
                dgvPorcentajes.Columns["desde"].HeaderText = "Aplicado desde";
                dgvPorcentajes.Columns["hasta"].HeaderText = "Hasta";
                dgvPorcentajes.Columns["porcentaje"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvPorcentajes.Columns["porcentaje"].Width = 100;
            }
            else
                DtPorcentajes.Clear();

        }

        private void AgregarCondicion()
        {
            oBonificacionesAplicacionCondiciones.Id = 0;
            oBonificacionesAplicacionCondiciones.Id_Bonificacion_Aplicacion = IdBonificacionAplicacion;
            oBonificacionesAplicacionCondiciones.Nivel = Convert.ToInt32(DtDatosBonificacionAplicacion.Rows[0]["nivel"]);
            oBonificacionesAplicacionCondiciones.Bonificacion_Nombre = DtDatosBonificacionAplicacion.Rows[0]["nombre"].ToString();
            oBonificacionesAplicacionCondiciones.Aplicacion = lblAplicacion.Text;
            if (oBonificacionesAplicacionCondiciones.Nivel == Convert.ToInt32(Bonificaciones_Aplicacion.NIVEL.SERVICIO))
            {
                oBonificacionesAplicacionCondiciones.Id_Item = Convert.ToInt32(DtDatosBonificacionAplicacion.Rows[0]["id_servicio"]);
                oBonificacionesAplicacionCondiciones.Tipo_Condicion = Convert.ToInt32(Bonificaciones_Aplicacion_Condiciones.TIPO_CONDICION.SERVICIOS);
                oBonificacionesAplicacionCondiciones.Nombre_Item = DtDatosBonificacionAplicacion.Rows[0]["servicio"].ToString();
                oBonificacionesAplicacionCondiciones.Tipo_Servicio_Sub = "";
            }
            else
            {
                oBonificacionesAplicacionCondiciones.Id_Item = Convert.ToInt32(DtDatosBonificacionAplicacion.Rows[0]["id_servicio_sub"]);
                oBonificacionesAplicacionCondiciones.Tipo_Condicion = Convert.ToInt32(Bonificaciones_Aplicacion_Condiciones.TIPO_CONDICION.SUBSERVICIOS);
                oBonificacionesAplicacionCondiciones.Nombre_Item = DtDatosBonificacionAplicacion.Rows[0]["subservicio"].ToString();
                oBonificacionesAplicacionCondiciones.Tipo_Servicio_Sub = DtDatosBonificacionAplicacion.Rows[0]["tipo_sub"].ToString();
            }
            ABMBonificaciones_Repeticion frmRep = new ABMBonificaciones_Repeticion(oBonificacionesAplicacionCondiciones);
            frmPopUp frmpopup = new frmPopUp();
            frmpopup.Maximizar = false;
            frmpopup.Formulario = frmRep;
            frmpopup.ShowDialog();
            ComenzarCarga();
        }

        private void EditarCondicion()
        {
            oBonificacionesAplicacionCondiciones.Id = Convert.ToInt32(dgvCondiciones.SelectedRows[0].Cells["id"].Value);
            oBonificacionesAplicacionCondiciones.Id_Bonificacion_Aplicacion = Convert.ToInt32(dgvCondiciones.SelectedRows[0].Cells["id_bonificacion_aplicacion"].Value);
            oBonificacionesAplicacionCondiciones.Id_Item = Convert.ToInt32(dgvCondiciones.SelectedRows[0].Cells["id_item"].Value);
            oBonificacionesAplicacionCondiciones.Nivel = Convert.ToInt32(dgvCondiciones.SelectedRows[0].Cells["nivel"].Value);
            oBonificacionesAplicacionCondiciones.Cantidad = Convert.ToInt32(dgvCondiciones.SelectedRows[0].Cells["cantidad"].Value);
            oBonificacionesAplicacionCondiciones.Tipo_Condicion = Convert.ToInt32(dgvCondiciones.SelectedRows[0].Cells["tipo_condicion"].Value);
            oBonificacionesAplicacionCondiciones.Nombre_Item = dgvCondiciones.SelectedRows[0].Cells["nombre_item"].Value.ToString();
            oBonificacionesAplicacionCondiciones.Tipo_Servicio_Sub = dgvCondiciones.SelectedRows[0].Cells["tipo_servicio_sub"].Value.ToString();
            oBonificacionesAplicacionCondiciones.Bonificacion_Nombre = DtDatosBonificacionAplicacion.Rows[0]["nombre"].ToString();
            oBonificacionesAplicacionCondiciones.Aplicacion = lblAplicacion.Text;
            ABMBonificaciones_Repeticion frmRep = new ABMBonificaciones_Repeticion(oBonificacionesAplicacionCondiciones);
            frmPopUp frmpopup = new frmPopUp();
            frmpopup.Maximizar = false;
            frmpopup.Formulario = frmRep;
            frmpopup.ShowDialog();
            ComenzarCarga();
        }

        public ABMBonificaciones_CondicionesRepeticion(int IdBonificacionAplicacionRecibida)
        {
            IdBonificacionAplicacion = IdBonificacionAplicacionRecibida;
            InitializeComponent();
        }

        private void ABMCondicionesBonificacion_Load(object sender, EventArgs e)
        {
            DtDatosBonificacionAplicacion = oBonificacionAplicacion.ListarPorId(IdBonificacionAplicacion);
            lblBonificacion.Text = String.Format("Bonificación: {0}", DtDatosBonificacionAplicacion.Rows[0]["nombre"]);
            if (Convert.ToInt32(DtDatosBonificacionAplicacion.Rows[0]["nivel"]) == Convert.ToInt32(Bonificaciones_Aplicacion.NIVEL.GRUPO))
                lblAplicacion.Text = String.Format("Aplicada a: Grupo {0}", DtDatosBonificacionAplicacion.Rows[0]["grupo"]);
            else if (Convert.ToInt32(DtDatosBonificacionAplicacion.Rows[0]["nivel"]) == Convert.ToInt32(Bonificaciones_Aplicacion.NIVEL.TIPO_SERVICIO))
                lblAplicacion.Text = String.Format("Aplicada a: Tipo de servicio {0}", DtDatosBonificacionAplicacion.Rows[0]["tipo_servicio"]);
            else if (Convert.ToInt32(DtDatosBonificacionAplicacion.Rows[0]["nivel"]) == Convert.ToInt32(Bonificaciones_Aplicacion.NIVEL.SERVICIO))
                lblAplicacion.Text = String.Format("Aplicada a: Servicio {0}", DtDatosBonificacionAplicacion.Rows[0]["servicio"]);
            else if (Convert.ToInt32(DtDatosBonificacionAplicacion.Rows[0]["nivel"]) == Convert.ToInt32(Bonificaciones_Aplicacion.NIVEL.SUBSERVICIO))
            {
                if (DtDatosBonificacionAplicacion.Rows[0]["tipo_sub"].ToString() == "S")
                {
                    if (Convert.ToInt32(DtDatosBonificacionAplicacion.Rows[0]["id_velocidad"]) != 0)
                        lblAplicacion.Text = String.Format("Aplicada a: Sub servicio {0}, con velocidad: {1} MB, del tipo: {2}, del servicio: {3}", DtDatosBonificacionAplicacion.Rows[0]["subservicio"], DtDatosBonificacionAplicacion.Rows[0]["velocidad"], DtDatosBonificacionAplicacion.Rows[0]["velocidad_tipo"], DtDatosBonificacionAplicacion.Rows[0]["servicio"]);
                    else
                        lblAplicacion.Text = String.Format("Aplicada a: Sub servicio {0}, del servicio: {1}", DtDatosBonificacionAplicacion.Rows[0]["subservicio"], DtDatosBonificacionAplicacion.Rows[0]["servicio"]);
                }
                else if (DtDatosBonificacionAplicacion.Rows[0]["tipo_sub"].ToString() == "E")
                    lblAplicacion.Text = String.Format("Aplicada a: Equipo {0}, del servicio: {1} ", DtDatosBonificacionAplicacion.Rows[0]["subservicio"], DtDatosBonificacionAplicacion.Rows[0]["servicio"]);
                else if (DtDatosBonificacionAplicacion.Rows[0]["tipo_sub"].ToString() == "P")
                    lblAplicacion.Text = String.Format("Aplicada a: Solicitud {0}, del servicio: {1} ", DtDatosBonificacionAplicacion.Rows[0]["subservicio"], DtDatosBonificacionAplicacion.Rows[0]["servicio"]);
            }
            ComenzarCarga();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ABMCondicionesBonificacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            ComenzarCarga();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarCondicion();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea eliminar la condicón seleccionada?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    oBonificacionesAplicacionCondiciones.Eliminar(Convert.ToInt32(dgvCondiciones.SelectedRows[0].Cells["id"].Value));

                    ComenzarCarga();
                }
                catch { MessageBox.Show("Error al realizar operación."); }
            }
        }

        private void imgReturn_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvCondiciones_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            AsignarValores();
        }

        private void ABMCondicionesRepeticion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void dgvCondiciones_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCondiciones.Rows.Count > 0)
                btnEliminar.Enabled = true;
            else
                btnEliminar.Enabled = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            EditarCondicion();
        }
    }
}
