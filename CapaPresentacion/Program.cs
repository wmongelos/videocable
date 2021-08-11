using System;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using CapaNegocios;
using System.Drawing.Imaging;
using System.Drawing;
using System.Diagnostics;
using System.Threading;

namespace CapaPresentacion
{
    static class Program
    {
        private static readonly string RutaRaizUsuario = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //if (!Debugger.IsAttached)
            //{
            //    Application.SetUnhandledExceptionMode(UnhandledExceptionMode.ThrowException);
            //    AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            //}

            System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("es-AR");

            frmSplash FrmSplashScreen = new frmSplash();
            if (FrmSplashScreen.ShowDialog() == DialogResult.OK)
            {
                frmLogin frmLog = new frmLogin();
                if (frmLog.ShowDialog() != DialogResult.OK)
                    return;
                else
                    Log.guardarEvento(Log.ACCION.INICIO_SESION);

                Application.Run(frmMain.Instance());
            }
        }
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            string fecha = DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year;
            DirectoryInfo info = System.IO.Directory.CreateDirectory(Path.Combine(RutaRaizUsuario + @"\GIES\" + fecha));

            CapturarPantalla(info.FullName);
            // TODO: improve logging and reporting
            try
            {

                Exception r = (Exception)e.ExceptionObject;
                if (r.InnerException == null)
                {
                    MessageBox.Show("Hubo un error al procesar la información. GIES se reiniciará automaticamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    string temporal = CrearArchivo(RutaRaizUsuario + @"\GIES\giesCurrentUser.txt");
                    if (Usuarios.CurrentUsuario != null)
                        ActualizarArchivo(temporal, Usuarios.CurrentUsuario.Id);
                    string error = CrearArchivo(info.FullName + @"\error " + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + "-" + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + ".txt");
                    ActualizarArchivo(error, 0, e.ExceptionObject.ToString());
                    Application.Restart();
                    Environment.Exit(-1);
                }
                else
                {
                    if (r.InnerException.Message.Contains("Access") || r.InnerException.Message.Contains("conexión"))
                    {
                        MessageBox.Show("No se puede establecer la conexion con el servidor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Environment.Exit(-1);

                    }
                    else
                    {
                        MessageBox.Show("Hubo un error al procesar la información. GIES se reiniciará automaticamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        string temporal = CrearArchivo(RutaRaizUsuario + @"\GIES\giesCurrentUser.txt");
                        ActualizarArchivo(temporal, Usuarios.CurrentUsuario.Id);
                        string error = CrearArchivo(info.FullName + @"\error " + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + "-" + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + ".txt");
                        ActualizarArchivo(error, 0, e.ExceptionObject.ToString());
                        Application.Restart();
                        Environment.Exit(-1);
                    }

                }
            }
            catch (Exception c)
            {
                MessageBox.Show("Hubo un error al procesar la información. GIES se reiniciará automaticamente." + c.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Restart();
                Environment.Exit(-1);
            }
        }

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message, "Unhandled Thread Exception");
        }

        private static string CrearArchivo(string rutaCompleta)
        {
            string fileName = string.Empty;
            try
            {
                fileName = rutaCompleta;
                FileInfo fileInfo = new FileInfo(fileName);
                fileInfo.Attributes = FileAttributes.Normal;
            }
            catch (Exception ex)
            {
                FileStream fs = File.Create(rutaCompleta);
                fs.Close();
            }
            return fileName;
        }

        private static void ActualizarArchivo(string rutaArchivo, int idUsuario, string mensaje = "")
        {
            try
            {

                StreamWriter streamWriter = File.AppendText(rutaArchivo);
                if (mensaje == "")
                    streamWriter.WriteLine(idUsuario);
                else
                    streamWriter.WriteLine(mensaje);

                streamWriter.Flush();
                streamWriter.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error writing to TEMP file: " + ex.Message);
            }
        }

        private static void CapturarPantalla(string rutaSalida)
        {
            try
            {
                System.Drawing.Rectangle workingRectangle = Screen.PrimaryScreen.WorkingArea;
                System.Drawing.Size tamanio;
                tamanio = new System.Drawing.Size(workingRectangle.Width, workingRectangle.Height);
                Bitmap captureBitmap = new Bitmap(tamanio.Width, tamanio.Height, PixelFormat.Format32bppArgb);
                Rectangle captureRectangle = Screen.AllScreens[0].Bounds;
                Graphics captureGraphics = Graphics.FromImage(captureBitmap);
                //Copying Image from The Screen
                captureGraphics.CopyFromScreen(captureRectangle.Left, captureRectangle.Top, 0, 0, captureRectangle.Size);
                //Saving the Image File (I am here Saving it in My E drive).
                captureBitmap.Save(rutaSalida + @"\captura_" + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year + "_" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second + ".jpg", ImageFormat.Jpeg);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
