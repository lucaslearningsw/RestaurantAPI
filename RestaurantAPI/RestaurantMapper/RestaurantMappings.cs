using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using RestaurantAPI.Models;
using RestaurantAPI.Models.Dtos;

namespace RestaurantAPI.RestaurantMapper
{
    public class RestaurantMappings : Profile
    {
        public RestaurantMappings()
        {
            CreateMap<Plate, PlateDto>().ReverseMap();
        }
    }
}

