using Persistence.KnnProject.Models;
using Persistence.KnnProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.KnnProject.Services
{
    public interface IReviewService
    {
        void Create(Review newPreview);

        void Update(Review modifiedPreview);

        void Delete(int previewId);

        IList<Review> Get();
    }
    public class ReviewService : ServiceBase, IReviewService
    {
        private readonly IRepository<Review> _repoPreview;

        public ReviewService()
        {
            _repoPreview = _unitOfWork.Repository<Review>();
        }
        public void Create(Review newModel)
        {
            _repoPreview.Create(newModel);
            _unitOfWork.Save();
        }

        public void Delete(int previewId)    
        {
            _repoPreview.Delete(previewId);
            _unitOfWork.Save();
        }

        public IList<Review> Get()
        {
            var result = _repoPreview.GetAll();
            return result;
        }

        public void Update(Review modifiedModel)
        {
            _repoPreview.Update(modifiedModel);
            _unitOfWork.Save();
        }
    }
}
