using CapaNegocios;
using CapaPresentacion.Abms;
using CapaPresentacion.Busquedas;
using CapaPresentacion.Impresiones;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;


namespace CapaPresentacion
{
    public partial class ABMPlasticos : Form
    {
        private Thread hilo;
        private delegate void myDel();
        private DataTable DtPlasticos = new DataTable();
        private DataTable DtFormasPago;
        private Formas_de_pago oFormaPago = new Formas_de_pago();
        private Plasticos oPlasticos = new Plasticos();
        private Plasticos_Usuarios oPlasticosUsuarios = new Plasticos_Usuarios();
        private Tools oTools = new Tools();
        int id = 0;
        DataGridViewLinkColumn colVerServicios = new DataGridViewLinkColumn();
        int numero_fila;

        private void comenzarCarga()
        {
            btnBuscar.Enabled = false;
            pgCircular.Visible = true;
            pgCircular.Start();
            dgv.DataSource = null;
            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
        }

        private void cargarDatos()
        {
            try
            {
                DtFormasPago = oFormaPago.ListarFormasDePagoConPresentacion();
                DtPlasticos = oPlasticos.Listar("0", 0);
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
            dgv.DataSource = DtPlasticos;
            dgv.Columns["Id"].Visible = false;
            dgv.Columns["formapago"].Visible = false;
            dgv.Columns["activo"].Visible = false;
            dgv.Columns["borrado"].Visible = false;
            dgv.Columns["id_forma_de_pago"].Visible = false;
            dgv.Columns["titular"].HeaderText = "Titular";
            dgv.Columns["numero"].HeaderText = "Numero";
            dgv.Columns["activoTexto"].HeaderText = "Estado";
            dgv.Columns["vencimiento"].HeaderText = "Vencimiento";
            AgregarLinkColumn();
            dgv.Columns["numero"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["vencimiento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["activoTexto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["vencimiento"].Width = 90;
            dgv.Columns["activoTexto"].Width = 70;
            dgv.Columns["ColVerServicios"].Width = 70;
            dgv.Columns["numero"].Width = 200;
            dgv.Columns["titular"].Width = 700;

            cbTarjeta.DataSource = DtFormasPago;
            cbTarjeta.DisplayMember = "Nombre";
            cbTarjeta.ValueMember = "Id";
            lblTotal.Text = String.Format("Total de Registros: {0}", DtPlasticos.Rows.Count);
            controles(false);
            asignarValores();
            pgCircular.Visible = false;
            btnBuscar.Enabled = true;
        }

        private void controles(bool state)
        {
            btnActualizar.Enabled = !state;
            btnNuevo.Enabled = !state;
            btnEditar.Enabled = !state;
            dgv.Enabled = !state;
            txtNumero.Enabled = state;
            txtTitular.Enabled = state;
            dtpFechaVencimiento.Enabled = state;
            checkActiva.Enabled = state;
            btnGuardar.Enabled = state;
            btnCancelar.Enabled = state;
            cbTarjeta.Enabled = state;
        }

        private void AgregarLinkColumn()
        {
            int IndexColumn = -1;
            DataGridViewLinkColumn ColVerServicios = new DataGridViewLinkColumn();
            ColVerServicios.Name = "ColVerServicios";
            ColVerServicios.HeaderText = "Servicios";
            ColVerServicios.Text = "Ver";
            ColVerServicios.Width = 50;
            ColVerServicios.UseColumnTextForLinkValue = true;
            ColVerServicios.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            foreach (DataGridViewColumn columna in dgv.Columns)
            {
                if (columna.Name == "ColVerServicios")
                    IndexColumn = columna.Index;
            }
            if (IndexColumn >= 0)
                dgv.Columns.RemoveAt(IndexColumn);
            dgv.Columns.Add(ColVerServicios);
        }

        private void asignarValores()
        {
            try
            {
                if (dgv.Rows.Count > 0)
                {
                    if (dgv.SelectedRows.Count > 0)
                    {
                        if (dgv.SelectedRows[0].Cells["activo"].Value.ToString() == "1")
                            checkActiva.Checked = true;
                        else
                            checkActiva.Checked = false;
                        id = Convert.ToInt32(dgv.SelectedRows[0].Cells["id"].Value);
                        txtTitular.Text = dgv.SelectedRows[0].Cells["titular"].Value.ToString();
                        txtNumero.Text = dgv.SelectedRows[0].Cells["numero"].Value.ToString();
                        txtNumero.Tag = dgv.SelectedRows[0].Cells["numero"].Value.ToString();
                        dtpFechaVencimiento.Value = Convert.ToDateTime(dgv.SelectedRows[0].Cells["vencimiento"].Value.ToString());
                        cbTarjeta.SelectedValue = dgv.SelectedRows[0].Cells["id_forma_de_pago"].Value.ToString();
                    }
                    else
                    {
                        if (dgv.Rows[0].Cells["activo"].Value.ToString() == "1")
                            checkActiva.Checked = true;
                        else
                            checkActiva.Checked = false;
                        id = Convert.ToInt32(dgv.Rows[0].Cells["id"].Value);
                        txtTitular.Text = dgv.Rows[0].Cells["titular"].Value.ToString();
                        txtNumero.Text = dgv.Rows[0].Cells["numero"].Value.ToString();
                        txtNumero.Tag = dgv.Rows[0].Cells["numero"].Value.ToString();
                        dtpFechaVencimiento.Value = Convert.ToDateTime(dgv.Rows[0].Cells["vencimiento"].Value.ToString());
                        cbTarjeta.SelectedValue = dgv.Rows[0].Cells["id_forma_de_pago"].Value.ToString();
                    }
                }
            }
            catch
            {

            }
        }

        private void editarRegistro()
        {
            txtTitular.Enabled = true;
            txtNumero.Enabled = true;
            txtTitular.Focus();
        }

        private void eliminarRegistro()
        {
            if (MessageBox.Show("¿Desea eliminar el Registro Seleccionado?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                oPlasticos.Eliminar(Convert.ToInt32(dgv.SelectedRows[0].Cells["id"].Value));

                comenzarCarga();
            }
        }

        private void guardarRegistro()
        {
            if (txtNumero.Text.Length == 0)
                txtNumero.Focus();
            else if (txtTitular.Text.Length == 0)
                txtTitular.Focus();
            else
            {

                if (validarDatos())
                {
                    oPlasticos.Id = id;
                    oPlasticos.Titular = txtTitular.Text.ToUpper();
                    oPlasticos.Numero = txtNumero.Text.ToUpper();

                    if (checkActiva.Checked)
                        oPlasticos.Activo = 1;
                    else
                        oPlasticos.Activo = 0;

                    oPlasticos.Id_Forma_de_Pago = Convert.ToInt32(cbTarjeta.SelectedValue);

                    try
                    {
                        oPlasticos.Vencimiento = dtpFechaVencimiento.Value;
                        oPlasticos.Guardar(oPlasticos);
                        comenzarCarga();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("El formato de la fecha no es correcto o no se ha asignado.");
                        dtpFechaVencimiento.Focus();
                    }
                }
            }
        }

        private void cancelarEdicion()
        {
            controles(false);
            limpiarValores();
        }

        private bool validarDatos()
        {
            if ((txtNumero.Tag != null && txtNumero.Tag.ToString() != txtNumero.Text && txtNumero.Text.Length > 0) || (txtNumero.Tag == null && txtNumero.Text.Length > 0))
            {
                if (DtPlasticos.Rows.Count > 0)
                {
                    DataRow[] dr = DtPlasticos.Select(String.Format("Numero = '{0}'", txtNumero.Text.ToUpper()));

                    if (dr.Count() > 0)
                    {
                        MessageBox.Show("El Valor ingresado ya Existe", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtNumero.Focus();
                        return false;
                    }
                }
                else
                {
                    DataTable dtConsulta = oPlasticos.Listar(txtNumero.Text, 0);
                    if (dtConsulta.Rows.Count > 0)
                    {
                        MessageBox.Show("El Valor ingresado ya Existe", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtNumero.Focus();
                        return false;
                    }
                }
            }

            return true;
        }

        private void limpiarValores()
        {
            txtTitular.Text = "";
            txtNumero.Text = "";
            dtpFechaVencimiento.Value = DateTime.Now;
            id = 0;
            txtNumero.Tag = "";
        }

        private void filtrarDatos()
        {
            DtPlasticos.DefaultView.RowFilter = string.Format("Numero LIKE '%{0}%' OR Convert([Vencimiento], System.String) LIKE '%{0}%' OR Titular LIKE '%{0}%' OR activoTexto LIKE '%{0}%'", txtPlastico.Text);
        }

        private void filtrarEstado()
        {
            int id_activo;
            if (rbActivo.Checked == true)
                id_activo = 1;
            else
                id_activo = 0;

            DtPlasticos.DefaultView.RowFilter = string.Format(" Convert([activo], System.String) LIKE '%{0}%'", id_activo);
        }

        public ABMPlasticos()
        {
            InitializeComponent();
        }

        private void ABMPlasticos_Load(object sender, EventArgs e)
        {
            colVerServicios.Name = "colVerServicios";
            colVerServicios.HeaderText = "Servicios";
            colVerServicios.Text = "Ver";
            colVerServicios.UseColumnTextForLinkValue = true;
            pgCircular.Location = new Point(
                        this.ClientSize.Width / 2 - pgCircular.Size.Width / 2,
                        this.ClientSize.Height / 2 - pgCircular.Size.Height / 2);
            pgCircular.Anchor = AnchorStyles.None;
            DtFormasPago = oFormaPago.ListarFormasDePagoConPresentacion();
            cbTarjeta.DataSource = DtFormasPago;
            cbTarjeta.DisplayMember = "Nombre";
            cbTarjeta.ValueMember = "Id";
            comenzarCarga();
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
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 0)
            {
                controles(true);
                editarRegistro();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 0)
            {
                eliminarRegistro();

                if (dgv.Rows.Count == 0)
                    limpiarValores();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            guardarRegistro();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cancelarEdicion();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmPopUp oFrmPopup = new frmPopUp();
            Impuestos.frmDebitos oFrmDebitos = new Impuestos.frmDebitos();
            oFrmPopup.Formulario = oFrmDebitos;
            oFrmDebitos.buscar = 1;
            if (oFrmPopup.ShowDialog() == DialogResult.OK)
            {
                numero_fila = 0;
                foreach (DataGridViewRow item in dgv.Rows)
                {
                    if (Convert.ToInt32(item.Cells["id"].Value) == oFrmDebitos.oPlasticos.Id)
                    {
                        numero_fila = item.Index;
                    }

                }
                dgv.Rows[numero_fila].Selected = true;
                asignarValores();
            }
        }

        private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            asignarValores();
        }

        private void ABMTipoComprobantes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            filtrarDatos();
        }


        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.Columns[e.ColumnIndex].Name.Equals("ColVerServicios"))
            {
                DataGridViewRow dgvrow;
                if (dgv.SelectedRows.Count > 0)
                    dgvrow = dgv.SelectedRows[0];
                else
                    dgvrow = dgv.Rows[0];
                ABMPlasticos_Usuarios ABMPlasticosUsuario = new ABMPlasticos_Usuarios(Convert.ToInt32(dgvrow.Cells["id"].Value), dgvrow.Cells["numero"].Value.ToString(), dgvrow.Cells["titular"].Value.ToString());
                frmPopUp frmpopup = new frmPopUp();
                frmpopup.Maximizar = false;
                frmpopup.Formulario = ABMPlasticosUsuario;
                frmpopup.ShowDialog();
            }
        }

        private void btnContrato_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea Imprimir el Contrato?", "Mensaje del Sistema",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                Impresion oImpresion = new Impresion();

                Int32 IdTarjeta = Convert.ToInt32(dgv.SelectedRows[0].Cells["id"].Value.ToString());
                String Titular = dgv.SelectedRows[0].Cells["titular"].Value.ToString();
                String TarjetaNro = dgv.SelectedRows[0].Cells["numero"].Value.ToString();
                String TarjetaVto = dgv.SelectedRows[0].Cells["vencimiento"].Value.ToString();

                Plasticos_Usuarios oPlasticosUsuarios = new Plasticos_Usuarios();
                DataTable dt = oPlasticosUsuarios.Listar(IdTarjeta, 0);

                object min = dt.Compute("MIN(Fecha_inicio)", string.Empty);

                String Inicio = Convert.ToDateTime(min).ToShortDateString();
                String Servicios = String.Empty;

                foreach (DataRow dr in dt.Rows)
                    Servicios = Servicios + dr["servicio"].ToString() + "\n";



                oImpresion.ImprimirContratoDebitoAut(Titular, TarjetaNro, TarjetaVto, IdTarjeta, Inicio, Servicios);
            }
        }


        private void btnBuscar_Click_2(object sender, EventArgs e)
        {
            filtrarEstado();
        }

        private void btnexportar_Click(object sender, EventArgs e)
        {
            oTools.ExportToExcel(dgv, "Plasticos");
        }
    }
}//261119fede
