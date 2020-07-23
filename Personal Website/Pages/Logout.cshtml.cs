using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace Personal_Website.Pages {

    public class LogoutModel : PageModel
    {
        
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

            return LocalRedirect(Url.Content("~/"));
        }

    }
}
