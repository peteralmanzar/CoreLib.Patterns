using System.Collections.Generic;

namespace CoreLib.Patterns.Repository.Abstraction
{
    public interface IRepository<T> : IEnumerable<T>
    {
        #region Functions
        void Create(T entity);
        void Delete(T entity);
        #endregion
    }
}