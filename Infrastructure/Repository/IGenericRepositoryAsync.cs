using Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public interface IGenericRepositoryAsync<TEntity>
        where TEntity : class, IEntity, new()
    {
        public Task AddAsync(TEntity entity);
        public Task DeleteAsync(TEntity entity);
        public Task UpdateAsync(TEntity entity);
        public Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null!);
        public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter);
    }
}
