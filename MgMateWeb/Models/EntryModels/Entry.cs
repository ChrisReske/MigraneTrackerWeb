using System;
using System.Collections.Generic;

namespace MgMateWeb.Models.EntryModels
{
    public class Entry
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public float HoursOfPain { get; set; }
        public List<AccompanyingSymptom> AccompanyingSymptoms { get; set; }
        public bool WasPainIncreasedDuringPhysicalActivity { get; set; }
        public float HoursOfIncapacitation { get; set; }
        public float HoursOfActivity { get; set; }

    }
}