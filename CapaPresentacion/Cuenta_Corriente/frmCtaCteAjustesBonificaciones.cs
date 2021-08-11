using CapaNegocios;
using System;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Cuenta_Corriente
{
    public partial class frmCtaCteAjustesBonificaciones : Form
    {
        private decimal viejoAjuste;
        private Thread hilo;
        private delegate void myDel();
        private Usuarios_CtaCte oUsuariosCtaCte = new Usuarios_CtaCte();
        private Usuarios_Servicios oUsuariosServicios = new Usuarios_Servicios();
        //private DateTime fechaDesde = new DateTime();
        //private DateTime fechaHasta = new DateTime();
        private DataGridViewRow drDatoSeleccionado;
        private DataTable dtDatosCtaCte = new DataTable();
        private bool realizarAjustes = false;
        DialogResult dialogResult;

        private void ComenzarCarga()
        {
            pgCircular.Start();
            hilo = new Thread(new ThreadStart(CargarDatos));
            hilo.IsBackground = true;
            hilo.Start();
        }

        private void CargarDatos()
        {
            myDel MD = new myDel(AsignarDatos);
            this.Invoke(MD, new object[] { });
            pgCircular.Stop();
        }

        private void AsignarDatos()
        {
            if (realizarAjustes == false)
            {
                dgvDatos.DataSource = null;

                foreach (DataRow dr in dtDatosCtaCte.Rows)
                    dr["Importe_Total"] = Convert.ToDecimal(dr["Importe_Total"]) - Convert.ToDecimal(dr["Importe_Provincial"]) - Convert.ToDecimal(dr["importe_punitorio"]);

                dtDatosCtaCte.AcceptChanges();

                dgvDatos.DataSource = dtDatosCtaCte;
                dgvDatos.ReadOnly = false;

                for (int x = 0; x < dgvDatos.Columns.Count; x++)
                {
                    dgvDatos.Columns[x].Visible = false;
                    dgvDatos.Columns[x].ReadOnly = true;

                }


                dgvDatos.Columns["Servicio"].Visible = true;
                dgvDatos.Columns["importe_saldo"].Visible = true;
                dgvDatos.Columns["fecha_desde"].Visible = true;
                dgvDatos.Columns["fecha_hasta"].Visible = true;
                dgvDatos.Columns["BonificacionPorcentaje"].Visible = true;
                dgvDatos.Columns["Bonificacionimporte"].Visible = true;
                dgvDatos.Columns["ImporteBonificado"].Visible = true;

                //    dgvDatos.Columns["elegir"].Visible = true;

                dgvDatos.Columns["Servicio"].HeaderText = "Descripción";
                dgvDatos.Columns["importe_saldo"].HeaderText = "Saldo";
                dgvDatos.Columns["fecha_desde"].HeaderText = "Desde";
                dgvDatos.Columns["fecha_hasta"].HeaderText = "Hasta";
                dgvDatos.Columns["BonificacionPorcentaje"].HeaderText = "%";
                dgvDatos.Columns["Bonificacionimporte"].HeaderText = "Bonificacion";
                dgvDatos.Columns["ImporteBonificado"].HeaderText = "Importe Bonificado";

                dgvDatos.Columns["BonificacionPorcentaje"].ReadOnly = false;
                dgvDatos.Columns["Bonificacionimporte"].ReadOnly = false;

                //      dgvDatos.Columns["elegir"].HeaderText = "Elegir";

                dgvDatos.Columns["importe_saldo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvDatos.Columns["ImporteBonificado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvDatos.Columns["Bonificacionimporte"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvDatos.Columns["BonificacionPorcentaje"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvDatos.Columns["importe_saldo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvDatos.Columns["fecha_desde"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvDatos.Columns["fecha_hasta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvDatos.Columns["importe_saldo"].DefaultCellStyle.Format = "c2";
                dgvDatos.Columns["Bonificacionimporte"].DefaultCellStyle.Format = "c2";
                dgvDatos.Columns["Servicio"].Width = 350;
                estilo();
                Controla_importes();
                oculta_filas();
            }
            else
            {
                btnGuardar.Enabled = true;
                realizarAjustes = false;
                MessageBox.Show("Operación realizada correctamente");
                this.DialogResult = DialogResult.OK;
                this.Close();

            }
        }

        private void AsignarValores()
        {

        }

        private void imgServicios_Unicos_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCtaCteAjustesBonificaciones_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void cboTipoValor_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        public frmCtaCteAjustesBonificaciones(DataTable dtDatosCtaCte)
        {
            this.dtDatosCtaCte = dtDatosCtaCte;

            dtDatosCtaCte.Columns.Add("BonificacionPorcentaje", typeof(decimal));
            dtDatosCtaCte.Columns.Add("Bonificacionimporte", typeof(decimal));
            dtDatosCtaCte.Columns.Add("ImporteBonificado", typeof(decimal));
            dtDatosCtaCte.Columns.Add("detalle", typeof(String));
            dtDatosCtaCte.Columns.Add("Operacion", typeof(Int32));
            Limpiar_importes();

            InitializeComponent();
        }

        private void frmCtaCteAjustesBonificaciones_Load(object sender, EventArgs e)
        {
            ComenzarCarga();
        }

        private void dgvDatos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDatos.Rows.Count > 0)
            {
                if (dgvDatos.SelectedRows.Count > 0)
                    drDatoSeleccionado = dgvDatos.CurrentRow;
                else
                    drDatoSeleccionado = dgvDatos.Rows[0];
                AsignarValores();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDetalle.Text))
            {
                MessageBox.Show("Debe especificar un detalle");
                txtDetalle.Focus();
            }
            else
            {
                if (rdnivelcomprobante.Checked == true)
                {

                    object sumOri = dtDatosCtaCte.Compute("sum(importe_total)", string.Format("encabezado ={0}", 2));
                    object sumBon = dtDatosCtaCte.Compute("sum(Bonificacionimporte)", string.Format("encabezado ={0}", 2));
                    sumOri = sumOri.ToString() == "" ? 0 : sumOri;
                    sumBon = sumBon.ToString() == "" ? 0 : sumBon;

                    Decimal Porcentaje = 0;

                    Porcentaje = decimal.Round(Convert.ToDecimal(sumBon.ToString()) * 100 / Convert.ToDecimal(sumOri.ToString()), 2);


                    foreach (DataRow fila in dtDatosCtaCte.Rows)
                    {
                        fila["Bonificacionimporte"] = 0;  //pone en 0 los subservicios y comprobantes

                        if (Convert.ToInt32(fila["encabezado"].ToString()) == 1)
                            fila["Bonificacionimporte"] = Decimal.Round(Convert.ToDecimal(fila["importe_total"].ToString()) * Porcentaje / 100, 2);  //pone en 0 los subservicios y comprobantes
                    }
                }



                foreach (DataRow fila in dtDatosCtaCte.Rows)
                {

                    if (rdnivelsubservicio.Checked == true)
                        if (Convert.ToInt32(fila["encabezado"].ToString()) != 0)
                            fila["Bonificacionimporte"] = 0;  //pone en 0 los servicios y comprobantes


                    if (rdnivelservicio.Checked == true)
                        if (Convert.ToInt32(fila["encabezado"].ToString()) != 1)
                            fila["Bonificacionimporte"] = 0;  //pone en 0 los subservicios y comprobantes



                    if (rdPorcentaje1.Checked == true)
                        fila["Operacion"] = 0; // 0 resta 1 suma

                    if (rdPorcentaje2.Checked == true)
                        fila["Operacion"] = 1; // 0 resta 1 suma


                    fila["Detalle"] = txtDetalle.Text;
                }

                oUsuariosCtaCte.GuardarAjustesManuales(dtDatosCtaCte);
                realizarAjustes = true;
                ComenzarCarga();

            }

        }

        private void cboTipoAjuste_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvDatos.Columns[e.ColumnIndex].Name.Equals("importeconajuste"))
                    dgvDatos.CurrentCell.ReadOnly = false;

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void dgvDatos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Boolean Continua = false;
            Int32 NroLinea = Convert.ToInt32(dgvDatos.CurrentRow.Cells["autonumerico"].Value.ToString());
            if (Convert.ToInt32(dgvDatos.CurrentRow.Cells["encabezado"].Value.ToString()) == 0 && rdnivelsubservicio.Checked == true)
                Continua = true;

            if (Convert.ToInt32(dgvDatos.CurrentRow.Cells["encabezado"].Value.ToString()) == 1 && rdnivelservicio.Checked == true)
                Continua = true;

            if (Convert.ToInt32(dgvDatos.CurrentRow.Cells["encabezado"].Value.ToString()) == 2 && rdnivelcomprobante.Checked == true)
                Continua = true;


            if (Continua == true)
            {

                if (dgvDatos.Columns[e.ColumnIndex].Name == "BonificacionPorcentaje")
                {
                    foreach (DataRow fila in dtDatosCtaCte.Rows)
                    {
                        if (NroLinea == Convert.ToDecimal(fila["autonumerico"].ToString()))
                        {
                            fila["Bonificacionimporte"] = Convert.ToDecimal(fila["Importe_total"].ToString()) * Convert.ToDecimal(fila["BonificacionPorcentaje"].ToString()) / 100;
                            if (rdPorcentaje1.Checked == true) //descuento
                                fila["ImporteBonificado"] = Convert.ToDecimal(fila["Importe_total"].ToString()) - Convert.ToDecimal(fila["Bonificacionimporte"].ToString());
                            else
                                fila["ImporteBonificado"] = Convert.ToDecimal(fila["Importe_total"].ToString()) + Convert.ToDecimal(fila["Bonificacionimporte"].ToString());
                        }
                    }

                }

                if (dgvDatos.Columns[e.ColumnIndex].Name == "Bonificacionimporte")
                {
                    foreach (DataRow fila in dtDatosCtaCte.Rows)
                    {
                        if (NroLinea == Convert.ToDecimal(fila["autonumerico"].ToString()))
                        {
                            if (rdPorcentaje1.Checked == true) //descuento
                                fila["ImporteBonificado"] = Convert.ToDecimal(fila["Importe_total"].ToString()) - Convert.ToDecimal(fila["Bonificacionimporte"].ToString());
                            else
                                fila["ImporteBonificado"] = Convert.ToDecimal(fila["Importe_total"].ToString()) + Convert.ToDecimal(fila["Bonificacionimporte"].ToString());

                            fila["BonificacionPorcentaje"] = decimal.Round(Convert.ToDecimal(fila["Bonificacionimporte"].ToString()) * 100 / Convert.ToDecimal(fila["Importe_total"].ToString()), 2);

                        }
                    }

                }
            }
            else
            {
                foreach (DataRow fila in dtDatosCtaCte.Rows)
                {
                    if (NroLinea == Convert.ToDecimal(fila["autonumerico"].ToString()))
                    {
                        fila["Bonificacionimporte"] = 0;
                        fila["ImporteBonificado"] = 0;
                        fila["BonificacionPorcentaje"] = 0;

                    }
                }

            }
            Controla_importes();

        }

        #region Grilla

        private void estilo()
        {
            foreach (DataGridViewRow dr in dgvDatos.Rows)
            {
                dr.Height = 35;
                int value = Convert.ToInt32(dr.Cells["Encabezado"].Value); // 2 comprobante 1= servicio


                if (dr.Cells["expande"].Value.ToString() == "+")
                    dr.Cells["expande"].Style.ForeColor = Color.Red;


                if (value == 0)
                {
                    dr.DefaultCellStyle.BackColor = Color.WhiteSmoke;

                    if (Convert.ToInt32(dr.Cells["idtiporegistroctactedet"].Value) == Convert.ToInt32(Usuarios_CtaCte_Det.TIPO_REGISTRO_CTACTEDET.DETALLE))
                        dr.DefaultCellStyle.ForeColor = Color.Black;
                    else
                        dr.DefaultCellStyle.ForeColor = Color.Green;

                    dr.DefaultCellStyle.Font = new Font("Calibri", 10, FontStyle.Regular);

                }
                if (value == 1)
                {
                    dr.DefaultCellStyle.BackColor = Color.Bisque;
                    dr.DefaultCellStyle.Font = new Font("Calibri", 12, FontStyle.Regular);

                }

                if (value == 2)
                {
                    dr.DefaultCellStyle.BackColor = Color.LightSalmon;
                    dr.DefaultCellStyle.Font = new Font("Calibri", 12, FontStyle.Bold);
                }
            }

        }

        private void oculta_filas()
        {
            dgvDatos.ClearSelection();
            txtDetalle.Focus();
            dgvDatos.CurrentCell.Selected = false;



            foreach (DataGridViewRow dr in dgvDatos.Rows)
            {
                if (rdnivelcomprobante.Checked == true)
                {
                    if (Convert.ToInt32(dr.Cells["encabezado"].Value) == 2)
                        dr.Visible = true;
                    else
                        try { dr.Visible = false; }
                        catch { }


                }

                if (rdnivelservicio.Checked == true)
                {
                    if (Convert.ToInt32(dr.Cells["encabezado"].Value) == 0)
                        try { dr.Visible = false; }
                        catch { }
                    else
                        dr.Visible = true;

                }


                if (rdnivelsubservicio.Checked == true)
                {
                    dr.Visible = true;
                }

            }
        }
        #endregion

        private void dgvDatos_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            viejoAjuste = Convert.ToDecimal(dgvDatos.CurrentCell.Value);
        }

        #region Importes
        private void Limpiar_importes()
        {
            foreach (DataRow fila in dtDatosCtaCte.Rows)
            {
                fila["BonificacionPorcentaje"] = 0;
                fila["Bonificacionimporte"] = 0;
                fila["ImporteBonificado"] = Convert.ToDecimal(fila["Importe_total"].ToString());
                fila["detalle"] = "";
                fila["Operacion"] = 0; // 0 resta 1 suma
            }


        }

        private void Controla_importes()
        {
            Decimal Total = 0;
            Decimal Bonificado = 0;


            //control si es aumento o descuento para todos los niveles
            foreach (DataRow dr in dtDatosCtaCte.Rows)
            {

                if (string.IsNullOrEmpty(dr["tipo"].ToString()))
                    dr["tipo"] = "S";

                if (rdPorcentaje1.Checked == true) //descuento
                    dr["ImporteBonificado"] = Convert.ToDecimal(dr["Importe_total"].ToString()) - Convert.ToDecimal(dr["Bonificacionimporte"].ToString());
                else
                    dr["ImporteBonificado"] = Convert.ToDecimal(dr["Importe_total"].ToString()) + Convert.ToDecimal(dr["Bonificacionimporte"].ToString());

                if (Convert.ToInt32(dr["encabezado"]) == 0) //linea de servicio --- suma los sub y graba la linea del servicio 
                {

                    Total = Total + decimal.Round(Convert.ToDecimal(dr["importe_total"].ToString()), 2);
                    Bonificado = Bonificado + decimal.Round(Convert.ToDecimal(dr["ImporteBonificado"].ToString()), 2);
                }
            }
            //*****************************************************************************

            if (rdnivelsubservicio.Checked == true)
            {
                foreach (DataRow dr in dtDatosCtaCte.Rows)
                {

                    if (Convert.ToInt32(dr["encabezado"]) == 1) //linea de servicio --- suma los sub y graba la linea del servicio 
                    {

                        object sumOri = dtDatosCtaCte.Compute("sum(ImporteBonificado)", string.Format("Id_usuarios_servicios = {0} and encabezado ={1} and Id_usuarios_ctacte = {2}", Convert.ToInt32(dr["Id_usuarios_servicios"]), 0, Convert.ToInt32(dr["Id_usuarios_ctacte"])));
                        object sumBon = dtDatosCtaCte.Compute("sum(Bonificacionimporte)", string.Format("Id_usuarios_servicios = {0} and encabezado ={1} and Id_usuarios_ctacte = {2}", Convert.ToInt32(dr["Id_usuarios_servicios"]), 0, Convert.ToInt32(dr["Id_usuarios_ctacte"])));

                        sumOri = sumOri.ToString() == "" ? 0 : sumOri;
                        dr["ImporteBonificado"] = Convert.ToDecimal(sumOri);

                        sumBon = sumBon.ToString() == "" ? 0 : sumBon;
                        dr["Bonificacionimporte"] = Convert.ToDecimal(sumBon);


                    }
                }

            }



            if (rdnivelservicio.Checked == true || rdnivelsubservicio.Checked == true)
            {
                foreach (DataRow dr in dtDatosCtaCte.Rows)
                {
                    if (Convert.ToInt32(dr["encabezado"]) == 2) //suma los sub y los pone en comprobante
                    {
                        object sumOri = dtDatosCtaCte.Compute("sum(ImporteBonificado)", string.Format("encabezado ={0}", 0));
                        object sumBon = dtDatosCtaCte.Compute("sum(Bonificacionimporte)", string.Format("encabezado ={0}", 0));
                        sumOri = sumOri.ToString() == "" ? 0 : sumOri;
                        dr["ImporteBonificado"] = Convert.ToDecimal(sumOri);

                        sumBon = sumBon.ToString() == "" ? 0 : sumBon;
                        dr["Bonificacionimporte"] = Convert.ToDecimal(sumBon);


                    }

                }
            }

            lbImporteCOmprobante.Text = "Importe Original : $ " + Total.ToString();
            lbimporteBonificado.Text = "Importe Bonificado : $ " + Bonificado.ToString();


        }
        #endregion

        #region Check
        private void rdPorcentaje1_CheckedChanged(object sender, EventArgs e)
        {
            Controla_importes();
        }

        private void rdnivelcomprobante_CheckedChanged(object sender, EventArgs e)
        {
            Limpiar_importes();
            Controla_importes();
            oculta_filas();
        }

        private void rdnivelservicio_CheckedChanged(object sender, EventArgs e)
        {
            Limpiar_importes();
            Controla_importes();
            oculta_filas();

        }

        private void rdnivelsubservicio_CheckedChanged(object sender, EventArgs e)
        {
            Limpiar_importes();
            Controla_importes();
            oculta_filas();

        }

        private void rdPorcentaje2_CheckedChanged(object sender, EventArgs e)
        {
            Controla_importes();
        }
        #endregion
    }
}
