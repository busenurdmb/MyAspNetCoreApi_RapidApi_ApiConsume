﻿using FluentValidation;
using HotelProject.WebUI.Dtos.Guest;

namespace HotelProject.WebUI.ValidationRules.GuestValidationRules
{
    public class GuestUpdateValidator:AbstractValidator<GuestUpdateDto>
    {
        public GuestUpdateValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim alanı boş geçilemezzzzzzz");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("İsim alanı boş geçilemez");
            RuleFor(x => x.city).NotEmpty().WithMessage("İsim alanı boş geçilemez");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Lütfen en az 3 karakter veri girişi yapınız");
            RuleFor(x => x.Surname).MinimumLength(2).WithMessage("Lütfen en az 2 karakter veri girişi yapınız");
            RuleFor(x => x.city).MinimumLength(3).WithMessage("Lütfen en az 3 karakter veri girişi yapınız");
            RuleFor(x => x.Name).MaximumLength(20).WithMessage("Lütfen en fazla 20 karakter veri girişi yapınız");
            RuleFor(x => x.Surname).MaximumLength(30).WithMessage("Lütfen en fazla 30 karakter veri girişi yapınız");
            RuleFor(x => x.city).MaximumLength(20).WithMessage("Lütfen en fazla 20 karakter veri girişi yapınız");
        }
    }
}
