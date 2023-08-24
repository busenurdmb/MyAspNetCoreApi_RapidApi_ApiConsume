using FluentValidation;
using HotelProject.DtoLayer.ContactDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.ValidationRules
{
    public class ContactCreateDtoValidator : AbstractValidator<ContactCreateDto>
    {
        public ContactCreateDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Message).NotEmpty();
            RuleFor(x => x.Mail).NotEmpty();
            //RuleFor(x => x.Date).NotEmpty();
        }
    }
}
