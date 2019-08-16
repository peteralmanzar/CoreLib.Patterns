using CoreLib.Patterns.Repository.Abstraction;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CoreLib.Patterns.Repository
{
    public class EntityRepository<T> : IEntityRepository<T>
        where T : IEntity
    {
        #region Members
        private List<T> _entities;
        #endregion

        #region Constructors
        public EntityRepository() : this(new List<T>())
        {

        }

        public EntityRepository(List<T> entities)
        {
            #region Guards
            if (entities is null) throw new ArgumentNullException(nameof(entities));
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

        public void Update(T entity)
        {
            #region Guards
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            #endregion

            var updatedEntity = _entities.Find(e => e.ID == entity.ID);
            updatedEntity = entity;
        }

        public void Delete(T entity)
        {
            #region Guards
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            #endregion

            _entities.Remove(entity);
        }

        public T FindById(int id)
        {
            return _entities.Find(e => e.ID == id);
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
