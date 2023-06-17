using System.Collections.Generic;
using System.Linq;
using System;
using WebAPI_QLNS.DTO;
using WebAPI_QLNS.Models;

namespace WebAPI_QLNS.DAO
{
    public class SachDAO
    {
        myDbContext db;
        public SachDAO()
        {
            db = new myDbContext();
        }


        public List<Sach> LayDanhSachSach()
        {
            return db.Sach.ToList();
        }
        //public Response Convert()

        public Sach LayThongTinSach(int SachId)
        {
            Response response = new Response();
            Sach sach = new Sach();
            try
            {
                 sach = db.Sach
                    .Where(e => e.Id == SachId).FirstOrDefault();
                if (sach == null)
                    throw new Exception("Not Found");
                response = new Response { Count = 1, Id = SachId.ToString(), Message = "Success", data = sach };
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


            return sach;
        }
        public Response XoaSach(int SachId)
        {
            Response respone = new Response();
            Sach p = new Sach();

            try
            {
                p = db.Sach.FirstOrDefault(x => x.Id == SachId);
                if (p == null)
                {
                    throw new Exception("Not found");
                }
                db.Sach.Remove(p);
                db.SaveChanges();
                respone = new Response(0, "Success");
                respone.Id = SachId.ToString();
                respone.Count = 1;
            }
            catch (System.Exception ex)
            {

                respone = new Response(-1, ex.Message);
            }
            return respone;
        }

        public Response ThemSach(Sach Sach)
        {
            Response respone = new Response();
            try
            {
                db.Sach.Add(Sach);
                int State = db.SaveChanges();
                respone = new Response(1, "Success");
                respone.Id = Sach.Id.ToString();
                respone.Count = 1;
            }
            catch (System.Exception ex)
            {

                respone = new Response(-1, ex.Message);
            }

            return respone;
        }
        public Response CapNhatSach(Sach Sach)
        {
            Response respone = new Response();
            try
            {
                db.Sach.Attach(Sach);

                db.Entry(Sach).Property(p => p.IdTheLoai).IsModified = true;
                db.Entry(Sach).Property(p => p.Ten).IsModified = true;
                db.Entry(Sach).Property(p => p.IdTacGia).IsModified = true;

                int State = db.SaveChanges();
                respone = new Response(1, "Success");
                respone.Id = Sach.Id.ToString();
                respone.Count = 1;
            }
            catch (System.Exception ex)
            {

                respone = new Response(-1, ex.Message);
            }

            return respone;
        }
        public List<Sach> TimkiemSach(ThongtinTimSachModel Thongtin)
        {
            Response response = new Response();
            List<Sach> sachs = new List<Sach>();
            try
            {
                var Sach1 = db.Sach
                    .Where(e => e.Ten.Contains(Thongtin.TenSach))
                    .ToList();
                var TacGia1 = db.TacGia
                    .Where(e => e.Ten.Contains(Thongtin.TenTacgia))
                    .ToList();
                var TheLoai1 = db.TheLoai
                    .Where(e => e.Ten.Contains(Thongtin.Theloai))
                    .ToList();

                sachs = (from a in Sach1
                        join b in TacGia1 on a.IdTacGia equals b.Id
                        join c in TheLoai1 on a.IdTheLoai equals c.Id
                        select new Sach
                        {
                            Id = a.Id,
                            Ten = a.Ten,
                            IdTacGia = a.IdTacGia,
                            IdTheLoai = a.IdTheLoai,
                            SoluongTon = a.SoluongTon
                        }
                       )
                       .ToList();

                if (sachs == null)
                    throw new Exception("Not Found");
                response = new Response { Count = 1, Id = "0", Message = "Success", data = sachs };
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


            return sachs;
        }
    }
}
