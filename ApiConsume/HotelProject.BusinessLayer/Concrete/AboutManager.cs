using AutoMapper;
using FluentValidation;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.UnitOfWork;
using HotelProject.DtoLayer.AboutDtos;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrete
{
    public class AboutManager : GenericManager<AboutCreateDto, AboutUpdateDto, AboutListDto, About>, IAboutService
    {
        public AboutManager(IUow uow, IMapper mapper, IValidator<AboutCreateDto> createdtovalidator, IValidator<AboutUpdateDto> updatevalidator) : base(uow, mapper, createdtovalidator, updatevalidator)
        {
        }
    }
}
