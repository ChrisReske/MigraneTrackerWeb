using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MgMateWeb.Models.EntryModels;
using MgMateWeb.Persistence.Entities;

namespace MgMateWeb.Controllers
{
    public class AccompanyingSymptomsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccompanyingSymptomsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SelectedAccompanyingSymptoms
        public async Task<IActionResult> Index()
        {
            return View(await _context.AccompanyingSymptoms
                .ToListAsync()
                .ConfigureAwait(false));
        }

        // GET: SelectedAccompanyingSymptoms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accompanyingSymptom = await _context.AccompanyingSymptoms
                .FirstOrDefaultAsync(m => m.Id == id)
                .ConfigureAwait(false);
            if (accompanyingSymptom == null)
            {
                return NotFound();
            }

            return View(accompanyingSymptom);
        }

        // GET: SelectedAccompanyingSymptoms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SelectedAccompanyingSymptoms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,CreationDate")] AccompanyingSymptom accompanyingSymptom)
        {
            if (ModelState.IsValid)
            {
                accompanyingSymptom.CreationDate = DateTime.Now;
                _context.Add(accompanyingSymptom);
                await _context
                    .SaveChangesAsync()
                    .ConfigureAwait(false);
                return RedirectToAction(nameof(Index));
            }
            return View(accompanyingSymptom);
        }

        // GET: SelectedAccompanyingSymptoms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accompanyingSymptom = await _context
                .AccompanyingSymptoms
                .FindAsync(id)
                .ConfigureAwait(false);
            if (accompanyingSymptom == null)
            {
                return NotFound();
            }
            return View(accompanyingSymptom);
        }

        // POST: SelectedAccompanyingSymptoms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,CreationDate")] AccompanyingSymptom accompanyingSymptom)
        {
            if (id != accompanyingSymptom.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accompanyingSymptom);
                    await _context
                        .SaveChangesAsync()
                        .ConfigureAwait(false);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccompanyingSymptomExists(accompanyingSymptom.Id))
                    {
                        return NotFound();
                    }

                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(accompanyingSymptom);
        }

        // GET: SelectedAccompanyingSymptoms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accompanyingSymptom = await _context.AccompanyingSymptoms
                .FirstOrDefaultAsync(m => m.Id == id)
                .ConfigureAwait(false);
           
            if (accompanyingSymptom == null)
            {
                return NotFound();
            }

            return View(accompanyingSymptom);
        }

        // POST: SelectedAccompanyingSymptoms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var accompanyingSymptom = await _context.AccompanyingSymptoms
                .FindAsync(id)
                .ConfigureAwait(false);
            
            _context.AccompanyingSymptoms
                .Remove(accompanyingSymptom);
            
            await _context
                .SaveChangesAsync()
                .ConfigureAwait(false);
            
            return RedirectToAction(nameof(Index));
        }

        private bool AccompanyingSymptomExists(int id)
        {
            return _context
                .AccompanyingSymptoms
                .Any(e => e.Id == id);
        }
    }
}
