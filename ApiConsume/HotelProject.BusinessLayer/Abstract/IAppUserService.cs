using HotelProject.DtoLayer.AppUserDtos;
using HotelProject.DtoLayer.WorkLocationDtos;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Abstract
{
   public interface IAppUserService:IDontBaseGenericService<AppUserCreateDto, AppUserUpdateDto,AppUserListDto,AppUser>
    {
         Task<List<AppUser>> UserListWithWorkLocation();
        int AppUsercount();

    }
}
