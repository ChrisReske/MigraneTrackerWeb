using MgMateWeb.Controllers;
using MgMateWeb.Dto;
using MgMateWeb.Models.FormModels;

namespace MgMateWeb.Interfaces.UtilsInterfaces
{
    public interface IEntryDtoUtils
    {
        EntryDto CreateEntryDto(EntryFormModel entryFormModel);
    }
}