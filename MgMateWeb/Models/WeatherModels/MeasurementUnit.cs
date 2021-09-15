using System.ComponentModel.DataAnnotations;

namespace MgMateWeb.Models.WeatherModels
{
    public enum MeasurementUnit
    {
        [Display(Name = "Standard")]
        Standard,

        [Display(Name = "Imperial")]
        Imperial,

        [Display(Name = "Metric")]
        Metric,
    }
}