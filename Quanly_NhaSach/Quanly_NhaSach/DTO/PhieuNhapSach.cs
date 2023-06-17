using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quanly_NhaSach.DTO
{
    public class PhieuNhapSach: INotifyPropertyChanged
    {
        [Key]
        [StringLength(50)]
        public string Id { get; set; }

        [Column("Ngay")]
        public System.DateTime Ngay { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        //public virtual ICollection<ChiTietNhapSach> ChiTietNhapSaches { get; set; }
    }
}
