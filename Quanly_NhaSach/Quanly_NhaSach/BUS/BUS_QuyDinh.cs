using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quanly_NhaSach.DAO;

namespace Quanly_NhaSach.BUS
{
    internal class BUS_QuyDinh
    {
        public DA DA { get; set; }
        public BUS_QuyDinh(DA da)
        {
            DA = da;
        }
        public List<QuyDinh> LayDuLieu()
        {
            return DA.QuyDinh.LayDuLieu();
        }

        public QuyDinh Lay(int id)
        {
            var duLieu = DA.QuyDinh.Lay(id);
            return duLieu;
        }
        public bool Them(QuyDinh tg)
        {
            return DA.QuyDinh.Them(tg);
        }
        public bool Sua(QuyDinh tg)
        {
            return DA.QuyDinh.Sua(tg);
        }
        public bool Xoa(QuyDinh tg)
        {
            return DA.QuyDinh.Xoa(tg);
        }
        public bool CoDungQuyDinh()
        {
            var quyDinh = DA.QuyDinh.Lay(0);
            return bool.Parse(quyDinh.GiaTri);
        }
    }
}
