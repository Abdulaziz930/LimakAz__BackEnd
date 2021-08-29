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
    public class PrivacyController : ControllerBase
    {
        private readonly IPrivacyService _privacyService;
        private readonly IMapper _mapper;

        public PrivacyController(IPrivacyService privacyService,IMapper mapper)
        {
            _privacyService = privacyService;
            _mapper = mapper;
        }

        //GET: api/Privacy/az
        [HttpGet("{languageCode}")]
        public async Task<IActionResult> Get([FromRoute] string languageCode)
        {
            if (string.IsNullOrEmpty(languageCode))
                return BadRequest();

            var privacy = await _privacyService.GetPrivacyAsync(languageCode);
            if (privacy == null)
                return NotFound();

            var privacyDto = _mapper.Map<PrivacyDto>(privacy);

            return Ok(privacyDto);
        }
    }
}
