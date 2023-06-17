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

    public class ChiTietPNController : ControllerBase
    {
        ChiTietNhapSachBUS _BUS;
        IConfiguration _config;
        public ChiTietPNController(IConfiguration configuration)
        {
            _config = configuration;
            _BUS = new ChiTietNhapSachBUS();
        }
        [HttpGet]
        public IActionResult getAll()
        {


                List<ChiTietNhapSachModel> ChiTietNhapSachs = _BUS.LayDanhSachChiTietNhapSach();

            Response response = new Response
            {
                Count = ChiTietNhapSachs.Count,
                Message = "Success",
                ResultCode = 0,
                data = ChiTietNhapSachs
            };
            return Ok(response);
        }
        [HttpGet("{Id}")]
        public IActionResult LayDanhsachChiTietNhapSach(string Id)
        {

            List<ChiTietNhapSachModel> ChiTietNhapSachs = _BUS.LayDanhsachChiTietNhapSach(Id);
            Response response = new Response
            {
                Count = 1,
                Message = "Success",
                ResultCode = 0,
                data = ChiTietNhapSachs
            };
            return Ok(response);
        }
        [HttpPost("Info")]
        public IActionResult LayThongTinChiTietNhapSach(ChiTietNhapSachModel ChiTietNhapSach)
        {

            ChiTietNhapSachModel ChiTietNhapSachs = _BUS.LayThongTinChiTietNhapSach(ChiTietNhapSach);
            Response response = new Response
            {
                Count = 1,
                Message = "Success",
                ResultCode = 0,
                data = ChiTietNhapSachs
            };
            return Ok(response);
        }
        [HttpDelete("{Id}")]
        public IActionResult XoaChiTietNhapSach(string Id)
        {
            Response response = _BUS.XoaChiTietNhapSach(Id);
            return Ok(response);
        }
        [HttpPost("Delete")]
        public IActionResult XoaChiTietNhapSach(ChiTietNhapSachModel ChiTietNhapSach)
        {

            Response response = _BUS.XoaChiTietNhapSach(ChiTietNhapSach);

            return Ok(response);

        }
        [HttpPost]
        public IActionResult ThemChiTietNhapSach(ChiTietNhapSachModel ChiTietNhapSach)
        {


            Response response = _BUS.ThemChiTietNhapSach(ChiTietNhapSach);

            return Ok(response);

        }
        [HttpPut]
        public IActionResult CapNhatChiTietNhapSach( ChiTietNhapSachModel ChiTietNhapSach)
        {

            Response response = _BUS.CapNhatChiTietNhapSach(ChiTietNhapSach);

            return Ok(response);

        }

    }
}
