using CapaNegocios;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmABMOperaciones : Form
    {
        private Thread hilo;
        private delegate void myDel();
        private DataTable dt;
        private Partes oPartes = new Partes();
        private Partes_Solicitudes oPartes_fallas = new Partes_Solicitudes();
        private Int32 id;

        public frmABMOperaciones()
        {
            InitializeComponent();
        }
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
                dt = oPartes.ListarOperaciones();
                myDel MD = new myDel(asignarDatos);
                this.Invoke(MD, new object[] { });
                pgCircular.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Informacion" + ex.Message);
            }
        }
        private void controles(bool state)
        {
            btnActualizar.Enabled = !state;
            btnNuevo.Enabled = !state;
            btnEditar.Enabled = dt.Rows.Count == 0 ? false : !state;
            btnEliminar.Enabled = dt.Rows.Count == 0 ? false : !state;
            dgv.Enabled = !state;
            txtNombre.Enabled = state;
            btnGuardar.Enabled = state;
            btnCancelar.Enabled = state;

        }

        private void asignarValores()
        {
            try
            {
                id = Convert.ToInt32(dgv.SelectedRows[0].Cells["Id"].Value);
                txtNombre.Text = dgv.SelectedRows[0].Cells["Nombre"].Value.ToString();
                if (Convert.ToInt32(dgv.SelectedRows[0].Cells["parte_fallas"].Value) == 1)
                {
                    chkParteFallas.Checked = true;
                }
                else
                {
                    chkParteFallas.Checked = false;
                }
                if (Convert.ToInt32(dgv.SelectedRows[0].Cells["partetrabajo"].Value) == 1)
                {
                    chkParteTrabajo.Checked = true;
                }
                else
                {
                    chkParteTrabajo.Checked = false;
                }
                if (Convert.ToInt32(dgv.SelectedRows[0].Cells["concargo"].Value) == 1)
                {
                    chkConCargo.Checked = true;
                }
                else
                {
                    chkConCargo.Checked = false;
                }

            }
            catch { }
        }
        private void asignarDatos()
        {
            dgv.DataSource = dt;

            if (dt.Rows.Count > 0)
            {
                dgv.Columns["Nombre"].HeaderText = "Operacion";
                lblTotal.Text = String.Format("Total de Registros: {0}", dt.Rows.Count);
                controles(false);
                asignarValores();
            }
        }
        private void DesabilitarControles()
        {
            btnActualizar.Enabled = false;
            btnNuevo.Enabled = false;
            btnEliminar.Enabled = false;
            btnEditar.Enabled = false;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
        }
        private void nuevoRegistro()
        {
            id = 0;
            txtNombre.Text = "";
            txtNombre.Enabled = true;
            txtNombre.Focus();
        }

        private void editarRegistro()
        {
            txtNombre.Enabled = true;
            txtNombre.Focus();
        }

        private void eliminarRegistro()
        {
            if (MessageBox.Show("¿Desea eliminar el Registro Seleccionado?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                oPartes.Eliminar_Operacion(id);
                comenzarCarga();
            }
        }
        private void guardarRegistro()
        {
            if (txtNombre.Text.Trim().Length == 0)
            {
                txtNombre.Focus();
            }
            else
            {
                if (validarDatos())
                {
                    oPartes.Operaciones_Id = id;
                    oPartes.Operacion_Nombre = txtNombre.Text.ToUpper();

                    if (chkParteFallas.Checked == true)
                    {
                        oPartes.Operacion_ParteFallas = 1;
                    }
                    else
                    {
                        oPartes.Operacion_ParteFallas = 0;
                    }

                    if (chkConCargo.Checked == true)
                    {
                        oPartes.Operacion_conCargo = 1;
                    }
                    else
                    {
                        oPartes.Operacion_conCargo = 0;
                    }

                    if (chkParteTrabajo.Checked == true)
                    {
                        oPartes.Opercion_ParteTrabajo = 1;
                    }
                    else
                    {
                        oPartes.Opercion_ParteTrabajo = 0;
                    }

                    oPartes.Guardar_Operacion(oPartes);
                    oPartes_fallas.Insertar_Operaciones_Basicas();
                    comenzarCarga();
                }
            }
        }

        private void cancelarEdicion()
        {
            controles(false);
        }

        private bool validarDatos()
        {
            if (txtNombre.Text.Trim().Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            guardarRegistro();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            controles(true);
            editarRegistro();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            controles(false);
            comenzarCarga();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            controles(true);
            limpiarValores();
            nuevoRegistro();
        }

        private void limpiarValores()
        {
            id = 0;
            txtNombre.Text = "";
            chkConCargo.Checked = false;
            chkParteFallas.Checked = false;
            chkParteTrabajo.Checked = false;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminarRegistro();
            if (dgv.Rows.Count == 0)
                limpiarValores();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cancelarEdicion();

        }

        private void frmABMOperaciones_Load(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            asignarValores();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
