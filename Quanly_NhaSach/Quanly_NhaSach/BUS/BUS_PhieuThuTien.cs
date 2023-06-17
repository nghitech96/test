using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quanly_NhaSach.DAO;

namespace Quanly_NhaSach.BUS
{
    internal class BUS_PhieuThuTien
    {
        public DA DA { get; set; }
        public BUS_PhieuThuTien(DA da)
        {
            DA = da;
        }
        public List<PhieuThuTien> LayDuLieu()
        {
            return DA.PhieuThuTien.LayDuLieu();
        }
        public bool Them(PhieuThuTien tg)
        {
            return DA.PhieuThuTien.Them(tg);
        }
        public bool Sua(PhieuThuTien tg, string Id)
        {
            return DA.PhieuThuTien.Sua(tg, Id);
        }
        public bool Xoa(PhieuThuTien tg)
        {
            return DA.PhieuThuTien.Xoa(tg);
        }
    }
}
