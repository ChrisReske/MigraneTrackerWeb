using System.Collections.Generic;
using MgMateWeb.Models.EntryModels;
using MgMateWeb.Models.FormModels;

namespace MgMateWeb.Interfaces.UtilsInterfaces
{
    public interface IEntryFormModelUtils
    {
        List<AccompanyingSymptom> GetSelectedAccompanyingSymptoms(EntryFormModel entryFormModel);
        List<Medication> GetSelectedMedications(EntryFormModel entryFormModel);
        List<PainType> GetSelectedPainTypes(EntryFormModel entryFormModel);
        WeatherDataEntry GetSelectedWeatherData(EntryFormModel entryFormModel);
        List<Trigger> GetSelectedTriggers(EntryFormModel entryFormModel);

    }
}