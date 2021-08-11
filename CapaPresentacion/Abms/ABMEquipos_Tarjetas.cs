using CapaNegocios;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Abms
{
    public partial class ABMEquipos_Tarjetas : Form
    {

        int IdTarjeta = 0;
        private Thread hilo;
        private delegate void myDel();
        DataTable dtDatosEquipos = new DataTable();
        DataTable dtTiposEquipos = new DataTable();
        DataTable dtEstadosTarjetas = new DataTable();
        DataTable dtTarjetas = new DataTable();
        Equipos oEquipo = new Equipos();
        Equipos_Tipos oEquiposTipos = new Equipos_Tipos();
        Equipos_Tarjetas oEquiposTarjetas = new Equipos_Tarjetas();
        Partes_Equipos oPartesEquipos = new Partes_Equipos();
        private int IdTipoEquipo = 0;
        private int EstadoTarjetas = 0;
        public bool vieneExterno = false;

        public enum TIPO_ID_RECIBIDO
        {
            EQUIPO = 1,
            PARTE_EQUIPO = 2
        }

        public ABMEquipos_Tarjetas(int TipoEquipoRecibido, int IdEstadoRecibido)
        {
            IdTipoEquipo = TipoEquipoRecibido;
            EstadoTarjetas = IdEstadoRecibido;
            InitializeComponent();
        }

        private void comenzarCarga()
        {
            pgCircular.Start();
            UseWaitCursor = true;
            setearEstadoControles(false);
            dgv.DataSource = null;
            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
        }

        private void cargarDatos()
        {

            dtTarjetas = oEquiposTarjetas.Listar();
            if (IdTipoEquipo > 0 && EstadoTarjetas > 0)
            {
                DataView DtvTarjetas = new DataView(dtTarjetas);
                DtvTarjetas.RowFilter = String.Format("id_equipos_tipo={0} and estado={1}", IdTipoEquipo, EstadoTarjetas);
                dtTarjetas = DtvTarjetas.ToTable();
            }

            dtTiposEquipos = oEquiposTipos.Listar();
            if (dtTiposEquipos.Rows.Count > 0)
            {
                DataView dtv = new DataView(dtTiposEquipos);
                dtv.RowFilter = String.Format("requiere_tarjeta=1");
                dtTiposEquipos = dtv.ToTable();
            }
            myDel MD = new myDel(asignarDatos);
            this.Invoke(MD, new object[] { });
            pgCircular.Stop();
            UseWaitCursor = false;
        }

        private void asignarDatos()
        {
            setearEstadoControles(true);
            if (dtTiposEquipos.Rows.Count > 0)
            {
                cboEquipos_Tipos.DataSource = dtTiposEquipos;
                cboEquipos_Tipos.DisplayMember = "nombre";
                cboEquipos_Tipos.ValueMember = "id";
                if (dtTiposEquipos.Rows.Count > 0)
                {
                    if (IdTipoEquipo > 0)
                    {
                        cboEquipos_Tipos.SelectedValue = IdTipoEquipo;
                        cboEquipos_Tipos.Enabled = false;
                    }
                    else
                        cboEquipos_Tipos.SelectedIndex = 0;
                }
                dgv.DataSource = dtTarjetas;

                for (int x = 0; x < dgv.Columns.Count; x++)
                    dgv.Columns[x].Visible = false;

                dgv.Columns["numero"].Visible = true;
                dgv.Columns["equipotipo"].Visible = true;
                dgv.Columns["serie"].Visible = true;
                dgv.Columns["mac"].Visible = true;
                dgv.Columns["usuario"].Visible = true;
                dgv.Columns["servicio"].Visible = true;

                dgv.Columns["numero"].HeaderText = "Número de tarjeta";
                dgv.Columns["equipotipo"].HeaderText = "Tipo de equipo";
                dgv.Columns["serie"].HeaderText = "Nro. de serie del equipo";
                dgv.Columns["mac"].HeaderText = "Dirección Mac del equipo";
                dgv.Columns["usuario"].HeaderText = "Usuario";
                dgv.Columns["servicio"].HeaderText = "Servicio";
                dgv.Columns["numero"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                lblTotal.Text = String.Format("Total de registros: {0}", dgv.Rows.Count);
                AsignarValores();
                ColorearGrilla();
                controles(true);
            }
            else
            {
                MessageBox.Show("No hay tipos de equipos cargados", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
        }

        private void AsignarValores()
        {
            if (dgv.Rows.Count > 0)
            {
                if (dgv.SelectedRows.Count > 0)
                {
                    try
                    {
                        IdTarjeta = Convert.ToInt32(dgv.SelectedRows[0].Cells["id"].Value);
                        txtNumero.Text = dgv.SelectedRows[0].Cells["numero"].Value.ToString();
                        txtNumero.Tag = dgv.SelectedRows[0].Cells["numero"].Value.ToString();
                        cboEstado.SelectedIndex = Convert.ToInt32(dgv.SelectedRows[0].Cells["estado"].Value) - 1;
                        cboEquipos_Tipos.SelectedValue = Convert.ToInt32(dgv.SelectedRows[0].Cells["id_equipos_tipo"].Value);
                    }
                    catch (Exception)
                    {
                    }
                }
                else
                {
                    IdTarjeta = Convert.ToInt32(dgv.Rows[0].Cells["id"].Value);
                    txtNumero.Text = dgv.Rows[0].Cells["numero"].Value.ToString();
                    txtNumero.Tag = dgv.Rows[0].Cells["numero"].Value.ToString();
                    cboEstado.SelectedIndex = Convert.ToInt32(dgv.Rows[0].Cells["estado"].Value) - 1;
                    cboEquipos_Tipos.SelectedValue = Convert.ToInt32(dgv.Rows[0].Cells["id_equipos_tipo"].Value);
                }

            }
            //if(IdRecibido>0)
            //cboEquipos_Tipos.SelectedValue = Convert.ToInt32(dtDatosEquipos.Rows[0]["id_equipos_tipos"]);
        }

        private void ColorearGrilla()
        {
            int EstadoTarjeta;
            foreach (DataGridViewRow fila in dgv.Rows)
            {
                EstadoTarjeta = Convert.ToInt32(fila.Cells["Estado"].Value);
                if (EstadoTarjeta == Convert.ToInt32(Equipos_Tarjetas.Tarjetas_Estados.DISPONIBLE))
                    fila.DefaultCellStyle.BackColor = Color.LightGreen;
                else if (EstadoTarjeta == Convert.ToInt32(Equipos_Tarjetas.Tarjetas_Estados.CON_FALLA))
                    fila.DefaultCellStyle.BackColor = Color.Tomato;
                else
                    fila.DefaultCellStyle.BackColor = Color.DarkGray;
            }
        }

        private void controles(bool state)
        {
            btnActualizar.Enabled = state;
            dgv.Enabled = state;
            btnNuevo.Enabled = state;
            btnEliminar.Enabled = state;
            btnEditar.Enabled = state;
            btnGuardar.Enabled = !state;
            btnCancelar.Enabled = !state;
            txtNumero.Enabled = !state;
            if (IdTipoEquipo > 0)
                cboEquipos_Tipos.Enabled = false;
            else
                cboEquipos_Tipos.Enabled = !state;
            cboEstado.Enabled = !state;
            btnNuevo.Focus();
        }

        private void limpiarValores()
        {
            IdTarjeta = 0;
            if (IdTipoEquipo == 0)
                cboEquipos_Tipos.SelectedIndex = 0;
            else
                cboEquipos_Tipos.SelectedValue = IdTipoEquipo;
            cboEstado.SelectedIndex = 0;
            txtNumero.Text = "";
            txtNumero.Tag = "";

        }

        private bool ValidarDatos()
        {
            if (txtNumero.Tag.ToString() != txtNumero.Text && txtNumero.Text.Length > 0)
            {
                DataRow[] dr = dtTarjetas.Select(String.Format("numero = '{0}'", txtNumero.Text.ToUpper()));

                if (dr.Count() > 0)
                {
                    MessageBox.Show("El Valor ingresado ya Existe", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtNumero.Focus();
                    return false;
                }
            }
            return true;
        }

        private void Guardar()
        {

            if (txtNumero.Text.Length > 0)
            {
                if (ValidarDatos())
                {
                    oEquiposTarjetas.Id = IdTarjeta;
                    oEquiposTarjetas.Numero = txtNumero.Text;
                    oEquiposTarjetas.Id_Equipos_Tipos = Convert.ToInt32(cboEquipos_Tipos.SelectedValue);
                    oEquiposTarjetas.Id_Estado = Convert.ToInt32(cboEstado.SelectedIndex) + 1;

                    oEquiposTarjetas.Guardar(oEquiposTarjetas);


                    if (IdTarjeta == 0)
                    {
                        if (MessageBox.Show("¿Desea Cargar en Forma Masiva?", "Mensaje del Sistema",
                        MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            using (frmPopUp frm = new frmPopUp())
                            {
                                ABMEquipos_Tarjetas_Stock frmMasivo = new ABMEquipos_Tarjetas_Stock();
                                frmMasivo.Id_Estado = oEquiposTarjetas.Id_Estado;
                                frmMasivo.Id_Equipos_Tipos = oEquiposTarjetas.Id_Equipos_Tipos;

                                frm.Maximizar = false;
                                frm.Formulario = frmMasivo;

                                if (frm.ShowDialog() == DialogResult.OK)
                                    comenzarCarga();
                            }
                        }
                        else 
                        {
                            if (vieneExterno)
                                this.Close();
                            else
                                comenzarCarga();
                        }
                    }
                    else
                        comenzarCarga();
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar un número de tarjeta");
                txtNumero.Focus();
            }


        }

        private void Eliminar()
        {
            oEquiposTarjetas.Eliminar(Convert.ToInt32(dgv.SelectedRows[0].Cells["id"].Value));
        }

        private void ABMTarjetasEquipos_Load(object sender, EventArgs e)
        {
            /*if(IdRecibido==0)
            {
                btnAsignarTarjeta.Enabled = false;
                btnQuitarTarjeta.Enabled = false;
            }*/
            
            btnNuevo.Focus();
            comenzarCarga();

        }

        private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            AsignarValores();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiarValores();
            controles(false);
            txtNumero.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 0)
            {
                controles(false);

            }
            else
                MessageBox.Show("No se ha seleccionado un registro.");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 0)
            {
                if (Convert.ToInt32(dgv.SelectedRows[0].Cells["estado"].Value) != Convert.ToInt32(Equipos_Tarjetas.Tarjetas_Estados.ENTREGADA))
                {
                    DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea eliminar la tarjeta?", "", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        try
                        {
                            Eliminar();
                            comenzarCarga();
                            if (dgv.Rows.Count == 0)
                                limpiarValores();
                        }
                        catch
                        {
                            MessageBox.Show("Error al eliminar.");
                        }
                    }

                }
                else
                    MessageBox.Show("No se puede eliminar ya que se encuentra asociada a un equipo.");

            }
            else
                MessageBox.Show("No se ha seleccionado un registro.");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            controles(true);
            dgv.Enabled = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            Guardar();

        }



        private void imgReturn_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void btnQuitarTarjeta_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(dgv.SelectedRows[0].Cells["estado"].Value) == Convert.ToInt32(Equipos_Tarjetas.Tarjetas_Estados.ENTREGADA))
                {
                    int idTarjeta = Convert.ToInt32(dgv.SelectedRows[0].Cells["id"].Value);
                    int idEquipo = Convert.ToInt32(dgv.SelectedRows[0].Cells["idEquipo"].Value);
                    oEquiposTarjetas.QuitarTarjetaEquipo(idEquipo);
                    oEquiposTarjetas.CambiarEstadoTarjeta(idTarjeta, Convert.ToInt32(Equipos_Tarjetas.Tarjetas_Estados.CON_FALLA));
                    MessageBox.Show("Operación realizada correctamente.");
                    comenzarCarga();
                }
                else
                    MessageBox.Show("No tiene un equipo asignado.");
            }
            catch
            {
                MessageBox.Show("Error al realizar operación.");
            }

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text.Length == 0)
                dtTarjetas.DefaultView.RowFilter = "id>0";
            else
            {
                try
                {
                    dtTarjetas.DefaultView.RowFilter = String.Format("numero Like '%" + txtBuscar.Text + "%' or equipoTipo Like '%" + txtBuscar.Text + "%' or EstadoNombre Like '%" + txtBuscar.Text + "%' or usuario Like '%" + txtBuscar.Text + "%' or servicio Like '%" + txtBuscar.Text + "%'");
                }
                catch
                {
                    dtTarjetas.DefaultView.RowFilter = String.Format("equipoTipo Like '%" + txtBuscar.Text + "%' or EstadoNombre Like '%" + txtBuscar.Text + "%' or usuario Like '%" + txtBuscar.Text + "%' or servicio Like '%" + txtBuscar.Text + "%'");
                }
            }
            ColorearGrilla();
        }

        private void setearEstadoControles(bool estado)
        {
            btnActualizar.Enabled = estado;
            btnCancelar.Enabled = estado;
            btnEditar.Enabled = estado;
            btnEliminar.Enabled = estado;
            btnGuardar.Enabled = estado;
            btnNuevo.Enabled = estado;
            btnQuitarTarjeta.Enabled = estado;
            cboEquipos_Tipos.Enabled = estado;
            cboEstado.Enabled = estado;
        }

        private void ABMTarjetasEquipos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void dgv_Sorted(object sender, EventArgs e)
        {
            ColorearGrilla();
        }

        private void lblDisponible_Click(object sender, EventArgs e)
        {

        }
    }
}
