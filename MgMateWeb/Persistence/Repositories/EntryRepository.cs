using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MgMateWeb.Interfaces.RepositoryInterfaces;
using MgMateWeb.Models.EntryModels;
using Microsoft.EntityFrameworkCore;


namespace MgMateWeb.Persistence.Repositories
{
    public class EntryRepository : Repository<Entry>, IEntryRepository
    {
        public ApplicationDbContext Context { get; }

        public EntryRepository(ApplicationDbContext context) : base(context)
        {
            Context = context;
        }

        public async Task<List<Entry>> GetAllEntriesAndRelatedDataAsync()
        {
            var entries = await Context.Entries
                .Include(e => e.EntryAccompanyingSymptoms)
                .ThenInclude(e => e.AccompanyingSymptom)
                .ToListAsync()
                .ConfigureAwait(false);
            return entries;
        }

        public async Task<Entry> ReloadEntryAsync()
        {
            var entryReloaded = await Context.Entries
                .OrderByDescending(entry => entry.CreationDate)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);
            return entryReloaded;
        }

    }
}