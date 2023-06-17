using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quanly_NhaSach.DAO;

namespace Quanly_NhaSach.BUS
{
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
        public List<PhieuCongNo> DS { get; set; }
        public long DauKy { get; set; }
        public long Tang { get; set; }
        public long Giam { get; set; }
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
    internal class BUS_ThongKe
    {
        public DA DA { get; set; }
        public BUS_ThongKe(DA da)
        {
            DA = da;
        }

        public ThongKeCongNoTrongKy BaoCaoCongNo(int thang, int nam, int idKhachHang, List<HoaDonBanHang> dsHD, List<PhieuThuTien> dsPT)
        {
            var tk = new ThongKeCongNoTrongKy();
                   

            var dsHDTheoKH = dsHD.Where(hd => (hd.Ngay.Year < nam || (hd.Ngay.Month <= thang && hd.Ngay.Year == nam)) && hd.IdKhachHang == idKhachHang).ToList();
            var dsPTTheoKH = dsPT.Where(hd => (hd.Ngay.Year < nam || (hd.Ngay.Month <= thang && hd.Ngay.Year == nam)) && hd.IdKhachHang == idKhachHang).ToList();

            List<PhieuCongNo> dsPCN = new List<PhieuCongNo>();
            long NoDauKy = 0;
            long tongThu = 0;
            long tongNo = 0;
            foreach (var p in dsHDTheoKH)
            {
                if (p.Ngay.Month == thang && p.Ngay.Year == nam)
                {
                    dsPCN.Add(new PhieuCongNo
                    {
                        Id = p.Id,
                        Ngay = p.Ngay,
                        SoLuong = p.ThanhTien,
                        Loai = "Bán Hàng"
                    });
                    tongNo += p.ThanhTien;
                }
                else
                {
                    NoDauKy += p.ThanhTien;
                }
            }
            foreach (var p in dsPTTheoKH)
            {
                if (p.Ngay.Month == thang && p.Ngay.Year == nam)
                {
                    dsPCN.Add(new PhieuCongNo
                    {
                        Id = p.Id,
                        Ngay = p.Ngay,
                        SoLuong = p.Tien * -1,
                        Loai = "Thu"
                    });
                    tongThu += p.Tien;
                }
                else
                {
                    NoDauKy -= p.Tien;
                }
            }
            dsPCN = dsPCN.OrderBy(p => p.Ngay).ToList();
            if (dsPCN.Count > 0)
            {
                var p = dsPCN[0];
                p.No = NoDauKy + p.SoLuong;
                for (int i = 1; i < dsPCN.Count; i++)
                {
                    p = dsPCN[i];
                    p.No = dsPCN[i - 1].No + p.SoLuong;
                }
            }

            tk.DauKy = NoDauKy;
            tk.Tang = tongNo;
            tk.Giam = tongThu;
            tk.CuoiKy = NoDauKy + tongNo - tongThu;
            tk.DS = dsPCN;
            return tk;
        }

        public ThongKeNXTTrongKy BaoCaoNXT(int thang, int nam, int idSach, List<HoaDonBanHang> dsHD, List<PhieuNhapSach> dsPN)
        {
            var tk = new ThongKeNXTTrongKy();
            var dsHDTheoSach = dsHD.Where(hd => (hd.Ngay.Year < nam || (hd.Ngay.Month <= thang && hd.Ngay.Year == nam)) && hd.ChiTietHoaDons.Any(ct => ct.IdSach == idSach)).ToList();
            var dsPNTheoSach = dsPN.Where(hd => (hd.Ngay.Year < nam || (hd.Ngay.Month <= thang && hd.Ngay.Year == nam)) && hd.ChiTietNhapSaches.Any(ct => ct.IdSach == idSach)).ToList();

            List<PhieuNhapXuat> dsPNX = new List<PhieuNhapXuat>();
            long tonDauThang = 0;
            long tongNhap = 0;
            long tongXuat = 0;
            foreach (var p in dsHDTheoSach)
            {
                var soLuongSach = p.ChiTietHoaDons.First(ct => ct.IdSach == idSach).SoLuong;
                if (p.Ngay.Month == thang && p.Ngay.Year == nam)
                {
                    dsPNX.Add(new PhieuNhapXuat
                    {
                        Id = p.Id,
                        Ngay = p.Ngay,
                        SoLuong = soLuongSach * -1,
                        Loai = "Xuất"
                    });
                    tongXuat += soLuongSach;
                }
                else
                {
                    tonDauThang -= soLuongSach;
                }
            }
            foreach (var p in dsPNTheoSach)
            {
                var soLuongSach = p.ChiTietNhapSaches.First(ct => ct.IdSach == idSach).SoLuong;
                if (p.Ngay.Month == thang && p.Ngay.Year == nam)
                {
                    dsPNX.Add(new PhieuNhapXuat
                    {
                        Id = p.Id,
                        Ngay = p.Ngay,
                        SoLuong = soLuongSach,
                        Loai = "Nhập"
                    });
                    tongNhap += soLuongSach;
                }
                else
                {
                    tonDauThang += soLuongSach;
                }
            }
            dsPNX = dsPNX.OrderBy(p => p.Ngay).ToList();
            if (dsPNX.Count > 0)
            {
                var p = dsPNX[0];
                p.Ton = tonDauThang + p.SoLuong;
                for (int i = 1; i < dsPNX.Count; i++)
                {
                    p = dsPNX[i];
                    p.Ton = dsPNX[i - 1].Ton + p.SoLuong;
                }
            }
            tk.DauKy = tonDauThang;
            tk.Tang = tongNhap;
            tk.Giam = tongXuat;
            tk.CuoiKy = tk.DauKy + tk.Tang - tk.Giam;
            tk.DS = dsPNX ;
            return tk;
        }

    }
}
