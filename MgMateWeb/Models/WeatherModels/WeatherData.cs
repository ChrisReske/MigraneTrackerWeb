using Newtonsoft.Json;

namespace MgMateWeb.Models.WeatherModels
{
    public class WeatherData
    {
        [JsonProperty("Coordinates")]
        public Coordinates Coordinates { get; set; }
        
        [JsonProperty("weather")]
        public Weather[] Weather { get; set; }
        
        [JsonProperty("_base")]
        public string Base { get; set; }
        
        [JsonProperty("main")]
        public Main Main { get; set; }
        
        [JsonProperty("visibility")]
        public int Visibility { get; set; }
        
        [JsonProperty("wind")]
        public Wind Wind { get; set; }
        
        [JsonProperty("clouds")]
        public Clouds Clouds { get; set; }
        
        [JsonProperty("dt")]
        //Time of data calculation, unix, UTC 
        public int TimeOfDataCalculation { get; set; }
        
        [JsonProperty("System")]
        public System System { get; set; }
        
        [JsonProperty("timezone")]
        // Shift in seconds from UTC 
        public int Timezone { get; set; }
        
        [JsonProperty("id")]
        // City Id
        public int Id { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("cod")]
        // Internal API parameter
        // (cf. documentation https://bit.ly/3tEeysM)
        public int Cod { get; set; }

    }
}