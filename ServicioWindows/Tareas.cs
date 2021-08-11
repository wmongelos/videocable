using CapaNegocios;
using CapaNegocios.Panel_Tareas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioWindows
{
    public class Tareas
    {
        public static bool Ejecutar(Procesos_Ejecucion procesoEjecucion, out string error)
        {
            if (!Enum.IsDefined(typeof(Procesos.Proceso), procesoEjecucion.Id_Proceso))
            {
                error = $"Proceso no definido. El proceso [{procesoEjecucion.Id_Proceso}] no esta asignado al enum de procesos";
                return false;
            }

            Procesos.Proceso proceso = (Procesos.Proceso)procesoEjecucion.Id_Proceso;

            try
            {
                switch (proceso)
                {
                    case Procesos.Proceso.Calculo_Punitorios:
                        if (CalcularPunitorios(out error))
                            return true;
                        else
                            return false;
                    case Procesos.Proceso.Lote_Parte_Baja:
                        if (RealizarBajaDeLote(procesoEjecucion.Id, out error))
                            return true;
                        else
                            return false;
                    default:
                        error = "Proceso no definido";
                        return false;
                }
            }
            catch (Exception ex)
            {
                error = $"Error: {ex.Message}";
                return false;
            }
        }

        public static bool CalcularPunitorios(out string error)
        {
            error = "";
            try
            {
                DataTable dtCtaCteDet = new Usuarios_CtaCte_Det().ListarCtacteDetConSaldo(bonificacion: false); //.Rows.Cast<DataRow>().Take(100).CopyToDataTable();
                new Punitorio().ActualizarPunitorios(dtCtaCteDet);
                return true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }       

        public static bool RealizarBajaDeLote(int idProcesoEjecucion, out string error)
        {
            error = "";
            try
            {
                List<int> partesDelLote = new Procesos_Ejecucion_Lotes().GetPartesDeLote(idProcesoEjecucion);
                DataTable dtResult = new Partes().gestionarAppExternasLista(partesDelLote, out string result);
                dtResult.WriteXml(@"C:\GIES\bajas_resultado.xml");

                return true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }
    }
}
