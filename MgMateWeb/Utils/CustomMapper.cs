using System;
using System.Threading.Tasks;
using MgMateWeb.Dto;
using MgMateWeb.Interfaces.UtilsInterfaces;
using MgMateWeb.Models.EntryModels;
using MgMateWeb.Models.FormModels;

namespace MgMateWeb.Utils
{
    public class CustomMapper : ICustomMapper
    {
        private readonly IEntryDtoUtils _entryDtoUtils;

        public CustomMapper(IEntryDtoUtils entryDtoUtils)
        {
            _entryDtoUtils = entryDtoUtils 
                             ?? throw new ArgumentNullException(nameof(entryDtoUtils));
        }


        public async Task<AccompanyingSymptom> CreateNewAccompanyingSymptomFromDtoAsync(AccompanyingSymptomDto accompanyingSymptomDto)
        {
            if(accompanyingSymptomDto is null)
            {
                return new AccompanyingSymptom();
            }

            accompanyingSymptomDto.CreationDate = DateTime.Now;

            var accompanyingSymptom = new AccompanyingSymptom
            {
                CreationDate = accompanyingSymptomDto.CreationDate,
                Description = accompanyingSymptomDto.Description,
                Id = accompanyingSymptomDto.Id
            };

            return await Task
                .FromResult(accompanyingSymptom)
                .ConfigureAwait(false);
        }

        public Entry MapEntryDtoToEntry(EntryFormModel entryFormModel)
        {
            var entryDto = _entryDtoUtils.CreateEntryDto(entryFormModel);

            var entry = new Entry()
            {
                CreationDate = DateTime.Now,
                AccompanyingSymptoms = entryDto.AccompanyingSymptoms,
                HoursOfActivity = entryDto.HoursOfActivity,
                HoursOfIncapacitation = entryDto.HoursOfIncapacitation,
                HoursOfPain = entryDto.HoursOfPain,
                Medications = entryDto.Medications,
                PainTypes = entryDto.PainTypes,
                PainIntensity = entryDto.PainIntensity,
                Triggers = entryDto.Triggers,
                WasPainIncreasedDuringPhysicalActivity = entryDto.WasPainIncreasedDuringPhysicalActivity,
                WeatherData = entryDto.WeatherData
            };

            return entry;
        }

    }
}