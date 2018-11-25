using Application.Data.Repositories;
using Application.Data.UnitsOfWork;
using Application.Interfaces;
using Application.Management.Interfaces;
using Application.Management.Services;
using Application.Services;
using Infrastructure.Data.EF;
using Infrastructure.Data.Repositories;
using Infrastructure.Data.UnitsOfWork;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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

            services.AddTransient<IProfileManagementService, ProfileManagementService>();
            services.AddTransient<IStockManagementService, StockManagementService>();
            services.AddTransient<ICurrencyManagementService, CurrencyManagementService>();
            services.AddTransient<IResourceManagementService, ResourceManagementService>();


            services.AddTransient<IAuthorizationService, AuthorizationService>();

            services.AddTransient<ITableEditorService, TableEditorService>();

            services.AddTransient<IProfileRepository, ProfileRepository>();
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IStockRepository, StockRepository>();
            services.AddTransient<ICurrencyRepository, CurrencyRepository>();
            services.AddTransient<IResourceRepository, ResourceRepository>();

            services.AddTransient<IResourceUOW, ResourceUOW>();

            // установка конфигурации подключения
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => //CookieAuthenticationOptions
                {
                    options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Authorization/Index");
                });

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

            app.UseAuthentication();

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
