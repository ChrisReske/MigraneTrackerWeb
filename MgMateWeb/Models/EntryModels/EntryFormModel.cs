using System;
using System.Collections.Generic;

namespace MgMateWeb.Models.EntryModels
{
    public class EntryFormModel
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
        public List<WeatherDataEntry> WeatherData { get; set; }
        public IEnumerable<int> SelectedSymptoms { get; set; }
        public IEnumerable<int> SelectedPainTypes { get; set; }
        public IEnumerable<int> SelectedTriggers { get; set; }
    }
}