using CapaNegocios;
using System;
using System.Data;

using System.Windows.Forms;

namespace CapaPresentacion.Abms
{
    public partial class ABMEquipos_Stock : Form
    {
        public DataTable dt = new DataTable();
        Equipos_Tipos oEquiposTipos = new Equipos_Tipos();
        Equipos_Marcas equipo_marcas = new Equipos_Marcas();
        Equipos_Modelos equipo_modelos = new Equipos_Modelos();
        Equipos oEquipo = new Equipos();

        private bool guardarDirecto;
        private int IdTipoEquipo, IdMarca, IdModelo, IdCantidadACargar;
        private int VerificarSerie, VerificarMac;
        private DialogResult Dialog;
        private string txtMacVacio;

        private bool ControlSerieYMac()
        {
            bool respuesta = true;
            if (VerificarSerie == 1 && dt.Select("Serie='" + txtSerie.Text.ToString() + "'").Length > 0)
            {
                MessageBox.Show("Ya hay una unidad con el número de serie o mac ingresado.");
                respuesta = false;
                txtSerie.Text = "";
                txtSerie.Focus();
            }

            if (VerificarMac == 1 && dt.Select("Mac='" + txtMac.Text.ToString() + "'").Length > 0)
            {
                MessageBox.Show("Ya hay una unidad con el número de mac ingresado.");
                respuesta = false;
                txtMac.Text = "";
                btnAgregarEquipo.Focus();
                txtMac.Focus();
            }
            return respuesta;
        }

        private bool ControlTxt()
        {
            if (VerificarSerie == 1 && String.IsNullOrEmpty(txtSerie.Text))
            {
                MessageBox.Show("Debe cargar Nro. de serie.");
                txtSerie.Focus();
                return false;
            }

            if (VerificarMac == 1 && String.IsNullOrEmpty(txtMac.Text))
            {
                MessageBox.Show("Debe cargar dirección MAC.");
                txtMac.Focus();
                return false;
            }
            return true;
        }

        private bool VerificacionSerieMac()
        {
            Equipos.VERIFICACION_SERIE_MAC Verificacion = oEquipo.VerificarEquipo(txtSerie.Text, txtMac.Text, 0, VerificarSerie, VerificarMac);
            if (Verificacion == Equipos.VERIFICACION_SERIE_MAC.SIN_REPETICION)
                return true;
            else if (Verificacion == Equipos.VERIFICACION_SERIE_MAC.SERIE_MAC_REPETIDOS)
            {
                MessageBox.Show("Los valores de Serie o Mac ya se encuentran asignados a otro equipo.");
                txtSerie.Focus();
                return false;
            }
            else if (Verificacion == Equipos.VERIFICACION_SERIE_MAC.SERIE_REPETIDO)
            {
                MessageBox.Show("El nro. de serie ya se encuentra asignado a otro equipo.");
                txtSerie.Text = "";
                txtSerie.Focus();
                return false;
            }
            else
            {
                MessageBox.Show("El nro. MAC ya se encuentra asignado a otro equipo.");
                txtMac.Text = "";
                btnAgregarEquipo.Focus();
                txtMac.Focus();
                return false;
            }
        }
        public ABMEquipos_Stock(int IdTipoEquipoRecibido, int IdMarcaRecibida, int IdModeloRecibido, int IdCantidadACargarRecibida, int VerificarSerieRecibida, int VerificarMacRecibida, bool guardarDirecto = true)
        {
            IdTipoEquipo = IdTipoEquipoRecibido;
            IdMarca = IdMarcaRecibida;
            IdModelo = IdModeloRecibido;
            IdCantidadACargar = IdCantidadACargarRecibida;
            VerificarSerie = VerificarSerieRecibida;
            VerificarMac = VerificarMacRecibida;
            dt.Columns.Add("Serie");
            dt.Columns.Add("Mac");
            this.guardarDirecto = guardarDirecto;
            InitializeComponent();
            estadoTabStopControles(false);
            txtMacVacio = txtMac.Text;
            dgvStock.RowsAdded += new DataGridViewRowsAddedEventHandler(verificarEquipoAgregado);
            dgvStock.RowsRemoved += new DataGridViewRowsRemovedEventHandler(verificarEquipoRemovido);
        }

        private void verificarEquipoAgregado(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (dgvStock.Rows.Count == IdCantidadACargar)
            {
                txtSerie.Enabled = false;
                txtMac.Enabled = false;
                btnAgregarEquipo.Enabled = false;
                estadoTabStopControles(true);
                btnGuardar.Focus();
            }
        }

        private void verificarEquipoRemovido(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            habilitarTextBox();
            btnAgregarEquipo.Enabled = true;
            estadoTabStopControles(false);
        }

        private void btnAgregarEquipo_Click(object sender, EventArgs e)
        {
            asignarSerieYMac();
        }

