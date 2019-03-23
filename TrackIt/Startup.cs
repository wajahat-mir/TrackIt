using System.Text;
using AutoMapper;
using GraphiQl;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrackIt.Helpers;
using TrackIt.Models;
using TrackIt.Services;

namespace TrackIt
{
    public class Startup
    {

        public const string GraphQlPath = "/api/graphql";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            var appSettings = appSettingsSection.Get<AppSettings>();
            var connection = appSettings.DBConnectionString;
            services.AddDbContext<InventoryContext>(opt =>
                opt.UseSqlServer(connection));

            services.ConfigureCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddAutoMapper();

            // configure jwt authentication
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.ConfigureAuthentication(key);

            // configure DI for application services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IInventoryService, InventoryService>();
            services.AddScoped<IBrandService, BrandService>();

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
                app.UseHsts();
            }

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseGraphiQl(GraphQlPath);
        }
    }
}
