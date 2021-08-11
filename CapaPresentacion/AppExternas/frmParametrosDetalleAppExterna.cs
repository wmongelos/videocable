using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Threading;
using CapaNegocios;

namespace CapaPresentacion.AppExternas
{
    public partial class frmParametrosDetalleAppExterna : Form
    {

        #region Declaraciones
        private Thread hilo;
        private delegate void myDel();
        private DataTable dt_Parametros;
        private DataTable dtFinal;
        public int id_app_Externa, id_Tipo_Facturacion,id_Parametro,Filtro=0;
        Configuracion oConfig = new Configuracion();
        Aplicaciones_Externas oAppExterna = new Aplicaciones_Externas();
        Zonas oZonas = new Zonas();
        Servicios_Categorias oServCat = new Servicios_Categorias();
        #endregion
        public frmParametrosDetalleAppExterna()
        {
            InitializeComponent();
        }


        #region METODOS
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
                if(id_Tipo_Facturacion == 1)
                    dtFinal = oZonas.ListarParametrosAppExtDet(id_Parametro, id_app_Externa);
                else
                    dtFinal = oServCat.ListarParametrosDetallesAppExt(id_Parametro, id_app_Externa);
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
            dgv.DataSource = dtFinal;

            for (int i = 0; i < dgv.ColumnCount; i++) 
                dgv.Columns[i].Visible = true;
            dgv.ReadOnly = false;
           /* if(id_Tipo_Facturacion == 1)
             {
                 dgv.Columns["Zona"].Visible = true;
                 dgv.Columns["Valor"].Visible = true;
                 dgv.Columns["Zona"].HeaderText = "Zona";
                 dgv.Columns["Valor"].HeaderText = "Valor";
             }
             else 
             { 
                 dgv.Columns["Categoria"].Visible = true;
                 dgv.Columns["Valor"].Visible = true;
                 dgv.Columns["Categoria"].HeaderText = "Categoria";
                 dgv.Columns["Valor"].HeaderText = "Valor";
             }*/

            Filtro = 1;
          
        }

        #endregion
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            int id_Reg=0,id_Par=0,idApp=0,id_tipFac=0;
            string valor = "";
            foreach (DataRow dr in dtFinal.Rows) 
            {
                id_Reg = 0;
                if (Convert.ToInt32(dr["id_parametro_Det"]) != 0)
                    id_Reg = Convert.ToInt32(dr["id_parametro_Det"]);

                id_Par = Convert.ToInt32(cboParametrosAppExt.SelectedValue);
                idApp = id_app_Externa;
                valor = dr["valor"].ToString();
                if (id_Tipo_Facturacion == 1)
                    id_tipFac = Convert.ToInt32(dr["id_zona"]);
                else
                    id_tipFac = Convert.ToInt32(dr["id_cat"]);
                oAppExterna.GuardarParametros_Det(id_Reg, id_Par, idApp, id_tipFac, valor);
            }
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            /*dgv.CurrentCell = dgv.CurrentRow.Cells["Valor"];
            dgv.BeginEdit(true);*/
        }

        private void cboParametrosAppExt_SelectedValueChanged(object sender, EventArgs e)
        {
            if(Filtro > 0)
            { 
                id_Parametro = Convert.ToInt32(cboParametrosAppExt.SelectedValue);
                comenzarCarga();
            }
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmParametrosDetalleAppExterna_Load(object sender, EventArgs e)
        {
            dt_Parametros = oAppExterna.ListarParametros(id_app_Externa);
            cboParametrosAppExt.ValueMember = "id_ap_ext_parametro";
            cboParametrosAppExt.DisplayMember = "prametro_aplicacion_externa";
            cboParametrosAppExt.DataSource = dt_Parametros;
            id_Tipo_Facturacion = oConfig.GetValor_N("Id_Tipo_Facturacion");
            id_Parametro = Convert.ToInt32(cboParametrosAppExt.SelectedValue);
            comenzarCarga();
        }
    }
}
