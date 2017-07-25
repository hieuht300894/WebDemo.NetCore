using EntityModel.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using WebDemo.Services;

namespace WebDemo.Areas.Admin.Controllers
{
    public class HomeController : BaseController<xNhanVien>
    {
        public HomeController(IRepository<xNhanVien> repository, IRepositoryCollection repositories) : 
            base(repository, repositories)
        {

        }

        public override IActionResult Index()
        {
            ViewBag.TieuDe = "Trang quản lý admin";
            ViewBag.TenDanhMuc = "";
            ViewBag.ChucNang = "";
            return base.Index();
        }
    }
}