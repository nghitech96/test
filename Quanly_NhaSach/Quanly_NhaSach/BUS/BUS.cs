using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanly_NhaSach.BUS
{
    internal class BL
    {
        private static BL _ins;

        public static BL Ins
        {
            get
            {
                if (_ins == null)
                {
                    _ins = new BL ();
                }
                return _ins; ;
            }
        }
        public BUS_TacGia TacGia { get; set; }
        public BUS_TheLoai TheLoai { get; set; }
        public BUS_KhachHang KhachHang { get; set; }
        public BUS_Sach Sach { get; set; }
        public BUS_PhieuNhapSach PhieuNhapSach { get; set; }
        public BUS_HoaDonBanHang HoaDonBanHang { get; set; }
        public BUS_PhieuThuTien PhieuThuTien { get; set; }
        public BUS_QuyDinh QuyDinh { get; set; }
        public BUS_NguoiDung NguoiDung { get; set; }
        public BUS_ThongKe  ThongKe { get; set; }
        public Func<bool> KiemTraKetNoi { get; set; } 
        public BL()
        {
            var da = new DAO.DA();
            TacGia = new BUS_TacGia(da);
            TheLoai = new BUS_TheLoai(da);
            KhachHang = new BUS_KhachHang(da);
            Sach = new BUS_Sach(da);
            PhieuNhapSach = new BUS_PhieuNhapSach(da, this);
            HoaDonBanHang = new BUS_HoaDonBanHang(da);
            PhieuThuTien = new BUS_PhieuThuTien(da);
            QuyDinh = new BUS_QuyDinh(da);
            NguoiDung = new BUS_NguoiDung(da);
            ThongKe = new BUS_ThongKe(da);
            KiemTraKetNoi = da.KiemTraKetNoi;
        }
    }
}
