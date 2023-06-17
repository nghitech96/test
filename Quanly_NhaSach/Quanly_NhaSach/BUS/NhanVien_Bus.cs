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
    internal class NhanVien_Bus
    {
        private Mapper _NhanVienMapper;
        
        public NhanVien_Bus()
        {
        
            var _configNhanVIen = new MapperConfiguration(cfg => cfg.CreateMap<NhanVien, NhanVienModel>().ReverseMap());
            _NhanVienMapper = new Mapper(_configNhanVIen);
        }
        public void Map(NhanVien nhanvien,ref NhanVienModel nhanVienModel )
        {
            nhanVienModel = _NhanVienMapper.Map<NhanVien, NhanVienModel> (nhanvien);

            //return PhieuThuTienModels;
        }
        public void Map( NhanVienModel nhanVienModel,ref NhanVien nhanvien)
        {
            nhanvien = _NhanVienMapper.Map< NhanVienModel, NhanVien>(nhanVienModel);

            //return PhieuThuTienModels;
        }
        public async Task<List<NhanVien>> LayDanhsachNhanVien()
        {
            string url = $"/api/NhanVien";

            var lstData = new List<NhanVien>();
            ResponseModel response = await HttpHelper.Get<ResponseModel>(url);
            if (response == null)
            {
                return lstData;
            }

            if (response.Count > 0 )
            {
                lstData = JsonConvert.DeserializeObject<List<NhanVien>>(response.data.ToString());
            }
            return lstData;
        }

        void Map(NhanVienModel so,NhanVien dst)
        {

        }
        public async Task<NhanVien> LayThongtinNhanVien(int NhanVienId)
        {
            string url = $"/api/NhanVien/{NhanVienId}";

            var lstData = new NhanVien();
            ResponseModel response = await HttpHelper.Get<ResponseModel>(url);

            if (response.Count > 0 & response != null)
            {
                lstData = JsonConvert.DeserializeObject<NhanVien>(response.data.ToString());
            }
            return lstData;
        }
        public async Task<ResponseModel> XoaNhanVien(int NhanVienId)
        {
            string url = $"/api/NhanVien/{NhanVienId}";

            var response = new ResponseModel();
            response = await HttpHelper.Delete(url);

            return response;
        }
        public async Task<ResponseModel> ThemNhanVien(NhanVienModel NhanVien)
        {
            string url = $"/api/NhanVien";

            var response = new ResponseModel();
            response = await HttpHelper.Post<NhanVienModel>(url, NhanVien);

            return response;
        }
        public async Task<ResponseModel> CapnhatNhanVien(NhanVienModel NhanVien)
        {
            string url = $"/api/NhanVien";

            var response = new ResponseModel();
            response = await HttpHelper.Put<NhanVienModel>(url, NhanVien);

            return response;
        }
        public async Task<List<NhanVien>> TimKiem(NhanVienModel nhanvien)
        {
            string url = $"/api/NhanVien/Timkiem";

            List<NhanVien> nhanviens = new List<NhanVien>();

            var response = await HttpHelper.Post<NhanVienModel>(url, nhanvien);
            if (response.Count>0)
            {
                nhanviens = JsonConvert.DeserializeObject<List<NhanVien>>(response.data.ToString());
            }

            return nhanviens;
        }
    }
}
