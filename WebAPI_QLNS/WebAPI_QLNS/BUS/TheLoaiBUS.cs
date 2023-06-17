using AutoMapper;
using System.Collections.Generic;
using WebAPI_QLNS.DAO;
using WebAPI_QLNS.DTO;
using WebAPI_QLNS.Models;

namespace WebAPI_QLNS.BUS
{
    public class TheLoaiBUS
    {
        private Mapper _TheLoaiMapper;
        private TheLoaiDAO _DAL;
        public TheLoaiBUS()
        {
            _DAL = new TheLoaiDAO();
            var _configTheLoai = new MapperConfiguration(cfg => cfg.CreateMap<TheLoai, TheLoaiModel>().ReverseMap());

            _TheLoaiMapper = new Mapper(_configTheLoai);
        }
        public List<TheLoaiModel> LayDanhSachTheLoai()
        {
            List<TheLoai> TheLoaiDB = _DAL.LayDanhSachTheLoai();
            List<TheLoaiModel> TheLoaiModels = _TheLoaiMapper.Map<List<TheLoai>, List<TheLoaiModel>>(TheLoaiDB);

            return TheLoaiModels;
        }
        public TheLoaiModel LayThongTinTheLoai(int TheLoaiId)
        {
            var TheLoaiDB = _DAL.LayThongTinTheLoai(TheLoaiId);
            TheLoaiModel TheLoaiModel = _TheLoaiMapper.Map<TheLoai, TheLoaiModel>(TheLoaiDB);
            return TheLoaiModel;
        }
        public Response XoaTheLoai(int TheLoaiId)
        {
            return _DAL.XoaTheLoai(TheLoaiId);
        }
        public Response ThemTheLoai(TheLoaiModel TheLoaiModel)
        {
            TheLoai TheLoaiEntity = _TheLoaiMapper.Map<TheLoaiModel, TheLoai>(TheLoaiModel);
            return _DAL.ThemTheLoai(TheLoaiEntity);
        }
        public Response CapNhatTheLoai(TheLoaiModel TheLoaiModel)
        {
            TheLoai TheLoaiEntity = _TheLoaiMapper.Map<TheLoaiModel, TheLoai>(TheLoaiModel);
            return _DAL.CapNhatTheLoai(TheLoaiEntity);

        }
    }
}
