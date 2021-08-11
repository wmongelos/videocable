using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CapaNegocios;
using System.Threading;
using CapaPresentacion;
using System.Globalization;


namespace CapaPresentacion.Informes
{
    public partial class frmInformeDeudoresENACOM : Form
    {
        public frmInformeDeudoresENACOM()
        {
            InitializeComponent();
        }

        #region PROPIEDADES
        private Thread hilo;
        private delegate void myDel();
        DataTable dtEnacom, dtGrupos;
        Usuarios_CtaCte oUsu_Ctacte = new Usuarios_CtaCte();
        Servicios oServ = new Servicios();
        DateTime FechaFinal = new DateTime();
        DateTime FechaActual = new DateTime();
        Tools oTool = new Tools();
        private static DataTable dtFinal = new DataTable();
        DataTable dtFinalInternet = new DataTable();
        DataTable dtFinalCable = new DataTable();
        int id_Grupos=0, id_actual =0, cont =1, id_ultimo = 0, contCable = 0 , contInt=0;
        decimal ImporteTotal = 0, SaldoTotal =0;
        int FilasTotales = 0;
        private DataTable dt_filtrada = new DataTable();
        string empresa;
        DataView dv;
        Configuracion oConfig = new Configuracion();
        #endregion

        #region METODOS

        private void comenzarCarga()
        {
            pgCircular.Start();
            dgv.DataSource = null;
            FechaFinal = dtpHasta.Value;
            FechaFinal = FechaFinal.AddMonths(-4).AddDays(-(dtpHasta.Value.Day-1));
            FechaActual = dtpHasta.Value;
            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
        }

