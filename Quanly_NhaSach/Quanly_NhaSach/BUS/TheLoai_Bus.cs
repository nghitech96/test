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
    internal class TheLoai_Bus
    {
        public async Task<List<TheLoai>> LayDanhsachTheLoai()
        {
            string url = $"/api/TheLoai";
            ResponseModel response = new ResponseModel();
            var dsTheLoai = new List<TheLoai>();
            try
            {
                response = await HttpHelper.Get<ResponseModel>(url);
                if (response == null)
                {
                    return dsTheLoai;
                }

                if (response.Count > 0)
                {
                    dsTheLoai = JsonConvert.DeserializeObject<List<TheLoai>>(response.data.ToString());
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            
            
            return dsTheLoai;
        }

        public async Task<TheLoaiModel> LayThongtinTheLoai(int TheLoaiId)
        {
            string url = $"/api/TheLoai/{TheLoaiId}";

            var response = new TheLoaiModel();
            response = await HttpHelper.Get<TheLoaiModel>(url);

            return response;
        }
        public async Task<ResponseModel> XoaTheLoai(int TheLoaiId)
        {
            string url = $"/api/TheLoai/{TheLoaiId}";

            var response = new ResponseModel();
            response = await HttpHelper.Delete(url);

            return response;
        }
        public async Task<ResponseModel> ThemTheLoai(TheLoaiModel TheLoai)
        {
            string url = $"/api/TheLoai";

            var response = new ResponseModel();
            response = await HttpHelper.Post<TheLoaiModel>(url, TheLoai);

            return response;
        }
        public async Task<ResponseModel> CapnhatTheLoai(TheLoaiModel TheLoai)
        {
            string url = $"/api/TheLoai";

            var response = new ResponseModel();
            response = await HttpHelper.Put<TheLoaiModel>(url, TheLoai);

            return response;
        }
    }
}
