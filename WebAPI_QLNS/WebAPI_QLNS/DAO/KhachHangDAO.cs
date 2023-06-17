using System.Collections.Generic;
using System.Linq;
using System;
using WebAPI_QLNS.DTO;

namespace WebAPI_QLNS.DAO
{
    public class KhachHangDAO
    {
        myDbContext db;
        public KhachHangDAO()
        {
            db = new myDbContext();
        }


        public List<KhachHang> LayDanhSachKhachHang()
        {
            Response response = new Response();
            List<KhachHang> dsKhachhang = new List<KhachHang>();
            try
            {
                dsKhachhang = db.KhachHang.ToList();
                if (dsKhachhang != null)
                    throw new Exception("Not Found");
                //response = new Response { Count = 1, Id = "0", Message = "Success", data = dsKhachhang };
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
            return dsKhachhang;
        }
        //public Response Convert()

        public KhachHang LayThongTinKhachHang(int KhachHangId)
        {
            Response response = new Response();
            KhachHang khachHang = new KhachHang();
            try
            {
                 khachHang = db.KhachHang
                    .Where(e => e.Id == KhachHangId).FirstOrDefault();
                if (khachHang != null)
                    throw new Exception("Not Found");
                response = new Response { Count = 1, Id = KhachHangId.ToString(), Message = "Success", data = khachHang };
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


            return khachHang;


        }
        public Response XoaKhachHang(int KhachHangId)
        {
            Response respone = new Response();
            KhachHang p = new KhachHang();

            try
            {
                p = db.KhachHang.FirstOrDefault(x => x.Id == KhachHangId);
                if (p == null)
                {
                    throw new Exception("Not found");
                }
                db.KhachHang.Remove(p);
                db.SaveChanges();
                respone = new Response(0, "Success");
                respone.Id = KhachHangId.ToString();
                respone.Count = 1;
            }
            catch (System.Exception ex)
            {

                respone = new Response(-1, ex.Message);
            }
            return respone;
        }
        public Response TimKiemn(KhachHang khachhang)
        {
            Response response = new Response(-1);
            List<KhachHang> khachHangs = new List<KhachHang>();
            try
            {
                khachHangs = db.KhachHang.Where(n => (
                    (!string.IsNullOrEmpty(khachhang.Ten) && !string.IsNullOrEmpty(khachhang.DiaChi) && n.Ten.Contains(khachhang.Ten) && n.DienThoai == khachhang.DienThoai && n.Email == khachhang.Email &&n.DiaChi.Contains(khachhang.DiaChi)  ) // Tìm theo tên, sodt, email,diachi
                    || (!string.IsNullOrEmpty(khachhang.Ten) && string.IsNullOrEmpty(khachhang.DiaChi) && !string.IsNullOrEmpty(khachhang.DienThoai) && string.IsNullOrEmpty(khachhang.Email)  && n.Ten.Contains(khachhang.Ten) && n.DienThoai == khachhang.DienThoai ) //Tim theo ten, sodt
                    || (!string.IsNullOrEmpty(khachhang.Ten) && string.IsNullOrEmpty(khachhang.DiaChi) && string.IsNullOrEmpty(khachhang.DienThoai) && !string.IsNullOrEmpty(khachhang.Email)  && n.Ten.Contains(khachhang.Ten) && n.Email == khachhang.Email ) //Tim theo ten, email
                    || (!string.IsNullOrEmpty(khachhang.Ten) && !string.IsNullOrEmpty(khachhang.DiaChi) && string.IsNullOrEmpty(khachhang.DienThoai) && string.IsNullOrEmpty(khachhang.Email)  && n.Ten.Contains(khachhang.Ten) && n.DiaChi.Contains(khachhang.DiaChi) ) //Tim theo ten, diachi
                    || (string.IsNullOrEmpty(khachhang.Ten) && string.IsNullOrEmpty(khachhang.DiaChi) && !string.IsNullOrEmpty(khachhang.DienThoai) && !string.IsNullOrEmpty(khachhang.Email)  && n.DienThoai == khachhang.DienThoai && n.Email == khachhang.Email ) //Tim theo Sodt, email
                    || (!string.IsNullOrEmpty(khachhang.Ten) && string.IsNullOrEmpty(khachhang.DiaChi) && string.IsNullOrEmpty(khachhang.DienThoai) && string.IsNullOrEmpty(khachhang.Email)  && n.Ten.Contains(khachhang.Ten)) //Tim theo ten
                    || (string.IsNullOrEmpty(khachhang.Ten) && string.IsNullOrEmpty(khachhang.DiaChi) && !string.IsNullOrEmpty(khachhang.DienThoai) && string.IsNullOrEmpty(khachhang.Email)  && n.DienThoai == khachhang.DienThoai) // tim theo sodt
                    || (string.IsNullOrEmpty(khachhang.Ten) && string.IsNullOrEmpty(khachhang.DiaChi) && string.IsNullOrEmpty(khachhang.DienThoai) && !string.IsNullOrEmpty(khachhang.Email)  && n.Email == khachhang.Email ) // tim theo email
                    || (string.IsNullOrEmpty(khachhang.Ten) && string.IsNullOrEmpty(khachhang.DiaChi) && string.IsNullOrEmpty(khachhang.DienThoai) && string.IsNullOrEmpty(khachhang.Email)  && n.DiaChi.Contains(khachhang.DiaChi) ) // tim theo diachi
                )).ToList();

                if (khachHangs != null)
                {
                    response = new Response
                    {
                        ResultCode = 0,
                        Message = "Success",
                        Id = khachhang.Id.ToString(),
                        Count = khachHangs.Count,
                        data = khachHangs
                    };

                }

            }
            catch (System.Exception ex)
            {

                response = new Response(-1, ex.Message);
            }

            return response;
        }
        public Response ThemKhachHang(KhachHang KhachHang)
        {
            Response respone = new Response();
            try
            {
                db.KhachHang.Add(KhachHang);
                int State = db.SaveChanges();
                respone = new Response(1, "Success");
                respone.Id = KhachHang.Id.ToString();
                respone.Count = 1;
            }
            catch (System.Exception ex)
            {

                respone = new Response(-1, ex.Message);
            }

            return respone;
        }
        public Response CapNhatKhachHang(KhachHang KhachHang)
        {
            Response respone = new Response();
            try
            {
                db.KhachHang.Attach(KhachHang);

                db.Entry(KhachHang).Property(p => p.Ten).IsModified = true;
                db.Entry(KhachHang).Property(p => p.DienThoai).IsModified = true;
                db.Entry(KhachHang).Property(p => p.Email).IsModified = true;
                db.Entry(KhachHang).Property(p => p.DiaChi).IsModified = true;

                int State = db.SaveChanges();
                respone = new Response(1, "Success");
                respone.Id = KhachHang.Id.ToString();
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
