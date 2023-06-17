using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quanly_NhaSach.DTO
{
    public class HoaDonBanHang: INotifyPropertyChanged
    {
        [Key]
        [StringLength(50)]
        public string Id { get; set; }

        [Column("Ngay",TypeName ="DateTime")]        
        
        public System.DateTime Ngay { get; set; }

        [Column("IdKhachHang", TypeName ="int")]
        public int IdKhachHang { get; set; }
        
        [Column("ThanhTien", TypeName = "long")]
        public long ThanhTien { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        //public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }

        //public virtual KhachHang KhachHang { get; set; }

    }
}
