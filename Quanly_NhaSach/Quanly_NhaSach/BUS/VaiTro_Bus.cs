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
    internal class VaiTro_Bus
    {
        public async Task<List<VaiTro>> LayDanhsachVaiTro()
        {
            string url = $"/api/VaiTro";
            ResponseModel response = new ResponseModel();
            var dsVaiTro = new List<VaiTro>();
            try
            {
                response = await HttpHelper.Get<ResponseModel>(url);
                if (response == null)
                {
                    return dsVaiTro;
                }

                if (response.Count > 0)
                {
                    dsVaiTro = JsonConvert.DeserializeObject<List<VaiTro>>(response.data.ToString());
                }
            }
            catch (Exception ex)
            {

                throw;
            }


            return dsVaiTro;
        }

        public async Task<VaiTroModel> LayThongtinVaiTro(int VaiTroId)
        {
            string url = $"/api/VaiTro/{VaiTroId}";

            var response = new VaiTroModel();
            response = await HttpHelper.Get<VaiTroModel>(url);

            return response;
        }
        public async Task<ResponseModel> XoaVaiTro(int VaiTroId)
        {
            string url = $"/api/VaiTro/{VaiTroId}";

            var response = new ResponseModel();
            response = await HttpHelper.Delete(url);

            return response;
        }
        public async Task<ResponseModel> ThemVaiTro(VaiTroModel VaiTro)
        {
            string url = $"/api/VaiTro";

            var response = new ResponseModel();
            response = await HttpHelper.Post<VaiTroModel>(url, VaiTro);

            return response;
        }
        public async Task<ResponseModel> CapnhatVaiTro(VaiTroModel VaiTro)
        {
            string url = $"/api/VaiTro";

            var response = new ResponseModel();
            response = await HttpHelper.Put<VaiTroModel>(url, VaiTro);

            return response;
        }

    }
}
