using AutoMapper;
using DataAccess;
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
    public class AdvertisementsController : ControllerBase
    {
        private readonly IRepository<Advertisement> _repository;
        private readonly IMapper _mapper;

        public AdvertisementsController(IRepository<Advertisement> repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("count/{count}")]
        public async Task<IActionResult> Get([FromRoute] int count = 10)
        {
            var advertisements = await _repository.GetAll(x => x.IsDeleted == false,null).Take(count).ToListAsync();

            var advertisementDto = _mapper.Map<List<AdvertisementDto>>(advertisements);

            return Ok(advertisementDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int? id)
        {
            if (id == null)
                return BadRequest();

            var includedProperties = new List<string>
            {
                nameof(Advertisement.AdvertisementDetail)
            };

            var advertisementDetail = await _repository
                .GetAsync(x => x.IsDeleted == false && x.AdvertisementDetail.AdvertisementId == id, includedProperties);
            if (advertisementDetail == null)
                return NotFound();

            var advertisementDetailDto = _mapper.Map<AdvertisementDetailDto>(advertisementDetail);

            return Ok(advertisementDetailDto);
        }
    }
}
