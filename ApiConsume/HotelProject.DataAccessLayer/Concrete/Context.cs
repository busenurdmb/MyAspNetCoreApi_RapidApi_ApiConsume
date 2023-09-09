﻿using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser,AppRole,int>
    {
      

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder opt)
        //{
        //    opt.UseSqlServer("server=DESKTOP-493DFJA\\SQLEXPRESS;database=ApiDB;integrated security=true");

        //}

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<SendMessage> sendMessages { get; set; }
        public DbSet<MessageCategory> messageCategories { get; set; }
        public DbSet<WorkLocation> workLocations { get; set; }


    }
}
