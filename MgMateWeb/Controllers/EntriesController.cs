using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MgMateWeb.Dto;
using MgMateWeb.Interfaces.MapperInterfaces;
using MgMateWeb.Interfaces.PersistenceInterfaces;
using MgMateWeb.Interfaces.UtilsInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MgMateWeb.Models.EntryModels;
using MgMateWeb.Models.FormModels;
using MgMateWeb.Models.RelationshipModels;

namespace MgMateWeb.Controllers
{

    public class EntriesController : Controller
    {
        #region Fields and constants

        private readonly IUnitOfWork _unitOfWork;
        private readonly IEntriesControllerUtils _entriesControllerUtils;
        private readonly IEntryMapper _entryMapper;
        private readonly IEntryAccompanyingSymptomsUtils _entryAccompanyingSymptomsUtils;

        #endregion

        #region Constructor(s)

        public EntriesController(
            IUnitOfWork unitOfWork,
            IEntriesControllerUtils entriesControllerUtils,
            IEntryMapper entryMapper, 
            IEntryAccompanyingSymptomsUtils entryAccompanyingSymptomsUtils)
        {
            _unitOfWork = unitOfWork
                          ?? throw new ArgumentNullException(nameof(unitOfWork));
            _entriesControllerUtils = entriesControllerUtils
                                      ?? throw new ArgumentNullException(nameof(entriesControllerUtils));
            _entryMapper = entryMapper
                           ?? throw new ArgumentNullException(nameof(entryMapper));
            _entryAccompanyingSymptomsUtils = entryAccompanyingSymptomsUtils 
                                              ?? throw new ArgumentNullException(nameof(entryAccompanyingSymptomsUtils));
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
        public async Task<IActionResult> Details(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var entry = await _unitOfWork
                .Entries.GetSingleEntryAndRelatedDataAsync(id);


            if(entry is null)
            {
                return NotFound();
            }

            var entryDto = await _entryMapper
                .MapEntryToEntryDtoAsync(entry)
                .ConfigureAwait(false);

            return View(entryDto);
        }

        #endregion

        #region Entry / Create (GET and POST)

        // GET: Entries/Create
        public async Task<IActionResult> Create()
        {

            var accompanyingSymptoms = await _unitOfWork
                .AccompanyingSymptoms
                .GetAllAsync()
                .ConfigureAwait(false);

            var createEntryFormModel = new CreateEntryFormModel
            {
                AccompanyingSymptoms = accompanyingSymptoms as List<AccompanyingSymptom>
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

            var entry = await _entryMapper
                .CreateInitialEntryAsync(createEntryFormModel)
                .ConfigureAwait(false);

            if (entry is null)
            {
                return RedirectToAction(nameof(Index));
            }

            var wasEntrySaved = await _entriesControllerUtils
                .SaveEntryToDbAsync(entry)
                .ConfigureAwait(false);

            if (wasEntrySaved is false)
            {
                return RedirectToAction(nameof(Index));
            }

            var entryReloaded = await _unitOfWork.Entries
                .ReloadEntryAsync()
                .ConfigureAwait(false);

            if (entryReloaded is null)
            {
                return RedirectToAction(nameof(Index));
            }

            var selectedSymptoms = createEntryFormModel.SelectedAccSymptoms;
            if(selectedSymptoms is null)
            {
                return RedirectToAction(nameof(Index));
            }

            var entryAccompanyingSymptoms = 
                await _entryAccompanyingSymptomsUtils.CreateEntryAccompanyingSymptomAsync(
                 selectedSymptoms,
                 entryReloaded);

            if (entryAccompanyingSymptoms is null)
            {
                return RedirectToAction(nameof(Index));
            }

            entryReloaded.EntryAccompanyingSymptoms = entryAccompanyingSymptoms;
            
            _unitOfWork.Entries.Update(entry);

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

            var entry = await _unitOfWork
                .Entries
                .GetAsync(id)
                .ConfigureAwait(false);

            if (entry == null)
            {
                return NotFound();
            }

            var entryDto = await _entryMapper
                .MapEntryToEntryDtoAsync(entry)
                .ConfigureAwait(false);

            return View(entryDto);
        }

        // POST: Entries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EntryDto entryDto)
        {
            if (id != entryDto.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(entryDto);
            }

            var entry = await _entryMapper
                .MapEntryFromEntryDtoAsync(entryDto)
                .ConfigureAwait(false);

            try
            {
                _unitOfWork.Entries.Update(entry);

                await _unitOfWork
                    .CompleteAsync()
                    .ConfigureAwait(false);

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _entriesControllerUtils
                    .EntryExistsAsync(entry.Id)
                    .ConfigureAwait(false))
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

            var entry = await _unitOfWork
                .Entries
                .GetFirstOrDefaultById(m => m.Id == id)
                .ConfigureAwait(false);

            if (entry == null)
            {
                return NotFound();
            }

            var entryDto = await _entryMapper
                .MapEntryToEntryDtoAsync(entry)
                .ConfigureAwait(false);

            return View(entryDto);
        }

        // POST: Entries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var entry = await _unitOfWork
                .Entries
                .GetAsync(id)
                .ConfigureAwait(false);

            _unitOfWork.Entries.Remove(entry);

            await _unitOfWork
                .CompleteAsync()
                .ConfigureAwait(false);

            return RedirectToAction(nameof(Index));
        }

        #endregion

    }
}
