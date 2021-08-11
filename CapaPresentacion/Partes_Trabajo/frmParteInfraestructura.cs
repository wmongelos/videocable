using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using CapaNegocios;
using CapaPresentacion;

namespace CapaPresentacion.Partes_Trabajo
{
    public partial class frmParteInfraestructura : Form
    {
        public frmParteInfraestructura()
        {
            InitializeComponent();
        }

        #region Propiedades
        private Servicios oServicios = new Servicios();
        private Partes oPartes = new Partes();
        private Partes_Infraestructura oParteInfra = new Partes_Infraestructura();

        private DataTable dtGrupoServicios = new DataTable();
        private DataTable dtLocalidades = new DataTable();
        private DataTable dtTiposServicios = new DataTable();
        private DataView dvLocalidadesAux = new DataView();

        private int idCalle = 0;
        private Thread hilo;

        private delegate void myDel();
        #endregion

        #region Metodos
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
                dtGrupoServicios = oServicios.ListarGrupos();
                dtLocalidades = Tablas.DataLocalidades;
                dtTiposServicios = Tablas.DataServicios_Tipos;
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

            cboTipoServicio.DataSource = dtTiposServicios;
            cboTipoServicio.DisplayMember = "nombre";
            cboTipoServicio.ValueMember = "id";

            cboLocalidades.DataSource = dtLocalidades;
            cboLocalidades.ValueMember = "id";
            cboLocalidades.DisplayMember = "nombre";

            cboGrupoServicio.SelectedIndexChanged += CboGrupoServicio_SelectedIndexChanged;
            cboGrupoServicio.SelectedIndex = 1;
        }

        private void CboGrupoServicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtTiposServicios.DefaultView.RowFilter = $"id_servicios_grupos = {Convert.ToInt32(cboGrupoServicio.SelectedValue)}";
            cboTipoServicio.DataSource = dtTiposServicios.DefaultView.ToTable();
            cboTipoServicio.DisplayMember = "nombre";
            cboTipoServicio.ValueMember = "id";
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

        #region Eventos
        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
        private void frmParteInfraestructura_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void frmParteInfraestructura_Load(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void btnBuscarCalle_Click(object sender, EventArgs e)
        {
            BuscarCalle();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                oPartes.Id = 0;
                oPartes.Area = "";
                oPartes.Cantidad = 1;
                oPartes.Depto = txtDeptoServicio.Text;
                oPartes.Detalle_Falla = "INFRAESTRUCTURA";
                oPartes.Detalle_Solucion = "";
                oPartes.Direccion = "CALLE: " + txtCalleServicio.Text + " N°: " + txtAlturaServicio.Text + " PISO: " + txtPisoServicio.Text + " DEPTO: " + txtDeptoServicio.Text;
                oPartes.Entre_Calle_1 = txtEntreCalleServicio_1.Text;
                oPartes.Entre_Calle_2 = txtEntreCalleServicio_2.Text;
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
                DataTable dtAux = new DataTable();
                Partes_Solicitudes oParteFalla = new Partes_Solicitudes();
                dtAux = oParteFalla.GetFallasPorTipoServYOp(Convert.ToInt32(cboTipoServicio.SelectedValue), (int)Partes.Partes_Operaciones.INFRAESTRUCTURA);
                if (dtAux.Rows.Count > 0)
                    oPartes.Id_Partes_Fallas = Convert.ToInt32(dtAux.Rows[0]["id"]);
                else
                    oPartes.Id_Partes_Fallas = 11;
                oPartes.Id_Partes_Soluciones = 0;
                oPartes.Id_Servicios = 0;
                oPartes.Id_Servicios_Grupos = Convert.ToInt32(cboGrupoServicio.SelectedValue);
                oPartes.Id_Servicios_Tipos = Convert.ToInt32(cboTipoServicio.SelectedValue);
                oPartes.Id_Tecnico = 0;
                oPartes.Id_Usuarios = 0;
                oPartes.Id_Usuarios_Locaciones = 0;
                oPartes.Id_Usuarios_Servicios = 0;
                oPartes.Id_Zonas = 0;
                oPartes.Localidad = Convert.ToString(cboLocalidades.DisplayMember);
                oPartes.Manzana = 0;
                oPartes.Piso = txtPisoServicio.Text;
                oPartes.Servicio = "";
                oPartes.Telefono = "";
                oPartes.Usuario = "";
                oPartes.Id_Usuarios_Cuenta_Corriente = 0;
                int idParte = oPartes.Guardar(oPartes, 0);

                oParteInfra.Id_Parte = idParte;
                oParteInfra.Id_Localidad = Convert.ToInt32(cboLocalidades.SelectedValue);
                oParteInfra.Id_Calle = idCalle;
                oParteInfra.Altura = Convert.ToInt32(txtAlturaServicio.Text);
                oParteInfra.Piso = txtPisoServicio.Text;
                oParteInfra.Depto = txtDeptoServicio.Text;
                oParteInfra.Entre_Calle_1 = txtEntreCalleServicio_1.Text;
                oParteInfra.Entre_Calle_2 = txtEntreCalleServicio_2.Text;
                oParteInfra.Detalle = txtObsUsuario.Text;
                oParteInfra.Id_Tipo_Servicio = Convert.ToInt32(cboTipoServicio.SelectedValue);
                oParteInfra.Id_Grupo_Servicio = Convert.ToInt32(cboGrupoServicio.SelectedValue);
                oParteInfra.Guardar(oParteInfra);

                MessageBox.Show("Parte generado correctamente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al validar datos", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void cboLocalidades_SelectedValueChanged(object sender, EventArgs e)
        {
            try 
            { 
                int id_Localidad = Convert.ToInt32(cboLocalidades.SelectedValue);
                dvLocalidadesAux = dtLocalidades.Copy().DefaultView;
                dvLocalidadesAux.RowFilter = string.Format("id = {0}", id_Localidad);
                txtCPServicio.Text = dvLocalidadesAux.ToTable().Rows[0]["Codigo_Postal"].ToString();
                txtCalleServicio.Text = "";
                idCalle = 0;
                lblAltura.Text = "[Altura]";
            }
            catch { }
        }
    }
}
