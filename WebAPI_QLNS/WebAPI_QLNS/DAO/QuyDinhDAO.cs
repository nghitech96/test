using System.Collections.Generic;
using System.Linq;
using System;
using WebAPI_QLNS.DTO;

namespace WebAPI_QLNS.DAO
{
    public class QuyDinhDAO
    {
        myDbContext db;
        public QuyDinhDAO()
        {
            db = new myDbContext();
        }


        public List<QuyDinh> LayDanhSachQuyDinh()
        {
           
            Response response = new Response();
            List<QuyDinh> dsQuydinh = new List<QuyDinh>();
            try
            {
                dsQuydinh = db.QuyDinh.ToList();
                if (dsQuydinh != null)
                    throw new Exception("Not Found");
                response = new Response { Count = 1, Id = "0", Message = "Success", data = dsQuydinh };
            }
            catch (Exception ex)
            {
                response = new Response
                {
                    ResultCode = -1,
                    Message = ex.Message,
                    Id = "0",
                    data = ex.StackTrace,
                    Count = 0
                };
            }
            return dsQuydinh;
        }
        //public Response Convert()

        public QuyDinh LayThongTinQuyDinh(int QuyDinhId)
        {
            Response response = new Response();
            QuyDinh quydinh = new QuyDinh();
            try
            {
                 quydinh = db.QuyDinh
                    .Where(e => e.Id == QuyDinhId).FirstOrDefault();
                if (quydinh != null)
                    throw new Exception("Not Found");
                response = new Response { Count = 1, Id = QuyDinhId.ToString(), Message = "Success", data = quydinh };
            }
            catch (Exception ex)
            {

                response = new Response
                {
                    ResultCode = -1,
                    Message = ex.Message,
                    Id = "0",
                    data = ex.StackTrace,
                    Count = 0
                };
            }


            return quydinh;
        }
        public Response XoaQuyDinh(int QuyDinhId)
        {
            Response respone = new Response();
            QuyDinh p = new QuyDinh();

            try
            {
                p = db.QuyDinh.FirstOrDefault(x => x.Id == QuyDinhId);
                if (p == null)
                {
                    throw new Exception("Not found");
                }
                db.QuyDinh.Remove(p);
                db.SaveChanges();
                respone = new Response(0, "Success");
                respone.Id = QuyDinhId.ToString();
                respone.Count = 1;
            }
            catch (System.Exception ex)
            {

                respone = new Response(-1, ex.Message);
            }
            return respone;
        }

        public Response ThemQuyDinh(QuyDinh QuyDinh)
        {
            Response respone = new Response();
            try
            {
                db.QuyDinh.Add(QuyDinh);
                int State = db.SaveChanges();
                respone = new Response(1, "Success");
                respone.Id = QuyDinh.Id.ToString();
                respone.Count = 1;
            }
            catch (System.Exception ex)
            {

                respone = new Response(-1, ex.Message);
            }

            return respone;
        }
        public Response CapNhatQuyDinh(QuyDinh QuyDinh)
        {
            Response respone = new Response();
            try
            {
                db.QuyDinh.Attach(QuyDinh);

                db.Entry(QuyDinh).Property(p => p.Ten).IsModified = true;
                db.Entry(QuyDinh).Property(p => p.GiaTri).IsModified = true;
                db.Entry(QuyDinh).Property(p => p.Kieu).IsModified = true;

                int State = db.SaveChanges();
                respone = new Response(1, "Success");
                respone.Id = QuyDinh.Id.ToString();
                respone.Count = 1;
            }
            catch (System.Exception ex)
            {

                respone = new Response(-1, ex.Message);
            }

            return respone;
        }
    }
}
