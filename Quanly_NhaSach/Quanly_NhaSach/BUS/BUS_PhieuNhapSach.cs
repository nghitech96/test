using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quanly_NhaSach.DAO;

namespace Quanly_NhaSach.BUS
{
    internal class BUS_PhieuNhapSach
    {
        public DA DA { get; set; }
        public BL BL { get; set; }
        private List<QuyDinh> _dsQuyDinh;
        public BUS_PhieuNhapSach(DA da, BL bl)
        {
            DA = da;
            BL = bl;
            _dsQuyDinh = DA.QuyDinh.LayDuLieu();
        }
        public List<PhieuNhapSach> LayDuLieu()
        {
            return DA.PhieuNhapSach.LayDuLieu();
        }
        public bool Them(PhieuNhapSach tg)
        {
            return DA.PhieuNhapSach.Them(tg);
        }
        public bool Sua(PhieuNhapSach tg, string Id)
        {
            return DA.PhieuNhapSach.Sua(tg, Id);
        }
        public bool Xoa(PhieuNhapSach tg)
        {
            return DA.PhieuNhapSach.Xoa(tg);
        }     
        public bool KiemTraSoLuongNhapToiThieu(long sl)
        {          
            var slMin = _dsQuyDinh.Find(qd => qd.Id == 1).GiaTri.ToInt64();
            return sl >= slMin;
        }
    }
}
