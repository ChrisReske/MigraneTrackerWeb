using Newtonsoft.Json;

namespace MgMateWeb.Models.WeatherModels
{
    public class Snow
    {
        [JsonProperty("1h")]
        // Snow volume for the last 1 hour, mm
        public double SnowLastHourInMm { get; set; }

        [JsonProperty("3h")]
        // Rain volume for the last 3 hours, mm
        public double SnowLast3HoursInMm { get; set; }
    }
}