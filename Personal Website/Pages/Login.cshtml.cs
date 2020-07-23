using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
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

        public async Task<IActionResult> OnGetAsync()
        {
            //clear the existing external cookie
            try
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
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
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return LocalRedirect(Url.Content("~/"));
        }

    }
}
