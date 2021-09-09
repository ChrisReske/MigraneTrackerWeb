using System;
using System.Threading.Tasks;
using AutoMapper;
using MgMateWeb.Dto;
using MgMateWeb.Interfaces.UtilsInterfaces.ControllerUtilsInterfaces;
using MgMateWeb.Models.EntryModels;
using MgMateWeb.Persistence.Interfaces;

namespace MgMateWeb.Utils.ControllerUtils
{
    public class AccompanyingSymptomsControllerUtils : IAccompanyingSymptomsControllerUtils
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AccompanyingSymptomsControllerUtils(
            IMapper mapper, 
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper 
                      ?? throw new ArgumentNullException(nameof(mapper));
            _unitOfWork = unitOfWork 
                          ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<AccompanyingSymptom> MapAccompanyingSymptomFromDtoAsync(AccompanyingSymptomDto accompanyingSymptomDto)
        {
            if (accompanyingSymptomDto is null)
            {
                return new AccompanyingSymptom();
            }

            accompanyingSymptomDto.CreationDate = DateTime.Now;

            var accompanyingSymptom = _mapper.Map<AccompanyingSymptom>(accompanyingSymptomDto);

            return await Task
                .FromResult(accompanyingSymptom)
                .ConfigureAwait(false);
            ;
        }

        public async Task<int> SaveModelToDatabase(AccompanyingSymptom accompanyingSymptom)
        {
            if (accompanyingSymptom is null)
            {
                return -1; //failed
            }

            _unitOfWork
                .AccompanyingSymptomRepository
                .Add(accompanyingSymptom);

            return await _unitOfWork
                .CompleteAsync()
                .ConfigureAwait(false);
        }
    }
}