﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel.Models
{
    public class xTaiKhoan
    {
        public int KeyID { get; set; }

        public string Code { get; set; }

        public string Password { get; set; }

        public int IDNhanVien { get; set; }

        public string NhanVien { get; set; }
    }
}
