using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quanly_NhaSach.DTO
{
    public class ChiTietNhapSach: INotifyPropertyChanged
    {
       // [Key]
        public string IdPhieuNhap { get; set; }
       // [Key]
        [Column("IdSach", TypeName = "int")]
        public int IdSach { get; set; }
        [Column("SoLuong", TypeName = "long")]
        public long SoLuong { get; set; }

        [Column("Id", TypeName = "int")]
        public int Id { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;

        //public virtual PhieuNhapSach PhieuNhapSach { get; set; }
        //[ForeignKey("IdSach")]
        //public virtual Sach Sach { get; set; }
    }
}
