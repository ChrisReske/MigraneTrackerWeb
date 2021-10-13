using System;
using System.Threading.Tasks;
using MgMateWeb.Dto;
using MgMateWeb.Interfaces.MapperInterfaces;
using MgMateWeb.Models.EntryModels;
using MgMateWeb.Models.FormModels;

namespace MgMateWeb.Utils.Mappers
{
    public class EntryMapper : IEntryMapper
    {

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

        public async Task<EntryDto> MapEntryToEntryDtoAsync(Entry entry)
        {
            if (entry is null)
            {
                return new EntryDto();
            }

            var entryDto = new EntryDto
            {
                CreationDate = entry.CreationDate,
                EntryAccompanyingSymptoms = entry.EntryAccompanyingSymptoms,
                HoursOfIncapacitation = entry.HoursOfIncapacitation,
                HoursOfActivity = entry.HoursOfActivity,
                HoursOfPain = entry.HoursOfPain,
                Id = entry.Id,
                WasPainIncreasedDuringPhysicalActivity = entry.WasPainIncreasedDuringPhysicalActivity,
                LastChangedAt = entry.LastChangedAt,
            };

            return await Task.FromResult(entryDto);
        }

        public async Task<Entry> MapEntryFromEntryDtoAsync(EntryDto entryDto)
        {
            if (entryDto is null)
            {
                return new Entry();
            }

            var entry = new Entry
            {
                CreationDate = entryDto.CreationDate,
                WasPainIncreasedDuringPhysicalActivity = entryDto.WasPainIncreasedDuringPhysicalActivity,
                HoursOfIncapacitation = entryDto.HoursOfIncapacitation,
                HoursOfActivity = entryDto.HoursOfActivity,
                HoursOfPain = entryDto.HoursOfPain,
                EntryAccompanyingSymptoms = entryDto.EntryAccompanyingSymptoms,
                Id = entryDto.Id,
                LastChangedAt = DateTime.Now
            };

            return await Task.FromResult(entry);
        }

    }
}