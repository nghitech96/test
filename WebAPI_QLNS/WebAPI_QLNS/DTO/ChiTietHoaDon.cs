using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace WebAPI_QLNS.DTO
{
    public class ChiTietHoaDon
    {
        [Column("IdHoaDon")]
        [StringLength(50)]
        public string IdHoaDon { get; set; }
        
        [Column("IdSach", TypeName ="int")]
        public int IdSach { get; set; }
        
        [Column("SoLuong", TypeName = "long")]
        public long SoLuong { get; set; }

        [Column("DonGia", TypeName = "long")]
        public long DonGia { get; set; }

        [Key]
        [Column("Id", TypeName = "int")]
        public int Id { get; set; }

        public virtual HoaDonBanHang HoaDonBanHang { get; set; }
        public virtual Sach Sach { get; set; }
    }
}
