using FluentValidation;
using HotelProject.DtoLayer.SubscribeDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.ValidationRules
{
    public class SubscribeCreateDtoValidator : AbstractValidator<SubscribeCreateDto>
    {
        public SubscribeCreateDtoValidator()
        {
        }
    }
}
