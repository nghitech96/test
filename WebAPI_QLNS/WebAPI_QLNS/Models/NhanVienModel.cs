using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI_QLNS.Models
{
    public class NhanVienModel
    {
        public string TenNhanVien { set; get; }
        
        public string SoDT { set; get; }

        public string Email { set; get; }
        
        public int Id { set; get; }

        public string ChucVu { get; set; }

        
    }
}
