using System.Collections.Generic;
using MgMateWeb.Models.EntryModels;

namespace MgMateWeb.Models.FormModels
{
    public class CreateEntryFormModel : Entry
    {
        public IEnumerable<int> SelectedAccSymptoms { get; set; }
    }
}