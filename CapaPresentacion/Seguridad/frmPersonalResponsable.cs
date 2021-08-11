using CapaNegocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CapaPresentacion.Seguridad
{
    public partial class frmPersonalResponsable : Form
    {
        private readonly Objetos.Acciones accion;
        private readonly Entidades.Tabla entidad;
        private readonly List<int> idRegistrosAfectados;
        private DataTable dtPersonalHabilitado;

        public frmPersonalResponsable(Objetos.Acciones accion, Entidades.Tabla entidad, List<int> idRegistrosAfectados)
        {
            this.accion = accion;
            this.entidad = entidad;
            this.idRegistrosAfectados = idRegistrosAfectados;
            InitializeComponent();
        }

        public frmPersonalResponsable(Objetos.Acciones accion, Entidades.Tabla entidad, int idRegistroAfectado)
        {
            this.accion = accion;
            this.entidad = entidad;
            this.idRegistrosAfectados = new List<int>() { idRegistroAfectado };
            InitializeComponent();
        }

        private void frmPersonalResponsable_Load(object sender, EventArgs e)
        {
            dtPersonalHabilitado = new Personal().ListarPersonalHabilitado(accion);
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            int idPersonalSeleccionado = Convert.ToInt32(cboPersonal.SelectedValue);
            DataRow row = dtPersonalHabilitado.Select($"id_personal = {idPersonalSeleccionado}")[0];
            if(row["personal_clave"].ToString().ToUpper() == txtClave.Text.ToUpper())
            {
                foreach (int idRegistro in idRegistrosAfectados)
                {
                    Log_Acciones.Guardar(idPersonalSeleccionado, new Objetos().GetId(accion.ToString()), DateTime.Now, Convert.ToInt32(entidad), idRegistro);
                }
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Clave incorrecta", "Mensaje del sistema");
                return;
            }
        }

        private void frmPersonalResponsable_Shown(object sender, EventArgs e)
        {
            if (dtPersonalHabilitado.Rows.Count == 0)
            {
                MessageBox.Show("No hay ningun personal habilitado para realizar esta accion.", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboPersonal.Enabled = false;
                btnIngresar.Enabled = false;
                txtClave.Enabled = false;
                return;
            }

            cboPersonal.DataSource = dtPersonalHabilitado;
            cboPersonal.DisplayMember = "nombre_personal";
            cboPersonal.ValueMember = "id_personal";
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void frmPersonalResponsable_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                DialogResult = DialogResult.Cancel;
        }
    }
}
