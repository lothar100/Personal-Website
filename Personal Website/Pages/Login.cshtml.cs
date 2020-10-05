using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OtpNet;
using Personal_Website.Classes.Extensions;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Personal_Website.Pages {

    public class LoginModel : PageModel
    {

        private IConfiguration _configuration;

        public LoginModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IActionResult> OnGetAsync(string password, string code)
        {
            //clear the existing external cookie
            try
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            //verify 2fa code
            var secret = _configuration.GetValue<string>("Auth:Secret");
            var totp = new Totp(Base32Encoding.ToBytes(secret));

            if (code != totp.ComputeTotp().Encrypt())
            {
                return BadRequest("Invalid Code");
            }

            //verify password
            if (password != _configuration.GetValue<string>("Auth:Password"))
            {
                return BadRequest("Invalid Password");
            }

            //success, set claims identity now
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Role, "Admin"),
                new Claim(ClaimTypes.Name, _configuration.GetValue<string>("Auth:Username")),
                new Claim("secret", _configuration.GetValue<string>("Auth:Secret")),
                new Claim("issuer", _configuration.GetValue<string>("Auth:Issuer"))
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

            return LocalRedirect(Url.Content("~/"));
        }

    }
}
