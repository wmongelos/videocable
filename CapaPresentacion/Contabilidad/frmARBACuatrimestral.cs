using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CapaPresentacion;
using CapaNegocios;
using System.Threading;
using System.Globalization;
using System.Text.RegularExpressions;

namespace CapaPresentacion.Informes
{
    public partial class frmARBACuatrimestral : Form
    {

        #region PROPIEDADES

        private Thread hilo;
        private delegate void myDel();
        private delegate void myDel2();
        Usuarios_CtaCte_Det oUsu_Ctacte_Det = new Usuarios_CtaCte_Det();
        private DataTable dt_Cable = new DataTable();
        private DataTable dt_Internet = new DataTable();
        private DataTable dt_Cable_Final = new DataTable();
        private DataTable dt_Internet_Final = new DataTable();
        private DataTable dt_Cable_Internet = new DataTable();
        private static DataTable dt_Final = new DataTable();
        Servicios oSer = new Servicios();
        DateTime desde, hasta;
        int Grupo = 0;
        decimal Importe_Internet , Importe_Cable , Importe_Total_Ambos;
        private DataTable dt_Grupo = new DataTable();
        Decimal ImporteTotal;
        Int32 FilasTotales;                    
        Tools oTool = new Tools();
        #endregion

        public frmARBACuatrimestral()
        {
            InitializeComponent();
        }

        #region METODOS
        private void comenzarCarga()
        {
            pgCircular.Start();
            pgCircular.Enabled = true;
            lblEstado.Enabled = true;
            tbArbaCuatrimestral.Enabled = true;
          
            dgv.DataSource = null;

            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
        }

        private void cargarDatos()
        {
            try
            {
                dt_Cable = oUsu_Ctacte_Det.Listado_ARBA_Cuatrimestral(desde,hasta,(int)Servicios_Grupos.GRUPO.CABLE,Importe_Cable);
                dt_Internet = oUsu_Ctacte_Det.Listado_ARBA_Cuatrimestral(desde, hasta, (int)Servicios_Grupos.GRUPO.INTERNET, Importe_Internet);
                myDel MD = new myDel(asignarDatos);
                this.Invoke(MD, new object[] { });
                myDel2 MD2 = new myDel2(asignarDatos2);
                this.Invoke(MD2, new object[] { });

                pgCircular.Stop();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Informacion" + ex.Message);
            }

        }

