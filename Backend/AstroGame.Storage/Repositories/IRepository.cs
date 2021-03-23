using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AstroGame.Storage.Repositories
{
    public interface IRepository<T>
    {
        Task<T> GetAsync(Guid id);

        Task<List<T>> GetAsync();

        Task DeleteAsync(T entity);
    }
}