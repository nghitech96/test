using Quanly_NhaSach.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanly_NhaSach.BUS
{
    public class BUS_Sach
    {
        public DA DA { get; set; }
        public BUS_Sach(DA da)
        {
            DA = da;
        }
        public List<Sach> LayDuLieu()
        {
            return DA.Sach.LayDuLieu();
        }
        public bool Them(Sach tg)
        {
            return DA.Sach.Them(tg);
        }
        public bool Sua(Sach tg)
        {
            return DA.Sach.Sua(tg);
        }
        public bool Xoa(Sach tg)
        {
            return DA.Sach.Xoa(tg);
        }
        public Dictionary<int, long> DanhSachTon(DateTime ngay)
        {
            var dsPhieuNhap = DA.PhieuNhapSach.LayDuLieu();
            var dsHoaDon = DA.HoaDonBanHang.LayDuLieu();
            var dsSach = DA.Sach.LayDuLieu();
            dsPhieuNhap = dsPhieuNhap.Where(p => p.Ngay <= ngay).ToList();
            dsHoaDon = dsHoaDon.Where(p=> p.Ngay <= ngay).ToList();

            var dic = new Dictionary<int, long>();
            foreach (var sach in dsSach)
            {
                dic.Add(sach.Id, 0);
            }
            foreach (var pn in dsPhieuNhap)
            {
                foreach (var ct in pn.ChiTietNhapSaches)
                {
                    dic[ct.IdSach] += ct.SoLuong;
                }
            }

            foreach (var hd in dsHoaDon)
            {
                foreach (var ct in hd.ChiTietHoaDons)
                {
                    dic[ct.IdSach] -= ct.SoLuong;
                }
            }

            return dic;
        }
    }
}
