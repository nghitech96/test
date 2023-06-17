using System;
using System.Collections.Generic;
using System.Text;

namespace Quanly_NhaSach.Models
{

    public class ThongtinThongkeModel
    {
        public int Thang { get; set; }
        public int Nam { get; set; }
        public int Id { get; set; }
    }
    public class PhieuCongNoModel
    {
        public string Id { get; set; }
        public string Loai { get; set; }
        public long SoLuong { get; set; }
        public DateTime Ngay { get; set; }
        public long No { get; set; }
    }
    public class ThongKeCongNoTrongKyModel
    {
        public long IdKhachHang { get; set; }
        public string TenKhachHang { get; set; }
        public List<PhieuCongNoModel> DS { get; set; }
        public long DauKy { get; set; }
        public long Tang { get; set; }
        public long Giam { get; set; }
        public long CuoiKy { get; set; }
    }
    public class PhieuNhapXuatModel
    {
        public string Id { get; set; }
        public string Loai { get; set; }
        public long SoLuong { get; set; }
        public DateTime Ngay { get; set; }
        public long Ton { get; set; }
    }
    public class ThongKeNXTTrongKyModel
    {
        public List<PhieuNhapXuatModel> DS { get; set; }
        public long DauKy { get; set; }
        public long Tang { get; set; }
        public long Giam { get; set; }
        public long CuoiKy { get; set; }
    }

    internal class ThongKeBaoCaoModel
    {
    }
}
