using Newtonsoft.Json;

namespace MgMateWeb.Models.WeatherModels
{
    public class Wind
    {
        [JsonProperty("speed")]
        public float Speed { get; set; }
        
        [JsonProperty("deg")]
        // Wind direction, degrees (meteorological)
        public int DirectionInDegrees { get; set; }
    }
}