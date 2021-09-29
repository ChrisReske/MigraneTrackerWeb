using System.Collections.Generic;
using MgMateWeb.Models.EntryModels;

namespace MgMateWeb.Dto
{
    public class EntryDto
    {
        public PainIntensity PainIntensity { get; set; }
        public float HoursOfPain { get; set; }
        public List<PainType> PainTypes { get; set; }
        public List<AccompanyingSymptom> AccompanyingSymptoms { get; set; }
        public bool WasPainIncreasedDuringPhysicalActivity { get; set; }
        public List<Trigger> Triggers { get; set; }
        public List<Medication> Medications { get; set; }
        public float HoursOfIncapacitation { get; set; }
        public float HoursOfActivity { get; set; }
        public WeatherDataEntry WeatherData { get; set; }

    }
}