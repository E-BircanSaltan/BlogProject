using BlogProject.Api.Aspects;
using BlogProject.Api.Validation.FluentValidation;
using BlogProject.Business.Abstract;
using BlogProject.Entity.DTO.Login;
using BlogProject.Entity.Result;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ShoppingAPI.Api.Controllers
{
    [ApiController]
    [Route("[action")]
    public class AccountController : Controller
    {
        private readonly IUserServise _userService;
        private readonly IConfiguration _configuration;

        public AccountController(IUserServise userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost("/Login")]
        [ValidationFilter(typeof(LoginValidator))]
        public async Task<IActionResult> LoginAsync(LoginRequestDTO loginRequestDTO)
        {
            var user = await _userService.GetAsync((q => q.UserName == loginRequestDTO.KullaniciAdi && q.Password == loginRequestDTO.Sifre));


            if (user == null)
            {
                return NotFound(Sonuc<LoginResponseDTO>.SuccussNoDataFound());
            }
            else
            {
                var key = Encoding.UTF8.GetBytes(_configuration.GetValue<string>("AppSettings:JWTKey"));

                var claims = new List<Claim>();

                claims.Add(new Claim("KullaniciAdi", user.UserName));

                claims.Add(new Claim("KullaniciID", user.id.ToString()));

                claims.Add(new Claim("AdSoyad", user.FirstName + " " + user.LastName));



                var jwt = new JwtSecurityToken(
                    expires: DateTime.Now.AddDays(30),
                    notBefore: DateTime.Now,
                    claims: claims,
                    issuer: "https://asdasd.com",
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature));




                var token = new JwtSecurityTokenHandler().WriteToken(jwt);
                LoginResponseDTO loginResponseDTO = new()
                {
                    AdSoyad = user.FirstName + " " + user.LastName,
                    Token = token,
                };
                return Ok(Sonuc<LoginResponseDTO>.SuccussWithData(loginResponseDTO));
            }
        }
    }
}
