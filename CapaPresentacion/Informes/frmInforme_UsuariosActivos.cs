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
using CapaNegocios;

namespace CapaPresentacion.Informes
{
    public partial class frmInforme_UsuariosActivos : Form
    {
        public frmInforme_UsuariosActivos()
        {
            InitializeComponent();
        }

        #region DECLARACIONES
        private Thread hilo;
        private delegate void myDel();
        private DataTable dt, dtEstado;
        private Usuarios oUsu = new Usuarios();
        private Servicios oServ = new Servicios();
        int IndiceActual = 0, CantidadTotales = 0, CantidadUsuariosTotales = 0;
        string filtro = "";
        DataTable dt2 = new DataTable();
        DataTable dtTotalUsuarios = new DataTable();
        DataColumn col;
        #endregion

        #region PROPIEDADES
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
                dt = oUsu.Listar_Activos_Mensuales(filtro);
                
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
            SetearUsuariosInDatatable();
            dgv.DataSource = dt;
            CalcularFilasTotales();
            lblTotalRegistros.Text = "Cantidad de Servicios: " + CantidadTotales.ToString();
            lblUsuTotal.Text = "Cantidad de Usuarios por Estados: " + CantidadUsuariosTotales.ToString();
            CalcularPosrcentajes();
            FormatearGrilla();
        }

        private void FormatearGrilla()
        {
            for (int i = 0; i < dgv.ColumnCount; i++)
                dgv.Columns[i].Visible = false;

            dgv.Columns["Factura_mensualmente"].DisplayIndex = 0;
            dgv.Columns["Tipo_Servicio"].DisplayIndex = 1;
            dgv.Columns["Servicio"].DisplayIndex = 2;
            dgv.Columns["modalidad"].DisplayIndex = 3;
            dgv.Columns["cantidad"].DisplayIndex = 4;
            dgv.Columns["porcentaje_servicio"].DisplayIndex = 5;
            dgv.Columns["cantUsu"].DisplayIndex = 6;
            dgv.Columns["porcentaje_usuario"].DisplayIndex = 7;


            dgv.Columns["Servicio"].Visible = true;
            dgv.Columns["modalidad"].Visible = true;
            dgv.Columns["cantidad"].Visible = true;

            dgv.Columns["Tipo_Servicio"].Visible = true;
            dgv.Columns["Factura_mensualmente"].Visible = true;
            dgv.Columns["cantUsu"].Visible = true;
            dgv.Columns["porcentaje_servicio"].Visible = true;
            dgv.Columns["porcentaje_usuario"].Visible = true;
            dgv.Columns["porcentaje_servicio"].DefaultCellStyle.Alignment  = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["porcentaje_usuario"].DefaultCellStyle.Alignment  = DataGridViewContentAlignment.MiddleRight;

            dgv.Columns["Servicio"].HeaderText = "Servicio";
            dgv.Columns["modalidad"].HeaderText = "Modalidad";
            dgv.Columns["cantidad"].HeaderText = "Cantidad Servicios";
            dgv.Columns["Tipo_Servicio"].HeaderText = "Tipo Servicio";
            dgv.Columns["Factura_mensualmente"].HeaderText = "Factura Mensualmente";
            dgv.Columns["cantUsu"].HeaderText = "Cantidad Usuarios";
            dgv.Columns["porcentaje_servicio"].HeaderText = "% Servicios";
            dgv.Columns["porcentaje_usuario"].HeaderText = "% Usuarios";

            dgv.Columns["cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["cantUsu"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        
        private void SetearUsuariosInDatatable()
        {
            int id_Servicio;
            col = new DataColumn();
            col.DataType = System.Type.GetType("System.Int32");
            col.ColumnName = "cantUsu";
            dt.Columns.Add(col);

            DataColumn dcPorcentajeSer = new DataColumn();
            dcPorcentajeSer.DataType = typeof(decimal);
            dcPorcentajeSer.ColumnName = "porcentaje_servicio";
            dcPorcentajeSer.DefaultValue = 0;
            dt.Columns.Add(dcPorcentajeSer);

            DataColumn dcPorcentajeUsu = new DataColumn();
            dcPorcentajeUsu.DataType = typeof(decimal);
            dcPorcentajeUsu.ColumnName = "porcentaje_usuario";
            dcPorcentajeUsu.DefaultValue = 0;

            dt.Columns.Add(dcPorcentajeUsu);

            foreach (DataRow dr in dt.Rows) 
            {
                id_Servicio = 0;
                id_Servicio = Convert.ToInt32(dr["id_Servicio"]);
                dt2 = oUsu.Listar_Activos_Mensuales_usuarios(id_Servicio, filtro);
                dr["cantUsu"] = Convert.ToInt32(dt2.Rows[0]["CantUsu"].ToString());
                dt2.Clear();        
            }



        }

        private void CalcularFilasTotales()
        {
            dtTotalUsuarios = oUsu.ObtenerTotalUsuariosActivos(filtro);
            CantidadUsuariosTotales = 0;
            CantidadUsuariosTotales = Convert.ToInt32(dtTotalUsuarios.Rows[0]["CantUsu"].ToString());
            CantidadTotales = 0;
            if (dgv.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.Visible)
                    {
                        CantidadTotales= CantidadTotales + Convert.ToInt32(row.Cells["cantidad"].Value);
                        //CantidadUsuariosTotales = CantidadUsuariosTotales + Convert.ToInt32(row.Cells["cantUsu"].Value);
                    }
                }
            }
        }

