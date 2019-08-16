namespace CoreLib.Patterns.Repository.Abstraction
{
    public interface IEntityRepository<T> : IRepository<T>
        where T : IEntity
    {
        #region Functions
        void Update(T entity);
        T FindById(int id);
        #endregion
    }
}