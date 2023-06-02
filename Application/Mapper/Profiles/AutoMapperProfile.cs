using Application.Data.Dtos;
using AutoMapper;
using Core.Data.Models;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapper.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CountryDTO, Countries>()
                .ForMember(dest => dest.CountryId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Active, opt => opt.MapFrom(src => src.IsActive))
                .ReverseMap();

        }
    }
}
