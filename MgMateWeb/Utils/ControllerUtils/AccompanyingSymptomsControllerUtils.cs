using System;
using System.Threading.Tasks;
using MgMateWeb.Dto;
using MgMateWeb.Interfaces.UtilsInterfaces;
using MgMateWeb.Interfaces.UtilsInterfaces.ControllerUtilsInterfaces;
using MgMateWeb.Models.EntryModels;
using MgMateWeb.Persistence.Interfaces;

namespace MgMateWeb.Utils.ControllerUtils
{
    public class AccompanyingSymptomsControllerUtils : IAccompanyingSymptomsControllerUtils
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomMapper _customMapper;

        public AccompanyingSymptomsControllerUtils(
            IUnitOfWork unitOfWork, 
            ICustomMapper customMapper)
        {
            _unitOfWork = unitOfWork 
                          ?? throw new ArgumentNullException(nameof(unitOfWork));
            _customMapper = customMapper 
                            ?? throw new ArgumentNullException(nameof(customMapper));
        }

        public async Task<AccompanyingSymptom> MapAccompanyingSymptomFromDtoAsync(
            AccompanyingSymptomDto accompanyingSymptomDto)
        {
            if (accompanyingSymptomDto is null)
            {
                return new AccompanyingSymptom();
            }

            var accompanyingSymptom = await _customMapper
                .MapAccompanyingSymptomFromDtoAsync(accompanyingSymptomDto)
                .ConfigureAwait(false);

            return await Task
                .FromResult(accompanyingSymptom)
                .ConfigureAwait(false);
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