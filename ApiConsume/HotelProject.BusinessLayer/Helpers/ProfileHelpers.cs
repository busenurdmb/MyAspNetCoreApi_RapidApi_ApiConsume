using AutoMapper;
using HotelProject.BusinessLayer.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HotelProject.BusinessLayer.Helpers
{
    public static class ProfileHelpers
    {
        public static List<Profile> GetProfiles()
        {
            return new List<Profile>
            {
                new StaffProfile(),
                new RoomProfile(),
                new ServiceProfile(),
                new SubscribeProfile(),
                new TestimonialProfile(),
                new AboutProfile(),
                new BookingProfiles(),
                new ContactProfiile(),
                new GuestProfiles(),
                new SendMessageProfiles(),
                new MessageCategoryProfiles(),
                new WorkLocationProfiles(),
                new AppUserProfiles(),
            };


        }
    }
}
