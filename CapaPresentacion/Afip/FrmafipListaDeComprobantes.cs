using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CapaNegocios;
using CapaPresentacion.Impresiones;
using FEAFIPLib;
using System.Globalization;


namespace CapaPresentacion.Afip
{
    public partial class frmafipListaDeComprobantes : Form
    {
        private Int32 ErrorNro;
        private String ErrorDescripcion;

        private Double Factura_a;
        private Double Factura_b;
        private Double NotaCredito_a;
        private Double NotaCRedito_b;
        private Decimal NetoGies;
        private Decimal IvaGies;
        private Decimal ImpGies;
        private Decimal FinalGies;
        private Int32 fechaInicio;
        private Int32 fechaFin;
        private Int32 IdIva ;
        private Int32 IdComprobante ;


        private afip oAfip = new afip();
        private wsfev1 oAfipLIbreria = new wsfev1();
        private wsPadron oAfipPadron = new wsPadron();
        private Contribuyente oAfipContribuyente = new Contribuyente();
        private Configuracion oConfiguracion = new Configuracion();

        private Comprobantes_Tipo OcomprobantesTipo = new Comprobantes_Tipo();
        private Comprobante oComprobanteAfip = new Comprobante();
        private Puntos_Venta oPuntosdeventa = new Puntos_Venta();
        private Climpuestos oImpuestos = new Climpuestos();
        private Facturacion oFacturacion = new Facturacion();
        private Usuarios oUsuario = new Usuarios();
        private Comprobantes oComprobantes = new Comprobantes();
        private Impresion Oimpresion = new Impresion();

        private DataTable dtComprobantesTipos = new DataTable();
        private DataTable dtPuntos = new DataTable(); 
        private DataTable dtIvaVentas = new DataTable();
        private DataTable dtIvaVentasGies = new DataTable();
        private DataTable dt_Punto_venta = new DataTable();
        private DataTable dt_Datos_Usuario = new DataTable();
        private DataTable dt_Comprobante_Tipo_Filtrado = new DataTable();
        private DataTable dt_iva_ventas = new DataTable();

        public frmafipListaDeComprobantes()
        {
           InitializeComponent();
        }

        private void frmafipListaDeComprobantes_Load(object sender, EventArgs e)
        {
            this.CargarDatos();
        }

        private void CargarDatos()
        {
            dtComprobantesTipos = OcomprobantesTipo.Listar_Comprobantes_Afip();
            dtPuntos = oPuntosdeventa.Listar();
            this.AsignarDatos();
        }

        private void AsignarDatos()
        {
            spPuntodeVenta.Value = Convert.ToInt32(dtPuntos.Rows[0]["numero"].ToString());
            Arma_Grilla_Iva_Ventas();
            oAfipPadron.CUIT = Convert.ToDouble(oConfiguracion.GetValor_C("Cuit"));
            oAfipPadron.ModoProduccion = true;

        }

