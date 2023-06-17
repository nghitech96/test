using AutoMapper;
using System.Collections.Generic;
using WebAPI_QLNS.DAO;
using WebAPI_QLNS.DTO;
using WebAPI_QLNS.Models;

namespace WebAPI_QLNS.BUS
{
    public class QuyDinhBUS
    {
        private Mapper _QuyDinhMapper;
        private QuyDinhDAO _DAL;
        public QuyDinhBUS()
        {
            _DAL = new QuyDinhDAO();
            var _configQuyDinh = new MapperConfiguration(cfg => cfg.CreateMap<QuyDinh, QuyDinhModel>().ReverseMap());

            _QuyDinhMapper = new Mapper(_configQuyDinh);
        }
        public List<QuyDinhModel> LayDanhSachQuyDinh()
        {
            List<QuyDinh> QuyDinhDB = _DAL.LayDanhSachQuyDinh();
            List<QuyDinhModel> QuyDinhModels = _QuyDinhMapper.Map<List<QuyDinh>, List<QuyDinhModel>>(QuyDinhDB);

            return QuyDinhModels;
        }
        public QuyDinhModel LayThongTinQuyDinh(int QuyDinhId)
        {
            var QuyDinhDB = _DAL.LayThongTinQuyDinh(QuyDinhId);
            QuyDinhModel QuyDinhModel = _QuyDinhMapper.Map<QuyDinh, QuyDinhModel>(QuyDinhDB);
            return QuyDinhModel;
        }
        public Response XoaQuyDinh(int QuyDinhId)
        {
            return _DAL.XoaQuyDinh(QuyDinhId);
        }
        public Response ThemQuyDinh(QuyDinhModel QuyDinhModel)
        {
            QuyDinh QuyDinhEntity = _QuyDinhMapper.Map<QuyDinhModel, QuyDinh>(QuyDinhModel);
            return _DAL.ThemQuyDinh(QuyDinhEntity);
        }
        public Response CapNhatQuyDinh(QuyDinhModel QuyDinhModel)
        {
            QuyDinh QuyDinhEntity = _QuyDinhMapper.Map<QuyDinhModel, QuyDinh>(QuyDinhModel);
            return _DAL.CapNhatQuyDinh(QuyDinhEntity);

        }
    }
}
