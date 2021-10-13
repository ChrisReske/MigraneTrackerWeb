using System.Collections.Generic;
using System.Threading.Tasks;
using MgMateWeb.Dto;
using MgMateWeb.Models.EntryModels;

namespace MgMateWeb.Interfaces.MapperInterfaces
{
    public interface ICustomMapper
    {
        Task<AccompanyingSymptom> MapFromAccompanyingSymptomDtoAsync(AccompanyingSymptomDto accompanyingSymptomDto);
        Task<AccompanyingSymptomDto> MapToAccompanyingSymptomDtoAsync(AccompanyingSymptom accompanyingSymptom);

        Task<IEnumerable<AccompanyingSymptom>> MapFromMultipleAccompanyingSymptomsDtoAsync(
            IEnumerable<AccompanyingSymptomDto> accompanyingSymptomDtos);

        Task<IEnumerable<AccompanyingSymptomDto>> MapToMultipleAccompanyingSymptomsDtoAsync(
            IEnumerable<AccompanyingSymptom> accompanyingSymptoms);

    }
}