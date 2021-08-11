using CapaNegocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Partes_Trabajo
{
    public partial class frmPartes_Obs : Form
    {
        #region propiedades
        private Partes oPartes = new Partes();
        private Parte_Observacion oParteObservacion = new Parte_Observacion();
        private DataRow drParte;
        private DataTable dtObs = new DataTable();
        private DataTable dtObsGPS = new DataTable();
        private GPS oGps = new GPS();
        private Configuracion oConfig = new Configuracion();
        private Thread hilo;
        private delegate void myDel();
        public Int32 idParte;
        private bool parteNoTrabajaConAppExterna = false;
        #endregion
        #region METODOS
        private void comenzarCarga()
        {
            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.IsBackground = true;
            hilo.Start();
        }
        private void cargarDatos()
        {
            try
            {
                if (oConfig.GetValor_N("ParteTrabajaAppExterna") == 2)
                    parteNoTrabajaConAppExterna = true;
                dtObs = oParteObservacion.Listar(idParte);
                drParte = oPartes.TraerParteRow(idParte);
                if (oConfig.GetValor_N("ParteTrabajaAppExterna") == 1 && (!Debugger.IsAttached || Personal.Id_Login != 1))
                    dtObsGPS = oGps.ListarObservaciones(idParte);
                myDel MD = new myDel(asignarDatos);
                this.Invoke(MD, new object[] { });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Informacion" + ex.Message);
                throw;
            }
        }
        private void asignarDatos()
        {
            textboxObsGral.Text = drParte["detalle_falla"].ToString();
            txtObs.ReadOnly = true;
            if (parteNoTrabajaConAppExterna)
            {
                btnEnviar.Visible = false;
                btnCancelar.Location = btnEnviar.Location;
            }
            if(dtObsGPS != null && dtObsGPS.Rows.Count > 0)
            {
                dgvObsGPS.DataSource = dtObsGPS;

                dgvObsGPS.Columns["numord"].Visible = false;
                dgvObsGPS.Columns["cuando"].Width = 120;
                dgvObsGPS.Columns["area"].Width = 120;
                dgvObsGPS.Columns["nombre"].Width = 200;
                dgvObsGPS.Columns["observaciones"].Visible = false;
            }
            dgvObs.DataSource = dtObs;

            foreach (DataGridViewColumn item in dgvObs.Columns)
                item.Visible = false;

            dgvObs.Columns["observacion"].Visible = false;
            dgvObs.Columns["observacion"].HeaderText = "Observacion";

            dgvObs.Columns["id_parte"].Visible = true;
            dgvObs.Columns["id_parte"].HeaderText = "N° de parte";
            dgvObs.Columns["id_parte"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvObs.Columns["area"].Visible = true;
            dgvObs.Columns["area"].HeaderText = "Area";
            dgvObs.Columns["area"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvObs.Columns["personal"].Visible = true;
            dgvObs.Columns["personal"].HeaderText = "Personal";
            dgvObs.Columns["personal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvObs.Columns["fecha"].Visible = true;
            dgvObs.Columns["fecha"].HeaderText = "Fecha";
            dgvObs.Columns["fecha"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        #endregion


        public frmPartes_Obs()
        {
            InitializeComponent();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevaObs_Click(object sender, EventArgs e)
        {
            txtObs.Text = "";
            txtObs.ReadOnly = false;
            txtObs.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtObs.ReadOnly = true;
            txtObs.Text = "";

        }

        private void dgvObs_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                TextObsGies.Text = dgvObs.SelectedRows[0].Cells["observacion"].Value.ToString();
            }
            catch { }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!txtObs.Text.Trim().Equals(""))
            {
                oParteObservacion.Id = 0;
                oParteObservacion.IdParte = idParte;
                oParteObservacion.IdArea = Personal.Id_Area;
                oParteObservacion.IdPersonal = Personal.Id_Login;
                oParteObservacion.Fecha = DateTime.Now;
                oParteObservacion.Texto = txtObs.Text;
                if (oParteObservacion.Guardar(oParteObservacion) == 0)
                {
                    MessageBox.Show("Observacion guardada correctamente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (parteNoTrabajaConAppExterna == false)
                    {
                        if (oGps.GuardarObservacion(this.idParte, oParteObservacion) == 0)
                            MessageBox.Show("Observacion enviado a gps", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Error al guardar observacion en gps", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    comenzarCarga();
                }
                else
                    MessageBox.Show("Error al guardar observacion", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {

        }

        private void frmPartes_Obs_Load(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void dgvObsGPS_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                TextObsGPS.Text = dgvObsGPS.SelectedRows[0].Cells["observaciones"].Value.ToString();
            }
            catch { }
        }
    }
}
