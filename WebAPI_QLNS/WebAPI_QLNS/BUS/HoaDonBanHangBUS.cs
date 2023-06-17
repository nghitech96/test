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
    public class HoaDonBanHangBUS
    {
        private Mapper _HoaDonBanHangMapper;
        private HoaDonBanHangDAO _DAL;

        //private KhachHangDAO _khachhang;
        private QuyDinhDAO _quydinh;
        private List<QuyDinh> _qd;
        private QuyDinh qd4;
        private ThongkeBaoCao_DAO _tk;

        public HoaDonBanHangBUS()
        {
            _DAL = new HoaDonBanHangDAO();
            var _configHoaDonBanHang = new MapperConfiguration(cfg => cfg.CreateMap<HoaDonBanHang, HoaDonBanHangModel>().ReverseMap());

            _HoaDonBanHangMapper = new Mapper(_configHoaDonBanHang);
            _tk = new ThongkeBaoCao_DAO();
            //_khachhang = new KhachHangDAO();
            _quydinh = new QuyDinhDAO();
            _qd = _quydinh.LayDanhSachQuyDinh();
            qd4 = _qd.FirstOrDefault(x => x.Id == ((int)QuyDinhenum.QD4));

        }
        public List<HoaDonBanHangModel> LayDanhSachHoaDonBanHang()
        {
            List<HoaDonBanHang> HoaDonBanHangDB = _DAL.LayDanhSachHoaDonBanHang();
            List<HoaDonBanHangModel> HoaDonBanHangModels = _HoaDonBanHangMapper.Map<List<HoaDonBanHang>, List<HoaDonBanHangModel>>(HoaDonBanHangDB);

            return HoaDonBanHangModels;
        }
        public HoaDonBanHangModel LayThongTinHoaDonBanHang(string HoaDonBanHangId)
        {
            var HoaDonBanHangDB = _DAL.LayThongTinHoaDonBanHang(HoaDonBanHangId);
            HoaDonBanHangModel HoaDonBanHangModel = _HoaDonBanHangMapper.Map<HoaDonBanHang, HoaDonBanHangModel>(HoaDonBanHangDB);
            return HoaDonBanHangModel;
        }
        public Response XoaHoaDonBanHang(string HoaDonBanHangId)
        {
            return _DAL.XoaHoaDonBanHang(HoaDonBanHangId);
        }
        public Response ThemHoaDonBanHang(HoaDonBanHangModel hoaDonBanHangModel)
        {
            HoaDonBanHang HoaDonBanHangEntity = _HoaDonBanHangMapper.Map<HoaDonBanHangModel, HoaDonBanHang>(hoaDonBanHangModel);

            Response response = new Response();
            try
            {
                // KIểm tra quy đinh
                if (bool.Parse(qd4.GiaTri))     // true cho phép kiểm tra quy định
                {
                    var qd2_1 = _qd.FirstOrDefault(x => x.Id == ((int)QuyDinhenum.QD2_1)); // Tiền nợ không quá
                    //var qd2_2 = _qd.FirstOrDefault(x => x.Id == ((int)QuyDinhenum.QD2_2));  // Số lượng tồn sau khi bán không nhỏ hơn

                    
                    var Congno = _tk.TinhCongnoKhachHang(hoaDonBanHangModel.IdKhachHang);


                    if (Congno >= long.Parse(qd2_1.GiaTri))
                    {
                        throw new Exception($"Khách hàng đang nợ quá quy định (Nợ :{Congno}> QĐ:{qd2_1.GiaTri}) ");
                    }

                }
                response = _DAL.ThemHoaDonBanHang(HoaDonBanHangEntity);
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
        public Response CapNhatHoaDonBanHang(HoaDonBanHangModel HoaDonBanHangModel)
        {
            HoaDonBanHang HoaDonBanHangEntity = _HoaDonBanHangMapper.Map<HoaDonBanHangModel, HoaDonBanHang>(HoaDonBanHangModel);
            return _DAL.CapNhatHoaDonBanHang(HoaDonBanHangEntity);

        }
        public List<HoaDonBanHangModel> TimHoaDonBanHang(ThongtinTimHoaDonModel thongtin)
        {
            List<HoaDonBanHang> hoadonBanhangs = _DAL.TimHoaDonBanHang(thongtin);
            List<HoaDonBanHangModel> hoaDonBanHangModels = _HoaDonBanHangMapper.Map<List<HoaDonBanHang>, List<HoaDonBanHangModel>>(hoadonBanhangs);
            return hoaDonBanHangModels;
        }
    }
}
