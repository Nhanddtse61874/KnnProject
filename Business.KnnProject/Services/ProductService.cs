using Persistence.KnnProject.Models;
using Persistence.KnnProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        void AvarageStar(Product product);

        IList<Product> GetByProductCodes(IList<string> productCodes);

        IList<Product> GetAll(string sort,int? pageIndex, int? pageSize);

        IList<Product> GetByFilter(int? colorId, int? sizeId, int? tagId, int? categoryId, int? pageIndex, int? pageSize);

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
            var result = _repository.GetAll(x => x.CategoryId == categoryId,  x => x.OrderBy(y => y.Price), null,null, 
                    x => x.ImageStorages,
                    x => x.ColorProducts.Select(y => y.Color),
                    x => x.TagProducts.Select(y => y.Tag),
                    x => x.SizeProducts.Select(y => y.Size));
            return result;
        }

        public Product GetById(int productId)
        {
            var result = _repository.GetById(productId, x => x.ImageStorages,
                    x => x.ColorProducts.Select(y => y.Color),
                    x => x.TagProducts.Select(y => y.Tag),
                    x => x.SizeProducts.Select(y => y.Size),
                    x => x.Reviews);
             AvarageStar(result);
            return result;
        }

        public void Update(Product modifiedProduct)
        {
            _repository.Update(modifiedProduct);
            _unitOfWork.Save();
        }


        public IList<Product> GetAll(string sort, int? pageIndex, int? pageSize)
        {
            var orderBy = SortString(sort);

            var sortBy = sort.Split('.');

            //Func<IQueryable<Product>, IOrderedQueryable<Product>> orderBy = null;
            if (sortBy[0] == "createdate" && sortBy[1] == "desc")
            {
                //place category = date
                orderBy = x => x.OrderByDescending(y => y.CreatedDate);
            }
            else if (sortBy[0] == "name" && sortBy[1] == "desc")
            {
                orderBy = x => x.OrderByDescending(y => y.Name);
            }
            else if (sortBy[0] == "price" && sortBy[1] == "desc")
            {
                orderBy = x => x.OrderByDescending(y => y.Price);
            }
            else if (sortBy[0] == "createdate" && sortBy[1] == "asc")
            {
                orderBy = x => x.OrderBy(y => y.CreatedDate);
            }
            else if (sortBy[0] == "name" && sortBy[1] == "asc")
            {
                orderBy = x => x.OrderBy(y => y.Name);
            }
            else if (sortBy[0] == "price" && sortBy[1] == "asc")
            {
                orderBy = x => x.OrderBy(y => y.Price);
            }
            else
            {
                orderBy = x => x.OrderBy(y => y.Id);
            }
            var result =  _repository.GetAll(filter: null, orderBy: orderBy, 
                pageIndex: pageIndex, pageSize: pageSize,
                    x => x.ImageStorages,
                    x => x.ColorProducts.Select(y => y.Color),
                    x => x.TagProducts.Select(y => y.Tag),
                    x => x.SizeProducts.Select(y => y.Size),
                    x => x.Reviews);
            foreach (var item in result)
            {
                AvarageStar(item);
            }
            return result;
        }


        public IList<Product> GetByFilter(int? colorId, int? sizeId, int? tagId, int? categoryId, int? pageIndex, int? pageSize)
        {
            Expression<Func<Product, bool>> filter = x => true;

            if (colorId.HasValue)
            {
                filter = filter.And(x => x.ColorProducts.Select(y => y.ColorId).Contains(colorId ?? -1));
            }
            if (sizeId.HasValue)
            {
                filter = filter.And(x => x.SizeProducts.Select(y => y.SizeId).Contains(sizeId ?? -1));
            }

            if (tagId.HasValue)
            {
                filter = filter.And(x => x.TagProducts.Select(y => y.TagId).Contains(tagId ?? -1));
            }

            if (categoryId.HasValue)
            {
                filter = filter.And(x => x.CategoryId == categoryId);
            }
            var result = _repository.GetAll(filter, orderBy : x => x.OrderBy(y => y.CreatedDate), pageIndex : pageIndex, pageSize : pageSize,
                    x => x.ImageStorages,
                    x => x.ColorProducts.Select(y => y.Color),
                    x => x.TagProducts.Select(y => y.Tag),
                    x => x.SizeProducts.Select(y => y.Size),
                    x => x.Reviews);

            foreach (var item in result)
            {
                 AvarageStar(item);
            }
            return result;
        }


       public void AvarageStar(Product product)
        {
            var previews = product.Reviews.Select(x => x.Star);
            double starTotal = 0;
            foreach (var item in previews)
            {
                starTotal = starTotal + item;
            }
            var count = previews.Count();
            product.Star =  Math.Round((starTotal / count));
        }


        private Func<IQueryable<Product>, IOrderedQueryable<Product>> SortString(string sort)
        {
            var sortBy = sort.Split('.');

            Func<IQueryable<Product>, IOrderedQueryable<Product>> orderBy = null;
            if (sortBy[0] == "createdate" && sortBy[1] == "desc")
            {
                //place category = date
                orderBy = x => x.OrderByDescending(y => y.CreatedDate);
            }
            else if (sortBy[0] == "name" && sortBy[1] == "desc")
            {
                orderBy = x => x.OrderByDescending(y => y.Name);
            }
            else if (sortBy[0] == "price" && sortBy[1] == "desc")
            {
                orderBy = x => x.OrderByDescending(y => y.Price);
            }
            else if (sortBy[0] == "createdate" && sortBy[1] == "asc")
            {
                orderBy = x => x.OrderBy(y => y.CreatedDate);
            }
            else if (sortBy[0] == "name" && sortBy[1] == "asc")
            {
                orderBy = x => x.OrderBy(y => y.Name);
            }
            else if (sortBy[0] == "price" && sortBy[1] == "asc")
            {
                orderBy = x => x.OrderBy(y => y.Price);
            }
            else
            {
                orderBy = x => x.OrderBy(y => y.Id);
            }
            return orderBy;
        }

        public IList<Product> GetByProductCodes(IList<string> productCodes)
        {
            var result = new List<Product>();
            if(productCodes.Count != 0)
            {
                foreach (var item in productCodes)
                {
                    result.Add(_repository.Get(x => x.Code == item,
                        x => x.ImageStorages,
                        x => x.ColorProducts.Select(y => y.Color),
                        x => x.TagProducts.Select(y => y.Tag),
                        x => x.SizeProducts.Select(y => y.Size),
                        x => x.Reviews));
                }
                return result.Distinct().ToList();
            }else
            {
                return null;
            }
            
            
        }

       
    }
}
