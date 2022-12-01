using MD.AdvertisementApp.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MD.AdvertisementApp.UI.Controllers
{
    public class MotherPageController : Controller
    {
        private readonly IProvidedServiceService _providedServiceService;

        public MotherPageController(IProvidedServiceService providedServiceService)
        {
            _providedServiceService = providedServiceService;
        }

        public IActionResult Index()
        {
            var data = _providedServiceService.GetAllAsync();
            return View();
        }
    }
}
