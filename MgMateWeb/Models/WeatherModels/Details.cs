using Newtonsoft.Json;

namespace MgMateWeb.Models.WeatherModels
{
    public class Details
    {
        [JsonProperty("id")]
        public int Id { get; set; }
    
        [JsonProperty("name")]
        public string Name { get; set; }
    
        [JsonProperty("coord")]
        public Coordinates Coordinates { get; set; }
    
        [JsonProperty("main")]
        public Main Main { get; set; }
    
        [JsonProperty("dt")]
        public int Dt { get; set; }
    
        [JsonProperty("wind")]
        public Wind Wind { get; set; }
    
        [JsonProperty("sys")]
        public MgMateWeb.Models.WeatherModels.System System { get; set; }
    
        [JsonProperty("rain")]
        public Rain Rain { get; set; }
    
        [JsonProperty("snow")]
        public Snow Snow { get; set; }
    
        [JsonProperty("clouds")]
        public Clouds Clouds { get; set; }
    
        [JsonProperty("weather")]
        public Weather[] Weather { get; set; }
    }
}