using System;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Playlist.Data;
using Playlist.Models;

namespace Playlist {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddMvc().AddRazorPagesOptions(
                options => {
                    options.Conventions.AuthorizeFolder("/Playlists");
                    options.Conventions.AllowAnonymousToPage("/Playlists/Index");
                    options.Conventions.AllowAnonymousToFolder("/Playlists/Details");
                }
            );

            services.AddDbContext<PlaylistContext>(
                options => options.UseMySql(Configuration.GetConnectionString("DbConnection")));
            services.AddDbContext<IdentityContext>(
                options => options.UseMySql(Configuration.GetConnectionString("IdentityConnection")));

            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<IdentityContext>();

            services.Configure<IdentityOptions>(
                options => {
                    // Password settings
                    options.Password.RequireDigit           = true;
                    options.Password.RequiredLength         = 8;
                    options.Password.RequireNonAlphanumeric = true;
                    options.Password.RequireUppercase       = true;
                    options.Password.RequireLowercase       = true;

                    // Lockout settings
                    options.Lockout.DefaultLockoutTimeSpan  = TimeSpan.FromMinutes(30);
                    options.Lockout.MaxFailedAccessAttempts = 10;

                    // User settings
                    options.User.RequireUniqueEmail = true;
                });

            // If you want to tweak Identity cookies, they're no longer part of IdentityOptions.
            services.ConfigureApplicationCookie(options => options.LoginPath = "/Account/Login");

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(options => options.LoginPath = new PathString("/account/login"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }
            else {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc(
                routes => {
                    routes.MapRoute(
                        name: "default",
                        template: "{controller=Home}/{action=Index}/{id?}");
                });
        }
    }
}