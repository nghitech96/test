using AutoMapper;
using System.Collections.Generic;
using WebAPI_QLNS.DAO;
using WebAPI_QLNS.DTO;
using WebAPI_QLNS.Models;

namespace WebAPI_QLNS.BUS
{
    public class PhieuNhapSachBUS
    {
        private Mapper _PhieuNhapSachMapper;
        private PhieuNhapSachDAO _DAL;
        public PhieuNhapSachBUS()
        {
            _DAL = new PhieuNhapSachDAO();
            var _configPhieuNhapSach = new MapperConfiguration(cfg => cfg.CreateMap<PhieuNhapSach, PhieuNhapSachModel>().ReverseMap());

            _PhieuNhapSachMapper = new Mapper(_configPhieuNhapSach);
        }
        public List<PhieuNhapSachModel> LayDanhSachPhieuNhapSach()
        {
            List<PhieuNhapSach> PhieuNhapSachDB = _DAL.LayDanhSachPhieuNhapSach();
            List<PhieuNhapSachModel> PhieuNhapSachModels = _PhieuNhapSachMapper.Map<List<PhieuNhapSach>, List<PhieuNhapSachModel>>(PhieuNhapSachDB);

            return PhieuNhapSachModels;
        }
        public PhieuNhapSachModel LayThongTinPhieuNhapSach(string PhieuNhapSachId)
        {
            var PhieuNhapSachDB = _DAL.LayThongTinPhieuNhapSach(PhieuNhapSachId);
            PhieuNhapSachModel PhieuNhapSachModel = _PhieuNhapSachMapper.Map<PhieuNhapSach, PhieuNhapSachModel>(PhieuNhapSachDB);
            return PhieuNhapSachModel;
        }
        public Response XoaPhieuNhapSach(string PhieuNhapSachId)
        {
            return _DAL.XoaPhieuNhapSach(PhieuNhapSachId);
        }
        public Response ThemPhieuNhapSach(PhieuNhapSachModel PhieuNhapSachModel)
        {
            PhieuNhapSach PhieuNhapSachEntity = _PhieuNhapSachMapper.Map<PhieuNhapSachModel, PhieuNhapSach>(PhieuNhapSachModel);
            return _DAL.ThemPhieuNhapSach(PhieuNhapSachEntity);
        }
        public Response CapNhatPhieuNhapSach(PhieuNhapSachModel PhieuNhapSachModel)
        {
            PhieuNhapSach PhieuNhapSachEntity = _PhieuNhapSachMapper.Map<PhieuNhapSachModel, PhieuNhapSach>(PhieuNhapSachModel);
            return _DAL.CapNhatPhieuNhapSach(PhieuNhapSachEntity);

        }
    }
}
