using FluentValidation;
using HotelProject.DtoLayer.TestimonialDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.ValidationRules
{
    public class TestimonialCreateDtoValidator : AbstractValidator<TestimonialCreateDto>
    {
        public TestimonialCreateDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("boş geçme");
            RuleFor(x => x.Description).NotEmpty().WithMessage("boş geçme");
            RuleFor(x => x.Name).NotEmpty().WithMessage("boş geçme");
            RuleFor(x => x.Image).NotEmpty();
            
        }
    }
}
