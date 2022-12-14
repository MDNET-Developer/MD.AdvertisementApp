using MD.AdvertisementApp.Business.Interfaces;
using MD.AdvertisementApp.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using FluentValidation;
using AutoMapper;
using MD.AdvertisementApp.UI.AutoMapper;
using MD.AdvertisementApp.Dtos;
using MD.AdvertisementApp.UI.Extensions;
using MD.AdvertisementApp.Common.Enums;

namespace MD.AdvertisementApp.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IGenderService _genderService;
        private readonly IValidator<UserCreateModel> _userCreateModelValidator;
        private readonly IValidator<AppUserLogInDto> _userLoginValidator;
        private readonly IAppUserService _appUserService;
        private readonly IMapper _mapper;
        public AccountController(IGenderService genderService, IValidator<UserCreateModel> userCreateModelValidator, IMapper mapper, IAppUserService appUserService, IValidator<AppUserLogInDto> userLoginValidator)
        {
            _genderService = genderService;
            _userCreateModelValidator = userCreateModelValidator;
            _mapper = mapper;
            _appUserService = appUserService;
            _userLoginValidator = userLoginValidator;
        }

        public async Task<IActionResult> SignUp()
        {
            var genderdata = await _genderService.GetAllAsync();
            var userCreateModel = new UserCreateModel();
            userCreateModel.Gender = new SelectList(genderdata.Data, "Id", "Definition");
            return View(userCreateModel);
        }


        [HttpPost]
        public async Task<IActionResult> SignUp(UserCreateModel model)
        {
            var result = _userCreateModelValidator.Validate(model);
            if (result.IsValid)
            {
                var mappeddata = _mapper.Map<AppUserCreateDto>(model);
                var createResponse = await _appUserService.CreateAppUserWithRoleAsync(mappeddata, (int)RoleType.Member);
                return this.ResponseRedirectToAction(createResponse, "Index", "MotherPage");
            }
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            var genderdata = await _genderService.GetAllAsync();
            model.Gender = new SelectList(genderdata.Data, "Id", "Definition", model.GenderId);
            //model.genderid secilmis deyer yadda qalsin deye qoyuldu
            return View(model);
        }


        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(AppUserLogInDto dto)
        {
            return View();
        }

    }
}
