using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Threading;
using CapaPresentacion;
using CapaNegocios;

namespace CapaPresentacion.AppExternas
{
    public partial class frmVerISPNuevo : Form
    {
        #region [PROPIEDADES]
        private Thread hilo;
        private delegate void myDel();

        //DECLARACIONES RECIBIDAS POR PARAMETROS
        public int id_usuarioGlobal = 0;
        public int id_servicioGlobal = 0;
        public int id_usuarioServicioGlobal = 0;
        //TABLAS
        public DataTable dtEquiposGIES = new DataTable();
        public DataTable dtEquiposISP = new DataTable();
        public DataTable dtProductosIsp = new DataTable();
        public DataTable dtServicio = new DataTable();
        public DataTable dtUsuServ = new DataTable();
        public DataTable dtAccountISP = new DataTable();
        public DataTable dtDatosAppExterna = new DataTable();
        DataTable dtAplicacionesFiltradas = Tablas.DataIsp;


        //OBJETOS
        private Partes_Usuarios_Servicios oPartesUsuariosServicios = new Partes_Usuarios_Servicios();
        private Aplicaciones_Externas oAppExterna = new Aplicaciones_Externas();
        private Servicios oServicios = new Servicios();
        private Usuarios_Servicios oUsuSer = new Usuarios_Servicios();
        private Isp oISP = new Isp();
        private Equipos oEquipos = new Equipos();

        //Variables Internas del ISP
        private Int32 idCustomer=0, idLocation=0, idEquipment=0, idProduct=0, idAccesAccount=0;

        #endregion

        #region [METODOS]
        private void ComenzarCarga()
        {
            bloquearControles();
            dgvServiciosISP.DataSource = null;
            hilo = new Thread(new ThreadStart(CargarDatos));
            hilo.IsBackground = true;
            hilo.Start();
        }

        private void frmVerISPNuevo_Load(object sender, EventArgs e)
        {
            ComenzarCarga();
        }

        private void CargarDatos()
        {
            try
            {
                dtServicio = oServicios.BuscarDatosServicio(id_servicioGlobal);
                
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void bloquearControles()
        {
            foreach (Control item in this.Controls)
                item.Enabled = false;
        }

        #endregion


        #region [EVENTOS]
        public frmVerISPNuevo()
        {
            InitializeComponent();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
