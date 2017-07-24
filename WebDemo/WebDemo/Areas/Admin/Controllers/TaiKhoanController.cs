using EntityModel.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebDemo.Module;
using WebDemo.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebDemo.Areas.Admin.Controllers
{
    public class TaiKhoanController : BaseController<xTaiKhoan>
    {
        private IRepository<xTaiKhoan> repoTaiKhoan;
        private IRepository<xNhanVien> repoNhanVien;

        public TaiKhoanController(IRepository<xTaiKhoan> repository, IRepositoryCollection repositories) :
            base(repository, repositories)
        {
            repoTaiKhoan = repository;
            repoNhanVien = repositories.GetRepository<xNhanVien>();
        }

        public override IActionResult Index()
        {
            ViewBag.TieuDe = "Trang quản lý admin";
            ViewBag.TenDanhMuc = "Danh mục tài khoản";
            ViewBag.ChucNang = "";
            return base.Index();
        }

        public override IActionResult Insert()
        {
            List<xNhanVien> lstNhanVien = new List<xNhanVien>();
            var q = repoNhanVien.GetAll().Select(x => x.KeyID).Except(repoTaiKhoan.GetAll().Select(x => x.IDNhanVien));
            q.ToList().ForEach(x => lstNhanVien.Add(repoNhanVien.Detail(x)));
            ViewBag.DanhSachNhanVien = lstNhanVien;
            return base.Insert();
        }

        public override IActionResult Update(int id)
        {
            xTaiKhoan tk = repoTaiKhoan.Detail(id) ?? new xTaiKhoan();
            ViewBag.DanhSachNhanVien = new List<xNhanVien>() { new xNhanVien() { KeyID = tk.IDNhanVien, Name = tk.NhanVien } };
            return base.Update(id);
        }

        public override IActionResult InsertItem([FromBody] xTaiKhoan item)
        {
            Dictionary<string, object> dic = ValidationItem(item);
            if (dic.Any(x => !string.IsNullOrEmpty(x.Value.ToString())))
                return Json(new
                {
                    status = BadRequest().StatusCode,
                    msg = dic
                });
            item.NhanVien = (repoNhanVien.Detail(item.IDNhanVien) ?? new xNhanVien()).Name;
            return base.InsertItem(item);
        }

        public override IActionResult UpdateItem([FromBody] xTaiKhoan item)
        {
            Dictionary<string, object> dic = ValidationItem(item);
            if (dic.Any(x => !string.IsNullOrEmpty(x.Value.ToString())))
                return Json(new
                {
                    status = BadRequest(),
                    msg = dic
                });
            item.NhanVien = (repoNhanVien.Detail(item.IDNhanVien) ?? new xNhanVien()).Name;
            return base.UpdateItem(item);
        }

        public override Dictionary<string, object> ValidationItem(xTaiKhoan item)
        {
            Dictionary<string, object> dic = base.ValidationItem(item);

            if (!dic.Any())
                return dic;

            dic.ToList().ForEach(x => dic[x.Key] = string.Empty);

            if (string.IsNullOrEmpty(item.Code))
                dic["Code".ToLower()] = "Tên tài khoản không để trống";
            else
                repoTaiKhoan.GetAll().Any(delegate (xTaiKhoan x)
                {
                    if (x.KeyID != item.KeyID && x.Code.ToLower().Equals(item.Code.ToLower()))
                    {
                        dic["Code".ToLower()] += "Tên tài khoản đã tồn tại\n";
                        return true;
                    }
                    if (x.KeyID == item.KeyID && !x.Code.ToLower().Equals(item.Code.ToLower()))
                    {
                        dic["Code".ToLower()] += "Tên tài khoản không được chỉnh sửa\n";
                        return true;
                    }
                    return false;
                });

            if (item.IDNhanVien == 0)
                dic["IDNhanVien".ToLower()] = "Nhân viên chưa được chọn";
            else
            {
                repoTaiKhoan.GetAll().Any(delegate (xTaiKhoan x)
                {
                    if (x.KeyID != item.KeyID && x.IDNhanVien == item.IDNhanVien)
                    {
                        dic["IDNhanVien".ToLower()] += "Nhân viên đã có tài khoản\n";
                        return true;
                    }
                    if (x.KeyID == item.KeyID && x.IDNhanVien != item.IDNhanVien)
                    {
                        dic["IDNhanVien".ToLower()] += "Nhân viên không được chỉnh sửa\n";
                        return true;
                    }
                    return false;
                });
            }

            if (string.IsNullOrEmpty(item.Password))
                dic["Password".ToLower()] = "Mật khẩu không để trống";
            return dic;
        }
    }
}
