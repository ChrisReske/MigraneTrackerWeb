using System;

namespace MgMateWeb.Dto
{
    public class WeatherDataDto
    {
        public DateTime CreationDate { get; set; }
        public string City { get; set; }
        public string CountryCode { get; set; }
        public float Temperature { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
    }
}