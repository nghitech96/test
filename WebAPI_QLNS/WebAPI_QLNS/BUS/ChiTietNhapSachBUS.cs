using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI_QLNS.DAO;
using WebAPI_QLNS.DTO;
using WebAPI_QLNS.Helpers;
using WebAPI_QLNS.Models;

namespace WebAPI_QLNS.BUS
{
    public class ChiTietNhapSachBUS
    {
        private Mapper _ChiTietNhapSachMapper;
        private ChiTietNhapSachDAO _DAL;
        private QuyDinhDAO _quydinh;
        private SachDAO _sach;
        private List<QuyDinh> _qd;
        private QuyDinh qd4;
        public ChiTietNhapSachBUS()
        {
            _DAL = new ChiTietNhapSachDAO();
            var _configChiTietNhapSach = new MapperConfiguration(cfg => cfg.CreateMap<ChiTietNhapSach, ChiTietNhapSachModel>().ReverseMap());

            _ChiTietNhapSachMapper = new Mapper(_configChiTietNhapSach);

            _quydinh = new QuyDinhDAO();
            _sach = new SachDAO();
            _qd = _quydinh.LayDanhSachQuyDinh();
            qd4 = _qd.FirstOrDefault(x => x.Id == ((int)QuyDinhenum.QD4));
        }
        public List<ChiTietNhapSachModel> LayDanhSachChiTietNhapSach()
        {
            List<ChiTietNhapSach> ChiTietNhapSachDB = _DAL.LayDanhSachChiTietNhapSach();
            List<ChiTietNhapSachModel> ChiTietNhapSachModels = _ChiTietNhapSachMapper.Map<List<ChiTietNhapSach>, List<ChiTietNhapSachModel>>(ChiTietNhapSachDB);

            return ChiTietNhapSachModels;
        }
        public List<ChiTietNhapSachModel> LayDanhsachChiTietNhapSach(string ChiTietNhapSachId)
        {
            var ChiTietNhapSachDB = _DAL.LayDanhsachChiTietNhapSach(ChiTietNhapSachId);
            List< ChiTietNhapSachModel> ChiTietNhapSachModels = _ChiTietNhapSachMapper.Map<List<ChiTietNhapSach>, List<ChiTietNhapSachModel>>(ChiTietNhapSachDB);
            return ChiTietNhapSachModels;
        }
        public ChiTietNhapSachModel LayThongTinChiTietNhapSach(ChiTietNhapSachModel ChiTietNhapSachModel)
        {
            var ChiTietNhapSachDB = _DAL.LayThongTinChiTietNhapSach(ChiTietNhapSachModel);
            ChiTietNhapSachModel ChiTietNhapSachModels = _ChiTietNhapSachMapper.Map<ChiTietNhapSach, ChiTietNhapSachModel>(ChiTietNhapSachDB);
            return ChiTietNhapSachModels;
        }
        public Response XoaChiTietNhapSach(string ChiTietNhapSachId)
        {
            

            return _DAL.XoaChiTietNhapSach(ChiTietNhapSachId);
        }
        public Response XoaChiTietNhapSach(ChiTietNhapSachModel ChiTietNhapSachModel)
        {
            ChiTietNhapSach ChiTietNhapSachEntity = _ChiTietNhapSachMapper.Map<ChiTietNhapSachModel, ChiTietNhapSach>(ChiTietNhapSachModel);

            return _DAL.XoaChiTietNhapSach(ChiTietNhapSachEntity);
        }
        public Response ThemChiTietNhapSach(ChiTietNhapSachModel chiTietNhapSachModel)
        {
            ChiTietNhapSach ChiTietNhapSachEntity = _ChiTietNhapSachMapper.Map<ChiTietNhapSachModel, ChiTietNhapSach>(chiTietNhapSachModel);
            Response response = new Response();
            try
            {
                // KIểm tra quy đinh
                if (bool.Parse(qd4.GiaTri))     // true cho phép kiểm tra quy định
                {
                    var qd1_1 = _qd.FirstOrDefault(x => x.Id == ((int)QuyDinhenum.QD1_1)); // Số lượng nhập tối thiểu
                    var qd1_2 = _qd.FirstOrDefault(x => x.Id == ((int)QuyDinhenum.QD1_2));  // Số lượng tồn cho phép nhập

                    var sa = _sach.LayThongTinSach(chiTietNhapSachModel.IdSach);

                    var _SoluongTon = sa.SoluongTon;

                    if (_SoluongTon >= long.Parse(qd1_2.GiaTri))
                    {
                        throw new Exception($"Số lượng đầu sách còn nhiều, không được nhập (Tồn:{_SoluongTon} >QĐ:{qd1_2.GiaTri}) ");
                    }
                    if (chiTietNhapSachModel.SoLuong < long.Parse(qd1_1.GiaTri))
                    {
                        throw new Exception($"Số lượng đầu sách nhập tối thiểu theo QD1: >=:{qd1_1.GiaTri}) ");
                    }
                }



                response =  _DAL.ThemChiTietNhapSach(ChiTietNhapSachEntity);
            }
            catch (Exception ex)
            {

                response = new Response
                {
                    ResultCode = -1,
                    Message = ex.Message,
                    Count = 0,
                    Id = "0",
                    data = ex.Message
                };
            }
            return response;
        }
        public Response CapNhatChiTietNhapSach(ChiTietNhapSachModel chiTietNhapSachModel)
        {
            ChiTietNhapSach ChiTietNhapSachEntity = _ChiTietNhapSachMapper.Map<ChiTietNhapSachModel, ChiTietNhapSach>(chiTietNhapSachModel);
           
            Response response = new Response();
            try
            {
                // KIểm tra quy đinh
                if (bool.Parse(qd4.GiaTri))     // true cho phép kiểm tra quy định
                {
                    var qd1_1 = _qd.FirstOrDefault(x => x.Id == ((int)QuyDinhenum.QD1_1)); // Số lượng nhập tối thiểu
                    //var qd1_2 = _qd.FirstOrDefault(x => x.Id == ((int)QuyDinhenum.QD1_2));  // Số lượng tồn cho phép nhập

                    var sa = _sach.LayThongTinSach(chiTietNhapSachModel.IdSach);

                    var _SoluongTon = sa.SoluongTon;

                    //if (_SoluongTon >= long.Parse(qd1_2.GiaTri))
                    //{
                    //    throw new Exception($"Số lượng đầu sách còn nhiều, không được nhập (Tồn:{_SoluongTon} >QĐ:{qd1_2.GiaTri}) ");
                    //}
                    if (chiTietNhapSachModel.SoLuong < long.Parse(qd1_1.GiaTri))
                    {
                        throw new Exception($"Số lượng đầu sách nhập tối thiểu theo QD1: >=:{qd1_1.GiaTri}) ");
                    }
                }



                response =  _DAL.CapNhatChiTietNhapSach(ChiTietNhapSachEntity);
            }
            catch (Exception ex)
            {

                response = new Response
                {
                    ResultCode = -1,
                    Message = ex.Message,
                    Count = 0,
                    Id = "0",
                    data = ex.Message
                };
            }
            return response;
        }
        
    }
}
