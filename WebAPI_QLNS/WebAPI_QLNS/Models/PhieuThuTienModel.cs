using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace WebAPI_QLNS.Models
{
    public class PhieuThuTienModel
    {
        public string Id { get; set; }

        public int IdKhachHang { get; set; }

        public DateTime Ngay { get; set; }

        public long Tien { get; set; }

    }
}
