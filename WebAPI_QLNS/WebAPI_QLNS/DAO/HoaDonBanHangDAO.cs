using System.Collections.Generic;
using System.Linq;
using System;
using WebAPI_QLNS.DTO;
using WebAPI_QLNS.Models;
using System.Runtime.CompilerServices;

namespace WebAPI_QLNS.DAO
{
    public class HoaDonBanHangDAO
    {
        myDbContext db;
        public HoaDonBanHangDAO()
        {
            db = new myDbContext();
        }


        public List<HoaDonBanHang> LayDanhSachHoaDonBanHang()
        {
            Response response = new Response();
            List<HoaDonBanHang> dshoadon = new List<HoaDonBanHang>();
            try
            {
                dshoadon = db.HoaDonBanHang.ToList();
                if (dshoadon != null)
                    throw new Exception("Not Found");
                response = new Response { Count = 1, Id = "0", Message = "Success", data = dshoadon };
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
            return dshoadon;
        }
        //public Response Convert()

        public HoaDonBanHang LayThongTinHoaDonBanHang(string HoaDonBanHangId)
        {
            Response response = new Response();
            HoaDonBanHang hoadon = new HoaDonBanHang();
            try
            {
                 hoadon = db.HoaDonBanHang
                   .Where(e => e.Id == HoaDonBanHangId).FirstOrDefault();
                if (hoadon != null)
                    throw new Exception("Not Found");
                 //response = new Response { Count = 1, Id = HoaDonBanHangId, Message = "Success", data = hoadon };
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


            return hoadon;
        }
        public Response XoaHoaDonBanHang(string HoaDonBanHangId)
        {
            Response respone = new Response();
            HoaDonBanHang p = new HoaDonBanHang();

            try
            {
                p = db.HoaDonBanHang.FirstOrDefault(x => x.Id == HoaDonBanHangId);
                if (p == null)
                {
                    throw new Exception("Not found");
                }
                db.HoaDonBanHang.Remove(p);
                db.SaveChanges();
                respone = new Response(0, "Success");
                respone.Id = HoaDonBanHangId;
                respone.Count = 1;
            }
            catch (System.Exception ex)
            {

                respone = new Response(-1, ex.Message);
            }
            return respone;
        }

        public Response ThemHoaDonBanHang(HoaDonBanHang HoaDonBanHang)
        {
            Response respone = new Response();
            try
            {
                db.HoaDonBanHang.Add(HoaDonBanHang);
                int State = db.SaveChanges();
                respone = new Response(1, "Success");
                respone.Id = HoaDonBanHang.Id;
                respone.Count = 1;
            }
            catch (System.Exception ex)
            {

                respone = new Response(-1, ex.Message);
            }

            return respone;
        }
        public Response CapNhatHoaDonBanHang(HoaDonBanHang HoaDonBanHang)
        {
            Response respone = new Response();
            try
            {
                db.HoaDonBanHang.Attach(HoaDonBanHang);

                db.Entry(HoaDonBanHang).Property(p => p.Ngay).IsModified = true;
                db.Entry(HoaDonBanHang).Property(p => p.IdKhachHang).IsModified = true;
                db.Entry(HoaDonBanHang).Property(p => p.ThanhTien).IsModified = true;

                int State = db.SaveChanges();
                respone = new Response(1, "Success");
                respone.Id = HoaDonBanHang.Id;
                respone.Count = 1;
            }
            catch (System.Exception ex)
            {

                respone = new Response(-1, ex.Message);
            }

            return respone;
        }
        public List<HoaDonBanHang> TimHoaDonBanHang(ThongtinTimHoaDonModel thongtin)
        {
            Response response = new Response();
            List<HoaDonBanHang> dshoadon = new List<HoaDonBanHang>();
            try
            {


                var kq1 = db.HoaDonBanHang.ToList();
                var kq2 =(from a in db.HoaDonBanHang
                          join b in db.KhachHang on a.IdKhachHang equals b.Id
                          select new  {
                              Id = a.Id,    
                              Ten=b.Ten,
                              DiaChi=b.DiaChi,
                              DienThoai=b.DienThoai,
                              Email=b.Email,
                              IdKhachHang = b.Id
                          }
                          )
                    .Where(x => (
                    !string.IsNullOrEmpty(thongtin.Ten) && !string.IsNullOrEmpty(thongtin.DiaChi) && x.Ten.Contains(thongtin.Ten) && x.DiaChi.Contains(thongtin.DiaChi) && x.Email == thongtin.Email && x.DienThoai == thongtin.DienThoai && x.Id == thongtin.MaHD // Tìm theo toàn bộ thông tin khách hàng
                    || !string.IsNullOrEmpty(thongtin.Ten) && string.IsNullOrEmpty(thongtin.DiaChi) && string.IsNullOrEmpty(thongtin.DienThoai) && string.IsNullOrEmpty(thongtin.Email) && string.IsNullOrEmpty(thongtin.MaHD) && x.Ten.Contains(thongtin.Ten)  // Tìm theo tên
                    || string.IsNullOrEmpty(thongtin.Ten) && !string.IsNullOrEmpty(thongtin.DiaChi) && string.IsNullOrEmpty(thongtin.DienThoai) && string.IsNullOrEmpty(thongtin.Email) && string.IsNullOrEmpty(thongtin.MaHD) && x.DiaChi.Contains(thongtin.DiaChi)  // Tìm theo Dịa chỉ
                    || string.IsNullOrEmpty(thongtin.Ten) && string.IsNullOrEmpty(thongtin.DiaChi) && string.IsNullOrEmpty(thongtin.DienThoai) && string.IsNullOrEmpty(thongtin.Email) && string.IsNullOrEmpty(thongtin.MaHD) && x.DienThoai.Contains(thongtin.DienThoai)  // Tìm theo điện thoại
                    || string.IsNullOrEmpty(thongtin.Ten) && string.IsNullOrEmpty(thongtin.DiaChi) && string.IsNullOrEmpty(thongtin.DienThoai) && !string.IsNullOrEmpty(thongtin.Email) && string.IsNullOrEmpty(thongtin.MaHD) && x.Email.Contains(thongtin.Email)  // Tìm theo email
                    || (string.IsNullOrEmpty(thongtin.Ten) && string.IsNullOrEmpty(thongtin.DiaChi) && string.IsNullOrEmpty(thongtin.DienThoai) && string.IsNullOrEmpty(thongtin.Email) && !string.IsNullOrEmpty(thongtin.MaHD) && x.Id == thongtin.MaHD )  // Tìm theo Ma Hoa don
                    || string.IsNullOrEmpty(thongtin.Ten) && string.IsNullOrEmpty(thongtin.DiaChi) && string.IsNullOrEmpty(thongtin.DienThoai) && string.IsNullOrEmpty(thongtin.Email) && string.IsNullOrEmpty(thongtin.MaHD)  && x.Ten.Contains(thongtin.Ten) && x.DiaChi.Contains(thongtin.DiaChi) // Tìm theo tên,Dịa chỉ
                    ))
                    .ToList();
                
                dshoadon =(from a in kq1
                           join b in kq2 on a.Id equals b.Id
                           select new HoaDonBanHang
                           {
                               Id=a.Id,
                               IdKhachHang=a.IdKhachHang,
                               ThanhTien=a.ThanhTien,
                               Ngay=a.Ngay
                           }
                           )
                           .ToList();
                if (dshoadon == null)
                    throw new Exception("Not Found");
                response = new Response { Count = dshoadon.Count, Id = "0", Message = "Success", data = dshoadon };
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
            return dshoadon;
        }
    }
}
