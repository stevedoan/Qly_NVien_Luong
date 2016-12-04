﻿using Qly_Luong_NVien_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qly_Luong_NVien_Service
{
    public class HeSoLuongService : CommonCRUDService<HeSoLuong, int>
    {
        protected override Type assignedClass()
        {
            return typeof(HeSoLuong);
        }
    }
}
