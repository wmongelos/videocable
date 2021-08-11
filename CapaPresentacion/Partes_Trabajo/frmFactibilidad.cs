using CapaNegocios;
using CapaPresentacion.Busquedas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Partes_Trabajo
{
    public partial class frmFactibilidad : Form
    {

        #region PROPIEDADES
        private Servicios_Tipos oServiciosTipos = new Servicios_Tipos();
        private Servicios oServicios = new Servicios();
        private Usuarios oUsuarios = new Usuarios();
        private Usuarios oUsuarioExistente = new Usuarios();
        private Usuarios_Locaciones oLocacion = new Usuarios_Locaciones();
        private Partes oPartes = new Partes();
        private Partes_Usuarios_Servicios oParteUsuarioServicio = new Partes_Usuarios_Servicios();
        private Configuracion oConfig = new Configuracion();

        private DataTable dtTiposServicios = new DataTable();
        private DataTable dtGrupoServicios = new DataTable();
        private DataTable dtLocalidades = new DataTable();
        private DataTable dtDatosLocacion = new DataTable();

        private Boolean telefono1 = false;
        private Boolean nuevoUsuario = true;
        private Boolean nuevaLocacion = true;

        private int idCalle = 0;
        private int flag = 0;
        private GPS oGps = new GPS();
        private Thread hilo;
        private Boolean trabajaAgenda;

        private delegate void myDel();

        #endregion

        #region METODOS
        private void comenzarCarga()
        {
            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.IsBackground = true;
            hilo.Start();
        }
        private void cargarDatos()
        {
            try
            {
                if (oConfig.GetValor_N("Agenda_Trabajo") == 2)
                    trabajaAgenda = true;
                dtTiposServicios = Tablas.DataServicios_Tipos;
                dtGrupoServicios = oServicios.ListarGrupos();
                dtLocalidades = Tablas.DataLocalidades;

                myDel MD = new myDel(asignarDatos);
                this.Invoke(MD, new object[] { });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Informacion" + ex.Message);
                throw;
            }
        }
        private void asignarDatos()
        {
            cboGrupoServicio.DataSource = dtGrupoServicios;
            cboGrupoServicio.DisplayMember = "nombre";
            cboGrupoServicio.ValueMember = "id";

            //dtTiposServicios.Rows.Add(0, "NINGUNO");
            cboTipoServicio.DataSource = dtTiposServicios;
            cboTipoServicio.DisplayMember = "nombre";
            cboTipoServicio.ValueMember = "id";

            cboTipoDoc.DataSource = Tablas.DataTipoDNI;
            cboTipoDoc.DisplayMember = "tipo";
            cboTipoDoc.ValueMember = "id";

            cboLocalidades.DataSource = dtLocalidades;
            cboLocalidades.DisplayMember = "nombre";
            cboLocalidades.ValueMember = "id";
            flag = 1;

        }
        private void BuscarCalle()
        {
            using (frmPopUp frmModal = new frmPopUp())
            {
                Busquedas.frmBusquedaCalles frm = new Busquedas.frmBusquedaCalles();
                frm.Id_Localidad = Convert.ToInt32(cboLocalidades.SelectedValue);
                List<Int32> listLocalidades = new List<Int32>
                    {
                        Convert.ToInt32(cboLocalidades.SelectedValue)
                    };
                frm.lista_id_localidades = listLocalidades;

                frmModal.Formulario = frm;

                if (frmModal.ShowDialog() == DialogResult.OK)
                {

                    txtCalleServicio.Text = frm.Calle;
                    idCalle = frm.Id_Calle;
                    txtEntreCalleServicio_1.Focus();

                    lblAltura.Text = String.Format("Altura Desde {0} Hasta {1}", frm.oCalles.Altura_Desde, frm.oCalles.Altura_Hasta);
                }
                else
                    txtCalleServicio.Text = "";
            }
        }
        private Boolean ValidarDatos()
        {
            if (txtNombre.Text.Trim().Equals(""))
            {
                MessageBox.Show("Campo nombre vacio", "Mensaje del Sistema");
                txtNombre.Focus();
                return false;

            }
            if (txtApellido.Text.Trim().Equals(""))
            {
                MessageBox.Show("Campo apellido vacio", "Mensaje del Sistema");
                txtApellido.Focus();
                return false;
            }
            if (txtPrefijo_1.Text.Trim().Equals("") || (txtTelefono_1.Text.Trim().Equals("")))
            {
                telefono1 = false;
            }
            if ((txtPrefijo_2.Text.Trim().Equals("") || (txtTelefono_2.Text.Trim().Equals(""))) && (telefono1 == false))
            {
                MessageBox.Show("Campos telefono vacio, es necesario al menos un numero de telefono", "Mensaje del Sistema");
                txtPrefijo_1.Focus();
                return false;
            }
            if (txtCalleServicio.Text.Trim().Equals(""))
            {
                MessageBox.Show("Campo calle vacio", "Mensaje del Sistema");
                txtCalleServicio.Focus();
                return false;
            }
            if (txtAlturaServicio.Text.Trim().Equals("") || txtAlturaServicio.Text.Trim().Equals("0"))
            {
                MessageBox.Show("Campo altura vacio", "Mensaje del Sistema");
                txtAlturaServicio.Focus();
                return false;
            }
            return true;
        }
        #endregion

        public frmFactibilidad()
        {
            InitializeComponent();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmFactibilidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void frmFactibilidad_Load(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {

            if (ValidarDatos())
            {
                if (nuevoUsuario == true)
                {
                    oUsuarios.Id = 0;
                    oUsuarios.Id_Usuarios_Tipos = (int)Usuarios.Usuarios_Tipos.PROSPECTO;
                }
                else
                {
                    oUsuarios.Id = Usuarios.CurrentUsuario.Id;
                    oUsuarios.Id_Usuarios_Tipos = (int)Usuarios.Usuarios_Tipos.ABONADO;
                }
                oUsuarios.Tipo_Documento = cboTipoDoc.Text;
                oUsuarios.Id_Usuarios_TipoDoc = Convert.ToInt32(cboTipoDoc.SelectedValue);
                oUsuarios.Nombre = txtNombre.Text;
                oUsuarios.Apellido = txtApellido.Text;
                oUsuarios.Adhesion_Debito = 0;
                oUsuarios.Adhesion_FacDigital = 0;
                oUsuarios.Id_Usuarios_Profesiones = 0;
                oUsuarios.Codigo = 0;
                oUsuarios.Condicion_Iva = "";
                oUsuarios.Correo_Electronico = txtCorreo.Text;
                oUsuarios.CUIT = 0;
                oUsuarios.Debito_Automatico = 0;
                oUsuarios.Exento_Impuesto_Provincial = 0;
                oUsuarios.Id_Comprobantes_Iva = 1;
                oUsuarios.Numero_Documento = Convert.ToDouble(txtNumero.Text);
                oUsuarios.Nacimiento = DateTime.Now;
                oUsuarios.Prefijo_1 = Convert.ToInt32(txtPrefijo_1.Text);
                oUsuarios.Telefono_1 = Convert.ToInt32(txtTelefono_1.Text);
                oUsuarios.Prefijo_2 = Convert.ToInt32(txtPrefijo_2.Text);
                oUsuarios.Telefono_2 = Convert.ToInt32(txtTelefono_2.Text);
                if (nuevoUsuario)
                    oUsuarios.Id = oUsuarios.Guardar(oUsuarios);

                if (nuevaLocacion == true)
                {
                    oLocacion.Id = 0;
                    oLocacion.Id_Calle = this.idCalle;
                    oLocacion.Id_Calle_Entre_1 = 0;
                    oLocacion.Entre_Calle_1 = txtEntreCalleServicio_1.Text;
                    oLocacion.Entre_Calle_2 = txtEntreCalleServicio_2.Text;
                    oLocacion.Id_Calle_Entre_2 = 0;
                    oLocacion.Id_Locacion_Fiscal_Asociada = 0;
                    oLocacion.Id_Localidades = Convert.ToInt32(cboLocalidades.SelectedValue);
                    oLocacion.id_manzana = 0;
                    oLocacion.Id_Provincias = 0;
                    oLocacion.Localidad = cboLocalidades.Text;
                    oLocacion.Manzana = txtManzServicio.Text;
                    oLocacion.Observacion = txtObsUsuario.Text;
                    oLocacion.Parcela = txtParcelaServicio.Text;
                    oLocacion.Piso = txtPisoServicio.Text;
                    oLocacion.Depto = txtDeptoServicio.Text;
                    oLocacion.Altura = Convert.ToInt32(txtAlturaServicio.Text);
                    oLocacion.Calle = txtCalleServicio.Text;
                    oLocacion.Codigo_Postal = txtCPServicio.Text;
                    oLocacion.Prefijo_1 = Convert.ToInt32(txtPrefijo_1.Text);
                    oLocacion.Telefono_1 = Convert.ToInt32(txtTelefono_1.Text);
                    oLocacion.Prefijo_2 = Convert.ToInt32(txtPrefijo_2.Text);
                    oLocacion.Telefono_2 = Convert.ToInt32(txtTelefono_2.Text);
                    oLocacion.Tipo = "SV";
                    oLocacion.Usuario = txtApellido.Text + "," + txtNombre.Text;
                    oLocacion.Id_Usuarios = oUsuarios.Id;
                    oLocacion.Activo = 0;
                    oLocacion.Id = oLocacion.Guardar(oUsuarios.Id, oLocacion);
                }


                oPartes.Id = 0;
                oPartes.Area = "";
                oPartes.Cantidad = 1;
                oPartes.Depto = oLocacion.Depto;
                oPartes.Detalle_Falla = "FACTIBILIAD DE SERVICIO";
                oPartes.Detalle_Solucion = "";
                oPartes.Direccion = "CALLE: " + oLocacion.Calle + " N°: " + oLocacion.Altura + " PISO: " + oLocacion.Piso + " DEPTO: " + oLocacion.Depto;
                oPartes.Entre_Calle_1 = oLocacion.Entre_Calle_1;
                oPartes.Entre_Calle_2 = oLocacion.Entre_Calle_2;
                oPartes.Estado = Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_TECNICO.ToString();
                oPartes.Fecha_Movil = DateTime.Now;
                oPartes.Fecha_Programado = DateTime.Now;
                oPartes.Fecha_Realizado = DateTime.Now;
                oPartes.Fecha_Recibido = DateTime.Now;
                oPartes.Fecha_Reclamo = DateTime.Now;
                oPartes.Fecha_tipo = (int)Partes.Tipo_Fecha.FECHA_RECLAMO;
                oPartes.Id_Comprobantes = 0;
                oPartes.Id_Locacion_Anterior = 0;
                oPartes.Id_Movil = 0;
                oPartes.Id_Operadores = Personal.Id_Login;
                oPartes.Id_Partes_Estados = (int)Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_TECNICO;
                //obtengo idFalla
                DataTable dtAux = new DataTable();
                Partes_Solicitudes oParteFalla = new Partes_Solicitudes();
                dtAux = oParteFalla.GetFallasPorTipoServYOp(Convert.ToInt32(cboTipoServicio.SelectedValue), (int)Partes.Partes_Operaciones.FACTIBILIDAD);
                if (dtAux.Rows.Count > 0)
                    oPartes.Id_Partes_Fallas = Convert.ToInt32(dtAux.Rows[0]["id"]);
                else
                    oPartes.Id_Partes_Fallas = 8;
                oPartes.Id_Partes_Soluciones = 0;
                oPartes.Id_Servicios = 0;
                oPartes.Id_Servicios_Grupos = Convert.ToInt32(cboGrupoServicio.SelectedValue);
                oPartes.Id_Servicios_Tipos = Convert.ToInt32(cboTipoServicio.SelectedValue);
                oPartes.Id_Tecnico = 0;
                oPartes.Id_Usuarios = oUsuarios.Id;
                if (nuevaLocacion == true)
                    oPartes.Id_Usuarios_Locaciones = oLocacion.Id;
                else
                    oPartes.Id_Usuarios_Locaciones = Usuarios.CurrentUsuario.Id_Usuarios_Locacion;

                oPartes.Id_Usuarios_Servicios = 0;
                oPartes.Id_Zonas = 0;
                oPartes.Localidad = oLocacion.Localidad;
                oPartes.Manzana = 0;
                oPartes.Observacion = txtObsUsuario.Text;
                oPartes.Piso = oLocacion.Piso;
                oPartes.Servicio = cboTipoServicio.Text;
                oPartes.Telefono = oLocacion.Prefijo_1 + " " + oLocacion.Telefono_1;
                oPartes.Usuario = oUsuarios.Apellido + ", " + oUsuarios.Nombre;
                oPartes.Id_Usuarios_Cuenta_Corriente = 0;
                int idParte = oPartes.Guardar(oPartes, 0);

                oParteUsuarioServicio.Id = 0;
                oParteUsuarioServicio.idParteFalla = oPartes.Id_Partes_Fallas;
                oParteUsuarioServicio.IdPlastico = 0;
                oParteUsuarioServicio.Id_Parte = idParte;
                oParteUsuarioServicio.Id_Servicio = 0;
                oParteUsuarioServicio.idTipoServicio = oPartes.Id_Servicios_Tipos;
                oParteUsuarioServicio.idGrupoServicio = oPartes.Id_Servicios_Grupos;
                oParteUsuarioServicio.Id_Usuario_Servicio = 0;
                oParteUsuarioServicio.id_usuarios_servicios_sub = 0;
                oParteUsuarioServicio.Guardar(oParteUsuarioServicio);

                if (!trabajaAgenda)
                    oGps.EnviarParte(idParte);

                MessageBox.Show("Parte generado correctamente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al validar datos", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnBuscarCalle_Click(object sender, EventArgs e)
        {
            BuscarCalle();
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btnAbonado_Click(object sender, EventArgs e)
        {
            nuevaLocacion = false;
            nuevoUsuario = false;
            frmBusquedaUsuarios frm = new frmBusquedaUsuarios(2, "ingrese nombre/apellido de usuario", "");

            frmPopUp frmPop = new frmPopUp();
            frmPop.Formulario = frm;

            if (frmPop.ShowDialog() == DialogResult.OK)
            {
                dtDatosLocacion = oLocacion.ListarDatosLocacion(Usuarios.CurrentUsuario.Id_Usuarios_Locacion);
                oUsuarioExistente = Usuarios.CurrentUsuario;
                txtNombre.Text = Usuarios.CurrentUsuario.Nombre;
                txtApellido.Text = Usuarios.CurrentUsuario.Apellido;
                txtNumero.Text = Usuarios.CurrentUsuario.Numero_Documento.ToString();
                cboTipoDoc.SelectedValue = Usuarios.CurrentUsuario.Id_Usuarios_TipoDoc;

                txtCorreo.Text = Usuarios.CurrentUsuario.Correo_Electronico;

                txtPrefijo_1.Text = dtDatosLocacion.Rows[0]["prefijo_1"].ToString();
                txtTelefono_1.Text = dtDatosLocacion.Rows[0]["telefono_1"].ToString();

                txtPrefijo_2.Text = dtDatosLocacion.Rows[0]["prefijo_2"].ToString();
                txtTelefono_2.Text = dtDatosLocacion.Rows[0]["telefono_2"].ToString();

                txtCalleServicio.Text = dtDatosLocacion.Rows[0]["calle"].ToString();
                txtAlturaServicio.Text = dtDatosLocacion.Rows[0]["altura"].ToString();
                txtEntreCalleServicio_1.Text = dtDatosLocacion.Rows[0]["entre_calle_1"].ToString();
                txtEntreCalleServicio_2.Text = dtDatosLocacion.Rows[0]["entre_calle_2"].ToString();
                txtCPServicio.Text = dtDatosLocacion.Rows[0]["codigo_postal"].ToString();
                txtPisoServicio.Text = dtDatosLocacion.Rows[0]["piso"].ToString();
                txtDeptoServicio.Text = dtDatosLocacion.Rows[0]["depto"].ToString();
                txtManzServicio.Text = dtDatosLocacion.Rows[0]["manzana"].ToString();
                cboLocalidades.SelectedValue = dtDatosLocacion.Rows[0]["id_localidades"];
                txtParcelaServicio.Text = "";


                txtCalleServicio.ReadOnly = true;
                txtAlturaServicio.ReadOnly = true;
                txtEntreCalleServicio_1.ReadOnly = true;
                txtEntreCalleServicio_2.ReadOnly = true;
                txtCPServicio.ReadOnly = true;
                txtPisoServicio.ReadOnly = true;
                txtDeptoServicio.ReadOnly = true;
                txtManzServicio.ReadOnly = true;
                txtParcelaServicio.ReadOnly = true;
                cboLocalidades.Enabled = false;

                btnLocacion.Enabled = true;
                btnLocacion.Visible = true;
            }
        }

        private void btnLocacion_Click(object sender, EventArgs e)
        {
            nuevaLocacion = true;
            txtCalleServicio.ReadOnly = false;
            txtAlturaServicio.ReadOnly = false;
            txtEntreCalleServicio_1.ReadOnly = false;
            txtEntreCalleServicio_2.ReadOnly = false;
            txtCPServicio.ReadOnly = false;
            txtPisoServicio.ReadOnly = false;
            txtDeptoServicio.ReadOnly = false;
            txtManzServicio.ReadOnly = false;
            txtParcelaServicio.ReadOnly = false;
            cboLocalidades.Enabled = true;

            txtCalleServicio.Text = "";
            txtAlturaServicio.Text = "0";
            txtDeptoServicio.Text = "0";
            txtPisoServicio.Text = "0";
            txtCPServicio.Text = "0";
            txtManzServicio.Text = "0";
            txtParcelaServicio.Text = "0";
            txtEntreCalleServicio_1.Text = "";
            txtEntreCalleServicio_2.Text = "";
        }

        private void cboLocalidades_SelectedValueChanged(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                int idLoc = Convert.ToInt32(cboLocalidades.SelectedValue);
                Localidades oLoc = new Localidades();
                DataRow drDatosLoc;
                drDatosLoc = oLoc.TraerDatosLocalidad(idLoc);
                txtCPServicio.Text = drDatosLoc["Codigo_Postal"].ToString();
            }
        }
    }
}