        private void CalcularPosrcentajes()
        {
            decimal cantSer = 0;
            decimal cantUsu = 0;
            decimal porcentajeSer = 0;
            decimal porcentajeUsu = 0;
            
            foreach (DataRow dr in dt.Rows)
            {
                cantSer = Convert.ToInt32(dr["cantidad"]);
                porcentajeSer =Convert.ToDecimal((cantSer * 100) / CantidadTotales);
                dr["porcentaje_servicio"] =decimal.Round(porcentajeSer,2);
                cantUsu = Convert.ToInt32(dr["cantUsu"]);
                porcentajeUsu = Convert.ToDecimal((cantUsu * 100) / CantidadUsuariosTotales);
                dr["porcentaje_usuario"] = decimal.Round(porcentajeUsu, 2);
            }
        }
        #endregion

        #region EVENTOS


        private void btnExportar_Click(object sender, EventArgs e)
        {
            String Estados = string.Empty;

            foreach (object itemChecked in checkedListBoxServiciosEstados.CheckedItems)           
                Estados = Estados + "  " + itemChecked.ToString();
            
            if (dgv.Rows.Count > 0)
            {
                Tools tools = new Tools();
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    if(filtro == "")
                        tools.ExportDataTableToExcel(dt, "Sin Estados  ");
                    else
                        tools.ExportDataTableToExcel(dt, "Estados");
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al exportar a excel");
                }
                finally { this.Cursor = Cursors.Default; }
            }
            else
                MessageBox.Show("Grilla vacia");

        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmInforme_UsuariosActivos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void checkedListBoxServiciosEstados_SelectedIndexChanged(object sender, EventArgs e)
        {
            IndiceActual = checkedListBoxServiciosEstados.SelectedIndex;
            if (IndiceActual != -1) 
            {
                for(int i =0; i < checkedListBoxServiciosEstados.Items.Count; i++) 
                {
                    if (checkedListBoxServiciosEstados.GetItemChecked(i)) 
                        dtEstado.Rows[i]["Checked"] = true;
                    else
                        dtEstado.Rows[i]["Checked"] = false;

                }
                filtro = "";
                foreach(DataRow dr in dtEstado.Rows) 
                {
                        if (Convert.ToBoolean(dr["Checked"]) == true) 
                            filtro = filtro + dr["id"] + ",";
                }
                if (filtro != "")
                    filtro = filtro.Substring(0, filtro.Length - 1);
                else
                    filtro = "";
                comenzarCarga();
            }
        }

        private void frmInforme_UsuariosActivos_Load(object sender, EventArgs e)
        {
            filtro = string.Empty;
            dtEstado = oServ.ListarEstados();
            DataColumn clmChecked = new DataColumn
            {
                ColumnName = "Checked",
                DataType = typeof(Boolean),
                DefaultValue = false
            };
            dtEstado.Columns.Add(clmChecked);
            foreach (DataRow drEstado in dtEstado.Rows) 
            {
                checkedListBoxServiciosEstados.Items.Add(drEstado["Estado"].ToString());
            }
            comenzarCarga();
        }
        #endregion
    }
}
