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
    internal class KhachHang_Bus
    {

        private Mapper _KhachHangMapper;

        public KhachHang_Bus()
        {

            var _configKhachHang = new MapperConfiguration(cfg => cfg.CreateMap<KhachHang, KhachHangModel>().ReverseMap());
            _KhachHangMapper = new Mapper(_configKhachHang);
        }
        public void Map(KhachHang khachHang, ref KhachHangModel khachHangModel)
        {
            khachHangModel = _KhachHangMapper.Map<KhachHang, KhachHangModel>(khachHang);

            //return PhieuThuTienModels;
        }

        public void Map(KhachHangModel khachHangModel,ref KhachHang khachHang)
        {
            khachHang = _KhachHangMapper.Map<KhachHangModel, KhachHang>(khachHangModel);

            //return PhieuThuTienModels;
        }


        public async Task<List<KhachHang>> LayDanhsachKhachHang()
        {
            string url = $"/api/KhachHang";

            var lstData = new List<KhachHang>();
            ResponseModel response = await HttpHelper.Get<ResponseModel>(url);

            if (response == null)
            {
                return lstData;
            }

            if (response.Count > 0)
            {
                lstData = JsonConvert.DeserializeObject<List<KhachHang>>(response.data.ToString());
            }
            return lstData;
        }

        public async Task<KhachHang> LayThongtinKhachHang(int KhachHangId)
        {
            string url = $"/api/KhachHang/{KhachHangId}";

            var lstData = new KhachHang();
            ResponseModel response = await HttpHelper.Get<ResponseModel>(url);

            if (response.Count > 0 & response != null)
            {
                lstData = JsonConvert.DeserializeObject<KhachHang>(response.data.ToString());
            }
            return lstData;
        }
        public async Task<ResponseModel> XoaKhachHang(int KhachHangId)
        {
            string url = $"/api/KhachHang/{KhachHangId}";

            var response = new ResponseModel();
            response = await HttpHelper.Delete(url);

            return response;
        }
        public async Task<ResponseModel> ThemKhachHang(KhachHangModel KhachHang)
        {
            string url = $"/api/KhachHang";

            var response = new ResponseModel();
            response = await HttpHelper.Post<KhachHangModel>(url, KhachHang);

            return response;
        }
        public async Task<ResponseModel> CapnhatKhachHang(KhachHangModel KhachHang)
        {
            string url = $"/api/KhachHang";

            var response = new ResponseModel();
            response = await HttpHelper.Put<KhachHangModel>(url, KhachHang);

            return response;
        }
        public async Task<List<KhachHang>> Timkiem(KhachHangModel KhachHang)
        {
            string url = $"/api/KhachHang/Timkiem";
            List<KhachHang> dsKhachHang=new List<KhachHang>();

            var response = await HttpHelper.Post<KhachHangModel>(url, KhachHang);
            if (response.Count>0)
            {
                dsKhachHang = JsonConvert.DeserializeObject<List<KhachHang>>(response.data.ToString());
            }
            return dsKhachHang;
        }
    }
}
