using System;
using MgMateWeb.Interfaces.UtilsInterfaces;
using MgMateWeb.Models.FormModels;

namespace MgMateWeb.Utils
{
    public class EntryDtoParameterUtils : IEntryDtoParameterUtils
    {
        private readonly IEntryFormModelUtils _entryFormModelUtils;

        public EntryDtoParameterUtils(IEntryFormModelUtils entryFormModelUtils)
        {
            _entryFormModelUtils = entryFormModelUtils 
                                   ?? throw new ArgumentNullException(nameof(entryFormModelUtils));
        }


        public EntryDtoParameters CreateEntryDtoParameters(EntryFormModel entryFormModel)
        {
            if (entryFormModel is null)
            {
                return new EntryDtoParameters();
            }

            // TODO: Add null checks and add return statements

            var selectedAccompanyingSymptoms =
                _entryFormModelUtils.GetSelectedAccompanyingSymptoms(entryFormModel);

            var selectedPainTypes =
                _entryFormModelUtils.GetSelectedPainTypes(entryFormModel);

            var selectedMedications = _entryFormModelUtils
                .GetSelectedMedications(entryFormModel);

            var selectedTriggers = _entryFormModelUtils
                .GetSelectedTriggers(entryFormModel);

            var selectedWeatherData = _entryFormModelUtils
                .GetSelectedWeatherData(entryFormModel);

            var entryDtoParameters = new EntryDtoParameters
            {
                SelectedAccompanyingSymptoms = selectedAccompanyingSymptoms,
                SelectedMedications = selectedMedications,
                SelectedPainTypes = selectedPainTypes,
                SelectedTriggers = selectedTriggers,
                SelectedWeatherData = selectedWeatherData
            };

            return entryDtoParameters;
        }

    }
}