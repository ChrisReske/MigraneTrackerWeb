namespace MgMateWeb.Models.WeatherModels
{
    public class WeatherDataFormModel
    {
        public string City { get; set; }
        public string Country { get; set; }

        // Todo: Create Enum and Dropdown / Checkboxes for options other than 'metric'
        public string MeasurementUnit { get; set; }
    }
}