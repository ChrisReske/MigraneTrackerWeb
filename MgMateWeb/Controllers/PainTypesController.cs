using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MgMateWeb.Models.EntryModels;
using MgMateWeb.Persistence;

namespace MgMateWeb.Controllers
{
    public class PainTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PainTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PainTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.PainTypes.ToListAsync());
        }

        // GET: PainTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var painType = await _context.PainTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (painType == null)
            {
                return NotFound();
            }

            return View(painType);
        }

        // GET: PainTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PainTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,CreationDate")] PainType painType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(painType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(painType);
        }

        // GET: PainTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var painType = await _context.PainTypes.FindAsync(id);
            if (painType == null)
            {
                return NotFound();
            }
            return View(painType);
        }

        // POST: PainTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,CreationDate")] PainType painType)
        {
            if (id != painType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(painType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PainTypeExists(painType.Id))
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
            return View(painType);
        }

        // GET: PainTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var painType = await _context.PainTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (painType == null)
            {
                return NotFound();
            }

            return View(painType);
        }

        // POST: PainTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var painType = await _context.PainTypes.FindAsync(id);
            _context.PainTypes.Remove(painType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PainTypeExists(int id)
        {
            return _context.PainTypes.Any(e => e.Id == id);
        }
    }
}
