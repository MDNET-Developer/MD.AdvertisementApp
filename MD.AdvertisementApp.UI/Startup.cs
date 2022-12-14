using AutoMapper;
using FluentValidation;
using MD.AdvertisementApp.Business.DependencyResolvers.Microsoft;
using MD.AdvertisementApp.Business.Helper;
using MD.AdvertisementApp.Business.Mapping.AutoMapper;
using MD.AdvertisementApp.Business.ValidationRules;
using MD.AdvertisementApp.Dtos;
using MD.AdvertisementApp.UI.AutoMapper;
using MD.AdvertisementApp.UI.Models;
using MD.AdvertisementApp.UI.ValidationRules;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option =>
            {
                option.Cookie.Name = "MDAdvertisement";
                //HttpOnly nədir?;
                //Yuxarıdakı nümunədə Server tərəfindən Set - Cookie - ni təyin edərkən HttpOnly bayrağını da görürük, bu nə edir?
                //Bu Bayraqdan istifadə edərək server brauzerə JavaScript vasitəsilə kukiyə girişə icazə verməməyi bildirir.Cookie JavaScript sayəsində oğurlana bilər, çünki JavaScript kodları XSS ​​hücumunda icra edilə bilər. HttpOnly sayəsində JavaScript kodlarının Cookie məlumatlarını oxumasına icazə vermir, XSS hücumundan qorunur.Başqasının kukisi ələ keçirilərsə, Təcavüzkar Sessiya zamanı kuki məlumatının ələ keçirildiyi şəxs kimi çıxış edə bilər(bax: Sessiyanın oğurlanması).
                option.Cookie.HttpOnly = true;
                //Eğer kritik bir cookie’yi (authentication token, session id gibi) Same Site olarak işaretlerseniz, tarayıcınız bunu sadece kendi websitesinden giden isteklerde POST ediyor. A sitesinden B sitesine giden isteklerde, bu cookie yokmuş gibi davranıyor.
                //Lax - The cookie will be sent with "same-site" requests, and with "cross-site" top level navigation.
                //None - The cookie will be sent with all requests (see remarks).
                //Strict - When the value is Strict the cookie will only be sent along with "same-site" requests.
                option.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict;
                //Always - Secure is always marked true. Use this value when your login page and all subsequent pages requiring the authenticated identity are HTTPS. Local development will also need to be done with HTTPS urls.
                //None - Secure is not marked true. Use this value when your login page is HTTPS, but other pages on the site which are HTTP also require authentication information. This setting is not recommended because the authentication information provided with an HTTP request may be observed and used by other computers on your local network or wireless connection.
                //SameAsRequest	 - If the URI that provides the cookie is HTTPS, then the cookie will only be returned to the server on subsequent HTTPS requests. Otherwise if the URI that provides the cookie is HTTP, then the cookie will be returned to the server on all HTTP and HTTPS requests. This value ensures HTTPS for all authenticated requests on deployed servers, and also supports HTTP for localhost development and for servers that do not have HTTPS support.
                option.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.SameAsRequest;
                //Coockie-nin həyatda qalma müddəti
                option.ExpireTimeSpan = TimeSpan.FromDays(30);
                option.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/SignIn");
                option.LogoutPath = new Microsoft.AspNetCore.Http.PathString("/Account/LogOut");
                option.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Account/AccessDenied");
            });
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
;
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
