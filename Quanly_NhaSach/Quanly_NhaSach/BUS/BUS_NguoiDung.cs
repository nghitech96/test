using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quanly_NhaSach.DAO;

namespace Quanly_NhaSach.BUS
{
    internal class BUS_NguoiDung
    {
        public DA DA { get; set; }
        public BUS_NguoiDung(DA da)
        {
            DA = da;
        }
        public List<NguoiDung> LayDuLieu()
        {
            return DA.NguoiDung.LayDuLieu();
        }
        public bool Them(NguoiDung tg)
        {
            return DA.NguoiDung.Them(tg);
        }
        public bool Sua(NguoiDung tg)
        {
            return DA.NguoiDung.Sua(tg);
        }
        public bool Xoa(NguoiDung tg)
        {
            return DA.NguoiDung.Xoa(tg);
        }
        public NguoiDung KiemTraDangNHap(string taiKhoan, string matKhau)
        {
            matKhau = Ext.CreateMD5(matKhau);
            var nd = DA.NguoiDung.Tim(taiKhoan);
            if(nd!=null && nd.MatKhau.Equals(matKhau))
            {
                return nd;
            }
            return null;
        }
    }
}
