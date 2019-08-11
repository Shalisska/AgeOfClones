using Application.Data.Repositories;
using Application.Data.UnitsOfWork;
using Application.Interfaces;
using Application.Management.Interfaces;
using Application.Management.Services;
using Application.Services;
using Infrastructure.Data.EF;
using Infrastructure.Data.Repositories;
using Infrastructure.Data.UnitsOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sample.Models;

namespace AgeOfClones
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
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ClonesContextEF>(options => options.UseSqlServer(connection));
            //services.AddDbContext<NorthwindContext>(options => options
            //        .UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB; Database=Northwind; Trusted_Connection=True")
            //        .ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.QueryClientEvaluationWarning))
            //    );

            services.AddTransient<IProfileManagementService, ProfileManagementService>();
            services.AddTransient<IStockManagementService, StockManagementService>();
            services.AddTransient<ICurrencyManagementService, CurrencyManagementService>();
            services.AddTransient<IResourceManagementService, ResourceManagementService>();

            services.AddTransient<ITableEditorService, TableEditorService>();

            services.AddTransient<IProfileRepository, ProfileRepository>();
            services.AddTransient<IAccountManagementRepository, AccountRepository>();
            services.AddTransient<IStockRepository, StockRepository>();
            services.AddTransient<ICurrencyRepository, CurrencyRepository>();
            services.AddTransient<IResourceManagementRepository, ResourceRepository>();

            services.AddTransient<IResourceUOW, ResourceUOW>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                   name: "areas",
                   template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
