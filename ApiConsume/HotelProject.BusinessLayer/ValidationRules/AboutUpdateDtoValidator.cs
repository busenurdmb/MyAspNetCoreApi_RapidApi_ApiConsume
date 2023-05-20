using FluentValidation;
using HotelProject.DtoLayer.AboutDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.ValidationRules
{
    public class AboutUpdateDtoValidator : AbstractValidator<AboutUpdateDto>
    {
        public AboutUpdateDtoValidator()
        {
            RuleFor(x => x.Content).NotEmpty();
            RuleFor(x => x.Title1).NotEmpty();
            RuleFor(x => x.Title2).NotEmpty();
        }
    }
}
