using KnnProject.ViewModels;
using Persistence.DataAccess.Models;
using Persistence.KnnProject.Models;
using Persistence.KnnProject.Repositories;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace KnnProject.Controllers
{
    /// <summary>
    /// RESTful API
    /// 
    /// => web app => base_url/controller/action?argu=...
    /// => web app => base_url/controller?argy=....
    /// => ko co action thi` phan biet qua gi?
    ///> GET/POST/PUT/DELETE
    /// </summary>


    public class ProductsController : ApiControllerBase
    {
        IUnitOfWork _unit = new UnitOfWork();
        IRepository<User> _userRepo;
        IRepository<Category> _cateRepo;
        private readonly KnnDbContext db = new KnnDbContext();


        public ProductsController()
        {
            _cateRepo = _unit.Repository<Category>();
            _userRepo = _unit.Repository<User>();
        }

        // GET: api/Products
        public IHttpActionResult GetProduct(int pageIndex = 1, int pageElement = 10)
        {
            var c = _userRepo.GetElementByConditions(x => x.Address == "132");
            return Ok(c);
        }

        // GET: api/Products/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult GetProduct(int id)
        {
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // PUT: api/Products/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduct(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.Id)
            {
                return BadRequest();
            }

            db.Entry(product).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Products
        [ResponseType(typeof(Product))]
        public IHttpActionResult PostProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //unit of work == db

            //repository == db.Product
            db.Product.Add(product);

            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = product.Id }, product);
        }

        // DELETE: api/Products/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult DeleteProduct(int id)
        {
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            // => cơ chế linq: defered excute -> trì hoãn thực thi
            var a = db.Product;
            var b = a.Where(x => x.Name == "1");
            foreach (var item in a)
            {
                item.Id = 1;

                //nếu dùng lazy load
                item.TagProducts = db.TagProduct.ToList();// => multiple trip into database
            }//dùng lazy load => phải cẩn thận, nếu ko có exp thì tốt nhất là đừng dùng

            //eager loading
            //muốn load product kèm TagProducts => phải ghi rõ ra là mình muốn load cả 2
            var a2 = db.Product.Include(x => x.TagProducts);
            var b2 = a.Where(x => x.Name == "1");
            foreach (var item in a2)
            {
                item.Id = 1;

                //nếu dùng eager loading
                item.TagProducts = db.TagProduct.ToList();
            }//dùng eager loading => chú ý null, chú ý là mình sẽ cần những gì trong 1 câu query

            //explicit loading
            db.Product.Remove(product);
            db.SaveChanges();

            return Ok(product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(int id)
        {
            return db.Product.Count(e => e.Id == id) > 0;
        }
    }
}