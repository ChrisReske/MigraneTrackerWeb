using System.Collections.Generic;
using System.Threading.Tasks;
using MgMateWeb.Models.EntryModels;

namespace MgMateWeb.Interfaces.RepositoryInterfaces
{
    public interface IEntryRepository : IRepository<Entry>
    {
        Task<List<Entry>> GetAllEntriesAndRelatedDataAsync();

        Task<Entry> ReloadEntryAsync();

        Task<Entry> GetSingleEntryAndRelatedDataAsync(int id);

    }
}