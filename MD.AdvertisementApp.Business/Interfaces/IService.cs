﻿using MD.AdvertisementApp.Common;
using MD.AdvertisementApp.Dtos.Interfaces;
using MD.AdvertisementApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD.AdvertisementApp.Business.Interfaces
{
    internal interface IService<CreateDto,UpdateDto,ListDto,T>
        where CreateDto : class,IDto,new()
        where UpdateDto : class, IDto, new()
        where ListDto : class, IDto, new()
        where T:BaseEntity
    {
        Task<IResponse<CreateDto>> CreateAsync(CreateDto dto);
        Task<IResponse<UpdateDto>> UpdateAsync(UpdateDto dto);
        Task<IResponse<IDto>> GetByIdAsync<IDto>(int id);
        Task<IResponse> RemoveAsync(int id);
        Task<IResponse<List<ListDto>>> GetAllAsync();
    }
}