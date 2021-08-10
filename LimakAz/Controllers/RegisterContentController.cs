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
    public class RegisterContentController : ControllerBase
    {
        private readonly IRegisterContentService _registerContentService;
        private readonly IRegisterInformationService _registerInformationService;
        private readonly IMapper _mapper;

        public RegisterContentController(IRegisterContentService registerContentService
            , IRegisterInformationService registerInformationService, IMapper mapper)
        {
            _registerContentService = registerContentService;
            _registerInformationService = registerInformationService;
            _mapper = mapper;
        }

        [HttpGet("getRegisterContent/{languageCode}")]
        public async Task<IActionResult> GetRegisterContent([FromRoute] string languageCode)
        {
            if (string.IsNullOrEmpty(languageCode))
                return BadRequest();

            var registerContent = await _registerContentService.GetRegisterContentAsync(languageCode);
            if (registerContent == null)
                return NotFound();

            var registerContentDto = _mapper.Map<RegisterContentDto>(registerContent);

            return Ok(registerContentDto);
        }

        [HttpGet("getRegisterInformation/{languageCode}")]
        public async Task<IActionResult> GetRegisterInformation([FromRoute] string languageCode)
        {
            if (string.IsNullOrEmpty(languageCode))
                return BadRequest();

            var registerınformation = await _registerInformationService.GetRegisterInformationAsync(languageCode);
            if (registerınformation == null)
                return NotFound();

            var registerInformationDto = _mapper.Map<RegisterInformationDto>(registerınformation);

            return Ok(registerInformationDto);
        }
    }
}
