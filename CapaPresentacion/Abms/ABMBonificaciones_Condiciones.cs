using CapaNegocios;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Abms
{
    public partial class ABMBonificaciones_Condiciones : Form
    {
        private int IdBonificacionAplicacion = 0;
        private int idCatZona = 0;
        private Thread hilo;
        private delegate void myDel();
        private DataTable DtDatosBonificacionAplicacion = new DataTable();
        private Bonificaciones_Aplicacion oBonificacionAplicacion = new Bonificaciones_Aplicacion();
        private DataTable DtCondiciones = new DataTable();
        private Bonificaciones_Aplicacion_Condiciones oBonificacionesAplicacionCondiciones = new Bonificaciones_Aplicacion_Condiciones();

        private void ComenzarCarga()
        {
            pgCircular.Start();
            hilo = new Thread(new ThreadStart(CargarDatos));
            hilo.IsBackground = true;
            hilo.Start();
        }


        private void CargarDatos()
        {
            try
            {
                DtCondiciones = oBonificacionesAplicacionCondiciones.ListarPorIdBonificacionAplicacion(IdBonificacionAplicacion);
                myDel MD = new myDel(AsignarDatos);
                this.Invoke(MD, new object[] { });
                pgCircular.Stop();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
            }
        }


        private void AsignarDatos()
        {
            dgvCondiciones.DataSource = DtCondiciones;
            for (int x = 0; x < dgvCondiciones.Columns.Count; x++)
                dgvCondiciones.Columns[x].Visible = false;
            dgvCondiciones.Columns["cantidad"].Visible = true;
            dgvCondiciones.Columns["tipo_condicion_texto"].Visible = true;
            dgvCondiciones.Columns["nivel_texto"].Visible = true;
            dgvCondiciones.Columns["nombre_item"].Visible = true;
            dgvCondiciones.Columns["cantidad"].HeaderText = "Cantidad";
            dgvCondiciones.Columns["tipo_condicion_texto"].HeaderText = "Tipo";
            dgvCondiciones.Columns["nivel_texto"].HeaderText = "Nivel";
            dgvCondiciones.Columns["nombre_item"].HeaderText = "Nombre";
            dgvCondiciones.Columns["cantidad"].Width = 70;
            if (dgvCondiciones.Rows.Count > 0)
                btnEliminar.Enabled = true;
            else
                btnEliminar.Enabled = false;
            lblTotal.Text = String.Format("Total de Registros: {0}", dgvCondiciones.Rows.Count);
        }

        private void AgregarCondicion()
        {
            frmBusquedaServicios frmBonificacionItems;
            int NivelBonificacion = Convert.ToInt32(DtDatosBonificacionAplicacion.Rows[0]["nivel"]);
            oBonificacionesAplicacionCondiciones.Id = 0;
            oBonificacionesAplicacionCondiciones.Id_Bonificacion_Aplicacion = IdBonificacionAplicacion;
            oBonificacionesAplicacionCondiciones.Id_Item = 0;
            oBonificacionesAplicacionCondiciones.Nivel = 0;
            oBonificacionesAplicacionCondiciones.Nombre_Item = String.Empty;
            oBonificacionesAplicacionCondiciones.Tipo_Servicio_Sub = String.Empty;
            oBonificacionesAplicacionCondiciones.Tipo_Condicion = 0;
            oBonificacionesAplicacionCondiciones.Cantidad = 0;

            frmBonificacionItems = new frmBusquedaServicios(Convert.ToInt32(Bonificaciones_Aplicacion.SELECCION.TODOS), idCatZona);
            frmPopUp frmpopup = new frmPopUp();
            frmpopup.Maximizar = false;
            frmpopup.Formulario = frmBonificacionItems;
            frmpopup.ShowDialog();
            if (frmBonificacionItems.DialogResult == DialogResult.OK)
            {
                oBonificacionesAplicacionCondiciones.Id_Bonificacion_Aplicacion = IdBonificacionAplicacion;
                oBonificacionesAplicacionCondiciones.Id_Item = Convert.ToInt32(frmBonificacionItems.DrDatosItem["id"]);
                oBonificacionesAplicacionCondiciones.Nivel = Convert.ToInt32(frmBonificacionItems.DrDatosItem["nivel"]);


                if (oBonificacionesAplicacionCondiciones.Nivel == Convert.ToInt32(Bonificaciones_Aplicacion.NIVEL.SUBSERVICIO))
                {
                    oBonificacionesAplicacionCondiciones.Nombre_Item = String.Format("{0} - {1}", frmBonificacionItems.DrDatosItem["nombre"].ToString().Trim(), frmBonificacionItems.DrDatosItem["servicio"].ToString());
                    oBonificacionesAplicacionCondiciones.Tipo_Servicio_Sub = frmBonificacionItems.DrDatosItem["tipo_servicio_sub"].ToString();
                    if (oBonificacionesAplicacionCondiciones.Tipo_Servicio_Sub == "S")
                        oBonificacionesAplicacionCondiciones.Tipo_Condicion = Convert.ToInt32(Bonificaciones_Aplicacion_Condiciones.TIPO_CONDICION.SUBSERVICIOS);
                    else if (oBonificacionesAplicacionCondiciones.Tipo_Servicio_Sub == "E")
                        oBonificacionesAplicacionCondiciones.Tipo_Condicion = Convert.ToInt32(Bonificaciones_Aplicacion_Condiciones.TIPO_CONDICION.EQUIPOS);
                    else if (oBonificacionesAplicacionCondiciones.Tipo_Servicio_Sub == "P")
                        oBonificacionesAplicacionCondiciones.Tipo_Condicion = Convert.ToInt32(Bonificaciones_Aplicacion_Condiciones.TIPO_CONDICION.SOLICITUDES);
                }
                else
                {
                    oBonificacionesAplicacionCondiciones.Tipo_Condicion = Convert.ToInt32(Bonificaciones_Aplicacion_Condiciones.TIPO_CONDICION.SERVICIOS);
                    oBonificacionesAplicacionCondiciones.Nombre_Item = frmBonificacionItems.DrDatosItem["nombre"].ToString().Trim();
                    oBonificacionesAplicacionCondiciones.Tipo_Servicio_Sub = "";
                }


                ABMBonificaciones_CantidadCondiciones frmCantidadCondiciones = new ABMBonificaciones_CantidadCondiciones();
                frmpopup.Formulario = frmCantidadCondiciones;
                frmpopup.ShowDialog();
                if (frmCantidadCondiciones.DialogResult == DialogResult.OK)
                    oBonificacionesAplicacionCondiciones.Cantidad = frmCantidadCondiciones.Cantidad;

                oBonificacionesAplicacionCondiciones.Guardar(oBonificacionesAplicacionCondiciones);
                ComenzarCarga();
            }

        }




        public ABMBonificaciones_Condiciones(int IdBonificacionAplicacionRecibida, int idCatZona)
        {
            IdBonificacionAplicacion = IdBonificacionAplicacionRecibida;
            this.idCatZona = idCatZona;
            InitializeComponent();
        }

        private void ABMCondicionesBonificacion_Load(object sender, EventArgs e)
        {
            DtDatosBonificacionAplicacion = oBonificacionAplicacion.ListarPorId(IdBonificacionAplicacion);
            lblBonificacion.Text = String.Format("Bonificación: {0}", DtDatosBonificacionAplicacion.Rows[0]["nombre"]);
            if (Convert.ToInt32(DtDatosBonificacionAplicacion.Rows[0]["nivel"]) == Convert.ToInt32(Bonificaciones_Aplicacion.NIVEL.GRUPO))
                lblAplicacion.Text = String.Format("Aplicada a: Grupo {0}", DtDatosBonificacionAplicacion.Rows[0]["grupo"]);
            else if (Convert.ToInt32(DtDatosBonificacionAplicacion.Rows[0]["nivel"]) == Convert.ToInt32(Bonificaciones_Aplicacion.NIVEL.TIPO_SERVICIO))
                lblAplicacion.Text = String.Format("Aplicada a: Tipo de servicio {0}", DtDatosBonificacionAplicacion.Rows[0]["tipo_servicio"]);
            else if (Convert.ToInt32(DtDatosBonificacionAplicacion.Rows[0]["nivel"]) == Convert.ToInt32(Bonificaciones_Aplicacion.NIVEL.SERVICIO))
                lblAplicacion.Text = String.Format("Aplicada a: Servicio {0}", DtDatosBonificacionAplicacion.Rows[0]["servicio"]);
            else if (Convert.ToInt32(DtDatosBonificacionAplicacion.Rows[0]["nivel"]) == Convert.ToInt32(Bonificaciones_Aplicacion.NIVEL.SUBSERVICIO))
                lblAplicacion.Text = String.Format("Aplicada a: Sub servicio {0}, con velocidad: {1} MB, del tipo: {2}", DtDatosBonificacionAplicacion.Rows[0]["subservicio"], DtDatosBonificacionAplicacion.Rows[0]["velocidad"], DtDatosBonificacionAplicacion.Rows[0]["velocidad_tipo"]);
            ComenzarCarga();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ABMCondicionesBonificacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ComenzarCarga();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarCondicion();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea eliminar la condicón seleccionada?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    oBonificacionesAplicacionCondiciones.Eliminar(Convert.ToInt32(dgvCondiciones.SelectedRows[0].Cells["id"].Value));
                    ComenzarCarga();
                }
                catch { MessageBox.Show("Error al realizar operación."); }
            }
        }
    }
}
