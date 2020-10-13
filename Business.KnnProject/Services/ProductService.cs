using Persistence.KnnProject.Models;
using Persistence.KnnProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.KnnProject.Services
{
    public interface IProductService
    {
        IList<Product> GetByCategory(int categoryId);

        Product GetById(int productId);

        void Create(Product newProduct);

        void Update(Product modifiedProduct);

        void Delete(int ProductId);
    }
    public class ProductService : ServiceBase, IProductService
    {
        private readonly IRepository<Product> _repository;

        public ProductService()
        {
            _repository = _unitOfWork.Repository<Product>();
        }
        public void Create(Product newProduct)
        {
            _repository.Create(newProduct);
            _unitOfWork.Save();
        }

        public void Delete(int productId)
        {
            _repository.Delete(productId);
            _unitOfWork.Save();
        }

        public IList<Product> GetByCategory(int categoryId)
        {
            var result = _repository.GetAll(x => x.CategoryId == categoryId);
            return result;
        }

        public Product GetById(int productId)
        {
            var result = _repository.GetById(productId);
            return result;
        }

        public void Update(Product modifiedProduct)
        {
            _repository.Update(modifiedProduct);
            _unitOfWork.Save();
        }
    }
}
