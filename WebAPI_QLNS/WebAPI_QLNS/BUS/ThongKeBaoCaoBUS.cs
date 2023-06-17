using System.Collections.Generic;
using WebAPI_QLNS.DAO;

namespace WebAPI_QLNS.BUS
{
    public class ThongKeBaoCaoBUS
    {
        ThongkeBaoCao_DAO tkbc = new ThongkeBaoCao_DAO();

        public List<ThongKeCongNoTrongKy> BaoCaoCongNo(int thang, int nam, int idKhachHang)
        {
            return tkbc.BaoCaoCongNo(thang,nam, idKhachHang);
        }
        public ThongKeNXTTrongKy BaoCaoNhapXuat(int thang, int nam, int idSach)
        {
            return tkbc.BaoCaoNhapXuat(thang,nam,idSach);   
        }
    }
}
