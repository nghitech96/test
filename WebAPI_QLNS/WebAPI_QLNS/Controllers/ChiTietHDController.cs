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
    public class ChiTietHDController : ControllerBase
    {
        ChiTietHDBUS _BUS;
        IConfiguration _config;
        public ChiTietHDController(IConfiguration configuration)
        {
            _config = configuration;
            _BUS = new ChiTietHDBUS();
        }
        [HttpGet]
        public IActionResult getAll()
        {


            List<ChiTietHoaDonModel>  ChiTietHDs = _BUS.LayDanhSachChiTietHoaDon();
            if (ChiTietHDs == null)
            {
                return BadRequest();
            }
            Response response = new Response
            {
                Count = ChiTietHDs.Count,
                Message = "Success",
                ResultCode = 0,
                data = ChiTietHDs
            };
            return Ok(response);
        }
        [HttpGet("{Id}")]
        public IActionResult LayThongTinChiTietHD(string Id)
        {

           List< ChiTietHoaDonModel> ChiTietHDs = _BUS.LayDanhSachChiTietHoaDon(Id);
            if (ChiTietHDs == null)
            {
                return BadRequest();
            }
            Response response = new Response
            {
                Count = 1,
                Message = "Success",
                ResultCode = 0,
                data = ChiTietHDs
            };
            return Ok(response);
        }
        [HttpPost("Info")]
        public IActionResult LayThongTinChiTietHD(ChiTietHoaDonModel ChiTietHD)
        {

            Response response = _BUS.LayThongTinChiTietHoaDon(ChiTietHD);
            if (response == null)
            {
                return BadRequest(response);
            }
            return Ok(response);

        }

        [HttpDelete("{Id}")]
        public IActionResult XoaDanhsachChiTietHD(string Id)
        {
            Response response = _BUS.XoaDanhsachChiTietHoaDon(Id);
            if (response == null)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpPost("Delete")]
        public IActionResult XoaChiTietHD(ChiTietHoaDonModel ChiTietHD)
        {

            Response response = _BUS.XoaChiTietHoaDon(ChiTietHD);
            if (response == null)
            {
                return BadRequest(response);
            }
            return Ok(response);

        }
        [HttpPost]
        public IActionResult ThemChiTietHD(ChiTietHoaDonModel ChiTietHD)
        {

            Response response = _BUS.ThemChiTietHoaDon(ChiTietHD);
            if (response == null)
            {
                return BadRequest(response);
            }
            return Ok(response);

        }
        [HttpPut]
        public IActionResult CapNhatChiTietHD(ChiTietHoaDonModel ChiTietHD)
        {

            Response response = _BUS.CapNhatChiTietHoaDon(ChiTietHD);
            if (response == null)
            {
                return BadRequest();
            }
            return Ok(response);

        }

    }
}
