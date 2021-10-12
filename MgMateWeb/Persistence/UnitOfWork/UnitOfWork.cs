using System;
using System.Threading.Tasks;
using MgMateWeb.Interfaces.PersistenceInterfaces;
using MgMateWeb.Interfaces.RepositoryInterfaces;
using MgMateWeb.Persistence.Repositories;

namespace MgMateWeb.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private bool _disposed;

        #region Repositories

        public IAccompanyingSymptomsRepository AccompanyingSymptoms { get; }
        public IEntryRepository Entries { get; }

        public IEntryAccompanyingSymptomsRepository EntryAccompanyingSymptoms { get; }

        #endregion

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Entries = new EntryRepository(_context);
            AccompanyingSymptoms = new AccompanyingSymptomRepository(_context);
            EntryAccompanyingSymptoms = new EntryAccompanyingSymptomRepository(_context);

        }

        public async Task<int> CompleteAsync()
        {
            return await _context
                .SaveChangesAsync()
                .ConfigureAwait(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _context.Dispose();
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}