using System.Threading.Tasks;
using MgMateWeb.Dto;
using MgMateWeb.Models.EntryModels;
using MgMateWeb.Models.FormModels;

namespace MgMateWeb.Interfaces.UtilsInterfaces
{
    public interface ICustomMapper
    {
        Task<AccompanyingSymptom> CreateNewAccompanyingSymptomFromDtoAsync(AccompanyingSymptomDto accompanyingSymptomDto);

        Entry MapEntryDtoToEntry(EntryFormModel entryFormModel);

    }
}