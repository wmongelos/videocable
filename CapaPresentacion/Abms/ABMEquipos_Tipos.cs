using CapaNegocios;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Abms
{
    public partial class ABMEquipos_Tipos : Form
    {
        private Thread hilo;
        private delegate void myDel();
        private DataTable dt, dtEquiposTipos;
        private DataTable dtServicios_Tipo;
        private Servicios_Tipos oServicio_Tipo = new Servicios_Tipos();
        private Iva_Alicuotas Iva_Alicuotas = new Iva_Alicuotas();
        private Equipos_Tipos oEqui_Tipo = new Equipos_Tipos();
        private DataTable dt_Tipos_Servicios = new DataTable();
        private DataTable dt_Tipos_Servicios_Nuevo = new DataTable();
        private DataTable dtAlicuotas = new DataTable();


        private int Id = 0;

        public ABMEquipos_Tipos()
        {
            InitializeComponent();
        }

        private void comenzarCarga()
        {
            pgCircular.Start();

            dgv.DataSource = null;

            hilo = new Thread(new ThreadStart(cargarDatos));

            hilo.Start();
        }

        private void cargarDatos()
        {
            try
            {
                dtServicios_Tipo = oServicio_Tipo.Listar();
                dt_Tipos_Servicios = oEqui_Tipo.ListarTiposServicios(0);
                dt_Tipos_Servicios_Nuevo = dt_Tipos_Servicios.Clone();
                dtAlicuotas = Iva_Alicuotas.Listar();

                if (dtServicios_Tipo.Rows.Count > 0)
                    dt = oEqui_Tipo.ListarCantidadEquiposTipos();

                myDel MD = new myDel(asignarDatos);

                this.Invoke(MD, new object[] { });

                pgCircular.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Informacion" + ex.Message);
            }
        }

        private void asignarDatos()
        {
            dgvDetalle.Columns.Clear();

            dgv.DataSource = dt;

            if (dtServicios_Tipo.Rows.Count > 0)
            {
                dgv.Columns["Nombre"].HeaderText = "Tipo de Equipo";
                dgv.Columns["id"].Visible = false;
                dgv.Columns["Borrado"].Visible = false;
                dgv.Columns["verificar_serie"].Visible = false;
                dgv.Columns["verificar_mac"].Visible = false;
                dgv.Columns["Requiere_Tarjeta"].Visible = false;
                dgv.Columns["Requiere_Config"].Visible = false;
                dgv.Columns["Id_Iva_Alicuotas"].Visible = false;
                dgv.Columns["Total"].HeaderText = "Total Stock";
                dgv.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                cboTipos.DataSource = dtServicios_Tipo;
                cboTipos.DisplayMember = "Nombre";
                cboTipos.ValueMember = "Id";

                lblTotal.Text = String.Format("Total de Registros: {0}", dt.Rows.Count);

                dgvDetalle.DataSource = dt_Tipos_Servicios;
                dgvDetalle.Columns["Id"].Visible = false;
                dgvDetalle.Columns["Id_Equipos_Tipos"].Visible = false;
                dgvDetalle.Columns["Id_Servicios_Tipos"].Visible = false;

                DataGridViewLinkColumn col = new DataGridViewLinkColumn();
                dgvDetalle.Columns.Add(col);
                col.Text = "Eliminar";
                col.DataPropertyName = "Eliminar";
                col.Name = "Accion";
                col.LinkColor = Color.Blue;
                col.VisitedLinkColor = Color.Blue;
                col.UseColumnTextForLinkValue = true;
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.Width = 100;

                controles(false);

                cboAlicuotas.DataSource = dtAlicuotas;
                cboAlicuotas.ValueMember = "id";
                cboAlicuotas.DisplayMember = "Porcentaje";

                var total = dt.Compute("SUM(total)", "");

                lblTotalStock.Text = String.Format("Total en Stock: {0}", total.ToString());

                asignarValores();
            }
            else
            {
                MessageBox.Show("Debe cargar tipos de servicios para poder cargar tipos de equipos.");

                DesabilitarControles();
            }
        }

        private void DesabilitarControles()
        {
            btnActualizar.Enabled = false;
            btnNuevo.Enabled = false;
            btnEliminar.Enabled = false;
            btnEditar.Enabled = false;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
        }

        private void controles(bool state)
        {
            btnActualizar.Enabled = !state;
            btnNuevo.Enabled = !state;
            btnEditar.Enabled = !state;
            btnEliminar.Enabled = !state;

            dgv.Enabled = !state;

            txtNombre.Enabled = state;
            cboTipos.Enabled = state;
            chkVerificarMac.Enabled = state;
            chkVerificarSerie.Enabled = state;
            chkRequiereTarjeta.Enabled = state;
            chkRequiere_Config.Enabled = state;
            btnGuardar.Enabled = state;
            btnCancelar.Enabled = state;
            cboAlicuotas.Enabled = state;
        }

        private void limpiarValores()
        {
            Id = 0;
            txtNombre.Text = "";
            chkVerificarMac.Checked = false;
            chkVerificarSerie.Checked = false;
            chkRequiereTarjeta.Checked = false;
            chkRequiere_Config.Checked = false;
        }

        private void asignarValores()
        {
            try
            {
                Id = Convert.ToInt32(dgv.CurrentRow.Cells["Id"].Value);
                txtNombre.Text = dgv.CurrentRow.Cells["Nombre"].Value.ToString();
                txtNombre.Tag = dgv.CurrentRow.Cells["Nombre"].Value.ToString();

                cboAlicuotas.SelectedValue = dgv.CurrentRow.Cells["Id_Iva_Alicuotas"].Value.ToString();

                if (Convert.ToInt32(dgv.CurrentRow.Cells["verificar_serie"].Value) == 1)
                    chkVerificarSerie.Checked = true;
                else
                    chkVerificarSerie.Checked = false;

                if (Convert.ToInt32(dgv.CurrentRow.Cells["verificar_mac"].Value) == 1)
                    chkVerificarMac.Checked = true;
                else
                    chkVerificarMac.Checked = false;

                if (Convert.ToInt32(dgv.CurrentRow.Cells["Requiere_Tarjeta"].Value) == 1)
                    chkRequiereTarjeta.Checked = true;
                else
                    chkRequiereTarjeta.Checked = false;

                if (Convert.ToInt32(dgv.CurrentRow.Cells["Requiere_Config"].Value) == 1)
                    chkRequiere_Config.Checked = true;
                else
                    chkRequiere_Config.Checked = false;


                if (dt_Tipos_Servicios.Rows.Count > 0)
                    dt_Tipos_Servicios.DefaultView.RowFilter = String.Format("Id_Equipos_Tipos = {0}", dgv.CurrentRow.Cells["Id"].Value.ToString());
            }
            catch
            {

            }

        }

        private void nuevoRegistro()
        {
            Id = 0;
            txtNombre.Text = "";
            chkVerificarMac.Checked = false;
            chkVerificarSerie.Checked = false;
            chkRequiereTarjeta.Checked = false;
            chkRequiere_Config.Checked = false;
            cboTipos.Enabled = true;
            txtNombre.Enabled = true;

            txtNombre.Focus();

            asignarTipoServ();
        }

        private void editarRegistro()
        {
            asignarTipoServ();

            foreach (DataRow dr in dt_Tipos_Servicios.Rows)
            {
                if (Convert.ToInt32(dr["Id_Equipos_Tipos"]) == Convert.ToInt32(dgv.SelectedRows[0].Cells["Id"].Value))
                    dt_Tipos_Servicios_Nuevo.ImportRow(dr);
            }

            cboTipos.Enabled = true;
            txtNombre.Enabled = true;
            txtNombre.Focus();
            chkVerificarSerie.Enabled = true;
            chkVerificarMac.Enabled = true;
            chkRequiereTarjeta.Enabled = true;
            chkRequiere_Config.Enabled = true;
            cboAlicuotas.Enabled = true;
        }

        private void eliminarRegistro()
        {
            int idEquipoTipo = Convert.ToInt32(dgv.SelectedRows[0].Cells["Id"].Value);
            dtEquiposTipos = oEqui_Tipo.VerificarAsignacionDeEquipos(idEquipoTipo);
            if (dtEquiposTipos.Rows.Count == 0)
            {
                if (MessageBox.Show("¿Desea eliminar el Registro Seleccionado?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    oEqui_Tipo.Eliminar(idEquipoTipo);
                    comenzarCarga();
                }
            }
            else
            {
                MessageBox.Show("Existen equipos de este tipo, no se pueden eliminar");
            }

        }

        private void guardarRegistro()
        {
            if (txtNombre.Text.Length == 0)
                txtNombre.Focus();
            else
            {
                if (validarDatos())
                {
                    oEqui_Tipo.Id = Convert.ToInt32(Id);
                    if (oEqui_Tipo.Id == 0)
                        MessageBox.Show("Recuerde asignar tipos de servicio al tipo de equipo que está guardando.");

                    oEqui_Tipo.Nombre = txtNombre.Text.ToUpper();

                    if (chkVerificarMac.Checked == true)
                        oEqui_Tipo.Verificar_Mac = 1;
                    else
                        oEqui_Tipo.Verificar_Mac = 0;

                    if (chkVerificarSerie.Checked == true)
                        oEqui_Tipo.Verificar_Serie = 1;
                    else
                        oEqui_Tipo.Verificar_Serie = 0;

                    if (chkRequiereTarjeta.Checked == true)
                        oEqui_Tipo.Requiere_Tarjeta = 1;
                    else
                        oEqui_Tipo.Requiere_Tarjeta = 0;

                    oEqui_Tipo.Requiere_Config = chkRequiere_Config.Checked == true ? 1 : 0;

                    oEqui_Tipo.Id_Iva_Alicuotas = Convert.ToInt32(cboAlicuotas.SelectedValue);

                    dt_Tipos_Servicios_Nuevo.AcceptChanges();

                    oEqui_Tipo.Guardar(oEqui_Tipo, dt_Tipos_Servicios_Nuevo);

                    comenzarCarga();
                }
            }
        }

        private void cancelarEdicion()
        {
            controles(false);
        }

        private bool validarDatos()
        {
            if (txtNombre.Tag.ToString() != txtNombre.Text && txtNombre.Text.Length > 0)
            {
                DataRow[] dr = dt.Select(String.Format("Nombre = '{0}'", txtNombre.Text.ToUpper()));

                if (dr.Count() > 0)
                {
                    MessageBox.Show("El Valor ingresado ya Existe", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return false;
                }
            }

            return true;
        }

        private void asignarTipoServ()
        {
            dgvDetalle.Columns.Clear();

            dgvDetalle.DataSource = null;

            dt_Tipos_Servicios_Nuevo.Rows.Clear();

            dgvDetalle.DataSource = dt_Tipos_Servicios_Nuevo;
            dgvDetalle.Columns["Id"].Visible = false;
            dgvDetalle.Columns["Id_Equipos_Tipos"].Visible = false;
            dgvDetalle.Columns["Id_Servicios_Tipos"].Visible = false;

            DataGridViewLinkColumn col = new DataGridViewLinkColumn();
            dgvDetalle.Columns.Add(col);
            col.Text = "Eliminar";
            col.DataPropertyName = "Eliminar";
            col.Name = "Accion";
            col.LinkColor = Color.Blue;
            col.VisitedLinkColor = Color.Blue;
            col.UseColumnTextForLinkValue = true;
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            col.Width = 100;
        }

        private void ABMEquipos_Tipos_Load(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            controles(false);
            comenzarCarga();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            controles(true);

            limpiarValores();

            nuevoRegistro();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            controles(true);
            editarRegistro();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminarRegistro();
            if (dgv.Rows.Count == 0)
                limpiarValores();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            guardarRegistro();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cancelarEdicion();
        }

        private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            asignarValores();
        }

        private void ABMEquipos_Tipos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            dt_Tipos_Servicios_Nuevo.Rows.Add(0, Convert.ToInt32(cboTipos.SelectedValue), Convert.ToInt32(Id), cboTipos.Text);

            dt_Tipos_Servicios_Nuevo.AcceptChanges();
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataRow[] dr = dt.Select(String.Format("Id = {0}", dgv.SelectedRows[0].Cells["Id"].Value.ToString()));


            using (frmPopUp frm = new frmPopUp())
            {
                Informes.FrmStockTipoEquipos frmABM = new Informes.FrmStockTipoEquipos();
                frmABM.Datarow = dr[0];
                frm.Formulario = frmABM;
                frm.Maximizar = false;

                if (frm.ShowDialog() == DialogResult.OK)
                    cargarDatos();
            }
        }

        private void dgvDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                try
                {
                    int id = Convert.ToInt32(dgvDetalle.SelectedRows[0].Cells["Id"].Value);

                    if (id > 0)
                        oEqui_Tipo.Eliminar_Tipo_Servicios(id);

                    if (this.dgvDetalle.SelectedRows.Count > 0)
                        dgvDetalle.Rows.RemoveAt(this.dgvDetalle.SelectedRows[0].Index);
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
