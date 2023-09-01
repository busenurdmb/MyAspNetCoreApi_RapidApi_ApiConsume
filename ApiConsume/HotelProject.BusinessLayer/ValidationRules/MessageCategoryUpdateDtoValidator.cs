using FluentValidation;
using HotelProject.DtoLayer.MessageCategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.ValidationRules
{
    public class MessageCategoryUpdateDtoValidator : AbstractValidator<MessageCategoryUpdateDto>
    {
        public MessageCategoryUpdateDtoValidator()
        {
            RuleFor(x=>x.MessageCategoryName).NotEmpty().WithMessage("Boş Geçemessiniz");
        }
    }
}
