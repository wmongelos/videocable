using CapaNegocios;
using CapaPresentacion.Busquedas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Partes_Trabajo
{
    public partial class frmAsignacionTiposEquipos : Form
    {
        private Thread hilo;
        private delegate void myDel();
        public int idParteSeleccionado = 0;
        DataRow drDatosParte;
        DataTable dtPartesEquipos;
        DataTable dtEquiposTipos;
        Partes oParte = new Partes();
        Partes_Equipos oPartesEquipos = new Partes_Equipos();
        Equipos_Tipos oEquiposTipos = new Equipos_Tipos();
        List<int> listaEstados = new List<int>();
        int config_agenda;
        Configuracion oConfig = new Configuracion();
        Equipos oEquipos = new Equipos();
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
                if (idParteSeleccionado != 0)
                {
                    drDatosParte = oParte.TraerParteRow(idParteSeleccionado);

                    if (drDatosParte != null)
                    {
                        dtPartesEquipos = oPartesEquipos.ListarPorParte(idParteSeleccionado);
                        dtEquiposTipos = oEquiposTipos.ListarPorTipoServicios(Convert.ToInt32(drDatosParte["id_servicios_tipos"]));
                    }
                }
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

            if (drDatosParte != null)
            {

                lblParteSeleccionado.Text = String.Format("Parte seleccionado: {0}", idParteSeleccionado);
                lblUsuario.Text = String.Format("Usuario: {0} {1}", drDatosParte["apellido"], drDatosParte["nombre"]);
                lblServicio.Text = String.Format("Servicio: {0}", drDatosParte["servicio"]);

                cboEquipos_Tipos.DataSource = dtEquiposTipos;
                cboEquipos_Tipos.DisplayMember = "nombre";
                cboEquipos_Tipos.ValueMember = "id";
                dgv.DataSource = dtPartesEquipos;
                for (int x = 0; x < dgv.Columns.Count; x++)
                    dgv.Columns[x].Visible = false;
                dgv.Columns["id"].Visible = true;
                dgv.Columns["tipo_equipo"].Visible = true;
                dgv.Columns["serie"].Visible = true;
                dgv.Columns["mac"].Visible = true;

                dgv.Columns["id"].HeaderText = "Código";
                dgv.Columns["tipo_equipo"].HeaderText = "Tipo de equipo";
                dgv.Columns["serie"].HeaderText = "N° Serie";
                dgv.Columns["mac"].HeaderText = "N° MAC";

                AsignarValores();
                controles(true);

            }
            else
                MessageBox.Show("Error al traer los datos del parte.");



        }

        private void AsignarValores()
        {
            try
            {
                txtId.Text = dgv.SelectedRows[0].Cells["id"].Value.ToString();
                cboEquipos_Tipos.SelectedValue = Convert.ToInt32(dgv.SelectedRows[0].Cells["id_equipos_tipos"].Value);
            }
            catch { }

        }

        private void BuscarParte()
        {
            try
            {
                listaEstados.Add(Convert.ToInt32(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_EQUIPO));
                listaEstados.Add(Convert.ToInt32(Partes.Partes_Estados.ASIGNADO));
                frmBusquedaPartes frmBuscarParte = new frmBusquedaPartes();
                frmBuscarParte.AsignarListaEstados(listaEstados);
                frmPopUp frmpopup = new frmPopUp();
                frmpopup.Formulario = frmBuscarParte;
                frmpopup.Maximizar = false;
                frmpopup.ShowDialog();
                if (frmpopup.DialogResult == DialogResult.OK)
                {
                    idParteSeleccionado = frmBuscarParte.id_parte_seleccionado;
                    comenzarCarga();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al traer datos del parte.");
            }
        }

        private void Guardar()
        {
            try
            {
                oPartesEquipos.Id = Convert.ToInt32(txtId.Text);
                oPartesEquipos.Id_Equipos_Tipos = Convert.ToInt32(cboEquipos_Tipos.SelectedValue);
                oPartesEquipos.Id_Partes = idParteSeleccionado;
                oPartesEquipos.Id_Usuarios = Convert.ToInt32(drDatosParte["id_usuarios"]);
                oPartesEquipos.Id_Usuarios_Servicios = Convert.ToInt32(drDatosParte["id_usuarios_servicios"]);
                oPartesEquipos.Id_Servicios = Convert.ToInt32(drDatosParte["id_servicios"]);
                oPartesEquipos.Guardar(oPartesEquipos);
                oParte.SetearEstadoParte(oParte.Id, 0, 0, DateTime.Now, 0, 0, "");
                comenzarCarga();
            }
            catch
            {
                MessageBox.Show("Error al guardar tipo de equipo.");
            }
        }

        private void Eliminar()
        {
            oPartesEquipos.Eliminar(Convert.ToInt32(dgv.SelectedRows[0].Cells["id"].Value));
            int idEquipo = Convert.ToInt32(dgv.SelectedRows[0].Cells["id_equipos"].Value);
            string salida = "";

            if (idEquipo > 0)
                oEquipos.CambiarEstado(idEquipo, Convert.ToInt32(Equipos.Equipos_Estados.DISPONIBLE_EN_STOCK),out salida);


        }

        private void controles(bool state)
        {
            btnActualizar.Enabled = state;
            btnNuevo.Enabled = state;

            btnEliminar.Enabled = state;
            btnEditar.Enabled = state;


            btnGuardar.Enabled = !state;
            btnCancelar.Enabled = !state;



            cboEquipos_Tipos.Enabled = !state;
        }

        private void limpiarValores()
        {
            try
            {
                txtId.Text = "0";
                txtId.Tag = "";

                cboEquipos_Tipos.SelectedValue = Convert.ToInt32(dtEquiposTipos.Rows[0]["id"]);
            }
            catch
            {
                MessageBox.Show("Error. Controle que haya tipos de equipos cargados para el servicio del parte.");
            }
        }

        private void AsignarEquipoPE()
        {
            /*  if (oEquipos.ConsultarDisponibilidad(Convert.ToInt32(dgv.SelectedRows[0].Cells["id_equipos_tipos"].Value),1)==true)
              {
                  int idEquipoActual = Convert.ToInt32(dgv.SelectedRows[0].Cells["id_equipos"].Value);

                  frmBusquedaEquipos frm = new frmBusquedaEquipos(Convert.ToInt32(dgv.SelectedRows[0].Cells["id"].Value), Convert.ToInt32(dgv.SelectedRows[0].Cells["id_usuarios_servicios"].Value), Convert.ToInt32(dgv.SelectedRows[0].Cells["id_servicios"].Value), Convert.ToInt32(dgv.SelectedRows[0].Cells["id_usuarios"].Value), Convert.ToInt32(dgv.SelectedRows[0].Cells["id_equipos_tipos"].Value),0);

                  frmPopUp frmPop = new frmPopUp();

                  frmPop.Formulario = frm;
                  frmPop.Maximizar = false;

                  if (frmPop.ShowDialog() == DialogResult.OK)
                  {
                      int cantAsignados = 0;
                      lblParteSeleccionado.Text = "";
                      DataTable CantidadPartesEquipos = oPartesEquipos.ListarPorParte(oPartesEquipos.Id_Partes);
                      cantAsignados = CantidadPartesEquipos.Select("id_equipos>0").Length;

                      if (CantidadPartesEquipos.Rows.Count == cantAsignados)
                      {
                          if (config_agenda == Convert.ToInt32(Agenda_Encabezado.Uso_agenda.TRABAJA_CON_AGENDA))
                              oParte.ActualizarEstado(idParteSeleccionado, Convert.ToInt32(Partes.Partes_Estados.ASIGNADO));
                          else
                              oParte.ActualizarEstado(idParteSeleccionado, Convert.ToInt32(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_TECNICO));
                      }

                      if (idEquipoActual > 0)
                          oEquipos.CambiarEstado(idEquipoActual, Convert.ToInt32(Equipos.Equipos_Estados.DISPONIBLE_EN_STOCK));


                      comenzarCarga();
                  }
              }
              else
                  MessageBox.Show("No hay equipos disponibles para asignar. Ingrese nuevos equpos al sistema en la sección de equipos del menú principal.");

      */
        }

        private void QuitarEquipoPE()
        {
            int idEquipoActual = Convert.ToInt32(dgv.SelectedRows[0].Cells["id_equipos"].Value);

            if (idEquipoActual > 0)
            {
                DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea eliminar la asignación de equipo al registro?", "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    oPartesEquipos.QuitarEquipoAsignado(Convert.ToInt32(dgv.SelectedRows[0].Cells["id"].Value), idEquipoActual);
                    comenzarCarga();
                }
            }
            else
                MessageBox.Show("El registro no tiene un equipo asignado.");
        }

        public frmAsignacionTiposEquipos(int idParteRecibido)
        {
            idParteSeleccionado = idParteRecibido;
            InitializeComponent();
        }

        private void frmAsignacionTiposEquipos_Load(object sender, EventArgs e)
        {
            config_agenda = oConfig.GetValor_N("Agenda_Trabajo");
            if (idParteSeleccionado != 0)
                comenzarCarga();

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarParte();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (idParteSeleccionado != 0)
                comenzarCarga();
        }

        private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            AsignarValores();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (idParteSeleccionado != 0)
            {
                controles(false);
                limpiarValores();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un parte.");
                btnBuscar.Focus();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 0)
                controles(false);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 0)
            {
                if (Convert.ToInt32(dgv.SelectedRows[0].Cells["id_equipos"].Value) == 0)
                {
                    DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea eliminar la asignación de tipo de equipo?", "", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        try
                        {
                            Eliminar();
                            comenzarCarga();
                        }
                        catch
                        {
                            MessageBox.Show("Error al eliminar asignación.");
                        }
                    }

                }
                else
                    MessageBox.Show("No se puede eliminar ya que tiene un equipo asignado.");

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            controles(true);
            dgv.Enabled = true;
        }

        private void btnAsignarEquipo_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 0)
                AsignarEquipoPE();
            else
                MessageBox.Show("Debe seleccionar un registro de la grilla.");


        }

        private void btnQuitarEquipo_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 0)
                QuitarEquipoPE();
            else
                MessageBox.Show("Debe seleccionar un registro de la grilla.");


        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            if (idParteSeleccionado > 0)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
                this.Close();
        }

        private void frmAsignacionTiposEquipos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (idParteSeleccionado > 0)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                    this.Close();
            }
        }


    }
}
