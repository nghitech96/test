using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quanly_NhaSach.DTO
{
    public class PhieuThuTien: INotifyPropertyChanged
    {
        [Key]
        [StringLength(50)]
        public string Id { get; set; }

        [Column("IdKhachHang", TypeName ="int")]
        public int IdKhachHang { get; set; }

        [Column("Ngay")]
        public System.DateTime Ngay { get; set; }

        [Column("Tien", TypeName = "long")]
        public long Tien { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        // public virtual KhachHang KhachHang { get; set; }
    }
}
