using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MgMateWeb.Models.EntryModels;
using MgMateWeb.Persistence.Entities;

namespace MgMateWeb.Controllers
{
    public class TriggersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TriggersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Triggers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Triggers
                .ToListAsync()
                .ConfigureAwait(false));
        }

        // GET: Triggers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trigger = await _context.Triggers
                .FirstOrDefaultAsync(m => m.Id == id)
                .ConfigureAwait(false);
            
            if (trigger == null)
            {
                return NotFound();
            }

            return View(trigger);
        }

        // GET: Triggers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Triggers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,CreationDate")] Trigger trigger)
        {
            if (ModelState.IsValid)
            {
                trigger.CreationDate = DateTime.Now;

                _context.Add(trigger);
                
                await _context
                    .SaveChangesAsync()
                    .ConfigureAwait(false);
                
                return RedirectToAction(nameof(Index));
            }
            return View(trigger);
        }

        // GET: Triggers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trigger = await _context.Triggers
                .FindAsync(id)
                .ConfigureAwait(false);
            
            if (trigger == null)
            {
                return NotFound();
            }
            
            return View(trigger);
        }

        // POST: Triggers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,CreationDate")] Trigger trigger)
        {
            if (id != trigger.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trigger);
                    
                    await _context
                        .SaveChangesAsync()
                        .ConfigureAwait(false);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TriggerExists(trigger.Id))
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
            return View(trigger);
        }

        // GET: Triggers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trigger = await _context.Triggers
                .FirstOrDefaultAsync(m => m.Id == id)
                .ConfigureAwait(false);
            
            if (trigger == null)
            {
                return NotFound();
            }

            return View(trigger);
        }

        // POST: Triggers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trigger = await _context.Triggers
                .FindAsync(id)
                .ConfigureAwait(false);
            
            _context.Triggers.Remove(trigger);
            
            await _context.SaveChangesAsync()
                .ConfigureAwait(false);
            
            return RedirectToAction(nameof(Index));
        }

        private bool TriggerExists(int id)
        {
            return _context.Triggers.Any(e => e.Id == id);
        }
    }
}
