using AutoMapper;
using FluentValidation;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.UnitOfWork;
using HotelProject.DtoLayer.StaffDtos;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrete
{
    public class StaffManager : GenericManager<StaffCreateDto, StaffUpdateDto, StaffListDto, Staff>, IStaffService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        public StaffManager(IUow uow, IMapper mapper, IValidator<StaffCreateDto> createdtovalidator, IValidator<StaffUpdateDto> updatevalidator) : base(uow, mapper, createdtovalidator, updatevalidator)
        {
            _uow = uow;
            _mapper= mapper;
        }

        public async Task<IList<StaffListDto>> Last4T()
        {
            var data = await _uow.GetRepository<Staff>().Last4T();
            var Dto= _mapper.Map<List<StaffListDto>>(data);
            return Dto;
        }

        public int Staffcount()
        {
            return _uow.GetRepository<Staff>().GetCount();
        }
    }
}
