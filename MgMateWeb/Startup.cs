using MgMateWeb.Interfaces.UtilsInterfaces;
using MgMateWeb.Interfaces.UtilsInterfaces.ControllerUtilsInterfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using MgMateWeb.Persistence.Entities;
using MgMateWeb.Persistence.Interfaces;
using MgMateWeb.Persistence.UnitOfWork;
using MgMateWeb.Utils;
using MgMateWeb.Utils.ControllerUtils;

namespace MgMateWeb
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

            #region DbContext and database connection

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection"),
                    b => b
                        .MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            #endregion

            #region Custom interfaces

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAccompanyingSymptomsControllerUtils, AccompanyingSymptomsControllerUtils>();
            services.AddScoped<ICustomMapper, CustomMapper>();

            #endregion

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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
