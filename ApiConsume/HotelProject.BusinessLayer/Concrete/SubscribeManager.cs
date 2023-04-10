using AutoMapper;
using FluentValidation;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.UnitOfWork;
using HotelProject.DtoLayer.SubscribeDto;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrete
{
    public class SubscribeManager : GenericManager<SubscribeCreateDto, SubscribeUpdateDto, SubscribeListDto, Subscribe>, ISubscribeService
    {
        public SubscribeManager(IUow uow, IMapper mapper, IValidator<SubscribeCreateDto> createdtovalidator, IValidator<SubscribeUpdateDto> updatevalidator) : base(uow, mapper, createdtovalidator, updatevalidator)
        {
        }
    }
}
