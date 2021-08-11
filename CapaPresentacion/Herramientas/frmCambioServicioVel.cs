using CapaNegocios;
using CapaPresentacion.Herramientas;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmCambioServicioVel : Form
    {
        #region PROPIEDADES

        private Servicios oServicios = new Servicios();
        private Usuarios_Servicios oUsuarios_Servicios = new Usuarios_Servicios();
        private Servicios_Tarifas ServiciosTarifas = new Servicios_Tarifas();
        private Servicios_Velocidades ServiciosVelocidades = new Servicios_Velocidades();

        private DataTable Data = new DataTable();
        private DataTable DataZonas = new DataTable();
        private DataTable DataServicios = new DataTable();
        private DataTable DataServiciosVel = new DataTable();
        private DataTable DataServiciosVelTip = new DataTable();
        private DataTable DataT = new DataTable();

        private Int32 IdZonas, IdServicios, IdServiciosVel, IdServiciosVelTip;

        private Thread hilo;
        private delegate void myDel();
        #endregion

        #region MÉTODOS
        private void comenzarCarga()
        {
            pgCircular.Start();

            dgvDatos.DataSource = null;

            IdZonas = Convert.ToInt32(cboZonas.SelectedValue);
            IdServicios = Convert.ToInt32(cboServicios.SelectedValue);
            IdServiciosVel = Convert.ToInt32(cboServicios_Vel.SelectedValue);
            IdServiciosVelTip = Convert.ToInt32(cboServicios_Vel_Tip.SelectedValue);

            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.IsBackground = true;
            hilo.Start();
        }

        private void inicioCarga()
        {
            pgCircular.Start();

            hilo = new Thread(new ThreadStart(cargarCombos));
            hilo.IsBackground = true;
            hilo.Start();
        }

        private void cargarCombos()
        {
            Servicios oServicios = new Servicios();
            Servicios_Tipos oServicios_Tipos = new Servicios_Tipos();

            Zonas oZonas = new Zonas();
            DataZonas = oZonas.Listar();
            DataZonas.Rows.Add(0, "TODAS", 0);
            DataZonas.DefaultView.Sort = "Id asc";
            DataZonas = DataZonas.DefaultView.ToTable(true);

            myDel MD = new myDel(asignarCombos);
            this.Invoke(MD, new object[] { });
            pgCircular.Stop();
        }

        private void cargarDatos()
        {
            Data = oUsuarios_Servicios.ListarServicioVel(IdZonas, IdServicios, IdServiciosVel, IdServiciosVelTip);

            myDel MD = new myDel(asignarDatos);
            this.Invoke(MD, new object[] { });
            pgCircular.Stop();
        }

        private void asignarDatos()
        {
            dgvDatos.DataSource = Data;

            lblTotal.Text = String.Format("Total de Registros: {0}", Data.Rows.Count);
        }

        private void asignarCombos()
        {
            cboZonas.DataSource = DataZonas;
            cboZonas.DisplayMember = "Nombre";
            cboZonas.ValueMember = "Id";
        }
        #endregion

        public frmCambioServicioVel()
        {
            InitializeComponent();
        }

        private void frmCambioServicioVel_Load(object sender, EventArgs e)
        {
            this.cargarCombos();
        }


        private void btnExportar_Click(object sender, EventArgs e)
        {
            Tools tools = new Tools();
            tools.ExportToExcel(dgvDatos, "Usuarios");

        }

        private void cboZonas_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataServicios = oServicios.ListarPorTipoFacturacion(Convert.ToInt32(cboZonas.SelectedValue));

            DataServicios.DefaultView.RowFilter = "requiere_velocidad = 'SI'";

            cboServicios.DataSource = DataServicios;
            cboServicios.DisplayMember = "Descripcion";
            cboServicios.ValueMember = "Id_Servicios";
           // cboServicios.SelectionChangeCommitted += new EventHandler(this.cboServicios_SelectionChangeCommitted);
        }

        private void cboServicios_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int idtarifa = ServiciosTarifas.getTarifaId();

            DataT = ServiciosVelocidades.ListarPrecios(idtarifa, Convert.ToInt32(cboZonas.SelectedValue), Convert.ToInt32(cboServicios.SelectedValue));

            DataView view = new DataView(DataT);
            DataTable DataServiciosVel = view.ToTable(true, "Velocidad", "Id_Servicios_Velocidad");

            DataServiciosVel.DefaultView.ToTable(true, "Velocidad");

            cboServicios_Vel.DataSource = DataServiciosVel;
            cboServicios_Vel.DisplayMember = "Velocidad";
            cboServicios_Vel.ValueMember = "Id_Servicios_Velocidad";
        }

        private void cboServicios_Vel_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataView view = new DataView(DataT);
            DataTable DataServiciosVel = view.ToTable(true, "Tipo", "Id_Servicios_Velocidad_Tip");

            DataServiciosVel.DefaultView.ToTable(true, "Tipo");

            cboServicios_Vel_Tip.DataSource = DataServiciosVel;
            cboServicios_Vel_Tip.DisplayMember = "Tipo";
            cboServicios_Vel_Tip.ValueMember = "Id_Servicios_Velocidad_Tip";
        }

        private void btnCambioVel_Click(object sender, EventArgs e)
        {
            if (Data.Rows.Count > 0)
            {
                using (frmPopUp frm = new frmPopUp())
                {
                    frmCambioServicioVelSel frmSel = new frmCambioServicioVelSel();

                    int idtarifa = ServiciosTarifas.getTarifaId();

                    DataT = ServiciosVelocidades.ListarPrecios(idtarifa, Convert.ToInt32(cboZonas.SelectedValue), Convert.ToInt32(cboServicios.SelectedValue));

                    DataView view = new DataView(DataT);
                    DataTable DataServiciosVel = view.ToTable(true, "Velocidad", "Id_Servicios_Velocidad");

                    DataServiciosVel.DefaultView.ToTable(true, "Velocidad");

                    frmSel.dataTableVel = DataServiciosVel;
                    frm.Formulario = frmSel;
                    frm.Maximizar = false;

                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        Int32 Id_Zona = Convert.ToInt32(cboZonas.SelectedValue);
                        Int32 Id_Servicios = Convert.ToInt32(cboServicios.SelectedValue);
                        Int32 Id_Servicios_Vel_Anterior = Convert.ToInt32(cboServicios_Vel.SelectedValue);
                        Int32 Id_Servicios_Vel_Nueva = frmSel.Id_Velocidad_Sel;
                        Int32 Id_Tarifa = frmSel.Id_Tarifa_Sel;
                        Int32 Id_Servicios_Vel_Tip = Convert.ToInt32(cboServicios_Vel_Tip.SelectedValue);


                        Usuarios_Servicios oUsuarios_Servicios = new Usuarios_Servicios();

                        if (oUsuarios_Servicios.ActualizarVelocidades(Id_Zona, Id_Servicios, Id_Servicios_Vel_Anterior, Id_Servicios_Vel_Nueva))
                        {
                            Servicios_Tarifas_Sub_Esp servicios_Tarifas_Sub_Esp = new Servicios_Tarifas_Sub_Esp();

                            if (servicios_Tarifas_Sub_Esp.CambiarVelocidades(Id_Tarifa, Id_Zona, Id_Servicios, Id_Servicios_Vel_Anterior, Id_Servicios_Vel_Nueva, Id_Servicios_Vel_Tip))
                                this.comenzarCarga();
                        }
                    }
                }
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            this.comenzarCarga();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Data.DefaultView.RowFilter = String.Format("CONVERT(codigo, System.String) LIKE '%{0}%' or apellido LIKE '%{0}%' or nombre LIKE '%{0}%'", txtBuscar.Text);
            lblTotal.Text = String.Format("Total de Registros: {0}", dgvDatos.Rows.Count);
        }

        private void frmCambioServicioVel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
