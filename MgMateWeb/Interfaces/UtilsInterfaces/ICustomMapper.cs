using System.Threading.Tasks;
using MgMateWeb.Controllers;
using MgMateWeb.Dto;
using MgMateWeb.Models.EntryModels;
using MgMateWeb.Models.FormModels;

namespace MgMateWeb.Interfaces.UtilsInterfaces
{
    public interface ICustomMapper
    {
        Task<AccompanyingSymptom> CreateNewAccompanyingSymptomFromDtoAsync(AccompanyingSymptomDto accompanyingSymptomDto);
        EntryDto CreateEntryDto(EntryFormModel entryFormModel);

    }
}