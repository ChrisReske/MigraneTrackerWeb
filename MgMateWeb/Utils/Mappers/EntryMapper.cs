using System;
using System.Threading.Tasks;
using MgMateWeb.Interfaces.MapperInterfaces;
using MgMateWeb.Models.EntryModels;
using MgMateWeb.Models.FormModels;
using MgMateWeb.Models.RelationshipModels;

namespace MgMateWeb.Utils.Mappers
{
    public class EntryMapper : IEntryMapper
    {
        public async Task<EntryAccompanyingSymptom> CreateEntryAccompanyingSymptom(
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


        public async Task<Entry> CreateInitialEntryAsync(CreateEntryFormModel createEntryFormModel)
        {
            if (createEntryFormModel is null)
            {
                return new Entry();
            }

            var entry = new Entry()
            {
                CreationDate = DateTime.Now,
                HoursOfActivity = createEntryFormModel.HoursOfActivity,
                HoursOfIncapacitation = createEntryFormModel.HoursOfIncapacitation,
                HoursOfPain = createEntryFormModel.HoursOfPain,
                WasPainIncreasedDuringPhysicalActivity = createEntryFormModel.WasPainIncreasedDuringPhysicalActivity
            };
            return await Task
                .FromResult(entry)
                .ConfigureAwait(false);
        }

    }
}