        private void asignarDatos()
        {
            lblEstado.Text = "Procesando información";
            llenardtFinal();
            btnExportarExcel.Enabled = true;
            btnGeneraTxt.Enabled = true;
        }
        private void asignarDatos2()
        {
            lblEstado.Text = "Ajustando grilla";

            dgv.DataSource = dt_Final;
            FormatearDGV();
            AgregarColumna();
            CalcularImporteYFilasTotales();
            lblTotalRegistros.Text = "Total de Registros: " + FilasTotales.ToString();
            lblImporteTotal.Text = "Total:" + ImporteTotal.ToString("c2");
            foreach (Control item in this.Controls)
            {
                if (item.Name != "pgCircular" && item.Name != "lblEstado" && item.Name != "tbArbaCuatrimestral" && item.Name != "tbDatosFiltrados" && item.Name != "lblTituloHeader")
                    item.Enabled = true;
                else
                {
                    pgCircular.Stop();
                    pgCircular.Visible = false;
                    lblEstado.Visible = false;
                }
            }
        }
        private void FormatearDGV()
        {

            dgv.Columns["Id_Grupo"].Visible = false;
            dgv.Columns["id_usu_serv"].Visible = false;
            dgv.Columns["id_ctactedet"].Visible = false;
            dgv.Columns["id_ctacte"].Visible = false;
            dgv.Columns["id_Tipo_doc"].Visible = false;
            dgv.Columns["id_modalidad"].Visible = false;
            dgv.Columns["Id_Localidad"].Visible = false;
            dgv.Columns["id_usuario"].Visible = false;
            dgv.Columns["tipo_prestacion"].Visible = false;


        }
        private void llenardtFinal()
        {
            dt_Cable_Internet = dt_Cable.Clone();
            dt_Cable_Final = dt_Cable.Clone();
            dt_Internet_Final = dt_Internet.Clone();
            int id_Usuario_cable = 0, id_ctacte_Cable =0;
            int id_Usuario_internet = 0, id_ctacte_Internet=0;
            decimal Importe_Total = 0;

            foreach (DataRow drCable in dt_Cable.Rows)
            {
                id_Usuario_cable = Convert.ToInt32(drCable["id_usuario"]);
                id_ctacte_Cable = Convert.ToInt32(drCable["id_ctacte"]);
                foreach(DataRow drInternet in dt_Internet.Rows) 
                {
                    Importe_Total = 0;
                    id_Usuario_internet = Convert.ToInt32(drInternet["id_usuario"]);
                    id_ctacte_Internet = Convert.ToInt32(drInternet["id_ctacte"]);
                    if(id_Usuario_cable == id_Usuario_internet && id_ctacte_Cable == id_ctacte_Internet) 
                    {
                        Importe_Total = Convert.ToDecimal(drCable["Importe"]) + Convert.ToDecimal(drInternet["Importe"]);
                        DataRow drCable_Internet = dt_Cable_Internet.NewRow();
                        drCable_Internet["id_usu_serv"] = 0;
                        drCable_Internet["id_ctactedet"] = 0;
                        drCable_Internet["id_Ctacte"] = drCable["id_Ctacte"];
                        drCable_Internet["Fecha"] = drCable["Fecha"];
                        drCable_Internet["Comprobante"] = drCable["Comprobante"];
                        drCable_Internet["id_usuario"] = drCable["id_usuario"];
                        drCable_Internet["Usuario"] = drCable["Usuario"];
                        drCable_Internet["periodo"] = drCable["periodo"];
                        drCable_Internet["importe"] = Importe_Total;
                        drCable_Internet["grupo"] = "CABLE + INTERNET";
                        drCable_Internet["cuit"] = drCable["cuit"];
                        drCable_Internet["documento"] = drCable["documento"];
                        drCable_Internet["id_tipo_doc"] = drCable["id_tipo_doc"];
                        drCable_Internet["tipodoc"] = drCable["tipodoc"];
                        drCable_Internet["tipo_prestacion"] = drCable["tipo_prestacion"];
                        drCable_Internet["estadoabonado"] = drCable["estadoabonado"];
                        drCable_Internet["id_modalidad"] = drCable["id_modalidad"];
                        drCable_Internet["modalidad"] = drCable["modalidad"];
                        drCable_Internet["celular"] = drCable["celular"];
                        drCable_Internet["telefono"] = drCable["telefono"];
                        drCable_Internet["calle"] = drCable["calle"];
                        drCable_Internet["altura"] = drCable["altura"];
                        drCable_Internet["codigopostal"] = drCable["codigopostal"];
                        drCable_Internet["id_localidad"] = drCable["id_localidad"];
                        drCable_Internet["localidad"] = drCable["localidad"];
                        drCable_Internet["email"] = drCable["email"];
                        drCable_Internet["id_grupo"] = 3;
                        dt_Cable_Internet.Rows.Add(drCable_Internet);
                    }
                }
            }

            dt_Cable_Final = dt_Cable.AsEnumerable().Where(r =>
                    !dt_Cable_Internet.AsEnumerable().Any(w =>
                        w.Field<int>("id_Usuario") == r.Field<int>("id_usuario") && w.Field<int>("id_ctacte") == r.Field<int>("id_ctacte")))
                    .CopyToDataTable<DataRow>();

            dt_Internet_Final = dt_Internet.AsEnumerable().Where(r =>
                    !dt_Cable_Internet.AsEnumerable().Any(w =>
                        w.Field<int>("id_Usuario") == r.Field<int>("id_usuario") && w.Field<int>("id_ctacte") == r.Field<int>("id_ctacte")))
                    .CopyToDataTable<DataRow>();

            if(dt_Final.Rows.Count == 0)
                 dt_Final = dt_Cable_Internet.Clone();

            foreach(DataRow dr_Cable_Final in dt_Cable_Final.Rows)        
                dt_Final.ImportRow(dr_Cable_Final);
            foreach (DataRow dr_Internet_Final in dt_Internet_Final.Rows)
                dt_Final.ImportRow(dr_Internet_Final);
            foreach (DataRow dr_Cable_Internet in dt_Cable_Internet.Rows)
                dt_Final.ImportRow(dr_Cable_Internet);


        }

