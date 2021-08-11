using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using CapaNegocios;

namespace CapaPresentacion.AppExternas
{
    public partial class frmRelacionVelocidades : Form
    {
        #region PRPIEDADES

        private int IdVelocidad;
        private int IdVelocidadTipo;
        private int IdPaquete;
        private int IdAppExterna;
        private Servicios_Velocidades oVelocidades = new Servicios_Velocidades();
        private DataTable dtVelocidades;
        private DataTable dtVelocidadesTipos;
        private DataTable dtPaquetes;
        private DataTable dtRelaciones;
        private DataTable dtDatosAppExterna;

        private Thread hilo;
        private Isp oIsp;
        private int idAppExterna;
        private bool cargo = false;
        private delegate void myDel();

        #endregion

        #region METODOS
        private void comenzarCarga()
        {
            pgCircular.Start();
            dgvRelaciones.DataSource = null;
            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
        }

        private void cargarDatos()
        {
            try
            {
                DataView dv = Tablas.DataAplicionesExternas.DefaultView;
                dv.RowFilter = "nombre = 'ISP'";
                dtDatosAppExterna = dv.ToTable();
                if(dtDatosAppExterna.Rows.Count>0)
                {
                    idAppExterna = Convert.ToInt32(dtDatosAppExterna.Rows[0]["id"]);
                    oIsp = new Isp();
                    Isp.cadenaConexion = dtDatosAppExterna.Rows[0]["string_conexion"].ToString();
                    dtVelocidades = Tablas.DataServicios_Velocidades;
                    dtVelocidadesTipos = Tablas.DataServicios_Velocidades_Tipos;
                    dtPaquetes = oIsp.ListarProductos(idAppExterna);
                    dtRelaciones = oVelocidades.ListarRelacionesExternas();
                }
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
            cboVelocidad.DataSource = dtVelocidades;
            cboVelocidad.DisplayMember = "velocidad";
            cboVelocidad.ValueMember = "id";

            cboVelocidadTipo.DataSource = dtVelocidadesTipos;
            cboVelocidadTipo.DisplayMember = "nombre";
            cboVelocidadTipo.ValueMember = "id";

            cboPaquetes.DataSource = dtPaquetes;
            cboPaquetes.ValueMember = "product_id";
            cboPaquetes.DisplayMember = "name";

            dgvRelaciones.DataSource = dtRelaciones;
            dgvRelaciones.Columns["velocidad"].HeaderText = "Velocidad";
            dgvRelaciones.Columns["tipo_velocidad"].HeaderText = "Tipo de Velocidad";
            dgvRelaciones.Columns["paquete"].HeaderText = "Paquete Externo";
            dgvRelaciones.Columns["id"].Visible = false;
            dgvRelaciones.Columns["id_velocidad"].Visible = false;
            dgvRelaciones.Columns["id_velocidad_tipo"].Visible = false;
            dgvRelaciones.Columns["id_paquete_externo"].Visible = false;
            ColocarNombrePaquetes();
            lblTotal.Text = $"Cantidad de resgistros: {dtRelaciones.Rows.Count.ToString()}";
        }

        private void ColocarNombrePaquetes()
        {
            int idPaqueteAux = 0;
            DataTable dtAux = new DataTable();
            DataView dv = dtPaquetes.DefaultView;
            foreach (DataRow item in dtRelaciones.Rows)
            {
                idPaqueteAux = Convert.ToInt32(item["id_paquete_externo"]);
                dv.RowFilter = $"product_id={idPaqueteAux}";
                dtAux = dv.ToTable();
                if (dtAux.Rows.Count > 0)
                    item["paquete"] = dtAux.Rows[0]["name"].ToString();
                else
                    item["paquete"] = "Nombre de producto no disponible";

            }
            dv.RowFilter = "";


        }

        #endregion

        public frmRelacionVelocidades()
        {
            InitializeComponent();
        }

        private void btnAsociar_Click(object sender, EventArgs e)
        {
            IdVelocidad = Convert.ToInt32(cboVelocidad.SelectedValue);
            IdVelocidadTipo = Convert.ToInt32(cboVelocidadTipo.SelectedValue);
            IdPaquete = Convert.ToInt32(cboPaquetes.SelectedValue);
            
            DataView dvRelaciones = dtRelaciones.DefaultView;
            dvRelaciones.RowFilter = $"id_velocidad={IdVelocidad} and id_velocidad_tipo={IdVelocidadTipo} and id_paquete_externo={IdPaquete}";
            if(dvRelaciones.Count>0)
                MessageBox.Show("Ya existe una relacion con esta velocidad, tipo de velocidad y paquete externo.", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                dvRelaciones.RowFilter = $"id_velocidad={IdVelocidad} and id_velocidad_tipo={IdVelocidadTipo}";
                if(dvRelaciones.Count>0)
                {
                    DataTable dtAux = dvRelaciones.ToTable();
                    MessageBox.Show($"La velocidad seleccionada y el tipo de velocidad seleccionado ya tiene una relacion con {dtAux.Rows[0]["paquete"].ToString()}.", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (oVelocidades.GuardarRelacionExterna(IdVelocidad, IdVelocidadTipo, IdPaquete) == 0)
                    {
                        MessageBox.Show("Relacion guardada correctamente", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        comenzarCarga();
                    }
                    else
                        MessageBox.Show("Hubo un error al intentar guardar la relacion de servicios.", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            dvRelaciones.RowFilter = "";
        }

        private void frmRelacionVelocidades_Load(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if( dgvRelaciones.SelectedRows.Count>0)
            {
                if (oVelocidades.EliminarRelacionExterna(Convert.ToInt32(dgvRelaciones.SelectedRows[0].Cells["id"].Value))==0){
                    MessageBox.Show("Relacion eliminada correctamente", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    comenzarCarga();
                }
                else
                    MessageBox.Show("Hubo un error al intentar eliminar la relacion de servicios.", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRelacionVelocidades_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
