using Persistence.KnnProject.Models;
using Persistence.KnnProject.Repositories;
using System.Collections.Generic;

namespace Business.KnnProject.Services
{
    public interface ICategoryService
    {
        IList<Category> GetAllCategory();

        void Create(Category newCategory);

        void Update(Category modifiedCategory);

        void Delete(int categoryId);
    }
    public class CategoryService : ServiceBase, ICategoryService
    {
        private readonly IRepository<Category> _repository;

        public CategoryService()
        {
            _repository = _unitOfWork.Repository<Category>();
        }

        public IList<Category> GetAllCategory()
        {
            var result = _repository.GetAll(x => x.ParentId == null);
            foreach (var parent in result)
            {
                var sub = _repository.GetAll(x => x.ParentId == parent.Id);
                parent.SubCategories = sub;
            }

            return result;      
        }
        
        public void Create(Category newCategory)
        {
            _repository.Create(newCategory);
            _unitOfWork.Save(); 
        }

        public void Update(Category modifiedCategory)
        {
            _repository.Update(modifiedCategory);
            _unitOfWork.Save();
        }

        public void Delete(int categoryId)
        {
            _repository.Delete(categoryId);
            _unitOfWork.Save();
        }
    }
}
