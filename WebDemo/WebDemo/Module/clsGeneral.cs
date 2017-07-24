using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebDemo.Module
{
    public static class clsGeneral
    {
        public static Dictionary<int, string> LoaiTinhThanh = new Dictionary<int, string>()
        {
            { 0, string.Empty },
            { 1, "Thành phố TW" },
            { 2, "Tỉnh" },
            { 3, "Quận" },
            { 4, "Huyện" },
            { 5, "Thành phố trực thuộc TW" },
            { 6, "Thị xã" },
            { 7, "Phường" },
            { 8, "Xã" },
            { 9, "Thị trấn" }
        };
    }
}
