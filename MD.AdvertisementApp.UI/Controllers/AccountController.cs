using MD.AdvertisementApp.Business.Interfaces;
using MD.AdvertisementApp.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using FluentValidation;

namespace MD.AdvertisementApp.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IGenderService _genderService;
        private readonly IValidator<UserCreateModel> _userCreateModelValidator;
        public AccountController(IGenderService genderService, IValidator<UserCreateModel> userCreateModelValidator)
        {
            _genderService = genderService;
            _userCreateModelValidator = userCreateModelValidator;
        }

        public async Task<IActionResult> SignUp()
        {
            var genderdata = await _genderService.GetAllAsync();
            var userCreateModel = new UserCreateModel();
            userCreateModel.Gender = new SelectList(genderdata.Data,"Id", "Definition");
            return View(userCreateModel);
        }


        [HttpPost]
        public async Task<IActionResult> SignUp(UserCreateModel model)
        {
            var result = _userCreateModelValidator.Validate(model);
            if (result.IsValid)
            {
                return View();
            }
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
            }
            var genderdata = await _genderService.GetAllAsync();
            model.Gender = new SelectList(genderdata.Data, "Id", "Definition",model.GenderId);
            //model.genderid secilmis deyer yadda qalsin deye qoyuldu
            return View(model);
        }


        }
}
