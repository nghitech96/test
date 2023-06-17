using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using WebAPI_QLNS.DTO;

namespace WebAPI_QLNS.DAO
{
    public class NguoiDungDAO
    {
        myDbContext db;
        public NguoiDungDAO()
        {
            db = new myDbContext();
        }
        

        public List<NguoiDung> LayDanhSachNguoiDung() { 
            return db.NguoiDung.ToList(); 
        }
        //public Response Convert()
        public Response DangNhap(string TaiKhoan, string MatKhau)
        {
            var nd = db.NguoiDung.Where(e => (e.TaiKhoan == TaiKhoan && e.MatKhau == MatKhau)).FirstOrDefault();
            if (nd == null)
            {
                return new Response
                {
                    ResultCode =-1,
                    Message="Not found",
                    Count = 0,
                    Id= "0",
                    data = "User / password not invalid"
                };
            }
           
            return new Response
            {
                ResultCode = 0,
                Message = "Success",
                Count = 1,
                Id = nd.NguoiDungId.ToString(),
                data=nd

            };
        }
        public List<NguoiDungDangnhap> LayDanhsachNguoiDungDangNhap()
        {

            var nd = (from a in db.NguoiDung
                      join b in db.NhanVien on a.NhanVienId equals b.Id
                      select new NguoiDungDangnhap
                      {
                          NguoiDungId = a.NguoiDungId,

                          TenNhanVien = b.TenNhanVien,
                          Email = b.Email,
                          SoDT = b.SoDT,
                          TaiKhoan = a.TaiKhoan,
                          VaiTroId = a.VaiTroId,
                          NhanVienId = a.NhanVienId,
                          MatKhau = a.MatKhau
                      }
                      ).ToList() ;

            return nd;
        }
        public NguoiDungDangnhap LayThongTinNguoiDungDangNhap(int NguoiDungId)
        {

            var nd = (from a in db.NguoiDung
                      join b in db.NhanVien on a.NhanVienId equals b.Id
                      select new NguoiDungDangnhap
                      {
                          NguoiDungId = a.NguoiDungId,
                          
                          TenNhanVien=b.TenNhanVien,
                          Email=b.Email,
                          SoDT=b.SoDT,
                          TaiKhoan=a.TaiKhoan,
                          VaiTroId = a.VaiTroId,
                          NhanVienId = a.NhanVienId
                      }
                      )
                    .Where(e => e.NguoiDungId==NguoiDungId).FirstOrDefault();

            return nd;
        }
        public NguoiDung LayThongTinNguoiDung(int NguoiDungId)
        {

            var nd = db.NguoiDung
                    .Where(e => e.NguoiDungId == NguoiDungId).FirstOrDefault();

            return nd;
        }
        public Response XoaNguoiDung(int NguoiDungId)
        {
            Response respone = new Response();
            NguoiDung p = new NguoiDung();
            
            try
            {
                p = db.NguoiDung.FirstOrDefault(x => x.NguoiDungId == NguoiDungId);
                if (p == null)
                {
                    throw new  Exception("Not found");
                }
                db.NguoiDung.Remove(p);
                db.SaveChanges();
                respone = new Response(0,"Success");
                respone.Id = NguoiDungId.ToString();
                respone.Count = 1;
            }
            catch (System.Exception ex)
            {

                respone = new Response(-1, ex.Message);
            }
            return respone;
        }
        public Response TimNguoiDung(NguoiDungDangnhap nguoiDung)
        {
            Response respone = new Response(-1);
            List<NguoiDungDangnhap> nguoidungs = new List<NguoiDungDangnhap>();
            try
            {
               
                var nd = (from a in db.NguoiDung
                          join b in db.NhanVien on a.NhanVienId equals b.Id
                          select new NguoiDungDangnhap
                          {
                              NguoiDungId = a.NguoiDungId,
                              NhanVienId = a.NhanVienId,
                              TenNhanVien = b.TenNhanVien,
                              Email = b.Email,
                              SoDT = b.SoDT,
                              TaiKhoan = a.TaiKhoan,
                              VaiTroId = a.VaiTroId
                          }
                          )
                        .Where(n => (
                        (n.TaiKhoan.Contains(nguoiDung.TaiKhoan) && n.TenNhanVien.Contains(nguoiDung.TenNhanVien) && n.SoDT == nguoiDung.SoDT && n.Email == nguoiDung.Email && !string.IsNullOrEmpty(nguoiDung.TenNhanVien) && !string.IsNullOrEmpty(n.TaiKhoan)) // Tìm theo tên, sodt, email, taikhoan
                    || (string.IsNullOrEmpty(n.TaiKhoan) && !string.IsNullOrEmpty(nguoiDung.TenNhanVien) && !string.IsNullOrEmpty(nguoiDung.SoDT) && string.IsNullOrEmpty(nguoiDung.Email) && n.TenNhanVien.Contains(nguoiDung.TenNhanVien) && n.SoDT == nguoiDung.SoDT) //Tim theo ten, sodt
                    || (string.IsNullOrEmpty(n.TaiKhoan) && !string.IsNullOrEmpty(nguoiDung.TenNhanVien) && string.IsNullOrEmpty(nguoiDung.SoDT) && !string.IsNullOrEmpty(nguoiDung.Email) && n.TenNhanVien.Contains(nguoiDung.TenNhanVien) && n.Email == nguoiDung.Email) //Tim theo ten, email
                    || (string.IsNullOrEmpty(n.TaiKhoan) && string.IsNullOrEmpty(nguoiDung.TenNhanVien) && !string.IsNullOrEmpty(nguoiDung.SoDT) && !string.IsNullOrEmpty(nguoiDung.Email) && n.SoDT == nguoiDung.SoDT && n.Email == nguoiDung.Email) //Tim theo Sodt, email
                    || (!string.IsNullOrEmpty(n.TaiKhoan) && string.IsNullOrEmpty(nguoiDung.TenNhanVien) && !string.IsNullOrEmpty(nguoiDung.SoDT) && string.IsNullOrEmpty(nguoiDung.Email) && n.SoDT == nguoiDung.SoDT && n.TaiKhoan.Contains(nguoiDung.TaiKhoan)) //Tim theo tai khoản, Sodt
                    || (string.IsNullOrEmpty(n.TaiKhoan) && !string.IsNullOrEmpty(nguoiDung.TenNhanVien) && string.IsNullOrEmpty(nguoiDung.SoDT) && string.IsNullOrEmpty(nguoiDung.Email) && n.TenNhanVien.Contains(nguoiDung.TenNhanVien)) //Tim theo ten
                    || (string.IsNullOrEmpty(n.TaiKhoan) && string.IsNullOrEmpty(nguoiDung.TenNhanVien) && !string.IsNullOrEmpty(nguoiDung.SoDT) && string.IsNullOrEmpty(nguoiDung.Email) && n.SoDT == nguoiDung.SoDT) // tim theo sodt
                    || (string.IsNullOrEmpty(n.TaiKhoan) && string.IsNullOrEmpty(nguoiDung.TenNhanVien) && string.IsNullOrEmpty(nguoiDung.SoDT) && !string.IsNullOrEmpty(nguoiDung.Email) && n.Email == nguoiDung.Email) // tim theo email
                    || (!string.IsNullOrEmpty(n.TaiKhoan) && string.IsNullOrEmpty(nguoiDung.TenNhanVien) && string.IsNullOrEmpty(nguoiDung.SoDT) && string.IsNullOrEmpty(nguoiDung.Email) && n.TaiKhoan.Contains(nguoiDung.TaiKhoan)) // tim theo tai khoan

                        )).ToList();
                if (nd.Count>0)
                {
                    nguoidungs = nd;
                }
                respone = new Response {
                    ResultCode = 0,
                    Message = "Success",
                    Id="",
                    Count = nguoidungs.Count,
                    data=nguoidungs
                };
                
            }
            catch (System.Exception ex)
            {

                respone = new Response(-1, ex.Message);
            }

            return respone;
        }
        public Response ThemNguoiDung(NguoiDung nguoiDung)
        {
            Response respone = new Response();
            try
            {
                db.NguoiDung.Add(nguoiDung);
                int State = db.SaveChanges();
                respone = new Response(1, "Success");
                respone.Id = nguoiDung.NguoiDungId.ToString();
                respone.Count = 1;
            }
            catch (System.Exception ex)
            {

                respone=new Response(-1,ex.Message);
            }

            return respone;
        }
        public Response CapNhatNguoiDung(NguoiDung nguoiDung)
        {
            Response respone = new Response();
            try
            {
                db.NguoiDung.Attach(nguoiDung);
                db.Entry(nguoiDung).Property(p=>p.TaiKhoan).IsModified=true;
                db.Entry(nguoiDung).Property(p=>p.MatKhau).IsModified=true;
                db.Entry(nguoiDung).Property(p=>p.VaiTroId).IsModified=true;
                db.Entry(nguoiDung).Property(p=>p.TrangThai).IsModified=true;

                int State = db.SaveChanges();
                respone = new Response(1, "Success");
                respone.Id = nguoiDung.NguoiDungId.ToString();
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
