using AutoMapper;
using FluentValidation;
using MD.AdvertisementApp.Business.Interfaces;
using MD.AdvertisementApp.Common;
using MD.AdvertisementApp.DataAccess.UnitOfWork;
using MD.AdvertisementApp.Dtos;
using MD.AdvertisementApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD.AdvertisementApp.Business.Services
{
    public class AdvertisementService : Service<AdvertisementCreateDto, AdvertisementUpdateDto, AdvertisementListDto, Advertisement>, IAdvertisementService
    {
        private readonly IMapper _mapper;
        private readonly IUow _uow;
        public AdvertisementService(IMapper mapper, IValidator<AdvertisementCreateDto> createDtoValidator, IValidator<AdvertisementUpdateDto> updateDtoValidator, IUow uow) : base(mapper, createDtoValidator, updateDtoValidator, uow)
        {
            _mapper = mapper;
            _uow= uow;
        }

        public async Task<IResponse<List<AdvertisementListDto>>> GetActivesAsync()
        {
            var data = await _uow.GetRepository<Advertisement>().GetAllAsync(x => x.Status == true, x => x.CreatedDate, Common.Enums.OrderByType.DESC);
            var mappeddata = _mapper.Map<List<AdvertisementListDto>>(data);
            return new Response<List<AdvertisementListDto>>(ResponseType.Succsess, mappeddata);

        }
    }
}
