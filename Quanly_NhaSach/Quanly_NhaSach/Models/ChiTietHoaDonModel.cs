using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI_QLNS.Models
{
    public class ChiTietHoaDonModel
    {
        public string IdHoaDon { get; set; }
        
        public int IdSach { get; set; }
        
        
        public long SoLuong { get; set; }

        public long DonGia { get; set; }
        public int Id { get; set; }

    }
}
