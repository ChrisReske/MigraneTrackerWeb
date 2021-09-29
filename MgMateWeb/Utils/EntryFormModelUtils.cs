using System.Collections.Generic;
using System.Linq;
using MgMateWeb.Interfaces.UtilsInterfaces;
using MgMateWeb.Models.EntryModels;
using MgMateWeb.Models.FormModels;
using MgMateWeb.Persistence.Entities;

namespace MgMateWeb.Utils
{
    public class EntryFormModelUtils : IEntryFormModelUtils
    {
        private readonly ApplicationDbContext _context;

        public EntryFormModelUtils(ApplicationDbContext context)
        {
            _context = context;
        }


        public List<AccompanyingSymptom> GetSelectedAccompanyingSymptoms(EntryFormModel entryFormModel)
        {
            var accompanyingSymptoms = entryFormModel
                .SelectedSymptoms
                .Select(selectedSymptom => _context
                    .Find<AccompanyingSymptom>(selectedSymptom))
                .ToList();
            return accompanyingSymptoms;
        }

        public List<Medication> GetSelectedMedications(EntryFormModel entryFormModel)
        {
            return entryFormModel.SelectedMedications
                .Select(selectedMedication => _context.Medications
                    .Find(selectedMedication))
                .ToList();
        }

        public List<PainType> GetSelectedPainTypes(EntryFormModel entryFormModel)
        {
            return entryFormModel.SelectedPainTypes
                .Select(selectedPainType => _context.PainTypes
                    .Find(selectedPainType))
                .ToList();
        }

        public WeatherDataEntry GetSelectedWeatherData(EntryFormModel entryFormModel)
        {
            var selectedWeatherData = _context.WeatherData
                .Find(entryFormModel.SelectedWeatherData);
            return selectedWeatherData;
        }

        public List<Trigger> GetSelectedTriggers(EntryFormModel entryFormModel)
        {
            return entryFormModel.SelectedTriggers
                .Select(selectedTrigger => _context.Triggers
                    .Find(selectedTrigger))
                .ToList();
        }

    }
}