using CapaNegocios;
using CapaPresentacion.Impresiones;
using CapaPresentacion.Partes_Trabajo;
using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Debitos_Automaticos
{
    public partial class frmDebitosBaja : Form
    {
        private int idUltimoUsuarioGenerado;
        private int codUsuario;
        private string nroPlastico;
        Thread hilo;
        private delegate void myDel();
        Impresion oImpresiones = new Impresion();
        private bool generarBaja;
        private Plasticos oPlasticos = new Plasticos();
        private Plasticos_Usuarios oPlasticosUsuarios = new Plasticos_Usuarios();
        private DataTable dtPlasticos = new DataTable();
        private DataTable dtPlasticosUsuarios = new DataTable();
        private DataTable dtUsuariosServiciosBaja = new DataTable();

        private void ComenzarCarga()
        {
            pgCircular.Start();
            hilo = new Thread(new ThreadStart(CargarDatos));
            hilo.IsBackground = true;
            hilo.Start();
        }

        private void CargarDatos()
        {
            try
            {
                if (generarBaja)
                {

                }
                else
                {
                    dtPlasticos = oPlasticos.Listar(nroPlastico, codUsuario);
                    if (dtPlasticos.Rows.Count > 0)
                    {
                        myDel MD = new myDel(AsignarDatos);
                        this.Invoke(MD, new object[] { });
                    }
                    else
                    {
                        myDel MD = new myDel(Limpiar);
                        this.Invoke(MD, new object[] { });
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar información.");
            }
            pgCircular.Stop();
        }

        private void Limpiar()
        {
            dgvPlasticos.DataSource = null;
            dgvServiciosAsociados.DataSource = null;
            lblCondicionServicios.Text = string.Empty;
            lblCondicionServicios.Visible = false;
            lblPlasticos.Visible = false;
            lblServiciosAsociados.Visible = false;
        }

        private void AsignarDatos()
        {
            lblCondicionServicios.Visible = true;
            lblPlasticos.Visible = true;
            lblServiciosAsociados.Visible = true;

            dgvPlasticos.DataSource = dtPlasticos;
            for (int x = 0; x < dgvPlasticos.Columns.Count; x++)
                dgvPlasticos.Columns[x].Visible = false;

            dgvPlasticos.Columns["titular"].Visible = true;
            dgvPlasticos.Columns["numero"].Visible = true;
            dgvPlasticos.Columns["vencimiento"].Visible = true;
            dgvPlasticos.Columns["formapago"].Visible = true;

            dgvPlasticos.Columns["titular"].HeaderText = "Titular";
            dgvPlasticos.Columns["numero"].HeaderText = "Número";
            dgvPlasticos.Columns["vencimiento"].HeaderText = "Vencimiento";
            dgvPlasticos.Columns["formapago"].HeaderText = "Forma de pago";

            dgvPlasticos.Columns["titular"].ReadOnly = true;
            dgvPlasticos.Columns["numero"].ReadOnly = true;
            dgvPlasticos.Columns["vencimiento"].ReadOnly = true;
            dgvPlasticos.Columns["formapago"].ReadOnly = true;

            dgvPlasticos.Columns["titular"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPlasticos.Columns["numero"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPlasticos.Columns["vencimiento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPlasticos.Columns["formapago"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DataView dtvPlasticos = new DataView(dtPlasticos);
            dtvPlasticos.RowFilter = String.Format("activo=1");
            dtPlasticos = dtvPlasticos.ToTable();

            if (dtPlasticos.Rows.Count > 0)
            {
                lblCondicionServicios.Text = string.Empty;
                DataTable dtAux = new DataTable();
                dtPlasticosUsuarios.Clear();
                foreach (DataRow fila in dtPlasticos.Rows)
                {
                    dtAux.Clear();
                    dtAux = oPlasticosUsuarios.Listar(Convert.ToInt32(fila["id"]), 0);
                    if (dtPlasticosUsuarios.Rows.Count == 0)
                        dtPlasticosUsuarios = dtAux.Copy();
                    else
                    {
                        foreach (DataRow plasticousuario in dtAux.Rows)
                            dtPlasticosUsuarios.ImportRow(plasticousuario);
                    }
                }

                if (dtPlasticosUsuarios.Rows.Count > 0)
                {
                    DataColumn colSeleccionServicios = new DataColumn("colSeleccionServicio", typeof(bool));
                    colSeleccionServicios.DefaultValue = false;

                    dtPlasticosUsuarios.Columns.Add(colSeleccionServicios);

                    DataView dtvPlasticosUsuarios = new DataView(dtPlasticosUsuarios);
                    dtvPlasticosUsuarios.RowFilter = String.Format("activo1 = 1 and borrado = 0");
                    dtPlasticosUsuarios = dtvPlasticosUsuarios.ToTable();

                    dgvServiciosAsociados.DataSource = dtPlasticosUsuarios;
                    for (int x = 0; x < dgvServiciosAsociados.Columns.Count; x++)
                        dgvServiciosAsociados.Columns[x].Visible = false;

                    dgvServiciosAsociados.Columns["codigo"].Visible = true;
                    dgvServiciosAsociados.Columns["servicio"].Visible = true;
                    dgvServiciosAsociados.Columns["usuario"].Visible = true;
                    dgvServiciosAsociados.Columns["tiposervicio"].Visible = true;
                    dgvServiciosAsociados.Columns["colSeleccionServicio"].Visible = true;
                    dgvServiciosAsociados.Columns["locacion"].Visible = true;

                    dgvServiciosAsociados.Columns["servicio"].HeaderText = "Servicio";
                    dgvServiciosAsociados.Columns["usuario"].HeaderText = "Usuario";
                    dgvServiciosAsociados.Columns["tiposervicio"].HeaderText = "Tipo de servicio";
                    dgvServiciosAsociados.Columns["colSeleccionServicio"].HeaderText = "Seleccionar";
                    dgvServiciosAsociados.Columns["locacion"].HeaderText = "Locacion";
                    dgvServiciosAsociados.Columns["codigo"].HeaderText = "Codigo de Usuario";

                    dgvServiciosAsociados.Columns["servicio"].ReadOnly = true;
                    dgvServiciosAsociados.Columns["usuario"].ReadOnly = true;
                    dgvServiciosAsociados.Columns["tiposervicio"].ReadOnly = true;
                    dgvServiciosAsociados.Columns["colSeleccionServicio"].ReadOnly = false;
                    dgvServiciosAsociados.Columns["locacion"].ReadOnly = true;
                    dgvServiciosAsociados.Columns["codigo"].ReadOnly = true;
                    dgvServiciosAsociados.Columns["colSeleccionServicio"].Width = 70;
                    dgvServiciosAsociados.Columns["codigo"].Width = 70;

                    dgvServiciosAsociados.Columns["servicio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvServiciosAsociados.Columns["usuario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvServiciosAsociados.Columns["tiposervicio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvServiciosAsociados.Columns["colSeleccionServicio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvServiciosAsociados.Columns["codigo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    dtPlasticosUsuarios.DefaultView.RowFilter = String.Format("id_plastico='{0}'", dtPlasticos.Rows[0]["id"].ToString());
                }
            }
            else
            {
                lblCondicionServicios.Text = "[NO HAY SERVICIOS ACTIVOS ASOCIADOS AL PLASTICO SELECCIONADO]";
                dgvServiciosAsociados.DataSource = null;
            }


            lblTotal.Text = String.Format("Total de Registros: {0}", dgvPlasticos.Rows.Count);

        }

        private void Buscar()
        {
            generarBaja = false;
            if (rbUsuario.Checked)
            {
                try
                {
                    codUsuario = Convert.ToInt32(txtBuscar.Text);
                    nroPlastico = "0";
                    ComenzarCarga();
                }
                catch (OverflowException)
                {
                    MessageBox.Show("Numero demaciado grande para un usuario");
                    rbNumeroPlastico.Focus();
                }
            }
            else
            {
                codUsuario = 0;
                nroPlastico = txtBuscar.Text;
                ComenzarCarga();
            }
        }

        private void GenerarBaja()
        {
            try
            {
                generarBaja = true;
                Partes oPartes = new Partes();
                Partes_Usuarios_Servicios oPartesUsuariosServicios = new Partes_Usuarios_Servicios();
                DataRow drAgregar;
                int cantiadSeleccionados = dtPlasticosUsuarios.Select("colSeleccionServicio=True").Count();

                if (dgvPlasticos.SelectedRows.Count > 0 || cantiadSeleccionados > 0)
                {
                    DataRow[] drAux = dtPlasticosUsuarios.Select("colSeleccionServicio=True");
                    int aux = 0, flag = 0;
                    foreach (DataRow row in drAux)
                    {
                        if (aux == 0)
                            aux = Convert.ToInt32(row["codigo"]);
                        else if (aux != Convert.ToInt32(row["codigo"]))
                            flag = 1;
                    }
                    if (flag == 0)
                    {
                        if (dgvPlasticos.SelectedRows.Count > 0)
                        {
                            foreach (DataRow dr in dtPlasticosUsuarios.Select(String.Format("id_plastico='{0}'", dgvPlasticos.SelectedRows[0].Cells["id"].Value.ToString())))
                            {
                                if (Convert.ToBoolean(dr["colSeleccionServicio"]) == true)
                                {

                                    drAgregar = dtUsuariosServiciosBaja.NewRow();
                                    drAgregar["idparte"] = "0";
                                    drAgregar["idusuariosservicios"] = dr["id_usuarios_servicios"];
                                    drAgregar["idservicio"] = dr["id_servicios"];
                                    drAgregar["borrado"] = "0";
                                    drAgregar["idaplicacionexterna"] = "0";
                                    drAgregar["configurado"] = "0";
                                    drAgregar["idpartefalla"] = Tablas.DataSolicitudes.Select(String.Format("id_servicios_tipos='{0}' and id_partes_operaciones='{1}'", dr["id_servicios_tipo"].ToString(), Convert.ToInt16(Partes.Partes_Operaciones.BAJA_DE_DEBITO).ToString()))[0]["id"].ToString();
                                    drAgregar["idpartesolucion"] = "0";
                                    drAgregar["idusuarios"] = dr["id_usuarios"];
                                    drAgregar["idplastico"] = dr["id_plastico"];
                                    drAgregar["id_locacion"] = dr["id_usuarios_locaciones"];
                                    dtUsuariosServiciosBaja.Rows.Add(drAgregar);
                                }
                            }
                        }
                        else
                        {
                            foreach (DataRow dr in dtPlasticosUsuarios.Select("colSeleccionServicio=True"))
                            {
                                drAgregar = dtUsuariosServiciosBaja.NewRow();
                                drAgregar["idparte"] = "0";
                                drAgregar["idusuariosservicios"] = dr["id_usuarios_servicios"];
                                drAgregar["idservicio"] = dr["id_servicios"];
                                drAgregar["borrado"] = "0";
                                drAgregar["idaplicacionexterna"] = "0";
                                drAgregar["configurado"] = "0";
                                drAgregar["idpartefalla"] = Tablas.DataSolicitudes.Select(String.Format("id_servicios_tipos='{0}' and id_partes_operaciones='{1}'", dr["id_servicio_tipo"].ToString(), Convert.ToInt16(Partes.Partes_Operaciones.BAJA_DE_DEBITO).ToString()))[0]["id"].ToString();
                                drAgregar["idpartesolucion"] = "0";
                                drAgregar["idusuarios"] = dr["id_usuarios"];
                                drAgregar["idplastico"] = dr["id_plastico"];
                                drAgregar["id_locacion"] = dr["id_locacion"];
                                dtUsuariosServiciosBaja.Rows.Add(drAgregar);
                            }
                        }
                        oPartes.Id_Servicios = 0;
                        oPartes.Id_Usuarios_Servicios = 0;
                        oPartes.Id_Usuarios = Convert.ToInt32(dtUsuariosServiciosBaja.Rows[0]["idusuarios"]);
                        oPartes.Id_Usuarios_Locaciones = Convert.ToInt32(dtUsuariosServiciosBaja.Rows[0]["id_locacion"]);
                        oPartes.Id_Zonas = 0;
                        oPartes.Id_Partes_Fallas = Convert.ToInt32(dtUsuariosServiciosBaja.Rows[0]["idpartefalla"]);
                        oPartes.Id_Partes_Soluciones = 0;
                        oPartes.Id_Tecnico = Personal.Id_Login;
                        oPartes.Id_Movil = 0;
                        oPartes.Id_Operadores = Personal.Id_Login;
                        oPartes.Id_Areas = Personal.Id_Area;
                        oPartes.Fecha_Programado = dtpFechaBaja.Value;
                        oPartes.Id_Partes_Estados = Convert.ToInt32(Partes.Partes_Estados.ASIGNADO);
                        oPartes.Fecha_Reclamo = DateTime.Now;
                        oPartes.Detalle_Falla = "BAJA DE DÉBITO";
                        oPartes.Detalle_Solucion = "";
                        oPartes.Observacion = Personal.Name_Login;
                        oPartes.Id_Usuarios_Cuenta_Corriente = 0;
                        oPartes.Id = oPartes.Guardar(oPartes, 0);

                        foreach (DataRow fila in dtUsuariosServiciosBaja.Rows)
                        {
                            oPartesUsuariosServicios.Id_Parte = oPartes.Id;
                            oPartesUsuariosServicios.Id_Servicio = Convert.ToInt32(fila["idservicio"]);
                            oPartesUsuariosServicios.Id_Usuario_Servicio = Convert.ToInt32(fila["idusuariosservicios"]);
                            oPartesUsuariosServicios.idParteFalla = Convert.ToInt32(fila["idpartefalla"]);
                            oPartesUsuariosServicios.IdPlastico = Convert.ToInt32(fila["idplastico"]);
                            oPartesUsuariosServicios.id_usuarios_servicios_sub = 0;
                            oPartesUsuariosServicios.Guardar(oPartesUsuariosServicios);
                        }
                        if (dtpFechaBaja.Value.Date == DateTime.Now.Date)
                        {
                            string resultado = "";
                            int tipoResultado = 0;
                            if(oPartes.ConfirmarParte(oPartes.Id,0,"",DateTime.Now,Partes.TipoProblemas.OTRO,"",Personal.Id_Login,out tipoResultado, out resultado))
                            {
                                MessageBox.Show("Proceso realizado correctamente.","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Information);
                                DialogResult dialogResult = MessageBox.Show("¿Desea imprimir formulario de baja?", "", MessageBoxButtons.YesNo);
                                if (dialogResult == DialogResult.Yes)
                                {
                                    Impresion oImpresiones = new Impresion();
                                    oImpresiones.ImprimirParte(oPartes.Id, "");
                                }

                                //Se guarda el ultimo usuario al que se le genero una baja
                                this.idUltimoUsuarioGenerado = oPartes.Id_Usuarios;
                                btnHistorial.Enabled = true;
                            }
                            else
                            {
                                MessageBox.Show("Hubo un error al ejecutar el parte de baja de debito automatico.\n N'umero de parte: " + oPartes.Id + "\n Error:  "+resultado, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Log.guardarEvento(Log.ACCION.BAJA_DEBITO_AUTOMATICO, Usuarios.CurrentUsuario.Id, mensaje: resultado);
                            }
                        }
                       
                       

                    }
                    else
                        MessageBox.Show("Los servicios seleccionados deben ser del mismo codigo de usuario");
                }
                else
                    MessageBox.Show("No se han seleccionado débitos o servicios para dar de baja.");
            }
            catch (Exception c)
            {
                MessageBox.Show("Error al realizar el proceso de baja.: " + c.Message);
            }
            dtUsuariosServiciosBaja.Clear();
            generarBaja = false;
        }

        public frmDebitosBaja()
        {
            InitializeComponent();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDebitosBaja_Load(object sender, EventArgs e)
        {
            generarBaja = false;
            rbUsuario.Checked = true;
            dgvPlasticos.ReadOnly = false;
            dgvServiciosAsociados.ReadOnly = false;
            dtUsuariosServiciosBaja.Columns.Add("idparte", typeof(string));
            dtUsuariosServiciosBaja.Columns.Add("idusuariosservicios", typeof(string));
            dtUsuariosServiciosBaja.Columns.Add("idservicio", typeof(string));
            dtUsuariosServiciosBaja.Columns.Add("borrado", typeof(string));
            dtUsuariosServiciosBaja.Columns.Add("idaplicacionexterna", typeof(string));
            dtUsuariosServiciosBaja.Columns.Add("configurado", typeof(string));
            dtUsuariosServiciosBaja.Columns.Add("idpartefalla", typeof(string));
            dtUsuariosServiciosBaja.Columns.Add("idpartesolucion", typeof(string));
            dtUsuariosServiciosBaja.Columns.Add("idusuarios", typeof(string));
            dtUsuariosServiciosBaja.Columns.Add("idplastico", typeof(string));
            dtUsuariosServiciosBaja.Columns.Add("id_locacion", typeof(string));

            if (Usuarios.CurrentUsuario.Id > 0)
            {
                this.codUsuario = Usuarios.CurrentUsuario.Codigo;
                this.nroPlastico = "0";
                txtBuscar.Text = this.codUsuario.ToString();
                pgCircular.Start();
                hilo = new Thread(new ThreadStart(CargarDatos));
                hilo.IsBackground = true;
                hilo.Start();
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBuscar.Text.Length > 0)
                Buscar();
            else
            {
                MessageBox.Show("Datos en blanco.");
                txtBuscar.Focus();
            }
        }

        private void btnGenerarBaja_Click(object sender, EventArgs e)
        {
            GenerarBaja();

        }

        private void dgvPlasticos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dgvServiciosAsociados.Columns["servicio"].Visible = true;
                dgvServiciosAsociados.Columns["tiposervicio"].Visible = true;
                dgvServiciosAsociados.Columns["colSeleccionServicio"].Visible = true;

                dgvServiciosAsociados.Columns["servicio"].HeaderText = "Servicio";
                dgvServiciosAsociados.Columns["tiposervicio"].HeaderText = "Tipo de servicio";
                dgvServiciosAsociados.Columns["colSeleccionServicio"].HeaderText = "Seleccionar";

                dgvServiciosAsociados.Columns["servicio"].ReadOnly = true;
                dgvServiciosAsociados.Columns["tiposervicio"].ReadOnly = true;
                dgvServiciosAsociados.Columns["colSeleccionServicio"].ReadOnly = false;
                dgvServiciosAsociados.Columns["colSeleccionServicio"].Width = 70;

                dgvServiciosAsociados.Columns["servicio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvServiciosAsociados.Columns["tiposervicio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvServiciosAsociados.Columns["colSeleccionServicio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dtPlasticosUsuarios.DefaultView.RowFilter = String.Format("id_plastico='{0}'", dgvPlasticos.SelectedRows[0].Cells["id"].Value.ToString());
            }
            catch { }
        }

        private void dgvPlasticos_SelectionChanged(object sender, EventArgs e)
        {
            dtUsuariosServiciosBaja.Clear();
            if (dtPlasticosUsuarios.Rows.Count > 0)
            {
                foreach (DataRow fila in dtPlasticosUsuarios.Rows)
                    fila["colSeleccionServicio"] = false;
            }
        }

        private void dgvServiciosAsociados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                bool value = !Convert.ToBoolean(dgvServiciosAsociados.Rows[e.RowIndex].Cells["colSeleccionServicio"].Value);
                dgvServiciosAsociados.Rows[e.RowIndex].Cells["colSeleccionServicio"].Value = value;
            }
            catch (Exception)
            { }
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            if (this.idUltimoUsuarioGenerado > 0)
            {
                this.Close();
                frmPopUp frmPop = new frmPopUp();
                frmPartesHistorial frmHistorialPartes;
                frmHistorialPartes = new frmPartesHistorial(idUltimoUsuarioGenerado);
                frmPop.Formulario = frmHistorialPartes;
                frmPop.ShowDialog();
            }
            else
                MessageBox.Show("No se genero ninguna baja");
        }
    }
}//301019fede
