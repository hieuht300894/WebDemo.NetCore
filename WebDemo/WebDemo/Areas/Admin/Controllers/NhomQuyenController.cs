using EntityModel.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebDemo.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebDemo.Areas.Admin.Controllers
{
    public class NhomQuyenController : BaseController<xNhomQuyen>
    {
        public NhomQuyenController(IRepository<xNhomQuyen> repository, IRepositoryCollection repositories) :
            base(repository, repositories)
        { }

        public override IActionResult Index()
        {
            ViewBag.TieuDe = "Trang quản lý admin";
            ViewBag.TenDanhMuc = "Danh mục nhóm quyền";
            ViewBag.ChucNang = "";
            return base.Index();
        }
    }
}
