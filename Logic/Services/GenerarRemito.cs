using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Data.Base;
using Entities.Model;
using Logic.ClasesApi;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using Newtonsoft.Json;
using Polly;
using Polly.Retry;
using ILogger = Serilog.ILogger;
namespace Logic.Services
{
    public class GenerarRemito
    {
        #region Servicios
        // private  IServiciosApi _serviciosApi;
        private IRepository<Albventacamposlibre> _AlbventaCampoLibre;
        private IRepository<Albventacab> _AlbventaCab;
        private IRepository<Albventalin> _AlbventaLin;
        private readonly ILogger _logger;
        private readonly HttpClient _httpClient;
        private AlbVentaCabService _albVentaCabService;
        private AlbVentaLinService _albVentaLinService;
        private AlbVentaCamposLibresService _albventacamposlibreService;
        private readonly AsyncRetryPolicy<HttpResponseMessage> _retryAsyncPolicy;
        private readonly IConfiguration _config;
        
        #endregion

        #region Constructor
        public GenerarRemito(IRepository<Albventacamposlibre> albventaCampoLibre, IRepository<Albventacab> albventaCab, IRepository<Albventalin> albventaLin, AlbVentaCabService albVentaCabService, 
                AlbVentaLinService LineService, AlbVentaCamposLibresService albventacamposlibre,  ILogger logger1,IConfiguration configuration)
        {
            _AlbventaCampoLibre = albventaCampoLibre;
            _AlbventaCab = albventaCab;
            _AlbventaLin = albventaLin;
            _albVentaCabService = albVentaCabService;
            _albVentaLinService = LineService;
            _albventacamposlibreService = albventacamposlibre;
            _logger = logger1;
            _httpClient = new HttpClient();
            _config = configuration;
            
            //Permite reintentar x veces al darle a una api y recivir un codigo distinto de 200 com orespuesta 
            _retryAsyncPolicy = Policy.HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
                .Or<HttpRequestException>()
                .RetryAsync(3);
            
        }
        #endregion

        public async Task CargaRemito(CancellationToken cancellationToken = default)
        {
            var listaRemito = await _AlbventaCampoLibre.getAllTask();
            
            var urlApi = "https://stg.remitos-log.chl.bestseller-latam.com/venta";
            if (Uri.TryCreate(urlApi, UriKind.Absolute, out Uri uri))
            {
                _httpClient.BaseAddress = uri;
            }
            RemitoVenta remitoVenta = new RemitoVenta();
            LineaVenta lineaRemito = new LineaVenta();
            
            foreach (var unRemito in listaRemito)
            {
                if (unRemito != null)
                {
                    if (unRemito.Replicado == "F")
                    {
                        Console.WriteLine("Generar Remito Generico" + unRemito.Numserie + "-" + unRemito.Numalbaran);
                        
                        // var lineas = await Lineas(unRemito);
                        remitoVenta.tipoDoc = (int) unRemito.NNavigation.Tipodoc;
                        // remitoVenta.serie = unRemito.NNavigation.Albventacamposlibre.Numserie;
                        remitoVenta.serie = _config.GetSection("Serie").Value;
                        remitoVenta.referencia = "Ref";
                        remitoVenta.cliente = (int) unRemito.NNavigation.Codcliente;
                        remitoVenta.controlStock = false;
                        remitoVenta.recibido = true;
                        if (unRemito.NNavigation.Albventalins != null)
                        {
                            foreach (var lineaFactura in unRemito.NNavigation.Albventalins)
                            {
                                lineaRemito = new LineaVenta();
                                lineaRemito.codigo = "1957344433";
                                lineaRemito.deposito = lineaFactura.Codalmacen;
                                lineaRemito.descripcion = lineaFactura.Descripcion;
                                lineaRemito.dto = (int?) lineaFactura.Dto;
                                lineaRemito.iva = (int?) lineaFactura.Iva;
                                lineaRemito.precio = (int?) lineaFactura.Precio;
                                lineaRemito.unidades = (int?) lineaFactura.Unidadestotal;
                                remitoVenta.lineas.Add(lineaRemito);
                            }
                        }

                        try
                        {
                            var x = JsonConvert.SerializeObject(remitoVenta);
                            var respuesta = await _retryAsyncPolicy.ExecuteAsync(async () => await _httpClient.PostAsJsonAsync(urlApi, remitoVenta,cancellationToken));
                            if (respuesta.IsSuccessStatusCode)
                            {
                                // Console.WriteLine("Actualizar Campo Replicado");
                                unRemito.Replicado = "T";
                                await ActualizarEstado(unRemito);
                                _logger.Information("Se actualizo el campo Replicado del remito: " +
                                                    unRemito.Numserie + "-" + unRemito.Numalbaran);
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                            _logger.Error(e.Message);
                        }
                    }
                    else
                    {
                        Console.WriteLine("El Remito " + unRemito.Numserie + unRemito.Numalbaran + " Tiene replicado == T" );
                    }
                }
            }
        }

        public async Task<bool> ActualizarEstado(Albventacamposlibre remito)
        {
            var bandera = false;
            try
            { if (remito != null)
                {
                    await _albventacamposlibreService.UpdateRemito(remito);
                     _logger.Information("Update de Remito");
                    bandera = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                bandera = false;
                _logger.Error(e.Message);
             
            }
            return bandera;
        }
    }

}