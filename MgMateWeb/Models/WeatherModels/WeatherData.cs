using Newtonsoft.Json;

namespace MgMateWeb.Models.WeatherModels
{
    public class WeatherData
    {
        [JsonProperty("coord")]
        public Coord coord { get; set; }
        
        [JsonProperty("weather")]
        public Weather[] weather { get; set; }
        
        [JsonProperty("_base")]
        public string _base { get; set; }
        
        [JsonProperty("main")]
        public Main main { get; set; }
        
        
        [JsonProperty("visibility")]
        public int visibility { get; set; }
        
        [JsonProperty("wind")]
        public Wind wind { get; set; }
        
        [JsonProperty("clouds")]
        public Clouds clouds { get; set; }
        
        [JsonProperty("dt")]
        public int dt { get; set; }
        
        [JsonProperty("sys")]
        public Sys sys { get; set; }
        
        [JsonProperty("timezone")]
        public int timezone { get; set; }
        
        [JsonProperty("id")]
        public int id { get; set; }
        
        [JsonProperty("name")]
        public string name { get; set; }
        
        [JsonProperty("cod")]
        public int cod { get; set; }

    }

    public class Coord
    {
        public float lon { get; set; }
        public float lat { get; set; }
    }

    public class Main
    {
        public float temp { get; set; }
        public float feels_like { get; set; }
        public float temp_min { get; set; }
        public float temp_max { get; set; }
        public int pressure { get; set; }
        public int humidity { get; set; }
    }

    public class Wind
    {
        public float speed { get; set; }
        public int deg { get; set; }
    }

    public class Clouds
    {
        public int all { get; set; }
    }

    public class Sys
    {
        public int type { get; set; }
        public int id { get; set; }
        public float message { get; set; }
        public string country { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
    }

    public class Weather
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

}