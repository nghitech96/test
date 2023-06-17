using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI_QLNS.DTO
{
    public class NguoiDungDangnhap:NguoiDung
    {
        [Column("TenNhanVien")]
        [StringLength(255)]
        public string TenNhanVien { set; get; }
        [Column("SoDienThoai")]
        [StringLength(15)]
        public string SoDT { set; get; }
        [Column("Email")]
        [StringLength(255)]
        public string Email { set; get; }       
        
        [Column("NhanVienId", TypeName = "int")]
        public int NhanVienId { set; get; }
    }
}
