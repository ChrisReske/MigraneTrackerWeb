using MgMateWeb.Models.EntryModels;
using Microsoft.EntityFrameworkCore;

namespace MgMateWeb.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<AccompanyingSymptom> AccompanyingSymptoms { get; set; }
        public DbSet<Entry> Entries { get; set; }
        public DbSet<Medication> Medications { get; set; }
        public MedicationEffectiveness MedicationEffectiveness { get; set; }
        public PainIntensity PainIntensity { get; set; }
        public DbSet<PainType> PainTypes { get; set; }
        public DbSet<Trigger> Triggers { get; set; }
        public DbSet<WeatherDataEntry> WeatherData { get; set; }
    }
}