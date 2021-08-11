using CapaNegocios;
using CapaNegocios.Panel_Tareas;
using System;
using System.Collections.Generic;
using System.IO;
using System.Timers;

namespace ServicioWindows
{
    public class ServicioC
    {
        public enum Comandos
        {
            ActualizarEjecucionDeProcesos = 128
        }

        public const string NombreServicio = "ServicioGIES";
        public const string NombreDisplay = "Servicio GIES";
        public const string DescripcionServicio = "Administrador de procesos del GIES";
        public const string LogPath = @"C:\ServicioGIES\LogServicio.txt";

        private readonly double INTERVALO = TimeSpan.FromMinutes(10).TotalMilliseconds;
        private readonly Timer timer;
        private readonly Configuracion oConfig;
        private List<Procesos_Ejecucion> procesosEjecucion = new List<Procesos_Ejecucion>();

        public ServicioC()
        {
            timer = new Timer() { AutoReset = true };
            timer.Interval = INTERVALO;
            timer.Elapsed += TimerElapsed;
            oConfig = new Configuracion();
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            timer.Stop();
            File.AppendAllText(LogPath, $"--> Timer elapsed: {DateTime.Now}\n");
            DateTime fechaActual = DateTime.Now;
            try
            {
                procesosEjecucion = new Procesos_Ejecucion().ListarProcesosParaEjecutarPasados(fechaActual);
                if(procesosEjecucion.Count > 0)
                {
                    oConfig.LoadConfiguracion();
                    for (int i = 0; i < procesosEjecucion.Count; i++)
                    {
                        File.AppendAllLines(LogPath, new string[]
                        {
                            $"Id_Proceso_Ejecucion: {procesosEjecucion[0].Id}",
                            $"Id_Proceso: {procesosEjecucion[0].Id_Proceso}",
                            $"Inicio: {DateTime.Now}"
                        });

                        // Comparar con el INTERVALO si la diferencia es mayor si tiene que reprogramar - si esta dentro del rango lo ejecuta, si no lo reprograma
                        //if (!new Procesos().ProcesoDentroDelRango(procesosEjecucion[i].Id_Proceso))
                        //{
                        //    new Procesos_Ejecucion().Reprogramar(procesosEjecucion[i].Id, new Procesos_Ejecucion().ListarProcesosParaEjecutarProximos(fechaActual));
                        //}
                        //else
                        //{
                        Procesos_Ejecucion.Estados_Ejecucion_Proceso estadoEjecucion;
                        if (Tareas.Ejecutar(procesosEjecucion[i], out string error))
                        {
                            File.AppendAllText(LogPath, $"Finalizacion: {DateTime.Now}\n");
                            estadoEjecucion = Procesos_Ejecucion.Estados_Ejecucion_Proceso.Finalizado;
                        }
                        else
                        {
                            File.AppendAllText(LogPath, $"Error: {DateTime.Now} - [{error}]\n");
                            estadoEjecucion = Procesos_Ejecucion.Estados_Ejecucion_Proceso.Error;
                        }

                        new Procesos_Ejecucion().ActualizarEstado(procesosEjecucion[i].Id, estadoEjecucion);
                        if (procesosEjecucion[i].Id_Proceso_Automatico > 0)
                            new Procesos_Automaticos().AgregarProximaEjecucion(procesosEjecucion[i].Id_Proceso_Automatico, procesosEjecucion[i].Fecha_Ejecucion);

                        File.AppendAllText(LogPath, "*******************************\n");
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                File.AppendAllText(LogPath, $"--> Excepcion': {ex}\n");
            }
            timer.Start();
        }

        public void EjecutarComando(int comando)
        {
            if (comando == Convert.ToInt32(Comandos.ActualizarEjecucionDeProcesos))
            {
                
            }
        }

        public void Start()
        {
            List<string> lines = new List<string> { $"Inicio de servicio ({DateTime.Now}).", "*******************************" };
            File.AppendAllLines(LogPath, lines);
            timer.Start();
        }

        public void Stop()
        {
            List<string> lines = new List<string> { $"Detencion de servicio ({DateTime.Now}).", "*******************************" };
            File.AppendAllLines(LogPath, lines);
            timer.Stop();
        }
    }
}
