# Personal-Website
This is the code for my personal portfolio website, check it out!
The website is a .NET Core application built with Blazor.

### Admin Login / Security
This website is configured with basic Cookie Authentication following a two-factor login process.

###### `[Startup.cs]`
```cs
public void ConfigureServices(IServiceCollection services)
{
    services.Configure<CookiePolicyOptions>(options =>
    {
        options.CheckConsentNeeded = context => true;
        options.MinimumSameSitePolicy = SameSiteMode.None;
    });

    services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
    ...
}
```

###### `[Startup.cs]`
```cs
public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    ...
    app.UseCookiePolicy();
    app.UseAuthentication();
    ...
}
```

The App file begins with a <CascadingAuthenticationState> tag.
This tag will automatically update the underlying authentication state and broadcast that information to child elements.

###### `[App.razor]`
```
<CascadingAuthenticationState>
    <Router AppAssembly="@typeof(Program).Assembly">
        <Found Context="routeData">
            <AuthorizeRouteView RouteData="@routeData" DefaultLayout="@typeof(MainLayout)" />
        </Found>
        <NotFound>
            <LayoutView Layout="@typeof(MainLayout)">
                <p>Sorry, there's nothing at this address.</p>
            </LayoutView>
        </NotFound>
    </Router>
</CascadingAuthenticationState>
```

With the cascading authentication state in place an <AuthorizeView> tag can be used to display differing content depending on the user's authorization status.
In my website the login page will display the component for logging out if the state is authorized and display the sign-in form component when the state is not authorized.

###### `[AdminLogin.razor]`
```
...
<AuthorizeView>
    <Authorized>
        <LogoutAdminUser />
    </Authorized>
    <NotAuthorized>
        <EnterAdminPassword />
    </NotAuthorized>
</AuthorizeView>
...
```

###### Sign-in form step 1:
[![](https://tiny-img.com/images/custom-uploads/optimized/admin-password.png)]()

###### Sign-in form step 2:
[![](https://tiny-img.com/images/custom-uploads/optimized/admin-code.png)]()

After entering the password and two-factor code from my Google Authenticator app the form will submit to a GET action that handles and verifies the sign-in request.

**Unresolved design flaw:** The sign-in request should be handled by a POST action rather than a GET action. Using a GET action leaves path history with parameters in the browser. For now this is okay because sensitive information in the path is encrypted and the two-factor code is time sensitive. This only leaves a 30 second window of vulnerability on the browser that was used to successfuly sign-in. When using a POST action the authentication state was being stored by the HttpContext of the server and not the client. This would result in an unauthorized status following the redirect to the main page. I'm unsure if this is a flaw within Blazor or the way I've structured the request. (If you know how to resolve this issue please email me at pete.langevoort@gmail.com)

>**Sign-in Process:**\
>- Clear any existing external cookie\
>- Verify two-factor code\
>- Verify password\
>- If verification was successful, the user's identity profile will be created and consumed by Microsoft.AspNetCore.Authentication SignInAsync method.\

###### `[Login.cshtml.cs]`
```cs
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
```

Once the sign-in is authorized I am able to view my website with content editing controls that only appear in <Authorized> views.

>**Additional Information:**\
>- Only a single user exists and the verification credentials are stored in appsettings.Production.json
