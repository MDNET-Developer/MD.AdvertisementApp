using AutoMapper;
using FluentValidation;
using MD.AdvertisementApp.Business.Interfaces;
using MD.AdvertisementApp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD.AdvertisementApp.Business.Services
{
    public class Service<CreateDto, UpdateDto, ListDto> : IService<CreateDto, UpdateDto, ListDto>
        where CreateDto : class, new()
        where UpdateDto : class, new()
        where ListDto : class, new()
    {
        private readonly IMapper _mapper;
        private readonly IValidator<CreateDto> _createDtoValidator;
        public Task<IResponse<CreateDto>> CreateAsync(CreateDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<IResponse<List<ListDto>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IResponse<IDto>> GetByIdAsync<IDto>(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IResponse> RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IResponse<UpdateDto>> UpdateAsync(UpdateDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