        private void cargarDatos()
        {
            try
            {
                dtEnacom = oUsu_Ctacte.Listar_Deudores_Enacom(FechaFinal, id_Grupos, FechaActual);
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
            for (int i=0; i<dtEnacom.Rows.Count; i++)
            { 
            
                id_actual = Convert.ToInt32(dtEnacom.Rows[i]["id_usu"]);
                if(id_actual == id_ultimo) 
                {
                    if (Convert.ToInt32(dtEnacom.Rows[i]["id_grupo"]) == (int)Servicios_Grupos.GRUPO.CABLE)
                        contCable++;
                    else
                        contCable = 1;
                    if (Convert.ToInt32(dtEnacom.Rows[i]["id_grupo"]) == (int)Servicios_Grupos.GRUPO.INTERNET)
                        contInt++;
                    else
                        contInt = 1;
                }
                else 
                {
                    contCable = 0;
                    contInt = 0;
                }

                if(contCable == 4) 
                {
                    DataRow drFinal = dtFinalCable.NewRow();
                    drFinal["id_servicio"] = Convert.ToInt32(dtEnacom.Rows[i]["id_serv"]);
                    drFinal["id_tipo"] = Convert.ToInt32(dtEnacom.Rows[i]["id_tipo"]);
                    drFinal["id_usuario"] = Convert.ToInt32(dtEnacom.Rows[i]["id_usu"]);
                    drFinal["id_ctacte"] = Convert.ToInt32(dtEnacom.Rows[i]["id_ctacte"]);
                    drFinal["codUsu"] = Convert.ToInt32(dtEnacom.Rows[i]["codUsu"]);
                    drFinal["Servicio"] = dtEnacom.Rows[i]["Servicio"].ToString();
                    drFinal["Usuario"] = dtEnacom.Rows[i]["Usuario"].ToString();
                    drFinal["Grupo"] = dtEnacom.Rows[i]["Grupo"].ToString();
                    drFinal["Documento"] = dtEnacom.Rows[i]["Documento"].ToString();
                    drFinal["Altura"] = Convert.ToInt32(dtEnacom.Rows[i]["Altura"].ToString());
                    drFinal["Calle"] = dtEnacom.Rows[i]["Calle"].ToString();
                    drFinal["Provincia"] = dtEnacom.Rows[i]["Provincia"].ToString();
                    drFinal["Localidad"] = dtEnacom.Rows[i]["Localidad"].ToString();
                    drFinal["Cod_Postal"] = dtEnacom.Rows[i]["Cod_Postal"].ToString();
                    drFinal["Fecha_1"] = Convert.ToDecimal(dtEnacom.Rows[i - 3]["Saldo"]);
                    drFinal["Fecha_2"] = Convert.ToDecimal(dtEnacom.Rows[i - 2]["Saldo"]);
                    drFinal["Fecha_3"] = Convert.ToDecimal(dtEnacom.Rows[i - 1]["Saldo"]);
                    drFinal["Fecha_4"] = Convert.ToDecimal(dtEnacom.Rows[i]["Saldo"]);
                    SaldoTotal = Convert.ToDecimal(dtEnacom.Rows[i]["Saldo"]) + Convert.ToDecimal(dtEnacom.Rows[i - 1]["Saldo"]) + Convert.ToDecimal(dtEnacom.Rows[i - 2]["Saldo"]) + Convert.ToDecimal(dtEnacom.Rows[i - 3]["Saldo"]);
                    drFinal["Saldo"] = SaldoTotal;
                    dtFinalCable.Rows.Add(drFinal);
                }
                else if(contInt == 4) 
                {
                    DataRow drFinal = dtFinalInternet.NewRow();
                    drFinal["id_servicio"] = Convert.ToInt32(dtEnacom.Rows[i]["id_serv"]);
                    drFinal["id_tipo"] = Convert.ToInt32(dtEnacom.Rows[i]["id_tipo"]);
                    drFinal["id_usuario"] = Convert.ToInt32(dtEnacom.Rows[i]["id_usu"]);
                    drFinal["id_ctacte"] = Convert.ToInt32(dtEnacom.Rows[i]["id_ctacte"]);
                    drFinal["codUsu"] = Convert.ToInt32(dtEnacom.Rows[i]["codUsu"]);
                    drFinal["Servicio"] = dtEnacom.Rows[i]["Servicio"].ToString();
                    drFinal["Usuario"] = dtEnacom.Rows[i]["Usuario"].ToString();
                    drFinal["Grupo"] = dtEnacom.Rows[i]["Grupo"].ToString();
                    drFinal["Documento"] = dtEnacom.Rows[i]["Documento"].ToString();
                    drFinal["Altura"] = Convert.ToInt32(dtEnacom.Rows[i]["Altura"].ToString());
                    drFinal["Calle"] = dtEnacom.Rows[i]["Calle"].ToString();
                    drFinal["Provincia"] = dtEnacom.Rows[i]["Provincia"].ToString();
                    drFinal["Localidad"] = dtEnacom.Rows[i]["Localidad"].ToString();
                    drFinal["Cod_Postal"] = dtEnacom.Rows[i]["Cod_Postal"].ToString();
                    drFinal["Fecha_1"] = Convert.ToDecimal(dtEnacom.Rows[i -3]["Saldo"]);
                    drFinal["Fecha_2"] = Convert.ToDecimal(dtEnacom.Rows[i - 2]["Saldo"]);
                    drFinal["Fecha_3"] = Convert.ToDecimal(dtEnacom.Rows[i - 1]["Saldo"]);
                    drFinal["Fecha_4"] = Convert.ToDecimal(dtEnacom.Rows[i]["Saldo"]);
                    SaldoTotal = Convert.ToDecimal(dtEnacom.Rows[i]["Saldo"]) + Convert.ToDecimal(dtEnacom.Rows[i - 1]["Saldo"]) + Convert.ToDecimal(dtEnacom.Rows[i - 2]["Saldo"]) + Convert.ToDecimal(dtEnacom.Rows[i - 3]["Saldo"]);
                    drFinal["Saldo"] = SaldoTotal;
                    dtFinalInternet.Rows.Add(drFinal);
                }
                id_ultimo = Convert.ToInt32(dtEnacom.Rows[i]["id_usu"]);
            }
            foreach (DataRow dr_Cable_Final in dtFinalCable.Rows)
                dtFinal.ImportRow(dr_Cable_Final);
            foreach (DataRow dr_Internet_Final in dtFinalInternet.Rows)
                dtFinal.ImportRow(dr_Internet_Final);
            
            DataView dv = dtFinal.DefaultView;
            dv.Sort = "codUsu asc";
           dtFinal = dv.ToTable();

            dgv.DataSource = dtFinal;
            for (int i = 0; i < dgv.ColumnCount; i++)
                dgv.Columns[i].Visible = false;

            dgv.Columns["codUsu"].Visible = true;
            dgv.Columns["servicio"].Visible = true;
            dgv.Columns["usuario"].Visible = true;
            dgv.Columns["fecha_1"].Visible = true;
            dgv.Columns["fecha_2"].Visible = true;
            dgv.Columns["fecha_3"].Visible = true;
            dgv.Columns["fecha_4"].Visible = true;
            dgv.Columns["grupo"].Visible = true;
            dgv.Columns["saldo"].Visible = true;

            dgv.Columns["codUsu"].HeaderText = "Codigo";
            dgv.Columns["servicio"].HeaderText = "Servicio";
            dgv.Columns["usuario"].HeaderText = "Usuario";
            dgv.Columns["fecha_4"].HeaderText = dtpHasta.Value.AddMonths(-3).AddDays(-(dtpHasta.Value.Day - 1)).ToString("MMMM", CultureInfo.CreateSpecificCulture("es")).ToUpper();
            dgv.Columns["fecha_3"].HeaderText = dtpHasta.Value.AddMonths(-2).ToString("MMMM", CultureInfo.CreateSpecificCulture("es")).ToUpper();
            dgv.Columns["fecha_2"].HeaderText = dtpHasta.Value.AddMonths(-1).ToString("MMMM", CultureInfo.CreateSpecificCulture("es")).ToUpper();
            dgv.Columns["fecha_1"].HeaderText = dtpHasta.Value.ToString("MMMM", CultureInfo.CreateSpecificCulture("es")).ToUpper();
            dgv.Columns["grupo"].HeaderText = "Grupo del Servicio";
            dgv.Columns["saldo"].HeaderText = "Saldo/Deuda";

            dgv.Columns["fecha_1"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["fecha_1"].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("en-US");
            dgv.Columns["fecha_1"].DefaultCellStyle.Format = "C2";
            dgv.Columns["fecha_2"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["fecha_2"].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("en-US");
            dgv.Columns["fecha_2"].DefaultCellStyle.Format = "C2";
            dgv.Columns["fecha_3"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["fecha_3"].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("en-US");
            dgv.Columns["fecha_3"].DefaultCellStyle.Format = "C2";
            dgv.Columns["fecha_4"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["fecha_4"].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("en-US");
            dgv.Columns["fecha_4"].DefaultCellStyle.Format = "C2";
            dgv.Columns["Saldo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["Saldo"].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("en-US");
            dgv.Columns["Saldo"].DefaultCellStyle.Format = "C2";

            btnBuscar.Enabled = true;
            dtpHasta.Enabled = true;
            btnExportar.Enabled = true;
            label1.Visible = true;
            txtFiltro.Visible = true;
            calcula_Filas_Importe();
            lblFilas.Text = String.Format("Total de Registros: [{0}]", FilasTotales);
            lblSaldo.Text = String.Format("Saldo total: ${0}", ImporteTotal);

        }

        private void calcula_Filas_Importe()
        {
            ImporteTotal = 0;
            FilasTotales = 0;
            if (dgv.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.Visible)
                    {
                        ImporteTotal += Convert.ToDecimal(row.Cells["Saldo"].Value);
                        FilasTotales++;
                    }
                }
            }
        }

        private void LlenardtFinal()
        {
            dtFinal.Reset();
            DataColumn dc_Id_Serv = new DataColumn()
            {
                ColumnName = "Id_Servicio",
                DataType = typeof(int),
                DefaultValue = 0
            }; dtFinal.Columns.Add(dc_Id_Serv);
            DataColumn dc_id_Tipo = new DataColumn()
            {
                ColumnName = "Id_Tipo",
                DataType = typeof(int),
                DefaultValue = 0
            }; dtFinal.Columns.Add(dc_id_Tipo);
            DataColumn dc_id_usu = new DataColumn()
            {
                ColumnName = "Id_Usuario",
                DataType = typeof(int),
                DefaultValue = 0
            }; dtFinal.Columns.Add(dc_id_usu);
            DataColumn dc_id_Ctacte = new DataColumn()
            {
                ColumnName = "Id_Ctacte",
                DataType = typeof(int),
                DefaultValue = 0
            }; dtFinal.Columns.Add(dc_id_Ctacte);
            DataColumn dc_codUsu = new DataColumn()
            {
                ColumnName = "codUsu",
                DataType = typeof(int),
                DefaultValue = 0
            }; dtFinal.Columns.Add(dc_codUsu);
            DataColumn dc_servicio = new DataColumn()
            {
                ColumnName = "Servicio",
                DataType = typeof(string),
                DefaultValue = ""
            }; dtFinal.Columns.Add(dc_servicio);
            DataColumn dcFac = new DataColumn()
            {
                ColumnName = "Factura",
                DataType = typeof(string),
                DefaultValue = "Factura"
            }; dtFinal.Columns.Add(dcFac);
            DataColumn dc_usuario = new DataColumn()
            {
                ColumnName = "Usuario",
                DataType = typeof(string),
                DefaultValue = ""
            }; dtFinal.Columns.Add(dc_usuario);
            DataColumn dcTipoDocumento = new DataColumn()
            {
                ColumnName = "TipoDocumento",
                DataType = typeof(string),
                DefaultValue = "DNI"
            }; dtFinal.Columns.Add(dcTipoDocumento);
            DataColumn dcDocumento = new DataColumn()
            {
                ColumnName = "Documento",
                DataType = typeof(string),
                DefaultValue = ""
            }; dtFinal.Columns.Add(dcDocumento);
            DataColumn dcProvincia = new DataColumn()
            {
                ColumnName = "Provincia",
                DataType = typeof(string),
                DefaultValue = ""
            }; dtFinal.Columns.Add(dcProvincia);
            DataColumn dcCalle = new DataColumn()
            {
                ColumnName = "Calle",
                DataType = typeof(string),
                DefaultValue = ""
            }; dtFinal.Columns.Add(dcCalle);
            DataColumn dcAltura = new DataColumn()
            {
                ColumnName = "Altura",
                DataType = typeof(int),
                DefaultValue = 0
            }; dtFinal.Columns.Add(dcAltura);
            DataColumn dcLocalidad = new DataColumn()
            {
                ColumnName = "Localidad",
                DataType = typeof(string),
                DefaultValue = ""
            }; dtFinal.Columns.Add(dcLocalidad);
            DataColumn dcCodigoPostal = new DataColumn()
            {
                ColumnName = "Cod_Postal",
                DataType = typeof(string),
                DefaultValue = ""
            }; dtFinal.Columns.Add(dcCodigoPostal);

            DataColumn dcEmpresa = new DataColumn()
            {
                ColumnName = "Empresa",
                DataType = typeof(string),
                DefaultValue = empresa
            }; dtFinal.Columns.Add(dcEmpresa);
            DataColumn dc_Grupo = new DataColumn()
            {
                ColumnName = "Grupo",
                DataType = typeof(string),
                DefaultValue = ""
            }; dtFinal.Columns.Add(dc_Grupo);
            DataColumn dc_fecha_1 = new DataColumn()
            {
                ColumnName = "Fecha_1",
                DataType = typeof(decimal),
                DefaultValue = 0
            }; dtFinal.Columns.Add(dc_fecha_1);
            DataColumn dc_fecha_2 = new DataColumn()
            {
                ColumnName = "Fecha_2",
                DataType = typeof(decimal),
                DefaultValue = 0
            }; dtFinal.Columns.Add(dc_fecha_2);
            DataColumn dc_fecha_3 = new DataColumn()
            {
                ColumnName = "Fecha_3",
                DataType = typeof(decimal),
                DefaultValue = 0
            }; dtFinal.Columns.Add(dc_fecha_3);
            DataColumn dc_fecha_4 = new DataColumn()
            {
                ColumnName = "Fecha_4",
                DataType = typeof(decimal),
                DefaultValue = 0
            }; dtFinal.Columns.Add(dc_fecha_4);
            DataColumn dc_saldo = new DataColumn()
            {
                ColumnName = "Saldo",
                DataType = typeof(decimal),
                DefaultValue = 0
            }; dtFinal.Columns.Add(dc_saldo);
        }

        private void LlenardtFinalCable()
        {
            DataColumn dc_Id_Serv = new DataColumn()
            {
                ColumnName = "Id_Servicio",
                DataType = typeof(int),
                DefaultValue = 0
            }; dtFinalCable.Columns.Add(dc_Id_Serv);
            DataColumn dc_id_Tipo = new DataColumn()
            {
                ColumnName = "Id_Tipo",
                DataType = typeof(int),
                DefaultValue = 0
            }; dtFinalCable.Columns.Add(dc_id_Tipo);
            DataColumn dc_id_usu = new DataColumn()
            {
                ColumnName = "Id_Usuario",
                DataType = typeof(int),
                DefaultValue = 0
            }; dtFinalCable.Columns.Add(dc_id_usu);
            DataColumn dc_id_Ctacte = new DataColumn()
            {
                ColumnName = "Id_Ctacte",
                DataType = typeof(int),
                DefaultValue = 0
            }; dtFinalCable.Columns.Add(dc_id_Ctacte);
            DataColumn dc_codUsu = new DataColumn()
            {
                ColumnName = "codUsu",
                DataType = typeof(int),
                DefaultValue = 0
            }; dtFinalCable.Columns.Add(dc_codUsu);
            DataColumn dc_servicio = new DataColumn()
            {
                ColumnName = "Servicio",
                DataType = typeof(string),
                DefaultValue = ""
            }; dtFinalCable.Columns.Add(dc_servicio);
            DataColumn dc_usuario = new DataColumn()
            {
                ColumnName = "Usuario",
                DataType = typeof(string),
                DefaultValue = ""
            }; dtFinalCable.Columns.Add(dc_usuario);
            DataColumn dcTipoDoc = new DataColumn()
            {
                ColumnName = "TipoDocumento",
                DataType = typeof(string),
                DefaultValue = "DNI"
            }; dtFinalCable.Columns.Add(dcTipoDoc);
            DataColumn dcDoc = new DataColumn()
            {
                ColumnName = "Documento",
                DataType = typeof(string),
                DefaultValue = ""
            }; dtFinalCable.Columns.Add(dcDoc);
            DataColumn dc_Grupo = new DataColumn()
            {
                ColumnName = "Grupo",
                DataType = typeof(string),
                DefaultValue = ""
            }; dtFinalCable.Columns.Add(dc_Grupo);
            DataColumn dcProvincia = new DataColumn()
            {
                ColumnName = "Provincia",
                DataType = typeof(string),
                DefaultValue = ""
            }; dtFinalCable.Columns.Add(dcProvincia);
            DataColumn dcCalle = new DataColumn()
            {
                ColumnName = "Calle",
                DataType = typeof(string),
                DefaultValue = ""
            }; dtFinalCable.Columns.Add(dcCalle);
            DataColumn dcAltura = new DataColumn()
            {
                ColumnName = "Altura",
                DataType = typeof(int),
                DefaultValue = 0
            }; dtFinalCable.Columns.Add(dcAltura);
            DataColumn dcLocalidad = new DataColumn()
            {
                ColumnName = "Localidad",
                DataType = typeof(string),
                DefaultValue = ""
            }; dtFinalCable.Columns.Add(dcLocalidad);
            DataColumn dcCodigoPostal = new DataColumn()
            {
                ColumnName = "Cod_Postal",
                DataType = typeof(string),
                DefaultValue = ""
            }; dtFinalCable.Columns.Add(dcCodigoPostal);
            DataColumn dc_fecha_1 = new DataColumn()
            {
                ColumnName = "Fecha_1",
                DataType = typeof(decimal),
                DefaultValue = 0
            }; dtFinalCable.Columns.Add(dc_fecha_1);
            DataColumn dc_fecha_2 = new DataColumn()
            {
                ColumnName = "Fecha_2",
                DataType = typeof(decimal),
                DefaultValue = 0
            }; dtFinalCable.Columns.Add(dc_fecha_2);
            DataColumn dc_fecha_3 = new DataColumn()
            {
                ColumnName = "Fecha_3",
                DataType = typeof(decimal),
                DefaultValue = 0
            }; dtFinalCable.Columns.Add(dc_fecha_3);
            DataColumn dc_fecha_4 = new DataColumn()
            {
                ColumnName = "Fecha_4",
                DataType = typeof(decimal),
                DefaultValue = 0
            }; dtFinalCable.Columns.Add(dc_fecha_4);
            DataColumn dc_saldo = new DataColumn()
            {
                ColumnName = "Saldo",
                DataType = typeof(decimal),
                DefaultValue = 0
            }; dtFinalCable.Columns.Add(dc_saldo);
        }

        private void btnGeneraTxt_Click(object sender, EventArgs e)
        {
            if(dtFinal.Rows.Count > 0) 
            { 
                string[] Cadenas = new string[dtFinal.Rows.Count + 1];
                for (int i = 1; i < dtFinal.Rows.Count + 1; i++)
                {
                    Cadenas[i] = dtFinal.Rows[i - 1]["Documento"].ToString() + "," + dtFinal.Rows[i - 1]["TipoDocumento"].ToString() + "," + dtFinal.Rows[i - 1]["Calle"].ToString() + "," + dtFinal.Rows[i - 1]["Altura"].ToString() + "," + dtFinal.Rows[i - 1]["Localidad"].ToString() + "," + dtFinal.Rows[i - 1]["Provincia"].ToString() + "," + dtFinal.Rows[i - 1]["Cod_Postal"].ToString() + "," + dtFinal.Rows[i - 1]["Empresa"].ToString() + "," + dtFinal.Rows[i - 1]["Grupo"].ToString() + "," + dtFinal.Rows[i - 1]["Factura"].ToString() + "," + dtFinal.Rows[i - 1]["Fecha_1"].ToString() + "," + dtFinal.Rows[i - 1]["Fecha_2"].ToString() + "," + dtFinal.Rows[i - 1]["Fecha_3"].ToString() + "," + dtFinal.Rows[i - 1]["Fecha_4"].ToString() + "," + dtFinal.Rows[i - 1]["Saldo"].ToString();
                }
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Text Files (*.csv)|*.csv|All Files (*.*)|*.*";
                saveDialog.DefaultExt = "csv";
                saveDialog.RestoreDirectory = true;
                saveDialog.FilterIndex = 2;
                if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    oTool.ExportarCvs(saveDialog.FileName, 1, Cadenas);
                    MessageBox.Show("El archivo se exporto correctamente");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al exportar el archivo.");
                }
            }
        }

        private void LlenarDtFinalInternet()
        {
            DataColumn dc_Id_Serv = new DataColumn()
            {
                ColumnName = "Id_Servicio",
                DataType = typeof(int),
                DefaultValue = 0
            }; dtFinalInternet.Columns.Add(dc_Id_Serv);
            DataColumn dc_id_Tipo = new DataColumn()
            {
                ColumnName = "Id_Tipo",
                DataType = typeof(int),
                DefaultValue = 0
            }; dtFinalInternet.Columns.Add(dc_id_Tipo);
            DataColumn dc_id_usu = new DataColumn()
            {
                ColumnName = "Id_Usuario",
                DataType = typeof(int),
                DefaultValue = 0
            }; dtFinalInternet.Columns.Add(dc_id_usu);
            DataColumn dc_id_Ctacte = new DataColumn()
            {
                ColumnName = "Id_Ctacte",
                DataType = typeof(int),
                DefaultValue = 0
            }; dtFinalInternet.Columns.Add(dc_id_Ctacte);
            DataColumn dc_codUsu = new DataColumn()
            {
                ColumnName = "codUsu",
                DataType = typeof(int),
                DefaultValue = 0
            }; dtFinalInternet.Columns.Add(dc_codUsu);
            DataColumn dc_servicio = new DataColumn()
            {
                ColumnName = "Servicio",
                DataType = typeof(string),
                DefaultValue = ""
            }; dtFinalInternet.Columns.Add(dc_servicio);
            DataColumn dc_usuario = new DataColumn()
            {
                ColumnName = "Usuario",
                DataType = typeof(string),
                DefaultValue = ""
            }; dtFinalInternet.Columns.Add(dc_usuario);
            DataColumn dcTipoDoc = new DataColumn()
            {
                ColumnName = "TipoDocumento",
                DataType = typeof(string),
                DefaultValue = "DNI"
            }; dtFinalInternet.Columns.Add(dcTipoDoc);
            DataColumn dcDocumento = new DataColumn()
            {
                ColumnName = "Documento",
                DataType = typeof(string),
                DefaultValue = ""
            }; dtFinalInternet.Columns.Add(dcDocumento);
            DataColumn dcProvincia = new DataColumn()
            {
                ColumnName = "Provincia",
                DataType = typeof(string),
                DefaultValue = ""
            }; dtFinalInternet.Columns.Add(dcProvincia);
            DataColumn dcCalle = new DataColumn()
            {
                ColumnName = "Calle",
                DataType = typeof(string),
                DefaultValue = ""
            }; dtFinalInternet.Columns.Add(dcCalle);
            DataColumn dcAltura = new DataColumn()
            {
                ColumnName = "Altura",
                DataType = typeof(int),
                DefaultValue = 0
            }; dtFinalInternet.Columns.Add(dcAltura);
            DataColumn dcLocalidad = new DataColumn()
            {
                ColumnName = "Localidad",
                DataType = typeof(string),
                DefaultValue = ""
            }; dtFinalInternet.Columns.Add(dcLocalidad);
            DataColumn dcCodigoPostal = new DataColumn()
            {
                ColumnName = "Cod_Postal",
                DataType = typeof(string),
                DefaultValue = ""
            }; dtFinalInternet.Columns.Add(dcCodigoPostal);
            DataColumn dc_Grupo = new DataColumn()
            {
                ColumnName = "Grupo",
                DataType = typeof(string),
                DefaultValue = ""
            }; dtFinalInternet.Columns.Add(dc_Grupo);
            DataColumn dc_fecha_1 = new DataColumn()
            {
                ColumnName = "Fecha_1",
                DataType = typeof(decimal),
                DefaultValue = 0
            }; dtFinalInternet.Columns.Add(dc_fecha_1);
            DataColumn dc_fecha_2 = new DataColumn()
            {
                ColumnName = "Fecha_2",
                DataType = typeof(decimal),
                DefaultValue = 0
            }; dtFinalInternet.Columns.Add(dc_fecha_2);
            DataColumn dc_fecha_3 = new DataColumn()
            {
                ColumnName = "Fecha_3",
                DataType = typeof(decimal),
                DefaultValue = 0
            }; dtFinalInternet.Columns.Add(dc_fecha_3);
            DataColumn dc_fecha_4 = new DataColumn()
            {
                ColumnName = "Fecha_4",
                DataType = typeof(decimal),
                DefaultValue = 0
            }; dtFinalInternet.Columns.Add(dc_fecha_4);
            DataColumn dc_saldo = new DataColumn()
            {
                ColumnName = "Saldo",
                DataType = typeof(decimal),
                DefaultValue = 0
            }; dtFinalInternet.Columns.Add(dc_saldo);
        }
        #endregion

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmPopUp popUp = new frmPopUp();
            popUp.Formulario = new frmUsuariosCtaCteConsultaNuevo(Convert.ToInt32(dgv.SelectedRows[0].Cells["Id_Usuario"].Value.ToString()), 0);
            popUp.Maximizar = true;
            popUp.ShowDialog();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            dtFinal.Clear();

            this.Close();
        }

        private void frmInformeDeudoresENACOM_Load(object sender, EventArgs e)
        {
            empresa = oConfig.GetValor_C("Empresa");
            dtpHasta.Value = DateTime.Now;
            dtGrupos = oServ.ListarGrupos();
            label1.Visible = false;
            txtFiltro.Visible = false;
            LlenardtFinal();
            LlenarDtFinalInternet();
            LlenardtFinalCable();
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            dtFinal.DefaultView.RowFilter = String.Format("Convert([codusu], System.String) LIKE '%{0}%' OR servicio LIKE '%{0}%' OR usuario LIKE '%{0}%' OR grupo LIKE '%{0}%' OR Convert([saldo], System.String) LIKE '%{0}%' ", txtFiltro.Text);
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 0)
            {
                Tools tools = new Tools();
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    tools.ExportDataTableToExcel(dtFinal, "Deudores ENACOM");
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al exportar a excel");
                }
                finally { this.Cursor = Cursors.Default; }
            }
            else
                MessageBox.Show("Grilla vacia");
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            txtFiltro.Visible = false;
            btnBuscar.Enabled = false;
            dtpHasta.Enabled = false;
            btnExportar.Enabled = false;
            comenzarCarga();
        }
    }
}
