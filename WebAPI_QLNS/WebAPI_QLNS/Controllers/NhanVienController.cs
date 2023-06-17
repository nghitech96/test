using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using WebAPI_QLNS.BUS;
using WebAPI_QLNS.DAO;
using WebAPI_QLNS.DTO;
using WebAPI_QLNS.Models;

namespace WebAPI_QLNS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NhanVienController : ControllerBase
    {
        NhanVienBUS _BUS;
        IConfiguration _config;
        public NhanVienController(IConfiguration configuration)
        {
            _config = configuration;
            _BUS = new NhanVienBUS();
        }
        [HttpGet]
        public IActionResult getAll()
        {
            
            
            List<NhanVienModel> nhanViens = _BUS.LayDanhSachNhanVien();
            
            Response response = new Response
            {
                Count= nhanViens.Count,
                Message="Success",
                ResultCode=0,
                data=nhanViens
            };
            return Ok(response);
        }
        [HttpGet("{Id}")]
        public IActionResult LayThongTinNhanVien(int Id)
        {
            
            NhanVienModel nhanVien = _BUS.LayThongTinNhanVien(Id);
            Response response = new Response
            {
                Count =1,
                Message = "Success",
                ResultCode = 0,
                data = nhanVien
            };
            return Ok(response);
        }
        [HttpDelete("{Id}")]
        public IActionResult XoaNhanVien(int Id)
        {
            Response response = _BUS.XoaNhanVien(Id);
            return Ok(response);
        }
        [HttpPost]
        public IActionResult ThemNhanVien(NhanVienModel NhanVien)
        {

            Response response = _BUS.ThemNhanVien(NhanVien);

            return Ok(response);

        }
        [HttpPost("Timkiem")]
        public IActionResult TimNhanVien(NhanVienModel NhanVien)
        {

            Response response = _BUS.TimNhanVien(NhanVien);

            return Ok(response);

        }
        [HttpPut]
        public IActionResult CapNhatNhanVien(NhanVienModel NhanVien)
        {

            Response response = _BUS.CapNhatNhanVien(NhanVien);
           
            return Ok(response);

        }
        
        

    }
}
