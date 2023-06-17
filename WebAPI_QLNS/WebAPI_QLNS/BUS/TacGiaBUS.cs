using System.Collections.Generic;
using System.Linq;
using System;
using WebAPI_QLNS.DTO;
using AutoMapper;
using WebAPI_QLNS.DAO;
using WebAPI_QLNS.Models;

namespace WebAPI_QLNS.BUS
{
    public class TacGiaBUS
    {
        private Mapper _TacGiaMapper;
        private TacGiaDAO _DAL;
        public TacGiaBUS()
        {
            _DAL = new TacGiaDAO();
            var _configTacGia = new MapperConfiguration(cfg => cfg.CreateMap<TacGia, TacGiaModel>().ReverseMap());

            _TacGiaMapper = new Mapper(_configTacGia);
        }
        public List<TacGiaModel> LayDanhSachTacGia()
        {
            List<TacGia> TacGiaDB = _DAL.LayDanhSachTacGia();
            List<TacGiaModel> TacGiaModels = _TacGiaMapper.Map<List<TacGia>, List<TacGiaModel>>(TacGiaDB);

            return TacGiaModels;
        }
        public TacGiaModel LayThongTinTacGia(int TacGiaId)
        {
            var TacGiaDB = _DAL.LayThongTinTacGia(TacGiaId);
            TacGiaModel TacGiaModel = _TacGiaMapper.Map<TacGia, TacGiaModel>(TacGiaDB);
            return TacGiaModel;
        }
        public Response XoaTacGia(int TacGiaId)
        {
            return _DAL.XoaTacGia(TacGiaId);
        }
        public Response ThemTacGia(TacGiaModel TacGiaModel)
        {
            TacGia TacGiaEntity = _TacGiaMapper.Map<TacGiaModel, TacGia>(TacGiaModel);
            return _DAL.ThemTacGia(TacGiaEntity);
        }
        public Response CapNhatTacGia(TacGiaModel TacGiaModel)
        {
            TacGia TacGiaEntity = _TacGiaMapper.Map<TacGiaModel, TacGia>(TacGiaModel);
            return _DAL.CapNhatTacGia(TacGiaEntity);

        }
    }
}
