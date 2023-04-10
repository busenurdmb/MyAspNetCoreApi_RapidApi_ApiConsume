using AutoMapper;
using FluentValidation;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.UnitOfWork;
using HotelProject.DtoLayer.ServiceDtos;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrete
{
    public class ServiceManager : GenericManager<ServiceCreateDto, ServiceUpdateDto, ServiceListDto, Service>, IServiceService
    {
        public ServiceManager(IUow uow, IMapper mapper, IValidator<ServiceCreateDto> createdtovalidator, IValidator<ServiceUpdateDto> updatevalidator) : base(uow, mapper, createdtovalidator, updatevalidator)
        {
        }
    }
}
