using AutoMapper;
using DataAccess.Interfaces;
using Entities.Dto;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IRepository<Section> _sectionRepository;
        private readonly IRepository<AuxiliarySection> _auxiliarySectionRepository;
        private readonly IRepository<Authentication> _authenticationRepository;
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<Calculator> _calculatorRepository;
        private readonly IRepository<Country> _countryRepository;
        private readonly IRepository<City> _cityRepository;
        private readonly IRepository<Weight> _weightRepository;
        private readonly IRepository<UnitsOfLength> _unitsOfLengthRepository;
        private readonly IRepository<ProductType> _productTypeRepository;
        private readonly IRepository<WidthInput> _widthInputRepository;
        private readonly IRepository<WeightInput> _weightInputRepository;
        private readonly IRepository<LengthInput> _lengthInputRepository;
        private readonly IRepository<HeightInput> _heightInputRepository;
        private readonly IRepository<BoxCountInput> _boxCountInputRepository;
        private readonly IMapper _mapper;

        public ContentController(IRepository<Section> sectionRepository, IRepository<AuxiliarySection> auxiliarySectionRepository,
           IRepository<Authentication> authenticationRepository, IRepository<Order> orderRepository
            , IRepository<Calculator> calculatorRepository,IRepository<Country> countryRepository
            , IRepository<City> cityRepository, IRepository<Weight> weightRepository, IRepository<UnitsOfLength> unitsOfLengthRepository
            , IRepository<ProductType> productTypeRepository, IRepository<WidthInput> widthInputRepository
            , IRepository<WeightInput> weightInputRepository, IRepository<LengthInput> lengthInputRepository
            , IRepository<HeightInput> heightInputRepository, IRepository<BoxCountInput> boxCountInputRepository, IMapper mapper)
        {
            _sectionRepository = sectionRepository;
            _auxiliarySectionRepository = auxiliarySectionRepository;
            _authenticationRepository = authenticationRepository;
            _orderRepository = orderRepository;
            _calculatorRepository = calculatorRepository;
            _countryRepository = countryRepository;
            _cityRepository = cityRepository;
            _weightRepository = weightRepository;
            _unitsOfLengthRepository = unitsOfLengthRepository;
            _productTypeRepository = productTypeRepository;
            _widthInputRepository = widthInputRepository;
            _weightInputRepository = weightInputRepository;
            _lengthInputRepository = lengthInputRepository;
            _heightInputRepository = heightInputRepository;
            _boxCountInputRepository = boxCountInputRepository;
            _mapper = mapper;
        }

        [HttpGet("getContentWebSite/{languageCode}")]
        public async Task<IActionResult> GetContent([FromRoute] string languageCode)
        {
            if (string.IsNullOrEmpty(languageCode))
                return BadRequest();

            var includedProperties = new List<string>
            {
                nameof(Section.Language)
            };

            var sections = await _sectionRepository
                .GetAllAsync(x => x.Language.Code == languageCode && x.IsDeleted == false, includedProperties);
            if (sections == null)
                return NotFound();

            var auxiliarySections = await _auxiliarySectionRepository
                .GetAllAsync(x => x.Language.Code == languageCode && x.IsDeleted == false, includedProperties);
            if (auxiliarySections == null)
                return NotFound();

            var authentications = await _authenticationRepository
                .GetAllAsync(x => x.Language.Code == languageCode && x.IsDeleted == false, includedProperties);
            if (authentications == null)
                return NotFound();

            var order = await _orderRepository.GetAsync(x => x.Language.Code == languageCode && x.IsDeleted == false, includedProperties);
            if (order == null)
                return NotFound();

            var calculators = await _calculatorRepository
                .GetAllAsync(x => x.Language.Code == languageCode && x.IsDeleted == false, includedProperties);
            if (calculators == null)
                return NotFound();

            var countries = await _countryRepository
                .GetAllAsync(x => x.Language.Code == languageCode && x.IsDeleted == false, includedProperties);
            if (countries == null)
                return NotFound();

            var cities = await _cityRepository
                .GetAllAsync(x => x.Language.Code == languageCode && x.IsDeleted == false, includedProperties);
            if (cities == null)
                return NotFound();

            var weights = await _weightRepository
                .GetAllAsync(x => x.Language.Code == languageCode && x.IsDeleted == false, includedProperties);
            if (weights == null)
                return NotFound();

            var unitsOfLengths = await _unitsOfLengthRepository
                .GetAllAsync(x => x.Language.Code == languageCode && x.IsDeleted == false, includedProperties);
            if (unitsOfLengths == null)
                return NotFound();

            var productTypes = await _productTypeRepository
                .GetAllAsync(x => x.Language.Code == languageCode && x.IsDeleted == false, includedProperties);
            if (productTypes == null)
                return NotFound();

            var widthInput = await _widthInputRepository
                .GetAsync(x => x.Language.Code == languageCode && x.IsDeleted == false, includedProperties);
            if (widthInput == null)
                return NotFound();

            var weightInput = await _weightInputRepository
                .GetAsync(x => x.Language.Code == languageCode && x.IsDeleted == false, includedProperties);
            if (weightInput == null)
                return NotFound();

            var lengthInput = await _lengthInputRepository
                .GetAsync(x => x.Language.Code == languageCode && x.IsDeleted == false, includedProperties);
            if (lengthInput == null)
                return NotFound();

            var heightInput = await _heightInputRepository
                .GetAsync(x => x.Language.Code == languageCode && x.IsDeleted == false, includedProperties);
            if (heightInput == null)
                return NotFound();

            var boxCountInput = await _boxCountInputRepository
                .GetAsync(x => x.Language.Code == languageCode && x.IsDeleted == false, includedProperties);
            if (boxCountInput == null)
                return NotFound();

            var sectionsDto = _mapper.Map<List<SectionDto>>(sections);
            var auxiliarySectionsDto = _mapper.Map<List<AuxiliarySectionDto>>(auxiliarySections);
            var authenticationsDto = _mapper.Map<List<AuthenticationDto>>(authentications);
            var orderDto = _mapper.Map<OrderDto>(order);
            var calculatorsDto = _mapper.Map<List<CalculatorDto>>(calculators);
            var countriesDto = _mapper.Map<List<CountryDto>>(countries);
            var citiesDto = _mapper.Map<List<CityDto>>(cities);
            var weightsDto = _mapper.Map<List<WeightDto>>(weights);
            var unitsOfLengthsDto = _mapper.Map<List<UnitsOfLengthDto>>(unitsOfLengths);
            var productTypesDto = _mapper.Map<List<ProductTypeDto>>(productTypes);
            var widthInputDto = _mapper.Map<WidthInputDto>(widthInput);
            var weightInputDto = _mapper.Map<WeightInputDto>(weightInput);
            var lengthInputDto = _mapper.Map<LengthInputDto>(lengthInput);
            var heightInputDto = _mapper.Map<HeightInputDto>(heightInput);
            var boxCountInputDto = _mapper.Map<BoxCountInputDto>(boxCountInput);

            var contentDto = new ContentDto
            {
                SectionsDto = sectionsDto,
                AuxiliarySectionsDto = auxiliarySectionsDto,
                AuthenticationsDto = authenticationsDto,
                OrderDto = orderDto,
                CalculatorsDto = calculatorsDto,
                CountriesDto = countriesDto,
                CitiesDto = citiesDto,
                WeightsDto = weightsDto,
                UnitsOfLengthsDto = unitsOfLengthsDto,
                ProductTypesDto = productTypesDto,
                WidthInputDto = widthInputDto,
                WeightInputDto = weightInputDto,
                LengthInputDto = lengthInputDto,
                HeightInputDto = heightInputDto,
                BoxCountInputDto = boxCountInputDto
            };

            return Ok(contentDto);
        }
    }
}
