using AutoMapper;
using System.Collections.Generic;
using WebAPI_QLNS.DAO;
using WebAPI_QLNS.DTO;
using WebAPI_QLNS.Models;

namespace WebAPI_QLNS.BUS
{
    public class SachBUS
    {
        private Mapper _SachMapper;
        private SachDAO _DAL;
        public SachBUS()
        {
            _DAL = new SachDAO();
            var _configSach = new MapperConfiguration(cfg => cfg.CreateMap<Sach, SachModel>().ReverseMap());

            _SachMapper = new Mapper(_configSach);
        }
        public List<SachModel> LayDanhSachSach()
        {
            List<Sach> SachDB = _DAL.LayDanhSachSach();
            List<SachModel> SachModels = _SachMapper.Map<List<Sach>, List<SachModel>>(SachDB);

            return SachModels;
        }
        public SachModel LayThongTinSach(int SachId)
        {
            var SachDB = _DAL.LayThongTinSach(SachId);
            SachModel SachModel = _SachMapper.Map<Sach, SachModel>(SachDB);
            return SachModel;
        }
        public Response XoaSach(int SachId)
        {
            return _DAL.XoaSach(SachId);
        }
        public Response ThemSach(SachModel SachModel)
        {
            Sach SachEntity = _SachMapper.Map<SachModel, Sach>(SachModel);
            return _DAL.ThemSach(SachEntity);
        }
        public Response CapNhatSach(SachModel SachModel)
        {
            Sach SachEntity = _SachMapper.Map<SachModel, Sach>(SachModel);
            return _DAL.CapNhatSach(SachEntity);

        }
        public List<Sach> TimkiemSach(ThongtinTimSachModel ThongtinModel)
        {
            //Sach SachEntity = _SachMapper.Map<SachModel, Sach>(ThongtinModel);
            return _DAL.TimkiemSach(ThongtinModel);

        }
    }
}
