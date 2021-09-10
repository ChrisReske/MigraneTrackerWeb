using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MgMateWeb.Persistence.Interfaces.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace MgMateWeb.Persistence.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            Context = context;
        }

        public TEntity Get(int id)
        {
            
            return Context.Set<TEntity>().Find(id);
        }

        public async Task<TEntity> GetAsync(int? id)
        {
            return await Context
                .Set<TEntity>()
                .FindAsync(id)
                .ConfigureAwait(false);
        }

        public IEnumerable<TEntity> GetAll()
        {
         
            return Context.Set<TEntity>().ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var entities = await Context
                .Set<TEntity>()
                .ToListAsync()
                .ConfigureAwait(false);

            return entities;
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().SingleOrDefault(predicate);
        }

        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().AddRange(entities);
        }

        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }

        public Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
           return Context
                .Set<TEntity>()
                .FirstOrDefaultAsync(predicate);
        }
    }
}