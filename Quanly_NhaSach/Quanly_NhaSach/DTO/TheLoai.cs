using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Quanly_NhaSach.DTO
{
    public class TheLoai: INotifyPropertyChanged
    {
        [Key]
        public int Id { get; set; }
        [Column("Ten")]
        [StringLength(50)]
        public string Ten { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        //public virtual ICollection<Sach> Saches { get; set; }
    }
}
