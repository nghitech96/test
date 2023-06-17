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
    public class VaiTroController : ControllerBase
    {
        VaiTroBUS _BUS;
        IConfiguration _config;
        public VaiTroController(IConfiguration configuration)
        {
            _config = configuration;
            _BUS = new VaiTroBUS();
        }
        [HttpGet]
        public IActionResult getAll()
        {


            List<VaiTroModel> VaiTros = _BUS.LayDanhSachVaiTro();

            Response response = new Response
            {
                Count = VaiTros.Count,
                Message = "Success",
                ResultCode = 0,
                data = VaiTros
            };
            return Ok(response);
        }
        [HttpGet("{Id}")]
        public IActionResult LayThongTinVaiTro(int Id)
        {

            VaiTroModel VaiTro = _BUS.LayThongTinVaiTro(Id);
            Response response = new Response
            {
                Count = 1,
                Message = "Success",
                ResultCode = 0,
                data = VaiTro
            };
            return Ok(response);
        }
        [HttpDelete("{Id}")]
        public IActionResult XoaVaiTro(int Id)
        {
            Response response = _BUS.XoaVaiTro(Id);
            return Ok(response);
        }
        [HttpPost]
        public IActionResult ThemVaiTro(VaiTroModel VaiTro)
        {

            Response response = _BUS.ThemVaiTro(VaiTro);

            return Ok(response);

        }
        [HttpPut]
        public IActionResult CapNhatVaiTro(VaiTroModel VaiTro)
        {

            Response response = _BUS.CapNhatVaiTro(VaiTro);

            return Ok(response);

        }

    }
}
