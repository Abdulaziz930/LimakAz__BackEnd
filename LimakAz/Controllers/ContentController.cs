﻿using AutoMapper;
using DataAccess.Interfaces;
using Entities.Dto;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimakAz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentController : ControllerBase
    {
        private readonly IRepository<Calculator> _calculatorRepository;
        private readonly IRepository<Country> _countryRepository;
        private readonly IRepository<City> _cityRepository;
        private readonly IRepository<Weight> _weightRepository;
        private readonly IRepository<UnitsOfLength> _unitsOfLengthRepository;
        private readonly IRepository<ProductType> _productTypeRepository;
        private readonly IRepository<HowItWork> _howItWorkRepository;
        private readonly IRepository<HowItWorkCard> _howItWorkCardRepository;
        private readonly IRepository<Certificate> _certificateRepository;
        private readonly IRepository<AdvertisimentTitle> _advertisimentTitleRepository;
        private readonly IRepository<Advertisement> _advertisementRepository;
        private readonly IMapper _mapper;

        public ContentController(IRepository<Calculator> calculatorRepository, IRepository<Country> countryRepository
            , IRepository<City> cityRepository, IRepository<Weight> weightRepository, IRepository<UnitsOfLength> unitsOfLengthRepository
            , IRepository<ProductType> productTypeRepository
            , IRepository<HowItWork> howItWorkRepository, IRepository<HowItWorkCard> howItWorkCardRepository
            , IRepository<Certificate> certificateRepository, IRepository<AdvertisimentTitle> advertisimentTitleRepository
            , IRepository<Advertisement> advertisementRepository, IMapper mapper)
        {
            _calculatorRepository = calculatorRepository;
            _countryRepository = countryRepository;
            _cityRepository = cityRepository;
            _weightRepository = weightRepository;
            _unitsOfLengthRepository = unitsOfLengthRepository;
            _productTypeRepository = productTypeRepository;
            _howItWorkRepository = howItWorkRepository;
            _howItWorkCardRepository = howItWorkCardRepository;
            _certificateRepository = certificateRepository;
            _advertisimentTitleRepository = advertisimentTitleRepository;
            _advertisementRepository = advertisementRepository;
            _mapper = mapper;
        }

        [HttpGet("getCalculatorContent/{languageCode}")]
        public async Task<IActionResult> GetCalculatorContent([FromRoute] string languageCode)
        {
            if (string.IsNullOrEmpty(languageCode))
                return BadRequest();

            var includedProperties = new List<string>
            {
                nameof(Section.Language)
            };

            var calculator = await _calculatorRepository
                .GetAsync(x => x.Language.Code == languageCode && x.IsDeleted == false, includedProperties);
            if (calculator == null)
                return NotFound();

            var calculatorDto = _mapper.Map<CalculatorDto>(calculator);

            return Ok(calculatorDto);
        }

        [HttpGet("getContriesContent/{languageCode}")]
        public async Task<IActionResult> GetCountriesContnent([FromRoute] string languageCode)
        {
            if (string.IsNullOrEmpty(languageCode))
                return BadRequest();

            var includedProperties = new List<string>
            {
                nameof(Section.Language)
            };

            var countries = await _countryRepository
                .GetAllAsync(x => x.Language.Code == languageCode && x.IsDeleted == false, includedProperties);
            if (countries == null)
                return NotFound();

            var countriesDto = _mapper.Map<List<CountryDto>>(countries);

            return Ok(countriesDto);
        }

        [HttpGet("getCitiesContent/{languageCode}")]
        public async Task<IActionResult> GetCitiesContnent([FromRoute] string languageCode)
        {
            if (string.IsNullOrEmpty(languageCode))
                return BadRequest();

            var includedProperties = new List<string>
            {
                nameof(Section.Language)
            };

            var cities = await _cityRepository
                .GetAllAsync(x => x.Language.Code == languageCode && x.IsDeleted == false, includedProperties);
            if (cities == null)
                return NotFound();

            var citiesDto = _mapper.Map<List<CityDto>>(cities);

            return Ok(citiesDto);
        }

        [HttpGet("getWeightContent/{languageCode}")]
        public async Task<IActionResult> GetWeightsContnent([FromRoute] string languageCode)
        {
            if (string.IsNullOrEmpty(languageCode))
                return BadRequest();

            var includedProperties = new List<string>
            {
                nameof(Section.Language)
            };

            var weights = await _weightRepository
                .GetAllAsync(x => x.Language.Code == languageCode && x.IsDeleted == false, includedProperties);
            if (weights == null)
                return NotFound();

            var weightsDto = _mapper.Map<List<WeightDto>>(weights);

            return Ok(weightsDto);
        }

        [HttpGet("getUnitsOfLengthContent/{languageCode}")]
        public async Task<IActionResult> GetUnitsOfLengthsContnent([FromRoute] string languageCode)
        {
            if (string.IsNullOrEmpty(languageCode))
                return BadRequest();

            var includedProperties = new List<string>
            {
                nameof(Section.Language)
            };

            var unitsOfLengths = await _unitsOfLengthRepository
                .GetAllAsync(x => x.Language.Code == languageCode && x.IsDeleted == false, includedProperties);
            if (unitsOfLengths == null)
                return NotFound();

            var unitsOfLengthsDto = _mapper.Map<List<UnitsOfLengthDto>>(unitsOfLengths);

            return Ok(unitsOfLengthsDto);
        }

        [HttpGet("getProductTypesContent/{languageCode}")]
        public async Task<IActionResult> GetProductTypesContnent([FromRoute] string languageCode)
        {
            if (string.IsNullOrEmpty(languageCode))
                return BadRequest();

            var includedProperties = new List<string>
            {
                nameof(Section.Language)
            };

            var productTypes = await _productTypeRepository
                .GetAllAsync(x => x.Language.Code == languageCode && x.IsDeleted == false, includedProperties);
            if (productTypes == null)
                return NotFound();

            var productTypesDto = _mapper.Map<List<ProductTypeDto>>(productTypes);

            return Ok(productTypesDto);
        }

        [HttpGet("getHowItWorkContent/{languageCode}")]
        public async Task<IActionResult> GetHowItWorkContnent([FromRoute] string languageCode)
        {
            if (string.IsNullOrEmpty(languageCode))
                return BadRequest();

            var includedProperties = new List<string>
            {
                nameof(Section.Language)
            };

            var howItWork = await _howItWorkRepository
                .GetAsync(x => x.Language.Code == languageCode && x.IsDeleted == false, includedProperties);
            if (howItWork == null)
                return NotFound();

            var howItWorkDto = _mapper.Map<HowItWorkDto>(howItWork);

            return Ok(howItWorkDto);
        }

        [HttpGet("getHowItWorkCardContent/{languageCode}")]
        public async Task<IActionResult> GetHowItWorkCardContnent([FromRoute] string languageCode)
        {
            if (string.IsNullOrEmpty(languageCode))
                return BadRequest();

            var includedProperties = new List<string>
            {
                nameof(Section.Language)
            };

            var howItWorkCard = await _howItWorkCardRepository
                .GetAllAsync(x => x.Language.Code == languageCode && x.IsDeleted == false, includedProperties);
            if (howItWorkCard == null)
                return NotFound();

            var howItWorkCardsDto = _mapper.Map<List<HowItWorkCardDto>>(howItWorkCard);

            return Ok(howItWorkCardsDto);
        }

        [HttpGet("getCertificateContent/{languageCode}")]
        public async Task<IActionResult> GetCertificateContent([FromRoute] string languageCode)
        {
            if (string.IsNullOrEmpty(languageCode))
                return BadRequest();

            var includedProperties = new List<string>
            {
                nameof(Section.Language)
            };

            var certificate = await _certificateRepository
                .GetAsync(x => x.IsDeleted == false && x.Language.Code == languageCode, includedProperties);
            if (certificate == null)
                return NotFound();

            var certificateDto = _mapper.Map<CertificateDto>(certificate);

            return Ok(certificateDto);
        }

        [HttpGet("GetAdvertisimentTitleContent/{languageCode}")]
        public async Task<IActionResult> GetAdvertisimentTitleContent([FromRoute] string languageCode)
        {
            if (string.IsNullOrEmpty(languageCode))
                return BadRequest();

            var includedProperties = new List<string>
            {
                nameof(Language)
            };

            var advertisimentTitle = await _advertisimentTitleRepository
                .GetAsync(x => x.IsDeleted == false && x.Language.Code == languageCode, includedProperties);
            if (advertisimentTitle == null)
                return NotFound();

            var advertisimentTitleDto = _mapper.Map<AdvertisimentTitleDto>(advertisimentTitle);

            return Ok(advertisimentTitleDto);
        }

        [HttpGet("getAdvertisimentContent/{languageCode}/{count}")]
        public async Task<IActionResult> GetAdvertisementContent([FromRoute] string languageCode,int? count = 10)
        {
            if (string.IsNullOrEmpty(languageCode))
                return BadRequest();

            if (count == null)
                return NotFound();

            var includedProperties = new List<string>
            {
                nameof(AdvertisementDetail),
                nameof(Language)
            };

            var advertisiments = await _advertisementRepository
                .GetAll(x => x.IsDeleted == false && x.Language.Code == languageCode, includedProperties)
                .OrderByDescending(x => x.LastModificationDate).Take(count.Value).ToListAsync();
            if (advertisiments == null)
                return NotFound();

            var advertisimentsDto = _mapper.Map<List<AdvertisementDto>>(advertisiments);
            var advertisimentDetailDto = _mapper.Map<List<AdvertisementDetailDto>>(advertisiments);

            var allAdvertisementDto = new AllAdvertisementDto
            {
                AdvertisementDto = advertisimentsDto,
                AdvertisementDetailDto = advertisimentDetailDto
            };

            return Ok(allAdvertisementDto);
        }
    }
}
