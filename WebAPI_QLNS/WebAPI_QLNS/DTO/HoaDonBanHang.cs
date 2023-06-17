using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace WebAPI_QLNS.DTO
{
    public class HoaDonBanHang
    {
        [Key]
        [StringLength(50)]
        public string Id { get; set; }

        [Column("Ngay",TypeName ="DateTime")]        
        
        public DateTime Ngay { get; set; }

        [Column("IdKhachHang", TypeName ="int")]
        public int IdKhachHang { get; set; }
        
        [Column("ThanhTien", TypeName = "long")]
        public long ThanhTien { get; set; }
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }

        public virtual KhachHang KhachHang { get; set; }

    }
}
