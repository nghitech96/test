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
    internal class Sach_Bus
    {


        private Mapper _SachMapper;

        public Sach_Bus()
        {

            var _configSach = new MapperConfiguration(cfg => cfg.CreateMap<Sach, SachModel>().ReverseMap());
            _SachMapper = new Mapper(_configSach);
        }
        public void Map(Sach sach, ref SachModel sachModel)
        {
            sachModel = _SachMapper.Map<Sach, SachModel>(sach);
        }
        public void Map(SachModel sachModel, ref Sach sach)
        {
            sach = _SachMapper.Map< SachModel, Sach>(sachModel);
        }
        public async Task<List<Sach>> LayDanhsachSach()
        {
            string url = $"/api/Sach";
            ResponseModel response = new ResponseModel();
            var dsSach = new List<Sach>();
            try
            {
                response = await HttpHelper.Get<ResponseModel>(url);
                if (response == null)
                {
                    return dsSach;
                }

                if (response.Count > 0)
                {
                    dsSach = JsonConvert.DeserializeObject<List<Sach>>(response.data.ToString());
                }
            }
            catch (Exception ex)
            {

                throw;
            }


            return dsSach;
        }

        public async Task<SachModel> LayThongtinSach(int SachId)
        {
            string url = $"/api/Sach/{SachId}";

            var response = new SachModel();
            response = await HttpHelper.Get<SachModel>(url);

            return response;
        }
        public async Task<ResponseModel> XoaSach(int SachId)
        {
            string url = $"/api/Sach/{SachId}";

            var response = new ResponseModel();
            response = await HttpHelper.Delete(url);

            return response;
        }
        public async Task<ResponseModel> ThemSach(SachModel Sach)
        {
            string url = $"/api/Sach";

            var response = new ResponseModel();
            response = await HttpHelper.Post<SachModel>(url, Sach);

            return response;
        }

        public async Task<ResponseModel> CapnhatSach(SachModel Sach)
        {
            string url = $"/api/Sach";

            var response = new ResponseModel();
            response = await HttpHelper.Put<SachModel>(url, Sach);

            return response;
        }
        public async Task<List<Sach>> TimkiemSach(ThongtinTimSachModel thongtinModel)
        {
            string url = $"/api/Sach/Timkiem";

            List<Sach> Sachs = new List<Sach>();
            var  response = await HttpHelper.Post<ThongtinTimSachModel>(url, thongtinModel);

            if (response.Count > 0)
            {
                Sachs = JsonConvert.DeserializeObject<List<Sach>>(response.data.ToString());
            }

            return Sachs;
        }
    }
}
