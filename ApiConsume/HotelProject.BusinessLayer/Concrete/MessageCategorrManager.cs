using AutoMapper;
using FluentValidation;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.UnitOfWork;
using HotelProject.DtoLayer.MessageCategoryDtos;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrete
{
    public class MessageCategorrManager : GenericManager<MessageCategoryCreateDto, MessageCategoryUpdateDto, MessageCategoryListDto, MessageCategory>, IMessageCategoryService
    {
        public MessageCategorrManager(IUow uow, IMapper mapper, IValidator<MessageCategoryCreateDto> createdtovalidator, IValidator<MessageCategoryUpdateDto> updatevalidator) : base(uow, mapper, createdtovalidator, updatevalidator)
        {
        }
    }
}
