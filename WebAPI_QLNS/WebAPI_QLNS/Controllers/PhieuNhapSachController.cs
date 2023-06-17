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
    public class PhieuNhapSachController : ControllerBase
    {
        PhieuNhapSachBUS _BUS;
        IConfiguration _config;
        public PhieuNhapSachController(IConfiguration configuration)
        {
            _config = configuration;
            _BUS = new PhieuNhapSachBUS();
        }
        [HttpGet]
        public IActionResult getAll()
        {


            List<PhieuNhapSachModel> PhieuNhapSachs = _BUS.LayDanhSachPhieuNhapSach();

            Response response = new Response
            {
                Count = PhieuNhapSachs.Count,
                Message = "Success",
                ResultCode = 0,
                data = PhieuNhapSachs
            };
            return Ok(response);
        }
        [HttpGet("{Id}")]
        public IActionResult LayThongTinPhieuNhapSach(string Id)
        {

            PhieuNhapSachModel PhieuNhapSach = _BUS.LayThongTinPhieuNhapSach(Id);
            Response response = new Response
            {
                Count = 1,
                Message = "Success",
                ResultCode = 0,
                data = PhieuNhapSach
            };
            return Ok(response);
        }
        [HttpDelete("{Id}")]
        public IActionResult XoaPhieuNhapSach(string Id)
        {
            Response response = _BUS.XoaPhieuNhapSach(Id);
            return Ok(response);
        }
        [HttpPost]
        public IActionResult ThemPhieuNhapSach(PhieuNhapSachModel PhieuNhapSach)
        {

            Response response = _BUS.ThemPhieuNhapSach(PhieuNhapSach);

            return Ok(response);

        }
        [HttpPut]
        public IActionResult CapNhatPhieuNhapSach(PhieuNhapSachModel PhieuNhapSach)
        {

            Response response = _BUS.CapNhatPhieuNhapSach(PhieuNhapSach);

            return Ok(response);

        }

    }
}
