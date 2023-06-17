using System.Collections.Generic;
using System.Linq;
using System;
using WebAPI_QLNS.DTO;

namespace WebAPI_QLNS.DAO
{
    public class TheLoaiDAO
    {
        myDbContext db;
        public TheLoaiDAO()
        {
            db = new myDbContext();
        }


        public List<TheLoai> LayDanhSachTheLoai()
        {
            Response response = new Response();
            List<TheLoai> dsTheLoai = new List<TheLoai>();
            try
            {
                dsTheLoai = db.TheLoai.ToList();
                if (dsTheLoai != null)
                    throw new Exception("Not Found");
                response = new Response { Count = 1, Id = "0", Message = "Success", data = dsTheLoai };
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
            return dsTheLoai;
        }
        //public Response Convert()

        public TheLoai LayThongTinTheLoai(int TheLoaiId)
        {

            Response response = new Response();
            TheLoai theloai = new TheLoai();
            try
            {
                theloai = db.TheLoai
                   .Where(e => e.Id == TheLoaiId).FirstOrDefault();
                if (theloai != null)
                    throw new Exception("Not Found");
                response = new Response { Count = 1, Id = TheLoaiId.ToString(), Message = "Success", data = theloai };
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


            return theloai;
        }
        public Response XoaTheLoai(int TheLoaiId)
        {
            Response respone = new Response();
            TheLoai p = new TheLoai();

            try
            {
                p = db.TheLoai.FirstOrDefault(x => x.Id == TheLoaiId);
                if (p == null)
                {
                    throw new Exception("Not found");
                }
                db.TheLoai.Remove(p);
                db.SaveChanges();
                respone = new Response(0, "Success");
                respone.Id = TheLoaiId.ToString();
                respone.Count = 1;
            }
            catch (System.Exception ex)
            {

                respone = new Response(-1, ex.Message);
            }
            return respone;
        }

        public Response ThemTheLoai(TheLoai TheLoai)
        {
            Response respone = new Response();
            try
            {
                db.TheLoai.Add(TheLoai);
                int State = db.SaveChanges();
                respone = new Response(1, "Success");
                respone.Id = TheLoai.Id.ToString();
                respone.Count = 1;
            }
            catch (System.Exception ex)
            {

                respone = new Response(-1, ex.Message);
            }

            return respone;
        }
        public Response CapNhatTheLoai(TheLoai TheLoai)
        {
            Response respone = new Response();
            try
            {
                db.TheLoai.Attach(TheLoai);

                db.Entry(TheLoai).Property(p => p.Ten).IsModified = true;

                int State = db.SaveChanges();
                respone = new Response(1, "Success");
                respone.Id = TheLoai.Id.ToString();
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
