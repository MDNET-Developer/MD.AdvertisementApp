using FluentValidation;
using MD.AdvertisementApp.Dtos.GenderDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD.AdvertisementApp.Business.ValidationRules
{
    public class GenderUpdateDtoValidator:AbstractValidator<GenderUpdateDto>
    {
        public GenderUpdateDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x=>x.Definition).NotEmpty();
        }
    }
}
