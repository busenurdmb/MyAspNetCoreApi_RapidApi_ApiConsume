using AutoMapper;
using FluentValidation;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.BusinessLayer.AutoMapper;
using HotelProject.BusinessLayer.Concrete;
using HotelProject.BusinessLayer.ValidationRules;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.UnitOfWork;
using HotelProject.DtoLayer.RoomDtos;
using HotelProject.DtoLayer.ServiceDtos;
using HotelProject.DtoLayer.StaffDtos;
using HotelProject.DtoLayer.SubscribeDto;
using HotelProject.DtoLayer.TestimonialDtos;
using HotelProject.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.DependencyResolvers.Microsoft
{
    public static class DependecyExtension
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<Context>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("Local"));
            });

            var mapper = new MapperConfiguration(opt =>
            {
                opt.AddProfile(new StaffProfile());
            });

           services.AddScoped<IUow, Uow>();

            services.AddTransient<IValidator<StaffCreateDto>,StaffCreateDtoValidator>();
            services.AddTransient<IValidator<StaffUpdateDto>,StaffUpdateDtoValidator>();

            services.AddTransient<IValidator<ServiceCreateDto>, ServiceCreateDtoValidator>();
            services.AddTransient<IValidator<ServiceUpdateDto>, ServiceUpdateDtoValidator>();

            services.AddTransient<IValidator<SubscribeCreateDto>, SubscribeCreateDtoValidator>();
            services.AddTransient<IValidator<SubscribeUpdateDto>, SubscribeUpdateDtoValidator>();

            services.AddTransient<IValidator<TestimonialCreateDto>, TestimonialCreateDtoValidator>();
            services.AddTransient<IValidator<TestimonialUpdateDto>, TestimonialUpdateDtoValidator>();

            services.AddTransient<IValidator<RoomCreateDto>, RommCreateDtovalidator>();
            services.AddTransient<IValidator<RoomUpdateDto>, RommUpdateDtovalidator>();

           
            services.AddScoped<IStaffService, StaffManager>();
            services.AddScoped<IServiceService, ServiceManager>();
            services.AddScoped<IRoomService, RoomManager>();
            services.AddScoped<ISubscribeService, SubscribeManager>();
            services.AddScoped<ITestimonialService, TestimonialManager>();
          
        }
    }
}
