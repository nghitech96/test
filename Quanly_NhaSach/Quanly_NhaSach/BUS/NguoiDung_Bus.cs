using AutoMapper;
using Newtonsoft.Json;
using Quanly_NhaSach.DTO;
using Quanly_NhaSach.Helpers;
using Quanly_NhaSach.Models;
using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebAPI_QLNS.Models;

namespace Quanly_NhaSach.BUS
{
    internal class NguoiDung_Bus
    {
        private Mapper _NguoiDungMapper;
        private Mapper _NguoiDungMapper2;
        private Mapper _NguoiDungDangNhapMapper2;
        public NguoiDung_Bus()
        {

            var _confignguoidung = new MapperConfiguration(cfg => cfg.CreateMap<NguoiDung, NguoiDungModel>().ReverseMap());
            var _confignguoidung2 = new MapperConfiguration(cfg => cfg.CreateMap<NguoiDung, NguoiDungDangnhap>().ReverseMap());
            var _confignguoidungDangnhap2 = new MapperConfiguration(cfg => cfg.CreateMap<NguoiDungModel, NguoiDungDangnhap>().ReverseMap());
            _NguoiDungMapper = new Mapper(_confignguoidung);
            _NguoiDungMapper2 = new Mapper(_confignguoidung2);
            _NguoiDungDangNhapMapper2 = new Mapper(_confignguoidungDangnhap2);
        }
        public void Map(NguoiDung nguoidung, ref NguoiDungModel nguoidungModel)
        {
            nguoidungModel = _NguoiDungMapper.Map<NguoiDung, NguoiDungModel>(nguoidung);

            //return PhieuThuTienModels;
        }
        public void Map(NguoiDungModel nguoidungModel, ref NguoiDung nguoidung)
        {
            nguoidung = _NguoiDungMapper.Map<NguoiDungModel, NguoiDung>(nguoidungModel);

            //return PhieuThuTienModels;
        }
        public void Map(NguoiDungModel nguoidungModel, ref NguoiDungDangnhap nguoidung)
        {
            nguoidung = _NguoiDungDangNhapMapper2.Map<NguoiDungModel, NguoiDungDangnhap>(nguoidungModel);

            //return PhieuThuTienModels;
        }
        public void Map(List< NguoiDungDangnhap> nguoidungDangnhap, ref List<NguoiDung> nguoidung)
        {
            nguoidung = _NguoiDungMapper2.Map<List<NguoiDungDangnhap>,List< NguoiDung>>(nguoidungDangnhap);

            //return PhieuThuTienModels;
        }
        public async Task<ResponseModel> DangNhap(string username, string password)
        {
            string url = $"token";
            var response = new ResponseModel();
            var account = new AccountModel
            {
                UserName = username,
                Password = password
            };
            response = await HttpHelper.Authentication(url, account);
            return response;
        }
        public async Task<List<NguoiDung>> LayDanhsachNguoiDung()
        {
            string url = $"/api/nguoidung";

            var lstData = new List<NguoiDung>();
            var response = await HttpHelper.Get<ResponseModel>(url);

            if (response == null)
            {
                return lstData;
            }

            if (response.Count > 0)
            {
                lstData = JsonConvert.DeserializeObject<List<NguoiDung>>(response.data.ToString());
            }
            return lstData;
        }
        public async Task<List<NguoiDungDangnhap>> LayDanhsachNguoiDung2()
        {
            string url = $"/api/nguoidung/login";

            var lstData = new List<NguoiDungDangnhap>();
            var response = await HttpHelper.Get<ResponseModel>(url);

            if (response == null)
            {
                return lstData;
            }

            if (response.Count > 0)
            {
                lstData = JsonConvert.DeserializeObject<List<NguoiDungDangnhap>>(response.data.ToString());
            }
            return lstData;
        }
        public async Task<NguoiDungDangnhap> LayThongtinNguoiDungDangnhap(int NguoidungId)
        {
            string url = $"/api/nguoidung/Login/{NguoidungId}";

            var lstData = new NguoiDungDangnhap();
            ResponseModel response = await HttpHelper.Get<ResponseModel>(url);

            if (response.Count > 0 & response != null)
            {
                lstData = JsonConvert.DeserializeObject<NguoiDungDangnhap>(response.data.ToString());
            }
            return lstData;
        }
        public async Task<NguoiDung> LayThongtinNguoiDung(int NguoidungId)
        {
            string url = $"/api/nguoidung/{NguoidungId}";

            var lstData = new NguoiDung();
            ResponseModel response = await HttpHelper.Get<ResponseModel>(url);

            if (response.Count > 0 & response != null)
            {
                lstData = JsonConvert.DeserializeObject<NguoiDung>(response.data.ToString());
            }
            return lstData;
        }
        public async Task<ResponseModel> XoaNguoiDung(int NguoidungId)
        {
            string url = $"/api/nguoidung/{NguoidungId}";

            var response = new ResponseModel();
            response = await HttpHelper.Delete(url);

            return response;
        }
        public async Task<List<NguoiDungDangnhap>> TimNguoiDung(NguoiDungDangnhapModel Nguoidung)
        {
            string url = $"/api/nguoidung/Timkiem";
            List<NguoiDungDangnhap> nguoidungdn = new List<NguoiDungDangnhap>();
            //List<NguoiDung> nguoidungs = new List<NguoiDung>();

            var response = new ResponseModel();
            response = await HttpHelper.Post<NguoiDungDangnhapModel>(url, Nguoidung);
            if (response.Count>0)
            {
                nguoidungdn = JsonConvert.DeserializeObject<List<NguoiDungDangnhap>>(response.data.ToString());
                //Map(nguoidungdn, ref nguoidungs);
            }

            return nguoidungdn;
        }
        public async Task<ResponseModel> ThemNguoiDung(NguoiDungModel Nguoidung)
        {
            string url = $"/api/nguoidung";

            var response = new ResponseModel();
            response = await HttpHelper.Post<NguoiDungModel>(url, Nguoidung);

            return response;
        }
        public async Task<ResponseModel> CapnhatNguoiDung(NguoiDungModel Nguoidung)
        {
            string url = $"/api/nguoidung";

            var response = new ResponseModel();
            response = await HttpHelper.Put<NguoiDungModel>(url, Nguoidung);

            return response;
        }
    }
}
