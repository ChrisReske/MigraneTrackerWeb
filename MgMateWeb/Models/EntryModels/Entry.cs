using System;
using System.Collections.Generic;
using MgMateWeb.Models.RelationshipModels;

namespace MgMateWeb.Models.EntryModels
{
    public class Entry
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public float HoursOfPain { get; set; }
        public List<EntryAccompanyingSymptom> EntryAccompanyingSymptoms { get; set; }
        public bool WasPainIncreasedDuringPhysicalActivity { get; set; }
        public float HoursOfIncapacitation { get; set; }
        public float HoursOfActivity { get; set; }

    }
}