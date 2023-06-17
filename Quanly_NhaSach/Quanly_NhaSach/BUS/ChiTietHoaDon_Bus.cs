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

    internal class ChiTietHoaDon_Bus
    {
        private Mapper _ChiTietHoaDonMapper;

        public ChiTietHoaDon_Bus()
        {

            var _configChiTietHoaDon = new MapperConfiguration(cfg => cfg.CreateMap<ChiTietHoaDon, ChiTietHoaDonModel>().ReverseMap());
            _ChiTietHoaDonMapper = new Mapper(_configChiTietHoaDon);
        }
        public void Map(ChiTietHoaDon chiTietHoaDon, ref ChiTietHoaDonModel chiTietHoaDonModel)
        {
            chiTietHoaDonModel = _ChiTietHoaDonMapper.Map<ChiTietHoaDon, ChiTietHoaDonModel>(chiTietHoaDon);

            //return PhieuThuTienModels;
        }
        public void Map(ChiTietHoaDonModel chiTietHoaDonModel, ref ChiTietHoaDon chiTietHoaDon)
        {
            chiTietHoaDon = _ChiTietHoaDonMapper.Map<ChiTietHoaDonModel, ChiTietHoaDon>(chiTietHoaDonModel);

            //return PhieuThuTienModels;
        }
        public void Map(List<ChiTietHoaDon> chiTietHoaDon, ref List<ChiTietHoaDonModel> chiTietHoaDonModel)
        {
            chiTietHoaDonModel = _ChiTietHoaDonMapper.Map< List<ChiTietHoaDon>, List<ChiTietHoaDonModel>>(chiTietHoaDon);

            //return PhieuThuTienModels;
        }
        public void Map(List<ChiTietHoaDonModel> chiTietHoaDonModel, ref List<ChiTietHoaDon> chiTietHoaDon)
        {
            chiTietHoaDon = _ChiTietHoaDonMapper.Map< List<ChiTietHoaDonModel>, List<ChiTietHoaDon>>(chiTietHoaDonModel);

            //return PhieuThuTienModels;
        }
        public async Task<List<ChiTietHoaDon>> LayDanhsachChiTietHoaDon()
        {
            string url = $"/api/ChiTietHD";

            var lstData = new List<ChiTietHoaDon>();

            ResponseModel response = await HttpHelper.Get<ResponseModel>(url);
            if (response == null)
            {
                return lstData;
            }

            if (response.Count > 0)
            {
                lstData = JsonConvert.DeserializeObject<List<ChiTietHoaDon>>(response.data.ToString());
            }
            return lstData;
        }
        public async Task<List<ChiTietHoaDon>> LayDanhsachChiTietHoaDon(string chiTietHoaDonId)
        {
            string url = $"/api/ChiTietHD/{chiTietHoaDonId}";

            var lstData = new List<ChiTietHoaDon>();
            ResponseModel response = await HttpHelper.Get<ResponseModel>(url);

            if (response.Count > 0 & response != null)
            {
                var lstDataModel = JsonConvert.DeserializeObject<List<ChiTietHoaDonModel>>(response.data.ToString());

                lstData = _ChiTietHoaDonMapper.Map<List<ChiTietHoaDonModel>, List<ChiTietHoaDon>>(lstDataModel);
            }
            return lstData;
        }
        public async Task<ChiTietHoaDon> LayThongtinChiTietHoaDon(ChiTietHoaDonModel chiTietHoaDon)
        {
            string url = $"/api/ChiTietHD/Info";

            var lstData = new ChiTietHoaDon();
            ResponseModel response = await HttpHelper.Post<ChiTietHoaDonModel>(url, chiTietHoaDon);

            if (response.Count > 0 & response != null)
            {
                lstData = JsonConvert.DeserializeObject<ChiTietHoaDon>(response.data.ToString());
            }
            return lstData;
        }
       
        public async Task<ResponseModel> XoaDanhsachChiTietHoaDon(int ChiTietHoaDonId)
        {
            string url = $"/api/ChiTietHD/{ChiTietHoaDonId}";

            var response = new ResponseModel();
            response = await HttpHelper.Delete(url);

            return response;
        }
        public async Task<ResponseModel> XoaChiTietHoaDon(ChiTietHoaDonModel chiTietHoaDon)
        {
            string url = $"/api/ChiTietHD/Delete";

            var response = new ResponseModel();
            response = await HttpHelper.Post<ChiTietHoaDonModel>(url, chiTietHoaDon);

            return response;
        }
        public async Task<ResponseModel> ThemChiTietHoaDon(ChiTietHoaDonModel chiTietHoaDon)
        {
            string url = $"/api/ChiTietHD";

            var response = new ResponseModel();
            response = await HttpHelper.Post<ChiTietHoaDonModel>(url, chiTietHoaDon);

            return response;
        }
        public async Task<ResponseModel> CapnhatChiTietHoaDon(ChiTietHoaDonModel chiTietHoaDon)
        {
            string url = $"/api/ChiTietHD";

            var response = new ResponseModel();
            response = await HttpHelper.Put<ChiTietHoaDonModel>(url, chiTietHoaDon);

            return response;
        }
    }
}
