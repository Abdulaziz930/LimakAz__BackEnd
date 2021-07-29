using AutoMapper;
using Buisness.Abstract;
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
        //private readonly IRepository<Calculator> _calculatorRepository;
        //private readonly IRepository<Country> _countryRepository;
        //private readonly IRepository<City> _cityRepository;
        //private readonly IRepository<Weight> _weightRepository;
        //private readonly IRepository<UnitsOfLength> _unitsOfLengthRepository;
        //private readonly IRepository<ProductType> _productTypeRepository;
        //private readonly IRepository<HowItWork> _howItWorkRepository;
        //private readonly IRepository<HowItWorkCard> _howItWorkCardRepository;
        //private readonly IRepository<Certificate> _certificateRepository;
        //private readonly IRepository<AdvertisimentTitle> _advertisimentTitleRepository;
        //private readonly IRepository<Advertisement> _advertisementRepository;
        //private readonly IRepository<Tariff> _tariffRepository;
        //private readonly IRepository<CountryProductType> _countryProductTypeRepository;
        private readonly IAdvertisementService _advertisementService;
        private readonly IMapper _mapper;

        public ContentController(IAdvertisementService advertisementService,IMapper mapper)
        {
            _advertisementService = advertisementService;
            _mapper = mapper;
        }

        //public ContentController(IRepository<Calculator> calculatorRepository, IRepository<Country> countryRepository
        //    , IRepository<City> cityRepository, IRepository<Weight> weightRepository, IRepository<UnitsOfLength> unitsOfLengthRepository
        //    , IRepository<ProductType> productTypeRepository
        //    , IRepository<HowItWork> howItWorkRepository, IRepository<HowItWorkCard> howItWorkCardRepository
        //    , IRepository<Certificate> certificateRepository, IRepository<AdvertisimentTitle> advertisimentTitleRepository
        //    , IRepository<Advertisement> advertisementRepository,IRepository<Tariff> tariffRepository 
        //    , IRepository<CountryProductType> countryProductTypeRepository,IMapper mapper)
        //{
        //    _calculatorRepository = calculatorRepository;
        //    _countryRepository = countryRepository;
        //    _cityRepository = cityRepository;
        //    _weightRepository = weightRepository;
        //    _unitsOfLengthRepository = unitsOfLengthRepository;
        //    _productTypeRepository = productTypeRepository;
        //    _howItWorkRepository = howItWorkRepository;
        //    _howItWorkCardRepository = howItWorkCardRepository;
        //    _certificateRepository = certificateRepository;
        //    _advertisimentTitleRepository = advertisimentTitleRepository;
        //    _advertisementRepository = advertisementRepository;
        //    _tariffRepository = tariffRepository;
        //    _countryProductTypeRepository = countryProductTypeRepository;
        //    _mapper = mapper;
        //}

        //[HttpGet("getCalculatorContent/{languageCode}")]
        //public async Task<IActionResult> GetCalculatorContent([FromRoute] string languageCode)
        //{
        //    if (string.IsNullOrEmpty(languageCode))
        //        return BadRequest();

        //    var includedProperties = new List<string>
        //    {
        //        nameof(Section.Language)
        //    };

        //    var calculator = await _calculatorRepository
        //        .GetAsync(x => x.Language.Code == languageCode && x.IsDeleted == false, includedProperties);
        //    if (calculator == null)
        //        return NotFound();

        //    var calculatorDto = _mapper.Map<CalculatorDto>(calculator);

        //    return Ok(calculatorDto);
        //}

        //[HttpGet("getContriesContent/{languageCode}")]
        //public async Task<IActionResult> GetCountriesContnent([FromRoute] string languageCode)
        //{
        //    if (string.IsNullOrEmpty(languageCode))
        //        return BadRequest();

        //    var includedProperties = new List<string>
        //    {
        //        nameof(Section.Language)
        //    };

        //    var countries = await _countryRepository
        //        .GetAllAsync(x => x.Language.Code == languageCode && x.IsDeleted == false, includedProperties);
        //    if (countries == null)
        //        return NotFound();

        //    var countriesDto = _mapper.Map<List<CountryDto>>(countries);

        //    return Ok(countriesDto);
        //}

        //[HttpGet("getCitiesContent/{languageCode}")]
        //public async Task<IActionResult> GetCitiesContnent([FromRoute] string languageCode)
        //{
        //    if (string.IsNullOrEmpty(languageCode))
        //        return BadRequest();

        //    var includedProperties = new List<string>
        //    {
        //        nameof(Section.Language)
        //    };

        //    var cities = await _cityRepository
        //        .GetAllAsync(x => x.Language.Code == languageCode && x.IsDeleted == false, includedProperties);
        //    if (cities == null)
        //        return NotFound();

        //    var citiesDto = _mapper.Map<List<CityDto>>(cities);

        //    return Ok(citiesDto);
        //}

        //[HttpGet("getWeightContent/{languageCode}")]
        //public async Task<IActionResult> GetWeightsContnent([FromRoute] string languageCode)
        //{
        //    if (string.IsNullOrEmpty(languageCode))
        //        return BadRequest();

        //    var includedProperties = new List<string>
        //    {
        //        nameof(Section.Language)
        //    };

        //    var weights = await _weightRepository
        //        .GetAllAsync(x => x.Language.Code == languageCode && x.IsDeleted == false, includedProperties);
        //    if (weights == null)
        //        return NotFound();

        //    var weightsDto = _mapper.Map<List<WeightDto>>(weights);

        //    return Ok(weightsDto);
        //}

        //[HttpGet("getUnitsOfLengthContent/{languageCode}")]
        //public async Task<IActionResult> GetUnitsOfLengthsContnent([FromRoute] string languageCode)
        //{
        //    if (string.IsNullOrEmpty(languageCode))
        //        return BadRequest();

        //    var includedProperties = new List<string>
        //    {
        //        nameof(Section.Language)
        //    };

        //    var unitsOfLengths = await _unitsOfLengthRepository
        //        .GetAllAsync(x => x.Language.Code == languageCode && x.IsDeleted == false, includedProperties);
        //    if (unitsOfLengths == null)
        //        return NotFound();

        //    var unitsOfLengthsDto = _mapper.Map<List<UnitsOfLengthDto>>(unitsOfLengths);

        //    return Ok(unitsOfLengthsDto);
        //}

        //[HttpGet("getProductTypesContent/{languageCode}")]
        //public async Task<IActionResult> GetProductTypesContnent([FromRoute] string languageCode)
        //{
        //    if (string.IsNullOrEmpty(languageCode))
        //        return BadRequest();

        //    var includedProperties = new List<string>
        //    {
        //        nameof(Section.Language)
        //    };

        //    var productTypes = await _productTypeRepository
        //        .GetAllAsync(x => x.Language.Code == languageCode && x.IsDeleted == false, includedProperties);
        //    if (productTypes == null)
        //        return NotFound();

        //    var productTypesDto = _mapper.Map<List<ProductTypeDto>>(productTypes);

        //    return Ok(productTypesDto);
        //}

        //[HttpGet("getHowItWorkContent/{languageCode}")]
        //public async Task<IActionResult> GetHowItWorkContnent([FromRoute] string languageCode)
        //{
        //    if (string.IsNullOrEmpty(languageCode))
        //        return BadRequest();

        //    var includedProperties = new List<string>
        //    {
        //        nameof(Section.Language)
        //    };

        //    var howItWork = await _howItWorkRepository
        //        .GetAsync(x => x.Language.Code == languageCode && x.IsDeleted == false, includedProperties);
        //    if (howItWork == null)
        //        return NotFound();

        //    var howItWorkDto = _mapper.Map<HowItWorkDto>(howItWork);

        //    return Ok(howItWorkDto);
        //}

        //[HttpGet("getHowItWorkCardContent/{languageCode}")]
        //public async Task<IActionResult> GetHowItWorkCardContnent([FromRoute] string languageCode)
        //{
        //    if (string.IsNullOrEmpty(languageCode))
        //        return BadRequest();

        //    var includedProperties = new List<string>
        //    {
        //        nameof(Section.Language)
        //    };

        //    var howItWorkCard = await _howItWorkCardRepository
        //        .GetAllAsync(x => x.Language.Code == languageCode && x.IsDeleted == false, includedProperties);
        //    if (howItWorkCard == null)
        //        return NotFound();

        //    var howItWorkCardsDto = _mapper.Map<List<HowItWorkCardDto>>(howItWorkCard);

        //    return Ok(howItWorkCardsDto);
        //}

        //[HttpGet("getCertificateContent/{languageCode}")]
        //public async Task<IActionResult> GetCertificateContent([FromRoute] string languageCode)
        //{
        //    if (string.IsNullOrEmpty(languageCode))
        //        return BadRequest();

        //    var includedProperties = new List<string>
        //    {
        //        nameof(Section.Language)
        //    };

        //    var certificate = await _certificateRepository
        //        .GetAsync(x => x.IsDeleted == false && x.Language.Code == languageCode, includedProperties);
        //    if (certificate == null)
        //        return NotFound();

        //    var certificateDto = _mapper.Map<CertificateDto>(certificate);

        //    return Ok(certificateDto);
        //}

        //[HttpGet("GetAdvertisimentTitleContent/{languageCode}")]
        //public async Task<IActionResult> GetAdvertisimentTitleContent([FromRoute] string languageCode)
        //{
        //    if (string.IsNullOrEmpty(languageCode))
        //        return BadRequest();

        //    var includedProperties = new List<string>
        //    {
        //        nameof(Language)
        //    };

        //    var advertisimentTitle = await _advertisimentTitleRepository
        //        .GetAsync(x => x.IsDeleted == false && x.Language.Code == languageCode, includedProperties);
        //    if (advertisimentTitle == null)
        //        return NotFound();

        //    var advertisimentTitleDto = _mapper.Map<AdvertisimentTitleDto>(advertisimentTitle);

        //    return Ok(advertisimentTitleDto);
        //}

        [HttpGet("getAdvertisimentContent/{languageCode}/{count}")]
        public async Task<IActionResult> GetAdvertisementContent([FromRoute] string languageCode, int? count = 10)
        {
            if (string.IsNullOrEmpty(languageCode))
                return BadRequest();

            if (count == null)
                return NotFound();

            var advertisements = await _advertisementService.GetAllAdvertisementsAsync(count.Value,languageCode);
            if (advertisements == null)
                return NotFound();

            var advertisementsDto = new List<AdvertisementDto>();
            foreach (var advertisement in advertisements)
            {
                var advertisementDetailDto = new AdvertisementDetailDto
                {
                    Id = advertisement.AdvertisementDetail.Id,
                    Description = advertisement.AdvertisementDetail.Description
                };
                var advertisementDto = new AdvertisementDto
                {
                    Id = advertisement.Id,
                    Title = advertisement.Title,
                    Image = advertisement.Image,
                    CreationDate = advertisement.CreationDate,
                    AdvertisementDetailDto = advertisementDetailDto
                };
                advertisementsDto.Add(advertisementDto);
            }

            return Ok(advertisementsDto);
        }

        //[HttpGet("getTariffContent/{languageCode}")]
        //public async Task<IActionResult> GetTariffContent([FromRoute] string languageCode)
        //{
        //    if (string.IsNullOrEmpty(languageCode))
        //        return BadRequest();

        //    var includedProperties = new List<string>
        //    {
        //        nameof(Language),
        //        nameof(ProductType),
        //        nameof(Tariff.Prices),
        //    };

        //    var secondIncludedProperties = new List<string>
        //    {
        //        nameof(Country),
        //        nameof(Country.Language)
        //    };

        //    var tariffs = await _tariffRepository
        //        .GetAll(x => x.Language.Code == languageCode && x.ProductType.Language.Code == languageCode, includedProperties).ToListAsync();

        //    var countryProductType = await _countryProductTypeRepository
        //        .GetAllAsync(x => x.Country.Language.Code == languageCode,secondIncludedProperties);

        //    var tariffDto = new TariffDto
        //    {
        //        Tariffs = tariffs,
        //        CountryProductTypes = countryProductType
        //    };

        //    return Ok(tariffDto);
        //}
    }
}
