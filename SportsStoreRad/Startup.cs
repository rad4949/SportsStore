using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SportsStoreRad.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace SportsStoreRad
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }
        public Startup(IWebHostEnvironment hostEnv)
        {
            DBConnect connect = new DBConnect();
            FileStream fs = new FileStream("DBConnectString.json", FileMode.OpenOrCreate);
            JsonSerializer.SerializeAsync<DBConnect>(fs, connect);
            fs.Close();

            fs = new FileStream("DBConnectString.json", FileMode.OpenOrCreate);
            Configuration = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonStream(fs).Build();
            fs.Close();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<DbUser, DbRole>(options =>
            {
                options.Stores.MaxLengthForKeys = 128;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 5;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<IProductRepository, EFProductRepository>();
            services.AddTransient<IOrderRepository, EFOrderRepository>();
            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddControllersWithViews();
            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            try
            {
                if (!env.IsDevelopment())
                {
                    throw new Exception();
                }
                app.UseDeveloperExceptionPage();
            }
            catch (Exception ex)
            {
                app.Run(async (context) =>
                {
                    await context.Response.WriteAsync($"Error = {ex.Message}");
                });
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseStatusCodePages();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{Id?}");
               
                endpoints.MapControllerRoute(
                   name: "default",
                   pattern: "{controller=Cart}/{action=AddToCart}/{Id?}");

                endpoints.MapControllerRoute(
                   name: "default",
                   pattern: "{controller=Cart}/{action=Index}/{Id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Admin}/{action=Index}/{Id?}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Error}/{Id?}");

            });

            using (var scope = app.ApplicationServices.CreateScope())
            {
                ApplicationDbContext content = scope.ServiceProvider.GetService<ApplicationDbContext>();
                SeedData.Initial(content);
            }
            IdentitySeedData.SeedDataIdentity(app.ApplicationServices, env, this.Configuration);
        }
    }
}
