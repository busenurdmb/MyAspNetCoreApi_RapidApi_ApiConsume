using AutoMapper;
using FluentValidation;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.UnitOfWork;
using HotelProject.DtoLayer.BookingDtos;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrete
{
    public class BookingManager : GenericManager<BookingCreateDto, BookingUpdateDto, BookingListDto, Booking>, IBookingService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
      
        private readonly IValidator<BookingUpdateDto> _updatevalidator;

       

        public BookingManager(IUow uow, IMapper mapper, IValidator<BookingCreateDto> createdtovalidator, IValidator<BookingUpdateDto> updatevalidator) : base(uow, mapper, createdtovalidator, updatevalidator)
        {
            _uow = uow;
            _mapper = mapper;
            _updatevalidator = updatevalidator;
        }

        public async Task<BookingUpdateDto> BoookingStatusChangedApproved(BookingUpdateDto Dto)
        {
            var result = _updatevalidator.Validate(Dto);
            if (result.IsValid)
            {
                var entity = _mapper.Map<Booking>(Dto);
                _uow.GetRepository<Booking>().BookingStatusChangedApproved(entity);

                await _uow.SaveChangesAsync();
            }
            return Dto;   
          
        }
        public async Task<BookingUpdateDto> BookingStatusChangedCancel(BookingUpdateDto Dto)
        {
            //Dto.Status = "İptal Edildi";
            //var result = _updatevalidator.Validate(Dto);
            //if (result.IsValid)
            //{
            //    var unchangedData = await _uow.GetRepository<Booking>().FindAsync(Dto.ID);
            //    if (unchangedData != null)
            //    {

            //        var entity = _mapper.Map<Booking>(Dto);
            //        _uow.GetRepository<Booking>().Update(entity,unchangedData);

            //        await _uow.SaveChangesAsync();
            //    }
            //}
            //return Dto;
            var result = _updatevalidator.Validate(Dto);
            if (result.IsValid)
            {
                var entity = _mapper.Map<Booking>(Dto);
                _uow.GetRepository<Booking>().BookingStatusChangedCancel(entity);

                await _uow.SaveChangesAsync();
            }
            return Dto;
        }
        public int Bookingcount()
        {
            return _uow.GetRepository<Booking>().GetCount();
        }

        public async Task<IList<BookingListDto>> Last6T()
        {
            var data=await _uow.GetRepository<Booking>().Last6T();
            var dto=_mapper.Map<List<BookingListDto>>(data);
            return dto;
        }

        public async Task<BookingUpdateDto> BookingStatusChangedWait(BookingUpdateDto Dto)
        {
            var result = _updatevalidator.Validate(Dto);
            if (result.IsValid)
            {
                var entity = _mapper.Map<Booking>(Dto);
                _uow.GetRepository<Booking>().BookingStatusChangedWait(entity);

                await _uow.SaveChangesAsync();
            }
            return Dto;
        }
    }
}
