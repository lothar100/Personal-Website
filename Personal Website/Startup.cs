
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Personal_Website.Data.Context;
using System.Net.Http;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using Personal_Website.Data.Services;
using Personal_Website.Classes;
using System.Net.Mail;
using System.Net;
using System;

namespace Personal_Website {
    public class Startup {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

            services.AddRazorPages();
            services.AddServerSideBlazor();

            services.AddDbContext<SqlDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("SqlDbContext"));
            });

            services.AddScoped<ModuleService>();
            services.AddScoped<BrowserResizeService>();
            services.AddScoped<SessionState>();

            services.AddHttpContextAccessor();
            services.AddScoped<HttpContextAccessor>();
            services.AddHttpClient();
            services.AddScoped<HttpClient>();

            services.AddScoped<SmtpClient>(setup =>
            {
                string server = Configuration.GetSection("SMTP")["Server"];
                int port = Convert.ToInt32(Configuration.GetSection("SMTP")["DefaultPort"]);
                string username = Configuration.GetSection("SMTP")["Username"];
                string password = Configuration.GetSection("SMTP")["Password"];

                SmtpClient smtpClient = new SmtpClient(server, port)
                {
                    Credentials = new NetworkCredential(username, password)
                };

                return smtpClient;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