        private void asignarSerieYMac()
        {
            if (ControlTxt())
            {
                if (ControlSerieYMac())
                {
                    if (VerificacionSerieMac())
                    {
                        if (dgvStock.Rows.Count > IdCantidadACargar - 1)
                        {
                            estadoTabStopControles(true);
                            MessageBox.Show("No puede agregar mas equipos. Usted eligio agregar: " + IdCantidadACargar.ToString() + " Equipos", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            estadoTabStopControles(false);
                            dt.Rows.Add(txtSerie.Text, txtMac.Text);
                            dgvStock.DataSource = dt;
                            txtMac.Text = "";
                            txtSerie.Text = "";
                            txtSerie.Focus();
                        }
                    }
                }
            }
        }

        private void estadoTabStopControles(bool estado)
        {
            foreach (Control control in this.Controls)
            {
                if (control.Name != "txtSerie" || control.Name != "txtMac")
                {
                    control.TabStop = estado;
                }
            }
        }

        private void ABMEquiposStock_Load(object sender, EventArgs e)
        {
            habilitarTextBox();
        }

        private void habilitarTextBox()
        {
            if (VerificarSerie == 1 && VerificarMac == 1)
            {
                txtSerie.Enabled = true;
                txtMac.Enabled = true;
            }
            else if (VerificarSerie == 1 && VerificarMac == 0)
            {
                txtSerie.Enabled = true;
                txtMac.Enabled = false;
            }
            else if (VerificarSerie == 0 && VerificarMac == 1)
            {
                txtSerie.Enabled = false;
                txtMac.Enabled = true;
            }
        }

        private void txtSerie_TextChanged(object sender, EventArgs e)
        {
            if (txtSerie.Text.Length == 16 && !txtMac.Enabled)
            {
                if (ControlTxt())
                {
                    if (ControlSerieYMac())
                    {
                        if (VerificacionSerieMac())
                        {
                            dt.Rows.Add(txtSerie.Text, txtMac.Text);
                            dgvStock.DataSource = dt;
                            txtMac.Text = "";
                            txtSerie.Text = "";
                            txtSerie.Focus();
                        }
                    }
                }
            }
            else if (txtSerie.Text.Length == 16 && txtMac.Enabled)
            {
                txtMac.Focus();
            }
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtMac_TextChanged(object sender, EventArgs e)
        {
            if (txtMac.Text.Length > 16)
            {
                if (ControlTxt())
                {
                    if (ControlSerieYMac())
                    {
                        if (VerificacionSerieMac())
                        {
                            dt.Rows.Add(String.IsNullOrEmpty(txtSerie.Text) ? txtMac.Text : txtSerie.Text, txtMac.Text);
                            dgvStock.DataSource = dt;
                            txtMac.ResetText();
                            txtSerie.Text = "";

                            btnAgregarEquipo.Focus();
                            if (txtSerie.Enabled)
                                txtSerie.Focus();
                            else
                                txtMac.Focus();
                        }
                    }
                }
            }
        }

        private void txtMac_Enter(object sender, EventArgs e)
        {
            if (!txtSerie.Enabled)
            {
                this.BeginInvoke((MethodInvoker)delegate ()
                {
                    txtMac.Select(0, 0);
                });

            }
            else
            {
                if (!txtMac.Text.Equals(txtMacVacio))
                    txtSerie.Focus();
                else
                {
                    this.BeginInvoke((MethodInvoker)delegate ()
                    {
                        txtMac.Select(0, 0);
                    });
                }
            }
        }

        private void txtSerie_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtMac.Enabled)
                {
                    txtMac.Focus();
                }
                else
                {
                    asignarSerieYMac();
                    txtSerie.Focus();
                }
            }
        }

        private void btnQuitarEquipos_Click(object sender, EventArgs e)
        {
            if (dgvStock.SelectedRows.Count > 0)
                dgvStock.Rows.Remove(dgvStock.SelectedRows[0]);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (dgvStock.Rows.Count > 0)
            {

                if (dgvStock.Rows.Count > IdCantidadACargar)
                    MessageBox.Show("No puede agregar mas equipos. Usted eligio agregar: " + IdCantidadACargar.ToString() + " Equipos");

                else if (guardarDirecto)
                {
                    int control_carga = 0;
                    Dialog = DialogResult.Yes;
                    if (dgvStock.Rows.Count < IdCantidadACargar)
                        Dialog = MessageBox.Show(String.Format("Está a punto de ingresar una cantidad de equipos menor a la que solicitó. ¿Desea continuar?"), "", MessageBoxButtons.YesNo);
                    if (Dialog == DialogResult.Yes)
                    {
                        foreach (DataGridViewRow fila in dgvStock.Rows)
                        {
                            oEquipo.Id_Equipos_Tipos = IdTipoEquipo;
                            oEquipo.Id_Equipos_Marcas = IdMarca;
                            oEquipo.Id_Equipos_Modelos = IdModelo;
                            oEquipo.Id_Equipos_Estados = (Int32)Equipos.Equipos_Estados.DISPONIBLE_EN_STOCK;
                            oEquipo.Serie = fila.Cells["Serie"].Value.ToString();
                            oEquipo.Mac = fila.Cells["Mac"].Value.ToString();
                            oEquipo.Borrado = 0;
                            oEquipo.Guardar(oEquipo);
                            control_carga++;
                            this.DialogResult = DialogResult.OK;
                        }

                        if (control_carga == dgvStock.Rows.Count)
                        {
                            MessageBox.Show("Carga de equipos realizada con éxito.");
                        }
                        else
                        {
                            MessageBox.Show("Error en la carga de algunos equipos. Puede que algunos de ellos ya se encuentren cargados.");
                        }
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else
                {
                    Dialog = DialogResult.Yes;
                    if (dgvStock.Rows.Count < IdCantidadACargar)
                        Dialog = MessageBox.Show(String.Format("Está a punto de ingresar una cantidad de equipos menor a la que solicitó. ¿Desea continuar?"), "", MessageBoxButtons.YesNo);
                    if (Dialog == DialogResult.Yes)
                        this.DialogResult = DialogResult.OK;
                }
            }
            else
            {
                MessageBox.Show("No hay equipos para cargar.");
            }
        }

        private void ABMEquiposStock_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
