using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Personal_Website.Data.Models;
using System.Threading.Tasks;

namespace Personal_Website.Controllers {

    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : Controller {

        readonly IConfiguration _configuration;

        public AdminController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("[action]")]
        public IActionResult CheckPassword(AuthModel admin)
        {
            //check password
            if (admin.Code != _configuration.GetValue<string>("AdminSettings:Password"))
            {
                return BadRequest("Invalid Password");
            }

            return Ok();
        }

    }
}
