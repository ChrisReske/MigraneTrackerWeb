using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MgMateWeb.Models.EntryModels;
using MgMateWeb.Models.WeatherModels;
using MgMateWeb.Persistence;

namespace MgMateWeb.Controllers
{
    public class WeatherDataEntriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WeatherDataEntriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: WeatherDataEntries
        public async Task<IActionResult> Index()
        {
            return View(await _context.WeatherData.ToListAsync());
        }

        // GET: WeatherDataEntries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weatherDataEntry = await _context.WeatherData
                .FirstOrDefaultAsync(m => m.Id == id);
            if (weatherDataEntry == null)
            {
                return NotFound();
            }

            return View(weatherDataEntry);
        }

        // GET: WeatherDataEntries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WeatherDataEntries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,City,CountryCode,MeasurementUnit")] WeatherDataFormModel weatherDataFormModel)
        {
            if (!ModelState.IsValid)
            {
                return Content("Model state is invalid");
            }

            var weatherDataEntry = new WeatherDataEntry();




            _context.Add(weatherDataEntry);
            await _context.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));

        }

        // GET: WeatherDataEntries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weatherDataEntry = await _context.WeatherData.FindAsync(id);
            if (weatherDataEntry == null)
            {
                return NotFound();
            }
            return View(weatherDataEntry);
        }

        // POST: WeatherDataEntries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CreationDate,City,CountryCode,Temperature,Pressure,Humidity")] WeatherDataEntry weatherDataEntry)
        {
            if (id != weatherDataEntry.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(weatherDataEntry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WeatherDataEntryExists(weatherDataEntry.Id))
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
            return View(weatherDataEntry);
        }

        // GET: WeatherDataEntries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weatherDataEntry = await _context.WeatherData
                .FirstOrDefaultAsync(m => m.Id == id);
            if (weatherDataEntry == null)
            {
                return NotFound();
            }

            return View(weatherDataEntry);
        }

        // POST: WeatherDataEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var weatherDataEntry = await _context.WeatherData.FindAsync(id);
            _context.WeatherData.Remove(weatherDataEntry);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WeatherDataEntryExists(int id)
        {
            return _context.WeatherData.Any(e => e.Id == id);
        }
    }
}
