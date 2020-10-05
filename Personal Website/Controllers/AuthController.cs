using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OtpNet;
using Personal_Website.Classes.Extensions;
using Personal_Website.Data.Models;
using System.Threading.Tasks;

namespace Personal_Website.Controllers {

    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller {

        readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("[action]")]
        public IActionResult CheckPassword(AuthModel auth)
        {
            if (auth.Password.Encrypt() != _configuration.GetValue<string>("Auth:Password"))
            {
                return BadRequest("Invalid Password");
            }

            return Ok();
        }

        [HttpPost("[action]")]
        public IActionResult CheckCode(AuthModel auth)
        {
            string secret = _configuration.GetValue<string>("Auth:Secret");
            Totp totp = new Totp(Base32Encoding.ToBytes(secret));

            if (auth.Code != totp.ComputeTotp())
            {
                return BadRequest("Invalid Code");
            }

            return Ok();
        }

    }
}
