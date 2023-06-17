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
    public class TheLoaiController : ControllerBase
    {
        TheLoaiBUS _BUS;
        IConfiguration _config;
        public TheLoaiController(IConfiguration configuration)
        {
            _config = configuration;
            _BUS = new TheLoaiBUS();
        }
        [HttpGet]
        public IActionResult getAll()
        {


            List<TheLoaiModel> TheLoais = _BUS.LayDanhSachTheLoai();

            Response response = new Response
            {
                Count = TheLoais.Count,
                Message = "Success",
                ResultCode = 0,
                data = TheLoais
            };
            return Ok(response);
        }
        [HttpGet("{Id}")]
        public IActionResult LayThongTinTheLoai(int Id)
        {

            TheLoaiModel TheLoai = _BUS.LayThongTinTheLoai(Id);
            Response response = new Response
            {
                Count = 1,
                Message = "Success",
                ResultCode = 0,
                data = TheLoai
            };
            return Ok(response);
        }
        [HttpDelete("{Id}")]
        public IActionResult XoaTheLoai(int Id)
        {
            Response response = _BUS.XoaTheLoai(Id);
            return Ok(response);
        }
        [HttpPost]
        public IActionResult ThemTheLoai(TheLoaiModel TheLoai)
        {

            Response response = _BUS.ThemTheLoai(TheLoai);

            return Ok(response);

        }
        [HttpPut]
        public IActionResult CapNhatTheLoai(TheLoaiModel TheLoai)
        {

            Response response = _BUS.CapNhatTheLoai(TheLoai);

            return Ok(response);

        }

    }
}
