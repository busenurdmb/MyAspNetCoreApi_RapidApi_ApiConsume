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
        }
    }
}
