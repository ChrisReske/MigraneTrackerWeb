using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using MgMateWeb.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MgMateWeb.Models.EntryModels;
using MgMateWeb.Models.WeatherModels;
using MgMateWeb.Persistence;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using static System.String;

namespace MgMateWeb.Controllers
{
    public class WeatherDataEntriesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public WeatherDataEntriesController(
            ApplicationDbContext context, 
            IConfiguration configuration)
        {
            _context = context 
                       ?? throw new ArgumentNullException(nameof(context));
            _configuration = configuration 
                             ?? throw new ArgumentNullException(nameof(configuration));
        }

        // GET: WeatherDataEntries
        public async Task<IActionResult> Index()
        {
            return View(await _context.WeatherData.ToListAsync().ConfigureAwait(false));
        }

        // GET: WeatherDataEntries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weatherDataEntry = await _context.WeatherData
                .FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(false);
            if (weatherDataEntry == null)
            {
                return NotFound();
            }

            return View(weatherDataEntry);
        }

        // GET: WeatherDataEntries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WeatherDataEntries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("City,CountryCode,MeasurementUnit")] WeatherDataFormModel weatherDataFormModel)
        {
            if (!ModelState.IsValid)
            {
                return Content("Model state is invalid");
            }

            var weatherDataDto = await GetWeatherData(weatherDataFormModel)
                .ConfigureAwait(false);
            if(weatherDataDto is null)
            {
                return Content("Not weather data available.");
            }

            var weatherDataEntry = MapDtoToWeatherDataEntry(weatherDataDto);

            _context.Add(weatherDataEntry);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            
            return RedirectToAction(nameof(Index));

        }

        private static WeatherDataEntry MapDtoToWeatherDataEntry(WeatherDataDto weatherDataDto)
        {
            if (weatherDataDto is null)
            {
                return new WeatherDataEntry();
            }

            var weatherDataEntry = new WeatherDataEntry
            {
                CreationDate = weatherDataDto.CreationDate,
                City = weatherDataDto.City,
                CountryCode = weatherDataDto.CountryCode,
                Humidity = weatherDataDto.Humidity,
                Pressure = weatherDataDto.Pressure,
                Temperature = weatherDataDto.Temperature
            };
            return weatherDataEntry;
        }

        // GET: WeatherDataEntries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weatherDataEntry = await _context.WeatherData.FindAsync(id).ConfigureAwait(false);
            if (weatherDataEntry == null)
            {
                return NotFound();
            }
            return View(weatherDataEntry);
        }

        // POST: WeatherDataEntries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CreationDate,City,CountryCode,Temperature,Pressure,Humidity")] WeatherDataEntry weatherDataEntry)
        {
            if (id != weatherDataEntry.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(weatherDataEntry);
                    await _context.SaveChangesAsync()
                        .ConfigureAwait(false);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WeatherDataEntryExists(weatherDataEntry.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(weatherDataEntry);
        }

        // GET: WeatherDataEntries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weatherDataEntry = await _context.WeatherData
                .FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(false);
            if (weatherDataEntry == null)
            {
                return NotFound();
            }

            return View(weatherDataEntry);
        }

        // POST: WeatherDataEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var weatherDataEntry = await _context.WeatherData.FindAsync(id).ConfigureAwait(false);
            _context.WeatherData.Remove(weatherDataEntry);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return RedirectToAction(nameof(Index));
        }

        private bool WeatherDataEntryExists(int id)
        {
            return _context.WeatherData.Any(e => e.Id == id);
        }

        #region private methods (retrieve weather data)

        private static WeatherDataDto MapWeatherDataToDto(WeatherData weatherData)
        {
            if (weatherData is null)
            {
                return new WeatherDataDto();
            }

            var weatherDataDto = new WeatherDataDto
            {
                // Todo: Create individual methods for select statements in this block

                City = weatherData.Details.Select(d => d.Name).FirstOrDefault(),
                CountryCode = weatherData.Details.Select(d => d.System.Country).FirstOrDefault(),
                CreationDate = DateTime.Now,
                Humidity = weatherData.Details.Select(d => d.Main.Humidity).FirstOrDefault(),
                Pressure = weatherData.Details.Select(d => d.Main.Pressure).FirstOrDefault(),
                Temperature = weatherData.Details.Select(d => d.Main.Temperature).FirstOrDefault()
            };

            return weatherDataDto;
        }

        private static async Task<string> DownloadJsonFromApiAsync(string uri)
        {
            if (IsNullOrEmpty(uri) || IsNullOrWhiteSpace(uri))
            {
                return Empty;
            }

            var webClient = new WebClient();
            var weatherDataJson = await webClient
                .DownloadStringTaskAsync(uri)
                .ConfigureAwait(false);

            return await Task.FromResult(weatherDataJson).ConfigureAwait(false);
        }

        private string BuildQueryUrl(WeatherDataFormModel formModel)
        {
            const string weatherApiBaseUrl = @"https://api.openweathermap.org/data/2.5/find";

            var apiKey = GetWeatherApiKey();
            if (IsNullOrEmpty(apiKey) || IsNullOrWhiteSpace(apiKey))
            {
                return Empty;
            }

            var uriBuilder = new UriBuilder(weatherApiBaseUrl);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query["q"] = formModel.City;
            query["country"] = formModel.CountryCode;
            query["units"] = formModel.MeasurementUnit.ToString().ToLower();
            query["appid"] = apiKey;
            uriBuilder.Query = query.ToString()!;

            var url = uriBuilder.ToString();
            return url;
        }

        private string GetWeatherApiKey()
        {
            var apiKey = _configuration
                .GetSection("ApiKeys")
                .GetSection("OpenWeatherApiKey").Value;

            return apiKey;
        }

        private async Task<WeatherDataDto> GetWeatherData(WeatherDataFormModel formModel)
        {
            var weatherDataDto = new WeatherDataDto();

            // Build query url
            var uri = BuildQueryUrl(formModel);
            if (IsNullOrEmpty(uri) || IsNullOrWhiteSpace(uri))
            {
                return weatherDataDto;
            }

            // Download data
            var weatherDataJson = await DownloadJsonFromApiAsync(uri)
                .ConfigureAwait(false);
            if (IsNullOrEmpty(weatherDataJson)
                || IsNullOrWhiteSpace(weatherDataJson))
            {
                return weatherDataDto;
            }

            // Convert Json to object
            var weatherData = JsonConvert.DeserializeObject<WeatherData>(weatherDataJson);
            if (weatherData is null)
            {
                return weatherDataDto;
            }

            // Convert object to Dto/ViewModel
            weatherDataDto = MapWeatherDataToDto(weatherData);
            return weatherDataDto;
        }


        #endregion

    }
}
