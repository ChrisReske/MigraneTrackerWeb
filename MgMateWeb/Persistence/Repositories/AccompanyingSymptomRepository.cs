using MgMateWeb.Interfaces.RepositoryInterfaces;
using MgMateWeb.Models.EntryModels;

namespace MgMateWeb.Persistence.Repositories
{
    public class AccompanyingSymptomRepository : Repository<AccompanyingSymptom>, IAccompanyingSymptomsRepository
    {
        public AccompanyingSymptomRepository(ApplicationDbContext context) : base(context)
        {
            
        }
    }
}