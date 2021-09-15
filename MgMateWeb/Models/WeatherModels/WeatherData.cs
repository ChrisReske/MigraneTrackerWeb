using Newtonsoft.Json;

namespace MgMateWeb.Models.WeatherModels
{
    public class WeatherData
    {
        [JsonProperty("message")]
        public string Message { get; set; }
        
        [JsonProperty("cod")]
        public string Cod { get; set; }
        
        [JsonProperty("count")]
        public int Count { get; set; }
        
        [JsonProperty("list")]
        public Details[] Details { get; set; }

    }
}