using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MgMateWeb.Models.EntryModels;
using MgMateWeb.Models.FormModels;
using MgMateWeb.Persistence.Entities;

namespace MgMateWeb.Controllers
{
    public class EntriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EntriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Entries
        public async Task<IActionResult> Index()
        {
            return View(await _context.Entries.ToListAsync());
        }

        // GET: Entries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entry = await _context.Entries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entry == null)
            {
                return NotFound();
            }

            return View(entry);
        }

        // GET: Entries/Create
        public IActionResult Create()
        {
            var painTypes = _context.PainTypes.ToList();
            var triggers = _context.Triggers.ToList();
            var medications = _context.Medications.ToList();
            var weatherData = _context.WeatherData.ToList();
            var accompanyingSymptoms = _context.AccompanyingSymptoms.ToList();

            var model = new EntryFormModel()
            {
                PainTypes = painTypes,
                Triggers = triggers,
                Medications = medications,
                WeatherData = weatherData,
                AccompanyingSymptoms = accompanyingSymptoms
            };

            return View(model);
        }

        // POST: Entries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EntryFormModel entryFormModel)
        {
            if (!ModelState.IsValid)
            {
                return View(entryFormModel);
            }

            var entryDtoParams = CreateEntryDtoParameters(entryFormModel);

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

            var testEntryDto = entryDto;

            //_context.Add(entry);
            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Entries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entry = await _context.Entries.FindAsync(id);
            if (entry == null)
            {
                return NotFound();
            }
            return View(entry);
        }

        // POST: Entries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CreationDate,PainIntensity,PainDuration,WasPainIncreasedDuringPhysicalActivity,DurationOfIncapacitation,DurationOfActivity,SelectedWeatherData")] Entry entry)
        {
            if (id != entry.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntryExists(entry.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(entry);
        }

        // GET: Entries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entry = await _context.Entries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entry == null)
            {
                return NotFound();
            }

            return View(entry);
        }

        // POST: Entries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entry = await _context.Entries.FindAsync(id);
            _context.Entries.Remove(entry);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntryExists(int id)
        {
            return _context.Entries.Any(e => e.Id == id);
        }

        #region Custom private methods

        private List<AccompanyingSymptom> GetSelectedAccompanyingSymptoms(EntryFormModel entryFormModel)
        {
            var accompanyingSymptoms = entryFormModel
                .SelectedSymptoms
                .Select(selectedSymptom => _context
                    .Find<AccompanyingSymptom>(selectedSymptom))
                .ToList();
            return accompanyingSymptoms;
        }

        private List<Medication> GetSelectedMedications(EntryFormModel entryFormModel)
        {
            return entryFormModel.SelectedMedications
                .Select(selectedMedication => _context.Medications
                    .Find(selectedMedication))
                .ToList();
        }

        private List<PainType> GetSelectedPainTypes(EntryFormModel entryFormModel)
        {
            return entryFormModel.SelectedPainTypes
                .Select(selectedPainType => _context.PainTypes
                    .Find(selectedPainType))
                .ToList();
        }

        private WeatherDataEntry GetSelectedWeatherData(EntryFormModel entryFormModel)
        {
            var selectedWeatherData = _context.WeatherData
                .Find(entryFormModel.SelectedWeatherData);
            return selectedWeatherData;
        }

        private List<Trigger> GetSelectedTriggers(EntryFormModel entryFormModel)
        {
            return entryFormModel.SelectedTriggers
                .Select(selectedTrigger => _context.Triggers
                    .Find(selectedTrigger))
                .ToList();
        }

        private EntryDtoParameters CreateEntryDtoParameters(EntryFormModel entryFormModel)
        {
            var selectedAccompanyingSymptoms = GetSelectedAccompanyingSymptoms(entryFormModel);
            var selectedPainTypes = GetSelectedPainTypes(entryFormModel);
            var selectedMedications = GetSelectedMedications(entryFormModel);
            var selectedTriggers = GetSelectedTriggers(entryFormModel);
            var selectedWeatherData = GetSelectedWeatherData(entryFormModel);

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

        #endregion
    }
}
