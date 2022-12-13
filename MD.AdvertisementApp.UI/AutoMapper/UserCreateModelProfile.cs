using AutoMapper;
using MD.AdvertisementApp.Dtos.AppUserDtos;
using MD.AdvertisementApp.UI.Models;

namespace MD.AdvertisementApp.UI.AutoMapper
{
    public class UserCreateModelProfile:Profile
    {
        public UserCreateModelProfile()
        {
            CreateMap<UserCreateModel, AppUserCreateDto>().ReverseMap();
        }
    }
}
