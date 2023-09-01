using FluentValidation;
using HotelProject.DtoLayer.MessageCategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.ValidationRules
{
    public class MessageCategoryCreateDtoValidator : AbstractValidator<MessageCategoryCreateDto>
    {
        public MessageCategoryCreateDtoValidator()
        {
            RuleFor(x=>x.MessageCategoryName).NotEmpty().WithMessage("boş geçemessiniz");
        }
    }
}
