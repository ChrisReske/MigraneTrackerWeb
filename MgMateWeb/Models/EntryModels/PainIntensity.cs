using System.ComponentModel.DataAnnotations;

namespace MgMateWeb.Models.EntryModels
{
    public enum PainIntensity
    {
        [Display(Name="Low")]
        Low,
        
        [Display(Name = "Medium")]
        Medium,
        
        [Display(Name = "High")]
        High,
        
        [Display(Name="Very High")]
        VeryHigh,
        
        [Display(Name="Crippling")]
        Crippling

    }
}