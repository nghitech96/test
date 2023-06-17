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
    internal class ThongkeBaoCao_Bus
    {
        private Mapper _ThongkeBCMapper;

        public ThongkeBaoCao_Bus()
        {

            //var _configThongkeBC = new MapperConfiguration(cfg => cfg.CreateMap<ThongkeBC, ThongkeBCModel>().ReverseMap());
            //_ThongkeBCMapper = new Mapper(_configThongkeBC);
        }
       


        public async Task<List<ThongKeCongNoTrongKy>> ThongkeBaocaoCongNo(ThongtinThongkeModel thongtin)
        {
            string url = $"/api/ThongKeBaoCao/BaoCaoCongNo";

            var rsData = new List<ThongKeCongNoTrongKy>();
            var response = await HttpHelper.Post<ThongtinThongkeModel>(url, thongtin);

            if (response == null)
            {
                return rsData;
            }

            if (response.Count > 0)
            {
                rsData = JsonConvert.DeserializeObject<List<ThongKeCongNoTrongKy>>(response.data.ToString());
            }
            return rsData;
        }
        public async Task<ThongKeNXTTrongKy> BaocaoNhapxuatTon(ThongtinThongkeModel thongtin)
        {
            string url = $"/api/ThongKeBaoCao/BaoCaoNhapXuat";

            var rsData = new ThongKeNXTTrongKy();
            var response = await HttpHelper.Post<ThongtinThongkeModel>(url, thongtin);

            if (response == null)
            {
                return rsData;
            }

            if (response.Count > 0)
            {
                rsData = JsonConvert.DeserializeObject<ThongKeNXTTrongKy>(response.data.ToString());
            }
            return rsData;
        }
    }
}
