using System;
using System.Threading.Tasks;
using MgMateWeb.Controllers;
using MgMateWeb.Dto;
using MgMateWeb.Interfaces.UtilsInterfaces;
using MgMateWeb.Models.EntryModels;
using MgMateWeb.Models.FormModels;

namespace MgMateWeb.Utils
{
    public class CustomMapper : ICustomMapper
    {
        private readonly IEntryDtoParameterUtils _entryDtoParameterUtils;

        public CustomMapper(IEntryDtoParameterUtils entryDtoParameterUtils)
        {
            _entryDtoParameterUtils = entryDtoParameterUtils 
                                      ?? throw new ArgumentNullException(nameof(entryDtoParameterUtils));
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

        public EntryDto CreateEntryDto(EntryFormModel entryFormModel)
        {
            var entryDtoParams = _entryDtoParameterUtils
                .CreateEntryDtoParameters(entryFormModel);

            if(entryDtoParams is null)
            {
                return new EntryDto();
            }

            var entryDto = new EntryDto()
            {
                AccompanyingSymptoms = entryDtoParams.SelectedAccompanyingSymptoms,
                PainTypes = entryDtoParams.SelectedPainTypes,
                HoursOfActivity = entryFormModel.HoursOfActivity,
                HoursOfIncapacitation = entryFormModel.HoursOfIncapacitation,
                HoursOfPain = entryFormModel.HoursOfPain,
                Medications = entryDtoParams.SelectedMedications,
                PainIntensity = entryFormModel.PainIntensity,
                Triggers = entryDtoParams.SelectedTriggers,
                WasPainIncreasedDuringPhysicalActivity = entryFormModel.WasPainIncreasedDuringPhysicalActivity,
                WeatherData = entryDtoParams.SelectedWeatherData
            };

            return entryDto;
        }

    }
}