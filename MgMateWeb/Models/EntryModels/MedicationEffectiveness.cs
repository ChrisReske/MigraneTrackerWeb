using System.ComponentModel.DataAnnotations;

namespace MgMateWeb.Models.EntryModels
{
    public enum MedicationEffectiveness
    {
        [Display(Name = "None")]
        None,
        
        [Display(Name = "Low")]
        Low,
        
        [Display(Name = "Medium")]
        Medium,
        
        [Display(Name="High")]
        High,
    }
}