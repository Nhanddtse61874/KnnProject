using Persistence.KnnProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.KnnProject.Repositories
{
    class UnitOfWork<T> : IDisposable where T :BaseModel 
    {
        private readonly KnnDbContext dbContext = new KnnDbContext();
        public Repository<T> res = new Repository<T>();
       
        public UnitOfWork()
        {

        }
        public Repository<T> Repository
        {
            get
            {

                if (this.res == null)
                {
                    this.res = new Repository<T>(dbContext);
                }
                return res;
            }
        }

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
