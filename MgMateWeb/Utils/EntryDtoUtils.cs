using System;
using MgMateWeb.Controllers;
using MgMateWeb.Dto;
using MgMateWeb.Interfaces.UtilsInterfaces;
using MgMateWeb.Models.FormModels;

namespace MgMateWeb.Utils
{
    public class EntryDtoUtils : IEntryDtoUtils
    {
        private readonly IEntryDtoParameterUtils _entryDtoParameterUtils;

        public EntryDtoUtils(IEntryDtoParameterUtils entryDtoParameterUtils)
        {
            _entryDtoParameterUtils = entryDtoParameterUtils 
                                      ?? throw new ArgumentNullException(nameof(entryDtoParameterUtils));
        }


        public EntryDto CreateEntryDto(EntryFormModel entryFormModel)
        {
            var entryDtoParams = _entryDtoParameterUtils
                .CreateEntryDtoParameters(entryFormModel);

            if (entryDtoParams is null)
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