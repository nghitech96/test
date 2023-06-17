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
    public class HoaDonBanHangController : ControllerBase
    {
        HoaDonBanHangBUS _BUS;
        IConfiguration _config;
        public HoaDonBanHangController(IConfiguration configuration)
        {
            _config = configuration;
            _BUS = new HoaDonBanHangBUS();
        }
        [HttpGet]
        public IActionResult getAll()
        {


            List<HoaDonBanHangModel> HoaDonBanHangs = _BUS.LayDanhSachHoaDonBanHang();

            Response response = new Response
            {
                Count = HoaDonBanHangs.Count,
                Message = "Success",
                ResultCode = 0,
                data = HoaDonBanHangs
            };
            return Ok(response);
        }
        [HttpGet("{Id}")]
        public IActionResult LayThongTinHoaDonBanHang(string Id)
        {

            HoaDonBanHangModel HoaDonBanHang = _BUS.LayThongTinHoaDonBanHang(Id);
            Response response = new Response
            {
                Count = 1,
                Message = "Success",
                ResultCode = 0,
                data = HoaDonBanHang
            };
            return Ok(response);
        }
        [HttpDelete("{Id}")]
        public IActionResult XoaHoaDonBanHang(string Id)
        {
            Response response = _BUS.XoaHoaDonBanHang(Id);
            return Ok(response);
        }
        [HttpPost("Timkiem")]
        public IActionResult TimHoaDonBanHang(ThongtinTimHoaDonModel thongtin)
        {

            List<HoaDonBanHangModel> HoaDonBanHangs = _BUS.TimHoaDonBanHang(thongtin);

            Response response = new Response
            {
                Count = HoaDonBanHangs.Count,
                Message = "Success",
                ResultCode = 0,
                data = HoaDonBanHangs
            };
            return Ok(response);

        }
        [HttpPost]
        public IActionResult ThemHoaDonBanHang(HoaDonBanHangModel HoaDonBanHang)
        {

            Response response = _BUS.ThemHoaDonBanHang(HoaDonBanHang);

            return Ok(response);

        }
        [HttpPut]
        public IActionResult CapNhatHoaDonBanHang(HoaDonBanHangModel HoaDonBanHang)
        {

            Response response = _BUS.CapNhatHoaDonBanHang(HoaDonBanHang);

            return Ok(response);

        }

    }
}
