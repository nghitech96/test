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
    public class PhieuThuTienBUS
    {
        private Mapper _PhieuThuTienMapper;
        private PhieuThuTienDAO _DAL;

        private QuyDinhDAO _quydinh;
        private List<QuyDinh> _qd;
        private QuyDinh qd4;
        private QuyDinh qd3;

        private ThongkeBaoCao_DAO _tk;
        public PhieuThuTienBUS()
        {
            _DAL = new PhieuThuTienDAO();
            var _configPhieuThuTien = new MapperConfiguration(cfg => cfg.CreateMap<PhieuThuTien, PhieuThuTienModel>().ReverseMap());

            _PhieuThuTienMapper = new Mapper(_configPhieuThuTien);

            _tk = new ThongkeBaoCao_DAO();
            _quydinh = new QuyDinhDAO();
            _qd = _quydinh.LayDanhSachQuyDinh();
            qd4 = _qd.FirstOrDefault(x => x.Id == ((int)QuyDinhenum.QD4));
            qd3 = _qd.FirstOrDefault(x => x.Id == ((int)QuyDinhenum.QD3));

        }
        public List<PhieuThuTienModel> LayDanhSachPhieuThuTien()
        {
            List<PhieuThuTien> PhieuThuTienDB = _DAL.LayDanhSachPhieuThuTien();
            List<PhieuThuTienModel> PhieuThuTienModels = _PhieuThuTienMapper.Map<List<PhieuThuTien>, List<PhieuThuTienModel>>(PhieuThuTienDB);

            return PhieuThuTienModels;
        }
        public PhieuThuTienModel LayThongTinPhieuThuTien(string PhieuThuTienId)
        {
            var PhieuThuTienDB = _DAL.LayThongTinPhieuThuTien(PhieuThuTienId);
            PhieuThuTienModel PhieuThuTienModel = _PhieuThuTienMapper.Map<PhieuThuTien, PhieuThuTienModel>(PhieuThuTienDB);
            return PhieuThuTienModel;
        }
        public Response XoaPhieuThuTien(string PhieuThuTienId)
        {
            return _DAL.XoaPhieuThuTien(PhieuThuTienId);
        }
        public Response ThemPhieuThuTien(PhieuThuTienModel phieuThuTienModel)
        {
            PhieuThuTien phieuThuTienEntity = _PhieuThuTienMapper.Map<PhieuThuTienModel, PhieuThuTien>(phieuThuTienModel);
            Response response = new Response();
            try
            {
                // KIểm tra quy đinh
                if (bool.Parse(qd4.GiaTri))     // true cho phép kiểm tra quy định
                {

                    var Congno = _tk.TinhCongnoKhachHang(phieuThuTienModel.IdKhachHang);


                    if (Congno < phieuThuTienModel.Tien && bool.Parse( qd3.GiaTri))
                    {
                        throw new Exception($"Số tiền thu lớn hơn số tiền khách hàng nợ ( Thu:{phieuThuTienModel.Tien} > Nợ :{Congno}) ");
                    }

                }
                response = _DAL.ThemPhieuThuTien(phieuThuTienEntity);
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
        public Response CapNhatPhieuThuTien(PhieuThuTienModel phieuThuTienModel)
        {
            PhieuThuTien phieuThuTienEntity = _PhieuThuTienMapper.Map<PhieuThuTienModel, PhieuThuTien>(phieuThuTienModel);
            Response response = new Response();
            try
            {
                // KIểm tra quy đinh
                if (bool.Parse(qd4.GiaTri))     // true cho phép kiểm tra quy định
                {

                    var Congno = _tk.TinhCongnoKhachHang(phieuThuTienModel.IdKhachHang);


                    if (Congno < phieuThuTienModel.Tien && bool.Parse(qd3.GiaTri))
                    {
                        throw new Exception($"Số tiền thu lớn hơn số tiền khách hàng nợ ( Thu:{phieuThuTienModel.Tien} > Nợ :{Congno}) ");
                    }

                }
                response = _DAL.CapNhatPhieuThuTien(phieuThuTienEntity);
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
        public List<PhieuThuTienModel> TimPhieuThuTien(ThongtinTimPhieuThuModel phieuThuTien)
        {
           
            List<PhieuThuTien> phieuthus = _DAL.TimPhieuThuTien(phieuThuTien);
            List<PhieuThuTienModel> PhieuThuTienModels = _PhieuThuTienMapper.Map<List<PhieuThuTien>, List<PhieuThuTienModel>>(phieuthus);

            return PhieuThuTienModels;
        }
        public Response LayCongNoKhachHang(int IdKHachHang)
        {
            long Congno = _tk.TinhCongnoKhachHang(IdKHachHang);
            return new Response
            {
                ResultCode = 0,
                Message = "Success",
                Id = "0",
                Count = 1,
                data = Congno
            };
        }
    }
}
