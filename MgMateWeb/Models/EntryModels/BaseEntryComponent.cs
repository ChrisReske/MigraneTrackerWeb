using System;

namespace MgMateWeb.Models.EntryModels
{
    public class BaseEntryComponent
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
    }
}