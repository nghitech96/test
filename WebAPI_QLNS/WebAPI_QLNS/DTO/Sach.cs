using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPI_QLNS.DTO
{
    public class Sach
    {
        [Key]
        public int Id { get; set; }

        [Column("Ten")]
        [StringLength(50)]
        public string Ten { get; set; }

        [Column("IdTacGia", TypeName ="int")]
        public int IdTacGia { get; set; }

        [Column("IdTheLoai", TypeName = "int")]
        public int IdTheLoai { get; set; }

        [Column("SoluongTon", TypeName = "long")]
        public long SoluongTon { get; set; }

        public virtual TacGia TacGia { get; set; }
        public virtual TheLoai TheLoai { get; set; }

        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }

        public virtual ICollection<ChiTietNhapSach> ChiTietNhapSachs { get; set; }
        
    }
}
