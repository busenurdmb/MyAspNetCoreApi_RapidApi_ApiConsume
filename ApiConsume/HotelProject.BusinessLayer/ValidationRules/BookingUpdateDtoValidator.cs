using FluentValidation;
using HotelProject.DtoLayer.BookingDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.ValidationRules
{
    public class BookingUpdateDtoValidator : AbstractValidator<BookingUpdateDto>
    {
        public BookingUpdateDtoValidator()
        {
            //RuleFor(x => x.Name).NotEmpty();
            //RuleFor(x => x.Mail).NotEmpty();
            //RuleFor(x => x.Description).NotEmpty();
            //RuleFor(x => x.Checkin).NotEmpty();
            //RuleFor(x => x.ChildCount).NotEmpty();
            //RuleFor(x => x.ChildCount).NotEmpty();
        }
    }
}
