using AutoMapper;
using FluentValidation;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.UnitOfWork;
using HotelProject.DtoLayer.AppUserDtos;
using HotelProject.DtoLayer.WorkLocationDtos;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrete
{
    public class AppUserManager : DontBaseGenericManager<AppUserCreateDto, AppUserUpdateDto, AppUserListDto, AppUser>, IAppUserService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        public AppUserManager(IUow uow, IMapper mapper, IValidator<AppUserCreateDto> createdtovalidator, IValidator<AppUserUpdateDto> updatevalidator) : base(uow, mapper, createdtovalidator, updatevalidator)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public int AppUsercount()
        {
            return _uow.GetRepositoryDontBase<AppUser>().GetCount();
        }

        public async Task<List<AppUser>> UserListWithWorkLocation()
        {
            var ekle = _uow.GetRepositoryDontBase<AppUser>().UserListWithWorkLocation();
           
            await _uow.SaveChangesAsync();
            return ekle;
        }
    }
}
