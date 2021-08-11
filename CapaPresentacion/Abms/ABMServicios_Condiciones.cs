using CapaNegocios;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Abms
{
    public partial class ABMServicios_Condiciones : Form
    {
        //si no se solicita un servicio en particular, enviar el valor de id_servicio en 0
        int Id_Servicio = 0;
        private Thread hilo;
        private delegate void myDel();
        DataTable dtDatos_Servicio = new DataTable();
        Servicios oServicio = new Servicios();
        Servicios_Condiciones oServicios_Condiciones = new Servicios_Condiciones();
        DataTable dtServicios_Condiciones = new DataTable();


        private void comenzarCarga()
        {
            pgCircular.Start();
            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
        }

        private void cargarDatos()
        {
            try
            {
                dtDatos_Servicio = oServicio.BuscarDatosServicio(Id_Servicio);

                dtServicios_Condiciones = oServicios_Condiciones.Listar(Id_Servicio);

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
            if (dtDatos_Servicio.Rows.Count > 0)
            {

                lblNombre.Text = String.Format("Servicio: {0}", dtDatos_Servicio.Rows[0]["Descripcion"]);
                lblTipoServ.Text = String.Format("Tipo: {0}", dtDatos_Servicio.Rows[0]["Servicio_Tipo"]);
                lblModalidad.Text = String.Format("Modalidad: {0}", dtDatos_Servicio.Rows[0]["Modalidad"]);


                DataGridViewLinkColumn colEliminar = new DataGridViewLinkColumn();
                colEliminar.HeaderText = "";
                colEliminar.Text = "Eliminar";
                colEliminar.UseColumnTextForLinkValue = true;
                colEliminar.Name = "colEliminar";

                int control = 0;

                foreach (DataGridViewColumn columna in dgvServicioCondiciones.Columns)
                {
                    if (columna.Index == dgvServicioCondiciones.Columns["colEliminar"].Index)
                    {
                        control = 1;
                        break;
                    }
                }

                if (control == 1)
                    dgvServicioCondiciones.Columns.RemoveAt(dgvServicioCondiciones.Columns["colEliminar"].Index);

                dgvServicioCondiciones.DataSource = dtServicios_Condiciones;
                dgvServicioCondiciones.Columns.Add(colEliminar);
                dgvServicioCondiciones.Columns["id"].Visible = false;
                dgvServicioCondiciones.Columns["Id_servicio"].Visible = false;
                dgvServicioCondiciones.Columns["Id_tipo_condicion"].Visible = false;
                dgvServicioCondiciones.Columns["id_condicion"].Visible = false;
                dgvServicioCondiciones.Columns["id_tipo_facturacion"].Visible = false;
                dgvServicioCondiciones.Columns["tipo_item"].HeaderText = "";
                dgvServicioCondiciones.Columns["Nombre_Condicion"].HeaderText = "Nombre";
                dgvServicioCondiciones.Columns["Tipo_Condicion"].HeaderText = "Tipo";
                dgvServicioCondiciones.Columns["tipofac"].HeaderText = "Tipo facturación";
                dgvServicioCondiciones.Enabled = true;
            }
            else
                MessageBox.Show("Error al cargar datos del servicio. Puede que este inactivo o borrado.");
        }


        private void AgregarCondicion()
        {
            frmBusquedaServicios frmBuscarServicios = new frmBusquedaServicios(Convert.ToInt32(Bonificaciones_Aplicacion.SELECCION.GRUPOS_TIPOS_SERVICIOS), 0);

            frmPopUp frmpopup = new frmPopUp();
            frmpopup.Maximizar = false;
            frmpopup.Formulario = frmBuscarServicios;
            frmpopup.ShowDialog();

            if (frmBuscarServicios.DialogResult == DialogResult.OK)
            {
                try
                {
                    oServicios_Condiciones.Id_Servicio = Id_Servicio;
                    oServicios_Condiciones.Id_Tipo_Condicion = Convert.ToInt32(frmBuscarServicios.DrDatosItem["nivel"]);
                    oServicios_Condiciones.Id_Condicion = Convert.ToInt32(frmBuscarServicios.DrDatosItem["id"]);
                    oServicios_Condiciones.Cantidad = 1;
                    oServicios_Condiciones.Id_Tipo_Facturacion = frmBuscarServicios.idCatZonaRetorno;
                    ABMBonificaciones_CantidadCondiciones frmCantidadServicios = new ABMBonificaciones_CantidadCondiciones();
                    frmpopup.Formulario = frmCantidadServicios;
                    frmpopup.ShowDialog();
                    if (frmCantidadServicios.DialogResult == DialogResult.OK)
                        oServicios_Condiciones.Cantidad = frmCantidadServicios.Cantidad;
                    //oServicios_Condiciones.Cantidad = 1;
                    oServicios_Condiciones.Guardar(oServicios_Condiciones);
                    MessageBox.Show("Condición agregada correctamente.");
                    comenzarCarga();
                }
                catch
                {
                    MessageBox.Show("Error al agregar condición.");
                }
            }
        }


        private void Eliminar()
        {
            oServicios_Condiciones.Eliminar(Convert.ToInt32(dgvServicioCondiciones.SelectedRows[0].Cells["id"].Value));
            comenzarCarga();
        }

        public ABMServicios_Condiciones(int id_servicio)
        {
            Id_Servicio = id_servicio;
            InitializeComponent();
        }


        private void ABMServiciosCondiciones_Load(object sender, EventArgs e)
        {
            if (Id_Servicio > 0)
                comenzarCarga();

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarCondicion();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void dgvServicioCondiciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.ColumnIndex == dgvServicioCondiciones.SelectedRows[0].Cells["colEliminar"].ColumnIndex)
                {
                    DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea eliminar la condición seleccionada?", "", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                        Eliminar();

                }
            }
            catch
            { }
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ABMServiciosCondiciones_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmBusquedaServicios frm = new frmBusquedaServicios(1, 0);
            frmPopUp frmpopup = new frmPopUp();
            frmpopup.Maximizar = false;
            frmpopup.Formulario = frm;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                //Id_Servicio= Convert.ToInt32(frm.servicio_actual["idServicio"]);
                comenzarCarga();
            }
        }
    }
}//041119fede
