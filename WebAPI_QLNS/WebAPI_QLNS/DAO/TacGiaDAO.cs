using System.Collections.Generic;
using System.Linq;
using System;
using WebAPI_QLNS.DTO;

namespace WebAPI_QLNS.DAO
{
    public class TacGiaDAO
    {
        myDbContext db;
        public TacGiaDAO()
        {
            db = new myDbContext();
        }


        public List<TacGia> LayDanhSachTacGia()
        {
            Response response = new Response();
            List<TacGia> dsTacGia = new List<TacGia>();
            try
            {
                dsTacGia = db.TacGia.ToList();
                if (dsTacGia != null)
                    throw new Exception("Not Found");
                response = new Response { Count = 1, Id = "0", Message = "Success", data = dsTacGia };
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
            return dsTacGia;
        }
        //public Response Convert()

        public TacGia LayThongTinTacGia(int TacGiaId)
        {
            Response response = new Response();
            TacGia tacgia = new TacGia();
            try
            {
                 tacgia = db.TacGia
                    .Where(e => e.Id == TacGiaId).FirstOrDefault();
                if (tacgia != null)
                    throw new Exception("Not Found");
                response = new Response { Count = 1, Id = TacGiaId.ToString(), Message = "Success", data = tacgia };
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


            return tacgia;
        }
        public Response XoaTacGia(int TacGiaId)
        {
            Response respone = new Response();
            TacGia p = new TacGia();

            try
            {
                p = db.TacGia.FirstOrDefault(x => x.Id == TacGiaId);
                if (p == null)
                {
                    throw new Exception("Not found");
                }
                db.TacGia.Remove(p);
                db.SaveChanges();
                respone = new Response(0, "Success");
                respone.Id = TacGiaId.ToString();
                respone.Count = 1;
            }
            catch (System.Exception ex)
            {

                respone = new Response(-1, ex.Message);
            }
            return respone;
        }

        public Response ThemTacGia(TacGia TacGia)
        {
            Response respone = new Response();
            try
            {
                db.TacGia.Add(TacGia);
                int State = db.SaveChanges();
                respone = new Response(1, "Success");
                respone.Id = TacGia.Id.ToString();
                respone.Count = 1;
            }
            catch (System.Exception ex)
            {

                respone = new Response(-1, ex.Message);
            }

            return respone;
        }
        public Response CapNhatTacGia(TacGia TacGia)
        {
            Response respone = new Response();
            try
            {
                db.TacGia.Attach(TacGia);

                db.Entry(TacGia).Property(p => p.Ten).IsModified = true;

                int State = db.SaveChanges();
                respone = new Response(1, "Success");
                respone.Id = TacGia.Id.ToString();
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
