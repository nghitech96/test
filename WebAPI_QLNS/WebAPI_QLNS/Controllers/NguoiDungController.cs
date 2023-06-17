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
    public class NguoiDungController : ControllerBase
    {
        NguoiDungBUS _BUS=new NguoiDungBUS() ;
        IConfiguration _config;
        public NguoiDungController(IConfiguration configuration)
        {
            _config = configuration;
           

        }
        [HttpGet]
        public IActionResult getAll()
        {
            Response response = response = new Response
            {
                ResultCode = -1,
                Message = "No Data",
                Count = 0,
                Id = "0",
                data = null
            };
            List<NguoiDungModel> nguoidungmodel = _BUS.LayDanhSachNguoiDung();
            if (nguoidungmodel == null)
            {
                
                return BadRequest(response);
            }
            response = new Response
            {
                ResultCode = 0,
                Message = "Success",
                Count = nguoidungmodel.Count,
                Id = "0",
                data = nguoidungmodel
            };
            return Ok( response);
        }
        [HttpGet("{Id}")]
        public IActionResult LayThongtinNguoiDung(int Id)
        {
            NguoiDungModel response = _BUS.LayThongTinNguoiDung(Id);
            if (response == null)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpGet("login")]
        public IActionResult LayDanhSachNguoiDungDangNhap()
        {
            Response response = response = new Response
            {
                ResultCode = -1,
                Message = "No Data",
                Count = 0,
                Id = "0",
                data = null
            };
            List<NguoiDungDangnhapModel> nguoidungmodel = _BUS.LayDanhSachNguoiDungDangnhap();
            if (nguoidungmodel == null)
            {

                return BadRequest(response);
            }
            response = new Response
            {
                ResultCode = 0,
                Message = "Success",
                Count = nguoidungmodel.Count,
                Id = "0",
                data = nguoidungmodel
            };
            return Ok(response);
        }
        [HttpGet("login/{Id}")]
        public IActionResult LayThongtinNguoiDungDangnhap(int Id)
        {
            Response response = new Response();
            NguoiDungDangnhapModel nguoiDung = _BUS.LayThongTinNguoiDungDangNhap(Id);
            if (nguoiDung == null)
            {
                response = new Response { 
                ResultCode= -1,
                Message="Không thấy thông tin Người dùng",
                Count=0,
                Id="0",
                };
                return BadRequest(response);
            }
            response = new Response
            {
                ResultCode = 0,
                Message = "Success",
                Count = 1,
                Id = "0",
                data=nguoiDung
            };
            return Ok(response);
        }
        [HttpDelete("{Id}")]
        public IActionResult XoaNguoiDung(int Id)
        {
            Response response = _BUS.XoaNguoiDung(Id);
            if (response == null)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpPost("Timkiem")]
        public IActionResult TimNguoiDung(NguoiDungDangnhapModel nguoidung)
        {

            Response response = _BUS.TimNguoiDung(nguoidung);
            if (response == null)
            {
                return BadRequest(response);
            }
            return Ok(response);

        }
        [HttpPost]
        public IActionResult ThemNguoiDung(NguoiDungModel nguoidung)
        {

            Response response = _BUS.ThemNguoiDung(nguoidung);
            if (response == null)
            {
                return BadRequest(response);
            }
            return Ok(response);

        }
        [HttpPut]
        public IActionResult CapnhatNguoiDung(NguoiDungModel nguoidung)
        {

            Response response = _BUS.CapNhatNguoiDung(nguoidung);
            if (response == null)
            {
                return BadRequest(response);
            }
            return Ok(response);

        }


    }
}
