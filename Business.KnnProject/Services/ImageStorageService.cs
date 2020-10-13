using Persistence.KnnProject.Models;
using Persistence.KnnProject.Repositories;
using System.Collections.Generic;

namespace Business.KnnProject.Services
{
    public interface IImageStorageService
    {
        IList<ImageStorage> GetByProduct(int productId);

        void Create(ImageStorage newImg);

        void Update(ImageStorage modifiedImg);

        void Delete(int imgId);
    }
    public class ImageStorageService : ServiceBase, IImageStorageService
    {
        private readonly IRepository<ImageStorage> _repository;

        public ImageStorageService()
        {
            _repository = _unitOfWork.Repository<ImageStorage>();
            _unitOfWork.Save();
        }
        public void Create(ImageStorage newImg)
        {
            _repository.Create(newImg);
            _unitOfWork.Save();
        }

        public void Delete(int imgId)
        {
            _repository.Delete(imgId);
            _unitOfWork.Save();
        }

        public IList<ImageStorage> GetByProduct(int productId)
         => _repository.GetAll(x => x.ProductId == productId);

        public void Update(ImageStorage modifiedImg)
        {
            _repository.Update(modifiedImg);
            _unitOfWork.Save();
        }
    }
}
