using EntityModel.Models;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

namespace WebDemo.Model
{
    public static class DbInitializer
    {
        public static void Initialize(zModel db)
        {
            db.Database.EnsureCreated();
            try
            {
                if (!db.xNhanVien.Any())
                {
                    int n = 100;
                    xNhanVien[] lstNVs = new xNhanVien[n];

                    for (int i = 0; i < n; i++)
                    {
                        lstNVs[i] = new xNhanVien() { Code = $"NV{(i + 1)}", Name = $"Nhân viên {(i + 1)}" };
                    }

                    db.xNhanVien.AddRange(lstNVs.ToArray());
                    db.SaveChanges();
                }
            }
            catch { }
        }
    }
}
