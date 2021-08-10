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
    public class UserRuleController : ControllerBase
    {
        private readonly IUserRuleService _userRuleService;
        private readonly IMapper _mapper;

        public UserRuleController(IUserRuleService userRuleService,IMapper mapper)
        {
            _userRuleService = userRuleService;
            _mapper = mapper;
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
