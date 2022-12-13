using AutoMapper;
using FluentValidation;
using MD.AdvertisementApp.Business.Extensions;
using MD.AdvertisementApp.Business.Interfaces;
using MD.AdvertisementApp.Common;
using MD.AdvertisementApp.DataAccess.UnitOfWork;
using MD.AdvertisementApp.Dtos.Interfaces;
using MD.AdvertisementApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD.AdvertisementApp.Business.Services
{
    public class Service<CreateDto, UpdateDto, ListDto, T> : IService<CreateDto, UpdateDto, ListDto, T>
        where CreateDto : class, IDto, new()
        where UpdateDto : class, IUpdateDto, new()
        where ListDto : class, IDto, new()
        where T : BaseEntity
    {
        private readonly IMapper _mapper;
        private readonly IValidator<CreateDto> _createDtoValidator;
        private readonly IValidator<UpdateDto> _updateDtoValidator;
        private readonly IUow _uow;

        public Service(IMapper mapper, IValidator<CreateDto> createDtoValidator, IValidator<UpdateDto> updateDtoValidator, IUow uow)
        {
            _mapper = mapper;
            _createDtoValidator = createDtoValidator;
            _updateDtoValidator = updateDtoValidator;
            _uow = uow;
        }

        public async Task<IResponse<CreateDto>> CreateAsync(CreateDto dto)
        {
            var result = _createDtoValidator.Validate(dto);
            if (result.IsValid)
            {
                var createdEntity = _mapper.Map<T>(dto);
                await _uow.GetRepository<T>().Create(createdEntity);
                await _uow.SaveChanges();
                return new Response<CreateDto>(ResponseType.Succsess, dto);
            }
            else
            {
                return new Response<CreateDto>(ResponseType.ValidationError,dto,result.ConvertToCustomValidationError());
            }

        }

        public async Task<IResponse<List<ListDto>>> GetAllAsync()
        {
            var data = await _uow.GetRepository<T>().GetAllAsync();
            var mappeddto = _mapper.Map<List<ListDto>> (data);
            return new Response<List<ListDto>>(ResponseType.Succsess, mappeddto);
        }

        public async Task<IResponse<IDto>> GetByIdAsync<IDto>(int id)
        {
            var data = await _uow.GetRepository<T>().GetByFilter(x => x.Id == id);

            if (data == null)
            {
                return new Response<IDto>(ResponseType.NotFound, $"{id}-ə məxsus verilən tapılmadı");
            }

            else
            {
                var maddpeddto = _mapper.Map<IDto>(data);
                return new Response<IDto>(ResponseType.Succsess, maddpeddto);
            }
;
        }

        public async Task<IResponse> RemoveAsync(int id)
        {
            var data = await _uow.GetRepository<T>().Find(id);
            if(data==null)
            {
                return new Response<IDto>(ResponseType.NotFound, $"{id}-ə məxsus verilən tapılmadı");
            }

            else
            {
                _uow.GetRepository<T>().Remove(data);
                await _uow.SaveChanges();
                return new Response(ResponseType.Succsess);
            }


        }

        public async Task<IResponse<UpdateDto>> UpdateAsync(UpdateDto dto)
        {
            var result = _updateDtoValidator.Validate(dto);

            if (result.IsValid)
            {
                var getdata = await _uow.GetRepository<T>().Find(dto.Id);
                if (getdata == null)
                {
                    return new Response<UpdateDto>(ResponseType.NotFound, $"{dto.Id} -ə aid verilən tapılmadı");
                }
                else
                {
                    var mappedData = _mapper.Map<T>(dto);
                    _uow.GetRepository<T>().Update(mappedData, getdata);
                    await _uow.SaveChanges();
                    return new Response<UpdateDto>(ResponseType.Succsess, dto);
                }
            }
            else
            {
                return new Response<UpdateDto>(ResponseType.Succsess, dto, result.ConvertToCustomValidationError());
            }


            
        }
    }
}
