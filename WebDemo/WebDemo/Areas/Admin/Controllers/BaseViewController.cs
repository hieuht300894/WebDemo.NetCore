using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebDemo.Services;
using WebDemo.Module;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebDemo.Areas.Admin.Controllers
{
    public class BaseViewController<T> : BaseController<T> where T : class, new()
    {
        private IRepository<T> repository;
        private IRepositoryCollection repositories;

        public BaseViewController(IRepository<T> repository, IRepositoryCollection repositories) : base(repository, repositories)
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
        public override IActionResult InsertItem([FromBody] T item)
        {
            return base.InsertItem(item);
        }

        [HttpPost]
        [Route("capnhat")]
        public override IActionResult UpdateItem([FromBody] T item)
        {
            return base.UpdateItem(item);
        }

        [HttpPost]
        [Route("xoa")]
        public override IActionResult DeleteItem(int id)
        {
            return base.DeleteItem(id);
        }

        public override Dictionary<string, object> ValidationItem(T item)
        {
            return base.ValidationItem(item);
        }
    }
}
