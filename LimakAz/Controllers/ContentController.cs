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
        private readonly IAdvertisementService _advertisementService;
        private readonly ICalculatorService _calculatorService;
        private readonly ICountryService _countryService;
        private readonly ICityService _cityService;
        private readonly IWeightService _weightService;
        private readonly IUnitsOfLengthService _unitsOfLengthService;
        private readonly IProductTypeService _productTypeService;
        private readonly IHowItWorkService _howItWorkService;
        private readonly IHowItWorkCardService _howItWorkCardService;
        private readonly ICertificateService _certificateService;
        private readonly IAdvertisementTitleService _advertisementTitleService;
        private readonly ITariffService _tariffService;
        private readonly ITariffHeaderService _tariffHeaderService;
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContentController(IAdvertisementService advertisementService, ICalculatorService calculatorService
            , ICountryService countryService, ICityService cityService, IWeightService weightService
            , IUnitsOfLengthService unitsOfLengthService, IProductTypeService productTypeService
            , IHowItWorkService howItWorkService, IHowItWorkCardService howItWorkCardService
            , ICertificateService certificateService, IAdvertisementTitleService advertisementTitleService
            , ITariffService tariffService, ITariffHeaderService tariffHeaderService, IContactService contactService, IMapper mapper)
        {
            _advertisementService = advertisementService;
            _calculatorService = calculatorService;
            _countryService = countryService;
            _cityService = cityService;
            _weightService = weightService;
            _unitsOfLengthService = unitsOfLengthService;
            _productTypeService = productTypeService;
            _howItWorkService = howItWorkService;
            _howItWorkCardService = howItWorkCardService;
            _certificateService = certificateService;
            _advertisementTitleService = advertisementTitleService;
            _tariffService = tariffService;
            _contactService = contactService;
            _tariffHeaderService = tariffHeaderService;
            _mapper = mapper;
        }

        [HttpGet("getCalculatorContent/{languageCode}")]
        public async Task<IActionResult> GetCalculatorContent([FromRoute] string languageCode)
        {
            if (string.IsNullOrEmpty(languageCode))
                return BadRequest();

            var calculator = await _calculatorService.GetCalculatorAsync(languageCode);
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

            var countries = await _countryService.GetAllCountriesAsync(languageCode);
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

            var cities = await _cityService.GetAllCitiesAsync(languageCode);
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

            var weights = await _weightService.GetAllWeightsAsync(languageCode);
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

            var unitsOfLengths = await _unitsOfLengthService.GetAllUnitsOfLengthAsync(languageCode);
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

            var productTypes = await _productTypeService.GetAllProductTypesAsync(languageCode);
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

            var howItWork = await _howItWorkService.GetHowItWorkAsync(languageCode);
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

            var howItWorkCard = await _howItWorkCardService.GetAllHowItWorkCardsAsync(languageCode);
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

            var certificate = await _certificateService.GetCertificateAsync(languageCode);
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

            var advertisimentTitle = await _advertisementTitleService.GetAdvertisementTitleAsync(languageCode);
            if (advertisimentTitle == null)
                return NotFound();

            var advertisimentTitleDto = _mapper.Map<AdvertisimentTitleDto>(advertisimentTitle);

            return Ok(advertisimentTitleDto);
        }

        [HttpGet("getAdvertisimentContent/{languageCode}/{count}")]
        public async Task<IActionResult> GetAdvertisementContent([FromRoute] string languageCode, int? count = 10)
        {
            if (string.IsNullOrEmpty(languageCode))
                return BadRequest();

            if (count == null)
                return NotFound();

            var advertisements = await _advertisementService.GetAllAdvertisementsAsync(count.Value, languageCode);
            if (advertisements == null)
                return NotFound();

            var advertisementsDto = _mapper.Map<List<AdvertisementDto>>(advertisements);

            return Ok(advertisementsDto);
        }

        [HttpGet("getTariffContent/{languageCode}")]
        public async Task<IActionResult> GetTariffContent([FromRoute] string languageCode)
        {
            if (string.IsNullOrEmpty(languageCode))
                return BadRequest();

            var productTypes = await _productTypeService.GetAllProductTypesWithTariffAsync(languageCode);
            if (productTypes == null)
                return NotFound();

            var tariffContents = await _tariffService.GetMultiLanguageTrariffsAsync(languageCode);
            if (tariffContents == null)
                return NotFound();

            var tariffContentsDto = new List<TariffContentDto>();
            foreach (var countryItem in tariffContents)
            {
                var productTypesDto = new List<ProductTypeContentDto>();
                foreach (var productType in productTypes)
                {
                    var tariffs = await _tariffService.GetAllTariffContentsAsync(productType.Id,countryItem.Id);
                    if (tariffs == null)
                        return NotFound();

                    var tariffsDto = _mapper.Map<List<TariffDto>>(tariffs);
                    var productTypeDto = new ProductTypeContentDto
                    {
                        Id = productType.Id,
                        Name = productType.Name,
                        Value = productType.Value,
                        TariffsDto = tariffsDto
                    };
                    productTypesDto.Add(productTypeDto);
                }
                var tariffContentDto = new TariffContentDto
                {
                    Id = countryItem.Id,
                    ConutryName = countryItem.Name,
                    CountryValue = countryItem.Value,
                    TabTitle = countryItem.Tab.Title,
                    TabDescription = countryItem.Tab.Description,
                    TabImage = countryItem.Tab.TabImage,
                    ProductTypesDto = productTypesDto
                };
                tariffContentsDto.Add(tariffContentDto);
            }
            
            return Ok(tariffContentsDto);
        }

        [HttpGet("getTariffHeaderContent/{languageCode}")]
        public async Task<IActionResult> GetTariffHeaderContent([FromRoute] string languageCode)
        {
            if (string.IsNullOrEmpty(languageCode))
                return BadRequest();

            var tariffHeader = await _tariffHeaderService.GetTariffHeaderAsync(languageCode);
            if (tariffHeader == null)
                return NotFound();

            var tariffHeaderDto = _mapper.Map<TariffHeaderDto>(tariffHeader);

            return Ok(tariffHeaderDto);
        }

        [HttpGet("getContactContent/{languageCode}")]
        public async Task<IActionResult> GetContactContent([FromRoute] string languageCode)
        {
            if (string.IsNullOrEmpty(languageCode))
                return BadRequest();

            var contact = await _contactService.GetContactAsync(languageCode);
            if (contact == null)
                return NotFound();

            var contactDto = new ContactDto
            {
                Id = contact.Contacts.FirstOrDefault().Id,
                Location = contact.Contacts.FirstOrDefault().Location
            };

            return Ok(contactDto);
        }
    }
}
