using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;
using CapaPresentacion;
using CapaNegocios;

namespace CapaPresentacion
{
    public partial class FrmCass_Usuarios : Form
    {

        #region Propiedades

        private Thread hilo;
        private delegate void myDel();
        private DataTable dt_cass, dt_tarjeta_existente, dtUser, dtEquipos_Tarjetas, dtUsuario_Servicio, dtServiciosContratados;
        private DataTable  dt_Tarjeta_Asignada;
        private Cass oCass = new Cass(2);
        private Usuarios_Servicios oUsu_Ser = new Usuarios_Servicios();
        private Equipos oEquipo = new Equipos();
        private Equipos_Tarjetas oTarjeta = new Equipos_Tarjetas();
        private DataView dtvCass;
        int Verificacion = 0, idEquipo = 0 ,Id_Equipo_Asignado = 0, idServicio =0, idUsuarioServicio =0, idEquipoTipo=0 ;
        int cont, idUsuario = 0, id_cass_usuario = 0, id_Tarjeta = 0;
        private string Descripcion_Servicio = string.Empty;
        Int32 FilasTotales;

        public FrmCass_Usuarios()
        {
            InitializeComponent();
        }

        #endregion

        #region Metodos
        private void comenzarCarga()
        {
            dgv.DataSource = null;
            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
        }
        private void cargarDatos()
        {
            try
            {
                dt_cass = oCass.ListarUsuariosSistemaViejo();
                myDel MD = new myDel(asignarDatos);
                this.Invoke(MD, new object[] { });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Informacion" + ex.Message);
            }

        }
        private void asignarDatos()
        {

            dgv.DataSource = dt_cass;
            for (int i = 0; i < dgv.ColumnCount; i++)
                dgv.Columns[i].Visible = false;

            
            AgregarColumna();
            ColorearGrilla();
            dgv.Columns["usuario"].Visible = true;
            dgv.Columns["codigo_gies"].Visible = true;
            dgv.Columns["nombre_paquete"].Visible = true;
            dgv.Columns["codigo_Viejo"].Visible = true;
            dgv.Columns["servicio"].Visible = true;
            dgv.Columns["estado"].Visible = true;
            dgv.Columns["tarjeta"].Visible = true; 
            dgv.Columns["CASS"].Visible = true;
            dgv.Columns["GIES"].Visible = true;

            dgv.Columns["Usuario"].HeaderText = "Usuario";
            dgv.Columns["codigo_gies"].HeaderText = "CodGIES";
            dgv.Columns["nombre_paquete"].HeaderText = "Paquete"; 
            dgv.Columns["codigo_Viejo"].HeaderText = "CodViejo";
            dgv.Columns["servicio"].HeaderText = "Servicio";
            dgv.Columns["estado"].HeaderText = "Estado";
            dgv.Columns["tarjeta"].HeaderText = "Tarjeta";
            dgv.Columns["CASS"].HeaderText = "CASS";
            dgv.Columns["GIES"].HeaderText = "GIES";
            lblTotal.Text = String.Format("Total de Registros: {0}", FilasTotales);

        }
        private void ColorearGrilla()
        {
            FilasTotales = 0;
            if (dgv.Rows.Count > 0) 
            {
                foreach (DataGridViewRow item in dgv.Rows) 
                {
                    int Realizado = Convert.ToInt32(item.Cells["realizado"].Value.ToString());
                    if(Realizado == (int) Cass.ESTADOS_TARJETAS.ASIGNADA)
                        item.DefaultCellStyle.BackColor = Color.LightGreen;
                    else
                        item.DefaultCellStyle.BackColor = Color.Gray;

                    FilasTotales++;

                }
            }
        }
        private void AgregarColumna() 
        {
            if (cont < 1)
            {
                DataGridViewLinkColumn ctotal = new DataGridViewLinkColumn();
                ctotal.Text = "Ver CASS";
                ctotal.DataPropertyName = "Cass";
                ctotal.Name = "Cass";
                ctotal.LinkColor = Color.DarkOrchid;
                ctotal.VisitedLinkColor = Color.Violet;
                ctotal.UseColumnTextForLinkValue = true;
                ctotal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                ctotal.Width = 100;
                ctotal.HeaderText = "Cass";
                dgv.Columns.Add(ctotal);

                DataGridViewLinkColumn ctotal2 = new DataGridViewLinkColumn();
                ctotal2.Text = "Ver GIES";
                ctotal2.DataPropertyName = "GIES";
                ctotal2.Name = "GIES";
                ctotal2.LinkColor = Color.DarkOrchid;
                ctotal2.VisitedLinkColor = Color.Violet;
                ctotal2.UseColumnTextForLinkValue = true;
                ctotal2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                ctotal2.Width = 100;
                ctotal2.HeaderText = "GIES";
                dgv.Columns.Add(ctotal2);

                cont = cont + 1;
            }
        }
        private int VerificarTarjeta_Equipo(string Tarjeta) 
        {
            dtEquipos_Tarjetas = oTarjeta.Verificar_Tarjeta_Disponible(Tarjeta);
            if(dtEquipos_Tarjetas.Rows.Count > 0)
                Id_Equipo_Asignado = Convert.ToInt32(dtEquipos_Tarjetas.Rows[0]["id_Equipo"]);
            if (dtEquipos_Tarjetas.Rows.Count > 0 && Id_Equipo_Asignado > 0)
                return 1;
            else
                return 0;            
        }

