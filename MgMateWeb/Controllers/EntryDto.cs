using System;
using MgMateWeb.Models.EntryModels;

namespace MgMateWeb.Controllers
{
    public class EntryDto
    {
        public PainIntensity PainIntensity { get; set; }
        public float HoursOfPain { get; set; }
        public PainType PainType { get; set; }
        public AccompanyingSymptom AccompanyingSymptom { get; set; }
        public bool WasPainIncreasedDuringPhysicalActivity { get; set; }
        public Trigger Trigger { get; set; }
        public Medication Medication { get; set; }
        public float HoursOfIncapacitation { get; set; }
        public float HoursOfActivity { get; set; }
        public WeatherDataEntry WeatherData { get; set; }

    }
}