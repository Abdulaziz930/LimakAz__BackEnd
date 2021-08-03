using AutoMapper;
using Buisness.Abstract;
using Entities.Dto;
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
    public class CountryContentController : ControllerBase
    {
        private readonly ICountryContentService _countryContentService;
        private readonly IMapper _mapper;

        public CountryContentController(ICountryContentService countryContentService, IMapper mapper)
        {
            _countryContentService = countryContentService;
            _mapper = mapper;
        }

        [HttpGet("getCountryCountent/{languageCode}")]
        public async Task<IActionResult> GetCountryContent([FromRoute] string languageCode)
        {
            if (string.IsNullOrEmpty(languageCode))
                return BadRequest();

            var countryContent = await _countryContentService.GetCountryContentAsync(languageCode);
            if (countryContent == null)
                return NotFound();

            var countryContentDto = _mapper.Map<CountryContentDto>(countryContent);

            return Ok(countryContentDto);
        }
    }
}
