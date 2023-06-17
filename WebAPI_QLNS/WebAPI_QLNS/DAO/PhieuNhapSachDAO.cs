using System.Collections.Generic;
using System.Linq;
using System;
using WebAPI_QLNS.DTO;

namespace WebAPI_QLNS.DAO
{
    public class PhieuNhapSachDAO
    {
        myDbContext db;
        public PhieuNhapSachDAO()
        {
            db = new myDbContext();
        }


        public List<PhieuNhapSach> LayDanhSachPhieuNhapSach()
        {
            Response response = new Response();
            List<PhieuNhapSach> dsPhieunhap = new List<PhieuNhapSach>();
            try
            {
                dsPhieunhap = db.PhieuNhapSach.ToList();
                if (dsPhieunhap != null)
                    throw new Exception("Not Found");
                response = new Response { Count = 1, Id = "0", Message = "Success", data = dsPhieunhap };
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
            return dsPhieunhap;
        }
        //public Response Convert()

        public PhieuNhapSach LayThongTinPhieuNhapSach(string PhieuNhapSachId)
        {
            Response response = new Response();
            PhieuNhapSach phieunhap = new PhieuNhapSach();
            try
            {
                 phieunhap = db.PhieuNhapSach
                    .Where(e => e.Id == PhieuNhapSachId).FirstOrDefault();
                if (phieunhap != null)
                    throw new Exception("Not Found");
                response = new Response { Count = 1, Id = PhieuNhapSachId.ToString(), Message = "Success", data = phieunhap };
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


            return phieunhap;
        }
        public Response XoaPhieuNhapSach(string PhieuNhapSachId)
        {
            Response respone = new Response();
            PhieuNhapSach p = new PhieuNhapSach();

            try
            {
                p = db.PhieuNhapSach.FirstOrDefault(x => x.Id == PhieuNhapSachId);
                if (p == null)
                {
                    throw new Exception("Not found");
                }
                db.PhieuNhapSach.Remove(p);
                db.SaveChanges();
                respone = new Response(0, "Success");
                respone.Id = PhieuNhapSachId;
                respone.Count = 1;
            }
            catch (System.Exception ex)
            {

                respone = new Response(-1, ex.Message);
            }
            return respone;
        }

        public Response ThemPhieuNhapSach(PhieuNhapSach PhieuNhapSach)
        {
            Response respone = new Response();
            try
            {
                db.PhieuNhapSach.Add(PhieuNhapSach);
                int State = db.SaveChanges();
                respone = new Response(1, "Success");
                respone.Id = PhieuNhapSach.Id;
                respone.Count = 1;
            }
            catch (System.Exception ex)
            {

                respone = new Response(-1, ex.Message);
            }

            return respone;
        }
        public Response CapNhatPhieuNhapSach(PhieuNhapSach PhieuNhapSach)
        {
            Response respone = new Response();
            try
            {
                db.PhieuNhapSach.Attach(PhieuNhapSach);

                db.Entry(PhieuNhapSach).Property(p => p.Ngay).IsModified = true;

                int State = db.SaveChanges();
                respone = new Response(1, "Success");
                respone.Id = PhieuNhapSach.Id;
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
