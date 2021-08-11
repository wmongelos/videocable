using CapaNegocios;
using CapaPresentacion.Busquedas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacion.Herramientas
{
    public partial class frmCambioFac : Form
    {
        private Zonas oZonas = new Zonas();
        private Localidades oLocaldiades = new Localidades();
        private Usuarios_Locaciones oUsuLoc = new Usuarios_Locaciones();

        private int idCalle;

        public Boolean seModificoAlgo = false;
        public Int32 Id_Usuarios_Servicios, idLocacion, idCalleActual, alturaActual, idLocalidadActual, idZonaActual;
        public DateTime Fecha_Factura;
        public String Servicio, pisoActual, deptoActual, calleActual;

        private DataTable dtTipoFacturacion = new DataTable();
        private DataTable dtLocalidades = new DataTable();
        private DataTable dtLocaciones = new DataTable();

        public frmCambioFac()
        {
            InitializeComponent();
        }

        private void frmFechaFactura_Load(object sender, EventArgs e)
        {
            dtTipoFacturacion = oZonas.Listar();

            cboZona.DataSource = dtTipoFacturacion;
            cboZona.DisplayMember = "nombre";
            cboZona.ValueMember = "id";

            txtAlturaServicio.Text = alturaActual.ToString();
            txtPisoServicio.Text = pisoActual.ToString();
            txtDeptoServicio.Text = deptoActual.ToString();
            txtCalleServicio.Text = calleActual;

            cboZona.SelectedValue = idZonaActual;
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void frmFechaFactura_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.DialogResult = DialogResult.Cancel;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea confirmar el cambio de Zona?", "Mensaje del Sistema",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Usuarios_Servicios oUsuServicios = new Usuarios_Servicios();
                oUsuLoc.Id = this.idLocacion;
                oUsuLoc.Id_Localidades = Convert.ToInt32(cboLocalidades.SelectedValue);
                oUsuLoc.Altura = Convert.ToInt32(txtAlturaServicio.Text);
                oUsuLoc.Id_Calle = this.idCalle;
                oUsuLoc.Calle = txtCalleServicio.Text;
                oUsuLoc.Piso = txtPisoServicio.Text;
                oUsuLoc.Depto = txtDeptoServicio.Text;
                if (oUsuLoc.ActualizarDatosLocacion(oUsuLoc) == 0)
                {
                    MessageBox.Show("Datos de locacion actulizados correctamente", "Mensaje del Sistema");
                    this.seModificoAlgo = true;
                    if (oUsuServicios.ActualizarZona(this.Id_Usuarios_Servicios, Convert.ToInt32(cboZona.SelectedValue)) == 0)
                    {
                        MessageBox.Show("Zona del servicio actualizada correctamente", "Mensaje del Sistema");
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                        MessageBox.Show("Error al actualizar zona del servicio", "Mensaje del Sistema");
                }
                else
                    MessageBox.Show("Error al actualizar datos de locacion", "Mensaje del Sistema");
            }
        }

        private void cboZona_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                dtLocalidades = oZonas.ListarLocZonas(Convert.ToInt32(cboZona.SelectedValue));
                cboLocalidades.DataSource = dtLocalidades;
                cboLocalidades.DisplayMember = "localidad";
                cboLocalidades.ValueMember = "id_localidad";
            }
            catch (Exception)
            { }
        }

        private void BuscarCalle()
        {
            using (frmPopUp frmModal = new frmPopUp())
            {
                frmBusquedaCalles frm = new frmBusquedaCalles();
                frm.Id_Localidad = Convert.ToInt32(cboLocalidades.SelectedValue);
                List<Int32> listLocalidades = new List<Int32>
                    {
                        Convert.ToInt32(cboLocalidades.SelectedValue)
                    };

                frm.lista_id_localidades = listLocalidades;
                frmModal.Formulario = frm;

                if (frmModal.ShowDialog() == DialogResult.OK)
                {
                    txtCalleServicio.Text = frm.Calle;
                    txtCalleServicio.Tag = frm.Id_Calle.ToString();
                    this.idCalle = frm.Id_Calle;
                }
                else
                    txtCalleServicio.Text = "";
            }
        }

        private void btnBuscarCalle_Click(object sender, EventArgs e)
        {
            BuscarCalle();
        }

        private void cboLocalidades_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                int loc = Convert.ToInt32(cboLocalidades.SelectedValue);
                DataRow drDalosLoc;
                drDalosLoc = oLocaldiades.TraerDatosLocalidad(loc);
                string cp = drDalosLoc["codigo_postal"].ToString();
                txtCPServicio.Text = cp;

            }
            catch
            {
            }
        }
    }
}
