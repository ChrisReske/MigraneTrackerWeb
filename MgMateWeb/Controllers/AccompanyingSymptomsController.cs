using System;
using System.Linq;
using System.Threading.Tasks;
using MgMateWeb.Interfaces.PersistenceInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MgMateWeb.Models.EntryModels;
using MgMateWeb.Persistence;

namespace MgMateWeb.Controllers
{
    public class AccompanyingSymptomsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public AccompanyingSymptomsController(
            ApplicationDbContext context, 
            IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: AccompanyingSymptom
        public async Task<IActionResult> Index()
        {
            var accompanyingSymptoms = await _unitOfWork
                .AccompanyingSymptoms
                .GetAllAsync()
                .ConfigureAwait(false);

            return accompanyingSymptoms is null 
                ? View() 
                : View(accompanyingSymptoms);
        }

        // GET: AccompanyingSymptom/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accompanyingSymptom = await _unitOfWork
                .AccompanyingSymptoms
                .GetFirstOrDefaultById(m => m.Id == id)
                .ConfigureAwait(false);

            if (accompanyingSymptom == null)
            {
                return NotFound();
            }

            return View(accompanyingSymptom);
        }

        // GET: AccompanyingSymptom/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AccompanyingSymptom/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,CreationDate")] AccompanyingSymptom accompanyingSymptom)
        {
            if (!ModelState.IsValid)
            {
                return View(accompanyingSymptom);
            }

            accompanyingSymptom.CreationDate = DateTime.Now;
                
            _unitOfWork.AccompanyingSymptoms.Add(accompanyingSymptom);
            await _unitOfWork.CompleteAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: AccompanyingSymptom/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accompanyingSymptom = await _unitOfWork
                .AccompanyingSymptoms
                .GetAsync(id)
                .ConfigureAwait(false);

            if (accompanyingSymptom == null)
            {
                return NotFound();
            }
            return View(accompanyingSymptom);
        }

        // POST: AccompanyingSymptom/Edit/5
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

            if (!ModelState.IsValid)
            {
                return View(accompanyingSymptom);
            }

            try
            {
                _unitOfWork.AccompanyingSymptoms
                    .Update(accompanyingSymptom);
                await _unitOfWork
                    .CompleteAsync()
                    .ConfigureAwait(false);

            }
            catch (DbUpdateConcurrencyException)
            {
                if (await AccompanyingSymptomExists(accompanyingSymptom.Id) is false)
                {
                    return NotFound();
                }

                throw;
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: AccompanyingSymptom/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accompanyingSymptom = await _unitOfWork.AccompanyingSymptoms
                .GetFirstOrDefaultById(m => m.Id == id)
                .ConfigureAwait(false);

            if (accompanyingSymptom == null)
            {
                return NotFound();
            }

            return View(accompanyingSymptom);
        }

        // POST: AccompanyingSymptom/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var accompanyingSymptom = await _unitOfWork.AccompanyingSymptoms
                .GetAsync(id)
                .ConfigureAwait(false);

            _unitOfWork
                .AccompanyingSymptoms
                .Remove(accompanyingSymptom);

            await _unitOfWork
                .CompleteAsync()
                .ConfigureAwait(false);

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> AccompanyingSymptomExists(int id)
        {
            return await _unitOfWork.AccompanyingSymptoms
                .CheckIfAnyAsync(e => e.Id == id)
                .ConfigureAwait(false);
        }
    }
}
