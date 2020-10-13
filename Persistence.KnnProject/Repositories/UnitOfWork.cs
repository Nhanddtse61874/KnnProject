using Persistence.DataAccess.Models;
using Persistence.KnnProject.Models;
using System;

namespace Persistence.KnnProject.Repositories
{
    public interface IUnitOfWork
    {
        IRepository<T> Repository<T>() where T : BaseModel;

        void Save();
    }

    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly KnnDbContext dbContext = new KnnDbContext();
       
        public UnitOfWork()
        {
        }

        
        public IRepository<T> Repository<T>() where T : BaseModel
        {
            return new Repository<T>(dbContext);
        }//factory method - design pattern

        public void Save()
        {
            dbContext.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                    //...
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

//I => interface
//lien quan den dependency injection
//=> giam su phu. thuoc giua cac class khac nhau
