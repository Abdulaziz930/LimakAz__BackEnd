using AutoMapper;
using Buisness.Abstract;
using Entities.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimakAz.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BalanceContentController : ControllerBase
    {
        private readonly IBalanceContentService _balanceContentService;
        private readonly IMapper _mapper;

        public BalanceContentController(IBalanceContentService balanceContentService,IMapper mapper)
        {
            _balanceContentService = balanceContentService;
            _mapper = mapper;
        }

        [HttpGet("balanceContent/{languageCode}")]
        public async Task<IActionResult> GetBalanceCotent([FromRoute] string languageCode)
        {
            if (string.IsNullOrEmpty(languageCode))
                return BadRequest();

            var balanceContent = await _balanceContentService.GetBalanceContentAsync(languageCode);
            if (balanceContent == null)
                return NotFound();

            var balanceContentDto = _mapper.Map<BalanceContentDto>(balanceContent);

            return Ok(balanceContentDto);
        }
    }
}
