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
    internal class TacGia_Bus
    {
        public async Task<List<TacGia>> LayDanhsachTacGia()
        {
            string url = $"/api/TacGia";

            var dsTacGia = new List<TacGia>();
            ResponseModel response = new ResponseModel();
            response = await HttpHelper.Get<ResponseModel>(url);
            if (response == null)
            {
                return dsTacGia;
            }

            if (response.Count > 0)
            {
                dsTacGia = JsonConvert.DeserializeObject<List<TacGia>>(response.data.ToString());
            }
            return dsTacGia;
        }

        public async Task<TacGia> LayThongtinTacGia(int TacGiaId)
        {
            string url = $"/api/TacGia/{TacGiaId}";

            var response = new TacGia();
            response = await HttpHelper.Get<TacGia>(url);

            return response;
        }
        public async Task<ResponseModel> XoaTacGia(int TacGiaId)
        {
            string url = $"/api/TacGia/{TacGiaId}";

            var response = new ResponseModel();
            response = await HttpHelper.Delete(url);

            return response;
        }
        public async Task<ResponseModel> ThemTacGia(TacGiaModel TacGia)
        {
            string url = $"/api/TacGia";

            var response = new ResponseModel();
            response = await HttpHelper.Post<TacGiaModel>(url, TacGia);

            return response;
        }
        public async Task<ResponseModel> CapnhatTacGia(TacGiaModel TacGia)
        {
            string url = $"/api/TacGia";

            var response = new ResponseModel();
            response = await HttpHelper.Put<TacGiaModel>(url, TacGia);

            return response;
        }
    }
}
