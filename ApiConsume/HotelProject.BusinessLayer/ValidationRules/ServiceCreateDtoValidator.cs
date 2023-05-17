using FluentValidation;
using HotelProject.DtoLayer.ServiceDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.ValidationRules
{
    public class ServiceCreateDtoValidator : AbstractValidator<ServiceCreateDto>
    {
        public ServiceCreateDtoValidator()
        {
            RuleFor(x=>x.Description).NotEmpty().WithMessage("Açıklama alanını Boş Geçme");
            RuleFor(x => x.Title).NotEmpty().WithMessage("başlık alanını Boş Geçme");
            RuleFor(x => x.ServiceIcon).NotEmpty().WithMessage("icon alanını boş geçmeyin");
        }
    }
}
