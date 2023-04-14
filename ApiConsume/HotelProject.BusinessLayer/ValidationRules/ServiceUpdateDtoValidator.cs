using FluentValidation;
using HotelProject.DtoLayer.ServiceDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.ValidationRules
{
    public class ServiceUpdateDtoValidator : AbstractValidator<ServiceUpdateDto>
    {
        public ServiceUpdateDtoValidator()
        {
        }
    }
}
