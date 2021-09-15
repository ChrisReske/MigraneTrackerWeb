using System;
using System.Collections.Generic;

namespace MgMateWeb.Models.EntryModels
{
    public class Entry
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public PainIntensity PainIntensity { get; set; }
        public DateTime PainDuration { get; set; }
        public List<PainType> PainTypes { get; set; }
        public List<AccompanyingSymptom> AccompanyingSymptoms { get; set; }
        public bool WasPainIncreasedDuringPhysicalActivity { get; set; }
        public List<Trigger> Triggers { get; set; }
        public List<Medication> Medications { get; set; }
        public DateTime DurationOfIncapacitation { get; set; }
        public DateTime DurationOfActivity { get; set; }
        public WeatherDataEntry WeatherData { get; set; }

    }
}