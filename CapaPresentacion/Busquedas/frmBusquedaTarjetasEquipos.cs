using CapaNegocios;
using CapaPresentacion.Abms;
using System;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Busquedas
{
    public partial class frmBusquedaTarjetasEquipos : Form
    {
        private Thread hilo;
        private delegate void myDel();
        private DataTable DtTarjetas = new DataTable();
        Equipos_Tarjetas oEquiposTarjetas = new Equipos_Tarjetas();
        private int IdEquiposTipos = 0;
        private int IdTarjetasEstados = 0;
        public int IdTarjeta = 0;
        public String NumeroTarjeta;
        public int id_usuario_actual = 0;

        Cass oCass;
        DataTable dtAplicacionesFiltradas = Tablas.DataCass;

        private void comenzarCarga()
        {
            pgCircular.Start();

            dgvTarjetas.DataSource = null;

            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
        }

        private void cargarDatos()
        {
            if (IdEquiposTipos == 0)
                DtTarjetas = oEquiposTarjetas.Listar();
            else
                DtTarjetas = oEquiposTarjetas.ListarPorTipoEquipoYEstado(IdTarjetasEstados, IdEquiposTipos);

            myDel MD = new myDel(asignarDatos);

            this.Invoke(MD, new object[] { });

            pgCircular.Stop();

        }

        private void asignarDatos()
        {
            //oCass = new Cass(Convert.ToInt32(dtAplicacionesFiltradas.Rows[0]["Id"]));

            dgvTarjetas.DataSource = DtTarjetas;

            //foreach (DataGridViewRow row in dgvTarjetas.Rows)
            //{
            //    string numeroTarjeta = row.Cells["numero"].Value.ToString();
            //    if(oCass.VerificarTarjetaExistenteAbonado(numeroTarjeta, id_usuario_actual))
            //    {
            //        row.DefaultCellStyle.BackColor = Color.Tomato;
            //    }
            //}

            for (int x = 0; x < dgvTarjetas.Columns.Count; x++)
                dgvTarjetas.Columns[x].Visible = false;

            dgvTarjetas.Columns["numero"].Visible = true;
            dgvTarjetas.Columns["equipotipo"].Visible = true;
            dgvTarjetas.Columns["serie"].Visible = true;
            dgvTarjetas.Columns["mac"].Visible = true;
            dgvTarjetas.Columns["usuario"].Visible = true;
            dgvTarjetas.Columns["servicio"].Visible = true;

            dgvTarjetas.Columns["numero"].HeaderText = "Número de tarjeta";
            dgvTarjetas.Columns["equipotipo"].HeaderText = "Tipo de equipo";
            dgvTarjetas.Columns["serie"].HeaderText = "Nro. de serie del equipo";
            dgvTarjetas.Columns["mac"].HeaderText = "Dirección Mac del equipo";
            dgvTarjetas.Columns["usuario"].HeaderText = "Usuario";
            dgvTarjetas.Columns["servicio"].HeaderText = "Servicio";
            dgvTarjetas.Columns["numero"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            lblTotal.Text = String.Format("Total de registros: {0}", dgvTarjetas.Rows.Count);
            AsignarValores();
        }

        private void AsignarValores()
        {
            if (dgvTarjetas.Rows.Count > 0)
            {
                try 
                { 
                    IdTarjeta = Convert.ToInt32(dgvTarjetas.SelectedRows[0].Cells["id"].Value);
                    lblNtarjeta.Text = String.Format("Nro. de tarjeta: {0}", dgvTarjetas.SelectedRows[0].Cells["numero"].Value.ToString());
                    this.NumeroTarjeta = dgvTarjetas.SelectedRows[0].Cells["numero"].Value.ToString();
                    lblTipoEquipo.Text = String.Format("Tipo de equipo al que pertenece: {0}", dgvTarjetas.SelectedRows[0].Cells["equipotipo"].Value.ToString());
                }
                catch
                {

                }
            }
        }

        public frmBusquedaTarjetasEquipos(int IdEquiposTiposRecibido, int IdTarjetasEstadosRecibido)
        {
            IdEquiposTipos = IdEquiposTiposRecibido;
            IdTarjetasEstados = IdTarjetasEstadosRecibido;
            InitializeComponent();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBusquedaTarjetasEquipos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void frmBusquedaTarjetasEquipos_Load(object sender, EventArgs e)
        {
            if (IdTarjetasEstados == Convert.ToInt32(Equipos_Tarjetas.Tarjetas_Estados.DISPONIBLE))
                lblTarjetas.Text = String.Format("Tarjetas disponibles: ");
            else if (IdTarjetasEstados == Convert.ToInt32(Equipos_Tarjetas.Tarjetas_Estados.CON_FALLA))
                lblTarjetas.Text = String.Format("Tarjetas con falla: ");
            else if (IdTarjetasEstados == Convert.ToInt32(Equipos_Tarjetas.Tarjetas_Estados.ENTREGADA))
                lblTarjetas.Text = String.Format("Tarjetas entregadas: ");
            else
                lblTarjetas.Text = String.Format("Tarjetas: ");
            comenzarCarga();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            oCass = new Cass(Convert.ToInt32(dtAplicacionesFiltradas.Rows[0]["Id"]));
            if (dgvTarjetas.SelectedRows.Count > 0)
            {
                if (this.NumeroTarjeta != "" && this.IdTarjeta > 0)
                {
                    if(id_usuario_actual > 0)
                    {
                        if (oCass.VerificarTarjetaExistenteAbonado(this.NumeroTarjeta.ToString(), id_usuario_actual))
                            MessageBox.Show("Tarjeta ya asignada en el cass, porfavor escoja otra.");
                        else
                        {
                            MessageBox.Show("Tarjeta asignada correctamente");
                            this.DialogResult = DialogResult.OK;
                        }

                    }
                    else { 
                        if (oCass.VerificarTarjetaExistente(this.NumeroTarjeta.ToString()))
                            MessageBox.Show("Tarjeta ya asignada en el cass, porfavor escoja otra.");
                        else 
                        { 
                            MessageBox.Show("Tarjeta asignada correctamente");
                            this.DialogResult = DialogResult.OK;
                        }
                     
                    }
                }
            }
            else
                MessageBox.Show("No se han seleccionado tarjetas.");
        }

        private bool EsUnNumero(string text)
        {
            foreach (char digito in text)
            {
                if (!Char.IsDigit(digito))
                    return false;
            }
            return true;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            int Id;
            if (txtBuscar.Text.Length == 0)
                DtTarjetas.DefaultView.RowFilter = "id>0";
            else
            {
                try
                {
                    DtTarjetas.DefaultView.RowFilter = String.Format("Convert([numero], System.String) LIKE '%{0}%'", txtBuscar.Text);
                }
                catch
                {
                    DtTarjetas.DefaultView.RowFilter = String.Format("Convert([numero], System.String) LIKE '%{0}%'", txtBuscar.Text);
                }
            }
        }

        private void btnAgregarTarjeta_Click(object sender, EventArgs e)
        {
            ABMEquipos_Tarjetas ABMTarjetas = new ABMEquipos_Tarjetas(IdEquiposTipos, IdTarjetasEstados);
            frmPopUp frmpopup = new frmPopUp();
            frmpopup.Maximizar = false;
            ABMTarjetas.vieneExterno = true;
            frmpopup.Formulario = ABMTarjetas;
            frmpopup.ShowDialog();
            if (ABMTarjetas.DialogResult == DialogResult.Cancel)
                comenzarCarga();
        }

        private void dgvTarjetas_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            AsignarValores();
        }

        private void dgvTarjetas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AsignarValores();
        }

        private void dgvTarjetas_SelectionChanged(object sender, EventArgs e)
        {
            AsignarValores();
        }
    }
}
