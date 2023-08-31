using FluentValidation;
using HotelProject.DtoLayer.SendMessageDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.ValidationRules
{
    public class SendMessageUpdateDtoValidator : AbstractValidator<SendMessageUpdateDto>
    {
        public SendMessageUpdateDtoValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("gönderen kişinin emailini giriniz");
            RuleFor(x => x.SenderMail).NotEmpty().WithMessage("alıcının mealini  giriniz");
            RuleFor(x => x.Content).NotEmpty().WithMessage("alıcının mealini  giriniz");
            RuleFor(x => x.Title).NotEmpty().WithMessage("alıcının mealini  giriniz");
        }
    }
}
