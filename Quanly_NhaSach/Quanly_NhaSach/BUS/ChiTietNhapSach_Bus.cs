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
    internal class ChiTietNhapSach_Bus
    {

        private Mapper _NhanVienMapper;

        public ChiTietNhapSach_Bus()
        {

            var _configNhanVIen = new MapperConfiguration(cfg => cfg.CreateMap<ChiTietNhapSach, ChiTietNhapSachModel>().ReverseMap());
            _NhanVienMapper = new Mapper(_configNhanVIen);
        }
        public void Map(ChiTietNhapSach chitietPhieuNhap, ref ChiTietNhapSachModel chitietPhieuNhapModel)
        {
            chitietPhieuNhapModel = _NhanVienMapper.Map<ChiTietNhapSach, ChiTietNhapSachModel>(chitietPhieuNhap);

            //return PhieuThuTienModels;
        }
        public void Map(ChiTietNhapSachModel chitietPhieuNhapModel, ref ChiTietNhapSach chitietPhieuNhap)
        {
            chitietPhieuNhap = _NhanVienMapper.Map<ChiTietNhapSachModel, ChiTietNhapSach>(chitietPhieuNhapModel);

            //return PhieuThuTienModels;
        }
        public void Map(List<ChiTietNhapSach> chitietPhieuNhap, ref List<ChiTietNhapSachModel> chitietPhieuNhapModel)
        {
            chitietPhieuNhapModel = _NhanVienMapper.Map< List<ChiTietNhapSach>,List<ChiTietNhapSachModel>>(chitietPhieuNhap);

            //return PhieuThuTienModels;
        }
        public void Map(List<ChiTietNhapSachModel> chitietPhieuNhapModel, ref List<ChiTietNhapSach> chitietPhieuNhap)
        {
            chitietPhieuNhap = _NhanVienMapper.Map< List<ChiTietNhapSachModel>, List<ChiTietNhapSach>>(chitietPhieuNhapModel);

            //return PhieuThuTienModels;
        }
        public async Task<List<ChiTietNhapSach>> LayDanhsachChiTietNhapSach()
        {
            string url = $"api/ChiTietPN";

            var lstData = new List<ChiTietNhapSach>();
            ResponseModel response = await HttpHelper.Get<ResponseModel>(url);

            if (response == null)
            {
                return lstData;
            }

            if (response.Count > 0)
            {
                lstData = JsonConvert.DeserializeObject<List<ChiTietNhapSach>>(response.data.ToString());
            }
            return lstData;
        }
        public async Task<List<ChiTietNhapSach>> LayDanhsachChiTietNhapSach(string PhieuNhapId)
        {
            string url = $"api/ChiTietPN/{PhieuNhapId}";

            var lstData = new List<ChiTietNhapSach>();
            ResponseModel response = await HttpHelper.Get<ResponseModel>(url);

            if (response == null)
            {
                return lstData;
            }

            if (response.Count > 0)
            {
                var kq = JsonConvert.DeserializeObject<List<ChiTietNhapSachModel>>(response.data.ToString());
                Map(kq, ref lstData);
            }
            return lstData;
        }
        public async Task<ChiTietNhapSach> LayThongtinChiTietNhapSach(int ChiTietNhapSachId)
        {
            string url = $"api/ChiTietPN/{ChiTietNhapSachId}";

            var lstData = new ChiTietNhapSach();
            ResponseModel response = await HttpHelper.Get<ResponseModel>(url);

            if (response.Count > 0 & response != null)
            {
                lstData = JsonConvert.DeserializeObject<ChiTietNhapSach>(response.data.ToString());
            }
            return lstData;
        }
        public async Task<ResponseModel> XoaChiTietNhapSach(int ChiTietNhapSachId)
        {
            string url = $"api/ChiTietPN/{ChiTietNhapSachId}";

            var response = new ResponseModel();
            response = await HttpHelper.Delete(url);

            return response;
        }
        public async Task<ResponseModel> XoaChiTietNhapSach(ChiTietNhapSachModel ChiTietNhapSach)
        {
            string url = $"api/ChiTietPN/Delete";

            var response = new ResponseModel();
            response = await HttpHelper.Post<ChiTietNhapSachModel>(url, ChiTietNhapSach);

            return response;
        }

        public async Task<ResponseModel> ThemChiTietNhapSach(ChiTietNhapSachModel ChiTietNhapSach)
        {
            string url = $"api/ChiTietPN";

            var response = new ResponseModel();
            response = await HttpHelper.Post<ChiTietNhapSachModel>(url, ChiTietNhapSach);

            return response;
        }
        public async Task<ResponseModel> CapnhatChiTietNhapSach(ChiTietNhapSachModel ChiTietNhapSach)
        {
            string url = $"api/ChiTietPN";

            var response = new ResponseModel();
            response = await HttpHelper.Put<ChiTietNhapSachModel>(url, ChiTietNhapSach);

            return response;
        }

    }
}
