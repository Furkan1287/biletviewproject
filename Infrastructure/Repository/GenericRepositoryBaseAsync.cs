using Domain.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class GenericRepositoryBaseAsync<TEntity> : IGenericRepositoryAsync<TEntity>
        where TEntity : class, IEntity, new()

    {
        private readonly ApplicationDbContext _context;

        public GenericRepositoryBaseAsync(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TEntity entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            var removedEntity = _context.Remove(entity);
            removedEntity.State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null!)
        {
            return await (filter == null ?
                   _context.Set<TEntity>().ToListAsync() :
                   _context.Set<TEntity>().Where(filter).ToListAsync());
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _context.Set<TEntity>().Where(filter).SingleOrDefaultAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            var updatedEntity = _context.Update(entity);
            updatedEntity.State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
