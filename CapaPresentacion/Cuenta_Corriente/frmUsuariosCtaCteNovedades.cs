using CapaNegocios;
using System;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Cuenta_Corriente
{
    public partial class frmUsuariosCtaCteNovedades : Form
    {
        private Thread hilo;
        private delegate void myDel();
        private Usuarios oUsu = new Usuarios();
        private Usuarios_Locaciones oUsuLoc = new Usuarios_Locaciones();
        private Usuarios_Servicios_Novedades oNov = new Usuarios_Servicios_Novedades();
        private Usuarios_Servicios oUsuariosServicios = new Usuarios_Servicios();
        private DataTable dtLocaciones = new DataTable();
        private DataTable dtNovedades = new DataTable();
        private Configuracion oConfig = new Configuracion();
        private Tipo_Facturacion oTipoFacturacion = new Tipo_Facturacion();
        private Zonas oZonas = new Zonas();
        private Servicios_Categorias oServiciosCategorias = new Servicios_Categorias();
        private DataTable dtZonasCategorias = new DataTable();
        private DataTable dtServicios = new DataTable();
        private Servicios oSer = new Servicios();
        private Point oPointServicios = new Point();
        private Point oPointServicioslbl = new Point();

        private DataTable dtSoloLocaciones = new DataTable();

        public frmUsuariosCtaCteNovedades()
        {
            InitializeComponent();
        }

        private void frmUsuariosCtaCteNovedades_Load(object sender, EventArgs e)
        {
            ComenzarCarga();
        }

        private void ComenzarCarga()
        {
            pgCircular.Start();
            hilo = new Thread(new ThreadStart(CargarDatos));
            hilo.Start();
        }

        private void CargarDatos()
        {
            myDel MD = new myDel(AsignarDatos);
            this.Invoke(MD, new object[] { });
            pgCircular.Stop();
        }

        private void AsignarDatos()
        {
            oPointServicios = cboServicios.Location;
            oPointServicioslbl = lblServicios.Location;
            dtLocaciones = oUsuLoc.ListarLocacionesServicio(Usuarios.CurrentUsuario.Id);
            DataTable dtLocacionesCombo = new DataTable();
            dtLocacionesCombo.Columns.Add("Id", typeof(Int32));
            dtLocacionesCombo.Columns.Add("Locacion", typeof(String));
            foreach (DataRow item in dtLocaciones.Rows)
            {
                int id = Convert.ToInt32(item["id"]);
                string locacion = "Calle " + item["calle"] + " Nro: " + item["Altura"].ToString() + " Piso: " + item["Piso"].ToString() + " Depto: " + item["depto"].ToString();
                DataRow dr = dtLocacionesCombo.NewRow();
                dr["Id"] = id;
                dr["Locacion"] = locacion;
                dtLocacionesCombo.Rows.Add(dr);
            }

            dtSoloLocaciones = dtLocacionesCombo.Copy(); // es el datatable que se manda al formulario de detalle, se guarda para mandar sin el "todas";
            if (dtLocacionesCombo.Rows.Count > 1)
            {
                DataRow drTodas = dtLocacionesCombo.NewRow();
                drTodas["id"] = 0;
                drTodas["Locacion"] = "Todas";
                dtLocacionesCombo.Rows.Add(drTodas);
            }

            cboLocaciones.DataSource = dtLocacionesCombo;
            cboLocaciones.ValueMember = "id";
            cboLocaciones.DisplayMember = "Locacion";
            filtra_por_locaciones();
            lblUsuario.Text = String.Format("[{0}] - {1}, {2}", Usuarios.CurrentUsuario.Codigo, Usuarios.CurrentUsuario.Apellido, Usuarios.CurrentUsuario.Nombre);
            lblTotalReg.Text = "Total de registros: " + DgvNovedades.Rows.Count;

            DataTable dtUsuarios = new DataTable();
            dtUsuarios.Columns.Add("id", typeof(Int32));
            dtUsuarios.Columns.Add("nombre", typeof(String));

            if (Usuarios.CurrentUsuario.Id != 0)
            {
                string nombreCompletoUsuario = Usuarios.CurrentUsuario.Apellido + ", " + Usuarios.CurrentUsuario.Nombre;
                dtUsuarios.Rows.Add(Usuarios.CurrentUsuario.Id, nombreCompletoUsuario);
                dtUsuarios.Rows.Add(0, "TODOS LOS USUARIOS");
                cboTipoFacturacion.Visible = false;
                lblTipoFacturacion.Visible = false;
            }
            else
                dtUsuarios.Rows.Add(0, "TODOS LOS USUARIOS");

            cboUsuario.DataSource = dtUsuarios;
            cboUsuario.DisplayMember = "nombre";
            cboUsuario.ValueMember = "id";
        }


        private void filtra_por_locaciones()
        {
            try
            {
                int idLocacion = Convert.ToInt32(cboLocaciones.SelectedValue);
                lblocalidad.Text = cboLocaciones.SelectedText;
                Usuarios.CurrentUsuario.Id_Usuarios_Locacion = idLocacion;
                oNov.Id_Usuarios_Locaciones = idLocacion;
                if (idLocacion != 0)
                    oNov.Tipo_Busqueda = "L";
                else
                    oNov.Tipo_Busqueda = "U";

                oNov.Id_Usuarios = Convert.ToInt32(cboUsuario.SelectedValue);
                dtNovedades = oNov.Listar();
                dtNovedades.Columns.Add("Termina", typeof(String));
                foreach (DataRow dr in dtNovedades.Rows)
                {

                    if (Convert.ToInt32(dr["finaliza"].ToString()) == 1)
                        dr["Termina"] = dr["fecha_hasta"].ToString();
                    else
                        dr["Termina"] = "...";

                }
                DgvNovedades.DataSource = dtNovedades;
                Grilla_Novedades();
                lblTotalReg.Text = "Total de registros: " + DgvNovedades.Rows.Count;

            }
            catch { }
        }

        private void dgvLocaciones_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            filtra_por_locaciones();
        }

        private void Grilla_Novedades()
        {

            foreach (DataGridViewColumn item in DgvNovedades.Columns)
                item.Visible = false;


            DgvNovedades.Columns["Servicio_Nombre"].Visible = true;
            DgvNovedades.Columns["Servicio_Nombre"].HeaderText = "Servicio";

            DgvNovedades.Columns["Sub_Servicio_Nombre"].Visible = true;
            DgvNovedades.Columns["Sub_Servicio_Nombre"].HeaderText = "Subservicio";

            DgvNovedades.Columns["Fecha_Desde"].Visible = true;
            DgvNovedades.Columns["Fecha_Desde"].HeaderText = "Fecha desde";
            DgvNovedades.Columns["Fecha_Desde"].DisplayIndex = DgvNovedades.ColumnCount - 4;

            DgvNovedades.Columns["termina"].Visible = true;
            DgvNovedades.Columns["termina"].HeaderText = "Termina";

            DgvNovedades.Columns["porcentaje"].Visible = true;
            DgvNovedades.Columns["porcentaje"].HeaderText = "Porcentaje";
            DgvNovedades.Columns["porcentaje"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DgvNovedades.Columns["monto"].Visible = true;
            DgvNovedades.Columns["monto"].HeaderText = "Monto";
            DgvNovedades.Columns["monto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DgvNovedades.Columns["monto"].DefaultCellStyle.Format = "c";


            DgvNovedades.Columns["detalle"].Visible = true;
            DgvNovedades.Columns["detalle"].HeaderText = "Detalle";
            if (Convert.ToInt32(cboUsuario.SelectedValue) != 0)
            {
                DgvNovedades.Columns["locacion"].Visible = true;
                DgvNovedades.Columns["locacion"].HeaderText = "Locacion";
                DgvNovedades.Columns["locacion"].DisplayIndex = 0;

            }


            DgvNovedades.Columns["imprime"].Visible = true;
            DgvNovedades.Columns["imprime"].HeaderText = "Mostrar";
            DgvNovedades.Columns["imprime"].DisplayIndex = DgvNovedades.ColumnCount - 1;



        }
        private void PintarGRilla()
        {
            foreach (DataGridViewRow item in DgvNovedades.Rows)
            {
                int idLocacion = Convert.ToInt32(item.Cells["id_usuarios_locaciones"].Value);
                int idServicio = Convert.ToInt32(item.Cells["id_servicios"].Value);
                if ((idLocacion == 0) && (idServicio == 0))
                    item.DefaultCellStyle.BackColor = Color.LightGreen;
                if ((idLocacion != 0) && (idServicio == 0))
                    item.DefaultCellStyle.BackColor = Color.LightBlue;
                if ((idLocacion != 0) && (idServicio != 0))
                    item.DefaultCellStyle.BackColor = Color.White;


            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void btnElimina_Click(object sender, EventArgs e)
        {
            if (DgvNovedades.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("¿Desea eliminar el Registro Seleccionado?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        oNov.Eliminar(Convert.ToInt32(DgvNovedades.SelectedRows[0].Cells["Ids"].Value.ToString()));
                        filtra_por_locaciones();
                    }
                    catch { }
                }
            }
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUsuariosCtaCteNovedades_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();

        }

        private void btnEdita_Click(object sender, EventArgs e)
        {
            if (DgvNovedades.Rows.Count > 0)
            {
                Editar();
            }
        }
        private void Editar()
        {
            SeleccionarNovedad();
            frmUsuariosCtaCteNovedadesDetalle frm = new frmUsuariosCtaCteNovedadesDetalle();
            frmPopUp oPop = new frmPopUp();
            oPop.Formulario = frm;
            oPop.Maximizar = false;
            frm.oNov = this.oNov;
            if (oPop.ShowDialog() == DialogResult.OK)
            {
                filtra_por_locaciones();
            }

        }

        private void SeleccionarNovedad()
        {
            oNov.Id = Convert.ToInt32(DgvNovedades.SelectedRows[0].Cells["ids"].Value);
            oNov.Fecha_Desde = Convert.ToDateTime(DgvNovedades.SelectedRows[0].Cells["fecha_desde"].Value.ToString());
            oNov.Fecha_Hasta = Convert.ToDateTime(DgvNovedades.SelectedRows[0].Cells["fecha_hasta"].Value.ToString());
            oNov.Detalle = DgvNovedades.SelectedRows[0].Cells["detalle"].Value.ToString();
            oNov.Imprimir = Convert.ToInt32(DgvNovedades.SelectedRows[0].Cells["idimprime"].Value);
            oNov.Porcentaje = Convert.ToDecimal(DgvNovedades.SelectedRows[0].Cells["porcentaje"].Value);
            oNov.Monto = Convert.ToDecimal(DgvNovedades.SelectedRows[0].Cells["monto"].Value);
            oNov.Id_Origen = oNov.Imprimir = Convert.ToInt32(DgvNovedades.SelectedRows[0].Cells["id_origen"].Value);

        }
        private void btnAplicar_Click(object sender, EventArgs e)
        {



        }

        private void btnCancela_Click(object sender, EventArgs e)
        {

        }

        private void chkFinaliza_CheckedChanged(object sender, EventArgs e)
        {


        }

        private void Nuevo()
        {
            frmUsuariosCtaCteNovedadesDetalle frm = new frmUsuariosCtaCteNovedadesDetalle(dtSoloLocaciones);
            frmPopUp oPop = new frmPopUp();
            oPop.Formulario = frm;
            oPop.Maximizar = false;
            frm.oNov.Id = 0;

            if (oPop.ShowDialog() == DialogResult.OK)
            {
                ComenzarCarga();
            }

        }

        private void cboLocaciones_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                filtra_por_locaciones();
                int idLocacion = Convert.ToInt32(cboLocaciones.SelectedValue);
                if (idLocacion != 0)
                {
                    DataTable dt = oUsuariosServicios.Listar_Servicios_Activos(idLocacion);
                    cboServicios.DataSource = dt;
                    DataRow drTodos = dt.NewRow();
                    drTodos["id_servicios"] = 0;
                    drTodos["servicio"] = "TODOS";
                    dt.Rows.Add(drTodos);
                    cboServicios.DisplayMember = "servicio";
                    cboServicios.ValueMember = "id_servicios";
                    cboServicios.Enabled = true;
                    cboServicios.SelectedValue = 0;
                    lblTotalReg.Text = "Total de registros: " + DgvNovedades.Rows.Count;

                }
                else
                {
                    if (Usuarios.CurrentUsuario.Id != 0)
                        cboServicios.Enabled = false;
                }

            }
            catch (Exception)
            {

            }
        }

        private void cboServicios_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                int idServicioSeleccionado = Convert.ToInt32(cboServicios.SelectedValue);
                if (idServicioSeleccionado == 0)
                {
                    filtra_por_locaciones();

                }
                else
                {

                    DataView dvNovedades = dtNovedades.DefaultView;
                    dvNovedades.RowFilter = string.Format("id_servicios={0} and id_tipo_facturacion={1}", idServicioSeleccionado, Convert.ToInt32(cboTipoFacturacion.SelectedValue));
                    DgvNovedades.DataSource = dvNovedades;
                    Grilla_Novedades();
                    lblTotalReg.Text = "Total de registros: " + DgvNovedades.Rows.Count;


                }
            }
            catch (Exception)
            {

            }
        }

        private void DgvNovedades_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvNovedades.SelectedRows.Count > 0)
            {
                try
                {
                    SeleccionarNovedad();
                    if (oNov.Id_Origen == Convert.ToInt32(Usuarios_Servicios_Novedades.Origen.SISTEMA))
                    {
                        btnEdita.Enabled = false;
                        btnElimina.Enabled = false;
                    }
                    else
                    {
                        btnEdita.Enabled = true;
                        btnElimina.Enabled = true;
                    }
                    string detalle = DgvNovedades.SelectedRows[0].Cells["detalle"].Value.ToString();
                    lblDetalle.Text = "Detalle: " + detalle;
                    lblDetalle.Visible = true;
                }
                catch (Exception)
                {

                }
            }
            else
                lblDetalle.Visible = false;
        }

        private void DgvNovedades_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            PintarGRilla();

        }

        private void DgvNovedades_Leave(object sender, EventArgs e)
        {
            lblDetalle.Visible = false;
        }

        private void cboUsuario_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                int idUsuario = Convert.ToInt32(cboUsuario.SelectedValue);
                if (idUsuario == 0)
                {
                    lblLocaciones.Visible = false;
                    cboLocaciones.Visible = false;
                    cboServicios.Enabled = true;
                    cboTipoFacturacion.Visible = true;
                    lblTipoFacturacion.Visible = true;
                    lblServicios.Location = lblLocaciones.Location;
                    cboServicios.Location = cboLocaciones.Location;
                    int tipoFacturacion = oConfig.GetValor_N("Id_Tipo_Facturacion");
                    if (tipoFacturacion == Convert.ToInt32(Tipo_Facturacion.Id_Tipo_Facturacion.POR_ZONAS))
                    {
                        lblTipoFacturacion.Text = "Zona";
                        dtZonasCategorias = oZonas.Listar();
                    }
                    else
                    {
                        lblTipoFacturacion.Text = "Categoria";
                        dtZonasCategorias = oServiciosCategorias.Listar();
                    }
                    cboTipoFacturacion.DataSource = dtZonasCategorias;
                    cboTipoFacturacion.DisplayMember = "Nombre";
                    cboTipoFacturacion.ValueMember = "Id";
                    BuscarTodosUsuarios(Convert.ToInt32(cboTipoFacturacion.SelectedValue), Convert.ToInt32(cboServicios.SelectedValue));
                }
                else
                {
                    lblLocaciones.Visible = true;
                    cboLocaciones.Visible = true;
                    cboTipoFacturacion.Visible = false;
                    lblTipoFacturacion.Visible = false;
                    lblServicios.Location = oPointServicioslbl;
                    cboServicios.Location = oPointServicios;
                }
            }
            catch (Exception)
            {
            }
        }

        private void cboTipoFacturacion_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                int idTipoFac = Convert.ToInt32(cboTipoFacturacion.SelectedValue);
                dtServicios = oSer.ListarPorTipoFacturacion(idTipoFac);
                cboServicios.DataSource = dtServicios;
                cboServicios.DisplayMember = "descripcion";
                cboServicios.ValueMember = "id_servicios";
                cboServicios.Enabled = true;
                DataView dvNovedades = dtNovedades.DefaultView;
                dvNovedades.RowFilter = string.Format("id_servicios={0} and id_tipo_facturacion={1}", Convert.ToInt32(cboServicios.SelectedValue), Convert.ToInt32(cboTipoFacturacion.SelectedValue));
                DgvNovedades.DataSource = dvNovedades;
                Grilla_Novedades();
            }
            catch (Exception)
            {
            }

        }

        private void cboUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboLocaciones_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void BuscarTodosUsuarios(int idTipoFac, int idServicio)
        {
            oNov.Tipo_Busqueda = "T";
            dtNovedades = oNov.Listar();
            dtNovedades.Columns.Add("Termina", typeof(String));
            foreach (DataRow dr in dtNovedades.Rows)
            {

                if (Convert.ToInt32(dr["finaliza"].ToString()) == 1)
                    dr["Termina"] = dr["fecha_hasta"].ToString();
                else
                    dr["Termina"] = "...";

            }
            DgvNovedades.DataSource = null;
            DataView dvNovedades = dtNovedades.DefaultView;
            dvNovedades.RowFilter = string.Format("id_servicios={0} and id_tipo_Facturacion={1} and id_usuarios=0", Convert.ToInt32(cboServicios.SelectedValue), Convert.ToInt32(cboTipoFacturacion.SelectedValue));
            DgvNovedades.DataSource = dvNovedades;
            Grilla_Novedades();


        }
    }
}
