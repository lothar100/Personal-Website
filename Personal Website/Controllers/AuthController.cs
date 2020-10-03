using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OtpNet;
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
            //check 2fa code
            var secret = _configuration.GetValue<string>("AdminSettings:Secret");
            var totp = new Totp(Base32Encoding.ToBytes(secret));

            if (auth.Code != totp.ComputeTotp())
            {
                return BadRequest("Invalid Code");
            }

            return Ok();
        }

    }
}
