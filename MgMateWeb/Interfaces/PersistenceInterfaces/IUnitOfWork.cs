using System;
using System.Threading.Tasks;
using MgMateWeb.Interfaces.RepositoryInterfaces;

namespace MgMateWeb.Interfaces.PersistenceInterfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAccompanyingSymptomsRepository AccompanyingSymptoms { get; }

        /// <summary>
        /// Asynchronously saves all changes made in this context to the underlying database.
        /// </summary>
        /// <remarks>
        /// Multiple active operations on the same context instance are not supported.  Use 'await' to ensure
        /// that any asynchronous operations have completed before calling another method on this context.
        /// </remarks>
        /// <returns>
        /// A task that represents the asynchronous save operation.
        /// The task result contains the number of state entries written to the underlying database. This can include
        /// state entries for entities and/or relationships. Relationship state entries are created for
        /// many-to-many relationships and relationships where there is no foreign key property
        /// included in the entity class (often referred to as independent associations).
        /// </returns>
        Task<int> CompleteAsync();

    }
}