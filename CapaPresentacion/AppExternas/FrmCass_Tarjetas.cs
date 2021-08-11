using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CapaNegocios;
using System.Threading;

namespace CapaPresentacion
{
    public partial class FrmCass_Tarjetas : Form
    {
        public FrmCass_Tarjetas()
        {
            InitializeComponent();
        }

        #region PROPIEDADES
        public DataTable dtUsuario = new DataTable();
        public DataTable dt = new DataTable();
        public string Tarjeta;
        private DataView dvFiltrado;
        private Thread hilo;
        private delegate void myDel();

        #endregion

        #region CONSTRUCTORES
        private void asignarDatos()
        {
            dgv.DataSource = dt;
            foreach (DataGridViewColumn item in dgv.Columns)
                item.Visible = false;

            dgv.Columns["codUsu"].Visible = true;
            dgv.Columns["usuario"].Visible = true;
            dgv.Columns["serie"].Visible = true;
            dgv.Columns["mac"].Visible = true;
            dgv.Columns["TipoEquipo"].Visible = true;
            dgv.Columns["tarjeta"].Visible = true;

            dgv.Columns["codUsu"].HeaderText = "Codigo";
            dgv.Columns["usuario"].HeaderText = "Usuario";
            dgv.Columns["serie"].HeaderText = "Serie";
            dgv.Columns["mac"].HeaderText = "Mac";
            dgv.Columns["tipoEquipo"].HeaderText = "Equipo";
            dgv.Columns["tarjeta"].HeaderText = "Tarjeta";
        }
        #endregion


        #region EVENTOS
        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        private void frmTarjetasGIES_Load(object sender, EventArgs e)
        {
            dvFiltrado = Tablas.DataAplicionesExternas.DefaultView;
            dvFiltrado.RowFilter = "nombre = 'CASS'";
            DataTable dtAplicacionesFiltradas = dvFiltrado.ToTable();
            Cass oCass = new Cass(Convert.ToInt32(dtAplicacionesFiltradas.Rows[0]["Id"]));
            dt = oCass.ListarTarjetasGIES(this.Tarjeta);
            asignarDatos();
        }
    }
}
