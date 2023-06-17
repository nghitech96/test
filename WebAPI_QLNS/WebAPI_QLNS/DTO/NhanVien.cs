using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI_QLNS.DTO
{
    [Table("NhanVien")]
    public class NhanVien
    {
        public NhanVien() { }

        [Column("TenNhanVien")]
        [StringLength(50)]
        public string TenNhanVien { set; get; }
        
        [Column("SoDT")]
        [StringLength(20)]
        public string SoDT { set; get; }

        [Column("Email")]
        [StringLength(250)]
        public string Email { set; get; }
        
        [Key]
        [Column("Id")]
        public int Id { set; get; }

        [Column("ChucVu")]
        [StringLength(50)]
        public string ChucVu { get; set; }

        
        //[ForeignKey("NhanVienId")]
        //public virtual ICollection<NguoiDung> NguoiDungs { get; set; }
    }
}
