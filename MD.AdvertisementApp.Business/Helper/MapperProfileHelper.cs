using AutoMapper;
using MD.AdvertisementApp.Business.Mapping.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD.AdvertisementApp.Business.Helper
{
    public static class MapperProfileHelper
    {
        public static List<Profile> GetProfile()
        {
            List<Profile> profiles = new List<Profile>
            {
            new ProvidedServiceProfile(),
           new  AdvertisementProfile(),
           new AppUserProfile(),
           new GenderProfile()
            };

            return profiles;

        }
    }
}
