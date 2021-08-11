using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace ServicioWindows
{
    class Program
    {
        static void Main(string[] args)
        {
            var exitCode = HostFactory.Run(hostConfig =>
            {
                hostConfig.Service<ServicioC>(serviceConfig =>
                {
                    serviceConfig.ConstructUsing(servicio => new ServicioC());
                    serviceConfig.WhenStarted(servicio => servicio.Start());
                    serviceConfig.WhenStopped(servicio => servicio.Stop());
                    serviceConfig.WhenCustomCommandReceived((servicio, _, comando) => servicio.EjecutarComando(comando));
                });

                hostConfig.RunAsLocalSystem();
                hostConfig.SetServiceName(ServicioC.NombreServicio);
                hostConfig.SetDisplayName(ServicioC.NombreDisplay);
                hostConfig.SetDescription(ServicioC.DescripcionServicio);
                hostConfig.StartAutomatically();
                hostConfig.OnException((ex) =>
                {
                    File.AppendAllText(ServicioC.LogPath, $"--> Excepcion: {ex}\n");
                });
            });

            int exitCodeValor = (int)Convert.ChangeType(exitCode, exitCode.GetTypeCode());
            Environment.ExitCode = exitCodeValor;
        }
    }
}
