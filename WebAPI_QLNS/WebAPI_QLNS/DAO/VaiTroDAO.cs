using System.Collections.Generic;
using System.Linq;
using System;
using WebAPI_QLNS.DTO;

namespace WebAPI_QLNS.DAO
{
    public class VaiTroDAO
    {
        myDbContext db;
        public VaiTroDAO()
        {
            db = new myDbContext();
        }


        public List<VaiTro> LayDanhSachVaiTro()
        {
            Response response = new Response();
            List<VaiTro> dsVaiTro = new List<VaiTro>();
            try
            {
                dsVaiTro = db.VaiTro.ToList();
                if (dsVaiTro != null)
                    throw new Exception("Not Found");
                response = new Response { Count = 1, Id = "0", Message = "Success", data = dsVaiTro };
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
            return dsVaiTro;
        }
        //public Response Convert()

        public VaiTro LayThongTinVaiTro(int VaiTroId)
        {

            Response response = new Response();
            VaiTro VaiTro = new VaiTro();
            try
            {
                VaiTro = db.VaiTro
                   .Where(e => e.Id == VaiTroId).FirstOrDefault();
                if (VaiTro != null)
                    throw new Exception("Not Found");
                response = new Response { Count = 1, Id = VaiTroId.ToString(), Message = "Success", data = VaiTro };
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


            return VaiTro;
        }
        public Response XoaVaiTro(int VaiTroId)
        {
            Response respone = new Response();
            VaiTro p = new VaiTro();

            try
            {
                p = db.VaiTro.FirstOrDefault(x => x.Id == VaiTroId);
                if (p == null)
                {
                    throw new Exception("Not found");
                }
                db.VaiTro.Remove(p);
                db.SaveChanges();
                respone = new Response(0, "Success");
                respone.Id = VaiTroId.ToString();
                respone.Count = 1;
            }
            catch (System.Exception ex)
            {

                respone = new Response(-1, ex.Message);
            }
            return respone;
        }

        public Response ThemVaiTro(VaiTro VaiTro)
        {
            Response respone = new Response();
            try
            {
                db.VaiTro.Add(VaiTro);
                int State = db.SaveChanges();
                respone = new Response(1, "Success");
                respone.Id = VaiTro.Id.ToString();
                respone.Count = 1;
            }
            catch (System.Exception ex)
            {

                respone = new Response(-1, ex.Message);
            }

            return respone;
        }
        public Response CapNhatVaiTro(VaiTro VaiTro)
        {
            Response respone = new Response();
            try
            {
                db.VaiTro.Attach(VaiTro);

                db.Entry(VaiTro).Property(p => p.TenVaiTro).IsModified = true;

                int State = db.SaveChanges();
                respone = new Response(1, "Success");
                respone.Id = VaiTro.Id.ToString();
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
