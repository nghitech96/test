using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quanly_NhaSach.DAO;

namespace Quanly_NhaSach.BUS
{
    internal class BUS_TacGia
    {
        public DA DA { get; set; }
        public BUS_TacGia(DA da)
        {
            DA = da;
        }
        public List<TacGia> LayDuLieu()
        {
            return DA.TacGia.LayDuLieu();
        }
        public bool Them(TacGia tg)
        {
            return DA.TacGia.Them(tg);
        }
        public bool Sua(TacGia tg)
        {
            return DA.TacGia.Sua(tg);
        }
        public bool Xoa(TacGia tg)
        {
            return DA.TacGia.Xoa(tg);
        }
    }
}
