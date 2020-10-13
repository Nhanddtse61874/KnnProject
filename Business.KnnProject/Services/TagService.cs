using Persistence.KnnProject.Models;
using Persistence.KnnProject.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Business.KnnProject.Services
{
    public interface ITagService
    {
        IList<Tag> GetAllTag();

        void Create(Tag newTag);

        void Delete(int tagId);

        void Update(Tag modifiedTag);
    }
    public class TagService : ServiceBase, ITagService
    {
        private readonly IRepository<Tag> _repository;

        public TagService()
        {
            _repository = _unitOfWork.Repository<Tag>();
        }
        public void Create(Tag newTag)
        {
            _repository.Create(newTag);
            _unitOfWork.Save();
        }

        public void Delete(int tagId)
        {
            _repository.Delete(tagId);
            _unitOfWork.Save();
        }

        public IList<Tag> GetAllTag()
        {
            var result = _repository.GetAll().ToList();
           
            return result;
        }

        public void Update(Tag modifiedTag)
        {
            _repository.Update(modifiedTag);
            _unitOfWork.Save();
        }
    }
}
