using System;
using System.Threading.Tasks;
using MgMateWeb.Interfaces.PersistenceInterfaces;

namespace MgMateWeb.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private bool _disposed;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
           
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