        private void Arma_Grilla_Iva_Ventas()
        {
            dtIvaVentas.Columns.Add("Identificacion", typeof(String)).DefaultValue="-";
            dtIvaVentas.Columns.Add("Comprobante", typeof(String)).DefaultValue="-";
            dtIvaVentas.Columns.Add("letra", typeof(String)).DefaultValue="-";
            dtIvaVentas.Columns.Add("Fecha", typeof(String)).DefaultValue = "-";
            dtIvaVentas.Columns.Add("Numero", typeof(Double)).DefaultValue = 0;
            dtIvaVentas.Columns.Add("Cae", typeof(String)).DefaultValue = "-";
            dtIvaVentas.Columns.Add("Cae_vencimiento", typeof(String)).DefaultValue = "-";
            dtIvaVentas.Columns.Add("Neto_Afip", typeof(Decimal)).DefaultValue = 0;
            dtIvaVentas.Columns.Add("Iva_Afip", typeof(Decimal)).DefaultValue = 0;
            dtIvaVentas.Columns.Add("Provincial_Afip", typeof(Decimal)).DefaultValue = 0;
            dtIvaVentas.Columns.Add("Final_Afip", typeof(Decimal)).DefaultValue = 0;
            dtIvaVentas.Columns.Add("Neto_Gies", typeof(Decimal)).DefaultValue = 0;
            dtIvaVentas.Columns.Add("Iva_Gies", typeof(Decimal)).DefaultValue = 0;
            dtIvaVentas.Columns.Add("Provincial_Gies", typeof(Decimal)).DefaultValue = 0;
            dtIvaVentas.Columns.Add("Final_Gies", typeof(Decimal)).DefaultValue = 0;
            dtIvaVentas.Columns.Add("Error", typeof(String)).DefaultValue = "-";
            dtIvaVentas.Columns.Add("id_Iva_ventas", typeof(Int32)).DefaultValue = 0;
            dtIvaVentas.Columns.Add("id_comprobantes", typeof(Int32)).DefaultValue = 0;
            dtIvaVentas.Columns.Add("id_comprobantes_iva", typeof(Int32)).DefaultValue = 0;
            dtIvaVentas.Columns.Add("num_comprobante", typeof(Int32)).DefaultValue = 0;
            dtIvaVentas.Columns.Add("Altura", typeof(string)).DefaultValue = "-";
            dtIvaVentas.Columns.Add("Calle", typeof(string)).DefaultValue = "-";
            dtIvaVentas.Columns.Add("Localidad", typeof(string)).DefaultValue = "-";
            dtIvaVentas.Columns.Add("Codigo_Postal", typeof(string)).DefaultValue = "-";
            dtIvaVentas.Columns.Add("Provincia", typeof(string)).DefaultValue = "-";
            dtIvaVentas.Columns.Add("Numero_Documento", typeof(double)).DefaultValue = 0;
            dtIvaVentas.Columns.Add("id_usuario", typeof(Int32)).DefaultValue = 0;
            dtIvaVentas.Columns.Add("id_comprobantes_tipo", typeof(Int32)).DefaultValue = 0;
            dtIvaVentas.Columns.Add("id_usuario_locacion", typeof(Int32)).DefaultValue=0;
            dtIvaVentas.Columns.Add("razon_social", typeof(string)).DefaultValue = "-";
            dtIvaVentas.Columns.Add("fantasia", typeof(string)).DefaultValue = "-";
            dtIvaVentas.Columns.Add("Usuario", typeof(string)).DefaultValue = "-";
        }

        private void UltimoComprobante()
        {
            ErrorNro = 0;
            ErrorDescripcion = "";
            if (spPuntodeVenta.Value == 0)
            {
                spPuntodeVenta.Focus();
                return;
            }

            oAfip.Conectar(out ErrorNro, out ErrorDescripcion);
            if (ErrorNro > 0)
            {
                MessageBox.Show(ErrorDescripcion);
                return;
            }

            Factura_a = oAfip.GetUltimoComprobante(Convert.ToInt32(spPuntodeVenta.Value.ToString()), 1, out ErrorNro, out ErrorDescripcion);
            Factura_b = oAfip.GetUltimoComprobante(Convert.ToInt32(spPuntodeVenta.Value.ToString()), 6, out ErrorNro, out ErrorDescripcion);
            NotaCredito_a = oAfip.GetUltimoComprobante(Convert.ToInt32(spPuntodeVenta.Value.ToString()), 3, out ErrorNro, out ErrorDescripcion);
            NotaCRedito_b = oAfip.GetUltimoComprobante(Convert.ToInt32(spPuntodeVenta.Value.ToString()), 8, out ErrorNro, out ErrorDescripcion);

        }

