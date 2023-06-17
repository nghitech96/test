using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace WebAPI_QLNS.Models
{
    public class PhieuNhapSachModel
    {
        public string Id { get; set; }

        public DateTime Ngay { get; set; }
    }
}
