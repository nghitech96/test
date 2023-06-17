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
    internal class QuyDinh_Bus
    {


        private Mapper _QuyDinhMapper;

        public QuyDinh_Bus()
        {

            var _configQuyDinh = new MapperConfiguration(cfg => cfg.CreateMap<QuyDinh, QuyDinhModel>().ReverseMap());
            _QuyDinhMapper = new Mapper(_configQuyDinh);
        }
        public void Map(QuyDinh quyDinh, ref QuyDinhModel quyDinhModel)
        {
            quyDinhModel = _QuyDinhMapper.Map<QuyDinh, QuyDinhModel>(quyDinh);
        }
        public void Map(QuyDinhModel quyDinhModel, ref QuyDinh quyDinh)
        {
            quyDinh = _QuyDinhMapper.Map<QuyDinhModel, QuyDinh>(quyDinhModel);
        }
        public void Map(List<QuyDinh> quyDinh, ref List<QuyDinhModel> quyDinhModel)
        {
            quyDinhModel = _QuyDinhMapper.Map< List<QuyDinh>, List<QuyDinhModel>>(quyDinh);
        }
        public void Map(List<QuyDinhModel> quyDinhModel, ref List<QuyDinh> quyDinh)
        {
            quyDinh = _QuyDinhMapper.Map< List<QuyDinhModel>, List<QuyDinh>>(quyDinhModel);
        }
        public async Task<List<QuyDinh>> LayDanhsachQuyDinh()
        {
            string url = $"/api/QuyDinh";

            var lstData = new List<QuyDinh>();
            ResponseModel response = await HttpHelper.Get<ResponseModel>(url);

            if (response == null)
            {
                return lstData;
            }

            if (response.Count > 0)
            {
                lstData = JsonConvert.DeserializeObject<List<QuyDinh>>(response.data.ToString());
            }
            return lstData;
        }
      
        public async Task<QuyDinh> LayThongtinQuyDinh(int QuyDinhId)
        {
            string url = $"/api/QuyDinh/{QuyDinhId}";

            var lstData = new QuyDinh();
            ResponseModel response = await HttpHelper.Get<ResponseModel>(url);

            if (response == null)
            {
                return lstData;
            }

            if (response.Count > 0)
            {
                lstData = JsonConvert.DeserializeObject<QuyDinh>(response.data.ToString());
            }
            return lstData;
        }
        public async Task<ResponseModel> XoaQuyDinh(int QuyDinhId)
        {
            string url = $"/api/QuyDinh/{QuyDinhId}";

            var response = new ResponseModel();
            response = await HttpHelper.Delete(url);

            return response;
        }
        public async Task<ResponseModel> ThemQuyDinh(QuyDinhModel QuyDinh)
        {
            string url = $"/api/QuyDinh";

            var response = new ResponseModel();
            response = await HttpHelper.Post<QuyDinhModel>(url, QuyDinh);

            return response;
        }
        public async Task<ResponseModel> CapnhatQuyDinh(QuyDinhModel QuyDinh)
        {
            string url = $"/api/QuyDinh";

            var response = new ResponseModel();
            response = await HttpHelper.Put<QuyDinhModel>(url, QuyDinh);

            return response;
        }
    }
}
