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
        readonly ApplicationDbContext _context;

        public GenericRepositoryBaseAsync(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null, CancellationToken cancellationToken = default)
        {
            return await (predicate == null ?
                   _context.Set<TEntity>().ToListAsync() :
                   _context.Set<TEntity>().Where(predicate).ToListAsync(cancellationToken));
        }

        public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
