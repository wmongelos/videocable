using CapaNegocios;
using ClosedXML.Excel;
using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CapaPresentacion
{
    class Tools
    {
        /// <summary>
        /// Metodo Para Enviar Datatable a Excel
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="nombre"></param>
        /// <param name="form"></param>
        public void ExportDataTableToExcel(DataTable dt, string nombre, Form form = null)
        {
            string path = "";
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.Filter = "Excel | *.xlsx";
            saveFileDialog.FileName = $"{nombre}.xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (form != null)
                        form.Cursor = Cursors.WaitCursor;

                    path = saveFileDialog.FileName;
                    XLWorkbook wb = new XLWorkbook();
                    wb.Worksheets.Add(dt, $"{nombre}.xlsx");
                    wb.SaveAs(path);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (form != null)
                        form.Cursor = Cursors.Default;
                }
            }
        }

        Usuarios oUsu = new Usuarios();
        public void ExportToExcel(DataGridView dgv, String name)
        {
            // Creating a Excel object. 
            Microsoft.Office.Interop.Excel._Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = excel.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            try
            {
                worksheet = workbook.ActiveSheet;

                worksheet.Name = name;

                int cellRowIndex = 1;
                int cellColumnIndex = 1;
                int columnasVisibles = 0;
                //Loop through each row and read value from each column. 
                for (int i = -1; i < dgv.Rows.Count; i++)
                {

                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {
                        if (dgv.Columns[j].Visible == true)
                        {
                            columnasVisibles++;
                            if (cellRowIndex == 1)
                            {
                                worksheet.Cells[cellRowIndex, cellColumnIndex] = dgv.Columns[j].HeaderText;

                            }
                            else
                            {
                                worksheet.Cells[cellRowIndex, cellColumnIndex] = dgv.Rows[i].Cells[j].Value;
                            }

                            cellColumnIndex++;
                        }

                    }
                    cellColumnIndex = 1;
                    cellRowIndex++;
                }
                Char letra = 'A';
                int letranumero;
                letranumero = Convert.ToInt32(letra) + dgv.Columns.Count - 5;
                letra = Convert.ToChar(letranumero);
                Microsoft.Office.Interop.Excel.Range formatRange;
                string rango1 = string.Format("{0}1", letra);
                formatRange = worksheet.get_Range("A1", rango1);
                formatRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightYellow);
                formatRange.Cells.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                formatRange.EntireColumn.AutoFit();
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveDialog.FilterIndex = 2;

                if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    workbook.SaveAs(saveDialog.FileName);
                    MessageBox.Show("El archivo se exporto correctamente");
                }
            }
            catch
            {
                //MessageBox.Show(ex.Message);
            }
            finally
            {
                excel.Quit();
                workbook = null;
                excel = null;
            }
        }

        public void AgregarHojaExcel(string ruta, DataGridView dgv)
        {

        }

        public void ExportToExcel(DataGridView dgv, DataGridView dgv2, String name)
        {
            // Creating a Excel object. 
            Microsoft.Office.Interop.Excel._Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = excel.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            try
            {
                worksheet = workbook.ActiveSheet;

                worksheet.Name = name;

                int cellRowIndex = 1;
                int cellColumnIndex = 1;

                //Loop through each row and read value from each column. 
                for (int i = -1; i < dgv.Rows.Count; i++)
                {
                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {
                        if (dgv.Columns[j].Visible == true)
                        {
                            if (cellRowIndex == 1)
                            {
                                worksheet.Cells[cellRowIndex, cellColumnIndex] = dgv.Columns[j].HeaderText;

                            }
                            else
                            {
                                worksheet.Cells[cellRowIndex, cellColumnIndex] = dgv.Rows[i].Cells[j].Value;
                            }

                            cellColumnIndex++;
                        }

                    }
                    cellColumnIndex = 1;
                    cellRowIndex++;
                }
                cellRowIndex = dgv.Rows.Count + 1;
                //Loop through each row and read value from each column. 
                for (int i = -1; i < dgv2.Rows.Count; i++)
                {
                    for (int j = 0; j < dgv2.Columns.Count; j++)
                    {
                        if (dgv2.Columns[j].Visible == true)
                        {
                            if (cellRowIndex == 1)
                            {
                                worksheet.Cells[cellRowIndex, cellColumnIndex] = dgv2.Columns[j].HeaderText;

                            }
                            else
                            {
                                worksheet.Cells[cellRowIndex, cellColumnIndex] = dgv2.Rows[i].Cells[j].Value;
                            }

                            cellColumnIndex++;
                        }

                    }
                    cellColumnIndex = 1;
                    cellRowIndex++;
                }
                Char letra = 'd';
                int letranumero;
                letranumero = Convert.ToInt32(letra);
                Microsoft.Office.Interop.Excel.Range formatRange;
                string pintarDesde = string.Format("A1");
                formatRange = worksheet.get_Range("A1", "AF1");
                formatRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightYellow);
                formatRange.Cells.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;



                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveDialog.FilterIndex = 2;

                if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    workbook.SaveAs(saveDialog.FileName);
                    MessageBox.Show("El archivo se exporto correctamente");
                }
            }
            catch
            {
                //MessageBox.Show(ex.Message);
            }
            finally
            {
                excel.Quit();
                workbook = null;
                excel = null;
            }
        }
        public int CalcularDigitoCuit(string cuit)
        {
            int[] mult = new[] { 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 };

            char[] nums = cuit.ToCharArray();

            int total = 0;

            for (int i = 0; i < mult.Length; i++)
                total += int.Parse(nums[i].ToString()) * mult[i];

            var resto = total % 11;

            return resto == 0 ? 0 : resto == 1 ? 9 : 11 - resto;
        }
        public bool ValidaCuit(string cuit)
        {

            if (cuit == null)
                return false;

            cuit = cuit.Replace("-", string.Empty);

            if (cuit.Length != 11)

            {

                return false;

            }

            else

            {

                int calculado = CalcularDigitoCuit(cuit);

                int digito = int.Parse(cuit.Substring(10));

                return calculado == digito;

            }

        }
        public bool ComprobarFormatoEmail(string sEmailAComprobar)
        {
            String sFormato;
            sFormato = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(sEmailAComprobar, sFormato))
            {
                if (Regex.Replace(sEmailAComprobar, sFormato, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public Int32 EnviarFacturaElectronica(string destinatario, string rutaArchivo)
        {
            Int32 retorno = 0;
            MailMessage correo = new MailMessage();
            SmtpClient envios = new SmtpClient();
            Configuracion oCon = new Configuracion();
            string emisor = oCon.GetValor_C("CorreoFactura");         
            string password = oCon.GetValor_C("PassCorreo");         
            MailMessage message = new MailMessage(emisor, destinatario);
            message.Subject = oCon.GetValor_C("Empresa");
            SmtpClient client = new SmtpClient(oCon.GetValor_C("Servidor"), oCon.GetValor_N("Puerto"));
            // string texto = File.ReadAllText(@"C:\GIES\CorreoFactura.txt");
            Attachment adjunto = new Attachment(rutaArchivo, MediaTypeNames.Application.Pdf);
            message.Attachments.Add(adjunto);
            message.IsBodyHtml = true;
            //      message.Body = texto;

            client.EnableSsl = oCon.GetValor_N("SSL") == 1 ? true : false;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(emisor, password);
           // client.DeliveryMethod = SmtpDeliveryMethod.Network;
          

            try
            {
                client.Send(message);
            }
            catch (SmtpException x)
            {
                MessageBox.Show("Error al enviar correo." + x.ToString());
                retorno = -1;
            }
            client.Dispose();
            message.Dispose();

            return retorno;
        }

        public Boolean EscribirTxt(string ruta, int borraTodo, string contenido)
        {
            try
            {
                StreamWriter sw = new StreamWriter(ruta);
                if (borraTodo == 1)
                    sw.Flush();
                sw.WriteLine(contenido);
                sw.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public Boolean ExportarCvs(string ruta, int borraTodo, string[] contenido)
        {
            try
            {
                StreamWriter sw = new StreamWriter(ruta);
                if (borraTodo == 1)
                    sw.Flush();
                for (int i = 0; i < contenido.Length; i++)
                {
                    sw.WriteLine(contenido[i]);
                }
                sw.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public void EjecutarAplicacion(string ruta)
        {
            string exe = ruta;
            var psi = new ProcessStartInfo();
            psi.CreateNoWindow = true; //This hides the dos-style black window that the command prompt usually shows
            psi.FileName = ruta;
            //psi.Verb = "runas"; //This is what actually runs the command as administrator
            try
            {
                var process = new Process();
                process.StartInfo.Verb = "runas";
                process.StartInfo = psi;
                process.Start();
                process.WaitForExit();

            }
            catch (Exception)
            {
                //If you are here the user clicked decline to grant admin privileges (or he's not administrator)
            }
            //  Process.Start(ruta);
        }

        public Boolean GetProcesoAbierto(string nombreApp, string tituloVentana = "")
        {
            int cant = 0;
            Process[] procesos = Process.GetProcessesByName(nombreApp);
            if (procesos.Length > 0)
            {
                if (!string.IsNullOrEmpty(tituloVentana))
                {
                    foreach (Process item in procesos)
                    {
                        if (item.MainWindowTitle.Equals(tituloVentana))
                            cant++;
                    }
                    if (cant > 0)
                        return true;
                    else
                        return false;
                }
                else
                    return true;
            }
            else
                return false;
        }

        public void LeeTxtPadronARBA(string Ruta)
        {
            DataTable dtUsu;
            DataTable dtUsuAux, dtUsuAux2;
            DataView dv;
            dtUsu = oUsu.ListarTodosUsuariosARBA();
            string Tipo;
            string Fecha_Recibo, Fecha_Desde, Fecha_Hasta, Cuit;
            decimal Porcentaje;
            StreamReader streamReader = new StreamReader(Ruta);
            string[] Linea;
            string cont = "";
            char[] Delimitador = { ';' };

            while ((cont = streamReader.ReadLine()) != null)
            {
                try
                {
                    Linea = cont.Split(Delimitador);
                    Tipo = Linea[0];
                    Fecha_Recibo = Convert.ToString(Linea[1]);
                    Fecha_Desde = Convert.ToString(Linea[2]);
                    Fecha_Hasta = Convert.ToString(Linea[3]);
                    Cuit = Convert.ToString(Linea[4]);
                    Porcentaje = Convert.ToDecimal(Linea[8]);
                    dv = dtUsu.DefaultView;
                    dv.RowFilter = string.Format("Cuit = {0}", Cuit);
                    dtUsuAux2 = dv.ToTable();
                    if (dtUsuAux2.Rows.Count > 0)
                        oUsu.ActualizaImpuesto_Provincial(Convert.ToDouble(Cuit), Porcentaje);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Convert.ToString(ex));
                }
            }
            streamReader.Close();
        }

        public decimal NuevoAbonadoPADRONARBA(string Cuit)
        {
            DataTable dtUsu;
            DataTable dtUsuAux;
            string Ruta = @"C:\GIES\PadronARBA.txt";
            decimal Porcentaje = 0, PorcentajeTxt = 0;

            Boolean existeArchivo = File.Exists(Ruta);

            if (existeArchivo)
            {
                StreamReader streamReader = new StreamReader(Ruta);
                string[] Linea;
                string cont = "";
                char[] Delimitador = { ';' };
                dtUsu = oUsu.ListarTodosUsuariosARBA();
                cont = streamReader.ReadLine();
                Linea = cont.Split(Delimitador);
                while ((cont = streamReader.ReadLine()) != null)
                {
                    if (Convert.ToString(Linea[4]) == Cuit)
                    {
                        PorcentajeTxt = Convert.ToDecimal(Linea[8]);
                        break;
                    }
                    Linea = cont.Split(Delimitador);
                }

                Porcentaje = PorcentajeTxt;
                dtUsuAux = dtUsu.Copy();
            }


            return Porcentaje;
        }

        public void GenerarBKPMysql(string path)
        {

            try
            {
                DbConnectionStringBuilder db = new DbConnectionStringBuilder();

                db.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionStringMysql"].ConnectionString;

                var username = db["uid"].ToString();
                var userpass = db["pwd"].ToString();
                var server = db["server"].ToString();
                var database = db["database"].ToString();

                string fichero;
                SaveFileDialog fd = new SaveFileDialog();
                fd.DefaultExt = "*.sql";
                fd.Filter = "SQL Files (*.sql)|*.sql";
                if (fd.ShowDialog() == DialogResult.OK)
                {
                    if (fd.FileName != String.Empty)
                    {
                        String linea;
                        fichero = fd.FileName;
                        System.Diagnostics.Process proc = new System.Diagnostics.Process();
                        proc.EnableRaisingEvents = false;
                        proc.StartInfo.UseShellExecute = false;
                        proc.StartInfo.RedirectStandardOutput = true;
                        proc.StartInfo.FileName = "mysqldump";
                        proc.StartInfo.Arguments = string.Format("{0} --single-transaction --host={1} --user={2} --password={3}", database, server, username, userpass);
                        Process miProceso;
                        miProceso = Process.Start(proc.StartInfo);
                        StreamReader sr = miProceso.StandardOutput;
                        TextWriter tw = new StreamWriter(fd.FileName, false, Encoding.Default);
                        while ((linea = sr.ReadLine()) != null)
                        {
                            tw.WriteLine(linea);
                        }
                        tw.Close();
                        MessageBox.Show("Copia de seguridad realizada con éxito");
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Se ha producido un error al realizar la copia de seguridad");
            }
        }

        public bool ValidarIPv4(string ipString)
        {
            if (String.IsNullOrWhiteSpace(ipString))
                return false;

            string[] splitValues = ipString.Split('.');
            if (splitValues.Length != 4)
                return false;
            byte tempForParsing;
            return splitValues.All(r => byte.TryParse(r, out tempForParsing));

        }
    }
}
