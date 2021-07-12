﻿using AutoMapper;
using Entities.Dto;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Advertisement, AdvertisementDto>().ReverseMap();

            CreateMap<Advertisement, AdvertisementDetailDto>()
                .ForMember(x => x.Description, y => y.MapFrom(x => x.AdvertisementDetail.Description))
                .ForMember(x => x.AdvertisementId, y => y.MapFrom(x => x.AdvertisementDetail.AdvertisementId)).ReverseMap();
        }
    }
}
