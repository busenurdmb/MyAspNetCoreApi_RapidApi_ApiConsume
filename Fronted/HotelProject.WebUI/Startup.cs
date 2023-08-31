using FluentValidation;
using FluentValidation.AspNetCore;
using HotelProject.BusinessLayer.DependencyResolvers.Microsoft;
using HotelProject.BusinessLayer.Helpers;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.Guest;
using HotelProject.WebUI.ValidationRules.GuestValidationRules;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using HotelProject.WebUI.Mapping.AutoMapper;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace HotelProject.WebUI
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
           services.AddDependencies(Configuration);
       //  services.AddDbContext<Context>();

        
        

            services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>();

            services.AddHttpClient();
            
           services.AddTransient<IValidator<GuestCreateDtoo>, GuestCreateValidator>();
           services.AddTransient<IValidator<GuestUpdateDto>, GuestUpdateValidator>();
            services.AddControllersWithViews();
            services.AddFluentValidationAutoValidation();


            var profiles = ProfileHelpers.GetProfiles();
            profiles.Add(new GuestCretaeDtoProfile());
            var configuration = new MapperConfiguration(opt =>
            {
                opt.AddProfiles(profiles);
            });

            var mapper = configuration.CreateMapper();
            services.AddSingleton(mapper);

            //proje seviyesinde authorize
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
                options.LoginPath = "/Login/Index/";
            });
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

            app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404", "?code={0}");
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
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
