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
using CapaPresentacion;
using CapaNegocios;

namespace CapaPresentacion
{
    public partial class frmVerificacionEliminarServicios : Form
    {
        #region PROPIEDADES
        private DataTable dt_Generado = new DataTable();
        private Thread hilo;
        private delegate void myDel();
        private Servicios oSer = new Servicios();
        public int Total_Usuarios=0,VerificacionTarifaSub=0, VerificacionTarifaSubEsp=0, VerificacionCategoria=0, VerificacionUsuariosServicios=0;
        public int Id_servicio;
        #endregion


        public frmVerificacionEliminarServicios()
        {
            InitializeComponent();
        }

        #region METODOS
        private void comenzarCarga()
        {
            dgv.DataSource = null;

            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Operacion cancelada.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            oSer.Eliminar(Id_servicio);
            if(VerificacionUsuariosServicios == 1)
                oSer.EliminarUsuarioServicio(Id_servicio);
            if(VerificacionTarifaSub == 1 || VerificacionTarifaSubEsp == 1)
                oSer.EliminarTarifas(Id_servicio, VerificacionTarifaSub, VerificacionTarifaSubEsp);
            if(VerificacionCategoria == 1)
                oSer.EliminarCategoria(Id_servicio);
            MessageBox.Show("Servicio eliminado");
            this.Close();
        }

        private void frmVerificacionEliminarServicios_Load(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void cargarDatos()
        {
            try
            {
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
            MessageBox.Show("Este servicio no se puede eliminar. Presione 'OK' para ver los motivos.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            DataColumn dcTarifa = new DataColumn()
            {
                ColumnName = "Tarifa",
                DataType = typeof(string)
            }; dt_Generado.Columns.Add(dcTarifa);
            DataColumn dcCategoria = new DataColumn()
            {
                ColumnName = "Categoria",
                DataType = typeof(string)
            }; dt_Generado.Columns.Add(dcCategoria);
            DataColumn dcUsuarioServicio = new DataColumn()
            {
                ColumnName = "Usuario",
                DataType = typeof(string)
            }; dt_Generado.Columns.Add(dcUsuarioServicio);

            if(VerificacionCategoria == 1) 
            {
                DataRow dr1 = dt_Generado.NewRow();
                dr1["Categoria"] = "SI";
                if (VerificacionTarifaSub == 1 || VerificacionTarifaSubEsp == 1)
                    dr1["Tarifa"] = "SI";
                else
                    dr1["Tarifa"] = "NO";

                if(VerificacionUsuariosServicios == 1)
                    dr1["Usuario"] = "SI - Cantidad: " + Total_Usuarios.ToString();
                else
                    dr1["Usuario"] = "NO - Cantidad: " + Total_Usuarios.ToString();

                dt_Generado.Rows.Add(dr1);
            }
            else 
            {
                DataRow dr1 = dt_Generado.NewRow();
                dr1["Categoria"] = "NO";
                dr1["Tarifa"] = "NO";
                dr1["Usuario"] = "NO";
                dt_Generado.Rows.Add(dr1);
            }

            dgv.DataSource = dt_Generado;

            for (int i = 0; i < dgv.ColumnCount; i++)
                dgv.Columns[i].Visible = true;

        }
        #endregion


        #region Eventos
        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
