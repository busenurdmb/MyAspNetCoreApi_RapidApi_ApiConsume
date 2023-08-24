using AutoMapper;
using FluentValidation;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.UnitOfWork;
using HotelProject.DtoLayer.ContactDtos;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrete
{
    public class ContactManager : GenericManager<ContactCreateDto, ContactUpdateDto, ContactListDto, Contact>, IContactService
    {
        public ContactManager(IUow uow, IMapper mapper, IValidator<ContactCreateDto> createdtovalidator, IValidator<ContactUpdateDto> updatevalidator) : base(uow, mapper, createdtovalidator, updatevalidator)
        {
        }
    }
}
