using Quanly_NhaSach.Models;

namespace WebAPI_QLNS.Models
{
    public class NguoiDungDangnhapModel : NguoiDungModel
    {
        public string TenNhanVien { set; get; }
        public string SoDT { set; get; }
        public string Email { set; get; }
        public int NhanVienId { set; get; }
    }
}
