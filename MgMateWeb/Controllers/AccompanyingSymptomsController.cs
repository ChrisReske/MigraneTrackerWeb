using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MgMateWeb.Dto;
using MgMateWeb.Interfaces.UtilsInterfaces.ControllerUtilsInterfaces;
using Microsoft.AspNetCore.Mvc;
using MgMateWeb.Persistence.Interfaces;

namespace MgMateWeb.Controllers
{
    public class AccompanyingSymptomsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAccompanyingSymptomsControllerUtils _accompanyingSymptomsControllerUtils;

        public AccompanyingSymptomsController(
            IMapper mapper, 
            IUnitOfWork unitOfWork, 
            IAccompanyingSymptomsControllerUtils accompanyingSymptomsControllerUtils)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _accompanyingSymptomsControllerUtils = accompanyingSymptomsControllerUtils 
                                                   ?? throw new ArgumentNullException(nameof(accompanyingSymptomsControllerUtils));
        }

        // GET: AccompanyingSymptoms
        public async Task<IActionResult> Index()
        {
            var symptoms = await _unitOfWork
                .AccompanyingSymptomRepository
                .GetAllAsync()
                .ConfigureAwait(false);

            // Todo: If symptoms empty redirect to custom error / no data to display page

            var symptomsView = _mapper.Map<IEnumerable<AccompanyingSymptomDto>>(symptoms);

            return View(symptomsView);
        }

        // GET: AccompanyingSymptoms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }
            
            var accompanyingSymptom = await _unitOfWork
                .AccompanyingSymptomRepository
                .FirstOrDefaultAsync(
                    m => m.Id == id)
                .ConfigureAwait(false);
            
            if (accompanyingSymptom is null)
            {
                return NotFound();
            }

            var viewModel = _mapper
                .Map<AccompanyingSymptomDto>(accompanyingSymptom);

            return View(viewModel);
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
        public async Task<IActionResult> Create(AccompanyingSymptomDto accompanyingSymptomDto)
        {
            if (!ModelState.IsValid)
            {
                
                return RedirectToAction(nameof(Index));
            }

            var accompanyingSymptom = await 
                _accompanyingSymptomsControllerUtils
                    .MapAccompanyingSymptomFromDtoAsync(accompanyingSymptomDto)
                    .ConfigureAwait(false);

            await _accompanyingSymptomsControllerUtils.
                SaveModelToDatabase(accompanyingSymptom)
                .ConfigureAwait(false);

            // Todo: Add toast notification if saving was successful or redirect to success page
            return RedirectToAction("Index", "AccompanyingSymptoms");
        }


        // GET: AccompanyingSymptoms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accompanyingSymptom = await _unitOfWork
                .AccompanyingSymptomRepository
                .GetAsync((int)id)
                .ConfigureAwait(false);

            if (accompanyingSymptom == null)
            {
                return NotFound();
            }

            var accompanyingSymptomsDto = _mapper
                .Map<AccompanyingSymptomDto>(accompanyingSymptom);

            return View(accompanyingSymptomsDto);
        }

        // POST: AccompanyingSymptoms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AccompanyingSymptomDto accompanyingSymptomDto)
        {
            if (id != accompanyingSymptomDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var accompanyingSymptom = 
                    await _unitOfWork.AccompanyingSymptomRepository
                        .GetAsync(accompanyingSymptomDto.Id)
                        .ConfigureAwait(false);
                
                _mapper.Map(accompanyingSymptomDto, accompanyingSymptom);
               
                await _unitOfWork.CompleteAsync();
               
               return RedirectToAction(nameof(Index));
            }
            return View(accompanyingSymptomDto);
        }

        // GET: AccompanyingSymptoms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var accompanyingSymptom = await _unitOfWork
                .AccompanyingSymptomRepository
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
            if(id == 0)
            {
                return RedirectToAction(nameof(Index));
            }

            var accompanyingSymptom =
                await _unitOfWork
                    .AccompanyingSymptomRepository
                    .GetAsync(id)
                    .ConfigureAwait(false);

            _unitOfWork.AccompanyingSymptomRepository.Remove(accompanyingSymptom);

            await _unitOfWork
                .CompleteAsync()
                .ConfigureAwait(false);
            
            return RedirectToAction(nameof(Index));
        }
    }
}
