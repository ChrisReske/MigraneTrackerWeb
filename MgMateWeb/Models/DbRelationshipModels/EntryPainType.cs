using MgMateWeb.Models.EntryModels;

namespace MgMateWeb.Models.DbRelationshipModels
{
    public class EntryPainType
    {
        public int Id { get; set; }

        public int PainTypeId { get; set; }
        public virtual PainType PainType { get; set; }

        public int EntryId { get; set; }
        public virtual Entry Entry { get; set; }
    }
}