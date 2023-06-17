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
    public class QuyDinhController : ControllerBase
    {
        QuyDinhBUS _BUS;
        IConfiguration _config;
        public QuyDinhController(IConfiguration configuration)
        {
            _config = configuration;
            _BUS = new QuyDinhBUS();
        }
        [HttpGet]
        public IActionResult getAll()
        {


            List<QuyDinhModel> QuyDinhs = _BUS.LayDanhSachQuyDinh();

            Response response = new Response
            {
                Count = QuyDinhs.Count,
                Message = "Success",
                ResultCode = 0,
                data = QuyDinhs
            };
            return Ok(response);
        }
        [HttpGet("{Id}")]
        public IActionResult LayThongTinQuyDinh(int Id)
        {

            QuyDinhModel QuyDinh = _BUS.LayThongTinQuyDinh(Id);
            Response response = new Response
            {
                Count = 1,
                Message = "Success",
                ResultCode = 0,
                data = QuyDinh
            };
            return Ok(response);
        }
        [HttpDelete("{Id}")]
        public IActionResult XoaQuyDinh(int Id)
        {
            Response response = _BUS.XoaQuyDinh(Id);
            return Ok(response);
        }
        [HttpPost]
        public IActionResult ThemQuyDinh(QuyDinhModel QuyDinh)
        {

            Response response = _BUS.ThemQuyDinh(QuyDinh);

            return Ok(response);

        }
        [HttpPut]
        public IActionResult CapNhatQuyDinh(QuyDinhModel QuyDinh)
        {

            Response response = _BUS.CapNhatQuyDinh(QuyDinh);

            return Ok(response);

        }

    }
}
