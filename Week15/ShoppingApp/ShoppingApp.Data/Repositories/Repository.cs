using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ShoppingApp.Data.Context;
using ShoppingApp.Data.Entities;

namespace ShoppingApp.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ShoppingAppDbContext _db;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(ShoppingAppDbContext db)
        {
            _db = db;
            _dbSet = _db.Set<TEntity>();
        }



        public void Add(TEntity entity)
        {

            entity.CreatedDate = DateTime.Now;
            _dbSet.Add(entity);
        }

        public void Delete(TEntity entity, bool isHardDelete = true)
        {
            if (isHardDelete)
            {
                entity.ModifiedDate = DateTime.Now;
                entity.IsDeleted = true;
                _dbSet.Update(entity);
            }
            else
            {
                _dbSet.Remove(entity);
            }
        }

        public void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            Delete(entity);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null)
        {
            return predicate == null ? _dbSet : _dbSet.Where(predicate);
        }

        public TEntity GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Update(TEntity entity)
        {
            entity.ModifiedDate = DateTime.Now;
            _dbSet.Update(entity);
        }
    }
}