using CapaNegocios;
using CapaPresentacion.Busquedas;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacion
{

    public partial class frmUsuariosEquipos : Form
    {
        #region DECLARACIONES
        private Equipos Oequipos = new Equipos();
        private Servicios oServicios = new Servicios();
        private Equipos_Tarjetas oEquiposTarjetas = new Equipos_Tarjetas();
        private Isp oISP = new Isp();
        private Aplicaciones_Externas oAppExterna = new Aplicaciones_Externas();
        private DataTable dtDatosAppExterna = new DataTable();
        private DataTable dtEquipos = new DataTable();
        private DataTable dtDatosServicio = new DataTable();
        private DataTable dtAccessAccount = new DataTable();
        private Int32 IdUsuariosServicios, codUsuario, idServicio, idAppExterna, idUsuarioLocacion, idEquipment = 0, idAccessAccount, idCustomer, idLocation;
        private string nombreServicio;
        private Partes_Equipos oparteEqui = new Partes_Equipos();
        private DataTable dtTarjetaAsociada = new DataTable();
        public bool tieneTarjeta = false;

        Cass oCass;
        DataTable dtAplicacionesFiltradas = Tablas.DataCass;

        #endregion
        public frmUsuariosEquipos(Int32 idUsuarioServicio, Int32 codUsuario, Int32 idServicio, Int32 idUsuarioLocacion)
        {
            this.IdUsuariosServicios = idUsuarioServicio;
            this.codUsuario = codUsuario;
            this.idServicio = idServicio;
            this.idUsuarioLocacion = idUsuarioLocacion;

            InitializeComponent();
            ComenzarCarga();
        }

        private void ComenzarCarga()
        {
            dtEquipos.Clear();

            dtEquipos = Oequipos.BuscarEquipoPorUsuarioServicio(IdUsuariosServicios);
            dtEquipos.Columns.Add("app_externa", typeof(string));

            if (dtEquipos.Rows.Count == 0)
                dtTarjetaAsociada = oparteEqui.ListarPorUsuarioServicio(this.IdUsuariosServicios);

            if (dtTarjetaAsociada.Rows.Count > 0)
                tieneTarjeta = true;

            dtDatosServicio = oServicios.BuscarDatosServicio(this.idServicio);
            nombreServicio = dtDatosServicio.Rows[0]["descripcion"].ToString();
            idAppExterna = Convert.ToInt32(dtDatosServicio.Rows[0]["id_aplicaciones_externas"]);
            if (idAppExterna > 0)
            {
                dtDatosAppExterna = oAppExterna.Listar(idAppExterna);
                if (dtDatosServicio.Rows.Count > 0)
                {
                    if (dtDatosAppExterna.Rows[0]["nombre"].ToString() == "ISP")
                    {
                        Isp.cadenaConexion = dtDatosAppExterna.Rows[0]["string_conexion"].ToString();
                        foreach (DataRow item in dtEquipos.Rows)
                        {
                            idEquipment = oISP.VerificarExisteEquipo(item["mac"].ToString(), "");
                            if (idEquipment > 0)
                            {
                                idCustomer = oISP.VerificarExisteUsuario(this.codUsuario);
                                idLocation = oISP.VerificarExisteLocacion(this.idUsuarioLocacion);
                                dtAccessAccount = oISP.ListarAccessAccountPorCustomerLocation(idCustomer, idLocation);
                                if (dtAccessAccount.Rows.Count > 0)
                                {
                                    idAccessAccount = Convert.ToInt32(dtAccessAccount.Rows[0]["account_id"]);
                                    if (Convert.ToInt32(dtAccessAccount.Rows[0]["enabled"]) == 1)
                                        item["app_externa"] = string.Format("EQUIPO REGISTRADO EN {0}", dtDatosAppExterna.Rows[0]["nombre"].ToString());
                                    else
                                        item["app_externa"] = string.Format("EQUIPO NO REGISTRADO EN {0}", dtDatosAppExterna.Rows[0]["nombre"].ToString());

                                }
                                else
                                {
                                    idAccessAccount = oISP.obtenerIdAccesAccount(idEquipment);
                                    if (idAccessAccount > 0)
                                        item["app_externa"] = string.Format("EQUIPO REGISTRADO EN {0}", dtDatosAppExterna.Rows[0]["nombre"].ToString());
                                    else
                                        item["app_externa"] = string.Format("EQUIPO NO REGISTRADO EN {0}", dtDatosAppExterna.Rows[0]["nombre"].ToString());

                                }

                            }
                            else
                                item["app_externa"] = string.Format("EQUIPO NO REGISTRADO EN {0}", dtDatosAppExterna.Rows[0]["nombre"].ToString());

                            dtEquipos.AcceptChanges();
                        }

                    }

                }
            }

            AsignarDatos();

        }

        private void AsignarDatos()
        {

            lblCantidad.Text = string.Format("Cantidad de equipos: {0}", dtEquipos.Rows.Count);
            lblServicio.Text = nombreServicio;
            lblServicio.Location = new System.Drawing.Point(this.Width - lblServicio.Width - 10, lblServicio.Location.Y);
            dgvEquipos.DataSource = dtEquipos;
            for (int x = 0; x < dgvEquipos.Columns.Count; x++)
                dgvEquipos.Columns[x].Visible = false;

            dgvEquipos.Columns["serie"].Visible = true;
            dgvEquipos.Columns["mac"].Visible = true;
            dgvEquipos.Columns["marca"].Visible = true;
            dgvEquipos.Columns["modelo"].Visible = true;
            dgvEquipos.Columns["numtarjeta"].Visible = true;
            dgvEquipos.Columns["estado"].Visible = true;
            dgvEquipos.Columns["equipo_usuario"].Visible = true;
            dgvEquipos.Columns["equipo_clave"].Visible = true;
            dgvEquipos.Columns["equipo_ip"].Visible = true;
            if (dtDatosAppExterna.Rows.Count > 0)
            {
                if (dtDatosAppExterna.Rows[0]["nombre"].ToString() == "ISP")
                {
                    dgvEquipos.Columns["app_externa"].Visible = true;
                    dgvEquipos.Columns["app_externa"].HeaderText = "Aplicacion Externa";
                    dgvEquipos.Columns["app_externa"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                }
            }
            dgvEquipos.Columns["equipo_ip"].Visible = true;
            dgvEquipos.Columns["serie"].HeaderText = "Serie";
            dgvEquipos.Columns["mac"].HeaderText = "Mac";
            dgvEquipos.Columns["marca"].HeaderText = "Marca";
            dgvEquipos.Columns["modelo"].HeaderText = "Modelo";
            dgvEquipos.Columns["equipo_usuario"].HeaderText = "Usuario de Equipo";
            dgvEquipos.Columns["equipo_clave"].HeaderText = "Clave de Equipo";
            dgvEquipos.Columns["equipo_ip"].HeaderText = "IP de Equipo";
            dgvEquipos.Columns["numtarjeta"].HeaderText = "Tarjeta asignada";
            dgvEquipos.Columns["estado"].HeaderText = "Estado";
        }

        private void btnAsignarEquipo_Click(object sender, EventArgs e)
        {
            AsignarEquipo();
        }

        private void AsignarEquipo()
        {
            frmPopUp oPop = new frmPopUp();
            frmResponsable frmre = new frmResponsable();
            oPop.Formulario = frmre;
            oPop.Maximizar = false;
            if (oPop.ShowDialog() == DialogResult.OK)
            {
                using (frmPopUp frm = new frmPopUp())
                {
                    frmBusquedaEquipos frmBusqueda = new frmBusquedaEquipos(0, 0, this.IdUsuariosServicios, 0, 0, 0);
                    if (tieneTarjeta == true)
                        frmBusqueda.idTarjeta = Convert.ToInt32(dtTarjetaAsociada.Rows[0]["id_tarjeta"]);
                    else
                        frmBusqueda.idTarjeta = 0;
                    frm.Formulario = frmBusqueda;
                    frm.Maximizar = false;
                    frm.ShowDialog();
                }
            }
        }

        private void btnCass_Click(object sender, EventArgs e)
        {
            using (frmPopUp frm = new frmPopUp())
            {
                string tarjeta = dgvEquipos.Rows.Count > 0 ? dgvEquipos.SelectedRows[0].Cells["numtarjeta"].Value.ToString() : "";



                frm.Formulario = new FrmCass(tarjeta, IdUsuariosServicios);
                frm.Maximizar = false;
                frm.ShowDialog();
            }
        }

        private void AsignarValores()
        {
            try
            {
                lblEquipoSeleccionado.Text = String.Format("Equipo seleccionado: Serie {0}, Mac {1}", dgvEquipos.CurrentRow.Cells["serie"].Value, dgvEquipos.CurrentRow.Cells["mac"].Value);
               //if (dgvEquipos.CurrentRow.Cells["requiere_tarjeta"].Value.ToString() == "SI" && Convert.ToInt32(dgvEquipos.CurrentRow.Cells["id_equipos_estados"].Value) != Convert.ToInt32(Equipos.Equipos_Estados.EN_PROCESO_DE_ASIGNACION))
                 if (dgvEquipos.CurrentRow.Cells["requiere_tarjeta"].Value.ToString() == "SI")
                        btnAsignarTarjeta.Enabled = true;
                else
                    btnAsignarTarjeta.Enabled = false;
            }
            catch
            { }
        }

        private void AsignarTarjeta()
        {
            int IdTarjetaAnterior = 0;
            oCass = new Cass(Convert.ToInt32(dtAplicacionesFiltradas.Rows[0]["Id"]));
            frmBusquedaTarjetasEquipos frmBusquedaTarjetas = new frmBusquedaTarjetasEquipos(Convert.ToInt32(dgvEquipos.SelectedRows[0].Cells["id_equipos_tipos"].Value), Convert.ToInt32(Equipos_Tarjetas.Tarjetas_Estados.DISPONIBLE));
            frmBusquedaTarjetas.id_usuario_actual = Usuarios.CurrentUsuario.Id;
            frmPopUp frmpopup = new frmPopUp();
            frmpopup.Maximizar = false;
            frmpopup.Formulario = frmBusquedaTarjetas;
            frmpopup.ShowDialog();
            if (frmBusquedaTarjetas.DialogResult == DialogResult.OK)
            {
                IdTarjetaAnterior = Convert.ToInt32(dgvEquipos.SelectedRows[0].Cells["id_tarjeta"].Value);
                oEquiposTarjetas.AsignarTarjetaEquipo(Convert.ToInt32(dgvEquipos.SelectedRows[0].Cells["id"].Value), frmBusquedaTarjetas.IdTarjeta);
                oEquiposTarjetas.CambiarEstadoTarjeta(frmBusquedaTarjetas.IdTarjeta, Convert.ToInt32(Equipos_Tarjetas.Tarjetas_Estados.ENTREGADA));
                oEquiposTarjetas.CambiarEstadoTarjeta(IdTarjetaAnterior, Convert.ToInt32(Equipos_Tarjetas.Tarjetas_Estados.CON_FALLA));
                ComenzarCarga();
            }
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUsuariosEquipos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }



        private void dgvEquipos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            AsignarValores();
        }

        private void btnAsignarTarjeta_Click(object sender, EventArgs e)
        {
            AsignarTarjeta();
        }

        private void frmUsuariosEquipos_Load(object sender, EventArgs e)
        {

        }

        private void btnDesafectar_Click(object sender, EventArgs e)
        {
            if (dgvEquipos.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Se procedera a desafectar el equipo al usuario, esto podria afectar a aplicaciones externas. ¿Desea continuar?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dtDatosServicio = oServicios.BuscarDatosServicio(this.idServicio);
                    idAppExterna = Convert.ToInt32(dtDatosServicio.Rows[0]["id_aplicaciones_externas"]);
                    if (idAppExterna > 0)
                    {


                        dtDatosAppExterna = oAppExterna.Listar(idAppExterna);
                        if (dtDatosAppExterna.Rows[0]["nombre"].ToString() == "ISP")
                        {
                            idCustomer = 0;
                            idLocation = 0;
                            idEquipment = 0;
                            dtAccessAccount = new DataTable();
                            Isp.cadenaConexion = dtDatosAppExterna.Rows[0]["string_conexion"].ToString();
                            idCustomer = oISP.VerificarExisteUsuario(this.codUsuario);
                            idLocation = oISP.VerificarExisteLocacion(this.idUsuarioLocacion);
                            idEquipment = oISP.VerificarExisteEquipo(dgvEquipos.SelectedRows[0].Cells["mac"].Value.ToString(), "");
                            if (idEquipment > 0)
                            {
                                dtAccessAccount = oISP.ListarAccessAccountPorCustomerLocation(idCustomer, idLocation);
                                idAccessAccount = Convert.ToInt32(dtAccessAccount.Rows[0]["account_id"]);
                                if (idAccessAccount > 0)
                                {
                                    if (oISP.DesafectarEquipo(idAccessAccount, idEquipment) == 0)
                                    {
                                        MessageBox.Show("Equipo desafectado correctamente de ISP", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        if (Oequipos.EliminarRelacionEquipoServicio(Convert.ToInt32(dgvEquipos.SelectedRows[0].Cells["id"].Value)) == 0)
                                            MessageBox.Show("Equipo desafectado correctamente de GIES", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        else
                                            MessageBox.Show("Error al intentar desafectar equipo de GIES", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                    }
                                    else
                                        MessageBox.Show("Error al intentar desafectar equipo de isp", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    idAccessAccount = oISP.obtenerIdAccesAccount(idEquipment);
                                    if (idAccessAccount > 0)
                                    {
                                        if (oISP.DesafectarEquipo(idAccessAccount, idEquipment) == 0)
                                        {
                                            MessageBox.Show("Equipo desafectado correctamente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            if (Oequipos.EliminarRelacionEquipoServicio(Convert.ToInt32(dgvEquipos.SelectedRows[0].Cells["id"].Value)) == 0)
                                                MessageBox.Show("Equipo desafectado correctamente de GIES", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            else
                                                MessageBox.Show("Error al intentar desafectar equipo de GIES", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                        else
                                            MessageBox.Show("Error al intentar desafectar equipo de isp", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                            else
                            {
                                if (Oequipos.EliminarRelacionEquipoServicio(Convert.ToInt32(dgvEquipos.SelectedRows[0].Cells["id"].Value)) == 0)
                                    MessageBox.Show("Equipo desafectado correctamente de GIES", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            if (Oequipos.EliminarRelacionEquipoServicio(Convert.ToInt32(dgvEquipos.SelectedRows[0].Cells["id"].Value)) == 0)
                                MessageBox.Show("Equipo desafectado correctamente de GIES", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                MessageBox.Show("Error al intentar desafectar equipo de GIES", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        if (Oequipos.EliminarRelacionEquipoServicio(Convert.ToInt32(dgvEquipos.SelectedRows[0].Cells["id"].Value)) == 0)
                            MessageBox.Show("Equipo desafectado correctamente de GIES", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Error al intentar desafectar equipo de GIES", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    ComenzarCarga();
                }
            }
        }
    }
}

