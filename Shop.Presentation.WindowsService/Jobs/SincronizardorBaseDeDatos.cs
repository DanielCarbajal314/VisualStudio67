using Quartz;
using Shop.Services.implementation;
using Shop.Services.Interfaces.Handlers;
using Shop.Services.Interfaces.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf.Logging;

namespace Shop.Presentation.WindowsService.Jobs
{
    public class SincronizardorBaseDeDatos : IJob
    {
        private static readonly LogWriter _log = HostLogger.Get<SincronizardorBaseDeDatos>();
        IProductHandler productHandler = new EFProductHandler();

        public void Execute(IJobExecutionContext context)
        {
            try
            {
                var result = productHandler.RegisterProduct(new CreateProducto()
                {
                    CategoryId = 4,
                    Descripcion = "Un producto creado desde un Servico",
                    Name = "Producto - " + DateTime.Now
                });
                _log.Info("Registre un producto con id : " + result.Id);
            }
            catch (Exception e)
            {
                _log.Error(e);
            }

        }
    }
}
