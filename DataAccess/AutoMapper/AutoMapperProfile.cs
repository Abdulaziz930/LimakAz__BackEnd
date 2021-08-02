using AutoMapper;
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

            CreateMap<Language, LanguageDto>().ReverseMap();

            CreateMap<Calculator, CalculatorDto>().ReverseMap();

            CreateMap<Country, CountryDto>().ReverseMap();

            CreateMap<City, CityDto>().ReverseMap();

            CreateMap<UnitsOfLength, UnitsOfLengthDto>().ReverseMap();

            CreateMap<ProductType, ProductTypeDto>().ReverseMap();

            CreateMap<Weight, WeightDto>().ReverseMap();

            CreateMap<HowItWork, HowItWorkDto>().ReverseMap();

            CreateMap<HowItWorkCard, HowItWorkCardDto>().ReverseMap();

            CreateMap<Certificate, CertificateDto>().ReverseMap();

            CreateMap<CertifcateContent, CertificateContentDto>().ReverseMap();

            CreateMap<AdvertisimentTitle, AdvertisimentTitleDto>().ReverseMap();

            CreateMap<SocialMedia, SocialMediaDto>().ReverseMap();

            CreateMap<ContactContent, ContactContentDto>().ReverseMap();

            CreateMap<ShopContent, ShopContentDto>().ReverseMap();
        }
    }
}
