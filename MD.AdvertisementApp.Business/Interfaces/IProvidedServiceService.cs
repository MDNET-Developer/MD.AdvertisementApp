using MD.AdvertisementApp.Dtos.ProvidedServiceDtos;
using MD.AdvertisementApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD.AdvertisementApp.Business.Interfaces
{
    public interface IProvidedServiceService:
         IService<ProvidedServiceCreateDto, ProvidedServiceUpdateDto, ProvidedServiceListDto, ProvidedService>


    {
    }
}
