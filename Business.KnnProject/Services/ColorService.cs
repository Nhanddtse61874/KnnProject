using Persistence.KnnProject.Models;
using Persistence.KnnProject.Repositories;
using System.Collections.Generic;

namespace Business.KnnProject.Services
{
    public interface IColorService
    {
        IList<Color> GetAllColor();

        void Create(Color newColor);

        void Delete(int idColor);

        void Update(Color modifiedColor);
    }
    public class ColorService : ServiceBase,IColorService
    {
        private readonly IRepository<Color> _repository;

        public ColorService()
        {
            _repository = _unitOfWork.Repository<Color>();
        }
        public void Create(Color newColor)
        {
            _repository.Create(newColor);
            _unitOfWork.Save();
        }

        public void Delete(int idColor)
        {
            _repository.Delete(idColor);
            _unitOfWork.Save();
        }

        public IList<Color> GetAllColor() => _repository.GetAll();
        

        public void Update(Color modifiedColor)
        {
            _repository.Update(modifiedColor);
            _unitOfWork.Save();
        }
    }
}
