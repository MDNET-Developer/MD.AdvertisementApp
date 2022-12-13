using AutoMapper;
using FluentValidation;
using MD.AdvertisementApp.Business.Extensions;
using MD.AdvertisementApp.Business.Interfaces;
using MD.AdvertisementApp.Common;
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
    public class AppUserService : Service<AppUserCreateDto, AppUserUpdateDto, AppUserListDto, AppUser>, IAppUserService
    {
        private readonly IValidator<AppUserCreateDto> _createDtoValidator;
        private readonly IMapper _mapper;
        private readonly IUow _uow;
        public AppUserService(IMapper mapper, IValidator<AppUserCreateDto> createDtoValidator, IValidator<AppUserUpdateDto> updateDtoValidator, IUow uow) : base(mapper, createDtoValidator, updateDtoValidator, uow)
        {
            _createDtoValidator = createDtoValidator;
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<IResponse<AppUserCreateDto>> CreateAppUserWithRoleAsync(AppUserCreateDto dto , int roleId)
        {
            var validationResponse = _createDtoValidator.Validate(dto);
            if (validationResponse.IsValid)
            {
                var mappedUser = _mapper.Map<AppUser>(dto);
                await _uow.GetRepository<AppUser>().Create(mappedUser);
                await _uow.GetRepository<AppUserRole>().Create(new AppUserRole
                {
                    AppUser=mappedUser,
                    AppRoleId=roleId
                });
              await  _uow.SaveChanges();
            }
            return new Response<AppUserCreateDto>(ResponseType.ValidationError,dto, validationResponse.ConvertToCustomValidationError());
        }
    }
}
