using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PizzaApp.Models;
using PizzaApp.Models.IRepositories;
using PizzaApp.Models.MockRepositories;
using PizzaApp.Models.SqlPizzaRepository;
using PizzaApp.Models.SqlUserRepository;
using PizzaApp.Models.ViewModels;

namespace PizzaApp
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //dependency injection

            services.AddDbContextPool<PizzaDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("PizzaConnection")));
            services.AddDbContextPool<UserDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("PizzaConnection")));

           
            services.AddScoped<IPizzaRepository, SqlPizzaRepository>()
                .AddScoped<IUserRepository, SqlUserRepository>()
                .AddSingleton<IUserRepository, MockUserRepository>()
                .AddSingleton<IEmployeeRepository, MockEmployeeRepository>()
                .AddSingleton<IPizzaTypeRepository, MockPizzaTypeRepository>()
                .AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