        private Int32 LeerComprobante(Int32 Punto_de_Venta,Int32 Tipo_Comprobante,Int32 Nro)
        {

            String Comprobante_Nombre, Comprobante_Letra;
            Int32 Resultado = 0;
            Int32 FechaActual = 0;
            ErrorNro = 0;
            ErrorDescripcion = "";
            NetoGies = 0;
            IvaGies = 0;
            ImpGies = 0;
            FinalGies = 0;
            IdIva = 0;
            IdComprobante = 0;
                
                oComprobanteAfip = oAfip.ObtenerComprobante(Punto_de_Venta, Tipo_Comprobante,Nro, out ErrorNro, out ErrorDescripcion);
                oAfipContribuyente = oAfip.ObtenerContribuyente(Convert.ToDouble(oComprobanteAfip.DocNro.ToString()), out ErrorNro, out ErrorDescripcion);
                double Dni;
                Dni = oComprobanteAfip.DocNro;
                dt_Comprobante_Tipo_Filtrado = OcomprobantesTipo.Listar_Comprobante_Afip_filtrado(Convert.ToInt32(oComprobanteAfip.CbteTipo)); 
                dt_Punto_venta = oAfip.Get_Punto_Venta(Convert.ToInt32(spPuntodeVenta.Value));
                dt_Datos_Usuario = oUsuario.Buscar_datos_usuario(Convert.ToDouble(Dni));
                if (ErrorNro == 0)
                {
                    FechaActual = Convert.ToInt32( oComprobanteAfip.CbteFch.ToString());
                    if (FechaActual < fechaInicio)
                    {
                        Resultado = 1;
                    }
                    else
                    {
                    if (FechaActual <= fechaFin)
                    {
                        oImpuestos.Cae = oComprobanteAfip.CodAutorizacion.Trim();
                        dtIvaVentasGies = oImpuestos.ListarIvaVentas(Convert.ToInt32(Climpuestos.Campo_Busqueda.cae));
                        if (dtIvaVentasGies.Rows.Count > 0)
                        {
                            NetoGies = Convert.ToDecimal(dtIvaVentasGies.Rows[0]["importe_neto"].ToString());
                            IvaGies = Convert.ToDecimal(dtIvaVentasGies.Rows[0]["importe_iva"].ToString());
                            ImpGies = Convert.ToDecimal(dtIvaVentasGies.Rows[0]["importe_impuesto_provincial"].ToString());
                            FinalGies = Convert.ToDecimal(dtIvaVentasGies.Rows[0]["importe_final"].ToString());
                            IdIva = Convert.ToInt32(dtIvaVentasGies.Rows[0]["id"].ToString());
                            IdComprobante = Convert.ToInt32(dtIvaVentasGies.Rows[0]["id_comprobantes"].ToString());
                        }
                        Comprobante_Nombre = "FACTURA";
                        Comprobante_Letra = "A";
                        switch (Tipo_Comprobante)
                        {
                            case 1:
                                Comprobante_Nombre = "FACTURA";
                                Comprobante_Letra = "A";
                                break;
                            case 2:
                                Comprobante_Nombre = "NOTA DE DEBITO";
                                Comprobante_Letra = "A";
                                break;
                            case 3:
                                Comprobante_Nombre = "NOTA DE CREDITO";
                                Comprobante_Letra = "A";
                                break;
                            case 6:
                                Comprobante_Nombre = "FACTURA";
                                Comprobante_Letra = "B";
                                break;
                            case 7:
                                Comprobante_Nombre = "NOTA DE DEBITO";
                                Comprobante_Letra = "B";
                                break;
                            case 8:
                                Comprobante_Nombre = "NOTA DE CREDITO";
                                Comprobante_Letra = "B";
                                break;
                        }
                        if(dt_Datos_Usuario.Rows.Count> 0)
                        { 
                            DataRow drFa = dtIvaVentas.NewRow();
                            drFa["Identificacion"] = oComprobanteAfip.DocNro;
                            drFa["Comprobante"] = Comprobante_Nombre;
                            drFa["Letra"] = Comprobante_Letra;
                            drFa["fecha"] = oComprobanteAfip.CbteFch;
                            drFa["Numero"] = Nro;
                            drFa["cae"] = oComprobanteAfip.CodAutorizacion;
                            drFa["cae_vencimiento"] = oComprobanteAfip.FchVto;
                            drFa["Neto_Afip"] = Decimal.Round(Convert.ToDecimal(oComprobanteAfip.ImpNeto.ToString()), 2);
                            drFa["Iva_Afip"] = Decimal.Round(Convert.ToDecimal(oComprobanteAfip.ImpIVA.ToString()), 2);
                            drFa["Provincial_Afip"] = Decimal.Round(Convert.ToDecimal(oComprobanteAfip.ImpTrib.ToString()), 2);
                            drFa["Final_Afip"] = Decimal.Round(Convert.ToDecimal(oComprobanteAfip.Imptotal.ToString()), 2);
                            drFa["Neto_Gies"] = Decimal.Round(Convert.ToDecimal(NetoGies.ToString()), 2);
                            drFa["Iva_Gies"] = Decimal.Round(Convert.ToDecimal(IvaGies.ToString()), 2);
                            drFa["Provincial_Gies"] = Decimal.Round(Convert.ToDecimal(ImpGies.ToString()), 2);
                            drFa["Final_Gies"] = Decimal.Round(Convert.ToDecimal(FinalGies.ToString()), 2);
                            drFa["id_Iva_ventas"] = IdIva;
                            drFa["id_comprobantes"] = IdComprobante;
                            drFa["id_usuario"] = Convert.ToInt32(dt_Datos_Usuario.Rows[0]["id_usuario"]);
                            drFa["id_usuario_locacion"] = Convert.ToInt32(dt_Datos_Usuario.Rows[0]["id_usuario_locacion"]);
                            drFa["calle"] = dt_Datos_Usuario.Rows[0]["calle"].ToString();
                            drFa["Altura"] = dt_Datos_Usuario.Rows[0]["Altura"].ToString();
                            drFa["Localidad"] = dt_Datos_Usuario.Rows[0]["Localidad"].ToString();
                            drFa["Codigo_Postal"] = dt_Datos_Usuario.Rows[0]["Codigo_Postal"].ToString();
                            drFa["provincia"] = dt_Datos_Usuario.Rows[0]["provincia"].ToString();
                            drFa["Numero_Documento"] = Convert.ToDouble(dt_Datos_Usuario.Rows[0]["Numero_Documento"]);
                            drFa["Razon_Social"] = dt_Datos_Usuario.Rows[0]["Usuario"].ToString();
                            drFa["Fantasia"] = dt_Datos_Usuario.Rows[0]["Usuario"].ToString();
                            drFa["Usuario"] = dt_Datos_Usuario.Rows[0]["Usuario"].ToString();
                            drFa["id_comprobantes_iva"] = Convert.ToInt32(dt_Datos_Usuario.Rows[0]["id_comprobantes_iva"]);
                            drFa["id_comprobantes_tipo"] = Convert.ToInt32(dt_Comprobante_Tipo_Filtrado.Rows[0]["id"]);
                            if  (Decimal.Round(Convert.ToDecimal( drFa["Final_Gies"].ToString()),1) != Decimal.Round(Convert.ToDecimal( drFa["Final_Afip"].ToString()),1))
                                    drFa["Error"] = "*";
                                else
                                    drFa["Error"] = " ";
                                dtIvaVentas.Rows.Add(drFa);
                        }
                    }
                    }
                }
            return Resultado;
        }

