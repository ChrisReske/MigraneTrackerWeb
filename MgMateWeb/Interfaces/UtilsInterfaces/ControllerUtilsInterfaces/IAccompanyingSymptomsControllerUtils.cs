using System.Threading.Tasks;
using MgMateWeb.Dto;
using MgMateWeb.Models.EntryModels;

namespace MgMateWeb.Interfaces.UtilsInterfaces.ControllerUtilsInterfaces
{
    public interface IAccompanyingSymptomsControllerUtils
    {
        Task<AccompanyingSymptom> MapAccompanyingSymptomFromDtoAsync(AccompanyingSymptomDto accompanyingSymptomDto);

        Task<int> SaveModelToDatabase(AccompanyingSymptom accompanyingSymptom);
    }
}