using CapaNegocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Complementarias
{
    public partial class frmCambioServicioGeneracionPartes : Form
    {
        public bool CambioEquipo { get; set; }
        public bool CambioTecnologia { get; set; }
        public int IdFallaCambioEquipo { get; private set; }
        public int IdFallaCambioTecnologia { get; private set; }
        public string DescFallaCambioEquipo { get; private set; }
        public string DescFallaCambioTecnologia { get; private set; }

        private int idServicioTipoNuevo;

        public frmCambioServicioGeneracionPartes(int idServicioTipoNuevo)
        {
            InitializeComponent();
            CambioEquipo = true;
            CambioTecnologia = true;
            this.idServicioTipoNuevo = idServicioTipoNuevo;
        }

        private void cargarDatos()
        {
            DataTable DtSolicitudes = new Partes_Solicitudes().ListarServicioTipo(idServicioTipoNuevo, 0, 0, "P", 0);
            cboFallasCambioEquipo.DataSource = DtSolicitudes.Select(String.Format("id_partes_operaciones={0}", Convert.ToInt32(Partes.Partes_Operaciones.CAMBIO_DE_EQUIPO))).CopyToDataTable();
            cboFallasCambioEquipo.DisplayMember = "falla";
            cboFallasCambioEquipo.ValueMember = "id";

            cboFallasCambioTecnologia.DataSource = DtSolicitudes.Select(String.Format("id_partes_operaciones={0}", Convert.ToInt32(Partes.Partes_Operaciones.CAMBIO_TECNOLOGIA))).CopyToDataTable();
            cboFallasCambioTecnologia.DisplayMember = "falla";
            cboFallasCambioTecnologia.ValueMember = "id";
        }

        private void btnCambiar_Click(object sender, EventArgs e)
        {
            //verificar si hay fallas en el combobox
            IdFallaCambioEquipo = Convert.ToInt32(cboFallasCambioEquipo.SelectedValue);
            IdFallaCambioTecnologia = Convert.ToInt32(cboFallasCambioTecnologia.SelectedValue);
            DescFallaCambioEquipo = cboFallasCambioEquipo.Text;
            DescFallaCambioTecnologia = cboFallasCambioTecnologia.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void cerrarFormulario()
        {
            if(MessageBox.Show("Si cancela la operacion el cambio de servicio no se realizara\n¿Salir de todos modos?", "Mensaje del sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.DialogResult = DialogResult.Cancel;
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            cerrarFormulario();
        }

        private void frmCambioServicioGeneracionPartes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                cerrarFormulario();
        }

        private void cambiarEstadoCheckbox(object sender, EventArgs e)
        {
            CheckBox currentChk = sender as CheckBox;

            if (currentChk.Name == chkCambioEquipo.Name)
            {
                CambioEquipo = currentChk.Checked;
                cboFallasCambioEquipo.Enabled = currentChk.Checked;
            }
            else
            {
                CambioTecnologia = currentChk.Checked;
                cboFallasCambioTecnologia.Enabled = currentChk.Checked;
            }
        }

        private void frmCambioServicioGeneracionPartes_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }
    }
}
