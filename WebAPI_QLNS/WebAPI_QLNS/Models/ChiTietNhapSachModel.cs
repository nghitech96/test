using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI_QLNS.Models
{
    public class ChiTietNhapSachModel
    {
        public string IdPhieuNhap { get; set; }
        public int IdSach { get; set; }
        public long SoLuong { get; set; }
        public int Id { get; set; }
    }
}
