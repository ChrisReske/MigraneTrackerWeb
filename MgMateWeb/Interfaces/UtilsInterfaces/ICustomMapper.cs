using System.Threading.Tasks;
using MgMateWeb.Dto;
using MgMateWeb.Models.EntryModels;

namespace MgMateWeb.Interfaces.UtilsInterfaces
{
    public interface ICustomMapper
    {
        Task<AccompanyingSymptom> MapFromAccompanyingSymptomDto(AccompanyingSymptomDto accompanyingSymptomDto);
        Task<AccompanyingSymptomDto> MapToAccompanyingSymptomDto(AccompanyingSymptom accompanyingSymptom);

    }
}