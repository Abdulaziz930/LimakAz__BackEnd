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
    public class AdvertisementController : ControllerBase
    {
        private readonly IAdvertisementService _advertisementService;

        public AdvertisementController(IAdvertisementService advertisementService)
        {
            _advertisementService = advertisementService;
        }

        [HttpGet("getAdvertisementDetail/{id}/{languageCode}")]
        public async Task<IActionResult> GetAdvertisementDetail([FromRoute] int? id,string languageCode)
        {
            if (id == null)
                return BadRequest();

            if (string.IsNullOrEmpty(languageCode))
                return BadRequest();

            var advertisement = await _advertisementService.GetAdvertisementAsync(id.Value, languageCode);
            if (advertisement == null)
                return NotFound();

            var advertisementDetailDto = new AdvertisementDetailDto
            {
                Id = advertisement.Id,
                Title = advertisement.Title,
                Description = advertisement.AdvertisementDetail.Description,
                Image = advertisement.Image,
                CreationDate = advertisement.CreationDate
            };

            return Ok(advertisementDetailDto);
        }
    }
}
