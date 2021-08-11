using CapaNegocios;
using System;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Busquedas
{
    public partial class frmBusquedaUsuarios : Form
    {
        private Usuarios oUsu = new Usuarios();
        public int ID;
        public int id_usuario;
        private DataTable dtusuarios;
        public DataRow usuario_e;
        public string nombre, apellido, codigo;

        private Int32 tipo, tipoUsuario;
        private String filtro;
        private Thread hilo;
        private bool setearCurrentUsuario;
        private delegate void myDel();
        private Configuracion oConfig = new Configuracion();

        private void ComenzarCarga()
        {
            MostrarCarga();
            hilo = new Thread(new ThreadStart(CargarDatos));
            hilo.IsBackground = true;
            hilo.Start();
        }

        private void CargarDatos()
        {
            dtusuarios = oUsu.Busqueda(filtro);
            myDel MD = new myDel(AsignarDatos);
            try
            {
                this.Invoke(MD, new object[] { });
            }
            catch { }
        }

        private void MostrarCarga()
        {
            foreach (Control item in this.Controls)
            {
                if (item.Name != "pnlTitulo")
                {
                    item.Enabled = false;
                }
            }
            pgCircular.Start();
            pgCircular.Location = new Point(this.Width / 2, this.Height / 2);
            pgCircular.Visible = true;
        }

        private void OcultarCarga()
        {
            foreach (Control item in this.Controls)
                item.Enabled = true;
            pgCircular.Stop();
            pgCircular.Visible = false;
        }

        private void AsignarDatos()
        {
            OcultarCarga();

            dgvResultado.DataSource = dtusuarios;

            dgvResultado.Columns["id_usuarios"].Visible = false;
            dgvResultado.Columns["id_localidades"].Visible = false;
            dgvResultado.Columns["id_locacion"].Visible = false;
            dgvResultado.Columns["id_usuarios_locaciones"].Visible = false;
            dgvResultado.Columns["id_locacion_fiscal_asociada"].Visible = false;
            dgvResultado.Columns["id"].Visible = false;
            dgvResultado.Columns["activo"].Visible = false;
            dgvResultado.Columns["Localidad"].Visible = false;
            dgvResultado.Columns["AbvLocalidad"].Visible = true;

            dgvResultado.Columns["codigo_usuario"].HeaderText = "Código usuario";
            dgvResultado.Columns["apellido"].HeaderText = "Apellido";
            dgvResultado.Columns["nombre"].HeaderText = "Nombre";
            dgvResultado.Columns["AbvLocalidad"].HeaderText = "Localidad";
            dgvResultado.Columns["calle"].HeaderText = "Calle";
            dgvResultado.Columns["altura"].HeaderText = "Altura";
            dgvResultado.Columns["piso"].HeaderText = "Piso";
            dgvResultado.Columns["depto"].HeaderText = "Depto";
            dgvResultado.Columns["localidad"].HeaderText = "Localidad";
            dgvResultado.Columns["entre_calle_1"].HeaderText = "Entre calle";
            dgvResultado.Columns["entre_calle_2"].HeaderText = "Y calle";
            dgvResultado.Columns["saldo"].HeaderText = "Saldo";


            dgvResultado.Columns["codigo_usuario"].Width = 70;
            dgvResultado.Columns["apellido"].Width = 200;
            dgvResultado.Columns["nombre"].Width = 200;
            dgvResultado.Columns["localidad"].Width = 200;
            dgvResultado.Columns["saldo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvResultado.Columns["calle"].Width = 150;
            dgvResultado.Columns["Nombre"].Width = 250;


            lblTotal.Text = String.Format("Total de Registros: {0}", dgvResultado.Rows.Count);
        }

        /// <summary>
        /// ///////
        /// </summary>
        /// <param name="opcion">0 nada  1 nro usua  2 nombre 3 direccion+altura 4 dni 5 todos</param>
        /// <param name="texto1">primer texto apellido por ej</param>
        /// <param name="texto2">segundo txto nombre o altura en calle</param>
        public frmBusquedaUsuarios(Int32 opcion, string texto1_v, string texto2_v, bool setearCurrentUsuario = true)
        {
            InitializeComponent();

            this.setearCurrentUsuario = setearCurrentUsuario;
            chkUsuario.CheckedChanged += new EventHandler(checkChangue);
            chkNombre.CheckedChanged += new EventHandler(checkChangue);
            chkDomicilio.CheckedChanged += new EventHandler(checkChangue);
            chkDocumento.CheckedChanged += new EventHandler(checkChangue);
            chkGeneral.CheckedChanged += new EventHandler(checkChangue);

            if (rbAbonado.Checked)
                tipoUsuario = (int)Usuarios.Usuarios_Tipos.ABONADO;
            if (rbCliente.Checked)
                tipoUsuario = (int)Usuarios.Usuarios_Tipos.CLIENTE;
            if (rbProspecto.Checked)
                tipoUsuario = (int)Usuarios.Usuarios_Tipos.PROSPECTO;


            switch (opcion)
            {
                case 1:
                    chkUsuario.Checked = true;
                    break;
                case 2:
                    chkNombre.Checked = true;
                    break;
                case 3:
                    txtCalle.Text = texto1_v;
                    txtAltura.Text = texto2_v;
                    chkDomicilio.Checked = true;
                    break;
                case 4:
                    chkDocumento.Checked = true;
                    break;
                default:
                    break;
            }
            //chkDomicilio.Checked = true;


            txtBuscar.Text = String.Format("{0} {1}", texto1_v, texto2_v);
            this.tipo = opcion;

            //if (txtBuscar.Text.Trim().Length != 0)
            //    setearFiltro();
        }


        private void checkChangue(object sender, EventArgs e)
        {
            RadioButton radio = (RadioButton)sender;

            txtBuscar.Text = "";

            switch (radio.Name)
            {
                case "chkUsuario":
                    txtBuscar.Numerico = true;
                    this.tipo = 1;
                    break;
                case "chkNombre":
                    txtBuscar.Numerico = false;
                    this.tipo = 2;
                    break;
                case "chkDomicilio":
                    txtBuscar.Numerico = false;
                    this.tipo = 3;
                    AccionRadioButtonDomicilio();
                    break;
                case "chkDocumento":
                    txtBuscar.Numerico = true;
                    this.tipo = 4;
                    break;
                case "chkGeneral":
                    txtBuscar.Numerico = false;
                    this.tipo = 5;
                    break;
            }

            txtBuscar.Focus();
        }

        private void setearFiltro()
        {
            switch (this.tipo)
            {
                case 1:
                    txtBuscar.Text = txtBuscar.Text.Replace(" ", "");
                    filtro = String.Format("usuarios.codigo = {0} and usuarios.id_usuarios_tipos={1} ", txtBuscar.Text.Replace(" ", ""), tipoUsuario);
                    break;
                case 2:
                    string texto = txtBuscar.Text.Trim();
                    string texto1;
                    string texto2;
                    string texto3;
                    texto1 = texto;
                    texto2 = texto;
                    texto3 = texto;

                    if (texto.IndexOf(" ") > 0)
                    {
                        Int32 lugar = texto.IndexOf(" ");
                        texto1 = texto.Substring(0, lugar).Trim();
                        texto2 = texto.Substring(lugar, texto.Length - texto1.Length).Trim();
                        texto3 = texto2;
                        if (texto2.IndexOf(" ") > 0)
                        {
                            texto = texto2;
                            Int32 lugar1 = texto.IndexOf(" ");
                            texto2 = texto.Substring(0, lugar1).Trim();
                            texto3 = texto.Substring(lugar1, texto.Length - texto2.Length).Trim();
                        }

                    }
                    try
                    {
                        if (oConfig.GetValor_N("BusquedaUsuarioExactitud") == 2)
                            filtro = String.Format("(usuarios.apellido Like '" + texto1 + "%' or usuarios.apellido Like '" + texto2 + "%') and usuarios.id_usuarios_tipos=" + tipoUsuario + " ORDER BY usuarios.Apellido, usuarios.Nombre");
                        else
                            filtro = String.Format("(usuarios.apellido Like '%" + texto1 + "%' or usuarios.nombre Like '%" + texto1 + "%') and (usuarios.apellido Like '%" + texto2 + "%' or usuarios.nombre Like '%" + texto2 + "%') and (usuarios.apellido Like '%" + texto2 + "%' or usuarios.nombre Like '%" + texto3 + "%') and usuarios.id_usuarios_tipos=" + tipoUsuario + " ORDER BY usuarios.Apellido, usuarios.Nombre");
                    }
                    catch
                    {
                        filtro = String.Format("(usuarios.apellido Like '%" + texto1 + "%' or usuarios.nombre Like '%" + texto1 + "%') and (usuarios.apellido Like '%" + texto2 + "%' or usuarios.nombre Like '%" + texto2 + "%') and (usuarios.apellido Like '%" + texto2 + "%' or usuarios.nombre Like '%" + texto3 + "%') and usuarios.id_usuarios_tipos=" + tipoUsuario + " ORDER BY usuarios.Apellido, usuarios.Nombre");
                    }

                    break;
                case 3:
                    int numero;
                    if (txtAltura.Text.Trim().Equals(string.Empty))
                    {
                        if (int.TryParse(txtCalle.Text, out numero))
                            filtro = String.Format("usuarios_locaciones.Calle = '{0}' and usuarios.id_usuarios_tipos={1} ORDER BY usuarios_locaciones.Calle, usuarios_locaciones.Altura", txtCalle.Text, tipoUsuario);
                        else
                            filtro = String.Format("usuarios_locaciones.Calle LIKE '%{0}%' and usuarios.id_usuarios_tipos={1} ORDER BY usuarios_locaciones.Calle, usuarios_locaciones.Altura", txtCalle.Text, tipoUsuario);
                    }
                    else
                    {
                        if (int.TryParse(txtCalle.Text, out numero) && int.TryParse(txtAltura.Text, out numero))
                            filtro = String.Format("usuarios_locaciones.Calle = '{0}' and usuarios_locaciones.Altura>={1}  and usuarios.id_usuarios_tipos={2} ORDER BY usuarios_locaciones.Calle, usuarios_locaciones.Altura", txtCalle.Text, txtAltura.Text, tipoUsuario);
                        else if (int.TryParse(txtCalle.Text, out numero) == false && int.TryParse(txtAltura.Text, out numero))
                            filtro = String.Format("usuarios_locaciones.Calle LIKE '%{0}%' AND usuarios_locaciones.Altura >={1} and usuarios.id_usuarios_tipos={2} ORDER BY usuarios_locaciones.Calle, usuarios_locaciones.Altura", txtCalle.Text, txtAltura.Text, tipoUsuario);
                    }
                    break;
                case 4:
                    filtro = String.Format("(usuarios.numero_documento = {0} or usuarios.cuit = {0}) and usuarios.id_usuarios_tipos={1}", txtBuscar.Text, tipoUsuario);
                    break;
                case 5:
                    int numSalida;
                    if (int.TryParse(txtBuscar.Text, out numSalida))
                        filtro = String.Format("usuarios.codigo = {0} or usuarios_locaciones.altura = {0} and usuarios.id_usuarios_tipos = {1}", numSalida, tipoUsuario);
                    else
                        filtro = String.Format("usuarios.apellido Like '%{0}%' or usuarios.nombre Like '%{0}%' or usuarios_locaciones.calle Like '%{0}%' and usuarios.id_usuarios_tipos = {1}", txtBuscar.Text, tipoUsuario);
                    break;
                default:
                    break;
            }
            this.ComenzarCarga();
        }

        private void Confirmar()
        {
            try
            {
                id_usuario = Convert.ToInt32(dgvResultado.SelectedRows[0].Cells["Id_Usuarios"].Value);
                DataRow[] drFilter = dtusuarios.Select(String.Format("Id_Usuarios = {0} and id_locacion={1}", Convert.ToInt32(dgvResultado.SelectedRows[0].Cells["Id_Usuarios"].Value), Convert.ToInt32(dgvResultado.SelectedRows[0].Cells["id_locacion"].Value)));
                usuario_e = drFilter[0];

                if (setearCurrentUsuario)
                {
                    Usuarios.CurrentUsuario.Id_Usuarios_Locacion = Convert.ToInt32(dgvResultado.SelectedRows[0].Cells["Id_Locacion"].Value);
                    Usuarios.CurrentUsuario.Id_Localidad = Convert.ToInt32(dgvResultado.SelectedRows[0].Cells["Id_Localidades"].Value);
                    Usuarios.Current_IdUsuarioLocacionFiscal = Convert.ToInt32(dgvResultado.SelectedRows[0].Cells["id_locacion_fiscal_asociada"].Value);
                    oUsu.LlenarObjeto(Convert.ToInt32(dgvResultado.SelectedRows[0].Cells["Id_Usuarios"].Value));
                }
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar datos." + ex.Message);
            }
        }

        private void AccionRadioButtonDomicilio()
        {
            if (chkDomicilio.Checked)
            {
                lblBuscador.Visible = false;
                txtBuscar.Visible = false;
                lblCalle.Location = lblBuscador.Location;
                txtCalle.Location = new Point(lblCalle.Size.Width + 10, txtBuscar.Location.Y);
                lblAltura.Location = new Point(txtCalle.Location.X + txtCalle.Size.Width + 5, lblBuscador.Location.Y);
                txtAltura.Location = new Point(lblAltura.Location.X + lblAltura.Size.Width + 5, txtBuscar.Location.Y);

                lblCalle.Visible = true;
                txtCalle.Visible = true;
                lblAltura.Visible = true;
                txtAltura.Visible = true;

                txtCalle.Focus();
            }
            else
            {
                lblCalle.Visible = false;
                txtCalle.Visible = false;
                lblAltura.Visible = false;
                txtAltura.Visible = false;
                lblBuscador.Visible = true;
                txtBuscar.Visible = true;
            }
        }

        private void txtAltura_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtCalle.Text.Trim().Length == 0)
                {
                    txtCalle.Focus();
                    return;
                }
                setearFiltro();
            }
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtBuscar.Text.Trim().Length != 0)
                setearFiltro();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBuscar.Text.Trim().Length != 0 ||
                txtCalle.Text.Trim().Length != 0)
                setearFiltro();
        }

        private void frmBusquedaAbonados_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.DialogResult = DialogResult.Cancel;
            if ((e.KeyCode == Keys.Enter) && (dgvResultado.SelectedRows.Count > 0) && (txtBuscar.Focused == false)
                && (txtCalle.Focused == false) && (txtAltura.Focused == false))
            {
                if (dgvResultado.SelectedRows.Count > 0)
                    Confirmar();
            }
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnConfirma_Click(object sender, EventArgs e)
        {
            if (dgvResultado.SelectedRows.Count > 0)
                Confirmar();
            else
                MessageBox.Show("Se debe seleccionar un usuarios para poder confirmar", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void rbAbonado_CheckedChanged(object sender, EventArgs e)
        {
            tipoUsuario = (int)Usuarios.Usuarios_Tipos.ABONADO;
        }

        private void rbProspecto_CheckedChanged(object sender, EventArgs e)
        {
            tipoUsuario = (int)Usuarios.Usuarios_Tipos.PROSPECTO;
        }

        private void rbCliente_CheckedChanged(object sender, EventArgs e)
        {
            tipoUsuario = (int)Usuarios.Usuarios_Tipos.CLIENTE;
        }

        private void dgvResultado_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dgvResultado.Columns["CABLE"].Index)
            {
                dgvResultado.Rows[e.RowIndex].Cells["CABLE"].Style.BackColor = (Convert.ToInt32(dgvResultado.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) > 0) ? Color.Green : Color.White;
                dgvResultado.Rows[e.RowIndex].Cells["CABLE"].Style.ForeColor = (Convert.ToInt32(dgvResultado.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) > 0) ? Color.Green : Color.White;
            }
            if (e.ColumnIndex == dgvResultado.Columns["INTERNET"].Index)
            {
                dgvResultado.Rows[e.RowIndex].Cells["INTERNET"].Style.BackColor = (Convert.ToInt32(dgvResultado.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) > 0) ? Color.Green : Color.White;
                dgvResultado.Rows[e.RowIndex].Cells["INTERNET"].Style.ForeColor = (Convert.ToInt32(dgvResultado.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) > 0) ? Color.Green : Color.White;
            }
        }

        private void frmBusquedaUsuarios_Shown(object sender, EventArgs e)
        {
            if (chkDomicilio.Checked && txtCalle.Text.Trim().Length == 0)
            {
                txtCalle.Focus();
            }
            else if (txtBuscar.Text.Trim().Length == 0)
            {
                txtBuscar.Focus();
            }
        }

        private void dgvResultado_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                this.codigo = dgvResultado.SelectedRows[0].Cells["codigo_usuario"].Value.ToString();
                this.nombre = dgvResultado.SelectedRows[0].Cells["nombre"].Value.ToString();
                this.apellido = dgvResultado.SelectedRows[0].Cells["apellido"].Value.ToString();
                lblLocalidad.Text = dgvResultado.SelectedRows[0].Cells["localidad"].Value.ToString();

            }
            catch { }
        }

        private void dgvResultado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Confirmar();
        }

        private void frmBusquedaUsuarios_Load(object sender, EventArgs e)
        {
            pgCircular.Location = new Point(this.Width / 2, this.Height / 2);
            if (txtBuscar.Text.Trim().Length != 0)
                setearFiltro();
        }

    }
}
