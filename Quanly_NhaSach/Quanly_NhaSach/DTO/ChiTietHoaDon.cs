using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quanly_NhaSach.DTO
{
    public class ChiTietHoaDon: INotifyPropertyChanged
    {
        private long _soluong =0;
        private long _dongia = 0;
        [Column("IdHoaDon")]
        [StringLength(50)]
        public string IdHoaDon { get; set; }
        
        [Column("IdSach", TypeName ="int")]
        public int IdSach { get; set; }
        
        [Column("SoLuong", TypeName = "long")]
        public long SoLuong
        {
            get { return _soluong; }
            set
            {
                _soluong = value;
                TTien = _dongia * _soluong;
            }
        }

        [Column("DonGia", TypeName = "long")]
        public long DonGia { 
            get { return _dongia; } 
            set { _dongia = value; TTien = _dongia * _soluong;}
        }
        [Column("DonGia", TypeName = "long")]
        public long TTien { get; set; }

        [Column("Id", TypeName = "int")]
        public int Id { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        //public virtual HoaDonBanHang HoaDonBanHang { get; set; }
        //public virtual Sach Sach { get; set; }
    }
}
