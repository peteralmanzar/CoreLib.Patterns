using CoreLib.Patterns.Repository.Abstraction;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CoreLib.Patterns.Repository
{
    public class Repository<T> : IRepository<T>
    {
        #region Members
        private List<T> _entities;
        #endregion

        #region Constructors
        public Repository() : this(new List<T>())
        {

        }

        public Repository(List<T> entities)
        {
            #region Guards
            if (entities == null) throw new ArgumentNullException(nameof(entities));
            #endregion

            _entities = entities;
        }
        #endregion

        #region Public Functions
        public void Create(T entity)
        {
            #region Guards
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            #endregion

            _entities.Add(entity);
        }

        public void Delete(T entity)
        {
            #region Guards
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            #endregion

            _entities.Remove(entity);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _entities.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
}
