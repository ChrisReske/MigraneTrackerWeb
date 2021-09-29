using System.Collections.Generic;
using MgMateWeb.Models.EntryModels;

namespace MgMateWeb.Models.FormModels
{
    public class EntryDtoParameters
    {
        public List<AccompanyingSymptom> SelectedAccompanyingSymptoms { get; set; }
        public List<PainType> SelectedPainTypes { get; set; }
        public List<Medication> SelectedMedications  { get; set; }
        public List<Trigger> SelectedTriggers { get; set; }
        public WeatherDataEntry SelectedWeatherData { get; set; }
    }
}