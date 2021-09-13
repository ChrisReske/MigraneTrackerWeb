using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MgMateWeb.Controllers
{
    public class WeatherDataController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //TODO Get Weather data from API
        public async Task<IActionResult> GetWeatherDataAsync()
        {
            // Create query Url
            // city
            // country
            // units (for temperature, eg. F, or C°, set C° as default)
            // appId (KeyVault ?)
            // sample query = https://api.openweathermap.org/data/2.5/find?q=Hannover&country=de&units=metric&appid=APIKEY


            // Create and set up WebClient

            var webClient = new WebClient();

            // Download data

            // Convert Json to object


            // Convert object to Dto/ViewModel
            // to be added to general entry



            return null;
        }

    }
}
