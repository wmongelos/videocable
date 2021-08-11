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
    public partial class ABMAplicaciones_Externas_Parametros : Form
    {
        public ABMAplicaciones_Externas_Parametros()
        {
            InitializeComponent();
        }

        private Thread hilo;
        private delegate void myDel();
        private DataTable dt;
        public int Id_App_Externa;
        Aplicaciones_Externas oAppExt = new Aplicaciones_Externas();    
        private DataTable dtValores_Tipos = new DataTable();
        Array Valores = Enum.GetValues(typeof(Aplicaciones_Externas.VALORES_TIPO));
        private int Id_Registro = 0;
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
                List<string> Nombre_Valores = new List<string>();
                dt = oAppExt.ListarParametros(Id_App_Externa);
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

            foreach (Aplicaciones_Externas.VALORES_TIPO val in Valores)
            {
                DataRow dr = dtValores_Tipos.NewRow();
                dr["Id_Valor_Tipo"] = val;
                dr["Valor_Tipo"] = Enum.GetName(typeof(Aplicaciones_Externas.VALORES_TIPO), val);
                dtValores_Tipos.Rows.Add(dr);
            }

            dgv.DataSource = dt;
            for (int i = 0; i < dgv.ColumnCount; i++)
                dgv.Columns[i].Visible = false;

            dgv.Columns["conexion"].Visible = true;
            dgv.Columns["prametro_gies"].Visible = true;
            dgv.Columns["Prametro_aplicacion_externa"].Visible = true;
            dgv.Columns["detalle_gies"].Visible = true;

            dgv.Columns["conexion"].HeaderText = "Conexion";
            dgv.Columns["prametro_gies"].HeaderText = "Parametro Gies";
            dgv.Columns["Prametro_aplicacion_externa"].HeaderText = "Parametro Externo";
            dgv.Columns["detalle_gies"].HeaderText = "Detalle";

        }

        private void guardarRegistro()
        {
            if (txtParamExterno.Text == "" || txtParamGIES.Text == "" || txtDetalle.Text == "")
                MessageBox.Show("Debe completar todos los campos.");
            else 
            { 
                oAppExt.GuardarParametros(Id_App_Externa, txtParamGIES.Text, txtParamExterno.Text, txtDetalle.Text, Id_Registro);
                MessageBox.Show("Datos guardados correctamente.");
            }
        }

        private void HabilitarInputs() 
        {
            txtDetalle.Enabled = true;
            txtParamExterno.Enabled = true;
            txtParamGIES.Enabled = true;

        }

        private void DeshabilitarInputs() 
        {
            txtDetalle.Enabled = false;
            txtParamExterno.Enabled = false;
            txtParamGIES.Enabled = false;
        }

        private void SetearInputs() 
        {
            txtDetalle.Text = Convert.ToString(dgv.SelectedRows[0].Cells["detalle_gies"].Value.ToString());
            txtParamExterno.Text = Convert.ToString(dgv.SelectedRows[0].Cells["Prametro_aplicacion_externa"].Value.ToString()); ;
            txtParamGIES.Text = Convert.ToString(dgv.SelectedRows[0].Cells["prametro_gies"].Value.ToString()); ;
        }

        private void vaciarInputs() 
        {
            txtDetalle.Text = "";
            txtParamExterno.Text = "";
            txtParamGIES.Text = "";
        }

        private void eliminarRegistro()
        {
            if (dgv.Rows.Count > 0)
            {
                int id_Parametro = Convert.ToInt32(dgv.Rows[dgv.SelectedRows[0].Index].Cells["id_ap_ext_parametro"].Value);
                if (MessageBox.Show("¿Desea Eliminar el parametro Seleccionado?.", "Mensaje del Sistema",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    oAppExt.EliminarParametros(id_Parametro);
                }
            }
            else
                MessageBox.Show("No hay registros a eliminar.");

        }
        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ABMAplicaciones_Externas_Parametros_Load(object sender, EventArgs e)
        {
            DataColumn dcId = new DataColumn()
            {
                ColumnName = "Id_Valor_Tipo",
                DataType = typeof(int),
                DefaultValue = 0
            }; dtValores_Tipos.Columns.Add(dcId);
            DataColumn dcTipo = new DataColumn()
            {
                ColumnName = "Valor_Tipo",
                DataType = typeof(string),
                DefaultValue = ""
            }; dtValores_Tipos.Columns.Add(dcTipo);
            DeshabilitarInputs();
            comenzarCarga();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            guardarRegistro();
            comenzarCarga();
            vaciarInputs();
            DeshabilitarInputs();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminarRegistro();
            comenzarCarga();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Id_Registro = 0;
            HabilitarInputs();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 0) 
            { 
                Id_Registro = Convert.ToInt32(dgv.SelectedRows[0].Cells["id_ap_ext_parametro"].Value.ToString());
                SetearInputs();
                HabilitarInputs();
                txtParamExterno.Enabled = false;
                txtParamGIES.Enabled = false;
            }
            else
                MessageBox.Show("No hay registros para editar.");
;
        }

        private void btnCancela_Click(object sender, EventArgs e)
        {
            vaciarInputs();
            DeshabilitarInputs();
        }

        private void btnParametrosDet_Click(object sender, EventArgs e)
        {
            using (frmPopUp frm = new frmPopUp())
            {
                AppExternas.frmParametrosDetalleAppExterna frmABM = new AppExternas.frmParametrosDetalleAppExterna();
                frm.Formulario = frmABM;
                frmABM.id_app_Externa = this.Id_App_Externa;
                frm.Maximizar = false;
                frmABM.Show();
            }
        }
    }
}
