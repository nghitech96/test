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
    public class TacGiaController : ControllerBase
    {
        TacGiaBUS _BUS;
        IConfiguration _config;
        public TacGiaController(IConfiguration configuration)
        {
            _config = configuration;
            _BUS = new TacGiaBUS();
        }
        [HttpGet]
        public IActionResult getAll()
        {


            List<TacGiaModel> TacGias = _BUS.LayDanhSachTacGia();

            Response response = new Response
            {
                Count = TacGias.Count,
                Message = "Success",
                ResultCode = 0,
                data = TacGias
            };
            return Ok(response);
        }
        [HttpGet("{Id}")]
        public IActionResult LayThongTinTacGia(int Id)
        {

            TacGiaModel TacGia = _BUS.LayThongTinTacGia(Id);
            Response response = new Response
            {
                Count = 1,
                Message = "Success",
                ResultCode = 0,
                data = TacGia
            };
            return Ok(response);
        }
        [HttpDelete("{Id}")]
        public IActionResult XoaTacGia(int Id)
        {
            Response response = _BUS.XoaTacGia(Id);
            return Ok(response);
        }
        [HttpPost]
        public IActionResult ThemTacGia(TacGiaModel TacGia)
        {

            Response response = _BUS.ThemTacGia(TacGia);

            return Ok(response);

        }
        [HttpPut]
        public IActionResult CapNhatTacGia(TacGiaModel TacGia)
        {

            Response response = _BUS.CapNhatTacGia(TacGia);

            return Ok(response);

        }

    }
}
