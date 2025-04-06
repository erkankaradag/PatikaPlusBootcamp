using System.Linq.Expressions;

namespace ShoppingApp.Data.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        // The reason for using a generic structure is to communicate between all entity classes and the DB.
        void Add(TEntity entity);
        void Delete(TEntity entity, bool isHardDelete = true);
        void Delete(int id);
        void Update(TEntity entity);
        TEntity GetById(int id);

        // Advance
        TEntity Get(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null);
    }
}