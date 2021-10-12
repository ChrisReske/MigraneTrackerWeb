using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MgMateWeb.Interfaces.PersistenceInterfaces;
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
        #region Fields and constants

        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructor(s)

        public EntriesController(
            ApplicationDbContext context, 
            IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork 
                          ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        #endregion

        #region Entry / Index

        // GET: Entries
        public async Task<IActionResult> Index()
        {
            var entries = await _unitOfWork
                .Entries
                .GetAllEntriesAndRelatedDataAsync()
                .ConfigureAwait(false);

            return View(entries);
        }

        #endregion

        #region Entry / Details 

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

        #endregion

        #region Entry / Create (GET and POST)

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

            var entry = await CreateInitialEntryAsync(createEntryFormModel);
            if (entry is null)
            {
                return RedirectToAction(nameof(Index));
            }

            var wasEntrySaved = await SaveEntryToDbAsync(entry)
                .ConfigureAwait(false);
            if (wasEntrySaved is false)
            {
                return RedirectToAction(nameof(Index));
            }

            var selectedSymptoms = createEntryFormModel.SelectedAccSymptoms;
            var symptoms = new List<AccompanyingSymptom>();
            var entryAccompanyingSymptoms = new List<EntryAccompanyingSymptom>();

            var entryReloaded = await ReloadEntry();
            if (entryReloaded is null)
            {
                return RedirectToAction(nameof(Index));
            }

            foreach (var selectedSymptom in selectedSymptoms)
            {
                var symptom = await FindAccompanyingSymptomById(selectedSymptom)
                    .ConfigureAwait(false);

                symptoms.Add(symptom);

                var entryAccompanyingSymptom = 
                    await CreateEntryAccompanyingSymptom(entryReloaded, symptom)
                    .ConfigureAwait(false);

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

        #endregion

        #region Entry / Edit (GET and POST)

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

        #endregion

        #region Entry / Delete (GET and POST)

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

        #endregion

        #region Private Methods

        private async Task<bool> SaveEntryToDbAsync(Entry entry)
        {
            if (entry is null)
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

        private async Task<AccompanyingSymptom> FindAccompanyingSymptomById(int selectedSymptom)
        {
            if (selectedSymptom <= 0)
            {
                return new AccompanyingSymptom();
            }

            var symptom = await _context.AccompanyingSymptoms
                .FindAsync(selectedSymptom)
                .ConfigureAwait(false);
            return symptom;
        }

        private async Task<Entry> CreateInitialEntryAsync(CreateEntryFormModel createEntryFormModel)
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

        private async Task<EntryAccompanyingSymptom> CreateEntryAccompanyingSymptom(
            Entry entryReloaded, 
            AccompanyingSymptom symptom)
        {
            if(entryReloaded is null 
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


        #endregion
    }
}
