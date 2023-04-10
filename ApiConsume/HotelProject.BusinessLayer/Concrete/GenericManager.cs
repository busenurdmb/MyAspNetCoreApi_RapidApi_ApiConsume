using AutoMapper;
using FluentValidation;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.BusinessLayer.Extension;
using HotelProject.CommonLayer;
using HotelProject.DataAccessLayer.UnitOfWork;
using HotelProject.DtoLayer.Interfaces;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrete
{
    public class GenericManager<CreateDto, UpdateDto, ListDto, T> : IGenericService<CreateDto, UpdateDto, ListDto, T>
     where CreateDto : class, IDto, new()
         where UpdateDto : class, IUpdateDto, new()
         where ListDto : class, IDto, new()
         where T : BaseEntity
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateDto> _createdtovalidator;
        private readonly IValidator<UpdateDto> _updatevalidator;

        public GenericManager(IUow uow, IMapper mapper, IValidator<CreateDto> createdtovalidator, IValidator<UpdateDto> updatevalidator)
        {
            _uow = uow;
            _mapper = mapper;
            _createdtovalidator = createdtovalidator;
            _updatevalidator = updatevalidator;
        }

        public async Task<IResponse<CreateDto>> CreateAsync(CreateDto Dto)
        {
            var result = _createdtovalidator.Validate(Dto);
            if (result.IsValid)
            {
                var createdEntity = _mapper.Map<T>(Dto);
                await _uow.GetRepository<T>().CreateAsync(createdEntity);
                await _uow.SaveChanges();
                return new Response<CreateDto>(ResponseType.Success,Dto);
            }
            return new Response<CreateDto>(Dto, result.ConvertToCustomValidationError());
        }

        public async Task<IResponse<List<ListDto>>> GetAllAsync()
        {
           var data=await _uow.GetRepository<T>().GetAllAsync();
            var dto=_mapper.Map<List<ListDto>>(data);
            return new Response<List<ListDto>>(ResponseType.Success,dto);
        }

        public async Task<IResponse<IDto>> GetByIdAsync<IDto>(int id)
        {
            var data = await _uow.GetRepository<T>().GetByFilterAsync(x => x.ID == id);
            if (data == null)
                return new Response<IDto>(ResponseType.NotFound, $"{id} idsine sahip data bulunmadı");
            var dto = _mapper.Map<IDto>(data);
            return new Response<IDto>(ResponseType.Success, dto);
        }

        public Task<IResponse> RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IResponse<UpdateDto>> UpdateAsync(UpdateDto Dto)
        {
            throw new NotImplementedException();
        }

        //public void TDelete(T t)
        //{
        //    _uow.GetRepository<T>().Delete(t);
        //    _uow.SaveChanges();

        //}

        //public T TGetById(int id)
        //{
        // return   _uow.GetRepository<T>().GetById(id);

        //}

        //public List<T> TGetList()
        //{
        //    return _uow.GetRepository<T>().GetList();    
        //}
        //public void TInsert(T t)
        //{
        //   _uow.GetRepository<T>().Insert(t);
        //    _uow.SaveChanges();
        //}

        //public void TUpdate(T t)
        //{

        //    _uow.GetRepository<T>().Update(t);
        //    _uow.SaveChanges();
        //}
    }
}
