using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Project.Models;
using Project.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {   
            services.AddControllersWithViews();

            // Configur Database
            services.AddDbContext<Context>(
                options => options.UseSqlServer
                (Configuration.GetConnectionString("cs"))
                );

            // Inject UserManager - SignInManager - RoleManager
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<Context>();

            // Configur Session Remove After 30 Minutes
            services.AddSession(configure =>
            {
                configure.IdleTimeout = TimeSpan.FromMinutes(30);
            });
            //services.AddSession(configure => configure.IdleTimeout = TimeSpan.FromMinutes(30));


            // register MyServices
            // Add My Classes To Ioc Container to enable (resolve) Inject when need it
            services.AddScoped<IInstructorRepository, InstructorRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //env.IsEnvironment("Stage1")
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // Handel Stats Code in Production Or Staging
                //app.UseStatusCodePagesWithRedirects("/Home/Error");
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            // Add Session to MiddleWare
            app.UseSession();

            // Add Authentication
            app.UseAuthentication();

            app.UseAuthorization();

            // Custom middleware to prevent authenticated users from accessing the login page
            app.Use(async (context, next) =>
            {
                if(
                (context.Request.Path.StartsWithSegments("/Account/Login")
                ||
                context.Request.Path.StartsWithSegments("/Account/Register"))
                && 
                context.User.Identity.IsAuthenticated)
                {
                    context.Response.Redirect("/");
                }
                else
                {
                    await next();
                }
            });


            app.UseEndpoints(endpoints =>
            {
/*                endpoints.MapControllerRoute(
                    name:"Gomaa",
                    pattern: "Gomaa/{id:alpha}", // Constrain on Route
                    defaults: new { controller ="Department", action="Index"}
                    );*/
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
