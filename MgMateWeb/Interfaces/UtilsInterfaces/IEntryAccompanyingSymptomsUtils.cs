using System.Collections.Generic;
using System.Threading.Tasks;
using MgMateWeb.Models.EntryModels;
using MgMateWeb.Models.RelationshipModels;

namespace MgMateWeb.Interfaces.UtilsInterfaces
{
    public interface IEntryAccompanyingSymptomsUtils
    {
        Task<List<EntryAccompanyingSymptom>> CreateEntryAccompanyingSymptomAsync(
            IEnumerable<int> selectedSymptoms,
            Entry entryReloaded);

    }
}