using CapaNegocios;
using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Abms
{
    public partial class ABMPersonal : Form
    {
        #region PROPIEDADES
        private int Id;
        private Thread hilo;
        private delegate void myDel();
        private DataTable dt;
        private DataTable dtAreas;
        private DataTable dtPuntos;
        private DataTable dtRoles = new DataTable();
        private Personal oPersonal = new Personal();
        private Personal_Areas oPer_Areas = new Personal_Areas();
        private Puntos_Cobros oPuntos_Cobros = new Puntos_Cobros();
        private Personal_Roles oPersonal_Roles = new Personal_Roles();
        private int rowselect = 0;
        int hs1_hs_desde = 0;
        int hs1_mn_desde = 0;
        int hs1_hs_hasta = 0;
        int hs1_mn_hasta = 0;
        int hs2_hs_desde = 0;
        int hs2_mn_desde = 0;
        int hs2_hs_hasta = 0;
        int hs2_mn_hasta = 0;
        #endregion

        #region METODOS
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

                dtAreas = oPer_Areas.Listar();
                dtAreas.Rows.Add(0, "NINGUNA");

                DataView dtvAreas = dtAreas.DefaultView;
                dtvAreas.Sort = "Id ASC";
                dtAreas = dtvAreas.ToTable();

                dtRoles = oPersonal_Roles.Listar();
                dtRoles.Rows.Add(0, "NINGUNO");

                dt = oPersonal.Listar();

                dtPuntos = oPuntos_Cobros.Listar();

                dtPuntos.Rows.Add(0, "NINGUNO");

                DataView dtv = dtPuntos.DefaultView;
                dtv.Sort = "Id ASC";
                dtPuntos = dtv.ToTable();

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
            dgv.DataSource = dt;

            cboAreas.DataSource = dtAreas;
            cboAreas.DisplayMember = "Nombre";
            cboAreas.ValueMember = "Id";

            cboPuntosCobros.DataSource = dtPuntos;
            cboPuntosCobros.DisplayMember = "Descripcion";
            cboPuntosCobros.ValueMember = "Id";

            cboRoles.DataSource = dtRoles;
            cboRoles.DisplayMember = "Nombre";
            cboRoles.ValueMember = "Id";

            cboPuntosCobros.DisplayMember = "Nombre";
            cboPuntosCobros.ValueMember = "Id";

            for (int i = 0; i < dgv.Columns.Count; i++)
                dgv.Columns[i].Visible = false;

            dgv.Columns["Id"].Visible = false;
            dgv.Columns["Nombre"].Visible = true;
            dgv.Columns["Nombre"].HeaderText = "Nombre";
            dgv.Columns["Usuario"].Visible = true;
            dgv.Columns["Usuario"].HeaderText = "Usuario de Sistema";
            dgv.Columns["Area"].Visible = true;
            dgv.Columns["Area"].HeaderText = "Area";
            dgv.Columns["PuntoCobro"].Visible = true;
            dgv.Columns["PuntoCobro"].HeaderText = "Punto de Cobro";
            dgv.Columns["rol"].Visible = true;
            dgv.Columns["rol"].HeaderText = "Rol";

            lblTotal.Text = String.Format("Total de Registros: {0}", dt.Rows.Count);

            if (dgv.Rows.Count > 0)
                dgv.CurrentCell = dgv.Rows[rowselect].Cells[1];

            controles(false);
            bool state = false;
            spHorario1HS_Desde.Enabled = state;
            spHorario1HS_Hasta.Enabled = state;
            spHorario1MN_Desde.Enabled = state;
            spHorario1MN_Hasta.Enabled = state;
            spHorario2HS_Desde.Enabled = state;
            spHorario2HS_Hasta.Enabled = state;
            spHorario2MN_Desde.Enabled = state;
            spHorario2MN_Hasta.Enabled = state;
            spRango.Enabled = state;

            asignarValores();
        }

        private void controles(bool state)
        {
            btnActualizar.Enabled = !state;
            btnNuevo.Enabled = !state;
            btnEditar.Enabled = dt.Rows.Count == 0 ? false : !state;
            btnEliminar.Enabled = dt.Rows.Count == 0 ? false : !state;

            dgv.Enabled = !state;

            txtNombre.Enabled = state;
            txtClave.Enabled = state;
            cboPuntosCobros.Enabled = state;
            cboRoles.Enabled = state;
            chkDoble_turno.Enabled = state;
            chkUsuarioSistema.Enabled = state;
            cboAreas.Enabled = state;

            btnGuardar.Enabled = state;
            btnCancelar.Enabled = state;
        }

        private void limpiarValores()
        {
            Id = 0;
            txtNombre.Text = "";
            txtClave.Text = "";
            chkUsuarioSistema.Checked = false;
            spHorario1HS_Desde.Value = 0;
            spHorario1MN_Desde.Value = 0;
            spHorario1HS_Hasta.Value = 0;
            spHorario1MN_Hasta.Value = 0;
            spHorario2HS_Desde.Value = 0;
            spHorario2MN_Desde.Value = 0;
            spHorario2HS_Hasta.Value = 0;
            spHorario2MN_Hasta.Value = 0;
            spRango.Value = 0;
            chkDoble_turno.Checked = false;
        }

        private void asignarValores()
        {
            if (dgv.Rows.Count > 0)
            {
                if (dgv.SelectedRows.Count > 0)
                {
                    Id = Convert.ToInt32(dgv.SelectedRows[0].Cells["Id"].Value);
                    txtNombre.Text = dgv.SelectedRows[0].Cells["Nombre"].Value.ToString();

                    cboAreas.SelectedValue = dgv.SelectedRows[0].Cells["Id_Personal_Areas"].Value.ToString();
                    cboPuntosCobros.SelectedValue = dgv.SelectedRows[0].Cells["Id_Puntos_Cobros"].Value.ToString();
                    try
                    {
                        cboRoles.SelectedValue = dgv.SelectedRows[0].Cells["Id_Roles"].Value.ToString();
                    }
                    catch
                    {
                    }
                    chkUsuarioSistema.Checked = Convert.ToInt32(dgv.SelectedRows[0].Cells["Usuario_Sistema"].Value.ToString()) == 1 ? true : false;

                    txtClave.Text = dgv.SelectedRows[0].Cells["Clave"].Value.ToString();

                    try
                    {
                        chkDoble_turno.Checked = Convert.ToInt32(dgv.SelectedRows[0].Cells["Con_Doble_Turno"].Value.ToString()) == 1 ? true : false;
                    }
                    catch { }

                    try
                    {
                        hs1_hs_desde = Convert.ToInt32(dgv.SelectedRows[0].Cells["Hora_Inicio_1"].Value.ToString().Substring(0, 2));
                        hs1_mn_desde = Convert.ToInt32(dgv.SelectedRows[0].Cells["Hora_Inicio_1"].Value.ToString().Substring(3, 2));
                        hs1_hs_hasta = Convert.ToInt32(dgv.SelectedRows[0].Cells["Hora_Fin_1"].Value.ToString().Substring(0, 2));
                        hs1_mn_hasta = Convert.ToInt32(dgv.SelectedRows[0].Cells["Hora_Fin_1"].Value.ToString().Substring(3, 2));
                    }
                    catch
                    {
                        hs1_hs_desde = 0;
                        hs1_mn_desde = 0;
                        hs1_hs_hasta = 0;
                        hs1_mn_hasta = 0;
                    }
                    spHorario1HS_Desde.Value = hs1_hs_desde;
                    spHorario1MN_Desde.Value = hs1_mn_desde;
                    spHorario1HS_Hasta.Value = hs1_hs_hasta;
                    spHorario1MN_Hasta.Value = hs1_mn_hasta;

                    try
                    {
                        spRango.Value = Convert.ToInt32(dgv.SelectedRows[0].Cells["Rango"].Value.ToString());
                    }
                    catch
                    {
                        spRango.Value = 0;
                    }
                    if (chkDoble_turno.Checked)
                    {
                        try
                        {
                            hs2_hs_desde = Convert.ToInt32(dgv.SelectedRows[0].Cells["Hora_Inicio_2"].Value.ToString().Substring(0, 2));
                            hs2_mn_desde = Convert.ToInt32(dgv.SelectedRows[0].Cells["Hora_Inicio_2"].Value.ToString().Substring(3, 2));
                            hs2_hs_hasta = Convert.ToInt32(dgv.SelectedRows[0].Cells["Hora_Fin_2"].Value.ToString().Substring(0, 2));
                            hs2_mn_hasta = Convert.ToInt32(dgv.SelectedRows[0].Cells["Hora_Fin_2"].Value.ToString().Substring(3, 2));
                        }
                        catch
                        {
                            hs2_hs_desde = 0;
                            hs2_mn_desde = 0;
                            hs2_hs_hasta = 0;
                            hs2_mn_hasta = 0;
                        }
                        spHorario2HS_Desde.Value = hs2_hs_desde;
                        spHorario2MN_Desde.Value = hs2_mn_desde;
                        spHorario2HS_Hasta.Value = hs2_hs_hasta;
                        spHorario2MN_Hasta.Value = hs2_mn_hasta;
                    }
                    else
                    {
                        spHorario2HS_Desde.Value = spHorario2HS_Desde.Minimum;
                        spHorario2MN_Desde.Value = spHorario2MN_Desde.Minimum;
                        spHorario2HS_Hasta.Value = spHorario2HS_Hasta.Minimum;
                        spHorario2MN_Hasta.Value = spHorario2MN_Hasta.Minimum;
                    }
                }
                else
                {
                    Id = Convert.ToInt32(dgv.Rows[0].Cells["Id"].Value);
                    txtNombre.Text = dgv.Rows[0].Cells["Nombre"].Value.ToString();

                    cboAreas.SelectedValue = dgv.Rows[0].Cells["Id_Personal_Areas"].Value.ToString();
                    cboPuntosCobros.SelectedValue = dgv.Rows[0].Cells["Id_Puntos_Cobros"].Value.ToString();
                    try
                    {
                        cboRoles.SelectedValue = dgv.Rows[0].Cells["Id_Personal_Roles"].Value.ToString();
                    }
                    catch
                    { }
                    chkUsuarioSistema.Checked = Convert.ToInt32(dgv.Rows[0].Cells["Usuario_Sistema"].Value.ToString()) == 1 ? true : false;

                    txtClave.Text = dgv.Rows[0].Cells["Clave"].Value.ToString();

                    try
                    {
                        chkDoble_turno.Checked = Convert.ToInt32(dgv.Rows[0].Cells["Con_Doble_Turno"].Value.ToString()) == 1 ? true : false;
                    }
                    catch { }

                    try
                    {
                        hs1_hs_desde = Convert.ToInt32(dgv.Rows[0].Cells["Hora_Inicio_1"].Value.ToString().Substring(0, 2));
                        hs1_mn_desde = Convert.ToInt32(dgv.Rows[0].Cells["Hora_Inicio_1"].Value.ToString().Substring(3, 2));
                        hs1_hs_hasta = Convert.ToInt32(dgv.Rows[0].Cells["Hora_Fin_1"].Value.ToString().Substring(0, 2));
                        hs1_mn_hasta = Convert.ToInt32(dgv.Rows[0].Cells["Hora_Fin_1"].Value.ToString().Substring(3, 2));
                    }
                    catch
                    {
                        hs1_hs_desde = 0;
                        hs1_mn_desde = 0;
                        hs1_hs_hasta = 0;
                        hs1_mn_hasta = 0;
                    }
                    spHorario1HS_Desde.Value = hs1_hs_desde;
                    spHorario1MN_Desde.Value = hs1_mn_desde;
                    spHorario1HS_Hasta.Value = hs1_hs_hasta;
                    spHorario1MN_Hasta.Value = hs1_mn_hasta;

                    try
                    {
                        spRango.Value = Convert.ToInt32(dgv.Rows[0].Cells["Rango"].Value.ToString());
                    }
                    catch
                    {
                        spRango.Value = 0;
                    }
                    if (chkDoble_turno.Checked)
                    {
                        try
                        {
                            hs2_hs_desde = Convert.ToInt32(dgv.Rows[0].Cells["Hora_Inicio_2"].Value.ToString().Substring(0, 2));
                            hs2_mn_desde = Convert.ToInt32(dgv.Rows[0].Cells["Hora_Inicio_2"].Value.ToString().Substring(3, 2));
                            hs2_hs_hasta = Convert.ToInt32(dgv.Rows[0].Cells["Hora_Fin_2"].Value.ToString().Substring(0, 2));
                            hs2_mn_hasta = Convert.ToInt32(dgv.Rows[0].Cells["Hora_Fin_2"].Value.ToString().Substring(3, 2));
                        }
                        catch
                        {
                            hs2_hs_desde = 0;
                            hs2_mn_desde = 0;
                            hs2_hs_hasta = 0;
                            hs2_mn_hasta = 0;
                        }

                        spHorario2HS_Desde.Value = hs2_hs_desde;
                        spHorario2MN_Desde.Value = hs2_mn_desde;
                        spHorario2HS_Hasta.Value = hs2_hs_hasta;
                        spHorario2MN_Hasta.Value = hs2_mn_hasta;
                    }
                    else
                    {
                        spHorario2HS_Desde.Value = spHorario2HS_Desde.Minimum;
                        spHorario2MN_Desde.Value = spHorario2MN_Desde.Minimum;
                        spHorario2HS_Hasta.Value = spHorario2HS_Hasta.Minimum;
                        spHorario2MN_Hasta.Value = spHorario2MN_Hasta.Minimum;
                    }
                }
            }
        }

        private void nuevoRegistro()
        {
            txtNombre.Text = "";
            txtClave.Text = "";
            txtNombre.Enabled = true;
            chkUsuarioSistema.Enabled = true;
            chkUsuarioSistema.Checked = false;

            cboAreas.SelectedValue = "0";
            cboPuntosCobros.SelectedValue = "0";

            txtNombre.Focus();
        }

        private void editarRegistro()
        {
            rowselect = dgv.SelectedRows[0].Index;

            txtNombre.Focus();

        }

        private void eliminarRegistro()
        {
            if (MessageBox.Show("¿Desea eliminar el Registro Seleccionado?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                oPersonal.Eliminar(Id);
                rowselect = 0;
                comenzarCarga();
                if (dgv.Rows.Count == 0)
                    limpiarValores();
            }
        }

        private void guardarRegistro()
        {
            if (validarDatos())
            {
                oPersonal.Id = Id;
                oPersonal.Nombre = txtNombre.Text;
                oPersonal.Clave = txtClave.Text;
                oPersonal.Id_Personal_Areas = Convert.ToInt32(cboAreas.SelectedValue);
                oPersonal.Id_Puntos_Cobros = Convert.ToInt32(cboPuntosCobros.SelectedValue);
                oPersonal.Usuario_Sistema = chkUsuarioSistema.Checked == true ? 1 : 0;
                oPersonal.Doble_turno = chkDoble_turno.Checked == true ? 1 : 0;
                oPersonal.Hr_matutino_inicio = String.Format("{0}:{1}", spHorario1HS_Desde.Value, spHorario1MN_Desde.Value);
                oPersonal.Hr_matutino_fin = String.Format("{0}:{1}", spHorario1HS_Hasta.Value, spHorario1MN_Hasta.Value);
                oPersonal.Hr_vespertino_inicio = String.Format("{0}:{1}", spHorario2HS_Desde.Value, spHorario2MN_Desde.Value);
                oPersonal.Hr_vespertino_fin = String.Format("{0}:{1}", spHorario2HS_Hasta.Value, spHorario2MN_Hasta.Value);
                oPersonal.Rango = Convert.ToInt32(spRango.Value);
                oPersonal.Id_Rol = Convert.ToInt32(cboRoles.SelectedValue);
                oPersonal.Guardar(oPersonal, Personal.Id_Login);

                if (oPersonal.Id == 0)
                    rowselect = dgv.Rows.Count;

                comenzarCarga();
                limpiarValores();
                btnNuevo.Focus();
            }
        }

        private void cancelarEdicion()
        {
            controles(false);
            limpiarValores();
            asignarValores();
        }

        private bool validarDatos()
        {
            if (txtNombre.Text.Trim().Length == 0)
            {
                MessageBox.Show("Debe ingresar el Nombre del Personal", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                txtNombre.Focus();

                return false;
            }

            if (chkUsuarioSistema.Checked)
            {
                if (txtClave.Text.Length == 0)
                {
                    MessageBox.Show("Debe ingresar la Clave de Acceso al Sistema", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    txtClave.Focus();

                    return false;
                }
                else
                {
                    DataRow[] dr = null;

                    dr = dt.Select(String.Format("Clave = '{0}' AND Id<>'{1}'", txtClave.Text.ToUpper(), Id));

                    if (dr.Count() > 0)
                    {
                        MessageBox.Show("El Valor ingresado correspondiente a la clave ya existe", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        return false;
                    }
                }

                if (Convert.ToInt32(cboPuntosCobros.SelectedValue) == 0)
                {
                    MessageBox.Show("Debe seleccionar el Punto de Cobro", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    cboPuntosCobros.Focus();

                    return false;
                }
                if ((Convert.ToInt32(cboRoles.SelectedValue) == 0) && (chkUsuarioSistema.Checked == true))
                {
                    MessageBox.Show("Debe seleccionar el rol del usuario", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cboRoles.Focus();
                    return false;
                }
            }

            if (spHorario1HS_Desde.Enabled)
            {
                TimeSpan Hs1Desde = new TimeSpan(Convert.ToInt32(spHorario1HS_Desde.Value), Convert.ToInt32(spHorario1MN_Desde.Value), 0);
                TimeSpan Hs1Hasta = new TimeSpan(Convert.ToInt32(spHorario1HS_Hasta.Value), Convert.ToInt32(spHorario1MN_Hasta.Value), 0);
                if (Hs1Desde >= Hs1Hasta)
                {
                    MessageBox.Show("El Horario Salida debe ser Mayor al Horario de Inicio", "Mensaje del Sistema", MessageBoxButtons.OK);
                    spHorario1HS_Hasta.Focus();
                    return false;
                }

                if (spRango.Value == 0)
                {
                    MessageBox.Show("Debe ingresar el Rango Horario", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    spRango.Focus();

                    return false;
                }

                if (chkDoble_turno.Checked)
                {
                    TimeSpan Hs2Desde = new TimeSpan(Convert.ToInt32(spHorario2HS_Desde.Value), Convert.ToInt32(spHorario2MN_Desde.Value), 0);
                    TimeSpan Hs2Hasta = new TimeSpan(Convert.ToInt32(spHorario2HS_Hasta.Value), Convert.ToInt32(spHorario2MN_Hasta.Value), 0);

                    if (Hs2Desde <= Hs1Hasta)
                    {
                        MessageBox.Show("El segundo Horario de entrada debe ser Mayor al primer Horario de Salida", "Mensaje del Sistema", MessageBoxButtons.OK);

                        spHorario2HS_Desde.Focus();

                        return false;
                    }

                    if (Hs2Hasta <= Hs2Desde)
                    {
                        MessageBox.Show("El segundo Horario de salida debe ser Mayor al segundo Horario de Entrada", "Mensaje del Sistema", MessageBoxButtons.OK);

                        spHorario2HS_Hasta.Focus();

                        return false;
                    }

                }
            }



            return true;
        }

        private void ControlarArea()
        {
            try
            {
                if (cboAreas.Enabled)
                {
                    int Area_Id = Convert.ToInt32(cboAreas.SelectedValue);

                    DataRow[] drFilter = dtAreas.Select(String.Format("Id = {0}", Area_Id));

                    spHorario1HS_Desde.Enabled = Convert.ToInt32(drFilter[0]["Req_Horario"]) == 1 ? true : false;
                    spHorario1MN_Desde.Enabled = spHorario1HS_Desde.Enabled;
                    spHorario1HS_Hasta.Enabled = spHorario1HS_Desde.Enabled;
                    spHorario1MN_Hasta.Enabled = spHorario1HS_Desde.Enabled;
                    spRango.Enabled = spHorario1HS_Desde.Enabled;

                    lblAsignaHorarios.Visible = spHorario1HS_Desde.Enabled;
                }
            }
            catch { }
        }

        private void ControlarDobleTurno()
        {
            if (chkDoble_turno.Enabled)
            {
                if (spHorario1HS_Desde.Enabled)
                {
                    spHorario2HS_Desde.Enabled = chkDoble_turno.Checked;
                    spHorario2MN_Desde.Enabled = chkDoble_turno.Checked;
                    spHorario2HS_Hasta.Enabled = chkDoble_turno.Checked;
                    spHorario2MN_Hasta.Enabled = chkDoble_turno.Checked;
                }
            }
        }
        #endregion

        public ABMPersonal()
        {
            InitializeComponent();
        }

        private void ABMPersonal_Load(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void ABMPersonal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            controles(false);

            comenzarCarga();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            controles(true);
            spHorario1HS_Desde.Enabled = false;
            spHorario1HS_Hasta.Enabled = false;
            spHorario1MN_Desde.Enabled = false;
            spHorario1MN_Hasta.Enabled = false;
            spHorario2HS_Desde.Enabled = false;
            spHorario2HS_Hasta.Enabled = false;
            spHorario2MN_Desde.Enabled = false;
            spHorario2MN_Hasta.Enabled = false;
            spRango.Enabled = false;


            limpiarValores();

            nuevoRegistro();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            asignarValores();
            controles(true);
            ControlarArea();
            ControlarDobleTurno();
            editarRegistro();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminarRegistro();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            guardarRegistro();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cancelarEdicion();
            bool state = false;
            spHorario1HS_Desde.Enabled = state;
            spHorario1HS_Hasta.Enabled = state;
            spHorario1MN_Desde.Enabled = state;
            spHorario1MN_Hasta.Enabled = state;
            spHorario2HS_Desde.Enabled = state;
            spHorario2HS_Hasta.Enabled = state;
            spHorario2MN_Desde.Enabled = state;
            spHorario2MN_Hasta.Enabled = state;
            spRango.Enabled = state;
        }

        private void cboAreas_SelectedIndexChanged(object sender, EventArgs e)
        {
            ControlarArea();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkDoble_turno_CheckedChanged(object sender, EventArgs e)
        {
            ControlarDobleTurno();
        }

        private void chkUsuarioSistema_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkUsuarioSistema.Enabled)
            {
                txtClave.Enabled = chkUsuarioSistema.Checked;
                cboPuntosCobros.Enabled = chkUsuarioSistema.Checked;
                cboRoles.Enabled = chkUsuarioSistema.Checked;
            }
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            asignarValores();
        }

        private void cboAreas_SelectedValueChanged(object sender, EventArgs e)
        {
            ControlarArea();
        }

        private void dgv_Leave(object sender, EventArgs e)
        {
        }
    }
}
