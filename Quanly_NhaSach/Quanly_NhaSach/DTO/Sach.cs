using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Quanly_NhaSach.DTO
{
    public class Sach: INotifyPropertyChanged
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

        [Column("Ton", TypeName = "long")]
        public long SoluongTon { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        

    }
}
