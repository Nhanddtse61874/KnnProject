using Persistence.DataAccess.Models;
using Persistence.KnnProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Persistence.KnnProject.Repositories
{
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
    public interface IRepository<T> where T : BaseModel
    {
        List<T> GetAll(
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, 
            int? pageIndex = null, int? pageSize = null, 
            params Expression<Func<T, object>>[] includeProperties);

        List<T> GetElementsByConditions(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includeProperties);

        T GetById(int id);

        T GetElementByConditions(Expression<Func<T, bool>> filter = null);

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

        public void Delete(int id)
        {
            T entityToDelete = _dbSet.Find(id);
            _dbSet.Remove(entityToDelete);
        }

        public List<T> GetAll(
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            int? pageIndex = null, int? pageSize = null,
            params Expression<Func<T, object>>[] includeProperties)
        {
            //doan code nay` dung` chung nhieu` cho~ => thong nhat nhung thằng xài nó lại
            IQueryable<T> result = _dbSet;
            foreach (var includeProperty in includeProperties)
            {
                result = result.Include(includeProperty);
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

        public List<T> GetElementsByConditions(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> result = _dbSet;
            
            foreach (var includeProperty in includeProperties) 
            {
                result = result.Include(includeProperty);
            }

            if (filter != null)
            {
                result = result.Where(filter);
            }
            

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

        public T GetElementByConditions(Expression<Func<T, bool>> filter = null)
        {

            throw new NotImplementedException();
        }

    }
}