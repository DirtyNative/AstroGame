using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AstroGame.Api.Managers
{
    public abstract class ManagerBase<T>
    {
        public abstract Task<T> GetAsync(Guid id);

        public abstract Task<List<T>> GetByParentAsync(Guid parentId);
    }
}