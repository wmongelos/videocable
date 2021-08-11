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

namespace CapaPresentacion.Abms
{
    public partial class ABMCassRelacionGIES : Form
    {
        #region PROPIEDADES
        private DataTable dtCASS;
        private DataTable dtRelacion;
        private DataTable dtSubServ;
        Cass oCass;
        Servicios_Sub oServ_Sub = new Servicios_Sub();
        Servicios oServ = new Servicios();
        Aplicaciones_Externas oExterna = new Aplicaciones_Externas();
        private Thread hilo;
        private int id_Aplicacion_Externa = 0;
        private bool yaCargo = false;
        int Id_Servicio_Seleccionado = 0;
        #endregion
        public ABMCassRelacionGIES()
        {
            InitializeComponent();
        }

        #region METODOS

        private void CargarDatos()
        {
            dtCASS = oCass.ObtenerSubServiciosCASS();
            dtRelacion = oCass.Listar_Relacion();
        }
        private void asignarDatos()
        {

            dgvCass.DataSource = dtCASS;
            dgvRelacion.DataSource = dtRelacion;

            for (int i = 0; i < dgvCass.ColumnCount; i++)
                dgvCass.Columns[i].Visible = true;

            dgvCass.Columns["id_Servicio_cass"].Visible = false;
            dgvCass.Columns["servicio_cass"].HeaderText = "Servicio Cass";

            for (int i = 0; i < dgvRelacion.ColumnCount; i++)
                dgvRelacion.Columns[i].Visible = true;


            dgvRelacion.Columns["serviciogies"].HeaderText = "Servicio en GIES";
            dgvRelacion.Columns["subserviciogies"].HeaderText = "Sub-Servicio en GIES";
            dgvRelacion.Columns["subserviciocass"].HeaderText = "Producto en CASS";
            dgvRelacion.Columns["id"].Visible = false;
            dgvRelacion.Columns["id_serv"].Visible = false;
            dgvRelacion.Columns["id_sub"].Visible = false;


            if (yaCargo == false) 
            {
                btnAgregar.Visible = true;
                btnElimina.Visible = true;
                panel2.Visible = true;
                panel3.Visible = true;
                panel4.Visible = true;
                SetearCboServ();
                Id_Servicio_Seleccionado = Convert.ToInt32(cboServicios.SelectedValue);
                SetearCboSubServ(Id_Servicio_Seleccionado);
                yaCargo = true;
                SetearDtRelacion();
            }
            yaCargo = true;

        }

        private void SetearCboSubServ(int id_servicio)
        {
            dtSubServ = oServ_Sub.ListarServiciosSubCASS(id_Aplicacion_Externa);
            DataView dv = new DataView();
            dv = dtSubServ.DefaultView;
            dv.RowFilter = String.Format("id_serv = {0}", id_servicio);
            dtSubServ = dv.ToTable();
            cboSubGIES.DataSource = dtSubServ;
            cboSubGIES.ValueMember = "id_serv_sub";
            cboSubGIES.DisplayMember = "Servicio";
        }

        private void SetearCboServ()
        {
            cboServicios.DataSource = oServ.ListarServiciosAplicacionesExternas((int)CapaNegocios.Aplicaciones_Externas.Aplicacion_Externa.CASS);
            cboServicios.ValueMember = "id";
            cboServicios.DisplayMember = "Descripcion";
        }

        private void SetearDtRelacion()
        {
                CargarDatos();
                DataView dvRelacion = new DataView();
                dvRelacion = dtRelacion.DefaultView;
                dvRelacion.RowFilter = String.Format("id_sub = {0} and id_serv = {1}", Convert.ToInt32(cboSubGIES.SelectedValue), Convert.ToInt32(cboServicios.SelectedValue));
                dtRelacion = dvRelacion.ToTable();
                asignarDatos();
        }
        #endregion

        #region EVENTOS
        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void ABMCassRelacionGIES_Load(object sender, EventArgs e)
        {
            cboAplicaciones_Externas.DataSource = oExterna.ListarExternasConRelacion(0);
            cboAplicaciones_Externas.ValueMember = "id";
            cboAplicaciones_Externas.DisplayMember = "nombre";

            oCass = new Cass((int)Aplicaciones_Externas.Aplicacion_Externa.CASS);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int SubServElegido = 0, servElegido = 0;
            string Producto = string.Empty;

            SubServElegido = Convert.ToInt32(cboSubGIES.SelectedValue);
            servElegido = Convert.ToInt32(cboServicios.SelectedValue);
            Producto = dgvCass.SelectedRows[0].Cells["Servicio_CASS"].Value.ToString();

            oCass.Guardar(SubServElegido,servElegido ,Producto);
            SetearDtRelacion();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            yaCargo = false;
            id_Aplicacion_Externa = Convert.ToInt32(cboAplicaciones_Externas.SelectedValue);
            SetearDtRelacion();
        }

        private void btnElimina_Click(object sender, EventArgs e)
        {
            int id_seleccionado = 0;
            id_seleccionado = Convert.ToInt32(dgvRelacion.SelectedRows[0].Cells["Id"].Value);
            if (MessageBox.Show("Esta a punto de eliminar un Registro, ¿desea continuar con la operacion?", "Mensaje del sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                oExterna.EliminarRelacion(id_seleccionado);
            else
                MessageBox.Show("Operacion cancelada.");
            SetearDtRelacion();
        }

        private void cboServicios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (yaCargo)
            {
                int id_serv = 0;
                if (cboServicios.SelectedValue != null) 
                { 
                  id_serv = Convert.ToInt32(cboServicios.SelectedValue);
                    SetearCboSubServ(id_serv);
                }
            }
        }

        private void cboSubGIES_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (yaCargo)
            {
                if(cboSubGIES.SelectedValue != null)
                    SetearDtRelacion();
            }
        }
    }
}
