using System.Threading.Tasks;
using MgMateWeb.Dto;
using MgMateWeb.Models.EntryModels;
using MgMateWeb.Models.FormModels;
using MgMateWeb.Models.RelationshipModels;

namespace MgMateWeb.Interfaces.MapperInterfaces
{
    public interface IEntryMapper
    {
        Task<EntryAccompanyingSymptom> CreateEntryAccompanyingSymptom(
            Entry entryReloaded,
            AccompanyingSymptom symptom);

        Task<Entry> CreateInitialEntryAsync(CreateEntryFormModel createEntryFormModel);

        Task<EntryDto> MapEntryToEntryDtoAsync(Entry entry);

        Task<Entry> MapEntryFromEntryDtoAsync(EntryDto entryDto);

    }
}