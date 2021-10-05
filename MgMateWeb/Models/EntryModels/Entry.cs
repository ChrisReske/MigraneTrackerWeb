using System;
using System.Collections.Generic;

namespace MgMateWeb.Models.EntryModels
{
    public class Entry
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime PainDuration { get; set; }
        public List<AccompanyingSymptom> AccompanyingSymptoms { get; set; }
        public bool WasPainIncreasedDuringPhysicalActivity { get; set; }
        public DateTime DurationOfIncapacitation { get; set; }
        public DateTime DurationOfActivity { get; set; }

    }
}