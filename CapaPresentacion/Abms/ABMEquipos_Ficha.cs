using CapaNegocios;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;


namespace CapaPresentacion.Abms
{
    public partial class ABMEquipos_Ficha : Form
    {
        private int IdEquipo = 0;
        private Thread hilo;
        private delegate void myDel();
        private Equipos_Tipos oEquipoTipo = new Equipos_Tipos();
        private Equipos_Marcas oEquipoMarca = new Equipos_Marcas();
        private Equipos_Modelos oEquipoModelo = new Equipos_Modelos();
        private Equipos_Estados oEquipoEstados = new Equipos_Estados();
        private Equipos oEquipo = new Equipos();
        private DataTable DtEquiposTipos = new DataTable();
        private DataTable DtEquiposMarcas = new DataTable();
        private DataTable DtEquiposModelos = new DataTable();
        private DataTable DtEquiposEstados = new DataTable();
        private DataTable DtDatosEquipo = new DataTable();
        private DataRow DrTipoEquipo;
        private int VerificarSerie = 0;
        private int VerificarMac = 0;
        private DialogResult Dialog;

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
                DtEquiposTipos = oEquipoTipo.Listar();
                DtEquiposMarcas = oEquipoMarca.Listar();
                DtEquiposModelos = oEquipoModelo.Listar();
                DtEquiposEstados = oEquipoEstados.Listar();
                if (IdEquipo > 0)
                    DtDatosEquipo = oEquipo.BuscarDatosEquipo(IdEquipo);
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
            DataView dvTipos = new DataView(DtEquiposTipos);
            dvTipos.Sort = "Nombre asc";
            cboEquipos_Tipos.DataSource = dvTipos.ToTable();
            cboEquipos_Tipos.DisplayMember = "Nombre";
            cboEquipos_Tipos.ValueMember = "Id";

            DataView dvMarcas = new DataView(DtEquiposMarcas);
            dvTipos.Sort = "Nombre asc";
            cboEquipos_Marcas.DataSource = dvMarcas.ToTable();
            cboEquipos_Marcas.DisplayMember = "Nombre";
            cboEquipos_Marcas.ValueMember = "id";

            DataView dtvModelos = DtEquiposModelos.DefaultView;
            dtvModelos.RowFilter = String.Format("id_equipos_marcas={0}", DtEquiposMarcas.Rows[0]["id"]);
            dtvModelos.Sort = "Nombre asc";
            cboEquipos_Modelos.DataSource = dtvModelos.ToTable();
            cboEquipos_Modelos.DisplayMember = "Nombre";
            cboEquipos_Modelos.ValueMember = "Id";

            DataView dvEstados = new DataView(DtEquiposEstados);
            dvEstados.Sort = "Nombre asc";
            cboEquiposEstados.DataSource = dvEstados.ToTable();
            cboEquiposEstados.DisplayMember = "nombre";
            cboEquiposEstados.ValueMember = "id";
            if (IdEquipo == 0)
            {
                cboEquiposEstados.SelectedValue = Convert.ToInt32(Equipos.Equipos_Estados.DISPONIBLE_EN_STOCK);
                cboEquiposEstados.Enabled = false;
            }
            else
            {
                txtSerie.Text = DtDatosEquipo.Rows[0]["serie"].ToString();
                txtMac.Text = DtDatosEquipo.Rows[0]["mac"].ToString();
                cboEquiposEstados.SelectedValue = Convert.ToInt32(DtDatosEquipo.Rows[0]["id_equipos_estados"]);
                cboEquipos_Tipos.SelectedValue = Convert.ToInt32(DtDatosEquipo.Rows[0]["id_equipos_tipos"]);
                cboEquipos_Marcas.SelectedValue = Convert.ToInt32(DtDatosEquipo.Rows[0]["id_equipos_marcas"]);
                cboEquipos_Modelos.SelectedValue = Convert.ToInt32(DtDatosEquipo.Rows[0]["id_equipos_modelos"]);
                spinnerCant.Enabled = false;
            }

            DataRow[] drFilter = DtEquiposTipos.Select(String.Format("Id = {0}", cboEquipos_Tipos.SelectedValue));
            DrTipoEquipo = drFilter[0];
            if (Convert.ToInt32(DrTipoEquipo["Verificar_Serie"]) == 0)
                VerificarSerie = 0;
            else
                VerificarSerie = 1;
            if (Convert.ToInt32(DrTipoEquipo["Verificar_Mac"]) == 0)
                VerificarMac = 0;
            else
                VerificarMac = 1;