        private void CalcularImporteYFilasTotales()
        {
            ImporteTotal = 0;
            FilasTotales = 0;
            if (dgv.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.Visible)
                    {
                        ImporteTotal += Convert.ToDecimal(row.Cells["Importe"].Value);
                        FilasTotales++;
                    }
                }
            }
        }

        private void AgregarColumna()
        {

                DataGridViewLinkColumn ctotal = new DataGridViewLinkColumn();
                ctotal.Text = "Ver Detalle";
                ctotal.DataPropertyName = "Detalle";
                ctotal.Name = "Detalle";
                ctotal.LinkColor = Color.DarkOrchid;
                ctotal.VisitedLinkColor = Color.Violet;
                ctotal.UseColumnTextForLinkValue = true;
                ctotal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                ctotal.Width = 100;
                ctotal.HeaderText = "Detalle";
                dgv.Columns.Add(ctotal);
        }
        #endregion

        #region EVENTOS
        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmARBACuatrimestral_Load(object sender, EventArgs e)
        {

            dt_Grupo = oSer.ListarGrupos();
            dt_Grupo.Rows.Add(3, "INTERNET+CABLE");
            dt_Grupo.AcceptChanges();
            dtpDesde.Value = new DateTime(2020,10,1);
            dtpHasta.Value = new DateTime(2021, 1, 31);
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 0)
            {
                Tools tools = new Tools();
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    tools.ExportDataTableToExcel(dt_Final, "ARBA Cuatrimestral");
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

        private void txtFiltrar_TextChanged(object sender, EventArgs e)
        {
            dt_Final.DefaultView.RowFilter = String.Format("Convert([Importe], System.String) LIKE '%{0}%' OR Convert([Fecha], System.String) LIKE '%{0}%' OR Usuario LIKE '%{0}%' OR Comprobante LIKE '%{0}%' ", txtFiltrar.Text);
        }

        private void dgv_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgv.Columns[e.ColumnIndex].Name == "Detalle")
            {
                using (frmPopUp frm = new frmPopUp())
                {
                    frmARBA_Detalle frmABM = new frmARBA_Detalle();
                    frmABM.id_Ctacte = Convert.ToInt32(dgv.SelectedRows[0].Cells["id_ctacte"].Value);
                    frm.Formulario = frmABM;
                    frm.Maximizar = false;

                    if (frm.ShowDialog() == DialogResult.OK)
                        cargarDatos();
                }

                asignarDatos();
            }
        }

        private void frmARBACuatrimestral_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnGeneraTxt_Click(object sender, EventArgs e)
        {
            string[] Cadenas = new string[dt_Final.Rows.Count + 1];
            char pad = ' ';

            //
            string cuit;
            string tipoDoc;
            string numDoc;
            string nombreyApellido;
            string prestacion;
            string montoTotal;
            string periodo;
            string celular;
            string calle;
            string suministroAltura = "";
            string sinSuministroAltura = "";
            string piso = "";
            string[] pisoSlpit;
            string depto = "";
            string codigoPostal = "";
            string localidad = "";
            string telefono = "";
            string email = "";
            string tipoOperacion = "";

            //
            Cadenas[0] = "CUIT" + 
                "Tipo_Doc" + 
                "Numero_Documento" + 
                "NombreyApellido" + 
                "Prestacion" + 
                "MontoTotal" + 
                "Periodo" + 
                "Celular" + 
                "Calle" + 
                "Altura/Numero" + 
                "Sin_Numero" + 
                "Piso" + 
                "Departamento" + 
                "Codigo_Postal" + 
                "Localidad" + 
                "Telefono" + 
                "Email" + 
                "Tipo_Operacion";
            for (int i = 0; i < dt_Final.Rows.Count; i++)
            {
                cuit = dt_Final.Rows[i]["cuit"].ToString();
                if (cuit.Length > 11)
                    cuit = cuit.Substring(0, 11);

                if (cuit == "" || cuit == "0")
                    cuit = cuit.PadLeft(11,'0');
                tipoDoc = "1";
                numDoc = dt_Final.Rows[i]["Documento"].ToString();
                if (numDoc.Length != 8)
                    numDoc = "199";

                nombreyApellido = "    " + dt_Final.Rows[i]["usuario"].ToString().Replace('\u0090', ' ').Trim();
                prestacion = dt_Final.Rows[i]["Tipo_prestacion"].ToString();
                montoTotal = Math.Round(Convert.ToDecimal(dt_Final.Rows[i]["Importe"]), 2).ToString();
                periodo ="1";
                celular = dt_Final.Rows[i]["Telefono"].ToString();
                calle = dt_Final.Rows[i]["Calle"].ToString();
                if(calle.Length>29)
                    calle = calle.Substring(0, 29);
                if (Convert.ToInt32(dt_Final.Rows[i]["Altura"]) == 0)
                {
                    suministroAltura = "".PadLeft(5, ' ');
                    sinSuministroAltura = "1";
                }
                else
                {
                    suministroAltura = dt_Final.Rows[i]["Altura"].ToString().PadLeft(5, pad);
                    sinSuministroAltura = "0";

                }

                piso = "  ";

                //if (dt_Final.Rows[i]["piso"].ToString() == "")
                //    piso = "  ";
                //else
                //    piso = dt_Final.Rows[i]["piso"].ToString().PadLeft(2, pad);
                //if(piso.Length>2)
                //    piso = piso.Substring(0, 2);


                if (dt_Final.Rows[i]["depto"].ToString() == "")
                    depto = "   ";
                else
                    depto = dt_Final.Rows[i]["depto"].ToString().PadLeft(3, pad);

                codigoPostal = dt_Final.Rows[i]["CodigoPostal"].ToString();
                localidad = dt_Final.Rows[i]["Localidad"].ToString();
                email = dt_Final.Rows[i]["email"].ToString();
                if (!email.Contains("@") || !email.ToLower().Contains("com"))
                    email = "";
                email = ""; //lo dejo vacio xq hay emails que son tipo: "hola@hotmail.com13" y el 13 despues del com no se puede

                tipoOperacion = "A";

                Cadenas[i] =cuit + 
                             tipoDoc.ToString().PadLeft(1, pad)+
                             numDoc.PadRight(8, '0') + 
                             nombreyApellido.PadRight(50,pad)+
                             prestacion.PadLeft(1, pad) +
                             montoTotal.ToString().PadLeft(13, '0') + 
                             periodo.PadLeft(1, pad) + 
                             celular.PadLeft(10, '0') + 
                             calle.Trim().PadLeft(30, pad) + 
                             suministroAltura.PadLeft(5, pad) + 
                             sinSuministroAltura+
                             piso.Trim().PadLeft(2,pad)+
                             depto.PadLeft(3,pad)+
                             codigoPostal.PadLeft(4, pad) + 
                             localidad.PadRight(30, pad) + 
                             celular.PadLeft(10, '0') + 
                             email.PadLeft(40, pad) + 
                             "A";
            }
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Archivo de texto (*txt)|*txt";
            saveDialog.DefaultExt = "txt";
            saveDialog.RestoreDirectory = true;
            saveDialog.FilterIndex = 2;
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                oTool.ExportarCvs(saveDialog.FileName, 1, Cadenas);
                MessageBox.Show("El archivo se exporto correctamente", "Mensaje del sistema");
            }
            else
            {
                MessageBox.Show("Error al exportar el archivo.", "Mensaje del sistema");
            }
        }

        private void tbArbaCuatrimestral_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage.Name == "tbHistorial")
            {

            }
        }

        private void txtImporteInternet_TextChanged(object sender, EventArgs e)
        {
            if (txtImporteCable.Text != "" && txtImporteInternet.Text != "")
            {
                Importe_Total_Ambos = Convert.ToInt32(txtImporteCable.Text) + Convert.ToInt32(txtImporteInternet.Text);
                txtImporteAmbos.Text = Importe_Total_Ambos.ToString();
            }
            if (txtImporteCable.Text == "" || txtImporteInternet.Text == "")
                txtImporteAmbos.Text = "";

        }

        private void dtpDesde_ValueChanged(object sender, EventArgs e)
        {
            dtpHasta.MinDate = dtpDesde.Value.Date;
        }

        private void txtImporteCable_TextChanged(object sender, EventArgs e)

        {
            if (txtImporteCable.Text != "" && txtImporteInternet.Text != "")
            {
                Importe_Total_Ambos = Convert.ToInt32(txtImporteCable.Text) + Convert.ToInt32(txtImporteInternet.Text);
                txtImporteAmbos.Text = Importe_Total_Ambos.ToString();
            }
            if (txtImporteCable.Text == "" || txtImporteInternet.Text == "")
                txtImporteAmbos.Text = "";

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            llenardtFinal();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if(dtpHasta.Value<dtpDesde.Value)
                MessageBox.Show("La fecha Hasta no puede ser anterior a la fecha Desde.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                tbDatosFiltrados.Controls.Add(pgCircular);
                tbDatosFiltrados.Controls.Add(lblEstado);
                pgCircular.Location = new Point(tbArbaCuatrimestral.Width / 2-pgCircular.Width/2, tbArbaCuatrimestral.Height / 2- pgCircular.Height / 2);
                lblEstado.Text = "Buscando información...";
                lblEstado.Location = new Point(pgCircular.Location.X- (pgCircular.Width/2), pgCircular.Location.Y + pgCircular.Height + 15);
                //pgCircular.Location = new Point(tbArbaCuatrimestral.Location.X + (tbArbaCuatrimestral.Width / 2) - pgCircular.Width / 2, tbArbaCuatrimestral.Location.Y + (tbArbaCuatrimestral.Height / 2) - (pgCircular.Height / 2));
                pgCircular.BringToFront();
                lblEstado.BringToFront();
                pgCircular.Visible = true;
                lblEstado.Visible = true;
                foreach (Control item in this.Controls)
                {
                
                    if (item.Name != "pgCircular" && item.Name != "lblEstado" && item.Name != "tbArbaCuatrimestral" && item.Name != "tbDatosFiltrados" && item.Name != "lblTituloHeader")
                        item.Enabled = false;
                    else
                    {
                        item.Visible = true;
                        pgCircular.Start();
                        pgCircular.BringToFront();
                    }
                }
                desde = dtpDesde.Value;
                hasta = dtpHasta.Value;
                Importe_Cable = Convert.ToInt32(txtImporteCable.Text);
                Importe_Internet = Convert.ToInt32(txtImporteInternet.Text);
                if (txtImporteCable.Text == "" || txtImporteInternet.Text == "" || txtImporteAmbos.Text == "")
                    MessageBox.Show("Debe seleccionar un importe como piso.");
                else
                    comenzarCarga();
            }
            

          

        }
        #endregion
    }
}
