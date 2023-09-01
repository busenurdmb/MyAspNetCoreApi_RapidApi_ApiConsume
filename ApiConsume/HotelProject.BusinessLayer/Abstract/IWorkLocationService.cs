using HotelProject.DtoLayer.WorkLocationDtos;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Abstract
{
    public interface IWorkLocationService:IGenericService<WorkLocationCreateDto,WorkLocationUpdateDto,WorkLocationListDto,WorkLocation>
    {
    }
}
