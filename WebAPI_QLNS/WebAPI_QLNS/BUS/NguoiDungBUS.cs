using AutoMapper;
using System.Collections.Generic;
using WebAPI_QLNS.DAO;
using WebAPI_QLNS.DTO;
using WebAPI_QLNS.Models;

namespace WebAPI_QLNS.BUS
{
    public class NguoiDungBUS
    {
        private Mapper _NguoiDungMapper;
        private Mapper _NguoiDungMapper2;
        private NguoiDungDAO _DAL;
        public NguoiDungBUS()
        {
            _DAL = new NguoiDungDAO();
            var _configNguoiDung = new MapperConfiguration(cfg => cfg.CreateMap<NguoiDung, NguoiDungModel>().ReverseMap());
            var _configNguoiDung2 = new MapperConfiguration(cfg => cfg.CreateMap<NguoiDungDangnhap, NguoiDungDangnhapModel>().ReverseMap());

            _NguoiDungMapper = new Mapper(_configNguoiDung);
            _NguoiDungMapper2 = new Mapper(_configNguoiDung2);
        }
        public List<NguoiDungModel> LayDanhSachNguoiDung()
        {
            List<NguoiDung> NguoiDungDB = _DAL.LayDanhSachNguoiDung();
            List<NguoiDungModel> NguoiDungModels = _NguoiDungMapper.Map<List<NguoiDung>, List<NguoiDungModel>>(NguoiDungDB);


            return NguoiDungModels;
        }
        public List<NguoiDungDangnhapModel> LayDanhSachNguoiDungDangnhap()
        {
            List<NguoiDungDangnhap> NguoiDungDB = _DAL.LayDanhsachNguoiDungDangNhap();
            List<NguoiDungDangnhapModel> NguoiDungModels = _NguoiDungMapper2.Map<List<NguoiDungDangnhap>, List<NguoiDungDangnhapModel>>(NguoiDungDB);


            return NguoiDungModels;
        }
        public NguoiDungModel LayThongTinNguoiDung(int NguoiDungId)
        {
            var NguoiDungDB = _DAL.LayThongTinNguoiDung(NguoiDungId);
            NguoiDungModel NguoiDungModel = _NguoiDungMapper.Map<NguoiDung, NguoiDungModel>(NguoiDungDB);
            return NguoiDungModel;
        }
        
        public NguoiDungDangnhapModel LayThongTinNguoiDungDangNhap(int NguoiDungId)
        {
            var NguoiDungDB = _DAL.LayThongTinNguoiDungDangNhap(NguoiDungId);
            NguoiDungDangnhapModel NguoiDungModel = _NguoiDungMapper2.Map<NguoiDungDangnhap, NguoiDungDangnhapModel>(NguoiDungDB);
            return NguoiDungModel;
        }
        public Response XoaNguoiDung(int NguoiDungId)
        {
            return _DAL.XoaNguoiDung(NguoiDungId);
        }
        public Response TimNguoiDung(NguoiDungDangnhapModel NguoiDungModel)
        {
            NguoiDungDangnhap NguoiDungEntity = _NguoiDungMapper2.Map<NguoiDungDangnhapModel, NguoiDungDangnhap>(NguoiDungModel);
            return _DAL.TimNguoiDung(NguoiDungEntity);
        }
        public Response ThemNguoiDung(NguoiDungModel NguoiDungModel)
        {
            NguoiDung NguoiDungEntity = _NguoiDungMapper.Map<NguoiDungModel, NguoiDung>(NguoiDungModel);
            return _DAL.ThemNguoiDung(NguoiDungEntity);
        }
        public Response CapNhatNguoiDung(NguoiDungModel NguoiDungModel)
        {
            NguoiDung NguoiDungEntity = _NguoiDungMapper.Map<NguoiDungModel, NguoiDung>(NguoiDungModel);
            return _DAL.CapNhatNguoiDung(NguoiDungEntity);

        }
    }
}
