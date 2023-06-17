using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quanly_NhaSach.DTO
{
    [Table("NhanVien")]
    public class NhanVien: INotifyPropertyChanged
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

        public event PropertyChangedEventHandler PropertyChanged;


        //[ForeignKey("NhanVienId")]
        //public virtual ICollection<NguoiDung> NguoiDungs { get; set; }
    }
}
