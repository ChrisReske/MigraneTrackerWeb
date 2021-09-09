using System.Threading.Tasks;
using MgMateWeb.Dto;
using MgMateWeb.Models.EntryModels;

namespace MgMateWeb.Interfaces.UtilsInterfaces
{
    public interface ICustomMapper
    {
        Task<AccompanyingSymptom> MapAccompanyingSymptomFromDtoAsync(AccompanyingSymptomDto accompanyingSymptomDto);

    }
}