            ActualizarAdvertencia();
        }

        private void guardarRegistro()
        {
            if (VerificarSerie == 0 && VerificarMac == 0)
            {
                if (IdEquipo == 0)// si la operación es la carga de uno o más equipos
                {
                    Dialog = DialogResult.Yes;
                    if (spinnerCant.Value > 1)
                        Dialog = MessageBox.Show(String.Format("Está a punto de ingresar {0} equipos. ¿Desea continuar?", spinnerCant.Value), "", MessageBoxButtons.YesNo);

                    if (Dialog == DialogResult.Yes)
                    {
                        for (int x = 0; x < Convert.ToInt32(spinnerCant.Value); x++)
                        {
                            oEquipo.Id = 0;
                            oEquipo.Id_Equipos_Tipos = Convert.ToInt32(cboEquipos_Tipos.SelectedValue);
                            oEquipo.Id_Equipos_Marcas = Convert.ToInt32(cboEquipos_Marcas.SelectedValue);
                            oEquipo.Id_Equipos_Modelos = Convert.ToInt32(cboEquipos_Modelos.SelectedValue);
                            oEquipo.Id_Equipos_Estados = (Int32)Equipos.Equipos_Estados.DISPONIBLE_EN_STOCK;
                            oEquipo.Id_Usuarios = 0;
                            oEquipo.Id_Usuarios_servicios = 0;
                            oEquipo.Serie = txtSerie.Text;
                            oEquipo.Mac = txtMac.Text;
                            oEquipo.Guardar(oEquipo);
                        }
                    }
                }
                else
                {
                    oEquipo.Id = IdEquipo;
                    oEquipo.Id_Equipos_Tipos = Convert.ToInt32(cboEquipos_Tipos.SelectedValue);
                    oEquipo.Id_Equipos_Marcas = Convert.ToInt32(cboEquipos_Marcas.SelectedValue);
                    oEquipo.Id_Equipos_Modelos = Convert.ToInt32(cboEquipos_Modelos.SelectedValue);
                    oEquipo.Id_Equipos_Estados = Convert.ToInt32(cboEquiposEstados.SelectedValue);
                    if (oEquipo.Id_Equipos_Estados == Convert.ToInt32(Equipos.Equipos_Estados.DISPONIBLE_EN_STOCK))
                    {
                        oEquipo.Id_Usuarios = 0;
                        oEquipo.Id_Usuarios_servicios = 0;
                    }
                    oEquipo.Serie = txtSerie.Text;
                    oEquipo.Mac = txtMac.Text;
                    oEquipo.Guardar(oEquipo);
                }
                this.DialogResult = DialogResult.OK;
            }
            else if (VerificarSerie == 1 || VerificarMac == 1)
            {
                if (IdEquipo == 0 && spinnerCant.Value > 1)
                {
                    ABMEquipos_Stock frmStock = new ABMEquipos_Stock(Convert.ToInt32(cboEquipos_Tipos.SelectedValue), Convert.ToInt32(cboEquipos_Marcas.SelectedValue), Convert.ToInt32(cboEquipos_Modelos.SelectedValue), Convert.ToInt32(spinnerCant.Value), VerificarSerie, VerificarMac);
                    frmPopUp frmpopup = new frmPopUp();
                    frmpopup.Formulario = frmStock;
                    frmpopup.Maximizar = false;
                    frmpopup.ShowDialog();
                    if (frmpopup.DialogResult == DialogResult.OK)
                        this.DialogResult = DialogResult.OK;
                }
                else if (ControlTxtSerieYMac())
                {
                    if (VerificacionSerieMac())
                    {
                        if (IdEquipo == 0)
                        {
                            oEquipo.Id = 0;
                            oEquipo.Id_Equipos_Tipos = Convert.ToInt32(cboEquipos_Tipos.SelectedValue);
                            oEquipo.Id_Equipos_Marcas = Convert.ToInt32(cboEquipos_Marcas.SelectedValue);
                            oEquipo.Id_Equipos_Modelos = Convert.ToInt32(cboEquipos_Modelos.SelectedValue);
                            oEquipo.Id_Equipos_Estados = (Int32)Equipos.Equipos_Estados.DISPONIBLE_EN_STOCK;
                            oEquipo.Id_Usuarios = 0;
                            oEquipo.Id_Usuarios_servicios = 0;
                            oEquipo.Serie = txtSerie.Text;
                            oEquipo.Mac = txtMac.Text;
                            oEquipo.Guardar(oEquipo);
                            MessageBox.Show("Operación realizada correctamente.");
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            oEquipo.Id = IdEquipo;
                            oEquipo.Id_Equipos_Tipos = Convert.ToInt32(cboEquipos_Tipos.SelectedValue);
                            oEquipo.Id_Equipos_Marcas = Convert.ToInt32(cboEquipos_Marcas.SelectedValue);
                            oEquipo.Id_Equipos_Modelos = Convert.ToInt32(cboEquipos_Modelos.SelectedValue);
                            oEquipo.Id_Equipos_Estados = Convert.ToInt32(cboEquiposEstados.SelectedValue);

                            if (oEquipo.Id_Equipos_Estados == Convert.ToInt32(Equipos.Equipos_Estados.DISPONIBLE_EN_STOCK))
                            {
                                oEquipo.Id_Usuarios = 0;
                                oEquipo.Id_Usuarios_servicios = 0;
                            }
                            oEquipo.Serie = txtSerie.Text;
                            oEquipo.Mac = txtMac.Text;
                            oEquipo.Guardar(oEquipo);
                            MessageBox.Show("Operación realizada correctamente.");
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                }
            }
        }


        private bool ControlTxtSerieYMac()
        {
            if (VerificarSerie == 1 && txtSerie.Text.Length == 0)
            {
                MessageBox.Show("No ha cargado Nro. de serie.");
                txtSerie.Focus();
                return false;
            }

            if (VerificarMac == 1 && txtMac.Text.Length == 0)
            {
                MessageBox.Show("No ha cargado la dirección MAC.");
                txtMac.Focus();
                return false;
            }
            return true;
        }

        private bool VerificacionSerieMac()
        {
            Equipos.VERIFICACION_SERIE_MAC Verificacion = oEquipo.VerificarEquipo(txtSerie.Text, txtMac.Text, IdEquipo, VerificarSerie, VerificarMac);
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
                txtSerie.Focus();
                return false;
            }
            else
            {
                MessageBox.Show("El nro. MAC ya se encuentra asignado a otro equipo.");
                txtMac.Focus();
                return false;
            }
        }

        private void cancelarEdicion()
        {
            this.Close();
        }

        private void ActualizarAdvertencia()
        {
            if (VerificarSerie == 1 && VerificarMac == 1)
            {
                lblAdvertenciaTipoEquipo.Text = String.Format("*Se requiere verificación de Nro. de serie y Mac.");
                txtMac.Enabled = true;
                txtSerie.Enabled = true;
            }
            else if (VerificarSerie == 1 && VerificarMac == 0)
            {
                lblAdvertenciaTipoEquipo.Text = String.Format("*Se requiere verificación de Nro. de serie.");
                txtMac.Enabled = false;
                txtSerie.Enabled = true;
            }
            else if (VerificarSerie == 0 && VerificarMac == 1)
            {
                lblAdvertenciaTipoEquipo.Text = String.Format("*Se requiere verificación de Mac.");
                txtSerie.Enabled = false;
                txtMac.Enabled = true;
            }
            else
            {
                lblAdvertenciaTipoEquipo.Text = "*NO se requiere verificación de Nro. de serie o Mac.";
                txtMac.Enabled = false;
                txtSerie.Enabled = false;
            }
        }

        public ABMEquipos_Ficha(int IdEquipoRecibido)
        {
            IdEquipo = IdEquipoRecibido;
            InitializeComponent();
        }

        private void frmEquiposModal_Load(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            guardarRegistro();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cancelarEdicion();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEquiposModal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void cboEquipos_Marcas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataView dtvModelos = DtEquiposModelos.DefaultView;
                dtvModelos.RowFilter = String.Format("id_equipos_marcas={0}", cboEquipos_Marcas.SelectedValue);
                dtvModelos.Sort = "Nombre asc";
                cboEquipos_Modelos.DataSource = dtvModelos.ToTable();
                cboEquipos_Modelos.DisplayMember = "Nombre";
                cboEquipos_Modelos.ValueMember = "Id";
            }
            catch { }
        }

        private void cboEquipos_Tipos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                VerificarSerie = Convert.ToInt32(DtEquiposTipos.Select(String.Format("id={0}", cboEquipos_Tipos.SelectedValue))[0]["Verificar_Serie"]);
                VerificarMac = Convert.ToInt32(DtEquiposTipos.Select(String.Format("id={0}", cboEquipos_Tipos.SelectedValue))[0]["Verificar_Mac"]);
                ActualizarAdvertencia();
            }
            catch { }
        }
    }
}
