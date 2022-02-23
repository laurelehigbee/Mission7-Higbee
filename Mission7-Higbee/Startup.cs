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
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStaticFiles();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "paging",
                    pattern: "Page{pageNum}",
                    defaults: new { Controller = "Home", action = "Index" }
                    );

                endpoints.MapDefaultControllerRoute(); //instructions for using endpoints
            });
        }
    }
}
