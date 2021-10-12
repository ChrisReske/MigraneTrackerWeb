using MgMateWeb.Interfaces.RepositoryInterfaces;
using MgMateWeb.Models.RelationshipModels;


namespace MgMateWeb.Persistence.Repositories
{
    public class EntryAccompanyingSymptomRepository : Repository<EntryAccompanyingSymptom>, IEntryAccompanyingSymptomsRepository
    {

        public EntryAccompanyingSymptomRepository(ApplicationDbContext context) : base(context)
        {
            
        }
        
    }
}