using CapaNegocios;
using System;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmCass : Form
    {
        #region [PROPIEDADES]
        private string numTarjeta;
        private int idUsuSer, idServicio;
        private DataTable dataTable;
        private DataTable dtTarjeta, dtUser;
        private Thread hilo;
        private delegate void myDel();
        private Cass oCass;
        private Usuarios_Servicios oUsuSer = new Usuarios_Servicios();
        int cont = 0;
        public int id_Tipo_facturacion =0;
        public bool servicioRetirado = false;
        DataView dvFiltrado;
        DataTable dtFiltrada = new DataTable();
        DataTable dtAplicacionesFiltradas = Tablas.DataCass;
        bool tarjetaValida = false;
        #endregion

        #region [METODOS]
        private void asignarDatos()
        {
            if (servicioRetirado == true)
            {
                btnActivar.Enabled = false;
                btnDesactivar.Enabled = false;
                btnReanudar.Enabled = false;
                btnPausar.Enabled = false;
            }
            else
            {
                btnActivar.Enabled = true;
                btnDesactivar.Enabled = true;
                btnReanudar.Enabled = true;
                btnPausar.Enabled = true;
            }
            DataView dv = Usuarios.Current_dtServicios.DefaultView;
            //dv.RowFilter = "id_usuario_servicio=" + idUsuSer + "and (id_servicio_sub_tipo=1 or id_servicio_sub_tipo=0)";
            dv.RowFilter = "id_usuario_servicio= " + idUsuSer;
            dv.Sort = "id_usuario_servicio_sub asc";
            dataTable = dv.ToTable();
            int idServicio = Convert.ToInt32(dataTable.Rows[0]["id_servicio"]);
            setearLbls();

            Cass oCass = new Cass(Convert.ToInt32(dtAplicacionesFiltradas.Rows[0]["Id"]));
            dtTarjeta = oCass.ListarTarjetasUser(txtTarjeta.Text);
            dtUser = oCass.ListarPaquetesUser(Convert.ToString(txtCodigo.Text));
            DataColumn dc = new DataColumn();
            dc.ColumnName = "paquete";
            dc.DataType = typeof(string);
            dc.DefaultValue = string.Empty;
            dataTable.Columns.Add(dc);

            dgv.DataSource = dataTable;
            dgvTarjetas.DataSource = dtTarjeta;
            dgvUser.DataSource = dtUser;



            foreach (DataGridViewColumn item in dgv.Columns)
                item.Visible = false;

            foreach (DataGridViewColumn item1 in dgvTarjetas.Columns)
                item1.Visible = true;

            dgvTarjetas.Columns["id_producto"].Visible = false;
            dgvTarjetas.Columns["id_time"].Visible = false;
            dgvTarjetas.Columns["idTarjeta"].Visible = false;
            dgvTarjetas.Columns["id_User"].Visible = false;
            dgvTarjetas.Columns["EstadoProducto"].Visible = true;
            dgvTarjetas.Columns["EstadoTarjeta"].Visible = false;
            dgvTarjetas.Columns["Usuario"].HeaderText = "Usuario";
            dgvTarjetas.Columns["Codigo_Gies"].HeaderText = "Codigo";
            dgvTarjetas.Columns["producto"].HeaderText = "Producto";
            dgvTarjetas.Columns["Serie"].HeaderText = "Serie";
            dgvTarjetas.Columns["Fecha_Corte"].HeaderText = "CORTE";
            dgvTarjetas.Columns["Serie"].Width = 140;
            dgvTarjetas.Columns["producto"].Width = 70;
            dgvTarjetas.Columns["Codigo_gies"].Width = 70;
            dgvTarjetas.Columns["Usuario"].Width = 160;

            AgregarColumna();
            foreach (DataGridViewColumn item2 in dgvUser.Columns)
                item2.Visible = true;
            dgvUser.Columns["id_producto"].Visible = false;
            dgvUser.Columns["id_time"].Visible = false;
            dgvUser.Columns["idTarjeta"].Visible = false;
            dgvUser.Columns["id_User"].Visible = false;
            dgvUser.Columns["EstadoProducto"].Visible = false;
            dgvUser.Columns["EstadoTarjeta"].Visible = false;
            dgvUser.Columns["Usuario"].HeaderText = "Usuario";
            dgvUser.Columns["Codigo_Gies"].HeaderText = "Codigo";
            dgvUser.Columns["producto"].HeaderText = "Producto";
            dgvUser.Columns["Serie"].HeaderText = "Serie";
            dgvUser.Columns["Fecha_Corte"].HeaderText = "CORTE";
            dgvUser.Columns["Serie"].Width = 140;
            dgvUser.Columns["producto"].Width = 70;
            dgvUser.Columns["Codigo_gies"].Width = 70;
            dgvUser.Columns["Usuario"].Width = 160;

            foreach (DataGridViewRow item in dgv.Rows)
            {
                if (Convert.ToInt32(item.Cells["id_servicio_sub_tipo"].Value) != 1 && Convert.ToInt32(item.Cells["id_servicio_sub_tipo"].Value) != 0)
                    item.Visible = false;


                if (Convert.ToInt32(item.Cells["id_usuario_servicio_sub"].Value) == 0)
                {
                    item.DefaultCellStyle.ForeColor = Color.White;
                    item.DefaultCellStyle.BackColor = Color.SlateGray;
                    item.Cells["servicio_sub"].Value = "";
                }
                else
                {
                    item.Cells["servicio"].Value = "";
                    item.Cells["paquete"].Value = oCass.ObtenerPaqueteString(Convert.ToInt32(item.Cells["id_servicio_sub"].Value));
                }
            }

            dgv.Columns["servicio"].Visible = true;
            dgv.Columns["servicio"].HeaderText = "Servicio";
            dgv.Columns["servicio_sub"].HeaderText = "SubServicio";
            dgv.Columns["servicio_sub"].Visible = true;
            dgv.Columns["fecha_fin"].Visible = true;
            dgv.Columns["fecha_fin"].HeaderText = "Fecha Fin";
            dgv.Columns["estado"].Visible = true;
            dgv.Columns["estado"].HeaderText = "Estado";
            dgv.Columns["id_usuarios"].Visible = false;
            dataTable.AcceptChanges();
            foreach (DataGridViewRow row in dgv.Rows)
            {
                row.Height = 35;
            }
            txtCodigo.Enabled = false;
            txtTarjeta.Enabled = false;
        }

        public void setearLbls()
        {
            txtCodigo.Text = Usuarios.CurrentUsuario.Codigo.ToString();
            lblAbonado.BackColor = Color.YellowGreen;
            lblAbonado.ForeColor = Color.White;
            txtTarjeta.Text = this.numTarjeta.ToString();
            if(txtTarjeta.Text == "")
            {
                lblTarjeta.BackColor = Color.Tomato;
                lblTarjeta.ForeColor = Color.White;
            }
            else
            {
                lblTarjeta.BackColor = Color.YellowGreen;
                lblTarjeta.ForeColor = Color.White;
            }
        }

        private void AgregarColumna()
        {
            if (cont < 1)
            {
                DataGridViewLinkColumn ctotal = new DataGridViewLinkColumn();
                ctotal.Text = "Ver GIES";
                ctotal.DataPropertyName = "Tarjeta";
                ctotal.Name = "Tarjeta";
                ctotal.LinkColor = Color.DarkOrchid;
                ctotal.VisitedLinkColor = Color.Violet;
                ctotal.UseColumnTextForLinkValue = true;
                ctotal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                ctotal.Width = 100;
                ctotal.HeaderText = "Tarjeta";
                dgvUser.Columns.Add(ctotal);
                cont = cont + 1;
            }
        }

        private void PintarDgvUsuario()
        {

        }

        private void PintarDgvTarjetas()
        {

        }
        #endregion

        #region [EVENTOS]
        public FrmCass(string tarjeta, int idUsuSer)
        {
            this.numTarjeta = tarjeta.Trim().ToLower();
            this.idUsuSer = idUsuSer;
            DataTable dtUsuarioServicios = new DataTable();
            InitializeComponent();
        }

        private void FrmTest_Load(object sender, EventArgs e)
        {
            if (this.numTarjeta.Length == 16) 
                tarjetaValida = true;
            else
                tarjetaValida = false;
            asignarDatos();
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            if (tarjetaValida == true)
            {
                DataTable dt = new DataTable();
                string nombrePaquete = String.Empty;
                string PaquetesActivados = "", resultadoFinal = "";
                oCass = new Cass(Convert.ToInt32(dtAplicacionesFiltradas.Rows[0]["Id"]));
                dt = oCass.ObtenerPaquetesDt(Convert.ToInt32(dgv.SelectedRows[0].Cells["id_servicio_sub"].Value));
                string resultado = string.Empty;

                foreach (DataRow dr in dt.Rows)
                {
                    nombrePaquete = dr["cass_paquete"].ToString();
                    if (nombrePaquete != string.Empty)
                    {
                        if (oCass.ActivarPaqueteNuevo(Usuarios.CurrentUsuario.Id, txtTarjeta.Text, nombrePaquete, id_Tipo_facturacion, out resultado) == false)
                            PaquetesActivados = PaquetesActivados + $"\n{dr["cass_paquete"].ToString()} FALLIDO";
                        else
                        {
                            oUsuSer.ActivarSubservicio(Convert.ToInt32(dgv.SelectedRows[0].Cells["id_usuario_servicio_sub"].Value));
                            PaquetesActivados = PaquetesActivados + $"\n{dr["cass_paquete"].ToString()} EXITOSO";

                        }
                    }
                }
                resultadoFinal = "Operacion concluida, el resultado es: \n" + PaquetesActivados.ToString();
                MessageBox.Show(resultadoFinal.ToString());
                asignarDatos();
            }
            else
                MessageBox.Show("Numero de tarjeta invalido");
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            if (tarjetaValida == true)
            {
                DataTable dt = new DataTable();
                string nombrePaquete = String.Empty;
                oCass = new Cass(Convert.ToInt32(dtAplicacionesFiltradas.Rows[0]["Id"]));
                dt = oCass.ObtenerPaquetesDt(Convert.ToInt32(dgv.SelectedRows[0].Cells["id_servicio_sub"].Value));
                string PaquetesActivados = "", resultadoFinal = "";
                string resultado = string.Empty;
                foreach (DataRow dr in dt.Rows)
                {
                    nombrePaquete = dr["cass_paquete"].ToString();
                    if (nombrePaquete != string.Empty)
                    {
                        if (oCass.DesactivarPaquete(Usuarios.CurrentUsuario.Id, txtTarjeta.Text, nombrePaquete, out resultado) == false)
                            PaquetesActivados = PaquetesActivados + $"\n{dr["cass_paquete"].ToString()} FALLIDO";
                        else
                        {
                            DialogResult dialogResult = MessageBox.Show("¿Desea inhabilitar el paquete en el GIES?", "", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                oUsuSer.DesactivarSubservicio(Convert.ToInt32(dgv.SelectedRows[0].Cells["id_usuario_servicio_sub"].Value));
                            }
                            PaquetesActivados = PaquetesActivados + $"\n{dr["cass_paquete"].ToString()} EXITOSO";

                        }
                    }
                }
                resultadoFinal = "Operacion concluida, el resultado es: \n" + PaquetesActivados.ToString();
                MessageBox.Show(resultadoFinal.ToString());
                asignarDatos();
            }
            else
                MessageBox.Show("Numero de tarjeta invalido");
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPausar_Click(object sender, EventArgs e)
        {
            try {
                if (tarjetaValida == true)
                {
                    string Salida = "";
                    oCass = new Cass(Convert.ToInt32(dtAplicacionesFiltradas.Rows[0]["Id"]));
                    oCass.PausarPaquetesAbonado(Usuarios.CurrentUsuario.Id, out Salida);
                    MessageBox.Show(Salida.ToString());
                    asignarDatos();
                }
                else
                    MessageBox.Show("Numero de tarjeta invalido");
            }
            catch
            {
                MessageBox.Show("Hubo un error al pausar al abonado.");
            }
        }

        private void dgvTarjetas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        private void btnReanudar_Click(object sender, EventArgs e)
        {
            try 
            {
                if (tarjetaValida == true)
                {
                    string Salida = "";
                    oCass = new Cass(Convert.ToInt32(dtAplicacionesFiltradas.Rows[0]["Id"]));
                    oCass.ReactivarPaquetesAbonado(Usuarios.CurrentUsuario.Id, out Salida);
                    MessageBox.Show(Salida.ToString());
                    asignarDatos();
                }
                else
                    MessageBox.Show("Numero de tarjeta invalido");
            }
            catch
            {
                MessageBox.Show("Hubo un error al reanudar el abonado.");
            }
        }

        private void dgvUser_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvUser.Columns[e.ColumnIndex].Name == "Tarjeta")
            {
                FrmCass_Tarjetas frmGies = new FrmCass_Tarjetas();       
                DataView dvFiltrado2 = dtUser.DefaultView;
                dvFiltrado2.RowFilter = string.Format("id_producto={0}", Convert.ToInt32(dgvUser.SelectedRows[0].Cells["id_producto"].Value));
                dtFiltrada = dvFiltrado2.ToTable();
                frmGies.dtUsuario = dtFiltrada;
                frmGies.Tarjeta = Convert.ToString(dtFiltrada.Rows[0]["serie"]);
                frmGies.ShowDialog();

                asignarDatos();
            }
        }


        #endregion
    }
}
