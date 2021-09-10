using System.Threading.Tasks;
using MgMateWeb.Dto;
using MgMateWeb.Models.EntryModels;

namespace MgMateWeb.Interfaces.UtilsInterfaces.ControllerUtilsInterfaces
{
    public interface IAccompanyingSymptomsControllerUtils
    {
        Task<AccompanyingSymptom> MapAccompanyingSymptomUponCreation(AccompanyingSymptomDto accompanyingSymptomDto);

        Task<int> SaveModelToDatabaseAsync(AccompanyingSymptom accompanyingSymptom);
    }
}