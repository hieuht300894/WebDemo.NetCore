using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EntityModel.Models;
using WebDemo.Services;
using WebDemo.Module;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebDemo.Areas.Admin.Controllers
{
    public class TinhThanhController : BaseViewController<eDM_TinhThanh>
    {
        private IRepository<eDM_TinhThanh> repository;
        public TinhThanhController(IRepository<eDM_TinhThanh> repository, IRepositoryCollection repositories) : base(repository, repositories)
        {
            this.repository = repository;
        }

        public override IActionResult Index()
        {
            ViewBag.TieuDe = "Trang quản lý admin";
            ViewBag.TenDanhMuc = "Danh mục tỉnh thành";
            ViewBag.ChucNang = "";
            ViewBag.DSLoaiTinhThanh = clsGeneral.LoaiTinhThanh;
            return base.Index();
        }

        public override IActionResult GetList([FromQuery] int[] ids)
        {
            int id = ids.Length > 0 ? ids[0] : 0;
            return PartialView(repository.GetAll().Where(x => x.IDLoai == id));
        }

        public override IActionResult Insert()
        {
            ViewBag.DSTinhThanh = repository.GetAll();
            ViewBag.DSLoaiTinhThanh = clsGeneral.LoaiTinhThanh;
            return base.Insert();
        }

        public override IActionResult InsertItem([FromBody] eDM_TinhThanh item)
        {
            Dictionary<string, object> dic = ValidationItem(item);
            if (dic.Any(x => !string.IsNullOrEmpty(x.Value.ToString())))
                return Json(new
                {
                    status = BadRequest().StatusCode,
                    msg = dic
                });
            item.Ma = string.Empty;
            item.Loai = clsGeneral.LoaiTinhThanh[item.IDLoai].ToString();
            item.TinhThanh = (repository.Detail(item.IDTinhThanh) ?? new eDM_TinhThanh()).Ten;
            return base.InsertItem(item);
        }

        public override IActionResult Update(int id)
        {
            eDM_TinhThanh curTT = repository.Detail(id) ?? new eDM_TinhThanh();
            eDM_TinhThanh parTT = repository.Detail(curTT.IDTinhThanh) ?? new eDM_TinhThanh();
            ViewBag.DSTinhThanh = repository.GetAll().Where(x => x.IDLoai == parTT.IDLoai);
            ViewBag.DSLoaiTinhThanh = clsGeneral.LoaiTinhThanh;
            return base.Update(id);
        }

        public override IActionResult UpdateItem([FromBody] eDM_TinhThanh item)
        {
            Dictionary<string, object> dic = ValidationItem(item);
            if (dic.Any(x => !string.IsNullOrEmpty(x.Value.ToString())))
                return Json(new
                {
                    status = BadRequest().StatusCode,
                    msg = dic
                });
            item.Ma = string.Empty;
            item.Loai = clsGeneral.LoaiTinhThanh[item.IDLoai].ToString();
            item.TinhThanh = (repository.Detail(item.IDTinhThanh) ?? new eDM_TinhThanh()).Ten;
            return base.UpdateItem(item);
        }

        public override Dictionary<string, object> ValidationItem(eDM_TinhThanh item)
        {
            Dictionary<string, object> dic = base.ValidationItem(item);

            if (!dic.Any())
                return dic;

            dic.ToList().ForEach(x => dic[x.Key] = string.Empty);

            if (string.IsNullOrEmpty(item.Ten))
                dic["Ten".ToLower()] = "Tên không để trống";

            if (item.IDLoai == 0)
                dic["IDLoai".ToLower()] = "Loại không để trống";

            return dic;
        }

        [Route("tinhthanhbyidloai")]
        public IActionResult GetTinhThanhBy(int keyid, int idloai)
        {
            if (keyid > 0)
                return Json(repository.GetAll().Where(x => x.IDLoai == idloai && x.KeyID != keyid));
            return Json(repository.GetAll().Where(x => x.IDLoai == idloai));
        }
    }
}
