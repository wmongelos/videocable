using CapaNegocios;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Abms
{
    public partial class ABMServicios : Form
    {
        #region [PROPIEDADES]
        private Thread hilo;
        private delegate void myDel();
        private DataTable dtSer;
        private DataTable dtSub;
        private DataTable dtSub_Clone;
        private DataTable dtEquipos_Tipos;
        private DataTable dtSubTipos;
        private Servicios oSer = new Servicios();
        private Servicios_Sub oSub = new Servicios_Sub();
        private Equipos_Tipos oEqui_Tipos = new Equipos_Tipos();
        private Int32 rowselect = 0, idServicioSeleccionado = 0, idServicioSubSeleccionado = 0;
        private DataTable dtAlicuotas = new DataTable();
        private Iva_Alicuotas Iva_Alicuotas = new Iva_Alicuotas();
        private DataGridViewLinkColumn columnaLink = new DataGridViewLinkColumn();
        private Servicios_Tarifas oTarifa = new Servicios_Tarifas();
        private DataTable dt_Tarifa = new DataTable();
        private DataTable dt_servicios_categorias = new DataTable(); 


        #endregion

        public ABMServicios()
        {
            InitializeComponent();
        }

        #region [METODOS]
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
                dtSer = oSer.Listar();

                dtSub = oSub.Listar();
                dtSubTipos = oSub.ListarTipos();

                dtAlicuotas = Iva_Alicuotas.Listar();

                DataColumn colSel = new DataColumn("Seleccion", typeof(Boolean));
                colSel.DefaultValue = false;
                dtSub.Columns.Add(colSel);

                foreach (DataRow dr in dtSub.Rows)
                {
                    if (Convert.ToInt32(dr["Valor_Defecto"]) == 1)
                        dr["Seleccion"] = true;
                }

                dtSub_Clone = dtSub.Clone();
                dtEquipos_Tipos = oEqui_Tipos.Listar();

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
            dgv.DataSource = dtSer;

            dgv.Columns["Id"].Visible = false;
            dgv.Columns["Codigo"].Visible = false;
            dgv.Columns["Descripcion"].HeaderText = "Descripcion";
            dgv.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgv.Columns["Tipo"].HeaderText = "Tipo";
            dgv.Columns["Tipo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgv.Columns["Tipo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["Requiere_Equipo"].HeaderText = "Requiere Equipo";
            dgv.Columns["Requiere_Equipo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["Requiere_Velocidad"].HeaderText = "Requiere Velocidad";
            dgv.Columns["Requiere_Velocidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["Requiere_Tarjeta"].HeaderText = "Requiere Tarjeta";
            dgv.Columns["Requiere_Tarjeta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["Dias_Bonificacion"].HeaderText = "Dias de Bonificacion";
            dgv.Columns["Dias_Bonificacion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["Factura_Mensualmente"].HeaderText = "Factura mensualmente";
            dgv.Columns["Factura_Mensualmente"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["Id_Servicios_Tipos"].Visible = false;
            dgv.Columns["Id_Servicios_Modalidad"].Visible = false;
            dgv.Columns["Id_Servicios_Grupos"].Visible = false;
            dgv.Columns["Condicion"].Visible = false;
            dgv.Columns["Fecha_Inicio_Servicio"].Visible = false;
            dgv.Columns["TipoCorte"].Visible = false;
            dgv.Columns["CorteAutomatico"].Visible = false;
            dgv.Columns["Forzar_Inicio_Mes"].Visible = false;
            dgv.Columns["Requiere_Servicio_Padre"].Visible = false;
            dgv.Columns["Aplicacion_Externa"].Visible = false;
            dgv.Columns["Id_Aplicaciones_Externas"].Visible = false;
            dgv.Columns["Id_Contrato"].Visible = false;
            dgv.Columns["Cuenta"].Visible = false;
            dgv.Columns["genera_deuda_cortado"].Visible = false;
            dgv.Columns["genera_deuda_retirado"].Visible = false;
            dgv.Columns["origenmeses"].Visible = false;
            dgv.Columns["habilita_debito"].Visible = false;
            dgv.Columns["id_parte_corte"].Visible = false;


            foreach (DataGridViewRow row in dgv.Rows)
                if (Convert.ToInt32(row.Cells["Condicion"].Value) > 0)
                {
                    row.DefaultCellStyle.ForeColor = Color.Red;
                }


            lblTotal.Text = String.Format("Total de Registros: {0}", dtSer.Rows.Count);

            if (dtSer.Rows.Count > 0)
                dgv.CurrentCell = dgv.Rows[rowselect].Cells[2];


            dgvSub.DataSource = dtSub;
            bool existeColumnaEliminar = false;
            foreach (DataGridViewColumn item in dgvSub.Columns)
            {
                if (item.Name == "cquitar")
                    existeColumnaEliminar = true;
            }
            if (!existeColumnaEliminar)
            {
                //agrego columna eliminar 
                columnaLink.Text = "Eliminar";
                columnaLink.DataPropertyName = "Quitar";
                columnaLink.Name = "cquitar";
                columnaLink.LinkColor = Color.Blue;
                columnaLink.VisitedLinkColor = Color.Blue;
                columnaLink.UseColumnTextForLinkValue = true;
                columnaLink.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                columnaLink.HeaderText = "Eliminar";
                dgvSub.Columns.Add(columnaLink);
            }

            foreach (DataGridViewColumn col in dgvSub.Columns)
                col.Visible = false;

            dgvSub.Columns["descripcion"].Visible = true;
            dgvSub.Columns["ip"].Visible = true;
            dgvSub.Columns["seleccion"].Visible = true;
            dgvSub.Columns["IP"].HeaderText = "Servicio de IP";
            dgvSub.Columns["IP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvSub.Columns["cquitar"].Visible = true;

            cboSubservicios_Tipos.DataSource = dtSubTipos;
            cboSubservicios_Tipos.ValueMember = "Id";
            cboSubservicios_Tipos.DisplayMember = "Nombre";

            cboAlicuotas.DataSource = dtAlicuotas;
            cboAlicuotas.DisplayMember = "Porcentaje";
            cboAlicuotas.ValueMember = "Id";

            controles(false);
            asignarValores();

        }

        private void controles(bool state)
        {
            btnActualizar.Enabled = !state;
            btnNuevo.Enabled = !state;
            btnEditar.Enabled = dtSer.Rows.Count == 0 ? false : !state;
            btnEliminar.Enabled = dtSer.Rows.Count == 0 ? false : !state;

            dgv.Enabled = !state;
            dgvSub.Enabled = !state;

            btnGuardar.Enabled = state;
            btnCancelar.Enabled = state;
            btnNuevaSub.Enabled = true;

        }

        private void asignarValores()
        {
            try
            {
                txtSubServicio.Text = String.Empty;
                txtIdSubServicio.Text = String.Empty;
                DataView dv = dtSub.DefaultView;
                dv.RowFilter = String.Format("Id_Servicios = {0}", dgv.SelectedRows[0].Cells["Id"].Value.ToString());
                idServicioSeleccionado = Convert.ToInt32(dgv.SelectedRows[0].Cells["Id"].Value);

                dgvSub.DataSource = dv;

                btnEditarSub.Enabled = dv.Count == 0 ? false : true;

                dtSub_Clone = dv.Table;
            }
            catch { }
        }

        private void nuevoRegistro()
        {
            chkRequiere_IP.Checked = false;
            chkValor_Defecto.Checked = false;

            dgvSub.DataSource = dtSub_Clone;

            txtIdSubServicio.Text = "0";
            txtSubServicio.Text = "";
            txtSubServicio.Enabled = true;
            cboSubservicios_Tipos.Enabled = true;
            chkRequiere_IP.Enabled = true;
            chkValor_Defecto.Enabled = true;
            cboAlicuotas.Enabled = true;
        }

        private void eliminarRegistro()
        {
            // EN TODOS LOS METODOS SI RETORNA 1 ES QUE HAY DATOS, SI RETORNA 0 ES QUE NO HAY DATOS
            dt_Tarifa = oTarifa.TraerDatosTarifaActual();
            int Usuarios_Totales = 0;
            int VerificacionTarifaSub = oSer.Verificacion_Servicio_Tarifa_Sub(Convert.ToInt32(dgv.SelectedRows[0].Cells["Id"].Value), Convert.ToInt32(dt_Tarifa.Rows[0]["id"]));                       
            int VerificacionTarifaSub_Esp = oSer.Verificacion_Servicio_Tarifa_Sub_Esp(Convert.ToInt32(dgv.SelectedRows[0].Cells["Id"].Value), Convert.ToInt32(dt_Tarifa.Rows[0]["id"]));
            int VerificacionCategorias = oSer.Verificacion_Categoria(Convert.ToInt32(dgv.SelectedRows[0].Cells["Id"].Value));
            int puedeEliminar = oSer.VerificarEliminar(Convert.ToInt32(dgv.SelectedRows[0].Cells["Id"].Value), out Usuarios_Totales);
            int id_servicio = Convert.ToInt32(dgv.SelectedRows[0].Cells["Id"].Value);
            if (MessageBox.Show("¿Desea eliminar el Registro Seleccionado?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (puedeEliminar == 0 && VerificacionCategorias == 0 &&(VerificacionTarifaSub==0 || VerificacionTarifaSub_Esp==0))
                {
                    oSer.Eliminar(Convert.ToInt32(dgv.SelectedRows[0].Cells["Id"].Value));
                    comenzarCarga();
                }
                else
                {
                    using (frmPopUp frm = new frmPopUp())
                    {
                        frmVerificacionEliminarServicios frm1 = new frmVerificacionEliminarServicios();
                        frm1.VerificacionTarifaSub = VerificacionTarifaSub ;
                        frm1.VerificacionTarifaSubEsp = VerificacionTarifaSub_Esp;
                        frm1.VerificacionUsuariosServicios = puedeEliminar;
                        frm1.VerificacionCategoria = VerificacionCategorias;
                        frm1.Total_Usuarios = Usuarios_Totales;
                        frm1.Id_servicio = id_servicio;
                        frm.Formulario = frm1;
                        frm.Maximizar = false;
                        frm.Show();
                    }
                }
                    

            }
        }

        private void guardarRegistroSub()
        {

            oSub.Id = txtIdSubServicio.Text.Length == 0 ? 0 : Convert.ToInt32(txtIdSubServicio.Text);
            oSub.Id_Servicios = Convert.ToInt32(dgv.SelectedRows[0].Cells["Id"].Value);
            oSub.Id_Servicios_Sub_Tipos = Convert.ToInt32(cboSubservicios_Tipos.SelectedValue);
            oSub.Descripcion = txtSubServicio.Text;
            oSub.Requiere_IP = chkRequiere_IP.CheckState == CheckState.Checked ? 1 : 0;
            oSub.Valor_Defecto = chkValor_Defecto.CheckState == CheckState.Checked ? 1 : 0;
            oSub.Id_Iva_Alicuotas = Convert.ToInt32(cboAlicuotas.SelectedValue);
            oSub.Guardar(oSub, Personal.Id_Login);

            txtIdSubServicio.Text = "0";
            comenzarCarga();
        }

        private void cancelarEdicion()
        {
            controles(false);
        }

        private void editarRegistroSub()
        {

            txtSubServicio.Enabled = true;
            btnGuardarSub.Enabled = true;
            btnCancelarSub.Enabled = true;
            cboSubservicios_Tipos.Enabled = true;
            chkRequiere_IP.Enabled = true;
            chkValor_Defecto.Enabled = true;
            //txtIdSubServicio.Text = dgvSub.SelectedRows[0].Cells["Id"].Value.ToString();
            //txtSubServicio.Text = dgvSub.SelectedRows[0].Cells["Descripcion"].Value.ToString();
            //cboSubservicios_Tipos.SelectedValue = Convert.ToInt32(dgvSub.SelectedRows[0].Cells["Id_Servicios_Sub_Tipos"].Value);


            //if (Convert.ToInt32(dgvSub.SelectedRows[0].Cells["Requiere_IP"].Value) == 0)
            //{
            //    chkRequiere_IP.Checked = false;
            //}
            //else
            //{
            //    chkRequiere_IP.Checked = true;
            //}

            //if (Convert.ToInt32(dgvSub.SelectedRows[0].Cells["Valor_Defecto"].Value) == 0)
            //{
            //    chkValor_Defecto.Checked = false;
            //}
            //else
            //{
            //    chkValor_Defecto.Checked = true;
            //}

            //cboAlicuotas.Enabled = true;
            //cboAlicuotas.SelectedValue = dgvSub.SelectedRows[0].Cells["Id_Iva_Alicuotas"].Value.ToString();

            txtSubServicio.Focus();

        }

        public int Verificar_Nombre_SubServ(string nombre)
        {
            int resultado = 0;
            DataTable dt = new DataTable();
            int id_sub = 0;
            if (dgvSub.SelectedRows.Count > 0)
            {
                id_sub = Convert.ToInt32(dgvSub.SelectedRows[0].Cells["Id"].Value);
            }
            else
            {
                id_sub = 0;
            }
            dt = oSub.Verificar_Servicio_Editar(Convert.ToInt32(dgv.SelectedRows[0].Cells["Id"].Value), id_sub);

            if (dt.Select("Descripcion='" + nombre + "'").Count() > 0)
            {
                resultado = 1;
            }

            return resultado;

        }

        private void AsignarDatosSubServicio()
        {
            txtSubServicio.Text = String.Empty;
            txtIdSubServicio.Text = String.Empty;
            if (dgvSub.Rows.Count > 0)
            {
                if (dgvSub.SelectedRows.Count > 0)
                {
                    try
                    {
                        txtIdSubServicio.Text = dgvSub.SelectedRows[0].Cells["Id"].Value.ToString();
                        idServicioSubSeleccionado = Convert.ToInt32(dgvSub.SelectedRows[0].Cells["Id"].Value);
                        txtSubServicio.Text = dgvSub.SelectedRows[0].Cells["Descripcion"].Value.ToString();
                        cboSubservicios_Tipos.SelectedValue = Convert.ToInt32(dgvSub.SelectedRows[0].Cells["Id_Servicios_Sub_Tipos"].Value);


                        if (Convert.ToInt32(dgvSub.SelectedRows[0].Cells["Requiere_IP"].Value) == 0)
                        {
                            chkRequiere_IP.Checked = false;
                        }
                        else
                        {
                            chkRequiere_IP.Checked = true;
                            //if (Convert.ToInt32(dgvSub.SelectedRows[0].Cells["Id_Servicios_Sub_Tipos"].Value) == 1)
                            //    btnVelocidad.Visible = true;
                            //else
                            //    btnVelocidad.Visible = false;
                        }

                        if (Convert.ToInt32(dgvSub.SelectedRows[0].Cells["Valor_Defecto"].Value) == 0)
                        {
                            chkValor_Defecto.Checked = false;
                        }
                        else
                        {
                            chkValor_Defecto.Checked = true;
                        }

                        cboAlicuotas.Enabled = true;
                        cboAlicuotas.SelectedValue = dgvSub.SelectedRows[0].Cells["Id_Iva_Alicuotas"].Value.ToString();
                    }
                    catch (Exception)
                    {

                    }

                    
                }
                else
                {
                    txtIdSubServicio.Text = dgvSub.Rows[0].Cells["Id"].Value.ToString();
                    txtSubServicio.Text = dgvSub.Rows[0].Cells["Descripcion"].Value.ToString();
                    cboSubservicios_Tipos.SelectedValue = Convert.ToInt32(dgvSub.Rows[0].Cells["Id_Servicios_Sub_Tipos"].Value);


                    if (Convert.ToInt32(dgvSub.Rows[0].Cells["Requiere_IP"].Value) == 0)
                    {
                        chkRequiere_IP.Checked = false;
                    }
                    else
                    {
                        chkRequiere_IP.Checked = true;
                    }

                    if (Convert.ToInt32(dgvSub.Rows[0].Cells["Valor_Defecto"].Value) == 0)
                    {
                        chkValor_Defecto.Checked = false;
                    }
                    else
                    {
                        chkValor_Defecto.Checked = true;
                    }

                    cboAlicuotas.Enabled = true;
                    cboAlicuotas.SelectedValue = dgvSub.Rows[0].Cells["Id_Iva_Alicuotas"].Value.ToString();
                }
            }
        }

        private void FiltrarDatos()
        {
            string texto = Convert.ToString(txtBusca.Text);
            dtSer.DefaultView.RowFilter = String.Format("Tipo Like '%{0}%' OR Descripcion Like '%{0}%' OR Modalidad Like '%{0}%'", texto);
        }
        #endregion

        private void ABMServicios_Load(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void ABMServicios_KeyDown(object sender, KeyEventArgs e)
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
            using (frmPopUp frm = new frmPopUp())
            {
                frm.Formulario = new ABMServicios_Ficha();
                frm.Maximizar = false;

                if (frm.ShowDialog() == DialogResult.OK)
                    comenzarCarga();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            using (frmPopUp frm = new frmPopUp())
            {
                ABMServicios_Ficha ABM = new ABMServicios_Ficha();

                DataRow[] drFilter = dtSer.Select(String.Format("Id = {0}", dgv.SelectedRows[0].Cells["Id"].Value));

                ABM.DataRow = drFilter[0];

                frm.Formulario = ABM;


                frm.Maximizar = false;

                if (frm.ShowDialog() == DialogResult.OK)
                    comenzarCarga();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminarRegistro();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cancelarEdicion();
        }

        private void btnCondicionesContratacion_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                using (frmPopUp frm = new frmPopUp())
                {
                    ABMServicios_Condiciones ABMServicio_Condicion = new ABMServicios_Condiciones(Convert.ToInt32(dgv.SelectedRows[0].Cells["id"].Value));

                    frm.Formulario = ABMServicio_Condicion;

                    if (frm.ShowDialog() == DialogResult.OK)
                        this.comenzarCarga();
                }
            }
        }

        private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            asignarValores();
            // Convert.ToInt32(dgv.SelectedRows[0].Cells["Id"].Value)
            try
            {
                if (Convert.ToInt32(dgv.SelectedRows[0].Cells["Condicion"].Value) > 0)
                {
                    lblRequiereCondicion.Visible = true;
                    lblRequiereCondicion.ForeColor = Color.Red;
                    lblRequiereCondicion.Text = "Requiere condicion: SI";
                }
                else
                {
                    lblRequiereCondicion.Visible = false;
                }
            }
            catch { }


        }

        private void dgvSub_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSub.Columns[e.ColumnIndex].Name == "Accion")
            {
                int id = Convert.ToInt32(dgvSub.SelectedRows[0].Cells["Id"].Value);
                oSub.EliminarSubSer(id);
                DataRow[] drFilter = dtSub.Select(String.Format("Id = {0}", id));
                drFilter.FirstOrDefault().Delete();
                dtSub.AcceptChanges();
                dgvSub.Refresh();
            }
            if (dgvSub.Columns[e.ColumnIndex].Name == "cquitar")
            {
                if (MessageBox.Show("Esta a punto de eliminar un sub servicio, ¿Desea continuar?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dgvSub.SelectedRows[0].Cells["Id"].Value);
                    if (oSub.VerificarEliminar(id) == 0)
                    {
                        oSub.EliminarSubSer(id);
                        DataRow[] drFilter = dtSub.Select(String.Format("Id = {0}", id));
                        drFilter.FirstOrDefault().Delete();
                        dtSub.AcceptChanges();
                        dgvSub.Refresh();
                        dgvSub.ClearSelection();
                    }
                    else
                        MessageBox.Show("No se puede eliminar un servicio que esta activo en al menos un usuario", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
            }
        }

        private void btnEditarSub_Click(object sender, EventArgs e)
        {
            editarRegistroSub();
        }

        private void btnGuardarSub_Click(object sender, EventArgs e)
        {
            rowselect = dgv.SelectedRows[0].Index;

            if (txtSubServicio.Text.Length > 0)
            {

                guardarRegistroSub();
                btnGuardarSub.Enabled = false;
                txtSubServicio.Enabled = false;
                cboSubservicios_Tipos.Enabled = false;
                chkRequiere_IP.Enabled = false;
                chkValor_Defecto.Enabled = false;
                chkRequiere_IP.Checked = false;
                chkValor_Defecto.Checked = false;
                btnGuardarSub.Enabled = false;
                txtSubServicio.Clear();
                btnCancelarSub.Enabled = false;
                btnNuevaSub.Enabled = true;
                btnEditarSub.Enabled = true;
                cboAlicuotas.Enabled = false;
            }
            else
            {
                MessageBox.Show("Hay datos en blanco.");
                txtIdSubServicio.Focus();
            }
        }

        private void btnNuevaSub_Click(object sender, EventArgs e)
        {
            txtSubServicio.Enabled = true;
            cboSubservicios_Tipos.Enabled = true;
            chkRequiere_IP.Enabled = true;
            chkValor_Defecto.Enabled = true;
            btnGuardarSub.Enabled = true;
            btnCancelarSub.Enabled = true;
            btnEditarSub.Enabled = false;
            btnNuevaSub.Enabled = false;
            cboAlicuotas.Enabled = true;
            txtIdSubServicio.Text = String.Empty;
            txtSubServicio.Text = String.Empty;

            txtSubServicio.Focus();
        }

        private void btnCancelarSub_Click(object sender, EventArgs e)
        {
            rowselect = dgv.SelectedRows[0].Index;

            btnGuardarSub.Enabled = false;
            btnNuevaSub.Enabled = true;
            btnEditarSub.Enabled = true;
            btnCancelarSub.Enabled = false;
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvSub_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            AsignarDatosSubServicio();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        private void txtBusca_TextChanged(object sender, EventArgs e)
        {

            if (txtBusca.Text.Trim() != "")
                FiltrarDatos();
            else
            {
                cargarDatos();
                txtBusca.Focus();
            }
        }

        private void cboSubservicios_Tipos_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                int tipoSub = Convert.ToInt32(cboSubservicios_Tipos.SelectedValue);
                if (tipoSub != Convert.ToInt32(Servicios_Sub.SERVICIO_SUB_TIPOS.SUBSERVICIO))
                {
                    chkRequiere_IP.Enabled = false;
                    chkRequiere_IP.Checked = false;
                }
                else
                    chkRequiere_IP.Enabled = true;

            }
            catch (Exception)
            {
            }

        }

        private void btnVelocidad_Click(object sender, EventArgs e)
        {
            //frmPopUp oPop = new frmPopUp();
            //ABMServicios_Velocidades_Relacion oABMRelacionVel = new ABMServicios_Velocidades_Relacion();
            //oABMRelacionVel.idServicio = idServicioSeleccionado;
            //oABMRelacionVel.idSubServicio = idServicioSubSeleccionado;
            //oPop.Maximizar = false;
            //oPop.Formulario = oABMRelacionVel;
            //oPop.ShowDialog();

        }
    }
}
