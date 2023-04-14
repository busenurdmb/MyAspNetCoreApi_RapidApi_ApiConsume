using FluentValidation;
using HotelProject.DtoLayer.RoomDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.ValidationRules
{
    public class RommCreateDtovalidator : AbstractValidator<RoomCreateDto>
    {
        public RommCreateDtovalidator()
        {
            RuleFor(x=>x.Title).NotEmpty().WithMessage("boş geçme");
            RuleFor(x=>x.Description).NotEmpty().WithMessage("boş geçme");
            RuleFor(x=>x.RommNumber).NotEmpty().WithMessage("boş geçme");
            RuleFor(x=>x.Price).NotEmpty();
            RuleFor(x=>x.Wifi).NotEmpty();
        }
    }
}
