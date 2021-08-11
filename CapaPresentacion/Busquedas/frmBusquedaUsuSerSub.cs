using CapaNegocios;
using System;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Busquedas
{
    public partial class frmBusquedaUsuSerSub : Form
    {
        #region DECLARACIONES

        //publico
        public Int32 codUsuario;
        public Int32 idUsuario;
        public Int32 cambiaEstado;
        public Int32 seleccionar;
        public Int32 eliminar;
        public Int32 eliminado;

        public DataTable dtSubServiciosElegidos;


        //privado
        private Usuarios_Servicios oUsuarioServicio = new Usuarios_Servicios();
        private Usuarios_Locaciones oLocacion = new Usuarios_Locaciones();
        private Usuarios oUsuario = new Usuarios();
        private Plasticos_Usuarios oPlasticosUsuarios = new Plasticos_Usuarios();

        private Thread hilo;
        private delegate void myDel();

        private DataTable dtLocaciones = new DataTable();
        private DataTable dtUsuarioServicio = new DataTable();
        private DataTable dtUsuarioServicioSub = new DataTable();
        private DataTable dtServicios = new DataTable();
        private DataTable dtSub = new DataTable();
        private DataTable dtEstados = Tablas.DataServicios_Estados;

        private int idUsuarioSerlicioSel = 0;


        enum TIPO_REGISTRO
        {
            LOCACION = 1,
            USUARIO_SERVICIO = 2
        }
        #endregion;

        #region METODOS

        private void ComenzarCarga()
        {
            pgCircular.Start();
            dgvServicios.DataSource = null;
            hilo = new Thread(new ThreadStart(CargarDatos));
            hilo.Start();
        }

        private void CargarDatos()
        {
            try
            {
                if (dtServicios.Columns.Count == 0)
                {
                    dtServicios.Columns.Add("tipo", typeof(Int32));
                    dtServicios.Columns.Add("idLocacion", typeof(Int32));
                    dtServicios.Columns.Add("locacion", typeof(String));
                    dtServicios.Columns.Add("idUsuarioServicio", typeof(Int32));
                    dtServicios.Columns.Add("servicio", typeof(String));
                    dtServicios.Columns.Add("estado", typeof(String));

                    dtServicios.AcceptChanges();
                }
                if (dtSub.Columns.Count == 0)
                {
                    dtSub.Columns.Add("idUsuarioServicio", typeof(Int32));
                    dtSub.Columns.Add("idSubServicio", typeof(Int32));
                    dtSub.Columns.Add("idUsuarioServicioSub", typeof(Int32));
                    dtSub.Columns.Add("subNombre", typeof(string));
                    dtSub.Columns.Add("selec", typeof(Boolean));

                }


                if (idUsuario != 0)
                {
                    dtLocaciones.Clear();
                    dtServicios.Clear();
                    dtSub.Clear();
                    dtUsuarioServicio.Clear();
                    DataRow drDatosUsuario = oUsuario.getDatos(idUsuario);
                    codUsuario = Convert.ToInt32(drDatosUsuario["codigo"]);
                    dtLocaciones = oLocacion.ListarLocacionesServicio(idUsuario);
                    dtUsuarioServicio = oUsuarioServicio.ListarServiciosYSubServiciosActivos(idUsuario);

                    if ((dtLocaciones.Rows.Count > 0) || (dtUsuarioServicio.Rows.Count > 0))
                    {
                        int idSub = 0;
                        int idLocacion = 0;
                        int idServicio = 0;
                        string locacion;
                        DataRow drNuevo;
                        foreach (DataRow item in dtLocaciones.Rows)
                        {
                            idLocacion = Convert.ToInt32(item["id"]);
                            locacion = "CALLE " + item["calle"].ToString() + " NRO: " + item["altura"].ToString() + " PISO:" + item["piso"].ToString() + " DEPTO" + item["depto"].ToString() + ", " + item["localidad"].ToString();
                            drNuevo = dtServicios.NewRow();
                            drNuevo["tipo"] = (int)TIPO_REGISTRO.LOCACION;
                            drNuevo["idLocacion"] = idLocacion;
                            drNuevo["locacion"] = locacion;
                            drNuevo["idUsuarioServicio"] = 0;
                            drNuevo["servicio"] = "";
                            drNuevo["estado"] = "";
                            dtServicios.Rows.Add(drNuevo);

                            DataRow[] drServicios = dtUsuarioServicio.Select(string.Format("id_locacion={0}", idLocacion));
                            if (drServicios.Length > 0)
                            {
                                foreach (DataRow itemServicio in drServicios)
                                {
                                    idSub = Convert.ToInt32(itemServicio["id_usuario_servicio_sub"]);

                                    idServicio = Convert.ToInt32(itemServicio["id_servicio"]);
                                    if (idSub == 0)
                                    {
                                        drNuevo = dtServicios.NewRow();
                                        drNuevo["tipo"] = (int)TIPO_REGISTRO.USUARIO_SERVICIO;
                                        drNuevo["idLocacion"] = idLocacion;
                                        drNuevo["locacion"] = "";
                                        drNuevo["idUsuarioServicio"] = Convert.ToInt32(itemServicio["id_usuario_servicio"]);
                                        drNuevo["servicio"] = itemServicio["servicio"];
                                        drNuevo["estado"] = itemServicio["estado"];
                                        dtServicios.Rows.Add(drNuevo);
                                    }
                                    else
                                    {
                                        DataRow drNuevoSu = dtSub.NewRow();
                                        drNuevoSu["idUsuarioServicio"] = Convert.ToInt32(itemServicio["id_usuario_servicio"]);
                                        drNuevoSu["idSubServicio"] = Convert.ToInt32(itemServicio["id_servicio_Sub"]);
                                        drNuevoSu["idUsuarioServicioSub"] = Convert.ToInt32(itemServicio["id_usuarios_servicios_sub"]);
                                        drNuevoSu["subNombre"] = itemServicio["servicio_Sub"];
                                        drNuevoSu["selec"] = false;
                                        dtSub.Rows.Add(drNuevoSu);
                                    }
                                }

                            }
                        }

                    }
                }
                myDel MD = new myDel(asignarDatos);
                this.Invoke(MD, new object[] { });
                pgCircular.Stop();

            }
            catch (Exception c)
            {
                MessageBox.Show("Error al cargar datos." + c.Message, "Mensjae del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void asignarDatos()
        {
            dgvServicios.DataSource = null;
            dgvServicios.Columns.Clear();
            if (idUsuario > 0)
            {
                cboLocaciones.DataSource = null;
                cboLocaciones.DataSource = dtLocaciones;
                cboLocaciones.ValueMember = "id";
                cboLocaciones.DisplayMember = "locacion";
                dgvServicios.DataSource = dtServicios;
                formatearGrillaServicios();
            }
            cboEstados.DataSource = dtEstados;
            cboEstados.DisplayMember = "estado";
            cboEstados.ValueMember = "id";
            if (cambiaEstado == 1)
            {
                cboEstados.Visible = true;
                cboEstados.Enabled = false;
                btnCambiaEstado.Visible = true;
                btnCambiaEstado.Enabled = false;
                btnSeleccionar.Visible = false;
                dtpFecha.Visible = true;
                dtpFecha.Enabled = false;
                btnCambiaEstado.Location = new Point(btnCancelar.Location.X - btnCambiaEstado.Width - 10, btnCambiaEstado.Location.Y);
                cboEstados.Location = new Point(btnCambiaEstado.Location.X - cboEstados.Width - 10, cboEstados.Location.Y);
                dtpFecha.Location = new Point(cboEstados.Location.X - dtpFecha.Width - 10, dtpFecha.Location.Y);
            }
            else
            {
                cboEstados.Visible = false;
                btnCambiaEstado.Visible = false;
                dtpFecha.Visible = false;
            }
        }

        private void formatearGrillaServiciosSub()
        {
            dgvSub.ReadOnly = false;
            dgvSub.Columns["idUsuarioServicio"].Visible = false;
            dgvSub.Columns["idSubServicio"].Visible = false;
            dgvSub.Columns["idUsuarioServicioSub"].Visible = false;
            dgvSub.Columns["selec"].HeaderText = "Seleccionar";
            dgvSub.Columns["selec"].ReadOnly = false;

            dgvSub.Columns["subNombre"].HeaderText = "SubServciio";

            foreach (DataGridViewRow item in dgvServicios.Rows)
                item.Height = 30;


        }

        private void formatearGrillaServicios()
        {
            dgvServicios.Columns["tipo"].Visible = false;
            dgvServicios.Columns["idLocacion"].Visible = false;
            dgvServicios.Columns["idUsuarioServicio"].Visible = false;
            dgvServicios.Columns["servicio"].HeaderText = "Servicio";
            dgvServicios.Columns["locacion"].HeaderText = "Locacion";


            foreach (DataGridViewRow item in dgvServicios.Rows)
            {
                item.Height = 30;
                if (Convert.ToInt32(item.Cells["tipo"].Value) == (int)TIPO_REGISTRO.LOCACION)
                    item.DefaultCellStyle.BackColor = Color.MediumPurple;
            }
            if (eliminar > 0)
            {
                int contador = 0;
                foreach (DataGridViewColumn item in dgvServicios.Columns)
                {
                    if (item.Name == "eliminar")
                        contador++;
                }
                if (contador == 0)
                {
                    DataGridViewLinkColumn columnaLink = new DataGridViewLinkColumn();
                    columnaLink.Text = "Eliminar servicio";
                    columnaLink.DataPropertyName = "eliminar";
                    columnaLink.Name = "eliminar";
                    columnaLink.LinkColor = Color.Blue;
                    columnaLink.VisitedLinkColor = Color.Blue;
                    columnaLink.UseColumnTextForLinkValue = true;
                    columnaLink.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    columnaLink.HeaderText = "";
                    columnaLink.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
                    dgvServicios.Columns.Add(columnaLink);
                }
            }
        }
        #endregion
        public frmBusquedaUsuSerSub()
        {
            InitializeComponent();
        }

        private void frmBusquedaUsuSerSub_Load(object sender, EventArgs e)
        {
            ComenzarCarga();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBusquedaUsuSerSub_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void txtCod_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtCod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int cod = Convert.ToInt32(txtCod.Text);
                oUsuario = oUsuario.traerUsuario(0, cod);
                this.idUsuario = oUsuario.Id;
                dtLocaciones.Clear();
                dtServicios.Clear();
                dtUsuarioServicio.Clear();
                ComenzarCarga();
            }
        }

        private void buscarInformacion(int idUsu)
        {

        }

        private void dgvServicios_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                int idUsuarioServicioSel = Convert.ToInt32(dgvServicios.SelectedRows[0].Cells["idUsuarioServicio"].Value);
                DataView dv = dtSub.DefaultView;
                dv.RowFilter = string.Format("idUsuarioServicio={0}", idUsuarioServicioSel);
                dgvSub.DataSource = dv;
                formatearGrillaServiciosSub();
            }
            catch
            {

            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            dtSubServiciosElegidos = dtSub.Clone();
            DataRow[] drSeleccionados = dtSub.Select("selec=true");
            foreach (DataRow item in drSeleccionados)
            {
                dtSubServiciosElegidos.ImportRow(item);
            }
            dtSubServiciosElegidos.AcceptChanges();
            this.DialogResult = DialogResult.OK;
        }

        private void pnlBotones_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

        }

        private void dgvServicios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvServicios.Columns[e.ColumnIndex].Name.Equals("eliminar"))
            {
                if (oPlasticosUsuarios.BuscarPlasticosServicio(Convert.ToInt32(dgvServicios.SelectedRows[0].Cells["idUsuarioServicio"].Value)).Rows.Count > 0)
                    MessageBox.Show("Este servicio esta adherido a debito automatico, para cambiarlo/eliminarlo, debe desafectarlo", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    if (MessageBox.Show("Esta a punto de eliminar un servicio de un usuario. ¿Desea continuar?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        int idUsuSer = Convert.ToInt32(dgvServicios.SelectedRows[0].Cells["idUsuarioServicio"].Value);
                        if (idUsuSer > 0)
                        {
                            oUsuarioServicio.EliminarUsuarioServicio(idUsuSer);
                            MessageBox.Show("Servicio eliminado correctamente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.eliminado = 1;
                            ComenzarCarga();
                        }
                    }
                }
            }

        }

        private void dgvServicios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (cambiaEstado == 1)
            {

                if (Convert.ToInt32(dgvServicios.SelectedRows[0].Cells["tipo"].Value) == (int)TIPO_REGISTRO.USUARIO_SERVICIO)
                {
                    idUsuarioSerlicioSel = Convert.ToInt32(dgvServicios.SelectedRows[0].Cells["idusuarioservicio"].Value);
                    if (idUsuarioSerlicioSel > 0)
                    {
                        btnCambiaEstado.Enabled = true;
                        dtpFecha.Enabled = true;
                        cboEstados.Enabled = true;
                        cboEstados.Focus();

                    }
                    else
                    {
                        btnCambiaEstado.Enabled = false;
                        cboEstados.Enabled = false;
                        dtpFecha.Enabled = false;

                    }
                }
            }
        }

        private void btnCambiaEstado_Click(object sender, EventArgs e)
        {

            oUsuarioServicio.Fecha_Estado = dtpFecha.Value;
            oUsuarioServicio.ActualizarEstado(idUsuarioSerlicioSel, Convert.ToInt32(cboEstados.SelectedValue));
            ComenzarCarga();
        }
    }
}
