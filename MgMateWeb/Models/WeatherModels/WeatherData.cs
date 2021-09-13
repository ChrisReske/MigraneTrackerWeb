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
        [JsonProperty("lon")]
        public float lon { get; set; }
        
        [JsonProperty("lat")]
        public float lat { get; set; }
    }

    public class Main
    {
        [JsonProperty("temp")]
        public float temp { get; set; }
        
        [JsonProperty("feels_like")]
        public float feels_like { get; set; }
        
        [JsonProperty("temp_min")]
        public float temp_min { get; set; }
        
        [JsonProperty("temp_max")]
        public float temp_max { get; set; }
        
        [JsonProperty("pressure")]
        public int pressure { get; set; }
        
        [JsonProperty("humidity")]
        public int humidity { get; set; }
    }

    public class Wind
    {
        [JsonProperty("speed")]
        public float speed { get; set; }
        
        [JsonProperty("deg")]
        public int deg { get; set; }
    }

    public class Clouds
    {
        [JsonProperty("all")]
        public int all { get; set; }
    }

    public class Sys
    {
        [JsonProperty("type")]
        public int type { get; set; }
        
        [JsonProperty("id")]
        public int id { get; set; }
        
        [JsonProperty("message")]
        public float message { get; set; }
        
        [JsonProperty("country")]
        public string country { get; set; }
        
        [JsonProperty("sunrise")]
        public int sunrise { get; set; }
        
        [JsonProperty("sunset")]
        public int sunset { get; set; }
    }

    public class Weather
    {
        [JsonProperty("id")]
        public int id { get; set; }
        
        [JsonProperty("main")]
        public string main { get; set; }
        
        [JsonProperty("description")]
        public string description { get; set; }
        
        [JsonProperty("icon")]
        public string icon { get; set; }
    }

}