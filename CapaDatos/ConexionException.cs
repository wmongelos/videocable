using System;
using System.IO;

namespace CapaDatos
{
    public class ConexionException : ApplicationException
    {
        public ConexionException(String mensaje, Exception original) : base(mensaje, original)
        {
            try
            {
                string filename = "Log.txt";

                using (FileStream fs = new FileStream(filename, FileMode.Append))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        string error = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + " ";
                        error += mensaje + " ---- " + original.ToString();
                        sw.WriteLine();
                        sw.WriteLine(error);
                    }

                }
            }
            catch (Exception)
            {
            }
        }

        public ConexionException(String mensaje) : base(mensaje) { }
    }
}
