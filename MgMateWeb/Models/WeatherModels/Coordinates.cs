using Newtonsoft.Json;

namespace MgMateWeb.Models.WeatherModels
{
    public class Coordinates
    {
        [JsonProperty("lon")]
        public float Longitude { get; set; }
        
        [JsonProperty("lat")]
        public float Latitude { get; set; }
    }
}