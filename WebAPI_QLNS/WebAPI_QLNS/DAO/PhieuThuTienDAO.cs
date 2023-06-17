using System.Collections.Generic;
using System.Linq;
using System;
using WebAPI_QLNS.DTO;
using WebAPI_QLNS.Models;

namespace WebAPI_QLNS.DAO
{
    public class PhieuThuTienDAO
    {
        myDbContext db;
        public PhieuThuTienDAO()
        {
            db = new myDbContext();
        }


        public List<PhieuThuTien> LayDanhSachPhieuThuTien()
        {
            
            Response response = new Response();
            List<PhieuThuTien> dsPhieuThutien = new List<PhieuThuTien>();
            try
            {
                dsPhieuThutien = db.PhieuThuTien.ToList();
                if (dsPhieuThutien != null)
                    throw new Exception("Not Found");
                response = new Response { Count = 1, Id = "0", Message = "Success", data = dsPhieuThutien };
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
            return dsPhieuThutien;
        }
        public List<PhieuThuTien> TimPhieuThuTien(ThongtinTimPhieuThuModel thongtin)
        {

            Response response = new Response();
            List<PhieuThuTien> dsPhieuThutien = new List<PhieuThuTien>();
            try
            {
                var kq1 = db.PhieuThuTien.ToList();

                var kq2 = (from a in db.PhieuThuTien
                           join b in db.KhachHang on a.IdKhachHang equals b.Id
                           select new
                           {
                               Id = a.Id,
                               Ten = b.Ten,
                               DiaChi = b.DiaChi,
                               DienThoai = b.DienThoai,
                               Email = b.Email,
                               IdKhachHang = b.Id
                           }
                          )
                    .Where(x => (
                    !string.IsNullOrEmpty(thongtin.Ten) && !string.IsNullOrEmpty(thongtin.DiaChi) && x.Ten.Contains(thongtin.Ten) && x.DiaChi.Contains(thongtin.DiaChi) && x.Email == thongtin.Email && x.DienThoai == thongtin.DienThoai && x.Id == thongtin.MaPhieu // Tìm theo toàn bộ thông tin khách hàng
                    || !string.IsNullOrEmpty(thongtin.Ten) && string.IsNullOrEmpty(thongtin.DiaChi) && string.IsNullOrEmpty(thongtin.DienThoai) && string.IsNullOrEmpty(thongtin.Email) && string.IsNullOrEmpty(thongtin.MaPhieu) && x.Ten.Contains(thongtin.Ten)  // Tìm theo tên
                    || string.IsNullOrEmpty(thongtin.Ten) && !string.IsNullOrEmpty(thongtin.DiaChi) && string.IsNullOrEmpty(thongtin.DienThoai) && string.IsNullOrEmpty(thongtin.Email) && string.IsNullOrEmpty(thongtin.MaPhieu) && x.DiaChi.Contains(thongtin.DiaChi)  // Tìm theo Dịa chỉ
                    || string.IsNullOrEmpty(thongtin.Ten) && string.IsNullOrEmpty(thongtin.DiaChi) && string.IsNullOrEmpty(thongtin.DienThoai) && string.IsNullOrEmpty(thongtin.Email) && string.IsNullOrEmpty(thongtin.MaPhieu) && x.DienThoai.Contains(thongtin.DienThoai)  // Tìm theo điện thoại
                    || string.IsNullOrEmpty(thongtin.Ten) && string.IsNullOrEmpty(thongtin.DiaChi) && string.IsNullOrEmpty(thongtin.DienThoai) && !string.IsNullOrEmpty(thongtin.Email) && string.IsNullOrEmpty(thongtin.MaPhieu) && x.Email.Contains(thongtin.Email)  // Tìm theo email
                    || (string.IsNullOrEmpty(thongtin.Ten) && string.IsNullOrEmpty(thongtin.DiaChi) && string.IsNullOrEmpty(thongtin.DienThoai) && string.IsNullOrEmpty(thongtin.Email) && !string.IsNullOrEmpty(thongtin.MaPhieu) && x.Id == thongtin.MaPhieu)  // Tìm theo Ma Phieu thu
                    || string.IsNullOrEmpty(thongtin.Ten) && string.IsNullOrEmpty(thongtin.DiaChi) && string.IsNullOrEmpty(thongtin.DienThoai) && string.IsNullOrEmpty(thongtin.Email) && string.IsNullOrEmpty(thongtin.MaPhieu) && x.Ten.Contains(thongtin.Ten) && x.DiaChi.Contains(thongtin.DiaChi) // Tìm theo tên,Dịa chỉ
                    ))
                    .ToList();

                dsPhieuThutien = (from a in kq1
                            join b in kq2 on a.Id equals b.Id
                            select new PhieuThuTien
                            {
                                Id = a.Id,
                                IdKhachHang = a.IdKhachHang,
                                Tien = a.Tien,
                                Ngay = a.Ngay
                            }
                           )
                           .ToList();

                if (dsPhieuThutien != null)
                    throw new Exception("Not Found");
                response = new Response { Count = dsPhieuThutien.Count, Id = "0", Message = "Success", data = dsPhieuThutien };
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
            return dsPhieuThutien;
        }
        //public Response Convert()

        public PhieuThuTien LayThongTinPhieuThuTien(string PhieuThuTienId)
        {
            Response response = new Response();
            PhieuThuTien phieuthu = new PhieuThuTien();
            try
            {
                phieuthu = db.PhieuThuTien
                    .Where(e => e.Id == PhieuThuTienId).FirstOrDefault();
                if (phieuthu != null)

                    throw new Exception("Not Found");
                response = new Response { Count = 1, Id = PhieuThuTienId, Message = "Success", data = phieuthu };
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


            return phieuthu;
        }
        public Response XoaPhieuThuTien(string PhieuThuTienId)
        {
            Response respone = new Response();
            PhieuThuTien p = new PhieuThuTien();

            try
            {
                p = db.PhieuThuTien.FirstOrDefault(x => x.Id == PhieuThuTienId);
                if (p == null)
                {
                    throw new Exception("Not found");
                }
                db.PhieuThuTien.Remove(p);
                db.SaveChanges();
                respone = new Response(0, "Success");
                respone.Id = PhieuThuTienId;
                respone.Count = 1;
            }
            catch (System.Exception ex)
            {

                respone = new Response(-1, ex.Message);
            }
            return respone;
        }

        public Response ThemPhieuThuTien(PhieuThuTien PhieuThuTien)
        {
            Response respone = new Response();
            try
            {
                db.PhieuThuTien.Add(PhieuThuTien);
                int State = db.SaveChanges();
                respone = new Response(1, "Success");
                respone.Id = PhieuThuTien.Id;
                respone.Count = 1;
            }
            catch (System.Exception ex)
            {

                respone = new Response(-1, ex.Message);
            }

            return respone;
        }
        public Response CapNhatPhieuThuTien(PhieuThuTien PhieuThuTien)
        {
            Response respone = new Response();
            try
            {
                db.PhieuThuTien.Attach(PhieuThuTien);

                db.Entry(PhieuThuTien).Property(p => p.Ngay).IsModified = true;
                db.Entry(PhieuThuTien).Property(p => p.Tien).IsModified = true;
                db.Entry(PhieuThuTien).Property(p => p.IdKhachHang).IsModified = true;

                int State = db.SaveChanges();
                respone = new Response(1, "Success");
                respone.Id = PhieuThuTien.Id;
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
