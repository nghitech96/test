using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_QLNS.BUS;
using WebAPI_QLNS.DAO;
using WebAPI_QLNS.DTO;

namespace WebAPI_QLNS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class ThongKeBaoCaoController : ControllerBase
    {
        ThongKeBaoCaoBUS _bus = new ThongKeBaoCaoBUS();


        [HttpPost("BaoCaoCongNo")]
        public IActionResult BaoCaoCongNo(ThongtinThongke thongtin)
        {

            Response response = new DTO.Response(-1,"Error");
            var datas = _bus.BaoCaoCongNo(thongtin.Thang, thongtin.Nam, thongtin.Id);

            if (datas!=null)
            {
                response = new Response
                {
                    ResultCode = 0,
                    Message="Succcess",
                    Count = datas.Count,
                    data=datas,
                    Id="1"
                };
            }
            

            return Ok(response);
        }
        [HttpPost("BaoCaoNhapXuat")]
        public IActionResult BaoCaoNhapXuat(ThongtinThongke thongtin)
        {
            Response response = new DTO.Response(-1, "Error");
            var datas = _bus.BaoCaoNhapXuat(thongtin.Thang, thongtin.Nam, thongtin.Id);
            if (datas != null)
            {
                response = new Response
                {
                    ResultCode = 0,
                    Message = "Succcess",
                    Count = datas.DS.Count,
                    data = datas,
                    Id = "1"
                };
            }

            return Ok(response);
        }
    }
}
