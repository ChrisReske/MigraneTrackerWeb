using MgMateWeb.Models.EntryModels;
using MgMateWeb.Models.RelationshipModels;
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

        public DbSet<EntryAccompanyingSymptom> EntryAccompanyingSymptoms { get; set; }

    }
}