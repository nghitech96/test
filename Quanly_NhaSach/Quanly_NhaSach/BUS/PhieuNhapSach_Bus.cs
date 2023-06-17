using AutoMapper;
using Newtonsoft.Json;
using Quanly_NhaSach.DTO;
using Quanly_NhaSach.Helpers;
using Quanly_NhaSach.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPI_QLNS.Models;

namespace Quanly_NhaSach.BUS
{
    internal class PhieuNhapSach_Bus
    {
        private Mapper _NhanVienMapper;

        public PhieuNhapSach_Bus()
        {

            var _configNhanVIen = new MapperConfiguration(cfg => cfg.CreateMap<PhieuNhapSach, PhieuNhapSachModel >().ReverseMap());
            _NhanVienMapper = new Mapper(_configNhanVIen);
        }
        public void Map(PhieuNhapSach phieuNhap, ref PhieuNhapSachModel phieuNhapModel)
        {
            phieuNhapModel = _NhanVienMapper.Map<PhieuNhapSach, PhieuNhapSachModel>(phieuNhap);

            //return PhieuThuTienModels;
        }
        public void Map(PhieuNhapSachModel phieuNhapModel, ref PhieuNhapSach phieuNhap)
        {
            phieuNhap = _NhanVienMapper.Map<PhieuNhapSachModel, PhieuNhapSach>(phieuNhapModel);

            //return PhieuThuTienModels;
        }

        public async Task<List<PhieuNhapSach>> LayDanhsachPhieuNhapSach()
        {
            string url = $"/api/PhieuNhapSach";

            var lstData = new List<PhieuNhapSach>();
            ResponseModel response = await HttpHelper.Get<ResponseModel>(url);

            if (response == null)
            {
                return lstData;
            }

            if (response.Count > 0)
            {
                lstData = JsonConvert.DeserializeObject<List<PhieuNhapSach>>(response.data.ToString());
            }
            return lstData;
        }

        public async Task<PhieuNhapSach> LayThongtinPhieuNhapSach(int PhieuNhapSachId)
        {
            string url = $"/api/PhieuNhapSach/{PhieuNhapSachId}";

            var lstData = new PhieuNhapSach();
            ResponseModel response = await HttpHelper.Get<ResponseModel>(url);

            if (response == null)
            {
                return lstData;
            }

            if (response.Count > 0)
            {
                lstData = JsonConvert.DeserializeObject<PhieuNhapSach>(response.data.ToString());
            }
            return lstData;
        }
        public async Task<ResponseModel> XoaPhieuNhapSach(string PhieuNhapSachId)
        {
            string url = $"/api/PhieuNhapSach/{PhieuNhapSachId}";

            var response = new ResponseModel();
            response = await HttpHelper.Delete(url);

            return response;
        }
        public async Task<ResponseModel> ThemPhieuNhapSach(PhieuNhapSachModel PhieuNhapSach)
        {
            string url = $"/api/PhieuNhapSach";

            var response = new ResponseModel();
            response = await HttpHelper.Post<PhieuNhapSachModel>(url, PhieuNhapSach);

            return response;
        }
        public async Task<ResponseModel> CapnhatPhieuNhapSach(PhieuNhapSachModel PhieuNhapSach)
        {
            string url = $"/api/PhieuNhapSach";

            var response = new ResponseModel();
            response = await HttpHelper.Put<PhieuNhapSachModel>(url, PhieuNhapSach);

            return response;
        }
    }
}
