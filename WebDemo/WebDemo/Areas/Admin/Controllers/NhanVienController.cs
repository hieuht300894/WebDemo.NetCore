using System.Threading.Tasks;
using EntityModel.Models;
using Microsoft.AspNetCore.Mvc;
using WebDemo.Services;
using System.Collections.Generic;
using WebDemo.Module;
using System;
using System.Linq;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebDemo.Areas.Admin.Controllers
{
    public class NhanVienController : BaseController<xNhanVien>
    {
        private IRepository<xNhanVien> repo;

        public NhanVienController(IRepository<xNhanVien> repository, IRepositoryCollection repositories) :
            base(repository, repositories)
        {
            this.repo = repository;
        }

        public override IActionResult Index()
        {
            ViewBag.TieuDe = "Trang quản lý admin";
            ViewBag.TenDanhMuc = "Danh mục nhân viên";
            ViewBag.ChucNang = "";

            var res = repo.GetAllV2(string.Empty, "sp_Search", 1);
            return base.Index();
        }

        public override IActionResult InsertItem([FromBody] xNhanVien item)
        {
            Dictionary<string, object> dic = ValidationItem(item);
            if (dic.Any(x => !string.IsNullOrEmpty(x.Value.ToString())))
                return Json(new
                {
                    status = BadRequest().StatusCode,
                    msg = dic
                });
            return base.InsertItem(item);
        }

        public override IActionResult UpdateItem([FromBody] xNhanVien item)
        {
            Dictionary<string, object> dic = ValidationItem(item);
            if (dic.Any(x => !string.IsNullOrEmpty(x.Value.ToString())))
                return Json(new
                {
                    status = BadRequest(),
                    msg = dic
                });
            return base.UpdateItem(item);
        }

        public override Dictionary<string, object> ValidationItem(xNhanVien item)
        {
            Dictionary<string, object> dic = base.ValidationItem(item);

            if (!dic.Any())
                return dic;

            dic.ToList().ForEach(x => dic[x.Key] = string.Empty);

            if (string.IsNullOrEmpty(item.Code))
                dic["code"] = "Trường không để trống";
            else
                repo.GetAll().Any(delegate (xNhanVien x)
                {
                    if (x.KeyID != item.KeyID && x.Code.ToLower().Equals(item.Code.ToLower()))
                    {
                        dic["code"] += "Trường đã tồn tại\n";
                        return true;
                    }
                    if (x.KeyID == item.KeyID && !x.Code.ToLower().Equals(item.Code.ToLower()))
                    {
                        dic["code"] += "Trường không được chỉnh sửa\n";
                        return true;
                    }
                    return false;
                });

            if (string.IsNullOrEmpty(item.Name))
                dic["name"] = "Trường không để trống";

            return dic;
        }
    }
}
