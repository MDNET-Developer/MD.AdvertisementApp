using FluentValidation;
using MD.AdvertisementApp.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD.AdvertisementApp.Business.ValidationRules
{
    public class AppUserLogInDtoValidator:AbstractValidator<AppUserLogInDto>
    {
        public AppUserLogInDtoValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("İstifadəçi adını daxil edin");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifrəni daxil edin");
        }
    }
}
