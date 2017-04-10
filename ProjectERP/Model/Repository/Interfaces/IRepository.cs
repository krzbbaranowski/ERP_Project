using System.Collections.Generic;

namespace ProjectERP.Model.Repository.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetById(int id);
        IEnumerable<TEntity> GetEntities();
        void Add(TEntity entity);
        void Remove(TEntity entity);
        void Update(TEntity entity);
        void Save();
    }
}