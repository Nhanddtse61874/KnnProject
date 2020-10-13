using Persistence.KnnProject.Models;
using Persistence.KnnProject.Repositories;
using System.Collections.Generic;

namespace Business.KnnProject.Services
{
    public interface ISizeService
    {
        IList<Size> Get();

        void Update(Size modifiedSize);

        void Create(Size newSize);

        void Delete(int sizeId);
    }
    public class SizeService : ServiceBase, ISizeService
    {
        private readonly IRepository<Size> _repo;

            public SizeService()
        {
            _repo = _unitOfWork.Repository<Size>();
        }
        public void Create(Size newSize)
        {
            _repo.Create(newSize);
            _unitOfWork.Save();
        }

        public void Delete(int sizeId)
        {
            _repo.Delete(sizeId);
            _unitOfWork.Save();
        }

        public IList<Size> Get()
            => _repo.GetAll();
        
        public void Update(Size modifiedSize)
        {
            _repo.Update(modifiedSize);
            _unitOfWork.Save();
        }
    }
}
