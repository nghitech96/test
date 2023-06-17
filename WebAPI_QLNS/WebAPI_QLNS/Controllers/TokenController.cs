using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.Text;
using System;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using WebAPI_QLNS.DTO;
using WebAPI_QLNS.DAO;
using WebAPI_QLNS.Models;

namespace WebAPI_QLNS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        public IConfiguration Configuration { get; }

        NguoiDungDAO _BUS=new NguoiDungDAO() ;
        public TokenController(IConfiguration configuration)
        {
            this.Configuration = configuration;
            
        }
        [Route("/token")]

        [HttpPost]
        public IActionResult Create(AccountModel account)
        {
            string tokenString = null;
            NguoiDungDangnhap nv = new NguoiDungDangnhap(); //{ 
            
            //    TaiKhoan= account.UserName., MatKhau =account.Password,Email="dsds@gmail.com",NguoiDungId=1,
            //    TenNhanVien="Nguyễn Duy Mạnh"
            //};
            try
            {
                if (string.IsNullOrEmpty(account.UserName))
                {
                    throw new Exception("UserName is null");
                }

                Response rp = _BUS.DangNhap(account.UserName, account.Password);
                if (rp.Count == 0)
                {
                    throw new Exception("Username/Password invalid");
                }

                NguoiDung nd = new NguoiDung();
                nd.NguoiDungId = int.Parse(rp.Id);

                //_BUS.Convert(rp.dataset.Tables[0].Rows[0], ref nd);
                 nv = _BUS.LayThongTinNguoiDungDangNhap(nd.NguoiDungId);
                if (nv == null)
                {
                    throw new Exception("Username/Password invalid");
                }
                //_BUS.Convert(rp.dataset.Tables[0].Rows[0], ref nv);
                tokenString = GenerateToken(nv);
            }
            catch (Exception ex)
            {

                return Ok(new Response
                {
                    ResultCode = -1,
                    Message = ex.Message,
                    data = ex.Message
                });
            }

            return Ok(new Response
            {
                ResultCode = 0,
                Id = nv.NguoiDungId.ToString() ,
                Count = 1,
                Message = "Success",
                data = tokenString
            }); ;
        }

        private bool IsValidUserAndPasswordCombination(string username, string password)
        {
            if (string.IsNullOrEmpty(username))
            {
                return false;
            }

            Response rp = _BUS.DangNhap(username, password);
            if (rp.Count > 0)
            {
                return true;
            }
            return false;
        }

        private string GenerateToken(NguoiDungDangnhap nd)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var secretKey = Configuration["Jwt:Key"];
            var secretKeyBytes = Encoding.UTF8.GetBytes(secretKey);

            var tokenDesciption = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Email,nd.Email),
                    new Claim(ClaimTypes.Name,nd.TenNhanVien),
                    new Claim("UserNAme",nd.TaiKhoan),
                    new Claim("Id",nd.NguoiDungId.ToString()),


                    new Claim("TokenId",Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(65), // Thởi gian sống của token
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey
                (secretKeyBytes), SecurityAlgorithms.HmacSha512Signature)
            };
            var token = jwtTokenHandler.CreateToken(tokenDesciption);

            return jwtTokenHandler.WriteToken(token);
        }
    }
}
