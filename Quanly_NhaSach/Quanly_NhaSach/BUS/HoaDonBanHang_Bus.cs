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
    internal class HoaDonBanHang_Bus
    {
        private Mapper _HoaDonBanHangMapper;

        public HoaDonBanHang_Bus()
        {

            var _configHoaDonBanHang = new MapperConfiguration(cfg => cfg.CreateMap<HoaDonBanHang, HoaDonBanHangModel>().ReverseMap());
            _HoaDonBanHangMapper = new Mapper(_configHoaDonBanHang);
        }
        public void Map(HoaDonBanHang hoaDonBanHang, ref HoaDonBanHangModel hoaDonBanHangModel)
        {
            hoaDonBanHangModel = _HoaDonBanHangMapper.Map<HoaDonBanHang, HoaDonBanHangModel>(hoaDonBanHang);

            //return PhieuThuTienModels;
        }
        public void Map(HoaDonBanHangModel hoaDonBanHangModel, ref HoaDonBanHang hoaDonBanHang)
        {
            hoaDonBanHang = _HoaDonBanHangMapper.Map<HoaDonBanHangModel, HoaDonBanHang>(hoaDonBanHangModel);

            //return PhieuThuTienModels;
        }

        public async Task<List<HoaDonBanHang>> LayDanhsachHoaDonBanHang()
        {
            string url = $"/api/HoaDonBanHang";

            var lstData = new List<HoaDonBanHang>();
            ResponseModel response = await HttpHelper.Get<ResponseModel>(url);

            if (response == null)
            {
                return lstData;
            }

            if (response.Count > 0)
            {
                lstData = JsonConvert.DeserializeObject<List<HoaDonBanHang>>(response.data.ToString());
            }
            return lstData;
        }
        public async Task<List<HoaDonBanHang>> TimHoaDonBanHang(ThongtinTimHoaDonModel hoaDonBanHang)
        {
            string url = $"/api/HoaDonBanHang/Timkiem";
            var lstData = new List<HoaDonBanHang>();
            var response = new ResponseModel();
            response = await HttpHelper.Post<ThongtinTimHoaDonModel>(url, hoaDonBanHang);

            if (response == null)
            {
                return lstData;
            }

            if (response.Count > 0)
            {
                lstData = JsonConvert.DeserializeObject<List<HoaDonBanHang>>(response.data.ToString());
            }
            return lstData;
        }
        public async Task<HoaDonBanHang> LayThongtinHoaDonBanHang(string HoaDonBanHangId)
        {
            string url = $"/api/HoaDonBanHang/{HoaDonBanHangId}";

            var lstData = new HoaDonBanHang();
            ResponseModel response = await HttpHelper.Get<ResponseModel>(url);

            if (response.Count > 0 & response != null)
            {
                lstData = JsonConvert.DeserializeObject<HoaDonBanHang>(response.data.ToString());
            }
            return lstData;
        }
        public async Task<ResponseModel> XoaHoaDonBanHang(string HoaDonBanHangId)
        {
            string url = $"/api/HoaDonBanHang/{HoaDonBanHangId}";

            var response = new ResponseModel();
            response = await HttpHelper.Delete(url);

            return response;
        }
        public async Task<ResponseModel> ThemHoaDonBanHang(HoaDonBanHangModel hoaDonBanHang)
        {
            string url = $"/api/HoaDonBanHang";

            var response = new ResponseModel();
            response = await HttpHelper.Post<HoaDonBanHangModel>(url, hoaDonBanHang);

            return response;
        }
        public async Task<ResponseModel> CapnhatHoaDonBanHang(HoaDonBanHangModel hoaDonBanHang)
        {
            string url = $"/api/HoaDonBanHang";

            var response = new ResponseModel();
            response = await HttpHelper.Put<HoaDonBanHangModel>(url, hoaDonBanHang);

            return response;
        }
    }
}
