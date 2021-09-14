using MgMateWeb.Models.WeatherModels;
using Newtonsoft.Json;

namespace MgMateWeb.Models.WeatherModels
{
    public class WeatherDataNew
    {
        [JsonProperty("message")]
        public string Message { get; set; }
        
        [JsonProperty("cod")]
        public string Cod { get; set; }
        
        [JsonProperty("count")]
        public int Count { get; set; }
        
        [JsonProperty("list")]
        public List[] list { get; set; }

    }
}

public class List
{
    [JsonProperty("id")]
    public int id { get; set; }
    
    [JsonProperty("name")]
    public string name { get; set; }
    
    [JsonProperty("coord")]
    public Coord coord { get; set; }
    
    [JsonProperty("main")]
    public Main main { get; set; }
    
    [JsonProperty("dt")]
    public int dt { get; set; }
    
    [JsonProperty("wind")]
    public Wind wind { get; set; }
    
    [JsonProperty("sys")]
    public Sys sys { get; set; }
    
    [JsonProperty("rain")]
    public Rain rain { get; set; }
    
    [JsonProperty("snow")]
    public Snow snow { get; set; }
    
    [JsonProperty("clouds")]
    public Clouds clouds { get; set; }
    
    [JsonProperty("weather")]
    public Weather[] weather { get; set; }
}

public class Coord
{
    [JsonProperty("lat")]
    public float Lat { get; set; }
    
    [JsonProperty("lon")]
    public float Lon { get; set; }
}

public class Main
{
    [JsonProperty("temp")]
    public float Temp { get; set; }
    
    [JsonProperty("feels_like")]
    public float FeelsLike { get; set; }
    
    [JsonProperty("temp_min")]
    public float TempMin { get; set; }
    
    [JsonProperty("temp_max")]
    public float TempMax { get; set; }
   
    [JsonProperty("pressure")]
    public int Pressure { get; set; }
    
    [JsonProperty("humidity")]
    public int Humidity { get; set; }
}

public class Wind
{
    [JsonProperty("speed")]
    public float Speed { get; set; }
    
    [JsonProperty("deg")]
    public int Deg { get; set; }
}

public class Sys
{
    [JsonProperty("country")]
    public string Country { get; set; }
}

public class Clouds
{
    [JsonProperty("all")]
    public int All { get; set; }
}

public class Weather
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("main")]
    public string Main { get; set; }
    
    [JsonProperty("description")]
    public string Description { get; set; }
    
    [JsonProperty("icon")]
    public string Icon { get; set; }
}
