using AutoMapper;
using System.Collections.Generic;
using WebAPI_QLNS.DAO;
using WebAPI_QLNS.DTO;
using WebAPI_QLNS.Models;

namespace WebAPI_QLNS.BUS
{
    public class VaiTroBUS
    {
        private Mapper _VaiTroMapper;
        private VaiTroDAO _DAL;
        public VaiTroBUS()
        {
            _DAL = new VaiTroDAO();
            var _configVaiTro = new MapperConfiguration(cfg => cfg.CreateMap<VaiTro, VaiTroModel>().ReverseMap());

            _VaiTroMapper = new Mapper(_configVaiTro);
        }
        public List<VaiTroModel> LayDanhSachVaiTro()
        {
            List<VaiTro> VaiTroDB = _DAL.LayDanhSachVaiTro();
            List<VaiTroModel> VaiTroModels = _VaiTroMapper.Map<List<VaiTro>, List<VaiTroModel>>(VaiTroDB);

            return VaiTroModels;
        }
        public VaiTroModel LayThongTinVaiTro(int VaiTroId)
        {
            var VaiTroDB = _DAL.LayThongTinVaiTro(VaiTroId);
            VaiTroModel VaiTroModel = _VaiTroMapper.Map<VaiTro, VaiTroModel>(VaiTroDB);
            return VaiTroModel;
        }
        public Response XoaVaiTro(int VaiTroId)
        {
            return _DAL.XoaVaiTro(VaiTroId);
        }
        public Response ThemVaiTro(VaiTroModel VaiTroModel)
        {
            VaiTro VaiTroEntity = _VaiTroMapper.Map<VaiTroModel, VaiTro>(VaiTroModel);
            return _DAL.ThemVaiTro(VaiTroEntity);
        }
        public Response CapNhatVaiTro(VaiTroModel VaiTroModel)
        {
            VaiTro VaiTroEntity = _VaiTroMapper.Map<VaiTroModel, VaiTro>(VaiTroModel);
            return _DAL.CapNhatVaiTro(VaiTroEntity);

        }

    }
}
