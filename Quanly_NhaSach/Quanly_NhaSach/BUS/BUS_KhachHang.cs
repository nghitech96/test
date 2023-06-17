using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quanly_NhaSach.DAO;

namespace Quanly_NhaSach.BUS
{
    internal class BUS_KhachHang
    {
        public DA DA { get; set; }
        public BUS_KhachHang(DA da)
        {
            DA = da;
        }
        public List<KhachHang> LayDuLieu()
        {
            return DA.KhachHang.LayDuLieu();
        }
        public bool Them(KhachHang tg)
        {
            return DA.KhachHang.Them(tg);
        }
        public bool Sua(KhachHang tg)
        {
            return DA.KhachHang.Sua(tg);
        }
        public bool Xoa(KhachHang tg)
        {
            return DA.KhachHang.Xoa(tg);
        }
        public long KiemTraNo(KhachHang kh, DateTime ngay)
        {
            var no = DA.HoaDonBanHang.LayDuLieu().Where(hd=> hd.Ngay <= ngay && hd.IdKhachHang == kh.Id).Sum(hd=> hd.ThanhTien);
            var tra = DA.PhieuThuTien.LayDuLieu().Where(pt=> pt.Ngay <= ngay && pt.IdKhachHang == kh.Id).Sum(pt=> pt.Tien);

            return no - tra;
        }
    }
}
