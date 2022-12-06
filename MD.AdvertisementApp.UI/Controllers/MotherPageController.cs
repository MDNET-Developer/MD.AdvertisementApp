using MD.AdvertisementApp.Business.Interfaces;
using MD.AdvertisementApp.UI.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MD.AdvertisementApp.UI.Controllers
{
    public class MotherPageController : Controller
    {
        private readonly IProvidedServiceService _providedServiceService;

        public MotherPageController(IProvidedServiceService providedServiceService)
        {
            _providedServiceService = providedServiceService;
        }

        public async Task<IActionResult> Index()
        {
            var data =await _providedServiceService.GetAllAsync();
            return this.ResponseView(data);
        }
    }
}
