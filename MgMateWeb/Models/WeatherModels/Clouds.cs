using Newtonsoft.Json;

namespace MgMateWeb.Models.WeatherModels
{
    public class Clouds
    {
        [JsonProperty("all")]
        //  Cloudiness, %
        public int All { get; set; }
    }
}