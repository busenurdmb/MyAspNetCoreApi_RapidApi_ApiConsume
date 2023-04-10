using HotelProject.CommonLayer;
using HotelProject.DtoLayer.Interfaces;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Abstract
{
    public interface IGenericService<CreateDto,UpdateDto,ListDto,T> 
        where CreateDto:class,IDto,new ()
        where UpdateDto:class,IUpdateDto,new ()
        where ListDto:class,IDto,new ()
        where T : BaseEntity
    {
        Task<IResponse<CreateDto>> CreateAsync(CreateDto Dto);
        Task<IResponse<UpdateDto>> UpdateAsync(UpdateDto Dto);
        Task<IResponse<IDto>> GetByIdAsync<IDto>(int id);
        Task<IResponse> RemoveAsync(int id);
        Task<IResponse<List<ListDto>>> GetAllAsync();
    }
}
