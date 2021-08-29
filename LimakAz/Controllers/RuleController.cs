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
    public class RuleController : ControllerBase
    {
        private readonly IRuleService _ruleService;
        private readonly IRuleContentService _ruleContentService;
        private readonly IMapper _mapper;

        public RuleController(IRuleService ruleService,IRuleContentService ruleContentService,IMapper mapper)
        {
            _ruleService = ruleService;
            _ruleContentService = ruleContentService;
            _mapper = mapper;
        }

        //GET: api/Rule/getRules/az
        [HttpGet("getRules/{languageCode}")]
        public async Task<IActionResult> GetRules([FromRoute] string languageCode)
        {
            if (string.IsNullOrEmpty(languageCode))
                return BadRequest();

            var rules = await _ruleService.GetAllRulesAsync(languageCode);
            if (rules == null)
                return NotFound();

            var rulesDto = _mapper.Map<List<RuleDto>>(rules);

            return Ok(rulesDto);
        }

        //GET: api/Rule/getRuleContent/az
        [HttpGet("getRuleContent/{languageCode}")]
        public async Task<IActionResult> GetRuleContent([FromRoute] string languageCode)
        {
            if (string.IsNullOrEmpty(languageCode))
                return BadRequest();

            var ruleContent = await _ruleContentService.GetRuleContentAsync(languageCode);
            if (ruleContent == null)
                return NotFound();

            var ruleContentDto = _mapper.Map<RuleContentDto>(ruleContent);

            return Ok(ruleContentDto);
        }
    }
}
