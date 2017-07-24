using EntityModel.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebDemo.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebDemo.Areas.Admin.Controllers
{
    public class PhanQuyenController : BaseController<xPhanQuyen>
    {
        public PhanQuyenController(IRepository<xPhanQuyen> repository, IRepositoryCollection repositories) :
            base(repository, repositories)
        { }

        public override IActionResult Index()
        {
            ViewBag.TieuDe = "Trang quản lý admin";
            ViewBag.TenDanhMuc = "Danh mục phân quyền";
            ViewBag.ChucNang = "";
            return base.Index();
        }
    }
}
