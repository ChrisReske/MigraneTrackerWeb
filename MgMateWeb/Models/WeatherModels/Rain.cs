using Newtonsoft.Json;

namespace MgMateWeb.Models.WeatherModels
{
    public class Rain
    {
        [JsonProperty("1h")]
        // Rain volume for the last 1 hour, mm
        public double RainLastHourInMm { get; set; }

        [JsonProperty("3h")]
        // Rain volume for the last 3 hours, mm
        public double RainLast3HoursInMm { get; set; }
    }
}