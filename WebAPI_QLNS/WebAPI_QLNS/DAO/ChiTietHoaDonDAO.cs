using System.Collections.Generic;
using System.Linq;
using System;
using WebAPI_QLNS.DTO;

namespace WebAPI_QLNS.DAO
{
    public class ChiTietHoaDonDAO
    {
        myDbContext db;
        ThongkeBaoCao_DAO tk;
        public ChiTietHoaDonDAO()
        {
            db = new myDbContext();
            tk = new ThongkeBaoCao_DAO();
        }


        public List<ChiTietHoaDon> LayDanhSachChiTietHoaDon()
        {
            Response rs = new Response();
            List <ChiTietHoaDon> chiTietHoaDons = new List<ChiTietHoaDon>(); 
            try
            {
                chiTietHoaDons = db.ChiTietHoaDon.ToList();
                if (chiTietHoaDons != null)
                    throw new Exception("Not Found");
                //rs = new Response { Count = 1, Id = "0", Message = "Success", data = chiTietHoaDons };
            }
            catch (Exception ex)
            {
                rs = new Response
                {
                    ResultCode = -1,
                    Message = ex.Message,
                    Id = "0",
                    data = ex.StackTrace,
                    Count = 0
                };
            }


            return chiTietHoaDons;

        }
        

        public List<ChiTietHoaDon> LayDanhSachChiTietHoaDon(string chiTietHoaDonId)
        {
            Response response = new Response();
            List<ChiTietHoaDon> chiTietHoaDons = new List<ChiTietHoaDon>();
            try
            {
                 chiTietHoaDons = db.ChiTietHoaDon
                   .Where(e => e.IdHoaDon == chiTietHoaDonId)
                   .ToList();
                if (chiTietHoaDons != null)
                    throw new Exception("Not Found");
                //response = new Response { Count = 1, Id = ChiTietHoaDonId, Message = "Success", data = chiTietHoaDon };
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


            return chiTietHoaDons;
        }
        public ChiTietHoaDon LayThongTinChiTietHoaDon(ChiTietHoaDon chiTietHD)
        {
            Response response = new Response();
            ChiTietHoaDon chiTietHoaDon = new ChiTietHoaDon();
            try
            {
                chiTietHoaDon = db.ChiTietHoaDon
                  .Where(e => (e.IdHoaDon == chiTietHD.IdHoaDon && e.IdSach== chiTietHD.IdSach)).FirstOrDefault();
                if (chiTietHoaDon != null)
                    throw new Exception("Not Found");
                //response = new Response { Count = 1, Id = ChiTietHoaDonId, Message = "Success", data = chiTietHoaDon };
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


            return chiTietHoaDon;
        }
        public Response XoaChiTietHoaDon(string ChiTietHoaDonId)
        {
            Response respone = new Response();
            List<ChiTietHoaDon> p = new List<ChiTietHoaDon>();

            try
            {
                p = db.ChiTietHoaDon
                    .Where(x => x.IdHoaDon == ChiTietHoaDonId)
                    .ToList();
                if (p == null)
                {
                    throw new Exception("Not found");
                }
                db.ChiTietHoaDon.RemoveRange(p);
                db.SaveChanges();
                respone = new Response(0, "Success");
                respone.Id = ChiTietHoaDonId;
                respone.Count = 1;
            }
            catch (System.Exception ex)
            {

                respone = new Response(-1, ex.Message);
            }
            return respone;
        }
        public Response XoaChiTietHoaDon(ChiTietHoaDon chiTietHD)
        {
            Response respone = new Response();
            ChiTietHoaDon p = new ChiTietHoaDon();

            try
            {
                p = db.ChiTietHoaDon
                  .FirstOrDefault(e => e.Id == chiTietHD.Id);
                if (p == null)
                {
                    throw new Exception("Not found");
                }
                db.ChiTietHoaDon.Remove(p);
                db.SaveChanges();
                tk.TinhSoluongSachTon(chiTietHD.IdSach);
                respone = new Response(0, "Success");
                respone.Id = chiTietHD.IdHoaDon;
                respone.Count = 1;
            }
            catch (System.Exception ex)
            {

                respone = new Response(-1, ex.Message);
            }
            return respone;
        }

        public Response ThemChiTietHoaDon(ChiTietHoaDon chiTietHD)
        {
            Response respone = new Response();
            try
            {
                db.ChiTietHoaDon.Add(chiTietHD);
                int State = db.SaveChanges();
                tk.TinhSoluongSachTon(chiTietHD.IdSach);

                respone = new Response(1, "Success");
                respone.Id = chiTietHD.IdHoaDon;
                respone.Count = 1;
            }
            catch (System.Exception ex)
            {

                respone = new Response(-1, ex.Message);
            }

            return respone;
        }
        public Response CapNhatChiTietHoaDon(ChiTietHoaDon chiTietHoaDon)
        {
            Response respone = new Response();
            try
            {
                //var res = db.ChiTietHoaDon
                //    .FirstOrDefault(x => x.Id == chiTietHoaDon.Id);
                    
                if (chiTietHoaDon.Id>0)
                {
                    db.ChiTietHoaDon.Attach(chiTietHoaDon);
                    db.Entry(chiTietHoaDon).Property(p => p.Id).IsModified = false;

                    db.Entry(chiTietHoaDon).Property(p => p.IdHoaDon).IsModified = true;
                    db.Entry(chiTietHoaDon).Property(p => p.IdSach).IsModified = true;

                    db.Entry(chiTietHoaDon).Property(p => p.DonGia).IsModified = true;
                    db.Entry(chiTietHoaDon).Property(p => p.SoLuong).IsModified = true;
                }
                else
                {
                    db.ChiTietHoaDon.Add(chiTietHoaDon);

                }

                int State = db.SaveChanges();
                tk.TinhSoluongSachTon(chiTietHoaDon.IdSach);

                respone = new Response(1, "Success");
                respone.Id = chiTietHoaDon.IdHoaDon;
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
