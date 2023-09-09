using AutoMapper;
using FluentValidation;
using HotelProject.BusinessLayer.Abstract;
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
   public class DontBaseGenericManager<CreateDto, UpdateDto, ListDto, T> : IDontBaseGenericService<CreateDto, UpdateDto, ListDto, T>
     where CreateDto : class, IDto, new()
         where UpdateDto : class, IUpdateDto, new()
         where ListDto : class, IDto, new()
         where T : class
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateDto> _createdtovalidator;
        private readonly IValidator<UpdateDto> _updatevalidator;

        public DontBaseGenericManager(IUow uow, IMapper mapper, IValidator<CreateDto> createdtovalidator, IValidator<UpdateDto> updatevalidator)
        {
            _uow = uow;
            _mapper = mapper;
            _createdtovalidator = createdtovalidator;
            _updatevalidator = updatevalidator;
        }

        public async Task<CreateDto> CreateAsync(CreateDto Dto)
        {
            var result = _createdtovalidator.Validate(Dto);
            if (result.IsValid)
            {
                var createdEntity = _mapper.Map<T>(Dto);
                await _uow.GetRepositoryDontBase<T>().CreateAsync(createdEntity);
                await _uow.SaveChangesAsync();
                return Dto;
            }
            return Dto;
        }

        public async Task<IList<ListDto>> GetAllAsync()
        {
            var data = await _uow.GetRepositoryDontBase<T>().GetAllAsync();
            var dto = _mapper.Map<List<ListDto>>(data);
            return dto;
        }

        public async Task<IDto> GetByIdAsync<IDto>(int id)
        {

            var data = await _uow.GetRepositoryDontBase<T>().FindAsync(id);
            return _mapper.Map<IDto>(data);

        }



        public async Task RemoveAsync(int id)
        {
            var data = await _uow.GetRepositoryDontBase<T>().FindAsync(id);
            if (data != null)
            {
                // var dto= _mapper.Map<IDto>(data);
                _uow.GetRepositoryDontBase<T>().Remove(data);
                await _uow.SaveChangesAsync();
            }




        }
        public async Task<UpdateDto> UpdateAsync(UpdateDto Dto)
        {

            var result = _updatevalidator.Validate(Dto);
            if (result.IsValid)
            {
                var unchangedData = await _uow.GetRepositoryDontBase<T>().FindAsync(Dto.ID);
                if (unchangedData != null)
                {
                    var entity = _mapper.Map<T>(Dto);
                    _uow.GetRepositoryDontBase<T>().Update(entity, unchangedData);
                    await _uow.SaveChangesAsync();

                }


                return Dto;
            }

            return Dto;
        }
    }
}
