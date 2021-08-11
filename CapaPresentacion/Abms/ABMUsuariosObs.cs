using CapaNegocios;
using System;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
namespace CapaPresentacion.Abms
{
    public partial class ABMUsuariosObs : Form
    {
        public Int32 idUsuario;
        public Int32 idNovedad = 0;
        private Usuarios oUsuarios = new Usuarios();
        private Usuarios_Servicios_Novedades oNovedades = new Usuarios_Servicios_Novedades();
        private Thread hilo;
        private delegate void myDel();
        private DataTable dtNovedadesTipos = new DataTable();
        private DataTable dtNovedades = new DataTable();
        private int opcionLoc;
        private frmPopUp oPop;
        private Busquedas.frmBusquedaUsuarios oBuscaLoc;
        private Usuarios_Locaciones oLocacionElegida = new Usuarios_Locaciones();
        private Usuarios_Servicios oServicios = new Usuarios_Servicios();
        private DataTable dtServicios = new DataTable();
        int flag = 0;

        private void comenzarCarga()
        {
            pgCircular.Start();
            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
        }

        private void cargarDatos()
        {
            try
            {

                dtNovedadesTipos = oNovedades.ListarTipos();
                dtNovedades = oNovedades.ListarObservaciones(Usuarios.CurrentUsuario.Id);
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
            cboTipo.DataSource = dtNovedadesTipos;
            cboTipo.ValueMember = "id";
            cboTipo.DisplayMember = "descripcion";
            dgvObs.DataSource = dtNovedades;
            idUsuario = Usuarios.CurrentUsuario.Id;
            pnlOpciones.Enabled = false;
            lblTotal.Text = "Total de Registros: " + dtNovedades.Rows.Count;
            dgvObs.Enabled = true;
            btnNuevo.Enabled = true;
            btnGuardar.Enabled = false;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            btnCancelar.Enabled = false;
            PonerDatosUsuarios();

            cboImprimir.DisplayMember = "Text";
            cboImprimir.ValueMember = "Value";
            var items = new[] {
                new { Text = "USUARIO", Value = "1" },
                new { Text = "OPERADOR", Value = "2" },
                new { Text = "AMBOS", Value = "3" }
            };
            cboImprimir.DataSource = items;

            cboLocacion.DisplayMember = "Text";
            cboLocacion.ValueMember = "Value";
            var itemsLocacion = new[] {
                new { Text = "GENERAL", Value = "0" },
                new { Text = "BUSCAR LOCACION", Value = "-1" }
            };
            cboLocacion.DataSource = itemsLocacion;

            var itemsServicios = new[] {
                new { Text = "GENERAL", Value = "0" },
            };
            cboServicios.DataSource = itemsServicios;
            cboServicios.DisplayMember = "Text";
            cboServicios.ValueMember = "Value";
            FormatearGilla();
            Cancelar();
        }

        public ABMUsuariosObs()
        {
            InitializeComponent();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void boton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PonerDatosUsuarios()
        {
            LBApellido.Text = Usuarios.CurrentUsuario.Apellido.Trim() + " , " + Usuarios.CurrentUsuario.Nombre.Trim() + " [" + Usuarios.CurrentUsuario.Codigo.ToString().Trim() + "]";
            LBNumero_documento.Text = "Documento : (" + Usuarios.CurrentUsuario.Tipo_Documento + ") Nro " + Usuarios.CurrentUsuario.Numero_Documento;
            lbcuit.Text = "C. Iva : (" + Usuarios.CurrentUsuario.Condicion_Iva + ") Nro " + Usuarios.CurrentUsuario.CUIT;
            lbcorreo.Text = Usuarios.CurrentUsuario.Correo_Electronico;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            flag = 1;
            oNovedades.Id = 0;
            pnlOpciones.Enabled = true;
            txtObs.Text = "";
            dtpFechaDesde.Focus();
            btnNuevo.Enabled = false;
            btnEditar.Enabled = false;
            btnCancelar.Enabled = true;
            btnEliminar.Enabled = false;
            dgvObs.Enabled = false;
            btnGuardar.Enabled = true;
            pnlOpciones.Visible = true;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Cancelar();
        }

        private void frmUsuariosObs_Load(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void dgvObs_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvObs.Rows.Count > 0)
            {
                SeleccionarFila();
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;
                flag = 0;
            }

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (txtObs.Text.Length > 0)
            {

                GuardarRegistro();
            }
            else
            {
                MessageBox.Show("Ingrese una observacion", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtObs.Focus();
            }
        }

        public void SeleccionarFila()
        {
            try
            {
                int idLocacion = Convert.ToInt32(dgvObs.SelectedRows[0].Cells["id_usuarios_locaciones"].Value);
                oNovedades.Id = Convert.ToInt32(dgvObs.SelectedRows[0].Cells["id"].Value);
                cboTipo.SelectedValue = Convert.ToInt32(dgvObs.SelectedRows[0].Cells["id_tipo"].Value);
                dtpFechaDesde.Value = Convert.ToDateTime(dgvObs.SelectedRows[0].Cells["fecha_desde"].Value);
                dtpFechaHasta.Value = Convert.ToDateTime(dgvObs.SelectedRows[0].Cells["fecha_hasta"].Value);
                txtObs.Text = dgvObs.SelectedRows[0].Cells["detalle"].Value.ToString();


            }
            catch (Exception)
            {

            }
        }
        public void GuardarRegistro()
        {
            try
            {
                DateTime fechaDesdeNueva;
                DateTime fechaHastaNueva;
                oNovedades.Id_Usuarios = idUsuario;
                oNovedades.Detalle = txtObs.Text;
                fechaDesdeNueva = new DateTime(dtpFechaDesde.Value.Year, dtpFechaDesde.Value.Month, dtpFechaDesde.Value.Day);
                fechaHastaNueva = new DateTime(dtpFechaHasta.Value.Year, dtpFechaHasta.Value.Month, dtpFechaHasta.Value.Day);
                oNovedades.Fecha_Desde = fechaDesdeNueva;
                oNovedades.Fecha_Hasta = fechaHastaNueva;
                oNovedades.Id_tipo = Convert.ToInt32(cboTipo.SelectedValue);
                oNovedades.Imprimir = Convert.ToInt32(cboImprimir.SelectedValue);
                oNovedades.Id_Usuarios_Locaciones = Convert.ToInt32(cboLocacion.SelectedValue);
                oNovedades.Id_Servicios = Convert.ToInt32(cboServicios.SelectedValue);

                oNovedades.GuardarObsUsuario(oNovedades);
                MessageBox.Show("Observacion guardada correctamente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtObs.Text = "";
                comenzarCarga();
            }
            catch (Exception)
            {
                MessageBox.Show("Hubo un problema al guardar la observacion", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (oNovedades.Id > 0)
            {
                oNovedades.ELiminar(oNovedades.Id);
                comenzarCarga();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (oNovedades.Id > 0)
            {
                pnlOpciones.Enabled = true;
                dtpFechaDesde.Focus();
                btnNuevo.Enabled = false;
                btnEditar.Enabled = false;
                btnCancelar.Enabled = true;
                btnEliminar.Enabled = false;
                btnGuardar.Enabled = true;
                dgvObs.Enabled = false;
                pnlOpciones.Visible = true;
            }
        }

        private void dgvObs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvObs.Rows.Count > 0)
            {
                SeleccionarFila();
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;
            }
        }

        public void Cancelar()
        {
            txtObs.Text = "";
            pnlOpciones.Enabled = false;
            pnlOpciones.Visible = false;
            btnNuevo.Enabled = true;
            btnEditar.Enabled = true;
            btnCancelar.Enabled = false;
            btnEliminar.Enabled = true;
            dgvObs.Enabled = true;

        }

        public void FormatearGilla()
        {
            dgvObs.EnableHeadersVisualStyles = false;
            dgvObs.ColumnHeadersHeight = 50;
            dgvObs.Columns["id_tipo"].Visible = false;
            dgvObs.Columns["id_usuarios_locaciones"].Visible = false;
            dgvObs.Columns["id_usuarios_locaciones"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            dgvObs.Columns["id"].Visible = false;
            dgvObs.Columns["id_servicios"].Visible = false;

            dgvObs.Columns["detalle"].HeaderText = "Observacion";

            dgvObs.Columns["fecha_desde"].HeaderText = "Fecha desde";
            dgvObs.Columns["fecha_desde"].Width = 100;
            dgvObs.Columns["fecha_hasta"].HeaderText = "Fecha hasta";
            dgvObs.Columns["fecha_hasta"].Width = 80;

            dgvObs.Columns["descripcion"].HeaderText = "Tipo";
            dgvObs.Columns["imprimir"].HeaderText = "Imprimir";
            dgvObs.Columns["imprimir"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            dgvObs.Columns["locacion"].HeaderText = "Locacion";
            dgvObs.Columns["servicio"].HeaderText = "Servicio";


            DataGridViewCellStyle cellStiloVigente = new DataGridViewCellStyle();
            DataGridViewCellStyle cellStiloFuera = new DataGridViewCellStyle();



            if (dgvObs.Rows.Count > 0)
            {
                DateTime fecha;
                DateTime fechahoy = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                foreach (DataGridViewRow item in dgvObs.Rows)
                {
                    fecha = Convert.ToDateTime(item.Cells["fecha_hasta"].Value);
                    Font oFont = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    Padding oPaddin = new Padding(5, 3, 5, 0);
                    cellStiloFuera.Font = oFont;
                    cellStiloFuera.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    cellStiloFuera.Padding = oPaddin;
                    cellStiloVigente.Font = oFont;
                    cellStiloVigente.Padding = oPaddin;
                    cellStiloVigente.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    if (fecha < fechahoy)
                    {
                        cellStiloFuera.WrapMode = DataGridViewTriState.True;
                        cellStiloFuera.BackColor = Color.DarkGray;
                        item.DefaultCellStyle = cellStiloFuera;

                    }
                    else
                    {
                        if (fecha >= fechahoy)
                        {
                            cellStiloVigente.WrapMode = DataGridViewTriState.True;
                            cellStiloVigente.BackColor = Color.Gainsboro;
                            item.DefaultCellStyle = cellStiloVigente;
                        }
                    }
                }

            }
            dgvObs.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);

        }

        private void ABMUsuariosObs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void cboLocacion_ValueMemberChanged(object sender, EventArgs e)
        {

        }

        private void cboLocacion_SelectedValueChanged(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                try
                {
                    opcionLoc = Convert.ToInt32(cboLocacion.SelectedValue);
                    if (opcionLoc == -1)
                    {
                        oPop = new frmPopUp();
                        oBuscaLoc = new Busquedas.frmBusquedaUsuarios(1, Usuarios.CurrentUsuario.Id.ToString(), "");
                        oPop.Formulario = oBuscaLoc;
                        oBuscaLoc.ID = Usuarios.CurrentUsuario.Id;
                        oPop.Maximizar = false;
                        if (oPop.ShowDialog() == DialogResult.OK)
                        {
                            if (Usuarios.CurrentUsuario.Id_Usuarios_Locacion != 0)
                            {
                                oLocacionElegida = oLocacionElegida.GetLocacion(Usuarios.CurrentUsuario.Id_Usuarios_Locacion);

                                string locacionCadena = string.Format("{0} {1} {2} {3}, {4}", oLocacionElegida.Calle, oLocacionElegida.Altura, oLocacionElegida.Piso, oLocacionElegida.Depto, oLocacionElegida.Localidad);
                                int idLocacionEliegida = oLocacionElegida.Id;
                                flag = 0;
                                opcionLoc = -1;
                                cboLocacion.DataSource = null;
                                cboLocacion.DisplayMember = "Text";
                                cboLocacion.ValueMember = "Value";
                                var itemsLocacionEle = new[]
                                {
                                    new { Text = "GENERAL", Value = "0" },
                                    new { Text = "BUSCAR LOCACION", Value = "-1" },
                                    new { Text= locacionCadena, Value =idLocacionEliegida.ToString() }

                                };
                                cboLocacion.DataSource = itemsLocacionEle;
                                cboLocacion.SelectedItem = idLocacionEliegida;
                                cboLocacion.SelectedIndex = cboLocacion.Items.Count - 1;

                                dtServicios = oServicios.Listar_Servicios_Activos(idLocacionEliegida);
                                DataRow drServiciosGeneral = dtServicios.NewRow();
                                drServiciosGeneral["id_servicios"] = 0;
                                drServiciosGeneral["servicio"] = "GENERAL";
                                dtServicios.Rows.Add(drServiciosGeneral);
                                cboServicios.DataSource = dtServicios;
                                cboServicios.DisplayMember = "servicio";
                                cboServicios.ValueMember = "id_servicios";

                            }
                        }
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            flag = 1;
        }

        private void txtObs_TextChanged(object sender, EventArgs e)
        {


        }


        private void dgvObs_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            dgvObs.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
        }

        private void dgvObs_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvObs.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);

        }

    }


}