        private void CargarEstados_Tarjetas()
        {
            if (dgv.Rows.Count > 0)
            {
                foreach (DataGridViewRow item in dgv.Rows)
                {
                    int Estado = 0;
                    int id_cass_usuario2 = 0;
                    int Realizado = 0;
                    Verificacion = VerificarTarjeta_Equipo(item.Cells["Tarjeta"].Value.ToString());
                    Realizado = Convert.ToInt32(item.Cells["Realizado"].Value.ToString());
                    id_cass_usuario2 = Convert.ToInt32(item.Cells["id_cass_usuarios"].Value.ToString());
                    if (Realizado == 0)
                    {
                        if (Verificacion == 0)
                        {
                            Estado = (int)Cass.ESTADOS_TARJETAS.SIN_ASIGNAR;
                            oUsu_Ser.Actualizar_UsuariosServicios_Equipos(idEquipo, idUsuario, idUsuarioServicio, id_cass_usuario2, Estado, 0, 0);
                        }
                        else
                        {
                            Estado = (int)Cass.ESTADOS_TARJETAS.ASIGNADA;
                            oUsu_Ser.Actualizar_UsuariosServicios_Equipos(idEquipo, idUsuario, idUsuarioServicio, id_cass_usuario2, Estado, 0, 0);
                        }
                    }

                }
            }       
        }

      
        private void CargarEquipo()
        {
            if (txtUsuario.Text == "" || txtServicios.Text == "")
                MessageBox.Show("Debe seleccionar un Usuario y un Servicio.");
            else 
            {
                if (idServicio > 0)
                {
                    DataTable dtEquiposStock = new DataTable();
                    dtEquiposStock = oEquipo.TraerEquiposPorTipoServicio(idServicio);
                    idEquipo = 0;
                    if (txtTarjeta.Text == "" || txtTarjeta.Text == "0")
                        MessageBox.Show("Ingrese un valor de tarjeta valido");
                    else
                    {
                        Verificacion = 0;
                        Verificacion = VerificarTarjeta_Equipo(txtTarjeta.Text);
                        string Descripcion = string.Empty;
                        if (Verificacion == 0)
                        {
                            using (frmPopUp frm = new frmPopUp())
                            {
                                frmEquiposEnStock frmEquipos = new frmEquiposEnStock();
                                frmEquipos.dtEquiposEnStock = dtEquiposStock;
                                frm.Formulario = frmEquipos;
                                frm.Maximizar = false;

                                if (frm.ShowDialog() == DialogResult.OK)
                                    cargarDatos();

                                idEquipo = frmEquipos.id_Equipo;
                                Descripcion = frmEquipos.Descripcion;
                                idEquipoTipo = frmEquipos.id_Equipo_tipo;

                            }
                            txtEquipo.Text = idEquipo.ToString() + " - " + Descripcion;
                        }
                        else 
                        {
                            if (MessageBox.Show("Tarjeta ya asignada a un equipo. ¿ Desea usar el equipo ?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                dt_Tarjeta_Asignada = oTarjeta.Listar_Tarjeta_AsignadaAEquipo(txtTarjeta.Text);
                                idEquipo = Convert.ToInt32(dt_Tarjeta_Asignada.Rows[0]["id_Equipo"]);
                                txtEquipo.Text = idEquipo.ToString() + " - SETOPBOX MINETTI" ;
                            }
                        }
                            
                    }
                }
                else
                    MessageBox.Show("Seleccione un servicio.");                
            }
        }
        #endregion

        #region Eventos
        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCargarEstadosTarjetas_Click(object sender, EventArgs e)
        {
            CargarEstados_Tarjetas();
            comenzarCarga();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            dtvCass = new DataView(dt_cass);
            dtvCass.RowFilter = String.Format("Realizado = {0}", (int)Cass.ESTADOS_TARJETAS.ASIGNADA);
            dt_cass = dtvCass.ToTable();
            dgv.DataSource = dt_cass;
            ColorearGrilla();
            lblTotal.Text = String.Format("Total de Registros: {0}", FilasTotales);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            dtvCass = new DataView(dt_cass);
            dtvCass.RowFilter = String.Format("Realizado = {0}", (int)Cass.ESTADOS_TARJETAS.SIN_ASIGNAR);
            dt_cass = dtvCass.ToTable();
            dgv.DataSource = dt_cass;
            ColorearGrilla();
            lblTotal.Text = String.Format("Total de Registros: {0}", FilasTotales);
        }

        private void FrmCass_Usuarios_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
        private void FrmCass_Usuarios_Load(object sender, EventArgs e)
        {
            comenzarCarga();
            
        }
        private void dgv_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dtServiciosContratados = oUsu_Ser.ListarServiciosYSubServiciosActivosCASS(Convert.ToInt32(dgv.SelectedRows[0].Cells["Id_Usu"].Value.ToString()));
            Usuarios.Current_dtServicios = dtServiciosContratados;
            DataView dv = new DataView(dtServiciosContratados);
            dv.Sort = "id_usuario_servicio, id_Tipo";
            dtServiciosContratados = dv.ToTable();
            dtUser = oCass.ListarPaquetesUser(dgv.SelectedRows[0].Cells["Codigo_gies"].Value.ToString());
            int codGies = Convert.ToInt32(dgv.SelectedRows[0].Cells["Codigo_gies"].Value);
            dtUsuario_Servicio = oUsu_Ser.ListarUsuariosServicios(codGies);

            if (dgv.Columns[e.ColumnIndex].Name == "Cass")
            {
                try 
                { 
                    if(Convert.ToString(dgv.SelectedRows[0].Cells["Codigo_gies"].Value.ToString()) == "0")
                    { 
                        
                        FrmCass frmGies = new FrmCass("", Convert.ToInt32(dtServiciosContratados.Rows[0]["id_usuario_servicio"]));
                        frmGies.ShowDialog();
                    }
                    else 
                    { 
                        FrmCass frmGies = new FrmCass(Convert.ToString(dgv.SelectedRows[0].Cells["Tarjeta"].Value), Convert.ToInt32(dtServiciosContratados.Rows[0]["id_usuario_servicio"]));
                        frmGies.ShowDialog();
                    }
                }
                catch
                {
                    MessageBox.Show("No se encontro dicha tarjeta relacionada a un usuario/equipo.");
                }
                asignarDatos();
            }

            else if (dgv.Columns[e.ColumnIndex].Name == "GIES")
            {
                try 
                {

                    FrmCass_Tarjetas frmGies = new FrmCass_Tarjetas();                  
                    frmGies.dtUsuario = dtServiciosContratados;
                    frmGies.Tarjeta = Convert.ToString(Convert.ToString(dgv.SelectedRows[0].Cells["Tarjeta"].Value));
                    frmGies.ShowDialog();

                    asignarDatos();
                }
                catch
                {
                    MessageBox.Show("No se puede inicializar el GIES ya que la tarjeta no es correcta.");
                }
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            CargarEquipo();
            dgv.Focus();
        }
        private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try 
            { 
                txtTarjeta.Text = dgv.SelectedRows[0].Cells["tarjeta"].Value.ToString();
            }
            catch { }
        }
        private void btnUsuario_Click(object sender, EventArgs e)
        {
        }
        private void btnUsuarioActual_Click(object sender, EventArgs e)
        {
        }
        private void btnEquipoRapido_Click(object sender, EventArgs e)
        {
            idEquipo = 0;
            Verificacion = 0;
            if (txtTarjeta.Text == "" || txtTarjeta.Text == "0")
                MessageBox.Show("Ingrese un valor de tarjeta valido");
            else 
            {
                if (txtUsuario.Text == "" || txtServicios.Text == "")
                        MessageBox.Show("Debe seleccionar un Usuario y un Servicio.");
                else { 
                    Verificacion = VerificarTarjeta_Equipo(txtTarjeta.Text);
                    if (Verificacion == 0)
                    {
                        Abms.frmAsignacionMinetti ofrm = new Abms.frmAsignacionMinetti();
                        ofrm.Viene = 1;
                        ofrm.Tarjeta = txtTarjeta.Text;
                        ofrm.Serie_Equipo = txtTarjeta.Text;
                        ofrm.ShowDialog();

                        idEquipo = ofrm.idEquipo;
                    }
                    else 
                    { 
                        if (MessageBox.Show("Tarjeta ya asignada a un equipo. ¿ Desea usar el equipo ?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) 
                        { 
                            dt_Tarjeta_Asignada = oTarjeta.Listar_Tarjeta_AsignadaAEquipo(txtTarjeta.Text);
                            idEquipo = Convert.ToInt32(dt_Tarjeta_Asignada.Rows[0]["id_Equipo"]);
                        }
                    }

                    txtEquipo.Text = idEquipo.ToString() + " - SETOPBOX MINETTI";

                    dgv.Focus();
                }
            }
        }

        private void btnUsuarioActual_Click_1(object sender, EventArgs e)
        {
            idUsuario = Convert.ToInt32(dgv.SelectedRows[0].Cells["id_usu"].Value.ToString());
            txtUsuario.Text = dgv.SelectedRows[0].Cells["codigo_gies"].Value.ToString() + " - " + dgv.SelectedRows[0].Cells["Usuario"].Value.ToString();
            dgv.Focus();
        }

        private void txtBuscador_TextChanged(object sender, EventArgs e)
        {
            dt_cass.DefaultView.RowFilter = String.Format("usuario LIKE '%{0}%' OR nombre_paquete LIKE '%{0}%' OR Convert([codigo_gies], System.String) LIKE '%{0}%' OR codigo_viejo LIKE '%{0}%' OR servicio LIKE '%{0}%' OR estado LIKE '%{0}%' OR tarjeta LIKE '%{0}%'", txtBuscador.Text);
            asignarDatos();
        }

        private void btnUsuario_Click_1(object sender, EventArgs e)
        {
            int id_usuario_nuevo;
            CapaPresentacion.Busquedas.frmBusquedaUsuarios frm = new CapaPresentacion.Busquedas.frmBusquedaUsuarios(1, "", "");
            frmPopUp frmPop = new frmPopUp();
            frmPop.Formulario = frm;

            if (frmPop.ShowDialog() == DialogResult.OK)
            {
                idUsuario = frm.id_usuario;
                txtUsuario.Text = frm.apellido.Trim() + " , " + frm.nombre.Trim() + " [" + frm.codigo.ToString().Trim() + "]";
                comenzarCarga();
            }
            dgv.Focus();
        }

        private void btnServicios_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
                MessageBox.Show("Debe seleccionar un usuario.");
            else
            {
                frmServiciosUsuarios ofrm = new frmServiciosUsuarios();
                ofrm.id_usuario = Convert.ToInt32(idUsuario);
                ofrm.ShowDialog();

                idServicio = ofrm.id_servicio;
                Descripcion_Servicio = ofrm.Descripcion;
                idUsuarioServicio = ofrm.id_usuario_servicio;
                txtServicios.Text = idServicio.ToString() + "-" + Descripcion_Servicio;

            }
            dgv.Focus();
        }

        private void btnGuardarTarjeta_Click(object sender, EventArgs e)
        {
            dt_tarjeta_existente = oTarjeta.Listar_Tarjetas(txtTarjeta.Text);
            if (dt_tarjeta_existente.Rows.Count > 0)
                id_Tarjeta = Convert.ToInt32(dt_tarjeta_existente.Rows[0]["id"]);
            else 
            {
                oTarjeta.Id_Equipos_Tipos = idEquipoTipo;
                oTarjeta.Id_Estado = (int)Equipos_Tarjetas.Tarjetas_Estados.ENTREGADA;
                oTarjeta.Numero = txtTarjeta.Text;
                oTarjeta.Id = oTarjeta.Guardar(oTarjeta);
                id_Tarjeta = oTarjeta.Id;
            }
            id_cass_usuario = 0;
            id_cass_usuario = Convert.ToInt32(dgv.SelectedRows[0].Cells["id_cass_usuarios"].Value.ToString());
            if ((txtTarjeta.Text == "0" || txtTarjeta.Text == "") || txtEquipo.Text == "" || txtUsuario.Text == "")
                MessageBox.Show("Complete todos los campos.");
            else 
            {
                oUsu_Ser.Actualizar_UsuariosServicios_Equipos(idEquipo, idUsuario, idUsuarioServicio, id_cass_usuario, (int)Cass.ESTADOS_TARJETAS.ASIGNADA, 1, id_Tarjeta);               
            }

            comenzarCarga();
            dgv.Focus();

        }
        #endregion
    }
}
