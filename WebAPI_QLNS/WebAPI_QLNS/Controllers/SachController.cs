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
    public class SachController : ControllerBase
    {
        SachBUS _BUS;
        IConfiguration _config;
        public SachController(IConfiguration configuration)
        {
            _config = configuration;
            _BUS = new SachBUS();
        }
        [HttpGet]
        public IActionResult getAll()
        {


            List<SachModel> Sachs = _BUS.LayDanhSachSach();

            Response response = new Response
            {
                Count = Sachs.Count,
                Message = "Success",
                ResultCode = 0,
                data = Sachs
            };
            return Ok(response);
        }
        [HttpGet("{Id}")]
        public IActionResult LayThongTinSach(int Id)
        {

            SachModel Sach = _BUS.LayThongTinSach(Id);
            Response response = new Response
            {
                Count = 1,
                Message = "Success",
                ResultCode = 0,
                data = Sach
            };
            return Ok(response);
        }
        [HttpDelete("{Id}")]
        public IActionResult XoaSach(int Id)
        {
            Response response = _BUS.XoaSach(Id);
            return Ok(response);
        }
        [HttpPost("Timkiem")]
        public IActionResult TimkiemSach(ThongtinTimSachModel ThongtinTimSach)
        {

            List<Sach> Sachs = _BUS.TimkiemSach(ThongtinTimSach);
            Response response = new Response
            {
                Count = Sachs.Count,
                Message = "Success",
                ResultCode = 0,
                data = Sachs
            };

            return Ok(response);

        }

        [HttpPost]
        public IActionResult ThemSach(SachModel Sach)
        {

            Response response = _BUS.ThemSach(Sach);

            return Ok(response);

        }
        [HttpPut]
        public IActionResult CapNhatSach(SachModel Sach)
        {

            Response response = _BUS.CapNhatSach(Sach);

            return Ok(response);

        }

    }
}
