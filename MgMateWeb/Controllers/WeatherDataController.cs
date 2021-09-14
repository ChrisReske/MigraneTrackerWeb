using System.Net;
using System.Threading.Tasks;
using MgMateWeb.Models.WeatherModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace MgMateWeb.Controllers
{
    public class WeatherDataController : Controller
    {
        private readonly IConfiguration _configuration;

        public WeatherDataController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public IActionResult Index()
        {
            return View();
        }

        //TODO Get Weather data from API

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GetWeatherDataAsync(WeatherDataFormModel formModel)
        {


            // Get ApiKey
            var apiKey = GetWeatherApiKey();

            if (apiKey is null)
                return Content("Could not retrieve ApiKey");
            
            // Create query Url
            // city
            // country
            // units (for temperature, eg. F, or C°, set C° as default)
            // appId (later => retrieve from KeyVault)
            // sample query = https://api.openweathermap.org/data/2.5/find?q=Hannover&country=de&units=metric&appid=APIKEY


            // Create and set up WebClient

            var webClient = new WebClient();

            // Download data

            // Convert Json to object


            // Convert object to Dto/ViewModel
            // to be added to general entry



            return null;
        }

        private string GetWeatherApiKey()
        {
            var apiKey = _configuration
                .GetSection("ApiKeys")
                .GetSection("OpenWeatherApiKey").Value;
            
            return apiKey;
        }
    }
}
