using AutoMapper;
using FluentValidation;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.UnitOfWork;
using HotelProject.DtoLayer.SendMessageDtos;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrete
{
    public class SendMessageManager : GenericManager<SendMessageCreateDto, SendMessageUpdateDto, SendMessageListDto, SendMessage>,ISendMessageService
    {
        private readonly IUow _uow;
        public SendMessageManager(IUow uow, IMapper mapper, IValidator<SendMessageCreateDto> createdtovalidator, IValidator<SendMessageUpdateDto> updatevalidator) : base(uow, mapper, createdtovalidator, updatevalidator)
        {
            _uow = uow;
        }
     

        public int SendMessagecount()
        {
            return _uow.GetRepository<SendMessage>().GetCount();
        }
    }
}
