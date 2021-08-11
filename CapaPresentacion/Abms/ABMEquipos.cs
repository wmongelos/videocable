using CapaNegocios;
using CapaPresentacion.Busquedas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Abms
{
    public partial class ABMEquipos : Form
    {
        private Thread hilo;
        private delegate void myDel();
        private DataTable dtEquipos;
        private Equipos oEquipo = new Equipos();
        private Equipos_Tipos oEquipo_Tipos = new Equipos_Tipos();
        private Equipos_Marcas oEquipo_Marca = new Equipos_Marcas();
        private Equipos_Modelos oEquipo_Model = new Equipos_Modelos();
        private Equipos_Estados oEquiposEstados = new Equipos_Estados();
        private Equipos_Tarjetas oEquiposTarjetas = new Equipos_Tarjetas();
        private List<int> listaSeleccionados = new List<int>();
        private DataView DtvEquipos;
        private DataTable DtEquiposAux = new DataTable();

        public ABMEquipos()
        {
            InitializeComponent();
        }

        private void comenzarCarga()
        {
            pgCircular.Start();
            dgv.DataSource = null;
            btnActualizar.Enabled = false;
            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
        }

        private void cargarDatos()
        {
            try
            {
                dtEquipos = oEquipo.Listar();
                myDel MD = new myDel(asignarDatos);
                this.Invoke(MD, new object[] { });
                btnActualizar.Enabled = true;
                pgCircular.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Informacion" + ex.Message);
            }
        }

        private void asignarDatos()
        {
            dgv.DataSource = dtEquipos;

            for (int i = 0; i < dgv.ColumnCount; i++)
                dgv.Columns[i].Visible = false;

            int control = 0;
            try
            {
                foreach (DataGridViewColumn columna in dgv.Columns)
                {
                    if (columna.Name == "colSeleccion")
                    {
                        control = 1;
                        break;
                    }
                }

                if (control == 1)
                    dgv.Columns.RemoveAt(dgv.Columns["colSeleccion"].Index);

                control = 0;

                DataGridViewCheckBoxColumn colSeleccion = new DataGridViewCheckBoxColumn();
                colSeleccion.HeaderText = "";
                colSeleccion.Name = "colSeleccion";
                dgv.Columns.Add(colSeleccion);
            }
            catch { }



            //dgv.Columns["Id_Usuarios"].Visible = false;
            //dgv.Columns["Id_Usuarios_Servicios"].Visible = false;
            //dgv.Columns["Id_Equipos_Marcas"].Visible = false;
            //dgv.Columns["Id_Equipos_Modelos"].Visible = false;
            //dgv.Columns["Id_Equipos_Tipos"].Visible = false;
            //dgv.Columns["Id_Equipos_Estados"].Visible = false;
            //dgv.Columns["requiere_tarjeta"].Visible = false;
            //dgv.Columns["id_tarjeta"].Visible = false;
            //dgv.Columns["posee_tarjeta"].Visible = false;

            dgv.Columns["estado"].Visible = true;
            dgv.Columns["calle"].Visible = true;
            dgv.Columns["altura"].Visible = true;
            dgv.Columns["codigo"].Visible = true;
            dgv.Columns["usuario"].Visible = true;
            dgv.Columns["tipo"].Visible = true;
            dgv.Columns["marca"].Visible = true;
            dgv.Columns["modelo"].Visible = true;
            dgv.Columns["serie"].Visible = true;
            dgv.Columns["mac"].Visible = true;
            dgv.Columns["equipo_usuario"].Visible = true;
            dgv.Columns["equipo_clave"].Visible = true;
            dgv.Columns["equipo_ip"].Visible = true;

            dgv.Columns["colSeleccion"].HeaderText = "Cambio de estado";
            dgv.Columns["estado"].ReadOnly = true;
            dgv.Columns["calle"].ReadOnly = true;
            dgv.Columns["altura"].ReadOnly = true;
            dgv.Columns["codigo"].ReadOnly = true;
            dgv.Columns["usuario"].ReadOnly = true;
            dgv.Columns["tipo"].ReadOnly = true;
            dgv.Columns["marca"].ReadOnly = true;
            dgv.Columns["modelo"].ReadOnly = true;
            dgv.Columns["serie"].ReadOnly = true;
            dgv.Columns["mac"].ReadOnly = true;
            dgv.Columns["equipo_usuario"].ReadOnly = true;
            dgv.Columns["equipo_clave"].ReadOnly = true;
            dgv.Columns["equipo_ip"].ReadOnly = true;

            dgv.Columns["Id"].HeaderText = "ID";
            dgv.Columns["Id"].Width = 50;
            dgv.Columns["estado"].HeaderText = "Estado";
            dgv.Columns["codigo"].HeaderText = "Codigo";
            dgv.Columns["calle"].HeaderText = "Calle";
            dgv.Columns["altura"].HeaderText = "Altura";
            dgv.Columns["usuario"].HeaderText = "Usuario";
            dgv.Columns["tipo"].HeaderText = "Tipo";
            dgv.Columns["marca"].HeaderText = "Marca";
            dgv.Columns["modelo"].HeaderText = "Modelo";
            dgv.Columns["serie"].HeaderText = "Serie";
            dgv.Columns["mac"].HeaderText = "Mac";
            dgv.Columns["numero"].HeaderText = "Nro. de tarjeta";
            dgv.Columns["equipo_usuario"].HeaderText = "Usuario configuración";
            dgv.Columns["equipo_clave"].HeaderText = "Clave configuración";
            dgv.Columns["equipo_ip"].HeaderText = "Ip configuración";
            dgv.Columns["numero"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["tipo"].Width = 100;
            dgv.Columns["marca"].Width = 100;
            dgv.Columns["modelo"].Width = 100;
            dgv.Columns["serie"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["mac"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["estado"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["calle"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["altura"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["usuario"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["numero"].Width = 70;
            dgv.Columns["colSeleccion"].Width = 90;
            dgv.Columns["equipo_usuario"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["equipo_clave"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["equipo_ip"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DtEquiposAux = dtEquipos;
            lblTotal.Text = String.Format("Total de Registros: {0}", dtEquipos.Rows.Count);
            ColorearGrilla();
            controles(false);

            if (dgv.Rows.Count == 0)
                DeshabilitaBtnGrillaVacia();
            else
            {
                foreach (Control item in this.Controls)
                {
                    item.Enabled = true;
                }
            }
        }

        private void DesabilitarControles()
        {
            btnActualizar.Enabled = false;
            btnNuevo.Enabled = false;
            btnEliminar.Enabled = false;
            btnEditar.Enabled = false;
            btnCancelar.Enabled = false;

            btnCambioEstado.Enabled = false;
        }

        private void controles(bool state)
        {
            btnActualizar.Enabled = !state;
            btnNuevo.Enabled = !state;
            btnEditar.Enabled = dtEquipos.Rows.Count == 0 ? false : !state;
            btnEliminar.Enabled = dtEquipos.Rows.Count == 0 ? false : !state;
            btnCambioEstado.Enabled = dtEquipos.Rows.Count == 0 ? false : !state;
            dgv.Enabled = !state;

            btnCancelar.Enabled = state;

        }

        private void nuevoRegistro()
        {
            ABMEquipos_Ficha frmAgregarEquipo = new ABMEquipos_Ficha(0);
            frmPopUp frmpopup = new frmPopUp();
            frmpopup.Maximizar = false;
            frmpopup.Formulario = frmAgregarEquipo;
            frmpopup.ShowDialog();
            if (frmAgregarEquipo.DialogResult == DialogResult.OK)
                comenzarCarga();

        }

        private void EditarRegistro()
        {
            if (dgv.SelectedRows.Count > 0)
            {
                if (Convert.ToInt32(dgv.SelectedRows[0].Cells["id_equipos_estados"].Value) != Convert.ToInt32(Equipos.Equipos_Estados.ASIGNADO_A_USUARIO) && Convert.ToInt32(dgv.SelectedRows[0].Cells["id_equipos_estados"].Value) != Convert.ToInt32(Equipos.Equipos_Estados.ASIGNADO_A_DEPARTAMENTO))
                {
                    ABMEquipos_Ficha frmAgregarEquipo = new ABMEquipos_Ficha(Convert.ToInt32(dgv.SelectedRows[0].Cells["id"].Value));
                    frmPopUp frmpopup = new frmPopUp();
                    frmpopup.Maximizar = false;
                    frmpopup.Formulario = frmAgregarEquipo;
                    frmpopup.ShowDialog();
                    if (frmAgregarEquipo.DialogResult == DialogResult.OK)
                        comenzarCarga();

                }
                else
                    MessageBox.Show("Este equipo se encuentra asignado, sus datos no pueden ser editados en este momento.");
            }
        }

        private void eliminarRegistro()
        {
            if (ColumnasSeleccionadas() == true)
            {
                if (MessageBox.Show("Puede que algunos equipos que haya seleccionado se encuentren asignados a usuarios. En estos casos, no se eliminarán. ¿Desea continuar?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (DataGridViewRow fila in dgv.Rows)
                    {
                        if (Convert.ToInt32(fila.Cells["colSeleccion"].Value) == 1 && Convert.ToInt32(fila.Cells["id_equipos_estados"].Value) != Convert.ToInt32(Equipos.Equipos_Estados.ASIGNADO_A_USUARIO) && Convert.ToInt32(fila.Cells["id_equipos_estados"].Value) != Convert.ToInt32(Equipos.Equipos_Estados.ASIGNADO_A_DEPARTAMENTO))
                        {
                            oEquipo.Eliminar(Convert.ToInt32(fila.Cells["id"].Value));
                        }
                    }

                    comenzarCarga();
                }
            }
            else
                MessageBox.Show("No se han seleccionado equipos.");
        }



        private void cancelarEdicion()
        {
            controles(false);
        }

        private bool ColumnasSeleccionadas()
        {
            bool Resultado = false;


            if (dgv.Rows.Count > 0)
            {
                foreach (DataGridViewRow fila in dgv.Rows)
                {
                    if (Convert.ToInt32(fila.Cells["colSeleccion"].Value) == 1)
                    {
                        Resultado = true;

                        break;
                    }
                }
            }

            return Resultado;
        }

        private void AsignarTarjeta()
        {
            int IdTarjetaAnterior;
            frmBusquedaTarjetasEquipos frmBusquedaTarjetas = new frmBusquedaTarjetasEquipos(Convert.ToInt32(dgv.SelectedRows[0].Cells["id_equipos_tipos"].Value), Convert.ToInt32(Equipos_Tarjetas.Tarjetas_Estados.DISPONIBLE));
            frmBusquedaTarjetas.id_usuario_actual = 0;
            frmPopUp frmpopup = new frmPopUp();
            frmpopup.Maximizar = false;
            frmpopup.Formulario = frmBusquedaTarjetas;
            frmpopup.ShowDialog();
            if (frmBusquedaTarjetas.DialogResult == DialogResult.OK)
            {
                IdTarjetaAnterior = Convert.ToInt32(dgv.SelectedRows[0].Cells["id_tarjeta"].Value);
                oEquiposTarjetas.AsignarTarjetaEquipo(Convert.ToInt32(dgv.SelectedRows[0].Cells["id"].Value), frmBusquedaTarjetas.IdTarjeta);
                oEquiposTarjetas.CambiarEstadoTarjeta(frmBusquedaTarjetas.IdTarjeta, Convert.ToInt32(Equipos_Tarjetas.Tarjetas_Estados.ENTREGADA));
                if (IdTarjetaAnterior != 0)
                    oEquiposTarjetas.CambiarEstadoTarjeta(IdTarjetaAnterior, Convert.ToInt32(Equipos_Tarjetas.Tarjetas_Estados.CON_FALLA));
                comenzarCarga();
            }

        }

        private void ColorearGrilla()
        {
            int EstadoEquipo;
            foreach (DataGridViewRow fila in dgv.Rows)
            {
                EstadoEquipo = Convert.ToInt32(fila.Cells["id_equipos_estados"].Value);
                if (EstadoEquipo == Convert.ToInt32(Equipos.Equipos_Estados.DISPONIBLE_EN_STOCK))
                    fila.DefaultCellStyle.BackColor = Color.LightGreen;
                else
                {
                    if (EstadoEquipo == Convert.ToInt32(Equipos.Equipos_Estados.EN_REPARACION))
                        fila.DefaultCellStyle.BackColor = Color.Tomato;
                    else
                        if ((EstadoEquipo == Convert.ToInt32(Equipos.Equipos_Estados.ASIGNADO_A_USUARIO)) || (EstadoEquipo == Convert.ToInt32(Equipos.Equipos_Estados.ASIGNADO_A_DEPARTAMENTO)))
                        fila.DefaultCellStyle.BackColor = Color.DarkGray;
                    else
                        fila.DefaultCellStyle.BackColor = Color.LightBlue;

                }

            }
        }

        private void DeshabilitaBtnGrillaVacia()
        {
            btnActualizar.Enabled = false;
            btnAsignarTarjeta.Enabled = false;
            btnDatosConfig.Enabled = false;
            btnHistorial.Enabled = false;
            btnEliminar.Enabled = false;
            btnEditar.Enabled = false;
            btnCambioEstado.Enabled = false;
            lblDisponible.Enabled = false;
            lblAsignado.Enabled = false;
            lblReparacion.Enabled = false;
            lblEnProceso.Enabled = false;
        }

        private void ABMEquipos_Load(object sender, EventArgs e)
        {
            dgv.ReadOnly = false;
            txtBuscar.Enabled = false;
            checkBox1.Enabled = false;
            txtMac.ForeColor = Color.LightGray;
            label7.ForeColor = Color.LightGray;

            if (dgv.Rows.Count == 0)
                DeshabilitaBtnGrillaVacia();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            controles(false);
            comenzarCarga();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            nuevoRegistro();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            EditarRegistro();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminarRegistro();
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cancelarEdicion();
        }

        private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            VerificarTarjeta();
        }

        private void ABMEquipos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCambioEstado_Click(object sender, EventArgs e)
        {
            if (ColumnasSeleccionadas() == true)
            {
                frmCambioEstadoEquipos frmCambioEstado = new frmCambioEstadoEquipos();
                frmPopUp frmpopup = new frmPopUp();
                frmpopup.Maximizar = false;
                frmpopup.Formulario = frmCambioEstado;
                frmpopup.ShowDialog();
                int idEstadoNuevo, idEstadoViejo, idEstadoActual, idEquipo;
                idEstadoNuevo = frmCambioEstado.idEstadoDevuelto;
                Boolean seleccionado;
                string salida;
                if (frmCambioEstado.DialogResult == DialogResult.OK)
                {
                    if (MessageBox.Show("Puede que algunos equipos que haya seleccionado se encuentren asignados a usuarios. En estos casos, el estado no cambiará. ¿Desea continuar?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        foreach (DataGridViewRow fila in dgv.Rows)
                        {
                            seleccionado = Convert.ToBoolean(fila.Cells["colSeleccion"].Value);
                            idEstadoActual = Convert.ToInt32(fila.Cells["id_equipos_estados"].Value);
                            idEquipo = Convert.ToInt32(fila.Cells["id"].Value);
                            if (seleccionado == true)
                            {
                                if (frmCambioEstado.idEstadoDevuelto != Convert.ToInt32(Equipos.Equipos_Estados.ASIGNADO_A_USUARIO) || frmCambioEstado.idEstadoDevuelto != Convert.ToInt32(Equipos.Equipos_Estados.ASIGNADO_A_DEPARTAMENTO))
                                    oEquipo.CambiarEstado(idEquipo, idEstadoNuevo,out salida);
                            }
                        }
                        comenzarCarga();
                    }
                }
            }
            else
                MessageBox.Show("No se han seleccionado equipos.");
        }

        private void btnAsignarTarjeta_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
                AsignarTarjeta();
            else
                MessageBox.Show("No se ha seleccionado un equipo.");
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtBuscar.Text))
                dtEquipos.DefaultView.RowFilter = "id>0";
            else
                dtEquipos.DefaultView.RowFilter = String.Format("tipo like '%{0}%' or  marca like '%{0}%' or modelo like '%{0}%' or serie like '%{0}%' or mac like '%{0}%' or usuario like '%{0}%' or estado like '%{0}%' or calle like '%{0}%' or numero like '%{0}%'", txtBuscar.Text);
            ColorearGrilla();
        }

        private void dgv_Sorted(object sender, EventArgs e)
        {
            ColorearGrilla();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            VerificarTarjeta();
        }

        private void lblDisponible_Click(object sender, EventArgs e)
        {
            dtEquipos = DtEquiposAux;
            DtvEquipos = new DataView(dtEquipos);
            DtvEquipos.RowFilter = String.Format("id_equipos_estados={0}", Convert.ToInt32(Equipos.Equipos_Estados.DISPONIBLE_EN_STOCK));
            dtEquipos = DtvEquipos.ToTable();
            dgv.DataSource = dtEquipos;
            ColorearGrilla();
        }

        private void lblAsignado_Click(object sender, EventArgs e)
        {
            dtEquipos = DtEquiposAux;
            DtvEquipos = new DataView(dtEquipos);
            DtvEquipos.RowFilter = String.Format("id_equipos_estados={0}", Convert.ToInt32(Equipos.Equipos_Estados.ASIGNADO_A_USUARIO));
            dtEquipos = DtvEquipos.ToTable();
            dgv.DataSource = dtEquipos;
            lblTotal.Text = "Total de equipos asignados: " + DtvEquipos.Count;

            ColorearGrilla();
        }

        private void lblReparacion_Click(object sender, EventArgs e)
        {
            dtEquipos = DtEquiposAux;
            DtvEquipos = new DataView(dtEquipos);
            DtvEquipos.RowFilter = String.Format("id_equipos_estados={0}", Convert.ToInt32(Equipos.Equipos_Estados.EN_REPARACION));
            dtEquipos = DtvEquipos.ToTable();
            dgv.DataSource = dtEquipos;
            ColorearGrilla();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            VerificarTarjeta();
        }
        private void VerificarTarjeta()
        {
            if (dgv.SelectedRows.Count > 0)
            {
                if (dgv.SelectedRows[0].Cells["requiere_tarjeta"].Value.ToString() == "SI" && Convert.ToInt32(dgv.SelectedRows[0].Cells["id_equipos_estados"].Value) != Convert.ToInt32(Equipos.Equipos_Estados.EN_PROCESO_DE_ASIGNACION))
                    btnAsignarTarjeta.Enabled = true;
                else
                    btnAsignarTarjeta.Enabled = false;
            }
        }

        private void lblEnProceso_Click(object sender, EventArgs e)
        {
            dtEquipos = DtEquiposAux;
            DtvEquipos = new DataView(dtEquipos);
            DtvEquipos.RowFilter = String.Format("id_equipos_estados={0}", Convert.ToInt32(Equipos.Equipos_Estados.EN_PROCESO_DE_ASIGNACION));
            dtEquipos = DtvEquipos.ToTable();
            dgv.DataSource = dtEquipos;
            ColorearGrilla();
        }

        private void btnDatosConfig_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 0)
            {
                if (dgv.SelectedRows.Count > 0)
                {
                    if (oEquipo_Tipos.VerificarRequerimientoConfig(Convert.ToInt32(dgv.SelectedRows[0].Cells["id_equipos_tipos"].Value)))
                    {
                        Partes_Trabajo.frmDatosConfiguracionEquipo frmDatosConfig = new Partes_Trabajo.frmDatosConfiguracionEquipo(Convert.ToInt32(dgv.SelectedRows[0].Cells["id"].Value), "", "", "");
                        frmPopUp frmPU = new frmPopUp();
                        frmPU.Formulario = frmDatosConfig;
                        frmPU.Maximizar = false;
                        frmPU.ShowDialog();
                    }
                }
                else
                    MessageBox.Show("No se ha seleccionado equipo.");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtMac.Location = txtBuscar.Location;
                txtMac.Visible = true;
                txtBuscar.Visible = false;
            }
            else
            {
                txtMac.Visible = false;
                txtBuscar.Visible = true;
            }
        }

        private void txtMac_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtMac.Text))
                dtEquipos.DefaultView.RowFilter = "id>0";
            else
                dtEquipos.DefaultView.RowFilter = String.Format("mac ='{0}'", txtMac.Text);
            ColorearGrilla();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            comenzarCarga();
            txtBuscar.Enabled = true;
            checkBox1.Enabled = true;
            txtMac.ForeColor = Color.Black;
            label7.ForeColor = Color.Black;
            ColorearGrilla();
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            DataRow[] dr = dtEquipos.Select(String.Format("Id = {0}", dgv.SelectedRows[0].Cells["Id"].Value.ToString()));
            using (frmPopUp frm = new frmPopUp())
            {
                frmHistorialAsignacionEquipos frmHistorial = new frmHistorialAsignacionEquipos();
                frmHistorial.DataRow = dr[0];
                frm.Formulario = frmHistorial;
                frm.Maximizar = false;

                if (frm.ShowDialog() == DialogResult.OK)
                    cargarDatos();
            }
        }
    }
}
