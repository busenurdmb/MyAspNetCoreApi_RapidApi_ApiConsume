using AutoMapper;
using FluentValidation;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.UnitOfWork;
using HotelProject.DtoLayer.BookingDtos;
using HotelProject.DtoLayer.ContactDtos;
using HotelProject.DtoLayer.Interfaces;
using HotelProject.EntityLayer.Concrete;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrete
{
    public class ContactManager : GenericManager<ContactCreateDto, ContactUpdateDto, ContactListDto, Contact>, IContactService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        

      

        public ContactManager(IUow uow, IMapper mapper, IValidator<ContactCreateDto> createdtovalidator, IValidator<ContactUpdateDto> updatevalidator) : base(uow, mapper, createdtovalidator, updatevalidator)
        { 
            _uow = uow;
          _mapper= mapper;

        }

        public int coontactcount()
        {
          return _uow.GetRepository<Contact>().GetCount();
        }

        public async Task<IList<ContactListDto>> Last4T()
        {
            var data =await _uow.GetRepository<Contact>().Last4T();
            var dto=_mapper.Map<List<ContactListDto>>(data);
            return dto;
        }
    }
}
