using MgMateWeb.Interfaces.RepositoryInterfaces;
using MgMateWeb.Models.EntryModels;

namespace MgMateWeb.Persistence.Repositories
{
    public class EntryRepository : Repository<Entry>, IEntryRepository
    {
        public EntryRepository(ApplicationDbContext context) : base(context)
        {
            
        }
    }
}