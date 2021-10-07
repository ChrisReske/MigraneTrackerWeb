using MgMateWeb.Models.EntryModels;

namespace MgMateWeb.Models.RelationshipModels
{
    public class EntryAccompanyingSymptom
    {
        public int Id { get; set; }

        public int EntryId { get; set; }

        public Entry Entry { get; set; }

        public int AccompanyingSymptomId { get; set; }
        
        public AccompanyingSymptom AccompanyingSymptom { get; set; }

    }
}