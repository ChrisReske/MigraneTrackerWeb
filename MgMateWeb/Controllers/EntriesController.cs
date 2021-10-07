using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MgMateWeb.Models.EntryModels;
using MgMateWeb.Models.FormModels;
using MgMateWeb.Models.RelationshipModels;
using MgMateWeb.Persistence;

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
            return View(await _context.Entries
                .Include(e => e.EntryAccompanyingSymptoms)
                .ThenInclude(e => e.AccompanyingSymptom)
                .ToListAsync()
                .ConfigureAwait(false));
        }

        // GET: Entries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entry = await _context.Entries
                .FirstOrDefaultAsync(m => m.Id == id)
                .ConfigureAwait(false);
            if (entry == null)
            {
                return NotFound();
            }

            return View(entry);
        }

        // GET: Entries/Create
        public IActionResult Create()
        {
            var accompanyingSymptoms = _context.AccompanyingSymptoms.ToList();

            var createEntryFormModel = new CreateEntryFormModel
            {
                AccompanyingSymptoms = accompanyingSymptoms
            };

            return View(createEntryFormModel);
        }

        // POST: Entries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateEntryFormModel createEntryFormModel)
        {
            if (!ModelState.IsValid)
            {
                return View(createEntryFormModel);
            }

            // Save blank entry first to access 'id' property
            var entry = new Entry()
            {
                CreationDate = DateTime.Now,
                HoursOfActivity = createEntryFormModel.HoursOfActivity,
                HoursOfIncapacitation = createEntryFormModel.HoursOfIncapacitation,
                HoursOfPain = createEntryFormModel.HoursOfPain,
                WasPainIncreasedDuringPhysicalActivity = createEntryFormModel.WasPainIncreasedDuringPhysicalActivity
            };

            var wasEntrySaved = await SaveEntryToDbAsync(entry)
                .ConfigureAwait(false);

            // Reload entry
            var selectedSymptoms = createEntryFormModel.SelectedAccSymptoms;
            var symptoms = new List<AccompanyingSymptom>();
            var entryAccompanyingSymptoms = new List<EntryAccompanyingSymptom>();

            var entryReloaded = await ReloadEntry();

            foreach (var selectedSymptom in selectedSymptoms)
            {
                var symptom = await _context.AccompanyingSymptoms
                    .FindAsync(selectedSymptom)
                    .ConfigureAwait(false);

                symptoms.Add(symptom);

                var entryAccompanyingSymptom = new EntryAccompanyingSymptom
                {
                    Entry = entryReloaded,
                    EntryId = entryReloaded.Id,
                    AccompanyingSymptom = symptom,
                    AccompanyingSymptomId = symptom.Id
                };

                _context.EntryAccompanyingSymptoms.Add(entryAccompanyingSymptom);
                await _context
                    .SaveChangesAsync()
                    .ConfigureAwait(false);

                entryAccompanyingSymptoms.Add(entryAccompanyingSymptom);
            }

            entryReloaded.EntryAccompanyingSymptoms = entryAccompanyingSymptoms;
            _context.Update(entry);

            return RedirectToAction(nameof(Index));
        }

        // GET: Entries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entry = await _context.Entries
                .FindAsync(id)
                .ConfigureAwait(false);
            
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,CreationDate,PainDuration,WasPainIncreasedDuringPhysicalActivity,DurationOfIncapacitation,DurationOfActivity")] Entry entry)
        {
            if (id != entry.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(entry);
            }

            try
            {
                _context.Update(entry);
                await _context
                    .SaveChangesAsync()
                    .ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntryExists(entry.Id))
                {
                    return NotFound();
                }

                throw;
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Entries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entry = await _context.Entries
                .FirstOrDefaultAsync(m => m.Id == id)
                .ConfigureAwait(false);

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
            var entry = await _context.Entries
                .FindAsync(id)
                .ConfigureAwait(false);
           
            _context.Entries.Remove(entry);
            
           await _context
                .SaveChangesAsync()
                .ConfigureAwait(false);
            
            return RedirectToAction(nameof(Index));
        }

        private bool EntryExists(int id)
        {
            return _context.Entries.Any(e => e.Id == id);
        }

        #region Private Methods

        private async Task<bool> SaveEntryToDbAsync(Entry entry)
        {
            if(entry is null)
            {
                return false;
            }

            try
            {
                _context.Add(entry);
                await _context
                    .SaveChangesAsync()
                    .ConfigureAwait(false);

                return await Task
                    .FromResult(true)
                    .ConfigureAwait(false);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private async Task<Entry> ReloadEntry()
        {
            var entryReloaded = await _context.Entries
                .OrderByDescending(entry => entry.CreationDate)
                .FirstOrDefaultAsync().ConfigureAwait(false);
            return entryReloaded;
        }


        #endregion
    }
}
