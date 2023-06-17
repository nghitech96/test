using System.Collections.Generic;
using System.Linq;
using System;
using WebAPI_QLNS.DTO;
using WebAPI_QLNS.Models;
using WebAPI_QLNS.Helpers;

namespace WebAPI_QLNS.DAO
{
    public class ChiTietNhapSachDAO
    {
        myDbContext db;
        ThongkeBaoCao_DAO tk;
        public ChiTietNhapSachDAO()
        {
            db = new myDbContext();
            tk = new ThongkeBaoCao_DAO();
        }


        public List<ChiTietNhapSach> LayDanhSachChiTietNhapSach()
        {
            Response response = new Response();
            List<ChiTietNhapSach> chiTietNhapSachs = new List<ChiTietNhapSach>();
            try
            {
                chiTietNhapSachs = db.ChiTietNhapSach.ToList();
                if (chiTietNhapSachs != null)
                    throw new Exception("Not Found");
                //response = new Response { Count = 1, Id = "0", Message = "Success", data = chiTietNhapSachs };
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
            return chiTietNhapSachs;
        }
        //public Response Convert()

        public List<ChiTietNhapSach> LayDanhsachChiTietNhapSach(string ChiTietNhapSachId)
        {
            Response response = new Response();
            List < ChiTietNhapSach> chiTietNhapSachs = new List<ChiTietNhapSach>();
            try
            {
                var schiTietNhapSachs = db.ChiTietNhapSach.ToList();

                chiTietNhapSachs = schiTietNhapSachs.Where(e => (e.IdPhieuNhap == ChiTietNhapSachId))
                   .ToList();
                if (chiTietNhapSachs != null)
                    throw new Exception("Not Found");
                response = new Response { Count = 1, Id = ChiTietNhapSachId, Message = "Success", data = chiTietNhapSachs };
            }
            catch (Exception ex)
            {

                response = new Response
                {
                    ResultCode = -1,
                    Message = ex.Message,
                    Id = ChiTietNhapSachId,
                    data = ex.StackTrace,
                    Count = 0
                };
            }


            return chiTietNhapSachs;

        }
        public ChiTietNhapSach LayThongTinChiTietNhapSach(ChiTietNhapSachModel chiTietNhapSachModel)
        {
            Response response = new Response();
            ChiTietNhapSach chiTietNhapSachs = new ChiTietNhapSach();
            try
            {
                chiTietNhapSachs = db.ChiTietNhapSach
                  .FirstOrDefault(e => e.Id == chiTietNhapSachModel.Id );
                if (chiTietNhapSachs != null)
                    throw new Exception("Not Found");
                response = new Response { Count = 1, Id = chiTietNhapSachModel.Id.ToString(), Message = "Success", data = chiTietNhapSachs };
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


            return chiTietNhapSachs;

        }
        public Response XoaChiTietNhapSach(string ChiTietNhapSachId)
        {
            Response response = new Response();
            //ChiTietNhapSach p = new ChiTietNhapSach();

            try
            {
                var p = db.ChiTietNhapSach
                    .Where(x => x.IdPhieuNhap == ChiTietNhapSachId)
                    .ToArray();
                if (p == null)
                {
                    throw new Exception("Not found");
                }
                db.ChiTietNhapSach.RemoveRange(p);
                db.SaveChanges();
                response = new Response(0, "Success");
                response.Id = ChiTietNhapSachId;
                response.Count = 1;
            }
            catch (System.Exception ex)
            {

                response = new Response(-1, ex.Message);
            }
            return response;
        }
        public Response XoaChiTietNhapSach(ChiTietNhapSach chiTietNhapSach)
        {
            Response response = new Response();

            try
            {
                var p = db.ChiTietNhapSach
                    .FirstOrDefault(x => x.Id == chiTietNhapSach.Id);
                if (p == null)
                {
                    throw new Exception("Not found");
                }
                db.ChiTietNhapSach.Remove(p);
                db.SaveChanges();
                
                tk.TinhSoluongSachTon(chiTietNhapSach.IdSach);

                response = new Response(0, "Success");
                response.Id = chiTietNhapSach.Id.ToString();
                response.Count = 1;
            }
            catch (System.Exception ex)
            {

                response = new Response(-1, ex.Message);
            }
            return response;
        }

        public Response ThemChiTietNhapSach(ChiTietNhapSach chiTietNhapSach)
        {
            Response respone = new Response();
            try
            {

                db.ChiTietNhapSach.Add(chiTietNhapSach);

                int State = db.SaveChanges();
                tk.TinhSoluongSachTon(chiTietNhapSach.IdSach);

                respone = new Response(1, "Success");
                respone.Id = chiTietNhapSach.Id.ToString();
                respone.Count = 1;
            }
            catch (System.Exception ex)
            {

                respone = new Response(-1, ex.Message);
            }

            return respone;
        }
        public Response CapNhatChiTietNhapSach(ChiTietNhapSach chiTietNhapSach)
        {
            Response respone = new Response();
            try
            {
                
                if (chiTietNhapSach.Id>0)
                {
                    db.ChiTietNhapSach.Attach(chiTietNhapSach);
                    db.Entry(chiTietNhapSach).Property(p => p.IdSach).IsModified = true;
                    db.Entry(chiTietNhapSach).Property(p => p.SoLuong).IsModified = true;
                }
                else
                {
                    db.ChiTietNhapSach.Add(chiTietNhapSach);
                }

                int State = db.SaveChanges();
                tk.TinhSoluongSachTon(chiTietNhapSach.IdSach);

                respone = new Response(1, "Success");
                respone.Id = chiTietNhapSach.Id.ToString();
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
