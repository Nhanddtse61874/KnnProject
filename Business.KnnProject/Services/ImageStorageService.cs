using Microsoft.AspNetCore.Http;
using Persistence.KnnProject.Models;
using Persistence.KnnProject.Repositories;
using System.Collections.Generic;

namespace Business.KnnProject.Services
{
    public interface IImageStorageService
    {
        IList<ImageStorage> GetByProduct(int productId);

        void UploadImages(List<IFormFile> files, int id);

        void Update(ImageStorage modifiedImg);

        void Delete(int imgId);
    }
    public class ImageStorageService : ServiceBase, IImageStorageService
    {
        private readonly IRepository<ImageStorage> _repository;
        private StorageService _storageService;

        public ImageStorageService()
        {
            _repository = _unitOfWork.Repository<ImageStorage>();
            _storageService = new StorageService();
            _unitOfWork.Save();
        }
        public void UploadImages(List<IFormFile> files, int id)
        {
            var models = new List<BlobModel>();
            foreach (var item in files)
            {
                var blobModel = new BlobModel
                {
                    FileName = item.FileName,
                    FileData = new byte[item.Length],
                    FileMimeType = item.ContentType
                };
                models.Add(blobModel);
            }

            var images = _storageService.UploadFileToBlobAsync(models);
            var createModels = new List<ImageStorage>();
            foreach (var item in images.Result)
            {
                var createModel = new ImageStorage
                {
                    ImageUrl = item,
                    Alt = item,
                    ProductId = id
                };
            }
            foreach (var item in createModels)
            {
                _repository.Create(item);
                _unitOfWork.Save();
            }
           
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
