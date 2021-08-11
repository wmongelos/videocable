using CapaNegocios;
using CapaPresentacion.Partes_Trabajo;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Abms
{
    public partial class ABMUnidadesFuncionales : Form
    {
        private Int32 idUsuLoc, cantidad, cantidadCargada, resultado, idTipoFacturacion;
        private Usuarios_Locaciones_Uf oUsuariosLocUf = new Usuarios_Locaciones_Uf();
        private Usuarios_Servicios oUsuSer = new Usuarios_Servicios();
        private DataTable dtUf = new DataTable();
        private Thread hilo;
        private delegate void myDel();
        private DataTable dtDatosUsuSer;
        public Int32 idUsuario;

        public ABMUnidadesFuncionales()
        {
            InitializeComponent();
        }

        private void ComenzarCarga()
        {
            pgCircular.Start();
            dgvPresentacion.DataSource = null;
            hilo = new Thread(new ThreadStart(CargarDatos));
            hilo.Start();
        }

        private void CargarDatos()
        {
            dtDatosUsuSer = oUsuSer.Traer_datos_usuarios_servicios(Usuarios_Servicios.Current_IdUsuarioServicio);
            idUsuLoc = Convert.ToInt32(dtDatosUsuSer.Rows[0]["id_usuarios_locaciones"]);
            cantidad = Convert.ToInt32(dtDatosUsuSer.Rows[0]["cant_bocas"]);
            idTipoFacturacion = Convert.ToInt32(dtDatosUsuSer.Rows[0]["id_tipo_facturacion"]);
            dtUf = oUsuariosLocUf.Listar(idUsuLoc);
            if (dtUf.Rows.Count > 0)
            {
                dtUf = dtUf.AsEnumerable()
                       .OrderBy(r => r.Field<string>("piso"))
                       .ThenBy(r => r.Field<string>("depto"))
                       .CopyToDataTable();
            }
            myDel MD = new myDel(AsignarDatos);
            this.Invoke(MD, new object[] { });
            pgCircular.Stop();
        }

        private void AsignarDatos()
        {
            cantidadCargada = dtUf.Rows.Count;
            lblCantidad.Text = string.Format("Unidades Funcionales en total: {0}, cargadas: {1}", cantidad, cantidadCargada);
            spMain.Panel1Collapsed = true;
            dgvPresentacion.DataSource = dtUf;
            DataGridViewLinkColumn dgvColumnaLink = new DataGridViewLinkColumn();

            dgvColumnaLink.Name = "link";
            dgvColumnaLink.LinkColor = Color.Blue;
            dgvColumnaLink.VisitedLinkColor = Color.Blue;
            dgvColumnaLink.UseColumnTextForLinkValue = true;
            dgvColumnaLink.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvColumnaLink.DataPropertyName = "ContratarServicio";
            dgvColumnaLink.Text = "Contratar servicio";
            dgvColumnaLink.HeaderText = "";
            dgvPresentacion.Columns.Add(dgvColumnaLink);

            FormatearGrilla();
        }

        private void FormatearGrilla()
        {

            dgvPresentacion.Columns["Id_Usuarios_Locaciones_Uf"].Visible = false;
            dgvPresentacion.Columns["id"].Visible = false;
            dgvPresentacion.Columns["id_usuario"].Visible = false;

            dgvPresentacion.Columns["apellido"].HeaderText = "Apellido";
            dgvPresentacion.Columns["apellido"].DisplayIndex = 0;

            dgvPresentacion.Columns["nombre"].HeaderText = "Nombre";
            dgvPresentacion.Columns["nombre"].DisplayIndex = 1;

            dgvPresentacion.Columns["piso"].HeaderText = "Piso";
            dgvPresentacion.Columns["piso"].DisplayIndex = 2;

            dgvPresentacion.Columns["depto"].HeaderText = "Departamento";
            dgvPresentacion.Columns["depto"].DisplayIndex = 3;

            dgvPresentacion.Columns["descripcion"].HeaderText = "Descripcion";
            dgvPresentacion.Columns["descripcion"].DisplayIndex = 4;

            foreach (DataGridViewRow item in dgvPresentacion.Rows)
                item.Height = 33;
            dgvPresentacion.ColumnHeadersDefaultCellStyle.Font = txtApellido.Font;

        }

        private Boolean ValidarDatos()
        {
            if (txtApellido.Text.Trim().Equals(""))
            {
                MessageBox.Show("Ingrese un nombre de Apellido", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApellido.Focus();
                return false;
            }
            if ((txtPiso.Text.Trim().Equals("")) || (txtPiso.Text.Trim().Equals("0")))
            {
                MessageBox.Show("Ingrese el piso", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPiso.Focus();
                return false;
            }
            if ((txtDepto.Text.Trim().Equals("")) || (txtDepto.Text.Trim().Equals("0")))
            {
                MessageBox.Show("Ingrese el departamento", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDepto.Focus();
                return false;
            }


            foreach (DataRow item in dtUf.Rows)
            {
                string piso = item["piso"].ToString();
                string depto = item["depto"].ToString();
                if ((piso == txtPiso.Text.Trim()) && (depto == txtDepto.Text.Trim()))
                {
                    MessageBox.Show("Ya existe un departamento con el mismo nombre en el mismo piso", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            return true;
        }

        private void SeleccioanarRegistro()
        {
            oUsuariosLocUf.Id = Convert.ToInt32(dgvPresentacion.CurrentRow.Cells["id"].Value);
            oUsuariosLocUf.Piso = dgvPresentacion.CurrentRow.Cells["piso"].Value.ToString();
            oUsuariosLocUf.Depto = dgvPresentacion.CurrentRow.Cells["depto"].Value.ToString();

        }

        private Int32 Guardar()
        {
            oUsuariosLocUf.Id = 0;
            oUsuariosLocUf.Apellido = txtApellido.Text;
            oUsuariosLocUf.Nombre = txtNombre.Text;
            oUsuariosLocUf.Piso = txtPiso.Text;
            oUsuariosLocUf.Depto = txtDepto.Text;
            oUsuariosLocUf.Descripcion = txtDetalle.Text;
            oUsuariosLocUf.IdUsuario = 0;
            resultado = oUsuariosLocUf.Guardar(oUsuariosLocUf, idUsuLoc);
            if ((resultado == -1) || (resultado == -2))
                MessageBox.Show("Hubo un problema al guardar los datos", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                dtUf = oUsuariosLocUf.Listar(idUsuLoc);
                dtUf = dtUf.AsEnumerable()
                       .OrderBy(r => r.Field<string>("piso"))
                       .ThenBy(r => r.Field<string>("depto"))
                       .CopyToDataTable();
                dgvPresentacion.DataSource = null;
                dgvPresentacion.DataSource = dtUf;
                FormatearGrilla();
                cantidadCargada++;
                lblCantidad.Text = string.Format("Unidades Funcionales en total: {0}, cargadas: {1}", cantidad, cantidadCargada);

            }
            return resultado;
        }

        private void VaciarCampos()
        {
            txtApellido.Text = "";
            txtNombre.Text = "";
            txtPiso.Text = "0";
            txtDepto.Text = "0";
            txtDetalle.Text = "";
            txtApellido.Focus();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ABMUnidadesFuncionales_Load(object sender, EventArgs e)
        {
            ComenzarCarga();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (cantidadCargada < cantidad)
            {
                spMain.Panel1Collapsed = false;
                spMain.SplitterDistance = txtApellido.Width + 20;
                txtApellido.Focus();
            }
            else
                MessageBox.Show("Ya esta todas las unidades funcionales cargadas", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            spMain.Panel1Collapsed = true;
        }

        private void txtPiso_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsNumber(e.KeyChar)) && (e.KeyChar != Convert.ToChar(Keys.Back)) && (!char.IsLetter(e.KeyChar));
        }

        private void txtDepto_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsNumber(e.KeyChar)) && (e.KeyChar != Convert.ToChar(Keys.Back)) && (!char.IsLetter(e.KeyChar));

        }

        private void dgvPresentacion_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                SeleccioanarRegistro();
            }
            catch
            {
            }
        }

        private void btnContratar_Click(object sender, EventArgs e)
        {
            if (oUsuariosLocUf.Id > 0)
            {
                frmParteConexion frm = new frmParteConexion(1);
                frm.TipoOperacion = 1;
                frm.oUsuariosLocaconesUF = oUsuariosLocUf;
                frm.idLocacionEdificio = this.idUsuLoc;
                frmMain.Instance().openForm(frm);
            }
        }

        private void pnlInferior_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvPresentacion_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPresentacion.Columns[e.ColumnIndex].Name != "link")
            {
                try
                {
                    this.idUsuario = Convert.ToInt32(dgvPresentacion.CurrentRow.Cells["id_usuario"].Value);
                    this.DialogResult = DialogResult.OK;
                }
                catch { }
            }
        }

        private void dgvPresentacion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPresentacion.Columns[e.ColumnIndex].Name == "link")
            {
                frmParteConexion frm = new frmParteConexion(1);
                frm.TipoOperacion = 1;
                frm.oUsuariosLocaconesUF = oUsuariosLocUf;
                frm.idLocacionEdificio = this.idUsuLoc;
                frm.idTipoFacturacion = idTipoFacturacion;
                frm.usuarioNombre = dgvPresentacion.CurrentRow.Cells["nombre"].Value.ToString();
                frm.usuarioApellido = dgvPresentacion.CurrentRow.Cells["apellido"].Value.ToString();
                frm.vieneUnidadesFuncionales = Convert.ToInt32(dgvPresentacion.CurrentRow.Cells["id"].Value);
                frm.idUsuarioEdificio = Usuarios.CurrentUsuario.Id;
                frmMain.Instance().openForm(frm);
                this.Close();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ComenzarCarga();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (ValidarDatos())
            {
                Guardar();
                if (resultado > 0)
                {
                    VaciarCampos();
                }
                if (cantidad == cantidadCargada)
                {
                    spMain.Panel1Collapsed = true;
                }
            }


        }

        private void ABMUnidadesFuncionales_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
