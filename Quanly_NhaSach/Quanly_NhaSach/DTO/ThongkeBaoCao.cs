using System;
using System.Collections.Generic;
using System.Text;

namespace Quanly_NhaSach.DTO
{
    public class ThongtinThongke
    {
        public int Thang { get; set; }
        public int Nam { get; set; }
        public int Id { get; set; }
    }
    public class PhieuCongNo
    {
        public string Id { get; set; }
        public string Loai { get; set; }
        public long SoLuong { get; set; }
        public DateTime Ngay { get; set; }
        public long No { get; set; }
    }
    public class ThongKeCongNoTrongKy
    {
        private long _tang;
        private long _giam;
        private long _phatsinh;
        public long IdKhachHang { get; set; }
        public string TenKhachHang { get; set; }
        public List<PhieuCongNo> DS { get; set; }
        public long DauKy { get; set; }
        public long Tang
        {
            get { return _tang; }
            set
            {
                _tang = value;
                _phatsinh = _tang - _giam;
            }
        }
        public long Giam
        {
            get { return _giam; }
            set
            {
                _giam = value;
                _phatsinh = _tang - _giam;
            }
        }
        public long Phatsinh
        {
            get { return _phatsinh; }
            set { _phatsinh = value; }
        }

        public long CuoiKy { get; set; }

    }
    public class PhieuNhapXuat
    {
        public string Id { get; set; }
        public string Loai { get; set; }
        public long SoLuong { get; set; }
        public DateTime Ngay { get; set; }
        public long Ton { get; set; }
    }
    public class ThongKeNXTTrongKy
    {
        public List<PhieuNhapXuat> DS { get; set; }
        public long DauKy { get; set; }
        public long Tang { get; set; }
        public long Giam { get; set; }
        public long CuoiKy { get; set; }
    }
    internal class ThongkeBaoCao
    {
    }
}
