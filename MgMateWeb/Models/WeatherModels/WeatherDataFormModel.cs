using System.ComponentModel.DataAnnotations;

namespace MgMateWeb.Models.WeatherModels
{
    public class WeatherDataFormModel
    {
        [Required]
        public string City { get; set; }
        
        [Required]
        public string CountryCode { get; set; }

        public MeasurementUnit MeasurementUnit { get; set; }
    }
}