        private void FormatearGrilla()
        {


            for (int i = 0; i < dgv.ColumnCount; i++)
                dgv.Columns[i].Visible = false;


            dgv.Columns["Neto_Afip"].Visible = true;
            dgv.Columns["Iva_Afip"].Visible = true;
            dgv.Columns["Provincial_Afip"].Visible = true;
            dgv.Columns["Final_Afip"].Visible = true;
            dgv.Columns["Neto_Gies"].Visible = true;
            dgv.Columns["Iva_gies"].Visible = true;
            dgv.Columns["Provincial_Gies"].Visible = true;
            dgv.Columns["Final_Gies"].Visible = true;
            dgv.Columns["Usuario"].Visible = true;

            dgv.Columns["Neto_Afip"].DefaultCellStyle.Format = "c2";
            dgv.Columns["Neto_Afip"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["Neto_Afip"].HeaderText = "Neto AFIP";

            dgv.Columns["Iva_Afip"].DefaultCellStyle.Format = "c2";
            dgv.Columns["Iva_Afip"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["Iva_Afip"].HeaderText = "Iva AFIP";

            dgv.Columns["Provincial_Afip"].DefaultCellStyle.Format = "c2";
            dgv.Columns["Provincial_Afip"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["Provincial_Afip"].HeaderText = "Percepcion AFIP";

            dgv.Columns["Final_Afip"].DefaultCellStyle.Format = "c2";
            dgv.Columns["Final_Afip"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["Final_Afip"].HeaderText = "Fnal AFIP";


            dgv.Columns["Neto_Gies"].DefaultCellStyle.Format = "c2";
            dgv.Columns["Neto_Gies"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["Neto_Gies"].HeaderText = "Neto";

            dgv.Columns["Iva_Gies"].DefaultCellStyle.Format = "c2";
            dgv.Columns["Iva_Gies"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["Iva_Gies"].HeaderText = "Iva";

            dgv.Columns["Provincial_Gies"].DefaultCellStyle.Format = "c2";
            dgv.Columns["Provincial_Gies"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["Provincial_Gies"].HeaderText = "Percepcion";

            dgv.Columns["Final_Gies"].DefaultCellStyle.Format = "c2";
            dgv.Columns["Final_Gies"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["Final_Gies"].HeaderText = "Final";




            DataGridViewLinkColumn link1 = new DataGridViewLinkColumn();

            if (dgv.Columns["Reimprime"] == null)
            {
                link1.Text = "Reimprime";
                link1.DataPropertyName = "Reimprime";
                link1.Name = "Reimprime";
                link1.LinkColor = Color.LightGray;
                link1.VisitedLinkColor = Color.LightGray;
                link1.UseColumnTextForLinkValue = true;
                link1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                link1.HeaderText = "Reimprime";
                link1.DefaultCellStyle.BackColor = Color.White;
                dgv.Columns.Add(link1);
            }

            DataGridViewLinkColumn link2 = new DataGridViewLinkColumn();
            if (dgv.Columns["Graba"] == null)
            {
                link2.Text = "Graba";
                link2.DataPropertyName = "Graba";
                link2.Name = "Graba";
                link2.LinkColor = Color.LightGray;
                link2.VisitedLinkColor = Color.LightGray;
                link2.UseColumnTextForLinkValue = true;
                link2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                link2.HeaderText = "Graba";
                link2.DefaultCellStyle.BackColor = Color.White;
                dgv.Columns.Add(link2);
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            UltimoComprobante();

            fechaInicio = Convert.ToInt32(dtpDesde.Value.ToString("yyyyMMdd"));
            fechaFin = Convert.ToInt32(dtpHasta.Value.ToString("yyyyMMdd"));

            Int32 fin;
            Int32 Ultima;
            Int32 Resultado;

            Ultima = Convert.ToInt32(Factura_a.ToString());
            //            fin = Ultima - 1000;
            fin = 1;
            Resultado = 0;

            for (int i =Ultima; i > fin; i--)
            {
                Resultado=LeerComprobante(Convert.ToInt32(spPuntodeVenta.Value.ToString()), 1, i);
                if (Resultado == 1)
                    break;
            }


            Ultima = Convert.ToInt32(NotaCredito_a.ToString());
            fin = Ultima - 1000;
            Resultado = 0;
            fin = 1;

            for (int i = Ultima; i > fin; i--)
            {
                Resultado = LeerComprobante(Convert.ToInt32(spPuntodeVenta.Value.ToString()), 3, i);
                if (Resultado == 1)
                    break;
            }


            Ultima = Convert.ToInt32(Factura_b.ToString());
      //      fin = Ultima - 1000;
            Resultado = 0;
            fin = 1;

            for (int i = Ultima; i > fin; i--)
            {
                Resultado = LeerComprobante(Convert.ToInt32(spPuntodeVenta.Value.ToString()), 6, i);
                if (Resultado == 1)
                    break;
            }

            Ultima = Convert.ToInt32(NotaCRedito_b.ToString());
      //      fin = Ultima - 1000;
            Resultado = 0;
            fin = 1;

            for (int i = Ultima; i > fin; i--)
            {
                Resultado = LeerComprobante(Convert.ToInt32(spPuntodeVenta.Value.ToString()), 8, i);
                if (Resultado == 1)
                    break;
            }

            dgv.DataSource = dtIvaVentas;
            this.FormatearGrilla();

        }

       private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            String Cerror = "*";
            if (e.ColumnIndex == dgv.Columns["Error"].Index)
            {
                dgv.Rows[e.RowIndex].Cells["Error"].Style.BackColor = (dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() ==Cerror) ? Color.Red : Color.White;
            }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.Columns[e.ColumnIndex].HeaderText == "Reimprime")
            {
                try
                {
                    Oimpresion.Imprime_factura_RDLC(false, Convert.ToInt32(dgv.SelectedRows[0].Cells["id_comprobantes"].Value.ToString()));
                }
                catch { }

            }

            if (dgv.Columns[e.ColumnIndex].HeaderText == "Graba")
            {
                try
                {
                    Sobreescribe();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error : " + ex);
                }

            }

        }

        private void SobreescribeTodos_viejo()
        {
            foreach(DataGridViewRow dr in dgv.Rows)
            {
                    Int32 idIva = 0;
                    decimal mNeto, mIva, mProvincial, mFinal;
                    idIva = Convert.ToInt32(dr.Cells["id_iva_ventas"].Value.ToString());
                    mNeto = Convert.ToDecimal(dr.Cells["neto_afip"].Value.ToString());
                    mIva = Convert.ToDecimal(dr.Cells["neto_afip"].Value.ToString());
                    mProvincial = Convert.ToDecimal(dr.Cells["provincial_afip"].Value.ToString());
                    mFinal = Convert.ToDecimal(dr.Cells["final_afip"].Value.ToString());
                    
                    
                    oAfip.SobreescribeImporteLIbro(idIva, mNeto, mIva, mProvincial, mFinal);

            }
        }

        private void SobreescribeTodos()
        {
            foreach (DataGridViewRow dr in dgv.Rows)
            {
                Int32 idIva = 0, id_comprobante=0;
                decimal mNeto, mIva, mProvincial, mFinal;
                idIva = Convert.ToInt32(dr.Cells["id_iva_ventas"].Value.ToString());
                mNeto = Convert.ToDecimal(dr.Cells["neto_afip"].Value.ToString());
                mIva = Convert.ToDecimal(dr.Cells["neto_afip"].Value.ToString());
                mProvincial = Convert.ToDecimal(dr.Cells["provincial_afip"].Value.ToString());
                mFinal = Convert.ToDecimal(dr.Cells["final_afip"].Value.ToString());

                if (idIva > 0)
                { 
                    oAfip.SobreescribeImporteLIbro(idIva, mNeto, mIva, mProvincial, mFinal);
                }
                else
                {
                    oComprobantes.Numero = Convert.ToInt32(dr.Cells["Numero"].ToString());
                    oComprobantes.Punto_Venta = Convert.ToInt32(spPuntodeVenta.Value.ToString());
                    oComprobantes.Importe = Convert.ToDecimal(dr.Cells["Final_Afip"].ToString());
                    oComprobantes.Id_Comprobantes_Tipo = Convert.ToInt32(dr.Cells["id_comprobantes_tipo"].ToString());
                    oComprobantes.Fecha = DateTime.ParseExact(dr.Cells["Fecha"].ToString(), "yyyyMMdd", CultureInfo.InvariantCulture);
                    oComprobantes.Id_Punto_Cobro = Puntos_Cobros.Id_Punto;
                    oComprobantes.Id_Punto_Venta = Convert.ToInt32(dt_Punto_venta.Rows[0]["id"]);
                    oComprobantes.Id_Personal = Personal.Id_Login;
                    oComprobantes.Id_Usuarios = Convert.ToInt32(dr.Cells["id_usuario"].ToString());
                    oComprobantes.Id_Usuarios_Locaciones = Convert.ToInt32(dr.Cells["id_usuario_locacion"].ToString());
                    id_comprobante = oComprobantes.Guardar(oComprobantes);

                    oFacturacion.Id_Usuarios = Convert.ToInt32(dr.Cells["id_usuario"].ToString());
                    oFacturacion.Id_Usuarios_locacion = Convert.ToInt32(dr.Cells["id_usuario_locacion"].ToString());
                    oFacturacion.Id_Comprobantes = id_comprobante;
                    oFacturacion.Id_Comprobantes_tipo = Convert.ToInt32(dr.Cells["id_comprobantes_tipo"].ToString());
                    oFacturacion.Letra = Convert.ToString(dr.Cells["Letra"]);
                    oFacturacion.Id_Comprobantes_iva = Convert.ToInt32(dr.Cells["id_comprobantes_iva"].ToString());
                    oFacturacion.Fecha = DateTime.ParseExact(dr.Cells["Fecha"].ToString(), "yyyyMMdd", CultureInfo.InvariantCulture);
                    oFacturacion.Punto_Venta = Convert.ToInt32(dt_Punto_venta.Rows[0]["id"]);
                    oFacturacion.Numero = Convert.ToInt32(dr.Cells["Numero"].ToString());
                    oFacturacion.Cae = Convert.ToString(dr.Cells["Cae"].ToString());
                    oFacturacion.Cae_vencimiento = DateTime.ParseExact(dr.Cells["Cae_vencimiento"].ToString(), "yyyyMMdd", CultureInfo.InvariantCulture);
                    oFacturacion.Calle = Convert.ToString(dr.Cells["Calle"]);
                    oFacturacion.Altura = Convert.ToInt32(dr.Cells["Altura"]);
                    oFacturacion.Localidad = Convert.ToString(dr.Cells["Localidad"]);
                    oFacturacion.Cod_postal = Convert.ToString(dr.Cells["Codigo_Postal"]);
                    oFacturacion.Provincia = Convert.ToString(dr.Cells["Provincia"]);
                    oFacturacion.Numero_Doc = Convert.ToDouble(dr.Cells["Numero_Documento"]);
                    oFacturacion.Importe_Neto = Convert.ToDecimal(dr.Cells["Neto_Afip"]);
                    oFacturacion.Importe_Iva = Convert.ToDecimal(dr.Cells["Iva_afip"]);
                    oFacturacion.Importe_Impuesto_Interno = 0;
                    oFacturacion.Importe_Impuesto_Nacional = 0;
                    oFacturacion.Importe_Impuesto_Municipal = 0;
                    oFacturacion.Importe_Impuesto_Otros = 0;
                    oFacturacion.Importe_Impuesto_Provincial = Convert.ToDecimal(dr.Cells["Provincial_afip"]);
                    oFacturacion.Importe_Final = Convert.ToDecimal(dr.Cells["Final_Afip"]);
                    oFacturacion.Razon_Social = Convert.ToString(dr.Cells["Usuario"]);
                    oFacturacion.Fantasia = Convert.ToString(dr.Cells["Usuario"]);
                    oFacturacion.Id_Iva_Ventas = oFacturacion.GuardarIvaVentas(oFacturacion);
                    oFacturacion.Guarda_Iva_Alicuotas_Afip(oFacturacion);

                }

            }
        }

        private void Sobreescribe_Viejo()
        {
            Int32 idIva = 0;
            decimal mNeto, mIva, mProvincial, mFinal;
            idIva = Convert.ToInt32(dgv.SelectedRows[0].Cells["id_iva_ventas"].Value.ToString());
            mNeto = Convert.ToDecimal(dgv.SelectedRows[0].Cells["neto_afip"].Value.ToString());
            mIva = Convert.ToDecimal(dgv.SelectedRows[0].Cells["neto_afip"].Value.ToString());
            mProvincial = Convert.ToDecimal(dgv.SelectedRows[0].Cells["provincial_afip"].Value.ToString());
            mFinal = Convert.ToDecimal(dgv.SelectedRows[0].Cells["final_afip"].Value.ToString());
            if (idIva > 0)
                oAfip.SobreescribeImporteLIbro(idIva, mNeto, mIva, mProvincial, mFinal);

        }

        private void Sobreescribe()
        {
            Int32 idIva = 0;
            decimal mNeto, mIva, mProvincial, mFinal;
            int id_comprobante, id_Iva_Ventas;
            double Numero = 0;
            Numero = oAfip.GetUltimoComprobante(Convert.ToInt32(spPuntodeVenta.Value.ToString()), Convert.ToInt32(dgv.SelectedRows[0].Cells["id_comprobantes_tipo"].ToString()), out ErrorNro, out ErrorDescripcion);         
            idIva = Convert.ToInt32(dgv.SelectedRows[0].Cells["id_iva_ventas"].Value.ToString());
            mNeto = Convert.ToDecimal(dgv.SelectedRows[0].Cells["neto_afip"].Value.ToString());
            mIva = Convert.ToDecimal(dgv.SelectedRows[0].Cells["neto_afip"].Value.ToString());
            mProvincial = Convert.ToDecimal(dgv.SelectedRows[0].Cells["provincial_afip"].Value.ToString());
            mFinal = Convert.ToDecimal(dgv.SelectedRows[0].Cells["final_afip"].Value.ToString());
            if (idIva > 0)
                oAfip.SobreescribeImporteLIbro(idIva, mNeto, mIva, mProvincial, mFinal);
            else
            {
                oComprobantes.Numero = Convert.ToInt32(dgv.SelectedRows[0].Cells["Numero"].ToString());
                oComprobantes.Punto_Venta = Convert.ToInt32(spPuntodeVenta.Value.ToString());
                oComprobantes.Importe = Convert.ToDecimal(dgv.SelectedRows[0].Cells["Final_Afip"].ToString());
                oComprobantes.Id_Comprobantes_Tipo = Convert.ToInt32(dgv.SelectedRows[0].Cells["id_comprobantes_tipo"].ToString());
                oComprobantes.Fecha = DateTime.ParseExact(dgv.SelectedRows[0].Cells["Fecha"].ToString(), "yyyyMMdd", CultureInfo.InvariantCulture);
                oComprobantes.Id_Punto_Cobro = Puntos_Cobros.Id_Punto;
                oComprobantes.Id_Punto_Venta = Convert.ToInt32(dt_Punto_venta.Rows[0]["id"]);
                oComprobantes.Id_Personal = Personal.Id_Login;
                oComprobantes.Id_Usuarios = Convert.ToInt32(dgv.SelectedRows[0].Cells["id_usuario"].ToString());
                oComprobantes.Id_Usuarios_Locaciones = Convert.ToInt32(dgv.SelectedRows[0].Cells["id_usuario_locacion"].ToString());
                id_comprobante = oComprobantes.Guardar(oComprobantes);

                oFacturacion.Id_Usuarios = Convert.ToInt32(dgv.SelectedRows[0].Cells["id_usuario"].ToString());
                oFacturacion.Id_Usuarios_locacion = Convert.ToInt32(dgv.SelectedRows[0].Cells["id_usuario_locacion"].ToString());
                oFacturacion.Id_Comprobantes = id_comprobante;
                oFacturacion.Id_Comprobantes_tipo = Convert.ToInt32(dgv.SelectedRows[0].Cells["id_comprobantes_tipo"].ToString());
                oFacturacion.Letra = Convert.ToString(dgv.SelectedRows[0].Cells["Letra"]);
                oFacturacion.Id_Comprobantes_iva = Convert.ToInt32(dgv.SelectedRows[0].Cells["id_comprobantes_iva"].ToString());
                oFacturacion.Fecha = DateTime.ParseExact(dgv.SelectedRows[0].Cells["Fecha"].ToString(), "yyyyMMdd", CultureInfo.InvariantCulture);
                oFacturacion.Punto_Venta = Convert.ToInt32(dt_Punto_venta.Rows[0]["id"]);
                oFacturacion.Numero = Convert.ToInt32(dgv.SelectedRows[0].Cells["Numero"].ToString());
                oFacturacion.Cae = Convert.ToString(dgv.SelectedRows[0].Cells["Cae"].ToString());
                oFacturacion.Cae_vencimiento = DateTime.ParseExact(dgv.SelectedRows[0].Cells["Cae_vencimiento"].ToString(), "yyyyMMdd", CultureInfo.InvariantCulture);
                oFacturacion.Calle = Convert.ToString(dgv.SelectedRows[0].Cells["Calle"]);
                oFacturacion.Altura = Convert.ToInt32(dgv.SelectedRows[0].Cells["Altura"]);
                oFacturacion.Localidad = Convert.ToString(dgv.SelectedRows[0].Cells["Localidad"]);
                oFacturacion.Cod_postal = Convert.ToString(dgv.SelectedRows[0].Cells["Codigo_Postal"]);
                oFacturacion.Provincia = Convert.ToString(dgv.SelectedRows[0].Cells["Provincia"]);
                oFacturacion.Numero_Doc = Convert.ToDouble(dgv.SelectedRows[0].Cells["Numero_Documento"]);
                oFacturacion.Importe_Neto = Convert.ToDecimal(dgv.SelectedRows[0].Cells["Neto_Afip"]);
                oFacturacion.Importe_Iva = Convert.ToDecimal(dgv.SelectedRows[0].Cells["Iva_afip"]);
                oFacturacion.Importe_Impuesto_Interno = 0;
                oFacturacion.Importe_Impuesto_Nacional = 0;
                oFacturacion.Importe_Impuesto_Municipal = 0;
                oFacturacion.Importe_Impuesto_Otros = 0;
                oFacturacion.Importe_Impuesto_Provincial = Convert.ToDecimal(dgv.SelectedRows[0].Cells["Provincial_afip"]);
                oFacturacion.Importe_Final = Convert.ToDecimal(dgv.SelectedRows[0].Cells["Final_Afip"]);
                oFacturacion.Razon_Social = Convert.ToString(dgv.SelectedRows[0].Cells["Usuario"]);
                oFacturacion.Fantasia = Convert.ToString(dgv.SelectedRows[0].Cells["Usuario"]);
                oFacturacion.Id_Iva_Ventas= oFacturacion.GuardarIvaVentas(oFacturacion);
                oFacturacion.Guarda_Iva_Alicuotas_Afip(oFacturacion);
            }

        }

        private void btnSobreeescribe_Click(object sender, EventArgs e)
        {
            SobreescribeTodos();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
