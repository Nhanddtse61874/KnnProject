using Persistence.DataAccess.Models;
using Persistence.KnnProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Persistence.KnnProject.Repositories
{
    public interface IRepository<T> where T : BaseModel
    {
        IList<T> GetAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, 
            int? pageIndex = null, int? pageSize = null, 
            params Expression<Func<T, object>>[] includeProperties);

        T GetById(int id);

        T Get(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includeProperties);

        void Create(T model);

        void Update(T model);

        void Delete(int id);
    }

    public class Repository<T> : IRepository<T> where T : BaseModel
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public Repository()
        {
        }

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public void Create(T model)
        {
            _dbSet.Add(model);
        }

        public void Update(T model)
        {
            _dbSet.Attach(model);
            _dbContext.Entry(model).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            T entityToDelete = _dbSet.Find(id);
            _dbSet.Remove(entityToDelete);
        }

        public IList<T> GetAll(Expression<Func<T, bool>> filter = null, 
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, 
            int? pageIndex = null, int? pageSize = null,
            params Expression<Func<T, object>>[] includeProperties)
        {
            var result = IncludeProperties(includeProperties);
            
            if (filter != null)
            {
                result = result.Where(filter);
            }
            if (orderBy != null)
            {
                result = orderBy(result);
            }
            if (pageIndex != null && pageSize != null)
            {
                result = result.Skip((pageIndex.Value - 1) * pageSize.Value).Take(pageSize.Value);
            }
            
            return result.ToList();
        }

        public T GetById(int id) => _dbSet.Find(id);

        public T Get(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includeProperties)
        {
            var result = IncludeProperties();
            return result.FirstOrDefault(filter);
        }

        private IQueryable<T> IncludeProperties(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> result = _dbSet;
            foreach (var includeProperty in includeProperties)
            {
                result = result.Include(includeProperty);
            }
            return result;
        }
    }
}

/// EF supprot 3 loại load data
/// lazy loading, eager loading, explicit loading
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