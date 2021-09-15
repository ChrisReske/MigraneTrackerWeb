using Newtonsoft.Json;

namespace MgMateWeb.Models.WeatherModels
{
    public class System
    {
        [JsonProperty("type")]
        public int Type { get; set; }
        
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("message")]
        public float Message { get; set; }
        
        [JsonProperty("country")]
        public string Country { get; set; }
        
        [JsonProperty("sunrise")]
        public int Sunrise { get; set; }
        
        [JsonProperty("sunset")]
        public int Sunset { get; set; }
    }
}