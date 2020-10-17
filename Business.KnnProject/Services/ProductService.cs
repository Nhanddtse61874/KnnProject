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

        IList<Product> GetAll(int? pageIndex, int? pageSize);

        IList<Product> GetByFilter(int? colorId, int? sizeId, int? tagId, int? categoryId, int? pageIndex, int? pageSize);
    }
    public class ProductService : ServiceBase, IProductService
    {
        private readonly IRepository<Product> _repository;

        private ITagService _tagService;
        private IColorService _coloService;
        private ISizeService _sizeService;
        public ProductService()
        {
            _tagService = new TagService();
            _coloService = new ColorService();
            _sizeService = new SizeService();
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
        public IList<Product> GetAll(int? pageIndex, int? pageSize)
        {

            return _repository.GetAll(filter: null, orderBy: x => x.OrderBy(y => y.Id), 
                pageIndex: pageIndex, pageSize: pageSize,
                    x => x.ImageStorages,
                    x => x.ColorProducts.Select(y => y.Color),
                    x => x.TagProducts.Select(y => y.Tag),
                    x => x.SizeProducts.Select(y => y.Size));
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
            return _repository.GetAll(filter, orderBy : x => x.OrderBy(y => y.Id), pageIndex : pageIndex, pageSize : pageSize,
                    x => x.ImageStorages,
                    x => x.ColorProducts.Select(y => y.Color),
                    x => x.TagProducts.Select(y => y.Tag),
                    x => x.SizeProducts.Select(y => y.Size));
        }
        //public IList<Product> GetAll2()
        //{
        //    int? sizeId = null;

        //    int? colorId = null;

        //    Expression<Func<Product, bool>> filter = x => true;

        //    if (sizeId.HasValue)
        //    {
        //        filter = filter.And(x => x.SizeProducts.Select(y => y.SizeId).Contains(sizeId ?? -1));
        //    }

        //    if (sizeId.HasValue)
        //    {
        //        filter = filter.And(x => x.SizeProducts.Select(y => y.SizeId).Contains(sizeId ?? -1));
        //    }

        //    if (true)
        //    {
        //        Expression<Func<Product, bool>> filterByColor = x => true;
        //        if (color == red)
        //        {
        //            filterByColor = filterByColor.Or(x => x.ColorProducts.Colro == red);
        //        }
        //        if (color == blue)
        //        {
        //            filterByColor = filterByColor.Or(x => x.ColorProducts.Colro == blue);
        //        }
        //        filter = filter.And(filterByColor);
        //    }

        //    return _repository.GetAll(
        //       filter, includeProperties: x => x.ColorProducts);


        //if (sizeId.HasValue)
        //{
        //    return _repository.GetAll(
        //    filter: x => x.SizeProducts.Select(y => y.SizeId).Contains(sizeId ?? -1),
        //    includeProperties: x => x.ColorProducts);
        //}
        //else if (colorId.HasValue)
        //{
        //    return _repository.GetAll(
        //    filter: x => x.ColorProducts.Select(y => y.ColorId).Contains(colorId ?? -1),
        //    includeProperties: x => x.ColorProducts);
        //}
        //else if (colorId.HasValue && sizeId.HasValue)
        //{
        //    return _repository.GetAll(
        //   filter: x => x.ColorProducts.Select(y => y.ColorId).Contains(colorId ?? -1)
        //            && x.SizeProducts.Select(y => y.SizeId).Contains(sizeId ?? -1),
        //   includeProperties: x => x.ColorProducts);
        //}
        //var result = _repository.GetAll(
        //    filter: x => x.SizeProducts.Select(y => y.SizeId).Contains(sizeId ?? -1)
        //              && x.ColorProducts.Select(y => y.ColorId).Contains(colorId ?? -1),
        //    includeProperties: x => x.ColorProducts);

        //return result;
        //}
    }
}
