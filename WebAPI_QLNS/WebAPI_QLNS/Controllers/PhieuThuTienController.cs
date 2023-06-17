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

    public class PhieuThuTienController : ControllerBase
    {
        PhieuThuTienBUS _BUS;
        IConfiguration _config;
        public PhieuThuTienController(IConfiguration configuration)
        {
            _config = configuration;
            _BUS = new PhieuThuTienBUS();
        }
        [HttpGet]
        public IActionResult getAll()
        {


            List<PhieuThuTienModel> PhieuThuTiens = _BUS.LayDanhSachPhieuThuTien();

            Response response = new Response
            {
                Count = PhieuThuTiens.Count,
                Message = "Success",
                ResultCode = 0,
                data = PhieuThuTiens
            };
            return Ok(response);
        }
        [HttpGet("{Id}")]
        public IActionResult LayThongTinPhieuThuTien(string Id)
        {

            PhieuThuTienModel PhieuThuTien = _BUS.LayThongTinPhieuThuTien(Id);
            Response response = new Response
            {
                Count = 1,
                Message = "Success",
                ResultCode = 0,
                data = PhieuThuTien
            };
            return Ok(response);
        }
        [HttpDelete("{Id}")]
        public IActionResult XoaPhieuThuTien(string Id)
        {
            Response response = _BUS.XoaPhieuThuTien(Id);
            return Ok(response);
        }
        [HttpPost]
        public IActionResult ThemPhieuThuTien(PhieuThuTienModel PhieuThuTien)
        {

            Response response = _BUS.ThemPhieuThuTien(PhieuThuTien);

            return Ok(response);

        }
        [HttpPut]
        public IActionResult CapNhatPhieuThuTien(PhieuThuTienModel PhieuThuTien)
        {

            Response response = _BUS.CapNhatPhieuThuTien(PhieuThuTien);

            return Ok(response);

        }
        [HttpPost("Timkiem")]
        public IActionResult TimPhieuThuTien(ThongtinTimPhieuThuModel phieuThuTien)
        {

            List <PhieuThuTienModel> phieuThuTiens = _BUS.TimPhieuThuTien(phieuThuTien);


            Response response = new Response
            {
                Count = phieuThuTiens.Count,
                Message = "Success",
                ResultCode = 0,
                data = phieuThuTiens
            };
            return Ok(response);

        }
        [HttpGet("Congno/{Id}")]
        public IActionResult LayCongNoKhachHang(int Id)
        {
            var response = _BUS.LayCongNoKhachHang(Id);
            return Ok(response);
        }
     }
}
