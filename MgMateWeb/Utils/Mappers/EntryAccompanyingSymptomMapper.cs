using System.Threading.Tasks;
using MgMateWeb.Interfaces.MapperInterfaces;
using MgMateWeb.Models.EntryModels;
using MgMateWeb.Models.RelationshipModels;

namespace MgMateWeb.Utils.Mappers
{
    public class EntryAccompanyingSymptomMapper : IEntryAccompanyingSymptomMapper
    {
        public async Task<EntryAccompanyingSymptom> CreateEntryAccompanyingSymptomAsync(
            Entry entryReloaded,
            AccompanyingSymptom symptom)
        {
            if (entryReloaded is null
                || symptom is null)
            {
                return new EntryAccompanyingSymptom();
            }

            var entryAccompanyingSymptom = new EntryAccompanyingSymptom
            {
                Entry = entryReloaded,
                EntryId = entryReloaded.Id,
                AccompanyingSymptom = symptom,
                AccompanyingSymptomId = symptom.Id
            };

            return await Task
                .FromResult(entryAccompanyingSymptom)
                .ConfigureAwait(false);
        }

    }
}