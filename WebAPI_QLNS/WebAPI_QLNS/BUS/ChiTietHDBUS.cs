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
    public class ChiTietHDBUS
    {
        private Mapper _ChiTietHoaDonMapper;
        private ChiTietHoaDonDAO _DAL;

        private QuyDinhDAO _quydinh;
        private SachDAO _sach;
        private List<QuyDinh> _qd;
        private QuyDinh qd4;

        public ChiTietHDBUS()
        {
            _DAL = new ChiTietHoaDonDAO();
            var _configChiTietHD = new MapperConfiguration(cfg => cfg.CreateMap<ChiTietHoaDon, ChiTietHoaDonModel>().ReverseMap());

            _ChiTietHoaDonMapper = new Mapper(_configChiTietHD);


            _quydinh = new QuyDinhDAO();
            _sach = new SachDAO();
            _qd = _quydinh.LayDanhSachQuyDinh();
            qd4 = _qd.FirstOrDefault(x => x.Id == ((int)QuyDinhenum.QD4));

        }
        public List<ChiTietHoaDonModel> LayDanhSachChiTietHoaDon()
        {
            List<ChiTietHoaDon> ChiTietHoaDonDB = _DAL.LayDanhSachChiTietHoaDon();
            List<ChiTietHoaDonModel> ChiTietHoaDonModels = _ChiTietHoaDonMapper.Map<List<ChiTietHoaDon>, List<ChiTietHoaDonModel>>(ChiTietHoaDonDB);

            return ChiTietHoaDonModels;
        }

        public List<ChiTietHoaDonModel> LayDanhSachChiTietHoaDon(string ChiTietHoaDonId)
        {
            var ChiTietHoaDonDB = _DAL.LayDanhSachChiTietHoaDon(ChiTietHoaDonId);
            List < ChiTietHoaDonModel> ChiTietHoaDonModel = _ChiTietHoaDonMapper.Map<List<ChiTietHoaDon>, List< ChiTietHoaDonModel >>(ChiTietHoaDonDB);
            return ChiTietHoaDonModel;
        }
        public Response LayThongTinChiTietHoaDon(ChiTietHoaDonModel chiTietHoaDonModel)
        {
            ChiTietHoaDon ChiTietHoaDonEntity = _ChiTietHoaDonMapper.Map<ChiTietHoaDonModel, ChiTietHoaDon>(chiTietHoaDonModel);
            return _DAL.ThemChiTietHoaDon(ChiTietHoaDonEntity);
        }
        public Response XoaDanhsachChiTietHoaDon(string ChiTietHoaDonId)
        {
            return _DAL.XoaChiTietHoaDon(ChiTietHoaDonId);
        }
        public Response XoaChiTietHoaDon(ChiTietHoaDonModel chiTietHoaDonModel)
        {
            ChiTietHoaDon ChiTietHoaDonEntity = _ChiTietHoaDonMapper.Map<ChiTietHoaDonModel, ChiTietHoaDon>(chiTietHoaDonModel);
            return _DAL.XoaChiTietHoaDon(ChiTietHoaDonEntity);
        }
        public Response ThemChiTietHoaDon(ChiTietHoaDonModel chiTietHoaDonModel)
        {
            ChiTietHoaDon chiTietHoaDonEntity = _ChiTietHoaDonMapper.Map<ChiTietHoaDonModel, ChiTietHoaDon>(chiTietHoaDonModel);
            Response response = new Response();
            try
            {
                // KIểm tra quy đinh
                if (bool.Parse(qd4.GiaTri))     // true cho phép kiểm tra quy định
                {
                    //var qd2_1 = _qd.FirstOrDefault(x => x.Id == ((int)QuyDinhenum.QD2_1)); // Tiền nợ không quá
                    var qd2_2 = _qd.FirstOrDefault(x => x.Id == ((int)QuyDinhenum.QD2_2));  // Số lượng tồn sau khi bán không nhỏ hơn

                    var sa = _sach.LayThongTinSach(chiTietHoaDonModel.IdSach);

                    

                    if ((sa.SoluongTon - chiTietHoaDonModel.SoLuong) >= long.Parse(qd2_2.GiaTri))
                    {
                        throw new Exception($"Số lượng đầu sách còn nhiều, sau khi bán {sa.SoluongTon - chiTietHoaDonModel.SoLuong} > QĐ:{qd2_2.GiaTri}) ");
                    }
                   
                }



                response =  _DAL.ThemChiTietHoaDon(chiTietHoaDonEntity);
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
        public Response CapNhatChiTietHoaDon(ChiTietHoaDonModel chiTietHoaDonModel)
        {
            ChiTietHoaDon ChiTietHoaDonEntity = _ChiTietHoaDonMapper.Map<ChiTietHoaDonModel, ChiTietHoaDon>(chiTietHoaDonModel);
            Response response = new Response();
            try
            {
                // KIểm tra quy đinh
                if (bool.Parse(qd4.GiaTri))     // true cho phép kiểm tra quy định
                {
                    //var qd2_1 = _qd.FirstOrDefault(x => x.Id == ((int)QuyDinhenum.QD2_1)); // Tiền nợ không quá
                    var qd2_2 = _qd.FirstOrDefault(x => x.Id == ((int)QuyDinhenum.QD2_2));  // Số lượng tồn sau khi bán không nhỏ hơn

                    var sa = _sach.LayThongTinSach(chiTietHoaDonModel.IdSach);



                    if ((sa.SoluongTon - chiTietHoaDonModel.SoLuong) < long.Parse(qd2_2.GiaTri))
                    {
                        throw new Exception($"Số lượng đầu sách còn nhiều, sau khi bán {sa.SoluongTon - chiTietHoaDonModel.SoLuong} > QĐ:{qd2_2.GiaTri}) ");
                    }
                    
                }

                response = _DAL.CapNhatChiTietHoaDon(ChiTietHoaDonEntity);
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
