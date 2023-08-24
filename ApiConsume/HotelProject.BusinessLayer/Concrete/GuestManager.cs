using AutoMapper;
using FluentValidation;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.UnitOfWork;
using HotelProject.DtoLayer.GuestDtos;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrete
{
    public class GuestManager : GenericManager<GuestCreateDto, GuestUpdateDto, GuestListDto, Guest>, IGuestService
    {
        public GuestManager(IUow uow, IMapper mapper, IValidator<GuestCreateDto> createdtovalidator, IValidator<GuestUpdateDto> updatevalidator) : base(uow, mapper, createdtovalidator, updatevalidator)
        {
        }
    }
}
