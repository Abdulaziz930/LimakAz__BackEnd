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
    public class AddressContentController : ControllerBase
    {
        private readonly IAddressContentService _addressContentService;
        private readonly IMapper _mapper;

        public AddressContentController(IAddressContentService addressContentService, IMapper mapper)
        {
            _addressContentService = addressContentService;
            _mapper = mapper;
        }

        [HttpGet("getAddressContent/{languageCode}")]
        public async Task<IActionResult> GetAddressContent([FromRoute] string languageCode)
        {
            if (string.IsNullOrEmpty(languageCode))
                return BadRequest();

            var addressConents = await _addressContentService.GetAddressContentsAsync(languageCode);
            if (addressConents == null)
                return NotFound();

            var addressContetsDto = new List<AddressContentDto>();
            foreach (var item in addressConents)
            {
                var addressesDto = new List<AddressDto>();
                foreach (var address in item.AddressContents)
                {
                    var addressDto = new AddressDto
                    {
                        Id = address.Id,
                        Title = address.Title,
                        Content = address.Content
                    };
                    addressesDto.Add(addressDto);
                }
                var addressContentDto = new AddressContentDto
                {
                    Id = item.Id,
                    Country = item.Name,
                    CountryValue = item.Value,
                    Addresses = addressesDto
                };
                addressContetsDto.Add(addressContentDto);
            }

            return Ok(addressContetsDto);
        }
    }
}
