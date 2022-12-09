using AutoMapper;
using FluentValidation;
using MD.AdvertisementApp.Business.Interfaces;
using MD.AdvertisementApp.DataAccess.UnitOfWork;
using MD.AdvertisementApp.Dtos.AppUserDtos;
using MD.AdvertisementApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD.AdvertisementApp.Business.Services
{
    internal class AppUserService : Service<AppUserCreateDto, AppUserUpdateDto, AppUserListDto, AppUser>, IAppUserService
    {
        public AppUserService(IMapper mapper, IValidator<AppUserCreateDto> createDtoValidator, IValidator<AppUserUpdateDto> updateDtoValidator, IUow uow) : base(mapper, createDtoValidator, updateDtoValidator, uow)
        {
        }
    }
}
