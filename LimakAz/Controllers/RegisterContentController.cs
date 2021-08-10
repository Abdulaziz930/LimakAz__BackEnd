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
        private readonly IGenderService _genderService;
        private readonly IUserRuleService _userRuleService;
        private readonly IMapper _mapper;

        public RegisterContentController(IRegisterContentService registerContentService
            , IRegisterInformationService registerInformationService, IGenderService genderService
            , IUserRuleService userRuleService, IMapper mapper)
        {
            _registerContentService = registerContentService;
            _registerInformationService = registerInformationService;
            _genderService = genderService;
            _userRuleService = userRuleService;
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

        [HttpGet("getGenders/{langaugeCode}")]
        public async Task<IActionResult> GetGender([FromRoute] string langaugeCode)
        {
            if (string.IsNullOrEmpty(langaugeCode))
                return BadRequest();

            var genders = await _genderService.GetAllGendersAsync(langaugeCode);
            if (genders == null)
                return NotFound();

            var gendersDto = _mapper.Map<List<GenderDto>>(genders);

            return Ok(gendersDto);
        }

        [HttpGet("getUserRule/{langaugeCode}")]
        public async Task<IActionResult> GetUserRule([FromRoute] string langaugeCode)
        {
            if (string.IsNullOrEmpty(langaugeCode))
                return BadRequest();

            var userRule = await _userRuleService.GetUserRuleAsync(langaugeCode);
            if (userRule == null)
                return NotFound();

            var userRuleDto = _mapper.Map<UserRuleDto>(userRule);

            return Ok(userRuleDto);
        }
    }
}
