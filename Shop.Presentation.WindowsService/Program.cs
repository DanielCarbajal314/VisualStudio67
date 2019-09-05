using Quartz;
using Shop.Presentation.WindowsService.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;
using Topshelf.Quartz;

namespace Shop.Presentation.WindowsService
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(windowsService =>
            {
                windowsService.UseNLog();
                windowsService.ScheduleQuartzJobAsService(service => {
                    service.WithJob(() => JobBuilder.Create<SincronizardorBaseDeDatos>().Build())
                           .AddTrigger(() => TriggerBuilder
                                            .Create()
                                            .WithCronSchedule("0/5 * * * * ?")
                                            .Build());
                });
                windowsService.StartAutomatically();
                windowsService.EnableServiceRecovery(recoveryOptions =>
                {
                    recoveryOptions.RestartService(1);
                });
                windowsService.SetDisplayName("SincronizadorDeBaseDeDatos");
                windowsService.SetDescription("Sincroniza las bases de datos");
                windowsService.SetServiceName("SincronizadorSQLDeLaTienda");

            });
        }
    }
}
