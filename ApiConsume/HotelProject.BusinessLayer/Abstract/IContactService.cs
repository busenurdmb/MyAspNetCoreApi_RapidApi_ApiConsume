using HotelProject.DtoLayer.BookingDtos;
using HotelProject.DtoLayer.ContactDtos;
using HotelProject.DtoLayer.StaffDtos;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Abstract
{
    public interface IContactService:IGenericService<ContactCreateDto,ContactUpdateDto,ContactListDto,Contact>
    {
        int coontactcount();
        Task<IList<ContactListDto>> Last4T();
    }
}
