using MgMateWeb.Models.EntryModels;
using MgMateWeb.Persistence.Entities;
using MgMateWeb.Persistence.Interfaces.RepositoryInterfaces;

namespace MgMateWeb.Persistence.Repositories
{
    public class AccompanyingSymptomRepository : Repository<AccompanyingSymptom>, IAccompanyingSymptomRepository
    {
        public AccompanyingSymptomRepository(ApplicationDbContext context) : base(context)
        {

        }

    }
}