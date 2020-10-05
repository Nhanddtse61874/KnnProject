using Persistence.KnnProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Persistence.KnnProject.Repositories
{
    /// EF supprot 3 loại load data
    /// lazy loading, eager loading, explicit  loading
    /// lazy loading: support load data khi gọi tới

    ///2 loại repository 
    ///=> specific repository => tức là repository cho 1 object cụ thể
    ///=> generic repository => tức là repository dành cho tất cả các model
    ///ở đây dùng generic
    ///
    ///TODO: 
    ///1. Xem video huong dan repository vs unitofwork
    ///2. Sua? lai repository de support phân trang, sắp xếp
    ///3. Implement unit of work
    ///
    ///4. Tìm cách sử dụng Include trong repository (optional)
    ///   -> mình đang dùng eager loading
    public interface IRepository<T> where T : BaseModel
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);

        T GetById(int id);

        void Create(T model);

        void Update(T model);

        void Delete(int id);
    }

    public class Repository<T> : IRepository<T> where T : BaseModel
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public void Create(T model)
        {
            _dbSet.Add(model);
        }

        public void Delete(int id)
        {
            T entityToDelete = _dbSet.Find(id);
            _dbSet.Remove(entityToDelete);
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            var result = _dbSet.Where(filter);

            return result.ToList();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Update(T model)
        {
            _dbSet.Attach(model);
            _dbContext.Entry(model).State = EntityState.Modified;
        }
    }
}
