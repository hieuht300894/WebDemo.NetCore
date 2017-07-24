using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebDemo.Module;
using WebDemo.Services;

namespace WebDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]")]
    public class BaseController<T> : Controller where T : class, new()
    {
        private IRepository<T> repository;
        private IRepositoryCollection repositories;
        public BaseController(IRepository<T> repository, IRepositoryCollection repositories)
        {
            this.repository = repository;
            this.repositories = repositories;
        }

        [HttpGet]
        public virtual IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("listitem/{id?}")]
        public virtual IEnumerable<T> GetListItems([FromQuery] int[] ids)
        {
            return repository.GetAll();
        }

        [HttpGet("{id}")]
        public virtual T DetailItem(int id)
        {
            T item = repository.Detail(id);
            return item;


        }

        [HttpGet]
        [Route("danhsach/{id?}")]
        public virtual IActionResult GetList([FromQuery] int[] ids)
        {
            return PartialView(repository.GetAll());
        }

        [HttpGet]
        [Route("themmoi/{id?}")]
        public virtual IActionResult Insert()
        {
            return PartialView(new T());
        }

        [HttpGet]
        [Route("capnhat/{id?}")]
        public virtual IActionResult Update(int id)
        {
            T item = DetailItem(id);
            if (item == null)
                return NotFound();
            return PartialView(item);
        }

        [HttpPost]
        [Route("themmoi")]
        public virtual IActionResult InsertItem([FromBody] T item)
        {
            if (item == null)
                return BadRequest();

            T _item = repository.Insert(item);

            if (_item == null)
                return StatusCode(500);
            return StatusCode(201, item);
        }

        [HttpPut]
        [Route("capnhat")]
        public virtual IActionResult UpdateItem([FromBody] T item)
        {
            if (item == null)
                return BadRequest();

            T _item = repository.Update(item);

            if (_item == null)
                return StatusCode(500);
            return StatusCode(201, item);
        }

        [HttpDelete]
        [Route("xoa")]
        public virtual IActionResult DeleteItem(int id)
        {
            if (id == 0)
                return NotFound();

            var chk = repository.Delete(id);
            if (!chk)
                return StatusCode(500);

            return StatusCode(204);
        }

        public virtual Dictionary<string, object> ValidationItem(T item)
        {
            return clsEntity.GetValue(item);
        }
    }
}