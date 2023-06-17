using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quanly_NhaSach.DAO;

namespace Quanly_NhaSach.BUS
{
    internal class BUS_TheLoai
    {
        public DA DA { get; set; }
        public BUS_TheLoai(DA da)
        {
            DA = da;
        }
        public List<TheLoai> LayDuLieu()
        {
            return DA.TheLoai.LayDuLieu();
        }
        public bool Them(TheLoai tg)
        {
            return DA.TheLoai.Them(tg);
        }
        public bool Sua(TheLoai tg)
        {
            return DA.TheLoai.Sua(tg);
        }
        public bool Xoa(TheLoai tg)
        {
            return DA.TheLoai.Xoa(tg);
        }
    }
}
