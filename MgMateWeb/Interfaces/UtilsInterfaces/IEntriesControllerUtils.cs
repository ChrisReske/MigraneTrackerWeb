using System.Threading.Tasks;
using MgMateWeb.Models.EntryModels;
using MgMateWeb.Models.FormModels;
using MgMateWeb.Models.RelationshipModels;

namespace MgMateWeb.Interfaces.UtilsInterfaces
{
    public interface IEntriesControllerUtils
    {
        Task<bool> SaveEntryToDbAsync(Entry entry);

        Task<AccompanyingSymptom> FindAccompanyingSymptomById(int selectedSymptom);

        Task<EntryAccompanyingSymptom> CreateEntryAccompanyingSymptom(
            Entry entryReloaded,
            AccompanyingSymptom symptom);

        Task<Entry> CreateInitialEntryAsync(CreateEntryFormModel createEntryFormModel);

        Task<bool> EntryExists(int id);


    }
}