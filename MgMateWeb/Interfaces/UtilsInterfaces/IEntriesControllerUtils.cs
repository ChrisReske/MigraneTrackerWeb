using System.Threading.Tasks;
using MgMateWeb.Models.EntryModels;

namespace MgMateWeb.Interfaces.UtilsInterfaces
{
    public interface IEntriesControllerUtils
    {
        Task<bool> SaveEntryToDbAsync(Entry entry);

        Task<AccompanyingSymptom> FindAccompanyingSymptomById(int selectedSymptom);

        Task<bool> EntryExists(int id);

    }
}