using System.Threading.Tasks;
using MgMateWeb.Dto;
using MgMateWeb.Models.EntryModels;
using MgMateWeb.Models.FormModels;
using System.Collections.Generic;

namespace MgMateWeb.Interfaces.MapperInterfaces
{
    public interface IEntryMapper
    {
        
        Task<Entry> CreateInitialEntryAsync(CreateEntryFormModel createEntryFormModel);

        Task<EntryDto> MapEntryToEntryDtoAsync(Entry entry);

        Task<Entry> MapEntryFromEntryDtoAsync(EntryDto entryDto);

        Task<List<EntryDto>> MapEntriesToEntriesDto( List<Entry> entries );

    }
}