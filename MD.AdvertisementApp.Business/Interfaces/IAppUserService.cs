using MD.AdvertisementApp.Common;
using MD.AdvertisementApp.Dtos.AppUserDtos;
using MD.AdvertisementApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD.AdvertisementApp.Business.Interfaces
{
    public interface IAppUserService:IService<AppUserCreateDto,AppUserUpdateDto,AppUserListDto,AppUser>
    {
        Task<IResponse<AppUserCreateDto>> CreateAppUserWithRoleAsync(AppUserCreateDto dto, int roleId);
    }
}
