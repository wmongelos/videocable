using CapaNegocios;
using CapaNegocios.Panel_Tareas;
using System;
using System.Collections.Generic;
using System.IO;
using System.Timers;

namespace ServicioWindows
{
    public class Servicio
    {
        /**
         * El enum tiene que estar entre 128 y 256
         */
        public enum Comandos
        {
            ActualizarEjecucionDeProcesos = 128
        }

        public const string NombreServicio = "ServicioGIES";
        public const string NombreDisplay = "Servicio GIES";
        public const string DescripcionServicio = "Administrador de procesos del GIES";
        public const string LogPath = @"C:\ServicioGIES\LogServicio.txt";

        private readonly Timer timer;
        private List<Procesos_Ejecucion> procesosEjecucion = new List<Procesos_Ejecucion>();
        private bool intervaloProlongado;
        private readonly Configuracion oConfig;

        public Servicio()
        {
            timer = new Timer() { AutoReset = true };
            timer.Elapsed += TimerElapsed;
            intervaloProlongado = false;
            oConfig = new Configuracion();
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            EjecutarTarea();
        }

        private void EjecutarTarea()
        {
            if(intervaloProlongado)
            {
                intervaloProlongado = false;
                ProgramarTarea();
                return;
            }
            else
            {
                timer.Stop();
                timer.Close();
            }

            File.AppendAllLines(LogPath, new string[]
            {
                $"Id_Proceso_Ejecucion: {procesosEjecucion[0].Id}",
                $"Id_Proceso: {procesosEjecucion[0].Id_Proceso}",
                $"Inicio: {DateTime.Now}"
            });

            try
            {
                oConfig.LoadConfiguracion();
                Procesos_Ejecucion.Estados_Ejecucion_Proceso estadoEjecucion;
                if (Tareas.Ejecutar(procesosEjecucion[0], out string error))
                {
                    File.AppendAllText(LogPath, $"Finalizacion: {DateTime.Now}\n");
                    estadoEjecucion = Procesos_Ejecucion.Estados_Ejecucion_Proceso.Finalizado;
                }
                else
                {
                    File.AppendAllText(LogPath, $"Error: {DateTime.Now} - [{error}]\n");
                    estadoEjecucion = Procesos_Ejecucion.Estados_Ejecucion_Proceso.Error;
                }

                new Procesos_Ejecucion().ActualizarEstado(procesosEjecucion[0].Id, estadoEjecucion);
                if(procesosEjecucion[0].Id_Proceso_Automatico > 0)
                    new Procesos_Automaticos().AgregarProximaEjecucion(procesosEjecucion[0].Id_Proceso_Automatico, procesosEjecucion[0].Fecha_Ejecucion);
                procesosEjecucion.Remove(procesosEjecucion[0]);
            }
            catch (Exception ex)
            {
                File.AppendAllText(LogPath, $"--> Excepcion en 'EjecutarTarea': {ex}\n");
            }

            File.AppendAllText(LogPath, "*******************************\n");
            ProgramarTarea();
        }

        private void ProgramarTarea()
        {
            if (procesosEjecucion.Count > 0)
            {
                timer.Stop();
                timer.Close();

                double milisegundosParaLaEjecucion = 0;
                if (procesosEjecucion[0].Estado == Convert.ToInt32(Procesos_Ejecucion.Estados_Ejecucion_Proceso.Reprogramado) &&
                   procesosEjecucion[0].Fecha_Reprogramado.HasValue)
                {
                    milisegundosParaLaEjecucion = (procesosEjecucion[0].Fecha_Reprogramado.Value - DateTime.Now).TotalMilliseconds;
                }
                else if (procesosEjecucion[0].Estado == Convert.ToInt32(Procesos_Ejecucion.Estados_Ejecucion_Proceso.No_Iniciado))
                {
                    milisegundosParaLaEjecucion = (procesosEjecucion[0].Fecha_Ejecucion - DateTime.Now).TotalMilliseconds;
                }
                else
                {
                    try
                    {
                        new Procesos_Ejecucion().ActualizarEstado(procesosEjecucion[0].Id, Procesos_Ejecucion.Estados_Ejecucion_Proceso.No_Realizado);
                        procesosEjecucion = new Procesos_Ejecucion().ListarProcesosParaEjecutar();
                    }
                    catch (Exception ex)
                    {
                        File.AppendAllText(LogPath, $"--> Excepcion en 'ProgramarTarea': {ex}\n");
                    }
                    ProgramarTarea();
                }

                if (milisegundosParaLaEjecucion < 0)
                {
                    try
                    {
                        new Procesos_Ejecucion().Reprogramar(procesosEjecucion[0].Id, procesosEjecucion);
                        procesosEjecucion = new Procesos_Ejecucion().ListarProcesosParaEjecutar();
                    }
                    catch (Exception ex)
                    {
                        File.AppendAllText(LogPath, $"--> Excepcion en 'ProgramarTarea': {ex}\n");
                    }
                    ProgramarTarea();
                }
                else
                {
                    if (milisegundosParaLaEjecucion > Int32.MaxValue)
                    {
                        milisegundosParaLaEjecucion = Int32.MaxValue;
                        intervaloProlongado = true;
                    }
                    else
                    {
                        intervaloProlongado = false;
                    }

                    timer.Interval = milisegundosParaLaEjecucion;
                    timer.Start();
                }
            }
        }

        public void EjecutarComando(int comando)
        {
            List<string> lines = new List<string> { $"Ejecucion de comando ({DateTime.Now})", $"Comando: ${comando}", "*******************************" };
            File.AppendAllLines(LogPath, lines);
            if (comando == Convert.ToInt32(Comandos.ActualizarEjecucionDeProcesos))
            {
                procesosEjecucion = new Procesos_Ejecucion().ListarProcesosParaEjecutar();
                ProgramarTarea();
            }
        }

        public void Start()
        {
            List<string> lines = new List<string> { $"Inicio de servicio ({DateTime.Now}).", "*******************************" };
            File.AppendAllLines(LogPath, lines);
            procesosEjecucion = new Procesos_Ejecucion().ListarProcesosParaEjecutar();
            ProgramarTarea();
        }

        public void Stop()
        {
            List<string> lines = new List<string> { $"Detencion de servicio ({DateTime.Now}).", "*******************************" };
            File.AppendAllLines(LogPath, lines);
            timer.Stop();
            timer.Close();
        }
    }
}
