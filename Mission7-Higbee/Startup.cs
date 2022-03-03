using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Mission7_Higbee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7_Higbee
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; } //initializes configuration variable
        public Startup(IConfiguration temp) //startup configuration
        {
            Configuration = temp;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<BookstoreContext>(options => //what to do when configuring the db
            {
                options.UseSqlite(Configuration["ConnectionStrings:BookstoreDbConnection"]);
            });
            services.AddScoped<IBookstoreRepository, EFBookstoreRepository>(); //adds repositories
            services.AddRazorPages();
            services.AddDistributedMemoryCache();
            services.AddSession();

            services.AddScoped<Cart>(x => SessionCart.GetCart(x));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IPurchaseRepository, EFPurchaseRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();

            app.UseSession();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("categorypage",
                pattern: "{bookCategory}/Page{pageNum}",
                new { Controller = "Home", action = "Index" });

                endpoints.MapControllerRoute("Paging",
                    pattern:"Page{pageNum}", new { 
                    Controller = "Home", action = "Index", pageNum=1 });

                endpoints.MapControllerRoute("category",
                    pattern: "{bookCategory}", 
                    new {Controller = "Home",action = "Index", pageNum = 1});

                endpoints.MapDefaultControllerRoute(); //instructions for using endpoints

                endpoints.MapRazorPages();
            });
        }
    }
}
