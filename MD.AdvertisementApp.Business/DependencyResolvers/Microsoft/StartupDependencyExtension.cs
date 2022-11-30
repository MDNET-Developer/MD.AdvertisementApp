﻿using AutoMapper;
using FluentValidation;
using MD.AdvertisementApp.Business.ValidationRules;
using MD.AdvertisementApp.DataAccess.Contexts;
using MD.AdvertisementApp.DataAccess.UnitOfWork;
using MD.AdvertisementApp.Dtos.ProvidedServiceDtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD.AdvertisementApp.Business.DependencyResolvers.Microsoft
{
    public static class StartupDependencyExtension
    {
        public static void AddDepencies(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<AdvertisementContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("Local"));
            });


            var mapperConfugration = new MapperConfiguration(opt =>
            {
                //opt.addprofile
            });

            var mapper = mapperConfugration.CreateMapper();
            services.AddSingleton(mapper);

            services.AddScoped<IUow, Uow>();

            services.AddTransient<IValidator<ProvidedServiceCreateDto>, ProvidedServiceCreateDtoValidator>();
            services.AddTransient<IValidator<ProvidedServiceUpdateDto>, ProvidedServiceUpdateDtoValidator>();
        }
    }
}