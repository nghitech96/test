using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI_QLNS.Models
{
    public class PhieuNhapSachModel
    {
        public string Id { get; set; }

        public System.DateTime Ngay { get; set; }
    }
}
