﻿using System;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using MgMateWeb.Models.WeatherModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Configuration;
using static System.String;

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

            if (formModel is null)
            {
                return Content("Form model was null.");
            }

            // Build query url
            var url = BuildQueryUrl(formModel);

            // Create and set up WebClient

            var webClient = new WebClient();

            // Download data

            // Convert Json to object


            // Convert object to Dto/ViewModel
            // to be added to general entry



            return null;
        }

        private string BuildQueryUrl(WeatherDataFormModel formModel)
        {
            const string weatherApiBaseUrl = @"https://api.openweathermap.org/data/2.5/find";

            var apiKey = GetWeatherApiKey();
            if(IsNullOrEmpty(apiKey) || IsNullOrWhiteSpace(apiKey))
            {
                return Empty;
            }

            var uriBuilder = new UriBuilder(weatherApiBaseUrl);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query["q"] = formModel.City;
            query["country"] = formModel.Country;
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
    }
}
