using System;
using System.Collections.Generic;
using MgMateWeb.Models.EntryModels;

namespace MgMateWeb.Models.FormModels
{
    public class CreateEntryFormModel 
    {
        public IEnumerable<int> SelectedAccSymptoms { get; set; }

        public List<AccompanyingSymptom> AccompanyingSymptoms { get; set; }
        public DateTime CreationDate { get; set; }
        public float HoursOfPain { get; set; }
        public bool WasPainIncreasedDuringPhysicalActivity { get; set; }
        public float HoursOfIncapacitation { get; set; }
        public float HoursOfActivity { get; set; }
    }
}