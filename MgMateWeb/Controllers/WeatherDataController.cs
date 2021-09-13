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

            // Create and set up WebClient
            // Add api headers
            var webClient = new WebClient();

            // Download data

            // Convert Json to object


            // Convert object to Dto/ViewModel
            // to be added to general entry



            return null;
        }

    }
}
