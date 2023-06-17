using AutoMapper;
using AutoMapper.Configuration.Conventions;
using System.Collections.Generic;
using System.Security.Principal;
using WebAPI_QLNS.DAO;
using WebAPI_QLNS.DTO;
using WebAPI_QLNS.Models;

namespace WebAPI_QLNS.BUS
{
    public class NhanVienBUS
    {
        private Mapper _NhanVienMapper;
        private NhanVienDAO _DAL;
        public NhanVienBUS()
        {
            _DAL=new NhanVienDAO();
            var _configNhanvien = new MapperConfiguration(cfg => cfg.CreateMap<NhanVien, NhanVienModel>().ReverseMap());

            _NhanVienMapper = new Mapper(_configNhanvien);
        }
        public List<NhanVienModel> LayDanhSachNhanVien()
        {
            List<NhanVien> NhanVienDB = _DAL.LayDanhSachNhanVien();
            List<NhanVienModel> nhanVienModels = _NhanVienMapper.Map<List<NhanVien>, List<NhanVienModel>>(NhanVienDB);

            return nhanVienModels;
        }
        public NhanVienModel LayThongTinNhanVien(int NhanVienId)
        {
            var NhanVienDB = _DAL.LayThongTinNhanVien(NhanVienId);
            NhanVienModel nhanVienModel = _NhanVienMapper.Map<NhanVien, NhanVienModel>(NhanVienDB);
            return nhanVienModel;
        }
        public Response XoaNhanVien(int NhanVienId)
        {
            return _DAL.XoaNhanVien(NhanVienId);
        }
        public Response TimNhanVien(NhanVienModel NhanVienModel)
        {
            NhanVien NhanVienEntity = _NhanVienMapper.Map<NhanVienModel, NhanVien>(NhanVienModel);
            return _DAL.TimNhanVien(NhanVienEntity);
        }
        public Response ThemNhanVien(NhanVienModel NhanVienModel)
        {
            NhanVien NhanVienEntity = _NhanVienMapper.Map<NhanVienModel, NhanVien>(NhanVienModel);
            return _DAL.ThemNhanVien(NhanVienEntity);
        }
        public Response CapNhatNhanVien(NhanVienModel NhanVienModel)
        {
            NhanVien NhanVienEntity = _NhanVienMapper.Map<NhanVienModel, NhanVien>(NhanVienModel);
            return _DAL.CapNhatNhanVien(NhanVienEntity);

        }
       

    }
}
