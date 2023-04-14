using AutoMapper;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.BusinessLayer.Concrete;
using HotelProject.BusinessLayer.DependencyResolvers.Microsoft;
using HotelProject.BusinessLayer.Helpers;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;

using HotelProject.DataAccessLayer.UnitOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProjectWebApi
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
            var profiles = ProfileHelpers.GetProfiles();

            //profiles.Add(new UserCreateModelProfile());
            var mapperConfiguration = new MapperConfiguration(opt =>
            {
                //opt.profile();
                opt.AddProfiles(profiles);

            });
            var mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);

            // services.AddScoped<IUow, Uow>();

            //services.AddScoped<IStaffDal,EfStaffDal>();


            //services.AddScoped<IServiceDal, EfServiceDal>();
            //services.AddScoped<IServiceService, ServiceManager>();

            //services.AddScoped<ITestimonialDal, EfTestimonialDal>();
            //services.AddScoped<ITestimonialService, TestimonialManager>();

            //services.AddScoped<ISubscribeDal, EfSubscribeDal>();
            //services.AddScoped<ISubscribeService, SubscribeManager>();

            //services.AddScoped<IRoomDal, EfRoomDal>();
            //services.AddScoped<IRoomService, RoomManager>();

            services.AddCors(cors =>
            {
                cors.AddPolicy("HotelApiCors", opt =>
                {
                    opt.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HotelProjectWebApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HotelProjectWebApi v1"));
            }

            app.UseRouting();
            app.UseCors("HotelApiCors");
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
