using Domain.Entities.Abstract;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public interface IGenericRepositoryAsync<T>
        where T : class, IEntity, new()
    {
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        public Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, CancellationToken cancellationToken = default);
        public Task<T?> GetAsync(Expression<Func<T, bool>> predicate);
    }
}
