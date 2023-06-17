using Quanly_NhaSach.Helpers;
using Quanly_NhaSach.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPI_QLNS.Models;

namespace Quanly_NhaSach.BUS
{
    internal class test_Bus
    {
       public async Task<NguoiDungDangnhapModel> GetData(int Id)
        {
            ResponseModel rs1 = new ResponseModel();
           

           var  rs = await  LayThongTinNguoiDungDangnhap(Id);
            return rs;
        }
        ResponseModel rs = new ResponseModel();
        public  async Task<ResponseModel> Login(AccountModel account)
        {
            string url = $"token";


            var rs = await HttpHelper.Authentication(url, account);
            return rs;
        }
        public async Task<NguoiDungDangnhapModel> LayThongTinNguoiDungDangnhap(int Id)
        {
            string url = $"api/NguoiDung/login/{Id}";


            var rs = await HttpHelper.Get<NguoiDungDangnhapModel>(url);
            return rs;
        }


    }

}
 