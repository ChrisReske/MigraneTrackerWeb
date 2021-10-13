using System.Threading.Tasks;
using MgMateWeb.Models.EntryModels;
using MgMateWeb.Models.RelationshipModels;

namespace MgMateWeb.Interfaces.MapperInterfaces
{
    public interface IEntryAccompanyingSymptomMapper
    {
        Task<EntryAccompanyingSymptom> CreateEntryAccompanyingSymptomAsync(
            Entry entryReloaded,
            AccompanyingSymptom symptom);
    }
}