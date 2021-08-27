using System;
using System.Threading.Tasks;
using MgMateWeb.Persistence.Entities;
using MgMateWeb.Persistence.Interfaces;
using MgMateWeb.Persistence.Interfaces.RepositoryInterfaces;
using MgMateWeb.Persistence.Repositories;

namespace MgMateWeb.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private bool _disposed;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            AccompanyingSymptomRepository = new AccompanyingSymptomRepository(_context);
        }

        public IAccompanyingSymptomRepository AccompanyingSymptomRepository { get; }

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