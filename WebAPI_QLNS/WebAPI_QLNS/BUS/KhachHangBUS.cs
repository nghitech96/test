using AutoMapper;
using System.Collections.Generic;
using WebAPI_QLNS.DAO;
using WebAPI_QLNS.DTO;
using WebAPI_QLNS.Models;

namespace WebAPI_QLNS.BUS
{
    public class KhachHangBUS
    {
        private Mapper _KhachHangMapper;
        private KhachHangDAO _DAL;
        public KhachHangBUS()
        {
            _DAL = new KhachHangDAO();
            var _configKhachHang = new MapperConfiguration(cfg => cfg.CreateMap<KhachHang, KhachHangModel>().ReverseMap());

            _KhachHangMapper = new Mapper(_configKhachHang);
        }
        public List<KhachHangModel> LayDanhSachKhachHang()
        {
            List<KhachHang> KhachHangDB = _DAL.LayDanhSachKhachHang();
            List<KhachHangModel> KhachHangModels = _KhachHangMapper.Map<List<KhachHang>, List<KhachHangModel>>(KhachHangDB);

            return KhachHangModels;
        }
        public KhachHangModel LayThongTinKhachHang(int KhachHangId)
        {
            var KhachHangDB = _DAL.LayThongTinKhachHang(KhachHangId);
            KhachHangModel KhachHangModel = _KhachHangMapper.Map<KhachHang, KhachHangModel>(KhachHangDB);
            return KhachHangModel;
        }
        public Response XoaKhachHang(int KhachHangId)
        {
            return _DAL.XoaKhachHang(KhachHangId);
        }
        public Response Timkiem(KhachHangModel KhachHangModel)
        {
            KhachHang KhachHangEntity = _KhachHangMapper.Map<KhachHangModel, KhachHang>(KhachHangModel);
            return _DAL.TimKiemn(KhachHangEntity);
        }
        public Response ThemKhachHang(KhachHangModel KhachHangModel)
        {
            KhachHang KhachHangEntity = _KhachHangMapper.Map<KhachHangModel, KhachHang>(KhachHangModel);
            return _DAL.ThemKhachHang(KhachHangEntity);
        }
        public Response CapNhatKhachHang(KhachHangModel KhachHangModel)
        {
            KhachHang KhachHangEntity = _KhachHangMapper.Map<KhachHangModel, KhachHang>(KhachHangModel);
            return _DAL.CapNhatKhachHang(KhachHangEntity);

        }
    }
}
