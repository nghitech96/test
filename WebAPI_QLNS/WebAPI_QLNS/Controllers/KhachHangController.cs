using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using WebAPI_QLNS.BUS;
using WebAPI_QLNS.DTO;
using WebAPI_QLNS.Models;

namespace WebAPI_QLNS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class KhachHangController : ControllerBase
    {
        KhachHangBUS _BUS;
        IConfiguration _config;
        public KhachHangController(IConfiguration configuration)
        {
            _config = configuration;
            _BUS = new KhachHangBUS();
        }
        [HttpGet]
        public IActionResult getAll()
        {


            List<KhachHangModel> KhachHangs = _BUS.LayDanhSachKhachHang();

            Response response = new Response
            {
                Count = KhachHangs.Count,
                Message = "Success",
                ResultCode = 0,
                data = KhachHangs
            };
            return Ok(response);
        }
        [HttpGet("{Id}")]
        public IActionResult LayThongTinKhachHang(int Id)
        {

            KhachHangModel KhachHang = _BUS.LayThongTinKhachHang(Id);
            Response response = new Response
            {
                Count = 1,
                Message = "Success",
                ResultCode = 0,
                data = KhachHang
            };
            return Ok(response);
        }
        [HttpDelete("{Id}")]
        public IActionResult XoaKhachHang(int Id)
        {
            Response response = _BUS.XoaKhachHang(Id);
            return Ok(response);
        }
        [HttpPost]
        public IActionResult ThemKhachHang(KhachHangModel KhachHang)
        {

            Response response = _BUS.ThemKhachHang(KhachHang);

            return Ok(response);

        }
        [HttpPost("Timkiem")]
        public IActionResult TimkiemKhachHang(KhachHangModel KhachHang)
        {

            Response response = _BUS.Timkiem(KhachHang);

            return Ok(response);

        }
        [HttpPut]
        public IActionResult CapNhatKhachHang(KhachHangModel KhachHang)
        {

            Response response = _BUS.CapNhatKhachHang(KhachHang);

            return Ok(response);

        }

    }
}
