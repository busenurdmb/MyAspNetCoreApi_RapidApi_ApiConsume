using FluentValidation;
using HotelProject.DtoLayer.StaffDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.ValidationRules
{
    public class StaffUpdateDtoValidator : AbstractValidator<StaffUpdateDto>
    {
        public StaffUpdateDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.SocialMedia1).NotEmpty();
            RuleFor(x => x.SocialMedia2).NotEmpty();
            RuleFor(x => x.SocialMedia3).NotEmpty();
        }
    }
}
