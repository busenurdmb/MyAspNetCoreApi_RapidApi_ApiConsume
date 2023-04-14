using FluentValidation;
using HotelProject.DtoLayer.RoomDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.ValidationRules
{
    public class RommUpdateDtovalidator : AbstractValidator<RoomUpdateDto>
    {
        public RommUpdateDtovalidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("boş geçme");
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Price).NotEmpty();
        }
    }
}
