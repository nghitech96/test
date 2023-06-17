using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI_QLNS.DTO
{
    public class NguoiDung
    {
        
        [Column("TaiKhoan")]
        [StringLength(50)]
        public string TaiKhoan { set; get; }

        [Column("MatKhau")]
        [StringLength(250)]
        public string MatKhau { set; get; }

        [Key]
        [Column("NguoiDungId", TypeName = "int")]
        public int NguoiDungId { get; set; }

        [Column("VaiTroId", TypeName = "int")] 
        public int VaiTroId { get; set; }

        [Column("TrangThai", TypeName = "int")]
        public int TrangThai { get; set; }

        [Column("NhanVienId", TypeName = "int")]
        public int NhanVienId { get; set; }




    }
}
