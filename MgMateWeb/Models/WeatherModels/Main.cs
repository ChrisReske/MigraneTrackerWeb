using Newtonsoft.Json;

namespace MgMateWeb.Models.WeatherModels
{
    public class Main
    {
        [JsonProperty("temp")]
        // Temperature. Unit Default: Kelvin
        public float Temperature { get; set; }
        
        [JsonProperty("feels_like")]
        // This temperature parameter accounts for
        // the human perception of weather. Unit Default: Kelvin
        public float FeelsLike { get; set; }
        
        [JsonProperty("temp_min")]
        //  Minimum temperature at the moment.
        // This is minimal currently observed temperature
        // (within large megalopolises and urban areas).
        // Unit Default: Kelvin
        public float MinimumTemperature { get; set; }
        
        [JsonProperty("temp_max")]
        // Maximum temperature at the moment.
        // This is maximal currently observed temperature
        // (within large megalopolises and urban areas).
        // Unit Default: Kelvin, 
        public float MaximumTemperature { get; set; }
        
        [JsonProperty("pressure")]
        // Atmospheric pressure
        // (on the sea level, if there is no
        // sea_level or grnd_level data), hPa
        public int Pressure { get; set; }
        
        [JsonProperty("humidity")]
        //  Humidity, %
        public int Humidity { get; set; }

        [JsonProperty("sea_level")]
        // Atmospheric pressure on the sea level, hPa
        public int PressureAtSeaLevel { get; set; }

        [JsonProperty("grnd_level")]
        // Atmospheric pressure on the ground level, hPa
        public int PressureAtGroundLevel { get; set; }

    }
}