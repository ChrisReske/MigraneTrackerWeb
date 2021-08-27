using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MgMateWeb.Models.EntryModels;
using MgMateWeb.Persistence;

namespace MgMateWeb.Controllers
{
    public class AccompanyingSymptomsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccompanyingSymptomsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AccompanyingSymptoms
        public async Task<IActionResult> Index()
        {
            return View(await _context.AccompanyingSymptoms.ToListAsync());
        }

        // GET: AccompanyingSymptoms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accompanyingSymptom = await _context.AccompanyingSymptoms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (accompanyingSymptom == null)
            {
                return NotFound();
            }

            return View(accompanyingSymptom);
        }

        // GET: AccompanyingSymptoms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AccompanyingSymptoms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,CreationDate")] AccompanyingSymptom accompanyingSymptom)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accompanyingSymptom);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(accompanyingSymptom);
        }

        // GET: AccompanyingSymptoms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accompanyingSymptom = await _context.AccompanyingSymptoms.FindAsync(id);
            if (accompanyingSymptom == null)
            {
                return NotFound();
            }
            return View(accompanyingSymptom);
        }

        // POST: AccompanyingSymptoms/Edit/5
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
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccompanyingSymptomExists(accompanyingSymptom.Id))
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
            return View(accompanyingSymptom);
        }

        // GET: AccompanyingSymptoms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accompanyingSymptom = await _context.AccompanyingSymptoms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (accompanyingSymptom == null)
            {
                return NotFound();
            }

            return View(accompanyingSymptom);
        }

        // POST: AccompanyingSymptoms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var accompanyingSymptom = await _context.AccompanyingSymptoms.FindAsync(id);
            _context.AccompanyingSymptoms.Remove(accompanyingSymptom);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccompanyingSymptomExists(int id)
        {
            return _context.AccompanyingSymptoms.Any(e => e.Id == id);
        }
    }
}
