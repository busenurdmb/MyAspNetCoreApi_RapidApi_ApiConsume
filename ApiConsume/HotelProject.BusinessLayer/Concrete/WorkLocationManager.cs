using AutoMapper;
using FluentValidation;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.UnitOfWork;
using HotelProject.DtoLayer.WorkLocationDtos;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrete
{
    public class WorkLocationManager : GenericManager<WorkLocationCreateDto, WorkLocationUpdateDto, WorkLocationListDto, WorkLocation>, IWorkLocationService
    {
        public WorkLocationManager(IUow uow, IMapper mapper, IValidator<WorkLocationCreateDto> createdtovalidator, IValidator<WorkLocationUpdateDto> updatevalidator) : base(uow, mapper, createdtovalidator, updatevalidator)
        {
        }
    }
}
