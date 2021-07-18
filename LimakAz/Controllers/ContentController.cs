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

            var orders = await _orderRepository.GetAllAsync(x => x.Language.Code == languageCode && x.IsDeleted == false, includedProperties);
            if (orders == null)
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

            var widthInputs = await _widthInputRepository
                .GetAllAsync(x => x.Language.Code == languageCode && x.IsDeleted == false, includedProperties);
            if (widthInputs == null)
                return NotFound();

            var weightInputs = await _weightInputRepository
                .GetAllAsync(x => x.Language.Code == languageCode && x.IsDeleted == false, includedProperties);
            if (weightInputs == null)
                return NotFound();

            var lengthInputs = await _lengthInputRepository
                .GetAllAsync(x => x.Language.Code == languageCode && x.IsDeleted == false, includedProperties);
            if (lengthInputs == null)
                return NotFound();

            var heightInputs = await _heightInputRepository
                .GetAllAsync(x => x.Language.Code == languageCode && x.IsDeleted == false, includedProperties);
            if (heightInputs == null)
                return NotFound();

            var boxCountInputs = await _boxCountInputRepository
                .GetAllAsync(x => x.Language.Code == languageCode && x.IsDeleted == false, includedProperties);
            if (boxCountInputs == null)
                return NotFound();

            var sectionsDto = _mapper.Map<List<SectionDto>>(sections);
            var auxiliarySectionsDto = _mapper.Map<List<AuxiliarySectionDto>>(auxiliarySections);
            var authenticationsDto = _mapper.Map<List<AuthenticationDto>>(authentications);
            var ordersDto = _mapper.Map<List<OrderDto>>(orders);
            var calculatorsDto = _mapper.Map<List<CalculatorDto>>(calculators);
            var countriesDto = _mapper.Map<List<CountryDto>>(countries);
            var citiesDto = _mapper.Map<List<CityDto>>(cities);
            var weightsDto = _mapper.Map<List<WeightDto>>(weights);
            var unitsOfLengthsDto = _mapper.Map<List<UnitsOfLengthDto>>(unitsOfLengths);
            var productTypesDto = _mapper.Map<List<ProductTypeDto>>(productTypes);
            var widthInputsDto = _mapper.Map<List<WidthInputDto>>(widthInputs);
            var weightInputsDto = _mapper.Map<List<WeightInputDto>>(weightInputs);
            var lengthInputsDto = _mapper.Map<List<LengthInputDto>>(lengthInputs);
            var heightInputsDto = _mapper.Map<List<HeightInputDto>>(heightInputs);
            var boxCountInputsDto = _mapper.Map<List<BoxCountInputDto>>(boxCountInputs);

            var contentDto = new ContentDto
            {
                SectionsDto = sectionsDto,
                AuxiliarySectionsDto = auxiliarySectionsDto,
                AuthenticationsDto = authenticationsDto,
                OrdersDto = ordersDto,
                CalculatorsDto = calculatorsDto,
                CountriesDto = countriesDto,
                CitiesDto = citiesDto,
                WeightsDto = weightsDto,
                UnitsOfLengthsDto = unitsOfLengthsDto,
                ProductTypesDto = productTypesDto,
                WidthInputsDto = widthInputsDto,
                WeightInputsDto = weightInputsDto,
                LengthInputsDto = lengthInputsDto,
                HeightInputsDto = heightInputsDto,
                BoxCountInputsDto = boxCountInputsDto
            };

            return Ok(contentDto);
        }
    }
}
