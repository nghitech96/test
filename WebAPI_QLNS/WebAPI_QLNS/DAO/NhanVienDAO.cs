using System.Collections.Generic;
using System.Linq;
using System;
using WebAPI_QLNS.DTO;
using System.Reflection.Metadata;

namespace WebAPI_QLNS.DAO
{
    public class NhanVienDAO
    {
        myDbContext db;
        public NhanVienDAO()
        {
            db = new myDbContext();
        }


        public List<NhanVien> LayDanhSachNhanVien()
        {
            List<NhanVien> nhanviens = new List<NhanVien>();   
            
            try
            {
                nhanviens = db.NhanVien.ToList();
                if (nhanviens != null)
                    throw new Exception("Not Found");
                
            }
            catch (Exception ex)
            {
                
            }


            return nhanviens;
        }
        //public Response Convert()
        
        public NhanVien LayThongTinNhanVien(int NhanVienId)
        {
            
                var nhanvien = db.NhanVien
                   .Where(e => e.Id == NhanVienId).FirstOrDefault();

            return nhanvien;
        }
        public Response XoaNhanVien(int NhanVienId)
        {
            Response response = new Response();
            NhanVien p = new NhanVien();

            try
            {
                p = db.NhanVien.FirstOrDefault(x => x.Id == NhanVienId);
                if (p == null)
                {
                    throw new Exception("Not found");
                }
                db.NhanVien.Remove(p);
                db.SaveChanges();
                response = new Response(0, "Success");
                response.Id = NhanVienId.ToString();
                response.Count = 1;
            }
            catch (System.Exception ex)
            {

                response = new Response(-1, ex.Message);
            }
            return response;
        }

        public Response TimNhanVien(NhanVien NhanVien)
        {
            Response response = new Response(-1);
            List<NhanVien> nhanviens = new List<NhanVien>();
            try
            {
                nhanviens = db.NhanVien.Where(n => (
                    (n.TenNhanVien.Contains(NhanVien.TenNhanVien) && n.SoDT == NhanVien.SoDT && n.Email == NhanVien.Email && !string.IsNullOrEmpty(NhanVien.TenNhanVien)) // Tìm theo tên, sodt, email
                    ||(!string.IsNullOrEmpty(NhanVien.TenNhanVien) && !string.IsNullOrEmpty(NhanVien.SoDT) && string.IsNullOrEmpty(NhanVien.Email) && n.TenNhanVien.Contains(NhanVien.TenNhanVien) && n.SoDT == NhanVien.SoDT) //Tim theo ten, sodt
                    || (!string.IsNullOrEmpty(NhanVien.TenNhanVien) && string.IsNullOrEmpty(NhanVien.SoDT) && !string.IsNullOrEmpty(NhanVien.Email) && n.TenNhanVien.Contains(NhanVien.TenNhanVien) && n.Email == NhanVien.Email) //Tim theo ten, email
                    || (string.IsNullOrEmpty(NhanVien.TenNhanVien) && !string.IsNullOrEmpty(NhanVien.SoDT) && !string.IsNullOrEmpty(NhanVien.Email) && n.SoDT == NhanVien.SoDT && n.Email == NhanVien.Email) //Tim theo Sodt, email
                    || (!string.IsNullOrEmpty(NhanVien.TenNhanVien) && string.IsNullOrEmpty(NhanVien.SoDT) && string.IsNullOrEmpty(NhanVien.Email) && n.TenNhanVien.Contains(NhanVien.TenNhanVien) ) //Tim theo ten
                    || (string.IsNullOrEmpty(NhanVien.TenNhanVien) && !string.IsNullOrEmpty(NhanVien.SoDT) && string.IsNullOrEmpty(NhanVien.Email) && n.SoDT == NhanVien.SoDT) // tim theo sodt
                    || (string.IsNullOrEmpty(NhanVien.TenNhanVien) && string.IsNullOrEmpty(NhanVien.SoDT) && !string.IsNullOrEmpty(NhanVien.Email) && n.Email == NhanVien.Email) // tim theo email
                )).ToList();

                if (nhanviens!=null)
                {
                    response = new Response
                    {
                        ResultCode = 0,
                        Message = "Success",
                        Id = NhanVien.Id.ToString(),
                        Count = nhanviens.Count,
                        data = nhanviens
                    };

                }
                
            }
            catch (System.Exception ex)
            {

                response = new Response(-1, ex.Message);
            }

            return response;
        }
        public Response ThemNhanVien(NhanVien NhanVien)
        {
            Response response = new Response();
            try
            {
                db.NhanVien.Add(NhanVien);
                int State = db.SaveChanges();
                response = new Response(1, "Success");
                response.Id = NhanVien.Id.ToString();
                response.Count = 1;
            }
            catch (System.Exception ex)
            {

                response = new Response(-1, ex.Message);
            }

            return response;
        }
        public Response CapNhatNhanVien(NhanVien NhanVien)
        {
            Response response = new Response();
            try
            {
                db.NhanVien.Attach(NhanVien);

                db.Entry(NhanVien).Property(p => p.TenNhanVien).IsModified = true;
                db.Entry(NhanVien).Property(p => p.ChucVu).IsModified = true;
                db.Entry(NhanVien).Property(p => p.SoDT).IsModified = true;
                db.Entry(NhanVien).Property(p => p.Email).IsModified = true;

                int State = db.SaveChanges();
                response = new Response(1, "Success");
                response.Id = NhanVien.Id.ToString() ;
                response.Count = 1;
            }
            catch (System.Exception ex)
            {

                response = new Response(-1, ex.Message);
            }

            return response;
        }
    }
}
