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
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;

        public AboutController(IAboutService aboutService,IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper = mapper;
        }

        [HttpGet("{languageCode}")]
        public async Task<IActionResult> Get([FromRoute] string languageCode)
        {
            if (string.IsNullOrEmpty(languageCode))
                return BadRequest();

            var about = await _aboutService.GetAboutAsync(languageCode);
            if (about == null)
                return NotFound();

            var aboutDto = _mapper.Map<AboutDto>(about);

            return Ok(aboutDto);
        }
    }
}
