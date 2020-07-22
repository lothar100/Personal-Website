using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Personal_Website.Data.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Personal_Website.Controllers {

    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : Controller {

        IConfiguration _configuration;

        public AdminController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(AdminModel admin)
        {
            //clear the existing external cookie
            try
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            //check password
            if (admin.Password != _configuration.GetValue<string>("AdminSettings:Password"))
            {
                return BadRequest("Invalid Password");
            }

            //success, set claims identity now
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, _configuration.GetValue<string>("AdminSettings:Username")),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true,
                RedirectUri = this.Request.Host.Value,
                ExpiresUtc = DateTime.UtcNow.AddDays(7)
            };

            try
            {
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("/");
        }

        private (string url, string error) ResponseTest(string url, string error)
        {
            return (url, error);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Logout()
        {
            //clear the existing external cookie
            try
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("/");
        }
    }
}
