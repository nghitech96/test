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
    internal class PhieuThuTien_Bus
    {

        private Mapper _NhanVienMapper;

        public PhieuThuTien_Bus()
        {

            var _configNhanVIen = new MapperConfiguration(cfg => cfg.CreateMap<PhieuThuTien, PhieuThuTienModel>().ReverseMap());
            _NhanVienMapper = new Mapper(_configNhanVIen);
        }
        public void Map(PhieuThuTien phieuThu, ref PhieuThuTienModel phieuThuModel)
        {
            phieuThuModel = _NhanVienMapper.Map<PhieuThuTien, PhieuThuTienModel>(phieuThu);

            //return PhieuThuTienModels;
        }
        public void Map(PhieuThuTienModel phieuThuModel, ref PhieuThuTien phieuThu)
        {
            phieuThu = _NhanVienMapper.Map<PhieuThuTienModel, PhieuThuTien>(phieuThuModel);

            //return PhieuThuTienModels;
        }
        public void Map(List<PhieuThuTien> phieuThu, ref List<PhieuThuTienModel> phieuThuModel)
        {
            phieuThuModel = _NhanVienMapper.Map< List<PhieuThuTien>, List<PhieuThuTienModel>>(phieuThu);

            //return PhieuThuTienModels;
        }
        public void Map(List<PhieuThuTienModel> phieuThuModel, ref List<PhieuThuTien> phieuThu)
        {
            phieuThu = _NhanVienMapper.Map< List<PhieuThuTienModel>, List<PhieuThuTien>>(phieuThuModel);

            //return PhieuThuTienModels;
        }

        public async Task<List<PhieuThuTien>> LayDanhsachPhieuThuTien()
        {
            string url = $"/api/PhieuThuTien";

            var lstData = new List<PhieuThuTien>();
            ResponseModel response = await HttpHelper.Get<ResponseModel>(url);

            if (response == null)
            {
                return lstData;
            }

            if (response.Count > 0)
            {
                lstData = JsonConvert.DeserializeObject<List<PhieuThuTien>>(response.data.ToString());
            }
            return lstData;
        }

        public async Task<PhieuThuTien> LayThongtinPhieuThuTien(int PhieuThuTienId)
        {
            string url = $"/api/PhieuThuTien/{PhieuThuTienId}";

            var lstData = new PhieuThuTien();
            ResponseModel response = await HttpHelper.Get<ResponseModel>(url);

            if (response == null)
            {
                return lstData;
            }

            if (response.Count > 0)
            {
                lstData = JsonConvert.DeserializeObject<PhieuThuTien>(response.data.ToString());
            }
            return lstData;
        }
        public async Task<ResponseModel> LayCongnoKHachHang(int IdKhachHang)
        {
            string url = $"/api/PhieuThuTien/CongNo/{IdKhachHang}";

            var lstData = new PhieuThuTien();
            ResponseModel response = await HttpHelper.Get<ResponseModel>(url);

            //if (response == null)
            //{
            //    return lstData;
            //}

            //if (response.Count > 0)
            //{
            //    lstData = JsonConvert.DeserializeObject<PhieuThuTien>(response.data.ToString());
            //}
            //return lstData;
            return response;
        }
        public async Task<ResponseModel> XoaPhieuThuTien(string PhieuThuTienId)
        {
            string url = $"/api/PhieuThuTien/{PhieuThuTienId}";

            var response = new ResponseModel();
            response = await HttpHelper.Delete(url);

            return response;
        }
        public async Task<ResponseModel> ThemPhieuThuTien(PhieuThuTienModel PhieuThuTien)
        {
            string url = $"/api/PhieuThuTien";

            var response = new ResponseModel();
            response = await HttpHelper.Post<PhieuThuTienModel>(url, PhieuThuTien);

            return response;
        }
        public async Task<ResponseModel> CapnhatPhieuThuTien(PhieuThuTienModel PhieuThuTien)
        {
            string url = $"/api/PhieuThuTien";

            var response = new ResponseModel();
            response = await HttpHelper.Put<PhieuThuTienModel>(url, PhieuThuTien);

            return response;
        }
        public async Task<List<PhieuThuTien>>  TimPhieuThuTien(ThongtinTimPhieuThuModel phieuThuTien)
        {
            string url = $"/api/PhieuThuTien/Tiemkiem";
            List<PhieuThuTien> lstData = new List<PhieuThuTien>();
            var response = new ResponseModel();
            response = await HttpHelper.Post<ThongtinTimPhieuThuModel>(url, phieuThuTien);

            if (response.Count > 0)
            {
                lstData = JsonConvert.DeserializeObject<List<PhieuThuTien>>(response.data.ToString());
            }
            return lstData;
        }
        
    }
}
