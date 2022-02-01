using System;
using System.Threading.Tasks;
using Data.Base;
using Data.Repositories;
using Entities.Model;
using Logic.ClasesApi;
using Logic.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Serilog;



namespace Remitos
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
           // GENERAR ARCHIVO LOG 
           var configuration = new ConfigurationBuilder()
               .AddJsonFile(@"C:\Proyectos\AppRemitos\Remitos\Remitos\appsettings.json")
               .Build();
          
           serviceCollection.AddSingleton<IConfiguration>(configuration);
           var logger = new LoggerConfiguration().WriteTo.File(@"C:\Proyectos\AppRemitos\Remitos\Remitos\LOG/log-.txt", rollingInterval: RollingInterval.Day)
               .CreateLogger();
           serviceCollection.AddSingleton<ILogger>(logger);

           
           #region Servicios
          
           var bconection = "Server=10.39.96.3;Database=LOGISTICUY;User Id=icgadmin;Password=masterkey";
           var logistcuy = new LOGISTICUYContext(bconection);
           serviceCollection.AddDbContext<LOGISTICUYContext>(option =>
               option.UseSqlServer(bconection));
           
           //LOGER 
           
           serviceCollection.AddTransient(typeof(IRepository<Albventacamposlibre>), typeof(AlbVentaCampoLibreRepositorio));
           serviceCollection.AddTransient(typeof(IRepository<Albventacab>), typeof(AlbVentaCabRepositorio));
           serviceCollection.AddTransient(typeof(IRepository<Albventalin>), typeof(AlbVentaLinRepositorio));
           serviceCollection.AddTransient(typeof(ITransactionManager), typeof(Data.Base.TransactionManager));
           // serviceCollection.AddTransient(typeof(TrasladoDeInformacion), typeof(TrasladoDeInformacion));
           
           serviceCollection.AddTransient<RemitoVenta>();
           serviceCollection.AddTransient<GenerarRemito>();
           serviceCollection.AddTransient<AlbVentaCamposLibresService>();
           serviceCollection.AddTransient<AlbVentaLinService>();
           serviceCollection.AddTransient<AlbVentaCabService>();
           
           var serviceProvider = serviceCollection.BuildServiceProvider();

          #endregion

           await serviceProvider.GetService<GenerarRemito>()?.CargaRemito();
        }
    }
}