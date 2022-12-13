using AutoMapper;
using FluentValidation;
using MD.AdvertisementApp.Business.DependencyResolvers.Microsoft;
using MD.AdvertisementApp.Business.Helper;
using MD.AdvertisementApp.Business.Mapping.AutoMapper;
using MD.AdvertisementApp.Business.ValidationRules;
using MD.AdvertisementApp.Dtos.AppUserDtos;
using MD.AdvertisementApp.UI.AutoMapper;
using MD.AdvertisementApp.UI.Models;
using MD.AdvertisementApp.UI.ValidationRules;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MD.AdvertisementApp.UI
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
            services.AddDepencies(Configuration);
            //UI layer oldugu ucun bunu strapupda yazdiq
            services.AddTransient<IValidator<UserCreateModel>, UserCreateModelValidator>();

            
            var mapperConfiguration = new MapperConfiguration(opt =>
            {
                opt.AddProfile(new UserCreateModelProfile());
                opt.AddProfile(new ProvidedServiceProfile());
                opt.AddProfile(new AdvertisementProfile());
                opt.AddProfile(new AppUserProfile());
                opt.AddProfile(new GenderProfile());
            });

            var mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);
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
            }
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
