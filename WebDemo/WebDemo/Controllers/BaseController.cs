using Microsoft.AspNetCore.Mvc;

namespace WebDemo.Controllers
{
    [Route("[controller]")]
    public class BaseController<T> : Controller where T : class, new()
    {
        [HttpGet]
        public virtual IActionResult Index()
        {
            return View();
        }

        [HttpGet("{id}")]
        public virtual IActionResult Detail(int id)
        {
            return View();

        }

        [HttpPost]
        public virtual IActionResult Insert([FromBody] T item)
        {
            return View(item);
        }

        [HttpPut]
        public virtual IActionResult Update([FromBody] T item)
        {
            return View(item);
        }

        [HttpDelete("{id}")]
        public virtual IActionResult Delete(int id)
        {
            return View();
        }
    }
}