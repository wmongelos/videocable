using CapaNegocios;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Abms
{
    public partial class ABMPartes_Fallas : Form
    {
        private Thread hilo;
        private delegate void myDel();
        private DataTable dt;
        private DataTable dtServicios_Tipos;
        private DataTable dtOperaciones;
        private Servicios_Tipos oSer = new Servicios_Tipos();
        private Partes oPartes = new Partes();
        private Partes_Solicitudes oPartes_Falla = new Partes_Solicitudes();
        private int Id = 0, editar = 0;
        private int Flag = 0;
        private string NombreNuevo;
        private DataTable dtAlicuotas = new DataTable();
        private Iva_Alicuotas Iva_Alicuotas = new Iva_Alicuotas();
        private int ultimaSeleccionTipoServicio = 0;
        private Tablas oTablas = new Tablas();

        private void ColorearGrilla()
        {
            foreach (DataGridViewRow fila in dgv.Rows)
            {
                if (Convert.ToInt32(fila.Cells["origen"].Value) == Convert.ToInt32(Partes_Solicitudes.ORIGEN_SOLICITUD.SISTEMA))
                    fila.DefaultCellStyle.BackColor = Color.MediumTurquoise;
                else
                    fila.DefaultCellStyle.BackColor = Color.SandyBrown;
            }
        }



        public ABMPartes_Fallas()
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
                dt = oPartes_Falla.Listar();
                dt.DefaultView.Sort = "origen desc";
                dtServicios_Tipos = oSer.Listar();
                dtOperaciones = oPartes.ListarOperaciones();
                dtAlicuotas = Iva_Alicuotas.Listar();

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

            if (Flag == 0)
            {
                cboServicios_Tipos.DataSource = dtServicios_Tipos;
                cboServicios_Tipos.ValueMember = "Id";
                cboServicios_Tipos.DisplayMember = "Nombre";
                DataView dv = dtOperaciones.DefaultView;
                dv.Sort = "nombre asc";
                DataTable dtoperacionesOrdenadas = dv.ToTable();
                cboPartes_Operaciones.DataSource = dtoperacionesOrdenadas;
                cboPartes_Operaciones.ValueMember = "Id";
                cboPartes_Operaciones.DisplayMember = "Nombre";

                cboAlicuotas.DataSource = dtAlicuotas;
                cboAlicuotas.ValueMember = "Id";
                cboAlicuotas.DisplayMember = "Porcentaje";
            }

            if (dt.Rows.Count > 0)
                dt.DefaultView.RowFilter = String.Format("id_servicios_tipos = {0}", cboServicios_Tipos.SelectedValue);
            dgv.DataSource = dt;

            dgv.Columns["Id"].Visible = false;
            dgv.Columns["Cargo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["Dias_Resolucion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["Id_Servicios_Tipos"].Visible = false;
            dgv.Columns["Id_Partes_Operaciones"].Visible = false;
            dgv.Columns["conCargo"].Visible = false;
            dgv.Columns["ServicioTipo"].Visible = false;
            dgv.Columns["Nombre"].HeaderText = "Descripcion";
            dgv.Columns["Nombre"].Width = 400;
            dgv.Columns["App_externa"].HeaderText = "Aplicación Externa";
            dgv.Columns["Aplica_app_externa"].Visible = false;
            dgv.Columns["Borrado"].Visible = false;
            dgv.Columns["Id_Iva_Alicuotas"].Visible = false;
            dgv.Columns["origen"].Visible = false;
            dgv.Columns["cargo"].Width = 200;
            dgv.Columns["cargo"].HeaderText = "Cargo";
            dgv.Columns["Dias_Resolucion"].Visible = true;
            dgv.Columns["Dias_Resolucion"].HeaderText = "Dias_Resolucion";
            dgv.Columns["Dias_Resolucion"].Width = 200;
            //dgv.Columns["codtra"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            if (dgv.Rows.Count > 0)
                ColorearGrilla();

            lblTotal.Text = String.Format("Total de Registros: {0}", dgv.Rows.Count);

            controles(false);
            if (Flag == 1)
            {
                foreach (DataGridViewRow item in dgv.Rows)
                {
                    if (Convert.ToString(item.Cells["nombre"].Value) == NombreNuevo)
                    {
                        item.Selected = true;
                    }
                }
            }
            asignarValores();
        }

        private void controles(bool state)
        {
            btnActualizar.Enabled = !state;
            btnNuevo.Enabled = !state;
            btnEditar.Enabled = !state;
            btnEliminar.Enabled = !state;

            dgv.Enabled = !state;
            cboPartes_Operaciones.Enabled = state;
            txtNombre.Enabled = state;
            cboAlicuotas.Enabled = state;
            chkAppExterna.Enabled = state;
            chkConCargo.Enabled = state;
            txtCodTra.Enabled = state;

            btnGuardar.Enabled = state;
            btnCancelar.Enabled = state;

        }

        private void limpiarValores()
        {
            Id = 0;
            txtNombre.Text = "";
            chkConCargo.Checked = false;
            txtCodTra.Text = "0";
            chkAppExterna.Checked = false;
        }

        private void asignarValores()
        {
            try
            {
                Id = Convert.ToInt32(dgv.SelectedRows[0].Cells["Id"].Value);
                txtNombre.Text = dgv.SelectedRows[0].Cells["Nombre"].Value.ToString();
                txtNombre.Tag = dgv.SelectedRows[0].Cells["Nombre"].Value.ToString();
                txtCodTra.Text = dgv.SelectedRows[0].Cells["dias_Resolucion"].Value.ToString();
                chkConCargo.Checked = Convert.ToDecimal(dgv.SelectedRows[0].Cells["conCargo"].Value.ToString()) == 1 ? true : false;
                chkAppExterna.Checked = Convert.ToDecimal(dgv.SelectedRows[0].Cells["Aplica_app_externa"].Value.ToString()) == 1 ? true : false;
                cboServicios_Tipos.SelectedValue = Convert.ToInt32(dgv.SelectedRows[0].Cells["Id_Servicios_tipos"].Value.ToString());
                cboPartes_Operaciones.SelectedValue = Convert.ToInt32(dgv.SelectedRows[0].Cells["Id_Partes_Operaciones"].Value.ToString());
                cboAlicuotas.SelectedValue = Convert.ToDecimal(dgv.SelectedRows[0].Cells["Id_iva_alicuotas"].Value.ToString());
            }
            catch
            {

            }
        }

        private void nuevoRegistro()
        {
            editar = 0;
            Id = 0;
            txtNombre.Text = "";
            chkAppExterna.Checked = false;
            cboServicios_Tipos.Enabled = true;
            txtNombre.Enabled = true;
            chkAppExterna.Enabled = true;
            chkConCargo.Enabled = true;
            txtNombre.Focus();
            txtCodTra.Text = "0";
        }

        private void editarRegistro()
        {
            cboServicios_Tipos.Enabled = true;
            txtNombre.Enabled = true;
            chkAppExterna.Enabled = true;
            chkConCargo.Enabled = true;
            txtCodTra.Enabled = true;
            editar = 1;
            cboServicios_Tipos.Focus();
        }

        private void eliminarRegistro()
        {
            if (MessageBox.Show("¿Desea eliminar el Registro Seleccionado?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                oPartes_Falla.Eliminar(Convert.ToInt32(Id));
                Flag = 1;
                comenzarCarga();
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
                    oPartes_Falla.Id = Convert.ToInt32(Id);
                    oPartes_Falla.Id_Servicios_Tipos = Convert.ToInt32(cboServicios_Tipos.SelectedValue);
                    oPartes_Falla.Id_Partes_Operaciones = Convert.ToInt32(cboPartes_Operaciones.SelectedValue);
                    oPartes_Falla.Nombre = txtNombre.Text.ToUpper();
                    oPartes_Falla.Aplica_app_externa = chkAppExterna.CheckState == CheckState.Checked ? 1 : 0;
                    oPartes_Falla.Id_Iva_Alicuota = Convert.ToInt32(cboAlicuotas.SelectedValue);
                    oPartes_Falla.Dias_Resolucion = Convert.ToInt32(txtCodTra.Text);

                    if (chkConCargo.CheckState == CheckState.Checked)
                    {
                        oPartes_Falla.ConCargo = 1;
                    }
                    else
                    {
                        oPartes_Falla.ConCargo = 0;
                    }
                    if (Id == 0)
                        oPartes_Falla.Origen = Convert.ToInt32(Partes_Solicitudes.ORIGEN_SOLICITUD.USUARIO);
                    else
                        oPartes_Falla.Origen = Convert.ToInt32(dgv.SelectedRows[0].Cells["origen"].Value);



                    oPartes_Falla.Id = oPartes_Falla.Guardar(oPartes_Falla);
                    Flag = 1;
                    NombreNuevo = oPartes_Falla.Nombre;
                    editar = 0;
                    Tablas.LoadSolicitudes();
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
            if ((txtNombre.Text.Length > 0) && (editar == 0))
            {
                DataRow[] dr = dt.Select(String.Format("Nombre = '{0}' and id_servicios_tipos={1} and borrado=0", txtNombre.Text.ToUpper(), Convert.ToInt32(cboServicios_Tipos.SelectedValue)));

                if (dr.Count() > 0)
                {
                    MessageBox.Show("El Valor ingresado ya Existe", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return false;
                }
            }

            return true;
        }

        private void ABMPartes_Fallas_Load(object sender, EventArgs e)
        {
            comenzarCarga();

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            controles(false);
            Flag = 0;
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

        private void ABMPartes_Fallas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void cboServicios_Tipos_SelectedValueChanged(object sender, EventArgs e)
        {
            if (btnNuevo.Enabled == true || btnEditar.Enabled == true)
            {
                try
                {

                    dt.DefaultView.RowFilter = String.Format("id_servicios_tipos={0}", cboServicios_Tipos.SelectedValue);

                    dgv.DataSource = dt;
                    if (dgv.Rows.Count > 0)
                        ColorearGrilla();
                    asignarValores();
                    lblTotal.Text = String.Format("Total de Registros: {0}", dgv.Rows.Count);
                }
                catch
                {

                }
            }
        }


        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}//301019fede
