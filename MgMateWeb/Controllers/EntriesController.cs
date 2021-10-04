using System;
using System.Linq;
using System.Threading.Tasks;
using MgMateWeb.Interfaces.UtilsInterfaces;
using MgMateWeb.Models.DbRelationshipModels;
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
        private readonly ICustomMapper _customMapper;

        public EntriesController(
            ApplicationDbContext context, 
            ICustomMapper customMapper)
        {
            _context = context 
                       ?? throw new ArgumentNullException(nameof(context));
            _customMapper = customMapper 
                            ?? throw new ArgumentNullException(nameof(customMapper));
        }

        // GET: Entries
        public async Task<IActionResult> Index()
        {
            return View(await _context.Entries.ToListAsync().ConfigureAwait(false));
        }

        // GET: Entries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entry = await _context.Entries
                .FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(false);
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

            // Create initial entry to get id
            var initialEntry = new Entry()
            {
                CreationDate = DateTime.Now
            };

            _context.Add(initialEntry);
            await _context
                .SaveChangesAsync()
                .ConfigureAwait(false);


            var initialEntryFromDb = await _context.Entries
                .OrderByDescending(e => e.CreationDate)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);


            foreach (var painTypeId in entryFormModel.SelectedPainTypes)
            {
                var entryPainType = new EntryPainType()
                {
                    EntryId = initialEntryFromDb.Id,
                    PainTypeId = painTypeId
                };

                _context.Add(entryPainType); 
                await _context.SaveChangesAsync()
                    .ConfigureAwait(false);
            }

            var test = initialEntryFromDb;

            _context.Add(initialEntryFromDb);
            await _context.SaveChangesAsync()
                .ConfigureAwait(false);
            
            return RedirectToAction(nameof(Index));
        }

        // GET: Entries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entry = await _context.Entries.FindAsync(id).ConfigureAwait(false);
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
                    await _context.SaveChangesAsync().ConfigureAwait(false);
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
                .FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(false);
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
            var entry = await _context.Entries.FindAsync(id).ConfigureAwait(false);
            _context.Entries.Remove(entry);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return RedirectToAction(nameof(Index));
        }

        private bool EntryExists(int id)
        {
            return _context.Entries.Any(e => e.Id == id);
        }

    }
}
