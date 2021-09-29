using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MgMateWeb.Models.EntryModels;
using MgMateWeb.Persistence.Entities;

namespace MgMateWeb.Controllers
{
    public class MedicationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MedicationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SelectedMedications
        public async Task<IActionResult> Index()
        {
            return View(await _context.Medications
                .ToListAsync()
                .ConfigureAwait(false));
        }

        // GET: SelectedMedications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medication = await _context.Medications
                .FirstOrDefaultAsync(m => m.Id == id)
                .ConfigureAwait(false);
            
            if (medication == null)
            {
                return NotFound();
            }

            return View(medication);
        }

        // GET: SelectedMedications/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SelectedMedications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("MedicationEffectiveness,Id,Description,CreationDate")] 
            Medication medication)
        {
            if (ModelState.IsValid)
            {
                medication.CreationDate = DateTime.Now;
                _context.Add(medication);
                
                await _context
                    .SaveChangesAsync()
                    .ConfigureAwait(false);
                
                return RedirectToAction(nameof(Index));
            }
            
            return View(medication);
        }

        // GET: SelectedMedications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medication = await _context.Medications
                .FindAsync(id)
                .ConfigureAwait(false);
            
            if (medication == null)
            {
                return NotFound();
            }
            return View(medication);
        }

        // POST: SelectedMedications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, 
            [Bind("MedicationEffectiveness,Id,Description,CreationDate")] Medication medication)
        {
            if (id != medication.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medication);
                    await _context
                        .SaveChangesAsync()
                        .ConfigureAwait(false);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicationExists(medication.Id))
                    {
                        return NotFound();
                    }

                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(medication);
        }

        // GET: SelectedMedications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medication = await _context.Medications
                .FirstOrDefaultAsync(m => m.Id == id)
                .ConfigureAwait(false);
            
            if (medication == null)
            {
                return NotFound();
            }

            return View(medication);
        }

        // POST: SelectedMedications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medication = await _context.Medications
                .FindAsync(id)
                .ConfigureAwait(false);
            
            _context.Medications.Remove(medication);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            
            return RedirectToAction(nameof(Index));
        }

        private bool MedicationExists(int id)
        {
            return _context.Medications.Any(e => e.Id == id);
        }
    }
}
