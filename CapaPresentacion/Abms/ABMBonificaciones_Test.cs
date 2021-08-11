using CapaNegocios;
using CapaPresentacion.Busquedas;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Abms
{
    public partial class ABMBonificaciones_Test : Form
    {
        Bonificaciones oBonificaciones = new Bonificaciones();
        DataTable DtUsuariosSubServicios = new DataTable();
        DataTable DtUsuariosSubServiciosBonificados = new DataTable();
        private Thread hilo;
        private delegate void myDel();
        Usuarios oUsuarios = new Usuarios();
        public DataRow drUsuario_actual;
        private int IdUsuario = 0;
        private int IdLocacion = 0;
        DataTable dtusuarios = new DataTable();
        Servicios_Tarifas oServiciosTarifas = new Servicios_Tarifas();
        private int idTarifaActual = 0;

        private void ComenzarCarga()
        {
            pgCircular.Start();
            hilo = new Thread(new ThreadStart(CargarDatos));
            hilo.IsBackground = true;
            hilo.Start();
        }


        private void CargarDatos()
        {
            //if (oBonificaciones.CalcularBonificaciones(DtUsuariosSubServicios.Copy(), DateTime.Now, Convert.ToInt32(oServiciosTarifas.TraerDatosTarifaActual().Rows[0]["id"]), false))
            //    DtUsuariosSubServiciosBonificados = oBonificaciones.dtSubServicios;

            //myDel MD = new myDel(AsignarDatos);
            //this.Invoke(MD, new object[] { });
            //pgCircular.Stop();

        }


        private void AsignarDatos()
        {
            dgv1.DataSource = DtUsuariosSubServiciosBonificados;

        }
        private void Buscar()
        {
            oUsuarios.Codigo = 0;
            oUsuarios.Usuario = "";
            oUsuarios.Calle = "";
            oUsuarios.Altura = 0;

            frmBusquedaUsuarios frm = new frmBusquedaUsuarios(1, "", "");
            if (frm.ShowDialog() == DialogResult.OK)
            {
                drUsuario_actual = frm.usuario_e;
                Usuarios.Usuario_Sel = frm.usuario_e;
                IdUsuario = Int32.Parse(drUsuario_actual["id"].ToString());
                IdLocacion = Int32.Parse(drUsuario_actual["id_usuarios_locaciones"].ToString());
                dtusuarios = oUsuarios.getDatos_ultimo();
                DataView v1 = dtusuarios.DefaultView;
                DataTable dt = new DataTable();
                v1.RowFilter = string.Format("id_usuarios_locaciones = {0} ", IdLocacion);
                dt = v1.ToTable();
                drUsuario_actual = dt.Rows[0];
                LBApellido.Text = drUsuario_actual["apellido"].ToString().Trim() + " , " + (drUsuario_actual["nombre"].ToString()).ToUpperInvariant() + " [" + drUsuario_actual["codigo"].ToString() + "]";
                LBNumero_documento.Text = "Documento : (" + drUsuario_actual["tipo_doc"].ToString() + ") Nro " + drUsuario_actual["numero_documento"].ToString();
                lbcuit.Text = "C. Iva : (" + drUsuario_actual["condicion_iva"].ToString() + ") Nro " + drUsuario_actual["cuit"].ToString();
                lblLocacion.Text = String.Format("Locación: {0}, {1} {2} ", drUsuario_actual["localidad"], drUsuario_actual["calle"], drUsuario_actual["altura"]);
                lbcorreo.Text = "Mail: " + drUsuario_actual["Correo_electronico"].ToString();
            }
        }
        public ABMBonificaciones_Test()
        {
            InitializeComponent();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            //if (IdUsuario > 0 && IdLocacion > 0)
            //{
            //    if (rbUsuario.Checked == true)
            //        DtUsuariosSubServicios = oBonificaciones.RetornarDtSubServicios(IdUsuario, 0,idTarifaActual);
            //    else if (rbLocacion.Checked == true)
            //        DtUsuariosSubServicios = oBonificaciones.RetornarDtSubServicios(IdUsuario, IdLocacion,idTarifaActual);
            //    dgvCondiciones.DataSource = DtUsuariosSubServicios;
            //}
            //else
            //    MessageBox.Show("Debe seleccionar un usuario.");
        }

        private void boton1_Click(object sender, EventArgs e)
        {
            ComenzarCarga();

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void frmPruebaBonificaciones_Load(object sender, EventArgs e)
        {
            idTarifaActual = Convert.ToInt32(oServiciosTarifas.TraerDatosTarifaActual().Rows[0]["id"]);
            rbUsuario.Checked = true;
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPruebaBonificaciones_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
