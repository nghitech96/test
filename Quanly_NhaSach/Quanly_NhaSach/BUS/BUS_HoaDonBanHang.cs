using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quanly_NhaSach.DAO;

namespace Quanly_NhaSach.BUS
{
    internal class BUS_HoaDonBanHang
    {
        public DA DA { get; set; }
        public BUS_HoaDonBanHang(DA da)
        {
            DA = da;
        }
        public List<HoaDonBanHang> LayDuLieu()
        {
            return DA.HoaDonBanHang.LayDuLieu();
        }
        public bool Them(HoaDonBanHang tg)
        {
            return DA.HoaDonBanHang.Them(tg);
        }
        public bool Sua(HoaDonBanHang tg, string Id)
        {
            return DA.HoaDonBanHang.Sua(tg, Id);
        }
        public bool Xoa(HoaDonBanHang tg)
        {
            return DA.HoaDonBanHang.Xoa(tg);
        }

    }
}
