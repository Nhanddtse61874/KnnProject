using Business.KnnProject.Services;
using KnnProject.ViewModels;
using Persistence.KnnProject.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace KnnProject.Controllers
{
    public class ContactController : ApiControllerBase
    {
        private readonly IContactService _service;

        public ContactController()
        {
            _service = new ContactService();
        }

        [HttpGet]
        public IHttpActionResult Get()
                => Ok(_mapper.Map<IEnumerable<ContactViewModel>>(_service.GetAllContact()));

        [HttpPost]
        public IHttpActionResult Post(CreateContactViewModel newModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _service.Create(_mapper.Map<Contact>(newModel));
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Put(UpdateContactViewModel modifiedModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _service.Update(_mapper.Map<Contact>(modifiedModel));
            return Ok();
        }


        [HttpDelete]
        public IHttpActionResult Delete(int contactId)
        {
            _service.Delete(contactId);
            return Ok();
        }
    }
}
