using FluentValidation;
using HotelProject.DtoLayer.GuestDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.ValidationRules
{
   public class GuestUpdateDtoValidator : AbstractValidator<GuestUpdateDto>
    {
        public GuestUpdateDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad Alanını Boş Geçme");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad Alanını Boş Geçme");
            RuleFor(x => x.city).NotEmpty().WithMessage("Şehir Alanını Boş Geçme");
        }
    }
}
