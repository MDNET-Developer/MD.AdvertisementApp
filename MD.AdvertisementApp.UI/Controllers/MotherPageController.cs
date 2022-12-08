using MD.AdvertisementApp.Business.Interfaces;
using MD.AdvertisementApp.UI.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MD.AdvertisementApp.UI.Controllers
{
    public class MotherPageController : Controller
    {
        private readonly IProvidedServiceService _providedServiceService;
        private readonly IAdvertisementService _advertisementService;
        public MotherPageController(IProvidedServiceService providedServiceService, IAdvertisementService advertisementService)
        {
            _providedServiceService = providedServiceService;
            _advertisementService = advertisementService;
        }

        public async Task<IActionResult> Index()
        {
            var data =await _providedServiceService.GetAllAsync();
            return this.ResponseView(data);
        }

        public async Task<IActionResult> HR()
        {
            var data = await _advertisementService.GetActivesAsync();
            return this.ResponseView(data);
        }
    }
}
