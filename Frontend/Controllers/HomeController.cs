using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using o3h.Webexample.Frontend.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace o3h.Webexample.Frontend.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> PrivacyAsync()
        {
            using var httpClient = new HttpClient();

            var apiClient = new swaggerClient("https://localhost:44369/", httpClient);
            var result = await apiClient.WeatherForecastAsync();

            //// create a product
            //await apiClient.CreateProductAsync("1.1", new CreateProductRequest
            //{
            //    Id = 1000,
            //    InventoryCount = 0,
            //    Name = "Test Product"
            //});
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
