using Persistence.KnnProject.Models;
using Persistence.KnnProject.Repositories;
using System.Collections.Generic;

namespace Business.KnnProject.Services
{
    public interface IContactService
    {
        IList<Contact> GetAllContact();

        void Create(Contact newContact);

        void Update(Contact modifiedContact);

        void Delete(int idContact);
    }
    public class ContactService : ServiceBase, IContactService
    {
        private readonly IRepository<Contact> _repository;

        public ContactService()
        {
            _repository = _unitOfWork.Repository<Contact>();
            _unitOfWork.Save();
        }
        public void Create(Contact newContact)
        {
            _repository.Create(newContact);
            _unitOfWork.Save();
        }

        public void Delete(int idContact)
        {
            _repository.Delete(idContact);
            _unitOfWork.Save();
        }

        public IList<Contact> GetAllContact() => _repository.GetAll();
       

        public void Update(Contact modifiedContact)
        {
            _repository.Update(modifiedContact);
            _unitOfWork.Save();
        }
    }
}
