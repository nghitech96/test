using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using WebAPI_QLNS.DTO;

namespace WebAPI_QLNS.DAO
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

        public List<PhieuCongNo> DS { get; set; }
        public string TenKhachhang { get; set; }
        public long IdKhachHang { get; set; }

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
        public long Giam { 
            get { return _giam; }
            set { 
                _giam = value;
                _phatsinh = _tang - _giam;
            }
        }
        public long Phatsinh
        {
            get { return _phatsinh; }
            set { _phatsinh=value; }
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
    public class ThongkeBaoCao_DAO
    {

        public myDbContext myDB;
        public ThongkeBaoCao_DAO()
        {
            myDB = new myDbContext();
        }
        public List<ThongKeCongNoTrongKy> BaoCaoCongNo(int thang, int nam, int idKhachHang)
        {
            
            var tkds = new List<ThongKeCongNoTrongKy>();


            var dsHD =myDB.HoaDonBanHang
                .Where(hd => (
               (hd.Ngay.Year < nam || (hd.Ngay.Month <= thang && hd.Ngay.Year == nam)) 
                )).ToList();
            var dsPT =myDB.PhieuThuTien
                 .Where(hd => (
                 (hd.Ngay.Year < nam || (hd.Ngay.Month <= thang && hd.Ngay.Year == nam))
                 )).ToList();

            var dsKh1 = (from p in dsHD
                        
                      group p by p.IdKhachHang into g
                      select new KhachHang {Id = g.Key}
                      )
                    .ToList();
            var dsKh = (from p in dsKh1
                        join k in myDB.KhachHang on p.Id equals k.Id
                        select new KhachHang
                        {
                            Id = k.Id,
                            Ten = k.Ten
                        })
                        .ToList();
            //var dsCNKH = List<>



            List < PhieuCongNo > dsPCN = new List<PhieuCongNo>();
            var dsHDTheoKH = new List<HoaDonBanHang>();
            var dsPTTheoKH = new List<PhieuThuTien>();
            long NoDauKy = 0;
            long tongThu = 0;
            long tongNo = 0;
            var tk = new ThongKeCongNoTrongKy();
            foreach (var kh in dsKh)
            {

                NoDauKy = 0;
                tongThu = 0;
                tongNo = 0;
                dsHDTheoKH = dsHD.Where(x => x.IdKhachHang == kh.Id).ToList();
                
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
                dsPTTheoKH = dsPT.Where(x => x.IdKhachHang == kh.Id).ToList();
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
                tk = new ThongKeCongNoTrongKy
                {
                    IdKhachHang=kh.Id,
                    DauKy=NoDauKy,
                    Tang=tongNo,
                    Giam =tongThu,
                    CuoiKy = NoDauKy + tongNo - tongThu,
                    DS = dsPCN,
                    TenKhachhang=kh.Ten
            };
                tkds.Add(tk);
                //tk.DauKy = NoDauKy;
                //tk.Tang = tongNo;
                //tk.Giam = tongThu;
                //tk.CuoiKy = NoDauKy + tongNo - tongThu;
                //tk.DS = dsPCN;
            }
            return tkds;
        }
        public ThongKeNXTTrongKy BaoCaoNhapXuat(int thang, int nam, int idSach)
        {
            var tk = new ThongKeNXTTrongKy();
            var dsHDTheoSach = myDB.HoaDonBanHang
                .Where(hd => (hd.Ngay.Year < nam || (hd.Ngay.Month <= thang && hd.Ngay.Year == nam)) && hd.ChiTietHoaDons.Any(ct => ct.IdSach == idSach)).ToList();
            var dsPNTheoSach =myDB.PhieuNhapSach
                .Where(hd => (hd.Ngay.Year < nam || (hd.Ngay.Month <= thang && hd.Ngay.Year == nam)) && hd.ChiTietNhapSaches.Any(ct => ct.IdSach == idSach)).ToList();

            List<PhieuNhapXuat> dsPNX = new List<PhieuNhapXuat>();
            long tonDauThang = 0;
            long tongNhap = 0;
            long tongXuat = 0;
            foreach (var p in dsHDTheoSach)
            {
                var soLuongSach = myDB.ChiTietHoaDon.FirstOrDefault(ct =>(ct.IdHoaDon ==p.Id && ct.IdSach == idSach )).SoLuong;
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
                var soLuongSach =myDB.ChiTietNhapSach.FirstOrDefault(ct => (ct.IdPhieuNhap == p.Id && ct.IdSach == idSach)).SoLuong;
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
            tk.DS = dsPNX;
            return tk;
        }
        public void TinhSoluongSachTon(int IdSach)
        {
            string message;
            try
            {
                var kq1 = myDB.ChiTietNhapSach
                .Where(x => x.IdSach == IdSach)
                .ToList();

               var SoNhap =kq1 .Select(c => c.SoLuong)
                .Sum();

                var kq2 = myDB.ChiTietHoaDon
                    .Where(x => x.IdSach == IdSach)
                    .ToList();
                var SoXuat = kq2.Select(c => c.SoLuong)
                    .Sum();

                var sach = myDB.Sach.FirstOrDefault(x => x.Id == IdSach);
                sach.SoluongTon = (SoNhap - SoXuat);

                myDB.Sach.Attach(sach);
                myDB.SaveChanges();
            }
            catch (Exception ex)
            {
                message = ex.Message;
               
            }
            

        }
        public long TinhCongnoKhachHang(int IdKhachHang)
        {
            long Congno = 0;
            var kq1 = myDB.HoaDonBanHang
                .Where(x => x.IdKhachHang == IdKhachHang)
                .ToList();
            var kq2 = myDB.PhieuThuTien
               .Where(x => x.IdKhachHang == IdKhachHang)
               .ToList();

            var TienNo = kq1.Select(x => x.ThanhTien).Sum();
            var TienTra = kq2.Select(x => x.Tien).Sum();
            Congno = TienNo - TienTra;
            return Congno;
        }
        public ThongKeCongNoTrongKy BaoCaoCongNo2(int thang, int nam, int idKhachHang)
        {

            var tk = new ThongKeCongNoTrongKy();


            var dsHDTheoKH = myDB.HoaDonBanHang
                .Where(hd => (
                ((hd.Ngay.Year < nam || (hd.Ngay.Month <= thang && hd.Ngay.Year == nam)) && idKhachHang > 0 && hd.IdKhachHang == idKhachHang)
                || ((hd.Ngay.Year < nam || (hd.Ngay.Month <= thang && hd.Ngay.Year == nam)) && idKhachHang == 0)
                )).ToList();
            var dsPTTheoKH = myDB.PhieuThuTien
                 .Where(hd => (
                 ((hd.Ngay.Year < nam || (hd.Ngay.Month <= thang && hd.Ngay.Year == nam)) && idKhachHang > 0 && hd.IdKhachHang == idKhachHang)
                 || ((hd.Ngay.Year < nam || (hd.Ngay.Month <= thang && hd.Ngay.Year == nam)) && idKhachHang == 0)
                 )).ToList();

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
    }
}
