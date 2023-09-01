using FluentValidation;
using HotelProject.DtoLayer.WorkLocationDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.ValidationRules
{
    public class WorkLocationCreateDtoValidator : AbstractValidator<WorkLocationCreateDto>
    {
        public WorkLocationCreateDtoValidator()
        {
            RuleFor(x=>x.WorkLocationName).NotEmpty().WithMessage("boş geçilmez");
            RuleFor(x=>x.WorkLocationCity).NotEmpty().WithMessage("boş geçilmez");
        }
    }
}
