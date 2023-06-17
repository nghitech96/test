using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI_QLNS.DTO
{
    public class KhachHang
    {
        [Key]
        public int Id { get; set; }

        [Column("Ten")]
        [StringLength(250)]
        public string Ten { get; set; }

        [Column("DiaChi")]
        [StringLength(250)]
        public string DiaChi { get; set; }
        [Column("DienThoai")]
        [StringLength(50)]
        public string DienThoai { get; set; }
        [Column("Email")]
        [StringLength(250)]
        public string Email { get; set; }
        public virtual ICollection<HoaDonBanHang> HoaDonBanHangs { get; set; }
        public virtual ICollection<PhieuThuTien> PhieuThuTiens { get; set; }
    }
}
